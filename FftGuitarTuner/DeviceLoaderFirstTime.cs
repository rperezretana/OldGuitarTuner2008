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

    class DeviceLoaderFirstTime
    {

        SoundCaptureDevice[] devices;
        public int defaultDev = 0;

        public DeviceLoaderFirstTime()
        {
            try
            {
                devices = SoundCaptureDevice.GetDevices();
                for (int i = 0; i < devices.Length; i++)
                {
                    if (devices[i].IsDefault)
                        defaultDev = i;
                }

            }
            catch (Exception y)
            {
                MessageBox.Show("Error getting sound capture devices. " + y.Message);
                throw y;
            }

        }

        public SoundCaptureDevice CurrentDevice
        {
            get
            {
                try
                {
                    return devices[defaultDev];
                }
                catch
                {
                    return devices[0];
                }
            }
        }



    }
}
