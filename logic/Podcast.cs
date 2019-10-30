using System;
namespace logic
{
    public class Podcast
    {
        public String URL { get; set; }
        public String Namn { get; set; }
        public Frekvens Frekvensen { get; set; }
        public Kategori Kategorin { get; set; }

        public Podcast(string titel, string url)
        {
            URL = url;
            Namn = titel;
            Frekvensen = Frekvens.VarjeHalvtimme;
            Kategorin = new Kategori("Historia");
        }
    }
}
