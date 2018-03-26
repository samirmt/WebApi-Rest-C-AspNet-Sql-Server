﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi_Rest_C_AspNet_Sql_Server;

namespace WebApi_Rest_C_AspNet_Sql_Server.Controllers
{
    public class ProdutosController : ApiController
    {
        private ProdutosEntities db = new ProdutosEntities();

        // GET: api/Produtos
        public IQueryable<Produtos> GetProdutos()
        {
            return db.Produtos;
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(Produtos))]
        public IHttpActionResult GetProdutos(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return NotFound();
            }

            return Ok(produtos);
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProdutos(int id, Produtos produtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produtos.Id)
            {
                return BadRequest();
            }

            db.Entry(produtos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(id))
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

        // POST: api/Produtos
        [ResponseType(typeof(Produtos))]
        public IHttpActionResult PostProdutos(Produtos produtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produtos.Add(produtos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produtos.Id }, produtos);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(Produtos))]
        public IHttpActionResult DeleteProdutos(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return NotFound();
            }

            db.Produtos.Remove(produtos);
            db.SaveChanges();

            return Ok(produtos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutosExists(int id)
        {
            return db.Produtos.Count(e => e.Id == id) > 0;
        }
    }
}