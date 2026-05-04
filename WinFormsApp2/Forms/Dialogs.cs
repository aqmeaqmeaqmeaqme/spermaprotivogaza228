using WinFormsApp2.Data;

namespace WinFormsApp2.Forms;

public class UserEditForm : Form
{
    private readonly TextBox _name = new() { Width = 250 };
    private readonly TextBox _email = new() { Width = 250 };
    private readonly TextBox _password = new() { Width = 250 };
    private readonly ComboBox _role = new() { Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

    public string UserName => _name.Text.Trim();
    public string Email => _email.Text.Trim();
    public string Password => _password.Text.Trim();
    public string Role => _role.SelectedItem?.ToString() ?? "User";

    public UserEditForm()
    {
        Text = "Добавить пользователя";
        _role.Items.AddRange(new[] { "User", "Admin" });
        _role.SelectedIndex = 0;
        var ok = new Button { Text = "Сохранить", Width = 250 };
        ok.Click += (_, _) => DialogResult = DialogResult.OK;
        Controls.Add(new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(20), Controls = { new Label { Text = "Имя" }, _name, new Label { Text = "Email" }, _email, new Label { Text = "Пароль" }, _password, new Label { Text = "Роль" }, _role, ok } });
        Width = 330; Height = 320;
    }
}

public class WorkoutEditForm : Form
{
    private readonly DateTimePicker _date = new() { Width = 250 };
    private readonly NumericUpDown _duration = new() { Width = 250, Minimum = 10, Maximum = 500, Value = 60 };
    private readonly NumericUpDown _bodyWeight = new() { Width = 250, Minimum = 30, Maximum = 300, DecimalPlaces = 1, Value = 70 };
    public DateTime WorkoutDate => _date.Value.Date;
    public int Duration => (int)_duration.Value;
    public double BodyWeight => (double)_bodyWeight.Value;

    public WorkoutEditForm()
    {
        Text = "Добавить тренировку";
        var ok = new Button { Text = "Сохранить", Width = 250 };
        ok.Click += (_, _) => DialogResult = DialogResult.OK;
        Controls.Add(new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(20), Controls = { new Label { Text = "Дата" }, _date, new Label { Text = "Длительность (мин)" }, _duration, new Label { Text = "Вес тела (кг)" }, _bodyWeight, ok } });
        Width = 340; Height = 290;
    }
}

public class ExerciseLogForm : Form
{
    private readonly TextBox _name = new() { Width = 250 };
    private readonly TextBox _muscle = new() { Width = 250 };
    private readonly NumericUpDown _sets = new() { Width = 250, Minimum = 1, Maximum = 20, Value = 3 };
    private readonly NumericUpDown _reps = new() { Width = 250, Minimum = 1, Maximum = 100, Value = 12 };
    private readonly NumericUpDown _weight = new() { Width = 250, Minimum = 0, Maximum = 500, DecimalPlaces = 1, Value = 20 };
    public string ExerciseName => _name.Text.Trim();
    public string MuscleGroup => _muscle.Text.Trim();
    public int Sets => (int)_sets.Value;
    public int Reps => (int)_reps.Value;
    public double Weight => (double)_weight.Value;

    public ExerciseLogForm()
    {
        Text = "Добавить упражнение";
        var ok = new Button { Text = "Сохранить", Width = 250 };
        ok.Click += (_, _) => DialogResult = DialogResult.OK;
        Controls.Add(new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(20), Controls = { new Label { Text = "Название" }, _name, new Label { Text = "Группа мышц" }, _muscle, new Label { Text = "Подходы" }, _sets, new Label { Text = "Повторения" }, _reps, new Label { Text = "Вес" }, _weight, ok } });
        Width = 340; Height = 410;
    }
}

public class ProgressForm : Form
{
    public ProgressForm(int userId)
    {
        Text = "Прогресс веса";
        Width = 500; Height = 350;
        var grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        grid.DataSource = DatabaseHelper.GetDataTable("SELECT Date, Weight FROM Progress WHERE UserId=@u ORDER BY Date DESC", new Microsoft.Data.Sqlite.SqliteParameter("@u", userId));
        Controls.Add(grid);
    }
}
