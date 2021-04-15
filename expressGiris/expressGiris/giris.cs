using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace expressGiris
{
    public partial class giris : DevExpress.XtraEditors.XtraForm
    {
        public giris()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (textEdit1.Text == "EXPRESS" && textEdit2.Text == "1")
            {
                anasayfa fr1 = new anasayfa();
                fr1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Şifre Veya Parola");
                textEdit2.Text = "";
            }

        }

        private void giris_Load(object sender, EventArgs e)
        {
            textEdit2.Focus();
        }
    }
}
