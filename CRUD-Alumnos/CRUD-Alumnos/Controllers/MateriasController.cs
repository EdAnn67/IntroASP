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
    public class MateriasController : ApiController
    {

        [ResponseType(typeof(Materia))]
        public IEnumerable<Materia> Get()
        {
            try
            {
                string sql = @"Select * From Materia";
                using (var db = new AlumnosContext())
                {
                    return db.Database.SqlQuery<Materia>(sql).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        [ResponseType(typeof(Materia))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                string sql = @"Select * From Materia";
                using (var db = new AlumnosContext())
                {
                    return Ok(db.Database.SqlQuery<Materia>(sql).Where(Alumno => Alumno.Id == id).ToList());
                }
            }
            catch
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] JObject jsonD)
        {
            try
            {
                using (AlumnosContext db = new AlumnosContext())
                {
                    Materia M = JsonConvert.DeserializeObject<Materia>(jsonD.ToString());
                    db.Materias.Add(M);
                    db.SaveChanges();
                    return Ok(M);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
