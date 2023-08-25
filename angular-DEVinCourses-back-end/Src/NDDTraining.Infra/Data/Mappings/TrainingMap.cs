using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NDDTraining.Domain.Models;

namespace NDDTraining.Infra.Data.Mappings;

public class TrainingMap : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> entity)
    {
        entity.ToTable("TRAININGS");

        entity.HasKey(t => t.Id);

        entity.Property(t => t.Id)
            .HasColumnName("ID");

        entity.Property(t => t.Url)
            .HasColumnName("URL")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(t => t.Title)
            .HasColumnName("TITLE")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(t => t.Description)
            .HasColumnName("DESCRIPTION")
            .HasColumnType("VARCHAR")
            .HasMaxLength(400)
            .IsRequired();

        entity.Property(t => t.Teacher)
            .HasColumnName("TEACHER")
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .IsRequired();

        entity.Property(t => t.Duration)
            .HasColumnName("DURATION")
            .HasColumnType("TIME")
            .IsRequired();

        entity.Property(t => t.Active)
            .HasColumnName("ACTIVE")
            .IsRequired();

        entity.Property(t => t.Category)
            .HasColumnName("CATEGORY")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        entity.HasData(new[]{
            new Training(1, "https://certificadocursosonline.com/wp-content/uploads/2018/07/Curso-de-Manutenc%CC%A7a%CC%83o-de-Computadores.jpg", "Manutenção de Computadores", "Architecto eaque consectetur nostrum impedit earum at harum. Reiciendis suscipit soluta, ab, repellat ad, Architecto eaque consectetur nostrum impedit earum at harum. Architecto eaque consectetur nostrum impedit earum at harum., Architecto eaque consectetur nostrum impedit earum at harum.", "Carlos Silva", new TimeSpan(20,0,0), true, "tecnologia"
            ),
            new Training(2, "https://setcesp.org.br/wp-content/uploads/2019/08/treinamento.jpg", "Ingles Basico", "Neste curso, os alunos irão obter um conhecimento aprofundado sobre os recursos disponíveis sobre Inlges o basico.", "Rodrigo Rosa", new TimeSpan(70,0,0), true, "idioma"
            ),
            new Training(3, "https://setcesp.org.br/wp-content/uploads/2019/08/treinamento.jpg", "Redacao", "Neste curso, os alunos irão obter um conhecimento aprofundado sobre os recursos disponíveis.", "Maria Eduarda", new TimeSpan(18,0,0), true, "educacao"
            ),
        });
    }
}
