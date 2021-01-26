using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Dispatcher;
using Newtonsoft.Json;
using Test.Model;

namespace TestApi
{
    internal class UserAuthenticationInvoker : IOperationInvoker
    {
        /// <summary>
        ///     The original operation invoker.
        /// </summary>
        private readonly IOperationInvoker _originalInvoker;

        public UserAuthenticationInvoker(IOperationInvoker originalInvoker)
        {
            _originalInvoker = originalInvoker;
        }

        #region Implementation of IOperationInvoker {

        public object[] AllocateInputs()
        {
            return _originalInvoker.AllocateInputs();
        }

        private static bool ValidateToken()
        {
            return true;

            ////var request = HttpContext.Current.Request;

            ////if (string.IsNullOrWhiteSpace(request.Headers["SecurityToken"])) return false;

            ////var securityToken = request.Headers["SecurityToken"];

            ////var requestHeader = JsonConvert.DeserializeObject<RequestHeaderObject>(securityToken);

            ////return Convert.ToString(ConfigurationManager.AppSettings[Constant.ConfigKeys.SerialKey]) ==
            ////       Encryption.Decrypt(requestHeader.Token);
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {

            if (!ValidateToken())
            {
                throw new Exception(); //new TuvServiceAuthenticationException(Resource.AuthorizationFailed);
            }

            var invoked = _originalInvoker.Invoke(instance, inputs, out outputs);

            return invoked;
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            throw new InvalidOperationException("The operation cannot be invoked asynchronously.");
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            throw new InvalidOperationException("The operation cannot be invoked asynchronously.");
        }

        public bool IsSynchronous { get { return true; } }

        #endregion
    }
}