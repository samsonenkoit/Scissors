using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ScissorsApp.Page
{
    public partial class LinkPage : ContentPage
    {
        private static string LinkUrl = "https://n20037.yclients.com/company:38297?o=";

        public LinkPage()
        {
            InitializeComponent();

            LinkWebView.Navigated += WebViewNavigated_Handler;
            LinkWebView.Navigating += WebViewNavigating_Handler;

            UpdateWebView();
        }

        private void SetPageLoadingState()
        {
            ErrorGr.IsVisible = false;
            LoadingGrid.IsVisible = true;
            SplashIm.IsVisible = true;
        }

        private void SetPageLoadedState()
        {
            ErrorGr.IsVisible = false;
            LoadingGrid.IsVisible = false;
            SplashIm.IsVisible = false;
        }

        private void SetPageLoadErrorState()
        {
            LoadingGrid.IsVisible = false;
            ErrorGr.IsVisible = true;
            SplashIm.IsVisible = true;
        }

        private void UpdateWebView()
        {
            LinkWebView.Source = LinkUrl;
        }

        #region Handlers

        private void UpdateButtonClicked_Handler(object sender, EventArgs arg)
        {
            UpdateWebView();
        }

        private void WebViewNavigated_Handler(object sender, WebNavigatedEventArgs arg)
        {
            if (arg.Result == WebNavigationResult.Success)
                SetPageLoadedState();
            else
            {
                SetPageLoadErrorState();
            }
        }

        private void WebViewNavigating_Handler(object sender, WebNavigatingEventArgs arg)
        {
            SetPageLoadingState();
        }

        #endregion
    }
}
