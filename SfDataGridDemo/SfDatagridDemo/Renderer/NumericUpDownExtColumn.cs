using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfDatagridDemo.Renderer
{
    public class NumericUpDownExtColumn : GridColumn
    {
        public NumericUpDownExtColumn()
        {
            SetCellType("NumericUpDown");
        }

    }
}
