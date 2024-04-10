# How to implement NumericUpDown inside SfDataGrid using Custom Column support.

To achieve the requirement of implementing a NumericUpDown inside an SfDataGrid column, follow these steps:

**Step 1** : Create a custom column by overriding a new class derived from the GridColumn class.
 
 ```C#
 public class NumericUpDownExtColumn : GridColumn
 {
     public NumericUpDownExtColumn()
     {
         SetCellType("NumericUpDown");
     }

 }
 ```

**Step 2** :  After creating a custom column, you need to create a renderer for the custom column. You can create a custom renderer by deriving from the GridCellRendererBase class.

**Step 3** :  In the OnRender method, you can create a NumericUpDown control. Within this method, initialize the properties for the NumericUpDown control, and finally, add the declared control into the DataGrid TableControl. 

You can add any other controls in the OnRender method by following this procedure based on your needs.

 
 ```C#
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
 ```

**Step 4** : Then you can add the previously created custom renderer to the SfDataGrid.CellRenderers collection.

 
 ```C#
 public Form1()
 {
     InitializeComponent();
     this.sfDataGrid1.CellRenderers.Add("NumericUpDown", new NumericUpDownCellRenderer(sfDataGrid1));
 }
 ```

**Step 5** :  At last, finally, you can define the custom column in SfDataGrid.

 
 ```C#
 public Form1()
 {
     InitializeComponent();
     this.sfDataGrid1.Columns.Add(new NumericUpDownExtColumn() { MappingName = "NumericUpDown", HeaderText = "NumericUpDown"});
 }
 ```

By following the above code, the output image is as referenced below.

 
 ![NumericUpDown_Image.png](https://support.syncfusion.com/kb/agent/attachment/article/15707/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIwNzUxIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.yG2J64WnfEu5VJbuOnqjv_4Po3p_Ce82_OS9tDfBzuw)

Take a moment to peruse the [Winforms - DataGrid Custom Column Support UG Documentation](https://help.syncfusion.com/windowsforms/datagrid/columntypes#custom-column-support), to learn more about Custom Column support with examples.