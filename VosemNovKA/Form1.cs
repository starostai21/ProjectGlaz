using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VosemNovKA
{
    public partial class Form1 : Form
    {
        Connect con = new Connect();
        SqlCl sq = new SqlCl();
        public int num_table=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            dataGridViewMat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMat.AllowUserToAddRows = false;
            dataGridViewMat.DataSource = con.IConO(sq.QueryMat).Tables[0];
            //dataGridView1.Columns[0].Visible = false;

            dataGridViewProd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProd.AllowUserToAddRows = false;
            dataGridViewProd.DataSource = con.IConO(sq.QueryProd).Tables[0];

            dataGridViewProdMat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProdMat.AllowUserToAddRows = false;
            dataGridViewProdMat.DataSource = con.IConO(sq.QueryProdMat).Tables[0];
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void Tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tables.SelectedIndex == 0)
            {
                num_table = 1;
            }
            if (Tables.SelectedIndex == 1)
            {
                num_table = 2;
            }
            if (Tables.SelectedIndex == 2)
            {
                num_table = 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WpfElementi we = new WpfElementi();
            we.Show();
        }
    }
}
