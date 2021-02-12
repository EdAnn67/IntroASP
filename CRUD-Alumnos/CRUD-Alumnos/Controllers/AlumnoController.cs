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
            AlumnosContext db = new AlumnosContext();

            db.Alumnoes.ToList();
            
            //List<Alumno> lista = db.Alumnoes.Where(a => a.Edad > 18).ToList();
            
            return View(db.Alumnoes.ToList());
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Alumno a)
        {
            return View();
        }
        /*
        public ActionResult Agregar()
        {
            return View();
        }*/
    }
}