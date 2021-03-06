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
    public class AlumnosController : ApiController
    {
        [ResponseType(typeof(Alumno))]  
        public IEnumerable<Alumno> Get()
        {
            try
            {
                int TestInt = 0;
                string sql = @"Select * From Alumno";
                using (var db = new AlumnosContext())
                {
                    return db.Database.SqlQuery<Alumno>(sql).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        [ResponseType(typeof(Alumno))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                string sql = @"Select * From Alumnos";
                using (var db = new AlumnosContext())
                {
                    return Ok(db.Database.SqlQuery<Alumno>(sql).Where(Alumno => Alumno.Id == id).ToList());
                }
            }
            catch
            {
                return NotFound();
            }
        }
        
        public IHttpActionResult Post([FromBody] JObject json)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    Alumno data = JsonConvert.DeserializeObject<Alumno>(json.ToString());
                    db.Alumnoes.Add(data);
                    return Ok(data);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

