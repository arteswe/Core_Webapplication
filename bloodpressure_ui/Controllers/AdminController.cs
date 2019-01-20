using System;
using System.Threading.Tasks;
using Bloodpressure_UI.Factory;
using Bloodpressure_UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bloodpressure_UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var data = await APIClientFactory.Instance.GetBloodpressureList();
            return View(data);
        }

        // GET: Admin/Details/5 - eventuellt kan det var intressant per datum 
        public async Task<ActionResult> Details(int id)
        {
            var data = await APIClientFactory.Instance.GetBloodpressure(id);
            return View(data);
        }

        //GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var model = new Bloodpressure()
                {
                    Diastolic = int.Parse(collection["Diastolic"]),
                    Systolic = int.Parse(collection["Systolic"]),
                    Comment = collection["Comment"],
                    Date = DateTime.Now,
                    Heartrate = int.Parse(collection["Heartrate"]),
                    PersonId = int.Parse(collection["PersonId"]),
                    Time = collection["Time"]

                };
                Bloodpressure response = await APIClientFactory.Instance.SaveUser(model);

                return RedirectToAction("Details", new { Id = response.Id });
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Admin/Edit/5     
        public async Task<ActionResult> Edit(int id)
        {
            Bloodpressure data = await APIClientFactory.Instance.GetBloodpressure(id);
            return View(data);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IFormCollection collection)
        {
            try
            {
                var model = new Bloodpressure();
                model.Id = int.Parse(collection["Id"]);
                model.Diastolic = int.Parse(collection["Diastolic"]);
                model.Systolic = int.Parse(collection["Systolic"]);
                model.Comment = collection["Comment"];
                model.Date = DateTime.Parse( collection["Date"]);
                model.Heartrate = int.Parse(collection["Heartrate"]);
                model.PersonId = int.Parse(collection["PersonId"]);
                model.Time = collection["Time"];

                var response = await APIClientFactory.Instance.UpdateUser(model);

                return RedirectToAction("Details", new { Id = response.Id });
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}