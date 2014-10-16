using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Storage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void btnWrite_Click(object sender, RoutedEventArgs e) {
            await WriteToFileAsync( );

            btnWrite.IsEnabled = false;
            btnRead.IsEnabled = true;
        }

        private async Task WriteToFileAsync( ) {
            var fileBytes = Encoding.UTF8.GetBytes( txtBoxEntry.Text.ToCharArray( ) );

            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            var dataFolder = await localFolder.CreateFolderAsync( "DataFolder", CreationCollisionOption.OpenIfExists );

            var file = await dataFolder.CreateFileAsync( "DataFile.txt", CreationCollisionOption.ReplaceExisting );

            using ( var s = await file.OpenStreamForWriteAsync( ) ) {
                s.Write(fileBytes, 0, fileBytes.Length);
            }
        }

        private async void btnRead_Click(object sender, RoutedEventArgs e) {
            await ReadFileAsync( );

            btnWrite.IsEnabled = true;
            btnRead.IsEnabled = false;
        }

        private async Task ReadFileAsync( ) {
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            if ( localFolder != null ) {
                var dataFolder = await localFolder.GetFolderAsync( "DataFolder" );

                var file = await dataFolder.OpenStreamForReadAsync( "DataFile.txt" );

                using ( var streamReader = new StreamReader( file ) ) {
                    txtBlockRead.Text = streamReader.ReadToEnd( );
                }
            }
        }
    }
}
