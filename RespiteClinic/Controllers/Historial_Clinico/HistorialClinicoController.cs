using RespiteClinic.Models;
using RespiteClinic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RespiteClinic.Controllers.Historial_Clinico
{
    public class HistorialClinicoController : Controller
    {
        // GET: HistorialClinico
        public ActionResult Index()
        {
            List<Historial_clinico> listHistorial;

            using (RespiteModel context = new RespiteModel())
            {

                listHistorial = (from h in context.historial_clinico
                                    select new Historial_clinico()
                                    {

                                        id = h.id,
                                        id_paciente = h.id_paciente,
                                        fecha_registro_historial = h.fecha_registro_historial,
                                        historial_enfermedades = h.historial_enfermedades,
                                        motivo_consulta = h.motivo_consulta,
                                        diagnostico = h.diagnostico,
                                        tratamiento = h.tratamiento,


                                    }).ToList();
            }
            return View(listHistorial);
        }

        // GET: HistorialClinico/Details/5
        public ActionResult Details(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Historial_clinico historial_clinico = (from h in context.historial_clinico
                                                 where h.id == id
                                                 select new Historial_clinico()
                                                 {
                                                     id = h.id,
                                                     id_paciente = h.id_paciente,
                                                     fecha_registro_historial = h.fecha_registro_historial,
                                                     historial_enfermedades = h.historial_enfermedades,
                                                     motivo_consulta = h.motivo_consulta,
                                                     diagnostico = h.diagnostico,
                                                     tratamiento = h.tratamiento,


                                                 }).FirstOrDefault();


                    if (historial_clinico == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(historial_clinico);
                }
            }
        }

        // GET: HistorialClinico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialClinico/Create
        [HttpPost]
        public ActionResult Create(Historial_clinico historial_Clinico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RespiteModel context = new RespiteModel())
                    {
                        var historial_clinico = new historial_clinico
                        {
                            id = historial_Clinico.id,
                            id_paciente = historial_Clinico.id_paciente,
                            fecha_registro_historial = historial_Clinico.fecha_registro_historial,
                            historial_enfermedades = historial_Clinico.historial_enfermedades,
                            motivo_consulta = historial_Clinico.motivo_consulta,
                            diagnostico = historial_Clinico.diagnostico,
                            tratamiento = historial_Clinico.tratamiento,

                        };
                        context.historial_clinico.Add(historial_clinico);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el registro: " + ex.Message);

            }
            return View(historial_Clinico);
        }

        // GET: HistorialClinico/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistorialClinico/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Historial_clinico historial_Clinico)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {
                    var historial_clinico = new historial_clinico
                    {
                        id = historial_Clinico.id,
                        id_paciente = historial_Clinico.id_paciente,
                        fecha_registro_historial = historial_Clinico.fecha_registro_historial,
                        historial_enfermedades = historial_Clinico.historial_enfermedades,
                        motivo_consulta = historial_Clinico.motivo_consulta,
                        diagnostico = historial_Clinico.diagnostico,
                        tratamiento = historial_Clinico.tratamiento,

                    };
                    context.Entry(historial_clinico).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HistorialClinico/Delete/5
        public ActionResult Delete(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Historial_clinico historial_clinico = (from h in context.historial_clinico
                                                           where h.id == id
                                                           select new Historial_clinico()
                                                           {
                                                               id = h.id,
                                                               id_paciente = h.id_paciente,
                                                               fecha_registro_historial = h.fecha_registro_historial,
                                                               historial_enfermedades = h.historial_enfermedades,
                                                               motivo_consulta = h.motivo_consulta,
                                                               diagnostico = h.diagnostico,
                                                               tratamiento = h.tratamiento,


                                                           }).FirstOrDefault();


                    if (historial_clinico == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(historial_clinico);
                }
            }
        }

        // POST: HistorialClinico/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {

                    var historial_clinico = context.historial_clinico.Find(id);
                    if (historial_clinico == null)
                    {
                        return HttpNotFound();
                    }

                    context.historial_clinico.Remove(historial_clinico);
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
