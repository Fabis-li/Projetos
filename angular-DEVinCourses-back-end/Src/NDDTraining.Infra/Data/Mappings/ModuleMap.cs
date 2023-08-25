using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NDDTraining.Domain.Models;

namespace NDDTraining.Infra.Data.Mappings;

public class ModuleMap : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> entity)
    {
        entity.ToTable("MODULES");

        entity.HasKey(m => m.Id);

        entity.Property(m => m.Id)
            .HasColumnName("ID");

        entity.Property(m => m.TitleModule)
            .HasColumnName("TITLE_MODULE")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(m => m.Link)
            .HasColumnName("LINK")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(m => m.Image)
            .HasColumnName("IMAGE")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(m => m.DescriptionModule)
            .HasColumnName("DESCRIPTION_MODULE")
            .HasColumnType("VARCHAR")
            .HasMaxLength(300)
            .IsRequired();

        entity.Property(m => m.StatusModule)
            .HasColumnName("STATUS_MODULE")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        /* entity.HasOne<Training>(m => m.Training)
            .WithMany(t => t.Modules)
            .HasForeignKey(m => m.TrainingId); */
        
        entity.HasData(new[]{
            new Module(1, 1, "Módulo 1", "vbs7jKRMuiA", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "Lorem ipsum dolor sit amet consectetur.", "finalizado"),
            new Module(2, 1, "Módulo 2", "3CC_YtyD7Po", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "Lorem ipsum dolor sit amet consectetur.", "disponivel"),
            new Module(3, 1, "Módulo 3", "TxxkFWty09g", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "Lorem ipsum dolor sit amet consectetur.", "disponivel"),
            new Module(4, 2, "Módulo 1", "vbs7jKRMuiA", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "Lorem ipsum dolor sit amet consectetur.", "finalizado"),
            new Module(5, 2, "Módulo 2", "3CC_YtyD7Po", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "Lorem ipsum dolor sit amet consectetur.", "disponivel"),
            new Module(6, 2, "Módulo 3", "TxxkFWty09g", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "Lorem ipsum dolor sit amet consectetur.", "disponivel"),
            new Module(7, 3, "Módulo 1", "vbs7jKRMuiA", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "Lorem ipsum dolor sit amet consectetur.", "finalizado"),
            new Module(8, 3, "Módulo 2", "3CC_YtyD7Po", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "Lorem ipsum dolor sit amet consectetur.", "disponivel"),
            new Module(9, 3, "Módulo 3", "TxxkFWty09g", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "Lorem ipsum dolor sit amet consectetur.", "disponivel"),
        });
    }
}
