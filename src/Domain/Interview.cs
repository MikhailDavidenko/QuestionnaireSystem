namespace QuestionnaireSystem.Domain;

/// <summary>
/// Представляет запись о прохождении анкеты пользователем.
/// </summary>
public sealed class Interview
{
    /// <summary>
    /// Уникальный идентификатор интервью.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Идентификатор анкеты, к которой относится интервью.
    /// </summary>
    public Guid SurveyId { get; private set; }
    
    /// <summary>
    /// Идентификатор вопроса, к которой относится интервью.
    /// </summary>
    public Guid CurrentQuestionId { get; private set; }

    /// <summary>
    /// Дата начала прохождения анкеты.
    /// </summary>
    public DateTime StartDate { get; private set; }

    /// <summary>
    /// Дата завершения прохождения анкеты.
    /// </summary>
    public DateTime? EndDate { get; private set; }

    private Interview(Guid id, Guid surveyId, Guid currentQuestionId, DateTime startDate, DateTime? endDate)
    {
        if (startDate > endDate)
        {
            throw new ArgumentException("Start date cannot be greater than end date");
        }
        
        Id = id;
        SurveyId = surveyId;
        CurrentQuestionId = currentQuestionId;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void UpdateQuestion(Guid questionId)
    {
        CurrentQuestionId = questionId;
    }

    /// <summary>
    /// Именованный конструктор для создания интервью.
    /// </summary>
    /// <param name="surveyId">Идентификатор анкеты.</param>
    public static Interview Create(Guid surveyId, Guid questionId)
    {
        return new Interview(Guid.NewGuid(), surveyId, questionId, DateTime.UtcNow, null);
    }
}
