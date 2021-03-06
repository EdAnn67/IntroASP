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

        public ActionResult detalleDoc(int id)
        {
            using (var db = new AlumnosContext())
            {
                Docente D = db.Docentes.Find(id);
                return View(D);
            }
        }
        
        public ActionResult EditarDoc(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Docente D = db.Docentes.Where(a => a.Id == id).FirstOrDefault();
                    Docente Doc = db.Docentes.Find(id);
                    return View(Doc);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarDoc(Docente a)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Docente D = db.Docentes.Find(a.Id);
                    D.Nombres = a.Nombres;
                    D.Apellidos = a.Apellidos;
                    D.IdMateria = a.IdMateria;

                    db.SaveChanges();
                    return View(D);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public ActionResult DeleteDoc(int id)
        {

            using (var db = new AlumnosContext())
            {
                Docente D = db.Docentes.Find(id);
                db.Docentes.Remove(D);
                db.SaveChanges();
                return RedirectToAction("Docentes");
            }


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
            using(var db = new AlumnosContext())
            {
                return PartialView(db.Materias.ToList());
            }
        }
    }
}