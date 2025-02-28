namespace QuestionnaireSystem.Domain;

/// <summary>
/// Представляет вариант ответа на вопрос.
/// </summary>
public sealed class Answer
{
    /// <summary>
    /// Уникальный идентификатор варианта ответа.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Идентификатор вопроса, к которому относится ответ.
    /// </summary>
    public Guid QuestionId { get; private set; }

    /// <summary>
    /// Текст варианта ответа.
    /// </summary>
    public string Text { get; private set; }

    private Answer(Guid id, Guid questionId, string text)
    {
        Id = id;
        QuestionId = questionId;
        Text = text;
    }

    /// <summary>
    /// Именованный конструктор для создания варианта ответа.
    /// </summary>
    /// <param name="questionId">Идентификатор вопроса.</param>
    /// <param name="text">Текст варианта ответа.</param>
    public static Answer Create(Guid questionId, string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Текст варианта ответа не может быть пустым", nameof(text));
        }
        
        return new Answer(Guid.NewGuid(), questionId, text);
    }
}