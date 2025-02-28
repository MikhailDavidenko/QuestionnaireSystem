using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Data.Questions;

public sealed class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Text)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(q => q.Order)
            .IsRequired();

        builder.HasOne<Survey>()
            .WithMany()
            .HasForeignKey(q => q.SurveyId);

        builder.HasIndex(q => q.Order);
    }
}