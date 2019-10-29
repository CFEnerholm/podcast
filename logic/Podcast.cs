﻿using System;
namespace logic
{
    public class Podcast
    {
        public String URL { get; set; }
        public String PodcastNamn { get; set; }
        public Frekvens Frekvensen { get; set; }
        public Kategori Kategorin { get; set; }

        public Podcast(string titel, string url)
        {
            URL = url;
            PodcastNamn = titel;
            Frekvensen = Frekvens.VarjeHalvtimme;
            Kategorin = new Kategori("Historia");
        }
    }
}
