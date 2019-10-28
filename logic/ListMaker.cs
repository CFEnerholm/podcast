using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace logic
{
    public class ListMaker
    {
        public JsonService Service;

        public ListMaker()
        {
            Service = new JsonService();
        }

        public List<Kategori> GetKategorier()
        {
            var list = Service.GetList("kategori.json");
            var kategoriList = new List<Kategori>();

            foreach (var k in list)
            {
                var kat = new Kategori(k.ToString());
                kategoriList.Add(kat);
            }
            return kategoriList;
        }

        public void AddKategori(Kategori kategori)
        {
            Service.AddItemToList(kategori.Namn, "kategori.json");
        }

        public void RemoveKategori(String kategori)
        {
            Service.RemoveItemFromList(kategori, "kategori.json");
        }
    }
}
