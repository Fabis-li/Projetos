using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("USER");
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id)
                .HasColumnName("ID");

            entity.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(u => u.Password)
                .HasColumnName("PASSWORD")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(u => u.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(u => u.Age)
                .HasColumnName("AGE")
                .HasColumnType("INT");          

            entity.Property(u => u.CPF)
                .HasColumnName("CPF")
                .HasColumnType("VARCHAR")
                .HasMaxLength(11)
                .IsRequired();

            entity.Property(u => u.Image)
                .HasColumnName("IMAGE")
                .HasColumnType("VARBINARY")
                .HasMaxLength(8000);

            entity.Property(u => u.ResetToken)
                .HasColumnName("TOKEN")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);
            entity.HasData(new[] {
                new User (1,"Admin", "admim@email.com", "adminadmin", 32, "39963055834"),
             });

        }
    }
}
