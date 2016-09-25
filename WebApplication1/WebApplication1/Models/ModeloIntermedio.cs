using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class ModeloIntermedio
    {
        public Cliente modeloCliente { get; set; }
        public Telefono modeloTelefono1 { get; set; }
        public Telefono modeloTelefono2 { get; set; }   
        public Cuenta modeloCuenta1 { get; set; }
        public Cuenta modeloCuenta2 { get; set; }
        public Cuenta modeloCuenta3 { get; set; }
        public List<Cliente> listaClientes = new List<Cliente>();
        public List<Telefono> listaTelefonos = new List<Telefono>();
        public List<Cuenta> listaCuenta = new List<Cuenta>();

        public IEnumerable<SelectListItem> clienteList { get; set; }
        public string clienteSelect { get; set; }
    }

}
