namespace QuestionnaireSystem.Domain;

/// <summary>
/// Представляет вопрос анкеты.
/// </summary>
public class Question
{
    /// <summary>
    /// Уникальный идентификатор вопроса.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Идентификатор анкеты, к которой относится вопрос.
    /// </summary>
    public Guid SurveyId { get; private set; }

    /// <summary>
    /// Текст вопроса.
    /// </summary>
    public string Text { get; private set; }

    /// <summary>
    /// Порядок отображения вопроса.
    /// </summary>
    public int Order { get; private set; }
    
    public IReadOnlyList<Answer> Answers { get; private set; }

    private Question(Guid id, Guid surveyId, string text, int order)
    {
        Id = id;
        SurveyId = surveyId;
        Text = text;
        Order = order;
    }

    /// <summary>
    /// Именованный конструктор для создания вопроса.
    /// </summary>
    /// <param name="surveyId">Идентификатор анкеты.</param>
    /// <param name="text">Текст вопроса.</param>
    /// <param name="order">Порядок отображения вопроса.</param>
    public static Question Create(Guid surveyId, string text, int order)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Текст вопроса не может быть пустым", nameof(text));
        }
        
        return new Question(Guid.NewGuid(), surveyId, text, order);
    }
}