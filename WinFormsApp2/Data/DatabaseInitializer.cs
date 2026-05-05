using Microsoft.Data.Sqlite;

namespace WinFormsApp2.Data;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        CreateTables();
        SeedData();
    }

    private static void CreateTables()
    {
        var sql = @"
PRAGMA foreign_keys = ON;
CREATE TABLE IF NOT EXISTS Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Email TEXT NOT NULL UNIQUE,
    Password TEXT NOT NULL,
    Role TEXT NOT NULL CHECK(Role IN ('Admin','User','Trainer'))
);
CREATE TABLE IF NOT EXISTS Workouts (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Date TEXT NOT NULL,
    Duration INTEGER NOT NULL,
    UserId INTEGER NOT NULL,
    FOREIGN KEY(UserId) REFERENCES Users(Id) ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS Exercises (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL UNIQUE,
    MuscleGroup TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS ExerciseLogs (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    WorkoutId INTEGER NOT NULL,
    ExerciseId INTEGER NOT NULL,
    Sets INTEGER NOT NULL,
    Reps INTEGER NOT NULL,
    Weight REAL NOT NULL,
    FOREIGN KEY(WorkoutId) REFERENCES Workouts(Id) ON DELETE CASCADE,
    FOREIGN KEY(ExerciseId) REFERENCES Exercises(Id) ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS Progress (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER NOT NULL,
    Date TEXT NOT NULL,
    Weight REAL NOT NULL,
    FOREIGN KEY(UserId) REFERENCES Users(Id) ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS Devices (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER NOT NULL,
    Type TEXT NOT NULL CHECK(Type IN ('Android','iOS','ПК')),
    Model TEXT NOT NULL,
    FOREIGN KEY(UserId) REFERENCES Users(Id) ON DELETE CASCADE
);
";
        DatabaseHelper.ExecuteNonQuery(sql);
    }

    private static void SeedData()
    {
        DatabaseHelper.ExecuteNonQuery(@"INSERT OR IGNORE INTO Users(Name,Email,Password,Role) VALUES
('Администратор','admin@mail.com','1234','Admin'),
('Пользователь','user@mail.com','1234','User');");

        DatabaseHelper.ExecuteNonQuery(@"INSERT OR IGNORE INTO Exercises(Name,MuscleGroup) VALUES
('Жим лежа','Грудь'),
('Приседания','Ноги'),
('Становая тяга','Спина');");
    }
}
