using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using QuestionnaireSystem.Application.Interviews;
using QuestionnaireSystem.Application.Questions;
using QuestionnaireSystem.Application.Results;
using QuestionnaireSystem.Application.Surveys;
using QuestionnaireSystem.Data.Engine;
using QuestionnaireSystem.Data.Interviews;
using QuestionnaireSystem.Data.Questions;
using QuestionnaireSystem.Data.Results;
using QuestionnaireSystem.Data.Surveys;

namespace QuestionnaireSystem.Data;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрирует репозитории
    /// </summary>
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
        => services
            .AddTransient<IQuestionRepository, QuestionRepository>()
            .AddTransient<IInterviewRepository, InterviewRepository>()
            .AddTransient<IResultRepository, ResultRepository>()
            .AddTransient<ISurveyRepository, SurveyRepository>();
    
    /// <summary>
    /// Регистрирует контекст
    /// </summary>
    public static IServiceCollection AddAppDbContext(this IServiceCollection services)
    {
        services.AddOptions<DbConnectionOptions>().BindConfiguration(DbConnectionOptions.OptionsKey);

        services
            .AddDbContext<AppDbContext>((provider, builder) =>
            {
                var connectionOptions = provider.GetRequiredService<IOptions<DbConnectionOptions>>();
                
                builder.UseNpgsql(connectionOptions.Value.RequiredConnectionString/*,
                    b => b.MigrationsAssembly("Data.Migrations.Postgre")*/);
            });

        return services;
    }
}