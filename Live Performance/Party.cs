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
        public Party(Partij p)
        {
            InitializeComponent();
            lidRepo = new LidRepository(new LidSqlContext());
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
    }
}
