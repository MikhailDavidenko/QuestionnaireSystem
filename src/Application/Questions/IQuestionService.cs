using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Application.Questions;

public interface IQuestionService
{
    Task<Question> GetQuestionByIdAsync(Guid questionId, CancellationToken cancellationToken);
}