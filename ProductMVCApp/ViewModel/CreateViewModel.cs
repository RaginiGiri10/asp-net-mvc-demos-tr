using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductMVCApp.ViewModel
{
    public class CreateViewModel
    {
        [Required(ErrorMessage ="Product Name is mandatory.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Product Price is mandatory")]
        [Range(1,500000,ErrorMessage ="Price must be in between 1 & 500000")]
        public int ProductPrice { get; set; }

        [Required(ErrorMessage = "Product Origin is mandatory")]
        public string ProductOrigin { get; set; }
    }
}