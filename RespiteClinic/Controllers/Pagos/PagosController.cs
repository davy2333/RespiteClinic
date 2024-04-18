using RespiteClinic.Models;
using RespiteClinic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RespiteClinic.Controllers.PagosController
{
    public class PagosController : Controller
    {
        // GET: Pagos
        public ActionResult Index()
        {
            List<Pagos> listPagos;

            using (RespiteModel context = new RespiteModel())
            {

                listPagos = (from pa in context.pagos
                                    select new Pagos()
                                    {

                                        id = pa.id,
                                        id_personal = pa.id_personal,
                                        fecha_pago = pa.fecha_pago,
                                        monto = pa.monto,


                                    }).ToList();
            }
            return View(listPagos);
        }

        // GET: Pagos/Details/5
        public ActionResult Details(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Pagos pagos = (from p in context.pagos
                                                 where p.id == id
                                                 select new Pagos()
                                                 {
                                                     id = p.id,
                                                     id_personal = p.id_personal,
                                                     fecha_pago = p.fecha_pago,
                                                     monto = p.monto,

                                                 }).FirstOrDefault();


                    if (pagos == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(pagos);
                }
            }
        }

        // GET: Pagos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pagos/Create
        [HttpPost]
        public ActionResult Create(Pagos pago)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {
                    var pagos = new pagos
                    {
                        id = pago.id,
                        id_personal = pago.id_personal,
                        fecha_pago = pago.fecha_pago,
                        monto = pago.monto, 


                    };
                    context.pagos.Add(pagos);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el registro: " + ex.Message);

            }
            return View(pago);
        }

        // GET: Pagos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pagos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pagos pago)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {
                    var pagos = new pagos
                    {
                        id = pago.id,
                        id_personal = pago.id_personal,
                        fecha_pago = pago.fecha_pago,
                        monto = pago.monto,
                    };
                    context.Entry(pagos).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Pagos/Delete/5
        public ActionResult Delete(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Pagos pagos = (from p in context.pagos
                                   where p.id == id
                                   select new Pagos()
                                   {
                                       id = p.id,
                                       id_personal = p.id_personal,
                                       fecha_pago = p.fecha_pago,
                                       monto = p.monto,

                                   }).FirstOrDefault();


                    if (pagos == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(pagos);
                }
            }
        }

        // POST: Pagos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            try
            {

                using (RespiteModel context = new RespiteModel())
                {

                    var pago = context.pagos.Find(id);
                    if (pago == null)
                    {
                        return HttpNotFound();
                    }

                    context.pagos.Remove(pago);
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
