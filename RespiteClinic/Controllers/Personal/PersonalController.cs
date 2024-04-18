using RespiteClinic.Models;
using RespiteClinic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RespiteClinic.Controllers.PersonalController
{
    public class PersonalController : Controller
    {
        // GET: Personal
        public ActionResult Index()
        {
            List<Personal> listPersonal;

            using (RespiteModel context = new RespiteModel())
            {

                listPersonal = (from per in context.personal
                                select new Personal()
                                {

                                    id = per.id,
                                    nombre = per.nombre,
                                    especialidad = per.especialidad,
                                    direccion = per.direccion,
                                    telefono = per.telefono,
                                    email = per.email,

                                }).ToList();
            }
            return View(listPersonal);
        }

        // GET: Personal/Details/5
        public ActionResult Details(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Personal personal = (from p in context.personal
                                                 where p.id == id
                                                 select new Personal()
                                                 {
                                                     id = p.id,
                                                     nombre = p.nombre,
                                                     especialidad = p.especialidad,
                                                     direccion = p.direccion,   
                                                     telefono= p.telefono,
                                                     email = p.email,

                                                 }).FirstOrDefault();


                    if (personal == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(personal);
                }
            }
        }

        // GET: Personal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personal/Create
        [HttpPost]
        public ActionResult Create(Personal PersonaL)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RespiteModel context = new RespiteModel())
                    {
                        var personal = new personal
                        {
                            id = PersonaL.id,
                            nombre = PersonaL.nombre,
                            especialidad = PersonaL.especialidad,
                            direccion = PersonaL.direccion,
                            telefono = PersonaL.telefono,
                            email = PersonaL.email,


                        };
                        context.personal.Add(personal);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el registro: " + ex.Message);

            }
            return View(PersonaL);
        }

        // GET: Personal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Personal PersonaL)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {
                    var personal = new personal
                    {
                        id = PersonaL.id,
                        nombre = PersonaL.nombre,
                        especialidad = PersonaL.especialidad,
                        direccion = PersonaL.direccion,
                        telefono = PersonaL.telefono,
                        email = PersonaL.email,

                    };
                    context.Entry(personal).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Personal/Delete/5
        public ActionResult Delete(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Personal personal = (from p in context.personal
                                         where p.id == id
                                         select new Personal()
                                         {
                                             id = p.id,
                                             nombre = p.nombre,
                                             especialidad = p.especialidad,
                                             direccion = p.direccion,
                                             telefono = p.telefono,
                                             email = p.email,

                                         }).FirstOrDefault();


                    if (personal == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(personal);
                }
            }
        }

        // POST: Personal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                using (RespiteModel context = new RespiteModel())
                {

                    var personaL = context.personal.Find(id);
                    if (personaL == null)
                    {
                        return HttpNotFound();
                    }

                    context.personal.Remove(personaL);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar el resgistro: " + ex.Message);
                return View();
            }
        }
    }
}
