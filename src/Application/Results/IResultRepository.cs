using System.Linq.Expressions;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Application.Results;

public interface IResultRepository
{
    Task AddRangeAsync(List<Result> result, CancellationToken token = default);
}