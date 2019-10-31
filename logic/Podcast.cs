using System;
using Data;
namespace logic
{
    public class Podcast
    {
        public String URL { get; set; }
        public String Namn { get; set; }
        public Frekvens Frekvensen { get; set; }
        public Kategori Kategorin { get; set; }

        public Podcast(string url, Frekvens frekvens, Kategori kategori)
        {
            var reader = new RSSReader(url);
            var namn = reader.GetPodCastName();
            Namn = namn;
            URL = url;
            Frekvensen = frekvens;
            Kategorin = kategori;
        }
    }
}
