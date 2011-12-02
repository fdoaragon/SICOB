using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using BLL;

namespace CasaCambio
{
    public partial class frmReporte : Form
    {
        ReportDocument rpt;
        public frmReporte(ReportDocument rptDoc)
        {
            InitializeComponent();
            rpt = rptDoc;
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            CrViewer1.ReportSource = rpt;
        }
    }
}
