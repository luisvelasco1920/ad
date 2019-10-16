using System;
using Gtk;

using CGtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel) {
        Build();

        Categoria categoria1 = new Categoria(1, "cat 1");
        Categoria categoria2 = new Categoria(2, "cat 2");


        //treeView.AppendColumn("id", new CellRendererText(), "text", 0);
        //treeView.AppendColumn("nombre", new CellRendererText(), "text", 1);

        ListStore listStore = new ListStore(typeof(Categoria));

        Fill(treeView, "Id", "Nombre");

        //CellRendererText cellRendererText = new CellRendererText();
        //treeView.AppendColumn("Id", cellRendererText,
        //  new TreeCellDataFunc ((tree_column, cell, tree_model, iter) => {
        //      //Categoria categoria = (Categoria)listStore.GetValue(iter, 0);
        //      //object value = categoria.Id;
        //      object obj = tree_model.GetValue(iter, 0);
        //      object value = obj.GetType().GetProperty("Id").GetValue(obj);

        //      ((CellRendererText)cell).Text = value.ToString();
        //  })
        //);

        //treeView.AppendColumn("Nombre", cellRendererText,
        //  new TreeCellDataFunc((tree_column, cell, tree_model, iter) => {
        //      //Categoria categoria = (Categoria)listStore.GetValue(iter, 0);
        //      //object value = categoria.Nombre;
        //      object obj = tree_model.GetValue(iter, 0);
        //      object value = obj.GetType().GetProperty("Nombre").GetValue(obj);
        //      cellRendererText.Text = value.ToString();

        //  })
        //);


        treeView.Model = listStore;

        listStore.AppendValues(categoria1);
        listStore.AppendValues(categoria2);


        newAction.Activated += (sender, e) => new CategoriaWindow();
        refreshStateActions();
        treeView.Selection.Changed += (sender, e) => refreshStateActions();
    }


    public void Fill(TreeView treeView, params string[] propertyNames) {
        CellRendererText cellRendererText = new CellRendererText();
        foreach (string propertyName in propertyNames)
            treeView.AppendColumn(propertyName, cellRendererText,
              new TreeCellDataFunc((tree_column, cell, tree_model, iter) => {
                  //Categoria categoria = (Categoria)listStore.GetValue(iter, 0);
                  //object value = categoria.Id;
                  object obj = tree_model.GetValue(iter, 0);
                  object value = obj.GetType().GetProperty(propertyName).GetValue(obj);

                  cellRendererText.Text = value.ToString();
              })
            );


    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
        Application.Quit();
        a.RetVal = true;
    }

    private void refreshStateActions() {
        bool hasSelectedRows = treeView.Selection.CountSelectedRows() > 0;
        editAction.Sensitive = hasSelectedRows;
        deleteAction.Sensitive = hasSelectedRows;
    }
}
