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
}