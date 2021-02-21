using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Alumnos.Models;

namespace CRUD_Alumnos.Controllers
{
    public class NotasController : Controller
    {       
        // GET: Notas
        public ActionResult ListaNotas()
        {

            AlumnosContext db = new AlumnosContext();
            db.Notas.ToList();
            return View(db.Notas.ToList());
        }
        
        public ActionResult agregarNotas()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult agregarNotas(Nota a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            try
            {
                using (var db = new AlumnosContext())
                {
                    db.Notas.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("ListaNotas");


                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar notas " + ex.Message);
                return View();
            }
        }



        public ActionResult detalleNotas(int id)
        {
            using(var db = new AlumnosContext())
            {
                Nota N = db.Notas.Find(id);
                return View(N);
            }
        }
    }
}