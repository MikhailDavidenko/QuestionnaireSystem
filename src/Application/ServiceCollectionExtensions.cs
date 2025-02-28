using Microsoft.Extensions.DependencyInjection;
using QuestionnaireSystem.Application.Interviews;
using QuestionnaireSystem.Application.Questions;
using QuestionnaireSystem.Application.Results;

namespace QuestionnaireSystem.Application;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрирует бизнес сервисы
    /// </summary>
    public static IServiceCollection AddBusinessServices(
        this IServiceCollection services)
        => services
            .AddTransient<IInterviewService, InterviewService>()
            .AddTransient<IQuestionService, QuestionService>()
            .AddTransient<IResultService, ResultService>();
}