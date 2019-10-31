using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace logic
{
    public class ListMaker
    {
        public JsonService KategoriService;
        public JsonService PodcastService;
        public RSSReader Reader;
        public List<Podcast> PodcastList;
        public List<Kategori> KategoriList;

        public ListMaker()
        {
            KategoriService = new JsonService();
            PodcastService = new JsonService();
            PodcastList = new List<Podcast>();
            KategoriList = new List<Kategori>();
            GetKategorier();
            GetPodcasts();
        }

        public void GetKategorier()
        {
            var list = KategoriService.GetList("kategori.json");

            foreach (var k in list)
            {
                var kat = new Kategori(k.ToString());
                KategoriList.Add(kat);
            }
        }

        public void GetPodcasts()
        {
            var list = PodcastService.GetList("podcast.json");
        
            foreach (Podcast p in list)
            {
                var url = p.URL;
                var frekvens = p.Frekvensen;
                var kategori = p.Kategorin;

                var pod = new Podcast(url, frekvens, kategori);
                PodcastList.Add(pod);
            }
        }

        public void AddKategori(Kategori kategori)
        {
            KategoriService.AddItemToList(kategori.Namn, "kategori.json");
            KategoriList.Clear();          
            GetKategorier();
        }

        public void RemoveKategori(String kategori)
        {
            KategoriService.RemoveItemFromList(kategori, "kategori.json");
            KategoriList.Clear();
            GetKategorier();
        }

        public void AddPodcast(Podcast podcast)
        {
            PodcastService.AddItemToList(podcast, "podcast.json");
            PodcastList.Clear();
            GetPodcasts();
        }

        public void RemovePodcast(String podcast)
        {         
            PodcastService.RemoveItemFromList(podcast, "kategori.json");
            PodcastList.Clear();
            GetPodcasts();
        }  
    }
}
