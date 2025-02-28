namespace QuestionnaireSystem.Application.Results;

public sealed record SaveAnswerCommand(
    Guid QuestionId,
    Guid InterviewId,
    Guid SurveyId,
    List<Guid> AnswerIds);