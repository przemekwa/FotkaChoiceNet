using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        String[] loginy;
        String sciezka = Environment.GetEnvironmentVariable("TEMP");

        int y = 0; //tablica
        int z = 2;
        int strona_profili = 0;
        bool czy_jest = false;

        
        String zrodlo;

       

        public Form1()
        {
            InitializeComponent();




            IniFile ustawienia = new IniFile(sciezka+"\\test.ini");


            if ((ustawienia.IniReadValue("ustawienia", "szczegoly")) == "FALSE")
            {
                label3.Visible = false;
            }





          
            Laduj_strone(strona_profili.ToString());
            Laduj_dane();
            nastepne(loginy, 0, true);
            nastepne(loginy, 1, false);
         



            


          
          
        }

     
        void nastepne(string[] loginy, int index,bool strona)
        {

            WebClient webClient2 = new WebClient();
            byte[] reqHTML;
            webClient2.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            reqHTML = webClient2.DownloadData("http://fotka.pl/profil/"+loginy[index]);
            UTF8Encoding objUTF8 = new UTF8Encoding();
            

            label3.Text = index.ToString();

            String zrodlo_profilu;

       

            StreamWriter write2 = new StreamWriter(sciezka + "\\profil.txt");
            write2.WriteLine(objUTF8.GetString(reqHTML));
            System.Console.WriteLine("Wczytano " + index + " profil");
            write2.Close();

            StreamReader read = new StreamReader(sciezka+"\\profil.txt");

            for (int x = 0; x < LiczbaLiniiWPliku(sciezka + "\\profil.txt"); x++)
            {
                zrodlo_profilu = read.ReadLine();
                if (zrodlo_profilu != null)
                {

                    if (szukaj("onclick=\"ctrlClickGO", zrodlo_profilu))
                    {
                        zrodlo_profilu = read.ReadLine();
                        zrodlo_profilu = read.ReadLine();

                        czy_jest = true;
                        if (strona)
                        {

                            string adres = (zrodlo_profilu.Substring(5, zrodlo_profilu.Length - 1 - 5)).ToString();
                            pictureBox2.Load(adres);
                            strona = false;
                          linkLabel1.Text = loginy[index];
                          System.Console.WriteLine("Wczytano obrazek " + index + "-go profilu");



                           


                        }
                        else
                        {
                            
                            string adres = (zrodlo_profilu.Substring(5, zrodlo_profilu.Length - 1 - 5)).ToString();
                            pictureBox1.Load(adres);
                            strona = true;
                            linkLabel2.Text = loginy[index];
                            System.Console.WriteLine("Wczytano obrazek " + index + "-go profilu");
                         }
                    }









                  }

            }

            if (czy_jest == false)
            {
                System.Console.WriteLine("Brak zdjęcia dla " + index + "-go profilu");
                
                if (strona)
                {
                    pictureBox2.Load("http://s.asteroid.pl/img/users/brak_zdjecia_woman_500.jpg");
                    strona = false;
                                        linkLabel1.Text = loginy[index];


                }
                else
                {
                    pictureBox1.Load("http://s.asteroid.pl/img/users/brak_zdjecia_woman_500.jpg");
                    strona = true;
                    linkLabel2.Text = loginy[index];
                }
                
            }
            czy_jest = false;

            read.Close();





          

        }


        bool szukaj(string parametr, string zrodlo)
        {

            
            


            return Regex.IsMatch(zrodlo, parametr);
        }

      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           


            if (z < loginy.Length)
            {
                if (loginy[z] != null)
                {
                    nastepne(loginy, z, false);
                    
                }
                else
                {
                    strona_profili++;
                    Laduj_strone(strona_profili.ToString());
                    y = 0;
                    z = 0;

                    Laduj_dane();

                    nastepne(loginy, z, false);
                }
                linkLabel2.Text = loginy[z];
            

                z++;


              
            }
              



            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          


            if (z < loginy.Length)
            {
                if (loginy[z] != null)
                {
                    nastepne(loginy, z, true);
                    
                }
                else
                {
                    strona_profili++;
                    Laduj_strone(strona_profili.ToString());
                    y = 0;
                    z = 0;

                    Laduj_dane();
                    nastepne(loginy, z, true);
                }

                linkLabel1.Text = loginy[z];
             



                z++;



            }

            
        }


        void Laduj_strone(string strona)
        {
           
            WebClient webClient = new WebClient();
            byte[] reqHTML;
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            reqHTML = webClient.DownloadData("http://www.fotka.pl/online/kobiety,1-30/1");
            UTF8Encoding objUTF8 = new UTF8Encoding();
            zrodlo = (objUTF8.GetString(reqHTML));
           // string zrodlo = System.Text.Encoding.GetEncoding("utf-8").GetString(reqHTML); 
            

            StreamWriter write = new StreamWriter(sciezka+"\\fotka.txt");
            
            
            write.WriteLine(zrodlo);



            System.Console.WriteLine("Wczytana strone z profilami...");
            write.Close();
            
        }

        void Laduj_dane()

    {
        




        loginy = new string[60];

        StreamReader read = new StreamReader(sciezka+"\\fotka.txt");
            

        for (int i = 0; i < LiczbaLiniiWPliku(sciezka+"\\fotka.txt"); i++)
        {
            zrodlo = read.ReadLine();
            Match szukam = Regex.Match("s","a");
            
            try
            {
                szukam = Regex.Match(zrodlo, "shadowed-avatar av-96\" href=\"/profil/[a-zA-z0-9]*\"");
            }
            catch
            {
            }
           
            if (szukam.Success)
            {
                loginy[y] = szukam.Groups[0].Value.Substring(37,(szukam.Groups[0].Value.Length - 37 -1));
                y++;
            }
        }
        read.Close();
        System.Console.WriteLine("Wczytano " + y + " profili..." );
      


    }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http:\\\\fotka.pl\\profil\\" + linkLabel1.Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http:\\\\fotka.pl\\profil\\" + linkLabel2.Text);
        }


        static long LiczbaLiniiWPliku(string f)
        {
            long count = 0;
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;
        }

        private void trackBar1_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

       


    }
}
