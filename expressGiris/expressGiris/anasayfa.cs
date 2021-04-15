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


using System.Drawing.Printing;

namespace expressGiris
{
    public partial class anasayfa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public anasayfa()
        {
            InitializeComponent();
        }
        

        SqlCommand komut;
    //  SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-ROLS6RN\\SQLEXPRESS;Initial Catalog=EXPRESS;Integrated Security=True");
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-0CVKI7F\\SQLEXPRESS;Initial Catalog=EXPRESS;Integrated Security=True");
      





        private void verileriListele()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("select* from MUSTERI_BILGI", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            gridControl1.DataSource = tablo;
            baglan.Close();
        }


        

        private void ekle()
        {


            string sorgu = "INSERT INTO MUSTERI_BILGI(ISIM,SOYISIM,TELEFON_NO,ARIZA,URUN_ADI,AKSESUAR,ALINAN_TARIH,YAPILAN_IS,FIYAT,TESLIM_DURUM,TESLIM_TARIHI) VALUES(@ISIM,@SOYISIM,@TELEFON_NO,@ARIZA,@URUN_ADI,@AKSESUAR,@ALINAN_TARIH,@YAPILAN_IS,@FIYAT,@TESLIM_DURUM,@TESLIM_TARIHI)";
            komut = new SqlCommand(sorgu, baglan);

            baglan.Open();
            komut.Parameters.AddWithValue("@ISIM", textEdit1.Text);
            komut.Parameters.AddWithValue("@SOYISIM", textEdit3.Text);
            komut.Parameters.AddWithValue("@TELEFON_NO", textEdit2.Text);
            komut.Parameters.AddWithValue("@ARIZA", memoEdit1.Text);
            komut.Parameters.AddWithValue("@URUN_ADI", comboBoxEdit1.Text);
            komut.Parameters.AddWithValue("@AKSESUAR", textEdit4.Text);
            komut.Parameters.AddWithValue("@ALINAN_TARIH", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@YAPILAN_IS", memoEdit2.Text);
            komut.Parameters.AddWithValue("@FIYAT", textEdit5.Text);
            komut.Parameters.AddWithValue("@TESLIM_DURUM", comboBox1.Text);
            komut.Parameters.AddWithValue("@TESLIM_TARIHI", dateTimePicker2.Value);
            komut.ExecuteNonQuery();
            baglan.Close();
            //baglan.Open();
            //SqlCommand komut=new SqlCommand("INSERT INTO MUSTERI_BILGI(ISIM_SOYISIM,TELEFON_NO,ARIZA,AKSESUAR,ALINAN_TARIH,FIYAT,TESLIM_DURUM,TESLIM_TARIHI) values ('" + textEdit1.Text + "','" + textEdit2.Text + "','" + memoEdit1.Text + "','" + textEdit4.Text + "','" +dateTimePicker1.Value.ToString() + "','" + textEdit5.Text + "','" + comboBox1.Text + "','" + dateTimePicker2.Value.ToString() + "')", baglan);
            //komut.ExecuteNonQuery();
            //baglan.Close();
            verileriListele();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text==""&&textEdit6.Text==""&&textEdit3.Text=="")
            {
                MessageBox.Show("Lütfen Bilgi Giriniz","Uyarı");
            }
            else
            {
                ekle();
                MessageBox.Show("Kayıt Eklendi","Bilgi");
                verileriListele();
            }
            
        }


        

        private void guncelle()
        {
            baglan.Open();
            string sorgu = "UPDATE MUSTERI_BILGI SET ISIM=@ISIM,SOYISIM=@SOYISIM,TELEFON_NO=@TELEFON_NO,ARIZA=@ARIZA,URUN_ADI=@URUN_ADI,AKSESUAR=@AKSESUAR,ALINAN_TARIH=@ALINAN_TARIH,YAPILAN_IS=@YAPILAN_IS,FIYAT=@FIYAT,TESLIM_DURUM=@TESLIM_DURUM,TESLIM_TARIHI=@TESLIM_TARIHI WHERE ID=@ID";


            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@ID", textEdit6.Text);
            komut.Parameters.AddWithValue("@ISIM", textEdit1.Text);
            komut.Parameters.AddWithValue("@SOYISIM", textEdit3.Text);
            komut.Parameters.AddWithValue("@TELEFON_NO", textEdit2.Text);
            komut.Parameters.AddWithValue("@ARIZA", memoEdit1.Text);
            komut.Parameters.AddWithValue("@URUN_ADI", comboBoxEdit1.Text);
            komut.Parameters.AddWithValue("@AKSESUAR", textEdit4.Text);
            komut.Parameters.AddWithValue("@ALINAN_TARIH", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@YAPILAN_IS", memoEdit2.Text);
            komut.Parameters.AddWithValue("@FIYAT", textEdit5.Text);
            komut.Parameters.AddWithValue("@TESLIM_DURUM", comboBox1.Text);
            komut.Parameters.AddWithValue("@TESLIM_TARIHI", dateTimePicker2.Value);



            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Güncelleme Başarılı!!!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            verileriListele();



        }

        


        
        private void silgonder()
        {


            string sorgu = "INSERT INTO SILINENLER(ID,ISIM,SOYISIM,TELEFON_NO,ARIZA,URUN_ADI,AKSESUAR,ALINAN_TARIH,YAPILAN_IS,FIYAT,TESLIM_DURUM,TESLIM_TARIHI) VALUES(@ID,@ISIM,@SOYISIM,@TELEFON_NO,@ARIZA,@URUN_ADI,@AKSESUAR,@ALINAN_TARIH,@YAPILAN_IS,@FIYAT,@TESLIM_DURUM,@TESLIM_TARIHI)";
            komut = new SqlCommand(sorgu, baglan);

            baglan.Open();
            komut.Parameters.AddWithValue("@ID",textEdit6.Text);
            komut.Parameters.AddWithValue("@ISIM", textEdit1.Text);
            komut.Parameters.AddWithValue("@SOYISIM", textEdit3.Text);
            komut.Parameters.AddWithValue("@TELEFON_NO", textEdit2.Text);
            komut.Parameters.AddWithValue("@ARIZA", memoEdit1.Text);
            komut.Parameters.AddWithValue("@URUN_ADI", comboBoxEdit1.Text);
            komut.Parameters.AddWithValue("@AKSESUAR", textEdit4.Text);
            komut.Parameters.AddWithValue("@ALINAN_TARIH", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("YAPILAN_IS", memoEdit2.Text);
            komut.Parameters.AddWithValue("@FIYAT", textEdit5.Text);
            komut.Parameters.AddWithValue("@TESLIM_DURUM", comboBox1.Text);
            komut.Parameters.AddWithValue("@TESLIM_TARIHI", dateTimePicker2.Value);
            komut.ExecuteNonQuery();
            baglan.Close();
            //baglan.Open();
            //SqlCommand komut = new SqlCommand("INSERT INTO SILINENLER(ISIM_SOYISIM,TELEFON_NO,ARIZA,AKSESUAR,ALINAN_TARIH,FIYAT,TESLIM_DURUM,TESLIM_TARIHI) values ('" + textEdit1.Text + "','" + textEdit2.Text + "','" + memoEdit1.Text + "','" + textEdit4.Text + "','" +  dateTimePicker1.Value.ToString() + "','" + textEdit5.Text + "','" + comboBox1.Text + "','" + dateTimePicker2.Value.ToString() + "')", baglan);
            //komut.ExecuteNonQuery();
            //baglan.Close();
            //verileriListele();

        }



        private void teslimGonder()
        {


            string sorgu = "INSERT INTO TESLIM_EDILEN(ID,ISIM,SOYISIM,TELEFON_NO,ARIZA,URUN_ADI,AKSESUAR,ALINAN_TARIH,YAPILAN_IS,FIYAT,TESLIM_DURUM,TESLIM_TARIHI) VALUES(@ID,@ISIM,@SOYISIM,@TELEFON_NO,@ARIZA,@URUN_ADI,@AKSESUAR,@ALINAN_TARIH,@YAPILAN_IS,@FIYAT,@TESLIM_DURUM,@TESLIM_TARIHI)";
            komut = new SqlCommand(sorgu, baglan);

            baglan.Open();
            komut.Parameters.AddWithValue("@ID", textEdit6.Text);
            komut.Parameters.AddWithValue("@ISIM", textEdit1.Text);
            komut.Parameters.AddWithValue("@SOYISIM", textEdit3.Text);
            komut.Parameters.AddWithValue("@TELEFON_NO", textEdit2.Text);
            komut.Parameters.AddWithValue("@ARIZA", memoEdit1.Text);
            komut.Parameters.AddWithValue("@URUN_ADI", comboBoxEdit1.Text);
            komut.Parameters.AddWithValue("@AKSESUAR", textEdit4.Text);
            komut.Parameters.AddWithValue("@ALINAN_TARIH", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("YAPILAN_IS", memoEdit2.Text);
            komut.Parameters.AddWithValue("@FIYAT", textEdit5.Text);
            komut.Parameters.AddWithValue("@TESLIM_DURUM", comboBox1.Text);
            komut.Parameters.AddWithValue("@TESLIM_TARIHI", dateTimePicker2.Value);
            komut.ExecuteNonQuery();
            baglan.Close();
            //baglan.Open();
            //SqlCommand komut = new SqlCommand("INSERT INTO SILINENLER(ISIM_SOYISIM,TELEFON_NO,ARIZA,AKSESUAR,ALINAN_TARIH,FIYAT,TESLIM_DURUM,TESLIM_TARIHI) values ('" + textEdit1.Text + "','" + textEdit2.Text + "','" + memoEdit1.Text + "','" + textEdit4.Text + "','" +  dateTimePicker1.Value.ToString() + "','" + textEdit5.Text + "','" + comboBox1.Text + "','" + dateTimePicker2.Value.ToString() + "')", baglan);
            //komut.ExecuteNonQuery();
            //baglan.Close();
            //verileriListele();

        }
        

        private void teslimEt()
        {
            string sil = "delete from MUSTERI_BILGI where ID=@ID";
            komut = new SqlCommand(sil, baglan);
            komut.Parameters.AddWithValue("@ID", textEdit6.Text);
            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Kayıt Teslim Edildi...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            verileriListele();
        }
        private void sil()
        {
            //int id = 0;
            //DialogResult dialog = new DialogResult();
            //dialog = MessageBox.Show("Kaydı Silmek İstediğinize Eminmisiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialog == DialogResult.Yes)
            //{

                string sil = "delete from MUSTERI_BILGI where ID=@ID";
                komut = new SqlCommand(sil, baglan);
                komut.Parameters.AddWithValue("@ID", textEdit6.Text);
                baglan.Open();
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Silindi","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                verileriListele();

          //  }
         //   else if (dialog == DialogResult.No)
            
            {

            }
        }


        //private void teslimSil()
        //{
        //    //int id = 0;
        //    DialogResult dialog = new DialogResult();
        //    dialog = MessageBox.Show("Kaydı Teslim Etmek İstediğinize Eminmisiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (dialog == DialogResult.Yes)
        //    {

        //        string sil = "delete from MUSTERI_BILGI where ID=@ID";
        //        komut = new SqlCommand(sil, baglan);
        //        komut.Parameters.AddWithValue("@ID", textEdit6.Text);
        //        baglan.Open();
        //        komut.ExecuteNonQuery();
        //        baglan.Close();
        //        MessageBox.Show("Kayıt Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        verileriListele();
        //    }
        //    else if (dialog==DialogResult.No)
        //    {

        //    }
        //}
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textEdit6.Text==""||textEdit1.Text==""&&textEdit3.Text=="")
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz","Uyarı");
            }
            else
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Kaydı Silmek Etmek İstediğinize Eminmisiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    silgonder();
                    sil();


                    temizle();
                }
                else if (dialog == DialogResult.No)
                {

                }
            }
            
           

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            temizle();


        }
        private void temizle()
        {
            textEdit6.Text = "";
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            comboBoxEdit1.Text = "";
            memoEdit1.Text = "";
            memoEdit2.Text = "";
            textEdit4.Text = "";
            textEdit5.Text = "";
            //dateTimePicker1.Text = "";
            //dateTimePicker2.Text = "";
            comboBox1.Text = "";
        }


        void GridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textEdit6.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
        }


        private void getir()
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            textEdit6.Text = row[0].ToString();
            textEdit1.Text = row[1].ToString();
            textEdit2.Text = row[3].ToString();
            textEdit3.Text = row[2].ToString();
            memoEdit1.Text = row[4].ToString();
            comboBoxEdit1.Text = row[5].ToString();
            textEdit4.Text = row[6].ToString();
            dateTimePicker1.Text = row[7].ToString();
            memoEdit2.Text = row[8].ToString();
            textEdit5.Text = row[9].ToString();
            comboBox1.Text = row[10].ToString();
            dateTimePicker2.Text = row[11].ToString();

        }

        

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            //PrintDialog p1 = new PrintDialog();
            //PrintDocument p2 = new PrintDocument();
            //p2.DocumentName = "Print Document";
            //p1.Document = p2;
            //p1.AllowSelection = true;
            //p1.AllowSomePages = true;

            //if (p1.ShowDialog() == DialogResult.OK) ;
            //p2.Print();
           
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
            verileriListele();
            //comboBox1.Text = "EDİLMEDİ";
            temizle();
        }

      

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            getir();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (textEdit6.Text==""&&textEdit3.Text==""&&textEdit1.Text=="")
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz","Uyarı");
            }
            else
            {
                guncelle();
            }
            
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (textEdit6.Text==""&&textEdit1.Text==""&&textEdit3.Text=="")
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz","Uyarı");
            }
            else
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Kaydı Teslim Etmek İstediğinize Eminmisiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)

                {
                    teslimEt();
                    teslimGonder();
                    temizle();
                }
                else
                {

                }
            }

            
            
                
            
            
         
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //anasayfa fr2 = new anasayfa();
            //fr2.Show();

            textEdit1.Focus();
            
        }

        

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        

        private void textEdit5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            listeler fr1 = new listeler();
            
            fr1.Show();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("İsim Soyisim: " + textEdit1.Text,new Font("Arial",12,FontStyle.Regular),Brushes.Black,new Point(10,80));
            e.Graphics.DrawString("Tel No: "+textEdit2.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 150));
            e.Graphics.DrawString("Arızası: "+memoEdit1.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 220));
            e.Graphics.DrawString("Aksesuarı: "+textEdit4.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 290));
           



        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }
    }
}
