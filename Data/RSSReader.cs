

using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Data
{
    public class RSSReader
    {
        public List<String> ListOfPodcast { set; get; } 
        public List<List<String>> ListOfAvsnitt { set; get; }
        public SyndicationFeed TheFeed { set; get; }
        public String URL;

        public RSSReader()
        {
            URL = "https://api.sr.se/api/rss/pod/23791";
            ListOfPodcast = new List<String>();
            ListOfAvsnitt = new List<List<String>>();
            GetFeed();
            GetPodcastInfo();
            GetAvsnittsInfo();
        }

        public void GetFeed()
        {
            Uri uri = new Uri(URL);
            XmlReader r = XmlReader.Create(URL);
            TheFeed = SyndicationFeed.Load(r);
            
        }

        public void GetPodcastInfo()
        {
            var title = TheFeed.Title.Text;
            ListOfPodcast.Add(title);
            ListOfPodcast.Add(URL);
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