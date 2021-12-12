using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCD_MessageBoxApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            if (txtIsım.Text != String.Empty && txtSoyisim.Text != String.Empty && txtEmail.Text != String.Empty && txtTelefon.Text != String.Empty)
            {


                int islemSonuc = yeniMusteriEkle(new Customer()
                {
                    id = Guid.NewGuid(),
                    isim = txtIsım.Text,
                    soyisim = txtSoyisim.Text,
                    emailAdress = txtEmail.Text,
                    telno = txtTelefon.Text
                });
                if (islemSonuc > 0)
                {
                    EkranaListele();
                    bildirimCubugu = new NotifyIcon();
                    bildirimCubugu.BalloonTipText = "Toplam müşteri kayıt adedi :" + VirtualDatabase.Customers.Count.ToString() + " Tanedir.";
                    bildirimCubugu.BalloonTipTitle = "Müşteri Adet Bilgisi";
                    bildirimCubugu.Visible = true;
                    bildirimCubugu.Icon = SystemIcons.Information;
                    bildirimCubugu.ShowBalloonTip(2000);
                    DialogResult karar = MessageBox.Show("Müşteri ekleme işlemi başarılı,yeni müşteri kaydı yapmak ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (karar == DialogResult.Yes)
                    {
                        EkranTemizle();
                        System.Threading.Thread.Sleep(300);
                        MessageBox.Show("Şimdi Yeni kayıt yapabilirsiniz.");
                    }
                    else if (karar == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("HATA! Kayıt işlemi yapılamadı");
                    }
                }
                else
                {
                    MessageBox.Show("HATA! Kayıt işlemi yapılamadı");
                }

            }
            else
            {
                MessageBox.Show("Lütfen her bir satırı eksiksiz giriniz aksi halde sistem kabul etmeyecektir.", "Eksik Bilgi Girişi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EkranaListele()
        {
            lstMusteriler.Items.Clear();
            foreach (Customer item in VirtualDatabase.Customers)
            {

                lstMusteriler.Items.Add(item.isim + " " + item.soyisim + " " + item.emailAdress + " " + item.telno);
            }
        }


        private void EkranTemizle()
        {
            txtIsım.Text = string.Empty;
            txtSoyisim.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private int yeniMusteriEkle(Customer customer)
        {
            VirtualDatabase.Customers.Add(customer);
            return 1;
        }

    }
}
