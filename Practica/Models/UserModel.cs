using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica.Models
{
    public class UserModel
    {
        [Display(Name = "Id")]
        public int UserId { get; set; }

        [Display(Name = "Usuario")]
        [DataType(DataType.Text)]
        [StringLength(10)]
        public string UserName { get; set; }
        public string Company { get; set; }
    }
}