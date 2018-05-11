using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HR.Models.HR;

namespace HR.Controllers
{
    public class HolidaysController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Holidays
        public async Task<ActionResult> Index()
        {
            var holidays = db.Holidays.Include(h => h.Organization);
            return View(await holidays.ToListAsync());
        }

        // GET: Holidays/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holiday holiday = await db.Holidays.FindAsync(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            return View(holiday);
        }

        // GET: Holidays/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationID = new SelectList(db.Organizations, "OrganizationID", "Organization_Name");
            return View();
        }

        // POST: Holidays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Holidayid,HolidayName,Desc,Year,RowVersion,OrganizationID")] Holiday holiday)
        {
            if (ModelState.IsValid)
            {
                db.Holidays.Add(holiday);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationID = new SelectList(db.Organizations, "OrganizationID", "Organization_Name", holiday.OrganizationID);
            return View(holiday);
        }

        // GET: Holidays/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holiday holiday = await db.Holidays.FindAsync(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationID = new SelectList(db.Organizations, "OrganizationID", "Organization_Name", holiday.OrganizationID);
            return View(holiday);
        }

        // POST: Holidays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Holidayid,HolidayName,Desc,Year,RowVersion,OrganizationID")] Holiday holiday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holiday).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationID = new SelectList(db.Organizations, "OrganizationID", "Organization_Name", holiday.OrganizationID);
            return View(holiday);
        }

        // GET: Holidays/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holiday holiday = await db.Holidays.FindAsync(id);
            if (holiday == null)
            {
                return HttpNotFound();
            }
            return View(holiday);
        }

        // POST: Holidays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Holiday holiday = await db.Holidays.FindAsync(id);
            db.Holidays.Remove(holiday);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
