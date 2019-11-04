using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Data
{
		public class SerializerService
    {
        public List<object> List;

            public SerializerService()
        {
               List = new List<object>();
        }


        public void Serialize(string filename, List<object> Lista)
        {
            var serializer = CreateSerializer();
            using (var sw = new StreamWriter(filename))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, Lista);
                }
            }
        }


        public List<object> Deserialize(string filename)
        {
           var serializer = CreateSerializer();
           using (var sr = new StreamReader(filename))
           {
             using (var jr = new JsonTextReader(sr))
              {
               var list = serializer.Deserialize<List<object>>(jr);
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
