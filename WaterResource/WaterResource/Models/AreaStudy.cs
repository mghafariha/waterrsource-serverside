﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WaterResource.Models
{
    public class AreaStudy
    {
        public int ID { get; set; }

        [DisplayName("نام محدوده")]
        [Required]
        public string Title { get; set; }

        [DisplayName("کد")]
        [Required]
        public string Code { get; set; }

        [DisplayName("نوع")]
        [Required]
        public string Kind { get; set; }

        [DisplayName("وضعیت")]
        [Required]
        public string Status { get; set; }
    }
}