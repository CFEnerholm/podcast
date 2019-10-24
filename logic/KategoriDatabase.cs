using System;
using System.Collections.Generic;

namespace logic
{
    public class KategoriDatabase
    {
        public static List<Kategori> kategorier { get; private set; }
        
        public KategoriDatabase()
        {


            AddKategori();

        }

        public static void AddKategori()
        {
            var lista = new List<Kategori>();
            var sport = new Kategori("Sport");
            var historia = new Kategori("Historia");

            lista.Add(sport);
            lista.Add(historia);
            
        }

        public static List<Kategori> GetList()
        {
            
            return kategorier;
        }
    }
}
