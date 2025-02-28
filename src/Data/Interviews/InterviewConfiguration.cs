using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Data.Interviews;

public sealed class InterviewConfiguration : IEntityTypeConfiguration<Interview>
{
    public void Configure(EntityTypeBuilder<Interview> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.StartDate)
            .IsRequired();

        builder.HasOne<Survey>()
            .WithMany()
            .HasForeignKey(i => i.SurveyId);
    }
}
