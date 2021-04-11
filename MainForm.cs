using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGaugeApp
{
    public partial class PHeatingSystem : Form
    {
        bool isConnected = false;
        String[] ports;
        int aGauge1T = 100;
        int aGauge2T = 100;
        int aGauge3T = 100;
        int aGauge4T = 100;
        int aGauge5T = 100;

        public PHeatingSystem()
        {
            InitializeComponent();
            GetAvailableComPorts();
            // Cmbaudr.SelectedIndex = 3;
            Do_connect();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        void GetAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
            AvailableSerialPorts.Items.Clear();
            AvailableSerialPorts.SelectedIndex = -1;
            foreach (string port in ports)
            {
                AvailableSerialPorts.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    AvailableSerialPorts.SelectedItem = ports[0];
                }
            }

        }
        private void AGauge4_ValueInRangeChanged(object sender, AGauge.ValueInRangeChangedEventArgs e)
        {
            //Tlabel2.Text = e.valueInRange.ToString();
            if (e.valueInRange == 0)
            {
                // Tlabel4.Text = "in range 0";
            }
            else if (e.valueInRange == 1)
            {
                //Tlabel4.Text = "in range 1";
            }
            else if (e.valueInRange == 2)
            {
                //Tlabel4.Text = "in range 2 ";
            }
            else if (e.valueInRange == 3)
            {
                //Tlabel4.Text = "in range 3";
            }
            else if (e.valueInRange == 4)
            {
                //Tlabel4.Text = "in range 4";
            }
            else
            {
                //Tlabel4.Text = " not in a range";
            }

        }
        private void AGauge1_ValueInRangeChanged(object sender, AGauge.ValueInRangeChangedEventArgs e)
        {
            //Tlabel3.Text = e.valueInRange.ToString();
            if (e.valueInRange == 0)
            {
                //Tlabel0.Text = "in range 0";
            }
            else if (e.valueInRange == 1)
            {
                //Tlabel0.Text = "in range 1";
            }
            else if (e.valueInRange == 2)
            {
                //Tlabel0.Text = "in range 2 ";
            }
            else if (e.valueInRange == 3)
            {
                //Tlabel0.Text = "in range 3";
            }
            else if (e.valueInRange == 4)
            {
                //Tlabel0.Text = "in range 4";
            }
            else
            {
                //Tlabel0.Text = " not in a range";
            }
        }
        private void Ttimer1_Tick(object sender, EventArgs e)
        {
            if (DserialPort1.IsOpen == true)
            {
                label2.Text = "Port open";
                Bconnect.Enabled = false;
                Bdissconect.Enabled = true;
            }
            else
            {
                label2.Text = "Port closed";
                Bconnect.Enabled = true;
                Bdissconect.Enabled = false;
            }
            aGauge1T -= 1;
            aGauge2T -= 1;
            aGauge3T -= 1;
            aGauge4T -= 1;
            aGauge5T -= 1;
            if (aGauge1T <= 0)
            {
                aGauge1.Value = -125;
                Agauge1_temp.Text = "-125";
            }
            if (aGauge2T <= 0)
            {
                aGauge2.Value = -125;
                Agauge2_temp.Text = "-125";
            }
            if (aGauge3T <= 0)
            {
                aGauge3.Value = -125;
                Agauge3_temp.Text = "-125";
            }

            if (aGauge4T <= 0)
            {
                aGauge4.Value = -125;
                Agauge4_temp.Text = "-125";
            }

            if (aGauge5T <= 0)
            {
                aGauge5.Value = -125;
                Agauge5_temp.Text = "-125";
            }


            if (aGauge3.Value >= 100)
            {

            }
            if (aGauge4.Value >= 100)
            {

            }

            if (aGauge5.Value >= 100)
            {

            }
            if (aGauge1.Value >= 100)
            {

            }
        }
        private void Bscanports_Click(object sender, EventArgs e)
        {
            GetAvailableComPorts();
        }

        private void Bconnect_Click(object sender, EventArgs e)
        {
            Do_connect();
        }

        private void Bdissconect_Click(object sender, EventArgs e)
        {
            isConnected = false;
            ;// well shit
            DserialPort1.Close();
        }

        private void DserialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string inputData;
                inputData = DserialPort1.ReadLine();
                //textBox1.BeginInvoke(new Action(() => { textBox1.Text += inputData; }));
                //textBox1.BeginInvoke(new Action(() => { textBox1.Text += "\n\r"; }));
                bool canConvert;
                string[] indata1 = inputData.Split(':');

                if (Properties.Settings.Default.GsensorID1 == indata1[0])
                {
                    Properties.Settings.Default.GsensorID1 = indata1[1];
                    GsensorID1.BeginInvoke(new Action(() => { GsensorID1.Text = indata1[1]; }));
                }
                if (Properties.Settings.Default.GsensorID2 == indata1[0])
                {
                    Properties.Settings.Default.GsensorID2 = indata1[1];
                    GsensorID2.BeginInvoke(new Action(() => { GsensorID2.Text = indata1[1]; }));
                }
                if (Properties.Settings.Default.GsensorID3 == indata1[0])
                {
                    Properties.Settings.Default.GsensorID3 = indata1[1];
                    GsensorID3.BeginInvoke(new Action(() => { GsensorID3.Text = indata1[1]; }));
                }
                if (Properties.Settings.Default.GsensorID4 == indata1[0])
                {
                    Properties.Settings.Default.GsensorID4 = indata1[1];
                    GsensorID4.BeginInvoke(new Action(() => { GsensorID4.Text = indata1[1]; }));
                }
                if (Properties.Settings.Default.GsensorID5 == indata1[0])
                {
                    Properties.Settings.Default.GsensorID5 = indata1[1];
                    GsensorID5.BeginInvoke(new Action(() => { GsensorID5.Text = indata1[1]; }));
                }

                // code for gauge update
                if (Properties.Settings.Default.GsensorID1 == indata1[1])
                {
                    canConvert = float.TryParse(indata1[2], out float number2);
                    if (canConvert == true)
                        aGauge1.BeginInvoke(new Action(() => { aGauge1.Value = number2; }));
                    Agauge1_temp.BeginInvoke(new Action(() => { Agauge1_temp.Text = indata1[2]; }));
                    Tlabel0.BeginInvoke(new Action(() => { Tlabel0.Text = inputData; }));
                    aGauge1T = 100;
                }
                else if (Properties.Settings.Default.GsensorID2 == indata1[1])
                {
                    canConvert = float.TryParse(indata1[2], out float number2);
                    if (canConvert == true)
                        aGauge2.BeginInvoke(new Action(() => { aGauge2.Value = number2; }));
                    Agauge2_temp.BeginInvoke(new Action(() => { Agauge2_temp.Text = indata1[2]; }));
                    Tlabel1.BeginInvoke(new Action(() => { Tlabel1.Text = inputData; }));
                    aGauge2T = 100;
                }
                else if (Properties.Settings.Default.GsensorID3 == indata1[1])
                {
                    canConvert = float.TryParse(indata1[2], out float number2);
                    if (canConvert == true)
                        aGauge3.BeginInvoke(new Action(() => { aGauge3.Value = number2; }));
                    Agauge3_temp.BeginInvoke(new Action(() => { Agauge3_temp.Text = indata1[2]; }));
                    Tlabel2.BeginInvoke(new Action(() => { Tlabel2.Text = inputData; }));
                    aGauge3T = 100;
                }
                else if (Properties.Settings.Default.GsensorID4 == indata1[1])
                {
                    canConvert = float.TryParse(indata1[2], out float number2);
                    if (canConvert == true)
                        aGauge4.BeginInvoke(new Action(() => { aGauge4.Value = number2; }));
                    Agauge4_temp.BeginInvoke(new Action(() => { Agauge4_temp.Text = indata1[2]; }));
                    Tlabel3.BeginInvoke(new Action(() => { Tlabel3.Text = inputData; }));
                    aGauge4T = 100;
                }
                else if (Properties.Settings.Default.GsensorID5 == indata1[1])
                {
                    canConvert = float.TryParse(indata1[2], out float number2);
                    if (canConvert == true)
                        aGauge5.BeginInvoke(new Action(() => { aGauge5.Value = number2; }));
                    Agauge5_temp.BeginInvoke(new Action(() => { Agauge5_temp.Text = indata1[2]; }));
                    Tlabel4.BeginInvoke(new Action(() => { Tlabel4.Text = inputData; }));
                    aGauge5T = 100;
                }



            }
            catch (Exception)
            {
                //HandleDisconnect(client);
            }

        }

        private void DserialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

        }

        private void Do_connect()
        {
            if (!isConnected)
            {
                string selectedPort = "";
                int baudr = 0;
                isConnected = true;
                if (AvailableSerialPorts.GetItemText(AvailableSerialPorts.SelectedItem) != "")
                {
                    selectedPort = AvailableSerialPorts.GetItemText(AvailableSerialPorts.SelectedItem);
                }
                if (Cmbaudr.GetItemText(Cmbaudr.SelectedItem) != "")
                {
                    baudr = Int32.Parse(Cmbaudr.GetItemText(Cmbaudr.SelectedItem));
                }

                if ((selectedPort != "") && (baudr != 0))
                {
                    if (SerialPort.GetPortNames().ToList().Contains(selectedPort))
                    {
                        Properties.Settings.Default.baurdr = Cmbaudr.GetItemText(Cmbaudr.SelectedItem);
                        Properties.Settings.Default.ComPort = selectedPort;
                        DserialPort1.PortName = selectedPort;
                        DserialPort1.BaudRate = baudr;
                        if (DserialPort1.IsOpen == false)
                        {
                            try
                            {
                                DserialPort1.Open();
                            }
                            catch (Exception)
                            {
                                label2.Text = "Port in use!";
                            }
                        }

                    }

                }

            }
            else
            {
                isConnected = false;
                ;// well shit
                DserialPort1.Close();

            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

            DserialPort1.Close();
            Properties.Settings.Default.Save();
        }

        private void PHeatingSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            DserialPort1.Close();
        }

    }
}
