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

namespace WP7
{
    public partial class GameOver : PhoneApplicationPage
    {
        private int animation;
        private GameManager gm = GameManager.getInstance();

        public GameOver()
        {            
            InitializeComponent();
            incorrectOrderOfArrest.Visibility = Visibility.Collapsed;
            didNotEmitOrderOfArrest.Visibility = Visibility.Collapsed;
            afterDeadLine.Visibility = Visibility.Collapsed;                            
            gameOverStoryboard.Begin();
			gameOverStoryboard.Completed += new EventHandler(gameOverStoryboard_Completed);
        }
		
		void gameOverStoryboard_Completed(object sender, EventArgs e)
        {
            ////NameSuspectText.Text = gm.Data.NameSuspect;

            switch (animation)
            {
                case 0:
                    incorrectOrderOfArrest.Visibility = Visibility.Visible;
                    break;
                case 1:
                    didNotEmitOrderOfArrest.Visibility = Visibility.Visible;
                    break;
                case 2:
                    afterDeadLine.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }            
        }
    }
}
