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

//Base ammo type
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


$darkWep[1,1] = "EWHPBlaster0" TAB 0;

datablock ItemData(EWHPBlaster0){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_disc.dts";
   image = EWHPBlaster0Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false; 

   wepClass = "EW";
   wepNameID = "EW-142";
   wepName = "high energy disc";
   light = 8;
   medium = 8;
   heavy = 8;
   description = "Energy disc bounces off everything careful";
};

datablock ExplosionData(EWHPBlaster0BoltExplosion){
   //explosionShape =  "effect_Plasma_explosion.dts";
   //soundProfile   = plasmaExpSound;
   subExplosion[0] = ChaingunExplosion;
   emitter[0] = ChaingunSparkEmitter;
   faceViewer = true;
   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.5;
};




datablock LinearProjectileData(EWHPBlaster0Bolt)
{
   projectileShapeName = "disc.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.40;
   damageRadius        = 7.5;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 2000;  // z0dd - ZOD, 4/24/02. Was 1750

   sound 				= discProjectileSound;
   explosion           = "EWHPBlaster0BoltExplosion";
   underwaterExplosion = "UnderwaterDiscExplosion";
   splash              = DiscSplash;

   dryVelocity       = 195; // z0dd - ZOD, 3/30/02. Slight disc speed up. was 90
   wetVelocity       = 155; // z0dd - ZOD, 3/30/02. Slight disc speed up. was 50
   velInheritFactor  = 0.75; // z0dd - ZOD, 3/30/02. was 0.5
   fizzleTimeMS      = 5000;
   lifetimeMS        = 5000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 25.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 20.0; // z0dd - ZOD, 4/24/02. Was 0.0. 20 degrees skips off water
   fizzleUnderwaterMS        = 5000;

   activateDelayMS = 200;

   hasLight    = true;
   lightRadius = 6.0;
   lightColor  = "0.175 0.175 0.5";
};


datablock ShapeBaseImageData(EWHPBlaster0Image){
   className = WeaponImage;
   shapeFile = "weapon_disc.dts";
   item = EWHPBlaster0;
   offset = "0 0 0";
   projectile = EWHPBlaster0Bolt;
   projectileType = LinearProjectile;
   usesEnergy = true;

   fireEnergy = 8;
   minEnergy = 8;
   
      stateName[0]                     = "Preactivate";
   stateTransitionOnLoaded[0]       = "Activate";
   stateTransitionOnNoAmmo[0]       = "NoAmmo";

   stateName[1]                     = "Activate";
   stateTransitionOnTimeout[1]      = "Ready";
   stateTimeoutValue[1]             = 0.5;
   stateSequence[1]                 = "Activated";
   stateSound[1]                    = DiscSwitchSound;

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "Fire";
   stateSequence[2]                 = "DiscSpin";
   stateSound[2]                    = DiscLoopSound;

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 1.25;
   stateFire[3]                     = true;
   stateRecoil[3]                   = LightRecoil;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFireMod";
   stateSound[3]                    = AAFireSound;

   stateName[4]                     = "Reload";
   stateTransitionOnNoAmmo[4]       = "NoAmmo";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.5; // 0.25 load, 0.25 spinup
   stateAllowImageChange[4]         = false;
   stateSequence[4]                 = "Reload";
   stateSound[4]                    = DiscReloadSound;

   stateName[5]                     = "NoAmmo";
   stateTransitionOnAmmo[5]         = "Reload";
   stateSequence[5]                 = "NoAmmo";
   stateTransitionOnTriggerDown[5]  = "DryFire";

   stateName[6]                     = "DryFire";
   stateSound[6]                    = DiscDryFireSound;
   stateTimeoutValue[6]             = 1.0;
   stateTransitionOnTimeout[6]      = "NoAmmo";
};

datablock ShapeBaseImageData(EWHPBlaster0Image4){
   offset = "0.0 0.1 0.125";
   rotation = "0 1 0 -90";
   shapeFile = "weapon_sniper.dts";
    emap = true;

};

datablock ShapeBaseImageData(EWHPBlaster0Image5){
   offset = "-0.0 0.1 0.125";
   rotation = "0 1 0 90";
   shapeFile = "weapon_sniper.dts";
    emap = true;
};


function EWHPBlaster0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(EWHPBlaster0Image4, 4);
   %obj.mountImage(EWHPBlaster0Image5, 5);
   %this.dwOnMount(%obj, %slot);
   
}

function EWHPBlaster0Image::onUnmount(%this,%obj,%slot){
   parent::onUnmount(%this,%obj,%slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %this.dwUnMount(%obj, %slot);
}

function EWHPBlaster0Image::onFireMod(%data,%obj,%slot){
   
   %energy = %obj.getEnergyLevel();
   if(%energy < %data.minEnergy){
       return;
   }
   %obj.setEnergyLevel(%energy - %data.fireEnergy);

   %damageMasks = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType |
                  $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
                  $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;

   %everythingElseMask = $TypeMasks::TerrainObjectType |
                         $TypeMasks::InteriorObjectType |
                         $TypeMasks::ForceFieldObjectType |
                         $TypeMasks::StaticObjectType |
                         $TypeMasks::MoveableObjectType |
                         $TypeMasks::DamagableItemObjectType;
   %muzPos = %obj.getMuzzlePoint(%slot); 
   %muzVec = %obj.getMuzzleVector(%slot);
   %hit = ContainerRayCast(%muzPos, VectorAdd(%muzPos, VectorScale(%muzVec, 1000)), %damageMasks | %everythingElseMask, %obj);     
   %p = new LinearProjectile() {
      dataBlock        = EWHPBlaster0Bolt;
      initialDirection = %muzVec;
      initialPosition  = %muzPos;
      sourceObject     = %obj;
      sourceSlot       = %slot;
      vehicleObject    = 0;
      sObj = %obj;
      lastHit = getSimTime();
   };
   MissionCleanup.add(%p);
   if(%hit){
      %normal = getWords(%hit,4,6);   
      %newNormal  =  vectorSub(%muzVec,vectorScale(%normal,vectorDot( %muzVec, %normal ) * 2.0));
      %p.newDirection = vectorNormalize(%newNormal);
      %p.newPos = getWords(%hit,1,3);
   }
}

datablock AudioProfile(bpImpact1){
   filename    = "fx/weapons/cg_metal1.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(bpImpact2){
   filename    = "fx/weapons/cg_metal2.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(bpImpact3){
   filename    = "fx/weapons/cg_metal3.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(bpImpact4){
   filename    = "fx/weapons/cg_metal4.wav";
   description = AudioClosest3d;
   preload = true;
};

function EWHPBlaster0Bolt::onExplode(%data, %proj, %pos, %mod){
   %proj.sourceObject = %proj.sObj;
   %data.onExplodeMod(%proj, %pos, %mod);
   %proj.superBoltCount++;
   if(%proj.superBoltCount < 12 && (getSimTime() - %proj.lastHit) < 5000){
      %damageMasks = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType |
                  $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
                  $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;

      %everythingElseMask = $TypeMasks::TerrainObjectType |
                            $TypeMasks::InteriorObjectType |
                            $TypeMasks::ForceFieldObjectType |
                            $TypeMasks::StaticObjectType |
                            $TypeMasks::MoveableObjectType |
                            $TypeMasks::DamagableItemObjectType;
      %muzPos = %proj.newPos;
      %muzVec = %proj.newDirection; 
      %muzPos = VectorAdd(%muzPos, VectorScale(%muzVec, 1));
      %hit = ContainerRayCast(%muzPos, VectorAdd(%muzPos, VectorScale(%muzVec, 1000)), %damageMasks | %everythingElseMask, "");     
      %p = new LinearProjectile() {
         dataBlock        = EWHPBlaster0Bolt;
         initialDirection = %muzVec;
         initialPosition  = %muzPos;
         sourceObject     = -1;
         sourceSlot       = 0;
         vehicleObject    = 0;
         sObj = %proj.sObj;
         lastHit = getSimTime();
      };
      MissionCleanup.add(%p);
      if(%hit){
         %normal = getWords(%hit,4,6);   
         %newNormal  =  vectorSub(%muzVec,vectorScale(%normal,vectorDot( %muzVec, %normal ) * 2.0));
         %p.newDirection = vectorNormalize(%newNormal);
         %p.newPos = getWords(%hit,1,3);
      }
      %p.superBoltCount = %proj.superBoltCount;
   }
}

function EWHPBlaster0Bolt::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal){
   parent::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal);
   serverPlay3D(("bpImpact" @ getRandom(1,4)), %position SPC "0 0 1 0");
}
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
$darkWep[1,2] = "SCannon" TAB 8;

datablock ItemData(SCannon){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = SCannonImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";
	
	wepClass = "TC";
   wepNameID = "TC-1000";
   wepName = "Theta Tiger Cannon";
   light = 8;
   medium = 15;
   heavy = 25;
   description = "A kinetic energy weapon that can deliver quick damage to its targets.";
};

datablock AudioProfile(SCannonSwitchSound){
   filename    = "fx/Bonuses/Nouns/tiger.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock ParticleData( SCannonCrescentParticle ){
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

datablock ParticleEmitterData( SCannonCrescentEmitter ){
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
   particles = "SCannonCrescentParticle";
};

datablock ExplosionData(SCannonExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = BombExplosionSound;
   faceViewer           = true;
   emitter[0] = SatchelExplosionSmokeEmitter;
   emitter[1] = SatchelSparksEmitter;
   emitter[2] = SCannonCrescentEmitter;
   
   offset = 4.0;
   playSpeed = 1.0;
   //explosionScale = "0.8 0.8 0.8";

   sizes[0] = "2.0 2.0 2.0";
   sizes[1] = "2.0 2.0 2.0";
   times[0] = 0.0;
   times[1] = 1.0;
   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;
};

datablock LinearFlareProjectileData(HeavyCShot){
   projectileShapeName = "plasmabolt.dts";
   scale               = "4.3 4.3 4.3";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.4;
   damageRadius        = 15;
   kickBackStrength    = 3000.0;
   radiusDamageType    = $DamageType::Dark;
   Impulse = true;
   explosion           = "SCannonExplosion";
   underwaterExplosion = "UnderwaterMortarExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 500.0;
   wetVelocity       =  100;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 2000;
   lifetimeMS        = 3000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 15.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 20.0; 
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.9;
   size[1]           = 1.0;
   size[2]           = 0.1;


   numFlares         = 35;
   flareColor        = "1 0.75 0.25";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
};

datablock ShapeBaseImageData(SCannonImage){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = SCannon;
   ammo = DarkAmmo;
   offset = "0 0 0";
   
   projectile = HeavyCShot;
   projectileType = LinearFlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = SCannonSwitchSound;

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
   stateScript[3] = "onFireMod";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PlasmaBarrelExpSound;
   stateSequence[3] = "Fire";
   
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

 datablock ShapeBaseImageData(SCannon2Image){
   offset = "0.005 1.2 0.13";
   rotation = "0 1 0 0";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;

};

datablock ShapeBaseImageData(SCannon3Image){
   offset = "0.005 1.0 0.13";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;
};

datablock ShapeBaseImageData(SCannon4Image){
   offset = "0.005 1.1 0.13";
   rotation = "0 1 0 180";
   shapeFile = "pack_upgrade_cloaking.dts";
};

function SCannonImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(SCannon2Image, 4);
   %obj.mountImage(SCannon3Image, 5);
   %obj.mountImage(SCannon4Image, 6);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function SCannonImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %this.dwUnMount(%obj, %slot);
}

function SCannonImage::onFireMod(%data, %obj, %slot){
  parent::onFireMod(%data, %obj, %slot);
  %obj.applyImpulse(%obj.getPosition(), VectorScale(%obj.getMuzzleVector(0), -4000));
}

function HeavyCShot::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
$darkWep[1,3] = "TigerB" TAB 12;

datablock ItemData(TigerB){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = TigerBImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";

   computeCRC = false;
   
   wepClass = "CO";
   wepNameID = "CO-1444";
   wepName = "Theta Atomic Mortar";
   light = 0;
   medium = 15;
   heavy = 0;
   description = "A long-range mini mortar weapon that can send rounds to distant targets, but at the cost of reduced damage.";
};

datablock ParticleData(AtomicMortarExplosionParticle){
   dragCoefficient      = 3.64;
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0;
   constantAcceleration = 0.0;
   lifetimeMS           = 900;
   lifetimeVarianceMS   = 200;
   spinRandomMin = "-560";
   useInvAlpha          =  false;
   spinRandomMax =  "720";
   textureName          = "special/shockLightning02";
   colors[0]     = "0 0.3 1 1";
   colors[1]     = "0 0.3 1 0.35";
   colors[2]     = "0 0.3 0.1 0";
   sizes[0]      = 2.5;
   sizes[1]      = 4.8;
   sizes[2]      = 6.8;
   times[0]      = 0;
   times[1]      = 0.5;
   times[2]      = 1;
};

datablock ParticleEmitterData(AtomicMortarExplosionEmitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 32.5;
   velocityVariance = 13.5;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   lifetimeMS       = 50;
   phiReferenceVel  = 0;
   blendStyle = "ADDITIVE";
   phiVariance      = 360;
   orientParticles  = false;
   reverseOrder = true;
   sortParticles    = true;
   overrideAdvance = true;
   softnessDistance = "0.0001";
   orientOnVelocity = 1;
   particles = "AtomicMortarExplosionParticle";
};

datablock ParticleData(AtomicMortarShockwaveParticle){
   dragCoefficient      = 0.2;
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0;
   constantAcceleration = 0;
   lifetimeMS           = 3250;
   lifetimeVarianceMS   = 2500;
   spinRandomMin    = "-90";
   spinRandomMax    = "90";
   textureName          = "particleTest";
   colors[0]     = "0 0.3 1 0.6";
   colors[1]     = "0 0.3 0.9 0.3";
   colors[2]     = "0 0.3 0.3 0";
   sizes[0]      = 5.5;
   sizes[1]      = 7.8;
   sizes[2]      = 7.8;
   times[0]      = 0;
   times[1]      = 0.6;
   times[2]      = 1;
};

datablock ParticleEmitterData(AtomicMortarShockwaveEmitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 4;
   velocityVariance = 3.9;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 180;
   lifetimeMS       = 50;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   orientParticles  = false;
   overrideAdvance = false;
   sortParticles    = true;
   softnessDistance = "0.0001";
   orientOnVelocity = 1;
   ambientFactor = "0.85";
   particles = "AtomicMortarShockwaveParticle";
};

datablock ExplosionData(TigerBExplosion){
   explosionShape = "disc_explosion.dts";
   soundProfile   = FusionExpSound;
   faceViewer           = true;

   playSpeed = 1;

   emitter[0] = AtomicMortarShockwaveEmitter;
   emitter[1] = AtomicMortarExplosionEmitter;
   
   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.0;
   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "10.0 10.0 10.0";
   camShakeDuration = 1.3;
   camShakeRadius = 25.0;
};

datablock ParticleData(TigerBSmokeParticle){
  dragCoefficient      = 0.1;
   gravityCoefficient   = -0.1;
   inheritedVelFactor   = 1.0;
   constantAcceleration = 0.1;
   lifetimeMS           = 250;
   lifetimeVarianceMS   = 0;
   useInvAlpha =  false;
   textureName          = "particleTest";
   colors[0]     = "0.0 0.75 0.75 1.0";
   colors[1]     = "1.0 1.0 1.0 0";
   sizes[0]      = 1.0;
   sizes[1]      = 1.15;

};

datablock ParticleEmitterData(TigerBSmokeEmitter){
  ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 3;
   velocityVariance = 1;
   ejectionOffset   = 0;
   thetaMin         = 90;
   thetaMax         = 90;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;

   particles = "TigerBSmokeParticle";
};

datablock GrenadeProjectileData(TigerBShot){
   projectileShapeName = "mortar_projectile.dts";
   scale               = "1.0 1.0 1.0";
   emitterDelay        = 1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.4;
   damageRadius        = 15.0;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 2000;

   explosion           = TigerBExplosion;
   underwaterExplosion = UnderwaterMortarExplosion;
   velInheritFactor    = 0.5;
   splash              = MortarSplash;
   depthTolerance      = 30.0;


   baseEmitter         = TigerBSmokeEmitter;
   bubbleEmitter       = MortarBubbleEmitter;

   grenadeElasticity = 0.35;
   grenadeFriction   = 0.2;
   armingDelayMS     = 256;
   muzzleVelocity    = 143.7;
   drag              = 0.1;

   sound			 = HAPCFlyerThrustSound;

   hasLight    = true;
   lightRadius = 10.0;
   lightColor  = "0.0 0.3 9.0 1.0";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";

};

datablock ShapeBaseImageData(TigerBImage){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   rotation = "0 0 1 0";
   //rotation  = "0.57735 0.57735 0.57735" SPC mRadToDeg(2.0944);
   item = TigerB;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;
   
   projectile = TigerBShot;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.25;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.15;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFireMod";
   stateSound[3] = MBLFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 1;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = GrenadeReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 0.25;
   stateTransitionOnTimeout[6] = "NoAmmo";
};
 datablock ShapeBaseImageData(TigerBImage1){
   offset = "0.005 1.2 0.13";
   rotation = "0 1 0 0";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;

};
 datablock ShapeBaseImageData(TigerBImage2){
   offset = "0.005 1.1 0.13";
   rotation = "0 1 0 0";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;

};
 datablock ShapeBaseImageData(TigerBImage3){
   offset = "0.005 1.0 0.13";
   rotation = "0 1 0 0";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;

};
 datablock ShapeBaseImageData(TigerBImage4){
   offset = "0.005 0.9 0.13";
   rotation = "0 1 0 0";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;

};
function TigerBImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
   %obj.mountImage(TigerBImage1,4);
   %obj.mountImage(TigerBImage2,5);
   %obj.mountImage(TigerBImage3,6);
   %obj.mountImage(TigerBImage4,7);
   
}

function TigerBImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %this.dwUnMount(%obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %obj.unmountImage(7);
}

function TigerBShot::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
$darkWep[1,4] = "TCAC0" TAB 30;
datablock ItemData(TCAC0){
   className = Weapon;
   catagory = "Spawn Items";
   //$$ TODO - real shape file
   shapeFile = "weapon_grenade_launcher.dts";
   image = TCAC0Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";

   computeCRC = false;
   emap=true;
   
   wepClass = "TC";
   wepNameID = "TC-100";
   wepName = "Theta Assault Cannon";
   light = 50;
   medium = 100;
   heavy = 150;
   description = "A dual-barrel ultra-fast explosive shotgun that is designed for close to mid-range targets. ";
};

datablock AudioProfile(TCAC0FireSound){
   filename    = "fx/misc/cannonshot.wav";
   description = AudioClosest3d;
   preload = true;
};


datablock TracerProjectileData(TCAC0Bullet){
   doDynamicClientHits = true;

   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.02;
   damageRadius        = 1.0;
   radiusDamageType    = $DamageType::Dark;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 0.0;
  // sound 				= SniperRifleProjectileSound;

   dryVelocity       = 520.0;
   wetVelocity       = 100.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 1000;
   lifetimeMS        = 1000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 1000;

   tracerLength    = 15.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 SPC 215.0/255.0 SPC 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.10;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};

datablock ShapeBaseImageData(TCAC0Image){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = TCAC0;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;
   
   projectile = TCAC0Bullet;
   projectileType = TracerProjectile;

   casing              = ShellDebris;
   shellExitDir        = "0.3 1.0 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 5.0 / 1000.0;

   // State Data
   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = ChaingunSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.4;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFireMod";
   stateSound[3] = TCAC0FireSound;

   stateName[4]                  = "Reload";
   stateTransitionOnNoAmmo[4]    = "NoAmmo";
   stateTransitionOnTimeout[4]   = "Ready";
   stateTimeoutValue[4]          = 0.1;
   stateAllowImageChange[4]      = false;
   //stateSequence[4]              = "Reload";
   //stateSound[4]                 = GrenadeSwitchSound;
   stateEjectShell[4]            = true;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
   stateScript[6] = "onDryFire";
};

datablock ShapeBaseImageData(TCAC0Image1) : TCAC0Image{
   offset = "-0.2 0 0";
   rotation = "0 1 0 0";
   emap = true;

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function vectorPerp(%vec){//perpendicular vector
   %x = getWord(%vec,1) * -1;
   %y = getWord(%vec,2) * -1;
   %z = getWord(%vec,0) * -1;
   return %x SPC %y SPC %z;
}

function tube(%radius, %segments, %pos1, %pos2, %i){
   %qxyz = vectorSub(%pos2,%pos1);//main vector
   %uxyz = vectorPerp(%qxyz); //perpendicular vector 
   %vxyz = vectorCross(%qxyz,%uxyz);//find the cross vector 
   %uxyz = vectorNormalize(%uxyz);// normlize main and cross vector
   %vxyz = vectorNormalize(%vxyz);
   
   %theta = 2*3.1415926*%i/%segments;  
   %x = %radius *(mCos(%theta)*getWord(%uxyz,0) + mSin(%theta)*getWord(%vxyz,0)); // rotate around main vector 
   %y = %radius *(mCos(%theta)*getWord(%uxyz,1) + mSin(%theta)*getWord(%vxyz,1));
   %z = %radius *(mCos(%theta)*getWord(%uxyz,2) + mSin(%theta)*getWord(%vxyz,2));
   return (getWord(%pos2,0) + %x SPC getWord(%pos2,1) + %y  SPC  getWord(%pos2,2) + %z);//sum are offset 
}


function TCAC0Image::onFireMod(%data, %obj, %slot){

   %obj.schedule(200, "setImageTrigger", 4, true);
   
   %obj.decInventory(%data.ammo,1);

   %vector = %obj.getMuzzleVector(%slot);
   %mp = %obj.getMuzzlePoint(%slot);
   %seg = 6;
	for (%i = 0; %i < %seg; %i++){
      %endPos = VectorAdd(%mp, VectorScale(VectorNormalize(%vector), 500));
      %cycPos = tube(getRandom(0,15), %seg, %mp, %endPos, %i);
      %vec = vectorNormalize(vectorSub(%cycPos, %mp));
      %p = new (%data.projectileType)() {
            dataBlock        = %data.projectile;
            initialDirection = %vec;
            initialPosition  = %mp;
            sourceObject     = %obj;
            sourceSlot       = %slot;
        };
	}
	%p = new (%data.projectileType)() {// send one down the center
      dataBlock        = %data.projectile;
      initialDirection = %obj.getMuzzleVector(%slot);
      initialPosition  = %obj.getMuzzlePoint(%slot);
      sourceObject     = %obj;
      sourceSlot       = %slot;
   };
}

function TCAC0Image1::onDryFire(%data, %obj, %slot){
   %obj.setImageTrigger(4, false);
}
function TCAC0Image1::onFireMod(%data, %obj, %slot){
   %vector = %obj.getMuzzleVector(%slot);
   %mp = %obj.getMuzzlePoint(%slot);
   %seg = 6;
	for (%i = 0; %i < %seg; %i++){
      %endPos = VectorAdd(%mp, VectorScale(VectorNormalize(%vector), 500));
      %cycPos = tube(getRandom(0,15), %seg, %mp, %endPos, %i);
      %vec = vectorNormalize(vectorSub(%cycPos, %mp));
      %p = new (%data.projectileType)() {
            dataBlock        = %data.projectile;
            initialDirection = %vec;
            initialPosition  = %mp;
            sourceObject     = %obj;
            sourceSlot       = %slot;
        };
	}
	%p = new (%data.projectileType)() {// send one down the center
      dataBlock        = %data.projectile;
      initialDirection = %obj.getMuzzleVector(%slot);
      initialPosition  = %obj.getMuzzlePoint(%slot);
      sourceObject     = %obj;
      sourceSlot       = %slot;
   };
   %obj.setImageTrigger(4, false);
}

function TCAC0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(TCAC0Image1, 4);
   %this.dwOnMount(%obj, %slot);
}

function TCAC0Image::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this,%obj,%slot);
   %obj.unmountImage(4);
   %this.dwUnMount(%obj, %slot);
}

function TCAC0Bullet::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[1,5] = "TurboChaingun" TAB 500;

datablock ItemData(TurboChaingun){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_chaingun.dts";
   image = TurboChaingunImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false; 
   
   wepClass = "TC";
   wepNameID = "TC-50";
   wepName = "Theta Turbo Chaingun";
   light = 200;
   medium = 400;
   heavy = 800;
   description = "A dual ultra-fast chaingun that is designed for finishing off targets with low health at close range.";
};

datablock TracerProjectileData(DarkChaingunBullet)
{
   doDynamicClientHits = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.01;
   damageRadius        = 1.0;
   radiusDamageType    = $DamageType::Dark;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   kickBackStrength  = 0.0;
   sound = ChaingunProjectile;
   dryVelocity       = 750.0; // z0dd - ZOD, 7/12/03. Was 425.0
   wetVelocity       = 280.0; // z0dd - ZOD, 7/12/03. Was 100.0
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;
   tracerLength    = 30.0; // z0dd - ZOD, 7/12/03. Was 15.0
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
   tracerTex[0] = "special/tracer00";
   tracerTex[1] = "special/tracercross";
   tracerWidth  = 0.20; // z0dd - ZOD, 7/12/03. Was 0.10
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;
   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};

datablock ShapeBaseImageData(TurboChaingunImage){
   className = WeaponImage;
   shapeFile = "weapon_chaingun.dts";
   item      = TurboChaingun;
   ammo 	 = DarkAmmo;
   projectile = DarkChaingunBullet;
   projectileType = TracerProjectile;
   emap = true;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 16 / 1000.0;

   
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = ChaingunSwitchSound;
   stateAllowImageChange[0] = false;
   //
   stateTimeoutValue[0]        = 0.5;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   //
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1]      = "NoAmmo";

   
   stateName[2]               = "NoAmmo";
   stateTransitionOnAmmo[2]   = "Ready";
   stateSpinThread[2]         = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";

   
   stateName[3]         = "Spinup";
   stateScript[3]       = "onSpinup";
   stateSpinThread[3]   = SpinUp;
   stateSound[3]        = ChaingunSpinupSound;
   //
   stateTimeoutValue[3]          = 0.5;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = ChaingunFireSound;
   //stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFireMod";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   //
   stateTimeoutValue[4]          = 0.01;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   
   stateName[5]       = "Spindown";
   stateScript[5]     = "onSpindown";
   stateSound[5]      = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   //
   stateTimeoutValue[5]            = 1.0;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   
   stateName[6]       = "EmptySpindown";
   stateSound[6]      = ChaingunSpinDownSound;
   stateSpinThread[6] = SpinDown;
   stateScript[6]     = "onSpindown";
   //
   stateTimeoutValue[6]        = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ShapeBaseImageData(MMGun2Image) : TurboChaingunImage{
   offset = "-0.2 0 0";
   stateScript[3] = "onFireMod";
};

datablock ShapeBaseImageData(MMGun3Image) : TurboChaingunImage{
   offset = "-0.0 0.3 0.1";
   rotation = "1 0 0 90";
   shapeFile = "pack_upgrade_cloaking.dts";
};

function TurboChaingunImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(MMGun2Image, 4);
   %obj.mountImage(MMGun3Image, 5);
   %this.dwOnMount(%obj, %slot);
}

function TurboChaingunImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %this.dwUnMount(%obj, %slot);
}

function TurboChaingunImage::onSpindown(%this,%obj,%slot){
   %obj.MMSpunUp = false;
   %obj.setImageTrigger(4, false);
}

function TurboChaingunImage::onSpinup(%this,%obj,%slot){
   //%obj.setImageTrigger(4, true);
   %obj.schedule(128, "setImageTrigger", 4, true);
}

function TurboChaingunImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
}

function TurboChaingunImage::onFireMod(%data, %obj, %slot){
   %vector = %obj.getMuzzleVector(%slot);
   %x = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %vector = MatrixMulVector(%mat, %vector);

   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %vector;
      initialPosition  = %obj.getMuzzlePoint(%slot);
      sourceObject     = %obj;
      sourceSlot       = %slot;
   };
   MissionCleanup.add(%p);
   %obj.MechSpunUp = true;
   %obj.decInventory(%data.ammo,2);
   %obj.lastProjectile = %p;
   %client.projectile = %p;
   return MMGun2Image::onFireMod(MMGun2Image,%obj,4); // Call the second image fire
}

function MMGun2Image::onFireMod(%data,%obj,%slot){
     if(!%obj.MMSpunUp)
          return false;

      %vector = %obj.getMuzzleVector(%slot);
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %vector = MatrixMulVector(%mat, %vector);

   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %vector;
      initialPosition  = %obj.getMuzzlePoint(%slot);
      sourceObject     = %obj;
      sourceSlot       = %slot;
   };
   MissionCleanup.add(%p);
   %obj.lastProjectile = %p;
   %client.projectile = %p;
}

function DarkChaingunBullet::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
$darkWep[2,1] = "RRepeater" TAB 50;
datablock ItemData(RRepeater){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy.dts";
   image = RRepeaterImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false; 
   
   wepClass = "RK";
   wepNameID = "RK-100";
   wepName = "Robot Repeater";
   light = 40;
   medium = 50;
   heavy = 70;
   description = "A weapon that fires a beam of projectile very deadly for slow or non moving targets";
};


datablock EnergyProjectileData(RRepeaterBolt){
   emitterDelay        = -1;
   directDamage        = 0.1;
   hasDamageRadius     = true;
   indirectDamage      = 0.01;
   damageRadius        = 1.0;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 45;
   bubbleEmitTime      = 1.0;
   // z0dd - ZOD, 5/07/04. Shotgun blaster no sound when gameplay changes in affect
   sound = BlasterProjectileSound;
   velInheritFactor    = 0.5;

   explosion           = "BlasterExplosion";
   splash              = BlasterSplash;


   grenadeElasticity = 0.998;
   grenadeFriction   = 0.0;
   armingDelayMS     = 500;

   muzzleVelocity    = 70.0;

   drag = 0.05;

   gravityMod        = 0.0;

   dryVelocity       = 70.0;
   wetVelocity       = 50.0;

   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0 0";

   scale = "0.25 20.0 1.0";
   crossViewAng = 0.99;
   crossSize = 0.55;

   lifetimeMS     = 3000;
   blurLifetime   = 0.2;
   blurWidth      = 0.25;
   blurColor = "1 0 0 1.0";

   texture[0] = "special/redflare";
   texture[1] = "special/redflare";
};

datablock ShapeBaseImageData(RRepeaterImage){
   className = WeaponImage;
   shapeFile = "weapon_energy.dts";
   item = RRepeater;
   //ammo = DarkAmmo;
   offset = "0 0 0";
   projectile = RRepeaterBolt;
   projectileType = EnergyProjectile;
   usesEnergy = true;
   fireEnergy = 20;
   minEnergy = 20;
   
   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;
   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";
   
   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";
   
   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFireMod";
   stateSound[3] = BlasterFireSound;
   
   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.1;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   //stateSound[4] = PlasmaReloadSound;
   
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

datablock ShapeBaseImageData(RRepeater2Image){

   offset = "-0.1 0.4 0.11";
   rotation = "0 1 0 90";
   shapeFile = "beacon.dts";
   emap = true;
};

datablock ShapeBaseImageData(RRepeater3Image){
   offset = "0.1 0.4 0.11";
   rotation = "0 1 0 -90";
   shapeFile = "beacon.dts";
    emap = true;
};

function RRepeaterImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(RRepeater2Image, 4);
   %obj.mountImage(RRepeater3Image, 5);
   %this.dwOnMount(%obj, %slot);
}

function RRepeaterImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %this.dwUnMount(%obj, %slot);
}
function RRepeaterImage::onFireMod(%data, %obj, %slot){
   %energy = %obj.getEnergyLevel();
   if(%energy < %data.minEnergy){
       return;
   }
   %obj.setEnergyLevel(%energy - %data.fireEnergy);
   %range = 300; 
   %rot = getWords(%obj.getTransform(), 3, 6);
   %muzzlePos = %obj.getMuzzlePoint(%slot);
   %muzzleVec = %obj.getMuzzleVector(%slot);
   %endPos    = VectorAdd(%muzzlePos, VectorScale(%muzzleVec, %range));
   %mask = $TypeMasks::StaticShapeObjectType | 
   $TypeMasks::InteriorObjectType | 
   $TypeMasks::TerrainObjectType | 
   $TypeMasks::ForceFieldObjectType | 
   $TypeMasks::PlayerObjectType | 
   $TypeMasks::VehicleObjectType;
   
   %hit = ContainerRayCast(%muzzlePos, %endPos, %mask, %obj);
   if((%hit)){
      %hitPos = getWords(%hit,1,3);
      %count = mFloor(vectorDist(%muzzlePos, %hitPos)/20) + 1;
      for(%i = 0; %i < %count; %i++){
         %p = new EnergyProjectile(){
            dataBlock = RRepeaterBolt;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  =  vectorLerpC(%muzzlePos, %hitPos, %i/%count);
            sourceObject = %obj;
            sourceSlot = %slot;
         };
         MissionCleanup.add(%p);
      }
   }
   else{
      %count = 12;
      for(%i = 0; %i < %count; %i++){
         %p = new EnergyProjectile(){
            dataBlock = RRepeaterBolt;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  =  vectorLerpC(%muzzlePos, %endPos, %i/%count);
            sourceObject = %obj;
            sourceSlot = %slot;
         };
         MissionCleanup.add(%p);
      }
   }  
}
function vectorLerpC(%point1, %point2, %t) {
	return vectorAdd(%point1, vectorScale(vectorSub(%point2, %point1), %t));
}

function RRepeaterBolt::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[2,2] = "RoboR" TAB 15;

datablock ItemData(RoboR){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_plasma.dts";
   image = RoboRImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";
   emap = true;
   
   wepClass = "RK";
   wepNameID = "RK-4000";
   wepName = "Robot Rifle";
   light = 15;
   medium = 20;
   heavy = 30;
   description = "A weapon that uses focused energy to penetrate armor and destroy robots.";
};

datablock AudioProfile(RoboRSwitchSound){
   filename    = "Voice/Bot1/gbl.hi.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RoboRReloadSound){
   filename    = "fx/misc/cannonstart.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RoboRDryFireSound){
   filename    = "voice/Bot1/gbl.aww.wav";
   description = AudioClose3d;
   preload = true;
};

datablock ExplosionData(RoboRExplosion){
   explosionShape = "energy_explosion.dts";
   soundProfile   = underwaterDiscExpSound;

   faceViewer     = false;
   explosionScale = "10 10 10";

   shakeCamera = true;
   camShakeFreq = "30.0 31.0 30.0";
   camShakeAmp = "30.0 30.0 30.0";
   camShakeDuration = 2.5;
   camShakeRadius = 10.0;
   
   
   sizes[0] = "30.0 32.0 32.0";
   sizes[1] = "30.0 32.0 32.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock LinearProjectileData(RoboRProjectile){
   projectileShapeName = "energy_bolt.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.5;
   damageRadius        = 4.5;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 1750;

   sound 				= BlasterProjectileSound;
   explosion           = "RoboRExplosion";
   underwaterExplosion = "UnderwaterMortarExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 350;
   wetVelocity       = 350;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 5000;
   lifetimeMS        = 5000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 15.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 5000;

   activateDelayMS = -1;
   
   size[0]           = 2.8;
   size[1]           = 4.0;
   size[2]           = 2.6;

   hasLight    = false;
   lightRadius = 6.0;
   lightColor  = "0.175 0.175 0.5";
};

datablock ShapeBaseImageData(RoboRImage){
   className = WeaponImage;
   shapeFile = "weapon_plasma.dts";
   item = RoboR;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;
   
   projectileSpread = 0;

   projectile = RoboRProjectile;
   projectileType = LinearProjectile;

   // State Data
   stateName[0]                     = "Preactivate";
   stateTransitionOnLoaded[0]       = "Activate";
   stateTransitionOnNoAmmo[0]       = "NoAmmo";

   stateName[1]                     = "Activate";
   stateTransitionOnTimeout[1]      = "Ready";
   stateTimeoutValue[1]             = 0.1;
   stateSequence[1]                 = "Activated";
   stateSound[1]                    = RoboRSwitchSound;

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "Fire";
   stateSequence[2]                 = "RoboRSpin";
   stateSound[2]                    = PlasmaIdleSound;

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.70;
   stateFire[3]                     = true;
   stateRecoil[3]                   = LightRecoil;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFireMod";
   stateSound[3]                    = BomberTurretFireSound;

   stateName[4]                     = "Reload";
   stateTransitionOnNoAmmo[4]       = "NoAmmo";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.7; // 0.25 load, 0.25 spinup
   stateAllowImageChange[4]         = false;
   stateSequence[4]                 = "Reload";
   stateSound[4]                    = RoboRReloadSound;

   stateName[5]                     = "NoAmmo";
   stateTransitionOnAmmo[5]         = "Reload";
   stateSequence[5]                 = "NoAmmo";
   stateTransitionOnTriggerDown[5]  = "DryFire";

   stateName[6]                     = "DryFire";
   stateSound[6]                    = RoboRDryFireSound;
   stateTimeoutValue[6]             = 1.0;
   stateTransitionOnTimeout[6]      = "NoAmmo";

};

datablock ShapeBaseImageData(RoboR2Image){

   offset = "0.0 0.4 0.35";
   rotation = "0 1 0 0";
   shapeFile = "beacon.dts";
   emap = true;
};

datablock ShapeBaseImageData(RoboR3Image){
   offset = "0.0 0.6 0.35";
   rotation = "0 1 1 0";
   shapeFile = "beacon.dts";
    emap = true;
};

datablock ShapeBaseImageData(RoboR4Image){
   offset = "-0.15 0.9 0.25";
    rotation = "1.0 1 0 180";
   shapeFile = "ammo_mortar.dts";
    emap = true;
};

function RoboRImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(RoboR2Image, 4);
   %obj.mountImage(RoboR3Image, 5);
   %obj.mountImage(RoboR4Image, 6);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function RoboRImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %this.dwUnMount(%obj, %slot);
}

function RoboRProjectile::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[2,3] = "RKImpactNade0" TAB 12;

datablock ItemData(RKImpactNade0){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = RKImpactNade0Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false;
   
   wepClass = "RK";
   wepNameID = "RK-3100";
   wepName = "Robot Impact Nade";
   light = 15;
   medium = 25;
   heavy = 30;
   description = "A grenade launcher weapon designed for very close combat, it has a very short arming time.";
};

datablock ParticleData(RKImpactNade0ExplosionParticle){
   dragCoefficient      = 0.89;
   gravityCoefficient   = -1.33;
   inheritedVelFactor   = 0.16;
   constantAcceleration = -0.02;
   lifetimeMS           = 1589;
   lifetimeVarianceMS   = 150;
   textureName          = "special/shockLightning01";
   useInvAlpha = 0;
   colors[0]     = "0.0629606 0.179024 0.857703 0.414622";
   colors[1]     = "0.559509 0.666089 0.963474 0.10847";
   sizes[0]      = 0.5;
   sizes[1]      = 2;
};

datablock ParticleEmitterData(RKImpactNade0ExplosionEmitter){
   ejectionPeriodMS = 8;
   periodVarianceMS = 4;
   ejectionVelocity = 6;
   velocityVariance = 2;
   ejectionOffset   = 5;
   thetaMin         = 11;
   thetaMax         = 72;
   phiReferenceVel  = 280;
   phiVariance      = 139;
   overrideAdvances = 1;
   orientParticles = 1;
   particles = RKImpactNade0ExplosionParticle;
};

datablock ExplosionData(RKImpactNade0BoltExplosion){
   explosionShape =  "effect_plasma_explosion.dts";
   soundProfile   = plasmaExpSound;
   subExplosion[0] = RoboRExplosion;
   subExplosion[1] = GrenadeExplosion;
   particleEmitter = RKImpactNade0ExplosionEmitter;
   particleDensity = 150;
   particleRadius = 1.25;
   faceViewer = true;
   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.5;
};

datablock ParticleData(RKImpactNade0ExplosionTrailParticle){
   dragCoefficient      = 0;
   gravityCoefficient   = -0.61;
   inheritedVelFactor   = 0.32;
   constantAcceleration = -0.16;
   lifetimeMS           = 1158;
   lifetimeVarianceMS   = 150;
   textureName          = "dust10";
   useInvAlpha = 1;
   colors[0]     = "0.688141 0.592625 0.242699 0.0338233";
   colors[1]     = "0.468535 0.661761 0.223375 0.257163";
   sizes[0]      = 0.5;
   sizes[1]      = 2;
};

datablock ParticleEmitterData(RKImpactNade0ExplosionTrailEmitter){
   ejectionPeriodMS = 12;
   periodVarianceMS = 9;
   ejectionVelocity = 5;
   velocityVariance = 1;
   ejectionOffset   = 3;
   thetaMin         = 18;
   thetaMax         = 23;
   phiReferenceVel  = 314;
   phiVariance      = 13;
   overrideAdvances = 0;
   orientParticles = 1;
   particles = RKImpactNade0ExplosionTrailParticle;
};

datablock GrenadeProjectileData(RKImpactNade0Grenade){
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.40;
   damageRadius        = 12.0;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 200;
   bubbleEmitTime      = 1.0;
   sound               = GrenadeProjectileSound;
   explosion           = "RKImpactNade0BoltExplosion";
   underwaterExplosion = "UnderwaterGrenadeExplosion";
   velInheritFactor    = 0.85;
   splash              = GrenadeSplash;
   baseEmitter         = RKImpactNade0ExplosionTrailEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   grenadeElasticity = 0.30;
   grenadeFriction   = 0.2;
   armingDelayMS     = 250;
   muzzleVelocity    = 80;
   gravityMod        = 2;
};

datablock ShapeBaseImageData(RKImpactNade0Image){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = RKImpactNade0;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;
   projectile = RKImpactNade0Grenade;
   projectileType = GrenadeProjectile;
   
   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;
   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";
   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";
   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.4;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   //stateSequence[3] = "Fire";
   stateScript[3] = "onFireMod";
   stateSound[3] = GrenadeFireSound;
   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   //stateSequence[4] = "Reload";
   stateSound[4] = GrenadeReloadSound;
   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   //stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";
   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData( RKImpactNade0Image6){
   offset = "0.0 0.4 -0.04";
   rotation = "0 1 1 0";
   shapeFile = "weapon_energy.dts";
};

function RKImpactNade0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(RKSCharge0Image2, 4);
   %obj.mountImage(RKSCharge0Image3, 5);
   %obj.mountImage(RKImpactNade0Image6, 6);
   %this.dwOnMount(%obj, %slot);
}

function RKImpactNade0Image::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %this.dwUnMount(%obj, %slot);
}

function RKImpactNade0Grenade::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////


$darkWep[2,4] = "RKCannon0" TAB 12;

datablock ItemData(RKCannon0){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_plasma.dts";
   image = RKCannon0Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false; 
   
   wepClass = "RK";
   wepNameID = "RK-6120";
   wepName = "Robot Cannon";
   light = 15;
   medium = 25;
   heavy = 35;
   description = "A weapon that fires a multi-projectile in a fixed pattern, which can hit hard if it lands on target.";
};

datablock ExplosionData(RoboRExplosion2){
   explosionShape = "energy_explosion.dts";
   //soundProfile   = underwaterDiscExpSound;

   faceViewer     = false;
   explosionScale = "10 10 10";

   shakeCamera = false;
   camShakeFreq = "3.0 3.0 3.0";
   camShakeAmp = "30.0 30.0 30.0";
   camShakeDuration = 1;
   camShakeRadius = 10.0;
   
   
   sizes[0] = "20.0 22.0 22.0";
   sizes[1] = "20.0 22.0 22.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock LinearProjectileData(RoboRProjectile2){
   projectileShapeName = "energy_bolt.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.06;
   damageRadius        = 2.0;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 2000;

   sound 				= BlasterProjectileSound;
   explosion           = "RoboRExplosion2";
   underwaterExplosion = "UnderwaterMortarExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 350;
   wetVelocity       = 350;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 5000;
   lifetimeMS        = 5000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 15.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 5000;

   activateDelayMS = -1;
   
   size[0]           = 2.8;
   size[1]           = 4.0;
   size[2]           = 2.6;

   hasLight    = false;
   lightRadius = 6.0;
   lightColor  = "0.175 0.175 0.5";
};

datablock ShapeBaseImageData(RKCannon0Image){
   className = WeaponImage;
   shapeFile = "weapon_plasma.dts";
   item = RKCannon0;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;
   
   projectileSpread = 0;

   projectile = RoboRProjectile2;
   projectileType = LinearProjectile;

   // State Data
   stateName[0]                     = "Preactivate";
   stateTransitionOnLoaded[0]       = "Activate";
   stateTransitionOnNoAmmo[0]       = "NoAmmo";

   stateName[1]                     = "Activate";
   stateTransitionOnTimeout[1]      = "Ready";
   stateTimeoutValue[1]             = 0.1;
   stateSequence[1]                 = "Activated";
   stateSound[1]                    = RoboRSwitchSound;

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "Fire";
   stateSequence[2]                 = "RoboRSpin";
   stateSound[2]                    = PlasmaIdleSound;

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.70;
   stateFire[3]                     = true;
   stateRecoil[3]                   = LightRecoil;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFireMod";
   stateSound[3]                    = BomberTurretFireSound;

   stateName[4]                     = "Reload";
   stateTransitionOnNoAmmo[4]       = "NoAmmo";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.7; // 0.25 load, 0.25 spinup
   stateAllowImageChange[4]         = false;
   stateSequence[4]                 = "Reload";
   stateSound[4]                    = RoboRReloadSound;

   stateName[5]                     = "NoAmmo";
   stateTransitionOnAmmo[5]         = "Reload";
   stateSequence[5]                 = "NoAmmo";
   stateTransitionOnTriggerDown[5]  = "DryFire";

   stateName[6]                     = "DryFire";
   stateSound[6]                    = RoboRDryFireSound;
   stateTimeoutValue[6]             = 1.0;
   stateTransitionOnTimeout[6]      = "NoAmmo";

};

datablock ShapeBaseImageData(RKCannon04Image){
   offset = "0 0.6 0.23";
    rotation = "1.0 0 0 90";
   shapeFile = "repair_kit.dts";
    emap = true;
};

function RKCannon0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(RoboR2Image, 4);
   %obj.mountImage(RoboR3Image, 5);
   %obj.mountImage(RKCannon04Image, 6);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}
 function RKCannon0Image::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %this.dwUnMount(%obj, %slot);
}

function RKCannon0Image::onFireMod(%data, %obj, %slot){

   %obj.applyImpulse(%obj.getPosition(), VectorScale(%obj.getMuzzleVector(0), -400));
   %obj.decInventory(%data.ammo,1);

   %vector = %obj.getMuzzleVector(%slot);
   %mp = %obj.getMuzzlePoint(%slot);

	for (%i = 0; %i < 8; %i++)
	{
      %endPos = VectorAdd(%mp, VectorScale(VectorNormalize(%vector), 200));
      %cycPos = tube(8, 8, %mp, %endPos, %i);//getRandom(0,15)
      %vec = vectorNormalize(vectorSub(%cycPos, %mp));
      %p = new (%data.projectileType)() {
            dataBlock        = %data.projectile;
            initialDirection = %vec;
            initialPosition  = %mp;
            sourceObject     = %obj;
			   damageFactor	 = 1;
            sourceSlot       = %slot;
      };
	}
	%p = new (%data.projectileType)() {
            dataBlock        = %data.projectile;
            initialDirection = %vector;
            initialPosition  = %mp;
            sourceObject     = %obj;
			   damageFactor	 = 1;
            sourceSlot       = %slot;
   };
}

function RoboRProjectile2::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[2,5] = "RKSCharge0" TAB 15;

datablock ItemData(RKSCharge0){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = RKSCharge0Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";

   computeCRC = false;
   
   wepClass = "RK";
   wepNameID = "RK-200";
   wepName = "Robot Armor Cutter";
   light = 14;
   medium = 32;
   heavy = 37;
   description = "A weapon designed for very close-range engagements, it fires a high-damage charge.";
};

datablock ExplosionData(RKSCharge0Explosion){
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = PlasmaBarrelExpSound;
   faceViewer           = true;

   playSpeed = 1;
   subExplosion[0] = RoboRExplosion;
   emitter[0] = SatchelSparksEmitter;

      
   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.0;
   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 1.3;
   camShakeRadius = 25.0;
};

datablock LinearFlareProjectileData(RKSCharge0Shot){
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.8;
   damageRadius        = 1;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Dark;
   blockSelfDamage = true;
   explosion           = "RKSCharge0Explosion";
   splash              = PlasmaSplash;

   dryVelocity       = 95.0;
   wetVelocity       = -1;
   velInheritFactor  = 0.8;
   fizzleTimeMS      = 150;
   lifetimeMS        = 150;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = -1;

   size[0]           = 0.6;
   size[1]           = 0.5;
   size[2]           = 0.4;


   numFlares         = 80;
   flareColor        = "0.2 0.0 1";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";
   sound        = ChaingunProjectile;
   
   hasLight    = true;
   lightRadius = 8.0;
   lightColor  = "0.2 0.0 1";
};

datablock ShapeBaseImageData(RKSCharge0Image){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = RKSCharge0;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;
   
   projectile = RKSCharge0Shot;
   projectileType = LinearFlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 1;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFireMod";
   stateSound[3] = MBLFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = GrenadeReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(RKSCharge0Image2){
   offset = "0.0 0.4 0.29";
   rotation = "0 1 1 0";
   shapeFile = "beacon.dts";

};

datablock ShapeBaseImageData(RKSCharge0Image3){
   offset = "0.0 0.65 0.29";
   rotation = "0 1 1 0";
   shapeFile = "beacon.dts";
};

function RKSCharge0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(RKSCharge0Image2, 4);
   %obj.mountImage(RKSCharge0Image3, 5);
   %this.dwOnMount(%obj, %slot);
}

function RKSCharge0Image::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %this.dwUnMount(%obj, %slot);
}

function RKSCharge0Shot::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[3,1] = "STGravAnchor0" TAB 50;

datablock ItemData(STGravAnchor0)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_elf.dts";
   image        = STGravAnchor0Image;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false;
   emap = true;

   wepClass = "ST";
   wepNameID = "ST-9";
   wepName = "Star Grav Anchor";
   light = 1;
   medium = 1;
   heavy = 1;
   description = "A weapon that fires a beam of energy that pulls objects and enemies towards the user. "; 
};

datablock ELFProjectileData(STGravAnchor0ELF)
{
    beamRange         = 40;
   numControlPoints  = 8;
   restorativeFactor = 3.75;
   dragFactor        = 4.5;
   endFactor         = 2.25;
   randForceFactor   = 2;
   randForceTime     = 0.125;
	drainEnergy			= 0.0;
	drainHealth			= 0.01;
   directDamageType  = $DamageType::Dark;
   blockSelfDamage = true;
	mainBeamWidth     = 0.1;           
	mainBeamSpeed     = 9.0;            
	mainBeamRepeat    = 0.25;           
   lightningWidth    = 0.1;
   lightningDist      = 0.15;           

   fireSound    = ElfGunFireSound;
   wetFireSound = ElfFireWetSound;

	textures[0] = "special/ELFBeam";
   textures[1] = "special/ELFLightning";
   textures[2] = "special/BlueImpact";

   emitter = ELFSparksEmitter;
};

datablock ShapeBaseImageData(STGravAnchor0Image)
{
   className = WeaponImage;
   shapeFile = "weapon_elf.dts";
   item = STGravAnchor0;
   offset = "0 0 0";
   projectile = STGravAnchor0ELF;
   projectileType = ELFProjectile;
   
   deleteLastProjectile = true;
   emap = true;
   usesEnergy = true;
   minEnergy = 3;
   stateName[0]                     = "Activate";
   stateSequence[0]                 = "Activate";
   stateSound[0]                    = ELFGunSwitchSound;
   stateTimeoutValue[0]             = 0.5;
   stateTransitionOnTimeout[0]      = "ActivateReady";
   stateName[1]                     = "ActivateReady";
   stateTransitionOnAmmo[1]         = "Ready";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";
   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "CheckWet";
   stateName[3]                     = "Fire";
   stateEnergyDrain[3]              = 5;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateScript[3]                   = "onFireMod";
   stateTransitionOnTriggerUp[3]    = "Deconstruction";
   stateTransitionOnNoAmmo[3]       = "Deconstruction";
   stateName[4]                     = "NoAmmo";
   stateTransitionOnAmmo[4]         = "Ready";
   stateName[5]                     = "Deconstruction";
   stateScript[5]                   = "deconstruct";
   stateTransitionOnTimeout[5]      = "Ready";
   stateTransitionOnNoAmmo[6]       = "NoAmmo";
   stateName[6]                     = "DryFire";
   stateSound[6]                    = ElfFireWetSound;
   stateTimeoutValue[6]             = 0.5;
   stateTransitionOnTimeout[6]      = "Ready";
   stateName[7]                     = "CheckWet";
   stateTransitionOnWet[7]          = "DryFire";
   stateTransitionOnNotWet[7]       = "Fire";
};
function STGravAnchor0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function STGravAnchor0Image::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %this.dwUnMount(%obj, %slot);
}
//from badshot tuts
function STGravAnchor0ELF::zapTarget(%data, %projectile, %target, %targeter){
   parent::zapTarget(%data, %projectile, %target, %targeter);
   %projectile.checkTractorStatus(%data, %target, %targeter);
}

function ELFProjectile::checkTractorStatus(%this, %data, %target, %targeter){
   %obj = %this.sourceObject;
   %client = %obj.client;
   if((isObject(%target)) && (isObject(%obj)) && isObject(%this))
   {
      if(%target.getDamageState() $= "Destroyed")
      {
         cancel(%this.Tractorrecur);
         %this.delete();
         return;
      }

      if ((%target.getType() & $TypeMasks::PlayerObjectType) || (%target.getType() & $TypeMasks::VehicleObjectType))
         if ((%target.team != %obj.team) || ($teamDamage)){ 
            %scale = ((%client.mod1 == 1) * 1) + ((%client.mod2 == 1) * 2)  + ((%client.mod3 == 1) * 4);
            %dataBlock = %target.getDataBlock();
            if(%obj.getObjectMount() != %target){
               %multi =  (%target.getType() & $TypeMasks::PlayerObjectType) ? 8 : 6;
               %pos = %obj.getPosition();
               %pos2 = %target.getPosition();
               %vec = VectorSub(%pos, %pos2);
               %vec = VectorNormalize(%vec);
               %amount = VectorScale(%vec, %dataBlock.mass * %multi);
               %target.applyImpulse(%pos2, %amount);
               RadiusExplosionMod(%this, %pos2, 1, %data.drainHealth, 0, %obj, $DamageType::Dark, %data);
            }
         }
      %this.TractorRecur = %this.schedule(128, checkTractorStatus, %data, %target, %targeter);
   }
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[3,2] = "TCDestructor0" TAB 15;

datablock ItemData(TCDestructor0)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = TCDestructor0Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   emap = true;
   computeCRC = false;

   wepClass = "ST";
   wepNameID = "ST-2030";
   wepName = "Shooting Star";
   light = 15;
   medium = 25;
   heavy = 30;
   description = "A weapon that fires a heavy armor-penetrating rod capable of going through walls.";
};

datablock ParticleData(BarrelSparks){
   dragCoefficient = 1;
   gravityCoefficient = 1.0;
   inheritedVelFactor = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS = 900;
   lifetimeVarianceMS = 0;
   textureName = "special/spark00";
   sizes[0] = 1.2;
   sizes[1] = 0.4;
   sizes[2] = 0.1;
   times[0] = 0.0;
   times[1] = 0.2;
   times[2] = 1.0;
};

datablock ParticleEmitterData(SparkBarrelSparkEmitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 15;
   velocityVariance = 4.0;
   ejectionOffset = 0.0;
   thetaMin = 0;
   thetaMax = 50;
   phiReferenceVel = 0;
   phiVariance = 360;
   overrideAdvances = false;
   orientParticles = true;
   lifetimeMS = 256;
   particles = "BarrelSparks";
};


datablock ExplosionData(SparkRifleBarrelExplosion){
   soundProfile = ChaingunImpact;
   emitter[0] = SparkBarrelSparkEmitter;
   faceViewer = false;
};

datablock LinearProjectileData(SparkRifleBulletc){
   projectileShapeName = "energy_bolt.dts";
   scale = "0.5 8 0.5";
   emitterDelay        = -1;
   directDamage        = 0.40;
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 4;
   radiusDamageType    = $DamageType::Dark;
   directDamageType = $DamageType::Dark;
   blockSelfDamage = true;
   kickBackStrength    = 2000;  

   sound 				= ChaingunProjectile;
   explosion           = "SparkRifleBarrelExplosion";
   underwaterExplosion = "UnderwaterDiscExplosion";
   splash              = DiscSplash;

   dryVelocity       = 300; 
   wetVelocity       = 200; 
   velInheritFactor  = 1; 
   fizzleTimeMS      = 5000;
   lifetimeMS        = 5000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 25.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 20.0; 
   fizzleUnderwaterMS        = 5000;

   activateDelayMS = -1;

   hasLight    = true;
   lightRadius = 6.0;
   lightColor  = "0.175 0.175 0.5";
};

datablock ShapeBaseImageData(TCDestructor0Image){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = TCDestructor0;
   ammo = DarkAmmo;
   offset = "0 0.26 0.01";
   emap = true;
   projectile = SparkRifleBulletc;
   projectileType = LinearProjectile;

   stateName[0]                     = "Preactivate";
   stateTransitionOnLoaded[0]       = "Activate";
   stateTransitionOnNoAmmo[0]       = "NoAmmo";
   stateName[1]                     = "Activate";
   stateTransitionOnTimeout[1]      = "Ready";
   stateTimeoutValue[1]             = 0.5;
   stateSequence[1]                 = "Activated";
   stateSound[1]                    = GrenadeSwitchSound;
   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "Fire";
   //stateSequence[2]                 = "DiscSpin";
   //stateSound[2]                    = DiscLoopSound;
   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 1.00;
   stateFire[3]                     = true;
   stateRecoil[3]                   = LightRecoil;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFireMod";
   stateSound[3]                    = AAFireSound;
   stateName[4]                     = "Reload";
   stateTransitionOnNoAmmo[4]       = "NoAmmo";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.2;
   stateAllowImageChange[4]         = false;
   //stateSequence[4]                 = "Reload";
   stateSound[4]                    = GrenadeReloadSound;
   stateName[5]                     = "NoAmmo";
   stateTransitionOnAmmo[5]         = "Reload";
   stateSequence[5]                 = "NoAmmo";
   stateTransitionOnTriggerDown[5]  = "DryFire";
   stateName[6]                     = "DryFire";
   stateSound[6]                    = DiscDryFireSound;
   stateTimeoutValue[6]             = 1.0;
   stateTransitionOnTimeout[6]      = "NoAmmo";
};

function TCDestructor0Image::onFireMod(%data, %obj, %slot){
   %obj.decInventory(%data.ammo,1);   
   %p = new (%data.projectileType)() {
            dataBlock        = %data.projectile;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
            sObj = %obj;
   };
   MissionCleanup.add(%p);
}

datablock StaticShapeData(spikePole){
   shapeFile = "teamlogo_projector.dts";
};

function pointToVec(%vec){
   %x = getWord(%vec, 0);
   %y = getWord(%vec, 1);
   %z = getWord(%vec, 2);
   %rotAngleX = mASin(%z);
   %rotAngleZ = mATan( %x, %y );
   %matrix = MatrixCreateFromEuler("0 0" SPC %rotAngleZ * -1);
   %matrix2 = MatrixCreateFromEuler(%rotAngleX+ mDegToRad(90) SPC "0 0");
   %finalMat = MatrixMultiply(%matrix, %matrix2);
   return getWords(%finalMat, 3, 6);
}


function SparkRifleBulletc::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal){
   if(isObject(%projectile.killTarget)){
     %projectile.killTarget.setVelocity("0 0 0");  
     %projectile.killTarget.setPosition(%position);  
      %rot = pointToVec(%projectile.initialDirection);
      %mul = MatrixMulPoint(%position SPC %rot,"-0.05 0 -0.05");
       %spike = new StaticShape() {
         dataBlock = spikePole;
         position = %mul;
         rotation = getWords(%rot,0,2) SPC mRadToDeg(getWord(%rot,3));
         scale = "0.1 0.1 6";
      };
      MissionCleanup.add(%spike);
      %spike.schedule(10000, "delete");   
      return;
   }
   
   %pos = VectorAdd(%position, VectorScale(%projectile.initialDirection, 2));
   %p = new (LinearProjectile)() {
      dataBlock        = "SparkRifleBulletc";
      initialDirection = %projectile.initialDirection;
      initialPosition  = %pos;
      sourceObject     = -1;
      damageFactor	  = 1;
      sourceSlot       = %projectile.sourceSlot;
      sObj = %projectile.sObj;
   };
   MissionCleanup.add(%p);
   if(isObject(%targetObject) && %targetObject != %projectile.sObj) {
      %targetObject.damage(%projectile.sObj, %position, %data.directDamage, %data.directDamageType);
      
      if(%targetObject.getClassName() $= "Player" && %targetObject.getState() $= "Dead"){
         if(getRandom(0,1)){
            %targetObject.setMomentumVector(%momVec);
            %targetObject.blowup();    
         }
         else{
            %p.killTarget = %targetObject;
            %vel = VectorScale(%projectile.initialDirection, 250);
            %targetObject.setVelocity(%vel);
         }
      }
   }
}

datablock ShapeBaseImageData(TCDestructor4Image){
   shapeFile = "weapon_grenade_launcher.dts";
    emap = true;
};

function TCDestructor0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(TCDestructor4Image, 4);
   %this.dwOnMount(%obj, %slot);
}

function TCDestructor0Image::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this,%obj,%slot);
   %obj.unmountImage(4);
   %this.dwUnMount(%obj, %slot);
}

function SparkRifleBulletc::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[3,3] = "STBurstCannon0" TAB 8;

datablock ItemData(STBurstCannon0)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_plasma.dts";
   image = STBurstCannon0Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false; 

   wepClass = "ST";
   wepNameID = "ST-10";
   wepName = "Star Burst";
   light = 0;
   medium = 0;
   heavy = 30;
   description = "A weapon that fires a projectile that explodes into multiple smaller, high-damage projectiles."; 
};
datablock ExplosionData(StarBrustExplosion)
{
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = PlasmaBarrelExpSound;
   particleEmitter = PlasmaExplosionEmitter;
   particleDensity = 150;
   particleRadius = 1.25;
   faceViewer = true;

   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.5;
};


datablock FlareProjectileData(StarBrustProj){
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = false;
   kickBackStrength    = 1500;
   useLensFlare        = false;

   sound 			   = FlareGrenadeBurnSound;
   explosion           = StarBrustExplosion;
   velInheritFactor    = 1;

   texture[0]          = "special/redflare";
   texture[1]          = "special/LensFlare/flare00";
   size                = 1.0;

   baseEmitter         = FlareEmitter;

   grenadeElasticity = 0.35;
   grenadeFriction   = 0.2;
   armingDelayMS     = 256;
   muzzleVelocity    = 90.0;
   drag = 0.1;
   gravityMod = 3;
};

datablock ShapeBaseImageData(STBurstCannon0Image){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = STBurstCannon0;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;
   projectile = StarBrustProj;
   projectileType = FlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;
   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";
   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";
   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.4;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFireMod";
   stateSound[3] = GrenadeFireSound;
   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = GrenadeReloadSound;
   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";
   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};
function STBurstCannon0Image::onFireMod(%data, %obj, %slot){
   %p = parent::onFireMod(%data, %obj, %slot);
   if((%obj.client.mod3 == 5)){
      FlareSet.add(%p);
   }
}
function STBurstCannon0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function STBurstCannon0Image::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %this.dwUnMount(%obj, %slot);
}

datablock ParticleData(FireballTrailParticle){
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.2;   
   inheritedVelFactor   = 0.00;

   lifetimeMS           = 250;  
   lifetimeVarianceMS   = 150;  

   textureName          = "particleTest";

   useInvAlpha = false;
   spinRandomMin = -100.0;
   spinRandomMax = 100.0;

   colors[0]     = "1.0 0.7 0.5 1.0";
   colors[1]     = "1.0 0.5 0.2 1.0";
   colors[2]     = "1.0 0.25 0.1 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 2.0;
   sizes[2]      = 0.1;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(FireballTrailEmitter){
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 0.25;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 30.0;

   particles = "FireballTrailParticle";
};
datablock ExplosionData(FireballStarSubExplosion)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;

   delayMS = 50;

   offset = 3.0;

   playSpeed = 1.5;

   sizes[0] = "0.5 0.5 0.5";
   sizes[1] = "0.5 0.5 0.5";
   times[0] = 0.0;
   times[1] = 1.0;

};             

datablock ExplosionData(STBBoltExplosion){
   //soundProfile   = PlasmaBarrelExpSound;
   particleEmitter = FireballAtmosphereExplosionEmitter;
   particleDensity = 250;
   particleRadius = 1.25;
   faceViewer = true;

   emitter[0] = FireballAtmosphereCrescentEmitter;

   subExplosion[0] = FireballStarSubExplosion;


};

datablock LinearFlareProjectileData(StarPlasma)
{
   projectileShapeName = "plasmabolt.dts";
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.15;
   damageRadius        = 8.0;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Dark;
   baseEmitter = FireballTrailEmitter;

   explosion           = "STBBoltExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 50.0; // z0dd - ZOD, 7/20/02. Faster plasma projectile. was 55
   wetVelocity       = 50;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 0;
   lifetimeMS        = 256;
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

   
   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
};

function StarBrustProj::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
   %burstCount = 8;
   %obj =  %proj.sourceObject;
   for(%i = 0; %i < %burstCount; %i++){
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.7;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.7;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.7;
      %mat = MatrixCreateFromEuler(%x SPC %y SPC %z);
      %vector = MatrixMulVector(%mat, "0 0 1");
      %p = new LinearFlareProjectile() 
      {
         dataBlock = StarPlasma;
         initialDirection = %vector;
         initialPosition  = %pos;
         sourceObject = -1;
         sourceSlot = 0;
         sObj = %obj;
      };
      MissionCleanup.add(%p);  
   }  
}

function StarPlasma::onExplode(%data, %proj, %pos, %mod){
   %proj.sourceObject = %proj.sObj;
   %data.onExplodeMod(%proj, %pos, %mod);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[3,4] = "STHMB0" TAB 50;


datablock ItemData(STHMB0){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_plasma.dts";
   image = STHMB0Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false; 
   
   wepClass = "ST";
   wepNameID = "ST-5";
   wepName = "Star Heavy Blaster";
   light = 0;
   medium = 0;
   heavy = 100;
   description = "A chain gun type weapon that does area of effect damage, but due to its heavy nature, it has a slow fire rate.";
};


datablock AudioProfile(STHMB0SpinDownSound){
   filename    = "fx/powered/inv_pad_off.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock ParticleData(PlasmaRExplosionParticle) {
   dragCoefficient = "1";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0.199609";
   constantAcceleration = "0";
   lifetimeMS = "500";
   lifetimeVarianceMS = "300";
   spinSpeed = "1";
   spinRandomMin = "0";
   spinRandomMax = "0";
   useInvAlpha = "0";
   animateTexture = "0";
   framesPerSec = "1";
   textureCoords[0] = "0 0";
   textureCoords[1] = "0 1";
   textureCoords[2] = "1 1";
   textureCoords[3] = "1 0";
   animTexTiling = "0 0";
   textureName = "special/BigSpark";
   colors[0] = "1 0 0 1";
   colors[1] = "0.996078 0.301961 0.00784314 0.71";
   colors[2] = "0.996078 0.301961 0.00784314 1";
   colors[3] = "0.996078 0.494118 0.00784314 1";
   sizes[0] = "0.494415";
   sizes[1] = "2";
   sizes[2] = "0.2";
   sizes[3] = "2";
   times[0] = "0";
   times[1] = "0.208333";
   times[2] = "0.8125";
   times[3] = "1";
};

datablock ParticleEmitterData(PlasmaRExplosionEmitter) {
   ejectionPeriodMS = "7";
   periodVarianceMS = "0";
   ejectionVelocity = "6.25";
   velocityVariance = "1";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "180";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "1";
   ambientFactor = "0";
   overrideAdvance = "1";
   orientParticles = "1";
   orientOnVelocity = "1";
   particles = "PlasmaRExplosionParticle";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";
   
   
   blendStyle = "ADDITIVE";
   sortParticles = "0";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
   
   
   
   Dampening = "0.8";
   elasticity = "0.3";
   
   
   
};

datablock ExplosionData(PlasmaRBoltExplosion){
   explosionShape = "disc_explosion.dts";
   soundProfile   = DeployablesExplosionSound;
   particleEmitter = PlasmaRExplosionEmitter;
   particleDensity = 150;
   particleRadius = 1.25;
   faceViewer = true;

   sizes[0] = "0.1 0.1 0.1";
   sizes[1] = "0.1 0.1 0.1";
   times[0] = 0.0;
   times[1] = 1.5;
};

datablock LinearFlareProjectileData(STHMB0Bolt){
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.25;
   damageRadius        = 8.5;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Dark;

   explosion           = "PlasmaRBoltExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 95.0;
   wetVelocity       = -1;
   velInheritFactor  = 0.8;
   fizzleTimeMS      = 1500;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = -1;

   size[0]           = 0.6;
   size[1]           = 0.5;
   size[2]           = 0.4;


   numFlares         = 80;
   flareColor        = "1.0 0.0 0.0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";
   sound        = ChaingunProjectile;
   
   hasLight    = true;
   lightRadius = 8.0;
   lightColor  = "1 0.0 0";
};

datablock ShapeBaseImageData(STHMB0Image){
   className = WeaponImage;
   shapeFile = "weapon_disc.dts";
   item = STHMB0;
   ammo = DarkAmmo;
   offset = "0 0 0";
   projectile = STHMB0Bolt;
   projectileType = LinearFlareProjectile;
   
    
   projectileSpread = 6.0 / 1000.0;
    
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = PlasmaSwitchSound;
   stateAllowImageChange[0] = false;

   stateTimeoutValue[0]        = 0.1;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";
   
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;

   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1]      = "NoAmmo";

   stateName[2]               = "NoAmmo";
   stateTransitionOnAmmo[2]   = "Ready";
   stateSpinThread[2]         = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";

   stateName[3]         = "Spinup";
   stateSpinThread[3]   = SpinUp;
   stateSound[3]        = MBLSwitchSound;

   stateTimeoutValue[3]          = 0.9;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   
   stateName[4]             = "Fire";
 //stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   //stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = GravChaingunFireSound;
 
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFireMod";
   stateFire[4]             = true;
   //stateEjectShell[4]       = true;
   //
   stateTimeoutValue[4]          = 0.2;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";
 
   
   stateName[5]       = "Spindown";
   stateSound[5]      = STHMB0SpinDownSound;
   //stateSpinThread[5] = SpinDown;

   stateTimeoutValue[5]            = 1.0;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   stateName[6]       = "EmptySpindown";
   stateSound[6]      = STHMB0SpinDownSound;
   //stateSpinThread[6] = SpinDown;
   
   stateTimeoutValue[6]        = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
   offset = "0.0 0 0.0";
   
};
 datablock ShapeBaseImageData(STHMB0Image4)
{
   offset = "0.0 0 0.05";
   rotation = "0 1 0 0";
   shapeFile = "weapon_plasma.dts";
    emap = true;

};
datablock ShapeBaseImageData(STHMB0Image5){
   offset = "0.0 0 0.18";
   rotation = "0 1 0 -180";
   shapeFile = "weapon_plasma.dts";
    emap = true;
};

function STHMB0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(STHMB0Image4, 4);
   %obj.mountImage(STHMB0Image5, 5);
   %this.dwOnMount(%obj, %slot);
}

function STHMB0Image::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %this.dwUnMount(%obj, %slot);
}
function STHMB0Image::onFireMod(%data,%obj,%slot)
{
   %p = Parent::onFireMod(%data, %obj, %slot);
   if(!%p)
      return;	
      
}

function STHMB0Bolt::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

$darkWep[3,5] = "MagCan" TAB 6;

datablock ItemData(MagCan){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = MagCanImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";

   computeCRC = false;

   wepClass = "ST";
   wepNameID = "ST-2";
   wepName = "Star Magnetar";
   light = 0;
   medium = 12;
   heavy = 15;
   description = "A powerful weapon that utilizes the power of magnetism to pull targets towards the point of impact, immobilizing them in place";
};


datablock ParticleData(MagCanExplosionParticle) {
   dragCoefficient = "0";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "3000";
   lifetimeVarianceMS = "0";
   spinSpeed = "1";
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
   textureName = "special/BlueImpact";
   colors[0] = "0.19 0 1 1";
   colors[1] = "0.19 0 1 1";
   colors[2] = "0.19 0 1 1";
   colors[3] = "0.0 0 1 1";
   sizes[0] = "1";
   sizes[1] = "2";
   sizes[2] = "5";
   sizes[3] = "6";
   times[0] = "0";
   times[1] = "0.1875";
   times[2] = "0.554167";
   times[3] = "1";
};

datablock ParticleEmitterData(MagCanExplosionEmitter) {
   ejectionPeriodMS = "60";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "2";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "0";
   phiReferenceVel = "0";
   phiVariance = "0";
   softnessDistance = "0.0001";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "MagCanExplosionParticle";
   lifetimeMS = "1";
   lifetimeVarianceMS = "0";
   
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
   
   Dampening = "0.8";
   elasticity = "0.3";
   
};

datablock ParticleData(MagCanShockwaveParticle) {
   dragCoefficient = "0";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "500";
   lifetimeVarianceMS = "100";
   spinSpeed = "1";
   spinRandomMin = "-1000";
   spinRandomMax = "1000";
   useInvAlpha = "0";
   animateTexture = "0";
   framesPerSec = "1";
   textureCoords[0] = "0 0";
   textureCoords[1] = "0 1";
   textureCoords[2] = "1 1";
   textureCoords[3] = "1 0";
   animTexTiling = "0 0";
   textureName = "special/shockLightning02";
   colors[0] = "0.19 0 1 1";
   colors[1] = "0.19 0 1 1";
   colors[2] = "0 0 1 1";
   colors[3] = "0 0 1 1";
   sizes[0] = "0.494415";
   sizes[1] = "0.796557";
   sizes[2] = "0.997986";
   sizes[3] = "1";
   times[0] = "0";
   times[1] = "0.0431373";
   times[2] = "1";
   times[3] = "1";
};

datablock ParticleEmitterData(MagCanShockwaveEmitter) {
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "4.167";
   velocityVariance = "0";
   ejectionOffset = "2.708";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "86.25";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "0.0001";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "MagCanShockwaveParticle";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";
   
   
   blendStyle = "ADDITIVE";
   sortParticles = "1";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
   
   
   
   Dampening = "0.8";
   elasticity = "0.3";
   
   
   
};

datablock ParticleData(MagCanSmokeParticle) {
   dragCoefficient = "2";
   gravityCoefficient = 0.0;
   inheritedVelFactor = "0";
   windCoefficient = "0";
   constantAcceleration = -30;
   lifetimeMS = "650";
   lifetimeVarianceMS = "0";
   spinRandomMin = "-200";
   spinRandomMax = "200";
   useInvAlpha = "0";
   
   colors[0] = "0.204724 0.204724 0.204724 0";
   colors[1] = "0.291339 0.291339 0.291339 0.199213";
   colors[2] = "0.259843 0.259843 0.259843 0.188976";
   colors[3] = "0.0787402 0.0787402 0.0787402 0.015748";
      
   sizes[0] = "10";
   sizes[1] = "10";
   sizes[2] = "10";
   sizes[3] = "10";
   
   times[0] = "0.1";
   times[1] = "0.8";
   times[2] = "0.9";
   times[3] = "1";
   
   spinSpeed = "1";
   textureName = "particleTest";


};

datablock ParticleEmitterData(MagCanSmokeEmitter) {
   ejectionPeriodMS = "5";
   periodVarianceMS = "0";
   ejectionVelocity = "10";
   velocityVariance = "0";
   ejectionOffset = "30";
   thetaMin = "0";
   thetaMax = "180";
   phiReferenceVel = 0;
   phiVariance = 360;
   orientParticles = "0";
   orientOnVelocity = true;
   lifetimeMS = "2040";
   blendStyle = "NORMAL";
   alignDirection = "0 1 0";
      
   particles = "MagCanSmokeParticle";

};

datablock ExplosionData(MagCanExplosion)
{
   explosionShape = "disc_explosion.dts";
   soundProfile   = PlasmaBarrelExpSound;
   faceViewer           = true;

   playSpeed = 1;

   emitter[0] = MagCanExplosionEmitter;
   emitter[1] = MagCanShockwaveEmitter;
   emitter[2] = MagCanSmokeEmitter;
      
   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.0;
   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 1.3;
   camShakeRadius = 25.0;
};

datablock LinearFlareProjectileData(MagCanShot){
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.2;
   damageRadius        = 8.5;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Dark;

   explosion           = "MagCanExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 95.0;
   wetVelocity       = -1;
   velInheritFactor  = 0.8;
   fizzleTimeMS      = 1500;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = -1;

   size[0]           = 0.6;
   size[1]           = 0.5;
   size[2]           = 0.4;


   numFlares         = 80;
   flareColor        = "0.2 0.0 1";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";
   sound        = ChaingunProjectile;
   
   hasLight    = true;
   lightRadius = 8.0;
   lightColor  = "0.2 0.0 1";
};

datablock ShapeBaseImageData(MagCanImage){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = MagCan;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;
   
   projectile = MagCanShot;
   projectileType = LinearFlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 1;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFireMod";
   stateSound[3] = MBLFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   //stateSequence[4] = "Reload";
   stateSound[4] = GrenadeReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(MagCanImage2){
   offset = "0 0.4 0.15";
   rotation = "0 1 0 -90";
   shapeFile = "weapon_targeting.dts";

};

datablock ShapeBaseImageData(MagCanImage3){
   offset = "0 0.4 0.15";
   rotation = "0 1 0 90";
   shapeFile = "weapon_targeting.dts";
};

function MagCanImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(MagCanImage2, 4);
   %obj.mountImage(MagCanImage3, 5);
   %this.dwOnMount(%obj, %slot);
}

function MagCanImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %this.dwUnMount(%obj, %slot);
}

function MagCanShot::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
   emMag(%pos, 2000);
}

function emMag(%pos,%time){
  %force = 800;
   InitContainerRadiusSearch(%pos,  30, $TypeMasks::PlayerObjectType); 
   while ((%targetObject = containerSearchNext()) != 0){
      %tgtPos = %targetObject.getWorldBoxCenter();
      %vec = VectorNormalize(VectorSub(%pos, %tgtPos));
      %impulseVec = VectorScale(%vec, %force);
      %targetObject.applyImpulse(%pos, %impulseVec);
    } 
    if(%time > 0){
       %time -= 100;
      schedule(128,0,"emMag",%pos,%time);
    }
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[4,1] = "EWElectroBolt0" TAB 50;
datablock ItemData(EWElectroBolt0){
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_chaingun.dts";
   image        = EWElectroBolt0Image;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false;
   emap = true;

   wepClass = "EW";
   wepNameID = "EW-3112";
   wepName = "Electro Bolt";
   light = 1;
   medium = 1;
   heavy = 1;
   description = "A purely energy-based chain gun, meaning that it doesn't require any physical ammunition to operate.";
}; 

datablock ParticleData(EWElectroBolt0ExplosionParticle){
   dragCoefficient      = 1.77;
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0;
   constantAcceleration = 0;
   lifetimeMS           = 218;
   lifetimeVarianceMS   = 50;
   textureName          = "special/lightning1frame1";
   useInvAlpha = 0;
   colors[0]     = "0 0.4 1 1";
   colors[1]     = "0 0.4 1 0.2";
   sizes[0]      = 0.5;
   sizes[1]      = 1;
};

datablock ParticleEmitterData(EWElectroBolt0ExplosionEmitter){
   ejectionPeriodMS = 7;
   periodVarianceMS = 4;
   ejectionVelocity = 5;
   velocityVariance = 2;
   ejectionOffset   = 0;
   thetaMin         = 90;
   thetaMax         = 90;
   phiReferenceVel  = 143;
   phiVariance      = 360;
   overrideAdvances = 0;
   orientParticles = 1;
   particles = EWElectroBolt0ExplosionParticle;
};

datablock ExplosionData(EWElectroBolt0TraceExplosion){
   explosionShape =  "energy_explosion.dts";
   soundProfile   = ChaingunImpact;
   particleEmitter = EWElectroBolt0ExplosionEmitter;
   particleDensity = 90;
   particleRadius = 0.5;
   faceViewer = false;
   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.5;
};

datablock TracerProjectileData(EWElectroBolt0Bullet){
   doDynamicClientHits = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.09;
   damageRadius        = 1.0;
   radiusDamageType    = $DamageType::Dark;
   explosion           = EWElectroBolt0TraceExplosion;
   splash              = ChaingunSplash;
   kickBackStrength  = 0.0;
   sound = ChaingunProjectile;
   dryVelocity       = 500;
   wetVelocity       = 280.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 15.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 20.0;
   fizzleUnderwaterMS        = 3000;
   tracerLength    = 22;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = "0 0.3 1 1";
   tracerTex[0] = "special/bluespark";
   tracerTex[1] = "special/shrikeBoltCross";
   tracerWidth  = 0.20;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;
   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};

datablock ShapeBaseImageData(EWElectroBolt0Image){
   className = WeaponImage;
   shapeFile = "weapon_chaingun.dts";
   item      = EWElectroBolt0;
   //ammo 	 = DarkAmmo;
   projectile = EWElectroBolt0Bullet;
   projectileType = TracerProjectile;
   
   usesEnergy = true;
   fireEnergy = 1;
   minEnergy = 4;

   emap = true;
   //casing              = ShellDebris;
   //shellExitDir        = "1.0 0.3 1.0";
   //shellExitOffset     = "0.15 -0.56 -0.1";
   //shellExitVariance   = 15.0;
   //shellVelocity       = 3.0;
   projectileSpread = 1.0 / 1000.0;
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = ChaingunSwitchSound;
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0]        = 0.5;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1]      = "NoAmmo";
   stateName[2]               = "NoAmmo";
   stateTransitionOnAmmo[2]   = "Ready";
   stateSpinThread[2]         = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";
   stateName[3]         = "Spinup";
   stateSpinThread[3]   = SpinUp;
   stateSound[3]        = ChaingunSpinupSound;
   stateTimeoutValue[3]          = 0.5;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = ChaingunFireSound;
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFireMod";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   stateTimeoutValue[4]          = 0.15;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";
   stateName[5]       = "Spindown";
   stateSound[5]      = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   stateTimeoutValue[5]            = 1.0;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";
   stateName[6]       = "EmptySpindown";
   stateSound[6]      = ChaingunSpinDownSound;
   stateSpinThread[6] = SpinDown;
   stateTimeoutValue[6]        = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ShapeBaseImageData(EWElectroBolt3Image){
   offset = "0.1 0.4 0.02";
   rotation = "1 0 0 90";
   shapeFile = "pack_upgrade_energy.dts";
    emap = true;
};

function EWElectroBolt0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(EWElectroBolt3Image, 4);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function EWElectroBolt0Image::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %this.dwUnMount(%obj, %slot);
}

function EWElectroBolt0Bullet::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
//////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////
$darkWep[4,2] = "COMidRangeNA0" TAB 25;

datablock ItemData(COMidRangeNA0){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_disc.dts";
   image = COMidRangeNA0Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   emap = true;
   computeCRC = false;

   wepClass = "CO";
   wepNameID = "CO-1";
   wepName = "Core ZeFF-One";
   light = 15;
   medium = 25;
   heavy = 30;
   description = "A multi mode weapon that fires a little bit of everything at random";
};

datablock ShapeBaseImageData(COMidRangeNA0Image){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = COMidRangeNA0;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.25;
   stateFire[3] = true;
   //stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFireMod";
   //stateSound[3] = PlasmaFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.1;
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
   
   stateName[7] = "WetFire";
   stateTransitionOnTimeout[7] = "Reload";
   stateTimeoutValue[7] = 0.1;
   stateFire[7] = true;
   //stateRecoil[7] = LightRecoil;
   stateAllowImageChange[7] = false;
   stateScript[7] = "onWetFire";
   
   stateName[8]               = "CheckWet";
   stateTransitionOnWet[8]    = "WetFire";
   stateTransitionOnNotWet[8] = "Fire";
   
};

datablock ShapeBaseImageData(COMidRangeNA0Image4){
   offset = "0 0.1 0.2";
   rotation = "0 1 0 0";
   shapeFile = "weapon_energy.dts";
    emap = true;

};

datablock ShapeBaseImageData(COMidRangeNA0Image5){
   offset = "-0.05 0.1 0.25";
   rotation = "0 1 0 90";
   shapeFile = "weapon_disc.dts";
    emap = true;
};

datablock ShapeBaseImageData(COMidRangeNA0Image6){
   offset = "0.15 0.1 0.25";
   rotation = "0 1 0 -90";
   shapeFile = "weapon_chaingun.dts";
    emap = true;
};

datablock ShapeBaseImageData(COMidRangeNA0Image7){
   offset = "0 0.1 0.15";
   rotation = "0 1 0 180";
   shapeFile = "weapon_plasma.dts";
    emap = true;
};

datablock LinearProjectileData(DiscProjectileC) : DiscProjectile {
   radiusDamageType    = $DamageType::Dark;
};
//--------------------------------------
datablock LinearFlareProjectileData(PlasmaBoltC) : PlasmaBolt {
   radiusDamageType    = $DamageType::Dark;
};
datablock GrenadeProjectileData(BasicGrenadeC) : BasicGrenade {
   radiusDamageType    = $DamageType::Dark;
};
datablock LinearProjectileData(RocketC)
{
   projectileShapeName = "weapon_missile_projectile.dts";
   emitterDelay = -1;
   baseEmitter = MissileSmokeEmitter;
   delayEmitter = MissileFireEmitter;
   bubbleEmitter = GrenadeBubbleEmitter;
   bubbleEmitTime = 1.0;
   directDamage = 0.0;
   hasDamageRadius = true;
   indirectDamage = 0.5;
   damageRadius = 7.5;
   radiusDamageType = $DamageType::Dark;
   kickBackStrength = 2000;
   sound = MissileProjectileSound;
   explosion = "MissileExplosion";
   underwaterExplosion = "UnderwaterDiscExplosion";
   splash = MissileSplash;
   dryVelocity = 90;
   wetVelocity = 50;
   velInheritFactor = 0.75;
   fizzleTimeMS = 5000;
   lifetimeMS = 5000;
   explodeOnDeath = true;
   reflectOnWaterImpactAngle = 15.0;
   explodeOnWaterImpact = false;
   deflectionOnWaterImpact = 20.0;
   fizzleUnderwaterMS = 5000;
//   activateDelayMS = 200;
   hasLight = true;
   lightRadius = 6.0;
   lightColor = "0.175 0.175 0.5";
};

function COMidRangeNA0Image::onFireMod(%data,%obj,%slot){
   %rng = getRandom(1,6);
   switch(%rng){
      case 1:
         %p = new EnergyProjectile() {
            dataBlock        = EnergyBolt;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };  
         serverPlay3D(BlasterFireSound, %obj.getTransform());
      case 2:
         %p = new LinearProjectile() {
            dataBlock        = DiscProjectileC;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };
         serverPlay3D(DiscFireSound, %obj.getTransform());
      case 3:
         %p = new LinearFlareProjectile() {
            dataBlock        = PlasmaBoltC;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };
         serverPlay3D(PlasmaFireSound, %obj.getTransform());
      case 4:
         %p = new GrenadeProjectile() {
            dataBlock        = BasicGrenadeC;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };
         serverPlay3D(GrenadeFireSound, %obj.getTransform());
      case 5: 
         %p = new TracerProjectile() {
            dataBlock        = ChaingunBullet;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };
         serverPlay3D(ChaingunImpact, %obj.getTransform());
      case 6:
            %p = new LinearProjectile() {
               dataBlock = RocketC;
               initialDirection = %obj.getMuzzleVector(%slot);
               initialPosition = %obj.getMuzzlePoint(%slot);
               sourceObject = %obj;
               sourceSlot = %slot;
            };
            MissionCleanup.add(%p);
            serverPlay3D(MissileFireSound, %obj.getTransform());
      default:
         %p = new TracerProjectile() {
            dataBlock        = ChaingunBullet;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };
         serverPlay3D(ChaingunImpact, %obj.getTransform());
   }
   MissionCleanup.add(%p);
   //serverPlay3D(LaserCannonFireSound, %obj.getTransform());
   %obj.decInventory(%data.ammo, 1);
}

function RocketC::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
function BasicGrenadeC::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
function PlasmaBoltC::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
function DiscProjectileC::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

function COMidRangeNA0Image::onWetFire(%data,%obj,%slot){
   %rng = getRandom(1,5);
   switch(%rng){
      case 1:
         %p = new EnergyProjectile() {
            dataBlock        = EnergyBolt;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };  
         serverPlay3D(BlasterFireSound, %obj.getTransform());
      case 2:
         %p = new LinearProjectile() {
            dataBlock        = DiscProjectileC;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };
         serverPlay3D(DiscFireSound, %obj.getTransform());
      case 3:
         %p = new TracerProjectile() {
            dataBlock        = ChaingunBullet;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };
         serverPlay3D(ChaingunImpact, %obj.getTransform());
      case 4:
         %p = new GrenadeProjectile() {
            dataBlock        = BasicGrenadeC;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };
         serverPlay3D(GrenadeFireSound, %obj.getTransform());
      case 5: 
         %p = new TracerProjectile() {
            dataBlock        = ChaingunBullet;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };
         serverPlay3D(ChaingunImpact, %obj.getTransform());
      default:
         %p = new TracerProjectile() {
            dataBlock        = ChaingunBullet;
            initialDirection = %obj.getMuzzleVector(%slot);
            initialPosition  = %obj.getMuzzlePoint(%slot);
            sourceObject     = %obj;
            sourceSlot       = %slot;
         };
         serverPlay3D(ChaingunImpact, %obj.getTransform());
   }
   MissionCleanup.add(%p);
   %obj.decInventory(%data.ammo, 1);
}

function COMidRangeNA0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(COMidRangeNA0Image4, 4);
   %obj.mountImage(COMidRangeNA0Image5, 5);
   %obj.mountImage(COMidRangeNA0Image6, 6);
   %obj.mountImage(COMidRangeNA0Image7, 7);
   %this.dwOnMount(%obj, %slot);
}

function COMidRangeNA0Image::onUnmount(%this,%obj,%slot){
   parent::onUnmount(%this,%obj,%slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %obj.unmountImage(7);
   %this.dwUnMount(%obj, %slot);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[4,3] = "COBeeCharge" TAB 10;

datablock ItemData(COBeeCharge){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = CORemoteCharge0Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false;
   
   wepClass = "CO";
   wepNameID = "CO-670";
   wepName = "Core Bee Charge";
   light = 15;
   medium = 25;
   heavy = 30;
   description = "A weapon that sends out a swarm of high energy projectiles";
};



datablock GrenadeProjectileData(CoreBeeGrenade)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.3;
   damageRadius        = 15.0;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 1500;
   bubbleEmitTime      = 1.0;

   sound               = GrenadeProjectileSound;
   explosion           = "GrenadeExplosion";
   underwaterExplosion = "UnderwaterGrenadeExplosion";
   velInheritFactor    = 0.85; // z0dd - ZOD, 3/30/02. Was 0.5
   splash              = GrenadeSplash;

   baseEmitter         = GrenadeSmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.30; // z0dd - ZOD, 9/13/02. Was 0.35
   grenadeFriction   = 0.2;
   armingDelayMS     = 650; // z0dd - ZOD, 9/13/02. Was 1000
   muzzleVelocity    = 75.00; // z0dd - ZOD, 3/30/02. GL projectile is faster. Was 47.00
   //drag = 0.1; // z0dd - ZOD, 3/30/02. No drag.
   gravityMod        = 1.9; // z0dd - ZOD, 5/18/02. Make GL projectile heavier, less floaty
};


datablock ShapeBaseImageData(CORemoteCharge0Image){
   className = WeaponImage;
   shapeFile = "weapon_plasma.dts";
   item = COBeeCharge;
   showname = "";
   ammo = DarkAmmo;
   offset = "0 0 0";

   emap = true;

   projectile = CoreBeeGrenade;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.4;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFireMod";
   stateSound[3] = GrenadeFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = GrenadeReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function CORemoteCharge0Image::onFireMod(%data, %obj, %slot){
   %p =  Parent::onFireMod(%data, %obj, %slot);
}
datablock ShapeBaseImageData(CORemoteCharge0Image2){
   offset = "0 0.5 0.24";
   rotation = "0 0 1 90";
   rotation = "0 1 0 90";
   shapeFile = "weapon_targeting.dts";
   emap = true;
};
datablock ShapeBaseImageData(CORemoteCharge0Image3){
   offset = "0 0.5 0.24";
   rotation = "0 1 0 -90";
   shapeFile = "weapon_targeting.dts";
   emap = true;
};
datablock ShapeBaseImageData(CORemoteCharge0Image4){
   offset = "0.0 0.7 0.18";
   rotation = "0 0 1 0";
   shapeFile = "mine.dts";
   emap = true;
};
function CORemoteCharge0Image::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(CORemoteCharge0Image2, 4);
   %obj.mountImage(CORemoteCharge0Image3, 5);
   %obj.mountImage(CORemoteCharge0Image4, 6);
   %obj.cannonfire = 0;
   %this.dwOnMount(%obj, %slot);
}

function CORemoteCharge0Image::onUnmount(%this, %obj, %slot){
   %obj.cannonfire = 0;
   Parent::onUnmount(%this,%obj,%slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %this.dwUnMount(%obj, %slot);
}


datablock EnergyProjectileData(beeBolt)
{
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.08;
   damageRadius        = 1.0;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 0.0;
   bubbleEmitTime      = 1.0;
   // z0dd - ZOD, 5/07/04. Shotgun blaster no sound when gameplay changes in affect
   sound = BlasterProjectileSound;
   velInheritFactor    = 0.5;

   explosion           = "BlasterExplosion";
   splash              = BlasterSplash;

   grenadeElasticity = 0.998;
   grenadeFriction   = 0.0;
   armingDelayMS     = 500;

   muzzleVelocity    = 90.0;

   drag = 0.05;

   gravityMod        = 0.0;

   dryVelocity       = 200.0;
   wetVelocity       = 150.0;

   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   hasLight    = true;
   lightRadius = 1;
   lightColor  = "1 1 0";

   scale = vectorScale("0.25 20.0 1.0",0.5);
   crossViewAng = 0.99;
   crossSize = 0.55;

   lifetimeMS     = 3000;
   blurLifetime   = 0.01;
   blurWidth      = 0.01;
   blurColor = "1 1 0 1.0";

   texture[0] = "special/landSpikeBoltCross";
   texture[1] = "special/landSpikeBoltCross";
};

function CoreBeeGrenade::onExplode(%data, %proj, %pos, %mod){
    %data.schedule(32,"onExplodeMod",%proj, %pos, %mod);
    
   %burstCount = 8;
   %tc = 0;
   %obj = %proj.sourceObject;
   InitContainerRadiusSearch(%pos,  16,  $TypeMasks::PlayerObjectType);
   while ((%player = containerSearchNext()) != 0){
      if(%obj.team == %player.team){
         continue;
      }
      %mask = $TypeMasks::StaticShapeObjectType | 
      $TypeMasks::InteriorObjectType | 
      $TypeMasks::TerrainObjectType | 
      $TypeMasks::ForceFieldObjectType | 
      $TypeMasks::VehicleObjectType;
      %hit = ContainerRayCast(%pos, %player.getWorldBoxCenter(), %mask);
      if(isObject(%player) && %player.getState() !$= "Dead" && !%hit && %projectile.count < 2){
         %tc++;
         %vec = vectorNormalize(vectorSub(%player.getWorldBoxCenter(), %pos));
          %p = new EnergyProjectile(){
            dataBlock = beeBolt;
            initialDirection =  %vec;
            initialPosition  =  VectorAdd(%pos, VectorScale(%vec, 4));
            sourceObject = %obj;
            sourceSlot = -1;
            count = %projectile.count + 0;
         };
         MissionCleanup.add(%p);
      }
   }

   for(%i =  %tc; %i < %burstCount; %i++){
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.7;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.7;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.7;
      %mat = MatrixCreateFromEuler(%x SPC %y SPC %z);
      %vector = MatrixMulVector(%mat, "0 0 1");
      %p = new EnergyProjectile()  
      {
         dataBlock = beeBolt;
         initialDirection = %vector;
         initialPosition  = %pos;
         sourceObject = %proj.sourceObject;
         sourceSlot = 0;
         sObj = %obj;
      };
      MissionCleanup.add(%p);  
   }  
}


function beeBolt::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal){
   %data.schedule(32,"onExplodeMod",%projectile, %position, %modifier);
   if((%obj.client.mod3 == 5 || %obj.client.mod2== 5) && getRandom(1,20) == 20){
      %obj = %projectile.sourceObject;
      %count = 0;
      InitContainerRadiusSearch(%position,  50,  $TypeMasks::PlayerObjectType);
      while ((%player = containerSearchNext()) != 0){
         if(%obj.team == %player.team){
            continue;
         }

         %mask = $TypeMasks::StaticShapeObjectType | 
         $TypeMasks::InteriorObjectType | 
         $TypeMasks::TerrainObjectType | 
         $TypeMasks::ForceFieldObjectType | 
         $TypeMasks::VehicleObjectType;
         %hit = ContainerRayCast(%position, %player.getWorldBoxCenter(), %mask, %targetObject);
         if(isObject(%player) && %player.getState() !$= "Dead" && !%hit && %projectile.count < 4){
            %vec = vectorNormalize(vectorSub(%player.getWorldBoxCenter(), %position));
            %p = new EnergyProjectile(){
               dataBlock = beeBolt;
               initialDirection =  %vec;
               initialPosition  =  VectorAdd(%position, VectorScale(%vec, 4));
               sourceObject = %obj;
               sourceSlot = -1;
               count = %projectile.count + 1;
            };
            MissionCleanup.add(%p);
         }
      }
   }
}

//////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
$darkWep[4,4] = "EDiscGun" TAB 15;

datablock ItemData(EDiscGun){
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_disc.dts";
   image        = TurboDiscImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false;
   emap = true;

   wepClass = "CO";
   wepNameID = "CO-1120";
   wepName = "Energy Disc";
   light = 10;
   medium = 20;
   heavy = 30;
   description = "A 3-mode weapon that switches mode depending on the user's energy level.";
}; 

datablock ParticleData(OvchgDiscTrailParticle){
   dragCoeffiecient     = 10000.0;
   gravityCoefficient   = 0.002;
   windCoefficient   = 0.0;   
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 2550; 
   lifetimeVarianceMS   = 0; 

   textureName          = "special/droplet";

   useInvAlpha = false;
   spinRandomMin = 0.0;
   spinRandomMax = 0.0;

   colors[0]     = "0.575 0.575 0.9 1.0";
   colors[1]     = "0.575 0.575 0.9 0.5";
   colors[2]     = "0.575 0.575 0.9 0.0";

   sizes[0]      = 0.40;
   sizes[1]      = 0.80;
   sizes[2]      = 1.20;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(OvchgDiscTrailEmitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionOffset = 1.0;
   ejectionVelocity = 0;
   velocityVariance = 0;

   thetaMin         = 0.0;
   thetaMax         = 180;

   particles = "OvchgDiscTrailParticle";
};

datablock ExplosionData(OvchgDiscExplosion){
   explosionShape = "disc_explosion.dts";
   soundProfile   = discExpSound;
   playSpeed = 0.65;

   faceViewer     = true;
   explosionScale = "2.0 2.0 2.0";

   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 12.0;

   sizes[0] = "2 2 2";
   sizes[1] = "2 2 2";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock LinearProjectileData(OPDiscProjectile){
   projectileShapeName = "disc.dts";
   scale               = "2.5 2.5 2.5";  // 2.5 2.5 2.5
   emitterDelay        = 128;
   directDamage        = 0;
   hasDamageRadius     = true;
   indirectDamage      = 0.6;
   damageRadius        = 8.5;
   directDamageType    = $DamageType::Dark;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 4000;  

   sound 				= discProjectileSound;
   explosion           = "OvchgDiscExplosion";
   underwaterExplosion = "UnderwaterDiscExplosion";
   splash              = DiscSplash;
   baseEmitter         = OvchgDiscTrailEmitter;

   dryVelocity       = 95; 
   wetVelocity       = 90; 
   velInheritFactor  = 0.75;
   fizzleTimeMS      = 7000;
   lifetimeMS        = 8000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 5.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 10.0; 
   fizzleUnderwaterMS        = 3000;

   activateDelayMS = 200;

   hasLight    = true;
   lightRadius = 12.0;
   lightColor  = "0.175 0.175 0.5";
};

datablock ParticleData(LightDiscTrailParticle){
   dragCoeffiecient     = 10000.0;
   gravityCoefficient   = 0.002;   
   windCoefficient   = 0.0;   
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 950;  // lasts 2 second
   lifetimeVarianceMS   = 0;   // ...more or less

   textureName          = "special/droplet";

   useInvAlpha = false;
   spinRandomMin = 0.0;
   spinRandomMax = 0.0;

   colors[0]     = "0.575 0.575 0.9 0.0";
   colors[1]     = "0.575 0.575 0.9 1.0";
   colors[2]     = "0.575 0.575 0.9 0.0";

   sizes[0]      = 0.40;
   sizes[1]      = 0.40;
   sizes[2]      = 0.40;

   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(LightDiscTrailEmitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionVelocity = 0;
   velocityVariance = 0;

   thetaMin         = 0.0;
   thetaMax         = 180;  

   particles = "LightDiscTrailParticle";
};

datablock ExplosionData(TurboDiscExplosion){
   explosionShape = "disc_explosion.dts";
   soundProfile   = discExpSound;

   faceViewer     = true;

   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 5.0;

   sizes[0] = "0.1 0.1 0.1";
   sizes[1] = "0.1 0.1 0.1";
   times[0] = 0.0;
   times[1] = 1.0;
};
datablock LinearProjectileData(TurboDiscProjectile){
   projectileShapeName = "disc.dts";
   scale               = "0.5 3.5 0.5";
   emitterDelay        = 128;
   directDamage        = 0;
   hasDamageRadius     = true;
   indirectDamage      = 0.30;
   damageRadius        = 5.5;
   directDamageType    = $DamageType::Dark;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 0;  

   sound 				= discProjectileSound;
   explosion           = "TurboDiscExplosion";
   underwaterExplosion = "UnderwaterDiscExplosion";
   splash              = DiscSplash;
   baseEmitter         = LightDiscTrailEmitter;

   dryVelocity       = 200; 
   wetVelocity       = 120;
   velInheritFactor  = 0.75; 
   fizzleTimeMS      = 7000;
   lifetimeMS        = 8000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 5.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 10.0; 
   fizzleUnderwaterMS        = 3000;

   activateDelayMS = 200;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.175 0.175 0.5";
};

datablock LinearProjectileData(eDiscProjectile){
   projectileShapeName = "disc.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.50;
   damageRadius        = 7.5;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 2000;  

   sound 				= discProjectileSound;
   explosion           = "DiscExplosion";
   underwaterExplosion = "UnderwaterDiscExplosion";
   splash              = DiscSplash;

   dryVelocity       = 95; 
   wetVelocity       = 55; 
   velInheritFactor  = 0.75; 
   fizzleTimeMS      = 5000;
   lifetimeMS        = 5000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 15.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 20.0; 
   fizzleUnderwaterMS        = 5000;

   activateDelayMS = 200;

   hasLight    = true;
   lightRadius = 6.0;
   lightColor  = "0.175 0.175 0.5";
};

datablock ShapeBaseImageData(TurboDiscImage){
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   item = EDiscGun;
   offset = "0 0 0";
   emap = true;
   
   usesEnergy = true;
   fireEnergy = 8;
   minEnergy = 4;
   
   projectile = TurboDiscProjectile;
   projectileType = LinearProjectile;

   stateName[0]                     = "Preactivate";
   stateTransitionOnLoaded[0]       = "Activate";
   stateTransitionOnNoAmmo[0]       = "NoAmmo";

   stateName[1]                     = "Activate";
   stateTransitionOnTimeout[1]      = "Ready";
   stateTimeoutValue[1]             = 0.05;
   stateSequence[1]                 = "Activated";
   stateSound[1]                    = DiscSwitchSound;

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "Fire";
   stateSequence[2]                 = "DiscSpin";
   stateSound[2]                    = DiscLoopSound;

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 1.25;
   stateFire[3]                     = true;
   stateRecoil[3]                   = LightRecoil;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFireMod";
   stateSound[3]                    = DiscFireSound;

   stateName[4]                     = "Reload";
   stateTransitionOnNoAmmo[4]       = "NoAmmo";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.5; // 0.25 load, 0.25 spinup
   stateAllowImageChange[4]         = false;
   stateSequence[4]                 = "Reload";
   stateSound[4]                    = DiscReloadSound;

   stateName[5]                     = "NoAmmo";
   stateTransitionOnAmmo[5]         = "Reload";
   stateSequence[5]                 = "NoAmmo";
   stateTransitionOnTriggerDown[5]  = "DryFire";

   stateName[6]                     = "DryFire";
   stateSound[6]                    = DiscDryFireSound;
   stateTimeoutValue[6]             = 1.0;
   stateTransitionOnTimeout[6]      = "NoAmmo";
};


datablock ShapeBaseImageData(TurboDiscImage2) : TurboDiscImage{
   offset = "0 0.0 0.21";
   rotation = "0 0 1 0";
   shapeFile = "weapon_disc.dts";
   emap = true;
   ammo = DarkAmmo;
   projectile = OPDiscProjectile;
   projectileType = LinearProjectile;
   stateSound[2]                    = "";
};

datablock ShapeBaseImageData(TurboDiscImage3) : TurboDiscImage{
   offset = "0.01 0.0 0.11";
   rotation = "0 0 1 0";
   shapeFile = "weapon_disc.dts";
   emap = true;
   ammo = DarkAmmo;
   projectile = eDiscProjectile;
   projectileType = LinearProjectile;
   stateSound[2]                    = "";
};

datablock ShapeBaseImageData(TurboDiscImage4) : TurboDiscImage{
   offset = "0 0.0 0";
   rotation = "0 0 1 0";
   shapeFile = "weapon_disc.dts";
   emap = true;
   ammo = DarkAmmo;
   projectile = TurboDiscProjectile;
   projectileType = LinearProjectile;
   stateSound[2]                    = "";
};

function TurboDiscImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(TurboDiscImage2, 4);
   %obj.mountImage(TurboDiscImage3, 5);
   %obj.mountImage(TurboDiscImage4, 6);
   %this.dwOnMount(%obj, %slot);
}

function TurboDiscImage::onUnmount(%this, %obj, %slot){
   Parent::onUnmount(%this,%obj,%slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %this.dwUnMount(%obj, %slot);
}

function TurboDiscImage::onFireMod(%data, %obj, %slot){
   %epct = %obj.getEnergyPercent() * 100;
   if(%epct > 80){
      %obj.setImageTrigger(4,1); 
      %obj.schedule(32, "setImageTrigger", 4, 0);
      
   }
   else if( %epct > 40){
      %obj.setImageTrigger(6,1);
      %obj.schedule(32, "setImageTrigger", 6, 0); 
   }
   else{
      %obj.setImageTrigger(5,1);
      %obj.schedule(32, "setImageTrigger", 5, 0); 
   }
   
   if(%data.usesEnergy){
      %energy = %obj.getEnergyLevel();
      %obj.setEnergyLevel(%energy - %data.fireEnergy);
   }
   else
      %obj.decInventory(%data.ammo,1);
   return %p;
}

function TurboDiscProjectile::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
function eDiscProjectile::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
function OPDiscProjectile::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[4,5] = "MagKick" TAB 30;
datablock ItemData(MagKick){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = MagKickImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";
	
	wepClass = "CO";
   wepNameID = "CO-334";
   wepName = "Core Kicker";
   light = 8;
   medium = 12;
   heavy = 15;
   description = "A close-range weapon that delivers a powerful shockwave, capable of disarming opponents";
};

datablock ExplosionData(MagKickExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = ConcussionGrenadeExplosionSound;
   shockwave =  ConcussionGrenadeShockwave;

   emitter[0] = ConcussionGrenadeSparkEmitter;
   emitter[1] = ConcussionGrenadeCrescentEmitter;
   faceViewer = true;
   sizes[0] = "0.5 0.5 0.5";
   sizes[1] = "0.5 0.5 0.5";
   times[0] = 0.1;
   times[1] = 1.0;

   shakeCamera = true;
   camShakeFreq = "4.0 5.0 4.5";
   camShakeAmp = "140.0 140.0 140.0";
   camShakeDuration = 1.0;
   camShakeRadius = 15.0;
};

datablock LinearFlareProjectileData(MagKickShot){
   projectileShapeName = "plasmabolt.dts";
   scale               = "1 1 1";
   faceViewer          = true;
   directDamage        = 0.01;
   hasDamageRadius     = true;
   indirectDamage      = 0.05;
   damageRadius        = 10;
   kickBackStrength    = 10000.0;
   radiusDamageType    = $DamageType::Dark;
   directDamageType    = $DamageType::Dark;
   blockSelfDamage = true;
   canConc  = true;
   Impulse = true;
   explosion           = "MagKickExplosion";
   underwaterExplosion = "UnderwaterMortarExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 100;
   wetVelocity       =  1;
   velInheritFactor  = 1;
   fizzleTimeMS      = 0;
   lifetimeMS        = 128;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.9;
   size[1]           = 1.0;
   size[2]           = 0.1;


   numFlares         = 35;
   flareColor        = "1 0.75 0.25";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.2 0.0";
};

datablock ShapeBaseImageData(MagKickImage){
   className = WeaponImage;
   shapeFile = "weapon_plasma.dts";
   item = MagKick;
   ammo = DarkAmmo;
   offset = "0 0 0";
   
   projectile = MagKickShot;
   projectileType = LinearFlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.4;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFireMod";
   stateSound[3] = PlasmaBarrelExpSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = GrenadeReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(MagKick2Image){
   offset = "0 0.1 0.2";
   rotation = "0 1 0 90";
   shapeFile = "weapon_elf.dts";
    emap = true;

};

datablock ShapeBaseImageData(MagKick3Image){
   offset = "0 0.1 0.25";
   rotation = "0 1 0 -90";
   shapeFile = "weapon_elf.dts";
    emap = true;
};

function MagKickShot::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

function MagKickImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(MagKick2Image, 4);
   %obj.mountImage(MagKick3Image, 5);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function MagKickImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %this.dwUnMount(%obj, %slot);
}

function MagKickImage::onFireMod(%data, %obj, %slot){
   parent::onFireMod(%data, %obj, %slot); 
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[5,1] = "LightningWrath" TAB 16;

datablock ItemData(LightningWrath){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = LightningWrathImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";
	
	wepClass = "DKM";
   wepNameID = "DKM-1337";
   wepName = "Lightning Wrath";
   light = 0;
   medium = 15;
   heavy = 25;
   description = "A deadly beam weapon that unleashes a powerful stream of electricity capable of penetrating even the toughest armor.";
};

datablock AudioProfile(LightningWrathSwitchSound){
   filename    = "fx/Bonuses/down_straipass1_yoyo.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(LightningWrathFireSound){
   filename    = "fx/Bonuses/down_perppass3_bunnybump.wav";
   description = AudioBIGExplosion3d;//AudioClose3d;
   preload = true;
};

datablock ShockwaveData(LightningWrathShockwave){
   width = 10;
   numSegments = 32;
   numVertSegments = 7;
   velocity = 10;
   acceleration = 140.0;
   lifetimeMS = 700;
   height = 6;
   verticalCurve = 0.375;

   mapToTerrain = false;
   renderBottom = true;
   orientToNormal = true;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 3.0;

   times[0] = 0.1;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.0 0.5 1.0 1.0";
   colors[1] = "0.0 0.5 1.0 1.0";
   colors[2] = "0.0 0 1.0 0.0";
};

datablock ParticleData(LightningWrathExplosionParticle){
   dragCoefficient      = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 2000;
   lifetimeVarianceMS   = 500;
   textureName          = "special/lightning2frame2";
   colors[0]     = "0.0 0.0 1.0 1.0";
   colors[1]     = "0.0 1.0 1.0 0.0";
   sizes[0]      = 1.5;
   sizes[1]      = 9;
};

datablock ParticleEmitterData(LightningWrathExplosionEmitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 10;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0.0;
   thetaMax         = 90;
   lifetimeMS           = 2000;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   orientParticles  = true;
   overrideAdvances = false;
   particles = "LightningWrathExplosionParticle";
};




datablock ExplosionData(LightningWrathBoltExplosion){
   explosionShape = "disc_explosion.dts";
   soundProfile   = LightningWrathFireSound;
   particleEmitter = LightningWrathExplosionEmitter;
   shockwave      = LightningWrathShockwave;
   particleDensity = 150;
   particleRadius = 1.25;
   faceViewer = true;

   colors[0] = "0.0 0.0 1.0 0.0";
   colors[1] = "0.0 0.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 0.4;
   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "5.0 5.0 5.0";

};

datablock SniperProjectileData(LightningWrathBeam){
   directDamage        = 0.0;
   directDamageType    = $DamageType::Dark;
   radiusDamageType    = $DamageType::Dark;
   hasDamageRadius     = true;
   indirectDamage      = 0.4;
   damageRadius        = 1.0;
   velInheritFactor    = 1.0;
   sound 			   = LightningWrathFireSound;
   explosion           = LightningWrathBoltExplosion;
   splash              = PlasmaSplash;

   maxRifleRange       = 1000;
   rifleHeadMultiplier = 1;   
   beamColor           = "0 0.0 1.0";
   fadeTime            = 0.8;
   explodeOnWaterImpact      = true;
   startBeamWidth		  = 1.0;
   endBeamWidth 	     = 1.0;
   pulseBeamWidth 	  = 4.5;
   beamFlareAngle 	  = 3.0;
   minFlareSize        = 0.0;
   maxFlareSize        = 400.0;
   pulseSpeed          = 6.0;
   pulseLength         = 0.150;

   lightRadius         = 1.0;
   lightColor          = "0 0.0 1.0";

   textureName[0]      = "special/flare";
   textureName[1]      = "special/nonlingradient";
   textureName[2]      = "special/skyLightning";// special/laserrip01
   textureName[3]      = "special/skyLightning";
   textureName[4]      = "special/skyLightning";
   textureName[5]      = "special/skyLightning";
   textureName[6]      = "special/skyLightning";
   textureName[7]      = "special/skyLightning";
   textureName[8]      = "special/skyLightning";
   textureName[9]      = "special/skyLightning";
   textureName[10]     = "special/skyLightning";
   textureName[11]     = "special/skyLightning";


};

datablock ShapeBaseImageData(LightningWrathImage){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = LightningWrath;
   ammo = DarkAmmo;
   offset = "0 0 0";
   
   projectile = LightningWrathBeam;
   projectileType = SniperProjectile;


   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "ActivateReady";
   stateSound[0]                    = LightningWrathSwitchSound;
   stateTimeoutValue[0]             = 0.5;
   stateSequence[0]                 = "Activate";

   stateName[1]                     = "ActivateReady";
   stateTransitionOnLoaded[1]       = "Ready";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "CheckWet";

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 1.5;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFireMod";

   stateName[4]                     = "Reload";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 1.5;
   stateAllowImageChange[4]         = false;

   stateName[5]                     = "CheckWet";
   stateTransitionOnWet[5]          = "DryFire";
   stateTransitionOnNotWet[5]       = "Fire";

   stateName[6]                     = "NoAmmo";
   stateTransitionOnAmmo[6]         = "Reload";
   stateTransitionOnTriggerDown[6]  = "DryFire";
   stateSequence[6]                 = "NoAmmo";

   stateName[7]                     = "DryFire";
   stateSound[7]                    = PlasmaDryFireSound;
   stateTimeoutValue[7]             = 0.5;
   stateTransitionOnTimeout[7]      = "Ready";
};

datablock ShapeBaseImageData(LightningWrath2Image){

   offset = "0.005 0.7 0.13";
   rotation = "1 0 0 90";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;

};

datablock ShapeBaseImageData(LightningWrath3Image){
   offset = "0.005 0.6 0.13";
    rotation = "1 0 0 90";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;
};

datablock ShapeBaseImageData(LightningWrath4Image){
   offset = "0.005 0.5 0.13";
    rotation = "1 0 0 90";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;
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
function LightningWrathImage::onMount(%this,%obj,%slot){
   parent::onMount(%this, %obj, %slot);
   %obj.mountImage(LightningWrath2Image, 4);
   %obj.mountImage(LightningWrath3Image, 5);
   %obj.mountImage(LightningWrath4Image, 6);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function LightningWrathImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %this.dwUnMount(%obj, %slot);
}

function LightningWrathImage::onFireMod(%data, %obj, %slot){
   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %obj.getMuzzleVector(%slot);
      initialPosition  = %obj.getMuzzlePoint(%slot);
      sourceObject     = %obj;
      damageFactor     = 1;
      sourceSlot       = %slot;
   };
   %p.setEnergyPercentage(1);

   %obj.lastProjectile = %p;
   MissionCleanup.add(%p);
   serverPlay3D(LightningWrathFireSound, %obj.getTransform());
   
   // AI hook
   if(%obj.client)
      %obj.client.projectile = %p;

   %obj.decInventory(%data.ammo, 1);
   %pos  = %obj.getMuzzlePoint(%slot);   
   %ray = containerRayCast(%pos, VectorAdd(%pos, VectorScale(%obj.getMuzzleVector(%slot), 2000)), $TypeMasks::StaticTSObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::WaterObjectType, %obj);
   //error(%ray);
   if(%ray){
      if(getRandom(1,100) < 5){
            %l = new Lightning(Lightning){
               position = getWords(%ray,1,3);
               rotation = "1 0 0 0";
               scale = "1 1 1000";
               dataBlock = "zapStorm";
               lockCount = "0";
               homingCount = "0";
               strikesPerMinute = "60";
               strikeWidth = "2.2";
               chanceToHitTarget = "1";
               strikeRadius = "20";
               boltStartRadius = "20"; //altitude the lightning starts from
               color = "1 1 1 1";
               fadeColor = "0.100000 0.100000 1.000000 1.000000";
               useFog = "1";
               shouldCloak = 0;
            };
            MissionCleanup.add(%l);
            %l.schedule(1500,"delete");

      }
      else{
         %l = new Lightning(Lightning){
               position = getWords(%ray,1,3);
               rotation = "1 0 0 0";
               scale = "1 1 20";
               dataBlock = "zapStorm";
               lockCount = "0";
               homingCount = "0";
               strikesPerMinute = "100";
               strikeWidth = "0.2";
               chanceToHitTarget = "0";
               strikeRadius = "20";
               boltStartRadius = "20"; //altitude the lightning starts from
               color = "1 1 1 1";
               fadeColor = "0.100000 0.100000 1.000000 1.000000";
               useFog = "1";
               shouldCloak = 0;
            };
            MissionCleanup.add(%l);
            %l.schedule(1500,"delete");
      }
   }
}
function LightningWrathBeam::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal){
    %data.onExplodeMod(%projectile, %position, %mod);
}

///////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

$darkWep[5,2] = "Bot101" TAB 50;

datablock ItemData(Bot101){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = Bot101Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";
	
	wepClass = "DKM";
   wepNameID = "DKM-0110";
   wepName = "DKM Destroyer";
   light = 15;
   medium = 25;
   heavy = 35;
   description = "A weapon that fires a vortex of dense dark matter";
};

datablock ParticleData( Bot101CrescentParticle ){
   dragCoefficient      = 2;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 0;
   textureName          = "special/crescent3";
   colors[0]     = "0.9 0.3 0.0 1.0";
   colors[1]     = "0.9 0.3 0.0 1.0";
   colors[2]     = "0.9 0.3 0.0 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 1.0;
   sizes[2]      = 1.6;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( Bot101CrescentEmitter ){
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 60;
   velocityVariance = 5.0;
   ejectionOffset   = 0.0;
   thetaMin         = 80;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 200;
   particles = "Bot101CrescentParticle";
};

datablock ParticleData(Bot101Dust){
   dragCoefficient      = 1.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = true;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   textureName          = "particleTest";
   colors[0]     = "0.1 0.1 0.1 1.0";
   colors[1]     = "0.1 0.1 0.1 1.0";
   colors[2]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 3.2;
   sizes[1]      = 4.6;
   sizes[2]      = 5.0;
   times[0]      = 0.0;
   times[1]      = 0.7;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(Bot101DustEmitter){
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 15.0;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 80;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   lifetimeMS       = 250;
   particles = "Bot101Dust";
};


datablock ParticleData(Bot101ExplosionSmoke){
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 2250;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "0.1 0.1 0.1 1.0";
   colors[1]     = "0.1 0.1 0.1 0.5";
   colors[2]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 6.0;
   sizes[2]      = 2.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(Bot101ExplosionSmokeEmitter){
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionVelocity = 10.25;
   velocityVariance = 0.25;

   thetaMin         = 80.0;
   thetaMax         = 80.0;

   lifetimeMS       = 2500;

   particles = "Bot101ExplosionSmoke";
};

datablock ExplosionData(Bot101Explosion){
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = FusionExpSound;

   faceViewer           = true;
   explosionScale = "4 4 4";
   delayMS = 0;
   playSpeed = 0.7;
   
   emitter[0] = Bot101DustEmitter;
   emitter[1] = Bot101ExplosionSmokeEmitter;
   emitter[2] = Bot101CrescentEmitter;
   
   //sizes[0] = "4.0 4.0 4.0";
   //sizes[1] = "4.0 4.0 4.0";
   //times[0] = 0.0;
   //times[1] = 1.0;
   
   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;
};

datablock ParticleData(bot1SmokeParticle){
   dragCoefficient = 0;
   gravityCoefficient = -0.3;
   windCoefficient = 0;
   inheritedVelFactor = 0.125;
   constantAcceleration = 0;
   lifetimeMS = 3200;
   lifetimeVarianceMS = 200;
   useInvAlpha = 1;
   spinRandomMin = -100;
   spinRandomMax = 100;

   animateTexture = false;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.0 0.0 0.0 0.5";
   colors[1]     = "0.0 0.0 0.0 0.8";
   colors[2]     = "0.0 0.0 0.0 0.2";
   sizes[0]      = 1.0;
   sizes[1]      = 2.0;
   sizes[2]      = 4.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(bot1SmokeEmitter){
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 1;
   velocityVariance = 0.55;
   ejectionOffset =   2;
   thetaMin = 90;
   thetaMax = 90;
   phiReferenceVel = 360;
   phiVariance = 0;
   orientParticles= 0;
   orientOnVelocity = 1;

   particles = "bot1SmokeParticle";
};

datablock ParticleData(bot2SmokeParticle){
   dragCoefficient = 0;
   gravityCoefficient = 0.0;
   windCoefficient = 0;
   inheritedVelFactor = 0.125;
   constantAcceleration = 0;
   lifetimeMS = 3200;
   lifetimeVarianceMS = 200;
   useInvAlpha = 1;
   spinRandomMin = -100;
   spinRandomMax = 100;

   animateTexture = false;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.0 0.0 0.0 0.5";
   colors[1]     = "0.0 0.0 0.0 0.8";
   colors[2]     = "0.0 0.0 0.0 0.2";
   sizes[0]      = 1.0;
   sizes[1]      = 1.0;
   sizes[2]      = 1.0;
   times[0]      = 1.0;
   times[1]      = 1.0;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(bot2SmokeEmitter){
    ejectionPeriodMS = 5;
    periodVarianceMS = 0;
    ejectionVelocity = 1;
    velocityVariance = 0.55;
    ejectionOffset =   2;
    thetaMin = 90;
    thetaMax = 90;
    phiReferenceVel = 360;
    phiVariance = 0;
    //overrideAdvances = ;
    orientParticles= 0;
    orientOnVelocity = 1;

   particles = "bot2SmokeParticle";
};

datablock LinearFlareProjectileData(Bot101Shot){
   projectileShapeName = "plasmabolt.dts";
   scale               = "2.3 2.3 2.3";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.45;
   damageRadius        = 10;
   kickBackStrength    = 3000.0;
   radiusDamageType    = $DamageType::Dark;
   Impulse = true;
   explosion           = "Bot101Explosion";
   //splash              = PlasmaSplash;
    baseEmitter         = bot1SmokeEmitter;

   dryVelocity       = 100.0;
   wetVelocity       = 100.0;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 4000;
   lifetimeMS        = 5000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.9;
   size[1]           = 1.0;
   size[2]           = 0.1;


   numFlares         = 35;
   flareColor        = "1 0.75 0.25";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
};

datablock ShapeBaseImageData(Bot101Image){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = Bot101;
   ammo = DarkAmmo;
   offset = "0 0 0";
   
   projectile = Bot101Shot;
   projectileType = LinearFlareProjectile;
   //armThread = looksn;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = MotionSensorDeploySound;

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
   //stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFireMod";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = MILFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.6;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
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

datablock ShapeBaseImageData(Bot1012Image){
   offset = "0.005 1.2 0.13";
   rotation = "0 1 0 0";
   shapeFile = "pack_deploy_sensor_pulse.dts";
   emap = true;
};

datablock ShapeBaseImageData(Bot1013Image){
   offset = "0.005 1.0 0.13";
   shapeFile = "pack_deploy_sensor_pulse.dts";
   emap = true;
};

datablock ShapeBaseImageData(Bot1014Image){
   offset = "0.005 0.6 0.18";
   rotation = "1 0 0 90";
   shapeFile = "pack_upgrade_cloaking.dts";
   emap = true;
};

function Bot101Image::onMount(%this,%obj,%slot){
     Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(Bot1012Image, 4);
   %obj.mountImage(Bot1013Image, 5);
   %obj.mountImage(Bot1014Image, 6);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}


function Bot101Image::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %this.dwUnMount(%obj, %slot);
}

function Bot101Shot::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

$darkWep[5,3] = "BMortar" TAB 10;

datablock ItemData(BMortar){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = BMortarImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";

   computeCRC = false;
   emap = true;
   
   wepClass = "DKM";
   wepNameID = "DKM-0011";
   wepName = "DKM Crusher";
   light = 0;
   medium = 0;
   heavy = 20;
   description = "A mortar-type weapon that has a lower range than traditional mortars but deals more damage.";
};

datablock ShockwaveData(BMortarShockwave){ 
   width = 6.0;
   numSegments = 32;
   numVertSegments = 6;
   velocity = 15;
   acceleration = 20.0;
   lifetimeMS = 500;
   height = 1.0;
   verticalCurve = 0.5;
   is2D = false;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.9 0.3 0.0 0.50";
   colors[1] = "0.9 0.3 0.0 0.25";
   colors[2] = "0.9 0.3 0.0 0.0";

   mapToTerrain = true;
   orientToNormal = false;
   renderBottom = false;
};

datablock ParticleData( BMortarCrescentParticle ){
   dragCoefficient      = 2;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 000;
   textureName          = "special/crescent3";
   colors[0]     = "0.9 0.3 0.0 1.0";
   colors[1]     = "0.9 0.3 0.0 0.5";
   colors[2]     = "0.9 0.3 0.0 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 1.0;
   sizes[2]      = 1.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( BMortarCrescentEmitter ){
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 40;
   velocityVariance = 5.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 400;
   particles = "BMortarCrescentParticle";
};


datablock ParticleData(BMortarExplosionSmoke){
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.30;   
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 500;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.0 0.0 0.0 0.0";
   colors[1]     = "0.0 0.0 0.0 0.5";
   colors[2]     = "0.0 0.0 0.0 0.5";
   colors[3]     = "0.0 0.0 0.0 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 3.0;
   sizes[2]      = 4.0;
   sizes[3]      = 5.0;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;



};

datablock ParticleEmitterData(BMortarExplosionSmokeEmitter){
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionOffset = 2.0;


   ejectionVelocity = 1.25;
   velocityVariance = 1.2;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   lifetimeMS       = 500;

   particles = "BMortarExplosionSmoke";

};


datablock ExplosionData(BMortarExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;

   delayMS = 100;

   offset = 0.0;

   playSpeed = 1.5;

   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.0;

   soundProfile   = MortarExplosionSound;

   shockwave = BMortarShockwave;
   shockwaveOnTerrain = true;


   emitter[0] = BMortarExplosionSmokeEmitter;
   emitter[1] = BMortarCrescentEmitter;

   shakeCamera = false;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 3.3;
   camShakeRadius = 45.0;
};

datablock ParticleData(BMortarSmokeParticle){
     dragCoefficient = 0;
    gravityCoefficient = -0.3;
    windCoefficient = 1;
    inheritedVelFactor = 0.125;
    constantAcceleration = 0;
    lifetimeMS = 500;
    lifetimeVarianceMS = 200;
    useInvAlpha = 1;
    spinRandomMin = -100;
    spinRandomMax = 100;

   animateTexture = false;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.0 0.0 0.0 0.5";
   colors[1]     = "0.0 0.0 0.0 0.8";
   colors[2]     = "0.0 0.0 0.0 0.2";
   sizes[0]      = 0.2;
   sizes[1]      = 0.5;
   sizes[2]      = 1.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};


datablock ParticleEmitterData(BMortarSmokeEmitter){
    ejectionPeriodMS = 1;
    periodVarianceMS = 0;
    ejectionVelocity = 1;
    velocityVariance = 0.55;
    ejectionOffset =   0.5;
    thetaMin = 10;
    thetaMax = 10;
    phiReferenceVel = 360;
    phiVariance = 0;
    orientParticles= 0;
    orientOnVelocity = 1;

   particles = "BMortarSmokeParticle";
};

datablock GrenadeProjectileData(BMortarShot){
   projectileShapeName = "mortar_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0;
   hasDamageRadius     = true;
   indirectDamage      = 0.5;
   damageRadius        = 1.0;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 2500;

   explosion           = "BMortarExplosion";
   underwaterExplosion = "UnderwaterMortarExplosion";
   velInheritFactor    = 0.5;
   splash              = MortarSplash;
   depthTolerance      = 10.0; // depth at which it uses underwater explosion

   baseEmitter         = BMortarSmokeEmitter;
   bubbleEmitter       = MortarBubbleEmitter;

   grenadeElasticity = 0.15;
   grenadeFriction   = 0.4;
   armingDelayMS     = 512;
   muzzleVelocity    = 62;   // was 63.7 lowered to help with bot aiming
   drag              = 0.1;
   gravityMod        = 1.1;
   
   sound			 = MortarProjectileSound;

   hasLight    = true;
   lightRadius = 4.0;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";

};

datablock ShapeBaseImageData(BMortarImage){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = BMortar;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;
   
   projectile = BMortarShot;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.4;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFireMod";
   stateSound[3] = GrenadeFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = GrenadeReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function BMortarImage::onFireMod(%data, %obj, %slot){
   parent::onFireMod(%data, %obj, %slot);
}

function BMortarImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function BMortarImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %this.dwUnMount(%obj, %slot);
}

function BMortarShot::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
   arkLink(%pos, %proj.sourceObject,  %proj, %data);
}

datablock ShockLanceProjectileData(fireBeamShock){
   directDamage        = 0.20;
   radiusDamageType    = $DamageType::dark;
   kickBackStrength    = 2500;
   velInheritFactor    = 0;
   sound               = "";

   zapDuration = 1.0;
   impulse = 2500;
   boltLength = 50; 
   extension = 50; 
   lightningFreq = 25.0;
   lightningDensity = 3.0;
   lightningAmp = 0.25;
   lightningWidth = 0.05;

   shockwave = ShocklanceHit;
   							 
   boltSpeed[0] = 2.0;
   boltSpeed[1] = -0.5;

   texWrap[0] = 1.5;
   texWrap[1] = 1.5;

   startWidth[0] = 0.3;
   endWidth[0] = 0.6;
   startWidth[1] = 0.3;
   endWidth[1] = 0.6;
   
   texture[0] = "special/shockLightning01";
   texture[1] = "special/shockLightning02";
   texture[2] = "special/shockLightning03";
   texture[3] = "special/sniper00";

   emitter[0] = ShockParticleEmitter;
};



function arkLink(%pos, %sobj, %proj, %data){
   %damageMasks = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType |
                  $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
                  $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;

   %everythingElseMask = $TypeMasks::TerrainObjectType |
                         $TypeMasks::InteriorObjectType |
                         $TypeMasks::ForceFieldObjectType |
                         $TypeMasks::StaticObjectType |
                         $TypeMasks::MoveableObjectType |
                         $TypeMasks::DamagableItemObjectType;
      initContainerRadiusSearch( %pos, 15, %damageMasks);
      while ( (%targetObj = containerSearchNext()) != 0 ){
            %endPos = %targetObj.getWorldBoxCenter();
            %ray = containerRayCast(%pos, %endPos, %everythingElseMask, %sobj);
            if (!%ray){ 
               %vec = vectorNormalize(vectorSub(%endPos, %pos));
               %v = new ShockLanceProjectile() {
                  dataBlock        = fireBeamShock;
                  initialDirection = %vec;
                  initialPosition  = %pos;
                  sourceObject     = -1;
                  sourceSlot       = 0;
                  targetId         = %targetObj;
               }; 
               %data.schedule(32,"onExplodeMod",%proj, %endPos, %mod);
            }
      }
}
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[5,4] = "BFG" TAB 100;

datablock ItemData(BFG){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_plasma.dts";
   image = BFGImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";
	
	wepClass = "DKM";
   wepNameID = "DKM-1234";
   wepName = "Plasma Charge Cannon";
   light = 150;
   medium = 350;
   heavy = 500;
   description = "A weapon that fires plasma projectiles and can be charged to increase damage dealt.";
};



datablock ParticleData(BfgTrail){
   dragCoeffiecient     = 0;
   gravityCoefficient   = 0;
   windCoefficient 		= 0.0;
   inheritedVelFactor   = 0;

   lifetimeMS           = 100;
   lifetimeVarianceMS   = 5;


   useInvAlpha =  false;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/tracercross";

   colors[0]     = "0.15 0.85 0.15 0.0";
   colors[1]     = "0.15 0.85 0.15 0.05";
   colors[2]     = "0.15 0.85 0.15 0.05";
   colors[3]     = "0.15 0.85 0.15 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 2.0;
   sizes[2]      = 2.0;
   sizes[3]      = 2.5;
   times[0]      = 0.0;
   times[1]      = 0.25;
   times[2]      = 0.55;
   times[3]      = 1.0;

};

datablock ParticleEmitterData(BfgTrailEmitter){
   ejectionPeriodMS = 20;
   periodVarianceMS = 0;
   ejectionOffset   = 0.0;

   ejectionVelocity = 0.05;
   velocityVariance = 0;

   thetaMin         = 0.0;
   thetaMax         = 180;

   lifetimeMS       = 10000000;

   particles = "BfgTrail";
};

datablock ShockwaveData(BfgShockwave){
   width = 4.0;
   numSegments = 32;
   numVertSegments = 6;
   velocity = 35;
   acceleration = 0.0;
   lifetimeMS = 250;
   height = 1.0;
   verticalCurve = 0.5;
   is2D = false;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.3 1.0 0.3 0.30";
   colors[1] = "0.3 1.0 0.3 0.15";
   colors[2] = "0.3 1.0 0.3 0.0";

   mapToTerrain = false;
   orientToNormal = true;
   renderBottom = false;
};

datablock ParticleData(BfgSmokeParticle){
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.15;   
   inheritedVelFactor   = 0.125;

   lifetimeMS           =  1200;
   lifetimeVarianceMS   =  200;
   useInvAlpha          =  true;
   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   animateTexture = false;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.4 0.8 0.4 0.5";
   colors[1]     = "0.5 0.5 0.5 0.2";
   colors[2]     = "0.8 0.8 0.8 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 2.0;
   sizes[2]      = 2.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};


datablock ParticleEmitterData(BfgExplosionSmokeEmitter){
   ejectionPeriodMS = 20;
   periodVarianceMS = 0;

   ejectionVelocity = 1.25;
   velocityVariance = 0.55;
   ejectionOffset   = 2.0;

   thetaMin         = 0.0;
   thetaMax         = 180;

   particles = "BfgSmokeParticle";
   lifetimeMS           =  200;
};

datablock ParticleData(BfgResidueParticle){
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.01;   
   inheritedVelFactor   = 0.125;

   lifetimeMS           =  3000;
   lifetimeVarianceMS   =  200;
   useInvAlpha          =  false;
   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   animateTexture = false;

   textureName = "special/shrikeboltcross";

   colors[0]     = "0.0 0.8 0.0 0.0";
   colors[1]     = "0.0 0.8 0.0 0.03";
   colors[2]     = "0.0 0.8 0.0 0.0";
   sizes[0]      = 4.0;
   sizes[1]      = 7.0;
   sizes[2]      = 14.5;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(BfgResidueEmitter){
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 0.25;
   velocityVariance = 0.05;
   ejectionOffset   = 3;

   thetaMin         = 0.0;
   thetaMax         = 180;

   particles = "BfgResidueParticle";
   lifetimeMS           =  200;
};

datablock ExplosionData(BfgExplosion){
   soundProfile   = FusionExpSound;
   
   explosionShape = "mortar_explosion.dts";
   faceViewer           = true;
   playSpeed = 3.5;
   
   lifetimeMS = 1000;

   sizes[0] = "0.2 0.2 0.2";
   sizes[1] = "0.2 0.2 0.2";
   sizes[2] = "0.2 0.2 0.2";
   sizes[3] = "0.2 0.2 0.2";
   
   times[0] = 0.25;
   times[1] = 0.50;
   times[2] = 0.75;
   times[3] = 0.99;



   shockwave = BfgShockwave;
   shockwaveOnTerrain = false;
   
   emitter[0] = BfgExplosionSmokeEmitter;
   emitter[1] =	BfgResidueEmitter;
   
   shakeCamera = false;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "2.0 2.0 2.0";
   camShakeDuration = 0.5;
   camShakeRadius = 3.0;
};

datablock ParticleData(Bfg3Trail){
   dragCoeffiecient     = 0;
   gravityCoefficient   = 0;
   windCoefficient 		= 0.0;
   inheritedVelFactor   = 0;

   lifetimeMS           = 1500;
   lifetimeVarianceMS   = 500;


   useInvAlpha =  false;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/shrikeboltcross";

   colors[0]     = "0.25 0.85 0.25 0.0";
   colors[1]     = "0.25 0.85 0.25 0.02";
   colors[2]     = "0.25 0.85 0.25 0.01";
   colors[3]     = "0.25 0.85 0.25 0.0";
   sizes[0]      = 8.0;
   sizes[1]      = 6.0;
   sizes[2]      = 6.0;
   sizes[3]      = 6.5;
   times[0]      = 0.0;
   times[1]      = 0.25;
   times[2]      = 0.55;
   times[3]      = 1.0;

};

datablock ParticleEmitterData(Bfg3TrailEmitter){
   ejectionPeriodMS = 20;
   periodVarianceMS = 0;
   ejectionOffset   = 0.0;

   ejectionVelocity = 0.05;
   velocityVariance = 0;

   thetaMin         = 0.0;
   thetaMax         = 180;

   lifetimeMS       = 10000;

   particles = "Bfg3Trail";
};

datablock ShockwaveData(BfgShockwave3){
   width = 12.0;
   numSegments = 32;
   numVertSegments = 6;
   velocity = 35;
   acceleration = 60.0;
   lifetimeMS = 450;
   height = 1.0;
   verticalCurve = 0.5;
   is2D = false;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.3 1.0 0.3 0.80";
   colors[1] = "0.3 1.0 0.3 0.75";
   colors[2] = "0.3 1.0 0.3 0.0";

   mapToTerrain = false;
   orientToNormal = true;
   renderBottom = false;
};

datablock ParticleData(BfgSmokeParticle3){
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.15;   
   inheritedVelFactor   = 0.125;

   lifetimeMS           =  2200;
   lifetimeVarianceMS   =  700;
   useInvAlpha          =  true;
   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   animateTexture = false;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.4 0.8 0.4 1.0";
   colors[1]     = "0.5 0.5 0.5 0.2";
   colors[2]     = "0.8 0.8 0.8 0.0";
   sizes[0]      = 3.0;
   sizes[1]      = 7.0;
   sizes[2]      = 11.5;
   times[0]      = 0.0;
   times[1]      = 0.6;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(BfgExplosionSmokeEmitter3){
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;

   ejectionVelocity = 10.25;
   velocityVariance = 0.55;

   thetaMin         = 0.0;
   thetaMax         = 180;

   particles = "BfgSmokeParticle3";
   lifetimeMS           =  200;
};

datablock ParticleData(BfgResidueParticle3){
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.01;   
   inheritedVelFactor   = 0.125;
   windCoefficient 		= 0.0;

   lifetimeMS           =  12000;
   lifetimeVarianceMS   =  200;
   useInvAlpha          =  false;
   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   animateTexture = false;

   textureName = "special/shrikeboltcross";

   colors[0]     = "0.0 0.8 0.0 0.0";
   colors[1]     = "0.0 0.8 0.0 0.03";
   colors[2]     = "0.0 0.8 0.0 0.0";
   sizes[0]      = 7.0;
   sizes[1]      = 9.0;
   sizes[2]      = 16.5;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(BfgResidueEmitter3){
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;

   ejectionVelocity = 0.25;
   velocityVariance = 0.05;
   ejectionOffset   = 6;

   thetaMin         = 0.0;
   thetaMax         = 180;

   particles = "BfgResidueParticle3";
   lifetimeMS           =  200;
};

datablock ExplosionData(BfgExplosion3){
   explosionShape = "mortar_explosion.dts";
   soundProfile   = FusionExpSound;

   shockwave = BfgShockwave3;
   shockwaveOnTerrain = false;

   emitter[0] = BfgExplosionSmokeEmitter3;
   emitter[1] = BfgResidueEmitter3;
   
   faceViewer     = true;
   playSpeed = 0.6;
   explosionScale = "2 2 2";

   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 30.0;

   sizes[0] = "2.0 2.0 2.0";
   sizes[1] = "2.0 2.0 2.0";
   times[0] = 0.0;
   times[1] = 1.0;
};


datablock ParticleData(Bfg5Trail){
   dragCoeffiecient     = 0;
   gravityCoefficient   = 0;
   windCoefficient 		= 0.0;
   inheritedVelFactor   = 0;

   lifetimeMS           = 3500;
   lifetimeVarianceMS   = 0;


   useInvAlpha =  false;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/shrikeboltcross";

   colors[0]     = "0.25 0.85 0.25 0.0";
   colors[1]     = "0.25 0.85 0.25 0.1";
   colors[2]     = "0.25 0.85 0.25 0.05";
   colors[3]     = "0.25 0.85 0.25 0.0";
   sizes[0]      = 6.2;
   sizes[1]      = 4.4;
   sizes[2]      = 4.4;
   sizes[3]      = 0.0;
   times[0]      = 0.0;
   times[1]      = 0.1;
   times[2]      = 0.35;
   times[3]      = 1.0;

};

datablock ParticleEmitterData(Bfg5TrailEmitter){
   ejectionPeriodMS = 20;
   periodVarianceMS = 0;
   ejectionOffset   = 0.0;

   ejectionVelocity = 0.05;
   velocityVariance = 0;

   thetaMin         = 0.0;
   thetaMax         = 180;

   lifetimeMS       = 0;

   particles = "Bfg5Trail";
};

datablock ShockwaveData(BfgShockwave5){
   width = 24.0;
   numSegments = 32;
   numVertSegments = 24;
   velocity = 300;
   acceleration = -290.0;
   lifetimeMS = 1050;
   height = 7.0;
   verticalCurve = 3.5;
   is2D = false;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.3 1.0 0.3 0.80";
   colors[1] = "0.3 1.0 0.3 0.75";
   colors[2] = "0.3 1.0 0.3 0.0";

   mapToTerrain = false;
   orientToNormal = true;
   renderBottom = false;
};

datablock ParticleData(BfgSmokeParticle5){
   dragCoeffiecient     = 3.4;
   gravityCoefficient   = -0.15;   
   inheritedVelFactor   = 0.125;

   lifetimeMS           =  4200;
   lifetimeVarianceMS   =  700;
   useInvAlpha          =  true;
   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   animateTexture = false;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.4 0.8 0.4 1.0";
   colors[1]     = "0.5 0.5 0.5 0.2";
   colors[2]     = "0.8 0.8 0.8 0.0";
   sizes[0]      = 8.0;
   sizes[1]      = 12.0;
   sizes[2]      = 20.5;
   times[0]      = 0.0;
   times[1]      = 0.6;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(BfgExplosionSmokeEmitter5){
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;

   ejectionVelocity = 10.25;
   velocityVariance = 0.55;

   thetaMin         = 0.0;
   thetaMax         = 180;

   particles = "BfgSmokeParticle5";
   lifetimeMS           =  200;
};

datablock ParticleData(BfgResidueParticle5){
   dragCoefficient      = 2;
   windCoefficient      = 0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 000;
   textureName          = "special/crescent3";
   colors[0]     = "0.25 0.95 0.25 0.2";
   colors[1]     = "0.25 0.95 0.25 0.05";
   colors[2]     = "0.25 0.95 0.25 0";
   sizes[0]      = 5.5;
   sizes[1]      = 10.0;
   sizes[2]      = 15.6;
   times[0]      = 0.0;
   times[1]      = 0.6;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(BfgResidueEmitter5){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 60;
   velocityVariance = 0.0;
   ejectionOffset   = 2.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 40;
   particles = "BfgResidueParticle5";
};

datablock ExplosionData(BfgExplosion5){
   explosionShape = "mortar_explosion.dts";
   soundProfile   = FusionExpSound;

   shockwave = BfgShockwave5;
   shockwaveOnTerrain = false;

   emitter[0] = BfgExplosionSmokeEmitter5;
   emitter[1] = BfgResidueEmitter5;
   
   faceViewer     = true;
   explosionScale = "4.75 4.75 4.75";
   playSpeed = 0.2;
   
   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 30.0;

   sizes[0] = "4.0 4.0 4.0";
   sizes[1] = "4.0 4.0 4.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock LinearFlareProjectileData(BfgProjectile1){
   faceViewer          = true;
   emitterDelay        = -1;
   directDamage        = 0.00;
   hasDamageRadius     = true;
   indirectDamage      = 0.30;
   damageRadius        = 7.50;
   directDamageType    = $DamageType::Dark;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 200;  

   sound 				= discProjectileSound;
   explosion           = "BfgExplosion";
   underwaterExplosion = "UnderwaterMortarExplosion";
   splash              = DiscSplash;
   baseEmitter         = BfgTrailEmitter;

   dryVelocity       = 90; // z0dd - ZOD, 3/30/02. Slight Bfg speed up. was 90
   wetVelocity       = 50; // z0dd - ZOD, 3/30/02. Slight Bfg speed up. was 50
   velInheritFactor  = 0.75; 
   fizzleTimeMS      = 9000;
   lifetimeMS        = 9000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 500;

   size[0]           = 0.005;
   size[1]           = 0.005;
   size[2]           = 0.005;


   scale             = "1 1 1";
   numFlares         = 1;
   flareColor        = "0.05 0.75 0.05";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 1.5;
   lightColor  = "0.175 0.575 0.175";
};

datablock LinearFlareProjectileData(BfgProjectile3){
   faceViewer          = true;
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.50;
   damageRadius        = 13;
   directDamageType    = $DamageType::Dark;
   radiusDamageType    = $DamageType::Dark;
   kickBackStrength    = 2000;  

   sound 				= discProjectileSound;
   explosion           = "BfgExplosion3";
   underwaterExplosion = "UnderwaterMortarExplosion";
   splash              = DiscSplash;
   baseEmitter         = Bfg3TrailEmitter;

   dryVelocity       = 120; // z0dd - ZOD, 3/30/02. Slight Bfg speed up. was 90
   wetVelocity       = 45; // z0dd - ZOD, 3/30/02. Slight Bfg speed up. was 50
   velInheritFactor  = 0.75; 
   fizzleTimeMS      = 0;
   lifetimeMS        = 9000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 9000;

   size[0]           = 1.155;
   size[1]           = 1.155;
   size[2]           = 1.155;


   scale             = "4.0 4.0 4.0";
   numFlares         = 10;
   flareColor        = "0.35 0.75 0.35";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 8.5;
   lightColor  = "0.375 0.575 0.375";
};


datablock GrenadeProjectileData(BfgProjectile5){
   projectileShapeName = "plasmabolt.dts";
   faceViewer          = true;
   scale               = "8.0 8.0 8.0";
   emitterDelay        = -1;
   directDamage        = 0;
   hasDamageRadius     = true;
   indirectDamage      = 1.0;
   damageRadius        = 30.5; // z0dd - ZOD, 8/13/02. Was 20.0
   radiusDamageType    = $DamageType::Dark;
   directDamageType    = $DamageType::Dark;
   kickBackStrength    = 5200;

   explosion           = "BfgExplosion5";
   underwaterExplosion = "UnderwaterMortarExplosion";
   velInheritFactor    = 0.85;
   splash              = DiscSplash;
   baseEmitter         = Bfg5TrailEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   
   sound	     = MortarProjectileSound;

   hasLight    = true;
   lightRadius = 6.0;
   lightColor  = "0.05 0.8 0.05";
   
   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 1";
   
   grenadeElasticity = 0.30; // z0dd - ZOD, 9/13/02. Was 0.35
   grenadeFriction   = 0.2;
   armingDelayMS     = 650; // z0dd - ZOD, 9/13/02. Was 1000
   muzzleVelocity    = 75.00; // z0dd - ZOD, 3/30/02. GL projectile is faster. Was 47.00
   //drag = 0.1; // z0dd - ZOD, 3/30/02. No drag.
   gravityMod        = 1.9; // z0dd - ZOD, 5/18/02. Make GL projectile heavier, less floaty
};

datablock ShapeBaseImageData(BFGImage){
   className = WeaponImage;
   shapeFile = "weapon_plasma.dts";
   item = BFG;
   showname = "Bio Force Gun";
   ammo = DarkAmmo;
   offset = "0 0 0";
   
   projectile = BfgProjectile1;
   projectileType = LinearFlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Charge";

   stateName[3] = "Charge";
   stateTransitionOnNoAmmo[3] = "NoAmmo";
   stateTransitionOnTimeout[3] = "Charge";
   stateTimeoutValue[3] = 0.1;
   stateScript[3] = "onCharge";
   stateTransitionOnTriggerUp[3] = "CheckWet";

   stateName[4] = "Fire";
   stateTransitionOnTimeout[4] = "Reload";
   stateTimeoutValue[4] = 0.1;
   stateFire[4] = true;
   stateRecoil[4] = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4] = "onFireMod";
   stateEmitterTime[4] = 0.2;
   stateSound[4] = MBLFireSound;

   stateName[5] = "Reload";
   stateTransitionOnNoAmmo[5] = "NoAmmo";
   stateTransitionOnTimeout[5] = "Ready";
   stateTimeoutValue[5] = 0.6;
   stateAllowImageChange[5] = false;
   stateSequence[5] = "Reload";
   stateSound[5] = ShockLanceMissSound;

   stateName[6] = "NoAmmo";
   stateTransitionOnAmmo[6] = "Reload";
   stateSequence[6] = "NoAmmo";
   stateTransitionOnTriggerDown[6] = "DryFire";

   stateName[7]       = "DryFire";
   stateSound[7]      = BomberTurretDryFireSound;
   stateTimeoutValue[7]        = 1.5;
   stateTransitionOnTimeout[7] = "NoAmmo";

   stateName[8]       = "WetFire";
   stateSound[8]      = PlasmaFireWetSound;
   stateTimeoutValue[8]        = 1.5;
   stateTransitionOnTimeout[8] = "Ready";

   stateName[9]               = "CheckWet";
   stateTransitionOnWet[9]    = "WetFire";
   stateTransitionOnNotWet[9] = "Fire";
};

function BFGImage::onCharge(%data, %obj, %slot){
   %obj.cannonfire += 4;

   if ((%obj.cannonfire < 100)){
      %message = "Plasma Gun " @ %obj.cannonfire @ "\% Charged.";
      CommandToClient(%obj.client, 'BottomPrint', %message, 2, 1 );
   }
   else if (%obj.cannonfire > 99){
      %message = "Plasma Gun Fully Charged!";
      CommandToClient(%obj.client, 'BottomPrint', %message, 2, 1 );
   }
}

function BFGImage::onFireMod(%data, %obj, %slot){

   if ((%obj.cannonfire > 90)) {
      %datab = BfgProjectile5;
      %ammoloss = 100;
      %pType = "GrenadeProjectile";
   }
   else if ((%obj.cannonfire > 50)){
      %datab = BfgProjectile3;
      %ammoloss = 10;
      %pType = "LinearFlareProjectile";
   }
   else{
      %datab = BfgProjectile1;
      %ammoloss = 2;
      %pType = "LinearFlareProjectile";
   }

   %p = new (%pType)() {
      dataBlock        = %datab;
      initialDirection = %obj.getMuzzleVector(%slot);
      initialPosition  = %obj.getMuzzlePoint(%slot);
      sourceObject     = %obj;
      sourceSlot       = %slot;
      vehicleObject    = %vehicle;
   };

   if (isObject(%obj.lastProjectile) && %obj.deleteLastProjectile)
      %obj.lastProjectile.delete();

   %obj.lastProjectile = %p;
   %obj.deleteLastProjectile = %data.deleteLastProjectile;
   MissionCleanup.add(%p);

   // AI hook
   if(%obj.client)
      %obj.client.projectile = %p;

   %obj.decInventory(%data.ammo, %ammoloss);
   %obj.cannonfire = 0;
}

datablock ShapeBaseImageData(BFGImage2){
   offset = "-0.15 0.9 0.25";
   rotation = "0 0 1 90";
   shapeFile = "ammo_mortar.dts";
   emap = true;
};

datablock ShapeBaseImageData(BFGImage3){
   offset = "-0.15 0.6 0.25";
   rotation = "0 0 1 90";
   shapeFile = "ammo_mortar.dts";
   emap = true;
};

function BFGImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(BFGImage2, 4);
   %obj.mountImage(BFGImage3, 5);
   %obj.cannonfire = 0;
   %this.dwOnMount(%obj, %slot);
}

function BFGImage::onUnmount(%this, %obj, %slot){
   %obj.cannonfire = 0;
   Parent::onUnmount(%this,%obj,%slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %this.dwUnMount(%obj, %slot);
}

function BfgProjectile1::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
function BfgProjectile3::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}

function BfgProjectile5::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}


////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

$darkWep[5,5] = "DFlame" TAB 100;

datablock ItemData(DFlame){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_elf.dts";
   image = DFlameImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";
	
	wepClass = "DKM";
   wepNameID = "DKM-2221";
   wepName = "Plasma Thrower";
   light = 100;
   medium = 150;
   heavy = 200;
   description = "A weapon that fires a stream of superheated plasma, similar to a flamethrower.";
};

datablock ParticleData(DFlameExplosionParticle){
   dragCoefficient      = 2;
   gravityCoefficient   = 0.2;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 750;
   lifetimeVarianceMS   = 250;
   textureName          = "particleTest";
   colors[0]     = "0.9 0.3 0.0 1.0";
   colors[1]     = "0.9 0.3 0.0 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 4;
};

datablock ParticleEmitterData(DFlameExplosionEmitter){
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;
   ejectionVelocity = 5;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "DFlameExplosionParticle";
};

datablock ExplosionData(DFlameBoltExplosion){
   particleEmitter = DFlameExplosionEmitter;
   particleDensity = 150;
   particleRadius = 1.25;
   faceViewer = true;

   sizes[0] = "2.0 2.0 2.0";
   sizes[1] = "2.0 2.0 2.0";
   times[0] = 0.0;
   times[1] = 1.5;
};

datablock ParticleData(DFlameMuzzleParticle) {
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -2;
   inheritedVelFactor   = 0.125;

   lifetimeMS           =  150;
   lifetimeVarianceMS   =  50;
   useInvAlpha          =  false;
   spinRandomMin        = 0.0;
   spinRandomMax        =  100.0;

   textureName = "particleTest";


   colors[0]     = "0.0 0.0 1.0 0.5";
   colors[1]     = "0.0 0.0 1.0 0.8";
   colors[2]     = "0.0 0.0 1.0 0.5";
   colors[3]     = "1.0 0.2 0.0 0.5";

   sizes[0]      = 0.2;
   sizes[1]      = 0.3;
   sizes[2]      = 0.3;
   sizes[3]      = 0.3;

   times[0]      = 0.2;
   times[1]      = 0.5;
   times[2]      = 0.5;
   times[3]      = 0.7;
};

datablock ParticleEmitterData(DFlameMuzzleEmitter) {
   ejectionPeriodMS = 3;
   periodVarianceMS = 1;

   ejectionVelocity = 0.0;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 45.0;

   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;

   particles = "DFlameMuzzleParticle";
};


datablock ParticleData(DFlameBaseParticle){
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.2;
   inheritedVelFactor   = 0.00;

   lifetimeMS           = 1050;
   lifetimeVarianceMS   = 150;



   useInvAlpha = false;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;
   animateTexture = true;
   framesPerSec = 15;
   textureName          = "particleTest" ;
   colors[0]     = "0.9 0.2 0.0 1.0";
   colors[1]     = "0.9 0.2 0.0 1.0";
   colors[2]     = "0.9 0.2 0.0 0.0";

   sizes[0]      = 0.25;
   sizes[1]      = 1.0;
   sizes[2]      = 3.0;

   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(DFlameBaseEmitter){
   ejectionPeriodMS = 15;
   periodVarianceMS = 5;

   ejectionVelocity = 1.25;
   velocityVariance = 0.50;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   particles = "DFlameBaseParticle";
};

datablock ParticleData(DFlameRifleParticle){
   dragCoefficient      = 2.75;
   gravityCoefficient   = 0.1;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 550;
   lifetimeVarianceMS   = 0;
   textureName          = "particleTest";
   colors[0]     = "0.5 0.36 0.00 1.0";
   colors[1]     = "0.5 0.36 0.00 0.0";
   sizes[0]      = 0.25;
   sizes[1]      = 0.20;
};

datablock ParticleEmitterData(DFlameRifleEmitter){
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 10;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 12;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance  = true;
   particles = "DFlameRifleParticle";
};

datablock LinearFlareProjectileData(DFlameBolt){
   //projectileShapeName = "";
   scale               = "0.1 0.1 0.1";
   faceViewer          = false;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.15;
   damageRadius        = 7.0;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Dark;
   explosion           = "DFlameBoltExplosion";
   baseEmitter         = DFlameBaseEmitter;
   dryVelocity       = 55.0;
   wetVelocity       = -1;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 500;
   lifetimeMS        = 600;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.1;
   size[1]           = 0.1;
   size[2]           = 0.1;


   numFlares         = 35;
   flareColor        = "1 0.75 0.25";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

	sound        = PlasmaProjectileSound;
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;
   
   hasLight    = true;
   lightRadius = 1.0;
   lightColor  = "0.9 0.3 0.0";
};

datablock ShapeBaseImageData(DFlameImage){
   className = WeaponImage;
   shapeFile = "weapon_elf.dts";
   item = DFlame;
   ammo = DarkAmmo;
   offset = "0 0 0";
   
   projectile = DFlameBolt;
   projectileType = LinearFlareProjectile;
   
   projectileSpread = 40.0 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateEmitter[2] = "DFlameMuzzleEmitter";
   stateEmitterNode[2] = "muzzlepoint1";
   stateEmitterTime[2] = 10000;
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFireMod";
   //stateSound[3] = DFlameFireSound;
   stateEmitterTime[3] = 0.02;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.05;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = PlasmaReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = PlasmaDryFireSound;
   stateTimeoutValue[6]        = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7]       = "WetFire";
   stateSound[7]      = PlasmaFireWetSound;
   stateTimeoutValue[7]        = 1.0;
   stateTransitionOnTimeout[7] = "Ready";

   stateName[8]               = "CheckWet";
   stateTransitionOnWet[8]    = "WetFire";
   stateTransitionOnNotWet[8] = "Fire";
};

function DFlameImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function DFlameImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %this.dwUnMount(%obj, %slot);
}

function DFlameBolt::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal){
   parent::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal);
   //if(!%targetObject.isBurning)
      //burnObject(%targetObject, %projectile.sourceObject);
}
function DFlameBolt::onExplode(%data, %proj, %pos, %mod){
   %data.onExplodeMod(%proj, %pos, %mod);
}
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
function ShapeBaseImageData::onFireMod(%data, %obj, %slot)
{
   %obj.lfireTime[%data.getName()] = getSimTime();
   
   %data.lightStart = getSimTime();

   if( %obj.station $= "" && %obj.isCloaked() )
   {
      if( %obj.respawnCloakThread !$= "" )
      {
         Cancel(%obj.respawnCloakThread);
         %obj.setCloaked( false );
         %obj.respawnCloakThread = "";
      }
       else
      {
         // if( %obj.getEnergyLevel() > 20 )
         // {
         //    %obj.setCloaked( false );
         //    %obj.reCloak = %obj.schedule( 500, "setCloaked", true );
         // }

         //We check if the player is still cloaked now. So no need to limit to 20% energy for the cloak in/out animation
         %obj.setCloaked( false );
         %obj.reCloak = schedule( 500, 0, "checkCloakState", %obj);
      }  
   }
   if( %obj.client > 0 )
   {   
      %obj.setInvincibleMode(0 ,0.00);
      %obj.setInvincible( false ); // fire your weapon and your invincibility goes away.   
   }
   
   %vehicle = 0;
   if(%data.usesEnergy)
   {
      if(%data.useMountEnergy)
      {
         %useEnergyObj = %obj.getObjectMount();
         if(!%useEnergyObj)
            %useEnergyObj = %obj;
         %energy = %useEnergyObj.getEnergyLevel();
         %vehicle = %useEnergyObj;
      }
      else
         %energy = %obj.getEnergyLevel();
      
      if(%data.useCapacitor && %data.usesEnergy)
      {   
         if( %useEnergyObj.turretObject.getCapacitorLevel() < %data.minEnergy )
         {   
            return;
         }
      }
      else if(%energy < %data.minEnergy)
         return;
   }
   // ---------------------------------------------------------------------
   // z0dd - ZOD, 4/24/02. Code optimization
   if(%data.projectileSpread)
   {
      %vec = %obj.getMuzzleVector(%slot);
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %vector = MatrixMulVector(%mat, %vec);
   }
   else
   {
      // z0dd - ZOD, 4/10/02. Founder - fixes off center projectile drift.
      //%vector = %obj.getMuzzleVector(%slot);
      %vector = MatrixMulVector("0 0 0 0 0 1 0", %obj.getMuzzleVector(%slot));
   }

   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %vector;
      initialPosition  = %obj.getMuzzlePoint(%slot);
      sourceObject     = %obj;
      sourceSlot       = %slot;
      vehicleObject    = %vehicle;
   };
   // End streamlining
   // ---------------------------------------------------------------------
   if (isObject(%obj.lastProjectile) && %obj.deleteLastProjectile)
      %obj.lastProjectile.delete();

   %obj.lastProjectile = %p;
   %obj.deleteLastProjectile = %data.deleteLastProjectile;
   MissionCleanup.add(%p);
   
   // AI hook
   if(%obj.client)
      %obj.client.projectile = %p;

   if(%data.usesEnergy)
   {
      if(%data.useMountEnergy)
      {   
         if( %data.useCapacitor )
         {   
            %vehicle.turretObject.setCapacitorLevel( %vehicle.turretObject.getCapacitorLevel() - %data.fireEnergy );
         }
         else
            %useEnergyObj.setEnergyLevel(%energy - %fireEnergy);
      }
      else
         %obj.setEnergyLevel(%energy - %obj.client.fireEnergy);
   }
   else
      %obj.decInventory(%data.ammo,1);
   return %p;
}

function LerpClamped(%start, %end, %t){
    // clamp t between 0 and 1
    if (%t < 0)     %t = 0;
    else if (%t > 1) %t = 1;
    return %start + (%end - %start) * %t;
}

function ProjectileData::onExplodeMod(%data, %proj, %pos, %mod){
   if (%data.hasDamageRadius){
      RadiusExplosionMod(%proj, %pos, %data.damageRadius, %data.indirectDamage, %data.kickBackStrength, %proj.sourceObject, %data.radiusDamageType, %data);
   }
}

function RadiusExplosionMod(%explosionSource, %position, %radius, %damage, %impulse, %sourceObject, %damageType, %projData){
   %client = %sourceObject.client;
   %scale = ((%client.mod1 == 1) * 1) + ((%client.mod2 == 1) * 2)  + ((%client.mod3 == 1) * 4);
   %rngFactor = ((%client.mod1 == 5) * 1) + ((%client.mod2 == 5) * 2)  + ((%client.mod3 == 5) * 4);
   %dist = vectorDist(%explosionSource.initialPosition, %position);
   %distScale = 1 - (%dist / 300);
   %dmgFallOff = LerpClamped((%scale+7) / 14, 1, %distScale);
   %bonusDmg = ((%client.mod1 == 2) * (%damage * 0.1)) + ((%client.mod2 == 2) * (%damage * 0.2))  + ((%client.mod3 == 2) * (%damage * 0.4));
   %bonusAOE = ((%client.mod1 == 4) * mFloor(%radius * 0.1)) + ((%client.mod2 == 4) * mFloor( %radius * 0.2))  + ((%client.mod3 == 4) * mFloor(%radius * 0.35));

   %rngScale = %rngFactor / 7;
   %bonusDmg += ((%rngFactor > 1) * getRandom(0,1)) * (%damage  * (getRandom(LerpClamped(-40, 0, %rngScale),40)/100));
   %bonusAOE += ((%rngFactor > 2) * getRandom(0,1)) * (%radius * (getRandom(LerpClamped(-40, 0, %rngScale),40)/100));
   %dmgFallOff = (%rngFactor > 4) ? (getRandom(50,100)/100) : %dmgFallOff;
   InitContainerRadiusSearch(%position, %radius + %bonusAOE, $TypeMasks::PlayerObjectType      |
                                                 $TypeMasks::VehicleObjectType     |
                                                 $TypeMasks::StaticShapeObjectType |
                                                 $TypeMasks::TurretObjectType      |
                                                 $TypeMasks::ItemObjectType);

   %numTargets = 0;
   while ((%targetObject = containerSearchNext()) != 0)
   {
      %dist = containerSearchCurrRadDamageDist();

      if (%dist > %radius || (%sourceObject == %targetObject && %projData.blockSelfDamage))
         continue;

      // z0dd - ZOD, 5/18/03. Changed to stop Force Field console spam
      // if (%targetObject.isMounted())
      if (!(%targetObject.getType() & $TypeMasks::ForceFieldObjectType) && %targetObject.isMounted())
      {
         %mount = %targetObject.getObjectMount();
         %found = -1;
         for (%i = 0; %i < %mount.getDataBlock().numMountPoints; %i++)
         {
            if (%mount.getMountNodeObject(%i) == %targetObject)
            {
               %found = %i;
               break;
            }
         }
         if (%found != -1)
         {
            if (%mount.getDataBlock().isProtectedMountPoint[%found])
            {
               continue;
            }
         }
      }
      %targets[%numTargets]     = %targetObject;
      %targetDists[%numTargets] = %dist;
      %numTargets++;
   }

   for (%i = 0; %i < %numTargets; %i++)
   {
      %targetObject = %targets[%i];
      %dist = %targetDists[%i];
      if(isObject(%targetObject)) // z0dd - ZOD, 5/18/03 Console spam fix.
      {
         %coverage = calcExplosionCoverage(%position, %targetObject,
                                          ($TypeMasks::InteriorObjectType |
                                           $TypeMasks::TerrainObjectType |
                                           $TypeMasks::ForceFieldObjectType |
                                           $TypeMasks::VehicleObjectType));
         if (%coverage == 0)
            continue;

         %shieldDmg = %targetObject.isShielded  == 1 ? LerpClamped(0, 0.25, %scale/7) : 0;
         %damage += %bonusDmg;
         %damage *= %dmgFallOff;
         %amount = (1.0 - ((%dist / %radius) * 0.88)) * %coverage * (%damage + %shieldDmg);
      
         %data = %targetObject.getDataBlock();
         %className = %data.className;

         if (%impulse && %data.shouldApplyImpulse(%targetObject))
         {
            %p = %targetObject.getWorldBoxCenter();
            %momVec = VectorSub(%p, %position);
            %momVec = VectorNormalize(%momVec);
         
            if(%sourceObject == %targetObject)
            {
               if (%damageType == $DamageType::Disc)
               {
                  %impulse = 4475;
               }
               else if (%damageType == $DamageType::Mortar)
               {
            	%impulse = 5750;
               }
            }
            //------------------------------------------------------------------------------
         
            %impulseVec = VectorScale(%momVec, %impulse * (1.0 - (%dist / %radius)));
            %doImpulse = true;
         }
         else if( %className $= FlyingVehicleData || %className $= HoverVehicleData ) // Removed WheeledVehicleData. z0dd - ZOD, 4/24/02. Do not allow impulse applied to MPB, conc MPB bug fix.
         {
            %p = %targetObject.getWorldBoxCenter();
            %momVec = VectorSub(%p, %position);
            %momVec = VectorNormalize(%momVec);
            %impulseVec = VectorScale(%momVec, %impulse * (1.0 - (%dist / %radius)));
         
            if( getWord( %momVec, 2 ) < -0.5 )
               %momVec = "0 0 1";
            
            // Add obj's velocity into the momentum vector
            %velocity = %targetObject.getVelocity();
            //%momVec = VectorNormalize( vectorAdd( %momVec, %velocity) );
            %doImpulse = true;
         }
         else
         {   
            %momVec = "0 0 1";
            %doImpulse = false;
         }
      
         if(%amount > 0){
            if(%targetObject.getClassName() $= "Player"){
               %scale = (%rngFactor > 5) ?  getRandom(5,7) : %scale;
               if(%targetObject.getArmorSize() $= "light"){
                  %dmgScale = LerpClamped(0.9, 1.1, %scale/7); 
                  %amount *= %dmgScale;
               }
               else if(%targetObject.getArmorSize() $= "Medium") {
                  %dmgScale = LerpClamped(0.6, 0.8, %scale/7); 
                  %amount *= %dmgScale;
               }
               else if(%targetObject.getArmorSize() $= "Heavy") {
                  %dmgScale = LerpClamped(0.5, 0.7, %scale/7); 
                  %amount *= %dmgScale;
               }
               //error("total Damage" SPC %amount NL "damageScale" SPC %dmgScale SPC %scale NL "Aoe" SPC %bonusAOE NL "bonusDmg"  SPC %bonusDmg NL "dmgFallOff" SPC %dmgFallOff );
            }
            %data.damageObject(%targetObject, %sourceObject, %position, %amount, %damageType, %momVec, %explosionSource.theClient, %explosionSource);
         }
         if(  %projData.canConc && %data.getClassName() $= "PlayerData" ){
            %data.applyConcussion( %dist, %radius, %sourceObject, %targetObject );
            if(!$teamDamage && %sourceObject != %targetObject && %sourceObject.client.team == %targetObject.client.team)
            {
               messageClient(%targetObject.client, 'msgTeamConcussionGrenade', '\c1You were hit by %1\'s concussion', getTaggedString(%sourceObject.client.name));
            }
	      }
         //-------------------------------------------------------------------------------
         // z0dd - ZOD, 4/16/02. Tone done the how much bomber & HPC flip out when damaged
         if( %doImpulse )
         {
            %vehName = %targetObject.getDataBlock().getName();
            if ((%vehName $= "BomberFlyer") || (%vehName $= "HAPCFlyer"))
            {
              %bomberimp = VectorScale(%impulseVec, 0.6);
              %impulseVec = %bomberimp;
            }
            %targetObject.applyImpulse(%position, %impulseVec);
         }
         //if( %doImpulse )
         //   %targetObject.applyImpulse(%position, %impulseVec);
         //-------------------------------------------------------------------------------
      }
   }
}

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


// datablock StaticShapeData(faceBox){
//    catagory = "MISC";
//    shapeFile = "faceBox.dts";
//    alwaysAmbient = true;
//    isInvincible = true;
// };

datablock TriggerData(faceDeathTrigger){
   tickPeriodMS =  1000;
};

datablock StaticShapeData(weaponBuilder){
   catagory = "MISC";
   shapeFile = "buildStation.dts";
   alwaysAmbient = false;
   isInvincible = true;
};

datablock StaticShapeData(weaponBuilder)
{
   catagory = "Stations";
   shapeFile = "buildStation.dts";
   maxDamage = 4.00;
   destroyedLevel = 4.00;
   disabledLevel = 3.70;
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
   //humSound = StationInventoryHumSound;
   cmdCategory = "Support";
   cmdIcon = CMDStationIcon;
   cmdMiniIconName = "commander/MiniIcons/com_inventory_grey";
   targetNameTag = 'Inventory';
   targetTypeTag = 'Station';
   debrisShapeName = "debris_generic.dts";
   debris = StationDebris;

};

datablock TriggerData(BuildTrigger){
   tickPeriodMS = 32;
};

function weaponBuilder::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   %obj.init = 0;

   %trigger = new Trigger()
   { 
      dataBlock = BuildTrigger;
      polyhedron = "-0.5 0.5 -0.5 1.0 0.0 0.0 -0.0 -1.0 -0.0 -0.0 -0.0 1.0";
      scale = "1 4 1";
   };     
   %obj.pwrTrigger = %trigger;
   MissionCleanup.add(%trigger);

   %trans = %obj.getTransform();
   %vSPos = getWords(%trans,0,2);
   %vRot =  getWords(%trans,3,6);
   %trigger.setTransform(vectorAdd(%vSPos,"0 0 0.5") SPC %vRot); 

   // associate the trigger with the station
   %trigger.station = %obj;
   %obj.trigger = %trigger; 
   %obj.invincible = true;
}


function weaponBuilder::damageObject(%data, %targetObject, %sourceObject, %position, %amount, %damageType){
   if( %targetObject.invincible)
		return; 
   parent::damageObject(%data, %targetObject, %sourceObject, %position, %amount, %damageType);
}

function weaponBuilder::onRemove(%this, %obj){
   parent::onRemove(%this, %obj);
   if(isObject(%obj.trigger)){
      %obj.trigger.delete();
   }
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

function BuildTrigger::onleaveTrigger(%data, %trigger, %player){
   %station = %trigger.station;
   %targetname = %station.getDataBlock().getName(); 
   if(%player.team == %station.team && !%trigger.powerTrig){
      if(isObject(%station)){
         if(%targetname $= "weaponBuilder"){
            commandToClient(%player.client, 'BuildWep', 0);
            %player.client.wepStation = "";
         }
         else if(%targetname $= "T2AmmoDeployableObj"){
            %station.stopThread(2);
            %player.setRepairRate(0);
         }
      }
   }
   %trigger.lastObj = "";
}

function BuildTrigger::onTickTrigger(%data, %trig){
	return;
}

function serverCmdBuildWepSelect(%client, %t, %c, %m1, %m2, %m3){
   if(%t > 0 && %c > 0 && %m1 > 0 && %m2 > 0 && %m3 > 0){
      commandToClient(%client, 'EnableWepBuild', 1);
   }
}


function serverCmdStartWepBuild(%client, %t, %c, %m1, %m2, %m3){
   commandToClient(%client, 'BuildWep', 0);
   %weapon = getField($darkWep[%t, %c],0);
   %ammo = getField($darkWep[%t, %c],1);
   if(isObject(%weapon)){
      %client.mod1 = %m1;
      %client.mod2 = %m2;
      %client.mod3 = %m3;
      %client.wt = %t;
      %client.wc = %c;
      %station = %client.wepStation;
      if(%station.isDisabled()){
         messageClient(%client, 'msgStationDisabled', '\c2Station is disabled.');
         return;
      }
      else if(!%station.isPowered()){
         messageClient(%client, 'msgStationNoPower', '\c2Station is not powered.');
         return;
      }
      else if(%station.isDestroyed){
         messageClient(%client, 'msgStationDestroyed', '\c2Station is destroyed.');
         return;
      }
      if(%client.lastWepBuildMs && (getSimTime() - %client.lastWepBuildMs) < 8000){
         messageClient(%client, 'msgClient', '\c2Weapon build already in progress');
         return;
      }
      %client.lastWepBuildMs = getSimTime();
      if(%station.init){
         %station.setThreadDir(2, true);
      }
      else{
         %station.playThread(2, "activate");
         %station.init = 1;
      } 
      %station.playAudio(2, wepBuildClose); 
      schedule(3200,0,"buildWepEff", %station, %weapon);
      schedule(5000,0,"giveBuildWeapon", %client, %weapon, %ammo);
   }
   else{
      error("no weapon");
   }
}

function giveBuildWeapon(%client, %weapon, %ammo){
   if(isObject(%client.player)){
      if(isObject(%client.hasDrkWep) && %client.player.hasInventory(%client.hasDrkWep)){
         messageClient(%client, 'MsgClient', '\c0You already have a built weapon.~wfx/powered/station_denied.wav');
         return;
      }
      %client.hasDrkWep = %weapon;
      if(%client.mod3 == 5 && getRandom(1,100) == 100){
          %wep = getRandom(1,3);
         centerPrint(%client,"\n<color:ff0000><font:Arial:22>This experimental weapon has a large blast radius.", 5, 3);
         messageClient(%client, 'MsgClient', "~wfx/misc/warning_beep.wav");
         switch(%wep){
            case 1:
               %client.player.setInventory(ThetaStrike, 1, true);
               %client.player.setInventory(DarkAmmo, 2, true);
               %client.player.use(ThetaStrike); 
            case 2:
               %client.player.setInventory(StarNova, 1, true);
               %client.player.setInventory(DarkAmmo, 1, true);
               %client.player.use(StarNova); 
            case 3:
               %client.player.setInventory(ZapNukeGun, 1, true);
               %client.player.setInventory(DarkAmmo, 1, true);
               %client.player.use(ZapNukeGun); 
         }
      }
      else{
         %client.player.setInventory(%weapon,1,true);
         if(isObject(%weapon.image.ammo)){
            %bonusAmmo = ((%client.mod1 == 3) * mFloor(%ammo * 0.25)) + ((%client.mod2 == 3) * mFloor(%ammo * 0.5))  + ((%client.mod3 == 3) * mFloor(%ammo * 1));
            %bonusAmmo += ((%client.mod1 == 5) * getRandom(0,1)) * (%ammo  * getRandom());
            %client.player.setInventory("DarkAmmo", mFloor(%ammo + %bonusAmmo),true); 
         }
         else{
            %scale = ((%client.mod1 == 3) * 1) + ((%client.mod2 == 3) * 2)  + ((%client.mod3 == 3) * 4);
            %client.fireEnergy =  LerpClamped(%weapon.image.fireEnergy, 0, %scale / 7);
         }
         %client.player.use(%weapon); 
      }
   }
}

datablock AudioProfile(wepBuildOpen)
{
   filename    = "buildOpen.wav";
   description = AudioClosest3d;
   preload = true;
};
datablock AudioProfile(wepBuildClose)
{
   filename    = "buildClose.wav";
   description = AudioClosest3d;
   preload = true;
};

function buildWepEff(%station, %weapon){
   %station.setThreadDir(2, false);
   %station.playAudio(2, wepBuildOpen); 
   %time =  2000;

   %xForm = %station.getTransform();
   %pos = vectorAdd(getWords(%xform, 0, 2) ,"0 0 1.2");
   %newRot = MatrixMultiply(%pos SPC getWords(%xForm,3,6) , "0 0 0" SPC "0 0 1" SPC mDegToRad(90));
 
   %item = new Item() {
      position = "0 0 0";
      scale = "1 1 1";
      dataBlock = %weapon;
      lockCount = "0";
      homingCount = "0";
      collideable = "0";
      static = "1";
      rotate = "0";
   };

   MissionCleanup.add(%item);
   %item.setTransform(%newRot);

   %part =  new ParticleEmissionDummy() {
      position = %pos;
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = "doubleTimeEmissionDummy";
      lockCount = "0";
      homingCount = "0";
      emitter = "ELFSparksEmitter";
      velocity = "1";
   };
   MissionCleanup.add(%part);
   
   %part.schedule(%time-500,"delete");
   %item.schedule(%time,"delete");
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


datablock ItemData(ThetaStrike){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = ThetaStrikeImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a dark weapon";

   isEX = true; 
	
	wepClass = "EX";
   wepNameID = "TC-9001";
   wepName = "Theta Strike Cannon";
   light = 1;
   medium = 1;
   heavy = 1;
   description = "A super kinetic weapon that unleashes a devastating blast capable of killing all within its radius, regardless of cover";
};
 
datablock ParticleData(thetaSExplosionParticle) {//fire
   dragCoefficient = "9";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "3000";
   lifetimeVarianceMS = "0";
   spinSpeed = "0";
   spinRandomMin = "-360";
   spinRandomMax = "720";
   useInvAlpha = "0";
   textureName = "particleTest";
   colors[0] = "0.992 0.4 0 1";
   colors[1] = "0.992 0.301961 0.00784314 1";
   colors[2] = "0.996078 0.301961 0.00784314 0";
   colors[3] = "0.980392 0.301961 0.0156863 0";
   sizes[0] = "100";
   sizes[1] = "100";
   sizes[2] = "100";
   sizes[3] = "100";
   times[0] = "0";
   times[1] = "0.1";
   times[2] = "0.2";
   times[3] = "0.3";
};

datablock ParticleEmitterData(thetaSExplosionEmitter) {//fire
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "655.35";
   velocityVariance = "0";
   ejectionOffset = "20";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "180";
   phiReferenceVel = "0";
   phiVariance = "360";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "thetaSExplosionParticle";
   lifetimeMS = "500";
   lifetimeVarianceMS = "0";
   useInvAlpha = false;
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
};

datablock ParticleData(thetaSExplosionParticle2) {//smoke
   dragCoefficient = "7";
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
   colors[0] = "0.529412 0.533333 0.533333 0.295";
   colors[1] = "0.537 0.537 0.541 0.238";
   colors[2] = "0.568627 0.568627 0.564706 0.292";
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

datablock ParticleEmitterData(thetaSExplosionEmitter2) {//smoke
   ejectionPeriodMS = "2";
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
   particles = "thetaSExplosionParticle2";
   lifetimeMS = "1000";
   lifetimeVarianceMS = "0";
   
   
   blendStyle = "NORMAL";
   sortParticles = "1";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
};

datablock ParticleData(thetaSExplosionParticleS) {
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
   textureName = "particleTest";
   colors[0] = "0.984 0.992 0.992 0.1";
   colors[1] = "0.984 0.984 0.992 0.1";
   colors[2] = "0.996 0.996 0.992 0.1";
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

datablock ParticleEmitterData(thetaSExplosionEmitterS) { //wave
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
   particles = "thetaSExplosionParticleS";
   lifetimeMS = "150";
   lifetimeVarianceMS = "0";
   
   
   useInvAlpha = false;
   sortParticles = "1";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
};

datablock ExplosionData(thetaSStrikeExplosion2){
   emitter[0] = thetaSExplosionEmitterS;
   emitter[1] = thetaSExplosionEmitterS;
   emitter[2] = thetaSExplosionEmitterS;
   emitter[3] = thetaSExplosionEmitterS;
   emitter[4] = thetaSExplosionEmitterS;
};

datablock ExplosionData(thetaSStrikeExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = BombExplosionSound;
   faceViewer           = true;
   emitter[0] = thetaSExplosionEmitter;
   emitter[1] = thetaSExplosionEmitter2;
   subExplosion[0] = thetaSStrikeExplosion2;
   subExplosion[1] = thetaSStrikeExplosion2;
   subExplosion[2] = thetaSStrikeExplosion2;
   subExplosion[3] = thetaSStrikeExplosion2;
   subExplosion[4] = thetaSStrikeExplosion2;
   //emitter[2] = BlastRingEmitter;
   delayMS = 150;
   offset = 4.0;
   playSpeed = 0.8;

   sizes[0] = "70 70 70";
   sizes[1] = "70 70 70";
   times[0] = 0.0;
   times[1] = 1.0;
   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "10.0 10.0 10.0";
   camShakeDuration = 2;
   camShakeRadius = 300.0;
};  
       
datablock LinearFlareProjectileData(ThetaCShot){
   projectileShapeName = "plasmabolt.dts";
   scale               = "6 6 6";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 100;
   damageRadius        = 150;
   kickBackStrength    = 10000.0;
   radiusDamageType    = $DamageType::Dark;
   Impulse = true;
   explosion           = "thetaSStrikeExplosion";
   underwaterExplosion = "UnderwaterMortarExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 900.0;
   wetVelocity       =  600;
   velInheritFactor  = 1;
   fizzleTimeMS      = 5000;
   lifetimeMS        = 5000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 15.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 20.0; 
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 6;
   size[1]           = 6;
   size[2]           = 6;


   numFlares         = 35;
   flareColor        = "1 0.75 0.25";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
   ignoreExEffects = 1;
};


datablock ShapeBaseImageData(ThetaStrikeImage){
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = ThetaStrike;
   ammo = DarkAmmo;
   offset = "0 0 0";
   
   projectile = ThetaCShot;
   projectileType = LinearFlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = BomberBombDryFireSound;//ThetaStrikeSwitchSound;

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
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PlasmaBarrelExpSound;
   stateSequence[3] = "Fire";
   
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

datablock ShockwaveData(ProTrailShockwave){
   width = 32;
   numSegments = 20;
   numVertSegments = 2;
   velocity = 20;
   acceleration = 2;
   lifetimeMS = 500;
   height = 32;
   verticalCurve = 0.5;

   //mapToTerrain = false;
   //renderBottom = true;
   mapToTerrain = false;
   renderBottom = true;
   orientToNormal = true;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6;

   times[0] = 0;
   times[1] = 0.8;
   times[2] = 1;

   colors[0] = "1 0.1 0 1";
   colors[1] = "1 0.1 0 1";
   colors[2] = "1 0.1 0 1";
};

datablock AudioProfile(Weapon9ExpSound){
   filename = "fx/Bonuses/upward_straipass2_elevator.wav";
   description = AudioDefault3d;
   preload = true;
};

datablock ExplosionData(ProTrailExplosion){
   soundProfile = Weapon9ExpSound;
   faceViewer = true;
   shockwave = ProTrailShockwave;
};

datablock LinearProjectileData(shockwaveTrailProj){
   projectileShapeName = "weapon_chaingun_ammocasing.dts";
   emitterDelay = -1;
   directDamage = 0;
   hasDamageRadius = false;
   indirectDamage = 0;
   damageRadius = 3;
   radiusDamageType = $DamageType::Dark;
   kickBackStrength = 3000;
   mass = 10;
   explosion = "ProTrailExplosion";
   underwaterExplosion = "ProTrailExplosion";
   splash = ChaingunSplash;
   dryVelocity = 1;
   wetVelocity = 1;
   velInheritFactor = 0;
   fizzleTimeMS = 1;
   lifetimeMS = 32;
   explodeOnDeath = true;
   reflectOnWaterImpactAngle = 0;
   explodeOnWaterImpact = false;
   deflectionOnWaterImpact = 0;
   fizzleUnderwaterMS = 5000;
   activateDelayMS = -1;
   hasLight = true;
   lightRadius = 6;
   lightColor = "0.19 0.17 0.5";
   ignoreExEffects = 1;
};

function waveTrails(%obj, %data){
   if(isObject(%obj)){
      %p = new LinearProjectile(){
         datablock = %data;
         initialPosition = %obj.getPosition();
         initialDirection = %obj.initialDirection;
         sourceObject = -1;
         sourceSlot = 0;
         vehicleObject = 0;
      };
      MissionCleanup.add(%p);
      schedule(32,0, "waveTrails", %obj, %data);
   }
}

function ThetaCShot::onExplode(%data, %proj, %pos, %mod){
   parent::onExplode(%data, %proj, %pos, %mod);
   %damageMasks = $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType |
                  $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
                  $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;
   initContainerRadiusSearch(%pos, %data.damageRadius, %damageMasks );
   while ( (%targetObj = containerSearchNext()) != 0 ){
      %targetObj.schedule(32, "damage", %proj.sourceObject, %pos, 100, $DamageType::Dark);
   }
   
}

datablock ShapeBaseImageData(ThetaStrike2Image){
   offset = "0.005 1.0 0.13";
   rotation = "0 1 0 0";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;
};

datablock ShapeBaseImageData(ThetaStrike3Image){
   offset = "0.005 1.1 0.13";
   shapeFile = "pack_upgrade_cloaking.dts";
    emap = true;
};

datablock ShapeBaseImageData(ThetaStrike4Image){
   offset = "0.005 1.2 0.13";
   rotation = "0 1 0 0";
   shapeFile = "pack_upgrade_cloaking.dts";
};

datablock ShapeBaseImageData(ThetaStrike5Image){
   offset = "0.005 1.3 0.13";
   rotation = "0 1 0 0";
   shapeFile = "pack_upgrade_cloaking.dts";
};

function ThetaStrikeImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(ThetaStrike2Image, 4);
   %obj.mountImage(ThetaStrike3Image, 5);
   %obj.mountImage(ThetaStrike4Image, 6);
   %obj.mountImage(ThetaStrike5Image, 7);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function ThetaStrikeImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %obj.unmountImage(7);
   %this.dwUnMount(%obj, %slot);
}

function ThetaStrikeImage::onFire(%data, %obj, %slot){
   %p =  parent::onFire(%data, %obj, %slot);
   %obj.applyImpulse(%obj.getPosition(), VectorScale(%obj.getMuzzleVector(0), -4000));
   waveTrails(%p, shockwaveTrailProj);
}

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

datablock ItemData(StarNova){
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_plasma.dts";
   image = StarNovaImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false; 

   isEX = true; 

   wepClass = "EX";
   wepNameID = "ST-9600";
   wepName = "Star Nova";
   light = 1;
   medium = 1;
   heavy = 1;
   description = "A weapon that bursts open into a fractal tree shape, then at each of its end points starts targeting everything it can see."; 
};

datablock ParticleData(novaTrailParticle){
   dragCoefficient      = 1;
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0;
   constantAcceleration = 0;
   lifetimeMS           = 12000;
   lifetimeVarianceMS   = 0;
   windCoefficient   = 0.0;
   textureName          = "particleTest";
   useInvAlpha = 0;
   colors[0]     = "0 0.3 1.0 1";
   colors[1]     = "0 0.3 1.0 0";
   sizes[0]      = 0.5;
   sizes[1]      = 0.5;
   times[0] = 0.1;
   times[1] = 1.0;
};

datablock ParticleEmitterData(novaTrailEmitter){
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 0;
   velocityVariance = 0;
   ejectionOffset   = 0;
   thetaMin         = 0;
   thetaMax         = 0;
   phiReferenceVel  = 345;
   phiVariance      = 0;
   overrideAdvances = 0;
   orientParticles = 1;
   particles = novaTrailParticle;
};

datablock ParticleData(novaExplosionParticle){
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
   sizes[0]      = 1;
   sizes[1]      = 1;
};

datablock ParticleEmitterData(novaExplosionEmitter){
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
   particles = "novaExplosionParticle";
};

datablock ExplosionData(novaStarExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   particleEmitter = novaExplosionEmitter;
   particleDensity = 50;
   particleRadius = 10;
   faceViewer = true;
   
   colors[0] = "0.0 0.0 1.0 0.0";
   colors[1] = "0.0 0.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 0.4;
   sizes[0] = "1 1 1";
   sizes[1] = "1 1 1";
};

datablock ExplosionData(novaStarExplosion2){
   explosionShape = "disc_explosion.dts";
   faceViewer           = true;
   playSpeed = 0.9;

   sizes[0] = "7.0 7.0 7.0";
   sizes[1] = "10.0 10.0 10.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock LinearFlareProjectileData(StarNovaProj3){
   projectileShapeName = "";
   scale               = "1 1 1";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 5.0;
   damageRadius        = 100;
   kickBackStrength    = 6000.0;
   radiusDamageType    = $DamageType::Dark;

   explosion           = "novaStarExplosion2";
   
   baseEmitter = "novaTrailEmitter";

   dryVelocity       = 1.0;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 256;
   lifetimeMS        = 256;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = -1;

   size[0]           = 0.0;
   size[1]           = 0.0;
   size[2]           = 0.0;


   numFlares         = 0;
   flareColor        = "0.0 0.0 0.0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

	//sound        = PlasmaProjectileSound;
   //fireSound    = PlasmaFireSound;
   //wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
   ignoreExEffects = 1;
};

datablock LinearFlareProjectileData(StarNovaProj2){
   projectileShapeName = "";
   scale               = "1 1 1";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 1;
   kickBackStrength    = 6000.0;
   radiusDamageType    = $DamageType::Dark;

   explosion           = "novaStarExplosion";
   
   baseEmitter = "novaTrailEmitter";

   dryVelocity       = 95.0;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 500;
   lifetimeMS        = 500;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = -1;

   size[0]           = 0.0;
   size[1]           = 0.0;
   size[2]           = 0.0;


   numFlares         = 0;
   flareColor        = "0.0 0.0 0.0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

	//sound        = PlasmaProjectileSound;
   //fireSound    = PlasmaFireSound;
   //wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
   ignoreExEffects = 1;
};

datablock LinearFlareProjectileData(StarNovaProj){
   projectileShapeName = "";
   scale               = "1 1 1";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 1;
   kickBackStrength    = 6000.0;
   radiusDamageType    = $DamageType::Dark;

   //explosion           = "StarExplosion";
   
   baseEmitter = novaTrailEmitter;

   dryVelocity       = 95.0;
   wetVelocity       = -1;
   velInheritFactor  = 0.3;
   fizzleTimeMS      = 3100;
   lifetimeMS        = 3100;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = -1;

   size[0]           = 0.0;
   size[1]           = 0.0;
   size[2]           = 0.0;


   numFlares         = 0;
   flareColor        = "0.0 0.0 0.0";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   //sound        = PlasmaProjectileSound;
   //fireSound    = PlasmaFireSound;
   //wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "1 0.75 0.25";
   ignoreExEffects = 1;
};

datablock ShapeBaseImageData(StarNovaImage){
   className = WeaponImage;
   shapeFile = "weapon_plasma.dts";
   item = STBurstCannon0;
   ammo = DarkAmmo;
   offset = "0 0 0";
   projectile = StarNovaProj;
   projectileType = LinearFlareProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;
   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";
   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";
   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PlasmaFireSound;
   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.6;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
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

function StarNovaImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %this.dwOnMount(%obj, %slot);
}

function StarNovaImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %this.dwUnMount(%obj, %slot);
}

function StarNovaProj::onExplode(%data, %proj, %pos, %mod){
   parent::onExplode(%data, %proj, %pos, %mod);
   %burstCount = 1;
   %obj =  %proj.sourceObject;
   %obj.expDepth = 0;
   %obj.starlockout = 0;
   for(%i = 0; %i < %burstCount; %i++){
      %vector = "0 0 1";
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.1;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.1;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.1;
      %mat = MatrixCreateFromEuler(%x SPC %y SPC %z);
      %vector = MatrixMulVector(%mat, %vector);
      %p = new LinearFlareProjectile() 
      {
         dataBlock = StarNovaProj2;
         initialDirection = %vector;
         initialPosition  = %pos;
         sourceObject = -1;
         sourceSlot = 0;
         sObj =  %obj;
      };
      MissionCleanup.add(%p);
   }  
}

function starBoom(%obj,%pos){
         %vector = "0 0 -1";
         %p = new LinearFlareProjectile() 
         {
            dataBlock = StarNovaProj3;
            initialDirection = %vector;
            initialPosition  = %pos;
            sourceObject = -1;
            sourceSlot = 0;
            sObj = %obj;
         };
         MissionCleanup.add(%p);  
}

function startBoomDelay(%obj){
   for(%i = 1; %i <= %obj.expDepth; %i++){
      schedule(16*%i, 0, "starBoom", %obj, %obj.starPos[%i]);
   }    
   
}

function StarNovaProj2::onExplode(%data, %proj, %pos, %mod){
   %obj =  %proj.sObj;
   %proj.sourceObject = %obj;
   parent::onExplode(%data, %proj, %pos, %mod);
   %burstCount = 4;
   %obj.starPos[%obj.expDepth++] = %pos;
   if(%obj.expDepth > 100){
      //error(%obj.expDepth);
      if(!%obj.starlockout){
         schedule(2000, 0, "startBoomDelay", %obj); 
         %obj.starlockout = 1;
      }
      return;
   }
   else{
      for(%i = 0; %i < %burstCount; %i++){
         %vector = "0 0 1";
         %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5; 
         %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5;
         %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5;
         %mat = MatrixCreateFromEuler(%x SPC %y SPC %z);
         %vector = MatrixMulVector(%mat, %vector);
         %p = new LinearFlareProjectile() 
         {
            dataBlock = StarNovaProj2;
            initialDirection = %vector;
            initialPosition  = %pos;
            sourceObject = -1;
            sourceSlot = 0;
            sObj = %obj;
         };
         MissionCleanup.add(%p);
      }  
   }
}

datablock ShockwaveData(StarNovaBeamShockwave){
   width = 30;
   numSegments = 32;
   numVertSegments = 7;
   velocity = 40;
   acceleration = 10.0;
   lifetimeMS = 1000;
   height = 6;
   verticalCurve = 0.375;

   mapToTerrain = false;
   renderBottom = true;
   orientToNormal = true;

   texture[0] = "special/shockwave5";
   texture[1] = "special/gradient";
   texWrap = 3.0;

   times[0] = 1.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.0 0.3 0.9 1.0";
   colors[1] = "0.0 0.3 0.9 1.0";
   colors[2] = "0.0 0.0 1.0 0.0";
};

datablock ExplosionData(StarNovaBeamExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = PlasmaBarrelExpSound;
   shockwave      = StarNovaBeamShockwave;
   faceViewer     = true;
   sizes[0] = "4.0 4.0 4.0";
   sizes[1] = "4.0 4.0 4.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

datablock SniperProjectileData(StarNovaBeam){
   directDamage        = 10;
   hasDamageRadius     = false;
   indirectDamage      = 0.0;
   damageRadius        = 0.0;
   velInheritFactor    = 1.0;
   sound 			   = BlasterProjectileSound;
   explosion           = "StarNovaBeamExplosion";
   splash              = PlasmaSplash;
   directDamageType    = $DamageType::Dark;

   maxRifleRange       = 600;
   rifleHeadMultiplier = 1;   
   beamColor           = "0 0 1";
   fadeTime            = 2.0;

   startBeamWidth		  = 1.5;
   endBeamWidth 	     = 1.5;
   pulseBeamWidth 	  = 0.5;
   beamFlareAngle 	  = 30.0;
   minFlareSize        = 0.0;
   maxFlareSize        = 400.0;
   pulseSpeed          = 6.0;
   pulseLength         = 0.150;

   lightRadius         = 1.0;
   lightColor          = "0 0.0 1.0";

   textureName[0]      = "special/flare";
   textureName[1]      = "special/nonlingradient";
   textureName[2]      = "special/skyLightning";// special/laserrip01
   textureName[3]      = "special/skyLightning";
   textureName[4]      = "special/skyLightning";
   textureName[5]      = "special/skyLightning";
   textureName[6]      = "special/skyLightning";
   textureName[7]      = "special/skyLightning";
   textureName[8]      = "special/skyLightning";
   textureName[9]      = "special/skyLightning";
   textureName[10]     = "special/skyLightning";
   textureName[11]     = "special/skyLightning";

};

function StarNovaBeam::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal){
   if(isObject(%targetObject)) {
      %targetObject.damage(%projectile.sObj, %position, %data.directDamage, %data.directDamageType);
   }
}

function StarNovaProj3::onExplode(%data, %proj, %pos, %mod){
   %obj =  %proj.sObj;
   %proj.sourceObject = %obj;
   parent::onExplode(%data, %proj, %pos, %mod);
   
   %damageMasks = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType |
                  $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
                  $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;
   %found = 0;
   initContainerRadiusSearch( %pos, 500, %damageMasks );
   while ( (%targetObj = containerSearchNext()) != 0 ){
      %endPos = %targetObj.getWorldBoxCenter();
      if(getSimTime() - %targetObj.lastNovaHit > 2000 || !%targetObj.lastNovaHit){
         %targetObj.lastNovaHit = getSimTime();
         %p = new SniperProjectile() {
            dataBlock        = StarNovaBeam;
            initialDirection = vectorNormalize(vectorSub(%endPos,%pos));
            initialPosition  = %pos;
            sourceObject     = -1;
            damageFactor     = 2;
            sourceSlot       = "";
            sObj = %obj;
         };
         %p.setEnergyPercentage(1);
         MissionCleanup.add(%p);
         %found =1;
         break;
      }
   }
   if(!%found){
      %vector = "0 0 -1";
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5; 
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.5;
      %mat = MatrixCreateFromEuler(%x SPC %y SPC %z);
      %vector = MatrixMulVector(%mat, %vector);
      %p = new SniperProjectile() {
         dataBlock        = StarNovaBeam;
         initialDirection = %vector;
         initialPosition  = %pos;
         sourceObject     = -1;
         damageFactor     = 2;
         sourceSlot       = "";
         sObj = %obj;
      };
      %p.setEnergyPercentage(1);
      MissionCleanup.add(%p);
   }
}
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

datablock ItemData(ZapNukeGun){
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_elf.dts";
   image        = ZapLauncherImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName = "a dark weapon";
   computeCRC = false;
   emap = true;

   isEX = true;   

   wepClass = "EX";
   wepNameID = "EW-9524";
   wepName = "Electrical Nuke";
   light = 1;
   medium = 1;
   heavy = 1;
   description = "A devastating weapon that creates an electrical storm that culminates in a massive power surge";
};

datablock ShapeBaseImageData(ZapLauncherImage)
{
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = ZapNukeGun;
   ammo = DarkAmmo;
   offset = "0 0 0";
   emap = true;

   projectile = BasicGrenade;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.4;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFire";
   stateSound[3] = LightningZapSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   //stateSound[4] = GrenadeReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ParticleData(ENChargedProj){
   dragCoefficient      = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 0;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 50.0;
   textureName          = "special/lightning1frame1";
   colors[0]     = "0.0 0.3 0.9 1.0";
   colors[1]     = "0.0 0.3 0.9 1.0";
   colors[2]     = "0.0 0.3 0.9 0.0";
   sizes[0]      = 0.2;
   sizes[1]      = 20.6;
   sizes[2]      = 30.0;
   times[0]      = 0.0;
   times[1]      = 0.7;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(ENChargedProjEmitter){
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 0.0;
   velocityVariance = 0.0;
   ejectionOffset   = 300.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = false;
   lifetimeMS       = 1000;
   particles = "ENChargedProj";
};

datablock ShockwaveData(ENShockwave){
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
datablock ExplosionData(ENBoltExplosion){
   explosionShape = "effect_plasma_explosion.dts";
   soundProfile   = MissileExplosionSound;
   emitter[0] = ENChargedProjEmitter;
   emitter[1] = ENChargedProjEmitter;

   shockwave      = ENShockwave;
   faceViewer = true;
   
   times[0] = 0.0;
   times[1] = 0.4;
   sizes[0] = "2.0 2.0 2.0";
   sizes[1] = "2.0 2.0 2.0";
   
   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "10.0 10.0 10.0";
   camShakeDuration = 2;
   camShakeRadius = 800.0;

};
datablock LinearFlareProjectileData(ENStrikeProj){
   projectileShapeName = "plasmabolt.dts";
   scale               = "1 1 1";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 50;
   damageRadius        = 5;
   kickBackStrength    = 0.0;
   directDamageType    = $DamageType::Dark;
   radiusDamageType    = $DamageType::Dark;
   Impulse = true;
   explosion           = "ENBoltExplosion";

   dryVelocity       = 800;
   wetVelocity       = 800;
   velInheritFactor  = 0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = -1;

   size[0]           = 20.0;
   size[1]           = 20.5;
   size[2]           = 80.0;


   numFlares         = 100;
   flareColor        = "0 0.5 1";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "0 0 1";
   ignoreExEffects = 1;
};
datablock ShapeBaseImageData(ZapLauncherImage2){

   offset = "0.0 0.6 0.1";
   rotation = "1 0 0 90";
   shapeFile = "pack_upgrade_energy.dts";
    emap = true;

};

datablock ShapeBaseImageData(ZapLauncherImage3){
   offset = "0.00 0.5 0.1";
    rotation = "1 0 0 90";
   shapeFile = "pack_upgrade_energy.dts";
    emap = true;
};

datablock ShapeBaseImageData(ZapLauncherImage4){
   offset = "0.0 0.4 0.1";
    rotation = "1 0 0 90";
   shapeFile = "pack_upgrade_energy.dts";
    emap = true;
};

function ZapLauncherImage::onMount(%this,%obj,%slot){
   Parent::onMount(%this,%obj,%slot);
   commandToClient( %obj.client, 'BottomPrint', %this.item.wepNameID SPC %this.item.wepName NL %this.item.description, 4, 3);
   %obj.mountImage(ZapLauncherImage2, 4); 
   %obj.mountImage(ZapLauncherImage3, 5); 
   %obj.mountImage(ZapLauncherImage4, 6); 
   %this.dwOnMount(%obj, %slot);
}

function ZapLauncherImage::onUnmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %this.dwUnMount(%obj, %slot);
}

function ZapLauncherImage::onFire(%data,%obj,%slot){
   %muzzlePos = %obj.getMuzzlePoint(%slot);
   %muzzleVec = %obj.getMuzzleVector(%slot);
   %endPos    = VectorAdd(%muzzlePos, VectorScale(%muzzleVec, 500));
   %mask = $TypeMasks::StaticShapeObjectType | 
   $TypeMasks::InteriorObjectType | 
   $TypeMasks::TerrainObjectType;
   
   %hit = ContainerRayCast(%muzzlePos, %endPos, %mask, %obj);
   if(%hit){  
      zapGun(1000, 0, getWords(%hit,1,3), %obj.client);
      %obj.decInventory(%data.ammo, 1);
   }
   else{
      messageClient(%obj.client, 'MsgClient', "~wfx/misc/warning_beep.wav");
       commandToClient( %obj.client, 'BottomPrint', "Invalid target or too far way, 500m range", 3, 1); 
   }
}
function zapGun(%count, %srCount, %pos, %client){
   %count -= 20;
   if(%count < 1)
      %count = 5;
   %srCount += 10;
   %var = new Lightning() {
		position = %pos;
		rotation = "1 0 0 0";
		scale =  %count SPC %count SPC 1000;
		dataBlock = "DefaultStorm";
		strikesPerMinute = %srCount;
		strikeWidth = "2.5";
		chanceToHitTarget = "0";
		strikeRadius = "1";
		boltStartRadius = "10";
		color = "1.0 1.0 1.0 1.0";
		fadeColor = "0.3 0.3 1.0 1.0";
		useFog = "1";
	};
   MissionCleanup.add(%var);
   %var.schedule(2000, "delete");
   %damageMasks = $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType |
               $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
               $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;            
   initContainerRadiusSearch(%pos, mFloor(%count/2), %damageMasks );
   while ( (%targetObject = containerSearchNext()) != 0 ){ 
      if(%targetObject != %client.player){
         %mask = $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | 
         $TypeMasks::TerrainObjectType | $TypeMasks::ForceFieldObjectType;
         %tgPos = %targetObject.getPosition();    
         %hit = ContainerRayCast(vectorAdd(%tgPos,"0 0 1000"), %tgPos, %mask, %targetObject);
         if(!%hit){
            %zap = new Lightning(){
               position = %tgPos;
               rotation = "1 0 0 0";
               scale = "1 1 1000";
               dataBlock = "DefaultStorm";
               lockCount = "0";
               homingCount = "0";
               strikesPerMinute = "60";
               strikeWidth = "2.5";
               chanceToHitTarget = "1";
               strikeRadius = "10";
               boltStartRadius = "70"; //altitude the lightning starts from
               color = "0.000000 0.100000 1.000000 1.000000";
               fadeColor = "0.100000 0.100000 1.000000 1.000000";
               useFog = "1";
               shouldCloak = 0;
            };
            MissionCleanup.add(%zap);
            %zap.schedule(2000,"delete");
            %targetObject.damage(%client.player, %tgPos, 20, $DamageType::Dark);
         }
      }
   }
	if(%count > 20){
	   schedule(256, 0, "zapGun", %count, %srCount, %pos, %client);
	}
	else{
      schedule(512, 0, "enStart", %pos, %client);
	}
}


function enStart(%pos, %client){
   %damageMasks = $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType |
                  $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
                  $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;            
   initContainerRadiusSearch(vectorAdd(%pos,"0 0 1"), 500, %damageMasks );
   while ( (%targetObject = containerSearchNext()) != 0 ){ 
      //schedule(126,0, "powerSurge", %targetObject, %pos, %client.player);
      schedule(126,0, "cycleMeltDown", %targetObject, %pos, %proj, %client.player);
   }
   
   for (%i = 0; %i < 3; %i++){
      %p = new LinearFlareProjectile() {
            dataBlock        = ENStrikeProj;
            initialDirection = "0 0 -1";
            initialPosition  = vectorAdd(%pos,"0 0 1000");
            sourceObject     =  %client.player;
            sourceSlot       = 0;
            vehicleObject    = 0;
            sObj = %sobj;
      };
      MissionCleanup.add(%p);
   } 
  %var = new Lightning() {
		position = %pos;
		rotation = "1 0 0 0";
		scale =  500 SPC 500 SPC 1000;
		dataBlock = "DefaultStorm";
		strikesPerMinute = 200;
		strikeWidth = "2.5";
		chanceToHitTarget = "1";
		strikeRadius = "500";
		boltStartRadius = "10";
		color = "1.0 1.0 1.0 1.0";
		fadeColor = "0.3 0.3 1.0 1.0";
		useFog = "1";
	};
   MissionCleanup.add(%var);
   %var.schedule(2000, "delete");
}

function ENStrikeProj::onExplode(%data, %proj, %pos, %mod){
   %proj.sourceObject = %proj.sObj;
   parent::onExplode(%data, %proj, %pos, %mod);
   expFlash(vectorAdd(%pos,"0 0 0.5"), 600, 0.7);
}

datablock LinearFlareProjectileData(MeltDownProj){
   projectileShapeName = "plasmabolt.dts";
   scale               = "1 1 1";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = false;
   indirectDamage      = 0.2;
   damageRadius        = 300;
   kickBackStrength    = 8000.0;
   radiusDamageType    = $DamageType::Dark;
   Impulse = true;
   explosion           = "SatchelMainExplosion";
   underwaterExplosion = "UnderwaterSatchelSubExplosion";
   splash              = PlasmaSplash;

   dryVelocity       = 500.0;
   wetVelocity       = 500;
   velInheritFactor  = 0.5;
   fizzleTimeMS      = 100;
   lifetimeMS        = 100;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.9;
   size[1]           = 10.0;
   size[2]           = 10.1;


   numFlares         = 55;
   flareColor        = "1 0.75 0.25";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

   hasLight    = true;
   lightRadius = 15.0;
   lightColor  = "1 0.75 0.25"; 
   ignoreExEffects = 1;
};


datablock ParticleData(MeltDownEmitterParticle){
   dragCoefficient      = 0.2;
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0;
   constantAcceleration = 0;
   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 500;
   spinRandomMin    = "-90";
   spinRandomMax    = "90";
   textureName          = "particleTest";
   colors[0]     = "0 0 1 0.6";
   colors[1]     = "0 0.2 1 0.3";
   colors[2]     = "0 0.2 1 0";
   sizes[0]      = 5.5;
   sizes[1]      = 10.8;
   sizes[2]      = 10.8;
   times[0]      = 0;
   times[1]      = 0.6;
   times[2]      = 1;
};

datablock ParticleEmitterData(MeltDownEmitter){
   ejectionPeriodMS = 45;
   periodVarianceMS = 0;
   ejectionVelocity = 4;
   velocityVariance = 3.9;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   orientParticles  = false;
   overrideAdvance = false;
   orientOnVelocity = 1;
   ambientFactor = "0.85";
   particles = "MeltDownEmitterParticle";
};

function cycleMeltDown(%targetObject, %pos, %proj, %sObj){
   if(%targetObject.getType() & $TypeMasks::GeneratorObjectType){
      %targetObject.damage(%sObj, %pos, 100, $DamageType::Dark);   
      %p = new LinearFlareProjectile() {
         dataBlock        = MeltDownProj;
         initialDirection = "0 0 1";
         initialPosition  = %targetObject.getWorldBoxCenter();
         sourceObject     = %sObj;
         sourceSlot       = 0;
      };
      MissionCleanup.add(%p);
      
      %part = new ParticleEmissionDummy() {
         position =  %targetObject.getPosition();
         rotation = "1 0 0 0";
         scale = "1 1 1";
         dataBlock = defaultEmissionDummy;
         emitter = "MeltDownEmitter";
         velocity = "1";
      };
      MissionCleanup.add(%part);
      
      %trig = new Trigger() {
            position = vectorAdd(%targetObject.getPosition(),"0 0 1.5");
            rotation = "0 0 1 0";
            scale = "10 10 6";
            dataBlock = "AnomalyTrig";
            polyhedron = "-0.5 0.5 -0.5 1.0 0.0 0.0 -0.0 -1.0 -0.0 -0.0 -0.0 1.0";

            locked = "true";
            type = "9";
            client = %sObj.client;
            part = %part;
      };
      MissionCleanup.add(%trig);
      %part.schedule(60000, "delete");
      %trig.schedule(60000, "delete");  
      shockLanceGenLoop(%trig);
   }
   else{
      %targetObject.damage(%sObj, %pos, 100, $DamageType::Dark); 
      %p = new LinearFlareProjectile() {
         dataBlock        = MeltDownProj;
         initialDirection = "0 0 1";
         initialPosition  = %targetObject.getWorldBoxCenter();
         sourceObject     = %sObj;
         sourceSlot       = 0;
      };
      MissionCleanup.add(%p);
   }  
}

function shockLanceGenLoop(%p){
   %everythingElseMask = $TypeMasks::TerrainObjectType |
                         $TypeMasks::InteriorObjectType |
                         $TypeMasks::ForceFieldObjectType |
                         $TypeMasks::StaticObjectType |
                         $TypeMasks::MoveableObjectType |
                         $TypeMasks::DamagableItemObjectType |
                         $TypeMasks::PlayerObjectType;
   if(isObject(%p)){
      initContainerRadiusSearch(%p.getPosition(), 25, $TypeMasks::PlayerObjectType );
      while ( (%targetObj = containerSearchNext()) != 0 ){ 
         %hit = ContainerRayCast(%p.getPosition(), %targetObj.getPosition(), %everythingElseMask, %p);
         %hitobj = getWord(%hit, 0);
         if(%hit && (%hitobj.getType() & $TypeMasks::PlayerObjectType)){
            %hitpos = getWord(%hit, 1) @ " " @ getWord(%hit, 2) @ " " @ getWord(%hit, 3);
            %vec = vectorNormalize(vectorSub(%targetObj.getWorldBoxCenter(),%p.getPosition()));
            %v = new ShockLanceProjectile() {
               dataBlock        = BasicShocker;
               initialDirection = %vec;
               initialPosition  = %p.getPosition();
               sourceObject     = -1;
               sourceSlot       = 0;
               targetId         = %hit;
            };
           //error("player" SPC %p.client.player);
            MissionCleanup.add(%v);
            %hitObj.damage(%p.client.player, %hitpos, 0.5, $DamageType::Dark); 
         }

      }
      schedule(512, 0, "shockLanceGenLoop", %p);
   }
}
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////