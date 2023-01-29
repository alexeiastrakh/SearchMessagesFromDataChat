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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=Oleksii;password=chess24;database=ChatTelegammmDataDb";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

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
                entity.Property(e => e.text);
                entity.Property(e => e.itDirection);
                entity.Property(e => e.Expirence);
            });

            modelBuilder.Entity<Root>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.type);
                entity.Property(e => e.name);
                entity.HasMany(d => d.messages);
                
                  
            });
    
        }
    }
}