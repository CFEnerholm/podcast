

using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Data
{
    public class RSSReader
    {
        public RSSReader()
        {

        }

        public List<String> GetPodcast(String title, String URL)
        {
            List<string> myList = new List<string>();
            myList.Add(title);
            myList.Add(URL);

            return myList;

        }

        public List<List<String>> GetFeed()
        {
            Uri u = new Uri("https://api.sr.se/api/rss/pod/23791");
            XmlReader r = XmlReader.Create("https://api.sr.se/api/rss/pod/23791");
            SyndicationFeed f = SyndicationFeed.Load(r);
            var PodTitle = f.Title.Text;

            GetPodcast(PodTitle, u.ToString());

            List<List<string>> myList = new List<List<string>>();

            foreach (SyndicationItem i in f.Items)
            {
                var title = i.Title.Text;
                var summary = ((TextSyndicationContent)i.Summary).Text;

                myList.Add(new List<string> { title, summary });
            }
            return myList;
        }
    }
}