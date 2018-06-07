using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using dotnet;

public class StudentController : Controller{
    private universityContext _context;

    public StudentController(universityContext context){
        _context = context;
    }
    
    public IActionResult Index(){
        return View(_context.Student.ToList());
    }

    public IActionResult Register(){
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(Student student){
        if(ModelState.IsValid){
            _context.Student.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(student);
    }
}