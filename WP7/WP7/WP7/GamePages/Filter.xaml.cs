﻿namespace WP7.GamePages
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
    using System.Windows.Shapes;
    using Microsoft.Phone.Controls;
    using WP7.ServiceReference;
    using WP7.Utilities;

    /// <summary>
    /// Partial class declaration Filter
    /// </summary>
    public partial class Filter : PhoneApplicationPage
    {
        /// <summary>
        /// Store for the property
        /// </summary>
        private List<string> gender;

        /// <summary>
        /// Store for the property
        /// </summary>
        private List<string> homeTown;

        /// <summary>
        /// Store for the property
        /// </summary>
        private List<string> film;

        /// <summary>
        /// Store for the property
        /// </summary>
        private List<string> music;

        /// <summary>
        /// Store for the property
        /// </summary>
        private List<string> tv;

        /// <summary>
        /// Store for the property
        /// </summary>
        private List<string> birthday;

        /// <summary>
        /// Store for the property
        /// </summary>
        private string[] filters;

        /// <summary>
        /// Store for the property
        /// </summary>
        private InterpoolWP7Client client = new InterpoolWP7Client();

        /// <summary>
        /// Store for the property
        /// </summary>
        private GameManager gm = GameManager.GetInstance();

        /// <summary>
        /// Store for the property
        /// </summary>
        private LanguageManager language = LanguageManager.GetInstance();

        /// <summary>
        /// Store for the property
        /// </summary>
        private int btnPosition = 0;

        /// <summary>
        /// Store for the property
        /// </summary>
        private int item = 0;

        /// <summary>
        /// Initializes a new instance of the Filter class.</summary>
        public Filter()
        {
            InitializeComponent();            
            AnimationPage.Begin();
            ////Change the language of the page            
            if (this.language.GetXDoc() != null)
            {
                this.language.TranslatePage(this);
            }

            this.client.FilterSuspectsCompleted += new EventHandler<FilterSuspectsCompletedEventArgs>(this.ClientFilterSuspectsCompleted);
            DataFacebookUser dfu = new DataFacebookUser();
            this.client.FilterSuspectsAsync(this.gm.UserId, dfu);
            this.client.CloseCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(this.ClientCloseCompleted);
            this.client.CloseAsync();
            this.filters = new string[Constants.MaxFilterfield];
            this.UpdateFilters();
            ComboList.Visibility = Visibility.Collapsed;
        }

        public void UpdateFilters() 
        {
            string[] filterField = this.gm.GetFilterField();
            GenderText.Text = filterField[4];
            HometownText.Text = filterField[3];
            MusicText.Text = filterField[5];
            TVText.Text = filterField[7];
            CinemaText.Text = filterField[6];
            BirthdayText.Text = filterField[2];
        }

        public void ClientCloseCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {    
        }

        public void ClientFilterSuspectsCompleted(object sender, FilterSuspectsCompletedEventArgs e)
        {
            this.gm.CurrentDateTime = e.Result.CurrentDate;
            /*if (e.Result.CurrentDate.CompareTo(gm.DeadLineDateTime) == 1)
                NavigationService.Navigate(new Uri("/GamePages/GameOver.xaml", UriKind.RelativeOrAbsolute));*/
            List<DataFacebookUser> dfu = e.Result.ListFacebookUser.ToList();
            this.gender = new List<string>();
            this.film = new List<string>();
            this.homeTown = new List<string>();
            this.music = new List<string>();
            this.tv = new List<string>();
            this.birthday = new List<string>();
            foreach (DataFacebookUser df in dfu)
            {
                if (!this.film.Contains(df.Cinema))
                {
                    this.film.Add(df.Cinema);
                }

                if (!this.gender.Contains(df.Gender))
                {
                    this.gender.Add(df.Gender);
                }

                if (!this.homeTown.Contains(df.Hometown))
                {
                    this.homeTown.Add(df.Hometown);
                }

                if (!this.music.Contains(df.Music))
                {
                    this.music.Add(df.Music);
                }

                if (!this.tv.Contains(df.Television))
                {
                    this.tv.Add(df.Television);
                }

                if (!this.birthday.Contains(df.Birthday))
                {
                    this.birthday.Add(df.Birthday);
                }
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            /*if (ComboList.Visibility == Visibility.Visible)
            {
                Item = 1;
                NavigationService.Navigate(new Uri("/GamePages/Filter.xaml?Item=" + Item, UriKind.Relative));
            }
            else
                NavigationService.Navigate(new Uri("/GamePages/Game.xaml", UriKind.Relative));*/
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string[] filterField = this.gm.GetFilterField();
            for (int i = 0; i < 8; i++) 
            {
                filterField[i] = this.filters[i];
            }

            NavigationService.Navigate(new Uri("/GamePages/Suspect.xaml", UriKind.RelativeOrAbsolute));
        }       

        private void ComboList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ComboList.SelectedIndex != -1)
            {
                string[] filterField = this.gm.GetFilterField();
                filterField[this.btnPosition] = ComboList.SelectedItem.ToString();
                this.filters[this.btnPosition] = ComboList.SelectedItem.ToString();
                ComboList.Visibility = Visibility.Collapsed;
                ContentGrid2.Visibility = Visibility.Collapsed;
                ContentGrid.Visibility = Visibility.Visible;
                this.UpdateFilters();
            }
        }        

        private void TVButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.btnPosition = 7;
            ComboList.ItemsSource = this.tv;
            ContentGrid.Visibility = Visibility.Collapsed;
            ContentGrid2.Visibility = Visibility.Visible;
            ComboList.Visibility = Visibility.Visible;
        }

        private void CinemaButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.btnPosition = 6;
            ComboList.ItemsSource = this.film;
            ContentGrid.Visibility = Visibility.Collapsed;
            ContentGrid2.Visibility = Visibility.Visible;
            ComboList.Visibility = Visibility.Visible;
        }

        private void HometownButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.btnPosition = 3;
            ComboList.ItemsSource = this.homeTown;
            ContentGrid.Visibility = Visibility.Collapsed;
            ContentGrid2.Visibility = Visibility.Visible;
            ComboList.Visibility = Visibility.Visible;
        }

        private void BirthdayButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.btnPosition = 2;
            ComboList.ItemsSource = this.birthday;
            ContentGrid.Visibility = Visibility.Collapsed;
            ContentGrid2.Visibility = Visibility.Visible;
            ComboList.Visibility = Visibility.Visible;
        }

        private void GenderButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.btnPosition = 4;
            ComboList.ItemsSource = this.gender;
            ContentGrid.Visibility = Visibility.Collapsed;
            ContentGrid2.Visibility = Visibility.Visible;
            ComboList.Visibility = Visibility.Visible;
        }

        private void MusicButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.btnPosition = 5;
            ComboList.ItemsSource = this.music;
            ContentGrid.Visibility = Visibility.Collapsed;
            ContentGrid2.Visibility = Visibility.Visible;
            ComboList.Visibility = Visibility.Visible;
        }
    }
}