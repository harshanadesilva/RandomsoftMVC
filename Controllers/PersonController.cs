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
    public class PersonController : Controller
    {
        //Hosted web API REST Service base url location
        string Baseurl = "https://60377f0e54350400177228df.mockapi.io/";
        public async Task<ActionResult> Index()
        {
            List<Person> PersonInfo = new List<Person>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/Person");

                if (Res.IsSuccessStatusCode)
                {
                    var postResponse = Res.Content.ReadAsStringAsync().Result;
                    PersonInfo = JsonConvert.DeserializeObject<List<Person>>(postResponse);
                }

                return View(PersonInfo);
            }
        }

        public async Task<ActionResult> Details(int? id)
        {
            Person PersonInfo = new Person();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/Person/" + id);

                if (Res.IsSuccessStatusCode)
                {
                    var postResponse = Res.Content.ReadAsStringAsync().Result;
                    PersonInfo = JsonConvert.DeserializeObject<Person>(postResponse);
                }

                return View(PersonInfo);
            }
        }

        // GET: Drugs/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Drug drug = db.Drugs.Find(id);
        //    if (drug == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(drug);
        //}
    }
}