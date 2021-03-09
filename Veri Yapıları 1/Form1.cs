using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veri_Yapıları_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int[] dizi = { 13, 34, 56, 92, 102, 142, 175, 194, 215, 234};
        public static int baslangic = 0, bitis = dizi.Length - 1;
        public static int devam, click;
        public int aranan;
        public int orta;
        int locY;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode==Keys.Enter)
            {
                if (dizi[orta] != aranan && devam == 2)
                {
                    Ara(dizi, aranan, baslangic, bitis);
                   
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            orta = (baslangic + bitis) / 2;
            btnTekrar.Visible = false;
            button1.Text = dizi[0].ToString();
            button2.Text = dizi[1].ToString();
            button3.Text = dizi[2].ToString();
            button4.Text = dizi[3].ToString();
            button5.Text = dizi[4].ToString();
            button6.Text = dizi[5].ToString();
            button7.Text = dizi[6].ToString();
            button8.Text = dizi[7].ToString();
            button9.Text = dizi[8].ToString();
            button10.Text = dizi[9].ToString();
        }

         int Ara(int[] dizi,int aranan,int bas,int bit)
        {
            orta = (bas + bit) / 2;
            click++;
            if (bit >= bas)
            {        
                if (orta == 0)
                    locY = 32;
                else if (orta == 1)
                    locY = 80;
                else if (orta == 2)
                    locY = 130;
                else if (orta == 3)
                    locY = 180;
                else if (orta == 4)
                    locY = 236;
                else if (orta == 5)
                    locY = 290;
                else if (orta == 6)
                    locY = 335;
                else if (orta == 7)
                    locY = 390;
                else if (orta == 8)
                    locY = 440;
                else if (orta == 9)
                    locY = 490;
                pbOk.Visible = true;
                pbOk.Location = new Point(180, locY);
                if (dizi[orta] == aranan)
                {
                    lblSonuc.Text = "Sayı dizinin " + orta + ". indisindedir.\nSayı "+click+" adım sonra bulundu.";
                    return 1;
                }
                else
                {
                    lblSonuc.Text = "Sayı taranan kutuda bulunamadı.\n'Enter'e tılayın.\nAdım="+click;
                    if (dizi[orta] > aranan)
                        bitis = orta -1;

                    else
                        baslangic = orta+1 ;

                    return -1;
                }
            }
            else
            {
                lblSonuc.Text = "Sayı dizide bulunamadı.";
                return 2;
            }
        }
       
        private void BtnTekrar_Click(object sender, EventArgs e)
        {
            txtAranan.Text = "";
            aranan = 0;
            locY = 0;
            baslangic = 0;
            bitis = dizi.Length-1;
            pbOk.Visible = false;
            lblSonuc.Text = "";
            txtAranan.Focus();
            click = 0;
        }
        
        private void TxtAranan_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                aranan = Convert.ToInt32(txtAranan.Text);
               devam=Ara(dizi, aranan,baslangic,bitis);
            }
            if (devam == 1||devam==2)
            {
                
                btnTekrar.Visible = true;
                devam = 0;
            }
        }

    }
}
