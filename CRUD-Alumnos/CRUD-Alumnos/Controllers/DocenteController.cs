﻿using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class DocenteController : Controller
    {
        // GET: Docente
        public ActionResult Docentes()
        {
            AlumnosContext db = new AlumnosContext();
            return View(db.Docentes.ToList());
        }
        public ActionResult AgregarDoc()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult AgregarDoc(Docente a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            try
            {
                using (var db = new AlumnosContext())
                {
                    db.Docentes.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Docentes");


                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar docente " + ex.Message);
                return View();
            }
        }
    }
}