using QuestionnaireSystem.Domain;
using QuestionnaireSystem.Web.Answers;

namespace QuestionnaireSystem.Web.Questions;

public static class QuestionMapperExtensions
{
    public static QuestionResponse MapToQuestionResponse(this Question question)
    {
        return new QuestionResponse
        {
            Id = question.Id,
            Text = question.Text,
            Options = question.Answers
                .Select(a => a.MapToAnswerResponse())
                .ToList()
        };
    }
}