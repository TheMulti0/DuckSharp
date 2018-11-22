# DuckSharp
[![https://www.nuget.org/packages/TheMulti0.DuckSharp/](https://img.shields.io/nuget/v/TheMulti0.DuckSharp.svg)](https://www.nuget.org/packages/TheMulti0.DuckSharp/) 
[![NuGet Downloads](https://img.shields.io/nuget/dt/TheMulti0.DuckSharp.svg)](https://www.nuget.org/stats/packages/TheMulti0.DuckSharp?groupby=Version)
[![Build Status](https://travis-ci.org/TheMulti0/DuckSharp.svg?branch=master)](https://travis-ci.org/TheMulti0/DuckSharp) 
[![Coverage Status](https://coveralls.io/repos/github/TheMulti0/DuckSharp/badge.svg?branch=)](https://coveralls.io/github/TheMulti0/DuckSharp?branch=)


This is a simple but yet powerful web API wrapper of the [DuckDuckGo Instant Answer API](https://duckduckgo.com/api).

## Getting Started

### Requirements
DuckSharp targets .NET Standard 1.1 - so your project **must** be compatible with it. See [Microsoft's guide on .NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support).

### Installation
DuckSharp can be installed from [NuGet](https://www.nuget.org/packages/TheMulti0.DuckSharp/). <br />
You can install it from Visual Studio's userinterface, or from the package manager console:
```ps1
PM> Install-Package TheMulti0.DuckSharp
```
Alternatively, you can use the .NET Core CLI:
```bash
> dotnet add package TheMulti0.DuckSharp
```

### Basic Usage
The simplest way to get an instant answer from DuckDuckGo using DuckSharp is the following (the following examples do not implement the `IDisposable` interface of the client, please wrap the client with a `using` statement when using it):
```cs
await new DuckSharpClient().GetInstantAnswerAsync("Apple");
```
You can also get [!bang redirect urls](https://duckduckgo.com/bang):
```cs
await new DuckSharpClient().GetBangRedirectAsync("!youtube Kanye West - Fade");
```
For the full documentation, be sure to checkout [this project's wiki page!](https://github.com/TheMulti0/DuckSharp/wiki)

## License
[This project is licensed under the MIT license](https://github.com/TheMulti0/DuckSharp/blob/master/LICENSE)

## Contributing
If any of you wants to contribute to this project, you can submit a pull request here, I promise that I'll review _any_ pull request that will be submitted. </br>
Please use my `.dotsettings` file and preserve Microsofts C# conventions and my coding style!
