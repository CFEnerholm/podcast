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

        public void ChangePodcast(String Podcast, Frekvens Frekvens, Kategori Kategori)
        {
            var list = new List<Object>();
            var lista = PodcastList;
            var namn = Podcast;
            Frekvens frekvens = Frekvens;
            Kategori kategori = Kategori;

            foreach (Podcast p in lista)
            {
                if (p.Namn.Equals(namn))
                {
                    p.Frekvensen = frekvens;
                    p.Kategorin = kategori;
                    

                }
                list.Add(p);
            }

            PodcastService.SaveList(list, "podcast.json");

            
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

        public void UpdateAvsnittInPodcast()
        {
            var kvartLista = PodcastList
                        .Where(p => p.Frekvensen.Equals(0));
            var halvtimmesLista = PodcastList
                        .Where(p => p.Frekvensen.Equals(1));
            var timmesLista = PodcastList
                        .Where(p => p.Frekvensen.Equals(2));

            if (I == 0)
            {
                foreach (var p in kvartLista)
                {
                    p.UpdateAvsnittsList();
                }
                I++;
            }

            else if (I == 1)
            {
                foreach (var p in kvartLista)
                {
                    p.UpdateAvsnittsList();
                }

                foreach (var p in halvtimmesLista)
                {
                    p.UpdateAvsnittsList();
                }

                I++;
            }

            else if (I == 2)
            {
                foreach (var p in kvartLista)
                {
                    p.UpdateAvsnittsList();
                }
                I++;
            }

            else if (I == 3)
            {
                foreach (var p in kvartLista)
                {
                    p.UpdateAvsnittsList();
                }

                foreach (var p in halvtimmesLista)
                {
                    p.UpdateAvsnittsList();
                }

                foreach (var p in timmesLista)
                {
                    p.UpdateAvsnittsList();
                }
                I = 0;
            }
        }

    }
}