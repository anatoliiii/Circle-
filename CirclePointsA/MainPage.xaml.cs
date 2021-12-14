using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using NavigationView = Microsoft.UI.Xaml.Controls.NavigationView;
using NavigationViewPaneDisplayMode = Microsoft.UI.Xaml.Controls.NavigationViewPaneDisplayMode;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CirclePointsA
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage mainPage;

        public Microsoft.UI.Xaml.Controls.NavigationView NavigationView
        {
            get { return nvSample; }
        }
        public MainPage()
        {
            InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(900, 600);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            nvSample.SelectedItem = nvSample.MenuItems.OfType<Microsoft.UI.Xaml.Controls.NavigationViewItem>().First();
            contentFrame.Navigate(typeof(Play));
            mainPage = this;

        }
        private void DisplayModeChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewDisplayModeChangedEventArgs args)
        {
            Thickness currMargin = AppTitleBar.Margin;
            if (sender.DisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewDisplayMode.Minimal)
            {
                AppTitleBar.Margin = new Thickness((sender.CompactPaneLength * 2), currMargin.Top, currMargin.Right, currMargin.Bottom);

            }
            else
            {
                AppTitleBar.Margin = new Thickness(sender.CompactPaneLength, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }

            UpdateAppTitleMargin(sender);
        }
        private void OnPaneDisplayModeChanged(DependencyObject sender, DependencyProperty dp)
        {
            var navigationView = sender as NavigationView;
            MainPage.mainPage.AppTitleBar.Visibility = navigationView.PaneDisplayMode == NavigationViewPaneDisplayMode.Top ? Visibility.Collapsed : Visibility.Visible;
        }

        private void NavigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                sender.Header = "Настройки";
                contentFrame.Navigate(typeof(SettingsLocal));
            }
            else
            {
                var selectedItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
                if (selectedItem != null)
                {
                    string selectedItemTag = ((string)selectedItem.Tag);
                    if (selectedItem.Name == "Sample")
                    {
                        sender.Header = "Введите параметры окружностей";
                        contentFrame.Navigate(typeof(Play));
                    }
                    if (selectedItem.Name == "About")
                    {
                        sender.Header = "Дополнительная информация";
                        contentFrame.Navigate(typeof(About));
                    }
                    if (selectedItem.Name == "Help")
                    {
                        sender.Header = "Помощь";
                        contentFrame.Navigate(typeof(Help));
                    }
                }
            }
        }
        private void UpdateAppTitleMargin(Microsoft.UI.Xaml.Controls.NavigationView sender)
        {
            const int smallLeftIndent = 4, largeLeftIndent = 24;

            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                AppTitle.TranslationTransition = new Vector3Transition();

                if ((sender.DisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewDisplayMode.Expanded && sender.IsPaneOpen) ||
                         sender.DisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewDisplayMode.Minimal)
                {
                    AppTitle.Translation = new System.Numerics.Vector3(smallLeftIndent, 0, 0);
                }
                else
                {
                    AppTitle.Translation = new System.Numerics.Vector3(largeLeftIndent, 0, 0);
                }
            }
            else
            {
                Thickness currMargin = AppTitle.Margin;

                if ((sender.DisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewDisplayMode.Expanded && sender.IsPaneOpen) ||
                         sender.DisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewDisplayMode.Minimal)
                {
                    AppTitle.Margin = new Thickness(smallLeftIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
                }
                else
                {
                    AppTitle.Margin = new Thickness(largeLeftIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
                }
            }
        }


    }

}
