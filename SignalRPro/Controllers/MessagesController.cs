using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SignalRPro;
using SignalRPro.Extensions;
using SignalRPro.Extensions.SqlServerNotifier;
using SignalRPro.Models;

namespace SignalRPro.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Messages
        public async Task<ActionResult> Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var collection = db.Messages.Where(x => x.ApplicationUser.UserName == currentUser.UserName && !x.Status);
            return View(await collection.ToListAsync());
        }

        // /Messages/GetMessages
        public ActionResult GetMessages()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var collection = db.Messages.Where(x=>x.ApplicationUser.UserName== currentUser.UserName&&!x.Status);
            return Json(collection.ToListAsync());
        }

       

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Message")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messages);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(messages);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Message")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messages).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(messages);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Messages messages =  db.Messages.Find(id);
            db.Messages.Remove(messages);
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
