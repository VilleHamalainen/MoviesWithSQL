using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MoviesWithSQL.Model;
using System.Data.Linq;

namespace MoviesWithSQL
{
	public partial class Form1 : Form
	{
		private SqlConnection moviesConnect;
		private SqlCommand commandExample;
		private SqlDataReader reader;
		private string sql, output = "";
		private DataClasses1DataContext dbStuff;

		public Form1()
		{
			InitializeComponent();
		}
		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			// dbStuff = new DataClasses1DataContext();
			//comboBox1.DataSource = dbStuff.elokuvats;

			//dbStuff = new DataClasses1DataContext();
			//dataGridView1.DataSource = dbStuff.elokuvats;
			//var list = from elokuvat in dbStuff.elokuvats select elokuvat;
			//comboBox1.DisplayMember = "Nimi";
			//comboBox1.ValueMember = "Nimi";
			//comboBox1.DataSource = list;

			//comboBox1.Items.=  Table<elokuvat> elokuvats;
		}

		private void Button1_Click(object sender, EventArgs e)
		{

			using (moviesConnect = new SqlConnection(@"Data Source=DESKTOP-V7CERF7\SQLEXPRESS;Initial Catalog=Movies;Integrated Security=True")) { 
			moviesConnect.Open();
			}
			MessageBox.Show("Connection is open hoorrray");
			moviesConnect.Close();
			
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		
			//dataGridView1.displ
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			dbStuff = new DataClasses1DataContext();
			dataGridView1.DataSource = dbStuff.elokuvats;
			var list = from elokuvat in dbStuff.elokuvats select elokuvat;
			comboBox1.DisplayMember = "Nimi";
			comboBox1.ValueMember = "Nimi";
			comboBox1.DataSource = list;
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			SqlConnection moviesConnect1 = moviesConnect;
			moviesConnect1.Open();
			sql = "Select Nimi from elokuvat where Id = 3";
			using (commandExample = new SqlCommand(sql,
										  moviesConnect)) { 
			reader = commandExample.ExecuteReader();
			}

			int i = 0;
			while (reader.Read())
			{

				output = output + reader.GetValue(0); //+ "\n" + reader.GetValue(3);
				i++;
				MessageBox.Show(output);
			}
		
			reader.Close();
			commandExample.Dispose();
			moviesConnect.Close();
		}
	}
}
