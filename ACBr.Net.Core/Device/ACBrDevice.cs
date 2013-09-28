using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBr.Net.Core
{

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("29A5B338-6E3C-47D3-AA31-91965AEF568C")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif    

    public sealed class ACBrDevice : IDisposable
    {
        #region Constantes

        const string ACBrDeviceAtivarPortaException    = "Porta não definida\\incorreta";
        const string ACBrDeviceAtivarException         = "Erro abrindo: ";
        const string ACBrDeviceSetBaudException        = "Valor deve estar na faixa de 50 a 4000000.\nNormalmente os equipamentos Seriais utilizam: 9600";
        const string ACBrDeviceSetDataException        = "Valor deve estar na faixa de 5 a 8.\nNormalmente os equipamentos Seriais utilizam: 7 ou 8";
        const string ACBrDeviceSetPortaException       = "Não é possível mudar a Porta com o Dispositivo Ativo";
        const string ACBrDeviceEnviaStrThreadException = "Erro gravando em: ";       

        #endregion Constantes

        #region Field

        private SerialPort COMPort;
        private string port;
        private int timeout;
        private int baud;
        private int data;   
        private bool hard;
        private bool soft;
        private int interval;
        private Handshake hand;
        private StopBits stop;
        private Parity parity;

        #endregion Field

        #region Constructor

        public ACBrDevice()
		{
            port = string.Empty;
            Ativo = false;
            timeout = 3;
            parity = Parity.None;
            hard = false;
            soft = false;
            data = 8;
            baud = 9600;
            ProcessMessages = true;
            SendBytesCount = 0;
            interval = 0;
        }

		#endregion Constructor

		#region Properties

        public bool Ativo { get; private set; }

        public string Porta { get; set; }

        public int Baud 
        {
            get
            {
                return baud;
            }
            set
            {
                SetBaund(value);
            }
        }

        public int DataBits
        {
            get
            {
                return data;
            }
            set
            {
                SetData(value);
            }
        }

        public Parity Parity 
        { 
            get
            {
                return parity;
            }
            set
            {
                SetParity(value);
            }
        }

        public StopBits StopBits
        {
            get
            {
                return stop;
            }
            set
            {
                SetStop(value);
            }
        }

        public Handshake HandShake
        {
            get
            {
                return hand;
            }
            set
            {
                SetHandshake(value);
            }
        }

        public bool HardFlow
        {
            get
            {
                return hard;
            }
            set
            {
                SetHardflow(value);
            }
        }

        public bool SoftFlow
        {
            get
            {
                return soft;
            }
            set
            {
                SetSoftflow(value);
            }
        }

        public int TimeOut
        {
            get
            {
                return timeout;
            }
            set
            {
                SetTimeout(value);
            }
        }

        public int SendBytesCount { get; set; }

        public int SendBytesInterval
        {
            get
            {
                return interval;
            }
            set
            {
                SetBytesInterval(value);
            }
        }

        public bool ProcessMessages { get; set; }

		#endregion Properties

        #region SetGetMethods

        private void SetPorta(string value)
        {
            if (Ativo)
                throw new ACBrException(ACBrDeviceSetPortaException);

            if (port.Equals(value))
                return;

            port = value;
        }

        private void SetHandshake(Handshake value)
        {
            if (value == Handshake.RequestToSend)
                hard = true;
            else if (value == Handshake.XOnXOff)
                soft = true;

            hand = value;
        }

        private void SetHardflow(bool value)
        {
            if (value)
                hand = Handshake.RequestToSend;
            else
                hand = Handshake.None;

            hard = value;
        }

        private void SetSoftflow(bool value)
        {
            if (value)
                hand = Handshake.XOnXOff;
            else
                hand = Handshake.None;

            soft = true;
        }

        private void SetBaund(int value)
        {
            if (Ativo)
                return;

            if (baud == value)
                return;

            if (value < 50 || value > 4000000)
                throw new ACBrException(ACBrDeviceSetBaudException);

            baud = value;
        }

        private void SetData(int value)
        {
            if (Ativo)
                return;

            if (data == value)
                return;

            if (value < 5 || value > 8)
                throw new ACBrException(ACBrDeviceSetDataException);

            data = value;
        }

        private void SetTimeout(int value)
        {
            if (timeout == value)
                return;

            if (value < 1)
                value = 1;

            timeout = value;

            if (COMPort != null)
            {
                COMPort.WriteTimeout = timeout * 1000;
                COMPort.ReadTimeout = timeout * 1000;
            }
        }

        private void SetBytesInterval(int value)
        {
            if (interval == value)
                return;

            if (interval < 0)
                value = 0;

            interval = value;
        }

        private void SetStop(StopBits value)
        {
            if (stop == value)
                return;

            stop = value;

            if (COMPort != null)
                COMPort.StopBits = stop;
        }

        private void SetParity(Parity value)
        {
            if (parity == value)
                return;

            parity = value;

            if (COMPort != null)
                COMPort.Parity = parity;
        }

        #endregion SetGetMethods

        #region Methods

        public void Ativar()
        {
            try
            {
                if (Ativo)
                    throw new ACBrException("Dispositivo já esta ativo");

                if (Porta.ToLower().Substring(0, 3).Equals("COM"))
                    throw new ACBrException(ACBrDeviceAtivarPortaException);

                ConfigurarSerial();
                COMPort.Open();
                Ativo = true;
            }
            catch (Exception ex)
            {
                var msg = string.Format("{0}{1}", ACBrDeviceAtivarException, port);
                throw new ACBrException(msg, ex);
            }
        }

        public void Desativar()
        {
            try
            {
                if (!Ativo)
                    throw new ACBrException("Dispositivo não está ativo");

                COMPort.Close();
                COMPort.Dispose();
                Ativo = false;
            }
            catch (Exception ex)
            {
                throw new ACBrException("Erro ao desativar o dispositivo", ex);
            }
        }

        public bool EmLinha(int timeout = 1)
        {
            if(!Ativo)
                return false;

            if (timeout < 1)
                timeout = 1;

            bool retorno = false;
            var limite = DateTime.Now.AddSeconds(timeout);
            while (limite > DateTime.Now || retorno)
            {
                if(hand == Handshake.RequestToSend)
                    retorno = COMPort.CtsHolding;
                if (hand == Handshake.XOnXOff)
                    retorno = COMPort.CDHolding;

                if (!retorno)
                {
                    if (ProcessMessages)
                        Application.DoEvents();

                    Thread.Sleep(10);
                }
            }

            return retorno;
        }

        public void EnviaString(string value)
        {
            int i = 0;
            int max = value.Length;
            int nbytes = SendBytesCount;

            if (nbytes == 0)
                nbytes = max;

            while (i <= max)
            {
                COMPort.Write(value.Substring(i, nbytes));

                if(SendBytesInterval > 0)
                    Thread.Sleep(SendBytesInterval);

                i += nbytes;
            }
        }

        private void ConfigurarSerial()
        {            
            if(COMPort == null)
                COMPort = new SerialPort();
            
            if(COMPort.IsOpen)
                return;

            COMPort.PortName = port;
            COMPort.ReadTimeout = timeout * 1000;
            COMPort.WriteTimeout = timeout * 1000;
            COMPort.BaudRate = baud;
            COMPort.DataBits = data;
            COMPort.Parity = parity;
            COMPort.StopBits = stop;
            COMPort.Handshake = hand;
            COMPort.ErrorReceived += COMPort_ErrorReceived;
            COMPort.DataReceived += COMPort_DataReceived;
        }

        #endregion Methods

        #region Eventhandlers

        void COMPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            var sp = (SerialPort)sender;            
        }

        void COMPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
        }

        #endregion Eventhandlers

        #region Dispose Methods

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }

            if (COMPort != null)
            {
                if (Ativo)
                    COMPort.Close();

                COMPort.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion Dispose Methods
    }
}