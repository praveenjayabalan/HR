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
    [Authorize(Roles = "Admin")]
    public class EmployeeTypesController : Controller
    {

        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: EmployeeTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.EmployeeTypes.ToListAsync());
        }

        // GET: EmployeeTypes/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeType employeeType = await db.EmployeeTypes.FindAsync(id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }
            return View(employeeType);
        }

        // GET: EmployeeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeTypeId,EmployeeTyp,Desc,Is_Actv,Is_Del,Crtd_by,Crtd_ts,Mod_by,Mod_ts,RowVersion")] EmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTypes.Add(employeeType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employeeType);
        }

        // GET: EmployeeTypes/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeType employeeType = await db.EmployeeTypes.FindAsync(id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }
            return View(employeeType);
        }

        // POST: EmployeeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeTypeId,EmployeeTyp,Desc,Is_Actv,Is_Del,Crtd_by,Crtd_ts,Mod_by,Mod_ts,RowVersion")] EmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeeType);
        }

        // GET: EmployeeTypes/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeType employeeType = await db.EmployeeTypes.FindAsync(id);
            if (employeeType == null)
            {
                return HttpNotFound();
            }
            return View(employeeType);
        }

        // POST: EmployeeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            EmployeeType employeeType = await db.EmployeeTypes.FindAsync(id);
            db.EmployeeTypes.Remove(employeeType);
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
