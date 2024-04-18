using RespiteClinic.Models;
using RespiteClinic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RespiteClinic.Controllers.DepartamentoController
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            List<Departamento> listDepartamento;

            using (RespiteModel context = new RespiteModel())
            {

                listDepartamento = (from d in context.departamento
                                    select new Departamento()
                                    {

                                        id = d.id,
                                        id_personal = d.id_personal,
                                        id_paciente = d.id_paciente,
                                        nombre_departamento = d.nombre_departamento,
                                        descripcion = d.descripcion,

                                    }).ToList();
            }   
            return View(listDepartamento);
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Departamento departamento = (from d in context.departamento
                                                         where d.id == id
                                                         select new Departamento()
                                                         {
                                                             id = d.id,
                                                             id_personal = d.id_personal,
                                                             id_paciente= d.id_paciente,
                                                             nombre_departamento =  d.nombre_departamento,
                                                             descripcion = d.descripcion

                                                         }).FirstOrDefault();


                    if (departamento == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(departamento);
                }
            }
            
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        [HttpPost]
        public ActionResult Create(Departamento departamentos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RespiteModel context = new RespiteModel())
                    {
                        var departamento = new departamento
                        {
                            id = departamentos.id,
                            id_personal = departamentos.id_personal,
                            id_paciente = departamentos.id_paciente,
                            nombre_departamento = departamentos.nombre_departamento,
                            descripcion = departamentos.descripcion,
                           
                            
                        };
                        context.departamento.Add(departamento);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }

                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el registro: " + ex.Message);

            }
            return View(departamentos);
        }

        // GET: Departamento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departamento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Departamento departamento)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {
                    var departamentos = new departamento
                    {
                        id = departamento.id,
                        id_personal = departamento.id_personal,
                        id_paciente = departamento.id_paciente,
                        nombre_departamento = departamento.nombre_departamento,
                        descripcion = departamento.descripcion

                    };
                    context.Entry(departamentos).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Departamento/Delete/5
        public ActionResult Delete(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Departamento departamento = (from d in context.departamento
                                                 where d.id == id
                                                 select new Departamento()
                                                 {
                                                     id = d.id,
                                                     id_personal = d.id_personal,
                                                     id_paciente = d.id_paciente,
                                                     nombre_departamento = d.nombre_departamento,
                                                     descripcion = d.descripcion

                                                 }).FirstOrDefault();


                    if (departamento == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(departamento);
                }
            }
        }

        // POST: Departamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                using (RespiteModel context = new RespiteModel())
                {

                    var departamentos = context.departamento.Find(id);
                    if (departamentos == null)
                    {
                        return HttpNotFound();
                    }

                    context.departamento.Remove(departamentos);
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
