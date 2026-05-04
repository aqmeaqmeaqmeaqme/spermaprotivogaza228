using Microsoft.Data.Sqlite;
using WinFormsApp2.Data;

namespace WinFormsApp2.Forms;

public class AdminForm : Form
{
    private readonly DataGridView _grid = new() { Dock = DockStyle.Top, Height = 300, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

    public AdminForm()
    {
        Text = "Панель администратора";
        Width = 800;
        Height = 450;

        var addBtn = new Button { Text = "Добавить пользователя", Width = 180 };
        addBtn.Click += (_, _) => AddUser();
        var delBtn = new Button { Text = "Удалить пользователя", Width = 180 };
        delBtn.Click += (_, _) => DeleteUser();

        var panel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 50 };
        panel.Controls.AddRange(new Control[] { addBtn, delBtn });

        Controls.Add(_grid);
        Controls.Add(panel);
        Load += (_, _) => LoadUsers();
    }

    private void LoadUsers() => _grid.DataSource = DatabaseHelper.GetDataTable("SELECT Id, Name, Email, Role FROM Users ORDER BY Id");

    private void AddUser()
    {
        var form = new UserEditForm();
        if (form.ShowDialog() == DialogResult.OK)
        {
            DatabaseHelper.ExecuteNonQuery("INSERT INTO Users(Name,Email,Password,Role) VALUES(@n,@e,@p,@r)",
                new SqliteParameter("@n", form.UserName), new SqliteParameter("@e", form.Email),
                new SqliteParameter("@p", form.Password), new SqliteParameter("@r", form.Role));
            LoadUsers();
        }
    }

    private void DeleteUser()
    {
        if (_grid.CurrentRow == null) return;
        var id = Convert.ToInt32(_grid.CurrentRow.Cells[0].Value);
        if (MessageBox.Show("Удалить пользователя?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Users WHERE Id=@id", new SqliteParameter("@id", id));
            LoadUsers();
        }
    }
}
