using QuestionnaireSystem.Application.Exceptions;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Application.Questions;

public sealed class QuestionService : IQuestionService
{
    private readonly IQuestionRepository questionRepository;

    public QuestionService(IQuestionRepository questionRepository)
    {
        this.questionRepository = questionRepository;
    }
    
    public async Task<Question> GetQuestionByIdAsync(Guid questionId, CancellationToken cancellationToken)
        => await questionRepository.GetFirstOrDefaultAsync(q => q.Id == questionId, cancellationToken)
            ?? throw new EntityNotFoundException($"Question {questionId} not found");
}