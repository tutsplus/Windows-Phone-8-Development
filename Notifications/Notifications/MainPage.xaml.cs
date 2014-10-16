using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Notifications
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

        private void Button_Click(object sender, RoutedEventArgs e) {
            var toastTemplate = ToastTemplateType.ToastText02;
            var toastXml = ToastNotificationManager.GetTemplateContent( toastTemplate );

            var toastTextElements = toastXml.GetElementsByTagName( "text" );
            toastTextElements[0].AppendChild( toastXml.CreateTextNode( "Hello There!" ) );
            toastTextElements[1].AppendChild( toastXml.CreateTextNode( "This is a sample toast" ) );

            var toast = new ToastNotification( toastXml );
            toast.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds( 3600 );
            toast.SuppressPopup = true;

            toast.Tag = "winphone";
            toast.Group = "tuts+";

            ToastNotificationManager.CreateToastNotifier( ).Show( toast );

            ToastNotificationManager.History.Remove("winphone", "tuts+");
        }
    }
}
