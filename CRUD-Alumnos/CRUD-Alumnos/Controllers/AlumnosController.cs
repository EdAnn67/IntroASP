using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRUD_Alumnos.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CRUD_Alumnos.Controllers
{
    //[ApiController]
    [AllowAnonymous]
    [RoutePrefix("api/Alumnos")]
    public class AlumnosController : ApiController
    {
        //[ResponseType(typeof(Alumno))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                string sql = @"Select * From Alumno";
                using (var db = new AlumnosContext())
                {
                    return Ok(db.Database.SqlQuery<Alumno>(sql).ToList());
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [ResponseType(typeof(Alumno))]
        [HttpGet]
        [Route("~/api/Alumnos/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                string sql = @"Select * From Alumno";
                using (var db = new AlumnosContext())
                {
                    return Ok(db.Database.SqlQuery<Alumno>(sql).Where(a => a.Id == id).ToList());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] JObject jsonD)
        {
            try
            {
                using (AlumnosContext db = new AlumnosContext())
                {
                    Alumno a = JsonConvert.DeserializeObject<Alumno>(jsonD.ToString());
                    db.Alumnoes.Add(a);
                    db.SaveChanges();
                    return Ok(a);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

