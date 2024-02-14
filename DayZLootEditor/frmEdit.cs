using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DayZLootEditor
{
    public partial class frmEdit : Form
    {
        //Created a list of strings with all itemType names
       private static List<string> list = new List<string> {"ACOGOptic",
"ACOGOptic_6x",
"AK101",
"AK101_Black",
"AK101_Green",
"AK74",
"AK74_Black",
"AK74_Green",
"AK74_Hndgrd",
"AK74_WoodBttstck",
"AKM",
"AKS74U",
"AKS74U_Black",
"AKS74U_Bttstck",
"AKS74U_Green",
"AK_Bayonet",
"AK_FoldingBttstck",
"AK_FoldingBttstck_Black",
"AK_FoldingBttstck_Green",
"AK_PlasticBttstck",
"AK_PlasticBttstck_Black",
"AK_PlasticBttstck_Green",
"AK_PlasticHndgrd",
"AK_RailHndgrd",
"AK_RailHndgrd_Black",
"AK_RailHndgrd_Green",
"AK_Suppressor",
"AK_WoodBttstck",
"AK_WoodBttstck_Black",
"AK_WoodBttstck_Camo",
"AK_WoodHndgrd",
"AK_WoodHndgrd_Black",
"AK_WoodHndgrd_Camo",
"ASVAL",
"AgaricusMushroom",
"AirborneMask",
"AlarmClock_Blue",
"AlarmClock_Green",
"AlarmClock_Red",
"AliceBag_Black",
"AliceBag_Camo",
"AliceBag_Green",
"AmmoBox",
"AmmoBox_00buck_10rnd",
"AmmoBox_12gaRubberSlug_10Rnd",
"AmmoBox_12gaSlug_10Rnd",
"AmmoBox_22_50Rnd",
"AmmoBox_308WinTracer_20Rnd",
"AmmoBox_308Win_20Rnd",
"AmmoBox_357_20Rnd",
"AmmoBox_380_35rnd",
"AmmoBox_45ACP_25rnd",
"AmmoBox_545x39Tracer_20Rnd",
"AmmoBox_545x39_20Rnd",
"AmmoBox_556x45Tracer_20Rnd",
"AmmoBox_556x45_20Rnd",
"AmmoBox_762x39Tracer_20Rnd",
"AmmoBox_762x39_20Rnd",
"AmmoBox_762x54Tracer_20Rnd",
"AmmoBox_762x54_20Rnd",
"AmmoBox_9x19_25rnd",
"AmmoBox_9x39AP_20Rnd",
"AmmoBox_9x39_20Rnd",
"Ammo_12gaPellets",
"Ammo_12gaRubberSlug",
"Ammo_12gaSlug",
"Ammo_22",
"Ammo_308Win",
"Ammo_308WinTracer",
"Ammo_357",
"Ammo_380",
"Ammo_40mm_Chemgas",
"Ammo_40mm_Explosive",
"Ammo_40mm_Smoke_Black",
"Ammo_40mm_Smoke_Green",
"Ammo_40mm_Smoke_Red",
"Ammo_40mm_Smoke_White",
"Ammo_45ACP",
"Ammo_545x39",
"Ammo_545x39Tracer",
"Ammo_556x45",
"Ammo_556x45Tracer",
"Ammo_762x39",
"Ammo_762x39Tracer",
"Ammo_762x54",
"Ammo_762x54Tracer",
"Ammo_9x19",
"Ammo_9x39",
"Ammo_9x39AP",
"Ammo_Flare",
"Ammo_FlareBlue",
"Ammo_FlareGreen",
"Ammo_FlareRed",
"Ammo_HuntingBolt",
"Ammo_ImprovisedBolt_1",
"Ammo_ImprovisedBolt_2",
"AmmoBox",
"AmmoBox_00buck_10rnd",
"AmmoBox_12gaRubberSlug_10Rnd",
"AmmoBox_12gaSlug_10Rnd",
"AmmoBox_22_50Rnd",
"AmmoBox_308WinTracer_20Rnd",
"AmmoBox_308Win_20Rnd",
"AmmoBox_357_20Rnd",
"AmmoBox_380_35rnd",
"AmmoBox_45ACP_25rnd",
"AmmoBox_545x39Tracer_20Rnd",
"AmmoBox_545x39_20Rnd",
"AmmoBox_556x45Tracer_20Rnd",
"AmmoBox_556x45_20Rnd",
"AmmoBox_762x39Tracer_20Rnd",
"AmmoBox_762x39_20Rnd",
"AmmoBox_762x54Tracer_20Rnd",
"AmmoBox_762x54_20Rnd",
"AmmoBox_9x19_25rnd",
"AmmoBox_9x39AP_20Rnd",
"AmmoBox_9x39_20Rnd",
"Ammo_12gaPellets",
"Ammo_12gaRubberSlug",
"Ammo_12gaSlug",
"Ammo_22",
"Ammo_308Win",
"Ammo_308WinTracer",
"Ammo_357",
"Ammo_380",
"Ammo_40mm_Chemgas",
"Ammo_40mm_Explosive",
"Ammo_40mm_Smoke_Black",
"Ammo_40mm_Smoke_Green",
"Ammo_40mm_Smoke_Red",
"Ammo_40mm_Smoke_White",
"Ammo_45ACP",
"Ammo_545x39",
"Ammo_545x39Tracer",
"AnniversaryBox",
"Anniversary_FireworksLauncher",
"AntiChemInjector",
"AntiPestsSpray",
"Apple",
"Armband_APA",
"Armband_Altis",
"Armband_BabyDeer",
"Armband_Bear",
"Armband_Black",
"Armband_Blue",
"Armband_Bohemia",
"Armband_BrainZ",
"Armband_CDF",
"Armband_CHEL",
"Armband_CMC",
"Armband_Cannibals",
"Armband_Chedaki",
"Armband_Chernarus",
"Armband_Crook",
"Armband_DayZ",
"Armband_Green",
"Armband_HunterZ",
"Armband_Livonia",
"Armband_LivoniaArmy",
"Armband_LivoniaPolice",
"Armband_NAPA",
"Armband_NSahrani",
"Armband_Orange",
"Armband_Pink",
"Armband_Pirates",
"Armband_RSTA",
"Armband_Red",
"Armband_Refuge",
"Armband_Rex",
"Armband_Rooster",
"Armband_SSahrani",
"Armband_Snake",
"Armband_TEC",
"Armband_UEC",
"Armband_White",
"Armband_Wolf",
"Armband_Yellow",
"Armband_Zagorky",
"Armband_Zenit",
"ArmyPouch_Beige",
"ArmyPouch_Black",
"ArmyPouch_Camo",
"ArmyPouch_Green",
"AssaultBag_Black",
"AssaultBag_Green",
"AssaultBag_Ttsko",
"AthleticShoes_Black",
"AthleticShoes_Blue",
"AthleticShoes_Brown",
"AthleticShoes_Green",
"AthleticShoes_Grey",
"Aug",
"AugShort",
"AuriculariaMushroom",
"AviatorGlasses",
"B95",
"BDUJacket",
"BDUPants",
"BUISOptic",
"Bait",
"BakedBeansCan",
"BakedBeansCan_Opened",
"Balaclava3Holes_Beige",
"Balaclava3Holes_Black",
"Balaclava3Holes_Blue",
"Balaclava3Holes_Green",
"BalaclavaMask_Beige",
"BalaclavaMask_Black",
"BalaclavaMask_Blackskull",
"BalaclavaMask_Blue",
"BalaclavaMask_Green",
"BalaclavaMask_Pink",
"BalaclavaMask_White",
"BallisticHelmet_Black",
"BallisticHelmet_Green",
"BallisticHelmet_UN",
"BandageDressing",
"Bandana_Blackpattern",
"Bandana_Camopattern",
"Bandana_Greenpattern",
"Bandana_Polkapattern",
"Bandana_Redpattern",
"BarbedBaseballBat",
"BarbedWire",
"Bark_Birch",
"Bark_Oak",
"BarrelHoles_Blue",
"BarrelHoles_Green",
"BarrelHoles_Red",
"BarrelHoles_Yellow",
"Barrel_Blue",
"Barrel_Green",
"Barrel_Red",
"Barrel_Yellow",
"BaseRadio",
"BaseballBat",
"BaseballCap_Beige",
"BaseballCap_Black",
"BaseballCap_Blue",
"BaseballCap_CMMG_Black",
"BaseballCap_CMMG_Pink",
"BaseballCap_Camo",
"BaseballCap_Olive",
"BaseballCap_Pink",
"BaseballCap_Red",
"Battery9V",
"BatteryCharger",
"BeanieHat_Beige",
"BeanieHat_Black",
"BeanieHat_Blue",
"BeanieHat_Brown",
"BeanieHat_Green",
"BeanieHat_Grey",
"BeanieHat_Pink",
"BeanieHat_Red",
"BearPelt",
"BearSteakMeat",
"BearTrap",
"Bear_Beige",
"Bear_Dark",
"Bear_Pink",
"Bear_White",
"Binoculars",
"Bitterlings",
"BloodBagEmpty",
"BloodBagFull",
"BloodBagIV",
"BloodTestKit",
"Blouse_Blue",
"Blouse_Green",
"Blouse_Violet",
"Blouse_White",
"Blowtorch",
"BoarSteakMeat",
"BoletusMushroom",
"BomberJacket_Black",
"BomberJacket_Blue",
"BomberJacket_Brown",
"BomberJacket_Grey",
"BomberJacket_Maroon",
"BomberJacket_Olive",
"BomberJacket_SkyBlue",
"Bone",
"BoneBait",
"BoneHook",
"BoneKnife",
"Bonfire",
"BoonieHat_Black",
"BoonieHat_Blue",
"BoonieHat_DPM",
"BoonieHat_Dubok",
"BoonieHat_Flecktran",
"BoonieHat_NavyBlue",
"BoonieHat_Olive",
"BoonieHat_Orange",
"BoonieHat_Red",
"BoonieHat_Tan",
"BoxCerealCrunchin",
"BrassKnuckles_Dull",
"BrassKnuckles_Shiny",
"Breeches_Beetcheck",
"Breeches_Beige",
"Breeches_Black",
"Breeches_Blackcheck",
"Breeches_Blue",
"Breeches_Browncheck",
"Breeches_Green",
"Breeches_Pink",
"Breeches_Red",
"Breeches_White",
"BrisketSpread",
"BrisketSpread_Opened",
"Broom",
"Broom_Birch",
"BurlapSack",
"BurlapSackCover",
"BurlapStrip",
"CZ527",
"CZ550",
"CZ61",
"CZ75",
"CableReel",
"Camonet",
"CanOpener",
"Candycane_Green",
"Candycane_Red",
"Candycane_RedGreen",
"Candycane_Yellow",
"CaninaBerry",
"CanisterGasoline",
"Canteen",
"CanvasBag_Medical",
"CanvasBag_Olive",
"CanvasPantsMidi_Beige",
"CanvasPantsMidi_Blue",
"CanvasPantsMidi_Grey",
"CanvasPantsMidi_Red",
"CanvasPantsMidi_Violet",
"CanvasPants_Beige",
"CanvasPants_Blue",
"CanvasPants_Grey",
"CanvasPants_Red",
"CanvasPants_Violet",
"CarBattery",
"CarRadiator",
"CarTent",
"CargoPants_Beige",
"CargoPants_Black",
"CargoPants_Blue",
"CargoPants_Green",
"CargoPants_Grey",
"Carp",
"CarpFilletMeat",
"CatFoodCan",
"CatFoodCan_Opened",
"Cauldron",
"Chainmail",
"Chainmail_Coif",
"Chainmail_Leggings",
"CharcoalTablets",
"Chemlight_Blue",
"Chemlight_Green",
"Chemlight_Red",
"Chemlight_White",
"Chemlight_Yellow",
"ChernarusMap",
"ChernarusMap_Open",
"ChernarusSportShirt",
"ChestHolster",
"Chestplate",
"ChickenBreastMeat",
"ChickenFeather",
"ChildBag_Blue",
"ChildBag_Green",
"ChildBag_Red",
"Chips",
"ChristmasHeadband_Antlers",
"ChristmasHeadband_Gingerbread",
"ChristmasHeadband_Trees",
"ClaymoreMine",
"Cleaver",
"Colt1911",
"CombatBoots_Beige",
"CombatBoots_Black",
"CombatBoots_Brown",
"CombatBoots_Green",
"CombatBoots_Grey",
"CombatKnife",
"CombinationLock",
"CombinationLock4",
"Compass",
"ConstructionHelmet_Blue",
"ConstructionHelmet_Lime",
"ConstructionHelmet_Orange",
"ConstructionHelmet_Red",
"ConstructionHelmet_White",
"ConstructionHelmet_Yellow",
"CookingStand",
"CourierBag",
"CowPelt",
"CowSteakMeat",
"CowboyHat_Brown",
"CowboyHat_black",
"CowboyHat_darkBrown",
"CowboyHat_green",
"CoyoteBag_Brown",
"CoyoteBag_Green",
"Crackers",
"CrookedNose",
"Crossbow_Autumn",
"Crossbow_Black",
"Crossbow_Summer",
"Crossbow_Wood",
"Crowbar",
"CrudeMachete",
"DarkMotoHelmet_Black",
"DarkMotoHelmet_Blue",
"DarkMotoHelmet_Green",
"DarkMotoHelmet_Grey",
"DarkMotoHelmet_Lime",
"DarkMotoHelmet_Red",
"DarkMotoHelmet_White",
"DarkMotoHelmet_Yellow",
"DarkMotoHelmet_YellowScarred",
"DeadChicken_Brown",
"DeadChicken_Spotted",
"DeadChicken_White",
"DeadRabbit",
"DeadRooster",
"Deagle",
"Deagle_Gold",
"DeerPelt",
"DeerSteakMeat",
"DenimJacket",
"Derringer_Black",
"Derringer_Grey",
"Derringer_Pink",
"DesignerGlasses",
"DirtBikeHelmet_Black",
"DirtBikeHelmet_Blue",
"DirtBikeHelmet_Chernarus",
"DirtBikeHelmet_Green",
"DirtBikeHelmet_Khaki",
"DirtBikeHelmet_Mouthguard",
"DirtBikeHelmet_Police",
"DirtBikeHelmet_Red",
"DirtBikeHelmet_Visor",
"DisinfectantAlcohol",
"DisinfectantSpray",
"DogFoodCan",
"DogFoodCan_Opened",
"DressShoes_Beige",
"DressShoes_Black",
"DressShoes_Brown",
"DressShoes_Sunburst",
"DressShoes_White",
"DryBag_Black",
"DryBag_Blue",
"DryBag_Green",
"DryBag_Orange",
"DryBag_Red",
"DryBag_Yellow",
"DrysackBag_Green",
"DrysackBag_Orange",
"DrysackBag_Yellow",
"DuctTape",
"DuffelBagSmall_Camo",
"DuffelBagSmall_Green",
"DuffelBagSmall_Medical",
"EasterEgg",
"ElectronicRepairKit",
"Engraved1911",
"Epinephrine",
"EpoxyPutty",
"EyeMask_Black",
"EyeMask_Blue",
"EyeMask_Christmas",
"EyeMask_Dead",
"EyeMask_NewYears",
"EyeMask_Red",
"EyeMask_Valentines",
"EyeMask_Yellow",
"EyePatch_Improvised",
"FAL",
"FAMAS",
"FNP45_MRDSOptic",
"FNX45",
"Fabric",
"FaceCover_Improvised",
"Fal_FoldingBttstck",
"Fal_OeBttstck",
"FangeKnife",
"FarmingHoe",
"FeetCover_Improvised",
"Fence",
"FenceKit",
"FieldShovel",
"FirefighterAxe",
"FirefighterAxe_Black",
"FirefighterAxe_Green",
"FirefighterJacket_Beige",
"FirefighterJacket_Black",
"FirefightersHelmet_Red",
"FirefightersHelmet_White",
"FirefightersHelmet_Yellow",
"FirefightersPants_Beige",
"FirefightersPants_Black",
"Fireplace",
"FireplaceIndoor",
"Firewood",
"FireworksLauncher",
"FirstAidKit",
"FishNetTrap",
"FishingRod",
"Flag_APA",
"Flag_Altis",
"Flag_BabyDeer",
"Flag_Bear",
"Flag_Bohemia",
"Flag_BrainZ",
"Flag_CDF",
"Flag_CHEL",
"Flag_CMC",
"Flag_Cannibals",
"Flag_Chedaki",
"Flag_Chernarus",
"Flag_Crook",
"Flag_DayZ",
"Flag_HunterZ",
"Flag_Livonia",
"Flag_LivoniaArmy",
"Flag_LivoniaPolice",
"Flag_NAPA",
"Flag_NSahrani",
"Flag_Pirates",
"Flag_RSTA",
"Flag_Refuge",
"Flag_Rex",
"Flag_Rooster",
"Flag_SSahrani",
"Flag_Snake",
"Flag_TEC",
"Flag_UEC",
"Flag_White",
"Flag_Wolf",
"Flag_Zagorky",
"Flag_Zenit",
"Flaregun",
"FlashGrenade",
"Flashlight",
"FlatCap_Black",
"FlatCap_BlackCheck",
"FlatCap_Blue",
"FlatCap_Brown",
"FlatCap_BrownCheck",
"FlatCap_Grey",
"FlatCap_GreyCheck",
"FlatCap_Red",
"FryingPan",
"FurCourierBag",
"FurImprovisedBag",
"GP5GasMask",
"GPSReceiver",
"GardenLime",
"GardenPlot",
"GardenPlotGreenhouse",
"GardenPlotPolytunnel",
"GasMask",
"GasMask_Filter",
"GasMask_Filter_Improvised",
"GhillieAtt_Mossy",
"GhillieAtt_Tan",
"GhillieAtt_Woodland",
"GhillieBushrag_Mossy",
"GhillieBushrag_Tan",
"GhillieBushrag_Woodland",
"GhillieHood_Mossy",
"GhillieHood_Tan",
"GhillieHood_Woodland",
"GhillieSuit_Mossy",
"GhillieSuit_Tan",
"GhillieSuit_Woodland",
"GhillieTop_Mossy",
"GhillieTop_Tan",
"GhillieTop_Woodland",
"GiftBox_Large_1",
"GiftBox_Large_2",
"GiftBox_Large_3",
"GiftBox_Large_4",
"GiftBox_Medium_1",
"GiftBox_Medium_2",
"GiftBox_Medium_3",
"GiftBox_Medium_4",
"GiftBox_Small_1",
"GiftBox_Small_2",
"GiftBox_Small_3",
"GiftBox_Small_4",
"GiftWrapPaper",
"Glock19",
"GlowPlug",
"GoatPelt",
"GoatSteakMeat",
"GorkaEJacket_Autumn",
"GorkaEJacket_Flat",
"GorkaEJacket_PautRev",
"GorkaEJacket_Summer",
"GorkaHelmet",
"GorkaHelmetVisor",
"GorkaPants_Autumn",
"GorkaPants_Flat",
"GorkaPants_PautRev",
"GorkaPants_Summer",
"GreatHelm",
"GreenBellPepper",
"Grenade_ChemGas",
"Guts",
"Hacksaw",
"Hammer",
"HandDrillKit",
"HandSaw",
"HandcuffKeys",
"Handcuffs",
"HandcuffsLocked",
"HandsCover_Improvised",
"Hatchet",
"HeadCover_Improvised",
"HeadlightH7",
"HeadlightH7_Box",
"Headtorch_Black",
"Headtorch_Grey",
"Heatpack",
"HighCapacityVest_Black",
"HighCapacityVest_Olive",
"HikingBootsLow_Beige",
"HikingBootsLow_Black",
"HikingBootsLow_Blue",
"HikingBootsLow_Grey",
"HikingBoots_Black",
"HikingBoots_Brown",
"HikingJacket_Black",
"HikingJacket_Blue",
"HikingJacket_Green",
"HikingJacket_Red",
"HipPack_Black",
"HipPack_Green",
"HipPack_Medical",
"HipPack_Party",
"HockeyHelmet_Black",
"HockeyHelmet_Blue",
"HockeyHelmet_Red",
"HockeyHelmet_White",
"HockeyMask",
"Honey",
"Hoodie_Black",
"Hoodie_Blue",
"Hoodie_Brown",
"Hoodie_Green",
"Hoodie_Grey",
"Hoodie_Red",
"Hook",
"HumanSteakMeat",
"HunterPants_Autumn",
"HunterPants_Brown",
"HunterPants_Spring",
"HunterPants_Summer",
"HunterPants_Winter",
"HuntingBag",
"HuntingBag_Hannah",
"HuntingJacket_Autumn",
"HuntingJacket_Brown",
"HuntingJacket_Spring",
"HuntingJacket_Summer",
"HuntingJacket_Winter",
"HuntingKnife",
"HuntingOptic",
"HuntingVest",
"ImprovisedBag",
"ImprovisedExplosive",
"ImprovisedFishingRod",
"ImprovisedSuppressor",
"IodineTincture",
"Izh18",
"Izh18Shotgun",
"Izh43Shotgun",
"Jeans_Black",
"Jeans_Blue",
"Jeans_BlueDark",
"Jeans_Brown",
"Jeans_Green",
"Jeans_Grey",
"JoggingShoes_Black",
"JoggingShoes_Blue",
"JoggingShoes_Red",
"JoggingShoes_Violet",
"JoggingShoes_White",
"JumpsuitJacket_Blue",
"JumpsuitJacket_Gray",
"JumpsuitJacket_Green",
"JumpsuitJacket_Red",
"JumpsuitPants_Blue",
"JumpsuitPants_Green",
"JumpsuitPants_Grey",
"JumpsuitPants_Red",
"JungleBoots_Beige",
"JungleBoots_Black",
"JungleBoots_Brown",
"JungleBoots_Green",
"JungleBoots_Olive",
"KashtanOptic",
"KazuarOptic",
"KitchenKnife",
"KitchenTimer",
"KobraOptic",
"KukriKnife",
"LabCoat",
"LactariusMushroom",
"LandMineTrap",
"Lard",
"LargeGasCanister",
"LargeTent",
"LeatherBelt_Beige",
"LeatherBelt_Black",
"LeatherBelt_Brown",
"LeatherBelt_Natural",
"LeatherGloves_Beige",
"LeatherGloves_Black",
"LeatherGloves_Brown",
"LeatherGloves_Natural",
"LeatherHat_Beige",
"LeatherHat_Black",
"LeatherHat_Brown",
"LeatherHat_Natural",
"LeatherJacket_Beige",
"LeatherJacket_Black",
"LeatherJacket_Brown",
"LeatherJacket_Natural",
"LeatherKnifeSheath",
"LeatherPants_Beige",
"LeatherPants_Black",
"LeatherPants_Brown",
"LeatherPants_Natural",
"LeatherSack_Beige",
"LeatherSack_Black",
"LeatherSack_Brown",
"LeatherSack_Natural",
"LeatherSewingKit",
"LeatherShirt_Natural",
"LeatherShoes_Beige",
"LeatherShoes_Black",
"LeatherShoes_Brown",
"LeatherShoes_Natural",
"LeatherStorageVest_Beige",
"LeatherStorageVest_Black",
"LeatherStorageVest_Brown",
"LeatherStorageVest_Natural",
"LegsCover_Improvised",
"Lockpick",
"LongTorch",
"LongWoodenStick",
"Longhorn",
"LugWrench",
"Lunchmeat",
"Lunchmeat_Opened",
"M14",
"M16A2",
"M18SmokeGrenade_Green",
"M18SmokeGrenade_Purple",
"M18SmokeGrenade_Red",
"M18SmokeGrenade_White",
"M18SmokeGrenade_Yellow",
"M4A1",
"M4A1_Black",
"M4A1_Green",
"M4_CQBBttstck",
"M4_CarryHandleOptic",
"M4_MPBttstck",
"M4_MPHndgrd",
"M4_OEBttstck",
"M4_PlasticHndgrd",
"M4_RISHndgrd",
"M4_RISHndgrd_Black",
"M4_RISHndgrd_Green",
"M4_Suppressor",
"M4_T3NRDSOptic",
"M65Jacket_Black",
"M65Jacket_Khaki",
"M65Jacket_Olive",
"M65Jacket_Tan",
"M67Grenade",
"M68Optic",
"M79",
"M9A1_Bayonet",
"MKII",
"MP5K",
"MP5_Compensator",
"MP5_PlasticHndgrd",
"MP5_RailHndgrd",
"MP5k_StockBttstck",
"Mace",
"Machete",
"Mackerel",
"MackerelFilletMeat",
"MacrolepiotaMushroom",
"Mag_1911_7Rnd",
"Mag_AK101_30Rnd",
"Mag_AK74_30Rnd",
"Mag_AK74_45Rnd",
"Mag_AKM_30Rnd",
"Mag_AKM_Drum75Rnd",
"Mag_AKM_Palm30Rnd",
"Mag_Aug_30Rnd",
"Mag_CMAG_10Rnd",
"Mag_CMAG_20Rnd",
"Mag_CMAG_30Rnd",
"Mag_CMAG_40Rnd",
"Mag_CZ527_5rnd",
"Mag_CZ550_10Rnd",
"Mag_CZ61_20Rnd",
"Mag_CZ75_15Rnd",
"Mag_Deagle_9rnd",
"Mag_FAL_20Rnd",
"Mag_FAMAS_25Rnd",
"Mag_FNX45_15Rnd",
"Mag_Glock_15Rnd",
"Mag_IJ70_8Rnd",
"Mag_M14_10Rnd",
"Mag_M14_20Rnd",
"Mag_MKII_10Rnd",
"Mag_MP5_15Rnd",
"Mag_MP5_30Rnd",
"Mag_P1_8Rnd",
"Mag_PP19_64Rnd",
"Mag_Ruger1022_15Rnd",
"Mag_Ruger1022_30Rnd",
"Mag_SSG82_5rnd",
"Mag_STANAG_30Rnd",
"Mag_STANAG_60Rnd",
"Mag_SVD_10Rnd",
"Mag_Saiga_5Rnd",
"Mag_Saiga_8Rnd",
"Mag_Saiga_Drum20Rnd",
"Mag_Scout_5Rnd",
"Mag_UMP_25Rnd",
"Mag_VAL_20Rnd",
"Mag_VSS_10Rnd",
"Magnum",
"MakarovIJ70",
"ManSuit_Beige",
"ManSuit_Black",
"ManSuit_Blue",
"ManSuit_Brown",
"ManSuit_DarkGrey",
"ManSuit_Khaki",
"ManSuit_LightGrey",
"ManSuit_White",
"Marmalade",
"Matchbox",
"MeatTenderizer",
"MedicalScrubsHat_Blue",
"MedicalScrubsHat_Green",
"MedicalScrubsHat_White",
"MedicalScrubsPants_Blue",
"MedicalScrubsPants_Green",
"MedicalScrubsPants_White",
"MedicalScrubsShirt_Blue",
"MedicalScrubsShirt_Green",
"MedicalScrubsShirt_White",
"MedievalBoots",
"MediumGasCanister",
"MediumTent",
"MediumTent_Green",
"MediumTent_Orange",
"Megaphone",
"MetalPlate",
"MetalWire",
"Mich2001Helmet",
"MilitaryBelt",
"MilitaryBeret_CDF",
"MilitaryBeret_ChDKZ",
"MilitaryBeret_NZ",
"MilitaryBeret_Red",
"MilitaryBeret_UN",
"MilitaryBoots_Beige",
"MilitaryBoots_Black",
"MilitaryBoots_Bluerock",
"MilitaryBoots_Brown",
"MilitaryBoots_Redpunk",
"MimeMask_Female",
"MimeMask_Male",
"MiniDress_BlueChecker",
"MiniDress_BlueWithDots",
"MiniDress_BrownChecker",
"MiniDress_GreenChecker",
"MiniDress_Pink",
"MiniDress_PinkChecker",
"MiniDress_RedChecker",
"MiniDress_WhiteChecker",
"MorozkoHat",
"Morphine",
"Mosin9130",
"Mosin9130_Black",
"Mosin9130_Camo",
"Mosin9130_Green",
"Mosin_Bayonet",
"Mosin_Compensator",
"MotoHelmet_Black",
"MotoHelmet_Blue",
"MotoHelmet_Green",
"MotoHelmet_Grey",
"MotoHelmet_Lime",
"MotoHelmet_Red",
"MotoHelmet_White",
"MotoHelmet_Yellow",
"MountainBag_Blue",
"MountainBag_Green",
"MountainBag_Orange",
"MountainBag_Red",
"MouthRag",
"Mp133Shotgun",
"NBCBootsGray",
"NBCBootsYellow",
"NBCGlovesGray",
"NBCGlovesYellow",
"NBCHoodGray",
"NBCHoodYellow",
"NBCJacketGray",
"NBCJacketYellow",
"NBCPantsGray",
"NBCPantsYellow",
"NVGHeadstrap",
"NVGoggles",
"Nail",
"NailBox",
"NailedBaseballBat",
"Netting",
"NioshFaceMask",
"NorseHelm",
"NurseDress_Blue",
"NurseDress_White",
"NylonKnifeSheath",
"OKZKCap_Beige",
"OKZKCap_Green",
"OMNOGloves_Brown",
"OMNOGloves_Gray",
"OfficerHat",
"OrientalMachete",
"OrienteeringCompass",
"P1",
"PP19",
"PP19_Bttstck",
"PSO11Optic",
"PSO1Optic",
"PUScopeOptic",
"PaddedGloves_Beige",
"PaddedGloves_Brown",
"PaddedGloves_Threat",
"PainkillerTablets",
"Pajka",
"Pajka_Opened",
"Paper",
"ParamedicJacket_Blue",
"ParamedicJacket_Crimson",
"ParamedicJacket_Green",
"ParamedicPants_Blue",
"ParamedicPants_Crimson",
"ParamedicPants_Green",
"PartyTent",
"PartyTent_Blue",
"PartyTent_Brown",
"PartyTent_Lunapark",
"Pate",
"Pate_Opened",
"PeachesCan",
"PeachesCan_Opened",
"Pear",
"Pen_Black",
"Pen_Blue",
"Pen_Green",
"Pen_Red",
"PepperSeeds",
"PepperSeedsPack",
"PersonalRadio",
"PetrolLighter",
"PetushokHat_Black",
"PetushokHat_Green",
"PetushokHat_Yellow",
"Pickaxe",
"PigPelt",
"PigSteakMeat",
"PileOfWoodenPlanks",
"PilotkaCap",
"Pipe",
"PipeWrench",
"PistolOptic",
"PistolSuppressor",
"Pitchfork",
"PlantMaterial",
"Plant_Pepper",
"Plant_Potato",
"Plant_Pumpkin",
"Plant_Tomato",
"Plant_Zucchini",
"Plastic_Explosive",
"PlateCarrierHolster",
"PlateCarrierHolster_Black",
"PlateCarrierHolster_Camo",
"PlateCarrierHolster_Green",
"PlateCarrierPouches",
"PlateCarrierPouches_Black",
"PlateCarrierPouches_Camo",
"PlateCarrierPouches_Green",
"PlateCarrierVest",
"PlateCarrierVest_Black",
"PlateCarrierVest_Camo",
"PlateCarrierVest_Green",
"PleurotusMushroom",
"Pliers",
"Plum",
"PoliceCap",
"PoliceJacket",
"PoliceJacketOrel",
"PolicePants",
"PolicePantsOrel",
"PoliceVest",
"PorkCan",
"PorkCan_Opened",
"PortableGasLamp",
"PortableGasStove",
"Pot",
"Potato",
"PotatoSeed",
"PowderedMilk",
"PowerGenerator",
"PressVest_Blue",
"PressVest_LightBlue",
"PrisonUniformJacket",
"PrisonUniformPants",
"PrisonerCap",
"Pumpkin",
"PumpkinHelmet",
"PumpkinSeeds",
"PumpkinSeedsPack",
"PurificationTablets",
"QuiltedJacket_Black",
"QuiltedJacket_Blue",
"QuiltedJacket_Green",
"QuiltedJacket_Grey",
"QuiltedJacket_Orange",
"QuiltedJacket_Red",
"QuiltedJacket_Violet",
"QuiltedJacket_Yellow",
"RDG2SmokeGrenade_Black",
"RDG2SmokeGrenade_White",
"RGD5Grenade",
"RabbitLegMeat",
"RabbitPelt",
"RabbitSnareTrap",
"RadarCap_Black",
"RadarCap_Blue",
"RadarCap_Brown",
"RadarCap_Green",
"RadarCap_Red",
"Rag",
"Raincoat_Black",
"Raincoat_Blue",
"Raincoat_Green",
"Raincoat_Orange",
"Raincoat_Pink",
"Raincoat_Red",
"Raincoat_Yellow",
"Rangefinder",
"ReflexOptic",
"ReflexVest",
"RemoteDetonator",
"RemoteDetonatorReceiver",
"RemoteDetonatorTrigger",
"Repeater",
"Rice",
"RidersJacket_Black",
"Roadflare",
"Rope",
"RopeBelt",
"Ruger1022",
"SKS",
"SKS_Bayonet",
"SSG82",
"SVD",
"Saiga",
"Saiga_Bttstck",
"SalineBag",
"SalineBagIV",
"SaltySticks",
"SambucusBerry",
"SantasBeard",
"SantasHat",
"Sardines",
"SardinesCan",
"SardinesCan_Opened",
"SawedoffB95",
"SawedoffFAMAS",
"SawedoffIzh18",
"SawedoffIzh18Shotgun",
"SawedoffIzh43Shotgun",
"SawedoffMagnum",
"SawedoffMosin9130",
"SawedoffMosin9130_Black",
"SawedoffMosin9130_Camo",
"SawedoffMosin9130_Green",
"Scout",
"Scout_Chernarus",
"Scout_Livonia",
"Screwdriver",
"SeaChest",
"SewingKit",
"SharpWoodenStick",
"SheepPelt",
"SheepSteakMeat",
"ShelterFabric",
"ShelterKit",
"ShelterLeather",
"ShelterSite",
"ShelterStick",
"Shirt_BlueCheck",
"Shirt_BlueCheckBright",
"Shirt_GreenCheck",
"Shirt_PlaneBlack",
"Shirt_RedCheck",
"Shirt_WhiteCheck",
"ShortJeans_Black",
"ShortJeans_Blue",
"ShortJeans_Brown",
"ShortJeans_Darkblue",
"ShortJeans_Green",
"ShortJeans_Red",
"Shovel",
"Sickle",
"SkateHelmet_Black",
"SkateHelmet_Blue",
"SkateHelmet_Gray",
"SkateHelmet_Green",
"SkateHelmet_Red",
"Skirt_Blue",
"Skirt_Red",
"Skirt_White",
"Skirt_Yellow",
"SlacksPants_Beige",
"SlacksPants_Black",
"SlacksPants_Blue",
"SlacksPants_Brown",
"SlacksPants_DarkGrey",
"SlacksPants_Khaki",
"SlacksPants_LightGrey",
"SlacksPants_White",
"SledgeHammer",
"SlicedPumpkin",
"Slingbag_Black",
"Slingbag_Brown",
"Slingbag_Gray",
"SmallFishTrap",
"SmallGasCanister",
"SmallGuts",
"SmallProtectorCase",
"SmallStone",
"SmershBag",
"SmershVest",
"Sneakers_Black",
"Sneakers_Gray",
"Sneakers_Green",
"Sneakers_Red",
"Sneakers_White",
"SodaCan_Cola",
"SodaCan_Fronta",
"SodaCan_Kvass",
"SodaCan_Pipsi",
"SodaCan_Spite",
"SpaghettiCan",
"SpaghettiCan_Opened",
"SparkPlug",
"SpearBone",
"SpearStone",
"Splint",
"Splint_Applied",
"SportGlasses_Black",
"SportGlasses_Blue",
"SportGlasses_Green",
"SportGlasses_Orange",
"Spotlight",
"Ssh68Helmet",
"StarlightOptic",
"StartKitIV",
"SteakKnife",
"Stone",
"StoneKnife",
"SurgicalGloves_Blue",
"SurgicalGloves_Green",
"SurgicalGloves_LightBlue",
"SurgicalGloves_White",
"SurgicalMask",
"Sweater_Blue",
"Sweater_Gray",
"Sweater_Green",
"Sweater_Red",
"Sword",
"TLRLight",
"TShirt_Beige",
"TShirt_Black",
"TShirt_Blue",
"TShirt_Green",
"TShirt_Grey",
"TShirt_OrangeWhiteStripes",
"TShirt_Red",
"TShirt_RedBlackStripes",
"TShirt_White",
"TTSKOBoots",
"TTSKOPants",
"TTsKOJacket_Camo",
"TacticalBaconCan",
"TacticalBaconCan_Opened",
"TacticalGloves_Beige",
"TacticalGloves_Black",
"TacticalGloves_Green",
"TacticalGoggles",
"TacticalShirt_Black",
"TacticalShirt_Grey",
"TacticalShirt_Olive",
"TacticalShirt_Tan",
"TaloonBag_Blue",
"TaloonBag_Green",
"TaloonBag_Orange",
"TaloonBag_Violet",
"TankerHelmet",
"TannedLeather",
"TelnyashkaShirt",
"TerritoryFlag",
"TerritoryFlagKit",
"TetracyclineAntibiotics",
"Thermometer",
"ThickFramesGlasses",
"ThinFramesGlasses",
"TireRepairKit",
"Tomato",
"TomatoSeeds",
"TomatoSeedsPack",
"Torch",
"TorsoCover_Improvised",
"TortillaBag",
"TrackSuitJacket_Black",
"TrackSuitJacket_Blue",
"TrackSuitJacket_Green",
"TrackSuitJacket_LightBlue",
"TrackSuitJacket_Red",
"TrackSuitPants_Black",
"TrackSuitPants_Blue",
"TrackSuitPants_Green",
"TrackSuitPants_LightBlue",
"TrackSuitPants_Red",
"Tripod",
"TripwireTrap",
"TruckBattery",
"Tshirt_10thAnniversary",
"TunaCan",
"TunaCan_Opened",
"UKAssVest_Black",
"UKAssVest_Camo",
"UKAssVest_Khaki",
"UKAssVest_Olive",
"UMP45",
"USMCJacket_Desert",
"USMCJacket_Woodland",
"USMCPants_Desert",
"USMCPants_Woodland",
"UndergroundStash",
"UniversalLight",
"UnknownFoodCan",
"UnknownFoodCan_Opened",
"Ushanka_Black",
"Ushanka_Blue",
"Ushanka_Green",
"VSS",
"VitaminBottle",
"Watchtower",
"WatchtowerKit",
"WaterBottle",
"WaterproofBag_Green",
"WaterproofBag_Orange",
"WaterproofBag_Yellow",
"WeaponCleaningKit",
"WeldingMask",
"Wellies_Black",
"Wellies_Brown",
"Wellies_Green",
"Wellies_Grey",
"Whetstone",
"WildboarPelt",
"Winchester70",
"WinterCoif_Black",
"WinterCoif_Blue",
"WinterCoif_Green",
"WinterCoif_Skull",
"WitchHat",
"WitchHood_Black",
"WitchHood_Brown",
"WitchHood_Chainmail_Black",
"WitchHood_Chainmail_Brown",
"WitchHood_Chainmail_Red",
"WitchHood_Red",
"WolfPelt",
"WolfSteakMeat",
"WomanSuit_Beige",
"WomanSuit_Black",
"WomanSuit_Blue",
"WomanSuit_Brown",
"WomanSuit_DarkGrey",
"WomanSuit_Khaki",
"WomanSuit_LightGrey",
"WomanSuit_White",
"WoodAxe",
"WoodenCrate",
"WoodenLog",
"WoodenPlank",
"WoodenStick",
"WoolCoat_Beige",
"WoolCoat_Black",
"WoolCoat_BlackCheck",
"WoolCoat_Blue",
"WoolCoat_BlueCheck",
"WoolCoat_BrownCheck",
"WoolCoat_Green",
"WoolCoat_GreyCheck",
"WoolCoat_Red",
"WoolCoat_RedCheck",
"WoolGlovesFingerless_Black",
"WoolGlovesFingerless_ChristmasBlue",
"WoolGlovesFingerless_ChristmasRed",
"WoolGlovesFingerless_Green",
"WoolGlovesFingerless_Tan",
"WoolGlovesFingerless_White",
"WoolGloves_Black",
"WoolGloves_ChristmasBlue",
"WoolGloves_ChristmasRed",
"WoolGloves_Green",
"WoolGloves_Tan",
"WoolGloves_White",
"WorkingBoots_Beige",
"WorkingBoots_Brown",
"WorkingBoots_Green",
"WorkingBoots_Grey",
"WorkingBoots_Yellow",
"WorkingGloves_Beige",
"WorkingGloves_Black",
"WorkingGloves_Brown",
"WorkingGloves_Yellow",
"Wrench",
"XmasLights",
"ZSh3PilotHelmet",
"Zagorky",
"ZagorkyChocolate",
"ZagorkyPeanuts",
"ZmijovkaCap_Black",
"ZmijovkaCap_Blue",
"ZmijovkaCap_Brown",
"ZmijovkaCap_Green",
"ZmijovkaCap_Red",
"Zucchini",
"ZucchiniSeeds",
"ZucchiniSeedsPack"
 };

        //creates a list of complexchildrentypes
       private static List<ComplexChildrenType> children = new List<ComplexChildrenType>();

        //creates an update list of objects based on user slection
       private static List<ComplexChildrenType> userComplexList = new List<ComplexChildrenType>();

        //Creates a list for simplechildren items
        private static List<String> userSimpleChildrenList = new List<String>();

        //Creates a method that when called retuns the updated user list
        public List<ComplexChildrenType> UserEditedComplexChildrenList()
        {  return userComplexList; }

        //method that returns simplechildren list
        public List<String> UserEditedSimpleChildrenList()
        { return userSimpleChildrenList; }

        public frmEdit()
        {
            InitializeComponent();
        }


        //Calls 2 ftn, one to create a ComplexChild list of objects from the item string list, the other to populate dgv with info
        //Also assigns 2 events to ftns so they are called when event is triggered
        private void frmEdit_Load(object sender, EventArgs e)
        {
            ComplexChildrenListCreation();

            DataGridPopulation();

            //This is the event \/ it is being attached to this ftn \/, so on form load it ensures that whenever this event is triggered ftn is called
            dgvItems.CurrentCellDirtyStateChanged += dgvItems_CurrentCellDirtyStateChanged;

            dgvItems.EditingControlShowing += DataGridView_EditingControlShowing;
        }

        private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Checks if the current control is a TextBox
            if (e.Control is TextBox)
            {
                TextBox textBox = (TextBox)e.Control;

                // Removes any existing event handler to avoid multiple subscriptions
                textBox.KeyPress -= TextBox_KeyPress;

                // Add the TextBox_KeyPress event handler
                textBox.KeyPress += TextBox_KeyPress;
            }
        }

        //ensures that only ints between -1 and 30 can be entered in text boxes
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int minValue = -1;
            int maxValue = 30;

            TextBox textBox = (TextBox)sender;

            // Allow backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Only allow digits, '-' at the beginning, and control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '-' && textBox.SelectionStart == 0 && !textBox.Text.Contains('-')))
            {
                e.Handled = true;
                return;
            }

            // Get the current text without the selected portion
            string newText = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength);

            // Insert the new character at the correct position
            newText = newText.Insert(textBox.SelectionStart, e.KeyChar.ToString());

            // Check if it's a valid integer or '-' at the beginning
            if (!int.TryParse(newText, out int value) && !(e.KeyChar == '-' && textBox.SelectionStart == 0 && !textBox.Text.Contains('-')))
            {
                e.Handled = true;
                return;
            }

            // Check if it's within the range
            if (value < minValue || value > maxValue)
            {
                e.Handled = true;
                return;
            }
        }

        //Sent: Nil
        //Returned: Nil
        //Description: Sends in data to DGV columns
        private void DataGridPopulation()
        {
            //adds each object in list to a row
            foreach (ComplexChildrenType listItem in children)
            {
                // Create a new row variable from DGVrow ftn
                DataGridViewRow row = new DataGridViewRow();

                // Use a CheckBox cell for the boolean column
                DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();
                row.Cells.Add(checkBoxCell);

                // Creates and populates the ItemType cell
                row.Cells.Add(new DataGridViewTextBoxCell { Value = listItem.itemType });

                DataGridViewTextBoxCell quantityCell = new DataGridViewTextBoxCell();
                quantityCell.Value = 0;
                row.Cells.Add(quantityCell);

                // Creates and populates HS cell, all init values should be -1
                row.Cells.Add(new DataGridViewTextBoxCell { Value = listItem.quickBarSlot });

                // Add the row to the DataGridView
                dgvItems.Rows.Add(row);
            }
        }


        //Sent: Nil
        //Return: Nil
        //Description: Creates a string list from all the items, then creates a list of complexchildrentype
        //             objects with item names entered all other values default
        private static void ComplexChildrenListCreation()
        {
            //foreach loop that creates an object of the complexchildrentype for each string in list, then adds each one to complexchildrentype list
            foreach (string item in list)
            {
                if (item != null)
                {
                    //Creates new object sends in itemType as a string, then adds to object list
                    ComplexChildrenType listItem = new ComplexChildrenType(item);
                    children.Add(listItem);
                }
            }
        }

        //Resets all values to default by calling population ftn, repopulates the dgv with og list
        //Also clears all lists
        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvItems.Rows.Clear();
            DataGridPopulation();
            userComplexList.Clear();
            userSimpleChildrenList.Clear();
        }


        //ftn that changes the value of quantitycol to one if add is clicked, ensures no errors, if user wants to add they need 1 item
        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvItems.IsCurrentCellDirty)
            {
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Handle the change in the committed cell value
                DataGridViewCheckBoxCell checkboxCell = dgvItems.CurrentCell as DataGridViewCheckBoxCell;

                if (checkboxCell != null && checkboxCell.OwningColumn.Name == "AddCol")
                {
                    bool isChecked = (bool)checkboxCell.Value;

                    // Update TextBox value based on checkbox state
                    if (isChecked)
                    {
                        dgvItems.CurrentRow.Cells["QuantityCol"].Value = 1;
                    }
                    else
                    {
                        // You can set a different value if the checkbox is unchecked
                        dgvItems.CurrentRow.Cells["QuantityCol"].Value = 0;
                    }

                }
            }
        }

        //Parses user selection and creates new ComplexChildrenType list, then closes the form
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //assigns the dialog result ok to this button click
            this.DialogResult = DialogResult.OK;

            //clears lists so duplicates arent added
            userComplexList.Clear();
            userSimpleChildrenList.Clear();

            foreach (DataGridViewRow row in dgvItems.Rows)
            {

                //creates variables from converted data from dgv
                string itemName = row.Cells["ItemCol"].Value.ToString();
                int hotSlot = Convert.ToInt32(row.Cells["HSCol"].Value);
                bool add = Convert.ToBoolean(row.Cells["AddCol"].Value);
                int quantity = Convert.ToInt32(row.Cells["QuantityCol"].Value);

                ComplexChildrenType userobject = new ComplexChildrenType(itemName, hotSlot);

                if (add && hotSlot > -1)
                {
                    //adds new item for quantity selected - may cause error multiple items same hotslot
                    for (int i = 0; i < quantity; i++)
                    {
                        userComplexList.Add(userobject);
                    }

                }

                if (add && hotSlot == -1)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        userSimpleChildrenList.Add(itemName);
                    }
                }
            }
                     
            /*Tests updated list
            foreach (ComplexChildrenType item in userComplexList)
            {
                MessageBox.Show($"ItemName: {item.itemType}, HotSlot: {item.quickBarSlot}");
            }

            foreach(string itemName in userSimpleChildrenList)
            {
                MessageBox.Show(itemName);
            } */
      
            this.Visible = false;
        }

        //searches through dgv if text in txt matches highlights and hides non matches, searchs in real time
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower(); // Convert to lowercase for case-insensitive comparison
            int columnIndex = 1;


                // Clear any previous selections
                dgvItems.ClearSelection();

                // Loop through each row in the DataGridView
                foreach (DataGridViewRow row in dgvItems.Rows)
                {

                    if (row.Cells[columnIndex].Value is string cellValue)
                    {
                        // Check if the cell value matches the search term
                        if (!string.IsNullOrEmpty(searchTerm) && cellValue.ToLower().Contains(searchTerm))
                        {
                            // Highlight the matching row
                            row.Selected = true;
                            row.Visible = true;
                        }
                        //if empty display all results
                        else if (string.IsNullOrEmpty(searchTerm)) 
                        {
                        row.Visible = true;
                        }
                        //if it does not match not vidible in dgv
                        else
                        {
                            row.Visible=false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cell value is not a string.");
                    }
                }
            

        }

        //Whenever text is changed btnclick event triggers, allows real time search results
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        //Clears search box
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        //Adds custom user item to dgv for placement into inventory list, allows user to place multiple of same item into 
        //different hot slots
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string itemName = txtAddItem.Text.Trim();
            int hotslot = Convert.ToInt32(nudHSAddItem.Value);

            //Creates new row for dgv
            DataGridViewRow row = new DataGridViewRow();

            // Use a CheckBox cell for the boolean column
            DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();
            checkBoxCell.Value = true; // Set the checkbox to be checked by default
            row.Cells.Add(checkBoxCell);

            // Creates and populates the ItemType cell
            row.Cells.Add(new DataGridViewTextBoxCell { Value = itemName });

            //Creates quantity cell and sets to 1
            DataGridViewTextBoxCell quantityCell = new DataGridViewTextBoxCell();
            quantityCell.Value = 1;
            row.Cells.Add(quantityCell);

            // Creates and populates HS cell
            row.Cells.Add(new DataGridViewTextBoxCell { Value = hotslot });

            // Add the row to the DataGridView
            dgvItems.Rows.Add(row);

            //Shows pic and lbl the calls ftn to start timer
            picCheckMark.Visible = true;
            lblAdded.Visible = true;
            timer1.Start();

        }

        //Stops the timer and hides the lbl and pic
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            picCheckMark.Visible=false;
            lblAdded.Visible=false;
        }

    }
}
