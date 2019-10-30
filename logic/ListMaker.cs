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
            CreatePodcast();
            CreateAvsnitt();
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

        public void CreatePodcast()
        {
            var podcast = Reader.ListOfPodcast;
          
                var title = podcast.ElementAt(0);
                var url = podcast.ElementAt(1);
                var thePodcast = new Podcast(title, url);

            allaPodcasts.Add(thePodcast);
        }

        public void CreateAvsnitt()
        {
            var avsnitt = Reader.ListOfAvsnitt;

            foreach (var a in avsnitt)
            {
                var title = a.ElementAt(0);
                var beskrivning = a.ElementAt(1);
                var ettAvsnitt = new Avsnitt(title, beskrivning);

                allaAvsnitt.Add(ettAvsnitt);
            }
        }
    }
}
