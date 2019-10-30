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
            var list = new List<Object>();
            serializerService.Serialize(jsonFilename, list);
            return list;
        }
    }

      

        public void AddItemToList(Object Item, String filename)
        {
            var item = Item;
            var serializerService = new SerializerService();
            var jsonFilename = filename;
            var lista = serializerService.Deserialize(jsonFilename);
            lista.Add(item);
            serializerService.Serialize(jsonFilename, lista);
        }

        public void RemoveItemFromList(Object Item, String filename)
        {
            var item = Item;
            var serializerService = new SerializerService();
            var jsonFilename = filename;
            var lista = serializerService.Deserialize(jsonFilename);
            lista.Remove(item);
            serializerService.Serialize(jsonFilename, lista);
        }
    }
}
