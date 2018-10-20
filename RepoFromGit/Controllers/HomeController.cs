using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepoFromGit.Models;

namespace RepoFromGit.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> TestData()
        {
            using (var client = new HttpClient())
            {
                //https://api.github.com/repos/UncleBeng/test_marge/commits?sha=develop
                client.BaseAddress = new Uri("https://api.github.com");
                // string pass = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(userName + ":" + userPassword));
                // client.DefaultRequestHeaders.Add("Authorization", "Basic" + " "+ pass);
                client.DefaultRequestHeaders.Add("User-Agent", "tom");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3.raw+json");
                var response = await client.GetAsync($"/repos/UncleBeng/test_marge/commits?sha=develop");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                // var rawJson = JsonConvert.DeserializeObject<TestModel>(stringResult);
                return View("TestData", stringResult);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
