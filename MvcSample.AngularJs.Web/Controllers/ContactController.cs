using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MvcSample.AngularJs.Web.Models;
using MvcSample.BusinessServices.Contracts;
using MvcSample.Domain.Entities;

namespace MvcSample.AngularJs.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactsService _contactsService;
        
        public ContactController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        //
        // GET: /Contact/
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetContacts()
        {
            var contacts = Mapper.Map<List<ContactViewModel>>(await _contactsService.GetContacts());
            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetContact(int id)
        {
            var contact = Mapper.Map<ContactViewModel>(await _contactsService.GetContact(id));
            return Json(contact, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public async Task<JsonResult> UpdateContact(int id, ContactViewModel contact)
        {
            await _contactsService.UpdateContact(id, Mapper.Map<Contact>(contact));

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddContact(ContactViewModel contact)
        {
            await _contactsService.AddContact(Mapper.Map<Contact>(contact));
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteContact(ContactViewModel contact)
        {
            await _contactsService.DeleteContact(contact.id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (Request.IsAjaxRequest())
            {
                filterContext.Result = Json(new {success = false, message = filterContext.Exception.Message}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}