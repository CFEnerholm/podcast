using System;
using System.Collections.Generic;
using System.IO;

namespace Data
{
    public class JsonService {

        

    public List<Object> GetList(String filename)
    {
        var serializerService = new SerializerService();
        var jsonFilename = filename;


        if (File.Exists(jsonFilename))
        {
            var list = serializerService.Deserialize(jsonFilename);

            return list;
        }

        else
        {
            var list = new List<Object>
                {
                 
                };
            serializerService.Serialize(jsonFilename, list);
            return list;
        }
    }


        public void AddItemToList(Object Kategori, String filename)
        {
            var kategori = Kategori;
            var serializerService = new SerializerService();
            var jsonFilename = filename;
            var kategoriLista = serializerService.Deserialize(jsonFilename);
            kategoriLista.Add(kategori);
            serializerService.Serialize(jsonFilename, kategoriLista);
        }

        public void RemoveItemFromList(Object Kategori, String filename)
        {
            var kategori = Kategori;
            var serializerService = new SerializerService();
            var jsonFilename = filename;
            var kategoriLista = serializerService.Deserialize(jsonFilename);
            kategoriLista.Remove(kategori);
            serializerService.Serialize(jsonFilename, kategoriLista);
        }
    }
}
