using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Clientes2Controller : Controller
    {
        
        BD_B45818Entities3 baseDatos = new BD_B45818Entities3();
        // GET: Clientes2
        public ActionResult Index()
        {
            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.listaClientes = baseDatos.Cliente.ToList();
            modelo.listaTelefonos = baseDatos.Telefono.ToList();
            modelo.listaCuenta = baseDatos.Cuenta.ToList();
            return View(modelo);
        }

        public ActionResult Delete(string id)
        {
            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.modeloCliente = baseDatos.Cliente.Find(id);
            modelo.listaTelefonos = baseDatos.Telefono.Where(a => a.Cedula == id).ToList();
            modelo.listaCuenta = baseDatos.Cuenta.Where(a => a.Cedula == id).ToList();
            return View(modelo);
        }

        public ActionResult Edit(string id)
        {
            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.modeloCliente = baseDatos.Cliente.Find(id);
            modelo.listaTelefonos = baseDatos.Telefono.Where(a => a.Cedula == id).ToList();
            modelo.modeloTelefono1 = modelo.listaTelefonos[0];
            modelo.modeloTelefono2 = modelo.listaTelefonos[1];
            modelo.listaCuenta = baseDatos.Cuenta.Where(a => a.Cedula == id).ToList();
            modelo.modeloCuenta1 = modelo.listaCuenta[0];
            modelo.modeloCuenta2 = modelo.listaCuenta[1];
            modelo.modeloCuenta3 = modelo.listaCuenta[2];

            return View(modelo);
        }



        public ActionResult Details(string id)
        {
            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.modeloCliente = baseDatos.Cliente.Find(id);
            modelo.listaTelefonos = baseDatos.Telefono.Where(a => a.Cedula == id).ToList();
            modelo.listaCuenta = baseDatos.Cuenta.Where(a => a.Cedula == id).ToList();
            return View(modelo);
        }

        public ActionResult Create()
        {
            ModeloIntermedio modelo = new ModeloIntermedio();

            var usuarios = baseDatos.AspNetUsers.ToList();

            IEnumerable<SelectListItem> selectList = from s in usuarios
                                                     select new SelectListItem
                                                     {
                                                         Text = s.Email,
                                                         Value = s.Email
                                                     };
            modelo.clienteList = selectList;

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloIntermedio modelo)
        {
            if (ModelState.IsValid)
            {
                modelo.modeloCliente.AspNetUsers = baseDatos.AspNetUsers.Where(m => m.Email == modelo.clienteSelect).FirstOrDefault();
                baseDatos.Cliente.Add(modelo.modeloCliente);
                baseDatos.SaveChanges();
                if (modelo.modeloTelefono1.Numero != null)
                {
                    modelo.modeloTelefono1.Cedula = modelo.modeloCliente.Cedula;
                    baseDatos.Telefono.Add(modelo.modeloTelefono1);
                }
                if (modelo.modeloTelefono2.Numero != null)
                {
                    modelo.modeloTelefono2.Cedula = modelo.modeloCliente.Cedula;
                    baseDatos.Telefono.Add(modelo.modeloTelefono2);
                }
                if (modelo.modeloCuenta1.Numero != null)
                {
                    modelo.modeloCuenta1.Cedula = modelo.modeloCliente.Cedula;
                    baseDatos.Cuenta.Add(modelo.modeloCuenta1);
                }
                if (modelo.modeloCuenta2.Numero != null)
                {
                    modelo.modeloCuenta2.Cedula = modelo.modeloCliente.Cedula;
                    baseDatos.Cuenta.Add(modelo.modeloCuenta2);
                }
                if (modelo.modeloCuenta3.Numero != null)
                {
                    modelo.modeloCuenta3.Cedula = modelo.modeloCliente.Cedula;
                    baseDatos.Cuenta.Add(modelo.modeloCuenta3);
                }

                baseDatos.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Debe completar toda la información necesaria.");
                return View(modelo);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloIntermedio modelo)
        {
            if (ModelState.IsValid)
            {
                baseDatos.Cliente.Attach(modelo.modeloCliente);
                baseDatos.Entry(modelo.modeloCliente).State = System.Data.Entity.EntityState.Modified;
                baseDatos.SaveChanges();
                if (modelo.modeloTelefono1.Numero != null)
                {
                    modelo.modeloTelefono1.Cedula = modelo.modeloCliente.Cedula;
                    baseDatos.Entry(modelo.modeloTelefono1).State = System.Data.Entity.EntityState.Modified;
                    baseDatos.SaveChanges();
                }
                if (modelo.modeloTelefono2.Numero != null)
                {
                    modelo.modeloTelefono2.Cedula = modelo.modeloCliente.Cedula;
                    baseDatos.Entry(modelo.modeloTelefono2).State = System.Data.Entity.EntityState.Modified;
                    baseDatos.SaveChanges();
                }
                if (modelo.modeloCuenta1.Numero != null)
                {
                    modelo.modeloCuenta1.Cedula = modelo.modeloCliente.Cedula;
                    baseDatos.Entry(modelo.modeloCuenta1).State = System.Data.Entity.EntityState.Modified;
                    baseDatos.SaveChanges();
                }
                if (modelo.modeloCuenta2.Numero != null)
                {
                    modelo.modeloCuenta2.Cedula = modelo.modeloCliente.Cedula;
                    baseDatos.Entry(modelo.modeloCuenta2).State = System.Data.Entity.EntityState.Modified;
                    baseDatos.SaveChanges();
                }
                if (modelo.modeloCuenta3.Numero != null)
                {
                    modelo.modeloCuenta3.Cedula = modelo.modeloCliente.Cedula;
                    baseDatos.Entry(modelo.modeloCuenta3).State = System.Data.Entity.EntityState.Modified;
                    baseDatos.SaveChanges();
                }
                baseDatos.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Debe completar toda la información necesaria.");
                return View(modelo);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cliente cliente = baseDatos.Cliente.Find(id);
            baseDatos.Cliente.Remove(cliente);
            baseDatos.SaveChanges();
            return RedirectToAction("Index");
        }

    }
    }