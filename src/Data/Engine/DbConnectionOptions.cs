namespace QuestionnaireSystem.Data.Engine;

public sealed class DbConnectionOptions
{
    public const string OptionsKey = "ConnectionStrings";

    public string? QuestionnaireSystemDb { get; set; }

    public string RequiredConnectionString => QuestionnaireSystemDb ?? throw new ArgumentNullException(EmptyServerUrlMessage);

    private const string EmptyServerUrlMessage = $"Конфигурационное значение «{nameof(QuestionnaireSystemDb)}» не задано";
}