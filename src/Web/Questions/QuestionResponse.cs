using QuestionnaireSystem.Web.Answers;

namespace QuestionnaireSystem.Web.Questions;

public sealed class QuestionResponse
{
    public Guid Id { get; set; }
    
    public string? Text { get; set; }
    
    public List<AnswerResponse> Options { get; set; } = new();
}