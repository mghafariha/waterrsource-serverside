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
using WaterResource.Models;

namespace WaterResource.Controllers
{
    public class WellVisitedsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WellVisiteds
        public IQueryable<WellVisited> GetWellVisiteds()
        {
            return db.WellVisiteds.Include(a => a.WellProfile);
        }
       [Queryable]
        public IQueryable<WellVisited> GetWellVisiteds(int count,int page,int type=0)
        {
            if (type!=0)
            {
                string query = "SELECT *  FROM [WellVisiteds] where WellProfileID is null and id not in (select WellVisitedID from WellViolations)";
                return db.WellVisiteds.SqlQuery(query).AsQueryable().Include(a => a.WellProfile).OrderBy(a => a.ID).Skip(count * (page - 1)).Take(count);
            }
            return db.WellVisiteds.Include(a => a.WellProfile).OrderBy(a=>a.ID).Skip(count*(page-1)).Take(count);
        }

        // GET: api/WellVisiteds/5
        [ResponseType(typeof(WellVisited))]
        public IHttpActionResult GetWellVisited(int id)
        {
            WellVisited wellVisited = db.WellVisiteds.Find(id);
            if (wellVisited == null)
            {
                return NotFound();
            }

            return Ok(wellVisited);
        }

        // GET: api/GetWellVisited/code
        [ResponseType(typeof(WellVisited))]
        public IHttpActionResult GetWellVisited(string code)
        {
            //WellProfile profle = db.WellProfiles.Where(a => a.Index == code).ToList().FirstOrDefault();
            WellVisited wellVisited = db.WellVisiteds.Where(a => a.WellProfile.Index == code).ToList().OrderByDescending(a => a.DateRegistration).FirstOrDefault();
            if (wellVisited == null)
            {
                return NotFound();
            }

            return Ok(wellVisited);
        }
        // PUT: api/WellVisiteds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWellVisited(int id, WellVisited wellVisited)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wellVisited.ID)
            {
                return BadRequest();
            }

            db.Entry(wellVisited).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WellVisitedExists(id))
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

        // POST: api/WellVisiteds
        [ResponseType(typeof(WellVisited))]
        public IHttpActionResult PostWellVisited(WellVisited wellVisited)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WellVisiteds.Add(wellVisited);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wellVisited.ID }, wellVisited);
        }

        // DELETE: api/WellVisiteds/5
        [ResponseType(typeof(WellVisited))]
        public IHttpActionResult DeleteWellVisited(int id)
        {
            WellVisited wellVisited = db.WellVisiteds.Find(id);
            if (wellVisited == null)
            {
                return NotFound();
            }

            db.WellVisiteds.Remove(wellVisited);
            db.SaveChanges();

            return Ok(wellVisited);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WellVisitedExists(int id)
        {
            return db.WellVisiteds.Count(e => e.ID == id) > 0;
        }
    }
}