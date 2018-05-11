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
    public class EmployeesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.Designation).Include(e => e.EmployeeType);
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationID", "Designation_Name");
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "EmployeeTypeId", "EmployeeTyp");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeID,Employee_Name,Employee_Code,Email,Date_Of_Birth,Address,Contact_No,Emergency_Contact_No,Qualifications,Is_Actv,Is_Del,Crtd_by,Crtd_ts,Mod_by,Mod_ts,RowVersion,EmployeeTypeId,DesignationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationID", "Designation_Name", employee.DesignationId);
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "EmployeeTypeId", "EmployeeTyp", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationID", "Designation_Name", employee.DesignationId);
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "EmployeeTypeId", "EmployeeTyp", employee.EmployeeTypeId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeID,Employee_Name,Employee_Code,Email,Date_Of_Birth,Address,Contact_No,Emergency_Contact_No,Qualifications,Is_Actv,Is_Del,Crtd_by,Crtd_ts,Mod_by,Mod_ts,RowVersion,EmployeeTypeId,DesignationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationID", "Designation_Name", employee.DesignationId);
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "EmployeeTypeId", "EmployeeTyp", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
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
