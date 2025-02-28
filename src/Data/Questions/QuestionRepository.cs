using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuestionnaireSystem.Application.Questions;
using QuestionnaireSystem.Data.Engine;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Data.Questions;

public sealed class QuestionRepository : IQuestionRepository
{
    private readonly AppDbContext context;

    public QuestionRepository(AppDbContext context)
    {
        this.context = context;
    }

    public Task<Question?> GetFirstOrDefaultAsync(Expression<Func<Question, bool>> predicate, CancellationToken cancellationToken)
        => context.Questions
            .Include(q => q.Answers)
            .FirstOrDefaultAsync(predicate, cancellationToken);

    public Task<Guid> GetIdAsync(Expression<Func<Question, bool>> predicate, CancellationToken cancellationToken = default)
        => context.Questions
            .Where(predicate)
            .Select(q => q.Id)
            .SingleOrDefaultAsync(cancellationToken);
}