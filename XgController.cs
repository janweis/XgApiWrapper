using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XgApiWrapper
{
    public class XgController
    {
        public Connection ConnectionData { get; set; }
        private WebHandler Web { get; set; }

        public XgController(Connection connection)
        {
            ConnectionData = connection;
            Web = new WebHandler();
        }

        ///
        /// GET DATA
        ///

        /// <summary>
        /// Get a List of Items of defined Type
        /// </summary>
        public async Task<T[]> GetItemsAsync<T>()
        {
            // Create Request
            Request request = new Request(ConnectionData, RequestType.Get, typeof(T));
            string xmlRequest = request.CreateXmlForList();

            return await ProcessAndValidateDataAsync<T>(xmlRequest);
        }

        /// <summary>
        /// Get Item by Name
        /// </summary>
        public async Task<T> GetItemAsync<T>(string name)
        {
            // Create Request
            Request request = new Request(ConnectionData, RequestType.Get, typeof(T));
            string xmlRequest = request.CreateXmlIncludeFilter(name);

            return
                (await ProcessAndValidateDataAsync<T>(xmlRequest))[0];
        }


        ///
        /// ADD, SET DATA
        ///

        /// <summary>
        /// Add a Object to the Firewall
        /// </summary>
        public async Task SetItemAsync<T>(T item) where T : IWebReturnStatus
        {
            // Create Request
            Request request = new Request(ConnectionData, RequestType.Set, typeof(T));
            string xmlRequest = request.CreateXmlIncludeObject<T>(item);
            T[] dataItemList = await ProcessAndValidateDataAsync<T>(xmlRequest);

            // Verify Response
            if (null != dataItemList)
            {
                if (dataItemList[0].Status.ReturnCode != 200)
                    throw new Exception("Webserver Message: " + dataItemList[0].Status.ReturnText + "; Code: " + dataItemList[0].Status.ReturnCode);

                //if (int.Parse(webReturnStatus.Status.ReturnCode) != 200)
            }
        }

        /// <summary>
        /// Add Objects to the Firewall
        /// </summary>
        public async Task SetItemAsync<T>(T[] items) where T : IWebReturnStatus
        {
            // Create Request
            Request request = new Request(ConnectionData, RequestType.Set, typeof(T));
            string xmlRequest = request.CreateXmlIncludeObject<T>(items);
            T[] dataItemList = await ProcessAndValidateDataAsync<T>(xmlRequest);

            // Verify Response
            if (null != dataItemList)
            {
                if (dataItemList[0].Status.ReturnCode != 200)
                    throw new Exception("Webserver Message: " + dataItemList[0].Status.ReturnText + "; Code: " + dataItemList[0].Status.ReturnCode);
            }
        }


        ///
        /// REMOVE DATA
        ///

        /// <summary>
        /// Remove a Object from the Firewall
        /// </summary>
        public async Task<T> DeleteItemAsync<T>(string name)
        {
            // Create Request
            Request request = new Request(ConnectionData, RequestType.Remove, typeof(T));
            string xmlRequest = request.CreateXmlIncludeFilter(name);

            return
                (await ProcessAndValidateDataAsync<T>(xmlRequest))[0];
        }

        /// <summary>
        /// Remove a Object from the Firewall
        /// </summary>
        public async Task<T[]> DeleteItemAsync<T>(string[] names)
        {
            // Create Request
            Request request = new Request(ConnectionData, RequestType.Remove, typeof(T));
            string xmlRequest = request.CreateXmlIncludeObjectName<T>(names);

            return
                await ProcessAndValidateDataAsync<T>(xmlRequest);
        }



        ///
        /// HELPER
        ///

        /// <summary>
        /// Sends and Receivs Data to the Webserver
        /// </summary>
        private async Task<T[]> ProcessAndValidateDataAsync<T>(string xmlRequest)
        {
            // Send Data
            string connectionString = Web.BuildConnectionString(xmlRequest, ConnectionData);
            string xmlResponse = await Web.SubmitConnectionStringAsync(connectionString);

            // Parse Data
            string[] loginStatus;
            List<T> dataItemList = XmlParser.ParseXmlResponseAdv<T>(xmlResponse, out loginStatus);

            // Verify Login
            if (null == loginStatus || loginStatus[0] != "Authentication Successful")
                throw new Exception("Authentication NOT successful!");

            if (null == dataItemList)
                return null;

            return dataItemList.ToArray();
        }
    }
}
