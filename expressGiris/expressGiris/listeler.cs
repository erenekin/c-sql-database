using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;


namespace expressGiris
{
    public partial class listeler : DevExpress.XtraEditors.XtraForm
    {
        public listeler()
        {
            InitializeComponent();
        }



        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-0CVKI7F\\SQLEXPRESS;Initial Catalog=EXPRESS;Integrated Security=True");


        
             private void verileriListele()
        {
            if (comboBox1.SelectedIndex==0)
            {
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter("select* from MUSTERI_BILGI", baglan);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                gridControl1.DataSource = tablo;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex==1)
            {
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter("select* from TESLIM_EDILEN", baglan);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                gridControl1.DataSource = tablo;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex==2)
            {
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter("select* from SILINENLER", baglan);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                gridControl1.DataSource = tablo;
                baglan.Close();
            }
            
        }
        private void listeler_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            verileriListele();
        }
    }
}