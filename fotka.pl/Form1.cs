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
using FotkaNetApi;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<Profile> loginy;

        int strona_profili = 1;
     
        bool czy_jest = false;
        
        String zrodlo;

        public Form1()
        {
            InitializeComponent();

           
            Laduj_dane();
            nastepne( 0, true);
            nastepne( 1, false);
        }


        void nastepne(int index, bool strona)
        {

            var profile = new FotkaApi().GetProfile(loginy[index].Name);


            if (strona)
            {
                pictureBox2.Load(profile.PhotoUrl);
                strona = false;
                linkLabel1.Text = profile.Name;

            }
            else
            {
                pictureBox1.Load(profile.PhotoUrl);
                strona = true;
                linkLabel2.Text = profile.Name;
            }
        }


      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (strona_profili < loginy.Count)
            {
              
                    strona_profili++;


                    nastepne(strona_profili, false);

                }
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {



            if (strona_profili < loginy.Count)
            {

                strona_profili++;


                nastepne(strona_profili, true);

            }

            
        }


      

        void Laduj_dane()

    {





        loginy = new FotkaApi().GetOnLineProfiles().ToList();




      
        System.Console.WriteLine("Wczytano " + loginy.Count + " profili..." );
      


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

     

     

       


    }
}
