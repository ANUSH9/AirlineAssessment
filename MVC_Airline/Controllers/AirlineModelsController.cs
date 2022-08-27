using AutoMapper;
using ClassLibraryAirline.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MVC_Airline.Controllers
{
    
    
    public class AirlineModelsController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7225/api");
        HttpClient client;

        private readonly IMapper _mapper;

        public AirlineModelsController(IMapper mapper)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _mapper = mapper;

        }
        #region List
        public IActionResult ViewIndex()
        {
          
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AirlineModels").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var List = JsonConvert.DeserializeObject<List<AirlineModel>>(data);
                var getlist = _mapper.Map<List<MvcModelAirline>>(List);
                getlist = getlist.OrderBy(n => n.AirlineName).ToList();
                return View(List);
            }
            else
            {
                return View();
            }
            
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MvcModelAirline book)
        {
            var postTask = client.PostAsJsonAsync<MvcModelAirline>(baseAddress + "/AirlineModels/", book);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ViewIndex");
            }
            ModelState.AddModelError(string.Empty, "Book Create");
            return View(book);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {


            var deleteTask = client.DeleteAsync(baseAddress + "/AirlineModels/" + id.ToString());
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("ViewIndex");
            }

            return RedirectToAction("Delete");
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Update(MvcModelAirline shoppingMall)

        {
            return View("Update", shoppingMall);
        }

        [HttpPost]
        public ActionResult UpdateAirline(MvcModelAirline shoppingMall)
        {
            var putTask = client.PutAsJsonAsync<MvcModelAirline>(baseAddress + "/AirlineModels" + shoppingMall.ID
                .ToString(), shoppingMall);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View(shoppingMall);
        }
        #endregion
    }
}