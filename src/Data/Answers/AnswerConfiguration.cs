using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Data.Answers;

public sealed class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Text)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne<Question>()
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId);
    }
}