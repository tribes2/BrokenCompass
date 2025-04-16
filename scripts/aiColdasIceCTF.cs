//-----------------------------------------------
// AI functions for CTF

function CTFGame::onAIRespawn(%game, %client)
{
   //add the default task
	if (! %client.defaultTasksAdded)
	{
		%client.defaultTasksAdded = true;
	   %client.addTask(AIEngageTask);
           %client.addtask(AIDetectRemeqTask);//- Lagg... 3-20-2003
	   %client.addTask(AIPickupItemTask);
	   %client.addTask(AITauntCorpseTask);
		%client.addtask(AIEngageTurretTask);
		%client.addtask(AIDetectMineTask);
                %client.addtask(AIDetectVehiculeTask);//- Lagg... 3-20-2003
	}
}

function CTFGame::onAIFriendlyFire(%game, %clVictim, %clAttacker, %damageType, %implement)
{
   if (%clAttacker && %clAttacker.team == %clVictim.team && %clAttacker != %clVictim && !%clVictim.isAIControlled())
   {
      // The Bot is only a little sorry:
      if ( getRandom() > 0.3 )
		   AIMessageThread("ChatSorry", %clAttacker, %clVictim);
   }
}

