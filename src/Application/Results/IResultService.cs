namespace QuestionnaireSystem.Application.Results;

public interface IResultService
{
    Task<Guid> SaveAnswerAndReturnNextQuestionIdAsync(SaveAnswerCommand command, CancellationToken cancellationToken);
}