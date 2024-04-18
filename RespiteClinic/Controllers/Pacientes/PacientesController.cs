using RespiteClinic.Models;
using RespiteClinic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RespiteClinic.Controllers.PacientesController
{
    public class PacientesController : Controller
    {
        // GET: Pacientes
        public ActionResult Index()
        {
            List<Pacientes> listPacientes;

            using (RespiteModel context = new RespiteModel())
            {

                listPacientes = (from p in context.pacientes
                                    select new Pacientes()
                                    {

                                        id = p.id,
                                        nombre = p.nombre,
                                        fecha_nacimiento = p.fecha_nacimiento,
                                        genero = p.genero,
                                        direccion = p.direccion,
                                        telefono = p.telefono,

                                    }).ToList();
            }
            return View(listPacientes);
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Pacientes pacientes = (from p in context.pacientes
                                                 where p.id == id
                                                 select new Pacientes()
                                                 {
                                                     id = p.id,
                                                     nombre = p.nombre,
                                                     fecha_nacimiento = p.fecha_nacimiento,
                                                     genero = p.genero,
                                                     direccion=p.direccion,
                                                     telefono=p.telefono,
                                                     

                                                 }).FirstOrDefault();


                    if (pacientes == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(pacientes);
                }
            }
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        public ActionResult Create(Pacientes paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RespiteModel context = new RespiteModel())
                    {
                        var pacientes = new pacientes
                        {
                            id = paciente.id,
                            nombre = paciente.nombre,
                            fecha_nacimiento = paciente.fecha_nacimiento,
                            genero = paciente.genero,
                            direccion = paciente.direccion,
                            telefono = paciente.telefono,


                        };
                        context.pacientes.Add(pacientes);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el registro: " + ex.Message);

            }
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pacientes paciente)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {
                    var pacientes = new pacientes
                    {
                        id = paciente.id,
                        nombre = paciente.nombre,
                        fecha_nacimiento = paciente.fecha_nacimiento,
                        genero = paciente.genero,
                        direccion = paciente.direccion,
                        telefono = paciente.telefono,

                    };
                    context.Entry(pacientes).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Pacientes pacientes = (from p in context.pacientes
                                           where p.id == id
                                           select new Pacientes()
                                           {
                                               id = p.id,
                                               nombre = p.nombre,
                                               fecha_nacimiento = p.fecha_nacimiento,
                                               genero = p.genero,
                                               direccion = p.direccion,
                                               telefono = p.telefono,


                                           }).FirstOrDefault();


                    if (pacientes == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(pacientes);
                }
            }
        }

        // POST: Pacientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                using (RespiteModel context = new RespiteModel())
                {

                    var pacientes = context.pacientes.Find(id);
                    if (pacientes == null)
                    {
                        return HttpNotFound();
                    }

                    context.pacientes.Remove(pacientes);
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
