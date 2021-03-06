﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCResumeSite.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using PagedList.Mvc;
using System.IO;


namespace MVCResumeSite.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        [Authorize(Roles="Admin")]    
        public ActionResult AdminIndex()
        {
            var posts = db.Posts.ToList();
            posts.ForEach(p => p.Slug = StringUtilities.URLFriendly(p.Title));
            return View(db.Posts.ToList());
        }

        public ActionResult Index(int? page, string query)
        {
            var posts = db.Posts.AsQueryable();
            if (!String.IsNullOrWhiteSpace(query))
            {
                posts = posts.Where(p => p.Title.Contains(query) || p.Body.Contains(query));
                ViewBag.Query = query;

            }
            posts = posts.OrderByDescending(p => p.DateCreated);
                return View(posts.ToPagedList(page ?? 1, 3));
        }
        // GET: Posts/Details/5
        public ActionResult Details(string Slug)
        {
            if (String.IsNullOrWhiteSpace(Slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.FirstOrDefault(p=>p.Slug == Slug);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create  
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Title,Slug,DateCreated,DateUpdated,Body,MediaUrl,Published")] Post post, HttpPostedFileBase image )
        {
            if (ModelState.IsValid)
            {
                var Slug = StringUtilities.URLFriendly(post.Title);
                if(db.Posts.Any(p => p.Slug == Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique.");
                    return View(post);
                }
                if (image != null)
                {
                    if (image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    if ((fileExtension == ".jpg") || (fileExtension == ".gif") || (fileExtension == ".png"))
                    {
                        var path = Server.MapPath("~/img/Blog/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        post.MediaUrl = "/img/Blog/" + fileName;

                        image.SaveAs(Path.Combine(path, fileName));
                    }
                    else
                    {
                        ModelState.AddModelError("image", "Invalid image extension. Only .jpg, gif, png");
                        return View(post);
                    }

                }
                }
                post.Slug = Slug;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            
            }
            post.DateCreated = DateTimeOffset.Now.Date;
            post.DateUpdated = DateTimeOffset.Now.Date;
            return View(post);
            
        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]    
        public ActionResult Edit([Bind(Include = "Id,Title,Slug,DateCreated,DateUpdated,Body,MediaUrl,Published")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment([Bind(Include = "PostId, Message")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.AuthorId = User.Identity.GetUserId();
                comment.DateCreated = System.DateTimeOffset.Now;
                db.Comments.Add(comment);
                db.SaveChanges();
                db.Entry(comment).Reference(p => p.Post).Load();
                return RedirectToAction("Details", new { Slug = comment.Post.Slug });
            }

            return View(comment);
        }
    }


}
