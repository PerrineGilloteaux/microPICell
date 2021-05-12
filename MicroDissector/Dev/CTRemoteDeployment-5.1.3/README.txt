CTREMOTE HowTo


ON YOUR DEVELOPMENT MACHINE:

Prerequisites:
 * CellTools should not be installed on this machine.

at first time use "MMI CellTools remote COM interface" must be registered in Windows:
1) start .\CTRemoteTest\CTRemoteTest.exe as Administrator
2) press "register CTRemote"
3) close CTRemoteTest.exe

start a demo CTRemote server:
1) start a new instance of .\CTRemoteTest.exe as normal user
2) press "Start Server as Demo"

start a CTRemote client:
1) start a new instance of .\CTRemoteTest.exe
2) use any of the buttons in the "Client section" to connect to the server



HOW TO CREATE YOUR OWN CLIENT

interface description of CTRemote:
1) an human readable interface description is given in .\CTRemote.ridl
2) a machine readable interface description is given in .\CTRemote.tlb


Visual Basic example:
1) Install Visual Studio 2017 Community Edition with VB
2) open .\Visual Studio 2017 - VB - CTRemoteClient\CTRemotClient.sln
3) adding CTRemote to a Visual Studio project can be done by selecting Project->AddReference->COM->MMI CellTools remote COM interface

CSharp example:
1) Install Visual Studio 2017 Community Edition with CS
2) open .\Visual Studio 2017 - CS - WindowsFormsApp1.sln
3) adding CTRemote to a Visual Studio project can be done by selecting Project->AddReference->COM->MMI CellTools remote COM interface

test your client:
1) start a demo CTRemote server:
	a)start a new instance of .\CTRemoteTest.exe as normal user
	b)press "Start Server as Demo"
2) start and test your client



ON CELLCUT MACHINE:
 
Prerequisites:
 * CellTools is installed on this machine
	** during the CellTools installation CTRemote is installed and registered
    ** do not register CTRemote manually	
 * The MMI Dongle is plugged in (granting the CTRemote license)
 * Do NOT use Remote desktop to connect to this PC
 
1) start CellTools as normal user
2) start a CTRemote client as normal user
