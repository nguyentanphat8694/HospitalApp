﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hospital.App
{
    public partial class frmText : DevExpress.XtraEditors.XtraForm
    {
        public frmText()
        {
            InitializeComponent();
        }
        public string ten = "";
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (teTen.Text.Trim() == "") {
                MessageBox.Show("Vui lòng nhập tên phác đồ");
                return;
            }
            ten = teTen.Text;
            this.Close();

        }
    }
}