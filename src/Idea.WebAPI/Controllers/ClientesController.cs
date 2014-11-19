using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Idea.Models.Entities;
using Idea.WebAPI.Models;
using Microsoft.Practices.Unity;
using Idea.DAL;

namespace Idea.WebAPI.Controllers
{
    
    public class ClientesController : ApiController
    {
        [Dependency]
        public IRepository ClientesRepository { get; set; }

        public ClientesController()
        {
            
        }

        // GET: api/Clientes
        public IEnumerable<Cliente> GetClientes()
        {
            return ClientesRepository.Query<Cliente>();
        }
        
        // GET: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = ClientesRepository.GetById<Cliente>(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.id)
            {
                return BadRequest();
            }

            try
            {
                ClientesRepository.Update(cliente, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clientes
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClientesRepository.Insert(cliente);
            return CreatedAtRoute("DefaultApi", new { id = cliente.id }, cliente);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Cliente cliente = ClientesRepository.GetById<Cliente>(id);
            if (cliente == null)
            {
                return NotFound();
            }

            ClientesRepository.Delete<Cliente>(cliente.id);
            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return (ClientesRepository.GetById<Cliente>(id) != null);
        }
    }
}