using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace logic
{
		public class SerializerService
    {
        public void Serialize(string filename, List<Kategori> KategoriLista)
        {
            var serializer = CreateSerializer();
            using (var sw = new StreamWriter(filename))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, KategoriLista);
                }
            }
        }


        public List<Kategori> Deserialize(string filename)
        {
           var serializer = CreateSerializer();
           using (var sr = new StreamReader(filename))
           {
             using (var jr = new JsonTextReader(sr))
              {
               var list = serializer.Deserialize<List<Kategori>>(jr);
                    return list;
              }
            }
               
         }

       

        private JsonSerializer CreateSerializer()
        {
            return new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };
        }
        

    }
}
