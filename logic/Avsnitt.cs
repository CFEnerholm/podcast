using System;

namespace logic
{
    public class Avsnitt : Podcast
    {
        public String AvsnittsNamn { get; set; }
        public Podcast Podcasten { get; set; }

        public Avsnitt()
        {
            
        }
    }
}
