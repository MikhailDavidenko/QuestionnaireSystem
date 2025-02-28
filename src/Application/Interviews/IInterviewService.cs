using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Application.Interviews;

public interface IInterviewService
{
    Task<Interview> GetInterviewByIdAsync(Guid id, Guid surveyId, CancellationToken cancellationToken);
    
    Task<Interview> CreateInterviewAsync(Guid surveyId, CancellationToken cancellationToken);
}