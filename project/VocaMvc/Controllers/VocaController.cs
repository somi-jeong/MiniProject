using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VocaMvc.Models;

namespace VocaMvc.Controllers
{
    public class VocaController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Voca> voca;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("vocas").Result;
            voca = response.Content.ReadAsAsync<IEnumerable<Voca>>().Result;
            return View(voca);

        }


        public ActionResult AddOrEdit(int id=0) {

            if (id == 0)
                return View(new Voca());
            else 
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("vocas/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Voca>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Voca voc) {
            if (voc.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("vocas", voc).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("vocas/"+voc.Id,voc).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteConfirm(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("vocas/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Voca>().Result);

        }

        public ActionResult Delete(int id) {

            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("vocas/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}
