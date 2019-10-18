using Gtk;
using System;
using System.Collections.Generic;

using CGtk;

using Serpis.Ad;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel) {
        Build();


        IList<Categoria> categorias = new List<Categoria>();
        categorias.Add(new Categoria(1, "cat 1"));
        categorias.Add(new Categoria(2, "cat 2"));
        categorias.Add(new Categoria(3, "cat 3"));

        TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre" }, categorias);

        newAction.Activated += (sender, e) => new CategoriaWindow();
        editAction.Activated += (sender, e) => {
            object value = TreeViewHelper.GetValue(treeView, "Nombre");
            Console.WriteLine("editAction Activated Nombre = " + value);
        };

        refreshAction.Activated += (sender, e) =>
            TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre" }, categorias);

        refreshStateActions();
        treeView.Selection.Changed += (sender, e) => refreshStateActions();
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
