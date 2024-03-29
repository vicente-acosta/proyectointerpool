﻿namespace WP7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using Microsoft.Phone.Controls;
    using WP7.ServiceReference;
    using System.ServiceModel;


    /// <summary>
    /// Partial class declaration Famous
    /// </summary>
    public partial class Famous : PhoneApplicationPage
    {
        /// <summary>
        /// Store for the property
        /// </summary>
        private InterpoolWP7Client client;

        /// <summary>
        /// Store for the property
        /// </summary>
        private LanguageManager language = LanguageManager.GetInstance();

        /// <summary>
        /// Store for the property
        /// </summary>
        private GameManager gm = GameManager.GetInstance();

        /// <summary>
        /// Initializes a new instance of the Famous class.</summary>
        public Famous()
        {
            InitializeComponent();
            AnimationPage.Begin();
            //// Change the language of the page            
            if (this.language.GetXDoc() != null)            
                this.language.TranslatePage(this);
			try {
                gm.AddCurrentFamous();
				this.client = new InterpoolWP7Client();
				this.client.GetClueByFamousCompleted += new EventHandler<GetClueByFamousCompletedEventArgs>(GetClueByFamousCallback);
                this.client.GetClueByFamousAsync(gm.UserId, gm.GetCurrentFamous());
                this.client.CloseCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(this.ClientCloseCompleted);
				this.client.CloseAsync();
				this.client = new InterpoolWP7Client();
                this.client.GetCurrentFamousCompleted += new EventHandler<GetCurrentFamousCompletedEventArgs>(this.ClientGetCurrentFamousCompleted);
                int numFamous = 1;
                if (gm.GetCurrentFamous() == 2){
                    numFamous = 0;
                }
                if (gm.GetCurrentFamous() == 0){
                    numFamous = 2;
                }
                this.client.GetCurrentFamousAsync(this.gm.UserId, numFamous);
                this.client.CloseCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(this.ClientCloseCompleted);
				this.client.CloseAsync();
			} catch (FaultException e) {
				ShowHideInterpoolFailMessage(e.Message, true);			
			}   
            famousName.Visibility = System.Windows.Visibility.Collapsed;
            Bubble.Visibility = Visibility.Collapsed;
            dialogText.Visibility = Visibility.Collapsed;
			
        }

        public void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public void ClientCloseCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
        }

        public void ClientGetCurrentFamousCompleted(object sender, GetCurrentFamousCompletedEventArgs e)
        {
            DataFamous dataF = e.Result;
            int num = this.gm.GetCurrentFamous();
            //this.gm.AddFamous(num - 1, dataF.NameFamous);
            
            famousName.Visibility = System.Windows.Visibility.Visible;
            ////Show in the content of the button the name of the famous is going to be interrogated
            famousName.Text = dataF.NameFamous;
            string famousURI = "../FamousImages/" + dataF.FileFamous;
            famousImage.Source = new BitmapImage(new Uri(famousURI, UriKind.Relative));
            Bubble.Visibility = Visibility.Visible;
            dialogText.Visibility = Visibility.Visible;
        }

        private void GetClueByFamousCallback(object sender, GetClueByFamousCompletedEventArgs e)
        {
            DataClue data = e.Result;
            this.gm.CurrentDateTime = data.CurrentDate;
            dialogText.Text = data.Clue;
            this.gm.Data = data;
            this.gm.Info = data.GameInfo;
            switch (data.States)
            {
                case GameState.LOSE_EOAW:
                    NavigationService.Navigate(new Uri("/GamePages/GameOver.xaml?animation =" + 0, UriKind.RelativeOrAbsolute));
                    break;
                case GameState.LOSE_NEOA:
                    NavigationService.Navigate(new Uri("/GamePages/GameOver.xaml?animation =" + 1, UriKind.RelativeOrAbsolute));
                    break;
                case GameState.WIN:
                    NavigationService.Navigate(new Uri("/GamePages/Finish.xaml?", UriKind.RelativeOrAbsolute));
                    break;
                case GameState.LOSE_TO:
                    NavigationService.Navigate(new Uri("/GamePages/GameOver.xaml?animation =" + 2, UriKind.RelativeOrAbsolute));
                    break;
                default:
                    break;
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

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GamePages/Game.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
