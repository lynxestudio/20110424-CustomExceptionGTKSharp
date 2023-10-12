using System;
using Gtk;
using GtkPostException;

public partial class MainWindow : Gtk.Window
{
public MainWindow () : base(Gtk.WindowType.Toplevel)
{
Build ();
}

protected void OnDeleteEvent (object sender, DeleteEventArgs a)
{
Application.Quit ();
a.RetVal = true;
}
protected virtual void ExecuteQuery (object sender, System.EventArgs e)
{
try{
AddColumns(GridOutput);
GridOutput.Model = CreateModel();
lbmsg.Text += "Consulta ejecutada";

}catch(GtkPostException.DataBaseException ex){
MessageBox(ex.Message);

}
catch(GtkPostException.RuntimeException ex){
MessageBox(ex.Message);	

}
}

void MessageBox(string messageText){
using(Dialog dialog = new MessageDialog(this,
DialogFlags.Modal | DialogFlags.DestroyWithParent,
    MessageType.Error,
    ButtonsType.Ok,
    messageText,"")){
dialog.Run();
dialog.Hide();
}
}
//Creamos los encabezados de las columnas
void AddColumns (TreeView treeView)	{
CellRendererText rendererText = new CellRendererText ();
string[] s = {"Titulo","Año","Páginas","Autores"};
TreeViewColumn column;
for(int i = 0;i < s.Length;i++){
	column =  new TreeViewColumn (s[i], rendererText, "text", i);
	column.Resizable = true;
	column.MinWidth = 128;
	treeView.AppendColumn (column); 	
}
}
//Creamos el modelo de datos
ListStore CreateModel(){
ListStore store = new ListStore(typeof(string),
    typeof(int),
    typeof(int),
    typeof(string));

foreach(Book b in BooksDataManager.SelectAll(txtConnStr.Buffer.Text)){
store.AppendValues(b.Title,b.PubYear,b.NumPages,b.Authors);
}

return store;
}


}

