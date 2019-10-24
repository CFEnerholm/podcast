using System;
using System.Collections.Generic;

namespace logic
{
    public class KategoriDatabase
    {
        public static List<Kategori> kategorier { get; private set; }
        
        public KategoriDatabase()
        {
            var lista = new List<Kategori>();
            var sport = new Kategori("Sport");
            var historia = new Kategori("Historia");

            lista.Add(sport);
            lista.Add(historia);
        }
    }
}
