using System;
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
        public SerializerService Service;
        public int I;

        public ListMaker()
        {
            KategoriService = new JsonService();
            PodcastService = new JsonService();
            PodcastList = new List<Podcast>();
            KategoriList = new List<Kategori>();
            Service = new SerializerService();
            GetKategorier();
            GetPodcasts();
            I = 0;

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

        public async Task<List<Kategori>> GetAllKategorier()
        {
            var list = await KategoriService.GetCategoryList("kategori.json");

            foreach (var k in list)
            {
                var kat = new Kategori(k.ToString());
                KategoriList.Add(kat);
            }

            return KategoriList;
        }

        public void GetPodcasts()
        {
            var list = PodcastService.GetList("podcast.json");
            var list2 = new List<Object>();

            foreach (Podcast p in list)
            {
                var url = p.URL;
                var frekvens = p.Frekvensen;
                var kategori = p.Kategorin;

                var pod = new Podcast(url, frekvens, kategori);
                PodcastList.Add(pod);
            }
            foreach (Object o in PodcastList)
            {
                list2.Add(o);
            }
            PodcastService.SaveList(list2, "podcast.json");
        }

        public void ChangePodcast(String Podcast, Frekvens Frekvens, Kategori Kategori, String Url)
        {
            var list = new List<Object>();
            var lista = PodcastList;
            var namn = Podcast;
            var url = Url;
            Frekvens frekvens = Frekvens;
            Kategori kategori = Kategori;

            foreach (Podcast p in lista)
            {
                if (p.Namn.Equals(namn))
                {
                    p.Frekvensen = frekvens;
                    p.Kategorin = kategori;
                    p.URL = url;


                }
                list.Add(p);
            }

            PodcastService.SaveList(list, "podcast.json");
            PodcastList.Clear();
            GetPodcasts();


        }

        public void ChangeCategory(String Kategori, String NyKategori)
        {
            String kategori = Kategori;
            String nyKategori = NyKategori;

            var lista = KategoriList;
            var list = new List<Object>();

            foreach (Kategori k in lista)
            {
                if (k.Namn.Equals(kategori))
                {
                    k.Namn = nyKategori;
                }
                list.Add(k.Namn);
            }
            KategoriService.SaveList(list, "kategori.json");
            KategoriList.Clear();
            GetKategorier();

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

        public void RemovePodcast(String Podcast)
        {
            var podcast = Podcast;
            var lista = PodcastList;

            lista.RemoveAll(x => x.Namn == podcast);

            var list = new List<Object>();
            list.AddRange(lista);


            PodcastService.SaveList(list, "podcast.json");
            PodcastList.Clear();
            GetPodcasts();


        }
    }
}