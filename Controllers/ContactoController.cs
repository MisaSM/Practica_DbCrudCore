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
            return View(lista);
        }

        [HttpGet]
        public IActionResult Save() {
             
            return View(); 
        }

        [HttpPost]
        public IActionResult Save(ContactoModel model) 
        {
            if (!ModelState.IsValid) return View();
            var respuesta = contactoData.SaveContact(model);
            if (respuesta)
            {
                return RedirectToAction("");
            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Edit(int IdContacto) 
        {
            ContactoModel contact = contactoData.GetContactById(IdContacto);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactoModel model)
        {
            var result = contactoData.EditContact(model);
            if (result)
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
