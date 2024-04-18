using RespiteClinic.Models;
using RespiteClinic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RespiteClinic.Controllers.CitasController
{
    public class CitasController : Controller
    {
        // GET: Citas
        public ActionResult Index()
        {
            List<Citas> listCitas;

            using (RespiteModel context = new RespiteModel())
            {

                listCitas = (from c in context.citas
                             select new Citas()
                             {
                                 id = c.id,
                                 id_personal = c.id_personal,
                                 id_historial_clinico = c.id_historial_clinico,
                                 estado = c.estado,
                                 fecha_hora = c.fecha_hora,
                                 
                             }).ToList();

            }
            return View(listCitas);
        }

        // GET: Citas/Details/5
        public ActionResult Details(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Citas citas = (from c in context.citas
                                        where c.id == id
                                        select new Citas()
                                        {
                                            id = c.id,
                                            id_personal = c.id_personal,
                                            id_historial_clinico = c.id_historial_clinico,
                                            estado = c.estado,
                                            fecha_hora = c.fecha_hora,

                                        }).FirstOrDefault();
                    

                    if (citas == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(citas);
                }
            }
                      
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Citas/Create
        [HttpPost]
        public ActionResult Create(Citas citas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RespiteModel context = new RespiteModel())
                    {

                        var cita = new citas
                        {
                            id = citas.id,
                            id_personal = citas.id_personal,
                            id_historial_clinico = citas.id_historial_clinico,
                            estado = citas.estado,
                            fecha_hora = citas.fecha_hora
                        };

                        context.citas.Add(cita);
                        context.SaveChanges();

                    }
                    return RedirectToAction("Index");
                }
                

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Error al crear la cita: " + ex.Message);
                
            }
            return View(citas);

        }

        // GET: Citast/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Citast/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Citas citas)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {

                    var cita = new citas
                    {
                        id = citas.id,
                        id_personal = citas.id_personal,
                        id_historial_clinico = citas.id_historial_clinico,
                        estado = citas.estado,
                        fecha_hora = citas.fecha_hora
                    };

                    context.Entry(citas).State = EntityState.Modified;
                    context.SaveChanges();  

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Citast/Delete/5
        public ActionResult Delete(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                // Buscar la cita por su ID en la base de datos
                Citas citas = (from c in context.citas
                               where c.id == id
                               select new Citas()
                               {
                                   id = c.id,
                                   id_personal = c.id_personal,
                                   id_historial_clinico = c.id_historial_clinico,
                                   estado = c.estado,
                                   fecha_hora = c.fecha_hora,

                               }).FirstOrDefault();

                if (citas == null)
                {
                    return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                }
                return View(citas);
            }   

        }

        // POST: Citast/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {
                    
                    var cita = context.citas.Find(id);
                    if (cita == null)
                    {
                        return HttpNotFound(); 
                    }

                    context.citas.Remove(cita);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar la cita: " + ex.Message);
                return View();
            }
        }
    }
}
