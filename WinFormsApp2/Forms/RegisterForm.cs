using WinFormsApp2.Data;

namespace WinFormsApp2.Forms;

public class RegisterForm : Form
{
    private readonly TextBox _login = new() { Width = 250, PlaceholderText = "Логин" };
    private readonly TextBox _password = new() { Width = 250, PlaceholderText = "Пароль", UseSystemPasswordChar = true };
    private readonly ComboBox _role = new() { Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox _deviceType = new() { Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

    public RegisterForm()
    {
        Text = "Регистрация";
        Width = 360;
        Height = 360;
        StartPosition = FormStartPosition.CenterParent;

        _role.Items.Add("User");
        _role.SelectedIndex = 0;

        _deviceType.Items.AddRange(new[] { "Android", "iOS", "ПК" });
        _deviceType.SelectedIndex = 0;

        var saveButton = new Button { Text = "Зарегистрировать", Width = 250, Height = 35 };
        saveButton.Click += (_, _) => Register();

        var layout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            Padding = new Padding(25)
        };

        layout.Controls.AddRange(new Control[]
        {
            new Label { Text = "Логин" }, _login,
            new Label { Text = "Пароль" }, _password,
            new Label { Text = "Роль" }, _role,
            new Label { Text = "Тип устройства" }, _deviceType,
            saveButton
        });

        Controls.Add(layout);
    }

    private void Register()
    {
        var login = _login.Text.Trim();
        var password = _password.Text.Trim();
        var role = _role.SelectedItem?.ToString() ?? "User";
        var deviceType = _deviceType.SelectedItem?.ToString();

        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Заполните логин и пароль");
            return;
        }

        if (string.IsNullOrWhiteSpace(deviceType))
        {
            MessageBox.Show("Выберите тип устройства");
            return;
        }

        try
        {
            var userId = DatabaseHelper.CreateUser(login, password, role);
            DatabaseHelper.CreateDevice(userId, deviceType);
            MessageBox.Show("Пользователь зарегистрирован");
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка регистрации: {ex.Message}");
        }
    }
}
