using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Design;
using WebApp1.Data;

namespace WebApp1.Models
{
    public class Household
    {
        [Key]
        public Guid Id { get; set; }
    }
}