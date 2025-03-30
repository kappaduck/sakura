@echo off

set setupPath=.\src\Sakura.Setup\Sakura.Setup.csproj

dotnet run --project %setupPath% --configuration release -- sdl %*

exit /b %ERRORLEVEL%
