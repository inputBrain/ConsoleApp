using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();



        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }


        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("http://tester.consimple.pro");

            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}