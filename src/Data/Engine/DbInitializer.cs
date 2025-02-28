using Microsoft.EntityFrameworkCore;
using QuestionnaireSystem.Domain;

namespace QuestionnaireSystem.Data.Engine;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        EnsureDatabaseIsReady(context);
        
        context.Database.Migrate();
        
        if (context.Surveys.Any())
        {
            return;
        }

        var survey = Survey.Create("Анкета о предпочтениях", 
            "Это анкета, чтобы узнать ваши предпочтения.", 
            true);

        var question1 = Question.Create(survey.Id, "Какой ваш любимый цвет?", 1);
        var question2 = Question.Create(survey.Id, "Какой ваш любимый вид спорта?", 2);

        var answer1 = Answer.Create(question1.Id, "Красный");
        var answer2 = Answer.Create(question1.Id, "Синий");
        var answer3 = Answer.Create(question1.Id, "Зеленый");
        var answer4 = Answer.Create(question2.Id, "Футбол");
        var answer5 = Answer.Create(question2.Id, "Баскетбол");
        var answer6 = Answer.Create(question2.Id, "Теннис");

        context.Surveys.Add(survey);
        context.Questions.AddRange(question1, question2);
        context.Answers.AddRange(answer1, answer2, answer3, answer4, answer5, answer6);

        context.SaveChanges();
    }
    
    private static void EnsureDatabaseIsReady(AppDbContext context)
    {
        const int maxRetries = 5;
        int retryCount = 0;

        while (retryCount < maxRetries)
        {
            try
            {
                context.Database.CanConnect();
                return;
            }
            catch
            {
                retryCount++;
                Thread.Sleep(2000);
            }
        }

        throw new Exception("Не удалось подключиться к базе данных после нескольких попыток.");
    }
}