﻿using System;
using System.Drawing;

namespace Hospital.App
{
    public class WebcamEventArgs : EventArgs
    {
        private Image m_Image;
        private ulong m_FrameNumber;
        public Image WebCamImage
        {
            get
            {
                return this.m_Image;
            }
            set
            {
                this.m_Image = value;
            }
        }
        public ulong FrameNumber
        {
            get
            {
                return this.m_FrameNumber;
            }
            set
            {
                this.m_FrameNumber = value;
            }
        }
    }
}
