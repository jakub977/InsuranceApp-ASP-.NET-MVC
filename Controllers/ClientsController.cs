using InsuranceApp_Accounts.Data;
using InsuranceApp_Accounts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp_Accounts.Controllers
{
    [Authorize(Roles = "admin")] // Defines ability to use this controller only by admin
    public class ClientsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }


        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(ClientsController.Index), "Clients");
            }
        }



        /// <summary>
        /// GET Action
        /// </summary>
        /// <returns>Home screen</returns>
        [AllowAnonymous] // Let anyone to see this data 
        public IActionResult Index(int pg = 1)
        {
            List<Client> clientList = _context.Clients.ToList();

            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = clientList.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = clientList.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            //return View(clientList);

            return View(data);
        }


        // GET: Clients details
        [AllowAnonymous] // Let anyone to see this data
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }




        // GET: Clients/Create
        [AllowAnonymous] // Let anyone to see this data
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous] // Let anyone to see this data
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Phone,Email,Insurance,Limit,Subject,StartDate,EndDate")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                TempData["success"] = "Nový pojištěnec byl uložen"; // Temporary success message
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Pojištěnec nebyl uložen. Zkuste to znovu."; // Temporary error message
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Phone,Email,Insurance,Limit,Subject,StartDate,EndDate,Event,EventSubject,Place,EventDate")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Změny byly uloženy"; // Temporary success message
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                        TempData["error"] = "Změny nebyly uloženy. Zkuste to znovu."; // Temporary error message
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Client'  is null.");
            }
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }

            await _context.SaveChangesAsync();
            TempData["success"] = "Pojištěnec byl odstraněn"; // Temporary success message
            return RedirectToAction(nameof(Index));
        }








        /// GET Action <summary>
        [AllowAnonymous] // Let anyone to see this data
        public IActionResult InsuranceTypes()
        {
            return View();
        }


        /// <summary>
        /// GET Action
        /// </summary>
        /// <returns>Insurance</returns>
        [AllowAnonymous] // Let anyone to see this data 
        public IActionResult InsuranceList(int pg = 1)
        {
            List<Client> clientList = _context.Clients.ToList();

            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = clientList.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = clientList.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            //return View(clientList);

            return View(data);
        }


        // GET: Insurance details
        [AllowAnonymous] // Let anyone to see this data
        public async Task<IActionResult> InsuranceDetails(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        // GET: Add Insurance
        [AllowAnonymous] // Let anyone to see this data
        public async Task<IActionResult> AddInsurance(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST Add Insurance
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous] // Let anyone to see this data
        public async Task<IActionResult> AddInsurance(int id, [Bind("Id,FirstName,LastName,Address,Phone,Email,Insurance,Limit,Subject,StartDate,EndDate")] Client client, string? navratovaURL = null)
        {
            ViewData["ReturnUrl"] = navratovaURL;
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Pojištění bylo přidáno"; // Temporary success message
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                        TempData["success"] = "Pojištění nebylo přidáno"; // Temporary success message
                    }
                }
                return RedirectToLocal(navratovaURL);
            }
            return View(client);
        }



        // GET: Edit Insurance
        public async Task<IActionResult> EditInsurance(int? id, string returnUrl)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);

        }

        // POST Edit Insurance
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInsurance(int id, [Bind("Id,FirstName,LastName,Address,Phone,Email,Insurance,Limit,Subject,StartDate,EndDate,Event,EventSubject,Place,EventDate")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Změny pojištění byly uloženy"; // Temporary success message
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                        TempData["success"] = "Pojištění nebylo přidáno"; // Temporary success message
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Delete insurance
        public async Task<IActionResult> DeleteInsurance(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        // POST: Delete insurance
        [HttpPost, ActionName("DeleteInsurance")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedPOST(int id)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Client'  is null.");
            }
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                client.Insurance = null;
                client.Subject = null;
                client.Limit = null;
                client.StartDate = null;
                client.EndDate = null;
                client.Event = null;
                client.EventSubject = null;
                client.EventDate = null;
                client.Place = null;
                _context.Update(client);
            }

            await _context.SaveChangesAsync();
            TempData["success"] = "Pojištění bylo odstraněno"; // Temporary success message
            return RedirectToAction(nameof(Index));
        }






        /// <summary>
        /// GET Action
        /// </summary>
        /// <returns>Events</returns>
        [AllowAnonymous] // Let anyone to see this data 
        public IActionResult EventList(int pg = 1)
        {
            List<Client> clientList = _context.Clients.ToList();

            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = clientList.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = clientList.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            //return View(clientList);

            return View(data);
        }


        // GET: Insurance details
        [AllowAnonymous] // Let anyone to see this data
        public async Task<IActionResult> EventDetails(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        // GET: Add Event
        [AllowAnonymous] // Let anyone to see this data
        public async Task<IActionResult> AddEvent(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST Add Event
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous] // Let anyone to see this data
        public async Task<IActionResult> AddEvent(int id, [Bind("Id,FirstName,LastName,Address,Phone,Email,Insurance,Limit,Subject,StartDate,EndDate,Event,EventSubject,Place,EventDate")] Client client, string? navratovaURL = null)
        {
            ViewData["ReturnUrl"] = navratovaURL;
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Pojistná událost byla vytvořena"; // Temporary success message
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                        TempData["success"] = "Pojistná událost nebyla vytvořena"; // Temporary success message
                    }
                }
                return RedirectToLocal(navratovaURL);
            }
            return View(client);
        }


        // GET: Edit Insurance
        [AllowAnonymous]
        public async Task<IActionResult> EditEvent(int? id, string returnUrl)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);

        }

        // POST Edit Insurance
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> EditEvent(int id, [Bind("Id,FirstName,LastName,Address,Phone,Email,Insurance,Limit,Subject,StartDate,EndDate,Event,EventSubject,Place,EventDate")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Změny byly uloženy"; // Temporary success message
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                        TempData["success"] = "Změny nebyly uloženy"; // Temporary success message
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }


        // GET: Delete insurance
        public async Task<IActionResult> DeleteEvent(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        // POST: Delete insurance
        [HttpPost, ActionName("DeleteEvent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEventdPOST(int id)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Client'  is null.");
            }
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                client.Event = null;
                client.EventSubject = null;
                client.EventDate = null;
                client.Place = null;
                _context.Update(client);
            }

            await _context.SaveChangesAsync();
            TempData["success"] = "Pojistná událost byla odstraněna"; // Temporary success message
            return RedirectToAction(nameof(Index));
        }




        private bool ClientExists(int id)
        {
            return (_context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
