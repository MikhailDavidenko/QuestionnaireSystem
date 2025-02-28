using System.Linq.Expressions;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Application.Questions;

public interface IQuestionRepository
{
    Task<Question?> GetFirstOrDefaultAsync(Expression<Func<Question, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task<Guid> GetIdAsync(Expression<Func<Question, bool>> predicate, CancellationToken cancellationToken = default);
}