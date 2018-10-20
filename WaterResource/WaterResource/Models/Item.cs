using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WaterResource.Models
{
    public class Item
    {
        public int ID { get; set; }

        [DisplayName("نام ")]
        [Required]
        public string Title { get; set; }

       
    }
}