﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Microsoft.Phone.Controls;

namespace UI_wp7
{
	public class GameManager
	{
	
		private static GameManager instance;
		private String actualCity;
		private List<String> cities;
		private List<String> clues;
		private List<String> famous;
		private List<String> suspects;
        private int juego;
		
		public static GameManager getInstance()
		{
			if (instance == null)
				instance = new GameManager();
			return instance;	
		} 
	
		private GameManager()
		{
			cities = new List<String>();
			famous = new List<String>();
			clues = new List<String>();
			suspects = new List<String>();
            juego = 0;
		}
		
		public void AddCity(int position, String name)
		//Add the new citie in the list
		{
			cities.Insert(position, name);			
		}

        public void AddClue(int position, String name)
		//Add the new clue in the list
		{
			clues.Insert(position, name);			
		}

        public void AddFamous(int position, String name)
		//Add the new famous the list
		{
            famous.Insert(position, name);
		}
		
		public void SetActualCity(String city)
		{
			actualCity = city;
		}

        public void SetCurrentCities(List<String> list)
        {
            cities = list;
        }

        public void SetCurrentFamous(List<String> list)
        {
            famous = list;
        }

		public void RemoveCities()
		//Remove all the elements of the list
		{
			cities.RemoveRange(0,2);		
		}
		
		public void RemoveClues()
		//Remove all the elements of the list
		{
			clues.RemoveRange(0,2);		
		}
		
		public void RemoveFamous()
		//Remove all the elements of the list
		{
			famous.RemoveRange(0,2);		
		}
		
		public List<String> GetCities()
		//Return all the cities	
		{
			return cities;
		}
	
		public List<String> GetClues()
		//Return all the clues	
		{
			return clues;
		}
		
		public List<String> GetFamous()
		//Return all the famous	
		{
			return famous;
		}

        public String GetActualCity()
        //Return the actual city
        {
            return actualCity;
        }
		
		public List<String> GetSuspects()
		{
			return suspects;
		}
		
		public void SetSuspectsList(List<String> list)
		{
			suspects = list;
		}

        public void incJuego()
        {
            juego ++;
        }

        public int getJuego()
        {
            return juego;
        }
}
}