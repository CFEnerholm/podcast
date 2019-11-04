using System;


namespace logic
{
    public class Kategori : IName
    {

        public String Namn { get; set; }

        public Kategori(String namn)
        {
            Namn = namn;
        }   
    }
}
