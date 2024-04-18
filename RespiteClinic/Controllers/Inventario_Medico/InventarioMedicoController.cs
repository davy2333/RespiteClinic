using RespiteClinic.Models;
using RespiteClinic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RespiteClinic.Controllers.Inventario_Medico
{
    public class InventarioMedicoController : Controller
    {
        // GET: InventarioMedico
        public ActionResult Index()
        {
            List<Inventario_medico> listInventario;

            using (RespiteModel context = new RespiteModel())
            {

                listInventario = (from i in context.inventario_medico
                                    select new Inventario_medico()
                                    {

                                        id = i.id,
                                        nombre_producto = i.nombre_producto,
                                        descripcion = i.descripcion,
                                        stock = i.stock,
                                        MOQ = i.MOQ,
                                        precio = i.precio,
                                        fecha_caducidad = i.fecha_caducidad,
                                        proveedor = i.proveedor,

                                    }).ToList();
            }
            return View(listInventario);
        }

        // GET: InventarioMedico/Details/5
        public ActionResult Details(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Inventario_medico inventario_medico = (from i in context.inventario_medico
                                                 where i.id == id
                                                 select new Inventario_medico()
                                                 {
                                                     
                                                     id = i.id,
                                                     nombre_producto = i.nombre_producto,
                                                     descripcion = i.descripcion,
                                                     stock = i.stock,
                                                     MOQ = i.MOQ,
                                                     precio = i.precio,
                                                     fecha_caducidad = i.fecha_caducidad,
                                                     proveedor = i.proveedor,

                                                 }).FirstOrDefault();


                    if (inventario_medico == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(inventario_medico);
                }
            }
        }

        // GET: InventarioMedico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventarioMedico/Create
        [HttpPost]
        public ActionResult Create(Inventario_medico InventarioMedico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RespiteModel context = new RespiteModel())
                    {
                        var inventario_medico = new inventario_medico
                        {
                            id = InventarioMedico.id,
                            nombre_producto = InventarioMedico.nombre_producto,
                            descripcion = InventarioMedico.descripcion,
                            stock = InventarioMedico.stock,
                            MOQ = InventarioMedico.MOQ, 
                            precio = InventarioMedico.precio,
                            fecha_caducidad = InventarioMedico.fecha_caducidad,
                            proveedor = InventarioMedico.proveedor,




                        };
                        context.inventario_medico.Add(inventario_medico);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el registro: " + ex.Message);

            }
            return View(InventarioMedico);
        }

        // GET: InventarioMedico/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventarioMedico/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Inventario_medico InventarioMedico)
        {
            try
            {
                using (RespiteModel context = new RespiteModel())
                {
                    var inventario_medico = new inventario_medico
                    {
                        id = InventarioMedico.id,
                        nombre_producto = InventarioMedico.nombre_producto,
                        descripcion = InventarioMedico.descripcion,
                        stock = InventarioMedico.stock,
                        MOQ = InventarioMedico.MOQ,
                        precio = InventarioMedico.precio,
                        fecha_caducidad = InventarioMedico.fecha_caducidad,
                        proveedor = InventarioMedico.proveedor,

                    };
                    context.Entry(inventario_medico).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: InventarioMedico/Delete/5
        public ActionResult Delete(int id)
        {
            using (RespiteModel context = new RespiteModel())
            {
                {
                    // Buscar la cita por su ID en la base de datos
                    Inventario_medico inventario_medico = (from i in context.inventario_medico
                                                           where i.id == id
                                                           select new Inventario_medico()
                                                           {

                                                               id = i.id,
                                                               nombre_producto = i.nombre_producto,
                                                               descripcion = i.descripcion,
                                                               stock = i.stock,
                                                               MOQ = i.MOQ,
                                                               precio = i.precio,
                                                               fecha_caducidad = i.fecha_caducidad,
                                                               proveedor = i.proveedor,

                                                           }).FirstOrDefault();


                    if (inventario_medico == null)
                    {
                        return HttpNotFound(); // Si no se encuentra la cita, devolver un error 404
                    }

                    return View(inventario_medico);
                }
            }
        }

        // POST: InventarioMedico/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                using (RespiteModel context = new RespiteModel())
                {

                    var inventario_medico = context.inventario_medico.Find(id);
                    if (inventario_medico == null)
                    {
                        return HttpNotFound();
                    }

                    context.inventario_medico.Remove(inventario_medico);
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
