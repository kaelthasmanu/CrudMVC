using CrudMVC.Data;
using CrudMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudMVC.Controllers;

public class ContactsController : Controller
{

    private readonly ApplicationDbContext _context;

    public ContactsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var contacts = await _context.Contacts.ToListAsync();
        return View(contacts);
    }

    [HttpGet]
    public IActionResult Create()
    {
        // return an empty Contact so the view's tag helpers have a model instance
        return View(new Contact());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Contact contact)
    {
        if (!ModelState.IsValid)
        {
            // return the view with the posted model so validation messages can be shown
            return View(contact);
        }

        _context.Add(contact);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Contact contact)
    {
        if (id != contact.Id)
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {
            return View(contact);
        }

        try
        {
            _context.Update(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            if(!ContactExist(contact.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }

    private bool ContactExist(int id)
    {
        return _context.Contacts.Any(e => e.Id == id);
    }
}