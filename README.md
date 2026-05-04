# ИС отслеживания прогресса тренировок (WinForms + SQLite)

## Запуск
1. Установить .NET 8 SDK или выше.
2. Открыть `WinFormsApp2.sln` в Visual Studio 2022+.
3. Запустить проект `WinFormsApp2`.

При первом запуске автоматически создаётся `gym.db` рядом с exe и seed-данные.

## Тестовые аккаунты
- Admin: `admin@mail.com` / `1234`
- User: `user@mail.com` / `1234`

## Структура
- `WinFormsApp2/Models` — модели сущностей
- `WinFormsApp2/Data` — SQLite доступ и инициализация
- `WinFormsApp2/Forms` — формы Login/User/Admin и диалоги
- `WinFormsApp2/schema.sql` — SQL схема
