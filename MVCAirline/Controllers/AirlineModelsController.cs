using ClassLibraryAirline.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MVCAirline.Controllers
{
    public class AirlineModelsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7225/api");
        HttpClient client;


        public AirlineModelsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public IActionResult Index()
        {
            List<AirlineModel> shoppingMalls = new List<AirlineModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AirlineModels").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                shoppingMalls = JsonConvert.DeserializeObject<List<AirlineModel>>(data);
            }
            return View(shoppingMalls);
        }
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(AirlineModel book)
        {
            var postTask = client.PostAsJsonAsync<AirlineModel>(baseAddress + "/AirlineModels/", book);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Book Create");
            return View(book);
        }
       
        public ActionResult Delete(int id)
        {

            
            var deleteTask = client.DeleteAsync(baseAddress + "/AirlineModels/" + id.ToString());
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete");
        }

    }
}
