using System.Windows.Controls;

namespace JControl.Wpf.Client.Views
{
    /// <summary>
    /// AddDevToRoomDialogView.xaml 的交互逻辑
    /// </summary>
    public partial class AddDeviceItemView : UserControl
    {
        public AddDeviceItemView()
        {
            InitializeComponent();
        }

        Model.ProductModel viewmodel = null;

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            viewmodel = this.DataContext as Model.ProductModel;
            if (viewmodel.Id != 0)
            {
                title.Text = "修改产品";
            }
            else
            {
                title.Text = "新产品";
            }
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
