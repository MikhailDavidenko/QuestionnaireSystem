using QuestionnaireSystem.Application.Exceptions;
using QuestionnaireSystem.Application.Questions;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Application.Interviews;

public sealed class InterviewService : IInterviewService
{
    private readonly IInterviewRepository interviewRepository;
    private readonly IQuestionRepository questionRepository;

    public InterviewService(IInterviewRepository interviewRepository, IQuestionRepository questionRepository)
    {
        this.interviewRepository = interviewRepository;
        this.questionRepository = questionRepository;
    }

    public async Task<Interview> GetInterviewByIdAsync(Guid id, Guid surveyId, CancellationToken cancellationToken)
        => await interviewRepository.GetFirstOrDefaultAsync(
            interview => interview.Id == id && interview.SurveyId == surveyId, 
            cancellationToken) 
                ?? throw new EntityNotFoundException($"Interview {id} for survey {surveyId} not found");
    
    public async Task<Interview> CreateInterviewAsync(Guid surveyId, CancellationToken cancellationToken)
    {
        var firstQuestion = await questionRepository
            .GetFirstOrDefaultAsync(q => q.SurveyId == surveyId && q.Order == 1, cancellationToken)
                ?? throw new EntityNotFoundException($"First question for survey {surveyId} not found");
        
        var interview = Interview.Create(surveyId, firstQuestion.Id);
        
        await interviewRepository.AddAsync(interview, cancellationToken);
        
        return interview;
    }
}