using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace clientsCommandes_Tp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = Data.EF.GetClients().ToBindingList();

            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Sort(dataGridView1.Columns["ClientId"], ListSortDirection.Ascending);
        }

        private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource2.DataSource = Data.EF.GetCommandes().ToBindingList();

            dataGridView1.DataSource = bindingSource2;
            dataGridView1.Sort(dataGridView1.Columns["ComID"], ListSortDirection.Ascending);

            dataGridView1.Columns["ComID"].HeaderText = "Commande ID";
            dataGridView1.Columns["ComID"].DisplayIndex = 0;
            dataGridView1.Columns["Description"].DisplayIndex = 1;
            dataGridView1.Columns["Prix"].DisplayIndex = 2;
            dataGridView1.Columns["ClientId"].DisplayIndex = 3;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                //Data.Composants.UpdateComposants();
                Data.EF.SaveChanges();
            }
            catch (Exception)
            {


                Data.EF.Reload();
                bindingSource1.DataSource = Data.EF.GetClients().ToBindingList();
                dataGridView1.Sort(dataGridView1.Columns["ClientId"], ListSortDirection.Ascending);
                MessageBox.Show("Impossible de modifier/supprimer des clients");
            }
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            if (-1 == BusinessLayer.Commandes.UpdateCommandes())
            {
                bindingSource2.DataSource = Data.EF.GetCommandes().ToBindingList();
                dataGridView1.Sort(dataGridView1.Columns["ComID"], ListSortDirection.Ascending);
                MessageBox.Show("Commande inferieur que 10.00$");
            }
        }
        internal void montrerClients()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.DataSource = Data.EF.GetCommandes().ToList();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Impossible d'ajouter/modifier/supprimer");
        }
    }
}
