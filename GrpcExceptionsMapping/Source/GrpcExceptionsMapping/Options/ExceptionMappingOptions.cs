namespace GrpcExceptionsMapping.Options;

using Grpc.Core;
using GrpcExceptionsMapping.Map;

/// <summary>
/// Options for mapping exceptions to gRPC status code.
/// </summary>
public class ExceptionMappingOptions
{
    /// <summary>
    /// Map.
    /// </summary>
    private readonly ExceptionGrpcStatusMap exceptionMap = new();

    /// <summary>
    /// Add mapping for exception to gRPC status code.
    /// </summary>
    /// <param name="statusCode">gRPC status code.</param>
    /// <typeparam name="TException">Type of Exceptions.</typeparam>
    public void Map<TException>(StatusCode statusCode)
    where TException : Exception
        => this.exceptionMap.Map.Add(typeof(TException), statusCode);

    /// <summary>
    /// Enable debug exceptions.
    /// </summary>
    public void EnableDebugExceptions() => this.exceptionMap.EnableDebugException = true;

    /// <summary>
    /// Gets exception - gRPC status code map.
    /// </summary>
    /// <returns>Map.</returns>
    internal ExceptionGrpcStatusMap GetMap() => this.exceptionMap;
}
