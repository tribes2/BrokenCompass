datablock StaticShapeData(faceBox){
   catagory = "MISC";
   shapeFile = "faceBox.dts";
   alwaysAmbient = true;
   isInvincible = true;
};

datablock TriggerData(faceDeathTrigger){
   tickPeriodMS =  1000;
};

function faceBox::onAdd(%this, %obj){
   Parent::onAdd(%this, %obj);
   
   if(!isEventPending($faceEvent)){
      faceFlagReset();
   }
   
}

function faceDeathTrigger::onEnterTrigger(%data, %trigger, %player){
	%player.damage(0, %player.getPosition(), 100, $DamageType::Suicide);
}

function faceDeathTrigger::onleaveTrigger(%data, %trigger, %player){
	return;
}

function faceDeathTrigger::onTickTrigger(%data, %trig){
	return;
}

function faceFlagReset(){
	if(Game.class $= "CTFGame" || Game.class $= "LCTFGame" || Game.class $= "SCtFGame" || Game.class $= "PracticeCTFGame"){
		if(isObject($TeamFlag[1]) && isObject($TeamFlag[2])){
			%z1 = getWords($TeamFlag[1].getPosition(),2);
			%z2 = getWords($TeamFlag[2].getPosition(),2);
			if(%z1 < 1700){
				Game.flagReturn($TeamFlag[1]);
			}
			if(%z2 < 1700){
				Game.flagReturn($TeamFlag[2]);
			}
		}
		if(isObject(mapStartObj)){
			$faceEvent = schedule(1000, 0, "faceFlagReset");
		}
	}
}


package lctfDelete{
   //AutoRemove assets, sensors, and turrets from non-LT maps
   function deleteNonLCTFObjects()
   {
      %c = 0;
      InitContainerRadiusSearch("0 0 0", 9999, $TypeMasks::ItemObjectType |
      $TypeMasks::TurretObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StaticShapeObjectType); //For FF: $TypeMasks::ForceFieldObjectType
      while ((%obj = containerSearchNext()) != 0)
      {
         if(%obj.Datablock !$= "flag" && 
         %obj.Datablock !$= "RepairKit" && 
         %obj.Datablock !$= "RepairPatch" && 
         %obj.Datablock !$= "ExteriorFlagStand" && 
         %obj.Datablock !$= "InteriorFlagStand" && 
         %obj.Datablock !$= "NexusBase" &&
         %obj.dontDelete != 1) //Dont delete these...
         {
            %deleteList[%c] = %obj;
            %c++;
         }
      }
      for(%i = 0; %i  < %c; %i++)
      {
          %deleteList[%i].delete();
      }

      //Delete all ForceField PhysicalZones (PZones)
      // if(isObject(PZones))
      //    PZones.schedule(1500,"delete");
   }   
   
};
if(!isActivePackage(lctfDelete))
      activatePackage(lctfDelete);