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
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string url;
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration["MyAPI"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Category");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CategoryViewModel>>(jsonString);
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PostAsync(url + "api/Category", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Category/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CategoryViewModel>(jsonModel);
                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, CategoryViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PutAsync(url + "api/Category/" + model.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.DeleteAsync(url + "api/Category/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Up(Guid id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Category/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CategoryViewModel>(jsonModel);
                value.Order++;


                var jsonModelPut = JsonConvert.SerializeObject(value);
                StringContent contentPut = new StringContent(jsonModelPut, Encoding.UTF8, "application/json");
                var responseMessagePut = await httpclient.PutAsync(url + "api/Category/" + value.Id, contentPut);
                if (responseMessagePut.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Down(Guid id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Category/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CategoryViewModel>(jsonModel);
                if (value.Order > 0)
                {
                    value.Order--;

                    var jsonModelPut = JsonConvert.SerializeObject(value);
                    StringContent contentPut = new StringContent(jsonModelPut, Encoding.UTF8, "application/json");
                    var responseMessagePut = await httpclient.PutAsync(url + "api/Category/" + value.Id, contentPut);
                    if (responseMessagePut.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}
