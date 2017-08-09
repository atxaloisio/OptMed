using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace optmed
{
    public partial class frmUtilCamera : optmed.frmBase
    {
        VideoCaptureDevice videoSource;
        public Image imgCaptura { get; set; }
        public frmUtilCamera()
        {
            InitializeComponent();
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videosources != null)
            {
                videoSource = new AForge.Video.DirectShow.VideoCaptureDevice(videosources[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(CapturaFrame);
               
                videoSource.Start();
            }
        }

        private void CapturaFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (imgCamera.Image != null)
            {
                imgCamera.Image.Dispose();
            }

            imgCamera.Image = (Image)eventArgs.Frame.Clone();
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            imgCaptura = (System.Drawing.Image)imgCamera.Image.Clone();
            
            DialogResult = DialogResult.OK;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
        }
    }
}
