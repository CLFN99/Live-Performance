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
    public partial class NewElection : Form
    {
        private VerkiezingssoortRepository soortRepo;
        private VerkiezingsuitslagRepository uitslagRepo;
        List<Verkiezingssoort> soorten;
        public NewElection()
        {
            InitializeComponent();
            soortRepo = new VerkiezingssoortRepository(new VerkiezingssoortSqlContext());
            uitslagRepo = new VerkiezingsuitslagRepository(new VerkiezingsuitslagSqlContext());
            soorten = soortRepo.GetAll();
            foreach(Verkiezingssoort s in soorten)
            {
                cbElectionType.Items.Add(s.Naam);
            }
        }

        private void btnSaveElection_Click(object sender, EventArgs e)
        {
            Verkiezingsuitslag v = CreateUitslagFromForm();
            if(v != null)
            {
                if (uitslagRepo.New(v))
                {
                    MessageBox.Show("Verkiezingsuitslag succesvol opgeslagen.");
                }
                else if (!uitslagRepo.New(v))
                {
                    MessageBox.Show("Er ging iets mis.");
                }
            }
        }

        private Verkiezingsuitslag CreateUitslagFromForm()
        {
            int totaal = 0;
            string name = tbElectionName.Text;
            DateTime date = dtpElectionDate.Value;
            Verkiezingssoort soort = new Verkiezingssoort();
            foreach (Verkiezingssoort s in soorten)
            {
                if(s.Naam == cbElectionType.SelectedItem.ToString())
                {
                    soort = s;
                }
            }
            Verkiezingsuitslag v = new Verkiezingsuitslag(name, date, soort);
            v.Partijen = soort.Partijen;
            foreach(Partij p in v.Partijen)
            {
                foreach(Control c in votesPanel.Controls)
                {
                    if (p.Afkorting == c.Name)
                    {
                        p.Stemmen = Convert.ToInt32(c.Text);
                        totaal = totaal + Convert.ToInt32(c.Text);
                    }
                }
               
            }
            v.Totaal = totaal;
            v.ZetelsEnPercentageBerekenen();
            return v;
        }
    }
}
