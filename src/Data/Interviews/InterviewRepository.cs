using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuestionnaireSystem.Application.Interviews;
using QuestionnaireSystem.Data.Engine;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Data.Interviews;

public sealed class InterviewRepository : IInterviewRepository
{
    private readonly AppDbContext context;

    public InterviewRepository(AppDbContext context)
    {
        this.context = context;
    }
    
    public Task<Interview?> GetFirstOrDefaultAsync(
        Expression<Func<Interview, bool>> predicate,
        CancellationToken cancellationToken)
            => context.Interviews.FirstOrDefaultAsync(predicate, cancellationToken);
    
    public async Task AddAsync(Interview result, CancellationToken token)
    {
        await context.Interviews.AddAsync(result, token);
        await context.SaveChangesAsync(token);
    }
    
    public async Task UpdateAsync(Interview result, CancellationToken token)
    {
        context.Interviews.Update(result);
        await context.SaveChangesAsync(token);
    }
}