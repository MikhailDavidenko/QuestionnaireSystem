# QuestionnaireSystem

## БД

### Миграции 

Для создания миграций используется EF Core CLI. Необходимо выполнить следующие команды из src:

```shell
dotnet ef migrations add Init --startup-project Web --context QuestionnaireSystem.Data.Engine.AppDbContext --project Data
```

Миграции применяются при каждом запуске приложения.