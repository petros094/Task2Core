using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Helper;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        PersonAPI _personAPI = new PersonAPI();
        public async Task<IActionResult> Index()
        {
            List<PersonDTO> dto = new List<PersonDTO>();

            HttpClient client = _personAPI.InitializeClient();

            HttpResponseMessage res = await client.GetAsync("api/person");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<PersonDTO>>(result);

            }
            return View(dto);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("PersonId,FirstName,LastName,PhoneNumber,Email")]PersonDTO person)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _personAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("api/person", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(person);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<PersonDTO> dto = new List<PersonDTO>();
            HttpClient client = _personAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync($"api/values/");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<PersonDTO>>(result);
            }

            var person = dto.SingleOrDefault(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult Edit([Bind("PersonId,FirstName,LastName,PhoneNumber,Email")]PersonDTO person)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _personAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync($"api/values?id={person.PersonId}"+person.PersonId.ToString(), content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(person);
        }
        public  ActionResult Delete(int id)
        {
            HttpClient client = _personAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync($"api/values/{id}").Result;
            if ( res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
