using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace TextReader
{
    public class LeroLeroService
    {
        public HttpClient Client { get; }

        public LeroLeroService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("https://www.lerolero.com/");
        }
    }
}
