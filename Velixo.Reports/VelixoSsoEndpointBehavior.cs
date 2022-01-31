#nullable enable

using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

public class VelixoSsoEndpointBehavior : IVelixoSsoEndpointBehavior
{
    private readonly IVelixoSsoMessageInspector _messageInspector;

    public VelixoSsoEndpointBehavior(IVelixoSsoMessageInspector messageInspector)
    {
        _messageInspector = messageInspector;
    }

    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) => clientRuntime.ClientMessageInspectors.Add(_messageInspector);

    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
    }

    public void Validate(ServiceEndpoint endpoint)
    {
    }
}
