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
    public partial class Main : Form
    {
        private PartijRepository partijRepo;
        private LidRepository lidRepo;
        private VerkiezingsuitslagRepository uitslagRepo;
        private List<Partij> partijen;
        private List<Lid> leden;
        private List<Verkiezingsuitslag> uitslagen;
        private CoalitieRepository coalitieRepo;
        private List<Coalitie> coalities;
        private VerkiezingssoortRepository soortRepo;
        private List<Verkiezingssoort> soorten;

        public Main()
        {
            InitializeComponent();
            partijRepo = new PartijRepository(new PartijSqlContext());
            lidRepo = new LidRepository(new LidSqlContext());
            uitslagRepo = new VerkiezingsuitslagRepository(new VerkiezingsuitslagSqlContext());
            coalitieRepo = new CoalitieRepository(new CoalitieSqlContext());
            soortRepo = new VerkiezingssoortRepository(new VerkiezingssoortSqlContext());
        }

        private void btnPartyList_Click(object sender, EventArgs e)
        {
            btnCalcCoalition.Visible = true;
            btnNewParty.Visible = true;
            btnViewParty.Visible = true;
            btnExportCoalition.Visible = false;
            btnViewElection.Visible = false;
            listView.Columns.Clear();
            listView.Columns.Add("Partij", 60, HorizontalAlignment.Left);
            listView.Columns.Add("Volledige naam", 250, HorizontalAlignment.Left);
            listView.Columns.Add("Lijsttrekker", 150, HorizontalAlignment.Left);
            listView.Columns.Add("Zetels", 50, HorizontalAlignment.Left);
            AddPartiesToLv();
        }
        
        private void btnElectionList_Click(object sender, EventArgs e)
        {
            btnViewElection.Visible = true;
            btnExportCoalition.Visible = false;
            btnCalcCoalition.Visible = false;
            btnNewParty.Visible = false;
            btnViewParty.Visible = false;
            listView.Columns.Clear();
            listView.Columns.Add("Naam", 150, HorizontalAlignment.Left);
            listView.Columns.Add("Datum", 100, HorizontalAlignment.Left);
            listView.Columns.Add("Soort", 200, HorizontalAlignment.Left);
            AddElectionsToLv();
        }
        
        private void btnCoalitionList_Click(object sender, EventArgs e)
        {
            btnExportCoalition.Visible = true;
            btnCalcCoalition.Visible = false;
            btnNewParty.Visible = false;
            btnViewParty.Visible = false;
            btnViewElection.Visible = false;
            listView.Columns.Clear();
            listView.Columns.Add("Naam");
            listView.Columns.Add("Premier");
            AddCoalitionsToLv();
        }

        private void btnNewElection_Click(object sender, EventArgs e)
        {
            NewElection ne = new NewElection();
            ne.ShowDialog();
        }

        private void btnViewParty_Click(object sender, EventArgs e)
        {
            leden = lidRepo.GetAll();
            partijen = partijRepo.GetAll();
            if(listView.CheckedItems.Count > 1)
            {
                MessageBox.Show("U kunt maar één partij selecteren om te bekijken");
            }
            else if (listView.CheckedItems.Count != 0)
            {
                Party pForm = new Party(CreatePartijFromLv()[0]);
                pForm.ShowDialog();
            }
            
        }
        
        private void btnCalcCoalition_Click(object sender, EventArgs e)
        {
            if(listView.CheckedItems.Count <= 1)
            {
                MessageBox.Show("Selecteer meerdere partijen om de meerderheid te berekenen.");
            }
            else if(listView.CheckedItems.Count != 0)
            {
                List<Partij> coalitiePartijen = CreatePartijFromLv();
                CalcMeerderheid(coalitiePartijen);
            }
        }

        private void btnViewElection_Click(object sender, EventArgs e)
        {

            uitslagen = uitslagRepo.GetAll();
            if (listView.CheckedItems.Count > 1)
            {
                MessageBox.Show("U kunt maar één partij selecteren om te bekijken");
            }
            else if (listView.CheckedItems.Count != 0)
            {
                Election election = new Election(CreateUitslagFromLv());
                election.ShowDialog();
            }

        }


        //methods

        private Verkiezingsuitslag CreateUitslagFromLv()
        {
            Verkiezingsuitslag selectedUitslag = new Verkiezingsuitslag();
            foreach (ListViewItem item in listView.CheckedItems)
            {
                foreach(Verkiezingsuitslag u in uitslagen)
                {
                    if(u.Id == (item.Index + 1))
                    {
                        selectedUitslag = u;
                    }
                }
                return selectedUitslag;
            }
            return null;
        }

        private void CalcMeerderheid(List<Partij> coalitiePartijen)
        {
            soorten = soortRepo.GetAll();
            double i = 0;
            foreach(Verkiezingssoort soort in soorten)
            {
               // soort.Partijen = soortRepo.GetParties(soort);
                foreach(Partij p in coalitiePartijen)
                {
                    if (!soort.Partijen.Contains(p))
                    {
                        i = soort.Zetels / 2;
                    }
                }
            }
            
            int totalSeats = 0;
            
            foreach(Partij p in coalitiePartijen)
            {
                totalSeats = totalSeats + p.Zetels;
            }
            if(totalSeats > Math.Ceiling(i))
            {
                MessageBox.Show("Meerderheid bereikt!");
            }
            else if (totalSeats <= Math.Ceiling(i))
            {
                MessageBox.Show("Met deze partijen is geen meerderheid te bereiken.");
            }
        }

        private List<Partij> CreatePartijFromLv()
        {
            List<Partij> selectedPartijen = new List<Partij>();
            foreach (ListViewItem item in listView.CheckedItems)
            {
                Partij partij = new Partij();
                partij.Afkorting = item.Text;
                partij.Naam = item.SubItems[1].Text.ToString();
                foreach (Lid l in leden)
                {
                    if (l.Naam == item.SubItems[2].Text.ToString())
                    {
                        partij.LijsttrekkerId = l.Id;
                    }
                }
                partij.Zetels = Convert.ToInt32(item.SubItems[3].Text);
                foreach (Partij p in partijen)
                {
                    if (p.Afkorting == partij.Afkorting)
                    {
                        partij.Id = p.Id;
                    }
                }
                selectedPartijen.Add(partij);
            }
            return selectedPartijen;
        }

        private void AddCoalitionsToLv()
        {
            listView.Items.Clear();
            coalities = coalitieRepo.GetAll();
            
            foreach(Coalitie c in coalities)
            {
                ListViewItem item = new ListViewItem(c.Naam);
                item.SubItems.Add(lidRepo.GetById(c.PremierId).ToString());
                string parties = "";
                foreach(Partij p in c.Partijen)
                {
                    parties = parties + p.Afkorting + ", ";
                }
                item.SubItems.Add(parties);
                listView.Items.Add(item);
            }
        }

        private void AddPartiesToLv()
        {
            listView.Items.Clear();
            partijen = partijRepo.GetAll();
            leden = lidRepo.GetAll();
            foreach (Partij p in partijen)
            {
                ListViewItem item = new ListViewItem(p.Afkorting);
                item.SubItems.Add(p.Naam);
                foreach (Lid l in leden)
                {
                    if (l.PartijId == p.Id)
                    {
                        item.SubItems.Add(l.Naam);
                    }
                }
                item.SubItems.Add(p.Zetels.ToString());
                listView.Items.Add(item);
            }

        }

        private void AddElectionsToLv()
        {
            listView.Items.Clear();
            uitslagen = uitslagRepo.GetAll();
            foreach (Verkiezingsuitslag v in uitslagen)
            {
                ListViewItem item = new ListViewItem(v.Naam);
                item.SubItems.Add(v.Datum.ToShortDateString());
                item.SubItems.Add(v.Soort.Naam);
                listView.Items.Add(item);
            }
        }
    }
}
