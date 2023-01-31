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
        public DbSet<ItDirection> ItDirections { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
              optionsBuilder.UseSqlServer("Server=DESKTOP-DMI7F36; Database=DBChaaat; Trusted_Connection=True;TrustServerCertificate=True");

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
            modelBuilder.Entity<ItDirection>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.direction);
              


            });

        }
    }
}
