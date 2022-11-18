using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLibros.Contexto;
using WebApiLibros.Entidades;


namespace WebApiLibros.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AutorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            //LinqtoEntities Todos los Autores

            return context.Autores.ToList();

        }

        [HttpGet("{id}")]
        
        public ActionResult <Autor> Get( int id)
        {
            var resultado = context.Autores.FirstOrDefault(x => x.AutorId == id);
            if (resultado == null) { return NotFound(); }

            return resultado;

        }

        [HttpPost]

        public ActionResult Post ([FromBody] Autor autor ){
            context.Autores.Add(autor);
            context.SaveChanges();
            /*return new CreatedAtRouteResult("ObtenerAutor",
                                              new { id = autor.AutorId },
                                              autor);*/

            return Ok();

        }


        [HttpPut ("{id}")]

        public ActionResult Put (int id, [FromBody] Autor autor)
        {
            if (id != autor.AutorId)
            {
                BadRequest();
            }
            context.Entry(autor).State = EntityState.Modified;
            
            context.SaveChanges();
            return NoContent();


        }

        [HttpDelete("{id}")]

        public ActionResult <Autor> Delete (int id)
        {
            var resultado = context.Autores.FirstOrDefault(x => x.AutorId == id);

            if (resultado == null) {
                return NotFound();
            }
            context.Autores.Remove(resultado);
            context.SaveChanges();
            return resultado;

        }


    }
}