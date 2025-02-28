namespace QuestionnaireSystem.Domain;

/// <summary>
/// Представляет анкету.
/// </summary>
public sealed class Survey
{
    /// <summary>
    /// Уникальный идентификатор анкеты.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Название анкеты.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Описание анкеты.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Дата создания анкеты.
    /// </summary>
    public DateTime CreatedDate { get; private set; }

    /// <summary>
    /// Статус анкеты (активна/неактивна).
    /// </summary>
    public bool IsActive { get; private set; }

    private Survey(Guid id, string title, string description, DateTime createdDate, bool isActive)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedDate = createdDate;
        IsActive = isActive;
    }

    /// <summary>
    /// Именованный конструктор для создания анкеты.
    /// </summary>
    /// <param name="title">Название анкеты.</param>
    /// <param name="description">Описание анкеты.</param>
    /// <param name="isActive">Статус анкеты.</param>
    public static Survey Create(string title, string description, bool isActive)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Название анкеты не может быть пустым", nameof(title));
        }
        
        return new Survey(Guid.NewGuid(), title, description, DateTime.UtcNow, isActive);
    }
}