using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ProjectController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string url;
        public ProjectController(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration["MyAPI"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Project");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ProjectViewModel>>(jsonString);
            return View(values);
        }

        public async Task<IActionResult> Create()
        {
            List<CategoryViewModel> values = await GetAllCategories();

            ViewData["CategoryID"] = new SelectList(values, "Id", "Name");
            return View();
        }

        private async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Category");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CategoryViewModel>>(jsonString);
            return values;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PostAsync(url + "api/Project", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {

            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Project/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ProjectViewModel>(jsonModel);

                List<CategoryViewModel> values = await GetAllCategories();
                ViewData["CategoryID"] = new SelectList(values, "Id", "Name", value.CategoryID);

                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProjectViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PutAsync(url + "api/Project/" + model.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.DeleteAsync(url + "api/Project/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Up(Guid id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Project/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ProjectViewModel>(jsonModel);
                value.Order++;


                var jsonModelPut = JsonConvert.SerializeObject(value);
                StringContent contentPut = new StringContent(jsonModelPut, Encoding.UTF8, "application/json");
                var responseMessagePut = await httpclient.PutAsync(url + "api/Project/" + value.Id, contentPut);
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
            var responseMessage = await httpclient.GetAsync(url + "api/Project/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ProjectViewModel>(jsonModel);
                if (value.Order > 0)
                {
                    value.Order--;

                    var jsonModelPut = JsonConvert.SerializeObject(value);
                    StringContent contentPut = new StringContent(jsonModelPut, Encoding.UTF8, "application/json");
                    var responseMessagePut = await httpclient.PutAsync(url + "api/Project/" + value.Id, contentPut);
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
