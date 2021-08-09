using System;

namespace AzureFunctionWithSettings
{
    public abstract class ExampleServiceOptions
    {
        public string ServiceApiKey { get; set; }
        public TimeSpan Timeout { get; set; }
    }
}
