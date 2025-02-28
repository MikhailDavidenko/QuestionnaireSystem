using QuestionnaireSystem.Application.Results;
using QuestionnaireSystem.Data.Engine;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Data.Results;

public sealed class ResultRepository : IResultRepository
{
    private readonly AppDbContext context;

    public ResultRepository(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task AddRangeAsync(List<Result> result, CancellationToken token)
    {
        await context.Results.AddRangeAsync(result, token);
        await context.SaveChangesAsync(token);
    }
}