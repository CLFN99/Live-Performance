using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Repository.Logic;
using Repository.Data;

namespace Live_Performance
{
    public partial class ChangePartyName : Form
    {
        private Partij partij;
        public ChangePartyName(Partij p)
        {
            InitializeComponent();
            partij = p;
        }

        private void btnChangePartyName_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
