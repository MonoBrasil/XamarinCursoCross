using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Dia1Ex4
{
    public class TableSource : UITableViewSource
    {
        protected string[] tableItems;
        protected string cellIdentifier = "TableCell";

        public TableSource(string[] items)
        {
            tableItems = items;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return tableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // Pede uma célula reciclada para economizar memória
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier) ??
                                   new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            
            // se não há células disponíveis para reutilizar, cria uma nova
            cell.TextLabel.Text = tableItems[indexPath.Row];

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {   
            new UIAlertView("Linha Selecionada", tableItems[indexPath.Row], null, "OK", null).Show();
            var cell = tableView.CellAt(indexPath);
            cell.Accessory = UITableViewCellAccessory.Checkmark;
            tableView.DeselectRow(indexPath, true); // Convenção do iOS para remover a seleção
        }
			
    }
}

