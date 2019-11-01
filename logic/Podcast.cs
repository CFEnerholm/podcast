using System;
using System.Collections.Generic;
using System.Linq;
using Data;
namespace logic
{
    public class Podcast
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
        }

        public void UpdateAvsnittsList()
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
