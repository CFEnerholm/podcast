using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Data;
namespace logic
{
    public class Podcast: IName
    {
        public String URL { get; set; }
        public String Namn { get; set; }
        public Frekvens Frekvensen { get; set; }
        public Kategori Kategorin { get; set; }     
        public List<Avsnitt> AvsnittsLista { get; set; }
        
        public Podcast(string url, Frekvens frekvens, Kategori kategori)
        {
            RSSReader Reader = new RSSReader(url);
            var namn = Reader.GetPodCastName();
            var list = Reader.GetAvsnittsInfo();

            Namn = namn;
            URL = url;
            Frekvensen = frekvens;
            Kategorin = kategori;
            AvsnittsLista = new List<Avsnitt>();

            foreach (List<String> a in list)
            {
                var titel = a.ElementAt(0);
                var beskrivning = a.ElementAt(1);               
                Avsnitt avsnitt = new Avsnitt(titel, beskrivning);
                AvsnittsLista.Add(avsnitt);
            }

            switch (Frekvensen)
            {
                case Frekvens.VarjeKvart:
                    Timer(9000000);
                    break;
                case Frekvens.VarjeHalvtimme:
                    Timer(1800000);
                    break;
                case Frekvens.VarjeTimme:
                    Timer(3600000);
                    break;
            }
        }


        public void Timer(int Interval)
        {
            Timer timer = new Timer();
            timer.Interval = Interval;
            timer.Elapsed += TimerOnElapsed;
            timer.Start();
        }


        public void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            RSSReader Reader = new RSSReader(URL);
            var list = Reader.GetAvsnittsInfo();
            var i = 1;
            int avsnittsListLenght = AvsnittsLista.Count;

            foreach (var a in list)
            {
                if (i < avsnittsListLenght)
                {

                }
                else
                {
                    var titel = a.ElementAt(0);
                    var beskrivning = a.ElementAt(1);
                    Avsnitt avsnitt = new Avsnitt(titel, beskrivning);
                    AvsnittsLista.Add(avsnitt);
                }
                i++;
            }
        }
    }
}
