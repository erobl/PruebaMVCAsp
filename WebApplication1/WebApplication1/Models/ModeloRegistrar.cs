using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class ModeloRegistrar
    {
        public RegisterViewModel usuario { get; set; }

        public IEnumerable<SelectListItem> rolList { get; set; }
        public string rolSelect { get; set; }

        
    }
}