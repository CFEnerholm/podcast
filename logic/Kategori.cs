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
            KategoriLista = new List<String> { "Sport", "Historia", "Nyheter" };

        }

   
}}
