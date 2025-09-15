function initWepBuildHud(){
   if(!isObject(wepBuildDlg)){
      new GuiControl(wepBuildDlg) {
         profile = "GuiDefaultProfile";
         horizSizing = "width"; 
         vertSizing = "height";
         position = "0 0";
         extent = "640 480";
         minExtent = "8 8";
         visible = "1";
         helpTag = "0";
            mouseOn = "1";

         new ShellPaneCtrl(wepBuildFrame) {
            profile = "ShellDlgPaneProfile";
            horizSizing = "center";
            vertSizing = "center";
            position = "220 115";
            extent = "600 250";
            minExtent = "48 92";
            visible = "1";
            helpTag = "0";
            noTitleBar = "0";

            new GuiTextCtrl() {
               profile = "ShellTextRightProfile";
               horizSizing = "left";
               vertSizing = "top";
               position = "147 25";
               extent = "74 22";
               minExtent = "8 8";
               visible = "1";
               hideCursor = "0";
               bypassHideCursor = "0";
               helpTag = "0";
               text = "Weapon Class";
               maxLength = "255";
            };

            new GuiTextCtrl() {
               profile = "ShellTextRightProfile";
               horizSizing = "left";
               vertSizing = "top";
               position = "37 25";
               extent = "74 22";
               minExtent = "8 8";
               visible = "1";
               hideCursor = "0";
               bypassHideCursor = "0";
               helpTag = "0";
               text = "Weapon Type";
               maxLength = "255";
            };

            new GuiTextCtrl() {
               profile = "ShellTextRightProfile";
               horizSizing = "left";
               vertSizing = "top";
               position = "257 25";
               extent = "74 22";
               minExtent = "8 8";
               visible = "1";
               hideCursor = "0";
               bypassHideCursor = "0";
               helpTag = "0";
               text = "Tier 1 Mod";
               maxLength = "255";
            };

            new GuiTextCtrl() {
               profile = "ShellTextRightProfile";
               horizSizing = "left";
               vertSizing = "top";
               position = "367 25";
               extent = "74 22";
               minExtent = "8 8";
               visible = "1";
               hideCursor = "0";
               bypassHideCursor = "0";
               helpTag = "0";
               text = "Tier 2 Mod";
               maxLength = "255";
            };

            new GuiTextCtrl() {
               profile = "ShellTextRightProfile";
               horizSizing = "left";
               vertSizing = "top";
               position = "477 25";
               extent = "74 22";
               minExtent = "8 8";
               visible = "1";
               hideCursor = "0";
               bypassHideCursor = "0";
               helpTag = "0";
               text = "Tier 3 Mod";
               maxLength = "255";
            };
   ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            new ShellBitmapButton(WC1) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "20 40";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Theta";
               command = "selClassBuild(1);";
            };
         
            new ShellBitmapButton(WC2) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "20 70";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "RK-4K";
               command = "selClassBuild(2);";
            };
            new ShellBitmapButton(WC3) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "20 100";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Star";
               command = "selClassBuild(3);";
            };
            new ShellBitmapButton(WC4) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "20 130";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Core";
               command = "selClassBuild(4);";
            };
            new ShellBitmapButton(WC5) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "20 160";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Dark";
               command = "selClassBuild(5);";
            };
/////////////////////////////////////////////////////////////////
             new ShellBitmapButton(WT1) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "130 40";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Energy";
               command = "selTypeBuild(1);";
            };
         
            new ShellBitmapButton(WT2) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "130 70";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Linear/Direct";
               command = "selTypeBuild(2);";
            };
            new ShellBitmapButton(WT3) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "130 100";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Lobbed";
               command = "selTypeBuild(3);";
            };
            new ShellBitmapButton(WT4) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "130 130";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Mid Range";
               command = "selTypeBuild(4);";
            };
            new ShellBitmapButton(WT5) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "130 160";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Close Range";
               command = "selTypeBuild(5);";
            };
/////////////////////////////////////////////////////////////////
            new ShellBitmapButton(TAM1) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "240 40";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Armor/Shield Scale T1";
               command = "selT1ModBuild(1);";
            };
         
            new ShellBitmapButton(TAM2) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "240 70";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Damage T1";
               command = "selT1ModBuild(2);";
            };
            new ShellBitmapButton(TAM3) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "240 100";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Capacity T1";
               command = "selT1ModBuild(3);";
            };
            new ShellBitmapButton(TAM4) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "240 130";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "AOE T1";
               command = "selT1ModBuild(4);";
            };
            new ShellBitmapButton(TAM5) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "240 160";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Anomaly T1";
               command = "selT1ModBuild(5);";
            };
      /////////////////////////////////////////////////////////////////
            new ShellBitmapButton(TBM1) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "350 40";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Armor/Shield Scale T2";
               command = "selT2ModBuild(1);";
            };
         
            new ShellBitmapButton(TBM2) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "350 70";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Damage T2";
               command = "selT2ModBuild(2);";
            };
            new ShellBitmapButton(TBM3) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "350 100";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Capacity T2";
               command = "selT2ModBuild(3);";
            };
            new ShellBitmapButton(TBM4) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "350 130";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "AOE  T2";
               command = "selT2ModBuild(4);";
            };
            new ShellBitmapButton(TBM5) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "350 160";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Anomaly T2";
               command = "selT2ModBuild(5);";
            };
            /////////////////////////////////////////////////////////////////
            new ShellBitmapButton(TCM1) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "460 40";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Armor/Shield Scale T3";
               command = "selT3ModBuild(1);";
            };
         
            new ShellBitmapButton(TCM2) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "460 70";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Damage T3";
               command = "selT3ModBuild(2);";
            };
            new ShellBitmapButton(TCM3) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "460 100";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Capacity T3";
               command = "selT3ModBuild(3);";
            };
            new ShellBitmapButton(TCM4) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "460 130";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "AOE T3";
               command = "selT3ModBuild(4);";
            };
            new ShellBitmapButton(TCM5) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "460 160";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Anomaly T3";
               command = "selT3ModBuild(5);";
            };
            ///////////////////////////////////////////////////////////////////////////////
            new ShellBitmapButton(buildWepBtn) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "240 190";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Build Weapon";
               command = "buildWep();";
            };

            new ShellBitmapButton(buildWepClose) {
               profile = "ShellButtonProfile";
               horizSizing = "right";
               vertSizing = "top";
               position = "460 190";
               extent = "120 60";
               minExtent = "8 8";
               visible = "1";
               helpTag = "0";
               text = "Close";
               command = "Canvas.popDialog(wepBuildDlg);";
            };
         };
      };
   }
}

function clientCmdBuildWep(%val){
   if(%val){
      initWepBuildHud();
      ClientCmdSetHudMode("buildWep");
      Canvas.pushDialog(wepBuildDlg);
      wepBuildFrame.setTitle("Weapon Builder");
       buildWepBtn.buildT = 0;
       buildWepBtn.buildC = 0;
       buildWepBtn.buildT1 = 0;
       buildWepBtn.buildT2 = 0;
       buildWepBtn.buildT3 = 0;
      for(%i = 5; %i < wepBuildFrame.getCount(); %i++){
         %uiObj =  wepBuildFrame.getObject(%i);
         %uiObj.setActive(1);

      }
      buildWepBtn.setActive(0);
   }
   else{
      Canvas.popDialog(wepBuildDlg);
   }
}
function clientCmdEnableWepBuild(%val){
   buildWepBtn.setActive(1);   
}

function buildWep(%val){
   if(buildWepBtn.isActive()){
      commandToServer('StartWepBuild', buildWepBtn.buildC, buildWepBtn.buildT, buildWepBtn.buildT1, buildWepBtn.buildT2, buildWepBtn.buildT3);
   }
}

function selClassBuild(%val){
   WC1.setActive(%val != 1); 
   WC2.setActive(%val != 2);
   WC3.setActive(%val != 3);
   WC4.setActive(%val != 4);
   WC5.setActive(%val != 5);
   buildWepBtn.buildC = %val;
   commandToServer('BuildWEpSelect', buildWepBtn.buildC, buildWepBtn.buildT, buildWepBtn.buildT1, buildWepBtn.buildT2, buildWepBtn.buildT3);
}


function selTypeBuild(%val){
   WT1.setActive(%val != 1);
   WT2.setActive(%val != 2);
   WT3.setActive(%val != 3);
   WT4.setActive(%val != 4);
   WT5.setActive(%val != 5);
   buildWepBtn.buildT = %val;
   commandToServer('BuildWepSelect', buildWepBtn.buildC, buildWepBtn.buildT, buildWepBtn.buildT1, buildWepBtn.buildT2, buildWepBtn.buildT3);
}

function selT1ModBuild(%val){
   TAM1.setActive(%val != 1);
   TAM2.setActive(%val != 2);
   TAM3.setActive(%val != 3);
   TAM4.setActive(%val != 4);
   TAM5.setActive(%val != 5);
   buildWepBtn.buildT1 = %val;
   commandToServer('BuildWEpSelect', buildWepBtn.buildC, buildWepBtn.buildT, buildWepBtn.buildT1, buildWepBtn.buildT2, buildWepBtn.buildT3);
}

function selT2ModBuild(%val){
   TBM1.setActive(%val != 1);
   TBM2.setActive(%val != 2);
   TBM3.setActive(%val != 3);
   TBM4.setActive(%val != 4);
   TBM5.setActive(%val != 5);
   buildWepBtn.build = setField(buildWepBtn.build, 3, %val);
   buildWepBtn.buildT2 = %val;
   commandToServer('BuildWEpSelect', buildWepBtn.buildC, buildWepBtn.buildT, buildWepBtn.buildT1, buildWepBtn.buildT2, buildWepBtn.buildT3);
}

function selT3ModBuild(%val){
   TCM1.setActive(%val != 1);
   TCM2.setActive(%val != 2);
   TCM3.setActive(%val != 3);
   TCM4.setActive(%val != 4);
   TCM5.setActive(%val != 5);
   buildWepBtn.buildT3 = %val;
   commandToServer('BuildWEpSelect', buildWepBtn.buildC, buildWepBtn.buildT, buildWepBtn.buildT1, buildWepBtn.buildT2, buildWepBtn.buildT3);
}