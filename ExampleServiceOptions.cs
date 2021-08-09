using System;

namespace AzureFunctionWithSettings
{
    public class ExampleServiceOptions
    {
        public string ServiceApiKey { get; set; }
        public TimeSpan Timeout { get; set; }
    }
}
