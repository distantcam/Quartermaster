@echo off

set SOURCE="build"
set DESTINATION="..\Kerbal Space Program"

xcopy %SOURCE% %DESTINATION%\GameData\Quartermaster /I /Y
xcopy Quartermaster.version %DESTINATION%\GameData\Quartermaster /I /Y

call %DESTINATION%\ksp.exe