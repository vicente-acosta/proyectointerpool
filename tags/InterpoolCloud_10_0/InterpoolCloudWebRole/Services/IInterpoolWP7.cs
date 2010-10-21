﻿namespace InterpoolCloudWebRole.Services
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
        
    [ServiceContract]
    public interface IInterpoolWP7
    {
        [OperationContract]
        void StartGame(string userIdFacebook);

        [OperationContract]
        string GetUserIdFacebook(string idLogin);

        [OperationContract]
        DataCity GetCurrentCity(string userIdFacebook);

        [OperationContract]
        List<DataCity> GetPossibleCities(string userIdFacebook);

        [OperationContract]
        DataFamous GetCurrentFamous(string userIdFacebook, int numClue);

        [OperationContract]
        List<DataFacebookUser> FilterSuspects(string userIdFacebook, DataFacebookUser fbud);

        [OperationContract]
        void EmitOrderOfArrest(string userIdFacebook, string userIdFacebookSuspect);

        [OperationContract]
        List<DataCity> GetCities(string userIdFacebook);

        [OperationContract]
        DataCity Travel(string userIdFacebook, string nameNextCity);

		[OperationContract]
        DataClue GetClueByFamous(string userIdFacebook, int numFamous);
    }
}
