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
    public class DocentesController : ApiController
    {

        [ResponseType(typeof(Docente))]
        public IEnumerable<Docente> Get()
        {
            try
            {
                string sql = @"Select * From Docente";
                using (var db = new AlumnosContext())
                {
                    return db.Database.SqlQuery<Docente>(sql).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        [ResponseType(typeof(Docente))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                string sql = @"Select * From Alumnos";
                using (var db = new AlumnosContext())
                {
                    return Ok(db.Database.SqlQuery<Docente>(sql).Where(Alumno => Alumno.Id == id).ToList());
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
                    Docente data = JsonConvert.DeserializeObject<Docente>(json.ToString());
                    db.Docentes.Add(data);
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
