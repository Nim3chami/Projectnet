using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace projectnet
{
    public partial class FormAddUser : Form
    {
        private const string UsersFilePath = "users.txt";

        public FormAddUser()
        {
            InitializeComponent();

            // Subscribe event handlers here instead of Designer
            btnAdd.Click += btnAdd_Click;
            btnRemove.Click += btnRemove_Click;

            btnAdd.MouseEnter += (s, e) => { btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 150, 245); };
            btnAdd.MouseLeave += (s, e) => { btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 120, 215); };

            btnRemove.MouseEnter += (s, e) => { btnRemove.BackColor = System.Drawing.Color.FromArgb(230, 60, 60); };
            btnRemove.MouseLeave += (s, e) => { btnRemove.BackColor = System.Drawing.Color.FromArgb(200, 40, 40); };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string adminUser = txtAdminUsername.Text.Trim();
            string adminPass = txtAdminPassword.Text;
            string newUser = txtNewUsername.Text.Trim();
            string newPass = txtNewPassword.Text;

            if (string.IsNullOrEmpty(adminUser) || string.IsNullOrEmpty(adminPass) ||
                string.IsNullOrEmpty(newUser) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateAdmin(adminUser, adminPass))
            {
                MessageBox.Show("Admin credentials invalid.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UserExists(newUser))
            {
                MessageBox.Show("User already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddUser(newUser, newPass);
            MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string adminUser = txtAdminUsername.Text.Trim();
            string adminPass = txtAdminPassword.Text;
            string userToRemove = txtRemoveUsername.Text.Trim();

            if (string.IsNullOrEmpty(adminUser) || string.IsNullOrEmpty(adminPass) || string.IsNullOrEmpty(userToRemove))
            {
                MessageBox.Show("Please fill all admin credentials and username to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateAdmin(adminUser, adminPass))
            {
                MessageBox.Show("Admin credentials invalid.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!UserExists(userToRemove))
            {
                MessageBox.Show("User does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userToRemove.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Cannot remove the admin user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (RemoveUser(userToRemove))
            {
                MessageBox.Show($"User '{userToRemove}' removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRemoveUsername.Clear();
            }
            else
            {
                MessageBox.Show("Failed to remove user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateAdmin(string username, string password)
        {
            try
            {
                var lines = File.ReadAllLines(UsersFilePath);
                return lines.Any(line =>
                {
                    var parts = line.Split(',');
                    return parts.Length == 2 &&
                           parts[0].Equals(username, StringComparison.OrdinalIgnoreCase) &&
                           parts[1] == password &&
                           parts[0].Equals("admin", StringComparison.OrdinalIgnoreCase);
                });
            }
            catch
            {
                return false;
            }
        }

        private bool UserExists(string username)
        {
            try
            {
                var lines = File.ReadAllLines(UsersFilePath);
                return lines.Any(line =>
                {
                    var parts = line.Split(',');
                    return parts.Length == 2 &&
                           parts[0].Equals(username, StringComparison.OrdinalIgnoreCase);
                });
            }
            catch
            {
                return false;
            }
        }

        private void AddUser(string username, string password)
        {
            try
            {
                File.AppendAllLines(UsersFilePath, new[] { $"{username},{password}" });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add user: " + ex.Message);
            }
        }

        private bool RemoveUser(string username)
        {
            try
            {
                var lines = File.ReadAllLines(UsersFilePath).ToList();
                var filteredLines = lines.Where(line =>
                {
                    var parts = line.Split(',');
                    return parts.Length == 2 && !parts[0].Equals(username, StringComparison.OrdinalIgnoreCase);
                }).ToList();

                if (filteredLines.Count == lines.Count)
                {
                    return false; // no user removed
                }

                File.WriteAllLines(UsersFilePath, filteredLines);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing user: " + ex.Message);
                return false;
            }
        }

        private void lblAdminPassword_Click(object sender, EventArgs e)
        {
            // Optional empty handler - remove if unused
        }

        private void lblNewUsername_Click(object sender, EventArgs e)
        {
            // Optional empty handler - remove if unused
        }
    }
}
