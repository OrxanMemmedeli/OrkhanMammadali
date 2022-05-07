﻿using Microsoft.AspNetCore.Mvc;
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
    public class ExperienceController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string url;
        public ExperienceController(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration["MyAPI"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Experience");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ExperienceViewModel>>(jsonString);
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ExperienceViewModel model)
        {
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PostAsync(url + "api/Experience", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {


            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Experience/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ExperienceViewModel>(jsonModel);
                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ExperienceViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PutAsync(url + "api/Experience/" + model.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(Guid id)
        {


            var httpclient = new HttpClient();
            var responseMessage = await httpclient.DeleteAsync(url + "api/Experience/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
