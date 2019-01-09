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
    public class WellProfilesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WellProfiles
        public IQueryable<WellProfile> GetWellProfiles()
        {
            return db.WellProfiles.Include(a => a.City).Include(a => a.StudyArea).Include(a => a.Plain);
        }
        public IQueryable<WellProfile> GetWellProfiles(int count,int page)
        {
            return db.WellProfiles.Include(a => a.City).Include(a => a.StudyArea).Include(a => a.Plain).OrderBy(a=>a.ID).Skip(count * (page - 1)).Take(count);
        }

        // GET: api/WellProfiles/5
        [ResponseType(typeof(WellProfile))]
        public IHttpActionResult GetWellProfile(int id)
        {
            WellProfile wellProfile = db.WellProfiles.Find(id);//.Include(a => a.City).Include(a => a.StudyArea).Include(a => a.Plain);
            if (wellProfile == null)
            {
                return NotFound();
            }

            return Ok(wellProfile);
        }

        // GET: api/WellProfiles/code
        [ResponseType(typeof(WellProfile))]
        public IHttpActionResult GetWellProfile(string code)
        {
            WellProfile wellProfile = db.WellProfiles.Where(a=>a.Index==code).FirstOrDefault();
            if (wellProfile == null)
            {
                return NotFound();
            }

            return Ok(wellProfile);
        }

        // PUT: api/WellProfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWellProfile(int id, WellProfile wellProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wellProfile.ID)
            {
                return BadRequest();
            }

            db.Entry(wellProfile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WellProfileExists(id))
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

        // POST: api/WellProfiles
        [ResponseType(typeof(WellProfile))]
        public IHttpActionResult PostWellProfile(WellProfile wellProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
         

            db.WellProfiles.Add(wellProfile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wellProfile.ID }, wellProfile);
        }

        // DELETE: api/WellProfiles/5
        [ResponseType(typeof(WellProfile))]
        public IHttpActionResult DeleteWellProfile(int id)
        {
            WellProfile wellProfile = db.WellProfiles.Find(id);
            if (wellProfile == null)
            {
                return NotFound();
            }

            db.WellProfiles.Remove(wellProfile);
            db.SaveChanges();

            return Ok(wellProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WellProfileExists(int id)
        {
            return db.WellProfiles.Count(e => e.ID == id) > 0;
        }
    }
}