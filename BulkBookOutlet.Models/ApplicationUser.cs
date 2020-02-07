﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkBookOutlet.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }


        [NotMapped] // means the property below will not get pushed to database

        public string Role { get; set; }

      
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

    }
}
