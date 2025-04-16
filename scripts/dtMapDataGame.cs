// all datablocks used in darktigers maps

////////////////////////////////////////////////////////////////////////////////
//anabatic
datablock ParticleData(MegaBoilBubbleParticle)
{
   dragCoefficient      = 0.1;
   gravityCoefficient   = -0.15; // Aggressively rises
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 200;
   useInvAlpha          = false;
   spinRandomMin        = -180.0;
   spinRandomMax        = 180.0;
   textureName          = "special/bubbles"; // Swap with molten bubble or lava bubble texture for drama

   colors[0]     = "0.5 0.5 0.5 0.0";   // Start faded
   colors[1]     = "0.6 0.6 0.6 0.8";   // Become more visible
   colors[2]     = "0.1 0.1 0.1 0.0";   // Fade out at the end

   sizes[0]      = 2.0;
   sizes[1]      = 5.0;
   sizes[2]      = 7.5;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(MegaBoilBubbleEmitter)
{
   ejectionPeriodMS = 16; // Very rapid bubbling
   periodVarianceMS = 2;
   ejectionVelocity = 15.0;
   velocityVariance = 3.0;

   ejectionOffset   = 31.0; // Bubbles rise from slightly under the surface
   thetaMin         = 5;
   thetaMax         = 30; // Spread in angle to make it chaotic
   phiVariance      = 360;

   overrideAdvances = false;
   particles = "MegaBoilBubbleParticle";
};


datablock ParticleData(SnowParticle) {
   dragCoefficient = "0";
   windCoefficient = "-1";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "8000";
   lifetimeVarianceMS = "200";
   spinSpeed = "1";
   spinRandomMin = "-50";
   spinRandomMax = "50";
   useInvAlpha = "0";
   textureName = "precipitation/snowflake002";
   colors[0] = "0.204724 0.204724 0.204724 0.0";
   colors[1] = "0.291339 0.291339 0.291339 1";
   colors[2] = "0.259843 0.259843 0.259843 1";
   colors[3] = "0.0787402 0.0787402 0.0787402 1";
   sizes[0] = "0.5";
   sizes[1] = "0.5";
   sizes[2] = "0.5";
   sizes[3] = "0.5";
   times[0] = "0.1";
   times[1] = "0.2";
   times[2] = "0.9";
   times[3] = "1";
};

datablock ParticleEmitterData(SnowEmitter) {
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "100";
   velocityVariance = "50";
   ejectionOffset = "10";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "35";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "1";
   ambientFactor = "0";
   overrideAdvance = "1";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "SnowParticle";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
};
datablock ParticleData(SnowParticle2) {
   dragCoefficient = "0";
   windCoefficient = "-1";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "10000";
   lifetimeVarianceMS = "200";
   spinSpeed = "1";
   spinRandomMin = "-50";
   spinRandomMax = "50";
   useInvAlpha = "0";
   textureName = "precipitation/snowflake005";
   colors[0] = "0.204724 0.204724 0.204724 0.0";
   colors[1] = "0.291339 0.291339 0.291339 1";
   colors[2] = "0.259843 0.259843 0.259843 1";
   colors[3] = "0.0787402 0.0787402 0.0787402 1";
   sizes[0] = "0.8";
   sizes[1] = "0.8";
   sizes[2] = "0.8";
   sizes[3] = "0.8";
   times[0] = "0.1";
   times[1] = "0.2";
   times[2] = "0.9";
   times[3] = "1";
};

datablock ParticleEmitterData(SnowEmitter2) {
   ejectionPeriodMS = "5";
   periodVarianceMS = "0";
   ejectionVelocity = "100";
   velocityVariance = "70";
   ejectionOffset = "10";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "35";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "1";
   ambientFactor = "0";
   overrideAdvance = "1";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "SnowParticle2";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
};

///////////////////////////////////////////////////////////////////////////////
//Facing Worlds 

datablock StaticShapeData(faceBox){
   catagory = "MISC";
   shapeFile = "faceBox.dts";
   alwaysAmbient = true;
   isInvincible = true;
};

datablock TriggerData(faceDeathTrigger){
   tickPeriodMS =  1000;
};

///////////////////////////////////////////////////////////////////////////////
//Infernos Roar 

datablock ParticleEmissionDummyData(manyTimeEmissionDummy){
   timeMultiple = 20.0;
};

datablock ParticleData(vocBlastShockwaveParticle) {
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
   textureName = "smoke02";
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

datablock ParticleEmitterData(vocBlastShockwaveEmitter) {
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "600";
   velocityVariance = "0";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "90";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "0.0001";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "vocBlastShockwaveParticle";
   lifetimeMS = "2000";
   lifetimeVarianceMS = "0";
   
   
};

datablock ParticleData(vocBlastExplosionParticleS) {
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
   textureName = "dParticle";
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

datablock ParticleEmitterData(vocBlastExplosionEmitterS) {
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
   particles = "vocBlastExplosionParticleS";
   lifetimeMS = "150";
   lifetimeVarianceMS = "0";  
};

datablock ParticleData(vocBlastFireParticle) {
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
   textureName = "dParticle";
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

datablock ParticleEmitterData(vocBlastFireEmitter) {
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
   particles = "vocBlastFireParticle";
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

datablock ParticleData(vocBlastFireParticle2) {
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
   textureName = "smoke02";
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

datablock ParticleEmitterData(vocBlastFireEmitter2) {
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
   particles = "vocBlastFireParticle2";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";  
};

datablock GrenadeProjectileData(vocBlastExplosionProj)
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
   explosion           = FireballAtmosphereBoltExplosion;
   underwaterExplosion = UnderwaterMortarExplosion;
   velInheritFactor    = 0.85; 

   baseEmitter         = vocBlastFireEmitter2;
   delayEmitter        = vocBlastFireEmitter;
   emitterDelay = 32;
   bubbleEmitter       = MortarBubbleEmitter;

   grenadeElasticity = 0.30; 
   grenadeFriction   = 0.2;
   armingDelayMS     = 250;
   muzzleVelocity    = 200.00;
   gravityMod        = 3.9; 
};




datablock ExplosionData(vocBlastSmokeStack){
   lifeTimeMS = 30000;
   offset = 0;
   shakeCamera = true;
   camShakeFreq = "8.0 8.0 8.0";
   camShakeAmp = "5.0 5.0 5.0";
   camShakeDuration = 5;
   camShakeRadius = 2500.0;
};

datablock LinearFlareProjectileData(vocExplTwo){
   //projectileShapeName = "disc_explosion.dts";
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.0;
   damageRadius        = 7.7;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Explosion;

   explosion           = "vocBlastSmokeStack";

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




datablock ParticleData(vocBlastRingParticle) {
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
   textureName = "smoke02";
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

datablock ParticleEmitterData(vocBlastRingEmitter) {
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
   particles = "vocBlastRingParticle";
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

datablock ParticleData(vocBlastExplosionParticle2) {
   dragCoefficient = "0.25";
   windCoefficient = "0";
   gravityCoefficient = "1";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "20000";
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
   textureName = "smoke02";
   animTexName = "smoke02";
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
   times[2] = "0.8875";
   times[3] = "1";
};

datablock ParticleEmitterData(vocBlastExplosionEmitter2) {
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "150";
   velocityVariance = "100.83";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "90";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "0.0001";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "vocBlastExplosionParticle2";
   lifetimeMS = "4000";
   lifetimeVarianceMS = "0";
   
};

datablock ParticleData(vocBlastExplosionParticle) {
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
   textureName = "dParticle";
   colors[0] = "0.992 0.301961 0.0 1";
   colors[1] = "0.992 0.301961 0.0 1";
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

datablock ParticleEmitterData(vocBlastExplosionEmitter) {
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "655.35";
   velocityVariance = "0";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "90";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "0.0001";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "vocBlastExplosionParticle";
   lifetimeMS = "2000";
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


datablock ExplosionData(vocBlastExplosion)
{
   
   emitter[0] = vocBlastExplosionEmitter;
   emitter[1] = vocBlastExplosionEmitter2;
   emitter[2] = vocBlastRingEmitter;
   
   lifeTimeMS = 6000;
   
   shakeCamera = true;
   camShakeFreq = "8.0 8.0 8.0";
   camShakeAmp = "1.0 1.0 1.0";
   camShakeDuration = 5;
   camShakeRadius = 2500.0;

};

datablock LinearFlareProjectileData(explVoc){
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.0;
   damageRadius        = 400.7;
   kickBackStrength    = 50000.0;
   radiusDamageType    = $DamageType::Explosion;

   explosion           = "vocBlastExplosion";

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


datablock AudioProfile(VocLightningZapSound){
   filename = "fx/misc/lightning_impact.wav";
   description = AudioExplosion3d;
};

datablock LightningData(VocZapStorm){
   directDamageType = $DamageType::Lightning;
   directDamage = 1;
   
   strikeTextures[0]  = "special/skyLightning";

   strikeSound = VocLightningZapSound;
};


datablock ParticleData(vocBlastBigFireParticle) {
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
   textureName = "dParticle";
   colors[0] = "0.996078 0.301961 0.00784314 1";
   colors[1] = "0.996078 0.301961 0.00784314 0.77";
   colors[2] = "0.996078 0.301961 0.00784314 0.761";
   colors[3] = "0.996078 0.301961 0.00784314 1";
   sizes[0] = "13";
   sizes[1] = "13";
   sizes[2] = "13";
   sizes[3] = "13";
   times[0] = "0";
   times[1] = "0.270833";
   times[2] = "0.625";
   times[3] = "1";
};

datablock ParticleEmitterData(vocBlastBigFireEmitter) {
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
   particles = "vocBlastBigFireParticle";
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

datablock ParticleData(vocBlastBigFireParticle2) {
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
   textureName = "smoke02";
   colors[0] = "0.458824 0.458824 0.458824 1";
   colors[1] = "0.321569 0.321569 0.321569 0.496";
   colors[2] = "0.584314 0.584314 0.588235 1";
   colors[3] = "0.843137 0.847059 0.847059 0";
   sizes[0] = "15";
   sizes[1] = "15";
   sizes[2] = "15";
   sizes[3] = "15";
   times[0] = "0";
   times[1] = "0.329412";
   times[2] = "0.666667";
   times[3] = "1";
};

datablock ParticleEmitterData(vocBlastBigFireEmitter2) {
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
   particles = "vocBlastbigFireParticle2";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";  
};

datablock GrenadeProjectileData(vocBlastBigExplosionProj)
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

   baseEmitter         = vocBlastBigFireEmitter2;
   delayEmitter        = vocBlastBigFireEmitter;
   emitterDelay = 32;
   bubbleEmitter       = MortarBubbleEmitter;

   grenadeElasticity = 0.30; 
   grenadeFriction   = 0.2;
   armingDelayMS     = 250;
   muzzleVelocity    = 200.00;
   gravityMod        = 3.9; 
};


datablock GrenadeProjectileData(vocBlastExplosionProjSlow)
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
   explosion           = FireballAtmosphereBoltExplosion;
   underwaterExplosion = UnderwaterMortarExplosion;
   velInheritFactor    = 0.85; 

   baseEmitter         = vocBlastFireEmitter2;
   delayEmitter        = vocBlastFireEmitter;
   emitterDelay = 32;
   bubbleEmitter       = MortarBubbleEmitter;

   grenadeElasticity = 0.30; 
   grenadeFriction   = 0.2;
   armingDelayMS     = 250;
   muzzleVelocity    = 100.00;
   gravityMod        = 3.9; 
};


datablock ParticleData(vocAshSmokeParticle) {
   dragCoefficient = "0";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "6000";
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
   textureName = "smoke02";
   colors[0] = "0.11 0.11 0.11 1.0";
   colors[1] = "0.14 0.14 0.14 0.8";
   colors[2] = "0.167 0.16 0.16 0.7";
   colors[3] = "0.102 0.102 0.198 0.1";
   sizes[0] = "150";
   sizes[1] = "150";
   sizes[2] = "150";
   sizes[3] = "150";
   times[0] = "0.01";
   times[1] = "0.229167";
   times[2] = "0.8875";
   times[3] = "1";
};

datablock ParticleEmitterData(vocAshSmokeEmitter) {
   ejectionPeriodMS = "5";
   periodVarianceMS = "0";
   ejectionVelocity = "100";
   velocityVariance = "50.83";
   ejectionOffset = "50";
   ejectionOffsetVariance = "40";
   thetaMin = "0";
   thetaMax = "30";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "0.0001";
   ambientFactor = "0";
   overrideAdvance = "0";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "vocAshSmokeParticle";
   
};




datablock TriggerData(wTrig){
   tickPeriodMS =  32;
};

///////////////////////////////////////////////////////////////////////////////
//Storms rage

datablock ParticleData(LightningSparks){
   dragCoefficient = 0;
   gravityCoefficient = 6.0;
   inheritedVelFactor = 0.0;
   constantAcceleration = 1.0;
   lifetimeMS = 11900;
   lifetimeVarianceMS = 0;
   textureName = "special/spark00";
   sizes[0] = 2.2;
   sizes[1] = 2.4;
   sizes[2] = 2.1;
   times[0] = 0.0;
   times[1] = 0.2;
   times[2] = 1.0;
};

datablock ParticleEmitterData(LightningSparksEmitter){
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;
   ejectionVelocity = 30;
   velocityVariance = 14.0;
   ejectionOffset = 0.0;
   thetaMin = 0;
   thetaMax = 25;
   phiReferenceVel = 0;
   phiVariance = 360;
   overrideAdvances = false;
   orientParticles = true;
   lifetimeMS = 0;
   particles = "LightningSparks";
};

datablock ParticleData(RainMistParticle2) {
   dragCoefficient = "0";
   windCoefficient = "2";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "1000";
   lifetimeVarianceMS = "200";
   spinSpeed = "1";
   spinRandomMin = "-50";
   spinRandomMax = "50";
   useInvAlpha = "0";
   textureName = "rainmist";
   colors[0] = "0.204724 0.204724 0.204724 0.0";
   colors[1] = "0.291339 0.291339 0.291339 0.02";
   colors[2] = "0.259843 0.259843 0.259843 0.4";
   colors[3] = "0.0787402 0.0787402 0.0787402 0.4";
   sizes[0] = "30";
   sizes[1] = "30";
   sizes[2] = "30";
   sizes[3] = "30";
   times[0] = "0.1";
   times[1] = "0.4";
   times[2] = "0.9";
   times[3] = "1";
};

datablock ParticleEmitterData(RainMistEmitter2) {
   ejectionPeriodMS = "4";
   periodVarianceMS = "0";
   ejectionVelocity = "00";
   velocityVariance = "0";
   ejectionOffset = "40";
   ejectionOffsetVariance = "0";
   thetaMin = "90";
   thetaMax = "90";
   phiReferenceVel = "0";
   phiVariance = "180";
   softnessDistance = "1";
   ambientFactor = "0";
   overrideAdvance = "1";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "RainMistParticle2";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
};


datablock ParticleData(RainMistParticle) {
   dragCoefficient = "0";
   windCoefficient = "0.05";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "9000";
   lifetimeVarianceMS = "200";
   spinSpeed = "1";
   spinRandomMin = "-50";
   spinRandomMax = "50";
   useInvAlpha = "0";
   textureName = "rainmist";
   colors[0] = "0.204724 0.204724 0.204724 0.0";
   colors[1] = "0.291339 0.291339 0.291339 0.25";
   colors[2] = "0.259843 0.259843 0.259843 0.25";
   colors[3] = "0.0787402 0.0787402 0.0787402 0.25";
   sizes[0] = "150";
   sizes[1] = "150";
   sizes[2] = "150";
   sizes[3] = "150";
   times[0] = "0.1";
   times[1] = "0.2";
   times[2] = "0.9";
   times[3] = "1";
};

datablock ParticleEmitterData(RainMistEmitter) {
   ejectionPeriodMS = "12";
   periodVarianceMS = "0";
   ejectionVelocity = "140";
   velocityVariance = "50";
   ejectionOffset = "100";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "15";
   phiReferenceVel = "0";
   phiVariance = "360";
   softnessDistance = "1";
   ambientFactor = "0";
   overrideAdvance = "1";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "RainMistParticle";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
};




datablock ParticleData(vvParticle) {
   dragCoefficient = "0.25";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "1200";
   lifetimeVarianceMS = "200";
   spinSpeed = "1";
   spinRandomMin = "-50";
   spinRandomMax = "50";
   useInvAlpha = "1";
   textureName = "rainmist";
   colors[0] = "0.504724 0.504724 0.504724 0.15";
   colors[1] = "0.591339 0.591339 0.591339 0.15";
   colors[2] = "0.559843 0.559843 0.559843 0.15";
   colors[3] = "0.0787402 0.0787402 0.0787402 0.015748";
   sizes[0] = "100";
   sizes[1] = "100";
   sizes[2] = "100";
   sizes[3] = "100";
   times[0] = "0";
   times[1] = "0.05";
   times[2] = "0.65";
   times[3] = "1";
};

datablock ParticleEmitterData(vvEmitter) {
   ejectionPeriodMS = "30";
   periodVarianceMS = "0";
   ejectionVelocity = "200";
   velocityVariance = "50";
   ejectionOffset = "0";
   ejectionOffsetVariance = "0";
   thetaMin = "0";
   thetaMax = "5";
   phiReferenceVel = "0";
   phiVariance = "360";
   overrideAdvance = "1";
   orientParticles = "0";
   orientOnVelocity = "1";
   particles = "vvParticle";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0"; 
   
};
/////////////////////////////////////////////////////////////////////////////////
//TwinTorrents

datablock ParticleData(apBubbleStreamParticle) {
   dragCoefficient = "0.5";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "500";
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
   textureName          = "special/bubbles";
   colors[0]     = "0.7 0.8 1.0 0.8";
   colors[1]     = "0.7 0.8 1.0 0.4";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.4;
   sizes[1]      = 0.7;
   sizes[2]      = 0.7;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(apBubbleStreamEmitter) {
   ejectionPeriodMS = "2";
   periodVarianceMS = "0";
   ejectionVelocity = "150";
   velocityVariance = "50";
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
   particles = "apBubbleStreamParticle";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";
   useEmitterSizes = "0";
   useEmitterColors = "0";
   blendStyle = "NORMAL";
   sortParticles = "0";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
   renderReflection = "1";
   glow = "0";
   EnableCollison = "0";
   Dampening = "0.8";
   elasticity = "0.3";
   KillColTime = "1000";
   killedByCollision = "0";
   ColDetectDistAdj = "1";
};

datablock ParticleData(SXFlowParticle) {
   dragCoefficient = "0.5";
   windCoefficient = "0";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "600";
   lifetimeVarianceMS = "100";
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
   colors[0] = "0.204724 0.204724 0.204724 0.01";
   colors[1] = "0.291339 0.291339 0.291339 0.01";
   colors[2] = "0.259843 0.259843 0.259843 0.1";
   colors[3] = "0.0787402 0.0787402 0.0787402 0.015748";
   sizes[0] = "40";
   sizes[1] = "40";
   sizes[2] = "40";
   sizes[3] = "40";
   times[0] = "0";
   times[1] = "0.05";
   times[2] = "0.65";
   times[3] = "1";
};

datablock ParticleEmitterData(SXFlowEmitter) {
   ejectionPeriodMS = "15";
   periodVarianceMS = "0";
   ejectionVelocity = "200";
   velocityVariance = "50";
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
   particles = "SXFlowParticle";
   lifetimeMS = "0";
   lifetimeVarianceMS = "0";
   useEmitterSizes = "0";
   useEmitterColors = "0";
   blendStyle = "NORMAL";
   sortParticles = "0";
   reverseOrder = "0";
   alignParticles = "0";
   alignDirection = "0 1 0";
   highResOnly = "1";
   renderReflection = "1";
   glow = "0";
   EnableCollison = "0";
   Dampening = "0.8";
   elasticity = "0.3";
   KillColTime = "1000";
   killedByCollision = "0";
   ColDetectDistAdj = "1";
};

datablock ForceFieldBareData(SXAllFastField)
{
   fadeMS           = 1000;
   baseTranslucency = 0.30;
   powerOffTranslucency = 0.0;
   teamPermiable    = true;
   otherPermiable   = true;
   color            = "0.0 0.0 1.0";   
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
datablock TriggerData(wpDeathTrigger){
   tickPeriodMS =  512;
};


