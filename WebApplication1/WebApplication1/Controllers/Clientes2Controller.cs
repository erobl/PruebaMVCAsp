using System;
using System.Collections.Generic;
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

        public ActionResult Edit()
        {
            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.listaClientes = baseDatos.Cliente.ToList();
            modelo.listaTelefonos = baseDatos.Telefono.ToList();
            modelo.listaCuenta = baseDatos.Cuenta.ToList();
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloIntermedio modelo)
        {
            if (ModelState.IsValid)
            {
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
                baseDatos.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Debe completar toda la información necesaria.");
                return View(modelo);
            }
        }

    }
    }