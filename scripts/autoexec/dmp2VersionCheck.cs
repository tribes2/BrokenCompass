// Tells the server what version of the DMP2 pack the client is using
$DMP2::Version = 0.6;

// Client Only
addMessageCallback('MsgDMP2Ver', DMP2Return);

function DMP2Return()
{
   commandToServer('ClientDMP2Version',$DMP2::Version);
}
 
// Server Only
function serverCmdClientDMP2Version(%client, %version)
{
	if(!%client.DMP2Version)
		%client.DMP2Version = %version;
}

package DMP2VersionCheck
{

function GameConnection::onConnect( %client, %name, %raceGender, %skin, %voice, %voicePitch )
{
	parent::onConnect( %client, %name, %raceGender, %skin, %voice, %voicePitch );
	
	messageClient(%client, 'MsgDMP2Ver');
}

};

// Prevent package from being activated if it is already
if (!isActivePackage(DMP2VersionCheck))
	activatePackage(DMP2VersionCheck);