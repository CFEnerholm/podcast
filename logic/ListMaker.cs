using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace logic
{
    public class ListMaker
    {
        public JsonService KategoriService;
        public JsonService PodcastService;
        public RSSReader Reader;
        public List<Avsnitt> allaAvsnitt = new List<Avsnitt>();
        public List<Podcast> allaPodcasts = new List<Podcast>();

        public ListMaker()
        {
            KategoriService = new JsonService();
            PodcastService = new JsonService();
            Reader = new RSSReader();
            //CreatePodcast();
            CreateAvsnitt();
        }

        public List<Kategori> GetKategorier()
        {
            var list = KategoriService.GetList("kategori.json");
            var allaKategorier = new List<Kategori>();

            foreach (var k in list)
            {
                var kat = new Kategori(k.ToString());
                allaKategorier.Add(kat);
            }
            return allaKategorier;
        }

        public List<Podcast> GetPodcasts()
        {
            var list = PodcastService.GetList("podcast.json");
            var podcastList = new List<Podcast>();

            foreach (var p in list)
            {
                Kategori kategori = new Kategori("Gröt");
                var pod = new Podcast("P3 Histöria", "blablabla", Frekvens.VarjeKvart, kategori);
                podcastList.Add(pod);
            }
            return podcastList;
        }

        public void AddKategori(Kategori kategori)
        {
            KategoriService.AddItemToList(kategori.Namn, "kategori.json");
        }

        public void RemoveKategori(String kategori)
        {
            KategoriService.RemoveItemFromList(kategori, "kategori.json");
        }

        public void AddPodcast(Podcast podcast)
        {
            
            PodcastService.AddItemToList(podcast, "podcast.json");
        }

        public void RemovePodcast(String podcast)
        {
            PodcastService.RemoveItemFromList(podcast, "podcast.json");
        }

        //public void CreatePodcast()
        //{
        //    var podcast = Reader.ListOfPodcast;

        //    var title = podcast.ElementAt(0);
        //    var url = podcast.ElementAt(1);
        //    var thePodcast = new Podcast(title, url);

        //    allaPodcasts.Add(thePodcast);
        //}

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
