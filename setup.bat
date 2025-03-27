@echo off

set setupPath=.\src\Sakura.Setup\Sakura.Setup.csproj

dotnet run --project %setupPath% -- sdl %*

exit /b %ERRORLEVEL%
