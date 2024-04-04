using SfDatagridDemo.Renderer;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.DataGrid.Styles;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfDatagridDemo
{
    public partial class Form1 : Form
    {
        ViewModel viewModel;
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1.AutoGenerateColumns = false;

            viewModel = new ViewModel();
            this.sfDataGrid1.AllowEditing = true;
            sfDataGrid1.DataSource = viewModel.OrdersListDetails;
            this.sfDataGrid1.CellRenderers.Add("NumericUpDown", new NumericUpDownCellRenderer(sfDataGrid1));
            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "OrderID", HeaderText = "OrderID" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "CustomerID" });
            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "Quantity", HeaderText = "Quantity" });
            this.sfDataGrid1.Columns.Add(new NumericUpDownExtColumn() { MappingName = "NumericUpDown", HeaderText = "NumericUpDown" , Width=150});
        }
    }

}
