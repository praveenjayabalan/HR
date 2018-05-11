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
    public class DesignationsController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Designations
        public async Task<ActionResult> Index()
        {
            var designations = db.Designations.Include(d => d.Department);
            return View(await designations.ToListAsync());
        }

        // GET: Designations/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Department_Name");
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DesignationID,Designation_Name,Designation_code,Is_Actv,Is_Del,Crtd_by,Crtd_ts,Mod_by,Mod_ts,RowVersion,DepartmentID")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(designation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Department_Name", designation.DepartmentID);
            return View(designation);
        }

        // GET: Designations/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Department_Name", designation.DepartmentID);
            return View(designation);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DesignationID,Designation_Name,Designation_code,Is_Actv,Is_Del,Crtd_by,Crtd_ts,Mod_by,Mod_ts,RowVersion,DepartmentID")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Department_Name", designation.DepartmentID);
            return View(designation);
        }

        // GET: Designations/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Designation designation = await db.Designations.FindAsync(id);
            db.Designations.Remove(designation);
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
