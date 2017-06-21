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

        public Main()
        {
            InitializeComponent();
            partijRepo = new PartijRepository(new PartijSqlContext());
            lidRepo = new LidRepository(new LidSqlContext());
            uitslagRepo = new VerkiezingsuitslagRepository(new VerkiezingsuitslagSqlContext());
            coalitieRepo = new CoalitieRepository(new CoalitieSqlContext());
        }

        private void btnPartyList_Click(object sender, EventArgs e)
        {
            btnCalcCoalition.Visible = true;
            btnNewParty.Visible = true;
            btnViewParty.Visible = true;
            listView.Columns.Add("Partij", 60, HorizontalAlignment.Left);
            listView.Columns.Add("Volledige naam", 250, HorizontalAlignment.Left);
            listView.Columns.Add("Lijsttrekker", 150, HorizontalAlignment.Left);
            listView.Columns.Add("Zetels", 50, HorizontalAlignment.Left);
            listView.CheckBoxes = true;
            AddPartiesToLv();
        }
        
        private void btnElectionList_Click(object sender, EventArgs e)
        {
            lblInfo.Visible = true;
            listView.Columns.Add("Naam", - 2, HorizontalAlignment.Left);
            listView.Columns.Add("Datum", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Soort", -2, HorizontalAlignment.Left);
            AddElectionsToLv();
        }
        
        private void btnCoalitionList_Click(object sender, EventArgs e)
        {
            btnExportCoalition.Visible = true;
            listView.Columns.Add("Naam");
            listView.Columns.Add("Premier");
            listView.CheckBoxes = true;
            AddCoalitionsToLv();
        }

        private void btnNewElection_Click(object sender, EventArgs e)
        {
            NewElection newElection = new NewElection();
            newElection.ShowDialog();
        }

        

        

        //methods
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

        private void btnViewParty_Click(object sender, EventArgs e)
        {
            leden = lidRepo.GetAll();
            partijen = partijRepo.GetAll();
            Partij partij = new Partij();

            foreach (ListViewItem item in listView.CheckedItems)
            {
                
                partij.Afkorting = item.Text;
                partij.Naam = item.SubItems[1].Text.ToString();
                foreach(Lid l in leden)
                {
                    if(l.Naam == item.SubItems[2].Text.ToString())
                    {
                        partij.LijsttrekkerId = l.Id;
                    }
                }
                partij.Zetels = Convert.ToInt32(item.SubItems[3].Text);
            }

            foreach(Partij p in partijen)
            {
                if(p.Afkorting == partij.Afkorting)
                {
                    partij.Id = p.Id;
                }
            }
            Party pForm = new Party(partij);
            pForm.ShowDialog();
        }
    }
}
