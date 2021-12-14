using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CirclePointsA
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class About : Page
    {
        public string Version
        {
            get
            {
                var version = Windows.ApplicationModel.Package.Current.Id.Version;
                return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            }
        }
        public About()
        {
            this.InitializeComponent();
        }
    }
}
