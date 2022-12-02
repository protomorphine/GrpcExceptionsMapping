namespace GrpcExceptionsMapping.Interceptors;

using Grpc.Core;
using Grpc.Core.Interceptors;
using GrpcExceptionsMapping.Map;

/// <summary>
/// Interceptor which handle exceptions.
/// </summary>
internal sealed class ExceptionHandlingInterceptor : Interceptor
{
    /// <summary>
    /// Map.
    /// </summary>
    private readonly ExceptionGrpcStatusMap map;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionHandlingInterceptor"/> class.
    /// </summary>
    /// <param name="map">Exception to gRPC status code map.</param>
    public ExceptionHandlingInterceptor(ExceptionGrpcStatusMap map) => this.map = map;

    /// <inheritdoc />
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context).ConfigureAwait(true);
        }
        catch (Exception e)
        {
            var exceptionType = e.GetType();

            var status = this.map.Map.FirstOrDefault(kv => kv.Key == exceptionType)
                .Value ?? StatusCode.Internal;

            throw new RpcException(new Status(status, e.Message));
        }
    }
}
