using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Data.Results;

public sealed class ResultConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne<Interview>()
            .WithMany()
            .HasForeignKey(r => r.InterviewId);

        builder.HasOne<Question>()
            .WithMany()
            .HasForeignKey(r => r.QuestionId);

        builder.HasOne<Answer>()
            .WithMany()
            .HasForeignKey(r => r.AnswerId);
    }
}
