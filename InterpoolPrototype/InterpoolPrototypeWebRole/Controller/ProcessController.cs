﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterpoolPrototypeWebRole.Data;

namespace InterpoolPrototypeWebRole.Controller
{
    public class ProcessController:IProcessController
    {
        public void StartGame(User user)
        {
            // this is only the structs that we should follow

            // 1 the trip is built to be followed by user
            BuiltTravel(user);

            // 2 Get suspects
            GetSuspects();

            // 3 Create clues
            
            //CreateClue();
        }

        public void GetSuspects()
        {
            throw new NotImplementedException();
        }

        public void BuiltTravel(User user)
        {
            Game newGame = new Game();
            user.Game = newGame;
            IDataManager dm = new DataManager();

            List<City> selectedCities = new List<City>();
            NodePath node;
            //TODO, maybe the amount of NodePath should be a param in the data base
            for (int i = 0; i < 4; i++)
            {
                node = new NodePath();
                bool find = false;
                do
                {
                    //get one city random
                    //if not city in selectedCities
                    //  find = true
                    //  node.City = city
                    //  node.Famous.Add(new List<Famous> (dm.getFamousByCity(city)))
                } while (!find);
                newGame.NodePath.Add(node);
            }
        }

        public IQueryable<Clue> CreateClue(City city, User user, Suspect suspect)
        {
            return null;
            
        }
    }
}