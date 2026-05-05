using Microsoft.Data.Sqlite;
using WinFormsApp2.Data;

namespace WinFormsApp2.Forms;

public class UserForm : Form
{
    private readonly int _userId;
    private readonly ComboBox _exerciseFilter = new() { Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly DataGridView _grid = new() { Dock = DockStyle.Top, Height = 280, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

    public UserForm(int userId, string userName)
    {
        _userId = userId;
        Text = $"Тренировки: {userName}";
        Width = 900;
        Height = 500;

        var addWorkoutBtn = new Button { Text = "Добавить тренировку", Width = 180 };
        addWorkoutBtn.Click += (_, _) => AddWorkout();
        var delWorkoutBtn = new Button { Text = "Удалить тренировку", Width = 180 };
        delWorkoutBtn.Click += (_, _) => DeleteWorkout();
        var addExerciseBtn = new Button { Text = "Добавить упражнение", Width = 180 };
        addExerciseBtn.Click += (_, _) => AddExerciseLog();
        var progressBtn = new Button { Text = "Показать прогресс", Width = 180 };
        progressBtn.Click += (_, _) => ShowProgress();
        var exerciseProgressBtn = new Button { Text = "Прогресс упражнения", Width = 180 };
        exerciseProgressBtn.Click += (_, _) => ShowExerciseProgress();
        var panel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 60 };
        panel.Controls.AddRange(new Control[] { addWorkoutBtn, delWorkoutBtn, addExerciseBtn, progressBtn, _exerciseFilter, exerciseProgressBtn });

        Controls.Add(_grid);
        Controls.Add(panel);
        Load += (_, _) =>
        {
            LoadWorkouts();
            LoadExercisesFilter();
        };
    }

    private void LoadWorkouts()
    {
        _grid.DataSource = DatabaseHelper.GetDataTable(
            "SELECT Id, Date, Duration FROM Workouts WHERE UserId=@uid ORDER BY Date DESC",
            new SqliteParameter("@uid", _userId));
    }

    private void AddWorkout()
    {
        var form = new WorkoutEditForm();
        if (form.ShowDialog() == DialogResult.OK)
        {
            DatabaseHelper.ExecuteNonQuery("INSERT INTO Workouts(Date,Duration,UserId) VALUES(@d,@dur,@uid)",
                new SqliteParameter("@d", form.WorkoutDate.ToString("yyyy-MM-dd")),
                new SqliteParameter("@dur", form.Duration),
                new SqliteParameter("@uid", _userId));
            DatabaseHelper.ExecuteNonQuery("INSERT INTO Progress(UserId,Date,Weight) VALUES(@u,@d,@w)",
                new SqliteParameter("@u", _userId), new SqliteParameter("@d", DateTime.Now.ToString("yyyy-MM-dd")),
                new SqliteParameter("@w", form.BodyWeight));
            LoadWorkouts();
        }
    }

    private void DeleteWorkout()
    {
        if (_grid.CurrentRow == null) return;
        var id = Convert.ToInt32(_grid.CurrentRow.Cells[0].Value);
        DatabaseHelper.ExecuteNonQuery("DELETE FROM Workouts WHERE Id=@id", new SqliteParameter("@id", id));
        LoadWorkouts();
    }

    private void AddExerciseLog()
    {
        if (_grid.CurrentRow == null)
        {
            MessageBox.Show("Выберите тренировку");
            return;
        }
        var workoutId = Convert.ToInt32(_grid.CurrentRow.Cells[0].Value);
        var form = new ExerciseLogForm();
        if (form.ShowDialog() == DialogResult.OK)
        {
            DatabaseHelper.ExecuteNonQuery("INSERT OR IGNORE INTO Exercises(Name,MuscleGroup) VALUES(@n,@m)",
                new SqliteParameter("@n", form.ExerciseName), new SqliteParameter("@m", form.MuscleGroup));

            var exerciseId = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT Id FROM Exercises WHERE Name=@n", new SqliteParameter("@n", form.ExerciseName)));
            DatabaseHelper.ExecuteNonQuery("INSERT INTO ExerciseLogs(WorkoutId,ExerciseId,Sets,Reps,Weight) VALUES(@w,@e,@s,@r,@we)",
                new SqliteParameter("@w", workoutId), new SqliteParameter("@e", exerciseId),
                new SqliteParameter("@s", form.Sets), new SqliteParameter("@r", form.Reps), new SqliteParameter("@we", form.Weight));
            LoadExercisesFilter();
            MessageBox.Show("Упражнение добавлено");
        }
    }

    private void ShowProgress()
    {
        using var form = new ProgressForm(_userId);
        form.ShowDialog();
    }

    private void ShowExerciseProgress()
    {
        if (_exerciseFilter.SelectedValue == null)
        {
            MessageBox.Show("Нет упражнений для отображения прогресса");
            return;
        }

        var exerciseId = Convert.ToInt32(_exerciseFilter.SelectedValue);
        _grid.DataSource = DatabaseHelper.GetExerciseProgress(_userId, exerciseId);
    }

    private void LoadExercisesFilter()
    {
        var dt = DatabaseHelper.GetUserExercises(_userId);
        _exerciseFilter.DataSource = dt;
        _exerciseFilter.DisplayMember = "Name";
        _exerciseFilter.ValueMember = "Id";
    }
}
