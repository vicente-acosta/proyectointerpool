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
    using System.Windows.Shapes;
    using Microsoft.Phone.Controls;
    using WP7.ServiceReference;
    using WP7.Utilities;

    public partial class City : PhoneApplicationPage
    {
        private InterpoolWP7Client client;
        private LanguageManager language;
        private GameManager gm = GameManager.getInstance();
        private double[] coordX;
        private double[] coordY;
        private int currentTravel;

        public City()
        {
            InitializeComponent();
            this.coordX = new double[Constants.MAX_CITIES];
            this.coordY = new double[Constants.MAX_CITIES];
			AnimationPage.Begin();
            this.language = LanguageManager.GetInstance();
            if (this.language.GetXDoc() != null)
                this.language.TranslatePage(this);
            this.client = new InterpoolWP7Client();
            this.client.GetCitiesCompleted += new EventHandler<GetCitiesCompletedEventArgs>(this.client_GetCitiesCompleted);
            this.client.GetCitiesAsync(this.gm.UserId);
            this.client.CloseCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(this.client_CloseCompleted);
            this.client.CloseAsync();	
            Thickness margin = plane.Margin;
            margin.Top = 200;
            margin.Bottom = 100;
            plane.Margin = margin;
            Thickness margin1 = avion.Margin;
            margin1.Left = 100;
            margin1.Top = 300;
            avion.Margin = margin1;
            button1.Visibility = System.Windows.Visibility.Collapsed;
            button2.Visibility = System.Windows.Visibility.Collapsed;
            button3.Visibility = System.Windows.Visibility.Collapsed;
            closeInterpoolMessage();
        }

        void client_GetCitiesCompleted(object sender, GetCitiesCompletedEventArgs e)
        {
            List<DataCity> dataCities = e.Result.ToList();
            if (dataCities != null)
            {
                button1.Content = dataCities.ElementAt(0).NameCity;
                button2.Content = dataCities.ElementAt(1).NameCity;
                button3.Content = dataCities.ElementAt(2).NameCity;
                for (int i = 0; i < dataCities.Count; i++)
                {
                    coordX[i] = dataCities.ElementAt(0).Left;
                    coordY[i] = dataCities.ElementAt(0).Top;
                }
                button1.Visibility = System.Windows.Visibility.Visible;
                button2.Visibility = System.Windows.Visibility.Visible;
                button3.Visibility = System.Windows.Visibility.Visible;                
            }
        }

        void client_CloseCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GamePages/Game.xaml", UriKind.RelativeOrAbsolute));
        }

        void client_TravelCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            currentTravel = 0;
            this.showInterpoolMessage(button1.Content.ToString());
        }

        private void travel1()
        {                
                InterpoolWP7Client client = new InterpoolWP7Client();
                client.TravelCompleted += new EventHandler<TravelCompletedEventArgs>(client_TravelCompleted);
                client.TravelAsync(this.gm.UserId, button1.Content.ToString());
                this.gm.SetCurrentCity(button1.Content.ToString());
                client.CloseCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(this.client_CloseCompleted);
                client.CloseAsync();
            ////}
        }

        private void showInterpoolMessage(string nameCity) 
        {
            messageText.Text = "¿Desea viajar a " + nameCity + "?";
            MessageImage.Visibility = Visibility.Visible;
            messageText.Visibility = Visibility.Visible;
            YesButton.Visibility = Visibility.Visible;
            NoButton.Visibility = Visibility.Visible;
            textToTravel.Visibility = Visibility.Collapsed;
            button1.Visibility = Visibility.Collapsed;
            button2.Visibility = Visibility.Collapsed;
            button3.Visibility = Visibility.Collapsed;                
        }

        void client_TravelCompleted(object sender, TravelCompletedEventArgs e)
        {
            DataCity city = e.Result;
            gm.CurrentDateTime = city.CurrentDate;
            if (city.CurrentDate.CompareTo(gm.DeadLineDateTime) == 1)
                NavigationService.Navigate(new Uri("/GamePages/GameOver.xaml", UriKind.RelativeOrAbsolute));
            ////Coords. cities
            double coordX_cityI = gm.Left; 
            double coordY_cityI = gm.Top;
            double coordX_cityE = coordX[currentTravel];
            double coordY_cityE = coordY[currentTravel];
			////pregunto si coordX_I < coordY_I, si es true, esta bien asi
			////sino cambiar el scale del X a -1(para q el plane quede mirando para el lado que va)
			
			////Start Frame 1, Position (init_X,init_Y)
			DoubleKeyFrame keyframeX = translateX.KeyFrames[0];
			double init_frame = 0.0, init_X = coordX_cityI;
			keyframeX.SetValue(EasingDoubleKeyFrame.ValueProperty, init_frame);
			trX1.SetValue(EasingDoubleKeyFrame.ValueProperty, init_X);
			DoubleKeyFrame keyframeY = translateY.KeyFrames[0];
			double init_Y = coordY_cityI;
			keyframeY.SetValue(EasingDoubleKeyFrame.ValueProperty, init_frame);
			trY1.SetValue(EasingDoubleKeyFrame.ValueProperty, init_Y);
			
			////Start Frame 2, Position (init_X2,init_Y2)
			DoubleKeyFrame keyframeX2 = translateX.KeyFrames[1];
			double init_frame2 = 3.0, init_X2 = coordX_cityI + 40;
			keyframeX2.SetValue(EasingDoubleKeyFrame.ValueProperty, init_frame2);
			trX2.SetValue(EasingDoubleKeyFrame.ValueProperty, init_X2);
			DoubleKeyFrame keyframeY2 = translateY.KeyFrames[1];
			double init_Y2 = coordY_cityI - 45;
			keyframeY2.SetValue(EasingDoubleKeyFrame.ValueProperty, init_frame2);
			trY2.SetValue(EasingDoubleKeyFrame.ValueProperty, init_Y2);
			
			////Start Frame 3, Position (init_X3,init_Y3)
			DoubleKeyFrame keyframeX3 = translateX.KeyFrames[2];
			double init_frame3 = 6.0, init_X3 = coordX_cityI + 240;
			keyframeX3.SetValue(EasingDoubleKeyFrame.ValueProperty, init_frame3);
			trX3.SetValue(EasingDoubleKeyFrame.ValueProperty, init_X3);
			DoubleKeyFrame keyframeY3 = translateY.KeyFrames[2];
			double init_Y3 = init_Y2;
			keyframeY3.SetValue(EasingDoubleKeyFrame.ValueProperty, init_frame3);
			trY3.SetValue(EasingDoubleKeyFrame.ValueProperty, init_Y3);
			
			////Start Frame 4, Position (init_X4,init_Y4)
			DoubleKeyFrame keyframeX4 = translateX.KeyFrames[3];
            double init_frame4 = 9.0, init_X4 = coordX_cityE;
            ////coordX_cityI + 380;
            keyframeX4.SetValue(EasingDoubleKeyFrame.ValueProperty, init_frame4);
            trX4.SetValue(EasingDoubleKeyFrame.ValueProperty, init_X4);
            DoubleKeyFrame keyframeY4 = translateY.KeyFrames[3];
			double init_Y4 = coordY_cityE;
			keyframeY4.SetValue(EasingDoubleKeyFrame.ValueProperty, init_frame4);
			trY4.SetValue(EasingDoubleKeyFrame.ValueProperty, init_Y4);			
			plane_sound.Play();
			////Start plane animation 			
			animacion2.Begin();
            animacion2.Completed += new EventHandler(animacion2_Completed);
            gm.Left = coordX[currentTravel];
            gm.Top = coordY[currentTravel];
            gm.ShowAnimation = (city.CityNumber == 3);            
        }

        void animacion2_Completed(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/GamePages/Game.xaml", UriKind.RelativeOrAbsolute));
        }


        private void button2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            currentTravel = 1;
            this.showInterpoolMessage(button2.Content.ToString());
        }

        private void travel2()
        {        
                InterpoolWP7Client client = new InterpoolWP7Client();
                client.TravelCompleted += new EventHandler<TravelCompletedEventArgs>(client_TravelCompleted);
                client.TravelAsync(this.gm.UserId, button2.Content.ToString());
                this.gm.SetCurrentCity(button2.Content.ToString());
                this.client.CloseCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(client_CloseCompleted);
                client.CloseAsync();            
        }

        private void button3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            currentTravel = 2;
            this.showInterpoolMessage(button3.Content.ToString());
        }

        private void travel3()
        {	               
                InterpoolWP7Client client = new InterpoolWP7Client();
                client.TravelCompleted += new EventHandler<TravelCompletedEventArgs>(client_TravelCompleted);
                client.TravelAsync(this.gm.UserId, button3.Content.ToString());
                this.gm.SetCurrentCity(button3.Content.ToString());
                client.CloseCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(client_CloseCompleted);
                client.CloseAsync();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;
            closeInterpoolMessage();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            closeInterpoolMessage();
            switch (currentTravel)
            {
                case 0:
                    travel1();
                    break;
                case 1:
                    travel2();
                    break;
                case 2:
                    travel3();
                    break;
                default:
                    break;
            }
        }

        private void closeInterpoolMessage()
        {
            messageText.Text = "";
            MessageImage.Visibility = System.Windows.Visibility.Collapsed;
            messageText.Visibility = Visibility.Collapsed;
            YesButton.Visibility = Visibility.Collapsed;
            NoButton.Visibility = Visibility.Collapsed;
            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;
            textToTravel.Visibility = Visibility.Visible;    
        }
    }
}