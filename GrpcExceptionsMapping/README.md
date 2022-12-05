# Mapping Exceptions on gRPC Status Codes

[![GrpcExceptionsMapping NuGet Package](https://img.shields.io/nuget/v/Protomorphine.GrpcExceptionsMapping.svg)](https://www.nuget.org/packages/Protomorphine.GrpcExceptionsMapping/) [![GrpcExceptionsMapping NuGet Package Downloads](https://img.shields.io/nuget/dt/Protomorphine.GrpcExceptionsMapping)](https://www.nuget.org/packages/Protomorphine.GrpcExceptionsMapping/g) [![.NET](https://github.com/protomorphine/GrpcExceptionsMapping/actions/workflows/dotnet.yml/badge.svg)](https://github.com/protomorphine/GrpcExceptionsMapping/actions/workflows/dotnet.yml)

Interceptor which allows to map exceptions on specified gRPC status code.

## Usage

- Add mapping:
```c#
builder.Services.AddGrpcExceptionMapping(options =>
{
    // add mappings ObjectNotFoundException into NotFound status code
    options.Map<ObjectNotFoundException>(StatusCode.NotFound);
    
    // origin exception will be part of RpcException
    options.EnableDebugExceptions();
});
```

- Add interceptor to request pipeline:

_NOTE! Call `AddGrpcExceptionMapping` before activating interceptor!_
```c#
builder.Service.UseGrpcExceptionMapping();
```
