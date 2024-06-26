﻿using Microsoft.EntityFrameworkCore;
using TecnicosRegistros.Models;

namespace TecnicosRegistros.DAL;
public class Contexto : DbContext
{
    public DbSet<Tecnicos> Tecnicos { get; set; }
    public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
    public DbSet<Incentivos> Incentivos { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }
}