using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WebApiOdata.Contextopessoa;
using WebApiOdata.Models;

namespace WebApiOdata.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WebApiOdata.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Pessoa>("Pessoas");
    builder.EntitySet<Contato>("Contato"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PessoasController : ODataController
    {
        private contexto db = new contexto();

        // GET: odata/Pessoas
        [EnableQuery]
        public IQueryable<Pessoa> GetPessoas()
        {
            return db.Pessoa;
        }

        // GET: odata/Pessoas(5)
        [EnableQuery]
        public SingleResult<Pessoa> GetPessoa([FromODataUri] int key)
        {
            return SingleResult.Create(db.Pessoa.Where(pessoa => pessoa.id == key));
        }

        // PUT: odata/Pessoas(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Pessoa> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pessoa pessoa = db.Pessoa.Find(key);
            if (pessoa == null)
            {
                return NotFound();
            }

            patch.Put(pessoa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(pessoa);
        }

        // POST: odata/Pessoas
        public IHttpActionResult Post(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pessoa.Add(pessoa);
            db.SaveChanges();

            return Created(pessoa);
        }

        // PATCH: odata/Pessoas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Pessoa> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pessoa pessoa = db.Pessoa.Find(key);
            if (pessoa == null)
            {
                return NotFound();
            }

            patch.Patch(pessoa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(pessoa);
        }

        // DELETE: odata/Pessoas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Pessoa pessoa = db.Pessoa.Find(key);
            if (pessoa == null)
            {
                return NotFound();
            }

            db.Pessoa.Remove(pessoa);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Pessoas(5)/Contatos
        [EnableQuery]
        public IQueryable<Contato> GetContatos([FromODataUri] int key)
        {
            return db.Pessoa.Where(m => m.id == key).SelectMany(m => m.Contatos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PessoaExists(int key)
        {
            return db.Pessoa.Count(e => e.id == key) > 0;
        }
    }
}
