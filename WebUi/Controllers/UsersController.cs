using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Domain.Entities;
using Data.Repositories.Concrete;
using Microsoft.AspNetCore.Routing;
using WebUi.Dtos;

namespace WebUi.Controllers
{
    [Route("[controller]/[action]")]

    public class UsersController : Controller
    {
        private readonly UserRepository _repo;

        public UsersController(CrudContext context)
        {
            _repo = new UserRepository(context);
        }

        // GET: Users

        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Create([FromBody] UserDto userDto )
        {
            User user = new User();
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                user.Created_at = DateTime.Now;
                user.Updated_at = DateTime.Now;
                user.Name = userDto.Name;
                user.Email = userDto.Emai;
                user.Password = userDto.Password;
                _repo.Add(user);
                await _repo.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,Password,Name,Created_at,Updated_at")] User user)
        {
            if (new Guid(id) != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(user);
                    await _repo.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id.ToString()))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _repo.GetUserById(id);
                
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _repo.GetUserById(id);
            _repo.Delete(user);
            await _repo.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _repo.GetUserById(id) != null;
        }
    }
}
