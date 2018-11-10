# DuckSharp
This is a simple but yet powerful web API wrapper of the [DuckDuckGo Instant Answer API](https://duckduckgo.com/api).

## Getting Started

### Requirements
DuckSharp targets .NET Standard 1.1 - so your project **must**. See [Microsoft's guide on .NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support).

### Installation
DuckSharp can be installed from [NuGet](https://www.nuget.org/packages/TheMulti0.DuckSharp/). <br />
You can install it from Visual Studio's userinterface, or from the package manager console:
```ps1
PM> Install-Package TheMulti0.DuckSharp -Version 1.0.0
```
Alternatively, you can use the .NET Core CLI:
```bash
> dotnet add package TheMulti0.DuckSharp
```

### Usage
The simplest way to get an instant answer from DuckDuckGo using DuckSharp is the following:
```cs
await new DuckSharpClient().GetInstantAnswerAsync("Apple");
```
You can also get [!bang redirects](https://duckduckgo.com/bang):
```cs
await new DuckSharpClient().GetBangRedirectAsync("!youtube Kanye West - Fade");
```
For a full documentation, be sure to checkout [this project's wiki page!](https://github.com/TheMulti0/DuckSharp/wiki)

## Contributing
If any of you wants to contribute to this project, you can submit a pull request here, I promise that I'll review _any_ pull request that will be submitted. </br>
Please use my `.dotsettings` file and preserve Microsofts C# conventions and my coding style!
