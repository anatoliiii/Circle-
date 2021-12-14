using System;
using System.Linq;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CirclePointsA
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsLocal : Page
    {
        public SettingsLocal()
        {
            this.InitializeComponent();
            Loaded += OnSettingsPageLoaded;

            if (MainPage.mainPage.NavigationView.PaneDisplayMode == Microsoft.UI.Xaml.Controls.NavigationViewPaneDisplayMode.LeftCompact)
            {
                navigationLocation.SelectedIndex = 0;
            }
            else
            {
                navigationLocation.SelectedIndex = 1;
            }

        }
        private void OnSettingsPageLoaded(object sender, RoutedEventArgs e)
        {
            var currentTheme = ThemeHelper.RootTheme.ToString();
            (ThemePanel.Children.Cast<RadioButton>().FirstOrDefault(c => c?.Tag?.ToString() == currentTheme)).IsChecked = true;
        }

        private void OnThemeRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            var selectedTheme = ((RadioButton)sender)?.Tag?.ToString();
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

            if (selectedTheme != null)
            {
                ThemeHelper.RootTheme = App.GetEnum<ElementTheme>(selectedTheme);
            }
        }

        private void OnThemeRadioButtonKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Up)
            {
                // NavigationRootPage.Current.PageHeader.Focus(FocusState.Programmatic);
            }
        }





        private void navigationLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationOrientationHelper.IsLeftMode = navigationLocation.SelectedIndex == 0;
        }

        private async void FolderButton_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            folderPicker.FileTypeFilter.Add(".png"); // meaningless, but you have to have something
            StorageFolder folder = await folderPicker.PickSingleFolderAsync();

            if (folder != null)
            {
                // UIHelper.ScreenshotStorageFolder = folder;
                // screenshotFolderLink.Content = UIHelper.ScreenshotStorageFolder.Path;
            }
        }
    }
}
