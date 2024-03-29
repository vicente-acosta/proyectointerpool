﻿namespace WP7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using System.Xml.Linq;
    using Microsoft.Phone.Controls;
    using WP7.ServiceReference;
    using WP7.Utilities;
    using System.ServiceModel;

    /// <summary>
    /// Partial class declaration Login
    /// </summary>
    public partial class Login : PhoneApplicationPage
    {

        /// <summary>
        /// Store for the property
        /// </summary>
        private InterpoolWP7Client client = new InterpoolWP7Client();

        /// <summary>
        /// Store for the property
        /// </summary>
        private LanguageManager language = LanguageManager.GetInstance();

        /// <summary>
        /// Store for the property
        /// </summary>
        private GameManager gm = GameManager.GetInstance();

        /// <summary>
        /// Initializes a new instance of the Login class.</summary>
        public Login()
        {
            InitializeComponent();
            if (this.language.GetXDoc() != null)
            {
                this.language.TranslatePage(this);
            }
            else
            {
                this.language.SetXDoc(XDocument.Load("GameLanguages/Spanish.xml"));
                this.language.TranslatePage(this);
            }

            if (string.IsNullOrEmpty(gm.UserEmail))
            {
                userEmail.Text = Constants.DEFAULT_DOMAIN;
                userEmail.SelectionStart = 0;
            }
            else
            {
                userEmail.Text = gm.UserEmail;
                userEmail.SelectAll();
            }
        }
        
        private void ContinueButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ContinueButton.Visibility = Visibility.Collapsed;
            loginMessage.Visibility = Visibility.Collapsed;
            loginImage.Visibility = Visibility.Collapsed;
            gm.UserEmail = userEmail.Text;
            userEmail.Visibility = Visibility.Collapsed;
            gm.GetUserInfoTries = 0;
            try
            {
                this.client.GetUserInfoCompleted += new EventHandler<GetUserInfoCompletedEventArgs>(client_GetUserInfoCompleted);
                client.GetUserInfoAsync(gm.UserEmail);
            }
            catch (FaultException ex) 
            {
                ShowHideInterpoolFailMessage(ex.Message, true); 
            }
        }

        void client_GetUserInfoCompleted(object sender, GetUserInfoCompletedEventArgs e)
        {
            this.gm.UserInfo = e.Result;
            this.gm.UserId = gm.UserInfo.UserIdFacebook;
            this.gm.GetUserInfoTries++;
            if (gm.FromMainPage == true)
            {
                gm.FromMainPage = false;
                if (gm.UserInfo.UserState == UserState.NO_REGISTERED || gm.UserInfo.UserState == UserState.REGISTERED_NO_PLAYING_LOGIN_REQUIRED)
                {
                    WebBrowser.Visibility = Visibility.Visible;
                    WebBrowser.Source = new Uri(Constants.FACEBOOK_LOGIN_URL, UriKind.Absolute);
                }
                else
                {
                    gm.FromMainPage = false;
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
                }
            }
            else
            {
                NavigationService.Navigate(new Uri("/GamePages/Options.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void YesFailButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ShowHideInterpoolFailMessage("", false);
        }

        private void ShowHideInterpoolFailMessage(string message, bool flag)
        {
            failMessageText.Visibility = (flag == true) ? Visibility.Visible : Visibility.Collapsed;
            if (flag)
                failMessageText.Text = message;
            MessageImage.Visibility = (flag == true) ? Visibility.Visible : Visibility.Collapsed;
            YesFailButton.Visibility = (flag == true) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
