﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Net;
using System.IO;

namespace InterpoolPrototypeWebRole.FacebookComunication
{

    public class oAuthFacebook
    {
        public enum Method { GET, POST };
        // TODO: change the next fixed urls with global parameters (in the WebConfig file)
        public const string AUTHORIZE = "https://graph.facebook.com/oauth/authorize";
        public const string ACCESS_TOKEN = "https://graph.facebook.com/oauth/access_token";
        public const string CALLBACK_URL = "http://servicewp7.cloudapp.net/FacebookCallback.aspx/";
        // public const string CALLBACK_URL = "http://127.0.0.1:81/FacebookCallback.aspx/";

        private string _consumerKey = "";
        private string _consumerSecret = "";
        private string _token = "";

        #region Properties

        public string ConsumerKey
        {
            get
            {
                if (_consumerKey.Length == 0)
                {
                    _consumerKey = "123625261023469"; //Your application ID
                }
                return _consumerKey;
            }
            set { _consumerKey = value; }
        }

        public string ConsumerSecret
        {
            get
            {
                if (_consumerSecret.Length == 0)
                {
                    _consumerSecret = "2ea5107535d2ee3f514a06a186139be6"; //Your application secret
                }
                return _consumerSecret;
            }
            set { _consumerSecret = value; }
        }

        public string Token { get { return _token; } set { _token = value; } }

        #endregion

        /// <summary>
        /// Get the link to Facebook's authorization page for this application.
        /// </summary>
        /// <returns>The url with a valid request token, or a null string.</returns>
        public string AuthorizationLinkGet()
        {
           // return string.Format("{0}?client_id={1}&redirect_uri={2}", AUTHORIZE, this.ConsumerKey, CALLBACK_URL);
            return string.Format("{0}?client_id={1}&redirect_uri={2}&scope=offline_access,publish_stream,friends_about_me,friends_birthday,friends_hometown,friends_interests,friends_likes,friends_online_presence, friends_status", AUTHORIZE, this.ConsumerKey, CALLBACK_URL);
        }

        /// <summary>
        /// Exchange the Facebook "code" for an access token.
        /// </summary>
        /// <param name="authToken">The oauth_token or "code" is supplied by Facebook's authorization page following the callback.</param>
        public void AccessTokenGet(string authToken)
        {
            this.Token = authToken;
            string accessTokenUrl = string.Format("{0}?client_id={1}&redirect_uri={2}&client_secret={3}&code={4}",
            ACCESS_TOKEN, this.ConsumerKey, CALLBACK_URL, this.ConsumerSecret, authToken);

            string response = WebRequest(Method.GET, accessTokenUrl, String.Empty);
            
            if (response.Length > 0)
            {
                //Store the returned access_token
                NameValueCollection qs = HttpUtility.ParseQueryString(response);

                if (qs["access_token"] != null)
                {
                    this.Token = qs["access_token"];
                }
            }
        }

        /// <summary>
        /// Web Request Wrapper
        /// </summary>
        /// <param name="method">Http Method</param>
        /// <param name="url">Full url to the web resource</param>
        /// <param name="postData">Data to post in querystring format</param>
        /// <returns>The web server response.</returns>
        public string WebRequest(Method method, string url, string postData)
        {

            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.UserAgent = "firefox";
            webRequest.Timeout = 20000;

            if (method == Method.POST)
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";

                //POST the data.
                requestWriter = new StreamWriter(webRequest.GetRequestStream());

                try
                {
                    requestWriter.Write(postData);
                }
                catch
                {
                    throw;
                }

                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }

            responseData = WebResponseGet(webRequest);
            webRequest = null;
            return responseData;
        }

        /// <summary>
        /// Process the web response.
        /// </summary>
        /// <param name="webRequest">The request object.</param>
        /// <returns>The response data.</returns>
        public string WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }

            return responseData;
        }
    }

}