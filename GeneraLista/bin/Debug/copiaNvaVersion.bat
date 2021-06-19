@echo off

net use \\192.168.123.12 /delete
set dOrigen=\\192.168.123.12\ACT_ALV_PAQMEX

for /f "tokens=1-7 delims=|" %%i in (lista.txt) do (

	rem echo %%i
	rem echo svrIP = %%j
	rem echo svrUser = %%k
	rem echo svrPass = %%l
	rem echo svrURLRaiz = %%m
	rem echo svrURLSubCarpeta = %%n
	rem echo ejecutable = %%o
	rem echo "%dOrigen%\%%n\%%o" "\\%%j\%%m\%%n\%%o"

	echo Copiando %%o en sucursal %%i
	net use \\%%j /user:%%k %%l
	md "\\%%j\ACT_ALV_PAQMEX\%%m"
	xcopy "%dOrigen%\%%n\%%o" "\\%%j\%%m\%%n\%%o" /y
	echo ==================================
	cls
)
