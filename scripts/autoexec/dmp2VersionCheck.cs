// Tells the server what version of the DMP2 pack the client is using
$DMP2::Version = 0.3;

// Client Only
addMessageCallback('MsgDMP2Ver', DMP2Return);

function DMP2Return()
{
   commandToServer('ClientDMP2Version', $DMP2::Version);
}