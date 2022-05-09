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
    public class SkillController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string url;
        public SkillController(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration["MyAPI"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Skill");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SkillViewModel>>(jsonString);
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SkillViewModel model)
        {
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PostAsync(url + "api/Skill", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {

            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Skill/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<SkillViewModel>(jsonModel);
                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, SkillViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PutAsync(url + "api/Skill/" + model.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(Guid id)
        {

            var httpclient = new HttpClient();
            var responseMessage = await httpclient.DeleteAsync(url + "api/Skill/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Up(Guid id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Skill/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<SkillViewModel>(jsonModel);
                value.Order++;


                var jsonModelPut = JsonConvert.SerializeObject(value);
                StringContent contentPut = new StringContent(jsonModelPut, Encoding.UTF8, "application/json");
                var responseMessagePut = await httpclient.PutAsync(url + "api/Skill/" + value.Id, contentPut);
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
            var responseMessage = await httpclient.GetAsync(url + "api/Skill/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<SkillViewModel>(jsonModel);
                if (value.Order > 0)
                {
                    value.Order--;

                    var jsonModelPut = JsonConvert.SerializeObject(value);
                    StringContent contentPut = new StringContent(jsonModelPut, Encoding.UTF8, "application/json");
                    var responseMessagePut = await httpclient.PutAsync(url + "api/Skill/" + value.Id, contentPut);
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
