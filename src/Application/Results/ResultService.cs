using QuestionnaireSystem.Application.Exceptions;
using QuestionnaireSystem.Application.Interviews;
using QuestionnaireSystem.Application.Questions;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Application.Results;

public sealed class ResultService : IResultService
{
    private readonly IInterviewRepository interviewRepository;
    private readonly IQuestionRepository questionRepository;
    private readonly IResultRepository resultRepository;

    public ResultService(
        IInterviewRepository interviewRepository,
        IQuestionRepository questionRepository,
        IResultRepository resultRepository)
    {
        this.interviewRepository = interviewRepository;
        this.questionRepository = questionRepository;
        this.resultRepository = resultRepository;
    }
    
    public async Task<Guid> SaveAnswerAndReturnNextQuestionIdAsync(SaveAnswerCommand command, CancellationToken cancellationToken)
    {
        var interview = await interviewRepository.GetFirstOrDefaultAsync(i => i.Id == command.InterviewId, cancellationToken)
            ?? throw new EntityNotFoundException("Interview not found");

        if (command.QuestionId != interview.CurrentQuestionId)
        {
            throw new ArgumentException("Question not currently available");
        }

        var question = await questionRepository.GetFirstOrDefaultAsync(q => q.Id == command.QuestionId, cancellationToken)
            ?? throw new EntityNotFoundException("Question not found");
        
        var results = Result.CreateList(interview.Id, question.Id, command.AnswerIds);
        
        await resultRepository.AddRangeAsync(results, cancellationToken);

        var nextQuestionId = await questionRepository
            .GetIdAsync(q => 
                q.SurveyId == command.SurveyId 
                && q.Order == question.Order + 1,
                cancellationToken);
        
        interview.UpdateQuestion(nextQuestionId);

        await interviewRepository.UpdateAsync(interview, cancellationToken);

        return nextQuestionId;
    }
}