using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        ArrayList skor=new ArrayList(); 
        StreamReader reader;
        FileStream fs;
        int hamleSayisi=0;
        Bitmap[] control;
        Bitmap[] btmp;
        Boolean [] resimBool=new Boolean[16];
        Bitmap resim1,resim2;
        int sayac = 0;
        private static Random randomNumber = new Random();

        public Form1()
        {
            InitializeComponent();
            
           
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            hamleSayisi = 0;
            for (int i = btmp.Length - 1; i > 0; i--)
            {
                int j = randomNumber.Next(i + 1);
                Bitmap temp = btmp[i];
                btmp[i] = btmp[j];
                btmp[j] = temp;
            }
            pictureBox2.Image = btmp[0];
            pictureBox3.Image = btmp[1];
            pictureBox4.Image = btmp[2];
            pictureBox5.Image = btmp[3];
            pictureBox6.Image = btmp[4];
            pictureBox7.Image = btmp[5];
            pictureBox8.Image = btmp[6];
            pictureBox9.Image = btmp[7];
            pictureBox10.Image = btmp[8];
            pictureBox11.Image = btmp[9];
            pictureBox12.Image = btmp[10];
            pictureBox13.Image = btmp[11];
            pictureBox14.Image = btmp[12];
            pictureBox15.Image = btmp[13];
            pictureBox16.Image = btmp[14];
            pictureBox17.Image = btmp[15];
            kontrol();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "Resim Seçiniz...";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;
           
            Image img = Image.FromFile(DosyaYolu);
            int widthThird = (int)((double)img.Width / 4.0 + 0.5);
            int heightThird = (int)((double)img.Height / 4.0 + 0.5);
            control = new Bitmap[16];
            btmp = new Bitmap[16];
            int x = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    control[x] = new Bitmap(widthThird, heightThird);
                    btmp[x] = new Bitmap(widthThird, heightThird);
                    Graphics c = Graphics.FromImage(control[x]);
                    Graphics g = Graphics.FromImage(btmp[x]);
                    x++;
                    g.DrawImage(img, new Rectangle(0, 0, widthThird, heightThird), new Rectangle(j * widthThird, i * heightThird, widthThird, heightThird), GraphicsUnit.Pixel);
                    g.Dispose();
                    c.DrawImage(img, new Rectangle(0, 0, widthThird, heightThird), new Rectangle(j * widthThird, i * heightThird, widthThird, heightThird), GraphicsUnit.Pixel);
                    c.Dispose();
                }

         

        }
        void kontrol()
        {
            Boolean esitlik=true;
            Color renk1, renk2;
            listBox1.Items.Clear();
            for (int x = 0; x < 16; x++)
            {
                esitlik = true;

                for (int i = 0; i < btmp[0].Width; i++)
                {
                    for (int j = 0; j < btmp[0].Height; j++)
                    {
                        renk1 = control[x].GetPixel(i, j);
                        renk2 = btmp[x].GetPixel(i, j);
                        if (renk1 != renk2)
                        {
                            esitlik = false;
                           
                        }
                    }

                }
                if (esitlik==true)
                {
                    String a = (x+1)+ ". kare dogru yerde";
                    listBox1.Items.Add(a);
                    if (listBox1.Items.Count==16)
                    {
                        MessageBox.Show("puzzle tamamlandı");
                        int puan = 100 - (hamleSayisi * 2);
                        dosyaGuncelle(puan);

                    }
                }
               
            }
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            resimBool[0] = true;
            if (sayac == 1)
            {
               
                degistir();
                sayac = 0;
            }
            if (sayac==0)
            {
             
                sayac++;
            }
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dosyaAc();
            dosyaOku();
            skor.Sort();
            skor.Reverse();
            if (skor.Count>5)
            {
                for (int i = 0; i < 5; i++)
                {
                    listBox2.Items.Add(skor[i]);
                }
            }
            else
            {
                for (int i = 0; i < skor.Count; i++)
                {
                    listBox2.Items.Add(skor[i]);
                }
            }
          
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            resimBool[1] = true;
            if (sayac == 1)
            {
                
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
             
                sayac++;
            }
           
            


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            resimBool[2] = true;
            if (sayac == 1)
            {
               
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
             
                sayac++;
            }
           
          
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            resimBool[3] = true;
            if (sayac == 1)
            {
                
                degistir();
                sayac = 0;
                return;
            }

            if (sayac == 0)
            {
             
                sayac++;
            }
           
          
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            resimBool[4] = true;
            if (sayac == 1)
            {
             
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
               
                sayac++;
            }
          
         
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            resimBool[5] = true;
            if (sayac == 1)
            {
                
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
            
                sayac++;
            }
            
           
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            resimBool[6] = true;
            if (sayac == 1)
            {
                
                degistir();
                sayac = 0;
                return;
            }

            if (sayac == 0)
            {
               
                sayac++;
            }
        
          
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            resimBool[7] = true;
            if (sayac == 1)
            {
               
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
             
                sayac++;
            }
         
            
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            resimBool[12] = true;
            if (sayac == 1)
            {
                
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
             
                sayac++;
            }
         
           
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            resimBool[8] = true;
            if (sayac == 1)
            {
                
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
          
                sayac++;
            }
         
           
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            resimBool[9] = true;
            if (sayac == 1)
            {
                
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
                
                sayac++;
            }
       
            
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            resimBool[10] = true;
            if (sayac == 1)
            {
                
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
        
                sayac++;
            }
         
           
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            resimBool[11] = true;
            if (sayac == 1)
            {
                
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
    
                sayac++;
            }
           
           
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            resimBool[13] = true;
            if (sayac == 1)
            {
               
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
             
                sayac++;
            }
          
          
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            resimBool[14] = true;
            if (sayac == 1)
            {
        
                degistir();
                sayac = 0;
                return;
            }
            if (sayac == 0)
            {
          
                sayac++;
            }
        
            
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            resimBool[15] = true;
            if (sayac == 1)
            {
            

                degistir();
                sayac = 0;
                return;
            }

            if (sayac == 0)
            {
                sayac++;
               
            }
        
           
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
   
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        void degistir()
        {
            Bitmap temp;
            int sayac = 0;
            int a = Array.IndexOf(resimBool, true);
            sayac++;
            if (a!=-1)
            {
                resimBool[a] = false;
               
            }
           
            
            int b = Array.IndexOf(resimBool, true);
            if (b!=-1)
            {
            resimBool[b] = false;

            }
            
            if (a!=-1&&b!=-1)
            {
                hamleSayisi++;
                textBox1.Text = hamleSayisi.ToString();
                temp = btmp[a];
                btmp[a] = btmp[b];
                btmp[b] = temp;
                pictureBox2.Image = btmp[0];
                pictureBox3.Image = btmp[1];
                pictureBox4.Image = btmp[2];
                pictureBox5.Image = btmp[3];
                pictureBox6.Image = btmp[4];
                pictureBox7.Image = btmp[5];
                pictureBox8.Image = btmp[6];
                pictureBox9.Image = btmp[7];
                pictureBox10.Image = btmp[8];
                pictureBox11.Image = btmp[9];
                pictureBox12.Image = btmp[10];
                pictureBox13.Image = btmp[11];
                pictureBox14.Image = btmp[12];
                pictureBox15.Image = btmp[13];
                pictureBox16.Image = btmp[14];
                pictureBox17.Image = btmp[15];
            }
            kontrol();

            
        }
        public void dosyaAc()
        {
            try
            {
                fs = new FileStream("puan.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                reader = new StreamReader(fs);

            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("dosya bulunamadı");
            }
        }
        public void dosyaOku()
        {
            String satir = reader.ReadLine();
            while (satir!=null)
            {
                int a = Convert.ToInt32(satir);
                skor.Add(a);
                satir = reader.ReadLine();
            }
            fs.Close();
        }
        public void dosyaGuncelle(int hamle)
        {
            FileStream ffs = new FileStream("puan.txt", FileMode.Open, FileAccess.Write);
            skor.Add(hamle);
            skor.Sort();
            skor.Reverse();
           
            StreamWriter yazici = new StreamWriter(ffs,Encoding.UTF8); 
            
            foreach (int a in skor)
            {
                
                yazici.WriteLine(a);
            }
            yazici.Close();
          
        }

    }
}
