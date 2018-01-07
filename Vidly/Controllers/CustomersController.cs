using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Import this so that you have access to Include() so that membershipt type is retrieved from DB along with customers
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.DTO;

namespace Vidly.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            //code commented out below because datatables and jquery code on the page make a call to the API to get the customers back
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customers);
            return View();
        }

        public ActionResult Details(int id)
        {
            //NOTE if you're trying to access a submodel within a model you will need the Include() bit of code as shown below
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes

            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        //Validation of token below is to prevent CSRF attack on customer edit/create page
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //IF statement below checks if the current model state(what the user entered) is correct, if it isn't they just go back to the same page
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            //Part of function for creating a brand new customer
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            //Part of function for updating an exisitng customer
            else
            {
                //Using Single here instead of SingleOrDefault because you can only update an existing customer entry
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}