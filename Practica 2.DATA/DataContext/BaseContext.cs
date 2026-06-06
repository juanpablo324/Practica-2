using EIN.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica_2.DATA.DataContext
{
    public class BaseContext:DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<AlumnoEntity> Alumnos { get; set; }
        public DbSet<GeneracionEntity> Generaciones { get; set; }

        public DbSet<GrupoEntity> Grupos { get; set; }
    }
}
