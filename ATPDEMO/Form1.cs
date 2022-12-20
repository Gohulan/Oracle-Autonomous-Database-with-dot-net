using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;

namespace ATPDEMO
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// When application start to debug it will display it connected with Oracle Cloud and db version 

			OracleConnection conn = new OracleConnection();
			conn.ConnectionString = "User ID=apexadmin; Password=Password#123; Data Source=orademodb_high";
			conn.Open();

			// Display Oracle Cloud Connected and Display Oracle ATP version 

			OracleCommand oraCmd1 = new OracleCommand("select * from v$version ", conn);
			OracleDataReader oraReader1;
			oraReader1 = oraCmd1.ExecuteReader();

			while (oraReader1.Read())
			{
				label2.Text = "Oracle ATP Version : "+oraReader1.GetString(0);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{

		}

		private void button1_Click_2(object sender, EventArgs e)
		{

		}

		private void button1_Click_3(object sender, EventArgs e)
		{

		}

		private void button1_Click_4(object sender, EventArgs e)
		{
			OracleConnection conn = new OracleConnection();
			conn.ConnectionString = "User ID=apexadmin; Password=Password#123; Data Source=orademodb_high";
			conn.Open();







			//OracleCommand oraCmd = new OracleCommand("select lname from demodata where fname='GOHULAN'", conn);
			OracleCommand oraCmd = new OracleCommand("select lname from demodata where fname='SOMANATHAN' ", conn);
			OracleDataReader oraReader;
			oraReader = oraCmd.ExecuteReader();

			while (oraReader.Read())
			{

				MessageBox.Show(oraReader.GetString(0));
			}

			oraReader.Close();
			conn.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string fname, lname, email;
			int mobile;

			fname = textBox1.Text;
			lname = textBox2.Text;
			email = textBox3.Text;
			mobile = Convert.ToInt32(textBox4.Text);

			OracleConnection conn = new OracleConnection();
			OleDbCommand cmd = new OleDbCommand();

			conn.ConnectionString = "User ID=apexadmin; Password=Password#123; Data Source=orademodb_high";
			conn.Open();

            OracleCommand oraCmd = new OracleCommand("INSERT INTO DEMODATA (LNAME, FNAME, EMAIL, MOBILE) VALUES ('"+lname+"','"+fname+"', '"+email+"' , '"+mobile+"') ", conn);
			
			int rowsupdated = oraCmd.ExecuteNonQuery();
			if (rowsupdated == 0)
                MessageBox.Show("Record not inserted");
            else
                MessageBox.Show("Success!");

			//Clear Textboxes 

			textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            conn.Dispose();


			 //         Developed By Somanathan Gohulan          //
			//                gohulan@cubemak.com				//

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
