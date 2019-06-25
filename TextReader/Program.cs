using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Polly;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TextReader
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = new HttpClient();

            var siteText = "";

            using (IWebDriver driver = new ChromeDriver())
            {
                var policy = Policy<string>
                   .Handle<Exception>()
                   .Fallback(() => blabla());

                driver.Navigate().GoToUrl("https://www.lipsum.com//");
                var element = driver.FindElement(By.XPath("//div[@id='Panes']/div[1]/p"));
                Console.WriteLine(element.Text);
                siteText = element.Text;

                driver.Navigate().GoToUrl("https://mothereff.in/byte-counter");

                var inputText = driver.FindElement(By.TagName("textarea"));
                inputText.Clear();
                inputText.SendKeys(siteText);

                var numberOfBytes = driver.FindElement(By.Id("bytes"));

                Console.WriteLine(numberOfBytes.Text);
            }

            Console.ReadKey();
        }

        public static string blabla()
        {
            return "";
        }
    }
}
