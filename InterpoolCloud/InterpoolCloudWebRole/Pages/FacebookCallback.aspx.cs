﻿//-----------------------------------------------------------------------
// <copyright file="FacebookCallback.aspx.cs" company="Interpool">
//     Copyright Interpool. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace InterpoolCloudWebRole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using InterpoolCloudWebRole.Data;
    using InterpoolCloudWebRole.FacebookCommunication;
    using InterpoolCloudWebRole.Utilities;
    using Newtonsoft.Json;
    using InterpoolCloudWebRole.Datatypes;

    /// <summary>
    /// Partial class declaration Face
    /// </summary>
    public partial class Face : System.Web.UI.Page
    {
        /// <summary>
        /// Description for Method.</summary>
        /// <param name="sender"> Parameter description for sender goes here</param>
        /// <param name="e"> Parameter description for e goes here</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            OAuthFacebook auth = new OAuthFacebook();

            if (Request["code"] == null)
            {
                //// Redirect the user back to Facebook for authorization.
                Response.Redirect(auth.AuthorizationLinkGet());
            }
            else
            {
                //// Gets the access token and secret.
                auth.AccessTokenGet(Request["code"]);

                if (auth.Token.Length > 0)
                {
                    IFacebookController facebookController = new FacebookController();
                    IDataManager dataManager = new DataManager();
                    InterpoolContainer container = dataManager.GetContainer();
                    User user = new User();
                    user.SubLevel = 0;
                    string codLevel = dataManager.GetParameter(Parameters.LevelRookie, container);
                    user.Level = container.Levels.Where(l => l.LevelName == codLevel).First();

                    DataFacebookUser userData = facebookController.GetUserInfoByToken(auth);
                    user.UserIdFacebook = userData.UserId;
                    user.UserTokenFacebook = auth.Token;
                    user.UserLoginId = userData.Email;
                    //// TODO: store the user's information in order to be used in future games
                    dataManager.StoreUser(user, container);

                    Response.Redirect(Constants.RedirectUrlAfterLoginFacebook);
                }
            }
        }
    }
}