using System;
using System.Collections;
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


        public ListMaker()
        {
            KategoriService = new JsonService();
            PodcastService = new JsonService();
        
            //CreatePodcast();
            //CreateAvsnitt();
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
       

            foreach (Podcast p in list)
            {
                var url = p.URL;
                var frekvens = p.Frekvensen;
                var kategori = p.Kategorin;
               
                var pod = new Podcast(url, frekvens, kategori);
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
            var list = PodcastService.GetList("podcast.json");

            foreach (Podcast p in list)
            {
                var namn = p.Namn;

                if (podcast.Equals(namn))
                {
                    PodcastService.RemoveItemFromList(p, "podcast.json");
                }
                
            }
        }

        //public void CreatePodcast()
        //{
        //    var podcast = Reader.ListOfPodcast;

        //    var title = podcast.ElementAt(0);
        //    var url = podcast.ElementAt(1);
        //    var thePodcast = new Podcast(title, url);

        //    allaPodcasts.Add(thePodcast);
        //}

        //public void CreateAvsnitt()
        //{
        //    var avsnitt = Reader.ListOfAvsnitt;

        //    foreach (var a in avsnitt)
        //    {
        //        var title = a.ElementAt(0);
        //        var beskrivning = a.ElementAt(1);
        //        var ettAvsnitt = new Avsnitt(title, beskrivning);

        //        allaAvsnitt.Add(ettAvsnitt);
        //    }
        //}
    }
}
