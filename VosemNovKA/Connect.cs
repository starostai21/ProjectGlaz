using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VosemNovKA
{
    class Connect:AbsCl
    {
        StreamReader sr;
        private string connectStringg;
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataAdapter adapter;
        private DataSet ds;

        public Connect()
        {
            sr = new StreamReader("Connect.txt");
            connectStringg = sr.ReadLine();
            return;
        }

        new public void Sidu_interface(string sql)
        {
            con = new MySqlConnection(connectStringg);
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        new public DataSet IConO(string query)
        {
            con = new MySqlConnection(connectStringg);
            con.Open();
            adapter = new MySqlDataAdapter(query, con);
            ds = new DataSet();
            adapter.Fill(ds);
            con.Close();
            return ds;
        }

        public List<string> ListBD(string sql, int count_col)
        {
            List<string> l1 = new List<string>();
            con = new MySqlConnection(connectStringg);
            con.Open();

            MySqlCommand cmd2 = new MySqlCommand(sql, con);
            try
            {
                MySqlDataReader dr2 = cmd2.ExecuteReader();
                dr2.Read();
                for (int i = 0; i < count_col + 1; i++)
                {
                    l1.Add(dr2.GetValue(i).ToString());
                }
                dr2.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return l1;
        }

        public string[] ABD(string sql, int count_col)
        {
            string[] l1 = new string[count_col];
            con = new MySqlConnection(connectStringg);
            con.Open();

            MySqlCommand cmd2 = new MySqlCommand(sql, con);
            try
            {
                MySqlDataReader dr2 = cmd2.ExecuteReader();
                dr2.Read();
                for (int i = 0; i < count_col; i++)
                {
                    l1[i] = dr2.GetValue(i).ToString();
                }
                dr2.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return l1;
        }

        public DataTable ConDT(string sql)
        {
            MySqlDataReader dr;
            con = new MySqlConnection(connectStringg);
            con.Open(); //открываем БД

            DataTable dt = new DataTable();

            cmd = new MySqlCommand(sql, con);
            try
            {
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                con.Close(); //закрываем соединение, т.к. оно нам больше не нужно
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public string SEL(string sql) //select;insert;update;delit
        {
            DataTable dt = new DataTable();
            string s = "";
            con = new MySqlConnection(connectStringg);
            con.Open();
            MySqlCommand cmd2 = con.CreateCommand();
            try
            {
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = sql;
                MySqlDataReader dr1 = cmd2.ExecuteReader();
                while (dr1.Read()) // построчно считываем данные
                {
                    s = dr1.GetValue(0).ToString();
                }
                con.Close(); //закрываем соединение, т.к. оно нам больше не нужно
                             // MessageBox.Show("Успешно");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("s=null:"+ex.Message);
                s = null;
            }
            return s;
        }
    }
}
