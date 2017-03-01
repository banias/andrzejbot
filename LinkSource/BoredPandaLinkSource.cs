using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AndrzejPBot.LinkSource
{
    public class BoredPandaLinkSource
    {
        private static Random _random = new Random();
        public string GetRandomLink()
        {
            var  url = $"http://www.boredpanda.com/category/weird";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Host = "www.boredpanda.com";
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.125 Safari/537.36");

                var response = client.GetAsync(url).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(result);
                var links = htmlDocument.DocumentNode.SelectNodes("//section/article/h2/a");
                return links[_random.Next(0, links.Count())].Attributes["href"].Value;
            }
        }
    }
}