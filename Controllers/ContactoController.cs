using Microsoft.AspNetCore.Mvc;
using PracticaCrud_MisaelSarabia.Data;
using PracticaCrud_MisaelSarabia.Models;

namespace PracticaCrud_MisaelSarabia.Controllers
{
    public class ContactoController : Controller
    {
        ContactoData contactoData = new ContactoData();
        public IActionResult GetAll()
        {
            var lista = contactoData.GetContacts();
            return View();
        }

        [HttpGet]
        public IActionResult Save() {
             
            return View(); 
        }

        [HttpPost]
        public IActionResult Save(ContactoModel model) 
        {
            var respuesta = contactoData.SaveContact(model);
            if (respuesta)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                return View();
            }
            
        }
    }
}
