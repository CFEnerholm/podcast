using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace logic
{
    public class ListMaker
    {
        public JsonService Service;
        public RSSReader Reader;
        public List<Avsnitt> allaAvsnitt = new List<Avsnitt>();
        public List<Podcast> allaPodcasts = new List<Podcast>();

        public ListMaker()
        {
            Service = new JsonService();
            Reader = new RSSReader();
        }

        public List<Kategori> GetKategorier()
        {
            var list = Service.GetList("kategori.json");
            var kategoriList = new List<Kategori>();

            foreach (var k in list)
            {
                var kat = new Kategori(k.ToString());
                kategoriList.Add(kat);
            }
            return kategoriList;
        }

        public void AddKategori(Kategori kategori)
        {
            Service.AddItemToList(kategori.Namn, "kategori.json");
        }

        public void RemoveKategori(String kategori)
        {
            Service.RemoveItemFromList(kategori, "kategori.json");
        }

        public List<Avsnitt> CreateAvsnit()
        {
            var list = Reader.GetFeed();
            

            foreach (var a in list)
            {
                var title = a.ElementAt(0);
                var beskrivning = a.ElementAt(1);
                var ettavsnitt = new Avsnitt(title, beskrivning);
                allaAvsnitt.Add(ettavsnitt);
            }
            return allaAvsnitt;

        }

        public List<Podcast> CreatePodcast()
        {
            var list = Reader.ListOfPodcast;

            var title = list.ElementAt(0);
            var url = list.ElementAt(1);
            var enPodcast = new Podcast(title, url);
            allaPodcasts.Add(enPodcast);

            return allaPodcasts;

        }
    }
}
