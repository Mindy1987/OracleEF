using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebEFFirst.Models
{
    [Table("T_USER")]
    public class User
    {
        [Column("ID")]
        public string Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("PASSWORD")]
        public string Password { get; set; }
    }
}