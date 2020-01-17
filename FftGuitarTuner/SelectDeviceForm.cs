using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoundCapture;

namespace FftGuitarTuner
{
    public partial class SelectDeviceForm : Form
    {
        SoundCaptureDevice[] devices;

        public SoundCaptureDevice SelectedDevice
        {
            get {
                try
                {
                    return devices[deviceNamesListBox.SelectedIndex];
                }
                catch
                {
                    return devices[0];
                }
            }
        }

        public SelectDeviceForm()
        {
            InitializeComponent();
        }


        public SelectDeviceForm(int g)
        {

            try
            {

                devices = SoundCaptureDevice.GetDevices();

                deviceNamesListBox.Items.Clear();


                devices = SoundCaptureDevice.GetDevices();



                //for (int i = 0; i < devices.Length; i++)
                //{
                //    //deviceNamesListBox.Items.Add(devices[i].Name);
                //    if (devices[i].IsDefault)
                //        defaultDeviceIndex = i;
                //}

                //deviceNamesListBox.SelectedIndex = defaultDeviceIndex;
            }
            catch (Exception y)
            {
                MessageBox.Show("Error capturando los dispositivos de sonido. Mensaje del sistema: " + y.Message);
                throw y;
            }
        }

        private void SelectDeviceForm_Load(object sender, EventArgs e)
        {
            LoadDevices();
        }

        private void LoadDevices()
        {
            try
            {


                deviceNamesListBox.Items.Clear();

                int defaultDeviceIndex = 0;

                devices = SoundCaptureDevice.GetDevices();
                for (int i = 0; i < devices.Length; i++)
                {
                    deviceNamesListBox.Items.Add(devices[i].Name);
                    if (devices[i].IsDefault)
                        defaultDeviceIndex = i;
                }

                deviceNamesListBox.SelectedIndex = defaultDeviceIndex;
            }
            catch (Exception y) {
                MessageBox.Show("Error capturando los dispositivos de sonido. Mensaje del sistema: "+y.Message);
                throw y;
            }
        }

        private void deviceNamesListBox_DoubleClick(object sender, EventArgs e)
        {
            if (deviceNamesListBox.SelectedIndex < 0) return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        private void deviceNamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
