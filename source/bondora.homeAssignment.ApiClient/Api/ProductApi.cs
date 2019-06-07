/* 
 * Equimpent rental API V1
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using bondora.homeAssignment.ApiClient.Client;
using bondora.homeAssignment.Models.Contracts.Product;

namespace bondora.homeAssignment.ApiClient.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProductApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"> (optional)</param>
        /// <returns>ProductContract</returns>
        ProductContract ApiProductGetProductGet (long? id = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"> (optional)</param>
        /// <returns>ApiResponse of ProductContract</returns>
        ApiResponse<ProductContract> ApiProductGetProductGetWithHttpInfo (long? id = null);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;ProductContract&gt;</returns>
        List<ProductContract> ApiProductGetProductsGet ();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;ProductContract&gt;</returns>
        ApiResponse<List<ProductContract>> ApiProductGetProductsGetWithHttpInfo ();
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProductApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"> (optional)</param>
        /// <returns>Task of ProductContract</returns>
        System.Threading.Tasks.Task<ProductContract> ApiProductGetProductGetAsync (long? id = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"> (optional)</param>
        /// <returns>Task of ApiResponse (ProductContract)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProductContract>> ApiProductGetProductGetAsyncWithHttpInfo (long? id = null);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;ProductContract&gt;</returns>
        System.Threading.Tasks.Task<List<ProductContract>> ApiProductGetProductsGetAsync ();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;ProductContract&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<ProductContract>>> ApiProductGetProductsGetAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProductApi : IProductApiSync, IProductApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ProductApi : IProductApi
    {
        private bondora.homeAssignment.ApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ProductApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ProductApi(String basePath)
        {
            this.Configuration = bondora.homeAssignment.ApiClient.Client.Configuration.MergeConfigurations(
                bondora.homeAssignment.ApiClient.Client.GlobalConfiguration.Instance,
                new bondora.homeAssignment.ApiClient.Client.Configuration { BasePath = basePath }
            );
            this.Client = new bondora.homeAssignment.ApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new bondora.homeAssignment.ApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = bondora.homeAssignment.ApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ProductApi(bondora.homeAssignment.ApiClient.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = bondora.homeAssignment.ApiClient.Client.Configuration.MergeConfigurations(
                bondora.homeAssignment.ApiClient.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new bondora.homeAssignment.ApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new bondora.homeAssignment.ApiClient.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = bondora.homeAssignment.ApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PetApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ProductApi(bondora.homeAssignment.ApiClient.Client.ISynchronousClient client,bondora.homeAssignment.ApiClient.Client.IAsynchronousClient asyncClient, bondora.homeAssignment.ApiClient.Client.IReadableConfiguration configuration)
        {
            if(client == null) throw new ArgumentNullException("client");
            if(asyncClient == null) throw new ArgumentNullException("asyncClient");
            if(configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = bondora.homeAssignment.ApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public bondora.homeAssignment.ApiClient.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public bondora.homeAssignment.ApiClient.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public bondora.homeAssignment.ApiClient.Client.IReadableConfiguration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public bondora.homeAssignment.ApiClient.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"> (optional)</param>
        /// <returns>ProductContract</returns>
        public ProductContract ApiProductGetProductGet (long? id = null)
        {
             bondora.homeAssignment.ApiClient.Client.ApiResponse<ProductContract> localVarResponse = ApiProductGetProductGetWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"> (optional)</param>
        /// <returns>ApiResponse of ProductContract</returns>
        public bondora.homeAssignment.ApiClient.Client.ApiResponse< ProductContract > ApiProductGetProductGetWithHttpInfo (long? id = null)
        {
            bondora.homeAssignment.ApiClient.Client.RequestOptions requestOptions = new bondora.homeAssignment.ApiClient.Client.RequestOptions();

            String[] @contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] @accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = bondora.homeAssignment.ApiClient.Client.ClientUtils.SelectHeaderContentType(@contentTypes);
            if (localVarContentType != null) requestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = bondora.homeAssignment.ApiClient.Client.ClientUtils.SelectHeaderAccept(@accepts);
            if (localVarAccept != null) requestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (id != null)
            {
                foreach (var kvp in bondora.homeAssignment.ApiClient.Client.ClientUtils.ParameterToMultiMap("", "id", id))
                {
                    foreach (var value in kvp.Value)
                    {
                        requestOptions.QueryParameters.Add(kvp.Key, value);
                    }
                }
            }


            // make the HTTP request

            var response = this.Client.Get< ProductContract >("/api/Product/GetProduct", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("ApiProductGetProductGet", response);
                if (exception != null) throw exception;
            }

            return response;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"> (optional)</param>
        /// <returns>Task of ProductContract</returns>
        public async System.Threading.Tasks.Task<ProductContract> ApiProductGetProductGetAsync (long? id = null)
        {
             bondora.homeAssignment.ApiClient.Client.ApiResponse<ProductContract> localVarResponse = await ApiProductGetProductGetAsyncWithHttpInfo(id);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"> (optional)</param>
        /// <returns>Task of ApiResponse (ProductContract)</returns>
        public async System.Threading.Tasks.Task<bondora.homeAssignment.ApiClient.Client.ApiResponse<ProductContract>> ApiProductGetProductGetAsyncWithHttpInfo (long? id = null)
        {

            bondora.homeAssignment.ApiClient.Client.RequestOptions requestOptions = new bondora.homeAssignment.ApiClient.Client.RequestOptions();

            String[] @contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] @accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };
            
            foreach (var contentType in @contentTypes)
                requestOptions.HeaderParameters.Add("Content-Type", contentType);
            
            foreach (var accept in @accepts)
                requestOptions.HeaderParameters.Add("Accept", accept);
            
            if (id != null)
            {
                foreach (var kvp in bondora.homeAssignment.ApiClient.Client.ClientUtils.ParameterToMultiMap("", "id", id))
                {
                    foreach (var value in kvp.Value)
                    {
                        requestOptions.QueryParameters.Add(kvp.Key, value);
                    }
                }
            }


            // make the HTTP request

            var response = await this.AsynchronousClient.GetAsync<ProductContract>("/api/Product/GetProduct", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("ApiProductGetProductGet", response);
                if (exception != null) throw exception;
            }

            return response;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;ProductContract&gt;</returns>
        public List<ProductContract> ApiProductGetProductsGet ()
        {
             bondora.homeAssignment.ApiClient.Client.ApiResponse<List<ProductContract>> localVarResponse = ApiProductGetProductsGetWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;ProductContract&gt;</returns>
        public bondora.homeAssignment.ApiClient.Client.ApiResponse< List<ProductContract> > ApiProductGetProductsGetWithHttpInfo ()
        {
            bondora.homeAssignment.ApiClient.Client.RequestOptions requestOptions = new bondora.homeAssignment.ApiClient.Client.RequestOptions();

            String[] @contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] @accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = bondora.homeAssignment.ApiClient.Client.ClientUtils.SelectHeaderContentType(@contentTypes);
            if (localVarContentType != null) requestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = bondora.homeAssignment.ApiClient.Client.ClientUtils.SelectHeaderAccept(@accepts);
            if (localVarAccept != null) requestOptions.HeaderParameters.Add("Accept", localVarAccept);



            // make the HTTP request

            var response = this.Client.Get< List<ProductContract> >("/api/Product/GetProducts", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("ApiProductGetProductsGet", response);
                if (exception != null) throw exception;
            }

            return response;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;ProductContract&gt;</returns>
        public async System.Threading.Tasks.Task<List<ProductContract>> ApiProductGetProductsGetAsync ()
        {
             bondora.homeAssignment.ApiClient.Client.ApiResponse<List<ProductContract>> localVarResponse = await ApiProductGetProductsGetAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="bondora.homeAssignment.ApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;ProductContract&gt;)</returns>
        public async System.Threading.Tasks.Task<bondora.homeAssignment.ApiClient.Client.ApiResponse<List<ProductContract>>> ApiProductGetProductsGetAsyncWithHttpInfo ()
        {

            bondora.homeAssignment.ApiClient.Client.RequestOptions requestOptions = new bondora.homeAssignment.ApiClient.Client.RequestOptions();

            String[] @contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] @accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };
            
            foreach (var contentType in @contentTypes)
                requestOptions.HeaderParameters.Add("Content-Type", contentType);
            
            foreach (var accept in @accepts)
                requestOptions.HeaderParameters.Add("Accept", accept);
            


            // make the HTTP request

            var response = await this.AsynchronousClient.GetAsync<List<ProductContract>>("/api/Product/GetProducts", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("ApiProductGetProductsGet", response);
                if (exception != null) throw exception;
            }

            return response;
        }

    }
}
