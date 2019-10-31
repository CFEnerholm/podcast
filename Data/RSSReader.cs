

using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Data
{
    public class RSSReader
    {
        public List<List<String>> ListOfAvsnitt { set; get; }
        public SyndicationFeed TheFeed { set; get; }
        public String URL;

        public RSSReader(string url)
        {
            URL = url;
          
            ListOfAvsnitt = new List<List<String>>();
            GetFeed();
            GetAvsnittsInfo();
        }

        public void GetFeed()
        {
            Uri uri = new Uri(URL);
            XmlReader r = XmlReader.Create(URL);
            TheFeed = SyndicationFeed.Load(r);
            
        }

        public String GetPodCastName()
        {
            var title = TheFeed.Title.Text;

            return title;
        }

        public void GetAvsnittsInfo()
        {
           
            foreach (SyndicationItem i in TheFeed.Items)
            {
                var title = i.Title.Text;
                var summary = ((TextSyndicationContent)i.Summary).Text;

                ListOfAvsnitt.Add(new List<string> { title, summary });
            }
        }
    }
}