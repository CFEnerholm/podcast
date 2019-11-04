using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Data
{
    public class RSSReader
    {
        public SyndicationFeed TheFeed { set; get; }
        public String URL;

        public RSSReader(string url)
        {
            URL = url;         
            GetFeed();
        }

        public void GetFeed()
        {
            XmlReader r = XmlReader.Create(URL);
            TheFeed = SyndicationFeed.Load(r);           
        }

        public String GetPodCastName()
        {
            var title = TheFeed.Title.Text;
            return title;
        }

        public List<List<String>> GetAvsnittsInfo()
        {

            var ListOfPods = new List<List<String>>();

            foreach (SyndicationItem i in TheFeed.Items)
            {
                var title = i.Title.Text;
                var summary = ((TextSyndicationContent)i.Summary).Text;

                ListOfPods.Add(new List<string> { title, summary });
            }
            return ListOfPods;
        }
    }
}