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
    public partial class Party : Form
    {
        private Partij partij;
        private LidRepository lidRepo;
        private List<Lid> leden;
        private PartijRepository partijRepo;

        public Party(Partij p)
        {
            InitializeComponent();
            lidRepo = new LidRepository(new LidSqlContext());
            partijRepo = new PartijRepository(new PartijSqlContext());
            leden = lidRepo.GetAll();
            partij = p;
            lblPartyName.Text = partij.Naam;
            lblPartyAfk.Text = partij.Afkorting;
            foreach(Lid l in leden)
            {
                if(l.Id == partij.LijsttrekkerId)
                {
                    lblPartyRep.Text = lblPartyRep.Text + l.Naam;
                }
            }
            lblSeats.Text = lblSeats.Text + partij.Zetels.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangePartyName cpn = new ChangePartyName(partij);
            cpn.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string warning = "Weet u zeker dat u deze partij wilt verwijderen? U zult dan ook alle verkiezingen en coalieties waarin de partij heeft deelgenomen verwijderen";
            DialogResult dialogResult = MessageBox.Show(warning, "Waarschuwing",  MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                partijRepo.Delete(partij);
            }
            else if (dialogResult == DialogResult.No){}
            
        }
    }
}
