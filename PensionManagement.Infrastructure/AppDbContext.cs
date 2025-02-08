using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatientMangementApi.PensionManagement.Domain;

namespace PatientMangementApi.PensionManagement.Infrastructure
{
public class AppDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientRecord> PatientRecords { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
}