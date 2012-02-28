using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace UrbanAirship.NET.Api
{
    public class NullRequest { }
    public class NullResponse { }

    public class ApiBase
    {
                private string _appKey;
        private string _masterKey;
        private string _baseUrl;
        public ApiBase(string baseUrl, string appKey, string masterKey)
        {
            _appKey = appKey;
            _masterKey = masterKey;
            _baseUrl = baseUrl;
        }

        protected string Url { get { return _baseUrl; } }

        protected TResponse Invoke<TRequest, TResponse>(string url, Method method, TRequest request)
            where TRequest : class
            where TResponse : new()
        {
            List<JsonConverter> converters = new List<JsonConverter>();

            string serializedRequest = null;
            if (request != null && request.GetType() != typeof(NullRequest))
            {
                serializedRequest = Newtonsoft.Json.JsonConvert.SerializeObject(request, Newtonsoft.Json.Formatting.None,
                 new Newtonsoft.Json.JsonSerializerSettings()
                 {
                     NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                     Converters = converters
                 });
            }

            RestClient client = new RestClient(_baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(_appKey, _masterKey);
            client.ClearHandlers();
            client.AddHandler("application/json", new NewtonsoftDeserializer(), true);
            //
            RestRequest restRequest = new RestRequest(url, method);
            restRequest.RequestFormat = DataFormat.Json;

            if (serializedRequest != null)
            {
                restRequest.AddParameter("application/json", serializedRequest, ParameterType.RequestBody);
            }


            if (typeof(TResponse) == typeof(NullResponse))
            {
                var restResponse = client.Execute(restRequest);
                Console.WriteLine("Response : " + restResponse.Content);

                if (restResponse.ResponseStatus != ResponseStatus.Completed)
                {
                    throw new Exception("RESPONSE ERROR", restResponse.ErrorException);
                }
                if (restResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw CreateExceptionFromHttpCode(restResponse);
                }

                return new TResponse();
            }
            else
            {

                var restResponse = client.Execute<TResponse>(restRequest);
                Console.WriteLine("::RESPONSECONTENT::" + restResponse.Content);

                if (restResponse.ResponseStatus != ResponseStatus.Completed)
                {
                    throw new Exception("RESPONSE ERROR", restResponse.ErrorException);
                }
                if (restResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw CreateExceptionFromHttpCode(restResponse);
                }
                return restResponse.Data;
            }
        }
        Exception CreateExceptionFromHttpCode(IRestResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException("Access to resource is denied", new Exception(response.Content));
                default:
                    throw new Exception("Invalid response from service HttpCode='" + response.StatusCode + "' '" + response.StatusDescription + "'", new Exception(response.Content));
            }
        }
    }
}

