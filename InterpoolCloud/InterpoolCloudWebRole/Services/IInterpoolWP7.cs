﻿//-----------------------------------------------------------------------
// <copyright file="IInterpoolWP7.cs" company="Interpool">
//     Copyright Interpool. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace InterpoolCloudWebRole.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using InterpoolCloudWebRole.Data;
    using InterpoolCloudWebRole.Datatypes;
    using InterpoolCloudWebRole.FacebookCommunication;
    using InterpoolCloudWebRole.Utilities;

    /// <summary>
    /// Interface Description IInterpoolWP7
    /// </summary>
    [ServiceContract]
    public interface IInterpoolWP7
    {
        /// <summary>
        /// Description for Method.</summary>
        /// <param name="userIdFacebook"> Parameter description for userIdFacebook goes here</param>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void StartGame(string userIdFacebook);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="idLogin"> Parameter description for idLogin goes here</param>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        string GetUserIdFacebook(string idLogin);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="idLogin"> Parameter description for idLogin goes here</param>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        DataUserInfo GetUserInfo(string idLogin);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="userIdFacebook"> Parameter description for userIdFacebook goes here</param>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        DataCity GetCurrentCity(string userIdFacebook);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="userIdFacebook"> Parameter description for userIdFacebook goes here</param>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<DataCity> GetPossibleCities(string userIdFacebook);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="userIdFacebook"> Parameter description for userIdFacebook goes here</param>
        /// <param name="numClue"> Parameter description for numClue goes here</param>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        DataFamous GetCurrentFamous(string userIdFacebook, int numClue);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="userIdFacebook"> Parameter description for userIdFacebook goes here</param>
        /// <param name="fbud"> Parameter description for fbud goes here</param>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        DataListFacebookUser FilterSuspects(string userIdFacebook, DataFacebookUser fbud);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="userIdFacebook"> Parameter description for userIdFacebook goes here</param>
        /// <param name="userIdFacebookSuspect"> Parameter description for userIdFacebookSuspect goes here</param>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void EmitOrderOfArrest(string userIdFacebook, string userIdFacebookSuspect);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="userIdFacebook"> Parameter description for userIdFacebook goes here</param>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<DataCity> GetCities(string userIdFacebook);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="userIdFacebook"> Parameter description for userIdFacebook goes here</param>
        /// <param name="nameNextCity"> Parameter description for nameNextCity goes here</param>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        DataCity Travel(string userIdFacebook, string nameNextCity);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="userIdFacebook"> Parameter description for userIdFacebook goes here</param>
        /// <param name="numFamous"> Parameter description for numFamous goes here</param>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        DataClue GetClueByFamous(string userIdFacebook, int numFamous);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="user"> Parameter description for user goes here</param>
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void DeleteGame(User user);

        /// <summary>
        /// Description for Method.</summary>
        /// <param name="userIdFacebook"> Parameter description for userIdFacebook goes here</param>
        /// <returns>Return results are described through the returns tag.</returns>
        [OperationContract]
        DataFacebookUser GetFilters(string userIdFacebook);  
    }
}
