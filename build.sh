#!/bin/bash
dotnet restore
dotnet build ./src/Tusky/Tusky.csproj -f netstandard2.0
dotnet build ./src/Tusky.Json/Tusky.Json.csproj -f netstandard2.0
dotnet test ./test/Tusky.Tests/Tusky.Tests.csproj -f netcoreapp2.1