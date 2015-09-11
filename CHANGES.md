# Infinity.NET Changes

Infinity.NET provides access to Visual Studio Online and Team Foundation
Server REST APIs for .NET.

## 0.1.2

 * Add support for OAuth for Visual Studio Online
 * Authentication errors against Visual Studio Online now throw an
   authentication exception
 * Support `GetItem` and `GetItems` against the 1.0 API
 * Support git trees with submodules

## 0.1.1

 Use HttpClient and Json.NET instead of RestSharp in order to produce
 a PCL-compatible library.

## 0.1.0

 Introduction of Infinity.NET

 - Git Client
 - Project Client
 - Team Client
 - TeamRoom Client

