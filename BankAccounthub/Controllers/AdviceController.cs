using BankAccounthub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankAccounthub.Controllers
{
    public class AdviceController : Controller
   
        {
        
        public async Task<ActionResult> RandomAdvice()
        {
            string apiUrl = "https://api.adviceslip.com/advice";
            string advice = await GetRandomAdvice(apiUrl);

            return View("RandomAdvice", advice); // Return full view initially with the first piece of advice
        }

        // AJAX request to get new advice
        [HttpGet]
        public async Task<JsonResult> GetNewAdvice()
        {
            string apiUrl = "https://api.adviceslip.com/advice";
            string advice = await GetRandomAdvice(apiUrl);

            return Json(advice); // Return advice as JSON
        }

        private async Task<string> GetRandomAdvice(string apiUrl)
        {
            string advice = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var adviceData = JsonConvert.DeserializeObject<AdviceResponse>(result);
                    advice = adviceData.slip.advice; // Extract the advice
                }
            }

            return advice;
        }
    // GET: AdviceController/Details/5
    public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdviceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdviceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdviceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdviceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdviceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdviceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
