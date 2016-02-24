using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NFLdb
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new
            SqlConnection("Data Source=Anson-PC;Initial Catalog=NFLdb;Integrated Security=True");
        SqlCommand com;
        DataTable TeamTable, PlayerTable, CoachTable, GMTable, StadiumTable, GameTable;
        DataTable SearchTable, SearchTable2, SearchTable3, SearchTable4, SearchTable5, SearchTable6;
        SqlDataAdapter sda, sda2, sda3, sda4, sda5, sda6, sda7, sda8, sda9, sda10, sda11, sda12;
        string txt;


        public Form1()
        {
            InitializeComponent();
            Load_Data();
        }

        private void teamsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.teamsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.nFLdbDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                com = new SqlCommand("INSERT into Teams values('"
                    + nameTextBox.Text + "',"
                    + winsTextBox.Text + ","
                    + losesTextBox.Text + ")", connection);
                com.ExecuteNonQuery();
                MessageBox.Show("Update Successful into Database");
                connection.Close();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
            Load_Data();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                com = new SqlCommand("Delete from Teams Where name = '"
                    + nameTextBox.Text + "'", connection);
                com.ExecuteNonQuery();
                MessageBox.Show("Delete Successful");
                connection.Close();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
            Load_Data();
        }

        void Clear()
        {
            nameTextBox.Text = "";
            winsTextBox.Text = "";
            losesTextBox.Text = "";
            player_numberTextBox.Text = "";
            teamTextBox.Text = "";
            positionTextBox.Text = "";
            date_of_birthTextBox.Text = "";
            player_heightTextBox.Text = "";
            player_weightTextBox.Text = "";
            collegeTextBox.Text = "";
            first_nameTextBox.Text = "";
            last_nameTextBox.Text = "";
            salaryTextBox.Text = "";
        }

        void Load_Data()
        {
            sda = new SqlDataAdapter("Select * From Teams", connection);
            sda2 = new SqlDataAdapter
                ("Select * From players order by team, player_number"
                , connection);
            TeamTable = new DataTable();
            PlayerTable = new DataTable();
            sda.Fill(TeamTable);
            sda2.Fill(PlayerTable);
            dataGridView1.DataSource = TeamTable;
            dataGridView2.DataSource = PlayerTable;
        }

        private void Add_Players_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                com = new SqlCommand("INSERT into players values("
                    + player_numberTextBox.Text + ",'"
                    + teamTextBox.Text + "','"
                    + positionTextBox.Text + "','"
                    + date_of_birthTextBox.Text + "',"
                    + player_heightTextBox.Text + ","
                    + player_weightTextBox.Text + ",'"
                    + collegeTextBox.Text + "','"
                    + first_nameTextBox.Text + "','"
                    + last_nameTextBox.Text + "',"
                    + salaryTextBox.Text
                    + ")", connection);
                com.ExecuteNonQuery();
                MessageBox.Show("Update Successful into Database");
                connection.Close();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
            Load_Data();
        }

        private void Delete_Players_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                com = new SqlCommand("Delete From players Where first_name = '"
                    + first_nameTextBox.Text + "' AND last_name = '"
                    + last_nameTextBox.Text + "'", connection);
                com.ExecuteNonQuery();
                MessageBox.Show("Delete Successful");
                connection.Close();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
            Load_Data();
        }

        private void Update_Players_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb2 = new SqlCommandBuilder(sda2);
            sda2.Update(PlayerTable);
            MessageBox.Show("Update Successful");
            Load_Data();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(TeamTable);
            MessageBox.Show("Update Successful");
        }

        private void Reset6_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void Clear_Game_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear_Team_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear_Player_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear_Coach_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear_GM_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear_Stadium_Click(object sender, EventArgs e)
        {
            Clear();
        }

        String txt4;



        private void Update_Game_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(sda6);
            sda6.Update(GameTable);
            MessageBox.Show("Update Successful");
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void Reset1_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void Reset2_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void Reset3_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        String txt1;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "Position":
                    txt1 = "position";
                    break;
                case "Number":
                    txt1 = "player_number";
                    break;
                case "Salary":
                    txt1 = "salary";
                    break;
                case "First Name":
                    txt1 = "first_name";
                    break;
                case "Last Name":
                    txt1 = "last_name";
                    break;
                case "College":
                    txt1 = "college";
                    break;
            }

        }

        private void Find_Player_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text == "Number")
                {
                    sda8 = new SqlDataAdapter("Select * from players where team like '"
                    + comboBox1.Text + "' and " + txt1 + " like '" + textBox2.Text + "'", connection);
                }

                else if (comboBox2.Text == "Position")
                {
                    sda8 = new SqlDataAdapter("Select * from players where team like '"
                    + comboBox1.Text + "' and " + txt1 + " like '" + textBox2.Text + "%'", connection);
                }

                else if (comboBox2.Text == "Salary")
                {
                    sda8 = new SqlDataAdapter("Select * from players where team like '"
                    + comboBox1.Text + "' and " + txt1 + " >= " + textBox2.Text + "", connection);
                }

                else if (comboBox2.Text == "" && textBox2.Text == "")
                {
                    sda8 = new SqlDataAdapter("Select * from players where team like '"
                        + comboBox1.Text + "'", connection);
                }

                else if (comboBox1.Text == "")
                {
                    sda8 = new SqlDataAdapter("Select * from players where " + txt1 + " like '%"
                        + textBox2.Text + "%'", connection);
                }

                else if (comboBox1.Text == "" && txt == "player_number")
                {
                    sda8 = new SqlDataAdapter("Select * from players where " + txt1 + " = "
                        + textBox2.Text + "", connection);
                }

                else
                {
                    sda8 = new SqlDataAdapter("Select * from players where team like '"
                    + comboBox1.Text + "' and " + txt1 + " like '%" + textBox2.Text + "%'", connection);
                }
                SearchTable2 = new DataTable();
                sda8.Fill(SearchTable2);
                dataGridView2.DataSource = SearchTable2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Find_Team_Click(object sender, EventArgs e)
        {
            try
            {
                sda7 = new SqlDataAdapter("Select * from Teams where name like '%"
                    + comboBox3.Text + "%'", connection);
                SearchTable = new DataTable();
                sda7.Fill(SearchTable);
                dataGridView1.DataSource = SearchTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
