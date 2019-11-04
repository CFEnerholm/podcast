using System;

namespace logic
{
    public class Avsnitt : IName
    {
        public String Namn { get; set; }
        public String Beskrivning { get; set; }

        public Avsnitt(String namn, String beskrivning )
        {
            Namn = namn;
            Beskrivning = beskrivning;
        }
    }
}
