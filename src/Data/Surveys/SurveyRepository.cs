using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuestionnaireSystem.Application.Surveys;
using QuestionnaireSystem.Data.Engine;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Data.Surveys;

public sealed class SurveyRepository : ISurveyRepository
{
    private readonly AppDbContext context;

    public SurveyRepository(AppDbContext context)
    {
        this.context = context;
    }
    
    public Task<Survey?> GetFirstOrDefaultAsync(
        Expression<Func<Survey, bool>> predicate,
        CancellationToken cancellationToken)
            => context.Surveys.FirstOrDefaultAsync(predicate, cancellationToken);
}