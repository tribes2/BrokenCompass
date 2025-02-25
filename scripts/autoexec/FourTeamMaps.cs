// Set in each mapfile .mis
//$FourTeamMaps::AllowLaser = false;
$FourTeamMaps::Team1Color = "255 255 255 255";
$FourTeamMaps::Team2Color = "255 255 0 255";
$FourTeamMaps::Team3Color = "255 0 255 2555";
$FourTeamMaps::Team4Color = "0 0 255 255";
$FourTeamMaps::Team5Color = "0 255 255 255";

//exec("scripts/autoexec/fourteammaps.cs");

package FourTeamMapsPackage
{
	function ArenaGame::missionLoadDone( %game )
	{
		// DefaultGame sets up the teams for us
		// Also calls initGameVars (below)
		DefaultGame::missionLoadDone( %game );


		// Set team scores to zero
		// Cannot be in initGameVars because teams haven't been setup there
		for( %i = 1; %i < (%game.numTeams + 1); %i++ )
			$teamScore[%i] = 0;

		// Schedule "teams randomized" message
		if ( $Arena::Pref::ShuffleTeams )
			%game.schedule( 5000, "messageTeamsRandomized" );

		//Creates individual Colors for each team

		for(%i = 0; %i < 32; %i++)
		{
			%team = (1 << %i);
			%j = 0;
			%jteam = (1 << %j);

			if(%i!=0){
				%jteam = (1 << %j);
				setSensorGroupColor(%i,%jteam, "255 255 255 255");
				%j++;
			}
			if(%i!=1){
				%jteam = (1 << %j);
				setSensorGroupColor(%i,%jteam, $FourTeamMaps::Team1Color);
				%j++;
			}
			if(%i!=2){
				%jteam = (1 << %j);
				setSensorGroupColor(%i,%jteam, $FourTeamMaps::Team2Color);
				%j++;
			}
			if(%i!=3){
				%jteam = (1 << %j);
				setSensorGroupColor(%i,%jteam, $FourTeamMaps::Team3Color);
				%j++;
			}
			if(%i!=4){
				%jteam = (1 << %j);
				setSensorGroupColor(%i,%jteam, $FourTeamMaps::Team4Color);
				%j++;
			}
			if(%i!=5){
				%jteam = (1 << %j);
				setSensorGroupColor(%i,%jteam, $FourTeamMaps::Team5Color);
				%j++;
			}
			setSensorGroupColor(%i,%team, "0 255 0 255");
		}

		//First Off-- Change some standard Death messages
		$DeathMessage[$DamageType::SatchelCharge, 0] = '%1 learns the hard way.';  //satchel charge only
		$DeathMessage[$DamageType::SatchelCharge, 1] = '%1 should have read the map description.';
		$DeathMessage[$DamageType::SatchelCharge, 2] = '%1 tries out the air.';
		$DeathMessage[$DamageType::SatchelCharge, 3] = '%1 tries out his l33t sniping skills.';
		$DeathMessage[$DamageType::SatchelCharge, 4] = '%1 goes up in flames.';

		$DeathMessageLavaCount = 4;
		$DeathMessageLava[0] = '\c0%1\'s last thought before falling into the toxic water : \'Oops\'.';
		$DeathMessageLava[1] = '\c0%1 forgot to put on scuba gear.';
		$DeathMessageLava[2] = '\c0%1 tries to go fishing.';
		$DeathMessageLava[3] = '\c0%1 tried to find a shortcut.';
	}

	function serverCmdBootToTheRear(%client, %who)
	{
		changePlayersTeam(%who, 3);
	}

	function serverCmdExplodePlayer(%client, %who)
	{
		changePlayersTeam(%who, 4);
	}

	function DefaultGame::sendGamePlayerPopupMenu( %game, %client, %targetClient, %key )
	{
	if( !%targetClient.matchStartReady )
		return;

	%isAdmin = ( %client.isAdmin || %client.isSuperAdmin );
	%isTargetSelf = ( %client == %targetClient );
	%isTargetAdmin = ( %targetClient.isAdmin || %targetClient.isSuperAdmin );
	%isTargetBot = %targetClient.isAIControlled();
	%isTargetObserver = ( %targetClient.team == 0 );
	%outrankTarget = false;

	if ( %client.isSuperAdmin ) // z0dd - ZOD, 7/11/03. Super admins should outrank even themseleves.
		%outrankTarget = 1; //!%targetClient.isSuperAdmin;
	else if ( %client.isAdmin )
		%outrankTarget = !%targetClient.isAdmin;

	if( %client.isSuperAdmin && %targetClient.guid != 0 ) // z0dd - ZOD, 9/29/02. Removed T2 demo code from here
	{
		messageClient( %client, 'MsgPlayerPopupItem', "", %key, "addAdmin", "", 'Add to Server Admin List', 10);
		messageClient( %client, 'MsgPlayerPopupItem', "", %key, "addSuperAdmin", "", 'Add to Server SuperAdmin List', 11);
	}

	//mute options
	if ( !%isTargetSelf )
	{
		if ( %client.muted[%targetClient] )
			messageClient( %client, 'MsgPlayerPopupItem', "", %key, "MutePlayer", "", 'Unmute Text Chat', 1);
		else
			messageClient( %client, 'MsgPlayerPopupItem', "", %key, "MutePlayer", "", 'Mute Text Chat', 1);

		if ( !%isTargetBot && %client.canListenTo( %targetClient ) )
		{
			if ( %client.getListenState( %targetClient ) )
				messageClient( %client, 'MsgPlayerPopupItem', "", %key, "ListenPlayer", "", 'Disable Voice Com', 9 );
			else
				messageClient( %client, 'MsgPlayerPopupItem', "", %key, "ListenPlayer", "", 'Enable Voice Com', 9 );
		}
		// ------------------------------------------
		// z0dd - ZOD 4/4/02. Observe a specific player
		if (%client.team == 0 && !%isTargetObserver)
			messageClient(%client, 'MsgPlayerPopupItem', "", %key, "ObservePlayer", "", 'Observe Player', 12);
	}
	if( !%client.canVote && !%isAdmin )
		return;

	// regular vote options on players
	if ( %game.scheduleVote $= "" && !%isAdmin && !%isTargetAdmin )
	{
		if ( $Host::allowAdminPlayerVotes && !%isTargetBot ) // z0dd - ZOD, 9/29/02. Removed T2 demo code from here
			messageClient( %client, 'MsgPlayerPopupItem', "", %key, "AdminPlayer", "", 'Vote to Make Admin', 2 );

		if ( !%isTargetSelf )
		{
			messageClient( %client, 'MsgPlayerPopupItem', "", %key, "KickPlayer", "", 'Vote to Kick', 3 );
		}
	}
	// Admin only options on players:
	else if ( %isAdmin ) // z0dd - ZOD, 9/29/02. Removed T2 demo code from here
	{
		if ( !%isTargetBot && !%isTargetAdmin )
			messageClient( %client, 'MsgPlayerPopupItem', "", %key, "AdminPlayer", "", 'Make Admin', 2 );

		if ( !%isTargetSelf && %outrankTarget )
		{
			messageClient( %client, 'MsgPlayerPopupItem', "", %key, "KickPlayer", "", 'Kick', 3 );

			if ( !%isTargetBot )
			{
				// ------------------------------------------------------------------------------------------------------
				// z0dd - ZOD - Founder 7/13/03. Bunch of new admin features
				messageClient(%client, 'MsgPlayerPopupItem', "", %key, "Warn", "", 'Warn player', 13);
				if(%isTargetAdmin)
				messageClient( %client, 'MsgPlayerPopupItem', "", %key, "StripAdmin", "", 'Strip admin', 14 );

				messageClient( %client, 'MsgPlayerPopupItem', "", %key, "SendMessage", "", 'Send Private Message', 15 );
				messageClient( %client, 'MsgPlayerPopupItem', "", %key, "PrintClientInfo", "", 'Client Info', 16 ); // z0dd - ZOD - MeBad, 7/13/03. Send client information.

				if( %client.isSuperAdmin )
				{
				messageClient( %client, 'MsgPlayerPopupItem', "", %key, "BanPlayer", "", 'Ban', 4 );

				if ( %targetClient.isGagged )
					messageClient( %client, 'MsgPlayerPopupItem', "", %key, "UnGagPlayer", "", 'UnGag Player', 17);
				else
					messageClient( %client, 'MsgPlayerPopupItem', "", %key, "GagPlayer", "", 'Gag Player', 17);

				if ( %targetClient.isFroze )
					messageClient( %client, 'MsgPlayerPopupItem', "", %key, "ThawPlayer", "", 'Thaw Player', 18);
				else
					messageClient( %client, 'MsgPlayerPopupItem', "", %key, "FreezePlayer", "", 'Freeze Player', 18);
				}
				if ( !%isTargetObserver )
				{
				messageClient( %client, 'MsgPlayerPopupItem', "", %key, "ToObserver", "", 'Force observer', 5 );
				}
			}
		}
		if ( %isTargetSelf || %outrankTarget )
		{
			if(%isTargetAdmin)
				messageClient( %client, 'MsgPlayerPopupItem', "", %key, "StripAdmin", "", 'Strip admin', 14 );

			if ( %game.numTeams > 1 )
			{
				if ( %isTargetObserver )
				{
					%action = %isTargetSelf ? "Join " : "Change to ";
					%str1 = %action @ getTaggedString( %game.getTeamName(1) );
					%str2 = %action @ getTaggedString( %game.getTeamName(2) );
					%str3 = %action @ getTaggedString( %game.getTeamName(3) );
					%str4 = %action @ getTaggedString( %game.getTeamName(4) );

					messageClient( %client, 'MsgPlayerPopupItem', "", %key, "ChangeTeam", "", %str1, 6 );
					messageClient( %client, 'MsgPlayerPopupItem', "", %key, "ChangeTeam", "", %str2, 7 );
					messageClient( %client, 'MsgPlayerPopupItem', "", %key, "BootPlayer", "", %str3, 19);
					messageClient( %client, 'MsgPlayerPopupItem', "", %key, "ExplodePlayer", "", %str4, 20);
				}
				else
				{
					for(%i = 1; %i < 5; %i++)
					{
						%changeTo = %i;
						//echo("%i:" @ %i SPC "ClientTeam:" SPC %client.team SPC "ChangeTo:" SPC %changeTo);
						if(%changeTo !$= %client.team)
						{
							%str = "Switch to " @ getTaggedString( %game.getTeamName(%changeTo) );
							switch$(%changeTo)
							{
								case 1:
									%caseId = 6;
								case 2:
									%caseId = 7;
								case 3:
									%caseId = 19;
								case 4:
									%caseId = 20;
							}
							messageClient( %client, 'MsgPlayerPopupItem', "", %key, "ChangeTeam", "", %str, %caseId );
						}
					}

					// z0dd - ZOD, 7/11/03. Allow Super admins to force themselves to obs.
					messageClient( %client, 'MsgPlayerPopupItem', "", %key, "ToObserver", "", 'Force observer', 5 );
				}
			}
			else if ( %isTargetObserver )
			{
				%str = %isTargetSelf ? 'Join the Game' : 'Add to Game';
				messageClient( %client, 'MsgPlayerPopupItem', "", %key, "JoinGame", "", %str, 8 );
			}
		}
	}
	}

	function ArenaGame::gameOver( %game )
	{
		// Cancel new round schedules
		cancel( %game.newRoundSch );
		%game.cancelRoundCountdown();

		// Cancel end round schedules
		cancel( %game.timeCheck );
		%game.cancelRoundEndCountdown();

		// Record the high scores
		if ( $Arena::Pref::TrackHighScores )
			%game.recordHighScores();

		// Default version clears it's game vars and takes care of the debriefing
		DefaultGame::gameOver( %game );

		// Determine the name of the winning team
		%winner = "";
		%topScore = "";
		%bTied = false;
		for ( %team = 1; %team <= %game.numTeams; %team++ )
		{
			if ( %topScore $= "" || $TeamScore[%team] > %topScore )
			{
			%topScore = $TeamScore[%team];
			%winner = %game.getTeamName(%team);
			%bTied = false;
			}
			else if ( $TeamScore[%team] == %topScore )
			{
			// Multiple teams tied for lead..
			%winner = "";
			%bTied = true;
			}
		}

		// Play the announcer voice
		// Copied from CTFGame

		if ( !%bTied )
		{
			switch$(%winner)
			{
				case 'Storm':
					messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.stowins.wav" );
				case 'Inferno':
					messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.infwins.wav" );
				case 'Starwolf':
					messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.swwin.wav" );
				case 'Blood Eagle':
					messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.bewin.wav" );
				case 'Diamond Sword':
					messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.dswin.wav" );
				case 'Phoenix':
					messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.pxwin.wav" );
				default:
					messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.gameover.wav" );
			}
		}
		else
			messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.gameover.wav" );

		// Clear everyone's objectiveHuds
		messageAll( 'MsgClearObjHud', "" );

		// Reset the scores of all the clients
		for( %i = 0; %i < ClientGroup.getCount(); %i++ )
		{
			%client = ClientGroup.getObject( %i );
			%game.resetScore( %client );
		}

		//Re-enable Sniping, disable multicolors
		$FourTeamMaps::AllowLaser = true;

		//Restore death Messages
		$DeathMessage[$DamageType::SatchelCharge, 0] = '\c0%4 buys %1 a ticket to the moon.';  //satchel charge only
		$DeathMessage[$DamageType::SatchelCharge, 1] = '\c0%4 blows %1 into low orbit.';
		$DeathMessage[$DamageType::SatchelCharge, 2] = '\c0%4 makes %1 a hugely explosive offer.';
		$DeathMessage[$DamageType::SatchelCharge, 3] = '\c0%4 turns %1 into a cloud of satchel-vaporized armor.';
		$DeathMessage[$DamageType::SatchelCharge, 4] = '\c0%4\'s satchel charge leaves %1 nothin\' but smokin\' boots.';

		$DeathMessageLavaCount = 4;
		$DeathMessageLava[0] = '\c0%1\'s last thought before falling into the lava : \'Oops\'.';
		$DeathMessageLava[1] = '\c0%1 makes the supreme sacrifice to the lava gods.';
		$DeathMessageLava[2] = '\c0%1 looks surprised by the lava - but only briefly.';
		$DeathMessageLava[3] = '\c0%1 wimps out by jumping into the lava and trying to make it look like an accident.';

		if(isActivePackage(FourTeamMapsPackage))
			deactivatePackage(FourTeamMapsPackage);
	}

	function ShapeBase::use(%this, %data)
	{
		if(%data $= "SniperRifle" && !$FourTeamMaps::AllowLaser)
		{
			//No sniper rifles, blow him up for being naughty
			%dmgRadius = 1;
				%dmgMod = 1.0;
				%expImpulse = 2500;
				%dmgType = $DamageType::SatchelCharge;
			RadiusExplosion(%this.client.player, %this.client.player.getPosition(), %dmgRadius, %dmgMod, %expImpulse, %this.client.player.sourceObject, %dmgType);
			//Lets be nice, warn them for the next time
			centerprint( %this.client, "<font:Univers:22><color:dcdcdc>Sniping is <font:Sui Generis:20><color:33CCCC>Disabled<font:Univers:22><color:dcdcdc> on this map.\n<font:Sui Generis:20><color:33CCCC>;-)", 5, 3 );
		}
		if(%data $= Grenade)
		{
			// figure out which grenade type you're using
			for(%x = 0; $InvGrenade[%x] !$= ""; %x++)
			{
				if(%this.inv[$NameToInv[$InvGrenade[%x]]] > 0)
				{
					%data = $NameToInv[$InvGrenade[%x]];
					break;
				}
			}
		}
		else if(%data $= "Backpack")
		{
			%pack = %this.getMountedImage($BackpackSlot);
			// if you don't have a pack but have placed a satchel charge, detonate it
			if(!%pack && (%this.thrownChargeId > 0) && %this.thrownChargeId.armed )
			{
				%this.playAudio( 0, SatchelChargeExplosionSound );
				schedule( 800, %this, "detonateSatchelCharge", %this );
				return true;
			}
			return false;
		}
		else if(%data $= Beacon)
		{
			%data.onUse(%this);
			if (%this.inv[%data.getName()] > 0)
			{
				return true;
			}
		}

		// default case
		if (%this.inv[%data.getName()] > 0)
		{
			%data.onUse(%this);
			return true;
		}

		return false;
	}
};