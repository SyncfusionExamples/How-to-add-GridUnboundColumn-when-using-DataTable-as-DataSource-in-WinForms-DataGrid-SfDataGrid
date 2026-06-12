using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnBoundColumnDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader;

            // Subscribe to QueryUnboundColumnInfo event
            sfDataGrid1.QueryUnboundColumnInfo += SfDataGrid1_QueryUnboundColumnInfo;

            // Create data table
            DataTable table = new DataTable();

            //// Define columns
            // Add a column for total minutes
            table.Columns.Add( "total_minute", typeof(int));

            // Add an expression column
            table.Columns.Add("grand_total", typeof(string), "total_minute * 20");

            // Add rows
            table.Rows.Add(71);
            table.Rows.Add(21);
            table.Rows.Add(120);
            table.Rows.Add(180);
            table.Rows.Add(30);
            table.Rows.Add(90);
            table.Rows.Add(60);

            // Set data source
            DataView dv = table.DefaultView;
            sfDataGrid1.DataSource = dv;

            // Adding columns to SfDataGrid
            sfDataGrid1.Columns.Add(new GridTextColumn
            {
                MappingName = "total_minute",
                HeaderText = "Minutes",
            });

            // Adding expression column to SfDataGrid
            sfDataGrid1.Columns.Add(new GridTextColumn
            {
                MappingName = "grand_total",
                HeaderText = "Using Expression Column",
                AllowEditing = false,
            });

            // Adding unbound column to SfDataGrid 
            sfDataGrid1.Columns.Add(new GridUnboundColumn
            {
                MappingName = "unBoundColumn",
                HeaderText = "Using QueryUnboundColumnInfo event",
                AllowEditing = false,
                AllowFiltering = false,
                AllowSorting = false,
                AllowGrouping = false,
            });
        }
        private void SfDataGrid1_QueryUnboundColumnInfo(object sender, Syncfusion.WinForms.DataGrid.Events.QueryUnboundColumnInfoArgs e)
        {
            if (e.UnboundAction == UnboundActions.QueryData)
            {
                var totalMin = Convert.ToDouble((e.Record as DataRowView).Row["total_minute"]);
                var save = totalMin * 112;
                e.Value = save.ToString();
            }
        }
    }
}
