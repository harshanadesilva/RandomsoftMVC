using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MytestApp.Models;
using Newtonsoft.Json.Converters;

namespace MytestApp.Controllers
{
    public class PostController : Controller
    {
        //Hosted web API REST Service base url location
        string Baseurl = "https://60377f0e54350400177228df.mockapi.io/";
        public async Task<ActionResult> Index()
        {
            List<Post> postInfo = new List<Post>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/Post");

                if (Res.IsSuccessStatusCode)
                {
                    var postResponse = Res.Content.ReadAsStringAsync().Result;
                    postInfo = JsonConvert.DeserializeObject<List<Post>>(postResponse);
                }

                return View(postInfo);
            }
        }

        public async Task<ActionResult> Details(int? id)
        {
            Post postInfo = new Post();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/Post/" + id);

                if (Res.IsSuccessStatusCode)
                {
                    var postResponse = Res.Content.ReadAsStringAsync().Result;
                    postInfo = JsonConvert.DeserializeObject<Post>(postResponse);
                }

                return View(postInfo);
            }
        }

    }
}