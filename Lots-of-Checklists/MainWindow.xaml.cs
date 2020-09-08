using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lots_of_Checklists
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var ctx = new ChecklistContext())
            {
                var checklist1 = new Checklist() { _checkListName = "Epic Checklist" };
                var checklistitem1 = new ChecklistItem() { _checkListItemName = "Get milk" };
                var checklistitem2 = new ChecklistItem() { _checkListItemName = "Get bread" };



                ctx.ChecklistItems.Add(checklistitem1);
                ctx.ChecklistItems.Add(checklistitem2);

                ctx.SaveChanges();
            };
        }
    }
}
