@echo off

set SOURCE="build"
set DESTINATION="..\Kerbal Space Program"

xcopy %SOURCE% %DESTINATION%\GameData\Quartermaster /d /e /c /r /i /k /y

call %DESTINATION%\ksp.exe