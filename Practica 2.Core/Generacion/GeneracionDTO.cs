using EIN.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ein.DTOS
{
    public class GeneracionSetDTO
    {
        [Required, StringLength(20)] public string Nombre { get; set; } = string.Empty;
    }
    public class GeneracionGetDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
