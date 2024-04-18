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

namespace RespiteClinic.Controllers.CitasInventarioController
{
    public class CitasInventarioController : Controller
    {
        // GET: CitasInventario
        public ActionResult Index()
        {
            List<Citas_inventario> listCitasInventario;

            using (RespiteModel context = new RespiteModel())
            {

                listCitasInventario = (from c in context.citas_inventario
                             select new Citas_inventario()
                             {

                                 id = c.id,
                                 id_citas = c.id_citas,
                                 id_inventario = c.id_inventario,
                                 cantidad_utilizada = c.cantidad_utilizada,

                             }).ToList();

            }
            return View(listCitasInventario);
        }

        // GET: CitasInventario/Details/5
        public ActionResult Details(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Citas_inventario citas_inventario = (from c in context.citas_inventario
                                   where c.id == id
                                   select new Citas_inventario()
                                   {
                                       id = c.id,
                                       id_citas = c.id_citas,
                                       id_inventario= c.id_inventario,
                                       cantidad_utilizada = c.cantidad_utilizada

                                   }).FirstOrDefault();


                    if (citas_inventario == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(citas_inventario);
                }
            }      
        }

        // GET: CitasInventario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CitasInventario/Create
        [HttpPost]
        public ActionResult Create(Citas_inventario cita_Inv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RespiteModel context = new RespiteModel())
                    {
                        var citas_inventario = new citas_inventario
                        {
                            id = cita_Inv.id,
                            id_citas = cita_Inv.id_citas,
                            id_inventario = cita_Inv.id_inventario,
                            cantidad_utilizada = cita_Inv.cantidad_utilizada
                        };
                        context.citas_inventario.Add(citas_inventario);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }

                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el registro: " + ex.Message);

            }
            return View(cita_Inv);
        }

        // GET: CitasInventario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CitasInventario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Citas_inventario cita_Inv)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {
                    var citas_inventario = new citas_inventario
                    {
                        id = cita_Inv.id,
                        id_citas = cita_Inv.id_citas,
                        id_inventario = cita_Inv.id_inventario,
                        cantidad_utilizada = cita_Inv.cantidad_utilizada
                    };
                    context.Entry(citas_inventario).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: CitasInventario/Delete/5
        public ActionResult Delete(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    Citas_inventario citas_inventario = (from c in context.citas_inventario
                                                         where c.id == id
                                                         select new Citas_inventario()
                                                         {
                                                             id = c.id,
                                                             id_citas = c.id_citas,
                                                             id_inventario = c.id_inventario,
                                                             cantidad_utilizada = c.cantidad_utilizada

                                                         }).FirstOrDefault();


                    if (citas_inventario == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(citas_inventario);
                }
            }

        }

        // POST: CitasInventario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {

                    var cita_inventario = context.citas_inventario.Find(id);
                    if (cita_inventario == null)
                    {
                        return HttpNotFound();
                    }

                    context.citas_inventario.Remove(cita_inventario);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar la cita: " + ex.Message);
                return View();
            }
        }
    }
}
