using System.Windows;
using System.Net.Http;
using AssistPurchase;
using AssistPurchase.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        
        private static readonly HttpClient client = new HttpClient();
        public string fruits;
        public Window1()
        {
            InitializeComponent();
           
           
        }

        private async System.Threading.Tasks.Task enter_ClickAsync(object sender, RoutedEventArgs e)
        {
            var newProduct = new MonitoringProducts()
            {
                ProductNumber = productNumber.Text,
                ProductName = productName.Text,
                ProductDescription = productDescp.Text,
                TouchScreen = touchScreen.Text,
                WearableMonitor = wearableMonitor.Text,
                AlarmManagement = alarmManagement.Text,
                Cost = cost.Text,
                ScreenSize = screenSize.Text,
                ConnectivitySupport = connec.Text,
                SummarizeDataSupport = summerize.Text,
                Compact = compact.Text,
                ScalableMeasurement = scalable.Text

            };

            var response = await client.PostAsync("http://localhost:5000/api/MonitoringProduct" + "/new", new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();

            productNumber.Text = responseString;
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            var result= enter_ClickAsync(sender, e);
        }
    }
}
