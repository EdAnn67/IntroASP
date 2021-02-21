using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Materias()
        {
            AlumnosContext db = new AlumnosContext();
            return View(db.Materias.ToList());
        }
        public ActionResult CrearMat()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearMat(Materia a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            try
            {
                using (var db = new AlumnosContext())
                {
                    db.Materias.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Materias");


                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar materia " + ex.Message);
                return View();
            }
            return View();
        }
    }
}