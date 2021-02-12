using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    var data = from a in db.Alumnoes
                               join c in db.Ciudades on a.codCiudad equals c.Id
                               where a.Edad > 18
                               select new AlumnoCE()
                               {
                                   Id = a.Id,
                                   Nombres = a.Nombres,
                                   Apellidos = a.Apellidos,
                                   Edad = a.Edad,
                                   Sexo = a.Sexo,
                                   NombreCiudad = c.Nombre,
                                   FechaRegistro = a.FechaRegistro
                               };
                    //List<Alumno> lista = db.Alumnoes.Where(a => a.Edad > 18).ToList();
                    return View(data.ToList());

                }
            }
            catch (Exception)
            {

                throw;
            }
            
            //List<Alumno> lista = db.Alumnoes.Where(a => a.Edad > 18).ToList();
            
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Alumno a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            try
            {
                using (var db = new AlumnosContext())
                {
                    a.FechaRegistro = DateTime.Now;
                    db.Alumnoes.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");


                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el alumno " + ex.Message);
                return View();
            }


            
        }

        public ActionResult ListaCiudades()
        {
            using (var db = new AlumnosContext())
            {
                return PartialView(db.Ciudades.ToList());
            }
        }
        
        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Alumno al = db.Alumnoes.Where(a => a.Id == id).FirstOrDefault();
                    Alumno alu = db.Alumnoes.Find(id);
                    return View(alu);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Alumno a)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Alumno al = db.Alumnoes.Find(a.Id);
                    al.Nombres = a.Nombres;
                    al.Apellidos = a.Apellidos;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;

                    db.SaveChanges();
                    return View(al);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult Details(int id)
        {

                using (var db = new AlumnosContext())
                {
                    Alumno alu = db.Alumnoes.Find(id);
                    return View(alu);
                }
           

        }

        public ActionResult Eliminar(int id)
        {

            using (var db = new AlumnosContext())
            {
                Alumno alu = db.Alumnoes.Find(id);
                db.Alumnoes.Remove(alu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


        }

        public static string NombreCiudad(int CodCiudad)
        {
            using(var db = new AlumnosContext())
            {
                return db.Ciudades.Find(CodCiudad).Nombre;
            }
        }
    }
}