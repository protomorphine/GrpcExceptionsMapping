# Mapping Exceptions on gRPC Status Codes

[![GrpcExceptionsMapping NuGet Package](https://img.shields.io/nuget/v/Protomorphine.GrpcExceptionsMapping.svg)](https://www.nuget.org/packages/Protomorphine.GrpcExceptionsMapping/) [![GrpcExceptionsMapping NuGet Package Downloads](https://img.shields.io/nuget/dt/Protomorphine.GrpcExceptionsMapping)](https://www.nuget.org/packages/Protomorphine.GrpcExceptionsMapping/g)

Interceptor which allows to map exceptions on specified gRPC status code.

## Usage

```c#
builder.Services.AddGrpcExceptionMapping(options => {
    options.Map<ObjectNotFoundException>(StatusCode.NotFound);
});

builder.Service.UseGrpcExceptionMapping();
```
