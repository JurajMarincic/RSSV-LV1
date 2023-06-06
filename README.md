# RSSV LV1

public partial class Form1 : Form
    {


        private string hours, minutes;
        private bool alarmSet;
        //Dodane varijable hours i minutes za provjeru trenutnog vremena te flag alarmSet za pomoć u zaustavljanju te pokretanju alarma.
        
        private System.Timers.Timer t;
        public Form1()
        {
            InitializeComponent();
            t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(vrijeme);
            t.Start();
            
            // Dodatno t.Start() kako bi se timer pokrenio i moglo se bilježiti trenutno vrijeme.
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

                // Dodan uvjet za provjeru trenutnog i zadanog vremena te poziva funkciju callAlarm() ako su uvjeti ispunjeni.
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
        // Dodan uvjet koji ispisuje poruku ako u jednom od TextBoxova nije ništa napisano te u slučaju da su brojke unesene vrijednosti za sate i minute se pohranjuju, a flag se mijenja u true.
           
        }


        private void callAlarm()
        {
            Console.Beep(3000, 1000);
            alarmSet = false;
            MessageBox.Show("Alarm!!!!");
        }
        // Funkcija koja poziva alarm tj. proizvodi zvučni signal i ispisuje poruku. Mijenjao sam flag ovdje jer se svugdje osim ovdje zvučni signal neprestano ponavljao sve dok se vrijeme u minutama ne promijeni. Pokušao sam ga staviti ispod ovog MessageBoxa i ispod poziva callAlarm() funkcije, ali mi se greška ponavljala.
