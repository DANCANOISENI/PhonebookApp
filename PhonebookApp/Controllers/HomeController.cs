using Microsoft.AspNetCore.Mvc;
using PhonebookApp;
using PhonebookApp.Models;
using System.Diagnostics;


namespace PhonebookApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<Contact> contacts = new List<Contact>()
    {
        new Contact { Id = 1, Name = "Dancan Oiseni Machora", PhoneNumber = "0740547783" },

        // Add more contacts as needed
    };

        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to the Phonebook App!";
            return View(contacts);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (contacts != null)
            {
                // Generate a unique ID for the new contact
                contact.Id = contacts.Count + 1;

                // Add the contact to the list
                contacts.Add(contact);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            Contact? contact = contacts?.Find(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            Contact? existingContact = contacts?.Find(c => c.Id == contact.Id);

            if (existingContact == null)
            {
                return NotFound();
            }

            existingContact.Name = contact.Name;
            existingContact.PhoneNumber = contact.PhoneNumber;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Contact? contact = contacts?.Find(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            Contact? contact = contacts?.Find(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            contacts?.Remove(contact);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}