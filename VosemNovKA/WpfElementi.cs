using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Data;

namespace VosemNovKA
{
    public partial class WpfElementi : Form
    {
        TableMay tm = new TableMay();
        int max1;
        int min1;
        UserControlWpf wpfControl = new UserControlWpf();
        UserControlWpf1 wpfControl1 = new UserControlWpf1();

        public WpfElementi()
        {
            InitializeComponent();

           
            
            elementHost1.Child = wpfControl;

            elementHost2.Child = wpfControl1;

            /*
            ElementHost host = new ElementHost();
            host.Left = 0;
            host.Top = 0;
            host.Dock = DockStyle.Fill; 
            host.Child = wpfControl;
            this.Controls.Add(host);
            */
        }

        private void WpfElementi_Load(object sender, EventArgs e)
        {
            min1 = 1;
            max1 = 21;

            dataGridView1.DataSource = tm.ForList(min1,max1);
        }
    }

    
}
