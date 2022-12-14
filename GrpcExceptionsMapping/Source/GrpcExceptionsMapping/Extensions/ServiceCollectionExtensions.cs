namespace GrpcExceptionsMapping.Extensions;

using GrpcExceptionsMapping.Interceptors;
using GrpcExceptionsMapping.Map;
using GrpcExceptionsMapping.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// IServiceCollection extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Initialize map.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="options">Mapping options.</param>
    public static void AddGrpcExceptionMapping(
        this IServiceCollection services,
        Action<ExceptionMappingOptions> options)
    {
        ExceptionMappingOptions mappingOptions = new();
        options.Invoke(mappingOptions);
        services.TryAddSingleton(mappingOptions.GetMap());
    }

    /// <summary>
    /// Add <see cref="ExceptionHandlingInterceptor"/> in gRPC request pipeline.
    /// </summary>
    /// <param name="services">Service collection.</param>
    public static void UseGrpcExceptionMapping(this IServiceCollection services)
    {
        if (services.All(x => x.ServiceType != typeof(ExceptionGrpcStatusMap)))
        {
            throw new InvalidOperationException($"Call {nameof(AddGrpcExceptionMapping)} firstly!");
        }

        services.AddGrpc(opt => opt.Interceptors.Add<ExceptionHandlingInterceptor>());
    }
}
