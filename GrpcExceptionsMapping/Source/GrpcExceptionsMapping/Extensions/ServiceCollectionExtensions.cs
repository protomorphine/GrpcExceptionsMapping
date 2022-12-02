namespace GrpcExceptionsMapping.Extensions;

using GrpcExceptionsMapping.Interceptors;
using GrpcExceptionsMapping.Options;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// IServiceCollection extensions
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Initialize map
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="options">Mapping options.</param>
    public static void AddGrpcExceptionMapping(this IServiceCollection services, Action<ExceptionMappingOptions> options)
    {
        ExceptionMappingOptions mappingOptions = new();
        options.Invoke(mappingOptions);

        services.AddSingleton(mappingOptions.GetMap());
    }

    /// <summary>
    /// Add <see cref="ExceptionHandlingInterceptor"/> in gRPC request pipeline
    /// </summary>
    /// <param name="services">Service collection.</param>
    public static void UseGrpcExceptionMapping(this IServiceCollection services) =>
        services.AddGrpc(opt =>
        {
            opt.Interceptors.Add<ExceptionHandlingInterceptor>();
        });
}
