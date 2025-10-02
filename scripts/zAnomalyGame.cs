//Version 1.0

$DamageType::Dark  = 201;
$DamageTypeText[$DamageType::Dark]  = 'Dark';
$Anomaly::darkWeaponBonus = 200;//bonus points too the team that fires the dark weapon 
$Anomaly::dkwUnlockTimeMin = 30;// how long untill the dark weapon is unlocked
$Anomaly::editMode = 0;// stops the main loop form starting to the map can be safely edited

if($Anomaly::editMode){ 
   autoExec("scripts/zAnomalyGame.cs",0,0);
}

$DeathMessageSelfKill[$DamageType::Dark, 0] = '\c0%1 kills %2self with a dark weapon.';
$DeathMessageSelfKill[$DamageType::Dark, 1] = '\c0%1 kills %2self with a dark weapon.';
$DeathMessageSelfKill[$DamageType::Dark, 2] = '\c0%1 kills %2self with a dark weapon.';
$DeathMessageSelfKill[$DamageType::Dark, 3] = '\c0%1 kills %2self with a dark weapon.';
$DeathMessageSelfKill[$DamageType::Dark, 4] = '\c0%1 kills %2self with a dark weapon.';

$DeathMessageTeamKill[$DamageType::Dark, 0] = '\c0%4 kill TEAMMATE %1 with a dark weapon.';

$DeathMessage[$DamageType::Dark, 0] = '\c0%4 kills %1 with dark weapon';
$DeathMessage[$DamageType::Dark, 1] = '\c0%4 kills %1 with dark weapon';
$DeathMessage[$DamageType::Dark, 2] = '\c0%4 kills %1 with dark weapon';
$DeathMessage[$DamageType::Dark, 3] = '\c0%4 kills %1 with dark weapon';
$DeathMessage[$DamageType::Dark, 4] = '\c0%4 kills %1 with dark weapon';

function SimObject::setPosition(%obj, %pos){
     %obj.setTransform(%pos SPC getWords(%obj.getTransform(), 3, 6));
}

function darkWpnDmg(){
   // // note damage scale for armor is handeld in radius Explosion is why its 1
   LightPlayerDamageProfile.damageScale[$DamageType::Dark] = 1;
   MediumPlayerDamageProfile.damageScale[$DamageType::Dark] = 1;
   HeavyPlayerDamageProfile.damageScale[$DamageType::Dark] = 1;
   
   ShrikeDamageProfile.damageScale[$DamageType::Dark] = 1.25;
   ShrikeDamageProfile.shieldDamageScale[$DamageType::Dark] = 1.5;
   BomberDamageProfile.damageScale[$DamageType::Dark] = 1;
   BomberDamageProfile.shieldDamageScale[$DamageType::Dark] = 1;
   HavocDamageProfile.damageScale[$DamageType::Dark] = 1;
   HavocDamageProfile.shieldDamageScale[$DamageType::Dark] = 1;
   WildcatDamageProfile.damageScale[$DamageType::Dark] = 1.25;
   WildcatDamageProfile.shieldDamageScale[$DamageType::Dark] = 2.5;
   TankDamageProfile.damageScale[$DamageType::Dark] = 1;
   TankDamageProfile.shieldDamageScale[$DamageType::Dark] = 0.8;
   MPBDamageProfile.damageScale[$DamageType::Dark] = 1;
   MPBDamageProfile.shieldDamageScale[$DamageType::Dark] = 0.8;
   TurretDamageProfile.damageScale[$DamageType::Dark] = 1.1;
   TurretDamageProfile.shieldDamageScale[$DamageType::Dark] = 1;
   StaticShapeDamageProfile.damageScale[$DamageType::Dark] = 1.15;
   StaticShapeDamageProfile.shieldDamageScale[$DamageType::Dark] = 1;
////////////////////////////////////////////////////////////////////////////////      
}darkWpnDmg();
datablock ParticleData(RedChargedParticle){
   windCoefficient      = 0.0;
   dragCoefficient      = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 10000;
   lifetimeVarianceMS   = 000;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 50.0;
   textureName          = "Special/crescent4";
   colors[0]     = "1.0 0.0 0.0 0.0";  // 0 0.3 0.9 1.0
   colors[1]     = "1.0 0.0 0.0 1.0";  // 0.0 0.3 0.9 0.2
   colors[2]     = "0.0 0.0 0.0 0.0";  // 0 0.3 0.9 0.0
   sizes[0]      = 30.0;
   sizes[1]      = 30.0;
   sizes[2]      = 30.0;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(RedChargedEmitter){
   ejectionPeriodMS = 15;
   periodVarianceMS = 0;
   ejectionVelocity = 1.01;
   velocityVariance = 0.0;
   ejectionOffset   = 25.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 1;
   particles = "RedChargedParticle";
};

datablock ParticleData(BlueChargedParticle){
   windCoefficient      = 0.0;
   dragCoefficient      = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 10000;
   lifetimeVarianceMS   = 000;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 50.0;
   textureName          = "Special/crescent4";
   colors[0]     = "0.0 0.0 1.0 0.0";  // 0 0.3 0.9 1.0
   colors[1]     = "0.0 0.0 1.0 1.0";  // 0.0 0.3 0.9 0.2
   colors[2]     = "0.0 0.0 0.0 0.0";  // 0 0.3 0.9 0.0
   sizes[0]      = 30.0;
   sizes[1]      = 30.0;
   sizes[2]      = 30.0;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BlueChargedEmitter){
   ejectionPeriodMS = 15;
   periodVarianceMS = 0;
   ejectionVelocity = 1.01;
   velocityVariance = 0.0;
   ejectionOffset   = 25.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 1;
   particles = "BlueChargedParticle";
};

datablock ParticleData(DarkParticle){
   windCoefficient      = 0.0;
   dragCoefficient      = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = -3;
   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 000;
   useInvAlpha          = true;
   spinRandomMin        = -90.0;
   spinRandomMax        = 50.0;
   textureName          = "particleTest";
   colors[0]     = "0.0 0.0 0.0 0.0";  // 0 0.3 0.9 1.0
   colors[1]     = "0.0 0.0 0.0 1.0";  // 0.0 0.3 0.9 0.2
   colors[2]     = "0.0 0.0 0.0 0.0";  // 0 0.3 0.9 0.0
   sizes[0]      = 10.0;
   sizes[1]      = 10.0;
   sizes[2]      = 4.0;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(DarkEmitter){
   ejectionPeriodMS = 6;
   periodVarianceMS = 0;
   ejectionVelocity = 1.01;
   velocityVariance = 0.0;
   ejectionOffset   = 25.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 1;
   particles = "DarkParticle";
};



datablock AudioProfile(LightningZapSound){
   filename = "fx/misc/lightning_impact.wav";
   description = AudioExplosion3d;
};

datablock LightningData(zapStorm){
   directDamageType = $DamageType::Lightning;
   directDamage = 1;
   
   strikeTextures[0]  = "special/skyLightning";

   strikeSound = LightningZapSound;
};

datablock ParticleData(SphereMistPart){
   textureName = "particleTest";
   dragCoefficient = "2";
   gravityCoefficient = 0.0;
   inheritedVelFactor = "0";
   windCoefficient = "0";
   constantAcceleration = -30;
   lifetimeMS = "2500";
   lifetimeVarianceMS = "0";
   spinRandomMin = "-200";
   spinRandomMax = "200";
   useInvAlpha = "0";
   
   colors[0] = "0.204724 0.204724 0.204724 0.199213";
   colors[1] = "0.291339 0.291339 0.291339 0.199213";
   colors[2] = "0.259843 0.259843 0.259843 0.188976";
   colors[3] = "0.0787402 0.0787402 0.0787402 0.015748";
      
   sizes[0] = "50";
   sizes[1] = "50";
   sizes[2] = "50";
   sizes[3] = "50";
   
   times[0] = "0.1";
   times[1] = "0.8";
   times[2] = "0.9";
   times[3] = "1";
   
   spinSpeed = "1";
};

datablock ParticleEmitterData(SphereMistEmitter){
   ejectionPeriodMS = "5";
   periodVarianceMS = "0";
   ejectionVelocity = "10";
   velocityVariance = "0";
   ejectionOffset = "400";
   thetaMin = "0";
   thetaMax = "180";
   phiReferenceVel = 0;
   phiVariance = 360;
   orientParticles = "0";
   orientOnVelocity = true;
   particles = "SphereMistPart";
   lifetimeMS = "0";
   blendStyle = "NORMAL";
   alignDirection = "0 1 0";
   
};

datablock LinearFlareProjectileData(BlueSpawnProj){
   projectileShapeName = "plasmabolt.dts";
   scale               = "2.3 2.3 2.3";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = false;
   indirectDamage      = 0;
   damageRadius        = 0;
   kickBackStrength    = 300.0;
   directDamageType    = $DamageType::Explosion;
   radiusDamageType    = $DamageType::Explosion;
   Impulse = true;
   explosion           = "MissileExplosion";
   //splash              = PlasmaSplash;

   dryVelocity       = 0.1;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0;
   lifetimeMS        = 16320;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 30.2;
   size[1]           = 30.5;
   size[2]           = 50.1;


   numFlares         = 150;
   flareColor        = "0 0.3 1";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "0 0.3 1";
   ignoreExEffects = 1;
};

datablock LinearFlareProjectileData(RedSpawnProj){
   projectileShapeName = "plasmabolt.dts";
   scale               = "2.3 2.3 2.3";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = false;
   indirectDamage      = 0;
   damageRadius        = 0;
   kickBackStrength    = 300.0;
   directDamageType    = $DamageType::Explosion;
   radiusDamageType    = $DamageType::Explosion;
   Impulse = true;
   explosion           = "MissileExplosion";
   //splash              = PlasmaSplash;

   dryVelocity       = 0.1;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0;
   lifetimeMS        = 16320;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 30.2;
   size[1]           = 30.5;
   size[2]           = 50.1;


   numFlares         = 150;
   flareColor        = "1 0.3 0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.3 0";
   ignoreExEffects = 1;
};

datablock StaticShapeData(AGameStart){
   catagory = "misc";
   shapeFile = "flag.dts";
};
function AGameStart::onAdd(%this, %obj){  
   Parent::onAdd(%this, %obj);
   if(!isObject(StartScriptObj)){
      %obj.setName("StartScriptObj");
   }
   if(!Game.aStart && !$Anomaly::editMode){
       aGameLoop();
      Game.aStart = 0;
   }
}
function aGameEffects(%pos, %exitPos){
   %exitPos = 1024*5 SPC 1024*5 SPC 450;
   if(!isObject(aEffect)){
      new SimGroup(aEffect);
      MissionCleanup.add(aEffect);
      aEffect.red = new LinearFlareProjectile() {
         dataBlock        =  RedSpawnProj;
         initialDirection = "0 0 1";
         initialPosition  = %pos;
         sourceObject     = -1;
         sourceSlot       = 0;
         vehicleObject    = 0;
      };
      aEffect.add(aEffect.red);

      aEffect.blue = new LinearFlareProjectile() {
         dataBlock        = BlueSpawnProj;
         initialDirection = "0 0 1";
         initialPosition  = %exitPos;
         sourceObject     = -1;
         sourceSlot       = 0;
         vehicleObject    = 0;
      };
      aEffect.add(aEffect.blue);

      %a = new ParticleEmissionDummy() {
         position = %pos;
         rotation = "1 0 0 0";
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter =  "SphereMistEmitter";
         velocity = "1";
      };
      aEffect.add(%a);  

      %a = new ParticleEmissionDummy() {
         position = %pos;
         rotation = "1 0 0 0";
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter =  "RedChargedEmitter";
         velocity = "1";
      };
      aEffect.add(%a); 

      %a = new ParticleEmissionDummy() {
         position = %pos;
         rotation = "1 0 0 0";
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "DarkEmitter";
         velocity = "1";
      }; 
      aEffect.add(%a);


      %a = new ParticleEmissionDummy() {
         position = %exitPos;
         rotation = "1 0 0 0";
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter =  "BlueChargedEmitter";
         velocity = "1";
      };
      aEffect.add(%a); 

      %a = new ParticleEmissionDummy() {
         position = %exitPos;
         rotation = "1 0 0 0";
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "DarkEmitter";
         velocity = "1";
      }; 
      aEffect.add(%a);

      %a  = new Lightning(Lightning){
         position = vectorAdd(%pos,"0 0 -110");
         rotation = "1 0 0 0";
         scale = "1 1 220";
         dataBlock = "zapStorm";
         lockCount = "0"; 
         homingCount = "0";
         strikesPerMinute = "12"; 
         strikeWidth = "2.5";
         chanceToHitTarget = "1";
         strikeRadius = "1";
         boltStartRadius = "1"; //altitude the lightning starts from
         color =   "1 0 0 1";
         fadeColor = "0.9 0.3 0 1";
      };
      aEffect.add(%a);
   }
   else{
      if(!isObject(aEffect.red)){
         aEffect.red = new LinearFlareProjectile() {
            dataBlock        =  RedSpawnProj;
            initialDirection = "0 0 1";
            initialPosition  = %pos;
            sourceObject     = -1;
            sourceSlot       = 0;
            vehicleObject    = 0;
         };
         aEffect.add(aEffect.red);
      }
      if(!isObject(aEffect.blue)){
         aEffect.blue = new LinearFlareProjectile() {
            dataBlock        = BlueSpawnProj;
            initialDirection = "0 0 1";
            initialPosition  = %exitPos;
            sourceObject     = -1;
            sourceSlot       = 0;
            vehicleObject    = 0;
         };
         aEffect.add(aEffect.blue); 
      }
   }
}
function aGameLoop(){
   if(($MatchStarted + $missionRunning) == 2 && ($HostGamePlayerCount - $HostGameBotCount > 0)){
      Game.loopTime += 128;
      if(Game.loopTime > (60000 * $Anomaly::dkwUnlockTimeMin)){
         Game.unlockDarkWep = 1;
      }
      if(getRandom(1,150) == 1){
         randomSteamBlast();
      }
      if(cbase.team && cbase.isPowered()){ 
         replaceTrees();
         %pos = "-4.41736 -3.32352 432.785";
         %exitPos = 1024*5 SPC 1024*5 SPC 250;
         aGameEffects(%pos, %exitPos);
         InitContainerRadiusSearch(%pos,  400,  $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::ProjectileObjectType | $TypeMasks::ItemObjectType);
         while ((%targetObject = containerSearchNext()) != 0){
            %tgtPos = %targetObject.getWorldBoxCenter();
            %dist = vectorDist(%pos,%tgtPos); 
            %zDist = getWord(%pos,2) - getWord(%tgtPos,2);
            %vec = VectorNormalize(VectorSub(%pos, %tgtPos));
            %limit = (cbase.team == %targetObj.team) ? 180 : 200;
            if(%zDist < %limit){
               if((%targetObject.getType() & $TypeMasks::ProjectileObjectType)){
                  if(%targetObject.getDatablock().getname() !$= "RedSpawnProj" && %targetObject.getDatablock().getname() !$= "BlueSpawnProj"){
                     if(%targetObject.getClassName() $= "LinearFlareProjectile" ||  %targetObject.getClassName() $= "LinearProjectile" ||  %targetObject.getClassName() $= "TracerProjectile" || %targetObject.getClassName() $= "GrenadeProjectile"){
                        %dis =  vectorDist(%targetObject.initialPosition,%targetObject.getPosition());
                        //error(getSimTime() - %targetObject.lifeTimeMS); 
                        if(%targetObject.lifeTimeMS && (getSimTime() - %targetObject.lifeTimeMS) > 60000){
                           continue;
                        }
                        if(%dis > 0.1 && %dist > 50){
                           %prec = 10;
                           %targetDir = vectorScale (%vec,%prec);
                           %projDir =  vectorScale(%targetObject.initialDirection,100-%prec);
                           %vecAdd = vectorNormalize(vectorAdd(%targetDir,%projDir));
                           %p = new (%targetObject.getClassName())() {
                              dataBlock        = %targetObject.getDatablock().getName();
                              initialDirection = %vecAdd;
                              initialPosition  = %targetObject.getPosition();
                              sourceObject     = -1;// needs to be -1 other wise rendering issues happen as it references source objects muzzle point
                              sourceSlot       = 0;
                              vehicleObject    = 0;
                              sobj = (!%targetObject.sourceObject) ? -1 : %targetObject.sourceObject;
                              lifeTimeMS =  (!%targetObject.lifeTimeMS) ? getSimTime() : %targetObject.lifeTimeMS;
                           };
                           MissionCleanup.add(%p);
                           %targetObject.delete();
                        }
                        else{
                           %p = new (%targetObject.getClassName())() {
                              dataBlock        = %targetObject.getDatablock().getName();
                              initialDirection = %targetObject.initialDirection;
                              initialPosition  = vectorAdd(%exitPos,"0 0 198");
                              sourceObject     = -1;
                              sourceSlot       = 0;
                              vehicleObject    = 0;
                              sobj = (!%targetObject.sourceObject) ? -1 : %targetObject.sourceObject;
                           };
                           MissionCleanup.add(%p);
                           %targetObject.delete();
                        }
                     }
                  }
               }
               else if((%targetObject.getType() & $TypeMasks::VehicleObjectType)){
                  if(%targetObject.getClassName() $= "WheeledVehicle"){
                     if(%dist < 60 && isEventPending(%targetObject.sch)){
                        cancel(%targetObject.sch);
                        %targetObject.delete(); 
                     }
                     else{
                        %impulseVec = VectorScale(%vec, 2000);
                        %targetObject.applyImpulse(vectorAdd(%targetObject.getPosition(),"0 0 0.01"), %impulseVec);
                     }
                  }
                  else{
                     %ray = ContainerRayCast(%pos, %tgtPos, $TypeMasks::StaticTSObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType, 0);
                     if(!%ray){
                        %impulseVec = VectorScale(%vec, 2000);
                        if(%dist < 60){
                           %targetObject.getDatablock().damageObject(%targetObject, 0, "0 0 0", 5, $DamageType::Impact); 
                        }
                        else{
                           %targetObject.applyImpulse(%targetObject.getPosition(), %impulseVec);
                        }
                     }
                  }
               }    
               else if((%targetObject.getType() & $TypeMasks::PlayerObjectType) && !%targetObject.isMounted()){
                  //error(%zDist);
                  %isSafe =  %targetObject.lastBoostTime && ((getSimTime() - %targetObject.lastBoostTime) < 10000);
                  if(!%isSafe){
                     if(%targetObject.holdingFlag){
                        Game.dropFlag(%targetObject); 
                     }
                     if(%dist < 40){
                        %targetObject.setPosition(vectorAdd(%exitPos,"0 0 198")); 
                        %targetObject.setVelocity(vectorScale(%targetObject.getVelocity(),0.5));  
                     }
                     else{
                        %timeDif = getSimTime() - %targetObject.lastPullTime;
                        if(!%targetObject.lastPullTime || %timeDif > 3000){
                           %targetObject.whcount = 0; 
                           %targetObject.precAdd = 0;  
                        }
                        %targetObject.lastPullTime = getSimTime();   
                        %targetObject.whcount++;
                        if(%targetObject.whcount > 100){
                           %targetObject.precAdd += 0.05;   
                        }
                        //error(%targetObject.whcount SPC %targetObject.precAdd);
                        %prec = 10 + %targetObject.precAdd;
                        %tvec = vectorNormalize(%targetObject.getVelocity());
                        %speed = VectorLen(%targetObject.getVelocity());
                        %speed  =  (%speed < 100) ? (%speed + 5) : %speed * 0.99;
                        //error(%speed);
                        %targetDir = vectorScale (%vec,%prec);
                        %projDir =  vectorScale(%tvec ,100-%prec);
                        %vecAdd = vectorNormalize(vectorAdd(%targetDir,%projDir));
                        %targetObject.setVelocity(vectorScale(%vecAdd,%speed));
                        //%targetObject.applyImpulse(%tgtPos,  VectorScale(%vec, 60));
                     }
                  }
               } 
               else if((%targetObject.getType() & $TypeMasks::ItemObjectType) && !%targetObject.static){
                  %ray = ContainerRayCast(%pos, %tgtPos, $TypeMasks::StaticTSObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType, 0);
                  if(!%ray){
                     if(%dist < 50 && %targetObject.getDatablock().getName() !$= "Flag"){
                        %targetObject.setPosition(vectorAdd(%exitPos,"0 0 198"));  
                     }
                     else if(%targetObject.getDatablock().getName() !$= "Flag"){
                        %prec = 10;
                        %tvec = vectorNormalize(%targetObject.getVelocity());
                        %speed = VectorLen(%targetObject.getVelocity());
                        %speed  =  (%speed < 100) ? (%speed + 10) : 100;
                        //error(%speed);
                        %targetDir = vectorScale (%vec,%prec);
                        %projDir =  vectorScale(%tvec ,100-%prec);
                        %vecAdd = vectorNormalize(vectorAdd(%targetDir,%projDir));
                        %targetObject.setVelocity(vectorScale(%vecAdd,%speed));
                        //%targetObject.applyImpulse(%tgtPos,  VectorScale(%vec, 60));
                     }
                  }
               }
            }
            else if((%targetObject.getType() & $TypeMasks::VehicleObjectType)){
               if(%targetObject.getClassName() $= "WheeledVehicle"){
                  if(%dist < 60 && isEventPending(%targetObject.sch)){
                     cancel(%targetObject.sch);
                     %targetObject.delete(); 
                  }
                  else{
                     %impulseVec = VectorScale(%vec, 2000);
                     %targetObject.applyImpulse(vectorAdd(%targetObject.getPosition(),"0 0 0.01"), %impulseVec);
                  }
               }
            }
         }
      }
      else if(isObject(aEffect)){
         aEffect.delete();
      }
   }

   if(isObject(StartScriptObj)){
      schedule(128, 0, "aGameLoop");
   }
}

function steamKick(%pos,%time){
   %uppos = vectorAdd(%pos, getRandom(-100,100) SPC getRandom(-100,100) SPC 150);
   steamkick2(%pos,%time,%uppos);
}

function steamkick2(%pos,%time,%uppos){
   InitContainerRadiusSearch(%pos,  50, $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType); 
   while ((%targetObject = containerSearchNext()) != 0){
      if((%targetObject.getType() & $TypeMasks::PlayerObjectType)){
         %force = 1800;
         %tgtPos = %targetObject.getWorldBoxCenter();
         %rot = getWords(MatrixMultiply("0 0 0 0 0 1" SPC mDegToRad(getRandom(1,360)), "0 0 0 0 1 0" SPC mDegToRad(getRandom(1,45))),3,6);
         %vec = VectorNormalize(VectorSub(%uppos, %pos));
         //error(%uppos SPC %vec);
         %impulseVec = VectorScale(%vec, %force);
         %targetObject.applyImpulse(%tgtPos, %impulseVec);
      }
      else if((%targetObject.getType() &$TypeMasks::VehicleObjectType) && %targetObject.getDataBlock().getName() $= "tree19"){
         %targetObject.applyImpulse(%targetObject.getPosition(),"5000 0 1900");
      }
    } 
    if(%time > 0){
       %time -= 64;
      schedule(64,0,"steamKick2",%pos,%time,%uppos);
    }  
   
}
datablock ParticleData(SteamStackParticle) {
   dragCoefficient = "0.5";
   windCoefficient = "0";
   gravityCoefficient = "10";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "5000";
   lifetimeVarianceMS = "200";
   spinSpeed = "1";
   spinRandomMin = "-50";
   spinRandomMax = "50";
   useInvAlpha = "0";
   animateTexture = "0";
   framesPerSec = "1";
   textureCoords[0] = "0 0";
   textureCoords[1] = "0 1";
   textureCoords[2] = "1 1";
   textureCoords[3] = "1 0";
   animTexTiling = "0 0";
   textureName = "particleTest";
   colors[0] = "0.204724 0.204724 0.204724 0.99213";
   colors[1] = "0.291339 0.291339 0.291339 0.1";
   colors[2] = "0.259843 0.259843 0.259843 0.1";
   colors[3] = "0.0787402 0.0787402 0.0787402 0.015748";
   sizes[0] = "50";
   sizes[1] = "50";
   sizes[2] = "50";
   sizes[3] = "50";
   times[0] = "0";
   times[1] = "0.05";
   times[2] = "0.65";
   times[3] = "1";
};

datablock ParticleEmitterData(SteamStackEmitter) {
   ejectionPeriodMS = "10";
   periodVarianceMS = "0";
   ejectionVelocity = "500";
   velocityVariance = "100";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "5";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "1";
   ambientFactor = "0";
   overrideAdvance = "1";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "SteamStackParticle";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";  

};

function randomSteamBlast(){
   %time = getRandom(3000, 8000);
   if(getRandom(1,2)  == 1) %team = isObject(Team1SFX) ? 2 : 1;
   else %team = isObject(Team2SFX) ? 1 : 2;
   
   if(%team == 1 && !isObject(Team1SFX)){
      if(isObject(TreeB) && getRandom(1,2) == 1){//lols
       %pos = TreeB.position;
       %rot = TreeB.rotation;
       TreeB.delete();
       	%veh = new WheeledVehicle() {
            position = %pos;
            rotation = %rot;
            scale = "1 1 1";
            dataBlock = "tree19";
            lockCount = "0";
            homingCount = "0";
            disableMove = "0";

            Target = "126";
            mountable = "1";
            respawn = "0";
            selfPower = "1";
            lastDamagedBy = "0";
         };
         MissionCleanup.add(%veh);
         %veh.schedule(5000,"delete");
      }
      steamKick("-287.25 -10.7926 197.165",%time);
      camShake("-287.25 -10.7926 197.165");  
      %sfx = new AudioEmitter(Team1SFX) {
         position = "-287.25 -10.7926 197.165";
         rotation = "1 0 0 0";
         scale = "1 1 1";
         fileName = "fx/vehicles/htransport_boost.wav";
         useProfileDescription = "0";
         outsideAmbient = "1";
         volume = "1";
         isLooping = "1";
         is3D = "1";
         minDistance = "100";
         maxDistance = "1024";
         coneInsideAngle = "360";
         coneOutsideAngle = "360";
         coneOutsideVolume = "1";
         coneVector = "0 0 1";
         loopCount = "-1";
         minLoopGap = 0;
         maxLoopGap = 0;
         type = "EffectAudioType";

         locked = "true";
      };
      MissionCleanup.add(%sfx);
      %sfx.schedule(%time,"delete");
   	%part = new ParticleEmissionDummy() {
         position = "-325.361 10.2393 194.433";
         rotation = "0 -1 0 13";
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "SteamStackEmitter";
         velocity = "1";
      };
      %part.schedule(%time, "delete"); 
      MissionCleanup.add(%part);
      %part = new ParticleEmissionDummy() {
         position = "-325.361 -20.5607 194.433";
         rotation = "0 -1 0 13";
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "SteamStackEmitter";
         velocity = "1";
      };
      %part.schedule(%time, "delete"); 
      MissionCleanup.add(%part);
      %part = new ParticleEmissionDummy() {
         position = "-264.561 23.6393 182.433";
         rotation = "0 1 0 17.7618";
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "SteamStackEmitter";
         velocity = "1";
      };
      %part.schedule(%time, "delete"); 
      MissionCleanup.add(%part);
      %part = new ParticleEmissionDummy() {
         position = "-267.161 -30.9607 194.433";
         rotation = "0 1 0 9.99997";
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "SteamStackEmitter";
         velocity = "1";
      };   
      %part.schedule(%time, "delete"); 
      MissionCleanup.add(%part);
   }
   else if(%team == 2 && !isObject(Team2SFX)){
      if(isObject(TreeA) && getRandom(1,2) == 1){//lols
       %pos = TreeA.position;
       %rot = TreeA.rotation;
       TreeA.delete();
       	%veh = new WheeledVehicle() {
            position = %pos;
            rotation = %rot;
            scale = "1 1 1";
            dataBlock = "tree19";
            lockCount = "0";
            homingCount = "0";
            disableMove = "0";

            Target = "126";
            mountable = "1";
            respawn = "0";
            selfPower = "1";
            lastDamagedBy = "0";
         };
         MissionCleanup.add(%veh);
         %veh.schedule(5000,"delete");
      }

      steamKick("286.981 -1.84569 200",%time);
      camShake("286.981 -1.84569 200");  
      %rot[0] = "0.062007 -0.825201 0.561425 15.2465";
      %rot[1] = "-0.11061 -0.0026778 0.99386 194.328";
      %rot[2] = "-0.0999666 -0.0720035 0.992382 126.016";
      %rot[3] = "-0.115559 0.0308397 0.992822 226.772";
      %rot[4] = "-0.0770999 -0.210176 0.974619 58.7289";
      %rotation = %rot[getRandom(0,4)];
      %sfx = new AudioEmitter(Team2SFX) {
         position = "286.981 -1.84569 200"; 
         rotation = "1 0 0 0";
         scale = "1 1 1";
         fileName = "fx/vehicles/htransport_boost.wav";
         useProfileDescription = "0";
         outsideAmbient = "1";
         volume = "1";
         isLooping = "1";
         is3D = "1";
         minDistance = "100";
         maxDistance = "1024";
         coneInsideAngle = "360";
         coneOutsideAngle = "360";
         coneOutsideVolume = "1";
         coneVector = "0 0 1";
         loopCount = "-1";
         minLoopGap = 0;
         maxLoopGap = 0;
         type = "EffectAudioType";

         locked = "true";
      };
      MissionCleanup.add(%sfx);
      %sfx.schedule(%time,"delete");
      %part = new ParticleEmissionDummy() {
         position = "317.569 12.6078 187.632";
         rotation = %rotation;
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "SteamStackEmitter";
         velocity = "1";
      };
      %part.schedule(%time, "delete"); 
      MissionCleanup.add(%part);
      %part = new ParticleEmissionDummy() {
         position = "312.319 -22.988 188.805";
         rotation = %rotation;
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "SteamStackEmitter";
         velocity = "1";
      };
      %part.schedule(%time, "delete"); 
      MissionCleanup.add(%part);
      %part = new ParticleEmissionDummy() {
         position = "255.718 -21.3017 201.462";
         rotation = %rotation;
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "SteamStackEmitter";
         velocity = "1";
      };
      %part.schedule(%time, "delete"); 
      MissionCleanup.add(%part);
      %part = new ParticleEmissionDummy() {
         position = "264.561 25.2672 199.485";
         rotation = %rotation;
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "SteamStackEmitter";
         velocity = "1";
      };
      %part.schedule(%time, "delete"); 
      MissionCleanup.add(%part);
      %part = new ParticleEmissionDummy() {
         position = "277.355 -4.42543 196.623";
         rotation = %rotation;
         scale = "1 1 1";
         dataBlock = "defaultEmissionDummy";
         lockCount = "0";
         homingCount = "0";
         emitter = "SteamStackEmitter";
         velocity = "1";
      };
      %part.schedule(%time, "delete"); 
      MissionCleanup.add(%part);
   }
}
datablock ExplosionData(camShake1){
   lifeTimeMS = 10000;
   offset = 0;
   
   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 2;
   camShakeRadius = 200.0;
};

datablock LinearFlareProjectileData(CamProj){
   projectileShapeName = "plasmabolt.dts";
   scale               = "0.01 0.01 0.01";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = false;
   indirectDamage      = 0;
   damageRadius        = 0;
   kickBackStrength    = 0.0;
   directDamageType    = $DamageType::Explosion;
   radiusDamageType    = $DamageType::Explosion;
   Impulse = true;
   explosion           = "camShake1";

   dryVelocity       = 0.1;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0;
   lifetimeMS        = 128;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = -1;

   size[0]           = 0.01;
   size[1]           = 0.01;
   size[2]           = 0.01;


   numFlares         = 3;
   flareColor        = "0 1 0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = false;
   lightRadius = 3.0;
   lightColor  = "0 1 0";
};

function camShake(%pos){
   %p = new LinearFlareProjectile() {
      dataBlock        = CamProj;
      initialDirection = "0 0 -1";
      initialPosition  = %pos;
      sourceObject     = -1; 
      sourceSlot       = 0;
      vehicleObject    = 0;
   };  
   MissionCleanup.add(%p);  
}

function replaceTrees(){
   if(!Game.rmvTrees){
      if(isObject(RandomOrganics)){
         RandomOrganics.delete();
      }
      for(%i = 0 ; %i < rmvTrees.getCount(); %i++){
         %tree = rmvTrees.getObject(%i);
         schedule(getRandom(1000,15000),0,"treeVeh",%tree); 
      }
      Game.rmvTrees = 1;
   }
}

function  treeVeh(%tree){
      %pos = %tree.position;
      %rot = %tree.rotation;
      %treeDB = %tree.DB;
      %tree.delete();
      %veh = new WheeledVehicle() {
         position = %pos;
         rotation = %rot;
         scale = "1 1 1";
         dataBlock = %treeDB;
         lockCount = "0";
         homingCount = "0";
         disableMove = "0";

         Target = "126";
         mountable = "1";
         respawn = "0";
         selfPower = "1";
         lastDamagedBy = "0";
      };
      MissionCleanup.add(%veh);
      %veh.sch = %veh.schedule(8000,"delete");  
   
}


datablock WheeledVehicleData(tree16) : ShrikeDamageProfile{
   mountable = 0;
   spawnOffset = "0 0 1.0";
   renderWhenDestroyed = false;

   catagory = "MISC";
   shapeFile = "borg16.dts";
   multipassenger = false;
   computeCRC = false;

   isShielded = false;
   explosion = BlasterExplosion;
   explosionDamage = 0.5;
   explosionRadius = 5.0;
   drag = 1.0;
   maxDamage = 1;
   destroyedLevel = 1.1;
   
   mass = 150;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 10;
   minDrag = 10;

   
   

   softSplashSoundVelocity = 10.0;
   mediumSplashSoundVelocity = 15.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 10.0;


   softImpactSpeed = 114;       
   hardImpactSpeed = 220;    

   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;
   targetNameTag = 'Physics';
   targetTypeTag = 'Object';
   sensorData = VehiclePulseSensor;
   sensorRadius = VehiclePulseSensor.detectRadius;

   minImpactSpeed = 10;     
   speedDamageScale = 0.006;

   damageScale[$DamageType::Water] = 0;
};

datablock WheeledVehicleData(tree17) : ShrikeDamageProfile{
   mountable = 0;
   spawnOffset = "0 0 1.0";
   renderWhenDestroyed = false;

   catagory = "MISC";
   shapeFile = "borg17.dts";
   multipassenger = false;
   computeCRC = false;

   isShielded = false;
   explosion = BlasterExplosion;
   explosionDamage = 0.5;
   explosionRadius = 5.0;
   drag = 1.0;
   maxDamage = 1;
   destroyedLevel = 1.1;
   
   mass = 150;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 10;
   minDrag = 10;

   softSplashSoundVelocity = 10.0;
   mediumSplashSoundVelocity = 15.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 10.0;

   softImpactSpeed = 114;       
   hardImpactSpeed = 220;    

   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;
   targetNameTag = 'Physics';
   targetTypeTag = 'Object';
   sensorData = VehiclePulseSensor;
   sensorRadius = VehiclePulseSensor.detectRadius;

   minImpactSpeed = 10;     
   speedDamageScale = 0.006;

   damageScale[$DamageType::Water] = 0;
};

datablock WheeledVehicleData(tree18) : ShrikeDamageProfile{
   mountable = 0;
   spawnOffset = "0 0 1.0";
   renderWhenDestroyed = false;

   catagory = "MISC";
   shapeFile = "borg18.dts";
   multipassenger = false;
   computeCRC = false;

   isShielded = false;
   explosion = BlasterExplosion;
   explosionDamage = 0.5;
   explosionRadius = 5.0;
   drag = 1.0;
   maxDamage = 1;
   destroyedLevel = 1.1;
   
   mass = 150;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 10;
   minDrag = 10;

   
   

   softSplashSoundVelocity = 10.0;
   mediumSplashSoundVelocity = 15.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 10.0;


   softImpactSpeed = 114;       
   hardImpactSpeed = 220;    

   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;
   targetNameTag = 'Physics';
   targetTypeTag = 'Object';
   sensorData = VehiclePulseSensor;
   sensorRadius = VehiclePulseSensor.detectRadius;

   minImpactSpeed = 10;     
   speedDamageScale = 0.006;

   damageScale[$DamageType::Water] = 0;
};

datablock WheeledVehicleData(tree19) : ShrikeDamageProfile{
   mountable = 0;
   spawnOffset = "0 0 1.0";
   renderWhenDestroyed = false;

   catagory = "MISC";
   shapeFile = "borg19.dts";
   multipassenger = false;
   computeCRC = false;

   isShielded = false;
   explosion = BlasterExplosion;
   explosionDamage = 0.5;
   explosionRadius = 5.0;
   drag = 1.0;
   maxDamage = 1;
   destroyedLevel = 1.1;
   
   mass = 150;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 10;
   minDrag = 10;

   
   

   softSplashSoundVelocity = 10.0;
   mediumSplashSoundVelocity = 15.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 10.0;


   softImpactSpeed = 114;       
   hardImpactSpeed = 220;    

   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;
   targetNameTag = 'Physics';
   targetTypeTag = 'Object';
   sensorData = VehiclePulseSensor;
   sensorRadius = VehiclePulseSensor.detectRadius;

   minImpactSpeed = 10;     
   speedDamageScale = 0.006;

   damageScale[$DamageType::Water] = 0;
};

function WeaponImage::dwOnMount(%this, %obj, %slot){
   %shape = %this.shapeFile;
   switch$(%shape){
      case "weapon_energy.dts":
         %obj.client.setWeaponsHudActive("Blaster");
      case "weapon_chaingun.dts":
         %obj.client.setWeaponsHudActive("Chaingun");
      case "weapon_disc.dts":
          %obj.client.setWeaponsHudActive("Disc");
      case "weapon_elf.dts":
          %obj.client.setWeaponsHudActive("ELFGun");
      case "weapon_grenade_launcher.dts":
          %obj.client.setWeaponsHudActive("GrenadeLauncher");
      case "weapon_missile.dts":
          %obj.client.setWeaponsHudActive("MissileLauncher");
      case "weapon_mortar.dts":
          %obj.client.setWeaponsHudActive("Mortar");
      case "weapon_plasma.dts":
          %obj.client.setWeaponsHudActive("Plasma");
      case "weapon_shocklance.dts":
          %obj.client.setWeaponsHudActive("ShockLance");
      case "weapon_sniper.dts":
         %obj.client.setWeaponsHudActive("SniperRifle");
      case "weapon_targeting.dts":
          %obj.client.setWeaponsHudActive("TargetingLaser");
      default:
         %obj.client.setWeaponsHudActive("Blaster");
   } 
   %obj.client.setWeaponsHudActive(%this.item);  
}

function WeaponImage::dwUnMount(%this, %obj, %slot){
   %shape = %this.shapeFile;
   switch$(%shape){
      case "weapon_energy.dts":
         %obj.client.setWeaponsHudActive("Blaster", 1);
      case "weapon_chaingun.dts":
         %obj.client.setWeaponsHudActive("Chaingun", 1);
      case "weapon_disc.dts":
          %obj.client.setWeaponsHudActive("Disc", 1);
      case "weapon_elf.dts":
          %obj.client.setWeaponsHudActive("ELFGun", 1);
      case "weapon_grenade_launcher.dts":
          %obj.client.setWeaponsHudActive("GrenadeLauncher", 1);
      case "weapon_missile.dts":
          %obj.client.setWeaponsHudActive("MissileLauncher", 1);
      case "weapon_mortar.dts":
          %obj.client.setWeaponsHudActive("Mortar", 1);
      case "weapon_plasma.dts":
          %obj.client.setWeaponsHudActive("Plasma", 1);
      case "weapon_shocklance.dts":
          %obj.client.setWeaponsHudActive("ShockLance", 1);
      case "weapon_sniper.dts":
         %obj.client.setWeaponsHudActive("SniperRifle", 1);
      case "weapon_targeting.dts":
          %obj.client.setWeaponsHudActive("TargetingLaser", 1);
      default:
         %obj.client.setWeaponsHudActive("Blaster", 1);
   } 
   %obj.client.setWeaponsHudActive(%this.item, 1);  
}


datablock TriggerData(anomalyTrig){
   tickPeriodMS =  32;
};

datablock StaticShapeData(T2AmmoDeployableObj) : StaticShapeDamageProfile
{
   className = Station;
   shapeFile = "t2DepAmmo.dts";
   maxDamage = 0.70;
   destroyedLevel = 0.70;
   disabledLevel = 0.42;
   explosion      = DeployablesExplosion;
   expDmgRadius = 8.0;
   expDamage = 0.35;
   expImpulse = 500.0;

   dynamicType = $TypeMasks::StationObjectType;
   isShielded = true;
   energyPerDamagePoint = 110;
   maxEnergy = 50;
   rechargeRate = 0.20;
   renderWhenDestroyed = false;
   doesRepair = true;

   deployedObject = true;

   cmdCategory = "DSupport";
   cmdIcon = CMDStationIcon;
   cmdMiniIconName = "commander/MiniIcons/com_inventory_grey";
   targetNameTag = 'Deployable';
   targetTypeTag = 'Station';

   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   heatSignature = 0;
};

datablock ShapeBaseImageData(T2AmmoDeployableImage)
{
   mass = 12; // z0dd - ZOD, 7/17/02. large packs are too heavy enough with new physics. was 15
   emap = true;

   shapeFile = "t2DepAmmo_Pack.dts";
   item = T2AmmoDeployable;
   mountPoint = 1;
   offset = "0 0 -0.5";
   rotation = "0 0 1 180";
   deployed = T2AmmoDeployableObj;
   heatSignature = 0;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Idle";

   isLarge = true;
   maxDepSlope = 30;
   deploySound = StationDeploySound;

   flatMinDeployDis   = 2.0; // z0dd - ZOD, 5/18/03. Was 1.0, try to prevent it intersecting with plyr bb.
   flatMaxDeployDis   = 5.0;

   minDeployDis       = 3.0; // z0dd - ZOD, 5/18/03. Was 2.5, try to prevent it intersecting with plyr bb.
   maxDeployDis       = 6.0;
};

$TeamDeployableMax[T2AmmoDeployable] = 6;
$TeamDeployableMin[T2AmmoDeployable] = 6;

datablock ItemData(T2AmmoDeployable)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "t2DepAmmo_Pack.dts";
   mass = 3.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = false;
   image = "T2AmmoDeployableImage";
   pickUpName = "an ammo station pack";
   heatSignature = 0;

   computeCRC = true;
   emap = true;

};

function T2AmmoDeployableImage::getInitialRotation(%item, %plyr) {
   %rot = rotFromTransform(%plyr.getTransform());
   // Rotate 180 degrees around Z-axis (PI radians)
   // Multiply original rotation by the 180-degree Z rotation
   %newRot = MatrixMultiply("0 0 0" SPC %rot, "0 0 0" SPC "0 0 1" SPC 3.14159265359);
   return getWords(rotFromTransform(%newRot), 0, 3);
}

function T2AmmoDeployableImage::onDeploy(%item, %plyr, %slot){
   %obj = Parent::onDeploy(%item, %plyr, %slot);
   %obj.init = 0;
   %trigger = new Trigger()
   { 
      dataBlock = BuildTrigger;
      polyhedron = "-0.125 0.0 0.1 0.25 0.0 0.0 0.0 -0.8 0.0 0.0 0.0 1.0";
   };     

   MissionCleanup.add(%trigger);

   %trans = %obj.getTransform();
   %vSPos = getWords(%trans,0,2);
   %vRot =  getWords(%trans,3,5);
   %vAngle = getWord(%trans,6);
   %matrix = VectorOrthoBasis(%vRot @ " " @ %vAngle + 0.0);
   %yRot = getWords(%matrix, 3, 5);
   %pos = vectorAdd(%vSPos, vectorScale(%yRot, 1));

   %trigger.setTransform(%pos @ " " @ %vRot @ " " @ %vAngle);

   // associate the trigger with the station
   %trigger.station =%obj;
   %obj.trigger = %trigger;

}
function T2AmmoDeployable::onCollision(%data,%obj,%col){
   if (%col.getDataBlock().className $= Armor && %col.getState() !$= "Dead" && %col.getMountedImage(2) == 0 && !%col.isMounted()){
      if (%col.client){
         messageClient(%col.client, 'MsgItemPickup', '\c0You picked up %1.', %data.pickUpName);
         serverPlay3D(ItemPickupSound, %col.getTransform());
      }
      if (%obj.isStatic()){
         %obj.respawn();
      }
      else{
         %obj.delete();
      }
      %col.setInventory(T2AmmoDeployable, 1, true);
      
   }
}

function T2AmmoDeployableObj::onDestroyed(%this, %obj, %prevState){
   Parent::onDestroyed(%this, %obj, %prevState);
   $TeamDeployedCount[%obj.team, T2AmmoDeployable]--;
   if(isObject(%obj.trigger)){   
      %obj.trigger.delete();
   }
   %obj.schedule(500, "delete");
}


function BuildTrigger::onEnterTrigger(%data, %trigger, %player){
   %station = %trigger.station;
   %targetname = %station.getDataBlock().getName(); 
   if(%trigger.powerTrig){
      if(%station.isEnabled() &&  %station.isPowered() && (!%player.client.lastInvySfx || (getSimTime() - %player.client.lastInvySfx) > 10000)){
         %player.client.play3D(invyPowerActivate, %trigger.getPosition());
         %player.client.lastInvySfx = getSimTime();
      }
      return;
   }

   if((%station.team != %player.client.team) && (%station.team != 0)){
         //%obj.station.playAudio(2, StationAccessDeniedSound);
         messageClient(%player.client, 'msgStationDenied', '\c2Access Denied -- Wrong team.~wfx/powered/station_denied.wav');
   }
   else if(%station.isDisabled()){
      messageClient(%player.client, 'msgStationDisabled', '\c2Station is disabled.');
   }
   else if(!%station.isPowered()){
      messageClient(%player.client, 'msgStationNoPower', '\c2Station is not powered.');
   }
   else if(%station.notDeployed){
      messageClient(%player.client, 'msgStationNotDeployed', '\c2Station is not deployed.');
   }
   else if(%station.isDestroyed){
      messageClient(%player.client, 'msgStationDestroyed', '\c2Station is destroyed.');
   }
   else if(isObject(%station) && %station.isEnabled() &&  %station.isPowered()){
      messageClient(%player.client, 'CloseHud', "", 'inventoryScreen');
      commandToClient(%player.client, 'TogglePlayHuds', true);
      if(%targetname $= "weaponBuilder"){
         if(isObject(%player.client.hasDrkWep) && %player.hasInventory(%player.client.hasDrkWep)){
            messageClient(%player.client, 'MsgClient', '\c0You already have a built weapon.~wfx/powered/station_denied.wav');
            return;
         }
         commandToClient(%player.client, 'BuildWep', 1);
         %player.client.wepStation = %station;
      }
      else if(%targetname $= "T2AmmoDeployableObj"){
         %station.playAudio(2, DepInvActivateSound);
         getAmmoStationLovin2(%player.client);
         %player.setVelocity("0 0 0");
         %oldRate = %player.getRepairRate();
         %player.setRepairRate(%oldRate + 0.00625);
         %station.playThread(2, "activate"); 
      }
   }
   %trigger.lastObj = %player;
}

function getAmmoStationLovin2(%client)
{
   // z0dd - ZOD, 4/24/02. This function was quite a mess, needed rewrite
   %cmt = $CurrentMissionType;

   // weapons
   for(%i = 0; %i < %client.player.weaponSlotCount; %i++)
   {
      %weapon = %client.player.weaponSlot[%i];
      if(%weapon.image.ammo $= "DarkAmmo"){
         if(!%weapon.isEx){
            %ammo = getField($darkWep[%client.wt, %client.wc],1);
            %bonusAmmo = ((%client.mod1 == 3) * mFloor(%ammo * 0.25)) + ((%client.mod2 == 3) * mFloor(%ammo * 0.5))  + ((%client.mod3 == 3) * mFloor(%ammo * 1));
            %client.player.setInventory("DarkAmmo", mFloor(%ammo + %bonusAmmo),true); 
         }
      }
      else if ( %weapon.image.ammo !$= "" ){
         %client.player.setInventory( %weapon.image.ammo, 999 );
      }
   }

   // grenades
   for(%i = 0; $InvGrenade[%i] !$= ""; %i++) // z0dd - ZOD, 5/27/03. Clear them all in one pass
        %client.player.setInventory($NameToInv[$InvGrenade[%i]], 0);

   for ( %i = 0; %i < getFieldCount( %client.grenadeIndex ); %i++ )
   {
      %client.player.lastGrenade = $NameToInv[%client.favorites[getField( %client.grenadeIndex, %i )]];
   }
   %grenType = %client.player.lastGrenade;
   if(%grenType $= "")
   {
      %grenType = Grenade;
   } 
   if ( !($InvBanList[%cmt, %grenType]) )
      %client.player.setInventory( %grenType, 30 );

   if(%grenType $= "Deployable Camera")
   {
      %maxDep = $TeamDeployableMax[DeployedCamera];
      %depSoFar = $TeamDeployedCount[%client.player.team, DeployedCamera];
      if(Game.numTeams > 1)
         %msTxt = "Your team has "@%depSoFar@" of "@%maxDep@" Deployable Cameras placed.";
      else
         %msTxt = "You have placed "@%depSoFar@" of "@%maxDep@" Deployable Cameras.";
      messageClient(%client, 'MsgTeamDepObjCount', %msTxt);
   }

   // Mines
   for(%i = 0; $InvMine[%i] !$= ""; %i++) // z0dd - ZOD, 5/27/03. Clear them all in one pass
        %client.player.setInventory($NameToInv[$InvMine[%i]], 0);

   for ( %i = 0; %i < getFieldCount( %client.mineIndex ); %i++ )
   {
      %client.player.lastMine = $NameToInv[%client.favorites[getField( %client.mineIndex, %i )]];
   }
   %mineType = %client.player.lastMine;
   if(%mineType $= "")
   {
      %mineType = Mine;
   }
   if ( !($InvBanList[%cmt, %mineType]) )
      %client.player.setInventory( %mineType, 30 );

   // miscellaneous stuff -- Repair Kit, Beacons, Targeting Laser
   if ( !($InvBanList[%cmt, RepairKit]) )
      %client.player.setInventory( RepairKit, 1 );

   if ( !($InvBanList[%cmt, Beacon]) )
      %client.player.setInventory( Beacon, 20 );

   if ( !($InvBanList[%cmt, TargetingLaser]) )
      %client.player.setInventory( TargetingLaser, 1 );

   if( %client.player.getMountedImage($BackpackSlot) $= "AmmoPack" )
      invAmmoPackPass(%client);
}

function SimObject::getUpVector(%obj){
   %rot = getWords(%obj.getTransform(), 3, 6);  
   %tmat = VectorOrthoBasis(%rot);
   return getWords(%tMat, 6, 8);
}

function anomalyTrig::onEnterTrigger(%data, %trigger, %player){
   %mode = %trigger.mode;
   if(isObject(PZones)){
      PZones.delete();
   }
   switch(%mode){
      case 1:
         if(%trigger.ispowered()){
            %player.setPosition(%trigger.getWorldBoxCenter());
            %vel = VectorScale(VectorNormalize(%trigger.getForwardVector()), 90);   
            %player.setVelocity(%vel);
            if(getSimTime() - %player.boostTrigTime > 2000){
               serverPlay3D(forceTrig, %trigger.getTransform());
               %player.client.play2D(aboostSound);
            }
            %player.boostTrigTime = getSimTime();
         }
         else{
            if(getSimTime() - %player.boostTrigMsgTime > 5000){
               messageClient(%player.client, 'MsgClient', '\c0Cannon is not powered.~wfx/powered/station_denied.wav');
            }
            %player.boostTrigMsgTime = getSimTime();
         }
         %player.lastBoostTime = getSimTime();
      case 2:
         if(%trigger.ispowered()){
            %trigPos = %trigger.getWorldBoxCenter();
            %player.setPosition(%trigPos);
            %vel = VectorScale(VectorNormalize(%trigger.getForwardVector()), 160);   
            %player.setVelocity(%vel);
            serverPlay3D(ACannonExpSound, %trigger.getTransform());
            cannonEffect(%trigger);
         }
         else{
            messageClient(%player.client, 'MsgClient', '\c0Cannon is not powered.~wfx/powered/station_denied.wav');
         }
         %player.lastBoostTime = getSimTime();
      case 3:
         if(Game.unlockDarkWep){
            %player.setInventory(DarkWeaponX, 1, true);
            %player.setInventory(DarkAmmo, 1, true);
            %player.use(DarkWeaponX);
         }
         else{
            %minLeft = $Anomaly::dkwUnlockTimeMin - mCeil((Game.loopTime / 1000) / 60);
            %pos = 1024*5 SPC 1024*5 SPC 250;
            %plrPos = %player.getPosition();
            %p = new SniperProjectile() {
               dataBlock        =  MOACShot;
               initialDirection = vectorNormalize(vectorSub(%plrPos, %pos));
               initialPosition  = %pos;
               sourceObject     = -1;
               damageFactor     = 2;
               sourceSlot       = "";
               sObj = %obj;
            };
            %p.setEnergyPercentage(1);
            MissionCleanup.add(%p);
            messageClient(%player.client, 'MsgClient', '\c0The dark weapon unlocks in %1 minutes.~wfx/powered/station_denied.wav', %minLeft);
         }
      default:
         return;
   }
}
function cannonEffect(%trigger){
       %p = new LinearFlareProjectile() {
         dataBlock        = ACannonEffect;
         initialDirection = vectorScale(%trigger.getForwardVector(),-1);
         initialPosition  = vectorAdd(%trigger.getWorldBoxCenter(),vectorScale(%trigger.getForwardVector(),8));
         sourceObject     = -1;
         sourceSlot       = 0;
         vehicleObject    = 0;
      };
      MissionCleanup.add(%p);  
}
function testBeam(){
      %pos = 1024*5 SPC 1024*5 SPC 450;
      %plrPos =  1024*5 SPC 1024*5 SPC -200;
      %p = new SniperProjectile() {
         dataBlock        =  MOACShot;
         initialDirection = "0 0 -1";
         initialPosition  = %pos;
         sourceObject     = -1;
         damageFactor     = 2;
         sourceSlot       = "";
         sObj = %obj;
      };
      %p.setEnergyPercentage(1);
      MissionCleanup.add(%p);
}

datablock ExplosionData(moacBeamExplosion)
{
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = ShapeExplosionSound;
   faceViewer = true;

   //emitter[0] = Weapon10ExplosionEmitter;
   //emitter[1] = Weapon10RifleEmitter;
   colors[0] = "0.0 0.0 1.0 0.0";
   colors[1] = "0.0 0.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1;
   sizes[0] = "10.0 10.0 10.0";
   sizes[1] = "1.0 1.0 1.0";

};

datablock SniperProjectileData(MOACShot){

   directDamage        = 30;
   hasDamageRadius     = true;
   indirectDamage      = 50;
   damageRadius        = 30.0;
   velInheritFactor    = 1.0;
   //sound 			   = Weapon10ProjectileSound;
   explosion           = "moacBeamExplosion";
   splash              = PlasmaSplash;
   directDamageType    = $DamageType::outOfBounds;

   maxRifleRange       = 1000;
   rifleHeadMultiplier = 3.3;   //may be added later
   beamColor           = "0 0 1";
   fadeTime            = 0.8;

   startBeamWidth		  = 18.2;
   endBeamWidth 	     = 18.2;
   pulseBeamWidth 	  = 18.5;
   beamFlareAngle 	  = 3.0;
   minFlareSize        = 0.0;
   maxFlareSize        = 400.0;
   pulseSpeed          = 6.0;
   pulseLength         = 0.050;

   lightRadius         = 5.0;
   lightColor          = "0 0.0 1";

   textureName[0]      = "special/flare";
   textureName[1]      = "special/nonlingradient";
   textureName[2]      = "special/laserrip01";
   textureName[3]      = "special/laserrip02";
   textureName[4]      = "special/laserrip03";
   textureName[5]      = "special/laserrip04";
   textureName[6]      = "special/laserrip05";
   textureName[7]      = "special/laserrip06";
   textureName[8]      = "special/laserrip07";
   textureName[9]      = "special/laserrip08";
   textureName[10]     = "special/laserrip09";
   textureName[11]     = "special/sniper00";

};

function anomalyTrig::onTriggerTick(%this, %triggerId){
 // anti spam
}
function anomalyTrig::onleaveTrigger(%data, %trigger, %player){

}

datablock ParticleData(ACannonSmokeParticle){
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.1;
   inheritedVelFactor   = 0.00;

   lifetimeMS           = 2000;
   lifetimeVarianceMS   = 150;

   textureName          = "bsmoke02";

   useInvAlpha = 1;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "0.2 0.2 0.2 1.0";
   colors[1]     = "0.2 0.2 0.2 1.0";
   colors[2]     = "0.2 0.2 0.2 0.0";

   sizes[0]      = 0.25;
   sizes[1]      = 4.5;
   sizes[2]      = 4.5;

   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(ACannonSmokeEmitter){
   ejectionPeriodMS = 5;
   periodVarianceMS = 1;

   ejectionVelocity = 14.25;
   velocityVariance = 0.50;

   thetaMin         = 0.0;
   thetaMax         = 90.0;
   lifetimeMS       = 1000;
   particles = "ACannonSmokeParticle";
};

datablock ParticleData(ACannonExplosionSmoke){
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = 1.0;   
   inheritedVelFactor   = 0.025;
   lifetimeMS           = 100;
   lifetimeVarianceMS   = 0;
   textureName          = "particleTest";
   useInvAlpha =  0;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   colors[0]     = "0.9 0.3 0.0 1.0";
   colors[1]     = "0.9 0.3 0.0 1";
   colors[2]     = "0.9 0.3 0.1 1";
   sizes[0]      = 16.0;
   sizes[1]      = 16.0;
   sizes[2]      = 12.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(AHeavyExplosionSmokeEmitter){
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;
   ejectionVelocity = 520.25;
   velocityVariance = 0.25;
   thetaMin         = 0.0;
   thetaMax         = 35.0;
   lifetimeMS       = 200;

   particles = "ACannonExplosionSmoke";
};

datablock ShockwaveData(ACannonShockwave){
   width = 30;
   numSegments = 32;
   numVertSegments = 7;
   velocity = 200;
   acceleration = 50.0;
   lifetimeMS = 600;
   height = 0.5;
   verticalCurve = 0.375;

   mapToTerrain = false;
   renderBottom = true;
   orientToNormal = true;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 3.0;

   times[0] = 1.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.5 0.5 0.0 1.0";
   colors[1] = "0.7 0.5 0.0 1.0";
   colors[2] = "0.9 0.3 0.0 1.0";
}; 

datablock AudioProfile(aboostSound){
   filename    = "fx/Bonuses/upward_straipass2_elevator.wav";
   description = AudioExplosion3d;
   preload = true;
};
datablock AudioDescription(AudioBIGXAExplosion3d){
   volume   = 1.0;
   isLooping= false;

   is3D     = true;
   minDistance= 50.0;
   MaxDistance= 440.0;
   type     = $EffectAudioType;
   environmentLevel = 1.0;
};
datablock AudioProfile(ACannonExpSound){
   filename    = "fx/powered/turret_mortar_explode.wav";
   description = "AudioBIGXAExplosion3d";
   preload = true;
};
datablock ExplosionData(ACannonExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;

   delayMS = 200;

   offset = 0.0;

   playSpeed = 1.5;

   sizes[0] = "6.0 6.0 6.0";
   sizes[1] = "6.0 6.0 6.0";
   times[0] = 0.0;
   times[1] = 1.0;

   shockwave      = ACannonShockwave;
   emitter[0] = ACannonSmokeEmitter;
   emitter[1] = AHeavyExplosionSmokeEmitter;
  //emitter[2] = HeavyCrescentEmitter;

   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 1;
   camShakeRadius = 150.0;
};

datablock LinearFlareProjectileData(ACannonEffect){
   projectileShapeName = "plasmabolt.dts";
   scale               = "0.1 0.1 0.1";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = false;
   indirectDamage      = 0.0;
   damageRadius        = 0.0;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Plasma;

   explosion           = "ACannonExplosion";

   dryVelocity       = 1; 
   wetVelocity       = 1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0;
   lifetimeMS        = 128;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.2;
   size[1]           = 0.5;
   size[2]           = 0.1;


   numFlares         = 35;
   flareColor        = "1 0.75 0.25";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

	sound        = PlasmaProjectileSound;
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;
   
   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
};

datablock ForceFieldBareData(APlrCannonBlocker)
{
   fadeMS           = 1000;
   baseTranslucency = 0.01;
   powerOffTranslucency = 0.0;
   teamPermiable    = true;
   otherPermiable   = false;
   color            = "0.28 0.89 0.31";
   powerOffColor    = "0.0 0.0 0.0";
   targetTypeTag    = 'ForceField'; 

   texture[0] = "skins/forcef1";
   texture[1] = "skins/forcef2";
   texture[2] = "skins/forcef3";
   texture[3] = "skins/forcef4";
   texture[4] = "skins/forcef5";

   framesPerSec = 10;
   numFrames = 5;
   scrollSpeed = 15;
   umapping = 1.0;
   vmapping = 0.15;
};




datablock AudioProfile(TeleporterAStart){
   filename    = "fx/misc/nexus_cap.wav";
   description = AudioDefault3d;
   preload = true;
};


datablock StaticShapeData(TeleporterA){
   catagory = "Teleporters";
   shapefile = "station_teleport.dts";
   mass = 10;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   targetNameTag = '';
   targetTypeTag = 'Teleporter';
//----------------------------------
   maxDamage = 1.00;
   destroyedLevel = 1.00;
   disabledLevel = 0.70;
   explosion      = ShapeExplosion;
   expDmgRadius = 8.0;
   expDamage = 0.4;
   expImpulse = 1500.0;
   // don't allow this object to be damaged in non-team-based
   // mission types (DM, Rabbit, Bounty, Hunters)
   noIndividualDamage = true;

   dynamicType = $TypeMasks::StationObjectType;
   isShielded = true;
   energyPerDamagePoint = 75;
   maxEnergy = 50;
   rechargeRate = 0.35;
   doesRepair = true;
   humSound = StationInventoryHumSound;

   cmdCategory = "Support";
   cmdIcon = CMDStationIcon;
   cmdMiniIconName = "commander/MiniIcons/com_inventory_grey";

   debrisShapeName = "debris_generic.dts";
   debris = StationDebris;
};

//datablock Staticshapedata(teledestroyed) : teleporter
//{
   //shapefile = "station_teleport.dts";
//};

$playerreject = 6;
function TeleporterA::onDestroyed(%data, %obj, %prevState){
   //set the animations
   %obj.playThread(1, "transition");
   %obj.setThreadDir(1, true);
   %obj.setDamageState(Destroyed);
   //%obj.setDatablock(teledestroyed);
   %obj.getDataBlock().onLosePowerDisabled(%obj);
}
function TeleporterA::damageObject(%data, %targetObject, %sourceObject, %position, %amount, %damageType){
   if( %targetObject.invincible)
		return; 
   parent::damageObject(%data, %targetObject, %sourceObject, %position, %amount, %damageType);
}
//---this is where I create the triggers and put them right over the nexus base's
function TeleporterA::onEnabled(%data, %obj, %prevState){ 
   %level = %obj.getdamagelevel();
  %obj.setdamagelevel(%level);
   if(%obj.ispowered())
   {
      %obj.playthread(1, "transition");
      %obj.setThreadDir(1, false);
      %obj.playThread(0, "ambient");
      %obj.setThreadDir(0, true);
   }
   else
   {
      %obj.playThread(0, "transition");
      %obj.setThreadDir(0, false);
   }
  Parent::onEnabled(%data, %obj, %prevState);
}

function TeleporterA::gainPower(%data, %obj){
   //%obj.setDatablock(teleporter);
   Parent::gainPower(%data, %obj);
   %obj.playthread(1, "transition");
   %obj.setThreadDir(1, false);
   %obj.playThread(0, "ambient");
   %obj.setThreadDir(0, true);
}

function TeleporterA::losePower(%data, %obj){
   %obj.playThread(0, "transition");
   %obj.setThreadDir(0, false);
   Parent::losePower(%data, %obj);
}

function TeleporterA::onAdd(%this, %tp){
   Parent::onAdd(%this, %tp);
   if(!isObject(tpSimSet)){
      new simSet(tpSimSet);
      MissionCleanup.add(tpSimSet);
   }
   tpSimSet.add(%tp);
   
   %trigger = new Trigger()
   {
      dataBlock = NewTeleportATrigger;
      polyhedron = "-0.75 0.75 0.1 1.5 0.0 0.0 0.0 -1.5 0.0 0.0 0.0 2.3";
   };
   
   MissionCleanup.add(%trigger);
   if(%tp.noflag $= "")
      %tp.noflag = "0";
   if(%tp.oneway $= "")
      %tp.oneway = "0";
   if(%tp.linkID $= "")
      %tp.linkID = "0";
   if(%tp.linkTo $= "")
      %tp.linkTo = "0";
   if(%tp.invincible $= ""){
      %tp.invincible = 1;
   }
   if(%tp.teamOnly $= ""){
      %tp.teamOnly = 1;
   }

   %trigger.setTransform(%tp.getTransform());
   
   %trigger.sourcebase = %tp;
   %tp.trigger = %trigger;

 //--------------do we need power?-----------------------
   %tp.playThread(1, "ambient");
   %tp.playThread(0, "transition");
   %tp.playThread(0, "ambient");

   %pos = %trigger.position;

}


datablock TriggerData(NewTeleportATrigger){
   tickPeriodMS =  256;
};


function NewTeleportATrigger::onEnterTrigger(%data, %trigger, %player)
{
   %colObj = %player;
   %client = %player.client;

   if(%player.transported $= "1")  // if this player was just transported
   {
      %player.transported = "0";
      %colObj.setMoveState(false);
      %trigger.player = %player;
      return; // then get out or it will never stop
   }

//--------------do we have power?-----------------------
   if(%trigger.sourcebase.ispowered() == 0){
      messageClient(%player.client, 'MsgClient', '\c0Teleporter is not powered.~wfx/powered/station_denied.wav');
      return;
   }

//----------------------disabled?-----------------------
   if(%trigger.sourcebase.isDisabled()){
      messageClient(%colObj.client, 'msgStationDisabled', '\c2Teleporter is disabled.~wfx/powered/station_denied.wav');
      return;
   }

//--------------are we on the right team?-----------------------
   if(%player.team != %trigger.sourcebase.team && %trigger.sourcebase.teamOnly){
      messageClient(%player.client, 'MsgClient', '\c0Wrong team.~wfx/powered/station_denied.wav');
      return;
   }

   //------------are we teleporting?-----------------------
   if(isObject(%trigger.player)){
      messageClient(%player.client, 'MsgClient', '\c0Teleporter in use.~wfx/powered/station_denied.wav');
      return;
   }
   //-------------is this a oneway teleporter?------------------------
   if(%trigger.sourcebase.oneway == "1"){
      messageClient(%player.client, 'MsgLeaveMissionArea', '\c1This teleporter is oneway only.~wfx/powered/station_denied.wav');
      return;
   }

   //-------------are we teleporting with flag?----------------------------------------
   %flag = %player.holdingflag;
   if(%player.holdingFlag > 0){
      if(%trigger.sourcebase.noflag $= "1"){
         if(%flag.team == 1)
            %otherTeam = 2;
         else
            %otherTeam = 1;

         //game.flagReset(%player.holdingflag);
         Game.dropFlag(%player); 
         messageClient(%player.client, 'MsgClient', '\c0Cant teleport with flag');
         //messageTeam(%flag.team, 'MsgCTFFlagReturned', '\c2Your flag was returned.~wfx/misc/flag_return.wav', 0, 0, %flag.team);
         //messageTeam(0, 'MsgCTFFlagReturned', '\c2The %2 flag was returned to base.~wfx/misc/flag_return.wav', 0, $teamName[%flag.team], %flag.team);
      }
   }
   %destList = getDestTeleA(%trigger.sourcebase,%player.client);
   
   if(%destList != -1){
      %vc = 0;
      for(%x = 0; %x < getFieldCount(%destList); %x++){
         %targetObj = getField(%destList,%x);
         // make sure its not in use  and its not destroyed  and it has power 
         if(!isObject(%targetObj.trigger.player) && %targetObj.isEnabled() && %targetObj.isPowered())
            %validTarget[%vc++] = %targetObj;
         else
            %inValidTarget[%ivc++] = %targetObj;
         
      }
      if(!%vc){
         if(isObject(%inValidTarget[1].trigger.player))
            messageClient(%player.client, 'MsgClient', '\c0Destination teleporter in use.~wfx/powered/station_denied.wav');
         else if(!%inValidTarget[1].isEnabled())
            messageClient(%player.client, 'MsgClient', '\c0Destination teleporter is destroyed.~wfx/powered/station_denied.wav');
         else if(!%inValidTarget[1].isPowered())
            messageClient(%player.client, 'MsgClient', '\c0Destination teleporter lost power.~wfx/powered/station_denied.wav');
         else
            messageClient(%player.client, 'MsgClient', '\c0Destination teleporter in use, destroyed, or loss power.~wfx/powered/station_denied.wav');
      }
      else{
         %dest = %validTarget[getRandom(1,%vc)];
         serverPlay3D(TeleporterAStart, %trigger.getTransform());
         messageClient(%player.client, 'MsgClient', '~wfx/misc/nexus_cap.wav');  
         %player.transported = 1;
         %teleDest =  vectorAdd(%dest.getPosition(),"0 0 0.5");
         teleporteffect(vectorAdd(%trigger.sourcebase.getPosition(),"0 0 0.5"));
         teleporteffect(%teleDest);
         %player.setmovestate(true);
         %player.setTransform(vectorAdd(%trigger.sourcebase.getPosition(),"0 0 0.5") SPC getWords(%player.getTransform(),3,6));
         %player.startfade(500,0,true);
         %player.schedule(500, "settransform", %teleDest SPC getWords(%player.getTransform(),3,6));
         %player.schedule(500, "startfade", 500, 0, false);
         %player.schedule(500, "setmovestate", false);
      }
   }
   else
      messageClient(%player.client, 'MsgLeaveMissionArea', '\c1This teleporter has no destination.~wfx/misc/warning_beep.wav');   
}
function getDestTeleA(%obj,%client){
   %idCount = getFieldCount(%obj.linkTo);
   if(!%idCount || %obj.team != %client.team)
      return -1;
   %count = 0;
   for(%i = 0; %i < tpSimSet.getCount(); %i++){
      %dest = tpSimSet.getObject(%i);
      if(%dest.team == %client.team && %dest != %obj){
         for(%a = 0; %a <  getFieldCount(%dest.linkTo); %a++){
            %destID = getField(%dest.linkTo,%a);
            if(%obj.linkID == %destID){// see if it links back to us
               if(%count++ == 1)
                  %teleList = %dest;
               else
                  %teleList = %teleList TAB %dest;
            }
         }
      }
   }
   if(%count > 0){
      return %teleList;
   }
   return -1;
}

function NewTeleportATrigger::onleaveTrigger(%data, %trigger, %player){
   if(%player == %trigger.player){
      %trigger.player = 0;  
   }
   if(!%player.transported){
      %player.tpWarn  = 0;
      %player.tpTime = 0;
      %player.tpDmgTime = 0;
   }
}

function NewTeleportATrigger::onTickTrigger(%data, %trig){
   %player = %trig.player; 
   if(isObject(%player)){
     if(%player.getState() $= "Dead"){
        %player.blowUp();
        %trig.player = 0;
     }
     else{
         if(%player.tpTime > 3000 && !%player.tpWarn){
            messageClient(%player.client, 'MsgLeaveMissionArea', '\c1Move off the teleporter or take damage.~wfx/misc/warning_beep.wav');
            %player.tpWarn = 1;         
         }
         %player.tpTime += %data.tickPeriodMS;
         if(%player.tpTime > 3000){
            %player.tpDmgTime += %data.tickPeriodMS;
            if(%player.tpDmgTime > 1000){
               %player.setdamageflash(0.3);
               %player.damage(0, %player.getPosition(), 0.04, $DamageType::Explosion);
            }
         }
     }
   }
   else
      %trig.player = 0;
}

function teleporteffect(%position){   
   %effect1 = new ParticleEmissionDummy(){
      position = %position;
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = "doubleTimeEmissionDummy";
      emitter = "AABulletExplosionEmitter2";
      velocity = "1";
   };

   %effect2 = new ParticleEmissionDummy(){
      position = getWord(%position,0) SPC getWord(%position,1) SPC getWord(%position,2) + 0.5;
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = "doubleTimeEmissionDummy";
      emitter = "AABulletExplosionEmitter2";
      velocity = "1";
   };

   %effect3 = new ParticleEmissionDummy(){
      position = getWord(%position,0) SPC getWord(%position,1) SPC getWord(%position,2) + 1;
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = "doubleTimeEmissionDummy";
      emitter = "AABulletExplosionEmitter2";
      velocity = "1";
   };

   %effect4 = new ParticleEmissionDummy(){
      position = getWord(%position,0) SPC getWord(%position,1) SPC getWord(%position,2) + 1.5;
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = "doubleTimeEmissionDummy";
      emitter = "AABulletExplosionEmitter2";
      velocity = "1";
   };
   MissionCleanup.add(%effect1);
   MissionCleanup.add(%effect2);
   MissionCleanup.add(%effect3);
   MissionCleanup.add(%effect4);
   %effect1.schedule(2000, "delete");
   %effect2.schedule(2000, "delete");
   %effect3.schedule(2000, "delete");
   %effect4.schedule(2000, "delete");
}

function SimObject::getUpVector(%obj){
   %rot = getWords(%obj.getTransform(), 3, 6);  
   %tmat = VectorOrthoBasis(%rot);
   return getWords(%tMat, 6, 8);
}




















function giveBigWep(){
   %player = LocalClientConnection.player; 
   %player.setInventory("ThetaStrike", 1, true);
   %player.setInventory("DarkWeaponX", 1, true);
   %player.setInventory("StarNova", 1, true);
   %player.setInventory("ZapNukeGun", 1, true);
   %player.setInventory("DarkAmmo", 15, true);
}

datablock ItemData(DarkAmmo){
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_disc.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon ammo";
};

///////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////

datablock ItemData(DarkWeaponX){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = DarkWeaponXImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";

   isEX = true; 
	
	wepClass = "EX";
   wepNameID = "????";
   wepName = "Dark Weapon";
   light = 0;
   medium = 0;
   heavy = 0;
   description = "A weapon of ultimate destruction, the consequences of its deployment are unknown and potentially catastrophic";
};

datablock AudioProfile(DarkWeaponXSwitchSound){
   filename    = "fx/vehicles/bomber_bomb_dryfire.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock ParticleData( DarkWeaponXCrescentParticle ){
   dragCoefficient      = 2;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 000;
   textureName          = "special/crescent3";
   colors[0]     = "0.9 0.4 0.0 1.0";
   colors[1]     = "0.9 0.4 0.0 1.0";
   colors[2]     = "0.9 0.4 0.0 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 1.0;
   sizes[2]      = 1.6;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( DarkWeaponXCrescentEmitter ){
   ejectionPeriodMS = 15;
   periodVarianceMS = 0;
   ejectionVelocity = 60;
   velocityVariance = 5.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 200;
   particles = "DarkWeaponXCrescentParticle";
};

datablock ParticleData(DXParticle){
   dragCoefficient      = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = -3.5;
   lifetimeMS           = 6000;
   lifetimeVarianceMS   = 500;
   useInvAlpha          =  0;
   textureName          = "special/bigSpark";
   colors[0]     = 2/255 SPC 68/255 SPC 252/255  SPC 1;
   colors[1]     = 2/255 SPC 68/255 SPC 252/255  SPC 1;
   sizes[0]      = 0.5;
   sizes[1]      = 9;
};

datablock ParticleEmitterData(DarkXEmitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 10;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 90;
   lifetimeMS       = 9000;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   orientParticles  = true;
   overrideAdvances = false;
   particles = "DXParticle";
};

datablock ParticleData(DX2Particle){
   dragCoefficient      = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = -3.5;
   lifetimeMS           = 6000;
   lifetimeVarianceMS   = 500;
   useInvAlpha          =  0;
   textureName          = "special/bigSpark";
   colors[0]     = 249/255 SPC 147/255 SPC 0  SPC 1;
   colors[1]     = 249/255 SPC 147/255 SPC 0  SPC 1;
   sizes[0]      = 0.5;
   sizes[1]      = 9;
};

datablock ParticleEmitterData(DarkX2Emitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 10;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 90;
   lifetimeMS       = 9000;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   orientParticles  = true;
   overrideAdvances = false;
   particles = "DX2Particle";
};

datablock ParticleData(BlastExplosionParticleS) {
   dragCoefficient = "1";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "1";
   lifetimeMS = "5376";
   lifetimeVarianceMS = "0";
   spinSpeed = "0";
   spinRandomMin = "-360";
   spinRandomMax = "720";
   useInvAlpha = "0";
   animateTexture = "0";
   framesPerSec = "1";
   textureCoords[0] = "0 0";
   textureCoords[1] = "0 1";
   textureCoords[2] = "1 1";
   textureCoords[3] = "1 0";
   animTexTiling = "0 0";
   textureName = "particleTest";
   colors[0] = "0.984 0.992 0.992 0.157";
   colors[1] = "0.984 0.984 0.992 0.173";
   colors[2] = "0.996 0.996 0.992 0.197";
   colors[3] = "0.996 0.996 0.992 0";
   sizes[0] = "150";
   sizes[1] = "150";
   sizes[2] = "150";
   sizes[3] = "150";
   times[0] = "0";
   times[1] = "0.0416667";
   times[2] = "0.125";
   times[3] = "0.375";
};

datablock ParticleEmitterData(BlastExplosionEmitterS) {
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "655.34";
   velocityVariance = "0";
   ejectionOffset = "100";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "180";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "0.0001";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "BlastExplosionParticleS";
   lifetimeMS = "150";
   lifetimeVarianceMS = "0";  
};

datablock ExplosionData(DarkWeaponXSubExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = BombExplosionSound;
   faceViewer           = true;
   particleEmitter = DarkX2Emitter;
   particleDensity = 5000;
   particleRadius = 50;
   faceViewer = true;
   offset = 0.0;
   playSpeed = 1.0;
   //explosionScale = "10.8 10.8 10.8";

   sizes[0] = "52.0 52.0 52.0";
   sizes[1] = "2.0 2.0 2.0";
   times[0] = 0.0;
   times[1] = 1.0;
   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;
};

datablock ExplosionData(DarkWeaponXExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = BombExplosionSound;
   faceViewer           = true;
   subExplosion[0] = DarkWeaponXSubExplosion;

   particleEmitter = DarkXEmitter;
   particleDensity = 10000;
   particleRadius = 100;
   faceViewer = true;
   offset = 0.0;
   playSpeed = 2.0;
   
   emitter[0]  = BlastExplosionEmitterS;
   emitter[1]  = BlastExplosionEmitterS;
   emitter[2]  = BlastExplosionEmitterS;
   emitter[3]  = BlastExplosionEmitterS;
   
   sizes[0] = "52.0 52.0 52.0";
   sizes[1] = "2.0 2.0 2.0";
   times[0] = 0.0;
   times[1] = 1.0;
   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 2;
   camShakeRadius = 600.0;
};

datablock LinearFlareProjectileData(DCShot){
   projectileShapeName = "plasmabolt.dts";
   scale               = "4.3 4.3 4.3";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.25;
   damageRadius        = 15.9;
   kickBackStrength    = 3000.0;
   radiusDamageType    = $DamageType::Dark;
   Impulse = true;
   explosion           = "DarkWeaponXExplosion";
   underwaterExplosion = "UnderwaterMortarExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 1;
   wetVelocity       = 1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0;
   lifetimeMS        = 1000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;


   size[0]           = 0.2;
   size[1]           = 0.5;
   size[2]           = 50.1;


   numFlares         = 150;
   flareColor        = "1 0 1";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "0 0.3 1";
   ignoreExEffects = 1;
};

datablock ShapeBaseImageData(DarkWeaponXImage){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = DarkWeaponX;
   ammo = DarkAmmo;
   offset = "0 0 0";
   
   projectile = DCShot;
   projectileType = LinearFlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = BomberBombDryFireSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 1.0;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   //stateSequence[3] = "Fire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = BomberBombReloadSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.3;
   stateAllowImageChange[4] = false;
   //stateSequence[4] = "Reload";
   stateSound[4] = PlasmaReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = PlasmaDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7]       = "WetFire";
   stateSound[7]      = PlasmaFireWetSound;
   stateTimeoutValue[7]        = 1.5;
   stateTransitionOnTimeout[7] = "Ready";

   stateName[8]               = "CheckWet";
   stateTransitionOnWet[8]    = "WetFire";
   stateTransitionOnNotWet[8] = "Fire";
};

datablock ShapeBaseImageData(DarkWeaponX3Image){
   offset = "-0.005 0.95 0.13";
   rotation = "0 1 0 180";
   shapeFile = "pack_upgrade_energy.dts";
    emap = true;
};

datablock ShapeBaseImageData(DarkWeaponX4Image){
   offset = "-0.005 1.05 0.13";
   rotation = "0 1 0 180";
   shapeFile = "pack_upgrade_energy.dts";
};

datablock ShapeBaseImageData(DarkWeaponX2Image){
   offset = "-0.005 1.15 0.13";
   rotation = "0 1 0 180";
   shapeFile = "pack_upgrade_energy.dts";
    emap = true;
};

datablock ShapeBaseImageData(DarkWeaponX5Image){
   offset = "-0.005 1.25 0.13";
   rotation = "0 1 0 180";
   shapeFile = "pack_upgrade_energy.dts";
};

function DarkWeaponXImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(DarkWeaponX2Image, 4);
   %obj.mountImage(DarkWeaponX3Image, 5);
   %obj.mountImage(DarkWeaponX4Image, 6);
   %obj.mountImage(DarkWeaponX5Image, 7);
   commandToClient( %obj.client, 'BottomPrint', "The Dark Weapon", 2, 3);
   %this.dwOnMount(%obj, %slot);
}

function DarkWeaponXImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %obj.unmountImage(7);
   %this.dwUnMount(%obj, %slot);
}


function DarkWeaponXImage::onFire(%data, %obj, %slot){
   if(!isObject($darkWeaponClient)){
      StartScriptObj.delete();
      aEffect.delete();
      messageAll('MsgClient', "\c2WARNING - The World Ender Has Been Fired!~wfx/misc/red_alert.wav");
      CancelCountdown();
      CancelEndCountdown();
      cancel(Game.timeCheck);
      cbase.team = 0;
      %obj.decInventory(%data.ammo, 1);
      %p = new (%data.projectileType)() {
         dataBlock        = %data.projectile;
         initialDirection = "0 0 -1";
         initialPosition  = "-4.41736 -3.32352 350";
         sourceObject     = %obj;
         sourceSlot       = %slot;
      };
      MissionCleanup.add(%p);
      for(%i = 0; %i < ClientGroup.getCount(); %i++){
         %tobj = ClientGroup.getObject(%i).getControlObject();
         %tobj.schedule(10,"setWhiteout", 0.8); 
      }
      %obj.schedule(1500,"setPosition", "-4.41736 -3.32352 350"); 
      schedule(1500, 0, "endStart"); 
      $darkWeaponClient = %obj.client;
      $darkWeaponTeam = %obj.client.team;
      %obj.theEnd = 1;
   }
}

datablock EnergyProjectileData(DKEnergyBolt){
   emitterDelay        = -1;
   // z0dd - ZOD, 5/07/04. Less damage shotgun blaster is gameplay changes in affect
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 2;
   damageRadius        = 10;
   kickBackStrength    = 8000.0;
   radiusDamageType    = $DamageType::Dark;
   // z0dd - ZOD, 5/07/04. Shotgun blaster no sound when gameplay changes in affect
   sound = HAPCFlyerThrustSound;
   velInheritFactor    = 0.5;

   explosion           = "SatchelMainExplosion";
   underwaterExplosion = "UnderwaterSatchelMainExplosion";
   splash              = BlasterSplash;


   grenadeElasticity = 0.998;
   grenadeFriction   = 0.0;
   armingDelayMS     = 12000;

   muzzleVelocity    = 90.0;

   drag = 0.05;

   gravityMod        = 1.0;

   dryVelocity       = 200.0;
   wetVelocity       = 150.0;

   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   hasLight    = true;
   lightRadius = 15.0;
   lightColor  = "1 0.3 0";

   scale = "0.25 20.0 1.0";
   crossViewAng = 0.99;
   crossSize = 0.55;

   lifetimeMS     = 30000;
   blurLifetime   = 1;
   blurWidth      = 0.25;
   blurColor = "1 0.5 0.0 1.0";

   texture[0] = "special/blasterBolt";
   texture[1] = "special/blasterBoltCross";
   ignoreExEffects = 1;
};

function DCShot::onExplode(%data, %proj, %pos, %mod){
   %obj =  %proj.sourceObject;
   %count = 256;
   for(%i = 0; %i < %count; %i++){
      %cycPos = tube(15, %count, %pos, vectorAdd(%pos,"0 0 1"), %i);//getRandom(0,15)
      %vec = vectorNormalize(vectorSub(%cycPos, %pos));
      %p = new EnergyProjectile(){
         dataBlock = DKEnergyBolt;
         initialDirection = %vec;
         initialPosition  = %pos;
         sourceObject = %obj;
         sourceSlot = 0;
      };
      MissionCleanup.add(%p);
   } 
   parent::onExplode(%data, %proj, %pos, %mod);
}

////////////////////////////////////////////////////////////////////////////////

datablock ShockwaveData( ENukeShockwave){
   width = 30;
   numSegments = 32;
   numVertSegments = 7;
   velocity = 100;
   acceleration = 1000.0;
   lifetimeMS = 2000;
   height = 800;
   verticalCurve = 0.375;

   mapToTerrain = true;
   renderBottom = true;
   orientToNormal = false;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.8 0.8 1.0 1.00";
   colors[1] = "0.8 0.5 1.0 0.20";
   colors[2] = "0.2 0.8 1.0 0.0";
};

datablock ExplosionData(ENukeExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;

   delayMS = 200;

   offset = 5.0;

   playSpeed = 1.5;

   sizes[0] = "6.0 6.0 6.0";
   sizes[1] = "6.0 6.0 6.0";
   times[0] = 0.0;
   times[1] = 1.0;

   shockwave      = ENukeShockwave;

   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 1;
   camShakeRadius = 150.0;
};

datablock LinearFlareProjectileData(EnukeProj){
   projectileShapeName = "plasmabolt.dts";
   scale               = "1 1 1";
   faceViewer          = true;
   directDamage        = 0;
   hasDamageRadius     = true;
   indirectDamage      = 1;
   damageRadius        = 7.7;
   kickBackStrength    = 0;
   radiusDamageType    = $DamageType::Dark;

   explosion = ENukeExplosion;
   splash              = PlasmaSplash;

   dryVelocity       = 0.1;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0;
   lifetimeMS        = 256;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.9;
   size[1]           = 1;
   size[2]           = 0.8;


   numFlares         = 80;
   flareColor        = "0 1 0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 5;
   lightColor  = "0 1 0";
};

datablock ParticleData(ECG){
    dragCoefficient = 1.0;
    gravityCoefficient = 0;
    windCoefficient = 0;
    inheritedVelFactor = 0;
    constantAcceleration = 0;
    lifetimeMS = 12000;
    lifetimeVarianceMS = 1000;
    useInvAlpha = 0;
    spinRandomMin = -90;
    spinRandomMax = 500;
    textureName = "special/lightning2frame2";
    times[0] = 0;
    times[1] = 0.5;
    times[2] = 1;
    colors[0] = "0.0 0.3 1.0 1.0";
    colors[1] = "0.0 0.3 1.0 1.0";
    colors[2] = "0.0 0.3 1.0 1.0";
    sizes[0] = 30;
    sizes[1] = 30;
    sizes[2] = 30;
};

datablock ParticleEmitterData(ECGEmitter){
   ejectionPeriodMS = 1;
    periodVarianceMS = 0;
    ejectionVelocity = 350;
    velocityVariance = 0;
    ejectionOffset =   0;
    thetaMin = 90;
    thetaMax = 91;
    phiReferenceVel = 0;
    phiVariance = 360;
    overrideAdvances = 0;
    lifeTimeMS = 30000;
    orientParticles= 1;
    orientOnVelocity = 0;

   particles = "ECG";
};

datablock ParticleData(IonRing){
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 15000;
   lifetimeVarianceMS   = 350;
   textureName          = "special/bigspark";
   colors[0]     = "0.9 0.3 0.0 1.0";
   colors[1]     = "0.9 0.3 0.0 1.0";
   colors[2]     = "0.9 0.3 0.0 1.0";
   sizes[0]      = 5.0;
   sizes[1]      = 5.0;
   sizes[2]      = 5.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(IonRingEmitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 50;
   velocityVariance = 0;
   ejectionOffset   = 0.0;
   thetaMin         = 60;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 15000;
   particles = "IonRing";
};

datablock ExplosionData(ECGExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = BombExplosionSound;

   faceViewer           = true;
   explosionScale = "10.8 10.8 10.8";

   emitter[0] = ECGEmitter;
   emitter[1] = IonRingEmitter;

   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;
};

datablock LinearFlareProjectileData(ECGFlashBolt){
   //projectileShapeName = "disc_explosion.dts";
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.0;
   damageRadius        = 7.7;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Dark;

   explosion           = "ECGExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 0.1;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0000;
   lifetimeMS        = 1000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.9;
   size[1]           = 1.0;
   size[2]           = 0.8;


   numFlares         = 80;
   flareColor        = "0.0 1.0 0.0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0 1.0 0";
};


function pointToPosx(%posOne, %posTwo){
   %vec = VectorSub(%posTwo, %posOne);
   // pull the values out of the vector
   
   %x = getWord(%vec, 0);
   %y = getWord(%vec, 1);
   %z = getWord(%vec, 2);
 
   //this finds the distance from origin to our point
  // %xylen =  vectorDist(getWords(%posOne,0,1) SPC 0, getWords(%posTwo,0,1) SPC 0);
   %len = vectorLen(%vec);
   
   //---------X-----------------
   //given the rise and length of our vector this will give us the angle in radians
   %rotAngleX = mATan( %z, %len );
   
   //---------Z-----------------
   //get the angle for the z axis
   %rotAngleZ = mATan( %x, %y );
 
   //create 2 matrices, one for the z rotation, the other for the x rotation
   %matrix = MatrixCreateFromEuler("0 0" SPC %rotAngleZ * -1);
   %matrix2 = MatrixCreateFromEuler(%rotAngleX SPC "0 0");
 
   //now multiply them together so we end up with the rotation we want
   %finalMat = MatrixMultiply(%matrix, %matrix2);
 
   //we're done, send the proper numbers back
   return getWords(%finalMat, 3, 6);
}


function newboom(){
   
   %part = new ParticleEmissionDummy() {
      position =  "100 4096 102";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = tripTimeEmissionDummy;
      emitter = "BlastExplosionEmitterS";
      velocity = "1";
   };  
   MissionCleanup.add(%part);
   %part.schedule(10000, "delete");
   %part.setScopeAlways();
   %part = new ParticleEmissionDummy() {
      position = "100 4096 102";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = defaultEmissionDummy;
      emitter = "BlastShockwaveEmitter";
      velocity = "1";
   }; 
   MissionCleanup.add(%part);
   %part.schedule(10000, "delete");
   %part.setScopeAlways();
       %p = new LinearFlareProjectile() {
         dataBlock        = explTwo;
         initialDirection ="0 0 -1";
         initialPosition  = "100 4096 102";
         sourceObject     = -1;
         sourceSlot       = 0;
         vehicleObject    = 0;
      };  
      MissionCleanup.add(%p);
   %p.setScopeAlways();
   %p = new LinearFlareProjectile() {
         dataBlock        = explOne;
         initialDirection ="0 0 -1";
         initialPosition  = "100 4096 102";
         sourceObject     = -1; 
         sourceSlot       = 0;
         vehicleObject    = 0;
      };  
   MissionCleanup.add(%p);
   %p.setScopeAlways();
   for(%i = 0; %i < 128; %i++){
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.15;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.15;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.15;
      %mat = MatrixCreateFromEuler(%x SPC %y SPC %z);
      %vector = MatrixMulVector(%mat,  "0 0 1");
      %p = new GrenadeProjectile() {
            dataBlock        = blastExplosionProj;
            initialDirection = %vector;
            initialPosition  = "100 4096 102";//vectorAdd(%position,"0 0 100");
            sourceObject     = -1; 
            sourceSlot       = 0;
            vehicleObject    = 0;
         };
      MissionCleanup.add(%p);
      //%p.setScopeAlways();
   }  
}

function aGameOver(){
    $TeamScore[$darkWeaponTeam] += $Anomaly::darkWeaponBonus;
   messageAll('MsgTeamScoreIs', "", $darkWeaponTeam, $TeamScore[$darkWeaponTeam]);
   messageAll('message', '\c2%1 used the Dark Weapon to end game, %3 Bonus points for team %2.~wfx/misc/MA3.wav', $darkWeaponClient.name, $darkWeaponTeam, $Anomaly::darkWeaponBonus);
   
   Game.gameOver();
   cycleMissions();
   $darkWeaponClient = 0;
   $darkWeaponTeam = 0; 
}
 


function randomBoom(%position){
   %p = new LinearFlareProjectile() {
         dataBlock        = explOne;
         initialDirection = "0 0 1";
         initialPosition  = %position;
         sourceObject     = -1; 
         sourceSlot       = 0;
         vehicleObject    = 0;
      };  
   MissionCleanup.add(%p);
   schedule(500,0,"delayEXBoom",%position);
   schedule(500,0,"partEXboom",%position,%vec);
}

function delayEXBoom(%position){
    %p = new LinearFlareProjectile() {
         dataBlock        = explTwo;
         initialDirection = "0 0 1";
         initialPosition  = %position;
         sourceObject     = -1;
         sourceSlot       = 0;
         vehicleObject    = 0;
      };  
}
function partEXboom(%position,%vec){
   %part = new ParticleEmissionDummy() {
      position =  %position;
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = tripTimeEmissionDummy;
      emitter = "BlastExplosionEmitterS";
      velocity = "1";
   };  
   MissionCleanup.add(%part);
   %part.schedule(10000, "delete");
   %part = new ParticleEmissionDummy() {
      position = %position;
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = defaultEmissionDummy;
      emitter = "BlastShockwaveEmitter";
      velocity = "1";
   }; 
   MissionCleanup.add(%part);
   %part.schedule(10000, "delete");
}

function testCubeStack(%pos){
      for(%i = 0; %i < 6; %i++){
      %p = new LinearFlareProjectile() {
         dataBlock        = CubeProj;
         initialDirection = "0 0 1";
         initialPosition  =  vectorAdd(%pos,"0 0" SPC %i * 100);
         sourceObject     = -1;
         sourceSlot       = 0;
         vehicleObject    = 0;
      };
      MissionCleanup.add(%p); 
   }   
}

function testStack(%pos){
   for(%i = 0; %i < 10; %i++){
      %p = new LinearFlareProjectile() {
         dataBlock        = ECGFlashBolt;
         initialDirection = "0 0 1";
         initialPosition  =  vectorAdd(%pos,"0 0" SPC %i * 40);
         sourceObject     = -1;
         sourceSlot       = 0;
         vehicleObject    = 0;
      };
      MissionCleanup.add(%p); 
   }   
}

function testWave(%pos){
   for(%i = 0; %i < 10; %i++){
      %p = new LinearFlareProjectile() {
         dataBlock        = EnukeProj;
         initialDirection = "0 0 1";
         initialPosition  =  %pos;
         sourceObject     = -1;
         sourceSlot       = 0;
         vehicleObject    = 0;
      };
      MissionCleanup.add(%p); 
   }
   for(%i = 0; %i < ClientGroup.getCount(); %i++){
      %cobj = ClientGroup.getObject(%i).getControlObject();
      %cobj.schedule(256,"setWhiteout", 0.8); 
   }   
   %time = 500;
   schedule(32+%time, 0, "ServerPlay2D", FusionExpSound);
   //schedule(64+%time, 0, "ServerPlay2D", FusionExpSound);
   schedule(224+%time, 0, "ServerPlay2D", FusionExpSound);
   //schedule(364+%time, 0, "ServerPlay2D", FusionExpSound);
}

function endStart(){
   %fireball = new FireballAtmosphere()
   {
      position = "0 0 250";
      rotation = "1 0 0 0"; 
      scale = "1 1 1";
      dataBlock = "fireball";
      lockCount = "1";
      homingCount = "1";
      dropRadius = 100;
      dropsPerMinute = 480;
      minDropAngle = "0";
      maxDropAngle = "50";
      startVelocity = "300";
      dropHeight = "2000";
      dropDir = "0.212 0.212 -0.953998";
   };
   MissionCleanup.add(%fireball);
   %pos = "4.41736 -3.32352 350";
   
   %lig = new Lightning() {
		position = %pos;
		rotation = "1 0 0 0";
		scale =  "2 2 800";
		dataBlock = "DefaultStorm";
		strikesPerMinute = 240;
		strikeWidth = "4";
		chanceToHitTarget = "0";
		strikeRadius = "1";
		boltStartRadius = "800";
		color = "1.0 1.0 1.0 1.0";
		fadeColor = "0.3 0.3 1.0 1.0";
		useFog = "1";
	};
	MissionCleanup.add(%lig);
   %lig.schedule(10000,"delete");
   %fireball.schedule(10000,"delete");
   schedule(1000+10000, 0, "testCubeStack", %pos); 
   schedule(5000+10000, 0, "testStack", %pos);
   schedule(14000+10000, 0, "testWave", %pos);
   schedule(14000+10000, 0, "randomBoom", %pos);
   for(%x = -2; %x < 2; %x++){
      for(%y = -2; %y < 2; %y++){
         schedule(15000+10000, 0, "randomBoom", vectorAdd(%pos, 256 * %x SPC 256 * %y SPC 0)); 
      }
   }
   schedule(16000+10000, 0, "aGameOver");
   schedule(16000+10000, 0, "newboom");
}

datablock ParticleData(CubeExplosionParticle){
   dragCoefficient      = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = -3.5;
   lifetimeMS           = 6000;
   lifetimeVarianceMS   = 500;
   useInvAlpha          =  0;
   textureName          = "special/bluespark";
   colors[0]     = "0.0 1.0 1.0 1.0";
   colors[1]     = "1.0 0.5 0.0 1.0";
   sizes[0]      = 0.5;
   sizes[1]      = 9;
};

datablock ParticleEmitterData(CubeExplosionEmitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 10;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 90;
   lifetimeMS       = 9000;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   orientParticles  = true;
   overrideAdvances = false;
   particles = "CubeExplosionParticle";
};

datablock ExplosionData(CubeExplosion){
   explosionShape = "effect_plasma_explosion.dts";
  // soundProfile   = EnukeExpSound;
   particleEmitter = CubeExplosionEmitter;
   particleDensity = 6250;
   particleRadius = 100;
   faceViewer = true;
   
   colors[0] = "0.0 0.0 1.0 0.0";
   colors[1] = "0.0 0.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 0.4;
   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
};

datablock LinearFlareProjectileData(CubeProj){
   projectileShapeName = "plasmabolt.dts";
   scale               = "1 1 1";
   faceViewer          = true;
   directDamage        = 0.30;
   hasDamageRadius     = false;
   indirectDamage      = 0;
   damageRadius        = 0;
   kickBackStrength    = 300.0;
   directDamageType    = $DamageType::Explosion;
   radiusDamageType    = $DamageType::Explosion;
   Impulse = true;
   explosion           = "CubeExplosion";

   dryVelocity       = 0.1;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0;
   lifetimeMS        = 128;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = -1;

   size[0]           = 0.2;
   size[1]           = 0.5;
   size[2]           = 0.1;


   numFlares         = 10;
   flareColor        = "0 1 0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "0 1 0";
};

datablock ParticleEmissionDummyData(tripTimeEmissionDummy){
   timeMultiple = 10.0;
};

datablock ParticleData(BlastShockwaveParticle) {
   dragCoefficient = "2";
   windCoefficient = "0";
   gravityCoefficient = "1";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "30000";
   lifetimeVarianceMS = "100";
   spinSpeed = "0";
   spinRandomMin = "-10";
   spinRandomMax = "10";
   useInvAlpha = "1";
   animateTexture = "0";
   framesPerSec = "1";
   textureCoords[0] = "0 0";
   textureCoords[1] = "0 1";
   textureCoords[2] = "1 1";
   textureCoords[3] = "1 0";
   animTexTiling = "0 0";
   textureName = "particleTest";
   colors[0] = "0.458824 0.458824 0.458824 1";
   colors[1] = "0.321569 0.321569 0.321569 0.496";
   colors[2] = "0.584314 0.584314 0.588235 1";
   colors[3] = "0.843137 0.847059 0.847059 0";
   sizes[0] = "150";
   sizes[1] = "150";
   sizes[2] = "150";
   sizes[3] = "150";
   times[0] = "0";
   times[1] = "0.291667";
   times[2] = "0.6875";
   times[3] = "1";
};

datablock ParticleEmitterData(BlastShockwaveEmitter) {
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "600";
   velocityVariance = "0";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "180";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "0.0001";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "BlastShockwaveParticle";
   lifetimeMS = "2000";
   lifetimeVarianceMS = "0";
   
   
};


datablock ExplosionData(BlastSmokeStack){
   lifeTimeMS = 15000;
   offset = 0;
   shakeCamera = true;
   camShakeFreq = "8.0 8.0 8.0";
   camShakeAmp = "5.0 5.0 5.0";
   camShakeDuration = 5;
   camShakeRadius = 2500.0;
   
};

datablock LinearFlareProjectileData(explTwo){
   //projectileShapeName = "disc_explosion.dts";
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.0;
   damageRadius        = 7.7;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Explosion;

   explosion           = "BlastSmokeStack";

   dryVelocity       = 0.1;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0;
   lifetimeMS        = 1000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = -1;

   size[0]           = 0.9;
   size[1]           = 1.0;
   size[2]           = 0.8;


   numFlares         = 80;
   flareColor        = "0.0 1.0 0.0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";
	sound        = PlasmaProjectileSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0 1.0 0";
};

datablock ParticleData(BlastExplosionParticle) {
   dragCoefficient = "1.8";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "6188";
   lifetimeVarianceMS = "0";
   spinSpeed = "0";
   spinRandomMin = "-360";
   spinRandomMax = "720";
   useInvAlpha = "0";
   animateTexture = "0";
   framesPerSec = "1";
   textureCoords[0] = "0 0";
   textureCoords[1] = "0 1";
   textureCoords[2] = "1 1";
   textureCoords[3] = "1 0";
   animTexTiling = "0 0";
   textureName = "particleTest";
   colors[0] = "0.992 0.996 0.996 1";
   colors[1] = "0.992 0.992 0.996 1";
   colors[2] = "0.996078 0.301961 0.00784314 1";
   colors[3] = "0.980392 0.301961 0.0156863 0";
   sizes[0] = "100";
   sizes[1] = "100";
   sizes[2] = "100";
   sizes[3] = "100";
   times[0] = "0";
   times[1] = "0.104167";
   times[2] = "0.208333";
   times[3] = "0.354167";
};

datablock ParticleEmitterData(BlastExplosionEmitter) {
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "655.35";
   velocityVariance = "0";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "180";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "0.0001";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "BlastExplosionParticle";
   lifetimeMS = "1000";
   lifetimeVarianceMS = "0";
   
   
   useInvAlpha = false;
   sortParticles = "1";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
   
   glow = "1";
   
   Dampening = "0.8";
   elasticity = "0.3";
   
   
   
};

datablock ParticleData(BlastRingParticle) {
   dragCoefficient = "0.8";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "9000";
   lifetimeVarianceMS = "1000";
   spinSpeed = "0.167";
   spinRandomMin = "-90";
   spinRandomMax = "500";
   useInvAlpha = "1";
   animateTexture = "0";
   framesPerSec = "1";
   textureCoords[0] = "0 0";
   textureCoords[1] = "0 1";
   textureCoords[2] = "1 1";
   textureCoords[3] = "1 0";
   animTexTiling = "0 0";
   textureName = "particleTest";
   colors[0] = "0.494118 0.494118 0.494118 0.559";
   colors[1] = "0.388235 0.388235 0.388235 0.568";
   colors[2] = "0.403922 0.403922 0.403922 0.556";
   colors[3] = "0.462745 0.462745 0.462745 0";
   sizes[0] = "50";
   sizes[1] = "50";
   sizes[2] = "50";
   sizes[3] = "50";
   times[0] = "0";
   times[1] = "0.375";
   times[2] = "0.854167";
   times[3] = "1";
};

datablock ParticleEmitterData(BlastRingEmitter) {
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "600";
   velocityVariance = "50";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "90";
   thetaMax = "90";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "1";
   ambientFactor = "0";
   overrideAdvance = "1";
   orientParticles = "0";
   orientOnVelocity = "0";
   particles = "BlastRingParticle";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";
   
   
   blendStyle = "NORMAL";
   sortParticles = "0";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
   
   
   
   Dampening = "0.8";
   elasticity = "0.3";
   
   
   
};

datablock ParticleData(BlastExplosionParticle2) {
   dragCoefficient = "1.2";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "15000";
   lifetimeVarianceMS = "0";
   spinSpeed = "0.083";
   spinRandomMin = "-10";
   spinRandomMax = "10";
   useInvAlpha = "1";
   animateTexture = "0";
   framesPerSec = "1";
   textureCoords[0] = "0 0";
   textureCoords[1] = "0 1";
   textureCoords[2] = "1 1";
   textureCoords[3] = "1 0";
   animTexTiling = "0 0";
   textureName = "particleTest";
   animTexName = "particleTest";
   colors[0] = "0.529412 0.533333 0.533333 0.495";
   colors[1] = "0.537 0.537 0.541 0.538";
   colors[2] = "0.568627 0.568627 0.564706 0.492";
   colors[3] = "0.502 0.502 0.498 0";
   sizes[0] = "150";
   sizes[1] = "150";
   sizes[2] = "150";
   sizes[3] = "150";
   times[0] = "0";
   times[1] = "0.229167";
   times[2] = "0.6875";
   times[3] = "1";
};

datablock ParticleEmitterData(BlastExplosionEmitter2) {
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "150";
   velocityVariance = "100.83";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "180";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "0.0001";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "BlastExplosionParticle2";
   lifetimeMS = "1000";
   lifetimeVarianceMS = "0";
   
};

datablock ParticleData(BlastFireParticle) {
   dragCoefficient = "1";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "100";
   lifetimeVarianceMS = "0";
   spinSpeed = "0";
   spinRandomMin = "-90";
   spinRandomMax = "500";
   useInvAlpha = "0";
   animateTexture = "0";
   framesPerSec = "1";
   textureCoords[0] = "0 0";
   textureCoords[1] = "0 1";
   textureCoords[2] = "1 1";
   textureCoords[3] = "1 0";
   animTexTiling = "0 0";
   textureName = "particleTest";
   colors[0] = "0.996078 0.301961 0.00784314 1";
   colors[1] = "0.996078 0.301961 0.00784314 0.77";
   colors[2] = "0.996078 0.301961 0.00784314 0.761";
   colors[3] = "0.996078 0.301961 0.00784314 1";
   sizes[0] = "3";
   sizes[1] = "3";
   sizes[2] = "3";
   sizes[3] = "3";
   times[0] = "0";
   times[1] = "0.270833";
   times[2] = "0.625";
   times[3] = "1";
};

datablock ParticleEmitterData(BlastFireEmitter) {
   ejectionPeriodMS = "2";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "15";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "1";
   ambientFactor = "0";
   overrideAdvance = "1";
   orientParticles = "0";
   orientOnVelocity = "0";
   particles = "BlastFireParticle";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";
   
   
   useInvAlpha = false;
   sortParticles = "0";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
   
   
   
   Dampening = "0.8";
   elasticity = "0.3";
   
   
   
};

datablock ParticleData(BlastFireParticle2) {
   dragCoefficient = "0.0";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "3000";//was 9000
   lifetimeVarianceMS = "1000";
   spinSpeed = "1";
   spinRandomMin = "-90";
   spinRandomMax = "500";
   useInvAlpha = "1";
   animateTexture = "0";
   framesPerSec = "1";
   textureCoords[0] = "0 0";
   textureCoords[1] = "0 1";
   textureCoords[2] = "1 1";
   textureCoords[3] = "1 0";
   animTexTiling = "0 0";
   textureName = "particleTest";
   colors[0] = "0.458824 0.458824 0.458824 1";
   colors[1] = "0.321569 0.321569 0.321569 0.496";
   colors[2] = "0.584314 0.584314 0.588235 1";
   colors[3] = "0.843137 0.847059 0.847059 0";
   sizes[0] = "5";
   sizes[1] = "5";
   sizes[2] = "5";
   sizes[3] = "5";
   times[0] = "0";
   times[1] = "0.329412";
   times[2] = "0.666667";
   times[3] = "1";
};

datablock ParticleEmitterData(BlastFireEmitter2) {
   ejectionPeriodMS = "15";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "4.583";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "5";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "1";
   ambientFactor = "0";
   overrideAdvance = "1";
   orientParticles = "0";
   orientOnVelocity = "0";
   particles = "BlastFireParticle2";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";  
};

datablock GrenadeProjectileData(blastExplosionProj)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.40;
   damageRadius        = 15.0;
   radiusDamageType    = $DamageType::Explosion;
   kickBackStrength    = 1500;
   bubbleEmitTime      = 1.0;

   //sound               = "";
   explosion           = VehicleBombExplosion;
   underwaterExplosion = UnderwaterMortarExplosion;
   velInheritFactor    = 0.85; 

   baseEmitter         = BlastFireEmitter2;
   delayEmitter        = BlastFireEmitter;
   emitterDelay = 32;
   bubbleEmitter       = MortarBubbleEmitter;

   grenadeElasticity = 0.30; 
   grenadeFriction   = 0.2;
   armingDelayMS     = 250;
   muzzleVelocity    = 200.00;
   gravityMod        = 3.9; 
};

datablock ExplosionData(BlastExplosion)
{
   
   emitter[0] = BlastExplosionEmitter;
   emitter[1] = BlastExplosionEmitter2;
   emitter[2] = BlastRingEmitter;
   
   lifeTimeMS = 6000;
   
   shakeCamera = true;
   camShakeFreq = "8.0 8.0 8.0";
   camShakeAmp = "1.0 1.0 1.0";
   camShakeDuration = 5;
   camShakeRadius = 2500.0;
   
   //debris = blastCannonDebris;
   //debrisThetaMin = 20;
   //debrisThetaMax = 90;
   //debrisNum = 150;
   //debrisNumVariance = "3";
   //debrisVelocity = "155";
   //debrisVelocityVariance = "55";

};

datablock LinearFlareProjectileData(explOne){
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.0;
   damageRadius        = 7.7;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Explosion;

   explosion           = "BlastExplosion";

   dryVelocity       = 0.1;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0;
   lifetimeMS        = 256;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;
   activateDelayMS = -1;

   size[0]           = 0.9;
   size[1]           = 1.0;
   size[2]           = 0.8;


   numFlares         = 80;
   flareColor        = "0.0 1.0 0.0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";
	sound        = PlasmaProjectileSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0 1.0 0";
};

function bigEBoom(%position){
   %p = new LinearFlareProjectile() {
         dataBlock        = CubeProj;
         initialDirection = "0 0 -1";
         initialPosition  = %position;
         sourceObject     = -1; 
         sourceSlot       = 0;
         vehicleObject    = 0;
      };  
   MissionCleanup.add(%p);
}

function bigBoom(%position, %sb, %vec){
   %p = new LinearFlareProjectile() {
         dataBlock        = explOne;
         initialDirection = VectorScale(%vec, -1);
         initialPosition  = VectorAdd(%position, VectorScale(%vec, 5));
         sourceObject     = -1; 
         sourceSlot       = 0;
         vehicleObject    = 0;
      };  
   MissionCleanup.add(%p);
   %p.setScopeAlways();
   schedule(500,0,"delayBoom",%position);
   schedule(500,0,"partboom",%position,%vec);
   for(%i = 0; %i < ClientGroup.getCount(); %i++){
      %cobj = ClientGroup.getObject(%i).getControlObject();
      %cobj.schedule(100,"setWhiteout",1); 
      %player =  ClientGroup.getObject(%i).player;
      if(isObject(%player)){
         %playerPos =  %player.getWorldBoxCenter();
         %ray = ContainerRayCast(%position, %playerPos, $TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType, 0);
         if(!%ray){
            //%player.scriptKill($DamageType::OutOfBounds);
            %data = %player.getDatablock();
            %data.damageObject(%player, %sb, %playerPos, 20, $DamageType::Dark, "0 0 1", %sb.client);
         }
      }
   }
}

function delayBoom(%position){
    %p = new LinearFlareProjectile() {
         dataBlock        = explTwo;
         initialDirection = "0 0 -1";
         initialPosition  = %position;
         sourceObject     = -1;
         sourceSlot       = 0;
         vehicleObject    = 0;
      };  
      %p.setScopeAlways();
}

function partboom(%position,%vec){
   for(%i = 0; %i < 150; %i++){
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.15;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.15;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.15;
      %mat = MatrixCreateFromEuler(%x SPC %y SPC %z);
      %vector = MatrixMulVector(%mat,  %vec);
      %p = new GrenadeProjectile() {
            dataBlock        = blastExplosionProj;
            initialDirection = %vector;
            initialPosition  = VectorAdd(%position, VectorScale(%vec, 5));//vectorAdd(%position,"0 0 100");
            sourceObject     = -1; 
            sourceSlot       = 0;
            vehicleObject    = 0;
         };
      MissionCleanup.add(%p);
      %p.setScopeAlways();
   }
   %part = new ParticleEmissionDummy() {
      position =  %position;
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = tripTimeEmissionDummy;
      emitter = "BlastExplosionEmitterS";
      velocity = "1";
   };  
   MissionCleanup.add(%part);
   %part.setScopeAlways();
   %part.schedule(10000, "delete");
   %part = new ParticleEmissionDummy() {
      position = %position;
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = defaultEmissionDummy;
      emitter = "BlastShockwaveEmitter";
      velocity = "1";
   }; 
   MissionCleanup.add(%part);
   %part.setScopeAlways();
   %part.schedule(10000, "delete");
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////


// datablock ItemData(ThetaStrike){
//    className = Weapon;
//    catagory = "Spawn Items";
//    shapeFile = "weapon_grenade_launcher.dts";
//    image = ThetaStrikeImage;
//    mass = 1;
//    elasticity = 0.2;
//    friction = 0.6;
//    pickupRadius = 2;
// 	pickUpName = "a dark weapon";

//    isEX = true; 
	
// 	wepClass = "EX";
//    wepNameID = "TC-9001";
//    wepName = "Theta Strike Cannon";
//    light = 1;
//    medium = 1;
//    heavy = 1;
//    description = "A super kinetic weapon that unleashes a devastating blast capable of killing all within its radius, regardless of cover";
// };
 
// datablock ParticleData(thetaSExplosionParticle) {//fire
//    dragCoefficient = "9";
//    windCoefficient = "0";
//    gravityCoefficient = "0";
//    inheritedVelFactor = "0";
//    constantAcceleration = "0";
//    lifetimeMS = "3000";
//    lifetimeVarianceMS = "0";
//    spinSpeed = "0";
//    spinRandomMin = "-360";
//    spinRandomMax = "720";
//    useInvAlpha = "0";
//    textureName = "particleTest";
//    colors[0] = "0.992 0.4 0 1";
//    colors[1] = "0.992 0.301961 0.00784314 1";
//    colors[2] = "0.996078 0.301961 0.00784314 0";
//    colors[3] = "0.980392 0.301961 0.0156863 0";
//    sizes[0] = "100";
//    sizes[1] = "100";
//    sizes[2] = "100";
//    sizes[3] = "100";
//    times[0] = "0";
//    times[1] = "0.1";
//    times[2] = "0.2";
//    times[3] = "0.3";
// };

// datablock ParticleEmitterData(thetaSExplosionEmitter) {//fire
//    ejectionPeriodMS = "1";
//    periodVarianceMS = "0";
//    ejectionVelocity = "655.35";
//    velocityVariance = "0";
//    ejectionOffset = "20";
//    ejectionOffsetVariance = "0";
//    thetaMin = "0";
//    thetaMax = "180";
//    phiReferenceVel = "0";
//    phiVariance = "360";
//    ambientFactor = "0";
//    overrideAdvance = "0";
//    orientParticles = "0";
//    orientOnVelocity = "1";
//    particles = "thetaSExplosionParticle";
//    lifetimeMS = "500";
//    lifetimeVarianceMS = "0";
//    useInvAlpha = false;
//    reverseOrder = "0";
//    alignParticles = "0";
//    alignDirection = "0 1 0";
// };

// datablock ParticleData(thetaSExplosionParticle2) {//smoke
//    dragCoefficient = "7";
//    windCoefficient = "0";
//    gravityCoefficient = "0";
//    inheritedVelFactor = "0";
//    constantAcceleration = "0";
//    lifetimeMS = "15000";
//    lifetimeVarianceMS = "0";
//    spinSpeed = "0.083";
//    spinRandomMin = "-10";
//    spinRandomMax = "10";
//    useInvAlpha = "1";
//    animateTexture = "0";
//    framesPerSec = "1";
//    textureCoords[0] = "0 0";
//    textureCoords[1] = "0 1";
//    textureCoords[2] = "1 1";
//    textureCoords[3] = "1 0";
//    animTexTiling = "0 0";
//    textureName = "particleTest";
//    colors[0] = "0.529412 0.533333 0.533333 0.295";
//    colors[1] = "0.537 0.537 0.541 0.238";
//    colors[2] = "0.568627 0.568627 0.564706 0.292";
//    colors[3] = "0.502 0.502 0.498 0";
//    sizes[0] = "150";
//    sizes[1] = "150";
//    sizes[2] = "150";
//    sizes[3] = "150";
//    times[0] = "0";
//    times[1] = "0.229167";
//    times[2] = "0.6875";
//    times[3] = "1";
// };

// datablock ParticleEmitterData(thetaSExplosionEmitter2) {//smoke
//    ejectionPeriodMS = "2";
//    periodVarianceMS = "0";
//    ejectionVelocity = "150";
//    velocityVariance = "100.83";
//    ejectionOffset = "0";
//    ejectionOffsetVariance = "0";
//    thetaMin = "0";
//    thetaMax = "180";
//    phiReferenceVel = "0";
//    phiVariance = "360";
//    softnessDistance = "0.0001";
//    ambientFactor = "0";
//    overrideAdvance = "0";
//    orientParticles = "0";
//    orientOnVelocity = "1";
//    particles = "thetaSExplosionParticle2";
//    lifetimeMS = "1000";
//    lifetimeVarianceMS = "0";
   
   
//    blendStyle = "NORMAL";
//    sortParticles = "1";
//    reverseOrder = "0";
//    alignParticles = "0";
//    alignDirection = "0 1 0";
// };

// datablock ParticleData(thetaSExplosionParticleS) {
//    dragCoefficient = "1";
//    windCoefficient = "0";
//    gravityCoefficient = "0";
//    inheritedVelFactor = "0";
//    constantAcceleration = "1";
//    lifetimeMS = "5376";
//    lifetimeVarianceMS = "0";
//    spinSpeed = "0";
//    spinRandomMin = "-360";
//    spinRandomMax = "720";
//    useInvAlpha = "0";
//    textureName = "particleTest";
//    colors[0] = "0.984 0.992 0.992 0.1";
//    colors[1] = "0.984 0.984 0.992 0.1";
//    colors[2] = "0.996 0.996 0.992 0.1";
//    colors[3] = "0.996 0.996 0.992 0";
//    sizes[0] = "150";
//    sizes[1] = "150";
//    sizes[2] = "150";
//    sizes[3] = "150";
//    times[0] = "0";
//    times[1] = "0.0416667";
//    times[2] = "0.125";
//    times[3] = "0.375";
// };

// datablock ParticleEmitterData(thetaSExplosionEmitterS) { //wave
//    ejectionPeriodMS = "1";
//    periodVarianceMS = "0";
//    ejectionVelocity = "655.34";
//    velocityVariance = "0";
//    ejectionOffset = "100";
//    ejectionOffsetVariance = "0";
//    thetaMin = "0";
//    thetaMax = "180";
//    phiReferenceVel = "0";
//    phiVariance = "360";
//    softnessDistance = "0.0001";
//    ambientFactor = "0";
//    overrideAdvance = "0";
//    orientParticles = "0";
//    orientOnVelocity = "1";
//    particles = "thetaSExplosionParticleS";
//    lifetimeMS = "150";
//    lifetimeVarianceMS = "0";
   
   
//    useInvAlpha = false;
//    sortParticles = "1";
//    reverseOrder = "0";
//    alignParticles = "0";
//    alignDirection = "0 1 0";
// };

// datablock ExplosionData(thetaSStrikeExplosion2){
//    emitter[0] = thetaSExplosionEmitterS;
//    emitter[1] = thetaSExplosionEmitterS;
//    emitter[2] = thetaSExplosionEmitterS;
//    emitter[3] = thetaSExplosionEmitterS;
//    emitter[4] = thetaSExplosionEmitterS;
// };

// datablock ExplosionData(thetaSStrikeExplosion){
//    explosionShape = "effect_plasma_explosion.dts";
//    soundProfile   = BombExplosionSound;
//    faceViewer           = true;
//    emitter[0] = thetaSExplosionEmitter;
//    emitter[1] = thetaSExplosionEmitter2;
//    subExplosion[0] = thetaSStrikeExplosion2;
//    subExplosion[1] = thetaSStrikeExplosion2;
//    subExplosion[2] = thetaSStrikeExplosion2;
//    subExplosion[3] = thetaSStrikeExplosion2;
//    subExplosion[4] = thetaSStrikeExplosion2;
//    //emitter[2] = BlastRingEmitter;
//    delayMS = 150;
//    offset = 4.0;
//    playSpeed = 0.8;

//    sizes[0] = "70 70 70";
//    sizes[1] = "70 70 70";
//    times[0] = 0.0;
//    times[1] = 1.0;
//    shakeCamera = true;
//    camShakeFreq = "8.0 9.0 7.0";
//    camShakeAmp = "10.0 10.0 10.0";
//    camShakeDuration = 2;
//    camShakeRadius = 300.0;
// };  
       
// datablock LinearFlareProjectileData(ThetaCShot){
//    projectileShapeName = "plasmabolt.dts";
//    scale               = "6 6 6";
//    faceViewer          = true;
//    directDamage        = 0.0;
//    hasDamageRadius     = true;
//    indirectDamage      = 100;
//    damageRadius        = 150;
//    kickBackStrength    = 10000.0;
//    radiusDamageType    = $DamageType::Dark;
//    Impulse = true;
//    explosion           = "thetaSStrikeExplosion";
//    underwaterExplosion = "UnderwaterMortarExplosion";
//    splash              = PlasmaSplash;

//    dryVelocity       = 900.0;
//    wetVelocity       =  600;
//    velInheritFactor  = 1;
//    fizzleTimeMS      = 5000;
//    lifetimeMS        = 5000;
//    explodeOnDeath    = true;
//    reflectOnWaterImpactAngle = 15.0;
//    explodeOnWaterImpact      = true;
//    deflectionOnWaterImpact   = 20.0; 
//    fizzleUnderwaterMS        = -1;

//    //activateDelayMS = 100;
//    activateDelayMS = -1;

//    size[0]           = 6;
//    size[1]           = 6;
//    size[2]           = 6;


//    numFlares         = 35;
//    flareColor        = "1 0.75 0.25";
//    flareModTexture   = "flaremod";
//    flareBaseTexture  = "flarebase";

//    hasLight    = true;
//    lightRadius = 3.0;
//    lightColor  = "1 0.75 0.25";
//    ignoreExEffects = 1;
// };


// datablock ShapeBaseImageData(ThetaStrikeImage){
//    className = WeaponImage;
//    shapeFile = "weapon_grenade_launcher.dts";
//    item = ThetaStrike;
//    ammo = DarkAmmo;
//    offset = "0 0 0";
   
//    projectile = ThetaCShot;
//    projectileType = LinearFlareProjectile;

//    stateName[0] = "Activate";
//    stateTransitionOnTimeout[0] = "ActivateReady";
//    stateTimeoutValue[0] = 0.5;
//    stateSequence[0] = "Activate";
//    stateSound[0] = BomberBombDryFireSound;//ThetaStrikeSwitchSound;

//    stateName[1] = "ActivateReady";
//    stateTransitionOnLoaded[1] = "Ready";
//    stateTransitionOnNoAmmo[1] = "NoAmmo";

//    stateName[2] = "Ready";
//    stateTransitionOnNoAmmo[2] = "NoAmmo";
//    stateTransitionOnTriggerDown[2] = "CheckWet";

//    stateName[3] = "Fire";
//    stateTransitionOnTimeout[3] = "Reload";
//    stateTimeoutValue[3] = 1.0;
//    stateFire[3] = true;
//    stateRecoil[3] = LightRecoil;
//    stateAllowImageChange[3] = false;
//    stateScript[3] = "onFire";
//    stateEmitterTime[3] = 0.2;
//    stateSound[3] = PlasmaBarrelExpSound;
//    stateSequence[3] = "Fire";
   
//    stateName[4] = "Reload";
//    stateTransitionOnNoAmmo[4] = "NoAmmo";
//    stateTransitionOnTimeout[4] = "Ready";
//    stateTimeoutValue[4] = 0.3;
//    stateAllowImageChange[4] = false;
//    //stateSequence[4] = "Reload";
//    stateSound[4] = PlasmaReloadSound;

//    stateName[5] = "NoAmmo";
//    stateTransitionOnAmmo[5] = "Reload";
//    stateSequence[5] = "NoAmmo";
//    stateTransitionOnTriggerDown[5] = "DryFire";

//    stateName[6]       = "DryFire";
//    stateSound[6]      = PlasmaDryFireSound;
//    stateTimeoutValue[6]        = 1.5;
//    stateTransitionOnTimeout[6] = "NoAmmo";

//    stateName[7]       = "WetFire";
//    stateSound[7]      = PlasmaFireWetSound;
//    stateTimeoutValue[7]        = 1.5;
//    stateTransitionOnTimeout[7] = "Ready";

//    stateName[8]               = "CheckWet";
//    stateTransitionOnWet[8]    = "WetFire";
//    stateTransitionOnNotWet[8] = "Fire";
// };

// datablock ShockwaveData(ProTrailShockwave){
//    width = 32;
//    numSegments = 20;
//    numVertSegments = 2;
//    velocity = 20;
//    acceleration = 2;
//    lifetimeMS = 500;
//    height = 32;
//    verticalCurve = 0.5;

//    //mapToTerrain = false;
//    //renderBottom = true;
//    mapToTerrain = false;
//    renderBottom = true;
//    orientToNormal = true;

//    texture[0] = "special/shockwave4";
//    texture[1] = "special/gradient";
//    texWrap = 6;

//    times[0] = 0;
//    times[1] = 0.8;
//    times[2] = 1;

//    colors[0] = "1 0.1 0 1";
//    colors[1] = "1 0.1 0 1";
//    colors[2] = "1 0.1 0 1";
// };

// datablock AudioProfile(Weapon9ExpSound){
//    filename = "fx/Bonuses/upward_straipass2_elevator.wav";
//    description = AudioDefault3d;
//    preload = true;
// };

// datablock ExplosionData(ProTrailExplosion){
//    soundProfile = Weapon9ExpSound;
//    faceViewer = true;
//    shockwave = ProTrailShockwave;
// };

// datablock LinearProjectileData(shockwaveTrailProj){
//    projectileShapeName = "weapon_chaingun_ammocasing.dts";
//    emitterDelay = -1;
//    directDamage = 0;
//    hasDamageRadius = false;
//    indirectDamage = 0;
//    damageRadius = 3;
//    radiusDamageType = $DamageType::Dark;
//    kickBackStrength = 3000;
//    mass = 10;
//    explosion = "ProTrailExplosion";
//    underwaterExplosion = "ProTrailExplosion";
//    splash = ChaingunSplash;
//    dryVelocity = 1;
//    wetVelocity = 1;
//    velInheritFactor = 0;
//    fizzleTimeMS = 1;
//    lifetimeMS = 32;
//    explodeOnDeath = true;
//    reflectOnWaterImpactAngle = 0;
//    explodeOnWaterImpact = false;
//    deflectionOnWaterImpact = 0;
//    fizzleUnderwaterMS = 5000;
//    activateDelayMS = -1;
//    hasLight = true;
//    lightRadius = 6;
//    lightColor = "0.19 0.17 0.5";
//    ignoreExEffects = 1;
// };

// function waveTrails(%obj, %data){
//    if(isObject(%obj)){
//       %p = new LinearProjectile(){
//          datablock = %data;
//          initialPosition = %obj.getPosition();
//          initialDirection = %obj.initialDirection;
//          sourceObject = -1;
//          sourceSlot = 0;
//          vehicleObject = 0;
//       };
//       MissionCleanup.add(%p);
//       schedule(32,0, "waveTrails", %obj, %data);
//    }
// }

// function ThetaCShot::onExplode(%data, %proj, %pos, %mod){
//    parent::onExplode(%data, %proj, %pos, %mod);
//    %damageMasks = $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType |
//                   $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
//                   $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;
//    initContainerRadiusSearch(%pos, %data.damageRadius, %damageMasks );
//    while ( (%targetObj = containerSearchNext()) != 0 ){
//       %targetObj.schedule(32, "damage", %proj.sourceObject, %pos, 100, $DamageType::Dark);
//    }
   
// }

// datablock ShapeBaseImageData(ThetaStrike2Image){
//    offset = "0.005 1.0 0.13";
//    rotation = "0 1 0 0";
//    shapeFile = "pack_upgrade_cloaking.dts";
//     emap = true;
// };

// datablock ShapeBaseImageData(ThetaStrike3Image){
//    offset = "0.005 1.1 0.13";
//    shapeFile = "pack_upgrade_cloaking.dts";
//     emap = true;
// };

// datablock ShapeBaseImageData(ThetaStrike4Image){
//    offset = "0.005 1.2 0.13";
//    rotation = "0 1 0 0";
//    shapeFile = "pack_upgrade_cloaking.dts";
// };

// datablock ShapeBaseImageData(ThetaStrike5Image){
//    offset = "0.005 1.3 0.13";
//    rotation = "0 1 0 0";
//    shapeFile = "pack_upgrade_cloaking.dts";
// };

// function ThetaStrikeImage::onMount(%this,%obj,%slot){
//    Parent::onMount(%this, %obj, %slot);
//    %obj.mountImage(ThetaStrike2Image, 4);
//    %obj.mountImage(ThetaStrike3Image, 5);
//    %obj.mountImage(ThetaStrike4Image, 6);
//    %obj.mountImage(ThetaStrike5Image, 7);
//    commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
//    %this.dwOnMount(%obj, %slot);
// }

// function ThetaStrikeImage::onUnmount(%this,%obj,%slot){
//    Parent::onUnmount(%this, %obj, %slot);
//    %obj.unmountImage(4);
//    %obj.unmountImage(5);
//    %obj.unmountImage(6);
//    %obj.unmountImage(7);
//    %this.dwUnMount(%obj, %slot);
// }

// function ThetaStrikeImage::onFire(%data, %obj, %slot){
//    %p =  parent::onFire(%data, %obj, %slot);
//    %obj.applyImpulse(%obj.getPosition(), VectorScale(%obj.getMuzzleVector(0), -4000));
//    waveTrails(%p, shockwaveTrailProj);
// }
///////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////

// datablock ItemData(StarNova){
//    className = Weapon;
//    catagory = "Spawn Items";
//    shapeFile = "weapon_plasma.dts";
//    image = StarNovaImage;
//    mass = 1;
//    elasticity = 0.2;
//    friction = 0.6;
//    pickupRadius = 2;
//    pickUpName = "a dark weapon";
//    computeCRC = false; 

//    isEX = true; 

//    wepClass = "EX";
//    wepNameID = "ST-9600";
//    wepName = "Star Nova";
//    light = 1;
//    medium = 1;
//    heavy = 1;
//    description = "A weapon that bursts open into a fractal tree shape, then at each of its end points starts targeting everything it can see."; 
// };

// datablock ParticleData(novaTrailParticle){
//    dragCoefficient      = 1;
//    gravityCoefficient   = 0;
//    inheritedVelFactor   = 0;
//    constantAcceleration = 0;
//    lifetimeMS           = 12000;
//    lifetimeVarianceMS   = 0;
//    windCoefficient   = 0.0;
//    textureName          = "particleTest";
//    useInvAlpha = 0;
//    colors[0]     = "0 0.3 1.0 1";
//    colors[1]     = "0 0.3 1.0 0";
//    sizes[0]      = 0.5;
//    sizes[1]      = 0.5;
//    times[0] = 0.1;
//    times[1] = 1.0;
// };

// datablock ParticleEmitterData(novaTrailEmitter){
//    ejectionPeriodMS = 5;
//    periodVarianceMS = 0;
//    ejectionVelocity = 0;
//    velocityVariance = 0;
//    ejectionOffset   = 0;
//    thetaMin         = 0;
//    thetaMax         = 0;
//    phiReferenceVel  = 345;
//    phiVariance      = 0;
//    overrideAdvances = 0;
//    orientParticles = 1;
//    particles = novaTrailParticle;
// };

// datablock ParticleData(novaExplosionParticle){
//    dragCoefficient      = 0.0;
//    gravityCoefficient   = 0.0;
//    inheritedVelFactor   = 0.0;
//    constantAcceleration = -3.5;
//    lifetimeMS           = 6000;
//    lifetimeVarianceMS   = 500;
//    useInvAlpha          =  0;
//    textureName          = "special/bluespark";
//    colors[0]     = "0.0 1.0 1.0 1.0";
//    colors[1]     = "1.0 0.5 0.0 1.0";
//    sizes[0]      = 1;
//    sizes[1]      = 1;
// };

// datablock ParticleEmitterData(novaExplosionEmitter){
//    ejectionPeriodMS = 1;
//    periodVarianceMS = 0;
//    ejectionVelocity = 10;
//    velocityVariance = 1.0;
//    ejectionOffset   = 0.0;
//    thetaMin         = 0;
//    thetaMax         = 90;
//    lifetimeMS       = 9000;
//    phiReferenceVel  = 0;
//    phiVariance      = 360;
//    orientParticles  = true;
//    overrideAdvances = false;
//    particles = "novaExplosionParticle";
// };

// datablock ExplosionData(novaStarExplosion){
//    explosionShape = "effect_plasma_explosion.dts";
//    particleEmitter = novaExplosionEmitter;
//    particleDensity = 50;
//    particleRadius = 10;
//    faceViewer = true;
   
//    colors[0] = "0.0 0.0 1.0 0.0";
//    colors[1] = "0.0 0.0 1.0 1.0";
//    times[0] = 0.0;
//    times[1] = 0.4;
//    sizes[0] = "1 1 1";
//    sizes[1] = "1 1 1";
// };

// datablock ExplosionData(novaStarExplosion2){
//    explosionShape = "disc_explosion.dts";
//    faceViewer           = true;
//    playSpeed = 0.9;

//    sizes[0] = "7.0 7.0 7.0";
//    sizes[1] = "10.0 10.0 10.0";
//    times[0] = 0.0;
//    times[1] = 1.0;
// };

// datablock LinearFlareProjectileData(StarNovaProj3){
//    projectileShapeName = "";
//    scale               = "1 1 1";
//    faceViewer          = true;
//    directDamage        = 0.0;
//    hasDamageRadius     = true;
//    indirectDamage      = 5.0;
//    damageRadius        = 100;
//    kickBackStrength    = 6000.0;
//    radiusDamageType    = $DamageType::Dark;

//    explosion           = "novaStarExplosion2";
   
//    baseEmitter = "novaTrailEmitter";

//    dryVelocity       = 1.0;
//    wetVelocity       = -1;
//    velInheritFactor  = 0.3;
//    fizzleTimeMS      = 256;
//    lifetimeMS        = 256;
//    explodeOnDeath    = true;
//    reflectOnWaterImpactAngle = 0.0;
//    explodeOnWaterImpact      = true;
//    deflectionOnWaterImpact   = 0.0;
//    fizzleUnderwaterMS        = -1;

//    activateDelayMS = -1;

//    size[0]           = 0.0;
//    size[1]           = 0.0;
//    size[2]           = 0.0;


//    numFlares         = 0;
//    flareColor        = "0.0 0.0 0.0";
//    flareModTexture   = "flaremod";
//    flareBaseTexture  = "flarebase";

// 	//sound        = PlasmaProjectileSound;
//    //fireSound    = PlasmaFireSound;
//    //wetFireSound = PlasmaFireWetSound;

//    hasLight    = true;
//    lightRadius = 3.0;
//    lightColor  = "1 0.75 0.25";
//    ignoreExEffects = 1;
// };

// datablock LinearFlareProjectileData(StarNovaProj2){
//    projectileShapeName = "";
//    scale               = "1 1 1";
//    faceViewer          = true;
//    directDamage        = 0.0;
//    hasDamageRadius     = true;
//    indirectDamage      = 0.1;
//    damageRadius        = 1;
//    kickBackStrength    = 6000.0;
//    radiusDamageType    = $DamageType::Dark;

//    explosion           = "novaStarExplosion";
   
//    baseEmitter = "novaTrailEmitter";

//    dryVelocity       = 95.0;
//    wetVelocity       = -1;
//    velInheritFactor  = 0.3;
//    fizzleTimeMS      = 500;
//    lifetimeMS        = 500;
//    explodeOnDeath    = true;
//    reflectOnWaterImpactAngle = 0.0;
//    explodeOnWaterImpact      = true;
//    deflectionOnWaterImpact   = 0.0;
//    fizzleUnderwaterMS        = -1;

//    activateDelayMS = -1;

//    size[0]           = 0.0;
//    size[1]           = 0.0;
//    size[2]           = 0.0;


//    numFlares         = 0;
//    flareColor        = "0.0 0.0 0.0";
//    flareModTexture   = "flaremod";
//    flareBaseTexture  = "flarebase";

// 	//sound        = PlasmaProjectileSound;
//    //fireSound    = PlasmaFireSound;
//    //wetFireSound = PlasmaFireWetSound;

//    hasLight    = true;
//    lightRadius = 3.0;
//    lightColor  = "1 0.75 0.25";
//    ignoreExEffects = 1;
// };

// datablock LinearFlareProjectileData(StarNovaProj){
//    projectileShapeName = "";
//    scale               = "1 1 1";
//    faceViewer          = true;
//    directDamage        = 0.0;
//    hasDamageRadius     = true;
//    indirectDamage      = 0.1;
//    damageRadius        = 1;
//    kickBackStrength    = 6000.0;
//    radiusDamageType    = $DamageType::Dark;

//    //explosion           = "StarExplosion";
   
//    baseEmitter = novaTrailEmitter;

//    dryVelocity       = 95.0;
//    wetVelocity       = -1;
//    velInheritFactor  = 0.3;
//    fizzleTimeMS      = 3100;
//    lifetimeMS        = 3100;
//    explodeOnDeath    = true;
//    reflectOnWaterImpactAngle = 0.0;
//    explodeOnWaterImpact      = true;
//    deflectionOnWaterImpact   = 0.0;
//    fizzleUnderwaterMS        = -1;

//    activateDelayMS = -1;

//    size[0]           = 0.0;
//    size[1]           = 0.0;
//    size[2]           = 0.0;


//    numFlares         = 0;
//    flareColor        = "0.0 0.0 0.0";
//    flareModTexture   = "flaremod";
//    flareBaseTexture  = "flarebase";

//    //sound        = PlasmaProjectileSound;
//    //fireSound    = PlasmaFireSound;
//    //wetFireSound = PlasmaFireWetSound;

//    hasLight    = true;
//    lightRadius = 3.0;
//    lightColor  = "1 0.75 0.25";
//    ignoreExEffects = 1;
// };

// datablock ShapeBaseImageData(StarNovaImage){
//    className = WeaponImage;
//    shapeFile = "weapon_plasma.dts";
//    item = STBurstCannon0;
//    ammo = DarkAmmo;
//    offset = "0 0 0";
//    projectile = StarNovaProj;
//    projectileType = LinearFlareProjectile;

//    stateName[0] = "Activate";
//    stateTransitionOnTimeout[0] = "ActivateReady";
//    stateTimeoutValue[0] = 0.5;
//    stateSequence[0] = "Activate";
//    stateSound[0] = PlasmaSwitchSound;
//    stateName[1] = "ActivateReady";
//    stateTransitionOnLoaded[1] = "Ready";
//    stateTransitionOnNoAmmo[1] = "NoAmmo";
//    stateName[2] = "Ready";
//    stateTransitionOnNoAmmo[2] = "NoAmmo";
//    stateTransitionOnTriggerDown[2] = "CheckWet";
//    stateName[3] = "Fire";
//    stateTransitionOnTimeout[3] = "Reload";
//    stateTimeoutValue[3] = 0.1;
//    stateFire[3] = true;
//    stateRecoil[3] = LightRecoil;
//    stateAllowImageChange[3] = false;
//    stateScript[3] = "onFire";
//    stateEmitterTime[3] = 0.2;
//    stateSound[3] = PlasmaFireSound;
//    stateName[4] = "Reload";
//    stateTransitionOnNoAmmo[4] = "NoAmmo";
//    stateTransitionOnTimeout[4] = "Ready";
//    stateTimeoutValue[4] = 0.6;
//    stateAllowImageChange[4] = false;
//    stateSequence[4] = "Reload";
//    stateSound[4] = PlasmaReloadSound;
//    stateName[5] = "NoAmmo";
//    stateTransitionOnAmmo[5] = "Reload";
//    stateSequence[5] = "NoAmmo";
//    stateTransitionOnTriggerDown[5] = "DryFire";
//    stateName[6]       = "DryFire";
//    stateSound[6]      = PlasmaDryFireSound;
//    stateTimeoutValue[6]        = 1.5;
//    stateTransitionOnTimeout[6] = "NoAmmo";
//    stateName[7]       = "WetFire";
//    stateSound[7]      = PlasmaFireWetSound;
//    stateTimeoutValue[7]        = 1.5;
//    stateTransitionOnTimeout[7] = "Ready";
//    stateName[8]               = "CheckWet";
//    stateTransitionOnWet[8]    = "WetFire";
//    stateTransitionOnNotWet[8] = "Fire";
// };

// function StarNovaImage::onMount(%this,%obj,%slot){
//    Parent::onMount(%this,%obj,%slot);
//    commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
//    %this.dwOnMount(%obj, %slot);
// }

// function StarNovaImage::onUnmount(%this,%obj,%slot){
//    Parent::onUnmount(%this, %obj, %slot);
//    %this.dwUnMount(%obj, %slot);
// }

// function StarNovaProj::onExplode(%data, %proj, %pos, %mod){
//    parent::onExplode(%data, %proj, %pos, %mod);
//    %burstCount = 1;
//    %obj =  %proj.sourceObject;
//    %obj.expDepth = 0;
//    %obj.starlockout = 0;
//    for(%i = 0; %i < %burstCount; %i++){
//       %vector = "0 0 1";
//       %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.1;
//       %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.1;
//       %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.1;
//       %mat = MatrixCreateFromEuler(%x SPC %y SPC %z);
//       %vector = MatrixMulVector(%mat, %vector);
//       %p = new LinearFlareProjectile() 
//       {
//          dataBlock = StarNovaProj2;
//          initialDirection = %vector;
//          initialPosition  = %pos;
//          sourceObject = -1;
//          sourceSlot = 0;
//          sObj =  %obj;
//       };
//       MissionCleanup.add(%p);
//    }  
// }

// function starBoom(%obj,%pos){
//          %vector = "0 0 -1";
//          %p = new LinearFlareProjectile() 
//          {
//             dataBlock = StarNovaProj3;
//             initialDirection = %vector;
//             initialPosition  = %pos;
//             sourceObject = -1;
//             sourceSlot = 0;
//             sObj = %obj;
//          };
//          MissionCleanup.add(%p);  
// }

// function startBoomDelay(%obj){
//    for(%i = 1; %i <= %obj.expDepth; %i++){
//       schedule(16*%i, 0, "starBoom", %obj, %obj.starPos[%i]);
//    }    
   
// }

// function StarNovaProj2::onExplode(%data, %proj, %pos, %mod){
//    %obj =  %proj.sObj;
//    %proj.sourceObject = %obj;
//    parent::onExplode(%data, %proj, %pos, %mod);
//    %burstCount = 4;
//    %obj.starPos[%obj.expDepth++] = %pos;
//    if(%obj.expDepth > 100){
//       //error(%obj.expDepth);
//       if(!%obj.starlockout){
//          schedule(2000, 0, "startBoomDelay", %obj); 
//          %obj.starlockout = 1;
//       }
//       return;
//    }
//    else{
//       for(%i = 0; %i < %burstCount; %i++){
//          %vector = "0 0 1";
//          %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5; 
//          %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5;
//          %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5;
//          %mat = MatrixCreateFromEuler(%x SPC %y SPC %z);
//          %vector = MatrixMulVector(%mat, %vector);
//          %p = new LinearFlareProjectile() 
//          {
//             dataBlock = StarNovaProj2;
//             initialDirection = %vector;
//             initialPosition  = %pos;
//             sourceObject = -1;
//             sourceSlot = 0;
//             sObj = %obj;
//          };
//          MissionCleanup.add(%p);
//       }  
//    }
// }

// datablock ShockwaveData(StarNovaBeamShockwave){
//    width = 30;
//    numSegments = 32;
//    numVertSegments = 7;
//    velocity = 40;
//    acceleration = 10.0;
//    lifetimeMS = 1000;
//    height = 6;
//    verticalCurve = 0.375;

//    mapToTerrain = false;
//    renderBottom = true;
//    orientToNormal = true;

//    texture[0] = "special/shockwave5";
//    texture[1] = "special/gradient";
//    texWrap = 3.0;

//    times[0] = 1.0;
//    times[1] = 0.5;
//    times[2] = 1.0;

//    colors[0] = "0.0 0.3 0.9 1.0";
//    colors[1] = "0.0 0.3 0.9 1.0";
//    colors[2] = "0.0 0.0 1.0 0.0";
// };

// datablock ExplosionData(StarNovaBeamExplosion){
//    explosionShape = "effect_plasma_explosion.dts";
//    soundProfile   = PlasmaBarrelExpSound;
//    shockwave      = StarNovaBeamShockwave;
//    faceViewer     = true;
//    sizes[0] = "4.0 4.0 4.0";
//    sizes[1] = "4.0 4.0 4.0";
//    times[0] = 0.0;
//    times[1] = 1.0;
// };

// datablock SniperProjectileData(StarNovaBeam){
//    directDamage        = 10;
//    hasDamageRadius     = false;
//    indirectDamage      = 0.0;
//    damageRadius        = 0.0;
//    velInheritFactor    = 1.0;
//    sound 			   = BlasterProjectileSound;
//    explosion           = "StarNovaBeamExplosion";
//    splash              = PlasmaSplash;
//    directDamageType    = $DamageType::Dark;

//    maxRifleRange       = 600;
//    rifleHeadMultiplier = 1;   
//    beamColor           = "0 0 1";
//    fadeTime            = 2.0;

//    startBeamWidth		  = 1.5;
//    endBeamWidth 	     = 1.5;
//    pulseBeamWidth 	  = 0.5;
//    beamFlareAngle 	  = 30.0;
//    minFlareSize        = 0.0;
//    maxFlareSize        = 400.0;
//    pulseSpeed          = 6.0;
//    pulseLength         = 0.150;

//    lightRadius         = 1.0;
//    lightColor          = "0 0.0 1.0";

//    textureName[0]      = "special/flare";
//    textureName[1]      = "special/nonlingradient";
//    textureName[2]      = "special/skyLightning";// special/laserrip01
//    textureName[3]      = "special/skyLightning";
//    textureName[4]      = "special/skyLightning";
//    textureName[5]      = "special/skyLightning";
//    textureName[6]      = "special/skyLightning";
//    textureName[7]      = "special/skyLightning";
//    textureName[8]      = "special/skyLightning";
//    textureName[9]      = "special/skyLightning";
//    textureName[10]     = "special/skyLightning";
//    textureName[11]     = "special/skyLightning";

// };

// function StarNovaBeam::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal){
//    if(isObject(%targetObject)) {
//       %targetObject.damage(%projectile.sObj, %position, %data.directDamage, %data.directDamageType);
//    }
// }

// function StarNovaProj3::onExplode(%data, %proj, %pos, %mod){
//    %obj =  %proj.sObj;
//    %proj.sourceObject = %obj;
//    parent::onExplode(%data, %proj, %pos, %mod);
   
//    %damageMasks = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType |
//                   $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
//                   $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;
//    %found = 0;
//    initContainerRadiusSearch( %pos, 500, %damageMasks );
//    while ( (%targetObj = containerSearchNext()) != 0 ){
//       %endPos = %targetObj.getWorldBoxCenter();
//       if(getSimTime() - %targetObj.lastNovaHit > 2000 || !%targetObj.lastNovaHit){
//          %targetObj.lastNovaHit = getSimTime();
//          %p = new SniperProjectile() {
//             dataBlock        = StarNovaBeam;
//             initialDirection = vectorNormalize(vectorSub(%endPos,%pos));
//             initialPosition  = %pos;
//             sourceObject     = -1;
//             damageFactor     = 2;
//             sourceSlot       = "";
//             sObj = %obj;
//          };
//          %p.setEnergyPercentage(1);
//          MissionCleanup.add(%p);
//          %found =1;
//          break;
//       }
//    }
//    if(!%found){
//       %vector = "0 0 -1";
//       %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5; 
//       %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5;
//       %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5;
//       %mat = MatrixCreateFromEuler(%x SPC %y SPC %z);
//       %vector = MatrixMulVector(%mat, %vector);
//       %p = new SniperProjectile() {
//          dataBlock        = StarNovaBeam;
//          initialDirection = %vector;
//          initialPosition  = %pos;
//          sourceObject     = -1;
//          damageFactor     = 2;
//          sourceSlot       = "";
//          sObj = %obj;
//       };
//       %p.setEnergyPercentage(1);
//       MissionCleanup.add(%p);
//    }
// }
// ////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////
// ////////////////////////////////////////////////////////////////////////////////

// datablock ItemData(ZapNukeGun){
//    className    = Weapon;
//    catagory     = "Spawn Items";
//    shapeFile    = "weapon_elf.dts";
//    image        = ZapLauncherImage;
//    mass         = 1;
//    elasticity   = 0.2;
//    friction     = 0.6;
//    pickupRadius = 2;
//    pickUpName = "a dark weapon";
//    computeCRC = false;
//    emap = true;

//    isEX = true;   

//    wepClass = "EX";
//    wepNameID = "EW-9524";
//    wepName = "Electrical Nuke";
//    light = 1;
//    medium = 1;
//    heavy = 1;
//    description = "A devastating weapon that creates an electrical storm that culminates in a massive power surge";
// };

// datablock ShapeBaseImageData(ZapLauncherImage)
// {
//    className = WeaponImage;
//    shapeFile = "weapon_grenade_launcher.dts";
//    item = ZapNukeGun;
//    ammo = DarkAmmo;
//    offset = "0 0 0";
//    emap = true;

//    projectile = BasicGrenade;
//    projectileType = GrenadeProjectile;

//    stateName[0] = "Activate";
//    stateTransitionOnTimeout[0] = "ActivateReady";
//    stateTimeoutValue[0] = 0.5;
//    stateSequence[0] = "Activate";
//    stateSound[0] = GrenadeSwitchSound;

//    stateName[1] = "ActivateReady";
//    stateTransitionOnLoaded[1] = "Ready";
//    stateTransitionOnNoAmmo[1] = "NoAmmo";

//    stateName[2] = "Ready";
//    stateTransitionOnNoAmmo[2] = "NoAmmo";
//    stateTransitionOnTriggerDown[2] = "Fire";

//    stateName[3] = "Fire";
//    stateTransitionOnTimeout[3] = "Reload";
//    stateTimeoutValue[3] = 0.4;
//    stateFire[3] = true;
//    stateRecoil[3] = LightRecoil;
//    stateAllowImageChange[3] = false;
//    stateSequence[3] = "Fire";
//    stateScript[3] = "onFire";
//    stateSound[3] = LightningZapSound;

//    stateName[4] = "Reload";
//    stateTransitionOnNoAmmo[4] = "NoAmmo";
//    stateTransitionOnTimeout[4] = "Ready";
//    stateTimeoutValue[4] = 0.5;
//    stateAllowImageChange[4] = false;
//    stateSequence[4] = "Reload";
//    //stateSound[4] = GrenadeReloadSound;

//    stateName[5] = "NoAmmo";
//    stateTransitionOnAmmo[5] = "Reload";
//    stateSequence[5] = "NoAmmo";
//    stateTransitionOnTriggerDown[5] = "DryFire";

//    stateName[6]       = "DryFire";
//    stateSound[6]      = GrenadeDryFireSound;
//    stateTimeoutValue[6]        = 1.5;
//    stateTransitionOnTimeout[6] = "NoAmmo";
// };

// datablock ParticleData(ENChargedProj){
//    dragCoefficient      = 0.0;
//    gravityCoefficient   = 0.0;
//    inheritedVelFactor   = 0.0;
//    constantAcceleration = 0.0;
//    lifetimeMS           = 500;
//    lifetimeVarianceMS   = 0;
//    useInvAlpha          = false;
//    spinRandomMin        = -90.0;
//    spinRandomMax        = 50.0;
//    textureName          = "special/lightning1frame1";
//    colors[0]     = "0.0 0.3 0.9 1.0";
//    colors[1]     = "0.0 0.3 0.9 1.0";
//    colors[2]     = "0.0 0.3 0.9 0.0";
//    sizes[0]      = 0.2;
//    sizes[1]      = 20.6;
//    sizes[2]      = 30.0;
//    times[0]      = 0.0;
//    times[1]      = 0.7;
//    times[2]      = 1.0;
// };

// datablock ParticleEmitterData(ENChargedProjEmitter){
//    ejectionPeriodMS = 1;
//    periodVarianceMS = 0;
//    ejectionVelocity = 0.0;
//    velocityVariance = 0.0;
//    ejectionOffset   = 300.0;
//    thetaMin         = 0;
//    thetaMax         = 180;
//    phiReferenceVel  = 0;
//    phiVariance      = 360;
//    overrideAdvances = false;
//    orientParticles  = false;
//    lifetimeMS       = 1000;
//    particles = "ENChargedProj";
// };

// datablock ShockwaveData(ENShockwave){
//    width = 30;
//    numSegments = 32;
//    numVertSegments = 7;
//    velocity = 100;
//    acceleration = 1000.0;
//    lifetimeMS = 2000;
//    height = 800;
//    verticalCurve = 0.375;

//    mapToTerrain = true;
//    renderBottom = true;
//    orientToNormal = false;

//    texture[0] = "special/shockwave4";
//    texture[1] = "special/gradient";
//    texWrap = 6.0;

//    times[0] = 0.0;
//    times[1] = 0.5;
//    times[2] = 1.0;

//    colors[0] = "0.8 0.8 1.0 1.00";
//    colors[1] = "0.8 0.5 1.0 0.20";
//    colors[2] = "0.2 0.8 1.0 0.0";
// };
// datablock ExplosionData(ENBoltExplosion){
//    explosionShape = "effect_plasma_explosion.dts";
//    soundProfile   = MissileExplosionSound;
//    emitter[0] = ENChargedProjEmitter;
//    emitter[1] = ENChargedProjEmitter;

//    shockwave      = ENShockwave;
//    faceViewer = true;
   
//    times[0] = 0.0;
//    times[1] = 0.4;
//    sizes[0] = "2.0 2.0 2.0";
//    sizes[1] = "2.0 2.0 2.0";
   
//    shakeCamera = true;
//    camShakeFreq = "8.0 9.0 7.0";
//    camShakeAmp = "10.0 10.0 10.0";
//    camShakeDuration = 2;
//    camShakeRadius = 800.0;

// };
// datablock LinearFlareProjectileData(ENStrikeProj){
//    projectileShapeName = "plasmabolt.dts";
//    scale               = "1 1 1";
//    faceViewer          = true;
//    directDamage        = 0.0;
//    hasDamageRadius     = true;
//    indirectDamage      = 50;
//    damageRadius        = 5;
//    kickBackStrength    = 0.0;
//    directDamageType    = $DamageType::Dark;
//    radiusDamageType    = $DamageType::Dark;
//    Impulse = true;
//    explosion           = "ENBoltExplosion";

//    dryVelocity       = 800;
//    wetVelocity       = 800;
//    velInheritFactor  = 0;
//    fizzleTimeMS      = 3000;
//    lifetimeMS        = 3000;
//    explodeOnDeath    = true;
//    reflectOnWaterImpactAngle = 0.0;
//    explodeOnWaterImpact      = true;
//    deflectionOnWaterImpact   = 0.0;
//    fizzleUnderwaterMS        = -1;

//    activateDelayMS = -1;

//    size[0]           = 20.0;
//    size[1]           = 20.5;
//    size[2]           = 80.0;


//    numFlares         = 100;
//    flareColor        = "0 0.5 1";
//    flareModTexture   = "flaremod";
//    flareBaseTexture  = "flarebase";

//    hasLight    = true;
//    lightRadius = 3.0;
//    lightColor  = "0 0 1";
//    ignoreExEffects = 1;
// };
// datablock ShapeBaseImageData(ZapLauncherImage2){

//    offset = "0.0 0.6 0.1";
//    rotation = "1 0 0 90";
//    shapeFile = "pack_upgrade_energy.dts";
//     emap = true;

// };

// datablock ShapeBaseImageData(ZapLauncherImage3){
//    offset = "0.00 0.5 0.1";
//     rotation = "1 0 0 90";
//    shapeFile = "pack_upgrade_energy.dts";
//     emap = true;
// };

// datablock ShapeBaseImageData(ZapLauncherImage4){
//    offset = "0.0 0.4 0.1";
//     rotation = "1 0 0 90";
//    shapeFile = "pack_upgrade_energy.dts";
//     emap = true;
// };

// function ZapLauncherImage::onMount(%this,%obj,%slot){
//    Parent::onMount(%this,%obj,%slot);
//    commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
//    %obj.mountImage(ZapLauncherImage2, 4); 
//    %obj.mountImage(ZapLauncherImage3, 5); 
//    %obj.mountImage(ZapLauncherImage4, 6); 
//    %this.dwOnMount(%obj, %slot);
// }

// function ZapLauncherImage::onUnmount(%this,%obj,%slot){
//    Parent::onUnmount(%this, %obj, %slot);
//    %obj.unmountImage(4);
//    %obj.unmountImage(5);
//    %obj.unmountImage(6);
//    %this.dwUnMount(%obj, %slot);
// }

// function ZapLauncherImage::onFire(%data,%obj,%slot){
//    %muzzlePos = %obj.getMuzzlePoint(%slot);
//    %muzzleVec = %obj.getMuzzleVector(%slot);
//    %endPos    = VectorAdd(%muzzlePos, VectorScale(%muzzleVec, 500));
//    %mask = $TypeMasks::StaticShapeObjectType | 
//    $TypeMasks::InteriorObjectType | 
//    $TypeMasks::TerrainObjectType;
   
//    %hit = ContainerRayCast(%muzzlePos, %endPos, %mask, %obj);
//    if(%hit){  
//       zapGun(1000, 0, getWords(%hit,1,3), %obj.client);
//       %obj.decInventory(%data.ammo, 1);
//    }
//    else{
//       messageClient(%obj.client, 'MsgClient', "~wfx/misc/warning_beep.wav");
//        commandToClient( %obj.client, 'BottomPrint', "Invalid target or too far way, 500m range", 3, 1); 
//    }
// }
// function zapGun(%count, %srCount, %pos, %client){
//    %count -= 20;
//    if(%count < 1)
//       %count = 5;
//    %srCount += 10;
//    %var = new Lightning() {
// 		position = %pos;
// 		rotation = "1 0 0 0";
// 		scale =  %count SPC %count SPC 1000;
// 		dataBlock = "DefaultStorm";
// 		strikesPerMinute = %srCount;
// 		strikeWidth = "2.5";
// 		chanceToHitTarget = "0";
// 		strikeRadius = "1";
// 		boltStartRadius = "10";
// 		color = "1.0 1.0 1.0 1.0";
// 		fadeColor = "0.3 0.3 1.0 1.0";
// 		useFog = "1";
// 	};
//    MissionCleanup.add(%var);
//    %var.schedule(2000, "delete");
//    %damageMasks = $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType |
//                $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
//                $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;            
//    initContainerRadiusSearch(%pos, mFloor(%count/2), %damageMasks );
//    while ( (%targetObject = containerSearchNext()) != 0 ){ 
//       if(%targetObject != %client.player){
//          %mask = $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | 
//          $TypeMasks::TerrainObjectType | $TypeMasks::ForceFieldObjectType;
//          %tgPos = %targetObject.getPosition();    
//          %hit = ContainerRayCast(vectorAdd(%tgPos,"0 0 1000"), %tgPos, %mask, %targetObject);
//          if(!%hit){
//             %zap = new Lightning(){
//                position = %tgPos;
//                rotation = "1 0 0 0";
//                scale = "1 1 1000";
//                dataBlock = "DefaultStorm";
//                lockCount = "0";
//                homingCount = "0";
//                strikesPerMinute = "60";
//                strikeWidth = "2.5";
//                chanceToHitTarget = "1";
//                strikeRadius = "10";
//                boltStartRadius = "70"; //altitude the lightning starts from
//                color = "0.000000 0.100000 1.000000 1.000000";
//                fadeColor = "0.100000 0.100000 1.000000 1.000000";
//                useFog = "1";
//                shouldCloak = 0;
//             };
//             MissionCleanup.add(%zap);
//             %zap.schedule(2000,"delete");
//             %targetObject.damage(%client.player, %tgPos, 20, $DamageType::Dark);
//          }
//       }
//    }
// 	if(%count > 20){
// 	   schedule(256, 0, "zapGun", %count, %srCount, %pos, %client);
// 	}
// 	else{
//       schedule(512, 0, "enStart", %pos, %client);
// 	}
// }


// function enStart(%pos, %client){
//    %damageMasks = $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType |
//                   $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
//                   $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;            
//    initContainerRadiusSearch(vectorAdd(%pos,"0 0 1"), 500, %damageMasks );
//    while ( (%targetObject = containerSearchNext()) != 0 ){ 
//       //schedule(126,0, "powerSurge", %targetObject, %pos, %client.player);
//       schedule(126,0, "cycleMeltDown", %targetObject, %pos, %proj, %client.player);
//    }
   
//    for (%i = 0; %i < 3; %i++){
//       %p = new LinearFlareProjectile() {
//             dataBlock        = ENStrikeProj;
//             initialDirection = "0 0 -1";
//             initialPosition  = vectorAdd(%pos,"0 0 1000");
//             sourceObject     =  %client.player;
//             sourceSlot       = 0;
//             vehicleObject    = 0;
//             sObj = %sobj;
//       };
//       MissionCleanup.add(%p);
//    } 
//   %var = new Lightning() {
// 		position = %pos;
// 		rotation = "1 0 0 0";
// 		scale =  500 SPC 500 SPC 1000;
// 		dataBlock = "DefaultStorm";
// 		strikesPerMinute = 200;
// 		strikeWidth = "2.5";
// 		chanceToHitTarget = "1";
// 		strikeRadius = "500";
// 		boltStartRadius = "10";
// 		color = "1.0 1.0 1.0 1.0";
// 		fadeColor = "0.3 0.3 1.0 1.0";
// 		useFog = "1";
// 	};
//    MissionCleanup.add(%var);
//    %var.schedule(2000, "delete");
// }

// function ENStrikeProj::onExplode(%data, %proj, %pos, %mod){
//    %proj.sourceObject = %proj.sObj;
//    parent::onExplode(%data, %proj, %pos, %mod);
//    expFlash(vectorAdd(%pos,"0 0 0.5"), 600, 0.7);
// }

// datablock LinearFlareProjectileData(MeltDownProj){
//    projectileShapeName = "plasmabolt.dts";
//    scale               = "1 1 1";
//    faceViewer          = true;
//    directDamage        = 0.0;
//    hasDamageRadius     = false;
//    indirectDamage      = 0.2;
//    damageRadius        = 300;
//    kickBackStrength    = 8000.0;
//    radiusDamageType    = $DamageType::Dark;
//    Impulse = true;
//    explosion           = "SatchelMainExplosion";
//    underwaterExplosion = "UnderwaterSatchelSubExplosion";
//    splash              = PlasmaSplash;

//    dryVelocity       = 500.0;
//    wetVelocity       = 500;
//    velInheritFactor  = 0.5;
//    fizzleTimeMS      = 100;
//    lifetimeMS        = 100;
//    explodeOnDeath    = true;
//    reflectOnWaterImpactAngle = 0.0;
//    explodeOnWaterImpact      = false;
//    deflectionOnWaterImpact   = 0.0;
//    fizzleUnderwaterMS        = -1;

//    //activateDelayMS = 100;
//    activateDelayMS = -1;

//    size[0]           = 0.9;
//    size[1]           = 10.0;
//    size[2]           = 10.1;


//    numFlares         = 55;
//    flareColor        = "1 0.75 0.25";
//    flareModTexture   = "flaremod";
//    flareBaseTexture  = "flarebase";

//    hasLight    = true;
//    lightRadius = 15.0;
//    lightColor  = "1 0.75 0.25"; 
//    ignoreExEffects = 1;
// };


// datablock ParticleData(MeltDownEmitterParticle){
//    dragCoefficient      = 0.2;
//    gravityCoefficient   = 0;
//    inheritedVelFactor   = 0;
//    constantAcceleration = 0;
//    lifetimeMS           = 1250;
//    lifetimeVarianceMS   = 500;
//    spinRandomMin    = "-90";
//    spinRandomMax    = "90";
//    textureName          = "particleTest";
//    colors[0]     = "0 0 1 0.6";
//    colors[1]     = "0 0.2 1 0.3";
//    colors[2]     = "0 0.2 1 0";
//    sizes[0]      = 5.5;
//    sizes[1]      = 10.8;
//    sizes[2]      = 10.8;
//    times[0]      = 0;
//    times[1]      = 0.6;
//    times[2]      = 1;
// };

// datablock ParticleEmitterData(MeltDownEmitter){
//    ejectionPeriodMS = 45;
//    periodVarianceMS = 0;
//    ejectionVelocity = 4;
//    velocityVariance = 3.9;
//    ejectionOffset   = 0.0;
//    thetaMin         = 0;
//    thetaMax         = 180;
//    phiReferenceVel  = 0;
//    phiVariance      = 360;
//    orientParticles  = false;
//    overrideAdvance = false;
//    orientOnVelocity = 1;
//    ambientFactor = "0.85";
//    particles = "MeltDownEmitterParticle";
// };

// function cycleMeltDown(%targetObject, %pos, %proj, %sObj){
//    if(%targetObject.getType() & $TypeMasks::GeneratorObjectType){
//       %targetObject.damage(%sObj, %pos, 100, $DamageType::Dark);   
//       %p = new LinearFlareProjectile() {
//          dataBlock        = MeltDownProj;
//          initialDirection = "0 0 1";
//          initialPosition  = %targetObject.getWorldBoxCenter();
//          sourceObject     = %sObj;
//          sourceSlot       = 0;
//       };
//       MissionCleanup.add(%p);
      
//       %part = new ParticleEmissionDummy() {
//          position =  %targetObject.getPosition();
//          rotation = "1 0 0 0";
//          scale = "1 1 1";
//          dataBlock = defaultEmissionDummy;
//          emitter = "MeltDownEmitter";
//          velocity = "1";
//       };
//       MissionCleanup.add(%part);
      
//       %trig = new Trigger() {
//             position = vectorAdd(%targetObject.getPosition(),"0 0 1.5");
//             rotation = "0 0 1 0";
//             scale = "10 10 6";
//             dataBlock = "AnomalyTrig";
//             polyhedron = "-0.5 0.5 -0.5 1.0 0.0 0.0 -0.0 -1.0 -0.0 -0.0 -0.0 1.0";

//             locked = "true";
//             type = "9";
//             client = %sObj.client;
//             part = %part;
//       };
//       MissionCleanup.add(%trig);
//       %part.schedule(60000, "delete");
//       %trig.schedule(60000, "delete");  
//       shockLanceGenLoop(%trig);
//    }
//    else{
//       %targetObject.damage(%sObj, %pos, 100, $DamageType::Dark); 
//       %p = new LinearFlareProjectile() {
//          dataBlock        = MeltDownProj;
//          initialDirection = "0 0 1";
//          initialPosition  = %targetObject.getWorldBoxCenter();
//          sourceObject     = %sObj;
//          sourceSlot       = 0;
//       };
//       MissionCleanup.add(%p);
//    }  
// }

// function shockLanceGenLoop(%p){
//    %everythingElseMask = $TypeMasks::TerrainObjectType |
//                          $TypeMasks::InteriorObjectType |
//                          $TypeMasks::ForceFieldObjectType |
//                          $TypeMasks::StaticObjectType |
//                          $TypeMasks::MoveableObjectType |
//                          $TypeMasks::DamagableItemObjectType |
//                          $TypeMasks::PlayerObjectType;
//    if(isObject(%p)){
//       initContainerRadiusSearch(%p.getPosition(), 25, $TypeMasks::PlayerObjectType );
//       while ( (%targetObj = containerSearchNext()) != 0 ){ 
//          %hit = ContainerRayCast(%p.getPosition(), %targetObj.getPosition(), %everythingElseMask, %p);
//          %hitobj = getWord(%hit, 0);
//          if(%hit && (%hitobj.getType() & $TypeMasks::PlayerObjectType)){
//             %hitpos = getWord(%hit, 1) @ " " @ getWord(%hit, 2) @ " " @ getWord(%hit, 3);
//             %vec = vectorNormalize(vectorSub(%targetObj.getWorldBoxCenter(),%p.getPosition()));
//             %v = new ShockLanceProjectile() {
//                dataBlock        = BasicShocker;
//                initialDirection = %vec;
//                initialPosition  = %p.getPosition();
//                sourceObject     = -1;
//                sourceSlot       = 0;
//                targetId         = %hit;
//             };
//            //error("player" SPC %p.client.player);
//             MissionCleanup.add(%v);
//             %hitObj.damage(%p.client.player, %hitpos, 0.5, $DamageType::Dark); 
//          }

//       }
//       schedule(512, 0, "shockLanceGenLoop", %p);
//    }
// }
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////