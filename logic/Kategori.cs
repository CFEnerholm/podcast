using System;
using System.Collections.Generic;
using Data;

namespace logic
{
    public class Kategori
    {
        public List<String> KategoriLista{ get; set; }

        public Kategori()
        {
            KategoriLista = new List<string>();
            KategoriLista.Add("historia");
            KategoriLista.Add("sport");
            

        }
    }
}
