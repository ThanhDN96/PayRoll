using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pay_roll
{
    public partial class Payroll : Form
    {
        public Payroll()
        {
            InitializeComponent();
        }
        // upload file
        private void btnnchoose_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.xlsm)|*.xlsx";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
               // string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
                txtpath.Text = sFileName;
            }
            DataTable tbl = new DataTable();
            Workbook wk = new Workbook(txtpath.Text);
            Worksheet ws = wk.Worksheets[0];

            tbl = ws.Cells.ExportDataTable(7, 1,ws.Cells.MaxRow, ws.Cells.MaxColumn);
            //dgvdata.AutoGenerateColumns = false;
            dgvdata.DataSource = tbl;
        }
       
    }
}
