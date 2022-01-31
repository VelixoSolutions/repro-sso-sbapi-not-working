using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Velixo.Reports.AcumaticaSoap;

public class SoapLoginService
{
    public async Task<ScreenSoap> LoginAsync(string connectionUri, string bearerToken)
    {
        BasicHttpBinding binding = new()
        {
            Name = "ScreenSoap",
            AllowCookies = true,
            MaxReceivedMessageSize = 2147483647,
            SendTimeout = TimeSpan.MaxValue, //Some clients have large writebacks, and this can be cancelled by the user anyway from the UI
            ReceiveTimeout = TimeSpan.MaxValue
        };

        EndpointAddress address = new(connectionUri + "/Soap/.asmx");

        if (address.Uri.Scheme == Uri.UriSchemeHttps)
        {
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
        }

        var screen = new ScreenSoapClient(binding, address);

        screen.Endpoint.EndpointBehaviors.Add(new VelixoSsoEndpointBehavior(new VelixoSsoMessageInspector(bearerToken)));

        await screen.SetLocaleNameAsync("en-US");

        return screen;
    }
}