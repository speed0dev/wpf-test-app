using NLog;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppTest01.src;

namespace WpfAppTest01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        // deletegate Object
        private DelegateTestClass obj = new DelegateTestClass();

        // NLog 정의
        private static readonly Logger LOG = LogManager.GetCurrentClassLogger();

        // 
        private EventHandler<EventArgs> handle; //

        
        
        // Binding
        private string _userName = "default Name";
        public string UserName
        {
            get { return _userName; }
            set {
                _userName = value;
                this.OnPropertyChanged();
            }
        }


        private List<string> list = new List<string>();

        // event
        public event PropertyChangedEventHandler? PropertyChanged;

        // 작용방법
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            Debug.WriteLine(" propertyName:" + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            //
            UserName = "Default User Name";


        }

        private async Task ClearList() {
            await Task.Delay(1000);  //
            list.Clear();
        }

        public void ShowEvent() {
            txtLog.Text = string.Join(">>", list);
            //ClearList();
        }

        private void rect1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            list.Add("Rect");
            Debug.WriteLine("[Rect1]MouseDown!");
            ShowEvent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            list.Add("Border");
            Debug.WriteLine("[Border]MouseDown!");
            ShowEvent();
        }

        private void btnCenter_Click(object sender, RoutedEventArgs e)
        {
            list.Add("Button");
            Debug.WriteLine("[Button]Click !!!");
            ShowEvent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            LOG.Debug("Button Click! ");
            //
            obj.DeleEvent?.Invoke(this, null);

        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            list.Add("PreButton");
            ShowEvent();

        }

        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            list.Add("PreBorder");
            ShowEvent();
        }

        private void Rectangle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            list.Add("PreRect");
            ShowEvent();
        }

        int nCount;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserName = "Call_" + nCount;
            ++nCount;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void txtLog_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtTest1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //
            obj.DeleEvent += (send, obj) => {

                Debug.WriteLine("Call Test");
                LOG.Debug("Call Test");

            };
        }
    }
}