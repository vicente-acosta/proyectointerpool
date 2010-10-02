﻿using System;
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

namespace WP7
{
    public partial class Game : PhoneApplicationPage
    {
        public Game()
        {
            InitializeComponent();
        }

        private void ComputerButton_Click(object sender, RoutedEventArgs e)
        {
            GameManager gm = GameManager.getInstance();
            gm.SetFamousIndex(2);
            NavigationService.Navigate(new Uri("/GamePages/Famous.xaml", UriKind.RelativeOrAbsolute));
        }
		
		private void DoorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
		
		private void FilesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Filter.xaml", UriKind.RelativeOrAbsolute));    
        }
		
		private void MapButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GamePages/City.xaml", UriKind.RelativeOrAbsolute));
        }

		private void NewspaperButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            GameManager gm = GameManager.getInstance();
            gm.SetFamousIndex(1);
			NavigationService.Navigate(new Uri("/GamePages/Famous.xaml", UriKind.RelativeOrAbsolute));
		}

		private void phoneButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            GameManager gm = GameManager.getInstance();
            gm.SetFamousIndex(0);
            NavigationService.Navigate(new Uri("/GamePages/Famous.xaml", UriKind.RelativeOrAbsolute));            
		}
	}
}