using Music.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Music.ViewModel
{
    public class NewsViewModel
    {
        public List<NewModel> News { get; set; }

    }
    public static class NewsViewModelExtension
    {
        public static void ParseXml(this NewsViewModel self,string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            var items=document.GetElementsByTagName("item").Cast<XmlNode>();
            if (self.News == null)
            {
                self.News = new List<NewModel>();
            }
            string provider = document.SelectSingleNode("copyright").InnerText;
            foreach (var item in items)
            {
                self.News.Add(
                    new NewModel
                    {
                        Title = item.SelectSingleNode("title").InnerText,
                        Description = item.SelectSingleNode("description").InnerText,
                        Link = item.SelectSingleNode("link").InnerText,
                        pubDate = DateTime.Parse(item.SelectSingleNode("pubDate").InnerText),
                        Provider=provider
                    }
                    );
            }
        }
    }
}
