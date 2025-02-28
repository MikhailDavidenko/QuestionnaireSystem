namespace QuestionnaireSystem.Domain;

/// <summary>
/// Представляет результаты прохождения интервью.
/// </summary>
public sealed class Result
{
    /// <summary>
    /// Уникальный идентификатор результата.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Идентификатор интервью, к которому относится результат.
    /// </summary>
    public Guid InterviewId { get; private set; }

    /// <summary>
    /// Идентификатор вопроса, на который был дан ответ.
    /// </summary>
    public Guid QuestionId { get; private set; }

    /// <summary>
    /// Идентификатор ответа, выбранного пользователем.
    /// </summary>
    public Guid AnswerId { get; private set; }

    private Result(Guid id, Guid interviewId, Guid questionId, Guid answerId)
    {
        Id = id;
        InterviewId = interviewId;
        QuestionId = questionId;
        AnswerId = answerId;
    }

    /// <summary>
    /// Именованный конструктор для создания результата.
    /// </summary>
    /// <param name="interviewId">Идентификатор интервью.</param>
    /// <param name="questionId">Идентификатор вопроса.</param>
    /// <param name="answerIds">Идентификаторы ответов.</param>
    public static List<Result> CreateList(Guid interviewId, Guid questionId, List<Guid> answerIds)
    {
        var results = new List<Result>();

        foreach (var answerId in answerIds)
        {
            var result = new Result(Guid.NewGuid(), interviewId, questionId, answerId);
            results.Add(result);
        }

        return results;
    }
}
