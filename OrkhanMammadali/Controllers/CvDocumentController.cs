using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrkhanMammadali.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OrkhanMammadali.Controllers
{
    public class CvDocumentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string url;
        public CvDocumentController(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration["MyAPI"];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/CvDocument");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CVDocumentViewModel>>(jsonString);
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CVDocumentViewModel model)
        {
            var httpclient = new HttpClient();
            model.fileURL = "";
            //var jsonModel = JsonConvert.SerializeObject(model);
            //StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");


            //byte[] data;
            //using (var br = new BinaryReader(model.File.OpenReadStream()))
            //{
            //    data = br.ReadBytes((int)model.File.OpenReadStream().Length);
            //}
            //ByteArrayContent bytes = new ByteArrayContent(data);

            MultipartFormDataContent multiContent = new MultipartFormDataContent();

            var content = new StreamContent(model.File.OpenReadStream());
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                Name = "\"file\"",
                FileName = "\"" + model.File.FileName + "\""
            };
            content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            //var path = Path.GetFullPath(model.File.FileName);
            //var fileContent = new StreamContent(System.IO.File.OpenRead(path));

            multiContent.Add(content);
            multiContent.Add(new StringContent(model.Id.ToString(), Encoding.UTF8, "application/json"), "\"Id\"");
            multiContent.Add(new StringContent(model.Status.ToString(), Encoding.UTF8, "application/json"), "\"Status\"");
            multiContent.Add(new StringContent(model.fileURL, Encoding.UTF8, "application/json"), "\"fileURL\"");

            var responseMessage = await httpclient.PostAsync(url + "api/CvDocument", multiContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/CvDocument/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonModel = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CVDocumentViewModel>(jsonModel);
                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, CVDocumentViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            var httpclient = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PutAsync(url + "api/CvDocument/" + model.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.DeleteAsync(url + "api/CvDocument/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }




    }
}
