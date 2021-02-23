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


        
        public ActionResult EditarNotas(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Nota N = db.Notas.Where(a => a.Id == id).FirstOrDefault();
                    Nota No = db.Notas.Find(id);
                    return View(No);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarNotas(Nota a)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Nota N = db.Notas.Find(a.Id);
                    N.Nota1 = a.Nota1;
                    N.Nota2 = a.Nota2;
                    N.Nota3 = a.Nota3;
                    N.IdAlumno = a.IdAlumno;

                    db.SaveChanges();
                    return View(N);
                }
            }
            catch (Exception ex)
            {
                

                throw;
            }
        }

        public ActionResult DeleteNotas(int id)
        {

            using (var db = new AlumnosContext())
            {
                Nota N = db.Notas.Find(id);
                db.Notas.Remove(N);
                db.SaveChanges();
                return RedirectToAction("ListaNotas");
            }


        }


        public static string Nombre_Alumno(int CodAlumno)
        {
            using (var db = new AlumnosContext())
            {
                return db.Alumnoes.Find(CodAlumno).Nombres;
            };
        }

        public static string Nombre_Materia(int CodMateria)
        {
            using (var db = new AlumnosContext())
            {
                return db.Materias.Find(CodMateria).Nombre;
            };
        }

        public ActionResult ListaMaterias()
        {
            using (var db = new AlumnosContext())
            {
                return PartialView(db.Materias.ToList());
            }
        }

        public ActionResult ListaAlumnos()
        {
            using (var db = new AlumnosContext())
            {
                return PartialView(db.Alumnoes.ToList());
            }
        }
    }
}