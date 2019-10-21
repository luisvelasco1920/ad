using System;
using System.Data;

using Serpis.Ad;

namespace CGtk
{
    public partial class CategoriaWindow : Gtk.Window
    {
        public CategoriaWindow(object id) : base(Gtk.WindowType.Toplevel) {
            this.Build();

            IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
            dbCommand.CommandText = "select * from categoria where id = @id";
            DbCommandHelper.AddParameter(dbCommand, "id", id);
            IDataReader dataReader = dbCommand.ExecuteReader();
            dataReader.Read();
            string nombre = (string)dataReader["nombre"];
            dataReader.Close();
            entryNombre.Text = nombre;

            buttonOk.Clicked += (sender, e) => {
                nombre = entryNombre.Text;
                //IDbCommand dbCommand = dbConnection.CreateCommand();
                //dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
                //DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
                //dbCommand.ExecuteNonQuery();
                dbCommand.CommandText = "update categoria set nombre=@nombre where id=@id";
                dbCommand.Parameters.Clear();
                DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
                DbCommandHelper.AddParameter(dbCommand, "id", id);
                dbCommand.ExecuteNonQuery();
                Destroy();
            };

            buttonCancel.Clicked += (sender, e) => Destroy();
        }
    }
}
