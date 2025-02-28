using System.Linq.Expressions;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Application.Interviews;

public interface IInterviewRepository
{
    Task<Interview?> GetFirstOrDefaultAsync(Expression<Func<Interview, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task AddAsync(Interview result, CancellationToken token = default);
    
    Task UpdateAsync(Interview result, CancellationToken token = default);
}