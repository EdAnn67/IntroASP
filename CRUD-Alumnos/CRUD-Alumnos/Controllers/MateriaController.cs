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
        }

        public ActionResult detalleMat(int id)
        {
            using (var db = new AlumnosContext())
            {
                Materia M = db.Materias.Find(id);
                return View(M);
            }
        }

        public ActionResult EditarMat(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Materia M = db.Materias.Where(a => a.Id == id).FirstOrDefault();
                    Materia Mat = db.Materias.Find(id);
                    return View(Mat);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMat(Materia a)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Materia M = db.Materias.Find(a.Id);
                    M.Nombre = a.Nombre;
                    

                    db.SaveChanges();
                    return View(M);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult DeleteMat(int id)
        {

            using (var db = new AlumnosContext())
            {
                Materia M = db.Materias.Find(id);
                db.Materias.Remove(M);
                db.SaveChanges();
                return RedirectToAction("Materias");
            }


        }
    }
}