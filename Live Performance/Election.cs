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
using Repository.Data;
using Repository.Logic;

namespace Live_Performance
{
    public partial class Election : Form
    {
        private Verkiezingsuitslag uitslag;
        private VerkiezingsuitslagRepository uitslagRepo;
        public Election(Verkiezingsuitslag u)
        {
            InitializeComponent();
            uitslagRepo = new VerkiezingsuitslagRepository(new VerkiezingsuitslagSqlContext());
            uitslag = u;
            lblName.Text = u.Naam;
            lblDate.Text = u.Datum.ToShortDateString();
            uitslagRepo.GetPartyElectionResults(u);
            FillLv();
            
        }

        private void FillLv()
        {
            foreach (Partij p in uitslag.Partijen)
            {
                ListViewItem item = new ListViewItem(p.Afkorting);
                item.SubItems.Add(p.Stemmen.ToString());
                item.SubItems.Add(p.Percentage.ToString());
                item.SubItems.Add(p.NieuweZetels.ToString());
                listView.Items.Add(item);
            }
        }
    }
}
