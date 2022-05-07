using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrkhanMammadali.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrkhanMammadali.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string url;
        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration["MyAPI"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Customer");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CustomerViewModel>>(jsonString);
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PostAsync(url + "api/Customer", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {

            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Customer/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CustomerViewModel>(jsonModel);
                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, CustomerViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PutAsync(url + "api/Customer/" + model.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(Guid id)
        {

            var httpclient = new HttpClient();
            var responseMessage = await httpclient.DeleteAsync(url + "api/Customer/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
