 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tp3EFcoreRelations.data;
using Tp3EFcoreRelations.Models;

namespace Tp3EFcoreRelations.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context) {  
            _context = context; 
        }
        public IActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.membeshipType).ToList();
            return View(customers);
        }
        //Get :Customers/Create
        public IActionResult Create()
        {
            var members = _context.MembershipTypes.ToList();
            ViewBag.member = new SelectList(members, "Id", "Name");
            return View();
        }

        //POST : Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerId,Name,MembershiptypeID")] Customer customer)
        {
            //verfier si MembershptypeID est null
            /*if (customer.membeshipType)
            {
                ModelState.AddModelError("MembershipType", "Le type d'adhesion");
            }*/

            if (ModelState.IsValid)
            {
                customer.CustomerId = Guid.NewGuid(); //Generation d'un nouvel ID
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var members = _context.MembershipTypes.ToList();
            ViewBag.member = new SelectList(members, "Id", "Name");
            return View(customer);

        }

        //Get :Customers/Edit/5
        public IActionResult Edit(Guid?id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            var members = _context.MembershipTypes.ToList();
            ViewBag.member = new SelectList(members, "Id", "Name",customer);
            return View(customer);
        }

        

        /*public IActionResult Edit()
        {
            _context.Update(customer);
            _context.SaveChanges();
        }*/

    }
}
