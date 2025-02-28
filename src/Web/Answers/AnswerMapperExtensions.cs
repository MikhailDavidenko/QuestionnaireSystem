using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Web.Answers;

public static class AnswerMapperExtensions
{
    public static AnswerResponse MapToAnswerResponse(this Answer answer)
    {
        return new AnswerResponse
        {
            Id = answer.Id,
            Text = answer.Text
        };
    }
}