using System.Linq.Expressions;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Application.Surveys;

public interface ISurveyRepository
{
    Task<Survey?> GetFirstOrDefaultAsync(Expression<Func<Survey, bool>> predicate, CancellationToken cancellationToken = default);
}