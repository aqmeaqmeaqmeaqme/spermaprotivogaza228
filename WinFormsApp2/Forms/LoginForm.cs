using Microsoft.Data.Sqlite;
using WinFormsApp2.Data;

namespace WinFormsApp2.Forms;

public class LoginForm : Form
{
    private readonly TextBox _email = new() { PlaceholderText = "Email", Width = 250 };
    private readonly TextBox _password = new() { PlaceholderText = "Пароль", Width = 250, UseSystemPasswordChar = true };

    public LoginForm()
    {
        Text = "Вход";
        Width = 350;
        Height = 220;
        StartPosition = FormStartPosition.CenterScreen;

        var loginButton = new Button { Text = "Войти", Width = 250, Height = 35 };
        loginButton.Click += LoginButton_Click;
        var registerButton = new Button { Text = "Регистрация", Width = 250, Height = 35 };
        registerButton.Click += (_, _) =>
        {
            using var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        };

        var layout = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(30), AutoScroll = true };
        layout.Controls.AddRange(new Control[] { new Label { Text = "Email" }, _email, new Label { Text = "Пароль" }, _password, loginButton, registerButton });
        Controls.Add(layout);
    }

    private void LoginButton_Click(object? sender, EventArgs e)
    {
        try
        {
            using var reader = DatabaseHelper.ExecuteReader(
                "SELECT Id, Name, Role FROM Users WHERE Email=@email AND Password=@password",
                new SqliteParameter("@email", _email.Text.Trim()),
                new SqliteParameter("@password", _password.Text.Trim()));

            if (!reader.Read())
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            var userId = reader.GetInt32(0);
            var name = reader.GetString(1);
            var role = reader.GetString(2);

            Hide();
            Form next = role == "Admin" ? new AdminForm() : new UserForm(userId, name);
            next.FormClosed += (_, _) => Close();
            next.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка входа: {ex.Message}");
        }
    }
}
