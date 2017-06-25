using System;
using System.Collections;
using System.Windows.Forms;

namespace FileFoxManager
{
    public class ItemComparer : IComparer
    {
        int columnIndex = 0;
        bool sortAscending = true;

        public int ColumnIndex
        {
            set
            {
                if (columnIndex == value)
                    sortAscending = !sortAscending;
                else
                {
                    columnIndex = value;
                    sortAscending = true;
                }
            }
        }

        public int Compare(object x, object y)
        {
            string value1 = ((ListViewItem)x).SubItems[columnIndex].Text;
            string value2 = ((ListViewItem)y).SubItems[columnIndex].Text;

            //if (value1 == "..")
            //{
            //    return -1;
            //}
            //else
            //{
                return String.Compare(value1, value2) * (sortAscending ? 1 : -1);
            //}
        }
    }
}