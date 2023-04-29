using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using todolist.Classes;

namespace todolist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshTarefas();
            MontaGrid();
        }

        private void MontaGrid()
        {
            if (grdViewLista.Columns["TarefasId"] != null)
            {
                grdViewLista.Columns["TarefasId"].Visible = false;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var context = new TarefasContext())
            {
                var tarefas = new Tarefas { Descricao = txtTarefas.Text, Completou = false };
                context.Tarefas.Add(tarefas);
                context.SaveChanges();
            }
            RefreshTarefas();
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            using (var context = new TarefasContext())
            {
                if (grdViewLista.SelectedRows.Count > 0 && grdViewLista.SelectedRows[0].Cells.Count > 0)
                {
                    var tarefas = context.Tarefas.Find((int)grdViewLista.SelectedRows[0].Cells[0].Value);
                    if (tarefas != null)
                    {
                        tarefas.Completou = true;
                        context.SaveChanges();
                    }
                }
            }
            RefreshTarefas();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            using (var context = new TarefasContext())
            {
                var tarefas = context.Tarefas.Find((int)grdViewLista.SelectedRows[0].Cells[0].Value);
                if (tarefas != null)
                {
                    context.Tarefas.Remove(tarefas);
                    context.SaveChanges();
                }
            }
            RefreshTarefas();
        }

        private void RefreshTarefas()
        {
            using (var context = new TarefasContext())
            {
                grdViewLista.DataSource = context.Tarefas.ToList();
            }
        }
    }
}
