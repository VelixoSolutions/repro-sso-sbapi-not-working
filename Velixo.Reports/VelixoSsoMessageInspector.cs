#nullable enable

using System.ServiceModel;
using System.ServiceModel.Channels;

public class VelixoSsoMessageInspector : IVelixoSsoMessageInspector
{
    private const string _authorizationHeaderName = "Authorization";

    private readonly string _bearerToken;

    public VelixoSsoMessageInspector(string bearerToken)
    {
        _bearerToken = bearerToken;
    }

    public void AfterReceiveReply(ref Message reply, object correlationState)
    {
    }

    public object? BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        var authorizationHeader = $"Bearer {_bearerToken}";

        if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out var httpRequestMessageObject))
        {
            var httpRequestMessage = (HttpRequestMessageProperty)httpRequestMessageObject;

            if (string.IsNullOrWhiteSpace(httpRequestMessage.Headers[_authorizationHeaderName]))
            {
                httpRequestMessage.Headers[_authorizationHeaderName] = authorizationHeader;
            }
        }
        else
        {
            var httpRequestMessage = new HttpRequestMessageProperty();

            httpRequestMessage.Headers.Add(_authorizationHeaderName, authorizationHeader);

            request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
        }

        return null;
    }
}
