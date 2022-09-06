using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;


namespace CRUDOperation.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }
    }
}
