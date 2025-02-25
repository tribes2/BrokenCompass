//All tasks for deathmatch, hunters, and tasks that coincide with the current objective task live here...

//Weights for tasks that override the objective task: must be between 4300 and 4700

$AIWeightDetectRemeq				= 3600;
$AIWeightDetectVehicule				= 3500;




//------------------------------------------------------------------------------------------------------------
//modified pickupitem task to include repairpack as a health item and fixed some other bugs - Lagg... 4-3-2003
//------------------------------------------------------------------------------------------------------------
//AIPickupItemTask is responsible for anything to do with picking up an item

function AIPickupItemTask::init(%task, %client)
{
}

function AIPickupItemTask::assume(%task, %client)
{
	%task.setWeightFreq(10);
	%task.setMonitorFreq(10);

	%task.pickupItem = -1;
        %client.pickupItem = -1;
}

function AIPickupItemTask::retire(%task, %client)
{
        %task.pickupItem = -1;
        %client.pickupItem = -1;
}

function AIPickupItemTask::weight(%task, %client)
{
	//if we're already picking up an item, make sure it's still valid, then keep the weight the same...
	if (%task.pickupItem > 0 && %client.pickupItem > 0)
	{
		if (isObject(%task.pickupItem) && !%task.pickupItem.isHidden())
			return;
		else
                {
			%task.pickupItem = -1;
                        %client.pickupItem = -1;
                }
	}

	//otherwise, search for objects
        //first, see if we can pick up health
	%player = %client.player;
	if (!isObject(%player))
		return;

	%damage = %player.getDamagePercent();
	%healthRad = %damage * 100;
	%closestHealth = -1;
	%closestHealthDist = %healthRad;
	%closestHealthLOS = false;
	%closestItem = -1;
	%closestItemDist = 32767;
	%closestItemLOS = false;

	//loop through the item list, looking for things to pick up
	%itemCount = $AIItemSet.getCount();
	for (%i = 0; %i < %itemCount; %i++)
	{
		%item = $AIItemSet.getObject(%i);
		if (!%item.isHidden())
		{
                    %dist = %client.getPathDistance(%item.getWorldBoxCenter());
		    if (((%item.getDataBlock().getName() $= "RepairPack" && %player.getInventory("RepairPack") <= 0) ||
                           (%item.isCorpse && %item.getInventory("RepairKit") > 0) ||
                           %item.getDataBlock().getName() $= "RepairPatch" ||
                           %item.getDataBlock().getName() $= "RepairKit") &&
                           %player.getInventory("RepairKit") <= 0 && %damage > 0.3)
 		    {
		        if (%dist > 0 && %dist < %closestHealthDist)
		    	{
			    %closestHealth = %item;
			    %closestHealthDist = %dist;

			    //check for LOS
			    %mask = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType;
			    %closestHealthLOS = !containerRayCast(%client.player.getWorldBoxCenter(), %item.getWorldBoxCenter(), %mask, 0);
			}
		    }
		    else
		    {
		        //only pick up stuff within 35m
			if (%dist < 45)
			{
			    if (AICouldUseItem(%client, %item))
			    {
		                if (%dist < %closestItemDist)
				{
				    %closestItem = %item;
				    %closestItemDist = %dist;

				    //check for LOS
				    %mask = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType;
				    %closestItemLOS = !containerRayCast(%client.player.getWorldBoxCenter(), %item.getWorldBoxCenter(), %mask, 0);
				}
			    }
			}
		    }
		}
	}

	//now set the weight
	if (%closestHealth > 0)
	{
	    //only choose an item if it's at least 25 m closer than health...
	    //and we're not engageing someone or not that badly in need
	    %currentTarget = %client.getEngageTarget();
	    if (%closestItem > 0 && %closetItemDist < %closestHealthDist - 25 && (%damage < 0.6 || %currentTarget <= 0) && %closestItemLOS)
            {
	        %task.pickupItem = %closestItem;
                %client.pickupItem = %closestItem;
                if (AIEngageWeaponRating(%client) < 20)                    
	            %task.setWeight($AIWeightNeedItemBadly);
		else if (%closestItemDist < 10 && %closestItemLOS)
		    %task.setWeight($AIWeightNeedItem);
                else if (%closestItemLOS)
                    %task.setWeight($AIWeightFoundItem);
                else
		    %task.setWeight(0);
	    }
	    else
	    {
		if (%damage > 0.8)
		{
		    %task.pickupItem = %closestHealth;
                    %client.pickupItem = %closestHealth;
		    %task.setWeight($AIWeightNeedItemBadly);
		}
		else if (%closestHealthLOS)
		{
		    %task.pickupItem = %closestHealth;
                    %client.pickupItem = %closestHealth;
		    %task.setWeight($AIWeightNeedItem);
		}
		else
		    %task.setWeight(0);
		}
	}
	else if (%closestItem > 0)
	{
		%task.pickupItem = %closestItem;
                if (AIEngageWeaponRating(%client) < 20)
		    %task.setWeight($AIWeightNeedItemBadly);
		else if (%closestItemDist < 10 && %closestItemLOS)
		    %task.setWeight($AIWeightNeedItem);
		else if (%closestItemLOS)
		    %task.setWeight($AIWeightFoundItem);
		else
		    %task.setWeight(0);
	}
	else
		%task.setWeight(0);
}

function AIPickupItemTask::monitor(%task, %client)
{
	//move to the pickup location
	if (isObject(%task.pickupItem))
        {
           if (%task.pickupItem.getDataBlock().getName() $= "RepairPack")
           {
               %distToRep = %client.getPathDistance(%task.pickupItem.position);
	       if (%distToRep < 10 && %client.player.getMountedImage($BackpackSlot) > 0 && %client.player.getInventory("RepairPack") <= 0)
               {
	           %client.player.throwPack();
               }
           }
	   %client.stepMove(%task.pickupItem.getWorldBoxCenter(), 0.25);
        }

	//this call works in conjunction with AIEngageTask
	%client.setEngageTarget(%client.shouldEngage);
}

//-------------------------------------------------------------------------------------------------
//modified slightly -                                                            Lagg... - 4-4-2003
//AITauntCorpseTask is should happen only after an enemy is freshly killed

function AITauntCorpseTask::init(%task, %client)
{
}

function AITauntCorpseTask::assume(%task, %client)
{
	%task.setWeightFreq(11);
	%task.setMonitorFreq(11);
}

function AITauntCorpseTask::retire(%task, %client)
{
}

function AITauntCorpseTask::weight(%task, %client)
{
   %task.corpse = %client.getVictimCorpse();
   if (%task.corpse > 0 && getSimTime() - %client.getVictimTime() < 7500)
	{
		//see if we're already taunting, and if it's time to stop
		if ((%task.tauntTime > %client.getVictimTime()) && (getSimTime() - %task.tauntTime > 1000))
			%task.corpse = -1;
		else
		{
			//if the corpse is within 25m, taunt
         %distToCorpse = %client.getPathDistance(%task.corpse.getWorldBoxCenter());
			if (%dist < 0 || %distToCorpse > 25)
				%task.corpse = -1;
		}
	}
	else
		%task.corpse = -1;

	//set the weight
	if (%task.corpse > 0)
	{
		//don't taunt someone if there's an enemy right near by...
		%result = AIFindClosestEnemy(%client, 40, 15000);
      %closestEnemy = getWord(%result, 0);
      %closestdist = getWord(%result, 1);
      if (%closestEnemy > 0)
			%task.setWeight(0);
		else
			%task.setWeight($AIWeightTauntVictim);
	}
	else
		%task.setWeight(0);
}

$AITauntChat[0] = "gbl.aww";
$AITauntChat[1] = "gbl.brag";
$AITauntChat[2] = "gbl.obnoxious";
$AITauntChat[3] = "gbl.sarcasm";
$AITauntChat[4] = "gbl.when";
function AITauntCorpseTask::monitor(%task, %client)
{
	//make sure we still have a corpse, and are not fighting anyone
	if (%client.getEngageTarget() <= 0 && %task.corpse > 0 && isObject(%task.corpse))
	{
      %clientPos = %client.player.getWorldBoxCenter();
		%corpsePos = %task.corpse.getWorldBoxCenter();
		%distToCorpse = VectorDist(%clientPos, %corpsePos);
		if (%distToCorpse < 2.0)
		{
			//start the taunt!
			if (%task.tauntTime < %client.getVictimTime())
			{
				%task.tauntTime = getSimTime();
				%client.stop();

				if (getRandom() > 0.2)
				{
					//pick the sound and taunt cels
					%sound = $AITauntChat[mFloor(getRandom() * 3.99)];
					%minCel = 2;
					%maxCel = 8;
				   schedule(250, %client, "AIPlayAnimSound", %client, %corpsePos, %sound, %minCel, %maxCel, 0);
				}
				//say 'bye'  :)
				else
				   schedule(250, %client, "AIPlayAnimSound", %client, %corpsePos, "gbl.bye", 2, 2, 0);
			}
		}
		else
			%client.stepMove(%task.corpse.getWorldBoxCenter(), 1.75);
	}
}

//------------------------------------------------------------------------------------
//New AIDefault Task                       ------                    Lagg... 3-20-2003
//AIDetectRemeqTask is responsible for finding and killing enemy remote inventories...
//------------------------------------------------------------------------------------

function AIDetectRemeqTask::init(%task, %client)
{

}
function AIDetectRemeqTask::assume(%task, %client)
{
	%task.setWeightFreq(7);
	%task.setMonitorFreq(7);
}

function AIDetectRemeqTask::retire(%task, %client)
{
	%task.engageRemeq = -1;
        %task.attackInitted = false;
	%client.setTargetObject(-1);
        %client.engageRemeq = -1;
}

function AIDetectRemeqTask::weight(%task, %client)
{
        //see if we're already attacking a remote inventory
        if (%task.engageRemeq > 0 && isObject(%task.engageRemeq) && %client.engageRemeq > 0)
        {
	   %task.setWeight($AIWeightDetectRemeq);
           return;
	}
        //see if we are still alive
        else if (!AIClientIsAlive(%client))
        {
           %task.engageRemeq = -1;
           %client.engageRemeq = -1;
	   //%client.setEngagetarget(-1);
        }
	else
	{
           //lets find some remote equipment (inventories)...
           %task.engageRemeq = -1;
	   %closestRemeq = -1;
	   %closestDist = 100;	//initialize so only remote invetoties within 100 m will be detected
           %depCount = 0;
           %depGroup = nameToID("MissionCleanup/Deployables");
           if (isObject(%depGroup))
           {	      
              %depCount = %depGroup.getCount();
	      for (%i = 0; %i < %depCount; %i++)
	      {
	         %obj = %depGroup.getObject(%i);
	         if (%obj.getDataBlock().getName() $= "DeployedStationInventory" && %obj.team != %client.team && %obj.isEnabled())
                 {
                    %remeqPos = %obj.getWorldBoxCenter();
		    %clPos = %client.player.getWorldBoxCenter();
                    %remeqDist = VectorDist(%remeqPos, %clPos);
		    if (%remeqDist < %closestDist)
                    {
                       //check for LOS
		       %mask = $TypeMasks::TerrainObjectType |
                              $TypeMasks::InteriorObjectType | $TypeMasks::StaticTSObjectType;
		       %remeqLOS = !containerRayCast(%client.player.getWorldBoxCenter(), %obj.getWorldBoxCenter(), %mask, 0);
                       if (%remeqLOS)
                       {
                          %task.engageRemeq = %obj;
                          %client.engageRemeq = %obj;
                       }
                       else
                       {
                          %task.engageRemeq = -1;
                          %client.engageRemeq = -1;
                          %task.setWeight(0);
                       }
                    }
                 }
              }              
           }                      
        }
}

function AIDetectRemeqTask::monitor(%task, %client)
{
        if (%task.engageRemeq > 0 && isObject(%task.engageRemeq) && AIClientIsAlive(%client) && %client.engageRemeq > 0)
	{
		//set the AI to fire at the remote inventory
                //also made adjustments to Mortar function in aiinventory.cs
		%client.setTargetObject(%task.engageRemeq, 300, "Mortar");

		//control the movement - shoot first ask questions later
		if (!%task.attackInitted)
		{
			%task.attackInitted = true;
                        %client.setEngageTarget(-1);
                        %client.stepMove(%task.engageRemeq.getWorldBoxCenter(), 8.0);
		}  
	}
        //else we are done
        else
        {
            %task.engageRemeq = -1;
            %client.engageRemeq = -1;
	    %task.attackInitted = false;
            %client.setTargetObject(-1);
            %task.setWeight(0);
        }              
}

//------------------------------------------------------------------------------------
//New AIDefault Task                       ------                    Lagg... 3-20-2003
//AIDetectVehiculeTask is for detecting / destroying enemy vehicles manned or unmanned
//------------------------------------------------------------------------------------

function AIDetectVehiculeTask::init(%task, %client)
{

}

function AIDetectVehiculeTask::assume(%task, %client)
{
	    %task.setWeightFreq(15);
	    %task.setMonitorFreq(7);
}

function AIDetectVehiculeTask::retire(%task, %client)
{
	    %task.engageVehicule = -1;
	    %task.attackInitted = false;
            %client.setTargetObject(-1);        
}

function AIDetectVehiculeTask::weight(%task, %client)
{
	%player = %client.player;
	if (!isObject(%player))
		return;

        //if we're already attacking a mine, 
	if (%task.engageVehicule > 0 && isObject(%task.engageVehicule))
	{
		%task.setWeight($AIWeightDetectRemeq);
		//return;
	}
	//see if we're within the viscinity of a new (enemy) vehicle
	%task.engageVehicule = -1;
	%closestVehicule = -1;
	%closestDist = 300;	//initialize so only vehicles within 300 m will be detected...
	%vehiculeCount = $AIVehicleSet.getCount();
	for (%i = 0; %i < %vehiculeCount; %i++)
	{
		%vehicule = $AIVehicleSet.getObject(%i);
                if (! %vehicule)//added to stop consol errors - Lagg... 2-18-2003
                {
                   echo("OPPS! Not a vehicle");
                   %task.setWeight(0);
                   return;
                }
		if(%vehicule.isEnabled() && %vehicule.team != %client.team)
                {
                            %vehiculePos = %vehicule.getWorldBoxCenter();
		            %clPos = %client.player.getWorldBoxCenter();
                            //check for LOS
			    %mask = $TypeMasks::TerrainObjectType | 
                                    $TypeMasks::InteriorObjectType | $TypeMasks::TSStaticShapeObjectType;
			    %vehiculeLOS = !containerRayCast(%client.player.getWorldBoxCenter(), %vehicule.getWorldBoxCenter(), %mask, 0);
                            //see if the vehicle is the closest...
		            %vehiculeDist = VectorDist(%vehiculePos, %clPos);
		            if (%vehiculeDist < %closestDist && %vehiculeLOS)
                            {
   		                %closestVehicule = %vehicule;
                                %closestDist = %vehiculeDist;
		            }
	          
                }
	            //see if we found a vehicle to attack
	            if (%closestVehicule > 0)
	            {
                            %task.engageVehicule = %closestVehicule;
		            %task.attackInitted = false;
		            %task.setWeight($AIWeightDetectRemeq);
                    }
	            else
                            %task.setWeight(0);
    }
}

function AIDetectVehiculeTask::monitor(%task, %client)
{

        %player = %client.player;
	if (!isObject(%player))
		return;

        //check for LOS
	%mask = $TypeMasks::TerrainObjectType |
                 $TypeMasks::InteriorObjectType | $TypeMasks::TSStaticShapeObjectType;
	%vehiculeLOS = !containerRayCast(%player.getWorldBoxCenter(), %task.engageVehicule.getWorldBoxCenter(), %mask, 0);

	if (%task.engageVehicule > 0 && isObject(%task.engageVehicule) && %vehiculeLOS)
	{
                %hasMortar = (%player.getInventory("Mortar") > 0) && (%player.getInventory("MortarAmmo") > 0);
                %hasMissile = (%player.getInventory("MissileLauncher") > 0) && (%player.getInventory("MissileLauncherAmmo") > 0);
        
                if (!%task.attackInitted)
		{
			%task.attackInitted = true;
                        if (%hasMissile || %hasMortar)
                           %client.stepRangeObject(%task.engageVehicule, "BasicTargeter", 80, 300);
                        else
                           %client.stepRangeObject(%task.engageVehicule, "DefaultRepairBeam", 20, 100);
                        //echo("-----------Attack inittiated enemy vehicle ----------");
			%client.setEngageTarget(-1);
			%client.setTargetObject(-1);
		}

                else if (%client.getStepStatus() $= "Finished")
		{
                        %client.stop();
                        //echo("-----------We are killing a enemy vehicle ----------");
                        //%vehiculePos = %vehicule.getWorldBoxCenter();
		                //%clPos = %client.player.getWorldBoxCenter();
                        if (vectorDist(%client.player.getWorldBoxCenter(), %task.engageVehicule.getWorldBoxCenter()) > 40 && %hasMissile)
                           %client.setTargetObject(%task.engageVehicule, 300, "Missile");
                        else
                           %client.setTargetObject(%task.engageVehicule, 300, "Mortar");
                }
	}
        else
        {
            %task.engageVehicule = -1;
	    %task.attackInitted = false;
            %client.setTargetObject(-1);
            %task.setWeight(0);
        }
}



//-----------------------------------------------------------------------------
