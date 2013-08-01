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
	public class ACBrDevice
    {
        #region Constantes

        const string ACBrDeviceAtivarPortaException    = "Porta não definida";
        const string ACBrDeviceAtivarException         = "Erro abrindo: ";
        const string ACBrDeviceSetBaudException        = "Valor deve estar na faixa de 50 a 4000000." + Environment.NewLine + 
                                                         "Normalmente os equipamentos Seriais utilizam: 9600";
        const string ACBrDeviceSetDataException        = "Valor deve estar na faixa de 5 a 8." + Environment.NewLine + 
                                                         "Normalmente os equipamentos Seriais utilizam: 7 ou 8";
        const string ACBrDeviceSetPortaException       = "Não é possível mudar a Porta com o Dispositivo Ativo";
        const string ACBrDeviceEnviaStrThreadException = "Erro gravando em: ";       

        #endregion Constantes

        #region Field

        private SerialPort COMPort;
        private string port;
        private int baud;
        private int data;   
        private bool hard;
        private bool soft;
        private Handshake hand;

        #endregion Field

        #region Constructor

        protected internal ACBrDevice()
		{
            Porta = string.Empty;
            Ativo = false;
            TimeOut = 3;
            Parity = Parity.None;
            HardFlow = false;
            SoftFlow = false;
            DataBits = 8;
            Baud = 9600;
            ProcessMessages = true;
            SendBytesCount = 0;
            SendBytesInterval = 0;
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

        public Parity Parity { get; set; }

        public StopBits StopBits { get; set; }

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

        public int TimeOut { get; set; }

        public int SendBytesCount { get; set; }

        public int SendBytesInterval { get; set; }

        public bool ProcessMessages { get; set; }

		#endregion Properties

        #region SetMethods

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

        #endregion SetMethods

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

            COMPort.PortName = Porta;
            COMPort.ReadTimeout = TimeOut * 100;
            COMPort.WriteTimeout = TimeOut * 100;
            COMPort.BaudRate = Baud;
            COMPort.DataBits = DataBits;
            COMPort.Parity = Parity;
            COMPort.StopBits = StopBits;
            COMPort.Handshake = HandShake;
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
    }
}