using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NDDTraining.Domain.Models;

namespace NDDTraining.Infra.Data.Mappings;

public class RegistrationMap : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> entity)
    {
        entity.ToTable("REGISTRATION");

        entity.HasKey(r => r.Id);

        entity.Property(r => r.Id)
            .HasColumnName("ID");

        entity.Property(m => m.UserId)
            .HasColumnName("USER_ID")
            .HasColumnType("INT")
            .IsRequired();

        entity.Property(m => m.TrainingId)
            .HasColumnName("TRAINING_ID")
            .HasColumnType("INT")
            .IsRequired();


        entity.Property(m => m.Status)
            .HasColumnName("STATUS")
            .HasMaxLength(50)
            .HasColumnType("VARCHAR")
            .IsRequired();
        
        entity.HasOne<Training>(r => r.Training)
            .WithMany()
            .HasForeignKey(r => r.TrainingId)
            .OnDelete(DeleteBehavior.NoAction);

        entity.HasOne<User>(r => r.User)
            .WithMany(u => u.Registrations)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
