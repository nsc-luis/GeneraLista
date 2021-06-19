@echo off

net use \\192.168.123.12 /delete
set dOrigen=\\192.168.123.12\ACT_ALV_PAQMEX

for /f "tokens=1-7 delims=|" %%i in (lista.txt) do (
	rem svr					=	%%i
	rem svrIP				=	%%j
	rem svrUser				=	%%k
	rem svrPass				=	%%l
	rem svrURLRaiz				=	%%m
	rem svrURLSubCarpeta			=	%%n
	rem archivo				=	%%o
	echo Moviendo %%m\%%n en sucursal %%i
	net use \\%%j /user:%%k %%l
	move \\%%j\%%m\%%n \\%%j\%%m\new_%%n
	move \\%%j\%%m\old_%%n \\%%j\%%m\%%n
	echo ==================================
)
pause