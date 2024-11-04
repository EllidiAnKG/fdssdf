using System.Data;
using System.Data.SQLite;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private SQLiteConnection connection;
        private string dbPath = "ComputerEquipment.db";

        public Form1()
        {
            CreateDatabase();
            InitializeComponent();
            ConnectToDatabase();
            LoadComputers();
        }
        private void CreateDatabase()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath}"))
                {
                    conn.Open();

                    string createComputersTable = @"
            CREATE TABLE IF NOT EXISTS Computers (
              ID INTEGER PRIMARY KEY AUTOINCREMENT,
              Name VARCHAR(255) NOT NULL,
              Model VARCHAR(255) NOT NULL,
              OS VARCHAR(255) NOT NULL,
              DatePurchased DATE NOT NULL
            )";
                    using (SQLiteCommand command = new SQLiteCommand(createComputersTable, conn))
                    {
                        command.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                MessageBox.Show("База данных создана или уже существует.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания базы данных: {ex.Message}");
            }
        }
        private void ConnectToDatabase()
        {
            try
            {
                connection = new SQLiteConnection($"Data Source={dbPath}");
                connection.Open();
                Console.WriteLine("База данных подключена");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
            }
        }

        private void LoadComputers()
        {
            try
            {
                computersDataGridView.Columns.Add("ID", "ID");
                computersDataGridView.Columns.Add("Name", "Имя");
                computersDataGridView.Columns.Add("Model", "Модель");
                computersDataGridView.Columns.Add("OS", "ОС");
                computersDataGridView.Columns.Add("DatePurchased", "Дата покупки");

                string query = "SELECT * FROM Computers";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        computersDataGridView.Rows.Clear();
                        while (reader.Read())
                        {
                            computersDataGridView.Rows.Add(reader["ID"], reader["Name"], reader["Model"], reader["OS"], reader["DatePurchased"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }



        private void ClearInputFields()
        {
            nameTextBox.Text = "";
            modelTextBox.Text = "";
            osTextBox.Text = "";
            datePurchasedDateTimePicker.Value = DateTime.Now;
        }

        //private void deleteComputerButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (computersDataGridView.SelectedRows.Count == 0)
        //        {
        //            MessageBox.Show("Пожалуйста, выберите компьютер для удаления.");
        //            return;
        //        }

        //        int computerId = Convert.ToInt32(computersDataGridView.SelectedRows[0].Cells["ID"].Value);

        //        string query = "DELETE FROM Computers WHERE ID = @ComputerID";
        //        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@ComputerID", computerId);
        //            command.ExecuteNonQuery();
        //        }
        //        MessageBox.Show("Компьютер удален.");
        //        LoadComputers();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка удаления компьютера: {ex.Message}");
        //    }
        //}

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void computersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int computerId = Convert.ToInt32(computersDataGridView.Rows[e.RowIndex].Cells["ID"].Value);

                    // Загрузка деталей компьютера в форму
                    string query = "SELECT * FROM Computers WHERE ID = @ComputerID";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ComputerID", computerId);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nameTextBox.Text = reader["Name"].ToString();
                                modelTextBox.Text = reader["Model"].ToString();
                                osTextBox.Text = reader["OS"].ToString();
                                datePurchasedDateTimePicker.Value = Convert.ToDateTime(reader["DatePurchased"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = nameTextBox.Text;
                string model = modelTextBox.Text;
                string os = osTextBox.Text;
                DateTime datePurchased = datePurchasedDateTimePicker.Value;

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(model) || string.IsNullOrEmpty(os))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }
                string query = "INSERT INTO Computers (Name, Model, OS, DatePurchased) VALUES (@Name, @Model, @OS, @DatePurchased)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@OS", os);
                    command.Parameters.AddWithValue("@DatePurchased", datePurchased);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Компьютер добавлен.");
                LoadComputers();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления компьютера: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (computersDataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите компьютер для удаления.");
                    return;
                }

                int computerId = Convert.ToInt32(computersDataGridView.SelectedRows[0].Cells["ID"].Value);

                string query = "DELETE FROM Computers WHERE ID = @ComputerID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ComputerID", computerId);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Компьютер удален.");
                LoadComputers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления компьютера: {ex.Message}");
            }
        }
    }
}

