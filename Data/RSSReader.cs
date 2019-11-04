using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using Validation;

namespace Data
{
    
    public class RSSReader
    {
        PodcastValidation PodcastValidation;
        public SyndicationFeed TheFeed { set; get; }
        public String URL;

        public RSSReader(string url)
        {
            URL = url;         
            GetFeed();
            PodcastValidation = new PodcastValidation();
        }

        public void GetFeed()
        {
            try
            {
                XmlReader r = XmlReader.Create(URL);
                TheFeed = SyndicationFeed.Load(r);
            }
            catch (Exception)
            {
                PodcastValidation.MessageDialog("Kolla internetuppkoppling");
            }         
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