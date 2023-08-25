using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NDDTraining.Domain.Models;

namespace NDDTraining.Infra.Data.Mappings;

public class CompletedModuleMap : IEntityTypeConfiguration<CompletedModule>
{
    public void Configure(EntityTypeBuilder<CompletedModule> entity)
    {
        entity.ToTable("COMPLETED_MODULE");

        entity.HasKey(rm => rm.Id);

        entity.Property(rm => rm.Id)
            .HasColumnName("ID");

        entity.Property(rm => rm.ModuleId)
            .HasColumnName("MODULE_ID")
            .HasColumnType("INT")
            .IsRequired();

        entity.Property(rm => rm.RegistrationId)
            .HasColumnName("REGISTRATION_ID")
            .HasColumnType("INT")
            .IsRequired();
        
        entity.HasOne<Registration>(rm => rm.Registration)
            .WithMany(r => r.CompletedModules)
            .HasForeignKey(rm => rm.RegistrationId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne<Module>(rm => rm.Module)
            .WithMany()
            .HasForeignKey(rm => rm.ModuleId)
            .OnDelete(DeleteBehavior.Restrict);
            
    }
}
