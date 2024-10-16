﻿using HospitalAppointment.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Context
{
    public class PostgreSqlContext : DbContext
    {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=yourdb;Username=youruser;Password=yourpassword");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Doctor-Appointments ilişkilendirmesi
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(a => a.DoctorId);

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
