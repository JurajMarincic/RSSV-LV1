using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSV_LV1
{
    public partial class Form1 : Form
    {


        private string hours, minutes;
        private bool alarmSet;
        private System.Timers.Timer t;
        public Form1()
        {
            InitializeComponent();
            //Kreiranje timer-a s periodom od 1000 ms
            t = new System.Timers.Timer(1000);
            //Dodavanje događaja timer-u; izvršava se periodno
            t.Elapsed += new System.Timers.ElapsedEventHandler(vrijeme);
            t.Start();
        }



        private void vrijeme(object s, EventArgs e)
        {
            //Metoda Invoke izvršava delegata na niti koja je vlasnik
            //rukovatelja kontrola (uobičajeno, glavna nit)
            //MethodInvoker je delegat koji može izvršiti bilo koju
            //metodu koja ne vraća ništa i nema parametre
            Invoke((MethodInvoker)delegate //Anonimna metoda
            {
                label4.Text = DateTime.Now.ToLongTimeString();
               

                if (hours == DateTime.Now.Hour.ToString() && minutes == DateTime.Now.Minute.ToString() && alarmSet)
                    {
                        callAlarm();
                    }

                
            });
        }


        private void button1_Click(object sender,
EventArgs e)
        {
 

           if (hourBox.Text == "" || minutesBox.Text=="")
            {
                MessageBox.Show("Unesite sate i minute!");
            }
           else
            {
                hours = hourBox.Text;
                minutes = minutesBox.Text;
                alarmSet = true;
            }

           
        }


        private void callAlarm()
        {
            Console.Beep(3000, 1000);
            alarmSet = false;
            MessageBox.Show("Alarm!!!!");
        }


    
    }
}
