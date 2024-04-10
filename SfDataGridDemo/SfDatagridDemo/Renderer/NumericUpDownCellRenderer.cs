using Syncfusion.Data;
using Syncfusion.Styles;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Helpers;
using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.DataGrid.Styles;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GridCellRendererBase = Syncfusion.WinForms.DataGrid.Renderers.GridCellRendererBase;

namespace SfDatagridDemo.Renderer
{
    public class NumericUpDownCellRenderer : GridCellRendererBase
    {
        public NumericUpDownCellRenderer(SfDataGrid dataGrid)
        {
            DataGrid = dataGrid;          
            IsInEditing = false;
        }
        protected SfDataGrid DataGrid { get; set; }

        protected override void OnRender(Graphics graphics, Rectangle cellRect, string cellValue, CellStyleInfo style, DataColumnBase column, RowColumnIndex rowColumnIndex)
        {           
            var NumericUpDownExtControl = new NumericUpDown();
            NumericUpDownExtControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            NumericUpDownExtControl.Value =Convert.ToDecimal(cellValue);
            NumericUpDownExtControl.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            NumericUpDownExtControl.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            NumericUpDownExtControl.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            NumericUpDownExtControl.Font = new Font(NumericUpDownExtControl.Font.FontFamily, 14);
            NumericUpDownExtControl.Text = cellValue ?? string.Empty;
            NumericUpDownExtControl.Size = cellRect.Size;
            NumericUpDownExtControl.Location = cellRect.Location;
            DataGrid.GetTopLevelParentDataGrid().TableControl.Controls.Add(NumericUpDownExtControl);
        }
    }
}
