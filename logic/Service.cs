using System;
using System.Collections.Generic;
using System.IO;

namespace logic
{
    public class Service
    {
        public Service()
        {

        }

        public List<Kategori> GetKategori()
        {
            var serializerService = new SerializerService();
            var jsonFilename = "kategori.json";


            if (File.Exists(jsonFilename))
            {
                var kategoriLista = serializerService.Deserialize(jsonFilename);

                return kategoriLista;
            }

            else
            {
                var lista = new List<Kategori>
                {
                   new Kategori("Sport"),
                   new Kategori("Historia")
                };
                serializerService.Serialize(jsonFilename, lista);
                return lista;
            }
        }

        public void NewKategori(Kategori Kategori)
        {
            var kategori = Kategori;
            var serializerService = new SerializerService();
            var jsonFilename = "kategori.json";
            var kategoriLista = serializerService.Deserialize(jsonFilename);
            kategoriLista.Add(kategori);
            serializerService.Serialize(jsonFilename, kategoriLista);

        }

        public void RemoveKategori(Kategori Kategori)
        {
            var kategori = Kategori;
            var serializerService = new SerializerService();
            var jsonFilename = "kategori.json";
            var kategoriLista = serializerService.Deserialize(jsonFilename);
            kategoriLista.Remove(kategori);
            serializerService.Serialize(jsonFilename, kategoriLista);

        }
    }
}

