//------------------------------------------------------------------------------
// Capto Lamia is a to thank for this one --------------------------------------
//Missile.set fix for Turrets so AI throws flares
//function MissileBarrelLarge::onFire(%data,%obj,%slot)
//{
//   Parent::onFire(%data,%obj,%slot);//taken out causes errors with ffs - Lagg...
//   %p = %obj.lastProjectile;
//   MissileSet.add(%p);
//}

package ColdasIceSupport {

//Lets make sure they avoid mortar turret projectiles
function MortarBarrelLarge::onFire(%data,%obj,%slot)
{
   Parent::onFire(%data,%obj,%slot);
   %p = %obj.lastProjectile;
   AIGrenadeThrown(%p);
}

//Lets make sure they attempt to avoid plasma turret projectiles
function PlasmaBarrelLarge::onFire(%data,%obj,%slot)
{
   Parent::onFire(%data,%obj,%slot);
   %p = %obj.lastProjectile;
   AIGrenadeThrown(%p);
}

function TurretData::selectTarget(%this, %turret)
{
   %turretTarg = %turret.getTarget();
   if(%turretTarg == -1)
      return;

   // if the turret isn't on a team, don't fire at anyone
   if(getTargetSensorGroup(%turretTarg) == 0)
   {
      %turret.clearTarget();
      return;
   }

   // stop firing if turret is disabled or if it needs power and isn't powered
   if((!%turret.isPowered()) && (!%turret.needsNoPower))
   {
      %turret.clearTarget();
      return;
   }

   %TargetSearchMask = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::TurretObjectType | $TypeMasks::SensorObjectType;

   %attackRadius = %turret.getMountedImage(0).attackRadius;

   InitContainerRadiusSearch(%turret.getMuzzlePoint(0),
                             %attackRadius,
                             %TargetSearchMask);

   while ((%potentialTarget = ContainerSearchNext()) != 0)
   {
      %potTargTarg = %potentialTarget.getTarget();
      if (%turret.isValidTarget(%potentialTarget) && (getTargetSensorGroup(%turretTarg) != getTargetSensorGroup(%potTargTarg)))
      {
         %turret.setTargetObject(%potentialTarget);
         return;
      }
   }
} 

//---------------------------------------------------------------------------
//We have to fix flag for CTF functions on ice - Lagg...
function Flag::onEnterLiquid(%data, %obj, %coverage, %type)
{
    if(%type > 3)  // 1-3 are water, 4-6 is lava and 7 is quicksand
    {
        //error("flag("@%obj@") is in liquid type" SPC %type);
        //game.schedule(3000, flagReturn, %obj);//taken out for ice functions - Lagg...
    }
}

function DefaultGame::testTurretKill(%game, %implement)
{
   if (isObject(%implement))//added to fix deployable turret spam - Lagg...
   {
       if(%implement == 0)
          return false;
       else     
          return (%implement.getClassName() $= "Turret");
   }
   else
       echo("fixed a consol error 'test turret kill' - Lagg... :)");
}

function DefaultGame::onClientDamaged(%game, %clVictim, %clAttacker, %damageType, %sourceObject)
{ 
   //set the vars if it was a turret
   if (isObject(%sourceObject))
   {
      %sourceClassType = %sourceObject.getDataBlock().getClassName();
      %sourceType = %sourceObject.getDataBlock().getName();
   }
   if (%sourceClassType $= "TurretData")
   {
      // jff: are there special turret types which makes this needed?   
      // tinman:  yes, we don't want bots stopping to fire on the big outdoor turrets, which they
      // will just get mowed down.  deployables only.
      if (%sourceType $= "TurretDeployedFloorIndoor" || %sourceType $= "TurretDeployedWallIndoor" ||
               %sourceType $= "TurretDeployedCeilingIndoor" || %sourceType $= "TurretDeployedOutdoor")
      {
         %clVictim.lastDamageTurretTime = getSimTime();
         %clVictim.lastDamageTurret = %sourceObject;
      }
   
      %turretAttacker = %sourceObject.getControllingClient();
      // should get a damagae message from friendly fire turrets also
       if(%turretAttacker && %turretAttacker != %clVictim && %turretAttacker.team == %clVictim.team)
       {   
          if (%game.numTeams > 1 && %turretAttacker.player.causedRecentDamage != %clVictim.player)    //is a teamgame & player just damaged a teammate
          {
                %turretAttacker.player.causedRecentDamage = %clVictim.player;
             %turretAttacker.player.schedule(1000, "causedRecentDamage", "");   //allow friendly fire message every x ms
             %game.friendlyFireMessage(%clVictim, %turretAttacker);          
          }        
       }
   }
   else if (%sourceClassType $= "PlayerData")
   {
      //now see if both were on the same team
      if(%clAttacker && %clAttacker != %clVictim && %clVictim.team == %clAttacker.team)
      {   
         if (%game.numTeams > 1 && %clAttacker.player.causedRecentDamage != %clVictim.player)    //is a teamgame & player just damaged a teammate
         {
               %clAttacker.player.causedRecentDamage = %clVictim.player;
            %clAttacker.player.schedule(1000, "causedRecentDamage", "");   //allow friendly fire message every x ms
            %game.friendlyFireMessage(%clVictim, %clAttacker);          
         }        
      }
      if (%clAttacker && %clAttacker != %clVictim)
      {
         %clVictim.lastDamageTime = getSimTime();
         %clVictim.lastDamageClient = %clAttacker;
         if (%clVictim.isAIControlled())
            %clVictim.clientDetected(%clAttacker);
      }   
   }

   //call the game specific AI routines...
   if (isObject(%clVictim) && %clVictim.isAIControlled())
      %game.onAIDamaged(%clVictim, %clAttacker, %damageType, %sourceObject);
   if (isObject(%clAttacker) && %clAttacker.isAIControlled())
      %game.onAIFriendlyFire(%clVictim, %clAttacker, %damageType, %sourceObject);
}
//-------------------------------------------------------------------------------------------
//spamerrors fixes ---------------------------------------------------
function CTFGame::onAIDamaged(%game, %clVictim, %clAttacker, %damageType, %implement)
{
   if (%clAttacker && %clAttacker != %clVictim && %clAttacker.team == %clVictim.team && aiClientIsAlive(%clVictim))
   {
	   schedule(250, %clVictim, "AIPlayAnimSound", %clVictim, %clAttacker.player.getWorldBoxCenter(), "wrn.watchit", -1, -1, 0);
      
      //clear the "lastDamageClient" tag so we don't turn on teammates...  unless it's uberbob!
      %clVictim.lastDamageClient = -1;
   }
}
function stopRepairing(%player)
{
   if (!isObject(%player))
   {
      echo("fixed a consol error 'stop repairing' - Lagg... :)");
      return;
   }
   // %player = the player who was using the repair pack

   if(%player.selfRepairing)
   {
      // there is no projectile for self-repairing
      %player.setRepairRate(%player.getRepairRate() - %player.repairingRate);
      %player.selfRepairing = false;
   }
   else if(%player.repairing > 0)
   {
      // player was repairing something else
      //if(%player.repairing.beingRepaired > 0)
      //{
         // don't decrement this stuff if it's already at 0 -- though it shouldn't be
         //%player.repairing.beingRepaired--;
         %player.repairing.setRepairRate(%player.repairing.getRepairRate() - %player.repairingRate);
      //}
      if(%player.repairProjectile > 0)
      {
         // is there a repair projectile? delete it
         %player.repairProjectile.delete();
         %player.repairProjectile = 0;
      }
   }
   %player.repairing = 0;
   %player.repairingRate = 0;
   %player.setImageTrigger($WeaponSlot, false);
   %player.setImageLoaded($WeaponSlot, false);
}
};
