﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerWeb.Models;

namespace TimeTrackerWeb.Controllers
{
    public class EventController : BaseDataAccessController<EventModel>
    {
        private const string TimeTrackerApiSubPath = "api/Event";

        // GET: Event
        public async Task<IActionResult> Index()
        {
            return View(await GetAll(TimeTrackerApiSubPath, GetAuthenticationTokenFromSession()));
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(string id)
        {
            return View(await GetById(TimeTrackerApiSubPath, id, GetAuthenticationTokenFromSession()));
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await Post(TimeTrackerApiSubPath, model, GetAuthenticationTokenFromSession());

            return RedirectToAction(nameof(Index));
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            return View(await GetById(TimeTrackerApiSubPath, id, GetAuthenticationTokenFromSession()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EventModel model)
        {
            if (!id.Equals(model.Id)) return NotFound();

            if (!ModelState.IsValid) return View(model);

            await Update(TimeTrackerApiSubPath, id, model, GetAuthenticationTokenFromSession());

            return RedirectToAction(nameof(Index));
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            return View(await GetById(TimeTrackerApiSubPath, id, GetAuthenticationTokenFromSession()));
        }

        // POST: Event/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await DeleteById(TimeTrackerApiSubPath, id, GetAuthenticationTokenFromSession());

            return RedirectToAction(nameof(Index));
        }

        private string GetAuthenticationTokenFromSession()
        {
            return HttpContext.Session.GetString("authenticationToken");
        }
    }
}