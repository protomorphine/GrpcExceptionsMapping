# Mapping Exceptions on gRPC Status Codes

[![GrpcExceptionsMapping NuGet Package](https://img.shields.io/nuget/v/GrpcExceptionsMapping.svg)](https://www.nuget.org/packages/GrpcExceptionsMapping/) [![GrpcExceptionsMapping NuGet Package Downloads](https://img.shields.io/nuget/dt/GrpcExceptionsMapping)](https://www.nuget.org/packages/GrpcExceptionsMapping)

Interceptor which allows to map exceptions on specified gRPC status code.

## Usage

```c#
builder.Services.AddGrpcExceptionMapping(options => {
    options.Map<ObjectNotFoundException>(StatusCode.NotFound);
});

builder.Service.UseGrpcExceptionMapping();
```
