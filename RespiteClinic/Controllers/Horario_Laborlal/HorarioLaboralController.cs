using RespiteClinic.Models;
using RespiteClinic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RespiteClinic.Controllers.Horario_Laborlal
{
    public class HorarioLaboralController : Controller
    {
        // GET: HorarioLaboral
        public ActionResult Index()
        {
            List<Horario_laboral> listHorario;

            using (RespiteModel context = new RespiteModel())
            {

                listHorario = (from h in context.horario_laboral
                                    select new Horario_laboral()
                                    {

                                        id = h.id,
                                        id_personal = h.id_personal,
                                        fecha = h.fecha,    
                                        hora_entrada = h.hora_entrada,
                                        hora_salida = h.hora_salida,


                                    }).ToList();
            }
            return View(listHorario);
        }

        // GET: HorarioLaboral/Details/5
        public ActionResult Details(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Horario_laboral horario_Laboral = (from h in context.horario_laboral
                                                 where h.id == id
                                                 select new Horario_laboral()
                                                 {
                                                     id = h.id,
                                                     id_personal = h.id_personal,
                                                     fecha = h.fecha,
                                                     hora_entrada= h.hora_entrada,
                                                     hora_salida= h.hora_salida,

                                                 }).FirstOrDefault();


                    if (horario_Laboral == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(horario_Laboral);
                }
            }
        }

        // GET: HorarioLaboral/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorarioLaboral/Create
        [HttpPost]
        public ActionResult Create(Horario_laboral horario_Laboral)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RespiteModel context = new RespiteModel())
                    {
                        var horario_laboral = new horario_laboral
                        {
                            id=horario_Laboral.id,
                            id_personal =  horario_Laboral.id_personal,
                            fecha=horario_Laboral.fecha,
                            hora_entrada = horario_Laboral.hora_entrada,
                            hora_salida = horario_Laboral.hora_salida
                            


                        };
                        context.horario_laboral.Add(horario_laboral);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el registro: " + ex.Message);

            }
            return View(horario_Laboral);
        }

        // GET: HorarioLaboral/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HorarioLaboral/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Horario_laboral horario_Laboral)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {
                    var horario_laboral = new horario_laboral
                    {
                        id = horario_Laboral.id,
                        id_personal = horario_Laboral.id_personal,
                        fecha = horario_Laboral.fecha,
                        hora_entrada = horario_Laboral.hora_entrada,
                        hora_salida = horario_Laboral.hora_salida

                    };
                    context.Entry(horario_laboral).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HorarioLaboral/Delete/5
        public ActionResult Delete(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Horario_laboral horario_Laboral = (from h in context.horario_laboral
                                                       where h.id == id
                                                       select new Horario_laboral()
                                                       {
                                                           id = h.id,
                                                           id_personal = h.id_personal,
                                                           fecha = h.fecha,
                                                           hora_entrada = h.hora_entrada,
                                                           hora_salida = h.hora_salida,

                                                       }).FirstOrDefault();


                    if (horario_Laboral == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(horario_Laboral);
                }
            }
        }

        // POST: HorarioLaboral/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                using (RespiteModel context = new RespiteModel())
                {

                    var horario_laboral = context.horario_laboral.Find(id);
                    if (horario_laboral == null)
                    {
                        return HttpNotFound();
                    }

                    context.horario_laboral.Remove(horario_laboral);
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
