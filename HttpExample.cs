using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzureFunctionWithSettings
{
    public class HttpExample
    {
        private readonly IOptions<ExampleServiceOptions> _config;

        public HttpExample(IOptions<ExampleServiceOptions> config)
        {
            _config = config;
        }

        [Function("HttpExample")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("HttpExample");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");


            response.WriteString("Welcome to Azure Functions! \n");
            response.WriteString($"The ServiceApiKey setting is: {_config.Value.ServiceApiKey} \n");
            response.WriteString($"The Timeout setting is is: {_config.Value.Timeout} \n");

            return response;
        }
    }
}
