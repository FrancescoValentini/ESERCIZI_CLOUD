using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormRubrica_models.Models;

namespace WinForm_RUBRICA {
    public partial class Form1 : Form {

        Rubrica rubr;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            rubr = new Rubrica("Rubrica");
        }

        private void personaBindingSource_CurrentChanged(object sender, EventArgs e) {
            
        }

        private void clearDataList() {
            personaBindingSource.Clear();
        }
        private void refreshDataList() {
            clearDataList();
            foreach (Persona p in rubr.getPersone()){
                personaBindingSource.Add(p);
            }
        }

        private void dataListSearch(string tel) {
            Persona p = rubr.FindPersona(tel);
            clearDataList();
            personaBindingSource.Add(p);
        }

        private void addPersona(String nome,String cogn, String tel) {
            Persona p = new Persona(nome, cogn, tel);  
            rubr.AddPersona(p);
            personaBindingSource.Add(p);
        }

        private void btnInserisci_Click(object sender, EventArgs e) {
            addPersona(txtbNome.Text, txtbCognome.Text, txtbTelefono.Text);
        }

        private void btnCerca_Click(object sender, EventArgs e) {
            if (txtbTelefonoRicerca.Text == "") {
                refreshDataList();
            } else {
                dataListSearch(txtbTelefonoRicerca.Text);
            }
            
        }

        private void btnElimina_Click(object sender, EventArgs e) {
            rubr.DeletePersona(txtbTelefonoRicerca.Text);
            refreshDataList();
        }

        private void eLIMINACONTATTOToolStripMenuItem_Click(object sender, EventArgs e) {


            foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                string telefono = (string)row.Cells[2].Value;
                rubr.DeletePersona(telefono);
            }
            refreshDataList();
        }
    }
}
