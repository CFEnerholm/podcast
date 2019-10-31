using System;

namespace logic
{
    public class Avsnitt //: Podcast
    {
        public String AvsnittsNamn { get; set; }
        public String Beskrivning { get; set; }

        public Avsnitt(String namn, String beskrivning )
        {
            AvsnittsNamn = namn;
            Beskrivning = beskrivning;
        }
    }
}
