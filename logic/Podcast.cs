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
            var reader = new RSSReader(url);
            var namn = reader.GetPodCastName();
           
            Namn = namn;
            URL = url;
            Frekvensen = frekvens;
            Kategorin = kategori;

            var list = reader.ListOfAvsnitt;

            foreach (List<String> a in list)
            {
                var titel = a.ElementAt(0);
                var beskrivning = a.ElementAt(1);
                var avsnitt = new Avsnitt(titel, beskrivning);
                AvsnittsLista.Add(avsnitt);
            }
        }
    }
}
