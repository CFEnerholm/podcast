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
    }
}

