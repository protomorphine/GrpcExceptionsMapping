namespace GrpcExceptionsMapping.Map;

using Grpc.Core;

/// <summary>
/// Exception to gRPC status code map.
/// </summary>
internal sealed class ExceptionGrpcStatusMap
{
    /// <summary>
    /// Gets dictionary with map.
    /// </summary>
    internal Dictionary<Type, StatusCode?> Map { get; } = new();

    /// <summary>
    /// Gets or sets a value indicating whether gets debug exceptions.
    /// </summary>
    internal bool EnableDebugException { get; set; }
}
