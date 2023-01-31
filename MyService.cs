using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TelegramSearhMessageBot
{
    public class Context : DbContext
    {
    
        public DbSet<Root> Roots { get; set; }
        public DbSet<Message> MessagesItems { get; set; }
        public DbSet<TextEntity> TextEntities { get; set; }
        public DbSet<Java> java { get; set; }
        public DbSet<Python> Python { get; set; }
        public DbSet<Csharp> csharps { get; set; }
        public DbSet<Cplusplus> cplusplus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
              optionsBuilder.UseSqlServer("Server=DESKTOP-DMI7F36; Database=DBChaat; Trusted_Connection=True;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.type);
                entity.Property(e => e.date);
                entity.Property(e => e.date_unixtime);
                entity.HasMany(e => e.text_entities);
                entity.HasMany(e => e.python);
                entity.HasMany(e => e.csharp);
                entity.HasMany(e => e.cplusplus);
                entity.HasMany(e => e.javas);
            });

            modelBuilder.Entity<Root>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.type);
                entity.Property(e => e.name);
                entity.HasMany(d => d.messages);


            });
            modelBuilder.Entity<TextEntity>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.type);
                entity.Property(e => e.text);


            });
            modelBuilder.Entity<Python>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.PythonVacancy);
         
            });
            modelBuilder.Entity<Cplusplus>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.CplusplusVacancy);

            });
            modelBuilder.Entity<Csharp>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.CsharpVacancy);

            });
            modelBuilder.Entity<Java>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.JavaVacancy);

            });

        }
    }
}
