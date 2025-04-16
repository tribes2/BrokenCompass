//-----------------------------------------------------------------------------------------------------------------
//Lagg-Alot - 4-12-2003
//
//These modified and new AIObjectives are the result of many hours of testing/modifing and more testing/modifing
//some of the objectives have new specific instuctions to make them work
//1) repair objective for sentryturrets (place the objective marker just obove the floor/ground
//where you want the bot to stand and repair the sentry turret all others objects are normal)
//2) new AIODestroyObject for those in tight space objects and for sentryturrets (place the objective marker 
//just obove the floor/ground where you want the bot to stand and shoot) MUST USE THIS FOR SENTRY TURRETS!
//3) new AIOMissileObject works for turrets sensors and (sometimes sentry turrets) (place the objective marker 
//in the spot you want bot to have a lineofsight to (LOS) bot will get LOS to the marker (not the object) than fire //missiles) makes it adjustable for hard to reach high up objects. Also place a AIOAttackObject with the same weight
//on the target to be missiled. If bot is to close to missile, gets unassignned and will kill with plasma disc.
//-------------------------------------------------------------------------------------------------------------------
//TASKS AND OBJECTIVES
//----------------------

//modified range for bot sniper to attack location - Lagg... 4-12-2003
function AIAttackLocation::monitor(%task, %client)
{
   //first, buy the equipment
   if (%client.needEquipment)
   {
	   %task.setMonitorFreq(5);
		if (%task.equipment !$= "")
			%equipmentList = %task.equipment;
		else
			%equipmentList = %task.desiredEquipment;
      %result = AIBuyInventory(%client, %equipmentList, %task.buyEquipmentSet, %task.buyInvTime);
		if (%result $= "InProgress")
			return;
		else if (%result $= "Finished")
		{
		   %task.setMonitorFreq(30);
			%client.needEquipment = false;
		}
		else if (%result $= "Failed")
		{
	      //if this task is the objective task, choose a new objective
	      if (%task == %client.objectiveTask)
	      {
	         AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
	      }
			return;
		}
   }
	//if we made it past the inventory buying, reset the inv time
	%task.buyInvTime = getSimTime();

	//chat
	if (%task.sendMsg)
	{
		if (%task.sendMsgTime == 0)
			%task.sendMsgTime = getSimTime();
		else if (getSimTime() - %task.sendMsgTime > 7000)
		{
			%task.sendMsg = false;
		   if (%client.isAIControlled())
			{
				if (%task.chat !$= "")
				{
					%chatMsg = getWord(%task.chat, 0);
					%chatTemplate = getWord(%task.chat, 1);
					if (%chatTemplate !$= "")
						AIMessageThreadTemplate(%chatTemplate, %chatMsg, %client, -1);
					else
						AIMessageThread(%task.chat, %client, -1);
				}
				else
					AIMessageThreadTemplate("AttackBase", "ChatSelfAttack", %client, -1);
			}
		}
	}

   //how far are we from the location we're defending
   %myPos = %client.player.getWorldBoxCenter();
   %distance = %client.getPathDistance(%task.location);
	if (%distance < 0)
		%distance = 32767;

	if (%client.player.getInventory(SniperRifle) > 0 && %client.player.getInventory(EnergyPack) > 0)
	{
		//first, find an LOS location
		if (%task.snipeLocation $= "")
		{
			%task.snipeLocation = %client.getLOSLocation(%task.location, 150, 400);//was 150-200 - Lagg...
			%task.hideLocation = %client.getHideLocation(%task.location, VectorDist(%task.location, %task.snipeLocation), %task.snipeLocation, 1); 
			%client.stepMove(%task.hideLocation, 4.0);
			%task.moveToPosition = true;
		}
		else
		{
			//see if we can acquire a target
			%energy = %client.player.getEnergyPercent();
			%distToSnipe = VectorDist(%task.snipelocation, %client.player.getWorldBoxCenter());
			%distToHide = VectorDist(%task.hidelocation, %client.player.getWorldBoxCenter());

			//until we're in position, we can move using the AIModeExpress, after that, we only want to walk...
			if (%task.moveToPosition)
			{
				if (%distToHide < 4.0)
				{
					//dissolve the human control link
					if (%task == %client.objectiveTask)
					{
						if (aiHumanHasControl(%task.issuedByClient, %client))
						{
							aiReleaseHumanControl(%client.controlByHuman, %client);

							//should re-evaluate the current objective weight
							%inventoryStr = AIFindClosestInventories(%client);
							%client.objectiveWeight = %client.objective.weight(%client, %client.objectiveLevel, 0, %inventoryStr);
						}
					}

					%task.moveToPosition = false;
				}
			}

			else if (%task.moveToSnipe)
			{
				if (%energy > 0.75 && %client.getStepStatus() $= "Finished")
				{
					%client.stepMove(%task.snipeLocation, 4.0, $AIModeWalk);
					%client.setEngageTarget(%task.engageTarget);
				}
				else if (%energy < 0.4)
				{
					%client.setEngageTarget(-1);
					%client.stepMove(%task.hideLocation, 4.0);
					//%task.nextSnipeTime = getSimTime() + 4000 + (getRandom() * 4000);
                                        %task.nextSnipeTime = getSimTime() + 1000 + (getRandom() * 4000);
					%task.moveToSnipe = false;
				}
			}

			else if (%energy > 0.5 && %task.engageTarget > 0 && getSimTime() > %task.nextSnipeTime)
			{ 
			   %client.stepRangeObject(%task.engageTarget.player.getWorldBoxCenter(), "BasicSniperShot", 150, 400, %task.snipelocation);
				%client.aimAt(%task.engageTarget.player.getWorldBoxCenter(), 2000);
				%task.moveToSnipe = true;
			}
		}
	}
	else
	{
	   //else see if we have a target to begin attacking
	   if (%client.getEngageTarget() <= 0 && %task.engageTarget > 0)
	      %client.stepEngage(%task.engageTarget);

	   //else move to the location we're defending
	   else if (%client.getEngageTarget() <= 0)
		{
	      %client.stepMove(%task.location, 8.0);
			if (VectorDist(%client.player.position, %task.location) < 10)
			{
				//dissolve the human control link
				if (%task == %client.objectiveTask)
				{
					if (aiHumanHasControl(%task.issuedByClient, %client))
					{
						aiReleaseHumanControl(%client.controlByHuman, %client);

						//should re-evaluate the current objective weight
						%inventoryStr = AIFindClosestInventories(%client);
						%client.objectiveWeight = %client.objective.weight(%client, %client.objectiveLevel, 0, %inventoryStr);
					}
				}
			}
		}
	}

   //see if we're supposed to be engaging anyone...
   if (!AIClientIsAlive(%client.getEngageTarget()) && AIClientIsAlive(%client.shouldEngage))
      %client.setEngageTarget(%client.shouldEngage);
}

//------------------------------

//modified range to attack object - Lagg... - 4-12-2003
function AIAttackObject::monitor(%task, %client)
{
   //first, buy the equipment - if we really really need some :) - Lagg... - 4-6-2003
   %hasPlasma = (%client.player.getInventory("Plasma") > 0) && (%client.player.getInventory("PlasmaAmmo") > 0);
   if (%client.needEquipment && !%hasPlasma)
   {
	   %task.setMonitorFreq(5);
		if (%task.equipment !$= "")
			%equipmentList = %task.equipment;
		else
			%equipmentList = %task.desiredEquipment;
      %result = AIBuyInventory(%client, %equipmentList, %task.buyEquipmentSet, %task.buyInvTime);
		if (%result $= "InProgress")
			return;
		else if (%result $= "Finished")
		{
		   %task.setMonitorFreq(15);
			%client.needEquipment = false;
		}
		else if (%result $= "Failed")
		{
	      //if this task is the objective task, choose a new objective
	      if (%task == %client.objectiveTask)
	      {
	         AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
	      }
			return;
		}
   }
	//if we made it past the inventory buying, reset the inv time
	%task.buyInvTime = getSimTime();
   
	//chat
	if (%task.sendMsg)
	{
		if (%task.sendMsgTime == 0)
			%task.sendMsgTime = getSimTime();
		else if (getSimTime() - %task.sendMsgTime > 7000)
		{
			%task.sendMsg = false;
		   if (%client.isAIControlled())
			{
				if (%task.chat !$= "")
				{
					%chatMsg = getWord(%task.chat, 0);
					%chatTemplate = getWord(%task.chat, 1);
					if (%chatTemplate !$= "")
						AIMessageThreadTemplate(%chatTemplate, %chatMsg, %client, -1);
					else
						AIMessageThread(%task.chat, %client, -1);
				}
				else if (%task.targetObject > 0)
				{
					%type = %task.targetObject.getDataBlock().getName();
					if (%type $= "GeneratorLarge")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackGenerator", %client, -1);
					else if (%type $= "SensorLargePulse")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackSensors", %client, -1);
					else if (%type $= "SensorMediumPulse")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackSensors", %client, -1);
					else if (%type $= "TurretBaseLarge")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackTurrets", %client, -1);
					else if (%type $= "StationVehicle")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackVehicle", %client, -1);
				}
			}
		}
	}
   //see if we need to engage a new target - this next bit was added to enhance performance :) - Lagg... 4-8-2003
   %engageTarget = %client.getEngageTarget();
   if (!AIClientIsAlive(%engageTarget) && %task.engageTarget > 0)
      %client.setEngageTarget(%task.engageTarget);


   //else see if we should abandon the engagement
   if (AIClientIsAlive(%engageTarget))
   {
      %myPos = %client.player.getWorldBoxCenter();
      %testPos = %engageTarget.player.getWorldBoxCenter();
      %distance = %client.getPathDistance(%testPos);
      if (%distance < 0 || %distance > 70)
         %client.setEngageTarget(-1);
   }


   //set the target object
   %outOfStuff = (AIAttackOutofAmmo(%client));
   if (isObject(%task.targetObject) && %task.targetObject.getDamageState() !$= "Destroyed" && !%outOfStuff)
   {
      %client.setTargetObject(%task.targetObject, 40, "Destroy");
   
      //move towards the object until we're within range
      if (! %client.targetInRange())
         %client.stepMove(%task.targetObject.getWorldBoxCenter(), 8.0);
      else
		{
			//dissolve the human control link
			if (%task == %client.objectiveTask)
				aiReleaseHumanControl(%client.controlByHuman, %client);

         %client.stop();
		}
   }
   else
   {
      %client.setTargetObject(-1);
      %client.stop();
      
      //if this task is the objective task, choose a new objective
      if (%task == %client.objectiveTask)
      {
         AIUnassignClient(%client);
         Game.AIChooseGameObjective(%client);
      }
   }
}

//---------------------------------------------------------------------------------------------
//modified for sentry turrets - place objective marker in spot you want bot to stand for repair
//fixed spam error when trying to repair a deployed object in case it gets killed while in loop
//also fixed bots finding repair pack if base is down :) -------------------- Lagg... 3-26-2003
//---------------------------------------------------------------------------------------------

function AIRepairObject::initFromObjective(%task, %objective, %client)
{
   %task.baseWeight = %client.objectiveWeight;
   %task.targetObject = %objective.targetObjectId;
	//need to force this objective to only require a repair pack
   //%task.equipment = %objective.equipment;
   %task.equipment = "RepairPack";
	%task.buyEquipmentSet = %objective.buyEquipmentSet;
	%task.desiredEquipment = %objective.desiredEquipment;
	%task.issuedByClient = %objective.issuedByClientId;
        %task.location = %objective.location;
        
	%task.deployed = %objective.deployed;
	if (%task.deployed)
	{
                if (!isObject(%task.targetObject) && isObject(%objective.repairObjective))
		{
                    //if this task is the objective task, choose a new objective
                    if (%task == %client.objectiveTask)
		    {
                        AIUnassignClient(%client);
	                Game.AIChooseGameObjective(%client);			
		    }
                    return;                    
	        }
		%task.location = %objective.position;
		%task.deployDirection = MatrixMulVector("0 0 0 " @ getWords(%objective.getTransform(), 3, 6), "0 1 0");
		%task.deployDirection = VectorNormalize(%task.deployDirection);
	}
}

function AIRepairObject::assume(%task, %client)
{
   %task.setWeightFreq(15);
   %task.setMonitorFreq(15);
   %client.needEquipment = AINeedEquipment(%task.equipment, %client);
      
   //clear the target object, and range it
   %client.setTargetObject(-1);
	if (! %client.needEquipment)
	{
	    if (%task.deployed)
	    {
                if (!isObject(%task.targetObject) && isObject(%objective.repairObjective))
		{
                    //if this task is the objective task, choose a new objective
                    if (%task == %client.objectiveTask)
		    {
                        AIUnassignClient(%client);
	                Game.AIChooseGameObjective(%client);			
		    }
		    return;                    
	        }
		   %task.repairLocation = VectorAdd(%task.location,VectorScale(%task.deployDirection, -4.0));//was -4
			%client.stepMove(%task.repairLocation, 0.25);
	    }
            //is it a sentry turret? - Lagg... 3-26-2003
	    else if (%task.targetObject.getDataBlock().getName() $= "SentryTurret")
                %client.stepMove(%task.location);
            else
	        %client.stepRangeObject(%task.targetObject, "DefaultRepairBeam", 2, 6);
	}

	//mark the current time for the buy inventory state machine
	%task.buyInvTime = getSimTime();
	%task.needToRangeTime = 0;
	%task.pickupRepairPack = -1;
	%task.usingInv = false;

	//set a tag to help the repairPack.cs script fudge acquiring a target
	%client.repairObject = %task.targetObject;
}

function AIRepairObject::retire(%task, %client)
{
   %client.setTargetObject(-1);
	%client.repairObject = -1;
}

function AIRepairObject::weight(%task, %client)
{
        //update the task weight
	if (%task == %client.objectiveTask)
		%task.baseWeight = %client.objectiveWeight;

   //let the monitor decide when to stop repairing
   %task.setWeight(%task.baseWeight);
}

function AIRepairObject::monitor(%task, %client)
{
   //echo("AIRepairObject --- monitor");
   //first, buy the equipment
   if (%client.needEquipment)
   {
           %task.setMonitorFreq(5);

		//first, see if we still need a repair pack
		if (%client.player.getInventory(RepairPack) > 0)
		{
			%client.needEquipment = false;
		   %task.setMonitorFreq(15);

			//if this is to repair a deployed object, walk to the deploy point...
			if (%task.deployed)
			{
                           if (!isObject(%task.targetObject) && isObject(%objective.repairObjective))
		           {
                               %client.setTargetObject(-1);
                               //if this task is the objective task, choose a new objective
                               if (%task == %client.objectiveTask)
		               {
                                  //AIUnassignClient(%client);
	                          //Game.AIChooseGameObjective(%client);			
		               }
		               AIClearObjective(%objective.repairObjective);
		               %objective.repairObjective.delete();
		               %objective.repairObjective = "";
                               //echo("AIRepairObject - init - is not an object so delete repairobjective");
                               return;                    
	                   }
			   %task.repairLocation = VectorAdd(%task.location,VectorScale(%task.deployDirection, -4.0));//was -4
				%client.stepMove(%task.repairLocation, 0.25);
			}
                        //is it a sentry turret? - Lagg... 3-26-2003
	                else if (%task.targetObject.getDataBlock().getName() $= "SentryTurret")
                           %client.stepMove(%task.location);
			//otherwise, we'll need to range it...
			else
			   %client.stepRangeObject(%task.targetObject, "DefaultRepairBeam", 2, 6);
		}
		else
		{
			// check to see if there's a repair pack nearby
			%closestRepairPack = -1;
			%closestRepairDist = 32767;

			//search the AIItemSet for a repair pack (someone might have dropped one...)
			%itemCount = $AIItemSet.getCount();
			for (%i = 0; %i < %itemCount; %i++)
			{
				%item = $AIItemSet.getObject(%i);
				if (%item.getDataBlock().getName() $= "RepairPack" && !%item.isHidden())
				{
                                        %dist = %client.getPathDistance(%item.getWorldBoxCenter());
					if (%dist > 0 && %dist < %closestRepairDist)
					{
                                                %closestRepairPack = %item;
						%closestRepairDist = %dist;
					}
				}
			}

			//choose whether we're picking up the closest pack, or buying from an inv station...
                        //with all these errors by Dynamix it is a wonder the bots do anything - Lagg... 3-25-2003
			if ((isObject(%closestRepairPack) && %closestRepairPack != %task.pickupRepairPack) || (%task.buyInvTime != %client.buyInvTime))
                        {
                                %task.pickupRepairPack = %closestRepairPack;

				//initialize the inv buying
				%task.buyInvTime = getSimTime();
				AIBuyInventory(%client, "RepairPack", %task.buyEquipmentSet, %task.buyInvTime);

				//now decide which is closer
				if (isObject(%closestRepairPack))
				{
                                        //added a little here to check for power - Lagg... - 3-25-2003
					if (isObject(%client.invToUse) && (%client.invToUse.isEnabled()) && (%client.invToUse.isPowered()))
					{
                                                %dist = %client.getPathDistance(%client.invToUse.getWorldBoxCenter());
						if (%dist < %closestRepairDist)
							%task.usingInv = true;
						else
							%task.usingInv = false;
					}
					else
                                           %task.usingInv = false;
				}
				else
					%task.usingInv = true;
			}

			//now see if we found a closer repair pack
			if (!%task.usingInv)
			{
				%client.stepMove(%task.pickupRepairPack.position, 0.25);
				%distToPack = %client.getPathDistance(%task.pickupRepairPack.position);
				if (%distToPack < 10 && %client.player.getMountedImage($BackpackSlot) > 0)
					%client.player.throwPack();

				//and we're finished until we actually have a repair pack... should now! - Lagg...
				return;
			}
			else
			{
		                %result = AIBuyInventory(%client, "RepairPack", %task.buyEquipmentSet, %task.buyInvTime);
				if (%result $= "InProgress")
					return;
				else if (%result $= "Finished")
				{
					%client.needEquipment = false;
				        %task.setMonitorFreq(15);

					//if this is to repair a deployed object, walk to the deploy point...
					if (%task.deployed)
					{ 	
					   %task.repairLocation = VectorAdd(%task.location,VectorScale(%task.deployDirection, -4.0));//was -4
						%client.stepMove(%task.repairLocation, 0.25);
					}
                                        //is it a sentry turret? - Lagg... 3-26-2003
	                                else if (%task.targetObject.getDataBlock().getName() $= "SentryTurret")
                                           %client.stepMove(%task.location);
					//otherwise, we'll need to range it...
					else
					   %client.stepRangeObject(%task.targetObject, "DefaultRepairBeam", 2, 6);
				}
				else if (%result $= "Failed")
				{
			      //if this task is the objective task, choose a new objective
			      if (%task == %client.objectiveTask)
			      {
			         AIUnassignClient(%client);
			         Game.AIChooseGameObjective(%client);
			      }
					return;
				}
			}
		}
   }
	//if we made it past the inventory buying, reset the inv time
	%task.buyInvTime = getSimTime();
   
	//chat
	if (%task.sendMsg)
	{
		if (%task.sendMsgTime == 0)
			%task.sendMsgTime = getSimTime();
		else if (getSimTime() - %task.sendMsgTime > 7000)
		{
			%task.sendMsg = false;
		   if (%client.isAIControlled())
			{
				if (%task.chat !$= "")
				{
					%chatMsg = getWord(%task.chat, 0);
					%chatTemplate = getWord(%task.chat, 1);
					if (%chatTemplate !$= "")
						AIMessageThreadTemplate(%chatTemplate, %chatMsg, %client, -1);
					else
						AIMessageThread(%task.chat, %client, -1);
				}
				else if (%task.targetObject > 0)
				{
					%type = %task.targetObject.getDataBlock().getName();
					if (%type $= "GeneratorLarge")
						AIMessageThreadTemplate("RepairBase", "ChatSelfRepairGenerator", %client, -1);
					else if (%type $= "StationVehicle")
						AIMessageThreadTemplate("RepairBase", "ChatSelfRepairVehicle", %client, -1);
					else if (%type $= "SensorLargePulse")
						AIMessageThreadTemplate("RepairBase", "ChatSelfRepairSensors", %client, -1);
					else if (%type $= "SensorMediumPulse")
						AIMessageThreadTemplate("RepairBase", "ChatSelfRepairSensors", %client, -1);
					else if (%type $= "TurretBaseLarge")
						AIMessageThreadTemplate("RepairBase", "ChatSelfRepairTurrets", %client, -1);
				}
			}
		}
	}

   //if deployable got killed before we get to it - Lagg...
   if (!isObject(%task.targetObject))
   {
       //echo("is not an object so don't repair it!!!!!!!!!!! - Lagg...");
       %client.setTargetObject(-1);

      //if this task is the objective task, choose a new objective
      if (%task == %client.objectiveTask)
         {
            //echo("and unassign client!!!!!!!!!!! - Lagg...");
            AIUnassignClient(%client);
	    Game.AIChooseGameObjective(%client);
            return;
	 }
    }
      if (%task.targetObject.getDamagePercent() > 0)
      {
         //make sure we still have equipment
		%client.needEquipment = AINeedEquipment(%task.equipment, %client);
         if (%client.needEquipment)
         {
         //if this task is the objective task, choose a new objective
         if (%task == %client.objectiveTask)
			{
            AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
				return;
			}
         }
      
		if (%task.deployed)
		{
			//see if we're within range of the deploy location
		   %clLoc = %client.player.position;
		   %distance = VectorDist(%clLoc, %task.repairLocation);
			%dist2D = VectorDist(%client.player.position, getWords(%task.repairLocation, 0, 1) SPC getWord(%client.player.position, 2));

			//set the aim when we get near the target...  this will be overwritten when we're actually trying to repair deployed
 			if (%distance < 10 && %dist2D < 10)
 		      %client.aimAt(%task.location, 1000);

			//see if we're at the deploy location
		   if ((%client.pathDistRemaining(20) > %distance + 0.25) || %dist2D > 0.3)
			{
	         %client.setTargetObject(-1);
		      %client.stepMove(%task.repairLocation, 0.25);
			}
			else
			{
				%client.stop();
                                %client.setTargetObject(%task.targetObject, 12, "Repair");//increased range - Lagg...
			}
		}
		else
		{
			%currentTime = getSimTime();
			if (%currentTime > %task.needToRangeTime)
			{
				//force a rangeObject every 10 seconds...
				%task.needToRangeTime = %currentTime + 6000;
				%client.setTargetObject(-1);
                                //is it a sentry turret? - Lagg... 3-26-2003
	                        if (%task.targetObject.getDataBlock().getName() $= "SentryTurret")
                                   %client.stepMove(%task.location);
                                else
			           %client.stepRangeObject(%task.targetObject, "DefaultRepairBeam", 2, 6);
			}

	      //if we've ranged the object, start repairing, else unset the object
	      else if (%client.getStepStatus() $= "Finished")
			{
				//dissolve the human control link
				if (%task == %client.objectiveTask)
					aiReleaseHumanControl(%client.controlByHuman, %client);
                                
                                //need to fix position if to close to object - Lagg...
                                %dist = VectorDist(%client.player.getWorldBoxCenter(), %task.targetObject.getWorldBoxCenter());
                                if (%dist < 2)
                                   %client.setDangerLocation(%task.targetObject.position, 2);                               
                                %client.setTargetObject(%task.targetObject, 12, "Repair");
			}
	      else
	         %client.setTargetObject(-1);
		}
   }
   else
   {
      %client.setTargetObject(-1);
      
      //if this task is the objective task, choose a new objective
      if (%task == %client.objectiveTask)
		{
         AIUnassignClient(%client);
			Game.AIChooseGameObjective(%client);
		}
   }
}

//------------------------------

//modified range to target and bot seeks LOS before shooting :) - Lagg... 4-12-2003
function AIMortarObject::monitor(%task, %client)
{
   //first, buy the equipment
   if (%client.needEquipment)
   {
	   %task.setMonitorFreq(5);
		if (%task.equipment !$= "")
			%equipmentList = %task.equipment;
		else
			%equipmentList = %task.desiredEquipment;
      %result = AIBuyInventory(%client, %equipmentList, %task.buyEquipmentSet, %task.buyInvTime);
		if (%result $= "InProgress")
			return;
		else if (%result $= "Finished")
		{
		   %task.setMonitorFreq(30);
			%client.needEquipment = false;
		}
		else if (%result $= "Failed")
		{
	      //if this task is the objective task, choose a new objective
	      if (%task == %client.objectiveTask)
	      {
	         AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
	      }
			return;
		}
   }
	//if we made it past the inventory buying, reset the inv time
	%task.buyInvTime = getSimTime();
   
	//chat
	if (%task.sendMsg)
	{
		if (%task.sendMsgTime == 0)
			%task.sendMsgTime = getSimTime();
		else if (getSimTime() - %task.sendMsgTime > 7000)
		{
			%task.sendMsg = false;
		   if (%client.isAIControlled())
			{
				if (%task.chat !$= "")
				{
					%chatMsg = getWord(%task.chat, 0);
					%chatTemplate = getWord(%task.chat, 1);
					if (%chatTemplate !$= "")
						AIMessageThreadTemplate(%chatTemplate, %chatMsg, %client, -1);
					else
						AIMessageThread(%task.chat, %client, -1);
				}
				else if (%task.targetObject > 0)
				{
					%type = %task.targetObject.getDataBlock().getName();
					if (%type $= "GeneratorLarge")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackGenerator", %client, -1);
					else if (%type $= "SensorLargePulse")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackSensors", %client, -1);
					else if (%type $= "SensorMediumPulse")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackSensors", %client, -1);
					else if (%type $= "TurretBaseLarge")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackTurrets", %client, -1);
					else if (%type $= "StationVehicle")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackVehicle", %client, -1);
				}
			}
		}
	}

   //make sure we still have something to destroy
   if (isObject(%task.targetObject) && %task.targetObject.getDamageState() !$= "Destroyed")
   {
      %clientPos = %client.player.getWorldBoxCenter();
      %targetPos = %task.targetObject.getWorldBoxCenter();
      %distance = %client.getPathDistance(%targetPos);
		if (%distance < 0)
			%distance = 32767;
      
      //make sure we still have equipment
		%client.needEquipment = AINeedEquipment(%task.equipment, %client);
      if (%client.needEquipment)
      {
         //if this task is the objective task, choose a new objective
         if (%task == %client.objectiveTask)
			{
            AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
				return;
			}
      }
      
      //next move to within 220 
      else if (%distance > 300)
      {
         %client.setTargetObject(-1);
         %client.stepMove(%task.targetObject.getWorldBoxCenter(), 15);
      }
      
      //now start ask for someone to laze the target, and start a 1 sec timer
      else if (%task.waitForTargetter)
      {
         //see if we've started the timer
         if (%task.waitTimerMS == 0)
         {
				//range the object
	         %client.stepRangeObject(%task.targetObject, "BasicTargeter", 80, 300);

            //now ask for a targeter...
				%targetType = %task.targetObject.getDataBlock().getName();
				if (%targetType $= "TurretBaseLarge")
					AIMessageThread("ChatCmdTargetTurret", %client, -1);
				else if (%targetType $= "SensorLargePulse")
					AIMessageThread("ChatCmdTargetSensors", %client, -1);
				else if (%targetType $= "SensorMediumPulse")
					AIMessageThread("ChatCmdTargetSensors", %client, -1);
				else
					AIMessageThread("ChatNeedTarget", %client, -1);

            %task.waitTimerMS = getSimTime();

            //create the objective
				if (! %task.targetterObjective)
				{
	            %task.targetterObjective = new AIObjective(AIOLazeObject)
	                              {
										      dataBlock = "AIObjectiveMarker";
	                                 weightLevel1 = $AIWeightLazeObject[1];
	                                 weightLevel2 = $AIWeightLazeObject[2];
	                                 description = "Laze the " @ %task.targetObject.getName();
	                                 targetObjectId = %task.targetObject;
												issuedByClientId = %client;
	                                 offense = true;
	                                 equipment = "TargetingLaser";
	                              };
			      MissionCleanup.add(%task.targetterObjective);
	            $ObjectiveQ[%client.team].add(%task.targetterObjective);
				}
				%task.targetterObjective.lastLazedTime = 0;

				//remove the escort (want a targetter instead)
				if (%client.escort)
				{
			      AIClearObjective(%client.escort);
			      %client.escort.delete();
			      %client.escort = "";
				}
         }									
         else
         {
            %elapsedTime = getSimTime() - %task.waitTimerMS;
				if (%task.targetterObjective.group > 0)
					%targetter = %task.targetterObjective.group.clientLevel[1];
				else
	            %targetter = %task.targetterObjective.clientLevel[1];

				//see if we can find a target near our objective
				%task.targetAcquired = false;
				%numTargets = ServerTargetSet.getCount();
				for (%i = 0; %i < %numTargets; %i++)
				{
					%targ = ServerTargetSet.getObject(%i);
					%targDist = VectorDist(%targ.getTargetPoint(), %task.targetObject.getWorldBoxCenter());
                    if (%targDist < 20)
					{
						%task.targetAcquired = true;
						break;
					}
				}

				if (%task.targetAcquired)
            {
               %task.waitForTargetter = false;
					%task.waitTimerMS = 0;
					%task.celebrate = true;
					%task.sayAcquired = false;
					AIMessageThread("ChatTargetAcquired", %client, -1);
            }

				//else see if we've run out of time
				else if ((! %targetter || ! %targetter.isAIControlled()) || %elapsedTime > 1000)
				{
               %task.waitForTargetter = false;
					%task.waitTimerMS = 0;
					%task.celebrate = true;
				}  
         }
      }
      
      //now we should finally be attacking with or without a targetter
      //eventually, the target will be destroyed, or we'll run out of ammo...
      else
      {
			//dissolve the human control link
			if (%task == %client.objectiveTask)
				aiReleaseHumanControl(%client.controlByHuman, %client);

			//see if we didn't acquired a spotter along the way
			if (%task.targetterObjective.group > 0)
	         %targetter = %task.targetterObjective.group.clientLevel[1];
			else
	         %targetter = %task.targetterObjective.clientLevel[1];
			if (! %task.targetAcquired && AIClientIsAlive(%targetter) && %targetter.isAIControlled())
			{
				%client.setTargetObject(-1);
		      %task.waitForTargetter = true;
			}
			else
			{
				//see if we can find a target near our objective
				if (! %task.targetAcquired)
				{
					%numTargets = ServerTargetSet.getCount();
					for (%i = 0; %i < %numTargets; %i++)
					{
						%targ = ServerTargetSet.getObject(%i);
						%targDist = VectorDist(%targ.getTargetPoint(), %task.targetObject.getWorldBoxCenter());
                        if (%targDist < 20)
						{
							%task.targetAcquired = true;
							break;
						}
					}
					//see if we found a target (must be by a human)
					if (%task.targetAcquired && %task.sayAcquired)
					{
						%task.sayAcquired = false;
						AIMessageThread("ChatTargetAcquired", %client, -1);
					}
				}
				
	         //set the target object, and keep attacking it
	         if (%client.getStepStatus() $= "Finished")
	            %client.setTargetObject(%task.targetObject, 300, "Mortar");
	         else
	            %client.setTargetObject(-1);
			}
      }
   }

	//the target must have been destroyed  :)
   else
   {
		//dissolve the human control link
		if (%task == %client.objectiveTask)
			aiReleaseHumanControl(%client.controlByHuman, %client);

      %client.setTargetObject(-1);
      %client.clearStep();
      %client.stop();

		if (%task.celebrate)
		{
			if (%task.waitTimerMS == 0)
			{
				//client animation "woohoo"!  :)
				//choose the animation range
				%minCel = 3;
				%maxCel = 8;

				//pick a random sound
				if (getRandom() > 0.25)
					%sound = "gbl.awesome";
				else if (getRandom() > 0.5)
					%sound = "gbl.thanks";
				else if (getRandom() > 0.75)
					%sound = "gbl.nice";
				else
					%sound = "gbl.rock";
			  	%randTime = mFloor(getRandom() * 500) + 1;
			   schedule(%randTime, %client, "AIPlayAnimSound", %client, %task.targetObject.getWorldBoxCenter(), %sound, %minCel, %maxCel, 0);

				//team message
				AIMessageThread("ChatEnemyTurretsDestroyed", %client, -1);

				//set the timer
            %task.waitTimerMS = getSimTime();
			}

			//else see if the celebration period is over
			else if (getSimTime() - %task.waitTimerMS > 3000)
				%task.celebrate = false;
		}
		else
		{
	      //if this task is the objective task, choose a new objective
	      if (%task == %client.objectiveTask)
			{
	         AIUnassignClient(%client);
				Game.AIChooseGameObjective(%client);
			}
		}
   }
}

//-----------------------------------
//modified range to deploy to make easier for outdoor inventory deployments - Lagg... - 4-12-2003
function AIDeployEquipment::monitor(%task, %client)
{
   //first, buy the equipment
   if (%client.needEquipment)
   {
	   %task.setMonitorFreq(5);
		if (%task.equipment !$= "")
			%equipmentList = %task.equipment;
		else
			%equipmentList = %task.desiredEquipment;
      %result = AIBuyInventory(%client, %equipmentList, %task.buyEquipmentSet, %task.buyInvTime);
		if (%result $= "InProgress")
			return;
		else if (%result $= "Finished")
		{	
		   %task.setMonitorFreq(30);
         %client.needEquipment = false;
         //if we made it past the inventory buying, reset the inv time
	      %task.buyInvTime = getSimTime();
      }
      else if (%result $= "Failed")
		{
	      //if this task is the objective task, choose a new objective
	      if (%task == %client.objectiveTask)
	      {
	         AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
	      }
			return;
		}
   }

   //make sure we still have equipment
		%client.needEquipment = AINeedEquipment(%task.equipment, %client);
      if (%client.needEquipment)
      {
         //if this task is the objective task, choose a new objective
         if (%task == %client.objectiveTask)
			{
            AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
				return;
			}
      }

	//chat
	if (%task.sendMsg)
	{
		if (%task.sendMsgTime == 0)
			%task.sendMsgTime = getSimTime();
		else if (getSimTime() - %task.sendMsgTime > 7000)
		{
			%task.sendMsg = false;
		   if (%client.isAIControlled())
			{
				if (%task.chat !$= "")
				{
					%chatMsg = getWord(%task.chat, 0);
					%chatTemplate = getWord(%task.chat, 1);
					if (%chatTemplate !$= "")
						AIMessageThreadTemplate(%chatTemplate, %chatMsg, %client, -1);
					else
						AIMessageThread(%task.chat, %client, -1);
				}
			}
		}
	}

   //see if we're supposed to be engaging anyone...
   if (AIClientIsAlive(%client.shouldEngage))
   {
	   %hasLOS = %client.hasLOSToClient(%client.shouldEngage);
	   %losTime = %client.getClientLOSTime(%client.shouldEngage);
	   if (%hasLOS || %losTime < 1000)
         %client.setEngageTarget(%client.shouldEngage);
      else
         %client.setEngageTarget(-1);
   }
   else
      %client.setEngageTarget(-1);

	//calculate the deployFromLocation
	%factor = -1 * (4 - (%task.passes * 0.5));//changed to 4m behind to improve proformance --- Lagg... 3-15-2003
   %task.deployFromLocation = VectorAdd(%task.location,VectorScale(%task.deployDirection, %factor));

	//see if we're within range of the deploy location
   %clLoc = %client.player.position;
   %distance = VectorDist(%clLoc, %task.deployFromLocation);
	%dist2D = VectorDist(%client.player.position, getWords(%task.deployFromLocation, 0, 1) SPC getWord(%client.player.position, 2));

	//set the aim when we get near the target...  this will be overwritten when we're actually trying to deploy
	if (%distance < 10 && %dist2D < 10)
      %client.aimAt(%task.location, 1000);

   if ((%client.pathDistRemaining(20) > %distance + 0.25) || %dist2D > 0.5)
	{
		%task.deployAttempts = 0;
		%task.checkObstructed = false;
		%task.waitMove = 0;
      %client.stepMove(%task.deployFromLocation, 0.25);
	   %task.setMonitorFreq(15);
		return;
	}
   
	if (%task.deployAttempts < 10 && %task.passes < 5 && !AIClientIsAlive(%client.getEngageTarget()))
	{
		//dissolve the human control link
		if (%task == %client.objectiveTask)
			aiReleaseHumanControl(%client.controlByHuman, %client);

	   %task.setMonitorFreq(3);
      %client.stop();
		if (%task.deployAttempts == 0)
			%deployPoint = %task.location;
		else
	      %deployPoint = findTurretDeployPoint(%client, %task.location, %task.deployAttempts);
      if(%deployPoint !$= "")
      {
         // we have possible point
         %task.deployAttempts++;
         %client.aimAt(%deployPoint, 2000);

			//try to deploy the backpack
			%client.deployPack = true;
         %client.lastDeployedObject = -1;
         %client.player.use(Backpack);
         
         // check if pack deployed
         if (isObject(%client.lastDeployedObject))
			{
				//see if there's a "repairObject" objective for the newly deployed thingy...
				if (%task == %client.objectiveTask)
				{
					%deployedObject = %client.lastDeployedObject;

					//search the current objective group and search for a "repair Object" task...
					%objective = %client.objective;

					//delete any previously associated "AIORepairObject" objective
					if (isObject(%objective.repairObjective))
					{
						AIClearObjective(%objective.repairObjective);
						%objective.repairObjective.delete();
						%objective.repairObjective = "";
					}

					//add the repair objective
	            %objective.repairObjective = new AIObjective(AIORepairObject)
		                              {
											      dataBlock = "AIObjectiveMarker";
		                                 weightLevel1 = %objective.weightLevel1 - 300;
		                                 weightLevel2 = 0;
		                                 description = "Repair the " @ %deployedObject.getDataBlock().getName();
													targetObjectId = %deployedObject;
													issuedByClientId = %client;
		                                 offense = false;
													defense = true;
		                                 equipment = "RepairPack";
                                                 buyEquipmentSet = "LightRepairSet";
		                              };
					%objective.repairObjective.deployed = true;
					%objective.repairObjective.setTransform(%objective.getTransform());
					%objective.repairObjective.group = %objective.group;
			      MissionCleanup.add(%objective.repairObjective);
	            $ObjectiveQ[%client.team].add(%objective.repairObjective);

					//finally, unassign the client so he'll go do something else...
			      AIUnassignClient(%client);
					Game.AIChooseGameObjective(%client);
				}

				//finished
				return;
			}
      }
	}
	else if (!%task.checkObstructed)
	{
		%task.checkObstructed = true;

	   //see if anything is in our way
	   InitContainerRadiusSearch(%task.location, 4, $TypeMasks::MoveableObjectType | $TypeMasks::VehicleObjectType |
																					                      $TypeMasks::PlayerObjectType);
	   %objSrch = containerSearchNext();
		if (%objSrch == %client.player)
		   %objSrch = containerSearchNext();
	   if (%objSrch)
			AIMessageThread("ChatMove", %client, -1);
	}
	else if (%task.waitMove < 5 && %task.passes < 5)
	{
		%task.waitMove++;

		//try another pass at deploying 
		if (%task.waitMove == 5)
		{
			%task.waitMove = 0;
			%task.passes++;
			%task.deployAttempts = 0;

			//see if we're *right* underneath the deploy point
			%deployDist2D = VectorDist(getWords(%client.player.position, 0, 1) @ "0", getWords(%task.location, 0, 1) @ "0");
			if (%deployDist2D < 0.25)
			{
				%client.pressjump();
				%client.deployPack = true;
	         %client.player.use(Backpack);

	         // check if pack deployed
	         if(%client.player.getMountedImage($BackpackSlot) == 0)
				{
					//don't add a "repairObject" objective for ceiling turrets
					if (%task == %client.objectiveTask)
					{
						AIUnassignClient(%client);
						Game.AIChooseGameObjective(%client);
					}
				}
			}
		}
	}
	else
	{
		//find a new assignment - and remove this one from the Queue
      if (%task == %client.objectiveTask)
		{
			error(%client SPC "from team" SPC %client.team SPC "is invalidating objective:" SPC %client.objective SPC "UNABLE TO DEPLOY EQUIPMENT");
			%client.objective.isInvalid = true;
	      AIUnassignClient(%client);
			Game.AIChooseGameObjective(%client);
		}
	}
}

//----------------------------------------------------------------------------------------------------------

//AI Objective functions

function AIODefault::weight(%objective, %client, %level, %inventoryStr)
{
   //make sure the player is still alive!!!!!
   if (! AIClientIsAlive(%client))
      return 0;

   //set the base weight
   switch (%level)
   {
      case 1:
         %weight = %objective.weightLevel1;
      case 2:
         %weight = %objective.weightLevel2;
      case 3:
         %weight = %objective.weightLevel3;
      default:
         %weight = %objective.weightLevel4;
   }
   
   //check Affinity
   if (ClientHasAffinity(%objective, %client))
      %weight += 40;

	//if the objective doesn't require any equipment, it automatically get's the +100...
	if (%objective.equipment $= "" && %objective.desiredEquipment $= "")
		%weight += 100;
	else
	{
		//check equipment requirement
		%needEquipment = AINeedEquipment(%objective.equipment, %client);
	      
	   //check Required equipment
	   if (%objective.equipment !$= "" && !%needEquipment)
	      %weight += 100;

		//figure out the percentage of desired equipment the bot has
		else if (%objective.desiredEquipment !$= "")
		{
			%count = getWordCount(%objective.desiredEquipment);
			%itemCount = 0;
			for (%i = 0; %i < %count; %i++)
			{
				%item = getWord(%objective.desiredEquipment, %i);
				if (!AINeedEquipment(%item, %client))
					%itemCount++;
			}

			//add to the weight
			%weight += mFloor((%itemCount / %count) * 75);
		}
	}
      
   //find the distance to target
   if (%objective.targetClientId !$= "" || %objective.targetObjectId !$= "")
   {
      if (AIClientIsAlive(%objective.targetClientId))
      {   
         %targetPos = %objective.targetClientId.player.getWorldBoxCenter();
      }
      else if (VectorDist(%objective.location, "0 0 0") > 1)
         %targetPos = %objective.location;
      else
      {   
         if(%objective.targetObjectId > 0)
            %targetPos = %objective.targetObjectId.getWorldBoxCenter();
      }
   }

	//make sure the destination is accessible
   %distance = %client.getPathDistance(%targetPos);
	if (%distance < 0)
		return 0;

	%closestInvIsRemote = (getWordCount(%inventoryStr) == 4);
	%closestInv = getWord(%inventoryStr, 0);
	%closestDist = getWord(%inventoryStr, 1);
	%closestRemoteInv = getWord(%inventoryStr, 2);
	%closestRemoteDist = getWord(%inventoryStr, 3);
	
   //if we need equipment, the distance is from the client, to an inv, then to the target
 	if (%needEquipment)
 	{
		//if we need a regular inventory station, and one doesn't exist, exit
		if (!isObject(%closestInv) && %needArmor)
			return 0;

		//find the closest inv based on whether we require armor (from a regular inv station)
		if (!%closestInvIsRemote)
		{
			%needArmor = false;
			%weightDist = %closestDist;
			%weightInv = %closestInv;
		}
		else
		{
	 		%needArmor = AIMustUseRegularInvStation(%objective.equipment, %client);
			if (%needArmor)
			{
				%weightDist = %closestDist;
				%weightInv = %closestInv;
			}
			else
			{
				%weightDist = %closestRemoteDist;
				%weightInv = %closestRemoteInv;
			}
		}

		//if we don't need armor, and there's no inventory station, see if the equipment we need
		//is something we can pick up off the ground (likely this would be a repair pack...)
		if (%weightDist >= 32767)
		{
  			%itemType = getWord(%objective.equipment, 0);
  			%found = false;
  			%itemCount = $AIItemSet.getCount();
  			for (%i = 0; %i < %itemCount; %i++)
  			{
  				%item = $AIItemSet.getObject(%i);
  				if (%item.getDataBlock().getName() $= %itemType && !%item.isHidden())
  				{
					%weightDist = %client.getPathDistance(%item.getWorldBoxCenter());
					if (%weightDist > 0)
					{
						%weightInv = %item;  //set the var so the distance function will work...
	  					%found = true;
	  					break;
					}
  				}
  			}
  			if (! %found)
  				return 0;
  		}
 
		//now find the distance used for weighting the objective
		%tempDist = AIGetPathDistance(%targetPos, %weightInv.getWorldBoxCenter());
		if (%tempDist < 0)
			%tempDist = 32767;
		%distance = %weightDist + %tempDist;
 	}
   
   //see if we're within 200 m
   if (%distance < 200)
      %weight += 30;
      
   //see if we're within 90 m
   if (%distance < 90)
      %weight += 30;

   //see if we're within 45 m
   if (%distance < 45)
      %weight += 30;
      
   //see if we're within 20 m
   if (%distance < 20)
      %weight += 30;
   
   //final return, since we've made it through all the rest
   return %weight;
}

//-------------------------------

//modified escorter armor type allowed - Lagg... - 4-12-2003
function AIOEscortPlayer::weight(%this, %client, %level, %minWeight, %inventoryStr)
{
   //make sure the player is still alive!!!!!
   if (! AIClientIsAlive(%client) || ! AIClientIsAlive(%this.targetClientId))
      return 0;

   //can't escort yourself
   if (%client == %this.targetClientId)
      return 0;

	//make sure the class is appropriate
	if (%this.forceClientId <= 0 && %this.issuedByClientId != %client.controlByHuman)
	{
		%targArmor = %this.targetClientId.player.getArmorSize();
      %myArmor = %client.player.getArmorSize();
      
		if ((%targArmor $= "Light" && %myArmor !$= "Light") || (%targArmor $= "Medium" && %myArmor $= "Heavy"))
	      return 0;
	}

	//can't bump a forced client from level 1
	if (%this.forceClientId > 0 && %this.forceClientId != %client && %level == 1)
      return 0;

	//if this bot is linked to a human who has issued this command, up the weight
	if (%this.issuedByClientId == %client.controlByHuman)
	{
		//make sure we have the potential to reach the minWeight
		if (!AIODefault::QuickWeight(%this, %client, %level, %minWeight))
		{
			if ($AIWeightHumanIssuedEscort < %minWeight)
				return 0;
			else
				%weight = $AIWeightHumanIssuedEscort;
		}
		else
		{
			// calculate the default...
			%weight = AIODefault::weight(%this, %client, %level, %inventoryStr);
			if (%weight < $AIWeightHumanIssuedEscort)
				%weight = $AIWeightHumanIssuedEscort;
		}
	}
	else
	{
		//make sure we have the potential to reach the minWeight
		if (!AIODefault::QuickWeight(%this, %client, %level, %minWeight))
			return 0;

		// calculate the default...
		%weight = AIODefault::weight(%this, %client, %level, %inventoryStr);
	}

	return %weight;
}





//------------------------------

//fixed here so bots will acually use the targetting lazer - Lagg... - 4-12-2003
//modified last laze time - Lagg...
//NEEDS MORE WORK causes consol spam like you would not believe :(
//no wonder they never enabled this one.   
function AIOLazeObject::weight(%this, %client, %level, %minWeight, %inventoryStr)
{
   //make sure the player is still alive!!!!!
   if (! AIClientIsAlive(%client))
      return 0;
      
	//see if it's already being lazed
	%numTargets = ServerTargetSet.getCount();
	for (%i = 0; %i < %numTargets; %i++)
	{
		%targ = ServerTargetSet.getObject(%i);
		if (%targ.sourceObject != %client.player)
		{
			%targDist = VectorDist(%targ.getTargetPoint(), %this.targetObjectId.getWorldBoxCenter());
			if (%targDist < 10)
			{
				%this.lastLazedTime = getSimTime();
				%this.lastLazedClient = %targ.sourceObject.client;
				break;
 			}
		}
	}

   //no need to laze if the object is already destroyed
   if (!isObject(%this.targetObjectId) || %this.targetObjectId.getDamageState() $= "Destroyed")
      return 0;
	else if (%this.targetObjectId.isHidden() || %this.targetObjectId.team == %client.team)
      return 0;      
	else if (getSimTime() - %this.lastLazedTime <= 10000 && %this.lastLazedClient != %client)
		return 0;
   else
	{
	   //set the base weight
	   switch (%level)
	   {
	      case 1:
	         %weight = %this.weightLevel1;
	      case 2:
	         %weight = %this.weightLevel2;
	      case 3:
	         %weight = %this.weightLevel3;
	      default:
	         %weight = %this.weightLevel4;
	   }
   
	   //check Affinity
	   if (ClientHasAffinity(%this, %client))
	      %weight += 100;
      
		//for now, do not deviate from the current assignment to laze a target, if you don't
		//already have a targeting laser.
		%needEquipment = AINeedEquipment(%this.equipment, %client);
		if (!%needEquipment)
			%weight += 100;
		else if (!aiHumanHasControl(%client.controlByHuman, %client))
			return 0;

		//see if this client is close to the issuing client
		if (%this.issuedByClientId > 0)
		{
			if (! AIClientIsAlive(%this.issuedByClientId))
				return 0;

		   %distance = %client.getPathDistance(%this.issuedByClientId.player.getWorldBoxCenter());
			if (%distance < 0)
				%distance = 32767;

		   //see if we're within 200 m
		   if (%distance < 200)
		      %weight += 30;

		   //see if we're within 90 m
		   if (%distance < 90)
		      %weight += 30;

		   //see if we're within 45 m
		   if (%distance < 45)
		      %weight += 30;
		}

		//now, if this bot is linked to a human who has issued this command, up the weight
		if (%this.issuedByClientId == %client.controlByHuman && %weight < $AIWeightHumanIssuedCommand)
			%weight = $AIWeightHumanIssuedCommand;

		return %weight;
	}
}

function AIOLazeObject::assignClient(%this, %client)
{
   %client.objectiveTask = %client.addTask(AILazeObject);
   %client.objectiveTask.initFromObjective(%this, %client);
}

function AIOLazeObject::unassignClient(%this, %client)
{
   %client.removeTask(%client.objectiveTask);
   %client.objectiveTask = "";
}

//------------------------------


//modified client escorter - Lagg... - 4-12-2003
function AIOMortarObject::assignClient(%this, %client)
{
   %client.objectiveTask = %client.addTask(AIMortarObject);
   %client.objectiveTask.initFromObjective(%this, %client);
   
   //create the escort objective (require a targeting laser in this case...)
   %client.escort = new AIObjective(AIOEscortPlayer)
                     {
						      dataBlock = "AIObjectiveMarker";
                        weightLevel1 = $AIWeightEscortOffense[1];
                        weightLevel2 = $AIWeightEscortOffense[2];
                        description = "Escort " @ getTaggedString(%client.name);
                        targetClientId = %client;
                        offense = true;
                        equipment = "Plasma PlasmaAmmo TargetingLaser";
								buyEquipmentSet = "MediumMissileSet";
                     };
   MissionCleanup.add(%client.escort);
   $ObjectiveQ[%client.team].add(%client.escort);
}

function AIOMortarObject::unassignClient(%this, %client)
{
   //kill the escort objective
   if (%client.escort)
   {
      AIClearObjective(%client.escort);
      %client.escort.delete();
      %client.escort = "";
   }
   
   %client.removeTask(%client.objectiveTask);
   %client.objectiveTask = "";
}

//--------------------------------------------------------------------------------
//modified here so bot will continue deploying if has equip and not get bumped
//can be set at a realistic weight now, like 3400               - Lagg... 4-12-2003
//If the function ShapeBaseImageData::testInvalidDeployConditions() changes at all, those changes need to be reflected here
function AIODeployEquipment::weight(%this, %client, %level, %minWeight, %inventoryStr)
{
   //make sure the player is still alive!!!!!
   if (! AIClientIsAlive(%client))
      return 0;

	//make sure the deploy objective is valid
	if (%this.isInvalid)
		return 0;

	//first, make sure we haven't deployed too many...
 	if (%this.equipment $= "TurretOutdoorDeployable" || %this.equipment $= "TurretIndoorDeployable")
      %maxAllowed = countTurretsAllowed(%this.equipment);
   else
      %maxAllowed = $TeamDeployableMax[%this.equipment];

	if ($TeamDeployedCount[%client.team, %this.equipment] >= %maxAllowed)
		return 0;

	//now make sure there are no other items in the way...
  	InitContainerRadiusSearch(%this.location, $MinDeployableDistance, $TypeMasks::VehicleObjectType |
  	                                             $TypeMasks::MoveableObjectType |
  	                                             $TypeMasks::StaticShapeObjectType |
  	                                             $TypeMasks::TSStaticShapeObjectType | 
  	                                             $TypeMasks::ForceFieldObjectType |
  	                                             $TypeMasks::ItemObjectType | 
  	                                             $TypeMasks::PlayerObjectType | 
  	                                             $TypeMasks::TurretObjectType);
	%objSearch = containerSearchNext();

	//make sure we're not invalidating the deploy location with the client's own player object
	if (%objSearch == %client.player)
		%objSearch = containerSearchNext();

	//did we find an object which would block deploying the equipment?
	if (isObject(%objSearch))
		return 0;

 	//now run individual checks based on the equipment type...
 	if (%this.equipment $= "TurretIndoorDeployable")
 	{
 		//check if there's another turret close to the deploy location
 	   InitContainerRadiusSearch(%this.location, $TurretIndoorSpaceRadius, $TypeMasks::StaticShapeObjectType);
 	   %found = containerSearchNext();
 	   if (isObject(%found))
 	   {
 			%foundName = %found.getDataBlock().getName();
 			if ((%foundName $= TurretDeployedFloorIndoor) || (%foundName $= "TurretDeployedWallIndoor") || (%foundName $= "TurretDeployedCeilingIndoor") || (%foundName $= "TurretDeployedOutdoor"))
 				return 0;
 		}
 
 		//now see if there are too many turrets in the area...
 	   %highestDensity = 0;
 	   InitContainerRadiusSearch(%this.location, $TurretIndoorSphereRadius, $TypeMasks::StaticShapeObjectType);
 	   %found = containerSearchNext();
 	   while (isObject(%found))
 	   {
 	      %foundName = %found.getDataBlock().getName();
 	      if ((%foundName $= "TurretDeployedFloorIndoor") || (%foundName $= "TurretDeployedWallIndoor") || (%foundName $= "TurretDeployedCeilingIndoor") || (%foundName $= "TurretDeployedOutdoor"))
 	      {
 				//found one
 				%numTurretsNearby++;
 
 				%nearbyDensity = testNearbyDensity(%found, $TurretIndoorSphereRadius);
 				if (%nearbyDensity > %highestDensity)
 					%highestDensity = %nearbyDensity;     
 	      }
 			%found = containerSearchNext();
 	   }
 
 	   if (%numTurretsNearby > %highestDensity)
 	      %highestDensity = %numTurretsNearby;
 
 		//now see if the area is already saturated
 		if (%highestDensity > $TurretIndoorMaxPerSphere)
 			return 0;
 	}
 
 	else if (%this.equipment $= "TurretOutdoorDeployable")
 	{
 		//check if there's another turret close to the deploy location
 	   InitContainerRadiusSearch(%this.location, $TurretOutdoorSpaceRadius, $TypeMasks::StaticShapeObjectType);
 	   %found = containerSearchNext();
 	   if (isObject(%found))
 		{
 			%foundName = %found.getDataBlock().getName();     
 			if ((%foundName $= "TurretDeployedFloorIndoor") || (%foundName $= "TurretDeployedWallIndoor") || (%foundName $= "TurretDeployedCeilingIndoor") || (%foundName $= "TurretDeployedOutdoor"))
 				return 0;
 		}
 
 		//now see if there are too many turrets in the area...
 	   %highestDensity = 0;
 	   InitContainerRadiusSearch(%this.location, $TurretOutdoorSphereRadius, $TypeMasks::StaticShapeObjectType);
 	   %found = containerSearchNext();
 	   while (isObject(%found))
 	   {
 	      %foundName = %found.getDataBlock().getName();
 	      if ((%foundName $= "TurretDeployedFloorIndoor") || (%foundName $= "TurretDeployedWallIndoor") || (%foundName $= "TurretDeployedCeilingIndoor") || (%foundName $= "TurretDeployedOutdoor"))
 	      {
 				//found one
 				%numTurretsNearby++;
 
 				%nearbyDensity = testNearbyDensity(%found, $TurretOutdoorSphereRadius);
 				if (%nearbyDensity > %highestDensity)
 					%highestDensity = %nearbyDensity;     
 	      }
 	     %found = containerSearchNext();
 	   }
 
 		if (%numTurretsNearby > %highestDensity)
 			%highestDensity = %numTurretsNearby;
 
 		//now see if the area is already saturated
 		if (%highestDensity > $TurretOutdoorMaxPerSphere)
 			return 0;
 	}

	//check equipment requirement
	%needEquipment = AINeedEquipment(%this.equipment, %client);
	
   //if don't need equipment, see if we've past the "point of no return", and should continue regardless
 	if (! %needEquipment)
 	{
 		%needArmor = AIMustUseRegularInvStation(%this.equipment, %client);
 		%result = AIFindClosestInventory(%client, %needArmor);
 		%closestInv = getWord(%result, 0);
 		%closestDist = getWord(%result, 1);
 
 		//if we're too far from the inv to go back, or we're too close to the deploy location, force continue
 		//if (%closestDist > 50 && VectorDist(%client.player.getWorldBoxCenter(), %task.location) < 50)
                if (%closestDist > 20)
 		{
 			%weight = AIODefault::weight(%this, %client, %level, %inventoryStr);
 			if (%weight < $AIWeightContinueDeploying)
 				%weight = $AIWeightContinueDeploying;
 			return %weight;
 		}
 	}

	//if this bot is linked to a human who has issued this command, up the weight
	if (%this.issuedByClientId == %client.controlByHuman)
	{
		//make sure we have the potential to reach the minWeight
		if (!AIODefault::QuickWeight(%this, %client, %level, %minWeight))
		{
			if ($AIWeightHumanIssuedCommand < %minWeight)
				return 0;
			else
				%weight = $AIWeightHumanIssuedCommand;
		}
		else
		{
			// calculate the default...
			%weight = AIODefault::weight(%this, %client, %level, %inventoryStr);
			if (%weight < $AIWeightHumanIssuedCommand)
				%weight = $AIWeightHumanIssuedCommand;
		}
	}
	else
	{
		//make sure we have the potential to reach the minWeight
		if (!AIODefault::QuickWeight(%this, %client, %level, %minWeight))
			return 0;

		// calculate the default...
		%weight = AIODefault::weight(%this, %client, %level, %inventoryStr);
	}

	return %weight;
}

//------------------------------------------------------------------------------------------
// -----------------          new AI Objective Place Camera           ---- Lagg... 1-14-2003
// have to fix this so a repair object objective is created for the newly deployed thingy??
//rotate the objective marker, bot will place on the "Y" same as all other deploy objectives
//------------------------------------------------------------------------------------------
//Lagg... new aioPlaceCamera --------------------------------------------------- 1-14-2003
function AIOPlaceCamera::weight(%this, %client, %level, %minWeight, %inventoryStr)
{
   //make sure the player is still alive!!!!!
   if (! AIClientIsAlive(%client))
      return 0;

	//make sure the deploy objective is valid
	//if (%this.isInvalid)
		//return 0;

	//first, make sure we haven't deployed too many...
 	if (%this.equipment $= "CameraGrenade")
        %maxAllowed = $TeamDeployableMax[DeployedCamera];
        else
                return 0;
   
	if ($TeamDeployedCount[%client.team, %this.equipment] >= %maxAllowed)
		return 0;

	//now make sure there are no other items in the way...
  	  InitContainerRadiusSearch(%this.location, $MinDeployableDistance, $TypeMasks::VehicleObjectType |
  	                                               $TypeMasks::MoveableObjectType |
  	                                               $TypeMasks::StaticShapeObjectType |
  	                                               $TypeMasks::TSStaticShapeObjectType |
  	                                               $TypeMasks::ForceFieldObjectType |
  	                                               $TypeMasks::ItemObjectType |
  	                                               $TypeMasks::PlayerObjectType | $TypeMasks::TurretObjectType);                   
	%objSearch = containerSearchNext();

	//make sure we're not invalidating the deploy location with the client's own player object
	if (%objSearch == %client.player)
		%objSearch = containerSearchNext();

	//did we find an object which would block deploying the equipment?
	if (isObject(%objSearch))
		return 0;

 	

	//check equipment requirement
	%needEquipment = AINeedEquipment(%this.equipment, %client);
	
        //if don't need equipment, see if we've past the "point of no return", and should continue regardless
 	if (! %needEquipment)
 	{
 		%needArmor = AIMustUseRegularInvStation(%this.equipment, %client);
 		%result = AIFindClosestInventory(%client, %needArmor);
 		%closestInv = getWord(%result, 0);
 		%closestDist = getWord(%result, 1);
 
 		//if we're too far from the inv to go back, or we're too close to the deploy location, force continue
 		if (%closestDist > 50 && VectorDist(%client.player.getWorldBoxCenter(), %task.location) < 50)
 		{
 			%weight = AIODefault::weight(%this, %client, %level, %inventoryStr);
 			if (%weight < $AIWeightContinueDeploying)
 				%weight = $AIWeightContinueDeploying;
 			return %weight;
 		}
 	}

	//if this bot is linked to a human who has issued this command, up the weight
	if (%this.issuedByClientId == %client.controlByHuman)
	{
		//make sure we have the potential to reach the minWeight
		if (!AIODefault::QuickWeight(%this, %client, %level, %minWeight))
		{
			if ($AIWeightHumanIssuedCommand < %minWeight)
				return 0;
			else
				%weight = $AIWeightHumanIssuedCommand;
		}
		else
		{
			// calculate the default...
			%weight = AIODefault::weight(%this, %client, %level, %inventoryStr);
			if (%weight < $AIWeightHumanIssuedCommand)
				%weight = $AIWeightHumanIssuedCommand;
		}
	}
	else
	{
		//make sure we have the potential to reach the minWeight
		if (!AIODefault::QuickWeight(%this, %client, %level, %minWeight))
			return 0;

		// calculate the default...
		%weight = AIODefault::weight(%this, %client, %level, %inventoryStr);
	}

	return %weight;
}

function AIOPlaceCamera::assignClient(%this, %client)
{
   %client.objectiveTask = %client.addTask(AIPlaceCamera);
   %task = %client.objectiveTask;
   %task.initFromObjective(%this, %client);
}

function AIOPlaceCamera::unassignClient(%this, %client)
{
   %client.removeTask(%client.objectiveTask);
   %client.objectiveTask = "";
}

//------------------------------------------------------------------------------------------
// -----------------          new AI Objective Place Camera           ---- Lagg... 1-14-2003
// have to fix this so a repair object objective is created for the newly deployed thingy??
//rotate the objective marker, bot will place on the "Y" same as all other deploy objectives
//------------------------------------------------------------------------------------------

function AIPlaceCamera::initFromObjective(%task, %objective, %client)
{
	//initialize the task vars from the objective
   %task.baseWeight = %client.objectiveWeight;
   %task.location = %objective.location;
   %task.equipment = %objective.equipment;
	%task.buyEquipmentSet = %objective.buyEquipmentSet;
	%task.desiredEquipment = %objective.desiredEquipment;
	%task.issuedByClient = %objective.issuedByClientId;
	%task.chat = %objective.chat;

	//initialize other task vars
	%task.sendMsg = true;
	%task.sendMsgTime = 0;

	//use the Y-axis of the rotation as the desired direction of deployement,
	//and calculate a walk to point 3 m behind the deploy point. 
	%task.deployDirection = MatrixMulVector("0 0 0 " @ getWords(%objective.getTransform(), 3, 6), "0 1 0");
	%task.deployDirection = VectorNormalize(%task.deployDirection);
}

function AIPlaceCamera::assume(%task, %client)
{
   %task.setWeightFreq(15);
   %task.setMonitorFreq(15);
	
	%client.needEquipment = AINeedEquipment(%task.equipment, %client);
   
   //mark the current time for the buy inventory state machine
	%task.buyInvTime = getSimTime();

	%task.passes = 0;
	%task.deployAttempts = 0;
	%task.checkObstructed = false;
	%task.waitMove = 0;
}

function AIPlaceCamera::retire(%task, %client)
{
}

function AIPlaceCamera::weight(%task, %client)
{
	//update the task weight
	if (%task == %client.objectiveTask)
		%task.baseWeight = %client.objectiveWeight;

   %task.setWeight(%task.baseWeight);
}

function AIPlaceCamera::monitor(%task, %client)
{
   //first, buy the equipment
   if (%client.needEquipment)
   {
	   %task.setMonitorFreq(5);
		if (%task.equipment !$= "")
			%equipmentList = %task.equipment;
		else
			%equipmentList = %task.desiredEquipment;
      %result = AIBuyInventory(%client, %equipmentList, %task.buyEquipmentSet, %task.buyInvTime);
		if (%result $= "InProgress")
			return;
		else if (%result $= "Finished")
		{	
		   %task.setMonitorFreq(30);
         %client.needEquipment = false;
         //if we made it past the inventory buying, reset the inv time
	      %task.buyInvTime = getSimTime();
      }
      else if (%result $= "Failed")
		{
	      //if this task is the objective task, choose a new objective
	      if (%task == %client.objectiveTask)
	      {
	         AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
	      }
			return;
		}
   }

	//chat
	if (%task.sendMsg)
	{
		if (%task.sendMsgTime == 0)
			%task.sendMsgTime = getSimTime();
		else if (getSimTime() - %task.sendMsgTime > 7000)
		{
			%task.sendMsg = false;
		   if (%client.isAIControlled())
			{
				if (%task.chat !$= "")
				{
					%chatMsg = getWord(%task.chat, 0);
					%chatTemplate = getWord(%task.chat, 1);
					if (%chatTemplate !$= "")
						AIMessageThreadTemplate(%chatTemplate, %chatMsg, %client, -1);
					else
						AIMessageThread(%task.chat, %client, -1);
				}
			}
		}
	}

   //see if we're supposed to be engaging anyone...
   if (AIClientIsAlive(%client.shouldEngage))
   {
	   %hasLOS = %client.hasLOSToClient(%client.shouldEngage);
	   %losTime = %client.getClientLOSTime(%client.shouldEngage);
	   if (%hasLOS || %losTime < 1000)
         %client.setEngageTarget(%client.shouldEngage);
      else
         %client.setEngageTarget(-1);
   }
   else
      %client.setEngageTarget(-1);

	//calculate the deployFromLocation
	%factor = -1 * (3 - (%task.passes * 0.5));
   %task.deployFromLocation = VectorAdd(%task.location,VectorScale(%task.deployDirection, %factor));

	//see if we're within range of the deploy location
   %clLoc = %client.player.position;
   %distance = VectorDist(%clLoc, %task.deployFromLocation);
	%dist2D = VectorDist(%client.player.position, getWords(%task.deployFromLocation, 0, 1) SPC getWord(%client.player.position, 2));

	//set the aim when we get near the target...  this will be overwritten when we're actually trying to deploy
	if (%distance < 10 && %dist2D < 10)
      %client.aimAt(%task.location, 1000);

   if ((%client.pathDistRemaining(20) > %distance + 0.25) || %dist2D > 0.5)
	{
		%task.deployAttempts = 0;
		%task.checkObstructed = false;
		%task.waitMove = 0;
      %client.stepMove(%task.deployFromLocation, 0.25);
	   %task.setMonitorFreq(15);
		return;
	}
   
	if (%task.deployAttempts < 1 && %task.passes < 1 && !AIClientIsAlive(%client.getEngageTarget()))
	{
		//dissolve the human control link
		if (%task == %client.objectiveTask)
			aiReleaseHumanControl(%client.controlByHuman, %client);

	   %task.setMonitorFreq(3);
      %client.stop();
		if (%task.deployAttempts == 0)
			%deployPoint = %task.location;
		else
	      %deployPoint = findTurretDeployPoint(%client, %task.location, %task.deployAttempts);
      if(%deployPoint !$= "")
      {
         // we have possible point
         %task.deployAttempts++;
         %client.aimAt(%deployPoint, 2000);

			//try to place the camera
			//%client.deployPack = true;
         %client.lastThrownObject = -1;
         %client.player.throwStrength = 2;
         %client.player.use(CameraGrenade);
         
         // check if camera deployed
         if (isObject(%client.lastDeployedObject))
			{
				//see if there's a "repairObject" objective for the newly deployed thingy...
				if (%task == %client.objectiveTask)
				{
					%deployedObject = %client.lastDeployedObject;

					//search the current objective group and search for a "repair Object" task...
					%objective = %client.objective;

					//delete any previously associated "AIORepairObject" objective
					if (isObject(%objective.repairObjective))
					{
						AIClearObjective(%objective.repairObjective);
						%objective.repairObjective.delete();
						%objective.repairObjective = "";
					}

					//add the repair objective
	            %objective.repairObjective = new AIObjective(AIORepairObject)
		                              {
											      dataBlock = "AIObjectiveMarker";
		                                 weightLevel1 = %objective.weightLevel1 - 60;
		                                 weightLevel2 = 0;
		                                 description = "Repair the Deployed Camera";
													targetObjectId = %deployedObject;
													issuedByClientId = %client;
		                                 offense = false;
													defense = true;
		                                 equipment = "RepairPack";
                                                 buyEquipmentSet = "LightRepairSet";
		                              };
					%objective.repairObjective.deployed = true;
					%objective.repairObjective.setTransform(%objective.getTransform());
					%objective.repairObjective.group = %objective.group;
			      MissionCleanup.add(%objective.repairObjective);
	            $ObjectiveQ[%client.team].add(%objective.repairObjective);

					//finally, unassign the client so he'll go do something else...
			      AIUnassignClient(%client);
					Game.AIChooseGameObjective(%client);
				}

				//finished
				return;
			}
      }
	}
	else if (!%task.checkObstructed)
	{
		%task.checkObstructed = true;

	   //see if anything is in our way
	   InitContainerRadiusSearch(%task.location, 4, $TypeMasks::MoveableObjectType | $TypeMasks::VehicleObjectType |
																					                      $TypeMasks::PlayerObjectType);
	   %objSrch = containerSearchNext();
		if (%objSrch == %client.player)
		   %objSrch = containerSearchNext();
	   if (%objSrch)
			AIMessageThread("ChatMove", %client, -1);
	}
	else if (%task.waitMove < 5 && %task.passes < 1)
	{
		%task.waitMove++;

		//try another pass at deploying 
		if (%task.waitMove == 5)
		{
			%task.waitMove = 0;
			%task.passes++;
			%task.deployAttempts = 0;

			//see if we're *right* underneath the deploy point
			%deployDist2D = VectorDist(getWords(%client.player.position, 0, 1) @ "0", getWords(%task.location, 0, 1) @ "0");
			if (%deployDist2D < 0.25)
			{
				%client.pressjump();
				//%client.deployPack = true;
                                %client.player.throwStrength = 2;
	                        %client.player.use(CameraGrenade);

	         // check if pack deployed
	         //if(%client.player.getMountedImage($BackpackSlot) == 0)
				   // {
					//don't add a "repairObject" objective for ceiling turrets
					if (%task == %client.objectiveTask)
					{
						AIUnassignClient(%client);
						Game.AIChooseGameObjective(%client);
					}
				//}
			}
		}
	}
	else
	{
		//find a new assignment - and remove this one from the Queue
      if (%task == %client.objectiveTask)
		{
			//error(%client SPC "from team" SPC %client.team SPC "is invalidating objective:" SPC %client.objective SPC "UNABLE TO DEPLOY EQUIPMENT");
			%client.objective.isInvalid = false;
	      AIUnassignClient(%client);
			Game.AIChooseGameObjective(%client);
		}
	}
}

//-----------------------------------------------------------------------------------------------------
//BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - AIO
//----                                                                            --- Lagg... 4-12-2003
//-----------------------------------------------------------------------------------------------------

function AIOMissileObject::weight(%this, %client, %level, %minWeight, %inventoryStr)
{
   // if were playing CnH, check who owns this
   if (!isObject(%this.targetObjectId) || %this.targetObjectId.isHidden() || %this.targetObjectId.team == %client.team)
      return 0;      
   
   //make sure the player is still alive!!!!!
   if (! AIClientIsAlive(%client))
      return 0;

   //lets check the range on this one
   if (vectorDist(%client.Player.getWorldBoxCenter(), %this.getWorldBoxCenter()) < 50)
      return 0;
    
   //no need to attack if the object is already destroyed
   if (!isObject(%this.targetObjectId) || %this.targetObjectId.getDamageState() $= "Destroyed")
      return 0;
   else
	{
		//if this bot is linked to a human who has issued this command, up the weight
		if (%this.issuedByClientId == %client.controlByHuman)
		{
			//make sure we have the potential to reach the minWeight
			if (!AIODefault::QuickWeight(%this, %client, %level, %minWeight))
			{
				if ($AIWeightHumanIssuedCommand < %minWeight)
					return 0;
				else
					%weight = $AIWeightHumanIssuedCommand;
			}
			else
			{
				// calculate the default...
				%weight = AIODefault::weight(%this, %client, %level, %inventoryStr);
				if (%weight < $AIWeightHumanIssuedCommand)
					%weight = $AIWeightHumanIssuedCommand;
			}
		}
		else
		{
			//make sure we have the potential to reach the minWeight
			if (!AIODefault::QuickWeight(%this, %client, %level, %minWeight))
				return 0;

			// calculate the default...
			%weight = AIODefault::weight(%this, %client, %level, %inventoryStr);
		}

		return %weight;
	}
}

function AIOMissileObject::assignClient(%this, %client)
{
   %client.objectiveTask = %client.addTask(AIMissileObject);
   %client.objectiveTask.initFromObjective(%this, %client);
}

function AIOMissileObject::unassignClient(%this, %client)
{
   %client.removeTask(%client.objectiveTask);
   %client.objectiveTask = "";
}

//----------------------------------------------------------------------------------------------------
//BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - AI
//----                                                                            -- Lagg... 4-12-2003
//----------------------------------------------------------------------------------------------------

function AIMissileObject::initFromObjective(%task, %objective, %client)
{
   %task.baseWeight = %client.objectiveWeight;
   %task.targetObject = %objective.targetObjectId;
   %task.location = %objective.location;
   %task.equipment = %objective.equipment;
	%task.buyEquipmentSet = %objective.buyEquipmentSet;
	%task.desiredEquipment = %objective.desiredEquipment;
	%task.issuedByClient = %objective.issuedByClientId;

	//initialize other task vars
	%task.sendMsg = true;
	%task.sendMsgTime = 0;
}

function AIMissileObject::assume(%task, %client)
{
   %task.setWeightFreq(15);
   %task.setMonitorFreq(5);
   %client.needEquipment = AINeedEquipment(%task.equipment, %client);

	//even if we don't *need* equipemnt, see if we should buy some... 
	if (! %client.needEquipment && %task.buyEquipmentSet !$= "")
	{
		//see if we could benefit from inventory
		%needArmor = AIMustUseRegularInvStation(%task.desiredEquipment, %client);
		%result = AIFindClosestInventory(%client, %needArmor);
		%closestInv = getWord(%result, 0);
		%closestDist = getWord(%result, 1);
		if (AINeedEquipment(%task.desiredEquipment, %client) && %closestInv > 0)
		{
			//find where we are
			%clientPos = %client.player.getWorldBoxCenter();
			%objPos = %task.targetObject.getWorldBoxCenter();
			%distToObject = %client.getPathDistance(%objPos);
			
			if (%distToObject < 0 || %closestDist < %distToObject)
				%client.needEquipment = true;
		}
	}

	//mark the current time for the buy inventory state machine
	%task.buyInvTime = getSimTime();
}

function AIMissileObject::retire(%task, %client)
{
   %client.setTargetObject(-1);
}

function AIMissileObject::weight(%task, %client)
{
        if (VectorDist(%task.location, %client.Player.getWorldBoxCenter) < 41)
        {
           echo(" Too Close to missile object set baseweight (0)");
           %task.baseWeight = 0;
        }
	
	else if (%task == %client.objectiveTask)
		%task.baseWeight = %client.objectiveWeight;

   //let the monitor decide when to stop attacking
   %task.setWeight(%task.baseWeight);
}

function AIMissileObject::monitor(%task, %client)
{
   //first, buy the equipment
   if (%client.needEquipment)
   {
	   %task.setMonitorFreq(5);
		if (%task.equipment !$= "")
			%equipmentList = %task.equipment;
		else
			%equipmentList = %task.desiredEquipment;
      %result = AIBuyInventory(%client, %equipmentList, %task.buyEquipmentSet, %task.buyInvTime);
		if (%result $= "InProgress")
			return;
		else if (%result $= "Finished")
		{
		   %task.setMonitorFreq(15);
			%client.needEquipment = false;
		}
		else if (%result $= "Failed")
		{
	      //if this task is the objective task, choose a new objective
	      if (%task == %client.objectiveTask)
	      {
	         AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
	      }
			return;
		}
   }
	//if we made it past the inventory buying, reset the inv time
	%task.buyInvTime = getSimTime();
   
	//chat
	if (%task.sendMsg)
	{
		if (%task.sendMsgTime == 0)
			%task.sendMsgTime = getSimTime();
		else if (getSimTime() - %task.sendMsgTime > 7000)
		{
			%task.sendMsg = false;
		   if (%client.isAIControlled())
			{
				if (%task.chat !$= "")
				{
					%chatMsg = getWord(%task.chat, 0);
					%chatTemplate = getWord(%task.chat, 1);
					if (%chatTemplate !$= "")
						AIMessageThreadTemplate(%chatTemplate, %chatMsg, %client, -1);
					else
						AIMessageThread(%task.chat, %client, -1);
				}
				else if (%task.targetObject > 0)
				{
					%type = %task.targetObject.getDataBlock().getName();
					if (%type $= "GeneratorLarge")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackGenerator", %client, -1);
					else if (%type $= "SensorLargePulse")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackSensors", %client, -1);
					else if (%type $= "SensorMediumPulse")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackSensors", %client, -1);
					else if (%type $= "TurretBaseLarge")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackTurrets", %client, -1);
					else if (%type $= "StationVehicle")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackVehicle", %client, -1);
				}
			}
		}
	}

   //set the target object
   if (isObject(%task.targetObject) && %task.targetObject.getDamageState() !$= "Destroyed")
   {
      //make sure we still have equipment
		%client.needEquipment = AINeedEquipment(%task.equipment, %client);
      if (%client.needEquipment)
      {
         //if this task is the objective task, choose a new objective
         if (%task == %client.objectiveTask)
			{
            AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
				return;
			}
      }

      //move to LOS location to objective marker(not to target)
      //(that makes the LOS location adjustable!)
      %firePos = %client.getLOSLocation(%task.location, 50, 290);
      %client.stepMove(%firePos);
      //check for LOS
      %missileLOS = "false";
      %mask = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::TSStaticShapeObjectType;
      %missileLOS = !containerRayCast(%client.player.getWorldBoxCenter(), %task.location, %mask, 0);
      %inRange = %client.getPathDistance(%task.location);
      
      if ((%inRange > 49) && (%inRange < 291) && %missileLOS)
      {
          %client.setTargetObject(%task.targetObject, 300, "Missile");
	      //dissolve the human control link
	      if (%task == %client.objectiveTask)
             {
	            aiReleaseHumanControl(%client.controlByHuman, %client);
                %client.stop();
             }
      }
      else if (%inRange < 50)
      {     
         //if this task is the objective task, choose a new objective
         if (%task == %client.objectiveTask)
         {
            %client.setTargetObject(-1);
            %client.stop();
            AIUnassignClient(%client);
            Game.AIChooseGameObjective(%client);
         }
      }     
   }
   else
   {     
      //if this task is the objective task, choose a new objective
      if (%task == %client.objectiveTask)
      {
         %client.setTargetObject(-1);
         %client.stop();
         AIUnassignClient(%client);
         Game.AIChooseGameObjective(%client);
      }
   }
}

//-----------------------------------------------------------------------------------------------------
//BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - AIO
//place objective marker in spot you want bot to stand and destroy for sentry turrets and hard to
//reach spots. basically same as attackobject --------------------------------------- Lagg... 3-26-2003
//-----------------------------------------------------------------------------------------------------

function AIODestroyObject::weight(%this, %client, %level, %minWeight, %inventoryStr)
{
   // if were playing CnH, check who owns this
   if (!isObject(%this.targetObjectId) || %this.targetObjectId.isHidden() || %this.targetObjectId.team == %client.team)
      return 0;      
   
   //make sure the player is still alive!!!!!
   if (! AIClientIsAlive(%client))
      return 0;
      
   //no need to attack if the object is already destroyed
   if (!isObject(%this.targetObjectId) || %this.targetObjectId.getDamageState() $= "Destroyed")
      return 0;
   else
	{
	   //set the base weight
	   switch (%level)
	   {
	      case 1:
	         %weight = %this.weightLevel1;
	      case 2:
	         %weight = %this.weightLevel2;
	      case 3:
	         %weight = %this.weightLevel3;
	      case 4:
	         %weight = %this.weightLevel4;
	   }
   
	   //check Affinity
	   if (ClientHasAffinity(%this, %client))
	      %weight += 100;
      
		//for now, do not deviate from the current assignment to laze a target, if you don't
		//already have a targeting laser.
                %hasPlasma = (%client.player.getInventory("Plasma") > 0) && (%client.player.getInventory("PlasmaAmmo") > 0);
		%needEquipment = AINeedEquipment(%this.equipment, %client);
                if (%hasPlasma)
                        %needEquipment = false;
		if (!%needEquipment)
			%weight += 100;
		else if (!aiHumanHasControl(%client.controlByHuman, %client))
			return 0;

		//see if this client is close to the issuing client
		if (%this.issuedByClientId > 0)
		{
			if (! AIClientIsAlive(%this.issuedByClientId))
				return 0;

		   %distance = %client.getPathDistance(%this.issuedByClientId.player.getWorldBoxCenter());
			if (%distance < 0)
				%distance = 32767;

		   //see if we're within 200 m
		   if (%distance < 200)
		      %weight += 30;

		   //see if we're within 90 m
		   if (%distance < 90)
		      %weight += 30;

		   //see if we're within 45 m
		   if (%distance < 45)
		      %weight += 30;
		}

		//now, if this bot is linked to a human who has issued this command, up the weight
		if (%this.issuedByClientId == %client.controlByHuman && %weight < $AIWeightHumanIssuedCommand)
			%weight = $AIWeightHumanIssuedCommand;

		return %weight;
	}
}

function AIODestroyObject::assignClient(%this, %client)
{
   %client.objectiveTask = %client.addTask(AIdestroyObject);
   %client.objectiveTask.initFromObjective(%this, %client);
}

function AIODestroyObject::unassignClient(%this, %client)
{
   %client.removeTask(%client.objectiveTask);
   %client.objectiveTask = "";
}

//----------------------------------------------------------------------------------------------------
//BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - BETA - AI
//place objective marker in spot you want bot to stand and destroy for sentry turrets and hard to
//reach spots. basically same as attackobject.                   ------------------- Lagg... 3-26-2003
//----------------------------------------------------------------------------------------------------

function AIDestroyObject::initFromObjective(%task, %objective, %client)
{
   %task.baseWeight = %client.objectiveWeight;
   %task.targetObject = %objective.targetObjectId;
   %task.equipment = %objective.equipment;
	%task.buyEquipmentSet = %objective.buyEquipmentSet;
	%task.desiredEquipment = %objective.desiredEquipment;
	%task.issuedByClient = %objective.issuedByClientId;
        %task.location = %objective.location;

	//initialize other task vars
	%task.sendMsg = true;
	%task.sendMsgTime = 0;
}

function AIDestroyObject::assume(%task, %client)
{
   %task.setWeightFreq(15);
   %task.setMonitorFreq(5);
   %client.needEquipment = AINeedEquipment(%task.equipment, %client);

	//even if we don't *need* equipemnt, see if we should buy some... 
	if (! %client.needEquipment && %task.buyEquipmentSet !$= "")
	{
		//see if we could benefit from inventory
		%needArmor = AIMustUseRegularInvStation(%task.desiredEquipment, %client);
		%result = AIFindClosestInventory(%client, %needArmor);
		%closestInv = getWord(%result, 0);
		%closestDist = getWord(%result, 1);
		if (AINeedEquipment(%task.desiredEquipment, %client) && %closestInv > 0)
		{
			//find where we are
			%clientPos = %client.player.getWorldBoxCenter();
			%objPos = %task.targetObject.getWorldBoxCenter();
			%distToObject = %client.getPathDistance(%objPos);
			
			if (%distToObject < 0 || %closestDist < %distToObject)
				%client.needEquipment = true;
		}
	}

	//mark the current time for the buy inventory state machine
	%task.buyInvTime = getSimTime();
}

function AIDestroyObject::retire(%task, %client)
{
   %client.setTargetObject(-1);
}

function AIDestroyObject::weight(%task, %client)
{
	//update the task weight
	if (%task == %client.objectiveTask)
		%task.baseWeight = %client.objectiveWeight;

   //let the monitor decide when to stop attacking
   %task.setWeight(%task.baseWeight);
}

function AIDestroyObject::monitor(%task, %client)
{
   //first, buy the equipment - if we really really need some :) - Lagg... - 4-6-2003
   %hasPlasma = (%client.player.getInventory("Plasma") > 0) && (%client.player.getInventory("PlasmaAmmo") > 0);
   if (%client.needEquipment && !%hasPlasma)
   {
	   %task.setMonitorFreq(5);
		if (%task.equipment !$= "")
			%equipmentList = %task.equipment;
		else
			%equipmentList = %task.desiredEquipment;
      %result = AIBuyInventory(%client, %equipmentList, %task.buyEquipmentSet, %task.buyInvTime);
		if (%result $= "InProgress")
			return;
		else if (%result $= "Finished")
		{
		   %task.setMonitorFreq(15);
			%client.needEquipment = false;
		}
		else if (%result $= "Failed")
		{
	      //if this task is the objective task, choose a new objective
	      if (%task == %client.objectiveTask)
	      {
	         AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
	      }
			return;
		}
   }
	//if we made it past the inventory buying, reset the inv time
	%task.buyInvTime = getSimTime();
   
	//chat
	if (%task.sendMsg)
	{
		if (%task.sendMsgTime == 0)
			%task.sendMsgTime = getSimTime();
		else if (getSimTime() - %task.sendMsgTime > 7000)
		{
			%task.sendMsg = false;
		   if (%client.isAIControlled())
			{
				if (%task.chat !$= "")
				{
					%chatMsg = getWord(%task.chat, 0);
					%chatTemplate = getWord(%task.chat, 1);
					if (%chatTemplate !$= "")
						AIMessageThreadTemplate(%chatTemplate, %chatMsg, %client, -1);
					else
						AIMessageThread(%task.chat, %client, -1);
				}
				else if (%task.targetObject > 0)
				{
					%type = %task.targetObject.getDataBlock().getName();
					if (%type $= "GeneratorLarge")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackGenerator", %client, -1);
					else if (%type $= "SensorLargePulse")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackSensors", %client, -1);
					else if (%type $= "SensorMediumPulse")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackSensors", %client, -1);
					else if (%type $= "TurretBaseLarge")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackTurrets", %client, -1);
					else if (%type $= "StationVehicle")
						AIMessageThreadTemplate("AttackBase", "ChatSelfAttackVehicle", %client, -1);
				}
			}
		}
	}

   //set the target object
   %outOfStuff = (AIAttackOutofAmmo(%client));
   if (isObject(%task.targetObject) && %task.targetObject.getDamageState() !$= "Destroyed" && !%outOfStuff)
   {
      %targetLOS = "false";
      %mask = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType;
      %targetLOS = !containerRayCast(%client.player.getWorldBoxCenter(), %task.targetObject.getWorldBoxCenter(), %mask, 0);
      if (%client.getStepStatus() $= "Finished" && %targetLOS)
	            %client.setTargetObject(%task.targetObject, 40, "Destroy");
      else
      {
          %client.setTargetObject(-1);
          %client.stepMove(%task.location);
      } 
   }
   else
   {
      %client.setTargetObject(-1);
      //%client.stop();
      
      //if this task is the objective task, choose a new objective
      if (%task == %client.objectiveTask)
      {
         AIUnassignClient(%client);
         Game.AIChooseGameObjective(%client);
      }
   }
}

//-------------------------------------------------------------------------------------------- AITouchObject ---
//ramdom set to go for flag/flipflop -                                                     - Lagg... - 4-14-2003

function AITouchObject::initFromObjective(%task, %objective, %client)
{
   %task.baseWeight = %client.objectiveWeight;
   %task.targetObject = %objective.targetObjectId;
	%task.mode = %objective.mode;
        %task.equipment = %objective.equipment;
	%task.buyEquipmentSet = %objective.buyEquipmentSet;
	%task.desiredEquipment = %objective.desiredEquipment;
	%task.issuedByClient = %objective.issuedByClientId;

	%task.sendMsgTime = 0;
	if (%task.mode $= "FlagGrab")
		%task.sendMsg = true;
	else
		%task.sendMsg = false;
	if (%objective.mode $= "FlagCapture")
		%task.location = %objective.location;
	else if(%objective.mode $= "TouchFlipFlop" || %task.mode $= "FlagGrab")
        {
              %task.location = %objective.location;
              //pick a random set based on armor...
	      %randNum = getRandom();
	      if (%randNum < 0.2)
              {
                    %task.desiredEquipment = "SensorJammerPack";
                    %task.buyEquipmentSet = "HeavyEnergySet";
              }
	      else if (%randNum < 0.4)
              {
                    %task.desiredEquipment = "SensorJammerPack";
                    %task.buyEquipmentSet = "LightSensorJammer";
              } 
	      else if (%randNum < 0.6)
              {
                    %task.desiredEquipment = "CloakingPack";
                    %task.buyEquipmentSet = "LightCloakSet";
              }
              else if (%randNum < 0.8)
              {
                    %task.desiredEquipment = "ShieldPack";
                    %task.buyEquipmentSet = "HeavyShieldSet";
              }
              else
              {
                    %task.desiredEquipment = "EnergyPack";
                    %task.buyEquipmentSet = "LightEnergyDefault";
              }
        }


   else
		%task.location = "";
   
}

//--------------------------------------------------------------------------------

function AITouchObject::monitor(%task, %client)
{
    //%client.needEquipment = AINeedEquipment(%task.equipment, %client);

	//even if we do *need* equipemnt, see if we are too far to go back - Lagg... 
	if (%client.needEquipment && (%task.mode $= "FlagGrab" || %task.mode $= "TouchFlipFlop") && %task.buyEquipmentSet !$= "")
	{
		//see if we could benefit from inventory
		%needArmor = AIMustUseRegularInvStation(%task.desiredEquipment, %client);
		%result = AIFindClosestInventory(%client, %needArmor);
		%closestInv = getWord(%result, 0);
		%closestDist = getWord(%result, 1) + 400;
		if (AINeedEquipment(%task.desiredEquipment, %client) && %closestInv > 0)
		{
			//find where we are
			%clientPos = %client.player.getWorldBoxCenter();
			%distToObject = vectorDist(%clientPos, %task.location);
			if (%distToObject < 0 || %closestDist > %distToObject)
				%client.needEquipment = false;
		}
	}
   //first, buy the equipment
   if (%client.needEquipment)
   {
	   %task.setMonitorFreq(5);
		if (%task.equipment !$= "")
			%equipmentList = %task.equipment;
		else
			%equipmentList = %task.desiredEquipment;
      %result = AIBuyInventory(%client, %equipmentList, %task.buyEquipmentSet, %task.buyInvTime);
		if (%result $= "InProgress")
			return;
		else if (%result $= "Finished")
		{
		   %task.setMonitorFreq(15);
			%client.needEquipment = false;
		}
		else if (%result $= "Failed")
		{
	      //if this task is the objective task, choose a new objective
	      if (%task == %client.objectiveTask)
	      {
	         AIUnassignClient(%client);
	         Game.AIChooseGameObjective(%client);
	      }
			return;
		}
   }
	//if we made it past the inventory buying, reset the inv time
	%task.buyInvTime = getSimTime();

	//chat
	if (%task.sendMsg)
	{
		if (%task.sendMsgTime == 0)
			%task.sendMsgTime = getSimTime();
		else if (getSimTime() - %task.sendMsgTime > 7000)
		{
			%task.sendMsg = false;
		   if (%client.isAIControlled())
			{
				if (%task.mode $= "FlagGrab")
					AIMessageThreadTemplate("AttackBase", "ChatSelfAttackFlag", %client, -1);
			}
		}
	}

   //keep updating the position, in case the flag is flying through the air...
	if (%task.location !$= "")
		%touchPos = %task.location;
	else
	   %touchPos = %task.targetObject.getWorldBoxCenter();
      
   //see if we need to engage a new target
   %engageTarget = %client.getEngageTarget();
   if (!AIClientIsAlive(%engageTarget) && %task.engageTarget > 0)
      %client.setEngageTarget(%task.engageTarget);
   
   //else see if we should abandon the engagement
   else if (AIClientIsAlive(%engageTarget))
   {
      %myPos = %client.player.getWorldBoxCenter();
      %testPos = %engageTarget.player.getWorldBoxCenter();
      %distance = %client.getPathDistance(%testPos);
      if (%distance < 0 || %distance > 70)
         %client.setEngageTarget(-1);
   }

	//see if we have completed our objective
   if (%task == %client.objectiveTask)
   {
		%completed = false;
		switch$ (%task.mode)
		{
	      case "TouchFlipFlop":
	         if (%task.targetObject.team == %client.team)
					%completed = true;
	      case "FlagGrab":
				if (!%task.targetObject.isHome)
					%completed = true;
	      case "FlagDropped":
				if ((%task.targetObject.isHome) || (%task.targetObject.carrier !$= ""))
					%completed = true;
	      case "FlagCapture":
				if (%task.targetObject.carrier != %client.player)
					%completed = true;
		}
		if (%completed)
		{
	      AIUnassignClient(%client);
	      Game.AIChooseGameObjective(%client);
			return;
		}
	}

	if (%task.mode $= "FlagCapture")
	{
		%homeFlag = $AITeamFlag[%client.team];

		//if we're within range of the flag's home position, and the flag isn't home, start idling...
		if (VectorDist(%client.player.position, %touchPos) < 40 && !%homeFlag.isHome)
		{
	   	if (%client.getStepName() !$= "AIStepIdlePatrol")
				%client.stepIdle(%touchPos);
		}
		else
		   %client.stepMove(%touchPos, 0.25);
	}
	else
	   %client.stepMove(%touchPos, 0.25);

	if (VectorDist(%client.player.position, %touchPos) < 10)
	{
		//dissolve the human control link
		if (%task == %client.objectiveTask)
		{
			if (aiHumanHasControl(%task.issuedByClient, %client))
			{
				aiReleaseHumanControl(%client.controlByHuman, %client);

				//should re-evaluate the current objective weight
				%inventoryStr = AIFindClosestInventories(%client);
				%client.objectiveWeight = %client.objective.weight(%client, %client.objectiveLevel, 0, %inventoryStr);
			}
		}
	}

   //see if we're supposed to be engaging anyone...
   if (!AIClientIsAlive(%client.getEngageTarget()) && AIClientIsAlive(%client.shouldEngage))
      %client.setEngageTarget(%client.shouldEngage);
}

//------------------------------




