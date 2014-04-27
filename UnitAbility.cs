using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DelegateContainer
{
	public delegate void ObjectParam(ObjectContainer o);
}

public class ObjectContainer {
	public int intValue = 0;
}

public class ExternPersistentContainer
{
	public DelegateContainer.ObjectParam func;
	public Card OwnerCard;
	public ExternPersistentContainer(Card c, DelegateContainer.ObjectParam f)
	{
		OwnerCard = c;
		func = f;
	}
}

public class UnitAbility {	

	/*OMITTED*/
	List<UnitObject> ExternEffects = null;
	public UnitObject _UnitObject = null;


	/// @cond
	List<Card> cardStorage = new List<Card>();
	/// 
	public List<ExternPersistentContainer> ExternPersistent;
	bool _CFDamage_Active = false;
	public List<int> deleteExtEffectEndBattleList;
	int _H_n = 0;
	bool _H_Active = false;
	
	int _SU_n = 0;
	Void0ParamsDelegate _SU_fnc;
	delegateConstraint _SU_constraint;
	Void0ParamsDelegate _SU_fnc_end;
	bool _SU_Active = false;
	Card Unit = null;
	bool _SU_EndEffect = true;
	
	int _SIH_n = 0;
	bool _SIH_Active = false;
	Void0ParamsDelegate _SIH_fnc;
	Void0ParamsDelegate _SIH_fnc_end;
	delegateConstraint _SIH_constraint;
	bool _SIH_End = false;
	Card _SIH_Card = null;
	
	bool _PB_Active = false;
	Void0ParamsDelegate _PB_func;
	bool _PB_EndEffect = true;
	
	int _SID_n = 0;
	bool _SID_Active = false;
	Void0ParamsDelegate _SID_fnc;
	bool _SID_End = false;
	Card _SID_Card = null;
	
	Card EnemyUnit = null;
	int _CB_num = 0;
	bool _CB_Active = false;
	CounterBlastDelegate _CB_fnc;
	int ModifyRealPower = 0;
	List<Card> CallFromDeckList;
	public float DC_time = 0;
	public int DC_n = 0;
	public bool DC_bool = false;
	public Gameplay Game = null;
	public CardIdentifier id;
	public int executeAbility;
	public Card _Card;
	public Card _AuxCard = null;
	public Card _AuxCard2 = null;
	public int _Power;
	public int _Critical;
	public bool bEnablePointer = false;
	public CardState _LastCardState = CardState.None;
	public bool bResumeAttack = false;
	public bool bActivePopup = false;
	public bool _AuxBool = false;
	public bool _AuxBool2 = false;
	public bool _AuxBool3 = false;
	public bool _AuxBool4 = false;
	public bool _AuxBool5 = false;
	public bool _AuxBool6 = false;
	public int _AuxInt2 = 0;
	
	public bool _ExternBool1 = false;
	
	public int CurrentExternAbility = -1;
	public int LastExternAbility = -1;
	
	public List<Void0ParamsDelegate> ExternUpdate;

	
	public Card SC_Card = null;
	public int SC_Int = 0;
	public bool SC_Bool = false;
	
	public bool _CFS_AuxBool3 = false;
	public Card _CFS_AuxCard = null;
	
	public bool _Megablast_AuxBool2 = false;
	public bool _Megablast_AuxBool3 = false;
	public int _Megablast_AuxInt = 0;
	public Card _Megablast_AuxCard = null;
	
	public bool _SBAux_Bool1 = false;
	public bool _SBAux_Bool2 = false;
	public List<CardIdentifier> _SBAux_IDVector = null;
	public int _SBAux_Int1 = 0;
	public Card _SBAux_Card1 = null;
	
	public int _AuxInt = 0;
	public List<CardIdentifier> _AuxIdVector;
	public bool[] _AuxBool20Array;
	
	public Card OwnerCard = null;
	public bool bWindowActive = false;
	
	public int _LastPersistenPower = -1;
	public int _LastPersistenCritical = -1;
	
	public delegate void MegablastEffect();
	
	public delegate void Void0ParamsDelegate();
	public delegate void CounterBlastDelegate();
	public delegate void AutoDelegate(CardState s, Card effectOwner);
	public delegate bool delegateConstraint();
	
	public List<AutoDelegate> ExternAuto;
	
	public bool _DropCall_AuxBool = false;
	
	public List<CardIdentifier> _CFDAux_IDVector;
	public bool _CFDAux_Bool1 = false;
	public int _CFDAux_Int1 = 0;
	public Card _CFDAux_Card = null;
	
	public float _Delay_Time = 0;
	public bool _Delay_Bool = false;
	
	/// @endcond
	/// @cond
	
	public UnitAbility(Card card)
	{
		executeAbility = -1;
		OwnerCard = card;
		_AuxBool20Array  = new bool[20];
		
		ClearAuxBool20Array();
		
		ExternAuto                   = new List<AutoDelegate>();
		ExternUpdate                 = new List<Void0ParamsDelegate>();
		ExternPersistent             = new List<ExternPersistentContainer>();
		CallFromDeckList             = new List<Card>();
		ExternEffects                = new List<UnitObject>();
		deleteExtEffectEndBattleList = new List<int>();
	}
	
	public void ClearAuxBool20Array()
	{
		for(int i = 0; i < 20; i++)
		{
			_AuxBool20Array[i] = false;
		}
	}
	
	public void SetUnitObject(CardIdentifier id)
	{
		if(id == CardIdentifier.MARTIAL_ARTS_MUTANT__MASTER_BEETLE)  	   		 	        _UnitObject = new MartialArtsMutanMasterBeetle();
		else if(id == CardIdentifier.UNRIVALED_BLADE_ROGUE_CYCLOMATOOTH)                    _UnitObject = new UnrivaledBladeRogueCyclomatooth();
		else if(id == CardIdentifier.MACHINING_SPARK_HERCULES)                              _UnitObject = new MachiningSparkHercules();
		else if(id == CardIdentifier.BLUE_STORM_GUARDIAN_DRAGON_ICEFALL_DRAGON)             _UnitObject = new BlueStormGuardianDragonIcefallDragon();
		else if(id == CardIdentifier.STARVADER_FREEZE_RAY_DRAGON)                           _UnitObject = new StarvaderFreezeRayDragon();
		else if(id == CardIdentifier.DRAGON_KNIGHT_GIMEL)                                   _UnitObject = new DragonKnightGimel();
		else if(id == CardIdentifier.DRAGONIC_BURNOUT)                                      _UnitObject = new DragonicBurnout();
		else if(id == CardIdentifier.LIBERATOR_STAR_RAIN_TRUMPETER)                         _UnitObject = new LiberatorStarRainTrumpeter();
		else if(id == CardIdentifier.LIBERATOR_HOLY_SHINE_DRAGON)                           _UnitObject = new LiberatorHolyShineDragon();
		else if(id == CardIdentifier.BLACKWINGED_SWORDBREAKER)                              _UnitObject = new BlackwingedSwordbreaker();
		else if(id == CardIdentifier.HATRED_PRISON_REVENGER_KUESARU)                        _UnitObject = new HatredPrisonRevengerKuesaru();
		else if(id == CardIdentifier.REVENGER_BLOODMASTER)                                  _UnitObject = new RevengerBloodmaster();
		else if(id == CardIdentifier.BLUE_STORM_KARMA_DRAGON_MAELSTROM_REVERSE)             _UnitObject = new BlueStormKarmaDragonMaelstromReverse();
		else if(id == CardIdentifier.SILVER_THORN_DRAGON_EMPRESS_VENUS_LUQUIER)             _UnitObject = new SilverThornEmpressVenusLuquier();
		else if(id == CardIdentifier.STARVADER_REVERSE_CRADLE)                              _UnitObject = new StarvaderReverseCradle();
		else if(id == CardIdentifier.DRAGON_MONK_GOJO)                                      _UnitObject = new DragonMonkGojo();
		else if(id == CardIdentifier.DRAGONIC_OVERLORD_THE_REBIRTH)                         _UnitObject = new DragonicOverlordTheRebirth();
		else if(id == CardIdentifier.DRAGONIC_OVERLORD_BREAK_RIDE)                          _UnitObject = new DragonicOverlordBreakRide();
		else if(id == CardIdentifier.LIBERATOR_MONARCH_SANCTUARY_ALFRED)                    _UnitObject = new LiberatorMonarchSanctuaryAlfred();
		else if(id == CardIdentifier.REVENGER_DRAGRULER_PHANTOM)                            _UnitObject = new RevengerDragrulerPhantom();
		else if(id == CardIdentifier.REVENGER_DESPERATE_DRAGON)                             _UnitObject = new RevengerDesperateDragon();
		else if(id == CardIdentifier.STAR_VADER_OMEGA_GLENDIOS)                             _UnitObject = new StarVaderOmegaGlendios();
		else if(id == CardIdentifier.CRIMSON_IMPACT__METATRON)                              _UnitObject = new CrimsonImpactMetatron();
		else if(id == CardIdentifier.MAJESTY_LORD_BLASTER)                                  _UnitObject = new MajestyLordBlaster();
		else if(id == CardIdentifier.DRAGON_KNIGHT__JALAL)                                  _UnitObject = new DragonKnightJalal();
		else if(id == CardIdentifier.SPECTRAL_SHEEP)                                        _UnitObject = new SpectralSheep();
		else if(id == CardIdentifier.ORDAIN_OWL)                                            _UnitObject = new OrdainOwl();
		else if(id == CardIdentifier.GODDESS_OF_UNION__JUNO)                                _UnitObject = new GoddessOfUnionJuno();
		else if(id == CardIdentifier.MYTH_GUARD__ACHERNAR)                                  _UnitObject = new MythGuardAchemar();
		else if(id == CardIdentifier.GRAPE_WITCH__GRAPPA)                                   _UnitObject = new GrapeWitchGrappa();
		else if(id == CardIdentifier.MYTH_GUARD__DENEBOLA)                                  _UnitObject = new MythGuardDenebola();
		else if(id == CardIdentifier.BATTLE_MAIDEN__KAYANARUMI)                             _UnitObject = new BattleMaidenKayanarumi();
		else if(id == CardIdentifier.ORANGE_WITCH__VALENCIA)                                _UnitObject = new OrangeWitchValencia();
		else if(id == CardIdentifier.SCARLET_LION_CUB__CARIA)                               _UnitObject = new ScarletLionCubCaria();
		else if(id == CardIdentifier.ANGELIC_WISEMAN)                                       _UnitObject = new AngelicWiseman();
		else if(id == CardIdentifier.MYTH_GUARD__FOMALHAUT)                                 _UnitObject = new MythGuardFomalhaut();
		else if(id == CardIdentifier.FLYING_SWORD_LIBERATOR__GORLOIS)                       _UnitObject = new FlyingSwordLiberatorGorlois();
		else if(id == CardIdentifier.THROW_BLADE_KNIGHT__MALEAGANT)                         _UnitObject = new ThrowBladeKnightMaleagant();
		else if(id == CardIdentifier.TWIN_HOLY_BEAST__WHITE_LION)                           _UnitObject = new TwinHolyBeastWhiteLion();
		else if(id == CardIdentifier.KNIGHT_OF_PASSION__TOR)                                _UnitObject = new KnightOfPassionTor();
		else if(id == CardIdentifier.GREEN_AXE_KNIGHT__TALIESYN)                            _UnitObject = new GreenAxeKnightTaliesyn();
		else if(id == CardIdentifier.TWIN_HOLY_BEAST__BLACK_LION)                           _UnitObject = new TwinHolyBeastBlackLion();
		else if(id == CardIdentifier.DORGAL_LIBERATOR)                                      _UnitObject = new DorgalLiberator();
		else if(id == CardIdentifier.SACRED_GUARDIAN_BEAST__CERYNEIAN)                      _UnitObject = new SacredGuardianBeastCeryneian();
		else if(id == CardIdentifier.LIBERATOR__BURNING_BLOW)                               _UnitObject = new LiberatorBurningBlow();
		else if(id == CardIdentifier.SECURITY_JEWEL_KNIGHT__ARWEN)                          _UnitObject = new SecurityJewelKnightArwen();
		else if(id == CardIdentifier.DESIRE_JEWEL_KNIGHT__HELOISE)                          _UnitObject = new DesireJewelKnightHeloise();
		else if(id == CardIdentifier.JEWEL_KNIGHT__MELME)                                   _UnitObject = new JewelKnightMelme();
		else if(id == CardIdentifier.SANCTUARY_OF_LIGHT__LITTLE_STORM)                      _UnitObject = new SanctuaryOfLightLittleStorm();
		else if(id == CardIdentifier.JEWEL_KNIGHT__TREANME)                                 _UnitObject = new JewelKnightTreanme();
		else if(id == CardIdentifier.KNIGHT_OF_COURAGE__ECTOR)                              _UnitObject = new KnightOfCourageEctor();
		else if(id == CardIdentifier.MYSTICAL_HERMIT)                                       _UnitObject = new MysticalHermit();
		else if(id == CardIdentifier.MAIDEN_OF_CHERRY_BLOOM)                                _UnitObject = new MaidenOfCherryBloom();
		else if(id == CardIdentifier.MAIDEN_OF_CHERRY_STONE)                                _UnitObject = new MaidenOfCherryStone();
		else if(id == CardIdentifier.WHITE_ROSE_MUSKETEER__ALBERTO)                         _UnitObject = new WhiteRoseMusketeerAlberto();
		else if(id == CardIdentifier.SPIRITUAL_SPHERE_ERADICATOR__NATA)                     _UnitObject = new SpiritualSphereEradicatorNata();
		else if(id == CardIdentifier.CERTAIN_KILL_ERADICATOR__OUEI)                         _UnitObject = new CertainKillEradicatorOuei();
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_UMBRELLA__SUKEROKKU)                  _UnitObject = new StealthRogueOfUmbrellaSukerokku();
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_DEMONIC_HAIR__GURENJISHI)             _UnitObject = new StealthRogueOfDemonicHairGurenjishi();
		else if(id == CardIdentifier.FIRE_GOD__AGNI)                                        _UnitObject = new FireGodAgni();
		else if(id == CardIdentifier.DOMINATE_DRIVE_DRAGON)                                 _UnitObject = new DominateDriveDragon();
		else if(id == CardIdentifier.DRAGON_KNIGHT__SADIG)                                  _UnitObject = new DragonKnightSadig();
		else if(id == CardIdentifier.INVESTIGATING_STEALTH_ROGUE__AMAKUSA)                  _UnitObject = new InvestigatingStealthRogueAmakusa();
		else if(id == CardIdentifier.DRAGON_KNIGHT__AKRAM)                                  _UnitObject = new DragonKnightAkram();
		else if(id == CardIdentifier.KNIGHT_OF_SCORCHING_SCALES__ELIWOOD)                   _UnitObject = new KnightOfScorchingScalesEliwood();
		else if(id == CardIdentifier.BATTLE_MAIDEN__AMENOHOAKARI)                           _UnitObject = new BattleMaidenAmenohoakari();
		else if(id == CardIdentifier.VORPAL_CANNON_DRAGON)                                  _UnitObject = new VorpalCannonDragon();
		else if(id == CardIdentifier.TREASURE_LIBERATOR__CALOGRENANT)                       _UnitObject = new TreasureLiberatorCalogrenant();
		else if(id == CardIdentifier.BLUE_SKY_LIBERATOR__HENGIST)                           _UnitObject = new BlueSkyLiberatorHengist();
		else if(id == CardIdentifier.LINKING_JEWEL_KNIGHT__TILDA)                           _UnitObject = new LinkingJewelKnightTilda();
		else if(id == CardIdentifier.SANCTUARY_OF_LIGHT__PLANET_LANCER)                     _UnitObject = new SanctuaryOfLightPlanetLancer();
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__KAGURABLOOM)                    _UnitObject = new CovertDemonicDragonKaburabloom();
		else if(id == CardIdentifier.SILVER_COLLAR_SNOWSTORM__SASAME)                       _UnitObject = new SilverCollarSnowstormSasame();
		else if(id == CardIdentifier.ERADICATOR__LORENTZ_FORCE_DRAGON)                      _UnitObject = new EradicatorLorentzForceDragon();
		else if(id == CardIdentifier.MAIDEN_OF_VENUS_TRAP______REVERSE_____)                _UnitObject = new MaidenOfVenusTrapReverse();
		else if(id == CardIdentifier.LORD_OF_THE_DEEP_FORESTS__MASTER_WISTERIA)             _UnitObject = new LordOfTheDeepForestsMasterWisteria();
		else if(id == CardIdentifier.RED_ROSE_MUSKETEER__ANTONIO)                           _UnitObject = new RedRoseMusketeerAntonio();
		else if(id == CardIdentifier.SANCTUARY_OF_LIGHT__DETERMINATOR)                      _UnitObject = new SanctuaryOfLightDeterminator();
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__HYAKKI_VOGUE______REVERSE_____) _UnitObject = new CovertDemonicDragonHyakkiVogueReverse();
		else if(id == CardIdentifier.ERADICATOR__TEMPEST_BOLT_DRAGON)                       _UnitObject = new EradicatorTempestBoltDragon();
		else if(id == CardIdentifier.SANCTUARY_OF_LIGHT__PLANETAL_DRAGON)                   _UnitObject = new SanctuaryOfLightPlanetalDragon();
		else if(id == CardIdentifier.BANDING_JEWEL_KNIGHT__MIRANDA)                         _UnitObject = new BandingJewelKnightMiranda();
		else if(id == CardIdentifier.SUMMONING_JEWEL_KNIGHT__GLORIA)                        _UnitObject = new SummoningJewelKnightGloria();
		else if(id == CardIdentifier.SWORD_FORMATION_LIBERATOR__IGRAINE)                    _UnitObject = new SwordFormationLiberatorIgraine();
		else if(id == CardIdentifier.GODDESS_OF_THE_SHIELD__AEGIS)                          _UnitObject = new GoddessOfTheShieldAegis();
		else if(id == CardIdentifier.DAUNTLESS_DOMINATE_DRAGON______REVERSE_____)           _UnitObject = new DauntlessDominateDragonReverse();
		else if(id == CardIdentifier.ERADICATOR__IGNITION_DRAGON)                           _UnitObject = new EradicatorIgnitionDragon();
		else if(id == CardIdentifier.SUNLIGHT_GODDESS__YATAGARASU)                          _UnitObject = new SunlightGoddessYatagarasu();
		else if(id == CardIdentifier.OMNISCIENCE_REGALIA__MINERVA)                          _UnitObject = new OmniscienceRegaliaMinerva();
		else if(id == CardIdentifier.SALVATION_LION__GRAND_EZEL_SCISSORS)                   _UnitObject = new SalvationLionGrandEzelScissors();
		else if(id == CardIdentifier.BROKEN_HEART_JEWEL_KNIGHT__ASHLEI________EVERSE_____)  _UnitObject = new BrokenHeartJewelKnightAshleiReverse();
		else if(id == CardIdentifier.LIBERATOR_OF_BONDS__GANCELOT_ZENITH)                   _UnitObject = new LiberatorOfBondsGancelotZenith();
		else if(id == CardIdentifier.ABYSSAL_SNIPER)                                        _UnitObject = new AbyssalSniper();
		else if(id == CardIdentifier.DEUTERIUMGUN_DRAGON)                                   _UnitObject = new DeuteriumgunDragon();
		else if(id == CardIdentifier.OCEAN_CURRENT_RESCUING_TURTLE_SOLDIER)                 _UnitObject = new OceanCurrentRescuingTurtleSoldier();
		else if(id == CardIdentifier.SHALLOWS_SWEEPER)                                      _UnitObject = new ShallowsSweeper();
		else if(id == CardIdentifier.HEAVY_RUSH_DRAGON)                                     _UnitObject = new HeavyRushDragon();
		else if(id == CardIdentifier.PATROL_SWIMMING_SEAL_SOLDIER)                          _UnitObject = new PatrolSwimmingSealSoldier();
		else if(id == CardIdentifier.APPRENTICE_GUNNER__SOLON)                              _UnitObject = new ApprenticeGunnerSolon();
		else if(id == CardIdentifier.COSMIC_CHEETAH)                                        _UnitObject = new CosmicCheetah();
		else if(id == CardIdentifier.WHISTLE_HYENA)                                         _UnitObject = new WhistleHyena();
		else if(id == CardIdentifier.TELESCOPE_RABBIT)                                      _UnitObject = new TelescopeRabbit();
		else if(id == CardIdentifier.BATTLE_SIREN__MARIKA)                                  _UnitObject = new BattleSirenMarika();
		else if(id == CardIdentifier.MARINE_GENERAL_OF_RAGING_CURRENT__MELTHOS)             _UnitObject = new MarineGeneralOfRagingCurrentMelthos();
		else if(id == CardIdentifier.BATTLE_SIREN__CALLISTA)                                _UnitObject = new BattleSirenCallista();
		else if(id == CardIdentifier.PETER_THE_GHOSTIE)                                     _UnitObject = new PeterTheGhostie();
		else if(id == CardIdentifier.DISCERNING_EYE__SKY_TROOPER)                           _UnitObject = new DiscerningEyeSkyTrooper();
		else if(id == CardIdentifier.GATLING_RAIZER)                                        _UnitObject = new GattlingRaizer();
		else if(id == CardIdentifier.BEAST_DEITY__DESERT_GATOR)                             _UnitObject = new BeastDeityDesertGator();
		else if(id == CardIdentifier.BEAST_DEITY__NIGHT_JACKAL)                             _UnitObject = new BeastDeityNightJackal();
		else if(id == CardIdentifier.COMBINED_MONSTER__BUGLEED)                             _UnitObject = new CombinedMonsterBugleed();
		else if(id == CardIdentifier.ELECTRIC_MONSTER__WHIPPLE)                             _UnitObject = new ElectricMonsterWhipple();
		else if(id == CardIdentifier.ANALYTIC_MONSTER__GIGABOLT)                            _UnitObject = new AnalyticMonsterGigabolt();
		else if(id == CardIdentifier.BEAM_MONSTER__RAYDRAM)                                 _UnitObject = new BeamMonsterRaydram();
		else if(id == CardIdentifier.HYPNOSIS_MONSTER__NECRORY)                             _UnitObject = new HypnosisMonsterNecrory();
		else if(id == CardIdentifier.SUPERMASSIVE_STAR__LADY_GUNNER)                        _UnitObject = new SupermassiveStarLadyGunner();
		else if(id == CardIdentifier.DESTRUCTION_STAR_VADER__TUNGSTEN)                      _UnitObject = new DestructionStarvaderTungsten();
		else if(id == CardIdentifier.PRISON_GATE_STAR_VADER__PALLADIUM)                     _UnitObject = new PrisonGateStarvaderPalladium();
		else if(id == CardIdentifier.ASTEROID_BELT__LADY_GUNNER)                            _UnitObject = new AsteroidBeltLadyGunner();
		else if(id == CardIdentifier.STAR_VADER__CHAOS_BEAT_DRAGON)                         _UnitObject = new StarvaderChaosBeatDragon();
		else if(id == CardIdentifier.BLACK_RING_CHAIN__PLEIADES)                            _UnitObject = new BlackRingChainPleiades();
		else if(id == CardIdentifier.CORROSION_DRAGON__CORRUPT_DRAGON)                      _UnitObject = new CorrosionDragonCorruptDragon();
		else if(id == CardIdentifier.DEATH_ARMY_COMMANDER)                                  _UnitObject = new DeathArmyCommander();
		else if(id == CardIdentifier.TEMPEST_STEALTH_ROGUE_FUUKI)                           _UnitObject = new TempestStealthRogueFuuki();
		else if(id == CardIdentifier.STEALTH_DRAGON_KODACHI_FUBUKI)                         _UnitObject = new StealthDragonKodachifubuki();
		else if(id == CardIdentifier.STEALTH_FIEND_MEZUOU)                                  _UnitObject = new StealthFiendMezuou();
		else if(id == CardIdentifier.FESTIVE_STEALTH_ROGUE_SHUTENMARU)                      _UnitObject = new FestivalStealthRogueShutenmaru();
		else if(id == CardIdentifier.STEALTH_FIEND_MASHIROMOMEN)                            _UnitObject = new StealthFiendMashiromomen();
		else if(id == CardIdentifier.ANESTHESIA_CELESTIAL__RUMAEL)                          _UnitObject = new AnesthesiaCelestialRumael();
		else if(id == CardIdentifier.TENDER_PIGEON)                                         _UnitObject = new TenderPigeon();
		else if(id == CardIdentifier.PENETRATE_CELESTIAL__GADRIEL)                          _UnitObject = new PenetrateCelestialGadriel();
		else if(id == CardIdentifier.STEALTH_FIEND_GOZUOU)                                  _UnitObject = new StealthFiendGozuou();
		else if(id == CardIdentifier.WASHUP_RACCOON)                                        _UnitObject = new WashupRaccoon();
		else if(id == CardIdentifier.SURGICAL_CELESTIAL__BATARIEL)                          _UnitObject = new SurgicalCelestialBatariel();
		else if(id == CardIdentifier.TWINKLEKNIFE_ANGEL)                                    _UnitObject = new TwinkleknifeAngel();
		else if(id == CardIdentifier.DRESSING_BARRAGE__SAHARIEL)                            _UnitObject = new DressingBarrageSahariel();
		else if(id == CardIdentifier.BUBBLE_EDGE_DRACOKID)                                  _UnitObject = new BubbleEdgeDracokid();
		else if(id == CardIdentifier.ABACUS_BEAR)                                           _UnitObject = new AbacusBear();
		else if(id == CardIdentifier.WHEEL_ASSAULT)                                         _UnitObject = new WheelAssault();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIMAGNUM)                           _UnitObject = new DimensionalRoboDaimagnum();
		else if(id == CardIdentifier.KNIGHT_OF_ENTROPY)                                     _UnitObject = new KnightOfEntropy();
		else if(id == CardIdentifier.PARADISE_ELK)                                          _UnitObject = new ParadiseElk();
		else if(id == CardIdentifier.EARNEST_STAR_VADER__SELENIUM)                          _UnitObject = new EarnestStarvaderSelenium();
		else if(id == CardIdentifier.DEMONIC_SEAS_NECROMANCER__BARBAROS)                    _UnitObject = new DemonicSeasNecromancerBarbaros();
		else if(id == CardIdentifier.SEA_STROLLING_BANSHEE)                                 _UnitObject = new SeaStrollingBanshee();
		else if(id == CardIdentifier.TIDAL_ASSAULT)                                         _UnitObject = new TidalAssault();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__GOCANNON)                            _UnitObject = new DimensionalRoboGocannon();
		else if(id == CardIdentifier.SPACE_DRAGON__DOGURUMADORA)                            _UnitObject = new SpaceDragonDogurumadora();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIHEART)                            _UnitObject = new DimensionalRoboDaiheart();
		else if(id == CardIdentifier.STEALTH_BEAST_KUROKO)                                  _UnitObject = new StealthBeastKuroko();
		else if(id == CardIdentifier.BEAST_DEITY__MAX_BEAT)                                 _UnitObject = new BeastDeityMaxBeat();
		else if(id == CardIdentifier.ENERGY_CHARGER)                                        _UnitObject = new EnergyCharger();
		else if(id == CardIdentifier.STEALTH_BEAST_TAMAHAGANE)                              _UnitObject = new StealthBeastTamahagane();
		else if(id == CardIdentifier.STEALTH_FIEND_DAIDARAHOUSHI)                           _UnitObject = new StealthFiendDaidarahoushi();
		else if(id == CardIdentifier.NURSING_CELESTIAL__NARELLE)                            _UnitObject = new NursingCelestialNarelle();
		else if(id == CardIdentifier.OPERATION_CELESTIAL__ARMEN)                            _UnitObject = new OperationCelestialArmen();
		else if(id == CardIdentifier.SCHOOL_PUNISHER__LEO_PALD______REVERSE_____)           _UnitObject = new SchoolPunisherLeopaldReverse();
		else if(id == CardIdentifier.HONORARY_PROFESSOR__CHATNOIR)                          _UnitObject = new HonoraryProfessorChatnoir();
		else if(id == CardIdentifier.ICE_PRISON_HADES_EMPEROR__COCYTUS______REVERSE_____)   _UnitObject = new IcePrisonHadesEmperorCocytusReverse();
		else if(id == CardIdentifier.COBALT_WAVE_DRAGON)                                    _UnitObject = new CobaltWaveDragon();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAISHIELD)                           _UnitObject = new DimensionalRoboDaishield();
		else if(id == CardIdentifier.BEAST_DEITY__BRAINY_PAPIO)                             _UnitObject = new BeastDeityBrainyPapio();
		else if(id == CardIdentifier.STAR_VADER__COLONY_MAKER)                              _UnitObject = new StarvaderColonyMaker();
		else if(id == CardIdentifier.LORD_OF_THE_SEVEN_SEAS__NIGHTMIST)                     _UnitObject = new LordOfTheSevenSeasNightmist();
		else if(id == CardIdentifier.SHURA_STEALTH_DRAGON__KABUKICONGO)                     _UnitObject = new ShuraStealthDragonKabukicongo();
		else if(id == CardIdentifier.STEALTH_BEAST_MIJINGAKURE)                             _UnitObject = new StealthBeastMijingakure();
		else if(id == CardIdentifier.BEAST_DEITY__SOLAR_FALCON)                             _UnitObject = new BeastDeitySolarFalcon();
		else if(id == CardIdentifier.EMERGENCY_CELESTIAL__DANIELLE)                         _UnitObject = new EmergencyCelestialDanielle();
		else if(id == CardIdentifier.BLUE_WAVE_DRAGON__TETRA_DRIVE_DRAGON)                  _UnitObject = new BlueWaveDragonTetraDriveDragon();
		else if(id == CardIdentifier.STAR_VADER__CHAOS_BREAKER_DRAGON)                      _UnitObject = new StarvaderChaosBreakerDragon();
		else if(id == CardIdentifier.POISON_JUGGLER)                                        _UnitObject = new PoisonJuggler();
		else if(id == CardIdentifier.ORIGINAL_SAVER__ZERO)                                  _UnitObject = new OriginalSaverZero();
		else if(id == CardIdentifier.DEADLIEST_BEAST_DEITY__ETHICS_BUSTER______REVERSE_____)_UnitObject = new DeadliestBeastDeityEthicsBusterReverse();
		else if(id == CardIdentifier.DARK_DIMENSIONAL_ROBO_______REVERSE______DAIYUSHA)     _UnitObject = new DarkDimensionalRoboReverseDaiyusha();
		else if(id == CardIdentifier.STRONGEST_BEAST_DEITY__ETHICS_BUSTER_EXTREME)          _UnitObject = new StrongestBeastDeityEthicsBusterExtreme();
		else if(id == CardIdentifier.SHURA_STEALTH_DRAGON__KUJIKIRICONGO)                   _UnitObject = new ShuraStealthDragonKujikiricongo();
		else if(id == CardIdentifier.CLEANUP_CELESTIAL__RAMIEL______REVERSE_____)           _UnitObject = new CleanupCelestialRamielReverse();
		else if(id == CardIdentifier.DIMENSION_CREEPER)                                     _UnitObject = new DimensionCreeper();
		else if(id == CardIdentifier.WERHASE_BANDIT)                                        _UnitObject = new WerhaseBandit();
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__FATE_COLLECTOR)                   _UnitObject = new AmonsFollowerFateCollector();
		else if(id == CardIdentifier.WERFUCHS_HEXER)                                        _UnitObject = new WerfuchsHexer();
		else if(id == CardIdentifier.HUGE_KNIFE_THROWING_EXPERT)                            _UnitObject = new HugeKnifeThrowingExpert();
		else if(id == CardIdentifier.FLYING_HIPPOGRIFF)                                     _UnitObject = new FlyingHippogriff();
		else if(id == CardIdentifier.SILVER_THORN_ASSISTANT__IRINA)                         _UnitObject = new SilverThornAssistantIrina();
		else if(id == CardIdentifier.SILVER_THORN_BEAST_TAMER__ANA)                         _UnitObject = new SilverThornBeastTamerAna();
		else if(id == CardIdentifier.TIGHTROPE_TUMBLER)                                     _UnitObject = new TightropeTumbler();
		else if(id == CardIdentifier.ELEGANT_ELEPHANT)                                      _UnitObject = new ElegantElephant();
		else if(id == CardIdentifier.SILVER_THORN_ASSISTANT__IONELA)                        _UnitObject = new SilverThornAssistantIonela();
		else if(id == CardIdentifier.JOURNEYING_TONE__WILLY)                                _UnitObject = new JourneyingToneWilly();
		else if(id == CardIdentifier.SILVER_THORN_BREATHING_DRAGON)                         _UnitObject = new SilverThornBreathingDragon();
		else if(id == CardIdentifier.TIGHTROPE_HOLDER)                                      _UnitObject = new TightropeHolder();
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__HELL_____S_DEAL)                  _UnitObject = new AmonsFollowerHellsDeal();
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__PHU_GEENLIN)                      _UnitObject = new AmosFollowerPhuGeenlin();
		else if(id == CardIdentifier.NUMBER_OF_TERROR)                                      _UnitObject = new NumberOfTerror();
		else if(id == CardIdentifier.WHITE_NIGHT__FENRIR)                                   _UnitObject = new WhiteNightFenrir();
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__HELL_____S_DRAW)                  _UnitObject = new AmonsFollowerHellsDraw();
		else if(id == CardIdentifier.WERLEOPARD_SOLDAT)                                     _UnitObject = new WerleopardSoldat();
		else if(id == CardIdentifier.FLOG_KNIGHT)                                           _UnitObject = new FlogKnight();
		else if(id == CardIdentifier.GRAVITY_BALL_DRAGON)                                   _UnitObject = new GravityBallDragon();
		else if(id == CardIdentifier.DEMONIC_CLAW_STAR_VADER__LANTHANUM)                    _UnitObject = new DemonicClawStarvaderLanthanum();
		else if(id == CardIdentifier.STRAFE_STAR_VADER__RUTHENIUM)                          _UnitObject = new StrafeStarvaderRuthenium();
		else if(id == CardIdentifier.PARADOX_NAIL__FENRIR)                                  _UnitObject = new ParadoxNailFenrir();
		else if(id == CardIdentifier.FURIOUS_CLAW_STAR_VADER__NIOBIUM)                      _UnitObject = new FuriousClawStarvaderNiobium();
		else if(id == CardIdentifier.GAMMA_BURST__FENRIR)                                   _UnitObject = new GammaBurstFenrir();
		else if(id == CardIdentifier.ONE_WHO_SHOOTS_GRAVITATIONAL_SINGULARITIES)            _UnitObject = new OneWhoShootsGravitationalSingularities();
		else if(id == CardIdentifier.LA_MORT)                                               _UnitObject = new LaMort();
		else if(id == CardIdentifier.PEEKGAL)                                               _UnitObject = new Peekgal();
		else if(id == CardIdentifier.SUNRISE_UNICORN)                                       _UnitObject = new SunriseUnicorn();
		else if(id == CardIdentifier.LIBERATOR__CHEER_UP_TRUMPETER)                         _UnitObject = new LiberatorCheerUpTrumpeter();
		else if(id == CardIdentifier.MAY_RAIN_LIBERATOR__BRUNO)                             _UnitObject = new MayRainLiberatorBruno();
		else if(id == CardIdentifier.SPINBAU_REVENGER)                                      _UnitObject = new SpinbauRevenger();
		else if(id == CardIdentifier.GIGANTECH_PILLAR_FIGHTER)                              _UnitObject = new GigantechPillarFighter();
		else if(id == CardIdentifier.CLOUDY_SKY_LIBERATOR__GERAINT)                         _UnitObject = new CloudySkyLiberatorGeraint();
		else if(id == CardIdentifier.SONBAU)                                                _UnitObject = new Sonbau();
		else if(id == CardIdentifier.CATASTROPHE_STINGER)                                   _UnitObject = new CatastropheStinger();
		else if(id == CardIdentifier.INNOCENT_BLADE__HEARTLESS)                             _UnitObject = new InnocentBladeHeartless();
		else if(id == CardIdentifier.REVENGER_OF_MALICE__DILAN)                             _UnitObject = new RevengerOfMaliceDilan();
		else if(id == CardIdentifier.DEMON_WORLD_CASTLE__ZERSCHLAGEN)                       _UnitObject = new DemonWorldCastleZerschlagen();
		else if(id == CardIdentifier.SHARKBAU_REVENGER)                                     _UnitObject = new SharkbauRevenger();
		else if(id == CardIdentifier.DEMON_WORLD_CASTLE__ZWEISPEER)                         _UnitObject = new DemonWorldCastleZweispeer();
		else if(id == CardIdentifier.SILVER_THORN_RISING_DRAGON)                            _UnitObject = new SilverThornRisingDragon();
		else if(id == CardIdentifier.SILVER_THORN_BEAST_TAMER__MARICICA)                    _UnitObject = new SilveThornBeastTamerMaricica();
		else if(id == CardIdentifier.FIRE_RING_GRYPHON)                                     _UnitObject = new FireRingGryphon();
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__RON_GEENLIN)                      _UnitObject = new AmonsFollowerRonGeenlin();
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__FOOL_____S_PALM)                  _UnitObject = new AmonsFollowerFoolsPalm();
		else if(id == CardIdentifier.WERBEAR_SOLDNER)                                       _UnitObject = new WebearSoldner();
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__PSYCHO_GLAIVE)                    _UnitObject = new AmonsFollowerPsychoGlaive();
		else if(id == CardIdentifier.STAR_VADER__DUST_TAIL_UNICORN)                         _UnitObject = new StarvaderDustTailUnicorn();
		else if(id == CardIdentifier.MICRO_HOLE_DRACOKID)                                   _UnitObject = new MicroholeDracokid();
		else if(id == CardIdentifier.ONE_WHO_OPENS_THE_BLACK_DOOR)                          _UnitObject = new OneWhoOpensTheBlackDoor();
		else if(id == CardIdentifier.LIGHTNING_HAMMER_WIELDING_EXORCIST_KNIGHT)             _UnitObject = new LightingHammerWieldingExorcistKnight();
		else if(id == CardIdentifier.EXORCIST_MAGE__DAN_DAN)                                _UnitObject = new ExorcistMageDanDan();
		else if(id == CardIdentifier.SCHR__DINGER_____S_LION)                               _UnitObject = new SchrodingersLion();
		else if(id == CardIdentifier.GRAVITY_COLLAPSE_DRAGON)                               _UnitObject = new GravityCollapseDragon();
		else if(id == CardIdentifier.HOMING_ERADICATOR__ROCHISHIN)                          _UnitObject = new HomingEradicatorRochisin();
		else if(id == CardIdentifier.LIGHTNING_AXE_WIELDING_EXORCIST_KNIGHT)                _UnitObject = new LightingAxeWieldingExorcistKnight();
		else if(id == CardIdentifier.LIBERATOR__BAGPIPE_ANGEL)                              _UnitObject = new LiberatorBagpipeAngel();
		else if(id == CardIdentifier.FRONTLINE_REVENGER__CLAUDAS)                           _UnitObject = new FrontlineRevengerClaudas();
		else if(id == CardIdentifier.REVENGER__DARK_BOND_TRUMPETER)                         _UnitObject = new RevengerDarkBondTrumpeter();
		else if(id == CardIdentifier.DANCING_PRINCESS_OF_THE_NIGHT_SKY)                     _UnitObject = new DancingPrincessOfTheNightSky();
		else if(id == CardIdentifier.BARRIER_TROOP_REVENGER__DORINT)                        _UnitObject = new BarrierTroopRevengerDorint();
		else if(id == CardIdentifier.NIGHTMARE_DOLL__CHELSEA)                               _UnitObject = new NightmareDollChelsea();
		else if(id == CardIdentifier.MIRACLE_POP__EVA)                                      _UnitObject = new MiraclePopEva();
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__VLAD_SPECULA)                     _UnitObject = new ArmonsFollowerVladSpecula();
		else if(id == CardIdentifier.SILVER_THORN_HYPNOS__LYDIA)                            _UnitObject = new SilverThornHypnosLydia();
		else if(id == CardIdentifier.MASTER_OF_FIFTH_ELEMENT)                               _UnitObject = new MasterOfFifthElement();
		else if(id == CardIdentifier.KING_OF_MASKS__DANTARIAN)                              _UnitObject = new KingOfMasksDantarian();
		else if(id == CardIdentifier.BARCGAL_LIBERATOR)                                     _UnitObject = new BarcgalLiberator();
		else if(id == CardIdentifier.BARRIER_STAR_VADER__PROMETHIUM)                        _UnitObject = new BarrierStarvaderPromethium();
		else if(id == CardIdentifier.IRON_FAN_ERADICATOR__RASETSUNYO)                       _UnitObject = new IronFanEradicatorRasetsunyo();
		else if(id == CardIdentifier.DARK_REVENGER__MAC_LIR)                                _UnitObject = new DarkRevengerMacLir();
		else if(id == CardIdentifier.DARK_CLOAK_REVENGER__TARTU)                            _UnitObject = new DarkCloakRevengerTartu();
		else if(id == CardIdentifier.SCHWARZSCHILD_DRAGON)                                  _UnitObject = new SchwarzchildDragon();
		else if(id == CardIdentifier.DEMON_MARQUIS__AMON______REVERSE_____)                 _UnitObject = new DemonMarquisAmonReverse();
		else if(id == CardIdentifier.SILVER_THORN_DRAGON_QUEEN__LUQUIER______REVERSE_____)  _UnitObject = new SilverThornDragonQueenLuquierReverse();
		else if(id == CardIdentifier.WITCH_OF_CURSED_TALISMAN__ETAIN)                       _UnitObject = new WitchOfCursedTalismanEtain();
		else if(id == CardIdentifier.DEMON_CONQUERING_DRAGON__DUNGAREE______UNLIMITED_____) _UnitObject = new DemonConqueringDragonDungareeUnlimited();
		else if(id == CardIdentifier.STAR_VADER__NEBULA_LORD_DRAGON)                        _UnitObject = new StarvaderNebulaLordDragon();
		else if(id == CardIdentifier.ERADICATOR__VOWING_SABER_DRAGON______REVERSE_____)     _UnitObject = new EradicatorVowingSaberDragonReverse();
		else if(id == CardIdentifier.WOLF_FANG_LIBERATOR__GARMORE)                   _UnitObject = new WolfFangLiberatorGarmore();
		else if(id == CardIdentifier.REVENGER__RAGING_FORM_DRAGON)                   _UnitObject = new RevengerRagingFormDragon();
		else if(id == CardIdentifier.DRAGONIC_KAISER_VERMILLION______THE_BLOOD_____) _UnitObject = new DragonicKaiserVermillionTHEBLOOD();
		else if(id == CardIdentifier.CEO_AMATERASU)                                  _UnitObject = new CEOAmaterasu();
		else if(id == CardIdentifier.KING_OF_KNIGHTS_ALFRED)                         _UnitObject = new Alfred();
		else if(id == CardIdentifier.HELL_SPIDER)                                    _UnitObject = new HellSpider();
		else if(id == CardIdentifier.SKY_DIVER)                                      _UnitObject = new SkyDiver();
		else if(id == CardIdentifier.SCARLET_WITCH_COCO)                             _UnitObject = new ScarletWitchCoCo();
		else if(id == CardIdentifier.CAPTAIN_NIGHTMIST)                              _UnitObject = new CaptainNightmist();
		else if(id == CardIdentifier.PERFECT_RAIZER)                                 _UnitObject = new PerfectRaizer();
		else if(id == CardIdentifier.HI_POWERED_RAIZER_CUSTOM)                       _UnitObject = new RaizerCustom();
		else if(id == CardIdentifier.RAIZER_CUSTOM)                                  _UnitObject = new RaizerCustom2();
		else if(id == CardIdentifier.RIGHT_ARRESTER)                                 _UnitObject = new RightArrester();
		else if(id == CardIdentifier.LEFT_ARRESTER)                                  _UnitObject = new LeftArrester();
		else if(id == CardIdentifier.GODDESS_OF_THE_FULL_MOON__TSUKUYOMI)            _UnitObject = new Tsukuyomi();
		else if(id == CardIdentifier.CRIMSON_BEAST_TAMER)                            _UnitObject = new CrimsonBeastTamer();
		else if(id == CardIdentifier.KNIGHT_OF_GODLY_SPEED__GALAHAD)                 _UnitObject = new Galahad();
		else if(id == CardIdentifier.TURQUOISE_BEAST_TAMER)                          _UnitObject = new TurquoiseBeastTamer();
		else if(id == CardIdentifier.TOP_IDOL__RIVIERE)                              _UnitObject = new TopIdolRiviere();
		else if(id == CardIdentifier.BERMUDA_PRINCESS__LENA)                         _UnitObject = new BermudaPrincessLena();
		else if(id == CardIdentifier.DRAGONIC_KAISER_VERMILLION)                     _UnitObject = new DragonicKaiserVermillion();
		else if(id == CardIdentifier.SUPER_IDOL__RIVIERE)                            _UnitObject = new SuperIdolRiviere();
		else if(id == CardIdentifier.MERMAID_IDOL__RIVIERE)                          _UnitObject = new MermaidIdolRiviere();
		else if(id == CardIdentifier.DRIVE_QUARTET__RESSAC)                          _UnitObject = new DriveQuartetRessac();
		else if(id == CardIdentifier.DRIVE_QUARTET__BUBBLIN)                         _UnitObject = new DriveQuartetBubblin();
		else if(id == CardIdentifier.PHANTOM_BLASTER_DRAGON)                         _UnitObject = new PhantomBlasterDragon();
		else if(id == CardIdentifier.ENIGMAN_STORM)                                  _UnitObject = new EnigmanStorm();
		else if(id == CardIdentifier.AMBER_DRAGON__ECLIPSE)                          _UnitObject = new AmberDragonEclipse();
		else if(id == CardIdentifier.AMBER_DRAGON__DUSK)                             _UnitObject = new AmberDragonDusk();
		else if(id == CardIdentifier.ELITE_MUTANT__GIRAFFA)                          _UnitObject = new EliteMutantGiraffa();
		else if(id == CardIdentifier.STERN_BLAUKLUGER)                               _UnitObject = new SternBlaukluger();
		else if(id == CardIdentifier.BLAUKLUGER)                                     _UnitObject = new Blaukluger();
		else if(id == CardIdentifier.BLASTER_DARK)                                   _UnitObject = new BlasterDark();
		else if(id == CardIdentifier.EISENKUGEL)                                     _UnitObject = new Eisenkugel();
		else if(id == CardIdentifier.BLAUPANZER)                                     _UnitObject = new Blaupanzer();
		else if(id == CardIdentifier.BRUGAL)                                         _UnitObject = new Brugal();
		else if(id == CardIdentifier.GODDESS_OF_FLOWER_DIVINATION__SAKUYA)           _UnitObject = new GoddessOfFlowerDivinationSakuya();
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__MANDALA_LORD)            _UnitObject = new CovertDemonicDragonMandalaLord();
		else if(id == CardIdentifier.PHANTOM_BLASTER_OVERLORD)                       _UnitObject = new PhantomBlasterOverlord();
		else if(id == CardIdentifier.DRAGONIC_OVERLORD_THE_END)                      _UnitObject = new DragonicOverlordTheEnd();
		else if(id == CardIdentifier.HEAVENLY_INJECTOR)                              _UnitObject = new HeavenlyInjector();
		else if(id == CardIdentifier.MISTRESS_HURRICANE)                             _UnitObject = new MistressHurricane();
		else if(id == CardIdentifier.BRIGHTLANCE_DRAGOON)                            _UnitObject = new BrightlanceDragoon();
		else if(id == CardIdentifier.SKY_WITCH__NANA)                                _UnitObject = new SkyWitchNaNa();
		else if(id == CardIdentifier.MAIDEN_OF_TRAILING_ROSE)                        _UnitObject = new MaidenOfTrailingRose();
		else if(id == CardIdentifier.GALACTIC_BEAST__ZEAL)                           _UnitObject = new GalacticBeastZeal();
		else if(id == CardIdentifier.BEAST_DEITY__AZURE_DRAGON)                      _UnitObject = new BeastDeityAzureDragon();
		else if(id == CardIdentifier.BLUE_STORM_SUPREME_DRAGON__GLORY_MAELSTROM)     _UnitObject = new BlueStormSupremeGloryMalestrom();
		else if(id == CardIdentifier.MILITARY_DRAGON__RAPTOR_CAPTAIN)                _UnitObject = new MilitaryDragonRaptorCaptain();
		else if(id == CardIdentifier.STEALTH_BEAST__GIGANTOAD)                       _UnitObject = new StealthBeastGigantoad();
		else if(id == CardIdentifier.MASS_PRODUCTION_SAILOR)                         _UnitObject = new MassProductionSailor();
		else if(id == CardIdentifier.STEALTH_DRAGON__ROYALE_NOVA)                    _UnitObject = new StealthDragonRoyaleNova();
		else if(id == CardIdentifier.EYE_OF_DESTRUCTION__ZEAL)                       _UnitObject = new EyeOfDestructionZeal();
		else if(id == CardIdentifier.BATTLE_SIREN__CARRI)                            _UnitObject = new BattleSirenCagli();
		else if(id == CardIdentifier.BATTLE_SIREN__EUPHENIA)                         _UnitObject = new BattleSirenEuphenia();
		else if(id == CardIdentifier.RED_PENCIL_RHINO)                               _UnitObject = new RedPencilRhino();
		else if(id == CardIdentifier.ARBOROS_DRAGON__BRANCH)                         _UnitObject = new ArborosDragonBranch();
		else if(id == CardIdentifier.SILENT_RIPPLE__SOTIRIO)                         _UnitObject = new SilentRippleSotirio();
		else if(id == CardIdentifier.DRAGON_DANCER__JULIA)                           _UnitObject = new DragonDancerJulia();
		else if(id == CardIdentifier.LIZARD_SOLDIER__RYUUSHIN)                       _UnitObject = new LizardSoldierRyoshin();
		else if(id == CardIdentifier.ERADICATOR__FIRST_THUNDER_DRACOKID)             _UnitObject = new EradicatorFirstThunderDracokid();
		else if(id == CardIdentifier.FLAG_OF_RAIJIN__CORPOSANT)                      _UnitObject = new FlagOfRaijinCorposant();
		else if(id == CardIdentifier.MILITARY_DRAGON__RAPTOR_SERGEANT)               _UnitObject = new MilitaryDragonRaptorSergeant();
		else if(id == CardIdentifier.MOBILE_BATTLESHIP__AKERON)                      _UnitObject = new MobileBattleshipArchelon();
		else if(id == CardIdentifier.TWIN_STRIKE_BRAVE_SHOOTER)                      _UnitObject = new TwinStrikeBraveShooter();
		else if(id == CardIdentifier.OPTICS_MUSKET_TITAN)                            _UnitObject = new TitanOfTheBeamRifle();
		else if(id == CardIdentifier.SAVAGE_ILLUMINATOR)                             _UnitObject = new SavageIlluminator();
		else if(id == CardIdentifier.ANCIENT_DRAGON__BABY_REX)                       _UnitObject = new AncientDragonBabyrex();
		else if(id == CardIdentifier.SAVAGE_PATRIARCH)                               _UnitObject = new SavagePatriarch();
		else if(id == CardIdentifier.ANCIENT_DRAGON__DINODILE)                       _UnitObject = new AncientDragonDinodile();
		else if(id == CardIdentifier.ANCIENT_DRAGON__GATTLING_ALLO)                  _UnitObject = new AncientDragonGattlingaro();
		else if(id == CardIdentifier.STEALTH_DRAGON__MAGATSU_GALE)                   _UnitObject = new StealthDragonMagatsuGale();
		else if(id == CardIdentifier.LAUNCHER_MAMMOTH)                               _UnitObject = new LauncherMammoth();
		else if(id == CardIdentifier.SAVAGE_ARCHER)                                  _UnitObject = new SavageArcher();
		else if(id == CardIdentifier.ANCIENT_DRAGON__TRI_PLASMA)                     _UnitObject = new AncientDragonTriplasma();
		else if(id == CardIdentifier.ANCIENT_DRAGON__STEGOBUSTER)                    _UnitObject = new AncientDragonStegobuster();
		else if(id == CardIdentifier.ANCIENT_DRAGON__DEINO_CLAWED)                   _UnitObject = new AncientDragonDinocrowd();
		else if(id == CardIdentifier.SEAL_DRAGON__ARTPITCH)                          _UnitObject = new SealDragonArtpique();
		else if(id == CardIdentifier.SEAL_DRAGON__TERRYCLOTH)                        _UnitObject = new SealDragonTerrycloth();
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__DIVA)                      _UnitObject = new DemonicDragonMageDeva();
		else if(id == CardIdentifier.RED_PULSE_DRACOKID)                             _UnitObject = new RedPulseDracokid();
		else if(id == CardIdentifier.BREATH_OF_PRIMORDIAL__ROLAMANDRI)               _UnitObject = new BreathOfOriginRolamandri();
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__SHAGARA)                   _UnitObject = new DemonicDragonMageSagara();
		else if(id == CardIdentifier.SEAL_DRAGON__KERSEY)                            _UnitObject = new SealDragonKersey();
		else if(id == CardIdentifier.SEAL_DRAGON__FLANNEL)                           _UnitObject = new SealDragonFlannel();
		else if(id == CardIdentifier.DEMONIC_DRAGON_BERSERKER__KUBANDA)              _UnitObject = new DemonicDragonBerserkerKumbhanda();
		else if(id == CardIdentifier.BLACKBOARD_PARROT)                              _UnitObject = new BlackboardParrot();
		else if(id == CardIdentifier.CURE_DROP_ANGEL)                                _UnitObject = new CureDropAngel();
		else if(id == CardIdentifier.HAZARD_BOB)                                     _UnitObject = new HazardBob();
		else if(id == CardIdentifier.PINEAPPLE_LO)                                   _UnitObject = new PineappleLaw();
		else if(id == CardIdentifier.STEALTH_DRAGON__MAGATSU_BREATH)                 _UnitObject = new StealthDragonMagatsuBreath();
		else if(id == CardIdentifier.WITCH_OF_PROHIBITED_BOOKS__CINNAMON)            _UnitObject = new WitchOfProhibitedBooksCinnamon();
		else if(id == CardIdentifier.SEAL_DRAGON__SPIKE_HELL_DRAGON)                 _UnitObject = new SealDragonSpikeHellDragon();
		else if(id == CardIdentifier.SEAL_DRAGON__CORDUROY)                          _UnitObject = new SealDragonCorduroy();
		else if(id == CardIdentifier.VIVID_RABBIT)                                   _UnitObject = new VividRabbit();
		else if(id == CardIdentifier.ANCIENT_DRAGON__IGUANOGORG)                     _UnitObject = new AncientDragonIguanogorg();
		else if(id == CardIdentifier.DEMONIC_SWORD_ERADICATOR__RAIOH)                _UnitObject = new DemonicSwordEradicatorRaioh();
		else if(id == CardIdentifier.IRON_BLOOD_ERADICATOR__SHUKI)                   _UnitObject = new SteelbloodedEradicatorShuki();
		else if(id == CardIdentifier.OPTICS_CANNON_TITAN)                            _UnitObject = new TitanOfTheBeamCannonTower();
		else if(id == CardIdentifier.RISING_RIPPLE__PAVROTH)                         _UnitObject = new RisingRipplePavroth();
		else if(id == CardIdentifier.STARTING_RIPPLE__ALECS)                         _UnitObject = new StartingRippleAlecs();
		else if(id == CardIdentifier.BOOTING_CELESTIAL__SANDALPHON)                  _UnitObject = new BootingCelestialSandalphon();
		else if(id == CardIdentifier.CAPSULE_GIFT_NURSE)                             _UnitObject = new CapsuleGiftNurse();
		else if(id == CardIdentifier.DOCTROID_ARGUS)                                 _UnitObject = new DoctroidArgus();
		else if(id == CardIdentifier.ORDER_CELESTIAL__YEQON)                         _UnitObject = new OrderCelestialYeqon();
		else if(id == CardIdentifier.DRUG_STORE_NURSE)                               _UnitObject = new DrugstoreNurse();
		else if(id == CardIdentifier.SAVAGE_HUNTER)                                  _UnitObject = new SavageHunter();
		else if(id == CardIdentifier.ANCIENT_DRAGON__BEAMANKYLO)                     _UnitObject = new AncientDragonBeamankylo();
		else if(id == CardIdentifier.WITCH_OF_FROGS__MELISSA)                        _UnitObject = new WitchOfFrogsMelissa();
		else if(id == CardIdentifier.SEAL_DRAGON__JAKADO)                            _UnitObject = new SealDragonJacquard();
		else if(id == CardIdentifier.SEAL_DRAGON__CHAMBRAY)                          _UnitObject = new SealDragonChambray();
		else if(id == CardIdentifier.DEMONIC_DRAGON_BERSERKER__GANDARUBA)            _UnitObject = new DemonicDragonBerserkerGandharva();
		else if(id == CardIdentifier.TEAR_KNIGHT__LUCAS)                             _UnitObject = new TearKnightLucas();
		else if(id == CardIdentifier.MICE_GUARD__LA_SUPERBA)                         _UnitObject = new MythGuardLaSuperba();
		else if(id == CardIdentifier.WITCH_OF_BIRDS__CHAMOMILE)                      _UnitObject = new WitchOfRavensChamomile();
		else if(id == CardIdentifier.FIENDISH_SWORD_ERADICATOR__CHO_OU)              _UnitObject = new FiendishSwordEradicatorChoOu();
		else if(id == CardIdentifier.BREATH_OF_DEMISE__VULCANIS)                     _UnitObject = new BreathOfDemiseVulcan();
		else if(id == CardIdentifier.DRAGON_KNIGHT__RUTOF)                           _UnitObject = new DragonKnightLotf();
		else if(id == CardIdentifier.THUNDERING_RIPPLE__GENOVIOUS)                   _UnitObject = new ThunderingRippleGenovious();
		else if(id == CardIdentifier.ANCIENT_DRAGON__SPINODRIVER)                    _UnitObject = new AncientDragonSpinodriver();
		else if(id == CardIdentifier.ANCIENT_DRAGON__TYRANNOLEGEND)                  _UnitObject = new AncientDragonTyrannolegend();
		else if(id == CardIdentifier.SEALED_DEMON_DRAGON__DUNGAREE)                  _UnitObject = new SealedDemonDragonDungaree();
		else if(id == CardIdentifier.RAVENOUS_DRAGON__BATTLEREX)                     _UnitObject = new RavenousDragonBattlerex();
		else if(id == CardIdentifier.ARMOR_BREAK_DRAGON)                             _UnitObject = new ArmorBreakDragon();
		else if(id == CardIdentifier.BLUE_STORM_DRAGON__MAELSTROM)                   _UnitObject = new BlueStormDragonMaelstrom();
		else if(id == CardIdentifier.SEAL_DRAGON__RINOCROSS)                         _UnitObject = new SealDragonRinocross();
		else if(id == CardIdentifier.ANCIENT_DRAGON__PARASWALL)                      _UnitObject = new AncientDragonParaswall();
		else if(id == CardIdentifier.DAUNTLESS_DRIVE_DRAGON)                         _UnitObject = new DauntlessDriveDragon();
		else if(id == CardIdentifier.FANG_OF_LIGHT__GARMORE)                         _UnitObject = new FangOfLightGarmore();
		else if(id == CardIdentifier.ERADICATOR__SWEEP_COMMAND_DRAGON)               _UnitObject = new EradicatorSweepCommandDragon();
		else if(id == CardIdentifier.LAST_CARD__REVONN)                              _UnitObject = new LastCardRevonn();
		else if(id == CardIdentifier.GODDESS_OF_GOOD_LUCK__FORTUNA)                  _UnitObject = new GoddessOfGoodLuckFortuna();
		else if(id == CardIdentifier.HELLFIRE_SEAL_DRAGON__BLOCKADE_INFERNO)         _UnitObject = new HellfireSealDragonBlockadeInferno();
		else if(id == CardIdentifier.STARLIGHT_UNICORN)                              _UnitObject = new StarlightUnicorn();
		else if(id == CardIdentifier.COVENANT_KNIGHT_RANDOLF)                        _UnitObject = new CovenantKnightRandolf();
		else if(id == CardIdentifier.WHITE_LILY_MUSKETEER__CECILIA)                  _UnitObject = new WhiteLilyMusketeerCecilia();
		else if(id == CardIdentifier.ERADICATOR__SPARK_HORN_DRAGON)                  _UnitObject = new EradicatorSparkHornDragon();
		else if(id == CardIdentifier.STAMP_SEA_OTTER)                                _UnitObject = new StampSeaOtter();
		else if(id == CardIdentifier.DRAGON_UNDEAD__SKULL_DRAGON)                    _UnitObject = new DragonUndeadSkullDragon();
		else if(id == CardIdentifier.KNIGHT_OF_FURY__AGRAVAIN)                       _UnitObject = new KnightOfFuryAgravain();
		else if(id == CardIdentifier.SLEYGAL_DAGGER)                                 _UnitObject = new SleygalDagger();
		else if(id == CardIdentifier.INCANDESCENT_LION__BLOND_EZEL)                  _UnitObject = new IncandescentLionBlondEzel();
		else if(id == CardIdentifier.GREAT_SILVER_WOLF__GARMORE)                     _UnitObject = new GreatSilverWolfGarmore();
		else if(id == CardIdentifier.TORPEDO_RUSH_DRAGON)                            _UnitObject = new TorpedoRushDragon();
		else if(id == CardIdentifier.ULTIMATE_DIMENSIONAL_ROBO__GREAT_DAIYUSHA)      _UnitObject = new UltimateDimensionalRoboGreatDaiyusha();
		else if(id == CardIdentifier.LARVA_BEAST__ZEAL)                              _UnitObject = new LarvaBeastZeal();
		else if(id == CardIdentifier.COMMANDER_LAUREL)                               _UnitObject = new CommanderLaurel();
		else if(id == CardIdentifier.DEMON_BIKE_OF_THE_WITCHING_HOUR)                _UnitObject = new DemonBikeOfTheWitchingHour();
		else if(id == CardIdentifier.RAINBOW_LIGHT__CARINE)                          _UnitObject = new RainbowLightCarine();
		else if(id == CardIdentifier.GREEDY_HAND)                                    _UnitObject = new GreedyHand();
		else if(id == CardIdentifier.NO_LIFE_KING__DEATH_ANCHOR)                     _UnitObject = new NoLifeKingDeathAnchor();
		else if(id == CardIdentifier.BARKING_MANTICORE)                              _UnitObject = new BarkingManticore();
		else if(id == CardIdentifier.KNIGHT_OF_ROSE_MORGANA)                         _UnitObject = new KnightOfRoseMorgana();
		else if(id == CardIdentifier.FLIRTATIOUS_SUCCUBUS)                           _UnitObject = new FlirtatiousSuccubus();
		else if(id == CardIdentifier.POET_OF_DARKNESS__AMON)                         _UnitObject = new PoetOfDarknessAmon();
		else if(id == CardIdentifier.VELVET_VOICE__RAINDEAR)                         _UnitObject = new VelvetVoiceRaindear();
		else if(id == CardIdentifier.WARRIOR_OF_DESTINY__DAI)                        _UnitObject = new WarriorOfDestinyDai();
		else if(id == CardIdentifier.MERMAID_IDOL__FLUTE)                            _UnitObject = new MermaidIdolFlute();
		else if(id == CardIdentifier.PEARL_SISTERS__PERLE)                           _UnitObject = new PearlSisterPerle();
		else if(id == CardIdentifier.DRIVE_QUARTET__SHUPLU)                          _UnitObject = new DriveQuartetShuplu();
		else if(id == CardIdentifier.DRIVE_QUARTET__FLOWS)                           _UnitObject = new DriveQuartetFlows();
		else if(id == CardIdentifier.WHITE_DRAGON_KNIGHT__PENDRAGON) 	   		 	 _UnitObject = new WhiteDragonKnightPendragon();
		else if(id == CardIdentifier.ORIGIN_MAGE__ILDONA)            	   		 	 _UnitObject = new OriginMageIlldona();
		else if(id == CardIdentifier.SUPERSONIC_SAILOR)              	   		 	 _UnitObject = new SupersonicSailor();
		else if(id == CardIdentifier.GENTLE_JIMM)                    	   		 	 _UnitObject = new GentleJimm();
		else if(id == CardIdentifier.BERSERK_DRAGON)                                 _UnitObject = new BerserkDragon();
		else if(id == CardIdentifier.CRIMSON_BUTTERFLY_BRIGITTE)                     _UnitObject = new CrimsonButterflyBrigitte();
		else if(id == CardIdentifier.ORACLE_GUARDIAN__SPHINX)        	   		 	 _UnitObject = new OracleGuardianSphinx();
		else if(id == CardIdentifier.ROCK_WITCH__GAGA)               	   		 	 _UnitObject = new RockWitchGaGa();
		else if(id == CardIdentifier.MACHINE_GUN_TALK__RYAN)         	  		 	 _UnitObject = new MachinegunTalkRyan();
		else if(id == CardIdentifier.GUARDIAN_OF_TRUTH__LOX)                         _UnitObject = new GuardianOfTruthLox();
		else if(id == CardIdentifier.HEROIC_HANI)                   	   		 	 _UnitObject = new HeroicHani();
		else if(id == CardIdentifier.BATTLE_SISTER__CREAM)           	   		 	 _UnitObject = new BattleSisterCream();
		else if(id == CardIdentifier.SUPPLE_BAMBOO_PRINCESS__KAGUYA) 	  		 	 _UnitObject = new SuppleBambooPrincessKaguya();
		else if(id == CardIdentifier.SOLAR_MAIDEN__UZUME)            	   		 	 _UnitObject = new SolarMaidenUzume();
		else if(id == CardIdentifier.LION_HEAT)                      	   		 	 _UnitObject = new LionetHeat();
		else if(id == CardIdentifier.TRANSMIGRATING_EVOLUTION__MIRAIOH)    		 	 _UnitObject = new TransmigratingEvolutionMiraioh();
		else if(id == CardIdentifier.STOIC_HANI)                           		 	 _UnitObject = new StoicHani();
		else if(id == CardIdentifier.BURSTRAIZER)                          		 	 _UnitObject = new Burstraizer();
		else if(id == CardIdentifier.TRANSRAIZER)                        		 	 _UnitObject = new Transraizer();
		else if(id == CardIdentifier.CRIMSON_DRIVE__APHRODITE)             		 	 _UnitObject = new CrimsonDriveAphrodite();
		else if(id == CardIdentifier.EXAMINE_ANGEL)                        		 	 _UnitObject = new ExamineAngel();
		else if(id == CardIdentifier.CRIMSON_MIND__BARUCH)                 		 	 _UnitObject = new CrimsonMindBaruch();
		else if(id == CardIdentifier.EMERGENCY_VEHICLE)                    		 	 _UnitObject = new EmergencyVehicle();
		else if(id == CardIdentifier.CANDLELIGHT_ANGEL)                    		 	 _UnitObject = new CandlelightAngel();
		else if(id == CardIdentifier.FEVER_THERAPY_NURSE)                  		 	 _UnitObject = new FeverTherapyNurse();
		else if(id == CardIdentifier.VOCAL_CHICKEN)                        		 	 _UnitObject = new VocalChicken();
		else if(id == CardIdentifier.RECORDER_DOG)                         		 	 _UnitObject = new MelodicaCat();
		else if(id == CardIdentifier.CRIMSON_HEART__NAHAS)                 		 	 _UnitObject = new CrimsonHeartNahas();
		else if(id == CardIdentifier.PARABOLA_MOOSE)                       		 	 _UnitObject = new ParabolicMoose();
		else if(id == CardIdentifier.BARCODE_ZEBRA)                        		 	 _UnitObject = new BarcodeZebra();
		else if(id == CardIdentifier.RECORDER_DOG)                         		 	 _UnitObject = new RecorderDog();
		else if(id == CardIdentifier.PROTRACTOR_PEACOCK)                   		 	 _UnitObject = new ProtractorPeacock();
		else if(id == CardIdentifier.SHARPENER_BEAVER)                     		 	 _UnitObject = new SharpenerBeaver();
		else if(id == CardIdentifier.CASTANET_DONKEY)                      		 	 _UnitObject = new CastanetDonkey();
		else if(id == CardIdentifier.HOLY_MAGE_OF_THE_GALE)                		 	 _UnitObject = new HolyMageOfTheGale();
		else if(id == CardIdentifier.GARDENING_MOLE)                       		 	 _UnitObject = new GardeningMole();
		else if(id == CardIdentifier.STRONGHOLD_OF_THE_BLACK_CHAINS__HOEL) 		 	 _UnitObject = new StrongholdOfTheBlackChainsHoel();
		else if(id == CardIdentifier.DEATH_METAL_DROID)                    		 	 _UnitObject = new DeathMetalDroid();
		else if(id == CardIdentifier.RUNEBAU)                             		 	 _UnitObject = new Runebau();
		else if(id == CardIdentifier.SMILING_PRESENTER)                    		 	 _UnitObject = new SmilingPresenter();
		else if(id == CardIdentifier.MAGICAL_PARTNER)                      		 	 _UnitObject = new MagicalPartner();
		else if(id == CardIdentifier.DEITY_SEALING_KID__SOH_KOH)           		 	 _UnitObject = new DeitySealingKidSohKoh();
		else if(id == CardIdentifier.EXORCIST_MAGE__ROH_ROH)               		 	 _UnitObject = new ExorcistMageRohRoh();
		else if(id == CardIdentifier.EXORCIST_MAGE__LIN_LIN)               		 	 _UnitObject = new ExorcistMageLinLin();
		else if(id == CardIdentifier.DRAGONIC_LAWKEEPER)                   		 	 _UnitObject = new DragonicLawkeeper();
		else if(id == CardIdentifier.DEMON_CHARIOT_OF_THE_WITCHING_HOUR)             _UnitObject = new DemonChariotOfTheWitchingHour();
		else if(id == CardIdentifier.BEWITCHING_OFFICER__LADY_BUTTERFLY)   		 	 _UnitObject = new BewitchingOfficerLadyButterfly();
		else if(id == CardIdentifier.DUDLEY_DAISY)                         		 	 _UnitObject = new DudleyDaisy();
		else if(id == CardIdentifier.JELLY_BEANS)                          		 	 _UnitObject = new JellyBeans();
		else if(id == CardIdentifier.GIGANTECH_DESTROYER)                  		 	 _UnitObject = new GigantechDestroyer();
		else if(id == CardIdentifier.TOXIC_TROOPER)                        		 	 _UnitObject = new ToxicTrooper();
		else if(id == CardIdentifier.TOXIC_SOLDIER)                        		 	 _UnitObject = new ToxicSoldier();
		else if(id == CardIdentifier.EVIL_ARMOR_GENERAL__GIRAFFA)                    _UnitObject = new EvilArmorGeneralGiraffa();
		else if(id == CardIdentifier.BLACK_DRAGON_KNIGHT__VORTIMER)        		 	 _UnitObject = new BlackDragonKnightVortimer();
		else if(id == CardIdentifier.BLACK_DRAGON_WHELP__VORTIMER)        		 	 _UnitObject = new BlackDragonWhelpVortimer();
		else if(id == CardIdentifier.DUDLEY_DOUGLASS)                      		 	 _UnitObject = new DudleyDouglass();
		else if(id == CardIdentifier.FIERCE_LEADER__ZACHARY)               		 	 _UnitObject = new FierceLeaderZachary();
		else if(id == CardIdentifier.FIELD_DRILLER)                        		 	 _UnitObject = new FieldDriller();
		else if(id == CardIdentifier.MEDICAL_MANAGER)                      		 	 _UnitObject = new MedicalManager();
		else if(id == CardIdentifier.SMART_LEADER__DARK_BRINGER)           		 	 _UnitObject = new SmartLeaderDarkBringer();
		else if(id == CardIdentifier.IRON_FIST_MUTANT__ROLY_POLY)          		 	 _UnitObject = new IronFistMutantRolyPoly();
		else if(id == CardIdentifier.PEST_PROFESSOR__MAD_FLY)              		 	 _UnitObject = new PestProfessorMadFly();
		else if(id == CardIdentifier.TRANSMUTATED_THIEF__STEAL_SPIDER)     		 	 _UnitObject = new TransmutatedThiefStealSpider();
		else if(id == CardIdentifier.BLASTER_JAVELIN)                                _UnitObject = new Javelin();
		else if(id == CardIdentifier.MACHINING_MOSQUITO)                   		 	 _UnitObject = new MachiningMosquito();
		else if(id == CardIdentifier.WAR_HORSE__RAGING_STORM)              		 	 _UnitObject = new WarHorseRagingStorm();
		else if(id == CardIdentifier.PETAL_FAIRY)                          		 	 _UnitObject = new PetalFairy();
		else if(id == CardIdentifier.BLUE_SCALE_DEER)                      		 	 _UnitObject = new BlueScaleDeer();
		else if(id == CardIdentifier.ONMYOJI_OF_THE_MOONLIT_NIGHT)         		 	 _UnitObject = new OnmyojiOfTheMoonlitNight();
		else if(id == CardIdentifier.OMNISCIENCE_MADONNA)                  		 	 _UnitObject = new OmniscienceMadonna();
		else if(id == CardIdentifier.GRAPESHOT_WYVERN)                     		 	 _UnitObject = new GrapeshotWyvern();
		else if(id == CardIdentifier.DRAGON_ARMORED_KNIGHT)                		 	 _UnitObject = new DragonArmoredKnight();
		else if(id == CardIdentifier.MIRU_BIRU)                            		 	 _UnitObject = new MiruBiru();
		else if(id == CardIdentifier.EAGLE_KNIGHT_OF_THE_SKIES)            		 	 _UnitObject = new EagleKnightOfTheSkies();
		else if(id == CardIdentifier.COMMANDER__GARRY_GANNON)              		 	 _UnitObject = new CommanderGarryGannon();
		else if(id == CardIdentifier.GYRO_SLINGER)                         		 	 _UnitObject = new GyroSlinger();
		else if(id == CardIdentifier.DRAGONIC_EXECUTIONER)                 		 	 _UnitObject = new DragonicExecutioner();
		else if(id == CardIdentifier.TWIN_SHINE_SWORDSMAN__MARHAUS)       			 _UnitObject = new TwinShineSwordsmanMarhaus();
		else if(id == CardIdentifier.FALCON_KNIGHT_OF_THE_AZURE)           			 _UnitObject = new FalconKnightOfTheAzure();
		else if(id == CardIdentifier.BLASTER_BLADE)                        			 _UnitObject = new BlasterBlade();
		else if(id == CardIdentifier.BEAST_DEITY__WHITE_TIGER)             			 _UnitObject = new BeastDeityWhiteTiger();
		else if(id == CardIdentifier.FLASH_EDGE_VALKYRIE)                  			 _UnitObject = new FlashEdgeValkyrie();
		else if(id == CardIdentifier.MECHA_TRAINER)                        			 _UnitObject = new MechaTrainer();
		else if(id == CardIdentifier.DEMONIC_LORD__DUDLEY_EMPEROR)         			 _UnitObject = new DemonicLordDudleyEmperor();
		else if(id == CardIdentifier.SCOUT_OF_DARKNESS__VORTIMER)         			 _UnitObject = new ScoutOfDarknessVortimer();
		else if(id == CardIdentifier.BLADE_FEATHER_VALKYRIE)              			 _UnitObject = new BladeFeatherValkyrie();
		else if(id == CardIdentifier.MEGACOLONY_BATTLER_C)                 			 _UnitObject = new MegacolonyBattlerC();
		else if(id == CardIdentifier.GIRLS______ROCK__RIO)                 			 _UnitObject = new GirlsRockRio();
		else if(id == CardIdentifier.INFINITE_CORROSION_FORM__DEATH_ARMY_COSMO_LORD) _UnitObject = new InfiniteCorrosionFormDeathArmyLord();
		else if(id == CardIdentifier.DEATH_ARMY_BISHOP)                              _UnitObject = new DeathArmyBishop();
		else if(id == CardIdentifier.BRUTAL_JOKER)                                   _UnitObject = new BrutalJoker();
		else if(id == CardIdentifier.DEATH_ARMY_KNIGHT)                              _UnitObject = new DeathArmyKnight();
		else if(id == CardIdentifier.DEATH_ARMY_PAWN)                                _UnitObject = new DeathArmyPawn();
		else if(id == CardIdentifier.BATTLE_SISTER__FROMAGE)                         _UnitObject = new BattleSisterFromage();
		else if(id == CardIdentifier.BATTLE_SISTER__MACARON)                         _UnitObject = new BattleSisterMacaron();
		else if(id == CardIdentifier.BATTLE_SISTER__OMELET)                          _UnitObject = new BattleSisterOmelet();
		else if(id == CardIdentifier.BATTLE_SISTER__WAFFLE)                          _UnitObject = new BattleSisterWaffle();
		else if(id == CardIdentifier.ETERNAL_IDOL__PACIFICA)                         _UnitObject = new EternalIdolPacifica();
		else if(id == CardIdentifier.PR___ISM_PROMISE__LABRADOR)                     _UnitObject = new PRISMPromiseLabrador();
		else if(id == CardIdentifier.PR___ISM_IMAGE__VERT)                           _UnitObject = new PRISMImageVert();
		else if(id == CardIdentifier.RECKLESS_EXPRESS)                               _UnitObject = new RecklessExpress();
		else if(id == CardIdentifier.HIGHSPEED_BRAKKI)                               _UnitObject = new HighspeedBrakki();
		else if(id == CardIdentifier.JUGGERNAUT_MAXIMUM)                             _UnitObject = new JuggernautMaximum();
		else if(id == CardIdentifier.SPECTRAL_DUKE_DRAGON)                           _UnitObject = new SpectralDukeDragon();
		else if(id == CardIdentifier.PR___ISM_PROMISE__CELTIC)                       _UnitObject = new PRISMPromiseCeltic();
		else if(id == CardIdentifier.DRAGON_MONK_GOKU)                               _UnitObject = new DragonMonkGoku();
		else if(id == CardIdentifier.GODDESS_OF_THE_SUN__AMATERASU)                  _UnitObject = new GoddessOfTheSunAmaterasu();
		else if(id == CardIdentifier.AURORA_STAR__CORAL)                             _UnitObject = new AuroraStarCoral();
		else if(id == CardIdentifier.LAVA_ARM_DRAGON)                                _UnitObject = new LavaArmDragon();
		else if(id == CardIdentifier.PR___ISM_IMAGE__CLEAR)                          _UnitObject = new PRISMImageClear();
		else if(id == CardIdentifier.SHINING_SINGER__IONIA)                          _UnitObject = new ShiningSingerIonia();
		else if(id == CardIdentifier.SHINY_STAR__CORAL)                              _UnitObject = new ShinyStarCoral();
		else if(id == CardIdentifier.KNIGHT_OF_THE_HARP_TRISTAN)                     _UnitObject = new KnightOfTheHarpTristan();
		else if(id == CardIdentifier.PR___ISM_ROMANCE__LUMIERE)                      _UnitObject = new PRISMRomanceLumiere();
		else if(id == CardIdentifier.ENIGMAN_RIPPLE)                                 _UnitObject = new EnigmanRipple();
		else if(id == CardIdentifier.PR___ISM_ROMANCE__MERCURE)                      _UnitObject = new PRISMRomanceMercure();
		else if(id == CardIdentifier.ULTRA_BEAST_DEITY__ILLUMINAL_DRAGON)            _UnitObject = new UltraBeastDeityIlluminalDragon();
		else if(id == CardIdentifier.SWEETS_HARMONY__MONA)                           _UnitObject = new SweetsHarmonyMona();
		else if(id == CardIdentifier.ANGELIC_STAR__CORAL)                            _UnitObject = new AngelicStarCoral();
		else if(id == CardIdentifier.MIRROR_DIVA__BISCAYNE)                          _UnitObject = new MirrorDivaBiscayne();
		else if(id == CardIdentifier.INTELLI_BEAUTY__LOIRE)                          _UnitObject = new IntelliBeautyLoire();
		else if(id == CardIdentifier.DANCING_FAN_PRINCESS__MINATO)                   _UnitObject = new DancingFanPrincessMinato();
		else if(id == CardIdentifier.PR___ISM_ROMANCE__ETOILE)                       _UnitObject = new PRISMRomanceEtolle();
		else if(id == CardIdentifier.PR___ISM_IMAGE__ROSA)                           _UnitObject = new PRISMImageRosa();
		else if(id == CardIdentifier.PR___ISM_SMILE__SCOTIA)                         _UnitObject = new PRISMSmileScotia();
		else if(id == CardIdentifier.ALFRED_EARLY)                                   _UnitObject = new AlfredEarly();
		else if(id == CardIdentifier.HOLY_DISASTER_DRAGON)                           _UnitObject = new HolyDisasterDragon();
		else if(id == CardIdentifier.FRESH_STAR__CORAL)                              _UnitObject = new FreshStarCoral();
		else if(id == CardIdentifier.PR___ISM_PROMISE__LEYTE)                        _UnitObject = new PRISMPromiseLeyte();
		else if(id == CardIdentifier.MASCOT_LADY__ORIA)                              _UnitObject = new MascotLadyOria();
		else if(id == CardIdentifier.LIBRARY_MADONNA__RION)                          _UnitObject = new LibraryMadonnaRion();
		else if(id == CardIdentifier.DOLPHIN_FRIEND__PLAGE)                          _UnitObject = new DolphinFriendPlage();
		else if(id == CardIdentifier.PR___ISM_SMILE__CORO)                           _UnitObject = new PRISMSmileCoro();
		else if(id == CardIdentifier.COSTUME_CHANGE__ALK)                            _UnitObject = new CostumeChangeAlk();
		else if(id == CardIdentifier.DEADLY_SWORDMASTER)                             _UnitObject = new DeadlySwordmaster();
		else if(id == CardIdentifier.PR___ISM_MIRACLE__IRISH)                        _UnitObject = new PRISMMiracleIrish();
		else if(id == CardIdentifier.HADES_CARRIAGE_OF_THE_WITCHING_HOUR)            _UnitObject = new HadesCarriageOfTheWitchingHour();
		else if(id == CardIdentifier.HEARTFUL_ALE__FUNDY)                            _UnitObject = new HeartfulAleFundy();
		else if(id == CardIdentifier.PRETTY_CELEB__CHARLOTTE)                        _UnitObject = new PrettyCelebCharlotte();
		else if(id == CardIdentifier.STEEL_SPEAR_LIBERATOR__BLEOBERIS)               _UnitObject = new SteelSpearLiberatorBleoberis();
		else if(id == CardIdentifier.WISDOM_KEEPER__METIS)                           _UnitObject = new WisdomKeeperMetis();
		else if(id == CardIdentifier.ERADICATOR__ELECTRIC_SHAPER_DRAGON)             _UnitObject = new EradicatorElectricShaperDragon();
		else if(id == CardIdentifier.STORY_TELLER)                                   _UnitObject = new StoryTeller();
		else if(id == CardIdentifier.DANDELION_MUSKETEER__MIRKKA)                    _UnitObject = new DandelionMusketeerMirkka();
		else if(id == CardIdentifier.UNRIVALED_BRUSH_WIELDER__PONGA)                 _UnitObject = new UnrivaledBrushWielderPonga();
		else if(id == CardIdentifier.WATER_GENERAL_OF_WAVE_LIKE_SPIRALS__BENEDICT)   _UnitObject = new WaterGeneralOfWavelikeSpiralsBenedict();
		else if(id == CardIdentifier.EMERALD_SHIELD__PASCHAL)                        _UnitObject = new EmeraldShieldPaschal();
		else if(id == CardIdentifier.BATTLE_SISTER_CHOCOLAT)                         _UnitObject = new BattleSisterChocolat();
		else if(id == CardIdentifier.FLASH_SHIELD_ISEULT)                            _UnitObject = new FlashShieldIseult();
		else if(id == CardIdentifier.CABLE_SHEEP)                                    _UnitObject = new CableSheep();
		else if(id == CardIdentifier.WYVERN_GUARD__GULD)                             _UnitObject = new WyvernGuardGuld();
		else if(id == CardIdentifier.HALO_SHIELD__MARK)                              _UnitObject = new HaloShieldMark();
		else if(id == CardIdentifier.PURE_KEEPER__REQUIEL)                           _UnitObject = new PureKeeperRequiel();
		else if(id == CardIdentifier.MAIDEN_OF_BLOSSOM_RAIN)                         _UnitObject = new MaidenOfBlossomRain();
		else if(id == CardIdentifier.STEALTH_BEAST__LEAVES_MIRAGE)                   _UnitObject = new StealthBeastLeavesMirage();
		else if(id == CardIdentifier.PARALYZE_MADONNA)                               _UnitObject = new ParalyzeMadonna();
		else if(id == CardIdentifier.DIAMOND_ACE)                                    _UnitObject = new DiamondAce();
		else if(id == CardIdentifier.DARK_SHIELD__MAC_LIR)                           _UnitObject = new DarkShieldMacLir();
		else if(id == CardIdentifier.DEVOURER_OF_PLANETS__ZEAL)                      _UnitObject = new DevourerOfPlanetsZeal();
		else if(id == CardIdentifier.MERMAID_IDOL__ELLY)                             _UnitObject = new MermaidIdolElly();
		else if(id == CardIdentifier.HADES_HYPNOTIST)                                _UnitObject = new HadesHypnotist();
		else if(id == CardIdentifier.ARCHBIRD)                                       _UnitObject = new Archbird();
		else if(id == CardIdentifier.MARCH_RABBIT_OF_NIGHTMARELAND)                  _UnitObject = new MarchRabbitOfNightmareland();
		else if(id == CardIdentifier.TWIN_BLADER)                                    _UnitObject = new TwinBlader();
		else if(id == CardIdentifier.GUST_JINN)                                      _UnitObject = new GustJinn();
		else if(id == CardIdentifier.WYVERN_GUARD_BARRI)                             _UnitObject = new WyvernGuardBarri();
		else if(id == CardIdentifier.CHEER_GIRL_MARILYN)                             _UnitObject = new CheerGirlMarylin();
		else if(id == CardIdentifier.HEXAGONAL_MAGUS)                                _UnitObject = new HexagonalMagus();
		else if(id == CardIdentifier.BATTLE_SISTER__PARFAIT)                         _UnitObject = new BattleSisterParfait();
		else if(id == CardIdentifier.BATTLE_SISTER__MONAKA)                          _UnitObject = new BattleSisterMonaka();
		else if(id == CardIdentifier.STELLAR_MAGUS)                                  _UnitObject = new StellarMagus();
		else if(id == CardIdentifier.BATTLE_SISTER__COCOTTE)                         _UnitObject = new BattleSisterCocotte();
		else if(id == CardIdentifier.BRIOLETTE_MAGUS)                                _UnitObject = new BrioletteMagus();
		else if(id == CardIdentifier.TETRA_MAGUS)                                    _UnitObject = new TetraMagus();
		else if(id == CardIdentifier.ORACLE_AGENT__ROYS)                             _UnitObject = new OracleAgentRoys();
		else if(id == CardIdentifier.CRESCENT_MAGUS)                                 _UnitObject = new CrescentMagus();
		else if(id == CardIdentifier.CUORE_MAGUS)                                    _UnitObject = new CuoreMagus();
		else if(id == CardIdentifier.RIPIS_MAGUS)                                    _UnitObject = new RipisMagus();
		else if(id == CardIdentifier.SAILAND_MAGUS)                                  _UnitObject = new SailandMagus();
		else if(id == CardIdentifier.BATTLE_SISTER__CARAMEL)                         _UnitObject = new BattleSisterCaramel();
		else if(id == CardIdentifier.BATTLE_SISTER__LEMONADE)                        _UnitObject = new BattleSisterLemonade();
		else if(id == CardIdentifier.PENTAGONAL_MAGUS)                               _UnitObject = new PentagonalMagus();
		else if(id == CardIdentifier.CIRCLE_MAGUS)                                   _UnitObject = new CircleMagus();
		else if(id == CardIdentifier.IMMORTAL__ASURA_KAISER)                         _UnitObject = new ImmortalAsuraKaiser();
		else if(id == CardIdentifier.ASURA_KAISER)                                   _UnitObject = new AsuraKaiser();
		else if(id == CardIdentifier.GALAXY_BLAUKLUGER)                              _UnitObject = new GalaxyBlaukluger();
		else if(id == CardIdentifier.MOND_BLAUKLUGER)                                _UnitObject = new MondBlaukluger();
		else if(id == CardIdentifier.MARS_BLAUKLUGER)                                _UnitObject = new MarsBlaukluger();
		else if(id == CardIdentifier.FLOWER_LEI_LEPRECHAUN)                          _UnitObject = new FlowerLeiLeprechaun();
		else if(id == CardIdentifier.DEMON_OF_ASPIRATION__AMON)                      _UnitObject = new DemonOfAspirationAmon();
		else if(id == CardIdentifier.GROSSE_BAER)                                    _UnitObject = new GrosseBaer();
		else if(id == CardIdentifier.DAREDEVIL_SAMURAI)                              _UnitObject = new DaredevilSamurai();
		else if(id == CardIdentifier.POLAR_STERN)                                    _UnitObject = new PolarStern();
		else if(id == CardIdentifier.MORGENROT)                                      _UnitObject = new Morgenrot();
		else if(id == CardIdentifier.PLUTO_BLAUKLUGER)                               _UnitObject = new PlutoBlaukluger();
		else if(id == CardIdentifier.FATE_HEALER__ERGODIEL)                          _UnitObject = new FeatherHealerErgodiel();
		else if(id == CardIdentifier.TAIL_JOE)                                       _UnitObject = new TailJoe();
		else if(id == CardIdentifier.BEAR_DOWN_SAMURAI)                              _UnitObject = new BearDownSamurai();
		else if(id == CardIdentifier.BLADE_ARM_LEPRECHAUN)                           _UnitObject = new BladeArmLeprechaun();
		else if(id == CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE)  _UnitObject = new TranscendenceDragonDragonicNouvelleVague();
		else if(id == CardIdentifier.CRUEL_DRAGON)                                   _UnitObject = new CruelDragon();
		else if(id == CardIdentifier.BLAST_BULK_DRAGON)                              _UnitObject = new BlastBulkDragon();
		else if(id == CardIdentifier.IRONCUTTER_BEETLE)                              _UnitObject = new Ironcutter();
		else if(id == CardIdentifier.NOUVELLECRITIC_DRAGON)                          _UnitObject = new NouvellecriticDragon();
		else if(id == CardIdentifier.DRAGONIC_GAIAS)                                 _UnitObject = new DragonicGaias();
		else if(id == CardIdentifier.DRAGON_DANCER__MARIA)                           _UnitObject = new DragonDancerMaria();
		else if(id == CardIdentifier.PUPA_MUTANT__GIRAFFA)                           _UnitObject = new PupaMutantGiraffa();
		else if(id == CardIdentifier.DRAGON_KNIGHT__NESHART)                         _UnitObject = new DragonKnightNeshart();
		else if(id == CardIdentifier.DRAGON_KNIGHT__ASHGAR)                          _UnitObject = new DragonKnightAshgar();
		else if(id == CardIdentifier.NOUVELLEROMAN_DRAGON)                           _UnitObject = new NouvelleromanDragon();
		else if(id == CardIdentifier.DRAGON_KNIGHT__MORTEZA)                         _UnitObject = new DragonKnightMorteza();
		else if(id == CardIdentifier.BAKINGRIM_DRAGON)                               _UnitObject = new BakingrimDragon();
		else if(id == CardIdentifier.GENIE_SOLDAT)                                   _UnitObject = new GenieSoldat();
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__KONGARA)                   _UnitObject = new DemonicDragonMageKongara();
		else if(id == CardIdentifier.SCALE_DRAGON_OF_THE_MAGMA_CAVE)                 _UnitObject = new ScaleDragonOfTheMagmaCave();
		else if(id == CardIdentifier.SOLITARY_LIBERATOR__GANCELOT)                   _UnitObject = new SolitaryLiberatorGancelot();
		else if(id == CardIdentifier.DIGNIFIED_GOLD_DRAGON)                          _UnitObject = new DignifiedGoldDragon();
		else if(id == CardIdentifier.ONSLAUGHT_LIBERATOR__MAELZION)                  _UnitObject = new OnslaughtLiberatorMaelzion();
		else if(id == CardIdentifier.LIBERATOR_OF_ROYALTY__PHALLON)                  _UnitObject = new LiberatorOfRoyaltyPhallon();
		else if(id == CardIdentifier.BLASTER_BLADE_LIBERATOR)                        _UnitObject = new BlasterBladeLiberator();
		else if(id == CardIdentifier.ZOOM_DOWN_EAGLE)                                _UnitObject = new ZoomDownEagle();
		else if(id == CardIdentifier.ZOIGAL_LIBERATOR)                               _UnitObject = new ZoigalLiberator();
		else if(id == CardIdentifier.LITTLE_LIBERATOR__MARRON)                       _UnitObject = new LittleLiberatorMarron();
		else if(id == CardIdentifier.POMERUGAL_LIBERATOR)                            _UnitObject = new PomerugalLiberator();
		else if(id == CardIdentifier.FUTURE_LIBERATOR__LLEW)                         _UnitObject = new FutureLiberatorLlew();
		else if(id == CardIdentifier.ERADICATOR__VOWING_SWORD_DRAGON)                _UnitObject = new EradicatorVowingSwordDragon();
		else if(id == CardIdentifier.BARRAGE_ERADICATOR__ZION)                       _UnitObject = new BarrageEradicatorZion();
		else if(id == CardIdentifier.DISCHARGING_DRAGON)                             _UnitObject = new DischargingDragon();
		else if(id == CardIdentifier.ERADICATOR__SPARK_RAIN_DRAGON)                  _UnitObject = new EradicatorSparkRainDragon();
		else if(id == CardIdentifier.ASSASSIN_SWORD_ERADICATOR__SUSEI)               _UnitObject = new AssassinSwordEradicatorSusei();
		else if(id == CardIdentifier.DRAGON_DANCER__VERONICA)                        _UnitObject = new DragonDancerVeronica();
		else if(id == CardIdentifier.LIGHTNING_BLADE_ERADICATOR__JEEM)               _UnitObject = new LightingBladeEradicatorJeem();
		else if(id == CardIdentifier.ERADICATOR__DEMOLITION_DRAGON)                  _UnitObject = new EradicatorDemolitionDragon();
		else if(id == CardIdentifier.DUST_STORM_ERADICATOR__TOKO)                    _UnitObject = new DustStormEradicatorToko();
		else if(id == CardIdentifier.ERADICATOR_OF_FIRE__KOHKAIJI)                   _UnitObject = new EradicatorOfFireKohkaiji();
		else if(id == CardIdentifier.IMPERIAL_DAUGHTER)                              _UnitObject = new ImperialDaughter();
		else if(id == CardIdentifier.ILLUSIONARY_REVENGER__MORDRED_PHANTOM)          _UnitObject = new IllusionaryRevengerMordredPhantom();
		else if(id == CardIdentifier.VENOMOUS_BREATH_DRAGON)                         _UnitObject = new VenomousBreathDragon();
		else if(id == CardIdentifier.REVENGER_OF_LABYRINTH__ARAUN)                   _UnitObject = new RevengerOfLabyrinthAraun();
		else if(id == CardIdentifier.NULLITY_REVENGER__MASQUERADE)                   _UnitObject = new NullityRevengerMasquerade();
		else if(id == CardIdentifier.BLASTER_DARK_REVENGER)                          _UnitObject = new BlasterDarkRevenger();
		else if(id == CardIdentifier.COILBAU_REVENGER)                               _UnitObject = new ColibauRevenger();
		else if(id == CardIdentifier.REVENGER_FORTRESS__FATALITA)                    _UnitObject = new RevengerFortressFatalita();
		else if(id == CardIdentifier.SACRILEGE_REVENGER__BERITH)                     _UnitObject = new SacrilegeRevengerBerith();
		else if(id == CardIdentifier.TRANSIENT_REVENGER__MASQUERADE)                 _UnitObject = new TransientRevengerMasquerade();
		else if(id == CardIdentifier.BURANBAU_REVENGER)                              _UnitObject = new BuranbauRevenger();
		else if(id == CardIdentifier.STAR_VADER__INFINITE_ZERO_DRAGON)               _UnitObject = new StarvaderInfiniteZeroDragon();
		else if(id == CardIdentifier.RAID_STAR_VADER__FRANCIUM)                      _UnitObject = new RaidStarvaderFrancium();
		else if(id == CardIdentifier.TWILIGHT_BARON)                                 _UnitObject = new TwilightBaron();
		else if(id == CardIdentifier.STAR_VADER__MOBIUS_BREATH_DRAGON)               _UnitObject = new StarvaderMobiusBreathDragon();
		else if(id == CardIdentifier.ENIGMAN_WAVE)                                   _UnitObject = new EnigmanWave();
		else if(id == CardIdentifier.AMBER_DRAGON__DAYLIGHT)                         _UnitObject = new AmberDragonDaylight();
		else if(id == CardIdentifier.UNRIVALED_STAR_VADER__RADON)                    _UnitObject = new UnrivaledStarvaderRadon();
		else if(id == CardIdentifier.STAR_VADER__PULSAR_BEAR)                        _UnitObject = new StarvaderPulsarBear();
		else if(id == CardIdentifier.SWIFT_STAR_VADER__STRONTIUM)                    _UnitObject = new SwiftStarvaderStrontium();
		else if(id == CardIdentifier.PURSUIT_STAR_VADER__FERMIUM)                    _UnitObject = new PursuitStarvaderFermium();
		else if(id == CardIdentifier.DEMONIC_BULLET_STAR_VADER__NEON)                _UnitObject = new DemonicBulletStarvaderNeon();
		else if(id == CardIdentifier.STAR_VADER__AURORA_EAGLE)                       _UnitObject = new StarvaderAuroraEagle();
		else if(id == CardIdentifier.TOP_IDOL__PACIFICA)                             _UnitObject = new TopIdolPacifica();
		else if(id == CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAIKAISER)              _UnitObject = new SuperDimensionalRoboDaikaiser();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__GOYUSHA)                      _UnitObject = new DimensionalRoboGoyusha();
		else if(id == CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAIYUSHA)               _UnitObject = new SuperDimensionalRoboDaiyusha();
		else if(id == CardIdentifier.ELECTRO_STAR_COMBINATION__COSMOGREAT)           _UnitObject = new ElectrostarCombinationCosmogreat();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__KAIZARD)                      _UnitObject = new DimensionalRoboKaizard();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIDRILLER)                   _UnitObject = new DimensionalRoboDaidriller();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAITIGER)                     _UnitObject = new DimensionalRoboDaitiger();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIBRAVE)                     _UnitObject = new DimensionalRoboDaibrave();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIMARINER)                   _UnitObject = new DimensionalRoboDaimariner();
		else if(id == CardIdentifier.REGALIA_OF_WISDOM__ANGELICA)                    _UnitObject = new RegaliaOfWisdomAngelica();
		else if(id == CardIdentifier.BATTLE_MAIDEN__MIZUHA)                          _UnitObject = new BattleMaidenMizuha();
		else if(id == CardIdentifier.WITCH_OF_WOLVES__SAFFRON)                       _UnitObject = new WitchOfWolvesSaffron();
		else if(id == CardIdentifier.BATTLE_MAIDEN__SAHOHIME)                        _UnitObject = new BattleMaidenSahohime();
		else if(id == CardIdentifier.GODDESS_OF_TREES__JUPITER)                      _UnitObject = new GoddessOfTreesJupiter();
		else if(id == CardIdentifier.BATTLE_MAIDEN__SHITATERUHIME)                   _UnitObject = new BattleMaidenShitateruhime();
		else if(id == CardIdentifier.BATTLE_MAIDEN__TATSUTAHIME)                     _UnitObject = new BattleMaidenTatsuhime();
		else if(id == CardIdentifier.EXISTENCE_ANGEL)                                _UnitObject = new ExistenceAngel();
		else if(id == CardIdentifier.WITCH_OF_CATS__CUMIN)                           _UnitObject = new WitchOfCatsCumin();
		else if(id == CardIdentifier.APPLE_WITCH__CIDER)                             _UnitObject = new AppleWitchCider();
		else if(id == CardIdentifier.ENIGROID_COMRADE)                               _UnitObject = new Comrade();
		else if(id == CardIdentifier.SANCTUARY_GUARD_DRAGON)                         _UnitObject = new SanctuaryGuardDragon();
		else if(id == CardIdentifier.PATHETIC_JEWEL_KNIGHT__OLWEN)                   _UnitObject = new PatheticJewelKnightOlwen();
		else if(id == CardIdentifier.BATTLE_FLAG_KNIGHT__CONSTANCE)                  _UnitObject = new BattleFlagKnightConstance();
		else if(id == CardIdentifier.REGRET_JEWEL_KNIGHT__URIEN)                     _UnitObject = new RegretJewelKnightUrien();
		else if(id == CardIdentifier.RENDGAL)                                        _UnitObject = new Rendgal();
		else if(id == CardIdentifier.RAINBOW_CALLING_BARD)                           _UnitObject = new RainbowcallingBard();
		else if(id == CardIdentifier.STARTING_LEGEND__AMBROSIUS)                     _UnitObject = new StartingLegendAmbrosius();
		else if(id == CardIdentifier.KNIGHT_OF_CONVICTION_BORS)                      _UnitObject = new KnightOfConvictionBors();
		else if(id == CardIdentifier.LEADING_JEWEL_KNIGHT__SALOME)                   _UnitObject = new LeadingJewelKnightSalome();
		else if(id == CardIdentifier.PURE_HEART_JEWEL_KNIGHT__ASHLEY)                _UnitObject = new PureHeartJewelKnightAshlei();
		else if(id == CardIdentifier.LIBERATOR_OF_THE_ROUND_TABLE__ALFRED)           _UnitObject = new LiberatorOfTheRoundTableAlfred();
		else if(id == CardIdentifier.ORACLE_QUEEN__HIMIKO)                           _UnitObject = new OracleQueenHimiko();
		else if(id == CardIdentifier.ETERNAL_GODDESS__IWANAGAHIME)                   _UnitObject = new EternalGoddessIwanagahime();
		else if(id == CardIdentifier.KING_OF_DIPTERA__BEELZEBUB)                     _UnitObject = new KingOfDipteraBeelzebub();
		else if(id == CardIdentifier.LAW_OFFICIAL__LOX)                              _UnitObject = new LawOfficialLox();
		else if(id == CardIdentifier.DARK_LORD_OF_ABYSS)                             _UnitObject = new DarkLordOfAbyss();
		else if(id == CardIdentifier.ERADICATOR__DRAGONIC_DESCENDANT)                _UnitObject = new EradicatorDragonicDescendant();
		else if(id == CardIdentifier.ERADICATOR__GAUNTLET_BUSTER_DRAGON)             _UnitObject = new EradicatorGauntletBusterDragon();
		else if(id == CardIdentifier.BEAST_DEITY__ETHICS_BUSTER)                     _UnitObject = new BeastDeityEthicsBuster();
		else if(id == CardIdentifier.BATTLE_DEITY_OF_THE_NIGHT__ARTEMIS)             _UnitObject = new BattleDeityOfTheNightArtemis();
		else if(id == CardIdentifier.GRATEFUL_CATAPULT)                              _UnitObject = new GratefulCatapult();
		else if(id == CardIdentifier.BAD_END_DRAGGER)                                _UnitObject = new BadEndDragger();
		else if(id == CardIdentifier.LAKE_MAIDEN_LIEN)                               _UnitObject = new LakeMaidenLien();
		else if(id == CardIdentifier.DEMON_WORLD_MARQUIS__AMON)                      _UnitObject = new DemonWorldMarquisAmon();
        else if(id == CardIdentifier.DIGNIFIED_SILVER_DRAGON)                        _UnitObject = new DignifiedSilverDragon();
        else if(id == CardIdentifier.MARTIAL_ARTS_GENERAL__DAIMU)                    _UnitObject = new MartialArtsGeneralDaim();
        else if(id == CardIdentifier.ARMORED_HEAVY_GUNNER)                           _UnitObject = new ArmoredHeavyGunner();
		else if(id == CardIdentifier.ARBOROS_DRAGON__TIMBER)                         _UnitObject = new ArborosDragonTimber();
        else if(id == CardIdentifier.RABBIT_HOUSE)                                   _UnitObject = new RabbitHouse();
        else if(id == CardIdentifier.KNIGHT_OF_EXPLOSIVE_AXE__GORNEMAN)              _UnitObject = new KnightOfTheExplosiveAxeGornement();
        else if(id == CardIdentifier.MUUNGAL)                                        _UnitObject = new Muungal();
        else if(id == CardIdentifier.MICE_GUARD__ANTARES)                            _UnitObject = new MythGuardAntares();
        else if(id == CardIdentifier.DEMONIC_DRAGON_BERSERKER__JANDIRA)              _UnitObject = new DemonicDagonBerserkerSandila();
        else if(id == CardIdentifier.ANTI_BATTLEROID_GUNNER)                         _UnitObject = new AntibattleroidGunner();
        else if(id == CardIdentifier.SCHEDULER_ANGEL)                                _UnitObject = new SchedulerAngel();
        else if(id == CardIdentifier.DOGMATIZE_JEWEL_KNIGHT__SYBILL)                 _UnitObject = new DogmatizeJewelKnightSybill();
		else if(id == CardIdentifier.LIGHTNING_SWORD_WIELDING_EXORCIST_KNIGHT)       _UnitObject = new LightingSwordWieldingExorcistKnight();
        else if(id == CardIdentifier.FLASHING_JEWEL_KNIGHT__ISEULT)                  _UnitObject = new FlashingJewelKnightIseult();
        else if(id == CardIdentifier.HALO_LIBERATOR__MARK)                           _UnitObject = new HaloLiberatorMark();
        else if(id == CardIdentifier.LIBERATOR_OF_THE_FLUTE__ESCRAD)                 _UnitObject = new LiberatorOfTheFluteEscrad();
        else if(id == CardIdentifier.BROOM_WITCH__CARAWAY)                           _UnitObject = new BroomWitchCallaway();
        else if(id == CardIdentifier.GODDESS_OF_SELF_SACRIFICE__KUSHINADA)           _UnitObject = new GoddessOfSelfSacrificeKushinada();
        else if(id == CardIdentifier.ERADICATOR_WYVERN_GUARD__GULD)                  _UnitObject = new EradicatorWyvernGuardGuld();
        else if(id == CardIdentifier.SUPREME_ARMY_ERADICATOR__ZUITAN)                _UnitObject = new SupremeArmyEradicatorZuitan();
        else if(id == CardIdentifier.FELLOWSHIP_JEWEL_KNIGHT__TRACIE)                _UnitObject = new FellowshipJewelKnightTracie();
        else if(id == CardIdentifier.JEWEL_KNIGHT__PRIZME)                           _UnitObject = new JewelKinghtPizmy();
		else if(id == CardIdentifier.DREAMING_JEWEL_KNIGHT__TIFFANY)                 _UnitObject = new DreamingJewelKnightTiffany();
        else if(id == CardIdentifier.CURVED_BLADE_LIBERATOR__JOSEPHUS)               _UnitObject = new FastChaseLiberatorJosephus();
        else if(id == CardIdentifier.WINGAL_LIBERATOR)                               _UnitObject = new WingalLiberator();
        else if(id == CardIdentifier.TWILIGHT_HUNTER__ARTEMIS)                       _UnitObject = new TwilightHunterArtemis();
        else if(id == CardIdentifier.BATTLE_MAIDEN__TAMAYORIHIME)                    _UnitObject = new BattleMaidenTamayorihime();
        else if(id == CardIdentifier.AIMING_FOR_THE_STARS__ARTEMIS)                  _UnitObject = new AimingForTheStarsArtemis();
        else if(id == CardIdentifier.TWIN_GUN_ERADICATOR__HAKUSHOU)                  _UnitObject = new DoubleGunEradicatorNakusho();
        else if(id == CardIdentifier.ERADICATOR__SAUCER_CANNON_WYVERN)               _UnitObject = new EradicatorSaucerCannonWyvern();
        else if(id == CardIdentifier.ERADICATOR_OF_THE_CEREMONIAL_BONFIRE__CASTOR)   _UnitObject = new CeremonialBonfireEradicatorCastor();
        else if(id == CardIdentifier.AMBUSH_DRAGON_ERADICATOR__LINCHU)               _UnitObject = new AmbushDragonEradicatorLinchu();
        else if(id == CardIdentifier.BEAST_DEITY__HATRED_CHAOS)                      _UnitObject = new BeastDeityHatrdChaos();
        else if(id == CardIdentifier.DUDLEY_MASON)                                   _UnitObject = new DudleyMason();
        else if(id == CardIdentifier.UNCOMPROMISING_KNIGHT__IDELL)                   _UnitObject = new UncompromisingKnightIdeale();
		else if(id == CardIdentifier.GIGANTECH_DOZER)                                _UnitObject = new GigantechDozer();
        else if(id == CardIdentifier.DELICATE_KNIGHT__CLAUDIN)                       _UnitObject = new KnightOfDetailsClaudin();
        else if(id == CardIdentifier.STINGING_JEWEL_KNIGHT__SHERRIE)                 _UnitObject = new StingingJewelKnightShellie();
        else if(id == CardIdentifier.RUSHGAL)                                        _UnitObject = new Rushhgal();
        else if(id == CardIdentifier.PRIMGAL)                                        _UnitObject = new Primgal();
        else if(id == CardIdentifier.KNIGHT_OF_FAR_BOW__SAFIR)                       _UnitObject = new KnightOfFarArrowsSaphir();
        else if(id == CardIdentifier.KNIGHT_OF_BREAK_FIST__SEGWARIDES)               _UnitObject = new BoulderSmashingKnightSegwarides();
        else if(id == CardIdentifier.GUIDING_FALCONEE)                               _UnitObject = new GuidingFalcony();
        else if(id == CardIdentifier.LIBERATOR__FLARE_MANE_STALLION)                 _UnitObject = new LiberatorFlareManeStallion();
        else if(id == CardIdentifier.HOLY_SQUIRE__ENIDE)                             _UnitObject = new HolySquireEnide();
        else if(id == CardIdentifier.CLEVER_JAKE)                                    _UnitObject = new CleverJake();
        else if(id == CardIdentifier.WITCH_OF_OWLS__PAPRIKA)                         _UnitObject = new WitchOfOwlsPaprika();
        else if(id == CardIdentifier.MICE_GUARD__ORION)                              _UnitObject = new MythGuardOrion();
        else if(id == CardIdentifier.BOWSTRING_OF_HEAVEN_AND_EARTH__ARTEMIS)         _UnitObject = new BowstringOfHeavenAndEarthArtemis();
		else if(id == CardIdentifier.BLADE_WING_REIJY)                               _UnitObject = new BladeWingReijy();
        else if(id == CardIdentifier.SNIPE_SNAKE)                                    _UnitObject = new SnipeSnake();
        else if(id == CardIdentifier.MICE_GUARD__SIRIUS)                             _UnitObject = new MythGuardSirius();
        else if(id == CardIdentifier.CLUSTER_HAMSTER)                                _UnitObject = new ClusterHamster();
        else if(id == CardIdentifier.BATTLE_MAIDEN__KUKURIHIME)                      _UnitObject = new BattleMaidenKukurihime();
        else if(id == CardIdentifier.BLOOD_AXE_DRAGOON)                              _UnitObject = new BloodAxeDragoon();
        else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__MAJIRA)                    _UnitObject = new DemonicDragonMageMajila();
        else if(id == CardIdentifier.SWORD_DANCE_ERADICATOR__HISEN)                  _UnitObject = new SwordDancerEradicatorHisen();
        else if(id == CardIdentifier.DRAGON_DANCER__AGNES)                           _UnitObject = new DragonDancerAgnes();
        else if(id == CardIdentifier.THUNDER_FIST_ERADICATOR__DOUI)                  _UnitObject = new LightingFistEradicatorDui();
        else if(id == CardIdentifier.ERADICATOR__STRIKE_DAGGER_DRAGON)               _UnitObject = new EradicatorStrikedaggerDragon();
		else if(id == CardIdentifier.DJINN_OF_THE_CLAPPING_THUNDER)                  _UnitObject = new DjinnOfTheThunderBreak();
		else if(id == CardIdentifier.BLOODY_RAIN)                                    _UnitObject = new BloodyReign();
		else if(id == CardIdentifier.BEAST_DEITY__HILARITY_DESTROYER)                _UnitObject = new BeastDeityHilarityDestroyer();
		else if(id == CardIdentifier.MACHINERY_ANGEL)                                _UnitObject = new MachineryAngel();
		else if(id == CardIdentifier.BEAST_DEITY__RIOT_HORN)                         _UnitObject = new BeastDeityRiotHorn();
		else if(id == CardIdentifier.BATTLE_ARM_LEPRECHAUN)                          _UnitObject = new BattleArmLeprechaun();
		else if(id == CardIdentifier.BLOW_KISS__OLIVIA)                              _UnitObject = new BlowKissOlivia();
		else if(id == CardIdentifier.GO_FOR_BREAK)                                   _UnitObject = new GoForBroke();
		else if(id == CardIdentifier.CHARGING_BILL_COLLECTOR)                        _UnitObject = new ChargingBillCollector();
		else if(id == CardIdentifier.UFO)                                            _UnitObject = new UFOUnluckyFlyingObject();
		else if(id == CardIdentifier.TYRANT_RECEIVER)                                _UnitObject = new TyrantReceiver();
		else if(id == CardIdentifier.DUDLEY_PHANTOM)                                 _UnitObject = new DudleyPhantom();
		else if(id == CardIdentifier.REIGN_OF_TERROR__THERMIDOR)                     _UnitObject = new ReignOfTerrorThermidor();
		else if(id == CardIdentifier.BABY_FACE__ISAAC)                               _UnitObject = new BabyFaceIzaac();
		else if(id == CardIdentifier.MOBILE_HOSPITAL__ASSAULT_HOSPICE)               _UnitObject = new MobileHospitalAssaultHospice();
		else if(id == CardIdentifier.CANDLE_CELESTIAL__SARIEL)                       _UnitObject = new CandleCelestialSariel();
		else if(id == CardIdentifier.CHIEF_NURSE__SHAMSIEL)                          _UnitObject = new ChiefNurseShamsiel();
		else if(id == CardIdentifier.REVERSE_AURA_PHOENIX)                           _UnitObject = new ReverseAuraPhoenix();
		else if(id == CardIdentifier.FIRST_AID_CELESTIAL__PENUEL)                    _UnitObject = new FirstAidCelestialPeniel();
		else if(id == CardIdentifier.ADAMANTINE_CELESTIAL__ANIEL)                    _UnitObject = new AdamantineCelestialAniel();
		else if(id == CardIdentifier.UNDERLAY_CELESTIAL__HESEDIEL)                   _UnitObject = new UnderlayCelestialHesediel();
		else if(id == CardIdentifier.MARKING_CELESTIAL__ARABHAKI)                    _UnitObject = new MarkingCelestialArabhaki();
		else if(id == CardIdentifier.WILD_SHOT_CELESTIAL__RAGUEL)                    _UnitObject = new WildShotCelestialRaguel();
		else if(id == CardIdentifier.SOLIDIFY_CELESTIAL__ZERACHIEL)                  _UnitObject = new SolidifyCelestialZerachiel();
		else if(id == CardIdentifier.PROPHECY_CELESTIAL__RAMIEL)                     _UnitObject = new ProphecyCelestialRamiel();
		else if(id == CardIdentifier.BORGAL)                                         _UnitObject = new Borgal();
		else if(id == CardIdentifier.ADVANCE_PARTY_BRAVE_SHOOTER)                    _UnitObject = new AdvancePartyBraveShooter();
		else if(id == CardIdentifier.SHORTSTOP_BRAVE_SHOOTER)                        _UnitObject = new MercenaryBraveShooter();
		else if(id == CardIdentifier.DRAGONIC_OVERLORD)                              _UnitObject = new DragonicOverlord();
		else if(id == CardIdentifier.BLUE_FLIGHT_DRAGON__TRANS_CORE_DRAGON)          _UnitObject = new BlueFlightDragonTranscoreDragon();
		else if(id == CardIdentifier.COSMO_HEALER__ERGODIEL)                         _UnitObject = new CosmoHealerErgodiel();
		else if(id == CardIdentifier.WINGAL)                                         _UnitObject = new Wingal();
		else if(id == CardIdentifier.BLAZING_LION__PLATINA_EZEL)                     _UnitObject = new BlazingLionPlatinaEzel();
		else if(id == CardIdentifier.MILITARY_DRAGON__RAPTOR_COLONEL)                _UnitObject = new MilitaryDragonRaptorColonel();
		else if(id == CardIdentifier.BRINGER_OF_KNOWLEDGE__LOX)                      _UnitObject = new BringerOfKnowledgeLox();
		else if(id == CardIdentifier.SNOGAL)                                         _UnitObject = new Snogal();
		else if(id == CardIdentifier.DEMON_WORLD_CASTLE__DONNERSCHLAG)               _UnitObject = new DonnerSchlag();
		else if(id == CardIdentifier.ARBOROS_DRAGON__SEPHIROT)                       _UnitObject = new ArborosDragonSephirot();
		else if(id == CardIdentifier.SUPPRESSION_ERADICATOR__DOKKASEI)               _UnitObject = new SuppressionEradicatorDokkasei();
		else if(id == CardIdentifier.ERADICATOR__BLADE_HANG_DRACOKID)                _UnitObject = new EradicatorBladeHangDracokid();
		else if(id == CardIdentifier.FLAME_STAR_SEAL_DRAGON_KNIGHT)                  _UnitObject = new FlameStarSealDragonKnight();
		else if(id == CardIdentifier.DRAGON_KNIGHT__LEZAR)                           _UnitObject = new DragonKnightLezar();
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__TAKSAKA)                   _UnitObject = new DemonicDragonMageTaksaka();
		else if(id == CardIdentifier.DIABLE_DRIVE_DRAGON)                            _UnitObject = new DiableDriveDragon();
		else if(id == CardIdentifier.EXPLOSIVE_CLAW_SEAL_DRAGON_KNIGHT)              _UnitObject = new ExplosiveClawSealDragonKnight();
		else if(id == CardIdentifier.CALAMITY_TOWER_WYVERN)                          _UnitObject = new CalamityTowerWyvern();
		else if(id == CardIdentifier.PRISON_EGG_SEAL_DRAGON_KNIGHT)                  _UnitObject = new PrisonEggSealDragonKnight();
		else if(id == CardIdentifier.STEALTH_BEAST__CHAIN_GEEK)                      _UnitObject = new StealthBeastChainGeek();
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_KITE__GOEMON)                  _UnitObject = new StealthRogueOfKiteGoemon();
		else if(id == CardIdentifier.STEALTH_BEAST__DEATHLY_DAGGER)                  _UnitObject = new StealthBeastDeathlyDagger();
		else if(id == CardIdentifier.ROARING_THUNDER_BOW__ZAFURA)                    _UnitObject = new RoaringThunderBowZafura();
		else if(id == CardIdentifier.PLASMA_SCIMITAR_DRAGOON)                        _UnitObject = new PlasmaScimitarDragoon();
		else if(id == CardIdentifier.DRAGON_DANCER__AGATHA)                          _UnitObject = new DragonDancerAgatha();
		else if(id == CardIdentifier.WYVERN_STRIKE__ZAROOS)                          _UnitObject = new WyvernStrikeZaroos();
		else if(id == CardIdentifier.WISHING_DJINN)                                  _UnitObject = new WishingDjinn();
		else if(id == CardIdentifier.JACKIN______PUMPKIN)                            _UnitObject = new JackinPumpkin();
		else if(id == CardIdentifier.LOTUS_DRUID)                                    _UnitObject = new LotusDruid();
		else if(id == CardIdentifier.MAIDEN_OF_PHYSALIS)                             _UnitObject = new MaidenOfPhysalis();
		else if(id == CardIdentifier.BLUE_ROSE_MUSKETEER__ERNEST)                    _UnitObject = new BlueRoseMusketeerErnest();
		else if(id == CardIdentifier.SAMURAI_SPIRIT)                                 _UnitObject = new SamuraiSpirit();
		else if(id == CardIdentifier.BATTLE_SISTER_COCOA)                            _UnitObject = new BattleSisterCocoa();
		
		if(_UnitObject != null) 
		{
			_UnitObject.SetOwnerCard(OwnerCard);
		}
	}

	public void AddUnitObject(UnitObject uo, bool deleteEndBattle = false)
	{
		uo.SetOwnerCard(OwnerCard);
		uo.SetGame(Game);
		uo.id = ExternEffects.Count;
		ExternEffects.Add(uo);
		if(deleteEndBattle)
		{
			deleteExtEffectEndBattleList.Add(uo.id);
		}
	}

	public void DecisionWindowAccept(int id = -1)
	{
		if(_UnitObject != null && id == -1)
		{
			_UnitObject.DecisionWindowAccept();
		}
		
		if(id != -1)
		{
			ExternEffects[id].DecisionWindowAccept();
		}
	}

	public void DecisionWindowDenied(int id = -1)
	{
		if(_UnitObject != null && id == -1)
		{
			_UnitObject.DecisionWindowDenied();
		}
		
		if(id != -1)
		{
			ExternEffects[id].DecisionWindowDenied();
		}
	}
	
	public void SelectionWindowOnClose(Card unitAffected, string optionSelected)
	{
		if(_UnitObject != null)
		{
			_UnitObject.SelectionWindowOnClose(unitAffected, optionSelected);	
		}
	}
	
	public void SelectionCardNameOnClose(string name)
	{
		if(_UnitObject != null)
		{
			_UnitObject.SelectionCardNameOnClose(name);	
		}
	}
	
	public void EndEvent(int id = -1)
	{
		if(_UnitObject != null && id == -1)
		{
			_UnitObject.EndEvent();	
		}

		if(id != -1)
		{
			ExternEffects[id].EndEvent();
		}
	}
	
	public void SetGame(Gameplay _Game)
	{
		Game = _Game;	
		if(_UnitObject != null)
		{
			_UnitObject.SetGame(_Game);	
		}
	}
	
	public void SetID(CardIdentifier _ID)
	{
		id = _ID;	
	}
	
	public void ShowOnScreen(Card card)
	{
		Game.ShowCardEffect(Resources.Load ("CardHelper/" + Game.Data.GetCardInfo(card.cardID).clan + "/" + Game.Data.GetImageName(card.cardID)) as Texture2D);
		Game.SendPacket(GameAction.SHOW_CARD, card.cardID);
	}

	public void CommitContPower()
	{
		SetPersistentPower_CommitChange(OwnerCard, contPower);
		SetPersistentCritical(OwnerCard, contCritical);
	}

	public void SetPower(int power)
	{
		contPower += power;
	}

	#region 0FunctionHandler
	public void UpdatePersistentAbilities(Card card)
	{
		//Debug.Log("Updating " + card.name);
		
		CardIdentifier _id = card.cardID;
		
		//SetPersistentPower(OwnerCard, 0);
		//bool HasPersistentFunction = true;
		
		if(_id == CardIdentifier.DUELING_DRAGON__ZANBAKU)
		{
			Zanbaku_Persistent();	
		}
		else if(_UnitObject != null)
		{
			_UnitObject.Cont();
			currPersistentPower = _UnitObject.currPersistentPower;
		}
		else
		{	
			//HasPersistentFunction = false;	
		}

		for(int i = 0; i < ExternEffects.Count; i++)
		{
			ExternEffects[i].Cont();
		}
	}
	/// @endcond
	 
	public AttackType _AttackType = AttackType.NONE;

	/// @cond
	public void CheckAbilitiesEnemyTurn(CardState cs)
	{
		CardIdentifier id = OwnerCard.cardID;
		
		if(id == CardIdentifier.DUELING_DRAGON__ZANBAKU)
		{
			Zanbaku_AutoEnemyTurn(cs);
		}
	}
	
	public void CheckExternAbilities(int id, CardState cs, Card effectOwner = null)
	{
		if(Game.bEffectOnGoing)
		{
			Game._AbilityManager.AddAbility(cs, OwnerCard, id);
			return;
		}	
		
		ExternEffects[id].Auto(cs, effectOwner);
	}
	
	public void CheckAbilities(CardState cs, Card card, Card effectOwner = null)
	{
		if(!Game.bCheckAutoMode)
		{
			if(cs == CardState.ClearEndTurnVariables)
			{
				ExternEffects.Clear();	
			}

			if(cs == CardState.ClearEndBattleVariables)
			{
				for(int i = 0; i < deleteExtEffectEndBattleList.Count; i++)
				{
					ExternEffects[deleteExtEffectEndBattleList[i]] = new DummyExternEffect();	
				}
				deleteExtEffectEndBattleList.Clear();
			}

			if(OwnerCard.IsLocked())
			{
				return;
			}

			Game._LastUnitAbilityCard = card;
			SetID (card.cardID);
			
			if(Game.bEffectOnGoing)
			{
				Game._AbilityManager.AddAbility(cs, card, -1, effectOwner);

				return;
			}
			
			if(cs == CardState.DeclareAttack)
			{
				//ConfirmAttack();
				DeclareAttack(_AttackType);
			}
		}
		
		if(id == CardIdentifier.STORM_RIDER__EUGEN) StormRiderEugen_Auto(cs);
		else if(id == CardIdentifier.OFFICER_CADET__ASTRAEA) OfficerCadetAstraea_Auto(cs);
		else if(id == CardIdentifier.LIGHT_SIGNALS_PENGUIN_SOLDIER) LightSignalsPenguinSoldier_Auto(cs);
		else if(id == CardIdentifier.DECK_SWEEPER) DeckSweeper_Auto(cs);
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_BODY_REPLACEMENT__KOKUENMARU) StealthRogueofBodyReplacementKokuenmaru_Auto(cs);
		else if(id == CardIdentifier.STEALTH_BEAST__FLAME_FOX) StealthBeastFlameFox_Auto(cs);
		else if(id == CardIdentifier.STEALTH_BEAST__SPELL_HOUND) StealthBeastSpellHound_Auto(cs);
		else if(id == CardIdentifier.SPIKED_CLUB_STEALTH_ROGUE__ARAHABAKI) SpikedClubStealthRogueArahabaki_Auto(cs);
		else if(id == CardIdentifier.FIRE_JUGGLER) FireJuggler_Auto(cs);
		else if(id == CardIdentifier.BARKING_WYVERN) BarkingWyvern_Auto(cs);
		else if(id == CardIdentifier.EXORCIST_DEMONIC_DRAGON__INDIGO) ExorcistDemonicDragonIndigo_Auto(cs);
		else if(id == CardIdentifier.DUSTY_PLASMA_DRAGON) DustyPlasmaDragon_Auto(cs);
		else if(id == CardIdentifier.DREAMING_SAGE__CORRON) DreamingSageCorron_Auto(cs);
		else if(id == CardIdentifier.ADVANCE_OF_THE_BLACK_CHAINS__KAHEDIN) AdvanceoftheBlackChainsKahedin_Auto(cs);
		else if(id == CardIdentifier.KNIGHT_OF_PASSION__BAGDEMAGUS) KnightofPassionBagdemagus_Auto(cs);
		else if(id == CardIdentifier.MOBILE_HOSPITAL__ELYSIUM) MobileHospitalElysium_Auto(cs);
		else if(id == CardIdentifier.BEAST_DEITY__BLANK_MARSH) BeastDeityBlankMarsh_Auto(cs);
		else if(id == CardIdentifier.HOLLOW_NOMAD) HollowNomady_Auto(cs);
		else if(id == CardIdentifier.BEAST_DEITY__YAMATANO_DRAKE) BeastDeityYamatanoDrake_Auto(cs);
		else if(id == CardIdentifier.BEAST_DEITY__GOLDEN_ANGLET) BeastDeityGoldenAnglet_Auto(cs);
		else if(id == CardIdentifier.BATTLE_MAIDEN__SAYORIHIME) BattleMaidenSayorihime_Auto(cs);
		else if(id == CardIdentifier.BATTLE_DEITY__SUSANOO) BattleDeitySusanoo_Auto(cs);
		else if(id == CardIdentifier.TRI_HOLL_DRACOKID) TrihollDracokid_Auto(cs);
		else if(id == CardIdentifier.BATTLE_SIREN__THERESA) BattleSirenTheresa_Auto(cs);
		else if(id == CardIdentifier.STORM_RIDER__NICOLAS) StormRiderNicolas_Auto(cs);
		else if(id == CardIdentifier.STORM_RIDER__DAMON)StormRiderDamon_Auto(cs);
		else if(id == CardIdentifier.STORM_RIDER__LYSANDER) StormRiderLysander_Auto(cs);
		else if(id == CardIdentifier.STEALTH_DRAGON__MAGATSU_WIND)StealthDragonMagatsuWind_Auto(cs);
		else if(id == CardIdentifier.STEALTH_FIEND__OBORO_CART) StealthFiendOboroCart_Auto(cs);
		else if(id == CardIdentifier.BLASTER_DARK_SPIRIT) BlasterDarkSpirit_Auto(cs);
		else if(id == CardIdentifier.BLASTER_BLADE_SPIRIT) BlasterBladeSpirit_Auto(cs);
		else if(id == CardIdentifier.NIGHTMARE_SUMMONER__RAQIEL) NightmareSummonerRaqiel_Auto(cs);
		else if(id == CardIdentifier.LORD_OF_THE_DEMONIC_WINDS__VAYU) LordoftheDemonicWindsVayu_Auto(cs);
		else if(id == CardIdentifier.BATTLER_OF_THE_TWIN_BRUSH__POLARIS) BattleroftheTwinBrushPolaris_Auto(cs);
		else if(id == CardIdentifier.BATTLE_SISTER__COOKIE) BattleSisterCookie_Auto(cs);
		else if(id == CardIdentifier.TRI_STINGER_DRAGON) TristingerDragon_Auto(cs);
		else if(id == CardIdentifier.PLATINUM_BLOND_FOX_SPIRIT__TAMAMO) PlatinumBlondFoxSpiritTamamo_Auto(cs);
		else if(id == CardIdentifier.FANTASY_PETAL_STORM__SHIRAYUKI) FantasyPetalStormShirayuki_Auto(cs);
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM) CovertDemonicDragonMagatsuStorm_Auto(cs);
		else if(id == CardIdentifier.BATTLE_SIREN__DOROTHEA) BattleSirenDorothea_Auto(cs);
		else if(id == CardIdentifier.BATTLE_SIREN__CYNTHIA) BattleSirenCynthia_Auto(cs);
		else if(id == CardIdentifier.SPLASH_ASSAULT) SplashAssault_Auto(cs);
		else if(id == CardIdentifier.ACCELERATED_COMMAND) AcceleratedCommand_Auto(cs);
		else if(id == CardIdentifier.TITAN_OF_THE_INFINITE_TRENCH) TitanoftheInfiniteTrench_Auto(cs);
		else if(id == CardIdentifier.CORAL_ASSAULT) CoralAssault_Auto(cs);
		else if(id == CardIdentifier.MARINE_GENERAL_OF_THE_RESTLESS_TIDES__ALGOS) MarineGeneraloftheRestlessTidesAlgos_Auto(cs);
		else if(id == CardIdentifier.KEY_ANCHOR__DABID) KeyAnchorDabid_Auto(cs);
		else if(id == CardIdentifier.MARINE_GENERAL_OF_THE_FULL_TIDES__XENOPHON) MarineGeneraloftheFullTidesXenophon_Auto(cs);
		else if(id == CardIdentifier.NAVALGAZER_DRAGON) NavalgazerDragon_Auto(cs);
		else if(id == CardIdentifier.EXORCIST_MAGE__KOH_KOH) ExorcistMageKohKoh_Auto(cs);
		else if(id == CardIdentifier.DRAGON_MONK__GINKAKU) DragonMonkGinkaku_Auto(cs);
		else if(id == CardIdentifier.DRAGON_MONK__KINKAKU) DragonMonkKinkaku_Auto(cs);
		else if(id == CardIdentifier.BLACK_CELESTIAL_MAIDEN__KALI) BlackCelestialMaidenKali_Auto(cs);
		else if(id == CardIdentifier.OFFICER_CADET__ERIKK) OfficerCadetErikk_Auto(cs);
		else if(id == CardIdentifier.RELIABLE_STRATEGIC_COMMANDER) ReliableStrategicCommander_Auto(cs);
		else if(id == CardIdentifier.STREAM_TROOPER) StreamTrooper_Auto(cs);
		else if(id == CardIdentifier.WHALE_SUPPLY_FLEET__KAIRIN_MARU) WhaleSupplyFleetKairinMaru_Auto(cs);
		else if(id == CardIdentifier.VETERAN_STRATEGIC_COMMANDER) VeteranStrategicCommander_Auto(cs);
		else if(id == CardIdentifier.DISTANT_SEA_ADVISOR__VASSILIS) DistantSeaAdvisorVassilis_Auto(cs);
		else if(id == CardIdentifier.TITAN_OF_THE_PYROXENE_MINE) TitanofthePyroxeneMine_Auto(cs);
		else if(id == CardIdentifier.BABY_PTERO) BabyPtero_Auto(cs);
		else if(id == CardIdentifier.TRANSPORT_DRAGON__BRACHIOPORTER) TransportDragonBrachioporter_Auto(cs);
		else if(id == CardIdentifier.FORTRESS_AMMONITE) FortressAmmonite_Auto(cs);
		else if(id == CardIdentifier.SAVAGE_MAGUS) SavageMagus_Auto(cs);
		else if(id == CardIdentifier.CARRIER_DRAGON__BRACHIOCARRIER) CarrierDragonBrachiocarrier_Auto(cs);
		else if(id == CardIdentifier.SAVAGE_WARLOCK) SavageWarlock_Auto(cs);
		else if(id == CardIdentifier.CITADEL_DRAGON__BRACHIOCASTLE) CitadelDragonBrachiocastle_Auto(cs);
		else if(id == CardIdentifier.SAVAGE_WAR_CHIEF) SavageWarChief_Auto(cs);
		else if(id == CardIdentifier.BROCCOLINI_MUSKETEER__KIRAH) BroccoliniMusketeerKirah_Auto(cs);
		else if(id == CardIdentifier.FRUITS_BASKET_ELF) FruitsBasketElf_Auto(cs);
		else if(id == CardIdentifier.BOON_BANA_NA) BoonBanana_Auto(cs);
		else if(id == CardIdentifier.TULIP_MUSKETEER__MINA) TulipMusketeerMina_Auto(cs);
		else if(id == CardIdentifier.POISON_MUSHROOM) PoisonMushroom_Auto(cs);
		else if(id == CardIdentifier.TULIP_MUSKETEER__ALMIRA) TulipMusketeerAlmira_Auto(cs);
		else if(id == CardIdentifier.WORLD_BEARING_TURTLE__AHKBARA) WorldBearingTurtleAhkbara_Auto(cs);
		else if(id == CardIdentifier.EXPLODING_TOMATO) ExplodingTomato_Auto(cs);
		else if(id == CardIdentifier.WORLD_SNAKE__OUROBOROS) WorldSnakeOuroboros_Auto(cs);
		else if(id == CardIdentifier.BLACK_LILY_MUSKETEER__HERMANN) BlackLilyMusketeerHermann_Auto(cs);
		else if(id == CardIdentifier.FIGHTING_SAUCER) FightingSaucer_Auto(cs);
		else if(id == CardIdentifier.SPEEDSTER) Speedster_Auto(cs);
		else if(id == CardIdentifier.PSYCHIC_GREY) PsychicGrey_Auto(cs);
		else if(id == CardIdentifier.MYSTERIOUS_NAVY_ADMIRAL__GOGOTH) MysteriousNavyAdmiralGogoth_Auto(cs);
		else if(id == CardIdentifier.ASSAULT_MONSTER__GUNROCK) AssaultMonsterGunrock_Auto(cs);
		else if(id == CardIdentifier.COSMIC_RIDER) CosmicRider_Auto(cs);
		else if(id == CardIdentifier.COSMIC_MOTHERSHIP) CosmicMothership_Auto(cs);
		else if(id == CardIdentifier.INTERDIMENSIONAL_NINJA__TSUKIKAGE) InterdimensionalNinjaTsukikage_Auto(cs);
		else if(id == CardIdentifier.COILING_DUCKBILL) CoilingDuckbill_Auto(cs);
		else if(id == CardIdentifier.COMPASS_LION) CompassLion_Auto(cs);
		else if(id == CardIdentifier.THUNDER_SPEAR_WIELDING_EXORCIST_KNIGHT) ThunderSpearWieldingExorcistKnight_Auto(cs);
		else if(id == CardIdentifier.AQUA_BREATH_DRACOKID) AquaBreathDracokid_Auto(cs);
		else if(id == CardIdentifier.STORM_RIDER__DIAMANTES) StormRiderDiamantes_Auto(cs);
		else if(id == CardIdentifier.MILITARY_DRAGON__RAPTOR_SOLDIER) MilitaryDragonRaptorSoldier_Auto(cs);
		else if(id == CardIdentifier.WINGED_DRAGON__BEAMPTERO) WingedDragonBeamptero_Auto(cs);
		else if(id == CardIdentifier.ASSAULT_DRAGON__PACHYPHALOS) AssaultDragonPachyphalos_Auto(cs, effectOwner);
		else if(id == CardIdentifier.WINGED_DRAGON__SLASHPTERO) WingedDragonSlashptero_Auto(cs);
		else if(id == CardIdentifier.ARBOROS_DRAGON__RATOON) ArborosDragonRatoon_Auto(cs);
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAILANDER) DimensionalRoboDailander_Auto(cs);
		else if(id == CardIdentifier.SUBTERRANEAN_BEAST__MAGMA_LORD) SubterraneanBeastMagmaLord_Auto(cs);
		else if(id == CardIdentifier.LADY_JUSTICE) LadyJustice_Auto(cs);
		else if(id == CardIdentifier.ENIGMAN_CYCLONE)  EnigmanCyclone_Auto(cs);
		else if(id == CardIdentifier.ARMED_INSTRUCTOR__BISON) ArmedInstructorBison_Auto(cs, effectOwner);
		else if(id == CardIdentifier.TEAR_KNIGHT__VALERIA) TearKnightValeria_Auto(cs);
		else if(id == CardIdentifier.DESTRUCTION_DRAGON__DARK_REX) DestructionDragonDarkRex_Auto(cs);
		else if(id == CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__REBECCA) LiLilyoftheValleyMusketeerRebecca_Auto(cs);
		else if(id == CardIdentifier.HYDRO_HURRICANE_DRAGON)  HydroHurricaneDragon_Auto(cs);
		else if(id == CardIdentifier.STORM_RIDER__BASIL) StormRiderBasil_Auto(cs);
		else if(id == CardIdentifier.OPERATOR_GIRL__MIKA) OperatorGirlMika_Auto(cs);
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIDRAGON) DimensionalRoboDaidragon_Auto(cs);
		else if(id == CardIdentifier.CHERRY_BLOSSOM_MUSKETEER__AUGUSTO) CherryBlossomMusketeerAugusto_Auto(cs);
		else if(id == CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__KAIVANT) LilyoftheValleyMusketeerKaivant_Auto(cs);
		else if(id == CardIdentifier.MAIDEN_OF_RAINBOW_WOOD) MaidenofRainbowWood_Auto(cs);
		else if(id == CardIdentifier.WATER_LILY_MUSKETEER__RUTH) WaterLilyMusketeerRuth_Auto(cs);
		else if(id == CardIdentifier.DREAMY_AMMONITE)
		{
			DreamyAmmonite_Auto(cs);
		}	
		else if(id == CardIdentifier.DREAMY_FORTRESS)
		{
			DreamyFortress_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTLE_SISTER__SOUFFLE)
		{
			BattleSisterSouffle_Auto(cs);	
		}
		else if(id == CardIdentifier.RUNE_WEAVER)
		{
			RuneWeaver_Auto(cs);	
		}
		else if(id == CardIdentifier.NIGHTMARE_DOLL__AMY)
		{
			NightmareDollAmy_Auto(cs);	
		}
		else if(id == CardIdentifier.JUMPING_GLENN)
		{
			JumpingGlenn_Auto(cs);	
		}
		else if(id == CardIdentifier.GIRL_WHO_CROSSED_THE_GAP)
		{
			GirlWhoCrossedtheGap_Auto(cs);	
		}
		else if(id == CardIdentifier.HOPE_CHILD__TURIEL)
		{
			HopeChildTuriel_Auto(cs);	
		}
		else if(id == CardIdentifier.MIRAGE_MAKER)
		{
			MirageMaker_Auto(cs);	
		}
		else if(id == CardIdentifier.MOONSAULT_SWALLOW)
		{
			MoonsaultSwallow_Auto(cs);	
		}
		else if(id == CardIdentifier.PINKY_PIGGY)
		{
			PinkyPiggy_Auto(cs);	
		}
		else if(id == CardIdentifier.INNOCENT_MAGICIAN)
		{
			InnocentMagician_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTLE_SISTER__ECLAIR)
		{
			BattleSisterEclair_Auto(cs);
		}	
		else if(id == CardIdentifier.DEVIL_IN_SHADOW)
		{
			DevilinShadow_Auto(cs);	
		}
		else if(id == CardIdentifier.BEAST_IN_HAND)
		{
			BeastinHand_Auto(cs);	
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN__SHISA)
		{
			OracleGuardianShisa_Auto(cs);
		}	
		else if(id == CardIdentifier.DRAWING_DREAD)
		{
			DrawingDread_Auto(cs);	
		}
		else if(id == CardIdentifier.CYBER_BEAST)
		{
			CyberBeast_Auto(cs);	
		}
		else if(id == CardIdentifier.BEAUTIFUL_HARPUIA)
		{
			BeautifulHarpuia_Auto(cs);	
		}
		else if(id == CardIdentifier.DISCIPLE_OF_PAIN)
		{
			DiscipleofPain_Auto(cs);	
		}
		else if(id == CardIdentifier.SEE_SAW_GAME_LOSER)
		{
			SeesawGameLoser_Auto(cs);	
		}
		else if(id == CardIdentifier.DOCTROID_MICROS)
		{
			DoctroidMicros_Auto(cs);
		}	
		else if(id == CardIdentifier.MASTER_OF_PAIN)
		{
			MasterofPain_Auto(cs);	
		}
		else if(id == CardIdentifier.DOCTROID_MEGALOS)
		{
			DoctroidMegalos_Auto(cs);	
		}
		else if(id == CardIdentifier.SEE_SAW_GAME_WINNER)
		{
			SeesawGameWinner_Auto(cs);	
		}
		else if(id == CardIdentifier.RULER_CHAMELEON)
		{
			RulerChameleon_Auto(cs);	
		}
		else if(id == CardIdentifier.SCHOOLYARD_PRODIGY__LOX)
		{
			SchoolyardProdigyLox_Auto(cs);	
		}
		else if(id == CardIdentifier.ACORN_MASTER)
		{
			AcornMaster_Auto(cs);	
		}
		else if(id == CardIdentifier.HULA_HOOP_CAPYBARA)
		{
			HulaHoopCapybara_Auto(cs);	
		}
		else if(id == CardIdentifier.FEATHER_PENGUIN)
		{
			FeatherPenguin_Auto(cs);	
		}
		else if(id == CardIdentifier.FAILURE_SCIENTIST__PONKICHI)
		{
			FailureScientistPonkichi_Auto(cs);	
		}
		else if(id == CardIdentifier.ELEMENT_GLIDER)
		{
			ElementGlider_Auto(cs);	
		}
		else if(id == CardIdentifier.TICK_TOCK_FLAMINGO)
		{
			TickTockFlamingo_Auto(cs);	
		}
		else if(id == CardIdentifier.CANVAS_KOALA)
		{
			CanvasKoala_Auto(cs);	
		}
		else if(id == CardIdentifier.MULTIMETER_GIRAFFE)
		{
			MultimeterGiraffe_Auto(cs);	
		}
		else if(id == CardIdentifier.EXPLOSION_SCIENTIST__BUNTA)
		{
			ExplosionScientistBunta_Auto(cs);
		}	
		else if(id == CardIdentifier.GLOBE_ARMADILLO)
		{
			GlobeArmadillo_Auto(cs);	
		}
		else if(id == CardIdentifier.PENCIL_KNIGHT__HAMMSUKE)
		{
			PencilKnightHammsuke_Auto(cs);	
		}
		else if(id == CardIdentifier.SCHOOLBAG_SEA_LION)
		{
			SchoolbagSeaLion_Auto(cs);
		}	
		else if(id == CardIdentifier.CALCULATOR_HIPPO)
		{
			CalculatorHippo_Auto(cs);
		}
		else if(id == CardIdentifier.SPRING_BREEZE_MESSENGER)
		{
			SpringBreezeMessenger_Auto(cs);	
		}
		else if(id == CardIdentifier.LOP_EAR_SHOOTER)
		{
			LopEarShooter_Auto(cs);	
		}
		else if(id == CardIdentifier.PHOTON_ARCHER__GRIFLET)
		{
			PhotonArcherGriflet_Auto(cs);	
		}
		else if(id == CardIdentifier.LITTLE_WITCH__LULU)
		{
			LittleWitchLuLu_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTLE_SISTER__GLACE)
		{
			BattleSisterGlace_Auto(cs);	
		}
		else if(id == CardIdentifier.COURTING_SUCCUBUS)
		{
			CourtingSuccubus_Auto(cs);	
		}
		else if(id == CardIdentifier.FREE_TRAVELER)
		{
			FreeTraveler_Auto(cs);	
		}
		else if(id == CardIdentifier.EVIL_EYE_BASILISK)
		{
			EvilEyeBasilisk_Auto(cs);	
		}
		else if(id == CardIdentifier.PURPLE_TRAPEZIST)
		{
			PurpleTrapezist_Auto(cs);	
		}
		else if(id == CardIdentifier.BULL_____S_EYE__MIA)
		{
			BullsEyeMia_Auto(cs);
		}
		else if(id == CardIdentifier.MIDNIGHT_INVADER)
		{
			MidnightInvader_Auto(cs);	
		}
		else if(id == CardIdentifier.FLASK_MARMOSET)
		{
			FlaskMarmoset_Auto(cs);	
		}
		else if(id == CardIdentifier.THERMOMETER_GIRAFFE)
		{
			ThermometerGiraffe_Auto(cs);	
		}
		else if(id == CardIdentifier.PENCIL_SQUIRE__HAMMSUKE)
		{
			PencilSquireHammsuke_Auto(cs);	
		}
		else if(id == CardIdentifier.MAGNET_CROCODILE)
		{	
			MagnetCrocodile_Auto(cs);
		}
		else if(id == CardIdentifier.DUMBBELL_KANGAROO)
		{
			DumbbellKangaroo_Auto(cs);	
		}
		else if(id == CardIdentifier.PENCIL_HERO__HAMMSUKE)
		{
			PencilHeroHammsuke_Auto(cs);	
		}
		else if(id == CardIdentifier.LISTENER_OF_TRUTH__DINDRANE)
		{
			ListenerofTruthDindrane_Auto(cs);
		}	
		else if(id == CardIdentifier.EMBLEM_MASTER)
		{
			EmblemMaster_Auto(cs);	
		}
		else if(id == CardIdentifier.PEEK_A_BOO)
		{
			Peekaboo_Auto(cs);	
		}
		else if(id == CardIdentifier.FIRE_BREEZE__CARRIE)
		{
			FireBreezeCarrie_Auto(cs);	
		}
		else if(id == CardIdentifier.SWORD_MAGICIAN__SARAH)
		{
			SwordMagicianSarah_Auto(cs);	
		}
		else if(id == CardIdentifier.MONOCULUS_TIGER)
		{
			MonoculusTiger_Auto(cs);	
		}
		else if(id == CardIdentifier.LAMP_CAMEL)
		{
			LampCamel_Auto(cs);	
		}
		else if(id == CardIdentifier.SCHOOL_DOMINATOR__APT)
		{
			SchoolDominatorApt_Auto(cs);	
		}
		else if(id == CardIdentifier.WHITE_HARE_IN_THE_MOON_____S_SHADOW__PELLINORE)
		{
			WhiteHareintheMoonShadowPellinore_Auto(cs);	
		}
		else if(id == CardIdentifier.EMERALD_WITCH__LALA)
		{
			EmeraldWitchLaLa_Auto(cs);	
		}
		else if(id == CardIdentifier.SILVER_THORN_DRAGON_TAMER__LUQUIER)
		{
			SilverThornDragonTamerLuquier_Auto(cs);	
		}
		else if(id == CardIdentifier.BINOCULUS_TIGER)
		{
			BinoculusTiger_Auto(cs);	
		}
		else if(id == CardIdentifier.SCHOOL_HUNTER__LEO_PALD)
		{	
			SchoolHunterLeopald_Auto(cs);
		}
		else if(id == CardIdentifier.THUNDER_BREAK_DRAGON)
		{
			ThunderBreakDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.PLASMABITE_DRAGON)
		{
			PlasmabiteDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.DRAGON_DANCER__RAIRAI)
		{
			DragonDancerRaiRai_Auto(cs);	
		}
		else if(id == CardIdentifier.SHIELDBLADE_DRAGOON)
		{
			ShieldbladeDragoon_Auto(cs);	
		}
		else if(id == CardIdentifier.BRIGHTJET_DRAGON)
		{
			BrightjetDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.LIGHTNING_OF_HOPE__HELENA)
		{
			LightningofHopeHelena_Auto(cs);	
		}
		else if(id == CardIdentifier.WYVERN_SUPPLY_UNIT)
		{
			WyvernSupplyUnit_Auto(cs);	
		}
		else if(id == CardIdentifier.DJINN_OF_THE_LIGHTNING_FLASH)
		{
			DjinnoftheLightningFlash_Auto(cs);	
		}
		else if(id == CardIdentifier.DJINN_OF_THE_LIGHTNING_SPARK)
		{
			DjinnoftheLightningSpark_Auto(cs);	
		}
		else if(id == CardIdentifier.DJINN_OF_THE_LIGHTNING_FLARE)
		{
			DjinnoftheLightningFlare_Auto(cs);	
		}
		else if(id == CardIdentifier.SILVER_FANG_WITCH)
		{
			SilverFangWitch_Auto(cs);	
		}
		else if(id == CardIdentifier.BLESSING_OWL)
		{
			BlessingOwl_Auto(cs);	
		}
		else if(id == CardIdentifier.CHARJGAL)
		{
			Charjgal_Auto(cs);	
		}
		else if(id == CardIdentifier.PRECIPICE_WHIRLWIND__SAGRAMORE)
		{
			PrecipiceWhirlwindSagramore_Auto(cs);	
		}
		else if(id == CardIdentifier.CHARGING_CHARIOT_KNIGHT)
		{
			ChargingChariotKnight_Auto(cs);	
		}
		else if(id == CardIdentifier.SACRED_GUARDIAN_BEAST__NEMEAN_LION)
		{
			SacredGuardianBeastNemeanLion_Auto(cs);
		}	
		else if(id == CardIdentifier.BATTLEFIELD_STORM__SAGRAMORE)
		{
			BattlefieldStormSagramore_Auto(cs);	
		}
		else if(id == CardIdentifier.CUP_BOWLER)
		{
			CupBowler_Auto(cs);
		}
		else if(id == CardIdentifier.KUNGFU_KID__BOLTA)
		{
			KungfuKidBolta_Auto(cs);
		}
		else if(id == CardIdentifier.MUSCLE_HERCULES)
		{
			MuscleHercules_Auto(cs);	
		}
		else if(id == CardIdentifier.TURBORAIZER)
		{
			Turboraizer_Auto(cs);	
		}
		else if(id == CardIdentifier.RISING_PHOENIX)
		{
			RisingPhoenix_Auto(cs);	
		}
		else if(id == CardIdentifier.DREADCHARGE_DRAGON)
		{
			DreadchargeDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.SATELLITEFALL_DRAGON)
		{
			SatellitefallDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTLE_FLAG_KNIGHT__LAUDINE)
		{
			BattleFlagKnightLaudine_Auto(cs);	
		}
		else if(id == CardIdentifier.COONGAL)
		{
			Coongal_Auto(cs);	
		}
		else if(id == CardIdentifier.GREED_SHADE)
		{
			GreedShade_Auto(cs);	
		}
		else if(id == CardIdentifier.ALMIGHTY_REPORTER)
		{
			AlmightyReporter_Auto(cs);	
		}
		else if(id == CardIdentifier.MARVELOUS_HANI)
		{
			MarvelousHani_Auto(cs);	
		}
		else if(id == CardIdentifier.BEAST_DEITY__SCARLET_BIRD)
		{
			BeastDeityScarletBird_Auto(cs);	
		}
		else if(id == CardIdentifier.BEAST_DEITY__BLACK_TORTOISE)
		{
			BeastDeityBlackTortoise_Auto(cs);	
		}
		else if(id == CardIdentifier.MOAI_THE_GREAT)
		{
			MoaitheGreat_Auto(cs);	
		}
		else if(id == CardIdentifier.SPARK_KID_DRAGOON)
		{
			SparkKidDragoon_Auto(cs);
		}	
		else if(id == CardIdentifier.LIZARD_SOLDIER__YOWSH)
		{
			LizardSoldierYowsh_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_FIGHTER)
		{
			StealthFighter_Auto(cs);	
		}
		else if(id == CardIdentifier.DRAGON_MONK__ENSEI)
		{
			DragonMonkEnsei_Auto(cs);	
		}
		else if(id == CardIdentifier.HEX_CANNON_WYVERN)
		{
			HexCannonWyvern_Auto(cs);	
		}
		else if(id == CardIdentifier.BREAKTHROUGH_DRAGON)
		{
			BreakthroughDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.LITTLE_FIGHTER__CRON)
		{
			LittleFighterCron_Auto(cs);	
		}
		else if(id == CardIdentifier.WAVING_OWL)
		{
			WavingOwl_Auto(cs);	
		}
		else if(id == CardIdentifier.PROVIDENCE_STRATEGIST)
		{
			ProvidenceStrategist_Auto(cs);	
		}
		else if(id == CardIdentifier.LITTLE_BATTLER__TRON)
		{
			LittleBattlerTron_Auto(cs);	
		}
		else if(id == CardIdentifier.SACRED_GUARDIAN_BEAST__ELEPHAS)
		{
			SacredGuardianBeastElephas_Auto(cs);
		}	
		else if(id == CardIdentifier.HOLY_MAGE__MANAWYDAN)
		{
			HolyMageManawydan_Auto(cs);	
		}
		else if(id == CardIdentifier.GIGANTECH_COMMANDER)
		{
			GigantechCommander_Auto(cs);	
		}
		else if(id == CardIdentifier.GIGANTECH_CRUSHER)
		{
			GigantechCrusher_Auto(cs);	
		}
		else if(id == CardIdentifier.HADES_STEERSMAN)
		{
			HadesSteersman_Auto(cs);
		}	
		else if(id == CardIdentifier.CAPTAIN_NIGHTKID)
		{
			CaptainNightkid_Auto(cs);	
		}
		else if(id == CardIdentifier.SKELETON_ASSAULT_TROOPS_CAPTAIN)
		{
			SkeletonAssaultTroopsCaptain_Auto(cs);	
		}
		else if(id == CardIdentifier.UNDEAD_PIRATE_OF_THE_CURSED_RIFLE)
		{
			PirateoftheCursedRifle_Auto(cs);	
		}
		else if(id == CardIdentifier.DRAGON_SPIRIT)
		{
			DragonSpirit_Auto(cs);	
		}
		else if(id == CardIdentifier.RIPPLE_BANSHEE)
		{
			RippleBanshee_Auto(cs);
		}
		else if(id == CardIdentifier.JOHN_THE_GHOSTIE)
		{
			JohntheGhostie_Auto(cs);	
		}
		else if(id == CardIdentifier.SKELETON_COLOSSUS)
		{
			SkeletonColossus_Auto(cs);	
		}
		else if(id == CardIdentifier.SEA_NAVIGATOR__SILVER)
		{	
			SeaNavigatorSilver_Auto(cs);
		}
		else if(id == CardIdentifier.UNDEAD_PIRATE_OF_THE_FRIGID_NIGHT)
		{
			UndeadPirateoftheFrigidNight_Auto(cs);	
		}
		else if(id == CardIdentifier.STORMRIDE_GHOST_SHIP)
		{
			StormrideGhostShip_Auto(cs);	
		}
		else if(id == CardIdentifier.GOD_EATING_ZOMBIE_SHARK)
		{
			GodeatingZombieShark_Auto(cs);	
		}
		else if(id == CardIdentifier.SUNNY_SMILE_ANGEL)
		{
			SunnySmileAngel_Auto(cs);	
		}
		else if(id == CardIdentifier.CLUTCH_RIFLE_ANGEL)
		{
			ClutchRifleAngel_Auto(cs);	
		}
		else if(id == CardIdentifier.LIGHTNING_CHARGER)
		{
			LightningCharger_Auto(cs);	
		}
		else if(id == CardIdentifier.THERMOMETER_ANGEL)
		{
			ThermometerAngel_Auto(cs);	
		}
		else if(id == CardIdentifier.CARRIER_OF_THE_LIFE_WATER)
		{
			CarrieroftheLifeWater_Auto(cs);
		}	
		else if(id == CardIdentifier.THOUSAND_RAY_PEGASUS)
		{
			ThousandRayPegasus_Auto(cs);
		}
		else if(id == CardIdentifier.HOLY_ZONE__PENEMUE)
		{
			HolyZonePenemue_Auto(cs);	
		}
		else if(id == CardIdentifier.IRON_HEART__MASTEMA)
		{
			IronHeartMastema_Auto(cs);
		}
		else if(id == CardIdentifier.MILLION_RAY_PEGASUS)
		{	
			MillionRayPegasus_Auto(cs);
		}
		else if(id == CardIdentifier.PULSE_WAVE__ADRIEL)
		{
			PulseWaveAdriel_Auto(cs);	
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__SAISHIN)
		{
			LizardSoldierSaishin_Auto(cs);
		}
		else if(id == CardIdentifier.PHOTON_BOMBER_WYVERN)
		{
			PhotonBomberWyvern_Auto(cs);	
		}
		else if(id == CardIdentifier.DESERT_GUNNER__RAIEN)
		{
			DesertGunnerRaien_Auto(cs);
		}	
		else if(id == CardIdentifier.DEMONIC_DRAGON_BERSERKER__GARUDA)
		{
			DemonicDragonBerserkerGaruda_Auto(cs);	
		}
		else if(id == CardIdentifier.RIOT_GENERAL__GYRAS)
		{
			RiotGeneralGyras_Auto(cs);	
		}
		else if(id == CardIdentifier.CRIMSON_LION_CUB__KYRPH)
		{
			CrimsonLionCubKyrph_Auto(cs);	
		}
		else if(id == CardIdentifier.MAGE_OF_CALAMITY__TRIPP)
		{
			MageofCalamityTripp_Auto(cs);	
		}
		else if(id == CardIdentifier.PLAYER_OF_THE_HOLY_AXE__NIMUE)
		{
			PlayeroftheHolyAxeNimue_Auto(cs);	
		}
		else if(id == CardIdentifier.THREE_STAR_CHEF__PIETRO)
		{
			ThreeStarChefPietro_Auto(cs);
		}	
		else if(id == CardIdentifier.SKELETON_DEMON_WORLD_KNIGHT)
		{
			SkeletonDemonWorldKnight_Auto(cs);	
		}
		else if(id == CardIdentifier.MASTER_SWORDSMAN__NIGHTSTORM)
		{
			MasterSwordsmanNightstorm_Auto(cs);
		}	
		else if(id == CardIdentifier.MIRACLE_FEATHER_NURSE)
		{
			MiracleFeatherNurse_Auto(cs);
		}	
		else if(id == CardIdentifier.MOBILE_HOSPITAL__FEATHER_PALACE)
		{
			MobileHospitalFeatherPalace_Auto(cs);	
		}
		else if(id == CardIdentifier.DRAGONIC_DEATHSCYTHE)
		{
			DragonicDeathscythe_Auto(cs);
		}	
		else if(id == CardIdentifier.DRILL_BULLET__GENIEL)
		{
			DrillBulletGeniel_Auto(cs);	
		}
		else if(id == CardIdentifier.THE_PHOENIX__CALAMITY_FLAME)
		{
			ThePhoenixCalamityFlame_Auto(cs);	
		}
		else if(id == CardIdentifier.VAJRA_EMPEROR__INDRA)
		{
			VajraEmperorIndra_Auto(cs);	
		}
		else if(id == CardIdentifier.DEATH_SEEKER__THANATOS)
		{
			DeathSeekerThanatos_Auto(cs);	
		}
		else if(id == CardIdentifier.LOVE_MACHINE_GUN__NOCIEL)
		{
			LoveMachineGunNociel_Auto(cs);	
		}
		else if(id == CardIdentifier.CORE_MEMORY__ARMAROS)
		{
			CoreMemoryArmaros_Auto(cs);	
		}
		else if(id == CardIdentifier.DESERT_GUNNER__SHIDEN)
		{
			DesertGunnerShiden_Auto(cs);	
		}
		else if(id == CardIdentifier.PLAYER_OF_THE_HOLY_BOW__VIVIANE)
		{
			PlayeroftheHolyBowViviane_Auto(cs);	
		}
		else if(id == CardIdentifier.ICE_PRISON_NECROMANCER__COCYTUS)
		{
			IcePrisonNecromancerCocytus_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTLE_CUPID__NOCIEL)
		{
			BattleCupidNociel_Auto(cs);	
		}
		else if(id == CardIdentifier.CIRCULAR_SAW__KIRIEL)
		{
			CircularSawKiriel_Auto(cs); 	
		}
		else if(id == CardIdentifier.DARK_SOUL_CONDUCTOR)
		{
			DarkSoulConductor_Auto(cs);	
		}
		else if(id == CardIdentifier.BIG_LEAGUE_BEAR)
		{
			BigLeagueBear_Auto(cs);	
		}
		else if(id ==CardIdentifier.MADCAP_MARIONETTE)
		{
			MadcapMarionette_Auto(cs);
		}	
		else if(id ==CardIdentifier.CONJURER_OF_MITHRIL)
		{
			ConjurerofMithril_Auto(cs);
		}	
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__MAHORAGA)
		{
			DemonicDragonMageMahoraga_Auto(cs);
		}	
		else if(id == CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAILADY)
		{
			SuperDimensionalRoboDailady_Auto(cs);	
		}
		else if(id == CardIdentifier.TOP_GUN)
		{
			TopGun_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__TAGITSUHIME)
		{
			BattleMaidenTagitsuhime_Auto(cs);	
		}
		else if(id == CardIdentifier.WHITE_HARE_OF_INABA)
		{
			WhiteHareofInaba_Auto(cs);	
		}
		else if(id == CardIdentifier.NIGHTMARE_PAINTER)
		{
			NightmarePainter_Auto(cs);	
		}
		else if(id == CardIdentifier.DREAM_PAINTER)
		{
			DreamPainter_Auto(cs);	
		}
		else if(id == CardIdentifier.POWERFUL_SAGE__BAIRON)
		{
			PowerfulSageBairon_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_BEAST__LEAF_RACCOON)
		{
			StealthBeastLeafRaccoon_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_BEAST__WHITE_MANE)
		{
			StealthBeastWhiteMane_Auto(cs);	
		}
		else if(id == CardIdentifier.BLADE_SEED_SQUIRE)
		{
			BladeSeedSquire_Auto(cs);	
		}
		else if(id == CardIdentifier.LILY_KNIGHT_OF_THE_VALLEY)
		{
			LilyKnightoftheValley_Auto(cs);	
		}
		else if(id == CardIdentifier.COLOSSAL_WINGS__SIMURGH)
		{
			ColossalWingsSimurgh_Auto(cs);	
		}
		else if(id == CardIdentifier.KNIGHT_OF_VERDURE__GENE)
		{
			KnightofVerdureGene_Auto(cs);	
		}
		else if(id == CardIdentifier.SPIRITUAL_TREE_SAGE__IRMINSUL)
		{
			SpiritualTreeSageIrminsul_Auto(cs);	
		}
		else if(id == CardIdentifier.BURNING_HORN_DRAGON)
		{
			BurningHornDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.APOCALYPSE_BAT)
		{
			ApocalypseBat_Auto(cs);	
		}
		else if(id == CardIdentifier.FLAME_OF_PROMISE__AERMO)
		{
			FlameofPromiseAermo_Auto(cs);	
		}
		else if(id == CardIdentifier.DEVIL_CHILD)
		{
			DevilChild_Auto(cs);	
		}
		else if(id == CardIdentifier.MAGICAL_POLICE__QUILT)
		{
			MagicalPoliceQuilt_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_BEAST__EVIL_FERRET)
		{
			StealthBeastEvilFerret_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_BEAST__MILLION_RAT)
		{
			StealthBeastMillionRat_Auto(cs);
		}	
		else if(id == CardIdentifier.KNIGHT_OF_PURGATORY__SKULL_FACE)
		{
			KnightofPurgatorySkullFace_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__CURSED_BREATH)
		{
			StealthDragonCursedBreath_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__TURBULENT_EDGE)
		{
			StealthDragonTurbulentEdge_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__VOIDGELGA)
		{
			StealthDragonVoidgelga_Auto(cs);	
		}
		else if(id == CardIdentifier.SHIELD_SEED_SQUIRE)
		{	
			ShieldSeedSquire_Auto(cs);
		}
		else if(id == CardIdentifier.STEALTH_FIEND__KURAMA_LORD)
		{
			StealthFiendKuramaLord_Auto(cs);	
		}
		else if(id == CardIdentifier.CAPED_STEALTH_ROGUE__SHANAOU)
		{
			CapedStealthRogueShanaou_Auto(cs);	
		}
		else if(id == CardIdentifier.KNIGHT_OF_HARVEST__GENE)
		{
			KnightofHarvestGene_Auto(cs);	
		}
		else if(id == CardIdentifier.AVATAR_OF_THE_PLAINS__BEHEMOTH)
		{
			AvatarofthePlainsBehemoth_Auto(cs);	
		}
		else if(id == CardIdentifier.HEY_YO_PINEAPPLE)
		{
			HeyYoPineapple_Auto(cs);	
		}
		else if(id == CardIdentifier.FRONTLINE_VALKYRIE__LAUREL)
		{
			FrontlineValkyrieLaurel_Auto(cs);	
		}
		else if(id == CardIdentifier.EVIL_EYE_PRINCESS__EURYALE)
		{
			EvileyePrincessEuryale_Auto(cs);	
		}
		else if(id == CardIdentifier.WINGAL_BRAVE)
		{
			WingalBrave_Auto(cs);	
		}
		else if(id == CardIdentifier.STREET_BOUNCER)
		{
			StreetBouncer_Auto(cs);	
		}
		else if(id == CardIdentifier.KNIGHT_OF_NULLITY__MASQUERADE)
		{
			KnightofNullityMasquerade_Auto(cs);	
		}
		else if(id == CardIdentifier.MOONLIGHT_WITCH__VAHA)
		{
			MoonlightWitchVaha_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_FIEND__MIDNIGHT_CROW)
		{
			StealthFiendMidnightCrow_Auto(cs);	
		}
		else if(id == CardIdentifier.KNIGHT_OF_FRIENDSHIP__KAY)
		{
			KnightofFriendshipKay_Auto(cs);	
		}
		else if(id == CardIdentifier.KNIGHT_OF_LOYALTY__BEDIVERE)
		{
			KnightofLoyaltyBedivere_Auto(cs);	
		}
		else if(id == CardIdentifier.GLASS_BEADS_DRAGON)
		{
			GlassBeadsDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.MIRACLE_BEAUTY)
		{
			MiracleBeauty_Auto(cs);	
		}
		else if(id == CardIdentifier.STAR_CALL_TRUMPETER)
		{
			StarCallTrumpeter_Auto(cs);	
		}
		else if(id == CardIdentifier.SWORD_DANCER_ANGEL)
		{
			SwordDancerAngel_Auto(cs);	
		}
		else if(id == CardIdentifier.DARK_CAT)
		{
			DarkCat_Auto(cs);
		}
		else if(id == CardIdentifier.METEOR_BREAK_WIZARD)
		{
			MeteorBreakWizard_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTLE_SISTER__MAPLE)
		{
			BattleSisterMaple_Auto(cs);
		}
		else if(id == CardIdentifier.MEGACOLONY_BATTLER_B)
		{
			MegacolonyBattlerB_Auto(cs);	
		}
		else if(id == CardIdentifier.TOOLKIT_BOY)
		{
			ToolkitBoy_Auto(cs);	
		}
		else if(id == CardIdentifier.CURSED_LANCER)
		{
			CursedLancer_Auto(cs);	
		}
		else if(id == CardIdentifier.DANCING_WOLF)
		{
			DancingWolf_Auto(cs);	
		}
		else if(id == CardIdentifier.FLAME_SEED_SALAMANDER)
		{
			FlameSeedSalamander_Auto(cs);	
		}
		else if(id == CardIdentifier.GRAPPLE_MANIA)
		{
			GrappleMania_Auto(cs);	
		}
		else if(id == CardIdentifier.GARNET_DRAGON__FLASH)
		{
			GarnetDragonFlash_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_MILLIPEDE)
		{
			StealthMillipede_Auto(cs);	
		}
		else if(id == CardIdentifier.GLORY_MAKER)
		{
			GloryMaker_Auto(cs);	
		}
		else if(id == CardIdentifier.ENIGMAN_SHINE)
		{
			EnigmanShine_Auto(cs);	
		}
		else if(id == CardIdentifier.DORANBAU)
		{
			Doranbau_Auto(cs);	
		}
		else if(id == CardIdentifier.DEMON_WORLD_CASTLE__FATALITA)
		{
			Fatalita_Auto(cs);	
		}
		else if(id == CardIdentifier.BEAST_KNIGHT__GARMORE)
		{
			BeastKnightGarmore_Auto(cs);	
		}
		else if(id == CardIdentifier.ARMORED_FAIRY__SHUBIELA)
		{
			ArmoredFairyShubiela_Auto(cs);	
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__RAOPIA)
		{
			LizardSoldierRaopia_Auto(cs);	
		}
		else if(id == CardIdentifier.GLOOM_FLYMAN)
		{
			GloomFlyman_Auto(cs);	
		}
		else if(id == CardIdentifier.WATER_GANG)
		{
			WaterGang_Auto(cs);	
		}
		else if(id == CardIdentifier.BLAUJUNGER)
		{
			Blaujunger_Auto(cs);	
		}
		else if(id == CardIdentifier.AMBER_DRAGON__DAWN)
		{
			AmberDragonDawn_Auto(cs);	
		}
		else if(id == CardIdentifier.LARVA_MUTANT__GIRAFFA)
		{
			LarvaMutantGiraffa_Auto(cs);	
		}
		else if(id == CardIdentifier.VIOLENT_VESPER)
		{
			ViolentVesper_Auto(cs);	
		}
		else if(id == CardIdentifier.DEATH_WARDEN_ANT_LION)
		{
			DeathWardenAntLion_Auto(cs);	
		}
		else if(id == CardIdentifier.ENIGMAN_FLOW)
		{	
			EnigmanFlow_Auto(cs);
		}
		else if(id == CardIdentifier.PLATINUM_ACE)
		{
			PlatinumAce_Auto(cs);	
		}
		else if(id == CardIdentifier.ENIGMAN_RAIN)
		{
			EnigmanRain_Auto(cs);	
		}
		else if(id == CardIdentifier.FULLBAU)
		{
			Fullbau_Auto(cs);	
		}
		else if(id == CardIdentifier.DARK_MAGE__BADHABH_CAAR)
		{
			DarkMageBadhabhCaar_Auto(cs);	
		}
		else if(id == CardIdentifier.COSMO_BEAK)
		{
			CosmoBeak_Auto(cs);
		}
		else if(id == CardIdentifier.GURURUBAU)
		{
			Gururubau_Auto(cs);	
		}
		else if(id == CardIdentifier.DARK_METAL_DRAGON)
		{
			DarkMetalDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.HEATNAIL_SALAMANDER)
		{
			HeatnailSalamander_Auto(cs);	
		}
		else if(id == CardIdentifier.SKULL_WITCH__NEMAIN)
		{
			SkullWitchNemain_Auto(cs);
		}	
		else if(id == CardIdentifier.DARKNESS_MAIDEN__MACHA)
		{	
			DarknessMaidenMacha_Auto(cs);
		}
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__SHIZUKU)
		{
			BermudaTriangleCadetShizuku_Auto(cs);	
		}
		else if(id == CardIdentifier.NAVY_DOLPHIN__AMUR)
		{
			NavyDolphinAmur_Auto(cs);	
		}
		else if(id == CardIdentifier.MERMAID_IDOL__FELUCCA)
		{
			MermaidIdolFelucca_Auto(cs);	
		}
		else if(id == CardIdentifier.PRISM_ON_THE_WATER__MYRTOA)
		{
			PrismontheWaterMyrtoa_Auto(cs);	
		}
		else if(id == CardIdentifier.DIVA_OF_CLEAR_WATERS__IZUMI)
		{
			DivaofClearWatersIzumi_Auto(cs);	
		}
		else if(id == CardIdentifier.SNOW_WHITE_OF_THE_CORALS__CLAIRE)
		{
			SnowWhiteoftheCoralsClaire_Auto(cs);	
		}
		else if(id == CardIdentifier.INTELLI_IDOL__MELVILLE)
		{
			IntelliidolMelville_Auto(cs);	
		}	
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__RIVIERE)
		{
			BermudaTriangleCadetRiviere_Auto(cs);	
		}
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__WEDDELL)
		{
			BermudaTriangleCadetWeddell_Auto(cs);	
		}
		else if(id == CardIdentifier.TURQUOISE_BLUE__TYRRHENIA)
		{
			TurquoiseBlueTyrrhenia_Auto(cs);	
		}
		else if(id == CardIdentifier.SUPER_IDOL__CERAM)
		{
			SuperIdolCeram_Auto(cs);	
		}
		else if(id == CardIdentifier.PEARL_SISTERS__PERLA)
		{
			PearlSistersPerla_Auto(cs);	
		}
		else if(id == CardIdentifier.BLOODY_CALF)
		{
			BloodyCalf_Auto(cs);	
		}
		else if(id == CardIdentifier.MASKED_POLICE__GRANDER)
		{
			MaskedPoliceGrander_Auto(cs);	
		}
		else if(id == CardIdentifier.DRAGON_DANCER__LOURDES)
		{
			DragonDancerLourdes_Auto(cs);	
		}
		else if(id == CardIdentifier.FLAME_EDGE_DRAGON)
		{
			FlameEdgeDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTLE_SISTER__VANILLA)
		{
			BattleSisterVanilla_Auto(cs);	
		}
		else if(id == CardIdentifier.GODDESS_OF_THE_CRESCENT_MOON__TSUKUYOMI)
		{
			GoddessoftheCrescentMoonTsukuyomi_Auto(cs);	
		}
		else if(id == CardIdentifier.FAITHFUL_ANGEL)
		{
			FaithfulAngel_Auto(cs);	
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN__RED_EYE)
		{
			OracleGuardianRedEye(cs);	
		}
		else if(id == CardIdentifier.SECRETARY_ANGEL)
		{
			SecretaryAngel_Auto(cs);	
		}
		else if(id == CardIdentifier.KNIGHT_OF_QUESTS__GALAHAD)
		{
			KnightofQuestsGalahad_Auto(cs);	
		}
		else if(id == CardIdentifier.SWORDSMAN_OF_THE_BLAZE__PALAMEDES)
		{
			SwordsmanoftheBlazePalamedes_Auto(cs);	
		}
		else if(id == CardIdentifier.KNIGHT_OF_TRIBULATIONS__GALAHAD)
		{
			KnightofTribulationsGalahad_Auto(cs);	
		}
		else if(id == CardIdentifier.BLACK_CANNON_TIGER)
		{
			BlackCannonTiger_Auto(cs);	
		}
		else if(id == CardIdentifier.RAGING_DRAGON__SPARKSAURUS)
		{
			RagingDragonSparksaurus_Auto(cs);	
		}
		else if(id == CardIdentifier.SAVAGE_DESTROYER)
		{
			SavageDestroyer_Auto(cs);	
		}
		else if(id == CardIdentifier.VACUUM_MAMMOTH)
		{
			VacuumMammoth_Auto(cs);	
		}
		else if(id == CardIdentifier.RAINBOW_MAGICIAN)
		{
			RainbowMagician_Auto(cs);	
		}
		else if(id == CardIdentifier.HUNGRY_CLOWN)
		{
			HungryClown_Auto(cs);	
		}
		else if(id == CardIdentifier.DARK_QUEEN_OF_NIGHTMARELAND)
		{
			DarkQueenofNightmareland_Auto(cs);	
		}
		else if(id == CardIdentifier.ELEPHANT_JUGGLER)
		{
			ElephantJuggler_Auto(cs);	
		}
		else if(id == CardIdentifier.DECADENT_SUCCUBUS)
		{
			DecadentSuccubus_Auto(cs);	
		}
		else if(id == CardIdentifier.DEATH_ARMY_GUY)
		{
			DeathArmyGuy_Auto(cs);	
		}
		else if(id == CardIdentifier.DEATH_ARMY_LADY)
		{
			DeathArmyLady_Auto(cs);	
		}
		else if(id == CardIdentifier.GODHAWK__ICHIBYOSHI)
		{
			GodhawkIchibyoshi_Auto(cs);	
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN__BLUE_EYE)
		{
			OracleGuardianBlueEye_Auto(cs);	
		}
		else if(id == CardIdentifier.DRANGAL)
		{
			Drangal_Auto(cs);	
		}
		else if(id == CardIdentifier.TOYPUGAL)
		{
			Toypugal_Auto(cs);	
		}
		else if(id == CardIdentifier.SAVAGE_WARRIOR)
		{
			SavageWarrior_Auto(cs);	
		}
		else if(id == CardIdentifier.RAGING_DRAGON__BLASTSAURUS)
		{
			RagingDragonBlastsaurus_Auto(cs);	
		}
		else if(id == CardIdentifier.HADES_RINGMASTER)
		{
			HadesRingmaster_Auto(cs);	
		}
		else if(id == CardIdentifier.MIDNIGHT_BUNNY)
		{
			MidnightBunny_Auto(cs);	
		}
		else if(id == CardIdentifier.SKULL_JUGGLER)
		{
			SkullJ_Auto(cs);	
		}
		else if(id == CardIdentifier.VERMILLION_GATEKEEPER)
		{
			Vermillion_Auto(cs);	
		}
		else if(id == CardIdentifier.ALLURING_SUCCUBUS)
		{
			Alluring_Auto(cs);
		}	
		else if(id == CardIdentifier.IMPRISONED_FALLEN_ANGEL__SARAQAEL)
		{
			Saraqael_Auto(cs);	
		}
		else if(id == CardIdentifier.DUAL_AXE_ARCHDRAGON)
		{
			DualAxe_Auto(cs);	
		}
		else if(id == CardIdentifier.MIRROR_DEMON)
		{
			MirrorDemon_Auto(cs);	
		}
		else if(id == CardIdentifier.DUSK_ILLUSIONIST__ROBERT)
		{
			Robert_Auto(cs);	
		}
		else if(id == CardIdentifier.DOREEN_THE_THRUSTER)
		{
			Doreen_Auto(cs);	
		}
		else if(id == CardIdentifier.GWYNN_THE_RIPPER)
		{
			Ripper_Auto(cs);	
		}
		else if(id == CardIdentifier.GODDESS_OF_THE_HALF_MOON__TSUKUYOMI)
		{
			HalfMoon_Auto(cs);	
		}
		else if(id == CardIdentifier.SWORDSMAN_OF_THE_EXPLOSIVE_FLAMES__PALAMEDES)
		{
			Palamedes_Auto(cs);	
		}
		else if(id == CardIdentifier.RAVENOUS_DRAGON__GIGAREX)
		{
			Gigarex_Auto(cs);	
		}
		else if(id == CardIdentifier.NIGHTMARE_DOLL__ALICE)
		{
			Alice_Auto(cs);	
		}
		else if(id == CardIdentifier.STIL_VAMPIR)
		{
			StillVampir_Auto(cs);	
		}
		else if(id == CardIdentifier.SPIKE_BOUNCER)
		{
			SpikeBouncer_Auto(cs);	
		}
		else if(id == CardIdentifier.PROWLING_DRAGON__STRIKEN)
		{
			Striken_Auto(cs);	
		}
		else if(id == CardIdentifier.MACHINING_WORKER_ANT)
		{
			WorkerAnt_Auto(cs);	
		}
		else if(id == CardIdentifier.MACHINING_MANTIS)
		{
			Mantis_Auto(cs);	
		}
		else if(id == CardIdentifier.SWIFT_ARCHER__FUSHIMI)
		{
			Fushimi_Auto(cs);	
		}
		else if(id == CardIdentifier.LARK_PIGEON)
		{
			LarkPigeon_Auto(cs);	
		}
		else if(id == CardIdentifier.STARTING_PRESENTER)
		{
			Presenter_Auto(cs);
		}
		else if(id == CardIdentifier.NITRO_JUGGLER)
		{
			NitroJuggler_Auto(cs);
		}	
		else if(id == CardIdentifier.JUMPING_JILL)
		{
			Jumping_Auto(cs);	
		}
		else if(id == CardIdentifier.CAT_BUTLER)
		{
			CatButler_Auto(cs);	
		}
		else if(id == CardIdentifier.BOOMERANG_THROWER)
		{
			Boomerang_Auto(cs);	
		}
		else if(id == CardIdentifier.SAGE_OF_GUIDANCE__ZENON)
		{
			Zenon_Auto(cs);	
		}
		else if(id == CardIdentifier.GUARD_GRIFFIN)
		{
			Griffin_Auto(cs);	
		}
		else if(id == CardIdentifier.BELLICOSITY_DRAGON)
		{
			BellDragon_Auto(cs);
		}
		else if(id == CardIdentifier.PROMISE_DAUGHTER)
		{
			Promise_Auto(cs);
		}
		else if(id == CardIdentifier.TWIN_SWORDSMAN__MUSASHI)
		{
			Musashi_Auto(cs);	
		}
		else if(id == CardIdentifier.MISS_SPLENDOR)
		{
			MissSplendor_Auto(cs);
		}	
		else if(id == CardIdentifier.WEATHER_FORECASTER__MISS_MIST)
		{
			MissMist_Auto(cs);	
		}
		else if(id == CardIdentifier.MACHINING_STAG_BEETLE)
		{
			MachiningStagBeetle_Auto(cs);	
		}
		else if(id == CardIdentifier.GOLDEN_BEAST_TAMER)
		{
			GoldenBeastTamer_Auto(cs);	
		}
		else if(id == CardIdentifier.EXCULPATE_THE_BLASTER)
		{
			ExculpateTheBlaster_Auto(cs);	
		}
		else if(id == CardIdentifier.MEGACOLONY_BUTTLER_A)
		{
			BattlerA_Auto(cs);	
		}
		else if(id == CardIdentifier.INTELLI_MOUSE)
		{
			IntelliMouse_Auto(cs);	
		}
		else if(id == CardIdentifier.LADY_BOMB)
		{
			LadyBomb_Auto(cs);	
		}
		else if(id == CardIdentifier.BLAZER_IDOLS)
		{
			BlazerIdols_Pointer();	
		}
		else if(id == CardIdentifier.BLAZER_IDOLS)
		{
			BlazerIdols_Auto(cs);	
		}
		else if(id == CardIdentifier.CRAY_SOLDIER)
		{
			CraySoldier_Auto(cs);	
		}
		else if(id == CardIdentifier.CANNON_FIRE_DRAGON_CANNON_GEAR)
		{
			CannonFireDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.ONE_WHO_GAZES_AT_THE_TRUTH)
		{
			OneWhoGazes_Auto(cs);	
		}
		else if(id == CardIdentifier.SECURITY_GUARDIAN)
		{
			SecurityGuardian_Auto(cs);	
		}
		else if(id == CardIdentifier.FOLLOWER_REAS)
		{
			FollowerReas_Auto(cs);	
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT_BERGER)
		{
			Berger_Auto(cs);	
		}
		else if(id == CardIdentifier.KNIGHT_OF_TRUTH_GORDON)
		{
			Gordon_Auto(cs);	
		}
		else if(id == CardIdentifier.EVIL_SHADE)
		{
			EvilShade_Auto(cs);	
		}
		else if(id == CardIdentifier.SKELETON_SWORDSMAN)
		{
			SkeletonSwordsman_Auto(cs);
		}
		else if(id == CardIdentifier.SPIKE_BROTHERS_ASSAULT_SQUAD)
		{
			AssaultSquad_Auto(cs);	
		}
		else if(id == CardIdentifier.CYCLONE_BLITZ)
		{
			CycloneBlitz_Auto(cs);	
		}
		else if(id == CardIdentifier.DEVIL_SUMMONER)
		{
			DevilSummoner_Auto(cs);	
		}
		else if(id == CardIdentifier.PANZER_GALE)
		{
			PanzerGale_Auto(cs);	
		}
		else if(id == CardIdentifier.SCIENTIST_MONKEY_RUE)
		{
			MonkeyRue_Auto(cs);	
		}
		else if(id == CardIdentifier.MASTER_FRAUDE)
		{
			MasterFraudo_Auto(cs);	
		}
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET_CARAVEL)
		{
			Caravel_Auto(cs);	
		}
		else if(id == CardIdentifier.DRAGON_EGG)
		{
			DragonEgg_Auto(cs);	
		}
		else if(id == CardIdentifier.WINGED_DRAGON_SKYPTERO)
		{
			WingedDragonSkyptero_Auto(cs);	
		}
		else if(id == CardIdentifier.LUCK_BIRD)
		{
			LuckBird_Auto(cs);	
		}
		else if(id == CardIdentifier.HIGH_DOG_BREEDER_AKANE)
		{
			BreederAkane_Auto(cs);	
		}
		else if(id == CardIdentifier.GREAT_SAGE_BARRON)
		{
			GreatSageBarron_Auto(cs);	
		}
		else if(id == CardIdentifier.GIGANTECH_CHARGER)
		{
			GigantechCharger_Auto(cs);	
		}
		else if(id == CardIdentifier.CHAPPIE_THE_GHOSTIE)
		{
			ChappieTheGhostie_Auto(cs);
		}	
		else if(id == CardIdentifier.DANCING_CUTLASS)
		{
			DancingCutlass_Auto(cs);	
		}
		else if(id == CardIdentifier.DUDLEY_DAN)
		{
			DudleyDan_Auto(cs);	
		}
		else if(id == CardIdentifier.UNITE_ATTACKER)
		{
			UniteAttacker_Auto(cs);	
		}
		else if(id == CardIdentifier.TOP_IDOL_FLORES)
		{
			TopIdolFlores_Auto(cs);	
		}
		else if(id == CardIdentifier.MAGICIAN_GIRL_KIRARA)
		{
			MagicianGirlKirara_Auto(cs);	
		}
		else if(id == CardIdentifier.SILENT_TOM)
		{
			SilentTom_Auto(cs);	
		}
		else if(id == CardIdentifier.CHAIN_ATTACK_SUTHERLAND)
		{
			ChainAttackSutherland_Auto(cs);	
		}
		else if(id == CardIdentifier.YOUNG_PEGASUS_KNIGHT)
		{
			YoungPegasusKnight(cs);	
		}
		else if(id == CardIdentifier.WITCH_DOCTOR_OF_THE_ABYSS_NEGROMARL)
		{
			Negromarl_Auto(cs);	
		}
		else if(id == CardIdentifier.KING_OF_DEMONIC_SEAS_BASSKIRK)
		{
			Basskirk_Auto(cs);	
		}
		else if(id == CardIdentifier.GENERAL_SEIFRIED)
		{
			GeneralSeifried_Auto(cs);	
		}
		else if(id == CardIdentifier.LION_HEAT)
		{
			LionHeat_Auto(cs);	
		}
		else if(id == CardIdentifier.SEAL_DRAGON_BLOCKADE)
		{
			SealDragonBlockade_Auto(cs);	
		}
		else if(id == CardIdentifier.BLAZING_FLARE_DRAGON)
		{
			BlazingFlareDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.SOUL_SAVER_DRAGON)
		{
			SoulSaverDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.RUIN_SHADE)
		{
			RuinShade_Auto(cs);	
		}
		else if(id == CardIdentifier.GUIDING_ZOMBIE)
		{
			GuidingZombie_Auto(cs);	
		}
		else if(id == CardIdentifier.REDSHOE_MILLY)
		{
			RedshoeMilly_Auto(cs);	
		}
		else if(id == CardIdentifier.ROCK_THE_WALL)
		{
			RockTheWall_Auto(cs);	
		}
		else if(id == CardIdentifier.NIGHTMARE_BABY)
		{
			NightmareBaby_Auto(cs);	
		}
		else if(id == CardIdentifier.BLUE_DUST)
		{
			BlueDust_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_BEAST_HAGAKURE)
		{
			Hagakure_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_DRAGON_DREADMASTER)
		{
			StealthDragonDreadmaster_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_BEAST_CHIGASUMI)
		{
			Chigasumi_Auto(cs);	
		}
		else if(id == CardIdentifier.DEMON_EATER)
		{
			DemonEater_Auto(cs);	
		}
		else if(id == CardIdentifier.STEALTH_DRAGON_VOIDMASTER)
		{
			StealthDragonVoidmaster_Auto(cs);	
		}
		else if(id == CardIdentifier.ASSAULT_DRAGON_BLIGHTOPS)
		{
			AssaultDragonBlightops_Auto(cs);	
		}
		else if(id == CardIdentifier.TYRANT_DEATHREX)
		{
			TyrantDeathrex_Auto(cs);	
		}
		else if(id == CardIdentifier.WYVERN_STRIKE_TEJAS)
		{
			WyvernStrike_Auto(cs, card);	
		}
		else if(id == CardIdentifier.FLAME_OF_HOPE_AERMO)
		{
			FlameOfHopeAermo_Auto(cs, card);	
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MADONNA_JOKA)
		{
			DemonicDragonMadonnaJoka_Auto(cs, card);	
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE_RAKSHASA)
		{
			DemonicDragonMageRakshasa_Auto(cs, card);	
		}
		else if(id == CardIdentifier.WYVERN_STRIKE_JARRAN)
		{
			WyvernStrikeJarran_Auto(cs, card);	
		}
		else if(id == CardIdentifier.GOLD_RUTILE)
		{
			GoldRutile_Auto(cs, card);	
		}
		else if(id == CardIdentifier.SUPER_ELECTROMAGNETIC_LIFEFORM_STORM)
		{
			SuperLifeform_Auto(cs);	
		}
		else if(id == CardIdentifier.QUEEN_OF_HEART)
		{
			QueenOfHeart_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTERING_MINOTAUR)
		{
			BatteringMinotaur_Auto(cs);	
		}
		else if(id == CardIdentifier.NGM_PROTOTYPE)
		{
			NGMPrototype_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTLERAIZER)
		{
			Battleraizer_Auto(cs);
		}
		else if(id == CardIdentifier.MR_INVINCIBLE)
		{
			MrInvincible_Auto(cs);	
		}
		else if(id == CardIdentifier.BARCGAL)
		{
			Barcgal_Auto(cs);	
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN_APOLLON)
		{
			OracleGuardianApollon_Auto(cs);	
		}
		else if(id == CardIdentifier.MAIDEN_OF_LIBRA)
		{
			MaidenOfLibra_Auto(cs);	
		}
		else if(id == CardIdentifier.BATTLE_SISTER_MOCHA)
		{
			BattleSisterMocha_Auto(cs);	
		}
		else if(id == CardIdentifier.WEATHER_GIRL_MILK)
		{
			WeatherGirlMilk_Auto(cs);
		}
		else if(id == CardIdentifier.LOZENGE_MAGUS)
		{
			LozengeMagus_Auto(cs);	
		}
		else if(id == CardIdentifier.DEMON_SLAYING_KNIGHT_LOHENGRIM)
		{
			Lohengrim_Auto(cs);	
		}
		else if(id == CardIdentifier.VORTEX_DRAGON)
		{
			VortexDragon_Auto(cs);	
		}
		else if(id == CardIdentifier.LIZARD_SOLIDER_CONROE)
		{
			LizardSoldierConroe_Auto(cs);	
		}
		else if(id == CardIdentifier.BRUTAL_JACK)
		{
			BrutalJack_Auto(cs);	
		}
		else if(id == CardIdentifier.CLAY_DOLL_MECHANIC)
		{
			ClayDollMechanic_Auto(cs);	
		}
		else if(id == CardIdentifier.HUNGRY_DUMPTY)
		{
			HungryDumpty_Auto(cs);	
		}
		else if(id == CardIdentifier.KARMA_QUEEN)
		{
			KarmaQueen_Auto(cs);	
		}
		else if(_UnitObject != null)
		{
			_UnitObject.Auto(cs, effectOwner);	
		}

		if(!Game.bCheckAutoMode)
		{
			if(cs == CardState.EndBattle)
			{
				Game.numBattle++;
			}
			
			
			if(Game.EffectOnGoingEnemyTurn)
			{
				Game.bEndEvent = true;
				Game.EffectOnGoingEnemyTurn = false;
			}
			
			for(int i = 0; i < ExternAuto.Count; i++)
			{
				if(Game.bEffectOnGoing)
				{
					Game._AbilityManagerExt.AddAbility(cs, OwnerCard, i, effectOwner);
				}
				else
				{
					LastExternAbility = i;
					ExternAuto[i](cs, effectOwner);
				}
			}

			for(int i = 0; i < ExternEffects.Count; i++)
			{
				if(Game.bEffectOnGoing)
				{
					Game._AbilityManager.AddAbility(cs, OwnerCard, ExternEffects[i].id);	
				}
				else
				{
					ExternEffects[i].Auto(cs, effectOwner);	
				}
			}
		}
	}
	
	public void CheckAbilityOnHand(CardState cs, Card card)
	{
		if(card.cardID == CardIdentifier.DEMONIC_DRAGON_BERSERKER_YAKSHA)
		{
			DemonicDragonBerserkerYaksha_CheckHandAbility(cs, card);
		}
		else if(_UnitObject != null)
		{
			_UnitObject.AutoHand(cs);
		}	
	}
	
	public int HasOnSoulEffect()
	{
		CardIdentifier id = OwnerCard.cardID;
	
		if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIBATTLES) return DimensionalRoboDaibattles_HasOnSoulEffect();
		else if(_UnitObject != null)
		{
			return _UnitObject.EffectOnSoul();	
		}
		
		return 0;
	}
	
	public int HasOnDamageEffect()
	{
		if(_UnitObject != null)
		{
			return _UnitObject.EffectOnDamage();	
		}
		
		return 0;
	}
	
	public int HasOnDropEffect()
	{
		CardIdentifier _id = OwnerCard.cardID;
		
		if(_id == CardIdentifier.MONSTER_FRANK)
		{
			return MonsterFrank_HasOnDropEffect();
		}	
		else if(_id == CardIdentifier.DEADLY_NIGHTMARE)
		{
			return DeadlyNightmare_Drop();	
		}
		else if(_id == CardIdentifier.DEADLY_SPIRIT)
		{
			return DeadlySpirit_Drop();
		}	
		else if(_id == CardIdentifier.SPIRIT_EXCEED)
		{
			return SpiritExceed_Drop();	
		}
		else if(_UnitObject != null)
		{
			return _UnitObject.EffectOnDrop();
		}
		
		return 0;
	}
	
	public bool HasInHandEffect(Card card)
	{
		Game._LastUnitAbilityCard = card;
		id = card.cardID;
		return CheckHandAbility(id);
	}
	
	public int HasOnFieldEffect(Card card)
	{
		Game._LastUnitAbilityCard = card;
		CardIdentifier id = card.cardID;
		 
		     if(id == CardIdentifier.SOLITARY_KNIGHT_GANCELOT)             return CheckActiveGancelot();
		else if(id == CardIdentifier.STEALTH_BEAST__CAT_DEVIL) return StealthBeastCatDevil_Field();
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_BODY_REPLACEMENT__KOKUENMARU) return StealthRogueofBodyReplacementKokuenmaru_Field();
		else if(id == CardIdentifier.STEALTH_BEAST__NIGHT_PANTHER) return StealthBeastNightPanther_Field();
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_SUMMONING__JIRAIYA) return StealthRogueofSummoningJiraiya_Field();
		else if(id == CardIdentifier.DREAMING_SAGE__CORRON) return DreamingSageCorron_Field();
		else if(id == CardIdentifier.STARLIGHT_MELODY_TAMER__FARAH) return StarlightMelodyTamerFarah_Field();
		else if(id == CardIdentifier.TRI_STINGER_DRAGON) return TristingerDragon_Field();
		else if(id == CardIdentifier.PLATINUM_BLOND_FOX_SPIRIT__TAMAMO) return PlatinumBlondFoxSpiritTamamo_Field();
		else if(id == CardIdentifier.CONVICTION_DRAGON__CHROMEJAILER_DRAGON) return ConvictionDragonChromejailerDragon_Field();
		else if(id == CardIdentifier.EXORCIST_MAGE__KOH_KOH)               return ExorcistMageKohKoh_Field();
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM) return CovertDemonicDragonMagatsuStorm_Field();
		else if(id == CardIdentifier.TEAR_KNIGHT__CYPRUS)                  return TearKnightCyprus_Field();
		else if(id == CardIdentifier.NAVALGAZER_DRAGON)                    return NavalgazerDragon_Field();
		else if(id == CardIdentifier.BROCCOLINI_MUSKETEER__KIRAH)          return BroccoliniMusketeerKirah_Field();
		else if(id == CardIdentifier.THUNDER_SPEAR_WIELDING_EXORCIST_KNIGHT) return ThunderSpearWieldingExorcistKnight_Field();
		else if(id == CardIdentifier.AQUA_BREATH_DRACOKID) return AquaBreathDracokid_Field();
		else if(id == CardIdentifier.SUBTERRANEAN_BEAST__MAGMA_LORD) return SubterraneanBeastMagmaLord_Field();
		else if(id == CardIdentifier.ARMED_INSTRUCTOR__BISON) return ArmedInstructorBison_Field();
		else if(id == CardIdentifier.HYDRO_HURRICANE_DRAGON) return HydroHurricaneDragon_Field();
		else if(id == CardIdentifier.GIRL_WHO_CROSSED_THE_GAP)
		{
			return GirlWhoCrossedtheGap_Field();
		}	
		else if(id == CardIdentifier.HOPE_CHILD__TURIEL)
		{
			return HopeChildTuriel_Field();	
		}
		else if(id == CardIdentifier.DEVIL_IN_SHADOW)
		{
			return DevilinShadow_Field();	
		}
		else if(id == CardIdentifier.INNOCENT_MAGICIAN)
		{
			return InnocentMagician_Field();	
		}
		else if(id == CardIdentifier.BATTLE_SISTER__ECLAIR)
		{
			return BattleSisterEclair_Field();	
		}
		else if(id == CardIdentifier.DARK_KNIGHT_OF_NIGHTMARELAND)
		{
			return DarkKnightofNightmareland_Field();	
		}
		else if(id == CardIdentifier.ACORN_MASTER)
		{
			return AcornMaster_Field();	
		}
		else if(id == CardIdentifier.THUMBTACK_FIGHTER__RESANORI)
		{
			return ThumbtackFighterResanori_Field();	
		}
		else if(id == CardIdentifier.FLASK_MARMOSET)
		{
			return FlaskMarmoset_Field();	
		}
		else if(id == CardIdentifier.YELLOW_BOLT)
		{
			return YellowBolt_Field();
		}
		else if(id == CardIdentifier.MAGICIAN_OF_QUANTUM_MECHANICS)
		{
			return MagicianofQuantumMechanics_Field();	
		}
		else if(id == CardIdentifier.TANK_MOUSE)
		{
			TankMouse_Field();	
		}
		else if(id == CardIdentifier.SILVER_THORN_DRAGON_TAMER__LUQUIER)
		{
			return SilverThornDragonTamerLuquier_Field();	
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__RIKI)
		{
			return LizardSoldierRiki_Field();	
		}
		else if(id == CardIdentifier.EVIL_SLAYING_SWORDSMAN__HAUGAN)
		{
			return EvilSlayingSwordsmanHaugan_Field();	
		}
		else if(id == CardIdentifier.SLEYGAL_SWORD)
		{
			return SleygalSword_Field();	
		}
		else if(id == CardIdentifier.SLEYGAL_DOUBLE_EDGE)
		{
			return SleygalDoubleEdge_Field();	
		}
		else if(id == CardIdentifier.MALEVOLENT_DJINN)
		{
			return MalevolentDjinn_Field();	
		}
		else if(id == CardIdentifier.SPARK_KID_DRAGOON)
		{
			return SparkKidDragoon_Field();	
		}
		else if(id == CardIdentifier.FLAME_OF_VICTORY)
		{
			return FlameofVictory_Field();	
		}
		else if(id == CardIdentifier.LITTLE_FIGHTER__CRON)
		{
			return LittleFighterCron_Field();	
		}
		else if(id == CardIdentifier.SKELETON_ASSAULT_TROOPS_CAPTAIN)
		{
			return SkeletonAssaultTroopsCaptain_Field();	
		}
		else if(id == CardIdentifier.CAPTAIN_NIGHTKID)
		{
			return CaptainNightkid_Field();	
		}
		else if(id == CardIdentifier.CHILD_FRANK)
		{
			return ChildFrank_Field();	
		}
		else if(id == CardIdentifier.CRITICAL_HIT_ANGEL)
		{
			return CriticalHitAngel_Field();	
		}
		else if(id == CardIdentifier.HAPPY_BELL__NOCIEL)
		{
			return HappyBellNociel_Field();	
		}
		else if(id == CardIdentifier.THERMOMETER_ANGEL)
		{
			return ThermometerAngel_Field();	
		}
		else if(id == CardIdentifier.LANCET_SHOOTER)
		{
			return LancetShooter_Field();	
		}
		else if(id == CardIdentifier.RIOT_GENERAL__GYRAS)
		{
			return RiotGeneralGyras_Field();	
		}
		else if(id == CardIdentifier.CRIMSON_LION_CUB__KYRPH)
		{
			return CrimsonLionCubKyrph_Field();	
		}
		else if(id == CardIdentifier.SKYHIGH_WALKER)
		{
			return SkyhighWalker_Field();	
		}
		else if(id == CardIdentifier.HYSTERIC_SHIRLEY)
		{
			return HystericShirley_Field();	
		}
		else if(id == CardIdentifier.GUIDE_DOLPHIN)
		{
			return GuideDolphin_Field();	
		}
		else if(id == CardIdentifier.ANTHRODROID)
		{
			return Anthrodroid_Field();	
		}
		else if(id == CardIdentifier.DOOM_BRINGER_GRIFFIN)
		{
			return DoomBringerGriffin_Field();	
		}
		else if(id == CardIdentifier.SILENT_SAGE__SHARON)
		{
			return SilentSageSharon_Field();	
		}
		else if(id == CardIdentifier.PHANTOM_BRINGER_DEMON)
		{
			return PhantomBringerDemon_Field();	
		}
		else if(id == CardIdentifier.STEALTH_FIEND__DART_SPIDER)
		{
			return StealthFiendDartSpider_Field();
		}	
		else if(id == CardIdentifier.WATERING_ELF)
		{
			return WateringElf_Field();	
		}
		else if(id == CardIdentifier.LADY_OF_THE_SUNLIGHT_FOREST)
		{
			return LadyoftheSunlightForest_FieldCheck();	
		}
		else if(id == CardIdentifier.CARAMEL_POPCORN)
		{
			return CaramelPopcorn_FieldCheck();	
		}
		else if(id == CardIdentifier.STEALTH_BEAST__EVIL_FERRET)
		{
			return StealthBeastEvilFerret_Field();	
		}
		else if(id == CardIdentifier.WITCH_OF_NOSTRUM__ARIANRHOD)
		{
			return Arianrhod_Field();	
		}
		else if(id == CardIdentifier.DEATH_WARDEN_ANT_LION)
		{
			return DeathWardenAntLion_Field();	
		}
		else if(id == CardIdentifier.COSMO_ROAR)
		{
			return CosmoRoar_Field();	
		}
		else if(id == CardIdentifier.SILVER_SPEAR_DEMON__GUSION)
		{
			return SilverSpearDemonGusion_Field();	
		}
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__SHIZUKU)
		{
			return BermudaTriangleCadetShizuku_Field();	
		}
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__WEDDELL)
		{
			return BermudaTriangleCadetWeddell_Field();	
		}
		else if(id == CardIdentifier.IMPRISONED_FALLEN_ANGEL__SARAQAEL)
		{
			return Saraqael_Field();	
		}
		else if(id == CardIdentifier.DUSK_ILLUSIONIST__ROBERT)
		{
			return Robert_Field();	
		}
		else if(id == CardIdentifier.EDEL_ROSE)
		{
			return EdelRose_Field();	
		}
		else if(id == CardIdentifier.ULTIMATE_LIFEFORM__COSMO_LORD)
		{
			return Lifeform_Field();	
		}
		else if(id == CardIdentifier.STIL_VAMPIR)
		{
			return StillVampir_Field();	
		}
		else if(id == CardIdentifier.SAVAGE_KING)
		{
			return SavageKing_Field();	
		}
		else if(id == CardIdentifier.ROCKET_HAMMER_MAN)
		{
			return RocketHammer_Field();
		}	
		else if(card.cardID == CardIdentifier.GOLDEN_BEAST_TAMER)
		{
			return GoldenBeastTamer_Field();	
		}
		else if(id == CardIdentifier.EXCULPATE_THE_BLASTER)
		{
			return ExculpateTheBlaster_Field();	
		}
		else if(card.cardID == CardIdentifier.INTELLI_MOUSE)
		{
			return IntelliMouse_Field();	
		}
		else if(card.cardID == CardIdentifier.RED_LIGHTING)
		{
			return RedLighting_Field();	
		}
		else if(card.cardID == CardIdentifier.PSYCHIC_BIRD)
		{
			return PsychicBird_Field();	
		}
		else if(card.cardID == CardIdentifier.GATTLING_CLAW_DRAGON)
		{
			return ClawDragon_Field();	
		}
		else if(card.cardID == CardIdentifier.IRON_TAIL_DRAGON)
		{
			return IronTailDragon_FieldCheck();	
		}
		else if(card.cardID == CardIdentifier.MARGAL)
		{
			return Margal_Field();	
		}
		else if(card.cardID == CardIdentifier.SOUL_GUIDING_ELF)
		{
			return SoulGuidingElf_FieldCheck();	
		}
		else if(card.cardID == CardIdentifier.ROUGH_SEAS_BANSHEE)
		{
			return RoughSeas_Field();	
		}
		else if(card.cardID == CardIdentifier.SILENCE_JOKER)
		{
			return SilenceJoker_Field();	
		}
		else if(card.cardID == CardIdentifier.SCIENTIST_MONKEY_RUE)
		{
			return MonkeyRue_Field();	
		}
		else if(card.cardID == CardIdentifier.DEMONIC_DRAGON_MAGE_KIMNARA)
		{
			return Kimnara_Field();	
		}
		else if(card.cardID == CardIdentifier.BLAZING_CORE_DRAGON)
		{
			return BlazingCoreDragon_Field();
		}	
		else if(card.cardID == CardIdentifier.PONGAL)
		{
			return Pongal_Field();	
		}
		else if(card.cardID == CardIdentifier.KING_OF_DEMONIC_SEAS_BASSKIRK)
		{
			return Basskirk_Field();	
		}
		else if(card.cardID == CardIdentifier.BLAZING_FLARE_DRAGON)
		{
			return BlazingFlareDragon_Field();	
		}
		else if(card.cardID == CardIdentifier.OASIS_GIRL)
		{
			return OasisGirl_FieldCheck();	
		}
		else if(card.cardID == CardIdentifier.SCREAMIN_AND_DANCIN_ANNOUNCER_SHOUT)
		{
			return ScreamingShout_FieldCheck();	
		}
		else if(card.cardID == CardIdentifier.BARCGAL)
		{
			return Barcgal_Field();	
		}
		else if(card.cardID == CardIdentifier.DRAGON_KNIGHT_ALEPH)
		{
			return DragonKnightAleph_Field();	
		}
		else if(card.cardID == CardIdentifier.EMBODIMENT_OF_VICTORY_ALEPH)
		{
			return EmbodimentVictoryAleph_Field();	
		}
		else if(card.cardID == CardIdentifier.FUTURE_KNIGHT_LLEW)
		{
			return FutureKnightLlew_Field();	
		}
		else if(card.cardID == CardIdentifier.VORTEX_DRAGON)
		{
			return VortexDragon_Field();	
		}
		else if(card.cardID == CardIdentifier.LIZARD_SOLIDER_CONROE)
		{
			return LizardSoldierConroe_Field();	
		}
		else if(card.cardID == CardIdentifier.BRUTAL_JACK)
		{
			return BrutalJack_Field();	
		}
		else if(card.cardID == CardIdentifier.GUIDING_ZOMBIE)
		{
			return GuidingZombie_Field();	
		}
		else if(_UnitObject != null)
		{
			return _UnitObject.Act();
		}
		
		return 0;
	}
	
	public bool CheckHandAbility(CardIdentifier _id)
	{
		if(_id == CardIdentifier.SOLITARY_KNIGHT_GANCELOT)
		{
			return CheckHandGancelot();
		}
		else if(_id == CardIdentifier.CHAOS_DRAGON_DINOCHAOS)
		{
			return ChaosDragon_Hand();	
		}
		else if(_id == CardIdentifier.EDEL_ROSE)
		{
			return EdelRose_Hand();	
		}
		else if(_id == CardIdentifier.DESTRUCTION_DRAGON__DARK_REX)
		{
			return DestructionDragonDarkRex_Hand();	
		}
		else if(_UnitObject != null)
		{
			return _UnitObject.EffectOnHand();	
		}
		
		return false;
	}
	/// @endcond
	/// @cond
	public void FreeUpdate(CardIdentifier _id)
	{
		if(CurrentExternAbility != -1)
		{
			ExternUpdate[CurrentExternAbility]();
			return;
		}
		
		for(int i = 0; i < ExternEffects.Count; i++)
		{
			ExternEffects[i].Update();	
		}
		
		if(_id == CardIdentifier.BATTLERAIZER)
		{
			Battleraizer_Update();	
		}
		else if(_id == CardIdentifier.BOON_BANA_NA) BoonBanana_Update();
		else if(_id == CardIdentifier.OFFICER_CADET__ASTRAEA) OfficerCadetAstraea_Update();
		else if(_id == CardIdentifier.LIGHT_SIGNALS_PENGUIN_SOLDIER) LightSignalsPenguinSoldier_Update();
		else if(_id == CardIdentifier.DECK_SWEEPER) DeckSweeper_Update();
		else if(_id == CardIdentifier.STEALTH_BEAST__CAT_DEVIL) StealthBeastCatDevil_Update();
		else if(_id == CardIdentifier.STEALTH_ROGUE_OF_BODY_REPLACEMENT__KOKUENMARU) StealthRogueofBodyReplacementKokuenmaru_Update();
		else if(_id == CardIdentifier.STEALTH_BEAST__FLAME_FOX) StealthBeastFlameFox_Update();
		else if(_id == CardIdentifier.STEALTH_BEAST__NIGHT_PANTHER) StealthBeastNightPanther_Update();
		else if(_id == CardIdentifier.STEALTH_ROGUE_OF_SUMMONING__JIRAIYA) StealthRogueofSummoningJiraiya_Update();
		else if(_id == CardIdentifier.STEALTH_BEAST__SPELL_HOUND) StealthBeastSpellHound_Update();
		else if(_id == CardIdentifier.FIRE_JUGGLER) FireJuggler_Update();
		else if(_id == CardIdentifier.BARKING_WYVERN) BarkingWyvern_Update();
		else if(_id == CardIdentifier.DREAMING_SAGE__CORRON) DreamingSageCorron_Update();
		else if(_id == CardIdentifier.ADVANCE_OF_THE_BLACK_CHAINS__KAHEDIN) AdvanceoftheBlackChainsKahedin_Update();
		else if(_id == CardIdentifier.MOBILE_HOSPITAL__ELYSIUM) MobileHospitalElysium_Update();
		else if(_id == CardIdentifier.BEAST_DEITY__BLANK_MARSH) BeastDeityBlankMarsh_Update();
		else if(_id == CardIdentifier.TRI_HOLL_DRACOKID) TrihollDracokid_Update();
		else if(_id == CardIdentifier.STORM_RIDER__NICOLAS) StormRiderNicolas_Update();
		else if(_id == CardIdentifier.STORM_RIDER__DAMON) StormRiderDamon_Update();
		else if(_id == CardIdentifier.STORM_RIDER__LYSANDER) StormRiderLysander_Update();
		else if(_id == CardIdentifier.STEALTH_DRAGON__MAGATSU_WIND) StealthDragonMagatsuWind_Update();
		else if(_id == CardIdentifier.STEALTH_FIEND__OBORO_CART)StealthFiendOboroCart_Update();
		else if(_id == CardIdentifier.BLASTER_BLADE_SPIRIT) BlasterBladeSpirit_Update();
		else if(_id == CardIdentifier.NIGHTMARE_SUMMONER__RAQIEL) NightmareSummonerRaqiel_Update();
		else if(_id == CardIdentifier.STARLIGHT_MELODY_TAMER__FARAH) StarlightMelodyTamerFarah_Update();
		else if(_id == CardIdentifier.LORD_OF_THE_DEMONIC_WINDS__VAYU) LordoftheDemonicWindsVayu_Update();
		else if(_id == CardIdentifier.BATTLER_OF_THE_TWIN_BRUSH__POLARIS) BattleroftheTwinBrushPolaris_Update();
		else if(_id == CardIdentifier.BATTLE_SISTER__COOKIE) BattleSisterCookie_Update();
		else if(_id == CardIdentifier.TRI_STINGER_DRAGON) TristingerDragon_Update();
		else if(_id == CardIdentifier.PLATINUM_BLOND_FOX_SPIRIT__TAMAMO) PlatinumBlondFoxSpiritTamamo_Update();
		else if(_id == CardIdentifier.FANTASY_PETAL_STORM__SHIRAYUKI) FantasyPetalStormShirayuki_Update();
		else if(_id == CardIdentifier.CONVICTION_DRAGON__CHROMEJAILER_DRAGON) ConvictionDragonChromejailerDragon_Update();
		else if(_id == CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM) CovertDemonicDragonMagatsuStorm_Update();
		else if(_id == CardIdentifier.BATTLE_SIREN__CYNTHIA) BattleSirenCynthia_Update();
		else if(_id == CardIdentifier.ACCELERATED_COMMAND) AcceleratedCommand_Update();
		else if(_id == CardIdentifier.TEAR_KNIGHT__CYPRUS) TearKnightCyprus_Update();
		else if(_id == CardIdentifier.KEY_ANCHOR__DABID) KeyAnchorDabid_Update();
		else if(_id == CardIdentifier.NAVALGAZER_DRAGON) NavalgazerDragon_Update();
		else if(_id == CardIdentifier.EXORCIST_MAGE__KOH_KOH) ExorcistMageKohKoh_Update();
		else if(_id == CardIdentifier.DRAGON_MONK__GINKAKU) DragonMonkGinkaku_Update();
		else if(_id == CardIdentifier.DRAGON_MONK__KINKAKU) DragonMonkKinkaku_Update();
		else if(_id == CardIdentifier.OFFICER_CADET__ERIKK) OfficerCadetErikk_Update();
		else if(_id == CardIdentifier.RELIABLE_STRATEGIC_COMMANDER) ReliableStrategicCommander_Update();
		else if(_id == CardIdentifier.STREAM_TROOPER) StreamTrooper_Update();
		else if(_id == CardIdentifier.VETERAN_STRATEGIC_COMMANDER) VeteranStrategicCommander_Update();
		else if(_id == CardIdentifier.DISTANT_SEA_ADVISOR__VASSILIS) DistantSeaAdvisorVassilis_Update();
		else if(_id == CardIdentifier.BABY_PTERO) BabyPtero_Update();
		else if(_id == CardIdentifier.TRANSPORT_DRAGON__BRACHIOPORTER) TransportDragonBrachioporter_Update();
		else if(_id == CardIdentifier.FORTRESS_AMMONITE) FortressAmmonite_Update();
		else if(_id == CardIdentifier.SAVAGE_MAGUS) SavageMagus_Update();
		else if(_id == CardIdentifier.CARRIER_DRAGON__BRACHIOCARRIER) CarrierDragonBrachiocarrier_Update();
		else if(_id == CardIdentifier.SAVAGE_WARLOCK) SavageWarlock_Update();
		else if(_id == CardIdentifier.CITADEL_DRAGON__BRACHIOCASTLE) CitadelDragonBrachiocastle_Update();
		else if(_id == CardIdentifier.BROCCOLINI_MUSKETEER__KIRAH) BroccoliniMusketeerKirah_Update();
		else if(_id == CardIdentifier.FRUITS_BASKET_ELF) FruitsBasketElf_Update();
		else if(_id == CardIdentifier.TULIP_MUSKETEER__MINA) TulipMusketeerMina_Update();
		else if(_id == CardIdentifier.TULIP_MUSKETEER__ALMIRA) TulipMusketeerAlmira_Update();
		else if(_id == CardIdentifier.WORLD_BEARING_TURTLE__AHKBARA) WorldBearingTurtleAhkbara_Update();
		else if(_id == CardIdentifier.EXPLODING_TOMATO) ExplodingTomato_Update();
		else if(_id == CardIdentifier.WORLD_SNAKE__OUROBOROS) WorldSnakeOuroboros_Update();
		else if(_id == CardIdentifier.DIMENSIONAL_ROBO__DAIBATTLES) DimensionalRoboDaibattles_Update();
		else if(_id == CardIdentifier.FIGHTING_SAUCER) FightingSaucer_Update();
		else if(_id == CardIdentifier.SPEEDSTER) Speedster_Update();
		else if(_id == CardIdentifier.MYSTERIOUS_NAVY_ADMIRAL__GOGOTH) MysteriousNavyAdmiralGogoth_Update();
		else if(_id == CardIdentifier.COSMIC_RIDER) CosmicRider_Update();
		else if(_id == CardIdentifier.COSMIC_MOTHERSHIP) CosmicMothership_Update();
		else if(_id == CardIdentifier.COILING_DUCKBILL) CoilingDuckbill_Update();
		else if(_id == CardIdentifier.COMPASS_LION) CompassLion_Update();
		else if(_id == CardIdentifier.THUNDER_SPEAR_WIELDING_EXORCIST_KNIGHT) ThunderSpearWieldingExorcistKnight_Update();
		else if(_id == CardIdentifier.AQUA_BREATH_DRACOKID) AquaBreathDracokid_Update();
		else if(_id == CardIdentifier.MILITARY_DRAGON__RAPTOR_SOLDIER) MilitaryDragonRaptorSoldier_Update();
		else if(_id == CardIdentifier.WINGED_DRAGON__BEAMPTERO) WingedDragonBeamptero_Update();
		else if(_id == CardIdentifier.WINGED_DRAGON__SLASHPTERO) WingedDragonSlashptero_Update();
		else if(_id == CardIdentifier.ARBOROS_DRAGON__RATOON) ArborosDragonRatoon_Update();
		else if(_id == CardIdentifier.DIMENSIONAL_ROBO__DAILANDER) DimensionalRoboDailander_Update();
		else if(_id == CardIdentifier.SUBTERRANEAN_BEAST__MAGMA_LORD) SubterraneanBeastMagmaLord_Update();
		else if(_id == CardIdentifier.ENIGMAN_CYCLONE) EnigmanCyclone_Update();
		else if(_id == CardIdentifier.ARMED_INSTRUCTOR__BISON) ArmedInstructorBison_Update();
		else if(_id == CardIdentifier.TEAR_KNIGHT__VALERIA) TearKnightValeria_Update();
		else if(_id == CardIdentifier.DESTRUCTION_DRAGON__DARK_REX) DestructionDragonDarkRex_Update();
		else if(_id == CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__REBECCA) LilyoftheValleyMusketeerRebecca_Update();
		else if(_id == CardIdentifier.HYDRO_HURRICANE_DRAGON) HydroHurricaneDragon_Update();
		else if(_id == CardIdentifier.OPERATOR_GIRL__MIKA) OperatorGirlMika_Update();
		else if(_id == CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__KAIVANT) LilyoftheValleyMusketeerKaivant_Update();
		else if(_id == CardIdentifier.MAIDEN_OF_RAINBOW_WOOD) MaidenofRainbowWood_Update();
		else if(_id == CardIdentifier.DREAMY_AMMONITE)
		{
			DreamyAmmonite_Update();	
		}
		else if(_id == CardIdentifier.DREAMY_FORTRESS)
		{
			DreamyFortress_Update();	
		}
		else if(_id == CardIdentifier.RUNE_WEAVER)
		{	
			RuneWeaver_Update();
		}
		else if(_id == CardIdentifier.NIGHTMARE_DOLL__AMY)
		{
			NightmareDollAmy_Update();	
		}
		else if(_id == CardIdentifier.GIRL_WHO_CROSSED_THE_GAP)
		{
			GirlWhoCrossedtheGap_Update();	
		}
		else if(_id == CardIdentifier.HOPE_CHILD__TURIEL)
		{
			HopeChildTuriel_Update();	
		}
		else if(_id == CardIdentifier.PINKY_PIGGY)
		{
			PinkyPiggy_Update();	
		}
		else if(_id == CardIdentifier.MIRAGE_MAKER)
		{
			MirageMaker_Update();	
		}
		else if(_id == CardIdentifier.MOONSAULT_SWALLOW)
		{	
			MoonsaultSwallow_Update();
		}
		else if(_id == CardIdentifier.DEVIL_IN_SHADOW)
		{
			DevilinShadow_Update();
		}
		else if(_id == CardIdentifier.INNOCENT_MAGICIAN)
		{
			InnocentMagician_Update();	
		}
		else if(_id == CardIdentifier.BATTLE_SISTER__ECLAIR)
		{
			BattleSisterEclair_Update();	
		}
		else if(_id == CardIdentifier.DARK_KNIGHT_OF_NIGHTMARELAND)
		{
			DarkKnightofNightmareland_Update();	
		}
		else if(_id == CardIdentifier.DOCTROID_MEGALOS)
		{
			DoctroidMegalos_Update();	
		}
		else if(_id == CardIdentifier.SEE_SAW_GAME_LOSER)
		{
			SeesawGameLoser_Update();	
		}
		else if(_id == CardIdentifier.DISCIPLE_OF_PAIN)
		{
			DiscipleofPain_Update();	
		}
		else if(_id == CardIdentifier.DOCTROID_MICROS)
		{
			DoctroidMicros_Update();	
		}
		else if(_id == CardIdentifier.MASTER_OF_PAIN)
		{
			MasterofPain_Update();	
		}
		else if(_id == CardIdentifier.BEAUTIFUL_HARPUIA)
		{
			BeautifulHarpuia_Update();	
		}
		else if(_id == CardIdentifier.BEAST_IN_HAND)
		{
			BeastinHand_Update();	
		}
		else if(_id == CardIdentifier.SEE_SAW_GAME_WINNER)
		{
			SeesawGameWinner_Update();	
		}
		else if(_id == CardIdentifier.RULER_CHAMELEON)
		{
			RulerChameleon_Update();	
		}
		else if(_id == CardIdentifier.SCHOOLYARD_PRODIGY__LOX)
		{
			SchoolyardProdigyLox_Update();	
		}
		else if(_id == CardIdentifier.ACORN_MASTER)
		{
			AcornMaster_Update();	
		}
		else if(_id == CardIdentifier.HULA_HOOP_CAPYBARA)
		{
			HulaHoopCapybara_Update();	
		}
		else if(_id == CardIdentifier.FEATHER_PENGUIN)
		{
			FeatherPenguin_Update();	
		}
		else if(_id == CardIdentifier.FAILURE_SCIENTIST__PONKICHI)
		{
			FailureScientistPonkichi_Update();	
		}
		else if(_id == CardIdentifier.ELEMENT_GLIDER)
		{
			ElementGlider_Update();	
		}
		else if(_id == CardIdentifier.TICK_TOCK_FLAMINGO)
		{
			TickTockFlamingo_Update();	
		}
		else if(_id == CardIdentifier.THUMBTACK_FIGHTER__RESANORI)
		{
			ThumbtackFighterResanori_Update();	
		}
		else if(_id == CardIdentifier.EXPLOSION_SCIENTIST__BUNTA)
		{
			ExplosionScientistBunta_Update();	
		}
		else if(_id == CardIdentifier.PENCIL_KNIGHT__HAMMSUKE)
		{
			PencilKnightHammsuke_Update();	
		}
		else if(_id == CardIdentifier.SPRING_BREEZE_MESSENGER)
		{
			SpringBreezeMessenger_Update();	
		}
		else if(_id == CardIdentifier.LOP_EAR_SHOOTER)
		{
			LopEarShooter_Update();	
		}
		else if(_id == CardIdentifier.PHOTON_ARCHER__GRIFLET)
		{
			PhotonArcherGriflet_Update();	
		}
		else if(_id == CardIdentifier.LITTLE_WITCH__LULU)
		{
			LittleWitchLuLu_Update();	
		}
		else if(_id == CardIdentifier.COURTING_SUCCUBUS)
		{
			CourtingSuccubus_Update();	
		}
		else if(_id == CardIdentifier.FREE_TRAVELER)
		{
			FreeTraveler_Update();	
		}
		else if(_id == CardIdentifier.PURPLE_TRAPEZIST)
		{
			PurpleTrapezist_Update();	
		}
		else if(_id == CardIdentifier.BULL_____S_EYE__MIA)
		{
			BullsEyeMia_Update();
		}
		else if(_id == CardIdentifier.FLASK_MARMOSET)
		{
			FlaskMarmoset_Update();	
		}
		else if(_id == CardIdentifier.TANK_MOUSE)
		{
			TankMouse_Update();	
		}
		else if(_id == CardIdentifier.PENCIL_SQUIRE__HAMMSUKE)
		{
			PencilSquireHammsuke_Update();	
		}
		else if(_id == CardIdentifier.PENCIL_HERO__HAMMSUKE)
		{
			PencilHeroHammsuke_Update();	
		}
		else if(_id == CardIdentifier.LISTENER_OF_TRUTH__DINDRANE)
		{
			ListenerofTruthDindrane_Update();	
		}
		else if(_id == CardIdentifier.YELLOW_BOLT)
		{
			YellowBolt_Update();	
		}
		else if(_id == CardIdentifier.EMBLEM_MASTER)
		{
			EmblemMaster_Update();	
		}
		else if(_id == CardIdentifier.MAGICIAN_OF_QUANTUM_MECHANICS)
		{
			MagicianofQuantumMechanics_Update();	
		}
		else if(_id == CardIdentifier.PEEK_A_BOO)
		{
			Peekaboo_Update();
		}	
		else if(_id == CardIdentifier.FIRE_BREEZE__CARRIE)
		{
			FireBreezeCarrie_Update();	
		}
		else if(_id == CardIdentifier.SWORD_MAGICIAN__SARAH)
		{
			SwordMagicianSarah_Update();	
		}
		else if(_id == CardIdentifier.MONOCULUS_TIGER)
		{
			MonoculusTiger_Update();	
		}
		else if(_id == CardIdentifier.LAMP_CAMEL)
		{
			LampCamel_Update();	
		}
		else if(_id == CardIdentifier.SCHOOL_DOMINATOR__APT)
		{
			SchoolDominatorApt_Update();	
		}
		else if(_id == CardIdentifier.WHITE_HARE_IN_THE_MOON_____S_SHADOW__PELLINORE)
		{
			WhiteHareintheMoonShadowPellinore_Update();	
		}
		else if(_id == CardIdentifier.EMERALD_WITCH__LALA)
		{
			EmeraldWitchLaLa_Update();
		}	
		else if(_id == CardIdentifier.SILVER_THORN_DRAGON_TAMER__LUQUIER)
		{
			SilverThornDragonTamerLuquier_Update();	
		}
		else if(_id == CardIdentifier.BINOCULUS_TIGER)
		{
			BinoculusTiger_Update();	
		}
		else if(_id == CardIdentifier.SCHOOL_HUNTER__LEO_PALD)
		{
			SchoolHunterLeopald_Update();	
		}
		else if(_id == CardIdentifier.PLASMABITE_DRAGON)
		{
			PlasmabiteDragon_Update();	
		}
		else if(_id == CardIdentifier.LIZARD_SOLDIER__RIKI)
		{
			LizardSoldierRiki_Update();	
		}
		else if(_id == CardIdentifier.DRAGON_DANCER__RAIRAI)
		{
			DragonDancerRaiRai_Update();	
		}
		else if(_id == CardIdentifier.THUNDER_BREAK_DRAGON)
		{
			ThunderBreakDragon_Update();	
		}
		else if(_id == CardIdentifier.WYVERN_SUPPLY_UNIT)
		{
			WyvernSupplyUnit_Update();	
		}
		else if(_id == CardIdentifier.SILVER_FANG_WITCH)
		{
			SilverFangWitch_Update();	
		}
		else if(_id == CardIdentifier.BLESSING_OWL)
		{
			BlessingOwl_Update();	
		}
		else if(_id == CardIdentifier.CHARJGAL)
		{
			Charjgal_Update();	
		}
		else if(_id == CardIdentifier.EVIL_SLAYING_SWORDSMAN__HAUGAN)
		{
			EvilSlayingSwordsmanHaugan_Update();	
		}
		else if(_id == CardIdentifier.BATTLEFIELD_STORM__SAGRAMORE)
		{
			BattlefieldStormSagramore_Update();	
		}
		else if(_id == CardIdentifier.SLEYGAL_SWORD)
		{
			SleygalSword_Update();	
		}
		else if(_id == CardIdentifier.SLEYGAL_DOUBLE_EDGE)
		{
			SleygalDoubleEdge_Update();	
		}
		else if(_id == CardIdentifier.MUSCLE_HERCULES)
		{
			MuscleHercules_Update();	
		}
		else if(_id == CardIdentifier.TURBORAIZER)
		{
			Turboraizer_Update();	
		}
		else if(_id == CardIdentifier.RISING_PHOENIX)
		{
			RisingPhoenix_Update();	
		}
		else if(_id == CardIdentifier.BATTLE_FLAG_KNIGHT__LAUDINE)
		{	
			BattleFlagKnightLaudine_Update();
		}
		else if(_id == CardIdentifier.ALMIGHTY_REPORTER)
		{
			AlmightyReporter_Update();	
		}
		else if(_id == CardIdentifier.MARVELOUS_HANI)
		{
			MarvelousHani_Update();	
		}
		else if(_id == CardIdentifier.BEAST_DEITY__SCARLET_BIRD)
		{
			BeasBeastDeityScarletBird_Update();
		}
		else if(_id == CardIdentifier.BEAST_DEITY__BLACK_TORTOISE)
		{
			BeastDeityBlackTortoise_Update();	
		}
		else if(_id == CardIdentifier.MALEVOLENT_DJINN)
		{
			MalevolentDjinn_Update();	
		}
		else if(_id == CardIdentifier.LIZARD_SOLDIER__YOWSH)
		{
			LizardSoldierYowsh_Update();	
		}
		else if(_id == CardIdentifier.SPARK_KID_DRAGOON)
		{
			SparkKidDragoon_Update();	
		}
		else if(_id == CardIdentifier.STEALTH_FIGHTER)
		{
			StealthFighter_Update();
		}	
		else if(_id == CardIdentifier.DRAGON_MONK__ENSEI)
		{
			DragonMonkEnsei_Update();	
		}
		else if(_id == CardIdentifier.FLAME_OF_VICTORY)
		{
			FlameofVictory_Update();	
		}
		else if(_id == CardIdentifier.LITTLE_FIGHTER__CRON)
		{
			LittleFighterCron_Update();	
		}
		else if(_id == CardIdentifier.WAVING_OWL)
		{
			WavingOwl_Update();	
		}
		else if(_id == CardIdentifier.PROVIDENCE_STRATEGIST)
		{
			ProvidenceStrategist_Update();	
		}
		else if(_id == CardIdentifier.SACRED_GUARDIAN_BEAST__ELEPHAS)
		{
			SacredGuardianBeastElephas_Update();	
		}
		else if(_id == CardIdentifier.HADES_STEERSMAN)
		{
			HadesSteersman_Update();	
		}
		else if(_id == CardIdentifier.SKELETON_ASSAULT_TROOPS_CAPTAIN)
		{
			SkeletonAssaultTroopsCaptain_Update();	
		}
		else if(_id == CardIdentifier.CAPTAIN_NIGHTKID)
		{
			CaptainNightkid_Update();	
		}
		else if(_id == CardIdentifier.UNDEAD_PIRATE_OF_THE_CURSED_RIFLE)
		{
			PirateoftheCursedRifle_Update();	
		}
		else if(_id == CardIdentifier.DRAGON_SPIRIT)
		{
			DragonSpirit_Update();	
		}
		else if(_id == CardIdentifier.RIPPLE_BANSHEE)
		{
			RippleBanshee_Update();	
		}
		else if(_id == CardIdentifier.JOHN_THE_GHOSTIE)
		{
			JohntheGhostie_Update();	
		}
		else if(_id == CardIdentifier.CHILD_FRANK)
		{
			ChildFrank_Update();	
		}
		else if(_id == CardIdentifier.SEA_NAVIGATOR__SILVER)
		{
			SeaNavigatorSilver_Update();
		}	
		else if(_id == CardIdentifier.SKELETON_COLOSSUS)
		{
			SkeletonColossus_Update();	
		}
		else if(_id == CardIdentifier.SUNNY_SMILE_ANGEL)
		{
			SunnySmileAngel_Update();	
		}
		else if(_id == CardIdentifier.HAPPY_BELL__NOCIEL)
		{
			HappyBellNociel_Update();	
		}
		else if(_id == CardIdentifier.CRITICAL_HIT_ANGEL)
		{
			CriticalHitAngel_Update();	
		}
		else if(_id == CardIdentifier.CARRIER_OF_THE_LIFE_WATER)
		{
			CarrieroftheLifeWater_Update();	
		}
		else if(_id == CardIdentifier.THERMOMETER_ANGEL)
		{
			ThermometerAngel_Update();	
		}
		else if(_id == CardIdentifier.LIGHTNING_CHARGER)
		{
			LightningCharger_Update();	
		}
		else if(_id == CardIdentifier.LANCET_SHOOTER)
		{
			LancetShooter_Update();	
		}
		else if(_id == CardIdentifier.LIZARD_SOLDIER__SAISHIN)
		{
			LizardSoldierSaishin_Update();	
		}
		else if(_id == CardIdentifier.DEMONIC_DRAGON_BERSERKER__GARUDA)
		{
			DemonicDragonBerserkerGaruda_Update();	
		}
		else if(_id == CardIdentifier.DESERT_GUNNER__RAIEN)
		{
			DesertGunnerRaien_Update();	
		}
		else if(_id == CardIdentifier.RIOT_GENERAL__GYRAS)
		{
			RiotGeneralGyras_Update();	
		}
		else if(_id == CardIdentifier.PLAYER_OF_THE_HOLY_AXE__NIMUE)
		{
			PlayeroftheHolyAxeNimue_Update();	
		}
		else if(_id == CardIdentifier.MAGE_OF_CALAMITY__TRIPP)
		{
			MageofCalamityTripp_Update();
		}
		else if(_id == CardIdentifier.DEADLY_NIGHTMARE)
		{
			DeadlyNightmare_Update();	
		}
		else if(_id == CardIdentifier.CRIMSON_LION_CUB__KYRPH)
		{
			CrimsonLionCubKyrph_Update();	
		}
		else if(id == CardIdentifier.THREE_STAR_CHEF__PIETRO)
		{
			ThreeStarChefPietro_Update();
		}	
		else if(_id == CardIdentifier.DEADLY_SPIRIT)
		{
			DeadlySpirit_Update();
		}	
		else if(_id == CardIdentifier.SKELETON_DEMON_WORLD_KNIGHT)
		{
			SkeletonDemonWorldKnight_Update();
		}	
		else if(_id == CardIdentifier.MIRACLE_FEATHER_NURSE)
		{
			MiracleFeatherNurse_Update();	
		}
		else if(_id == CardIdentifier.MOBILE_HOSPITAL__FEATHER_PALACE)
		{
			MobileHospitalFeatherPalace_Update();	
		}
		else if(_id == CardIdentifier.DEATH_SEEKER__THANATOS)
		{
			DeathSeekerThanatos_Update();	
		}
		else if(_id == CardIdentifier.DRAGONIC_DEATHSCYTHE)
		{
			DragonicDeathscythe_Update();	
		}
		else if(_id == CardIdentifier.VAJRA_EMPEROR__INDRA)
		{
			VajraEmperorIndra_Update();
		}		
		else if(_id == CardIdentifier.LOVE_MACHINE_GUN__NOCIEL)
		{
			LoveMachineGunNociel_Update();	
		}
		else if(_id == CardIdentifier.ORACLE_GUARDIAN_APOLLON)
		{
			OracleGuardinApollon_Update();	
		}
		else if(_id == CardIdentifier.CORE_MEMORY__ARMAROS)
		{
			CoreMemoryArmaros_Update();	
		}	
		else if(_id == CardIdentifier.DESERT_GUNNER__SHIDEN)
		{
			DesertGunnerShiden_Update();	
		}
		else if(_id == CardIdentifier.PLAYER_OF_THE_HOLY_BOW__VIVIANE)
		{
			PlayeroftheHolyBowViviane_Update();	
		}
		else if(_id == CardIdentifier.ICE_PRISON_NECROMANCER__COCYTUS)
		{
			IcePrisonNecromancerCocytus_Update();	
		}
		else if(_id == CardIdentifier.BATTLE_CUPID__NOCIEL)
		{
			BattleCupidNociel_Update();	
		}
		else if(_id == CardIdentifier.CIRCULAR_SAW__KIRIEL)
		{
			CircularSawKiriel_Update();	
		}
		else if(_id == CardIdentifier.MADCAP_MARIONETTE)
		{
			MadcapMarionette_Update();	
		}
		else if(_id ==CardIdentifier.DARK_SOUL_CONDUCTOR)
		{
			DarkSoulConductor_Update();
		}	
		else if(_id ==CardIdentifier.BIG_LEAGUE_BEAR)
		{
			BigLeagueBear_Update();	
		}
		else if(_id == CardIdentifier.SKYHIGH_WALKER)
		{
			SkyhighWalker_Update();	
		}
		else if(_id == CardIdentifier.CONJURER_OF_MITHRIL)
		{
			ConjurerofMithril_Update();
		}	
		else if(_id ==CardIdentifier.HYSTERIC_SHIRLEY)
		{
			HystericShirley_Update();	
		}
		else if(_id == CardIdentifier.ANTHRODROID)
		{
			Anthrodroid_Update();	
		}
		else if(_id == CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAILADY)
		{
			SuperDimensionalRoboDailady_Update();	
		}
		else if(_id == CardIdentifier.GUIDE_DOLPHIN)
		{
			GuideDolphin_Update();
		}	
		else if(_id == CardIdentifier.STEALTH_FIEND__DART_SPIDER)
		{
			StealthFiendDartSpider_Update();	
		}
		else if(_id == CardIdentifier.DOOM_BRINGER_GRIFFIN)
		{
			DoomBringerGriffin_Update();	
		}
		else if(_id == CardIdentifier.WHITE_HARE_OF_INABA)
		{
			WhiteHareofInaba_Update();	
		}
		else if(_id == CardIdentifier.POWERFUL_SAGE__BAIRON)
		{
			PowerfulSageBairon_Update();
		}
		else if(_id == CardIdentifier.NIGHTMARE_PAINTER)
		{
			NightmarePainter_Update();		
		}
		else if(_id == CardIdentifier.DREAM_PAINTER)
		{
			DreamPainter_Update();	
		}
		else if(_id == CardIdentifier.SILENT_SAGE__SHARON)
		{
			SilentSageSharon_Update();	
		}
		else if(_id == CardIdentifier.PHANTOM_BRINGER_DEMON)
		{
			PhantomBringerDemon_Update();	
		}
		else if(_id == CardIdentifier.WATERING_ELF)
		{
			WateringElf_Update();	
		}
		else if(_id == CardIdentifier.BLADE_SEED_SQUIRE)
		{
			BladeSeedSquire_Update();	
		}
		else if(_id == CardIdentifier.KNIGHT_OF_VERDURE__GENE)
		{
			KnightofVerdureGene_Update();	
		}
		else if(_id == CardIdentifier.SPIRITUAL_TREE_SAGE__IRMINSUL)
		{
			SpiritualTreeSageIrminsul_Update();	
		}
		else if(_id == CardIdentifier.APOCALYPSE_BAT)
		{
			ApocalypseBat_Update();	
		}
		else if(_id == CardIdentifier.FLAME_OF_PROMISE__AERMO)
		{
			FlameofPromiseAermo_Update();	
		}
		else if(_id == CardIdentifier.STEALTH_BEAST__EVIL_FERRET)
		{
			StealthBeastEvilFerret_Update();
		}
		else if(_id == CardIdentifier.STEALTH_BEAST__MILLION_RAT)
		{	
			StealthBeastMillionRat_Update();
		}
		else if(_id == CardIdentifier.KNIGHT_OF_PURGATORY__SKULL_FACE)
		{
			KnightofPurgatorySkullFace_FreeUpdate();	
		}
		else if(_id == CardIdentifier.STEALTH_DRAGON__TURBULENT_EDGE)
		{
			StealthDragonTurbulentEdge_Update();	
		}
		else if(_id == CardIdentifier.STEALTH_DRAGON__CURSED_BREATH)
		{
			StealthDragonCursedBreath_Update();	
		}
		else if(_id == CardIdentifier.STEALTH_DRAGON__VOIDGELGA)
		{
			StealthDragonVoidgelga_Update();	
		}
		else if(_id == CardIdentifier.SHIELD_SEED_SQUIRE)
		{
			ShieldSeedSquire_Update();	
		}
		else if(_id == CardIdentifier.STEALTH_FIEND__KURAMA_LORD)
		{
			StealthFiendKuramaLord_FreeUpdate();	
		}
		else if(_id == CardIdentifier.CAPED_STEALTH_ROGUE__SHANAOU)
		{
			CapedStealthRogueShanaou_Update();		
		}
		else if(_id == CardIdentifier.KNIGHT_OF_HARVEST__GENE)
		{
			KnightofHarvestGene_Update();	
		}
		else if(_id == CardIdentifier.EVIL_EYE_PRINCESS__EURYALE)
		{
			EvileyePrincessEuryale_Update();	
		}
		else if(_id == CardIdentifier.AVATAR_OF_THE_PLAINS__BEHEMOTH)
		{
			AvatarofthePlainsBehemoth_Update();	
		}
		else if(_id == CardIdentifier.WINGAL_BRAVE)
		{
			WingalBrave_Update();	
		}
		else if(_id == CardIdentifier.STREET_BOUNCER)
		{
			StreetBouncer_Update();	
		}
		else if(_id == CardIdentifier.STEALTH_FIEND__MIDNIGHT_CROW)
		{
			StealthFiendMidnightCrow_Update();	
		}
		else if(_id == CardIdentifier.MOONLIGHT_WITCH__VAHA)
		{
			MoonlightWitchVaha_Update();	
		}
		else if(_id == CardIdentifier.GLASS_BEADS_DRAGON)
		{
			GlassBeadsDragon_Update();	
		}
		else if(_id == CardIdentifier.STAR_CALL_TRUMPETER)
		{
			StarCallTrumpeter_Update();	
		}
		else if(_id == CardIdentifier.DARK_CAT)
		{
			DarkCat_Update();	
		}
		else if(_id == CardIdentifier.METEOR_BREAK_WIZARD)
		{
			MeteorBreakWizard_Update();	
		}
		else if(_id == CardIdentifier.MEGACOLONY_BATTLER_B)
		{
			MegacolonyBattlerB_Update();	
		}
		else if(_id == CardIdentifier.TOOLKIT_BOY)
		{
			ToolkitBoy_Update();	
		}
		else if(_id == CardIdentifier.CURSED_LANCER)
		{
			CursedLancer_Update();	
		}
		else if(_id == CardIdentifier.FLAME_SEED_SALAMANDER)
		{
			FlameSeedSalamander_Update();	
		}
		else if(_id == CardIdentifier.GRAPPLE_MANIA)
		{
			GrappleMania_Update();	
		}
		else if(_id == CardIdentifier.GARNET_DRAGON__FLASH)
		{	
			GarnetDragonFlash_Update();
		}
		else if(_id == CardIdentifier.ENIGMAN_SHINE)
		{
			EnigmanShine_Update();	
		}
		else if(_id == CardIdentifier.WITCH_OF_NOSTRUM__ARIANRHOD)
		{
			Arianrhod_Update();	
		}
		else if(_id == CardIdentifier.BEAST_KNIGHT__GARMORE)
		{
			BeastKnightGarmore_Update();	
		}
		else if(id == CardIdentifier.ARMORED_FAIRY__SHUBIELA)
		{	
			ArmoredFairyShubiela_Update();
		}
		else if(_id == CardIdentifier.GLOOM_FLYMAN)
		{
			GloomFlyman_Update();	
		}
		else if(_id == CardIdentifier.WATER_GANG)
		{	
			WaterGang_Update();
		}
		else if(_id == CardIdentifier.BLAUJUNGER)
		{
			Blaujunger_Update();	
		}
		else if(_id == CardIdentifier.AMBER_DRAGON__DAWN)
		{
			AmberDragonDawn_Update();	
		}
		else if(_id == CardIdentifier.LARVA_MUTANT__GIRAFFA)
		{
			LarvaMutantGiraffa_Update();		
		}
		else if(_id == CardIdentifier.VIOLENT_VESPER)
		{
			ViolentVesper_Update();	
		}
		else if(_id == CardIdentifier.DEATH_WARDEN_ANT_LION)
		{
			DeathWardenAntLion_Update();	
		}
		else if(_id == CardIdentifier.ENIGMAN_FLOW)
		{
			EnigmanFlow_Update();	
		}
		else if(_id == CardIdentifier.COSMO_ROAR)
		{
			CosmoRoar_Update();	
		}
		else if(_id == CardIdentifier.ENIGMAN_RAIN)
		{	
			EnigmanRain_Update();
		}
		else if(_id == CardIdentifier.FULLBAU)
		{	
			Fullbau_Update();
		}
		else if(_id == CardIdentifier.DARK_MAGE__BADHABH_CAAR)
		{
			DarkMageBadhabhCaar_Update();	
		}
		else if(_id == CardIdentifier.SILVER_SPEAR_DEMON__GUSION)
		{
			SilverSpearDemonGusion_Update();	
		}
		else if(_id == CardIdentifier.COSMO_BEAK)
		{
			CosmoBeak_Update();	
		}
		else if(_id == CardIdentifier.HEATNAIL_SALAMANDER)
		{
			HeatnailSalamander_Update();	
		}
		else if(_id == CardIdentifier.SKULL_WITCH__NEMAIN)
		{
			SkullWitchNemain_Update();	
		}
		else if(_id == CardIdentifier.DARKNESS_MAIDEN__MACHA)
		{
			DarknessMaidenMacha_Update();	
		}
		else if(_id == CardIdentifier.BERMUDA_TRIANGLE_CADET__SHIZUKU)
		{
			BermudaTriangleCadetShizuku_Update();	
		}
		else if(_id == CardIdentifier.NAVY_DOLPHIN__AMUR)
		{
			NavyDolphinAmur_Update();	
		}
		else if(_id == CardIdentifier.MERMAID_IDOL__FELUCCA)
		{
			MermaidIdolFelucca_Update();	
		}
		else if(_id == CardIdentifier.INTELLI_IDOL__MELVILLE)
		{	
			IntelliidolMelville_Update();
		}
		else if(_id == CardIdentifier.PRISM_ON_THE_WATER__MYRTOA)
		{
			PrismontheWaterMyrtoa_Update();	
		}
		else if(_id == CardIdentifier.BERMUDA_TRIANGLE_CADET__RIVIERE)
		{
			BermudaTriangleCadetRiviere_Update();	
		}
		else if(_id == CardIdentifier.BERMUDA_TRIANGLE_CADET__WEDDELL)
		{
			BermudaTriangleCadetWeddell_Update();	
		}
		else if(_id == CardIdentifier.TURQUOISE_BLUE__TYRRHENIA)
		{
			TurquoiseBlueTyrrhenia_Update();	
		}
		else if(_id == CardIdentifier.SUPER_IDOL__CERAM)
		{
			SuperIdolCeram_Update();	
		}
		else if(_id == CardIdentifier.PEARL_SISTERS__PERLA)
		{
			PearlSistersPerla_Update();
		}
		else if(_id == CardIdentifier.BLOODY_CALF)
		{
			BloodyCalf_Update();	
		}
		else if(_id == CardIdentifier.GODDESS_OF_THE_CRESCENT_MOON__TSUKUYOMI)
		{
			GoddessoftheCrescentMoonTsukuyomi_Update();	
		}
		else if(_id == CardIdentifier.ORACLE_GUARDIAN__RED_EYE)
		{
			OracleGuardianRedEye_Update();	
		}
		else if(_id == CardIdentifier.FAITHFUL_ANGEL)
		{
			FaithfulAngel_Update();	
		}
		else if(_id == CardIdentifier.KNIGHT_OF_TRIBULATIONS__GALAHAD)
		{
			KnightofTribulationsGalahad_Update();	
		}
		else if(_id == CardIdentifier.KNIGHT_OF_QUESTS__GALAHAD)
		{
			KnightofQuestsGalahad_Update();	
		}
		else if(_id == CardIdentifier.BLACK_CANNON_TIGER)
		{
			BlackCannonTiger_Update();	
		}
		else if(_id == CardIdentifier.RAGING_DRAGON__SPARKSAURUS)
		{
			RagingDragonSparksaurus_Update();	
		}
		else if(_id == CardIdentifier.VACUUM_MAMMOTH)
		{
			VacuumMammoth_Update();	
		}
		else if(_id == CardIdentifier.RAINBOW_MAGICIAN)
		{
			RainbowMagician_Update();	
		}
		else if(_id == CardIdentifier.HUNGRY_CLOWN)
		{
			HungryClown_Update();	
		}
		else if(_id == CardIdentifier.DARK_QUEEN_OF_NIGHTMARELAND)
		{
			DarkQueenofNightmareland_Update();	
		}
		else if(_id == CardIdentifier.ELEPHANT_JUGGLER)
		{
			ElephantJuggler_Update();	
		}
		else if(_id == CardIdentifier.DECADENT_SUCCUBUS)
		{
			DecadentSuccubus_Update();	
		}
		else if(id == CardIdentifier.DEATH_ARMY_GUY)
		{
			DeathArmyGuy_Update();	
		}
		else if(_id == CardIdentifier.DEATH_ARMY_LADY)
		{
			DeathArmyLady_Update();	
		}
		else if(_id == CardIdentifier.GODHAWK__ICHIBYOSHI)
		{
			GodhawkIchibyoshi_Update();	
		}
		else if(_id == CardIdentifier.ORACLE_GUARDIAN__BLUE_EYE)
		{
			OracleGuardianBlueEye_Update();	
		}
		else if(id == CardIdentifier.DRANGAL)
		{
			Drangal_Update();	
		}
		else if(id == CardIdentifier.RAGING_DRAGON__BLASTSAURUS)
		{
			RagingDragonBlastsaurus_Update();	
		}
		else if(id == CardIdentifier.HADES_RINGMASTER)
		{
			HadesRingmaster_Update();	
		}
		else if(id == CardIdentifier.MIDNIGHT_BUNNY)
		{
			MidnightBunny_Update();	
		}
		else if(_id == CardIdentifier.SKULL_JUGGLER)
		{
			SkullJ_Update();	
		}
		else if(_id == CardIdentifier.ALLURING_SUCCUBUS)
		{
			Alluring_Update();	
		}
		else if(_id == CardIdentifier.VERMILLION_GATEKEEPER)
		{
			Vermillion_Update();	
		}
		else if(_id == CardIdentifier.IMPRISONED_FALLEN_ANGEL__SARAQAEL)
		{
			Saraqael_Update();
		}	
		else if(id == CardIdentifier.MIRROR_DEMON)
		{
			MirronDemon_Update();	
		}
		else if(_id == CardIdentifier.DUSK_ILLUSIONIST__ROBERT)
		{
			Robert_Update();	
		}
		else if(_id == CardIdentifier.GODDESS_OF_THE_HALF_MOON__TSUKUYOMI)
		{
			HalfMoon_Update();	
		}
		else if(_id == CardIdentifier.NIGHTMARE_DOLL__ALICE)
		{
			Alice_Update();	
		}
		else if(_id == CardIdentifier.STIL_VAMPIR)
		{
			StillVampir_Update();	
		}
		else if(_id == CardIdentifier.PROWLING_DRAGON__STRIKEN)
		{
			Striken_Update();	
		}
		else if(_id == CardIdentifier.LARK_PIGEON)
		{
			LarkPigeon_Update();	
		}
		else if(_id == CardIdentifier.STARTING_PRESENTER)
		{
			Presenter_Update();	
		}
		else if(_id == CardIdentifier.CAT_BUTLER)
		{
			CatButler_Update();	
		}
		else if(_id == CardIdentifier.NITRO_JUGGLER)
		{
			NitroJuggler_Update();	
		}
		else if(_id == CardIdentifier.SAGE_OF_GUIDANCE__ZENON)
		{
			Zenon_Update();	
		}
		else if(_id == CardIdentifier.SAVAGE_KING)
		{
			SavageKing_Update();	
		}
		else if(_id == CardIdentifier.MACHINING_STAG_BEETLE)
		{
			MachiningStagBeetle_Update();
		}
		else if(_id == CardIdentifier.EXCULPATE_THE_BLASTER)
		{
			ExculpateTheBlaster_Update();
		}
		else if(_id == CardIdentifier.GOLDEN_BEAST_TAMER)
		{
			GoldenBeastTamer_Update();	
		}
		else if(_id == CardIdentifier.ONE_WHO_GAZES_AT_THE_TRUTH)
		{
			OneWhoGazes_Update();	
		}
		else if(_id == CardIdentifier.CYCLONE_BLITZ)
		{
			CycloneBlitz_Update();	
		}
		else if(_id == CardIdentifier.MASTER_FRAUDE)
		{
			MasterFraudo_Update();	
		}
		else if(_id == CardIdentifier.DEVIL_SUMMONER)
		{	
			DevilSummoner_Update();
		}
		else if(_id == CardIdentifier.BERMUDA_TRIANGLE_CADET_CARAVEL)
		{
			Caravel_Update();	
		}
		else if(_id == CardIdentifier.DRAGON_EGG)
		{
			DragonEgg_Update();	
		}
		else if(_id == CardIdentifier.LUCK_BIRD)
		{
			LuckBird_Update();	
		}
		else if(_id == CardIdentifier.HIGH_DOG_BREEDER_AKANE)
		{
			BreederAkane_Update();	
		}
		else if(_id == CardIdentifier.PONGAL)
		{
			Pongal_Update();	
		}
		else if(_id == CardIdentifier.GIGANTECH_CHARGER)
		{
			GigantechCharger_Update();
		}
		else if(_id == CardIdentifier.CHAPPIE_THE_GHOSTIE)
		{
			ChappieTheGhostie_Update();	
		}
		else if(_id == CardIdentifier.DANCING_CUTLASS)
		{
			DancingCutlass_Update();	
		}
		else if(_id == CardIdentifier.DUDLEY_DAN)
		{
			DudleyDan_Update();	
		}
		else if(_id == CardIdentifier.UNITE_ATTACKER)
		{
			UnitAttacker_Update();	
		}
		else if(_id == CardIdentifier.TOP_IDOL_FLORES)
		{
			TopIdolFlores_Update();	
		}
		else if(_id == CardIdentifier.WITCH_DOCTOR_OF_THE_ABYSS_NEGROMARL)
		{
			Negromarl_Update();	
		}
		else if(_id == CardIdentifier.KING_OF_DEMONIC_SEAS_BASSKIRK)
		{
			Basskirk_FreeUpdate();	
		}
		else if(_id == CardIdentifier.GENERAL_SEIFRIED)
		{
			GeneralSeifried_Update();	
		}
		else if(_id == CardIdentifier.BLAZING_FLARE_DRAGON)
		{
			BlazingFlareDragon_Update();	
		}
		else if(_id == CardIdentifier.SOUL_SAVER_DRAGON)
		{
			SoulSaverDragon_Update();	
		}
		else if(_id == CardIdentifier.RUIN_SHADE)
		{
			RuinShade_Update();	
		}
		else if(_id == CardIdentifier.GUIDING_ZOMBIE)
		{
			GuidingZombie_Update();
		}
		else if(_id == CardIdentifier.DEMON_EATER)
		{
			DemonEater_FreeUpdate();	
		}
		else if(_id == CardIdentifier.MR_INVINCIBLE)
		{
			MrInvincible_FreeUpdate();	
		}
		else if(id == CardIdentifier.BARCGAL)
		{
			Barcgal_Update();	
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT_ALEPH)
		{
			DragonKnightAleph_Update();	
		}
		else if(id == CardIdentifier.EMBODIMENT_OF_VICTORY_ALEPH)
		{
			EmbodimentVictoryAleph_Update();	
		}
		else if(id == CardIdentifier.LOZENGE_MAGUS)
		{
			LozengeMagus_Update();	
		}
		else if(id == CardIdentifier.DEMON_SLAYING_KNIGHT_LOHENGRIM)
		{
			Lohengrim_FreeUpdate();	
		}
		else if(id == CardIdentifier.FUTURE_KNIGHT_LLEW)
		{
			FutureKnightLlew_Update();	
		}
		else if(id == CardIdentifier.VORTEX_DRAGON)
		{
			VortexDragon_FreeUpdate();	
		}
		else if(id == CardIdentifier.LIZARD_SOLIDER_CONROE)
		{
			LizardSoldierConroe_Update();	
		}
		else if(_UnitObject != null)
		{
			_UnitObject.Update();	
		}
	}
	
	public bool CanRide()
	{
		CardIdentifier id = OwnerCard.cardID;
		
		if(id == CardIdentifier.EXCULPATE_THE_BLASTER)
		{
			return ExculpateTheBlaster_CanRide();
		}
		
		return true;
	}
	
	public bool CanAttack()
	{
		CardIdentifier id = OwnerCard.cardID;
		
		bool bReturn = true;
		
		if(id == CardIdentifier.EXCULPATE_THE_BLASTER)
		{
			bReturn = ExculpateTheBlaster_CanAttack();	
		}
		
		bool bLordCondition = true;
		
		if(OwnerCard.bLord)
		{
			Game.field.InitFieldIterator();
			while(Game.field.HasNextField())
			{
				Card c = Game.field.CurrentFieldCard();
				if(c != null && c.clan != OwnerCard.clan)
				{
					bLordCondition = false;
					break;
				}
			}
		}
		
		return bReturn && bLordCondition;
	}
	
	public bool HasSpecialAttackPattern()
	{
		CardIdentifier id = OwnerCard.cardID;
		
		if(id == CardIdentifier.EXCULPATE_THE_BLASTER)
		{
			return ExculpateTheBlaster_SpecialAttack();	
		}
		
		return false;
	}
	
	public void OnOpponentAccept()
	{
		CardIdentifier id = OwnerCard.cardID;
		
		if(id == CardIdentifier.DUELING_DRAGON__ZANBAKU)
		{
			Zanbaku_OnOpponentAccept();	
		}
		else if(id == CardIdentifier.PRISM_ON_THE_WATER__MYRTOA)
		{
			PrismontheWaterMyrtoa_OnAccept();	
		}
		else if(id == CardIdentifier.DARK_CAT)
		{
			DarkCat_OnAccept();	
		}
	}
	
	public void OnOpponentCancel()
	{
		CardIdentifier id = OwnerCard.cardID;
		
		if(id == CardIdentifier.DUELING_DRAGON__ZANBAKU)
		{
			Zanbaku_OnOpponentCancel();	
		}
		else if(id == CardIdentifier.PRISM_ON_THE_WATER__MYRTOA)
		{
			PrismontheWaterMyrtoa_OnCancel();	
		}
		else if(id == CardIdentifier.DARK_CAT)
		{
			DarkCat_OnCancel();	
		}
	}			
	
	bool OnCancel(Card c)
	{
		CardIdentifier id = c.cardID;
		
		if(id == CardIdentifier.PRISM_ON_THE_WATER__MYRTOA)
		{
			return PrismontheWaterMyrtoa_OnWindowCancel();
		}
		else if(id == CardIdentifier.TRI_STINGER_DRAGON) return TristingerDragon_Cancel();
		else if(id == CardIdentifier.OFFICER_CADET__ASTRAEA) return OfficerCadetAstraea_Cancel();
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_BODY_REPLACEMENT__KOKUENMARU) return StealthRogueofBodyReplacementKokuenmaru_Cancel();
		else if(id == CardIdentifier.DREAMING_SAGE__CORRON) return DreamingSageCorron_Cancel();
		else if(id == CardIdentifier.AQUA_BREATH_DRACOKID) return AquaBreathDracokid_Cancel();
		else if(id == CardIdentifier.EXORCIST_MAGE__KOH_KOH) return ExorcistMageKohKoh_Cancel();
		else if(id == CardIdentifier.OFFICER_CADET__ERIKK) return OfficerCadetErikk_Cancel();
		else if(id == CardIdentifier.BABY_PTERO) return BabyPtero_Cancel();
		else if(id == CardIdentifier.BROCCOLINI_MUSKETEER__KIRAH) return BroccoliniMusketeerKirah_Cancel();	
		else if(id == CardIdentifier.DARK_CAT)
		{
			return DarkCat_OnWindowCancel();	
		}
		else if(id == CardIdentifier.SCHOOL_HUNTER__LEO_PALD)
		{
			return SchoolHunterLeopald_OnWindowCancel();
		}
		else if(id == CardIdentifier.WHITE_HARE_IN_THE_MOON_____S_SHADOW__PELLINORE)
		{	
			return WhiteHareintheMoonShadowPellinore_OnCancel();
		}
		else if(id == CardIdentifier.LITTLE_WITCH__LULU)
		{
			return LittleWitchLuLu_OnCancel();	
		}
		else if(id == CardIdentifier.DESTRUCTION_DRAGON__DARK_REX)
		{
			return DestructionDragonDarkRex_Cancel();	
		}
		else if(_UnitObject != null)
		{
			return _UnitObject.Cancel();	
		}
		
		return false;
	}
	
	public void ActiveAbility(Card card, int idx, int idExtern = -1)
	{
		_Card = OwnerCard;
		CardIdentifier id = _Card.cardID;
		
		if(idExtern != -1)
		{
			ExternEffects[idExtern].Active(idx);
			return;
		}
		
		if(id == CardIdentifier.OFFICER_CADET__ASTRAEA) OfficerCadetAstraea_Active();
		else if(id == CardIdentifier.LIGHT_SIGNALS_PENGUIN_SOLDIER) LightSignalsPenguinSoldier_Active();
		else if(id == CardIdentifier.DECK_SWEEPER) DeckSweeper_Active();
		else if(id == CardIdentifier.STEALTH_BEAST__CAT_DEVIL) StealthBeastCatDevil_Active();
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_BODY_REPLACEMENT__KOKUENMARU) StealthRogueofBodyReplacementKokuenmaru_Active();
		else if(id == CardIdentifier.STEALTH_BEAST__FLAME_FOX) StealthBeastFlameFox_Active();
		else if(id == CardIdentifier.STEALTH_BEAST__NIGHT_PANTHER) StealthBeastNightPanther_Active();
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_SUMMONING__JIRAIYA) StealthRogueofSummoningJiraiya_Active();
		else if(id == CardIdentifier.STEALTH_BEAST__SPELL_HOUND) StealthBeastSpellHound_Active();
		else if(id == CardIdentifier.FIRE_JUGGLER) FireJuggler_Active();
		else if(id == CardIdentifier.BARKING_WYVERN) BarkingWyvern_Active();
		else if(id == CardIdentifier.DREAMING_SAGE__CORRON) DreamingSageCorron_Active();
		else if(id == CardIdentifier.ADVANCE_OF_THE_BLACK_CHAINS__KAHEDIN) AdvanceoftheBlackChainsKahedin_Active();
		else if(id == CardIdentifier.MOBILE_HOSPITAL__ELYSIUM) MobileHospitalElysium_Active();
		else if(id == CardIdentifier.BEAST_DEITY__BLANK_MARSH) BeastDeityBlankMarsh_Active();
		else if(id == CardIdentifier.TRI_HOLL_DRACOKID) TrihollDracokid_Active();
		else if(id == CardIdentifier.STORM_RIDER__NICOLAS) StormRiderNicolas_Active();
		else if(id == CardIdentifier.STORM_RIDER__DAMON)StormRiderDamon_Active();
		else if(id == CardIdentifier.STORM_RIDER__LYSANDER) StormRiderLysander_Active();
		else if(id == CardIdentifier.STEALTH_DRAGON__MAGATSU_WIND) StealthDragonMagatsuWind_Active();
		else if(id == CardIdentifier.STEALTH_FIEND__OBORO_CART)StealthFiendOboroCart_Active();
		else if(id == CardIdentifier.BLASTER_DARK_SPIRIT) BlasterDarkSpirit_Active();
		else if(id == CardIdentifier.BLASTER_BLADE_SPIRIT) BlasterBladeSpirit_Active();
		else if(id == CardIdentifier.NIGHTMARE_SUMMONER__RAQIEL) NightmareSummonerRaqiel_Active();
		else if(id == CardIdentifier.STARLIGHT_MELODY_TAMER__FARAH) StarlightMelodyTamerFarah_Active();
		else if(id == CardIdentifier.LORD_OF_THE_DEMONIC_WINDS__VAYU) LordoftheDemonicWindsVayu_Active();
		else if(id == CardIdentifier.BATTLER_OF_THE_TWIN_BRUSH__POLARIS) BattleroftheTwinBrushPolaris_Active();
		else if(id == CardIdentifier.BATTLE_SISTER__COOKIE) BattleSisterCookie_Active();
		else if(id == CardIdentifier.TRI_STINGER_DRAGON) TristingerDragon_Active();
		else if(id == CardIdentifier.PLATINUM_BLOND_FOX_SPIRIT__TAMAMO) PlatinumBlondFoxSpiritTamamo_Active();
		else if(id == CardIdentifier.FANTASY_PETAL_STORM__SHIRAYUKI) FantasyPetalStormShirayuki_Active();
		else if(id == CardIdentifier.CONVICTION_DRAGON__CHROMEJAILER_DRAGON) ConvictionDragonChromejailerDragon_Active(idx);
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM) CovertDemonicDragonMagatsuStorm_Active();
		else if(id == CardIdentifier.BATTLE_SIREN__CYNTHIA) BattleSirenCynthia_Active();
		else if(id == CardIdentifier.TEAR_KNIGHT__CYPRUS) TearKnightCyprus_Active();
		else if(id == CardIdentifier.KEY_ANCHOR__DABID) KeyAnchorDabid_Active();
		else if(id == CardIdentifier.NAVALGAZER_DRAGON) NavalgazerDragon_Active();
		else if(id == CardIdentifier.EXORCIST_MAGE__KOH_KOH) ExorcistMageKohKoh_Active();
		else if(id == CardIdentifier.DRAGON_MONK__GINKAKU) DragonMonkGinkaku_Active();
		else if(id == CardIdentifier.DRAGON_MONK__KINKAKU) DragonMonkKinkaku_Active();
		else if(id == CardIdentifier.OFFICER_CADET__ERIKK) OfficerCadetErikk_Active();
		else if(id == CardIdentifier.RELIABLE_STRATEGIC_COMMANDER) ReliableStrategicCommander_Active();
		else if(id == CardIdentifier.STREAM_TROOPER) StreamTrooper_Active();
		else if(id == CardIdentifier.VETERAN_STRATEGIC_COMMANDER) VeteranStrategicCommander_Active();
		else if(id == CardIdentifier.DISTANT_SEA_ADVISOR__VASSILIS) DistantSeaAdvisorVassilis_Active();
		else if(id == CardIdentifier.BABY_PTERO) BabyPtero_Active();
		else if(id == CardIdentifier.TRANSPORT_DRAGON__BRACHIOPORTER) TransportDragonBrachioporter_Active();
		else if(id == CardIdentifier.FORTRESS_AMMONITE) FortressAmmonite_Active();
		else if(id == CardIdentifier.SAVAGE_MAGUS) SavageMagus_Active();
		else if(id == CardIdentifier.CARRIER_DRAGON__BRACHIOCARRIER) CarrierDragonBrachiocarrier_Active();
		else if(id == CardIdentifier.SAVAGE_WARLOCK) SavageWarlock_Active();
		else if(id == CardIdentifier.CITADEL_DRAGON__BRACHIOCASTLE) CitadelDragonBrachiocastle_Active();
		else if(id == CardIdentifier.BROCCOLINI_MUSKETEER__KIRAH) BroccoliniMusketeerKirah_Active();
		else if(id == CardIdentifier.FRUITS_BASKET_ELF) FruitsBasketElf_Active();
		else if(id == CardIdentifier.BOON_BANA_NA) BoonBanana_Active();
		else if(id == CardIdentifier.TULIP_MUSKETEER__MINA) TulipMusketeerMina_Active();
		else if(id == CardIdentifier.TULIP_MUSKETEER__ALMIRA) TulipMusketeerAlmira_Active();
		else if(id == CardIdentifier.WORLD_SNAKE__OUROBOROS) WorldSnakeOuroboros_Active();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIBATTLES) DimensionalRoboDaibattles_Active();
		else if(id == CardIdentifier.FIGHTING_SAUCER) FightingSaucer_Active();
		else if(id == CardIdentifier.MYSTERIOUS_NAVY_ADMIRAL__GOGOTH) MysteriousNavyAdmiralGogoth_Active();
		else if(id == CardIdentifier.COSMIC_MOTHERSHIP) CosmicMothership_Active();
		else if(id == CardIdentifier.THUNDER_SPEAR_WIELDING_EXORCIST_KNIGHT) ThunderSpearWieldingExorcistKnight_Active();
		else if(id == CardIdentifier.AQUA_BREATH_DRACOKID) AquaBreathDracokid_Active();
		else if(id == CardIdentifier.MILITARY_DRAGON__RAPTOR_SOLDIER) MilitaryDragonRaptorSoldier_Active();
		else if(id == CardIdentifier.ARBOROS_DRAGON__RATOON) ArborosDragonRatoon_Active();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAILANDER) DimensionalRoboDailander_Active();
		else if(id == CardIdentifier.SUBTERRANEAN_BEAST__MAGMA_LORD) SubterraneanBeastMagmaLord_Active();
		else if(id == CardIdentifier.ARMED_INSTRUCTOR__BISON) ArmedInstructorBison_Active();
		else if(id == CardIdentifier.DESTRUCTION_DRAGON__DARK_REX) DestructionDragonDarkRex_Active();
		else if(id == CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__REBECCA) LilyoftheValleyMusketeerRebecca_Active();
		else if(id == CardIdentifier.HYDRO_HURRICANE_DRAGON) HydroHurricaneDragon_Active();
		else if(id == CardIdentifier.OPERATOR_GIRL__MIKA) OperatorGirlMika_Active();
		else if(id == CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__KAIVANT) LilyoftheValleyMusketeerKaivant_Active();
		else if(id == CardIdentifier.MAIDEN_OF_RAINBOW_WOOD) MaidenofRainbowWood_Active();
		else if(id == CardIdentifier.RUNE_WEAVER)
		{
			RuneWeaver_Active();	
		}
		else if(id == CardIdentifier.NIGHTMARE_DOLL__AMY)
		{
			NightmareDollAmy_Active();	
		}
		else if(id == CardIdentifier.GIRL_WHO_CROSSED_THE_GAP)
		{
			GirlWhoCrossedtheGap_Active();	
		}
		else if(id == CardIdentifier.HOPE_CHILD__TURIEL)
		{
			HopeChildTuriel_Active();	
		}
		else if(id == CardIdentifier.MIRAGE_MAKER)
		{
			MirageMaker_Active();	
		}
		else if(id == CardIdentifier.MOONSAULT_SWALLOW)
		{
			MoonsaultSwallow_Active();	
		}
		else if(id == CardIdentifier.DEVIL_IN_SHADOW)
		{
			DevilinShadow_Active();	
		}
		else if(id == CardIdentifier.PINKY_PIGGY)
		{
			PinkyPiggy_Active();	
		}
		else if(id == CardIdentifier.BATTLE_SISTER__ECLAIR)
		{
			BattleSisterEclair_Active();	
		}
		else if(id == CardIdentifier.INNOCENT_MAGICIAN)
		{
			InnocentMagician_Active();	
		}
		else if(id == CardIdentifier.DARK_KNIGHT_OF_NIGHTMARELAND)
		{
			DarkKnightofNightmareland_Active();	
		}
		else if(id == CardIdentifier.SEE_SAW_GAME_LOSER)
		{
			SeesawGameLosern_Active();	
		}
		else if(id == CardIdentifier.DISCIPLE_OF_PAIN)
		{
			DiscipleofPain_Active();	
		}
		else if(id == CardIdentifier.DOCTROID_MICROS)
		{
			DoctroidMicros_Active();	
		}
		else if(id == CardIdentifier.SEE_SAW_GAME_WINNER)
		{
			SeesawGameWinner_Active();	
		}
		else if(id == CardIdentifier.MASTER_OF_PAIN)
		{
			MasterofPain_Active();	
		}
		else if(id == CardIdentifier.DOCTROID_MEGALOS)
		{
			DoctroidMegalos_Active();
		}	
		else if(id == CardIdentifier.BEAUTIFUL_HARPUIA)
		{
			BeautifulHarpuia_Active();	
		}
		else if(id == CardIdentifier.BEAST_IN_HAND)
		{
			BeastinHand_Active();	
		}
		else if(id == CardIdentifier.RULER_CHAMELEON)
		{
			RulerChameleon_Active();	
		}
		else if(id == CardIdentifier.SCHOOLYARD_PRODIGY__LOX)
		{
			SchoolyardProdigyLox_Active();	
		}
		else if(id == CardIdentifier.HULA_HOOP_CAPYBARA)
		{
			HulaHoopCapybara_Active();	
		}
		else if(id == CardIdentifier.ACORN_MASTER)
		{
			AcornMaster_Active();	
		}
		else if(id == CardIdentifier.FEATHER_PENGUIN)
		{
			FeatherPenguin_Active();	
		}
		else if(id == CardIdentifier.FAILURE_SCIENTIST__PONKICHI)
		{
			FailureScientistPonkichi_Active();	
		}
		else if(id == CardIdentifier.ELEMENT_GLIDER)
		{
			ElementGlider_Active();	
		}
		else if(id == CardIdentifier.THUMBTACK_FIGHTER__RESANORI)
		{
			ThumbtackFighterResanori_Active();	
		}
		else if(id == CardIdentifier.EXPLOSION_SCIENTIST__BUNTA)
		{
			ExplosionScientistBunta_Active();	
		}
		else if(id == CardIdentifier.PENCIL_KNIGHT__HAMMSUKE)
		{
			PencilKnightHammsuke_Active();	
		}
		else if(id == CardIdentifier.SPRING_BREEZE_MESSENGER)
		{
			SpringBreezeMessenger_Active();	
		}
		else if(id == CardIdentifier.LOP_EAR_SHOOTER)
		{
			LopEarShooter_Active();	
		}
		else if(id == CardIdentifier.PHOTON_ARCHER__GRIFLET)
		{
			PhotonArcherGriflet_Active();	
		}
		else if(id == CardIdentifier.LITTLE_WITCH__LULU)
		{
			LittleWitchLuLu_Active();	
		}
		else if(id == CardIdentifier.COURTING_SUCCUBUS)
		{
			CourtingSuccubus_Active();	
		}
		else if(id == CardIdentifier.FREE_TRAVELER)
		{
			FreeTraveler_Active();	
		}
		else if(id == CardIdentifier.PURPLE_TRAPEZIST)
		{
			PurpleTrapezist_Active();	
		}
		else if(id == CardIdentifier.BULL_____S_EYE__MIA)
		{
			BullsEyeMia_Active();	
		}
		else if(id == CardIdentifier.FLASK_MARMOSET)
		{
			FlaskMarmoset_Active();	
		}
		else if(id == CardIdentifier.TANK_MOUSE)
		{
			TankMouse_Active();	
		}
		else if(id == CardIdentifier.PENCIL_SQUIRE__HAMMSUKE)
		{
			PencilSquireHammsuke_Active();	
		}
		else if(id == CardIdentifier.DUMBBELL_KANGAROO)
		{
			DumbbellKangaroo_Active();	
		}
		else if(id == CardIdentifier.PENCIL_HERO__HAMMSUKE)
		{
			PencilHeroHammsuke_Active();	
		}
		else if(id == CardIdentifier.LISTENER_OF_TRUTH__DINDRANE)
		{
			ListenerofTruthDindrane_Active();	
		}
		else if(id == CardIdentifier.YELLOW_BOLT)
		{
			YellowBolt_Active();	
		}
		else if(id == CardIdentifier.EMBLEM_MASTER)
		{
			EmblemMaster_Active();	
		}
		else if(id == CardIdentifier.MAGICIAN_OF_QUANTUM_MECHANICS)
		{
			MagicianofQuantumMechanics_Active();	
		}
		else if(id == CardIdentifier.PEEK_A_BOO)
		{
			Peekaboo_Active();
		}	
		else if(id == CardIdentifier.FIRE_BREEZE__CARRIE)
		{
			FireBreezeCarrie_Active();	
		}
		else if(id == CardIdentifier.SWORD_MAGICIAN__SARAH)
		{
			SwordMagicianSarah_Active();	
		}
		else if(id == CardIdentifier.MONOCULUS_TIGER)
		{
			MonoculusTiger_Active();	
		}
		else if(id == CardIdentifier.SCHOOL_DOMINATOR__APT)
		{
			SchoolDominatorApt_Active();	
		}
		else if(id == CardIdentifier.LAMP_CAMEL)
		{
			LampCamel_Active();	
		}
		else if(id == CardIdentifier.WHITE_HARE_IN_THE_MOON_____S_SHADOW__PELLINORE)
		{
			WhiteHareintheMoonShadowPellinore_Active();	
		}
		else if(id == CardIdentifier.EMERALD_WITCH__LALA)
		{
			EmeraldWitchLaLa_Active();	
		}
		else if(id == CardIdentifier.SILVER_THORN_DRAGON_TAMER__LUQUIER)
		{
			SilverThornDragonTamerLuquier_Active();	
		}
		else if(id == CardIdentifier.BINOCULUS_TIGER)
		{
			BinoculusTiger_Active();	
		}
		else if(id == CardIdentifier.SCHOOL_HUNTER__LEO_PALD)
		{
			SchoolHunterLeopald_Active();	
		}
		else if(id == CardIdentifier.PLASMABITE_DRAGON)
		{
			PlasmabiteDragon_Active();	
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__RIKI)
		{
			LizardSoldierRiki_Active();	
		}
		else if(id == CardIdentifier.LIGHTNING_OF_HOPE__HELENA)
		{
			LightningofHopeHelena_Active();	
		}
		else if(id == CardIdentifier.DRAGON_DANCER__RAIRAI)
		{
			DragonDancerRaiRai_Active();	
		}
		else if(id == CardIdentifier.THUNDER_BREAK_DRAGON)
		{
			ThunderBreakDragon_Active();	
		}
		else if(id == CardIdentifier.SILVER_FANG_WITCH)
		{
			SilverFangWitch_Active();	
		}
		else if(id == CardIdentifier.CHARJGAL)
		{
			Charjgal_Active();	
		}
		else if(id == CardIdentifier.SLEYGAL_SWORD)
		{
			SleygalSword_Active();	
		}
		else if(id == CardIdentifier.PRECIPICE_WHIRLWIND__SAGRAMORE)
		{
			PrecipiceWhirlwindSagramore_Active();	
		}
		else if(id == CardIdentifier.BATTLEFIELD_STORM__SAGRAMORE)
		{
			BattlefieldStormSagramore_Active();	
		}
		else if(id == CardIdentifier.EVIL_SLAYING_SWORDSMAN__HAUGAN)
		{
			EvilSlayingSwordsmanHaugan_Active();	
		}
		else if(id == CardIdentifier.SLEYGAL_DOUBLE_EDGE)
		{
			SleygalDoubleEdge_Active();	
		}
		else if(id == CardIdentifier.TURBORAIZER)
		{
			Turboraizer_Active();
		}
		else if(id == CardIdentifier.RISING_PHOENIX)
		{
			RisingPhoenix_Active();	
		}
		else if(id == CardIdentifier.MALEVOLENT_DJINN)
		{
			MalevolentDjinn_Active();	
		}
		else if(id == CardIdentifier.ALMIGHTY_REPORTER)
		{
			AlmightyReporter_Active();	
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__YOWSH)
		{
			LizardSoldierYowsh_Active();	
		}
		else if(id == CardIdentifier.STEALTH_FIGHTER)
		{
			StealthFighter_Active();	
		}
		else if(id == CardIdentifier.SPARK_KID_DRAGOON)
		{
			SparkKidDragoon_Active();	
		}
		else if(id == CardIdentifier.FLAME_OF_VICTORY)
		{
			FlameofVictory_Active();	
		}
		else if(id == CardIdentifier.WAVING_OWL)
		{
			WavingOwl_Active();	
		}
		else if(id == CardIdentifier.LITTLE_FIGHTER__CRON)
		{
			LittleFighterCron_Active();	
		}
		else if(id == CardIdentifier.SACRED_GUARDIAN_BEAST__ELEPHAS)
		{
			SacredGuardianBeastElephas_Active();	
		}
		else if(id == CardIdentifier.HADES_STEERSMAN)
		{
			HadesSteersman_Active();	
		}
		else if(id == CardIdentifier.SKELETON_ASSAULT_TROOPS_CAPTAIN)
		{
			SkeletonAssaultTroopsCaptain_Active();	
		}
		else if(id == CardIdentifier.CAPTAIN_NIGHTKID)
		{
			CaptainNightkid_Active();	
		}
		else if(id == CardIdentifier.UNDEAD_PIRATE_OF_THE_CURSED_RIFLE)
		{
			PirateoftheCursedRifle_Active();	
		}
		else if(id == CardIdentifier.DRAGON_SPIRIT)
		{
			DragonSpirit_Active();	
		}
		else if(id == CardIdentifier.RIPPLE_BANSHEE)
		{
			RippleBanshee_Active();	
		}
		else if(id == CardIdentifier.CHILD_FRANK)
		{
			ChildFrank_Active();	
		}
		else if(id == CardIdentifier.JOHN_THE_GHOSTIE)
		{
			JohntheGhostie_Active();	
		}
		else if(id == CardIdentifier.SUNNY_SMILE_ANGEL)
		{
			SunnySmileAngel_Active();	
		}
		else if(id == CardIdentifier.SKELETON_COLOSSUS)
		{
			SkeletonColossus_Active();	
		}
		else if(id == CardIdentifier.HAPPY_BELL__NOCIEL)
		{
			HappyBellNociel_Active();	
		}
		else if(id == CardIdentifier.CRITICAL_HIT_ANGEL)
		{
			CriticalHitAngel_Active();	
		}
		else if(id == CardIdentifier.CARRIER_OF_THE_LIFE_WATER)
		{
			CarrieroftheLifeWater_Active();
		}	
		else if(id == CardIdentifier.THERMOMETER_ANGEL)
		{
			ThermometerAngel_Active();	
		}
		else if(id == CardIdentifier.LIGHTNING_CHARGER)
		{
			LightningCharger_Active();	
		}
		else if(id == CardIdentifier.LANCET_SHOOTER)
		{
			LancetShooter_Active();
		}	
		else if(id == CardIdentifier.LIZARD_SOLDIER__SAISHIN)
		{
			LizardSoldierSaishin_Active();	
		}
		else if(id == CardIdentifier.RIOT_GENERAL__GYRAS)
		{
			RiotGeneralGyras_Active();	
		}
		else if(id == CardIdentifier.PLAYER_OF_THE_HOLY_AXE__NIMUE)
		{
			PlayeroftheHolyAxeNimue_Active();	
		}
		else if(id == CardIdentifier.DEADLY_NIGHTMARE)
		{
			DeadlyNightmare_Active();	
		}
		else if(id == CardIdentifier.CRIMSON_LION_CUB__KYRPH)
		{
			CrimsonLionCubKyrph_Active();
		}	
		else if(id == CardIdentifier.MIRACLE_FEATHER_NURSE)
		{
			MiracleFeatherNurse_Active();	
		}
		else if(id == CardIdentifier.DEADLY_SPIRIT)
		{
			DeadlySpirit_Active();	
		}
		else if(id == CardIdentifier.MOBILE_HOSPITAL__FEATHER_PALACE)
		{
			MobileHospitalFeatherPalace_Active();	
		}
		else if(id == CardIdentifier.SKELETON_DEMON_WORLD_KNIGHT)
		{
			SkeletonDemonWorldKnight_Active();	
		}
		else if(id == CardIdentifier.VAJRA_EMPEROR__INDRA)
		{
			VajraEmperorIndra_Active();	
		}
		else if(id == CardIdentifier.DRAGONIC_DEATHSCYTHE)
		{
			DragonicDeathscythe_Active();	
		}
		else if(id == CardIdentifier.DEATH_SEEKER__THANATOS)
		{
			DeathSeekerThanatos_Active();	
		}
		else if(id == CardIdentifier.LOVE_MACHINE_GUN__NOCIEL)
		{
			LoveMachineGunNociel_Active();	
		}
		else if(id == CardIdentifier.CORE_MEMORY__ARMAROS)
		{
			CoreMemoryArmaros_Active();	
		}
		else if(id == CardIdentifier.PLAYER_OF_THE_HOLY_BOW__VIVIANE)
		{
			PlayeroftheHolyBowViviane_Active();
		}	
		else if(id == CardIdentifier.ICE_PRISON_NECROMANCER__COCYTUS)
		{
			IcePrisonNecromancerCocytus_Active();	
		}
		else if(id == CardIdentifier.BATTLE_CUPID__NOCIEL)
		{
			BattleCupidNociel_Active();	
		}
		else if(id == CardIdentifier.CIRCULAR_SAW__KIRIEL)
		{
			CircularSawKiriel_Active();
		}	
		else if(id == CardIdentifier.GUIDE_DOLPHIN)
		{
			GuideDolphin_Active();	
		}
		else if(id ==CardIdentifier.DARK_SOUL_CONDUCTOR)
		{
			DarkSoulConductor_Active();	
		}
		else if(id ==CardIdentifier.BIG_LEAGUE_BEAR)
		{
			BigLeagueBear_Active();	
		}
		else if(id == CardIdentifier.MADCAP_MARIONETTE)
		{
			MadcapMarionette_Active();	
		}
		else if(id == CardIdentifier.HYSTERIC_SHIRLEY)
		{
			HystericShirley_Active();	
		}
		else if(id == CardIdentifier.SKYHIGH_WALKER)
		{
			SkyhighWalker_Active();	
		}
		else if(id == CardIdentifier.NIGHTMARE_PAINTER)
		{
			NightmarePainter_Active();
		}	
		else if(id == CardIdentifier.ANTHRODROID)
		{
			Anthrodroid_Active();	
		}
		else if(id == CardIdentifier.DOOM_BRINGER_GRIFFIN)
		{
			DoomBringerGriffin_Active();	
		}
		else if(id == CardIdentifier.WHITE_HARE_OF_INABA)
		{
			WhiteHareofInaba_Active();
		}	
		else if(id == CardIdentifier.DREAM_PAINTER)
		{
			DreamPainter_Active();	
		}
		else if(id == CardIdentifier.PHANTOM_BRINGER_DEMON)
		{
			PhantomBringerDemon_Active();	
		}
		else if(id == CardIdentifier.SILENT_SAGE__SHARON)
		{
			SilentSageSharon_Active();	
		}
		else if(id == CardIdentifier.STEALTH_FIEND__DART_SPIDER)
		{
			StealthFiendDartSpider_Active();	
		}
		else if(id == CardIdentifier.WATERING_ELF)
		{
			WateringElf_Active();	
		}
		else if(id == CardIdentifier.BLADE_SEED_SQUIRE)
		{
			BladeSeedSquire_Active();	
		}
		else if(id == CardIdentifier.LADY_OF_THE_SUNLIGHT_FOREST)
		{
			LadyoftheSunlightForest_Active();	
		}
		else if(id == CardIdentifier.CARAMEL_POPCORN)
		{
			CaramelPopcorn_Active();	
		}
		else if(id == CardIdentifier.KNIGHT_OF_VERDURE__GENE)
		{
			KnightofVerdureGene_Active();
		}	
		else if(id == CardIdentifier.APOCALYPSE_BAT)
		{
			ApocalypseBat_Active();	
		}
		else if(id == CardIdentifier.FLAME_OF_PROMISE__AERMO)
		{
			FlameofPromiseAermo_Active();	
		}
		else if(id == CardIdentifier.MAGICAL_POLICE__QUILT)
		{
			MagicalPoliceQuilt_Active();	
		}
		else if(id == CardIdentifier.STEALTH_BEAST__MILLION_RAT)
		{
			StealthBeastMillionRat_Active();	
		}
		else if(id == CardIdentifier.STEALTH_BEAST__EVIL_FERRET)
		{
			StealthBeastEvilFerret_Active();	
		}
		else if(id == CardIdentifier.KNIGHT_OF_PURGATORY__SKULL_FACE)
		{
			KnightofPurgatorySkullFace_Active();	
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__VOIDGELGA)
		{
			StealthDragonVoidgelga_Active();	
		}
		else if(id == CardIdentifier.SHIELD_SEED_SQUIRE)
		{
			ShieldSeedSquire_Active();	
		}
		else if(id == CardIdentifier.STEALTH_FIEND__KURAMA_LORD)
		{
			StealthFiendKuramaLord_Active();	
		}
		else if(id == CardIdentifier.CAPED_STEALTH_ROGUE__SHANAOU)
		{
			CapedStealthRogueShanaou_Active();	
		}
		else if(id == CardIdentifier.KNIGHT_OF_HARVEST__GENE)
		{
			KnightofHarvestGene_Active();	
		}
		else if(id == CardIdentifier.WINGAL_BRAVE)
		{
			WingalBrave_Active();	
		}
		else if(id == CardIdentifier.STEALTH_FIEND__MIDNIGHT_CROW)
		{
			StealthFiendMidnightCrow_Active();	
		}
		else if(id == CardIdentifier.AVATAR_OF_THE_PLAINS__BEHEMOTH)
		{
			AvatarofthePlainsBehemoth_Active();	
		}
		else if(id == CardIdentifier.STREET_BOUNCER)
		{
			StreetBouncer_Active();	
		}
		else if(id == CardIdentifier.MOONLIGHT_WITCH__VAHA)
		{
			MoonlightWitchVaha_Active();	
		}
		else if(id == CardIdentifier.GLASS_BEADS_DRAGON)
		{
			GlassBeadsDragon_Active();	
		}
		else if(id == CardIdentifier.STAR_CALL_TRUMPETER)
		{
			StarCallTrumpeter_Active();	
		}
		else if(id == CardIdentifier.DARK_CAT)
		{
			DarkCat_Active();
		}
		else if(id == CardIdentifier.METEOR_BREAK_WIZARD)
		{
			MeteorBreakWizard_Active();	
		}
		else if(id == CardIdentifier.MEGACOLONY_BATTLER_B)
		{
			MegacolonyBattlerB_Active();	
		}
		else if(id == CardIdentifier.GRAPPLE_MANIA)
		{
			GrappleMania_Active();	
		}
		else if(id == CardIdentifier.FLAME_SEED_SALAMANDER)
		{	
			FlameSeedSalamander_Active();
		}
		else if(id == CardIdentifier.WITCH_OF_NOSTRUM__ARIANRHOD)
		{
			Arianrhod_Active();	
		}
		else if(id == CardIdentifier.BEAST_KNIGHT__GARMORE)
		{
			BeastKnightGarmore_Active();	
		}
		else if(id == CardIdentifier.WATER_GANG)
		{
			WaterGang_Active();	
		}
		else if(id == CardIdentifier.DEATH_WARDEN_ANT_LION)
		{
			DeathWardenAntLion_Active();	
		}
		else if(id == CardIdentifier.COSMO_ROAR)
		{	
			CosmoRoar_Active();
		}
		else if(id == CardIdentifier.SILVER_SPEAR_DEMON__GUSION)
		{
			SilverSpearDemonGusion_Active();	
		}
		else if(id == CardIdentifier.HEATNAIL_SALAMANDER)
		{
			HeatnailSalamander_Active();	
		}
		else if(id == CardIdentifier.COSMO_BEAK)
		{
			CosmoBeak_Active();	
		}	
		else if(id == CardIdentifier.SKULL_WITCH__NEMAIN)
		{
			SkullWitchNemain_Active();	
		}
		else if(id == CardIdentifier.DARKNESS_MAIDEN__MACHA)
		{
			DarknessMaidenMacha_Active();	
		}
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__SHIZUKU)
		{
			BermudaTriangleCadetShizuku_Active();	
		}
		else if(id == CardIdentifier.MERMAID_IDOL__FELUCCA)
		{
			MermaidIdolFelucca_Active();	
		}
		else if(id == CardIdentifier.NAVY_DOLPHIN__AMUR)
		{
			NavyDolphinAmur_Active();	
		}
		else if(id == CardIdentifier.PRISM_ON_THE_WATER__MYRTOA)
		{
			PrismontheWaterMyrtoa_Active();	
		}
		else if(id == CardIdentifier.INTELLI_IDOL__MELVILLE)
		{
			IntelliidolMelville_Active();	
		}
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__RIVIERE)
		{
			BermudaTriangleCadetRiviere_Active();	
		}
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__WEDDELL)
		{
			BermudaTriangleCadetWeddell_Active();	
		}
		else if(id == CardIdentifier.TURQUOISE_BLUE__TYRRHENIA)
		{
			TurquoiseBlueTyrrhenia_Active();
		}	
		else if(id == CardIdentifier.SUPER_IDOL__CERAM)
		{
			SuperIdolCeram_Active();	
		}
		else if(id == CardIdentifier.PEARL_SISTERS__PERLA)
		{
			PearlSistersPerla_Active();	
		}
		else if(id == CardIdentifier.HUNGRY_CLOWN)
		{
			HungryClown_Active();
		}	
		else if(id == CardIdentifier.BLOODY_CALF)
		{
			BloodyCalf_Active();	
		}
		else if(id == CardIdentifier.FLAME_EDGE_DRAGON)
		{
			FlameEdgeDragon_Active();	
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN__RED_EYE)
		{
			OracleGuardianRedEye_Active();	
		}
		else if(id == CardIdentifier.SECRETARY_ANGEL)
		{
			SecretaryAngel_Active();	
		}
		else if(id == CardIdentifier.KNIGHT_OF_TRIBULATIONS__GALAHAD)
		{
			KnightofTribulationsGalahad_Active();
		}	
		else if(id == CardIdentifier.BLACK_CANNON_TIGER)
		{
			BlackCannonTiger_Active();	
		}
		else if(id == CardIdentifier.RAGING_DRAGON__SPARKSAURUS)
		{
			RagingDragonSparksaurus_Active();	
		}
		else if(id == CardIdentifier.VACUUM_MAMMOTH)
		{
			VacuumMammoth_Active();	
		}
		else if(id == CardIdentifier.RAINBOW_MAGICIAN)
		{
			RainbowMagician_Active();
		}
		else if(id == CardIdentifier.DARK_QUEEN_OF_NIGHTMARELAND)
		{
			DarkQueenofNightmareland_Active();	
		}
		else if(id == CardIdentifier.ELEPHANT_JUGGLER)
		{
			ElephantJuggler_Active();
		}
		else if(id == CardIdentifier.CANDY_CLOWN)
		{
			HungryClown_Active();	
		}
		else if(id == CardIdentifier.DECADENT_SUCCUBUS)
		{
			DecadentSuccubus_Active();	
		}
		else if(id == CardIdentifier.RAGING_DRAGON__BLASTSAURUS)
		{
			RagingDragonBlastsaurus_Active();	
		}
		else if(id == CardIdentifier.HADES_RINGMASTER)
		{
			HadesRingmaster_Active();	
		}
		else if(id == CardIdentifier.MIDNIGHT_BUNNY)
		{
			MidnightBunny_Active();	
		}
		else if(id == CardIdentifier.SKULL_JUGGLER)
		{
			SkullJ_Active();	
		}
		else if(id == CardIdentifier.ALLURING_SUCCUBUS)
		{
			Alluring_Active();	
		}
		else if(id == CardIdentifier.VERMILLION_GATEKEEPER)
		{
			Vermillion_Active();	
		}
		else if(id == CardIdentifier.IMPRISONED_FALLEN_ANGEL__SARAQAEL)
		{
			Saraqael_Active();	
		}
		else if(id == CardIdentifier.MIRROR_DEMON)
		{
			MirronDemon_Active();	
		}
		else if(id == CardIdentifier.DUSK_ILLUSIONIST__ROBERT)
		{
			Robert_Active();	
		}
		else if(id == CardIdentifier.GWYNN_THE_RIPPER)
		{
			Ripper_Active();	
		}
		else if(id == CardIdentifier.EDEL_ROSE)
		{
			EdelRose_Active();	
		}
		else if(id == CardIdentifier.ULTIMATE_LIFEFORM__COSMO_LORD)
		{
			Lifeform_Active();	
		}
		else if(id == CardIdentifier.GODDESS_OF_THE_HALF_MOON__TSUKUYOMI)
		{
			HalfMoon_Active();
		}
		else if(id == CardIdentifier.NIGHTMARE_DOLL__ALICE)
		{
			Alice_Active();	
		}
		else if(id == CardIdentifier.STIL_VAMPIR)
		{
			StillVampir_Active();
		}	
		else if(id == CardIdentifier.LARK_PIGEON)
		{
			LarkPigeon_Active();	
		}
		else if(id == CardIdentifier.STARTING_PRESENTER)
		{
			Presenter_Active();	
		}
		else if(id == CardIdentifier.NITRO_JUGGLER)
		{
			NitroJuggler_Active();	
		}
		else if(id == CardIdentifier.CAT_BUTLER)
		{
			CatButler_Active();	
		}
		else if(id == CardIdentifier.SAVAGE_KING)
		{
			SavageKing_Active();	
		}
		else if(id == CardIdentifier.GUARD_GRIFFIN)
		{
			Griffin_Active();	
		}
		else if(id == CardIdentifier.PROMISE_DAUGHTER)
		{
			Promise_Active();	
		}
		else if(id == CardIdentifier.ROCKET_HAMMER_MAN)
		{	
			RocketHammer_Active();
		}
		else if(id == CardIdentifier.EXCULPATE_THE_BLASTER)
		{
			ExculpateTheBlaster_Active();
		}
		else if(id == CardIdentifier.GOLDEN_BEAST_TAMER)
		{
			GoldenBeastTamer_Active();	
		}
		else if(_Card.cardID == CardIdentifier.EVIL_SHADE)
		{
			EvilShade_Active();	
		}
		else if(_Card.cardID == CardIdentifier.INTELLI_MOUSE)
		{
			IntelliMouse_Active();	
		}
		else if(_Card.cardID == CardIdentifier.LADY_BOMB)
		{
			LadyBomb_Active();	
		}
		else if(_Card.cardID == CardIdentifier.RED_LIGHTING)
		{
			RedLighting_Active();	
		}
		else if(_Card.cardID == CardIdentifier.CHAOS_DRAGON_DINOCHAOS)
		{
			ChaosDragon_Active();	
		}
		else if(_Card.cardID == CardIdentifier.PSYCHIC_BIRD)
		{
			PsychicBird_Active();	
		}
		else if(_Card.cardID == CardIdentifier.ONE_WHO_GAZES_AT_THE_TRUTH)
		{
			OneWhoGazes_Active();	
		}
		else if(_Card.cardID == CardIdentifier.GATTLING_CLAW_DRAGON)
		{
			ClawDragon_Active();	
		}
		else if(_Card.cardID == CardIdentifier.IRON_TAIL_DRAGON)
		{
			IronTailDragon_Active();
		}
		else if(_Card.cardID == CardIdentifier.MARGAL)
		{
			Margal_Active();	
		}
		else if(_Card.cardID == CardIdentifier.SOUL_GUIDING_ELF)
		{
			SoulGuidingElf_Active();
		}
		else if(_Card.cardID == CardIdentifier.ROUGH_SEAS_BANSHEE)
		{
			RoughSeas_Active();	
		}	
		else if(_Card.cardID == CardIdentifier.SILENCE_JOKER)
		{
			SilenceJoker_Active();	
		}
		else if(_Card.cardID == CardIdentifier.CYCLONE_BLITZ)
		{
			CycloneBlitz_Active();	
		}
		else if(_Card.cardID == CardIdentifier.SCIENTIST_MONKEY_RUE)
		{
			MonkeyRue_Active();	
		}
		else if(_Card.cardID == CardIdentifier.MASTER_FRAUDE)
		{
			MasterFraudo_Active();	
		}
		else if(_Card.cardID == CardIdentifier.BERMUDA_TRIANGLE_CADET_CARAVEL)
		{
			Caravel_Active();	
		}
		else if(_Card.cardID == CardIdentifier.DRAGON_EGG)
		{
			DragonEgg_Active();	
		}
		else if(_Card.cardID == CardIdentifier.WINGED_DRAGON_SKYPTERO)
		{
			WingedDragonSkyptero_Active();	
		}
		else if(_Card.cardID == CardIdentifier.LUCK_BIRD)
		{
			LuckBird_Active();	
		}
		else if(_Card.cardID == CardIdentifier.DEMONIC_DRAGON_MAGE_KIMNARA)
		{
			Kimnara_Active();	
		}
		else if(_Card.cardID == CardIdentifier.PONGAL)
		{
			Pongal_Active();	
		}
		else if(_Card.cardID == CardIdentifier.BLAZING_CORE_DRAGON)
		{
			BlazingCoreDragon_Active();	
		}
		else if(_Card.cardID == CardIdentifier.HIGH_DOG_BREEDER_AKANE)
		{
			BreederAkane_Active();	
		}
		else if(_Card.cardID == CardIdentifier.DANCING_CUTLASS)
		{
			DancingCutlass_Active();	
		}
		else if(_Card.cardID == CardIdentifier.DUDLEY_DAN)
		{
			DudleyDan_Active();	
		}
		else if(_Card.cardID == CardIdentifier.UNITE_ATTACKER)
		{
			UniteAttacker_Active();	
		}
		else if(_Card.cardID == CardIdentifier.TOP_IDOL_FLORES)
		{	
			TopIdolFlores_Active();	
		}
		else if(_Card.cardID == CardIdentifier.MAGICIAN_GIRL_KIRARA)
		{
			MagicianGirlKirara_Active();	
		}
		else if(_Card.cardID == CardIdentifier.WITCH_DOCTOR_OF_THE_ABYSS_NEGROMARL)
		{
			Negromarl_Active();	
		}
		else if(_Card.cardID == CardIdentifier.KING_OF_DEMONIC_SEAS_BASSKIRK)
		{
			Basskirk_Active();	
		}
		else if(_Card.cardID == CardIdentifier.GENERAL_SEIFRIED)
		{
			GeneralSeifried_Active();	
		}
		else if(_Card.cardID == CardIdentifier.LION_HEAT)
		{
			LionHeat_Active();	
		}
		else if(_Card.cardID == CardIdentifier.BLAZING_FLARE_DRAGON)
		{
			BlazingFlareDragon_Active();	
		}
		else if(_Card.cardID == CardIdentifier.SOUL_SAVER_DRAGON)
		{
			SoulSaverDragon_Active();	
		}
		else if(_Card.cardID == CardIdentifier.RUIN_SHADE)
		{
			RuinShade_Active();	
		}
		else if(_Card.cardID == CardIdentifier.SPIRIT_EXCEED)
		{
			SpiritExceed_Active();	
		}
		else if(_Card.cardID == CardIdentifier.GUIDING_ZOMBIE)
		{
			GuidingZombie_Active();	
		}
		else if(_Card.cardID == CardIdentifier.BLUE_DUST)
		{
			BlueDust_Active();	
		}
		else if(_Card.cardID == CardIdentifier.STEALTH_BEAST_HAGAKURE)
		{
			Hagakure_Active();	
		}
		else if(_Card.cardID == CardIdentifier.MONSTER_FRANK)
		{
			MonsterFrank_Active();	
		}
		else if(_Card.cardID == CardIdentifier.STEALTH_DRAGON_DREADMASTER)
		{
			StealthDragonDreadmaster_Active();	
		}
		else if(_Card.cardID == CardIdentifier.DEMON_EATER)
		{
			DemonEater_Active();	
		}
		else if(_Card.cardID == CardIdentifier.STEALTH_DRAGON_VOIDMASTER)
		{
			StealthDragonVoidmaster_Active();	
		}
		else if(_Card.cardID == CardIdentifier.ASSAULT_DRAGON_BLIGHTOPS)
		{
			AssaultDragonBlightops_Active();	
		}
		else if(_Card.cardID == CardIdentifier.SOLITARY_KNIGHT_GANCELOT)
		{
			GancelotActive();	
		}
		else if(_Card.cardID == CardIdentifier.DEMONIC_DRAGON_BERSERKER_YAKSHA)
		{
			DemonicDragonBerserkerYaksha_ActiveAbility();	
		}
		else if(_Card.cardID == CardIdentifier.WYVERN_STRIKE_TEJAS)
		{
			WyvernStrike_Active();	
		}
		else if(_Card.cardID == CardIdentifier.FLAME_OF_HOPE_AERMO)
		{
			FlameOfHopeAermo_Active();	
		}
		else if(_Card.cardID == CardIdentifier.GOLD_RUTILE)
		{
			GoldRutile_Active();	
		}
		else if(_Card.cardID == CardIdentifier.OASIS_GIRL)
		{
			OasisGirl_Active();	
		}
		else if(_Card.cardID == CardIdentifier.SCREAMIN_AND_DANCIN_ANNOUNCER_SHOUT)
		{
			ScreamingShout_Active();	
		}
		else if(_Card.cardID == CardIdentifier.BATTERING_MINOTAUR)
		{
			BatteringMinotaur_Active();	
		}
		else if(_Card.cardID == CardIdentifier.BATTLERAIZER)
		{
			Battleraizer_Active();	
		}
		else if(_Card.cardID == CardIdentifier.MR_INVINCIBLE)
		{
			MrInvincible_Active();	
		}
		else if(_Card.cardID == CardIdentifier.BARCGAL)
		{
			Barcgal_Active();	
		}
		else if(_Card.cardID == CardIdentifier.DRAGON_KNIGHT_ALEPH)
		{
			DragonKnightAleph_Active();	
		}
		else if(_Card.cardID == CardIdentifier.EMBODIMENT_OF_VICTORY_ALEPH)
		{
			EmbodimentVictoryAleph_Activate(idx);	
		}
		else if(_Card.cardID == CardIdentifier.ORACLE_GUARDIAN_APOLLON)
		{
			OracleGuardianApollon_Active();	
		}
		else if(_Card.cardID == CardIdentifier.MAIDEN_OF_LIBRA)
		{
			MaidenOfLibra_Active();	
		}
		else if(_Card.cardID == CardIdentifier.LOZENGE_MAGUS)
		{
			LozengeMagus_Active();	
		}
		else if(_Card.cardID == CardIdentifier.DEMON_SLAYING_KNIGHT_LOHENGRIM)
		{
			Lohengrim_Active();	
		}
		else if(_Card.cardID == CardIdentifier.FUTURE_KNIGHT_LLEW)
		{
			FutureKnightLlew_Active();	
		}
		else if(_Card.cardID == CardIdentifier.VORTEX_DRAGON)
		{
			VortexDragon_Active();	
		}
		else if(_Card.cardID == CardIdentifier.LIZARD_SOLIDER_CONROE)
		{
			LizardSoldierConroe_Active();	
		}
		else if(_Card.cardID == CardIdentifier.BRUTAL_JACK)
		{
			BrutalJack_Active();	
		}
		else if(_Card.cardID == CardIdentifier.KARMA_QUEEN)
		{
			KarmaQueen_Active();	
		}
		else if(_UnitObject != null)
		{
			_UnitObject.Active(idx);
		}
	}
	
	public void HandlePointerEvents()
	{		
		_Card = OwnerCard;
		
		CardIdentifier id = OwnerCard.cardID;
		
		for(int i = 0; i < ExternEffects.Count; i++)
		{
			ExternEffects[i].Pointer();	
		}
		
		if(id == CardIdentifier.OFFICER_CADET__ASTRAEA) OfficerCadetAstraea_Pointer();
		else if(id == CardIdentifier.STEALTH_BEAST__CAT_DEVIL) StealthBeastCatDevil_Pointer();
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_BODY_REPLACEMENT__KOKUENMARU) StealthRogueofBodyReplacementKokuenmaru_Pointer();
		else if(id == CardIdentifier.STEALTH_BEAST__NIGHT_PANTHER) StealthBeastNightPanther_Pointer();
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_SUMMONING__JIRAIYA) StealthRogueofSummoningJiraiya_Pointer();
		else if(id == CardIdentifier.STEALTH_BEAST__SPELL_HOUND) StealthBeastSpellHound_Pointer();
		else if(id == CardIdentifier.BARKING_WYVERN) BarkingWyvern_Pointer();
		else if(id == CardIdentifier.DREAMING_SAGE__CORRON) DreamingSageCorron_Pointer();
		else if(id == CardIdentifier.ADVANCE_OF_THE_BLACK_CHAINS__KAHEDIN) AdvanceoftheBlackChainsKahedin_Pointer();
		else if(id == CardIdentifier.MOBILE_HOSPITAL__ELYSIUM) MobileHospitalElysium_Pointer();
		else if(id == CardIdentifier.BEAST_DEITY__BLANK_MARSH) BeastDeityBlankMarsh_Pointer();
		else if(id == CardIdentifier.STORM_RIDER__NICOLAS) StormRiderNicolas_Pointer();
		else if(id == CardIdentifier.STORM_RIDER__DAMON) StormRiderDamon_Pointer();
		else if(id == CardIdentifier.STORM_RIDER__LYSANDER) StormRiderLysander_Pointer();
		else if(id == CardIdentifier.STEALTH_FIEND__OBORO_CART)StealthFiendOboroCart_Pointer();
		else if(id == CardIdentifier.BLASTER_DARK_SPIRIT) BlasterDarkSpirit_Pointer();
		else if(id == CardIdentifier.BLASTER_BLADE_SPIRIT) BlasterBladeSpirit_Pointer();
		else if(id == CardIdentifier.NIGHTMARE_SUMMONER__RAQIEL) NightmareSummonerRaqiel_Pointer();
		else if(id == CardIdentifier.STARLIGHT_MELODY_TAMER__FARAH) StarlightMelodyTamerFarah_Pointer();
		else if(id == CardIdentifier.LORD_OF_THE_DEMONIC_WINDS__VAYU) LordoftheDemonicWindsVayu_Pointer();
		else if(id == CardIdentifier.BATTLER_OF_THE_TWIN_BRUSH__POLARIS) BattleroftheTwinBrushPolaris_Pointer();
		else if(id == CardIdentifier.BATTLE_SISTER__COOKIE) BattleSisterCookie_Pointer();
		else if(id == CardIdentifier.TRI_STINGER_DRAGON) TristingerDragon_Pointer();
		else if(id == CardIdentifier.PLATINUM_BLOND_FOX_SPIRIT__TAMAMO) PlatinumBlondFoxSpiritTamamo_Pointer();
		else if(id == CardIdentifier.FANTASY_PETAL_STORM__SHIRAYUKI) FantasyPetalStormShirayuki_Pointer();
		else if(id == CardIdentifier.CONVICTION_DRAGON__CHROMEJAILER_DRAGON) ConvictionDragonChromejailerDragon_Pointer();
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM) CovertDemonicDragonMagatsuStorm_Pointer();
		else if(id == CardIdentifier.BATTLE_SIREN__CYNTHIA) BattleSirenCynthia_Pointer();
		else if(id == CardIdentifier.ACCELERATED_COMMAND) AcceleratedCommand_Pointer();
		else if(id == CardIdentifier.TEAR_KNIGHT__CYPRUS) TearKnightCyprus_Pointer();
		else if(id == CardIdentifier.KEY_ANCHOR__DABID) KeyAnchorDabid_Pointer();
		else if(id == CardIdentifier.NAVALGAZER_DRAGON) NavalgazerDragon_Pointer();
		else if(id == CardIdentifier.EXORCIST_MAGE__KOH_KOH) ExorcistMageKohKoh_Pointer();
		else if(id == CardIdentifier.DRAGON_MONK__GINKAKU) DragonMonkGinkaku_Pointer();
		else if(id == CardIdentifier.DRAGON_MONK__KINKAKU) DragonMonkKinkaku_Pointer();
		else if(id == CardIdentifier.OFFICER_CADET__ERIKK) OfficerCadetErikk_Pointer();
		else if(id == CardIdentifier.RELIABLE_STRATEGIC_COMMANDER) ReliableStrategicCommander_Pointer();
		else if(id == CardIdentifier.VETERAN_STRATEGIC_COMMANDER) VeteranStrategicCommander_Pointer();
		else if(id == CardIdentifier.DISTANT_SEA_ADVISOR__VASSILIS) DistantSeaAdvisorVassilis_Pointer();
		else if(id == CardIdentifier.BABY_PTERO) BabyPtero_Pointer();
		else if(id == CardIdentifier.TRANSPORT_DRAGON__BRACHIOPORTER) TransportDragonBrachioporter_Pointer();
		else if(id == CardIdentifier.FORTRESS_AMMONITE) FortressAmmonite_Pointer();
		else if(id == CardIdentifier.SAVAGE_MAGUS) SavageMagus_Pointer();
		else if(id == CardIdentifier.CARRIER_DRAGON__BRACHIOCARRIER) CarrierDragonBrachiocarrier_Pointer();
		else if(id == CardIdentifier.SAVAGE_WARLOCK) SavageWarlock_Pointer();
		else if(id == CardIdentifier.CITADEL_DRAGON__BRACHIOCASTLE) CitadelDragonBrachiocastle_Pointer();
		else if(id == CardIdentifier.BROCCOLINI_MUSKETEER__KIRAH) BroccoliniMusketeerKirah_Pointer();
		else if(id == CardIdentifier.FRUITS_BASKET_ELF) FruitsBasketElf_Pointer();
		else if(id == CardIdentifier.TULIP_MUSKETEER__MINA) TulipMusketeerMina_Pointer();
		else if(id == CardIdentifier.TULIP_MUSKETEER__ALMIRA) TulipMusketeerAlmira_Pointer();
		else if(id == CardIdentifier.WORLD_BEARING_TURTLE__AHKBARA) WorldBearingTurtleAhkbara_Pointer();
		else if(id == CardIdentifier.EXPLODING_TOMATO) ExplodingTomato_Pointer();
		else if(id == CardIdentifier.WORLD_SNAKE__OUROBOROS) WorldSnakeOuroboros_Pointer();
		else if(id == CardIdentifier.FIGHTING_SAUCER) FightingSaucer_Pointer();
		else if(id == CardIdentifier.SPEEDSTER) Speedster_Pointer();
		else if(id == CardIdentifier.COSMIC_RIDER) CosmicRider_Pointer();
		else if(id == CardIdentifier.COSMIC_MOTHERSHIP) CosmicMothership_Pointer();
		else if(id == CardIdentifier.COILING_DUCKBILL) CoilingDuckbill_Pointer();
		else if(id == CardIdentifier.COMPASS_LION) CompassLion_Pointer();
		else if(id == CardIdentifier.THUNDER_SPEAR_WIELDING_EXORCIST_KNIGHT) ThunderSpearWieldingExorcistKnight_Pointer();
		else if(id == CardIdentifier.AQUA_BREATH_DRACOKID) AquaBreathDracokid_Pointer();
		else if(id == CardIdentifier.WINGED_DRAGON__BEAMPTERO) WingedDragonBeamptero_Pointer();
		else if(id == CardIdentifier.WINGED_DRAGON__SLASHPTERO) WingedDragonSlashptero_Pointer();
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAILANDER) DimensionalRoboDailander_Pointer();
		else if(id == CardIdentifier.ENIGMAN_CYCLONE) EnigmanCyclone_Pointer();
		else if(id == CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__REBECCA) LilyoftheValleyMusketeerRebecca_Pointer();
		else if(id == CardIdentifier.HYDRO_HURRICANE_DRAGON) HydroHurricaneDragon_Pointer();
		else if(id == CardIdentifier.OPERATOR_GIRL__MIKA) OperatorGirlMika_Pointer();
		else if(id == CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__KAIVANT) LilyoftheValleyMusketeerKaivant_Pointer();
		else if(id == CardIdentifier.MAIDEN_OF_RAINBOW_WOOD) MaidenofRainbowWood_Pointer();
		else if(id == CardIdentifier.DESTRUCTION_DRAGON__DARK_REX) DestructionDragonDarkRex_Pointer();
		else if(id == CardIdentifier.RUNE_WEAVER)
		{
			RuneWeaver_Pointer();	
		}
		else if(id == CardIdentifier.GIRL_WHO_CROSSED_THE_GAP)
		{
			GirlWhoCrossedtheGap_Pointer();	
		}
		else if(id == CardIdentifier.HOPE_CHILD__TURIEL)
		{
			HopeChildTuriel_Pointer();	
		}
		else if(id == CardIdentifier.DEVIL_IN_SHADOW)
		{
			DevilinShadow_Pointer();	
		}
		else if(id == CardIdentifier.INNOCENT_MAGICIAN)
		{
			InnocentMagician_Pointer();	
		}
		else if(id == CardIdentifier.BATTLE_SISTER__ECLAIR)
		{
			BattleSisterEclair_Pointer();	
		}
		else if(id == CardIdentifier.DARK_KNIGHT_OF_NIGHTMARELAND)
		{
			DarkKnightofNightmareland_Pointer();	
		}
		else if(id == CardIdentifier.SEE_SAW_GAME_LOSER)
		{
			SeesawGameLoser_Pointer();	
		}
		else if(id == CardIdentifier.DISCIPLE_OF_PAIN)
		{
			DiscipleofPain_Pointer();	
		}
		else if(id == CardIdentifier.DOCTROID_MICROS)
		{
			DoctroidMicros_Pointer();	
		}
		else if(id == CardIdentifier.MASTER_OF_PAIN)
		{	
			MasterofPain_Pointer();
		}
		else if(id == CardIdentifier.DOCTROID_MEGALOS)
		{
			DoctroidMegalos_Pointer();	
		}
		else if(id == CardIdentifier.SEE_SAW_GAME_WINNER)
		{	
			SeesawGameWinner_Pointer();
		}
		else if(id == CardIdentifier.BEAST_IN_HAND)
		{
			BeastinHand_Pointer();	
		}
		else if(id == CardIdentifier.BEAUTIFUL_HARPUIA)
		{
			BeautifulHarpuia_Pointer();	
		}
		else if(id == CardIdentifier.RULER_CHAMELEON)
		{
			RulerChameleon_Pointer();	
		}
		else if(id == CardIdentifier.ACORN_MASTER)
		{
			AcornMaster_Pointer();	
		}
		else if(id == CardIdentifier.HULA_HOOP_CAPYBARA)
		{
			HulaHoopCapybara_Pointer();	
		}
		else if(id == CardIdentifier.FAILURE_SCIENTIST__PONKICHI)
		{
			FailureScientistPonkichi_Pointer();	
		}
		else if(id == CardIdentifier.TICK_TOCK_FLAMINGO)
		{
			TickTockFlamingo_Pointer();	
		}
		else if(id == CardIdentifier.THUMBTACK_FIGHTER__RESANORI)
		{
			ThumbtackFighterResanori_Pointer();
		}	
		else if(id == CardIdentifier.EXPLOSION_SCIENTIST__BUNTA)
		{
			ExplosionScientistBunta_Pointer();	
		}
		else if(id == CardIdentifier.PENCIL_KNIGHT__HAMMSUKE)
		{
			PencilKnightHammsuke_Pointer();	
		}
		else if(id == CardIdentifier.SPRING_BREEZE_MESSENGER)
		{
			SpringBreezeMessenger_Pointer();	
		}
		else if(id == CardIdentifier.LOP_EAR_SHOOTER)
		{
			LopEarShooter_Pointer();	
		}
		else if(id == CardIdentifier.PHOTON_ARCHER__GRIFLET)
		{
			PhotonArcherGriflet_Pointer();	
		}
		else if(id == CardIdentifier.FREE_TRAVELER)
		{
			FreeTraveler_Pointer();	
		}
		else if(id == CardIdentifier.PURPLE_TRAPEZIST)
		{
			PurpleTrapezist_Pointer();	
		}
		else if(id == CardIdentifier.FLASK_MARMOSET)
		{
			FlaskMarmoset_Pointer();
		}	
		else if(id == CardIdentifier.TANK_MOUSE)
		{
			TankMouse_Pointer();
		}
		else if(id == CardIdentifier.PENCIL_SQUIRE__HAMMSUKE)
		{
			PencilSquireHammsuke_Pointer();	
		}
		else if(id == CardIdentifier.DUMBBELL_KANGAROO)
		{
			DumbbellKangaroo_Pointer();	
		}
		else if(id == CardIdentifier.PENCIL_HERO__HAMMSUKE)
		{
			PencilHeroHammsuke_Pointer();	
		}
		else if(id == CardIdentifier.EMBLEM_MASTER)
		{
			EmblemMaster_Pointer();	
		}
		else if(id == CardIdentifier.MAGICIAN_OF_QUANTUM_MECHANICS)
		{
			MagicianofQuantumMechanics_Pointer();	
		}
		else if(id == CardIdentifier.FIRE_BREEZE__CARRIE)
		{
			FireBreezeCarrie_Pointer();	
		}
		else if(id == CardIdentifier.SWORD_MAGICIAN__SARAH)
		{
			SwordMagicianSarah_Pointer();	
		}
		else if(id == CardIdentifier.MONOCULUS_TIGER)
		{
			MonoculusTiger_Pointer();	
		}
		else if(id == CardIdentifier.LAMP_CAMEL)
		{
			LampCamel_Pointer();	
		}
		else if(id == CardIdentifier.SCHOOL_DOMINATOR__APT)
		{	
			SchoolDominatorApt_Pointer();
		}
		else if(id == CardIdentifier.WHITE_HARE_IN_THE_MOON_____S_SHADOW__PELLINORE)
		{
			WhiteHareintheMoonShadowPellinore_Pointer();	
		}
		else if(id == CardIdentifier.EMERALD_WITCH__LALA)
		{
			EmeraldWitchLaLa_Pointer();	
		}
		else if(id == CardIdentifier.SILVER_THORN_DRAGON_TAMER__LUQUIER)
		{
			SilverThornDragonTamerLuquier_Pointer();
		}	
		else if(id == CardIdentifier.BINOCULUS_TIGER)
		{
			BinoculusTiger_Pointer();	
		}
		else if(id == CardIdentifier.SCHOOL_HUNTER__LEO_PALD)
		{
			SchoolHunterLeopald_Pointer();	
		}
		else if(id == CardIdentifier.WYVERN_SUPPLY_UNIT)
		{
			WyvernSupplyUnit_Pointer();	
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__RIKI)
		{
			LizardSoldierRiki_Pointer();	
		}
		else if(id == CardIdentifier.LIGHTNING_OF_HOPE__HELENA)
		{
			LightningofHopeHelena_Pointer();	
		}
		else if(id == CardIdentifier.THUNDER_BREAK_DRAGON)
		{
			ThunderBreakDragon_Pointer();	
		}
		else if(id == CardIdentifier.BLESSING_OWL)
		{
			BlessingOwl_Pointer();	
		}
		else if(id == CardIdentifier.PRECIPICE_WHIRLWIND__SAGRAMORE)
		{
			PrecipiceWhirlwindSagramore_Pointer();
		}	
		else if(id == CardIdentifier.EVIL_SLAYING_SWORDSMAN__HAUGAN)
		{
			EvilSlayingSwordsmanHaugan_Pointer();	
		}
		else if(id == CardIdentifier.SLEYGAL_DOUBLE_EDGE)
		{
			SleygalDoubleEdge_Pointer();	
		}
		else if(id == CardIdentifier.BATTLEFIELD_STORM__SAGRAMORE)
		{
			BattlefieldStormSagramore_Pointer();	
		}
		else if(id == CardIdentifier.SLEYGAL_SWORD)
		{
			SleygalSword_Pointer();	
		}
		else if(id == CardIdentifier.MUSCLE_HERCULES)
		{
			MuscleHercules_Pointer();	
		}
		else if(id == CardIdentifier.BATTLE_FLAG_KNIGHT__LAUDINE)
		{
			BattleFlagKnightLaudine_Pointer();	
		}
		else if(id == CardIdentifier.SPARK_KID_DRAGOON)
		{
			SparkKidDragoon_Pointer();	
		}
		else if(id == CardIdentifier.FLAME_OF_VICTORY)
		{
			FlameofVictory_Pointer();	
		}
		else if(id == CardIdentifier.LITTLE_FIGHTER__CRON)
		{
			LittleFighterCron_Pointer();	
		}
		else if(id == CardIdentifier.SACRED_GUARDIAN_BEAST__ELEPHAS)
		{
			SacredGuardianBeastElephas_Pointer();	
		}
		else if(id == CardIdentifier.CAPTAIN_NIGHTKID)
		{
			CaptainNightkid_Pointer();	
		}
		else if(id == CardIdentifier.SKELETON_ASSAULT_TROOPS_CAPTAIN)
		{
			SkeletonAssaultTroopsCaptain_Pointer();	
		}
		else if(id == CardIdentifier.UNDEAD_PIRATE_OF_THE_CURSED_RIFLE)
		{
			PirateoftheCursedRifle_Pointer();	
		}
		else if(id == CardIdentifier.RIPPLE_BANSHEE)
		{
			RippleBanshee_Pointer();	
		}
		else if(id == CardIdentifier.CHILD_FRANK)
		{
			ChildFrank_Pointer();	
		}
		else if(id == CardIdentifier.SKELETON_COLOSSUS)
		{	
			SkeletonColossus_Pointer();
		}
		else if(id == CardIdentifier.HAPPY_BELL__NOCIEL)
		{
			HappyBellNociel_Pointer();	
		}
		else if(id == CardIdentifier.CRITICAL_HIT_ANGEL)
		{
			CriticalHitAngel_Pointer();	
		}
		else if(id == CardIdentifier.THERMOMETER_ANGEL)
		{
			ThermometerAngel_Pointer();	
		}
		else if(id == CardIdentifier.LANCET_SHOOTER)
		{
			LancetShooter_Pointer();	
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__SAISHIN)
		{
			LizardSoldierSaishin_Pointer();	
		}
		else if(id == CardIdentifier.DESERT_GUNNER__RAIEN)
		{
			DesertGunnerRaien_Pointer();	
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_BERSERKER__GARUDA)
		{
			DemonicDragonBerserkerGaruda_Pointer();
		}	
		else if(id == CardIdentifier.PLAYER_OF_THE_HOLY_AXE__NIMUE)
		{
			PlayeroftheHolyAxeNimue_Pointer();	
		}
		else if(id == CardIdentifier.CRIMSON_LION_CUB__KYRPH)
		{
			CrimsonLionCubKyrph_Pointer();	
		}
		else if(id == CardIdentifier.DEADLY_NIGHTMARE)
		{
			DeadlyNightmare_Pointer();	
		}
		else if(id == CardIdentifier.MAGE_OF_CALAMITY__TRIPP)
		{
			MageofCalamityTripp_Pointer();	
		}
		else if(id == CardIdentifier.SKELETON_DEMON_WORLD_KNIGHT)
		{
			SkeletonDemonWorldKnight_Pointer();	
		}
		else if(id == CardIdentifier.DEADLY_SPIRIT)
		{
			DeadlySpirit_Pointer();	
		}
		else if(id == CardIdentifier.THREE_STAR_CHEF__PIETRO)
		{
			ThreeStarChefPietro_Pointer();
		}	
		else if(id == CardIdentifier.MOBILE_HOSPITAL__FEATHER_PALACE)
		{
			MobileHospitalFeatherPalace_Pointer();	
		}
		else if(id == CardIdentifier.DRAGONIC_DEATHSCYTHE)
		{
			DragonicDeathscythe_Pointer();	
		}
		else if(id == CardIdentifier.VAJRA_EMPEROR__INDRA)
		{
			VajraEmperorIndra_Pointer();	
		}
		else if(id == CardIdentifier.DEATH_SEEKER__THANATOS)
		{
			DeathSeekerThanatos_Pointer();	
		}
		else if(id == CardIdentifier.LOVE_MACHINE_GUN__NOCIEL)
		{
			LoveMachineGunNociel_Pointer();	
		}
		else if(id == CardIdentifier.CORE_MEMORY__ARMAROS)
		{
			CoreMemoryArmaros_Pointer();	
		}
		else if(id == CardIdentifier.DESERT_GUNNER__SHIDEN)
		{
			DesertGunnerShiden_Pointer();	
		}
		else if(id == CardIdentifier.PLAYER_OF_THE_HOLY_BOW__VIVIANE)
		{
			PlayeroftheHolyBowViviane_Pointer();	
		}
		else if(id == CardIdentifier.BATTLE_CUPID__NOCIEL)
		{
			BattleCupidNociel_Pointer();	
		}
		else if(id == CardIdentifier.CIRCULAR_SAW__KIRIEL)
		{
			CircularSawKiriel_Pointer();	
		}
		else if(id == CardIdentifier.MADCAP_MARIONETTE)
		{
			MadcapMarionette_Pointer();	
		}
		else if(id == CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAILADY)
		{
			SuperDimensionalRoboDailady_Pointer();	
		}
		else if(id == CardIdentifier.GUIDE_DOLPHIN)
		{
			GuideDolphin_Pointer();	
		}
		else if(id == CardIdentifier.NIGHTMARE_PAINTER)
		{
			NightmarePainter_Pointer();	
		}
		else if(id == CardIdentifier.DOOM_BRINGER_GRIFFIN)
		{
			DoomBringerGriffin_Pointer();	
		}
		else if(id == CardIdentifier.WHITE_HARE_OF_INABA)
		{
			WhiteHareofInaba_Pointer();	
		}
		else if(id == CardIdentifier.DREAM_PAINTER)
		{
			DreamPainter_Pointer();	
		}
		else if(id == CardIdentifier.SILENT_SAGE__SHARON)
		{
			SilentSageSharon_Pointer();	
		}
		else if(id == CardIdentifier.PHANTOM_BRINGER_DEMON)
		{
			PhantomBringerDemon_Pointer();
		}	
		else if(id == CardIdentifier.POWERFUL_SAGE__BAIRON)
		{
			PowerfulSageBairon_Pointer();	
		}
		else if(id == CardIdentifier.WATERING_ELF)
		{
			WateringElf_Pointer();	
		}
		else if(id == CardIdentifier.LADY_OF_THE_SUNLIGHT_FOREST)
		{
			LadyoftheSunlightForest_Pointer();	
		}
		else if(id == CardIdentifier.MAGICAL_POLICE__QUILT)
		{
			MagicalPoliceQuilt_Pointer();	
		}
		else if(id == CardIdentifier.STEALTH_BEAST__EVIL_FERRET)
		{
			StealthBeastEvilFerret_Pointer();	
		}
		else if(id == CardIdentifier.AVATAR_OF_THE_PLAINS__BEHEMOTH)
		{
			AvatarofthePlainsBehemoth_Pointer();	
		}
		else if(id == CardIdentifier.EVIL_EYE_PRINCESS__EURYALE)
		{
			EvileyePrincessEuryale_Pointer();
		}	
		else if(id == CardIdentifier.MEGACOLONY_BATTLER_B)
		{
			MegacolonyBattlerB_Pointer();	
		}
		else if(id == CardIdentifier.FLAME_SEED_SALAMANDER)
		{
			FlameSeedSalamander_Pointer();	
		}
		else if(id == CardIdentifier.GARNET_DRAGON__FLASH)
		{
			GarnetDragonFlash_Pointer();	
		}
		else if(id == CardIdentifier.ENIGMAN_SHINE)
		{
			EnigmanShine_Pointer();	
		}
		else if(id == CardIdentifier.WITCH_OF_NOSTRUM__ARIANRHOD)
		{
			Arianrhod_Pointer();	
		}
		else if(id == CardIdentifier.BEAST_KNIGHT__GARMORE)
		{
			BeastKnightGarmore_Pointer();	
		}
		else if(id == CardIdentifier.GLOOM_FLYMAN)
		{	
			GloomFlyman_Pointer();
		}
		else if(id == CardIdentifier.COSMO_ROAR)
		{
			CosmoRoar_Pointer();	
		}
		else if(id == CardIdentifier.ENIGMAN_RAIN)
		{
			EnigmanRain_Pointer();	
		}
		else if(id == CardIdentifier.COSMO_BEAK)
		{
			CosmoBeak_Pointer();	
		}
		else if(id == CardIdentifier.HEATNAIL_SALAMANDER)
		{
			HeatnailSalamander_Pointer();	
		}
		else if(id == CardIdentifier.SKULL_WITCH__NEMAIN)
		{
			SkullWitchNemain_Pointer();	
		}
		else if(id == CardIdentifier.NAVY_DOLPHIN__AMUR)
		{
			NavyDolphinAmur_Pointer();	
		}
		else if(id == CardIdentifier.SNOW_WHITE_OF_THE_CORALS__CLAIRE)
		{
			SnowWhiteoftheCoralsClaire_Pointer();	
		}
		else if(id == CardIdentifier.INTELLI_IDOL__MELVILLE)
		{
			IntelliidolMelville_Pointer();
		}
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__WEDDELL)
		{
			BermudaTriangleCadetWeddell_Pointer();	
		}
		else if(id == CardIdentifier.TURQUOISE_BLUE__TYRRHENIA)
		{
			TurquoiseBlueTyrrhenia_Pointer();	
		}
		else if(id == CardIdentifier.PEARL_SISTERS__PERLA)
		{
			PearlSistersPerla_Pointer();	
		}
		else if(id == CardIdentifier.BLOODY_CALF)
		{
			BloodyCalf_Pointer();	
		}
		else if(id == CardIdentifier.FLAME_EDGE_DRAGON)
		{
			FlameEdgeDragon_Pointer();	
		}
		else if(id == CardIdentifier.FAITHFUL_ANGEL)
		{
			FaithfulAngel_Pointer();	
		}
		else if(id == CardIdentifier.SECRETARY_ANGEL)
		{
			SecretaryAngel_Pointer();
		}	
		else if(id == CardIdentifier.RAGING_DRAGON__SPARKSAURUS)
		{
			RagingDragonSparksaurus_Pointer();	
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN__BLUE_EYE)
		{
			OracleGuardianBlueEye_Pointer();	
		}
		else if(id == CardIdentifier.RAGING_DRAGON__BLASTSAURUS)
		{
			RagingDragonBlastsaurus_Pointer();	
		}
		else if(id == CardIdentifier.GWYNN_THE_RIPPER)
		{
			Ripper_Pointer();	
		}
		else if(id == CardIdentifier.ULTIMATE_LIFEFORM__COSMO_LORD)
		{
			Lifeform_Pointer();	
		}
		else if(id == CardIdentifier.STIL_VAMPIR)
		{
			StillVampir_Pointer();	
		}
		else if(id == CardIdentifier.MACHINING_WORKER_ANT)
		{
			WorkerAnt_Pointer();	
		}
		else if(id == CardIdentifier.SAVAGE_KING)
		{
			SavageKing_Pointer();	
		}
		else if(id == CardIdentifier.PROMISE_DAUGHTER)
		{
			Promise_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.ROCKET_HAMMER_MAN)
		{
			RocketHammer_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.INTELLI_MOUSE)
		{
			IntelliMouse_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.LADY_BOMB)
		{
			LadyBomb_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.CANNON_FIRE_DRAGON_CANNON_GEAR)
		{
			CannonFireDragon_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.CHAOS_DRAGON_DINOCHAOS)
		{
			ChaosDragon_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.GATTLING_CLAW_DRAGON)
		{
			ClawDragon_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.MARGAL)
		{
			Margal_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.SCIENTIST_MONKEY_RUE)
		{
			MonkeyRue_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.BLAZING_CORE_DRAGON)
		{
			BlazingCore_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.DEMONIC_DRAGON_MAGE_KIMNARA)
		{
			Kimnara_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.DUDLEY_DAN)
		{
			DudleyDan_Pointer();
		}
		else if(_Card.cardID == CardIdentifier.LION_HEAT)
		{
			LionHeat_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.BLAZING_FLARE_DRAGON)
		{
			BlazingFlareDragon_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.SOUL_SAVER_DRAGON)
		{
			SoulSaverDragon_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.SPIRIT_EXCEED)
		{
			SpiritExceed_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.TYRANT_DEATHREX)
		{
			TyrantDeathrex_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.FLAME_OF_HOPE_AERMO)
		{
			FlameOfHopeAermo_HandlePointer();	
		}
		else if(_Card.cardID == CardIdentifier.GOLD_RUTILE)
		{
			GoldRutile_HandlePointer();	
		}
		else if(_Card.cardID == CardIdentifier.SCREAMIN_AND_DANCIN_ANNOUNCER_SHOUT)
		{
			ScreamingShout_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.DRAGON_KNIGHT_ALEPH)
		{
			DragonKnightAleph_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.ORACLE_GUARDIAN_APOLLON)
		{
			OracleGuardianApollon_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.FUTURE_KNIGHT_LLEW)
		{
			FutureKnightLlew_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.VORTEX_DRAGON)
		{
			VortexDragon_Pointer();	
		}
		else if(_Card.cardID == CardIdentifier.KARMA_QUEEN)
		{
			KarmaQueen_Pointer();	
		}
		else if(_UnitObject != null)
		{
			_UnitObject.Pointer();
		}
	}
	#endregion
	/// @endcond
	/// @cond
	#region Flame Edge Dragon 
	public void FlameEdgeDragon_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits)
		{
			if(GetVanguard().clan == "Kagero")
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void FlameEdgeDragon_Active()
	{
		ShowAndDelay();
	}
	
	public void FlameEdgeDragon_Pointer()
	{
		DelayUpdate(delegate {
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	
	#region Stealth Beast, Cat Devil 
	int StealthBeastCatDevil_Field()
	{
		if(RC () && GetNumUnits("Murakumo") > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void StealthBeastCatDevil_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void StealthBeastCatDevil_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul (OwnerCard);	
			SelectUnit("Choose one of your Murakumo units.", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit.BelongsToClan("Murakumo");
			},
			delegate {
			
			});
		});
	}
	
	void StealthBeastCatDevil_Pointer()
	{
		SelectUnit_Pointer();
	}
	#endregion
	
	#region Deck Sweeper 
	void DeckSweeper_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Boost)
		{
			if(RC() && Game.field.GetNumberOfCardsInSoul() > 0 && OwnerCard.boostedUnit.name.Contains("Maelstrom"))
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void DeckSweeper_Active()
	{
		ShowAndDelay();
	}
	
	void DeckSweeper_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 6000);
			EndEffect();
		});
	}
	#endregion
	
	#region Light Signals Penguin Soldier 
	void LightSignalsPenguinSoldier_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 2 && VanguardIs("Aqua Force") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void LightSignalsPenguinSoldier_Active()
	{
		ShowAndDelay();
	}
	
	void LightSignalsPenguinSoldier_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(2);
		});
		
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Officer Cadet, Astraea 
	void OfficerCadetAstraea_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{	
			ConfirmAttack();
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Aqua Force");
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(RC() && CB(1) && GetDefensor().IsVanguard() && c != null && GetAttacker() == c && c.BelongsToClan("Aqua Force") && NumRG(delegate(Card c2) { return c2.BelongsToClan("Aqua Force") && !c2.IsStand(); }) > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}
	
	bool OfficerCadetAstraea_Cancel()
	{
		UnsetBool(1);
		return true;
	}
	
	void OfficerCadetAstraea_Active()
	{	
		if(GetBool(1))
		{
			UnsetBool(1);
			ShowAndDelay();
		}
		else
		{
			Forerunner_Active();
		}
	}
	
	void OfficerCadetAstraea_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit("Choose one of your Aqua Force rear-guards.", 1, true,
				delegate {
					StandUnit(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Aqua Force") && !Unit.IsStand();
				},
				delegate {
				
				});
			});
		});
	}
	
	void OfficerCadetAstraea_Pointer()
	{
		SelectUnit_Pointer();
		CounterBlast_Pointer();
	}
	#endregion
	
	#region Sage of Guidance, Zenon
	public void Zenon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(GetVanguard().clan == "Royal Paladin")
			{
				ShowOnScreen();
				StartEffect();
				_AuxCard = RevealTopCard();
				Delay(1);
			}
		}
	}
	
	public void Zenon_Update()
	{
		DelayUpdate(delegate {
			if(_AuxCard.clan == "Royal Paladin" && _AuxCard.grade == GetVanguard().grade)
			{
				Game.RideFromDeck(_AuxCard);		
			}
			else
			{
				SendCardFromDeckToDrop();
			}
			EndEffect();
		});
	}
	#endregion
	
	#region Stating Presenter
	public void Presenter_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.RideAboveIt)
		{
			if(GetVanguard().clan == "Pale Moon" && Game.playerDeck.Size() >= 2)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void Presenter_Active()
	{
		ShowOnScreen();
		Delay (1);
	}
	
	public void Presenter_Update()
	{	
		DelayUpdate(delegate {
			_AuxCard = Game.SoulCharge();
			_AuxBool = false;
		});
		
		if(_AuxBool && !_AuxCard.AnimationOngoing())
		{
			_AuxBool = false;
			Game.SoulCharge();
			EndEffect();
		}
	}
	#endregion
	
	#region Savage King
	public int SavageKing_Field()
	{
		if(Game.field.GetNumberOfCardsInSoul() >= 1 && Game.field.GetNumberOfRearWithClanName("Tachikaze") > 0)
		{
			return 1;	
		}
		return 0;
	}
	
	public void SavageKing_Active()
	{
		ShowOnScreen();
		StartEffect();
		SoulBlast(1);
	}
	
	public void SavageKing_Update()
	{
		SoulBlastUpdate(delegate() {
			EnableMouse();
			DisplayHelpMessage("Retire one of your Tachikaze rear guards.");
		});
	}
	
	public void SavageKing_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Tachikaze")
				{
					RetireUnit(c);
					IncreasePowerByTurn(OwnerCard, 3000);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Stealth Dragon, Dreadmaster
	public void StealthDragonDreadmaster_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			if(!OwnerCard.IsVanguard())
			{
				if(OwnerCard.boostedUnit == GetAttacker())
				{
					if(Game.playerHand.Size() < Game.enemyHand.Size())
					{
						if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
						{
							if(OwnerCard.boostedUnit.clan == "Nubatama")
							{
								Game.bEffectOnGoing = true;
								DisplayConfirmationWindow();	
							}
						}
					}
				}
			}
		}
	}
	
	public void StealthDragonDreadmaster_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		EnemyHasToDiscardOneCard();
		Game.bEffectOnGoing = false;
	}
	#endregion
		
	#region Love Machine Gun, Nociel 
	void LoveMachineGunNociel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking) ConfirmAttack();
		else if(cs == CardState.Call)
		{
			if(VanguardIs("Angel Feather") && HandSize("Angel Feather") > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void LoveMachineGunNociel_Active()
	{
		ShowAndDelay();	
	}
	
	void LoveMachineGunNociel_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, false, 
			delegate {
				FromHandToDamage(_SIH_Card);	
			}, 
			delegate {
				return _SIH_Card.clan == "Angel Feather";
			}, 
			delegate {
				SelectInDamage(
					1, 
					true, 
					delegate {
						FromDamageToHand(_SID_Card);
				});	
			},
			"Choose an Angel Feather from your hand.");
		});
	}
	
	void LoveMachineGunNociel_Pointer()
	{
		if(SelectInHand_Pointer()) return;
		if(SelectInDamage_Pointer()) return;
	}
	#endregion

	#region Meteor Break Wizard 
	void MeteorBreakWizard_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(CB(1))
			{
				DisplayConfirmationWindow();	
			}
			else 
			{
				ConfirmAttack();	
			}
		}
	}
	
	void MeteorBreakWizard_Active()
	{
		ShowAndDelay();	
		FlipCardInDamageZone(1);
	}
	
	void MeteorBreakWizard_Update()
	{
		DelayUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 3000);
			ConfirmAttack();
			EndEffect();
		});
	}
	#endregion
	
	#region Armored Fairy, Shubiela 
	void ArmoredFairyShubiela_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetVanguard().clan == "Nova Grappler" &&
				Game.field.GetNumberOfCardsInSoul() >= 3)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			if(OwnerCard.IsBoostedBy.clan == "Nova Grappler" && OwnerCard.IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
		}
	}
	
	void ArmoredFairyShubiela_Update()
	{	
		DelayUpdate(delegate {
			SoulBlast(3);	
		});
		
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Blue Dust
	public void BlueDust_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Dark Irregulars")
			{
				Game.bEffectOnGoing = true;
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void BlueDust_Active()
	{
		ShowOnScreen(OwnerCard);
		Game.bEffectOnGoing = false;
		Game.SoulCharge();
	}
	#endregion
	
	#region Stealth Fiend, Midnight Crow 
	void StealthFiendMidnightCrow_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CheckCounterBlast(1)	&&
				GetVanguard().clan == "Murakumo" &&
				Game.playerDeck.SearchForID(CardIdentifier.STEALTH_FIEND__MIDNIGHT_CROW) != null)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void StealthFiendMidnightCrow_Active()
	{
		FlipCardInDamageZone(1);
		ShowAndDelay();
	}
	
	void StealthFiendMidnightCrow_Update()
	{
		DelayUpdate(delegate {
			SetBool(1);
			Game.playerDeck.ViewDeck(CardIdentifier.STEALTH_FIEND__MIDNIGHT_CROW);
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
				SetBool(2);
			}
		}
		
		if(GetBool(2))
		{
			if(Game._MouseHelper.GetAttachedCard() != null)
			{
				UnsetBool(2);
				_AuxCard = Game._MouseHelper.GetAttachedCard();
				_AuxCard.unitAbilities.AddExternAuto(StealthFiendMidnightCrow_ExternAuto);					
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
	
	void StealthFiendMidnightCrow_ExternAuto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.EndTurn && _AuxCard != null)
		{
			//_AuxCard.unitAbilities.CurrentExternAbility = _AuxCard.unitAbilities.LastExternAbility;
			_AuxCard.unitAbilities.FromFieldToDeck(_AuxCard, true);	
			_AuxCard = null;
		}
	}
	#endregion
	
	#region Subterranean Beast, Magma Lord 
	void SubterraneanBeastMagmaLord_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			Game.SoulCharge();
			IncreasePowerByTurn(OwnerCard, 2000);
		}
	}
	
	int SubterraneanBeastMagmaLord_Field()
	{
		if(VC () && Megablast_Check(5, 8))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void SubterraneanBeastMagmaLord_Active()
	{
		Megablast_Active(5, 8);
	}
	
	void SubterraneanBeastMagmaLord_Update()
	{
		Megablast_Update(delegate {
			IncreaseEnemyPowerByTurn(GetEnemyVanguard(), -5000);
			for(int i = 0; i < 6; i++) 
			{
				Card c = EnemyField(i);
				if(c != null && !c.IsVanguard() && c.GetPower() <= 5000)
				{
					RetireEnemyUnit(c);
				}
			}
			EndEffect();
		});
	}
	#endregion
	
	#region Dimensional Robo, Dailander 
	void DimensionalRoboDailander_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(CB (1) && (NumRG(delegate(Card c) { return c.name.Contains("Dimensional Robo") && c != OwnerCard; }) > 0 || GetVanguard().name.Contains("Dimensional Robo"))) 
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void DimensionalRoboDailander_Active()
	{
		ShowAndDelay();	
	}
	
	void DimensionalRoboDailander_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit("Choose another of your units with \"Dimensional Robo\" in its card name.", 1, true, 
				delegate {
					IncreasePowerByTurn(Unit, 4000);	
				},
				delegate {
					return Unit.name.Contains("Dimensional Robo") && Unit != OwnerCard;	
				},
				delegate {
					
				}, true);
			});
		});
	}
	
	void DimensionalRoboDailander_Pointer()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer();
	}
	#endregion
	
	#region Schoolbag Sea Lion 
	void SchoolbagSeaLion_Auto(CardState cs)
	{
		if(cs == CardState.DriveCheck)
		{
			Card c = Game.DriveCard;
			if(c.grade == 3 && c.clan == "Great Nature")
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Stealth Beast, Evil Ferret 
	void StealthBeastEvilFerret_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Murakumo");	
			SetBool(1);
		}
	}
	
	int StealthBeastEvilFerret_Field()
	{
		if(!OwnerCard.IsVanguard() &&
			Game.playerHand.GetNumberOfCardsWithClanName("Murakumo") > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void StealthBeastEvilFerret_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void StealthBeastEvilFerret_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			FromFieldToDeck(OwnerCard, true);
			EnableMouse("Choose one Murakumo unit from your hand.");
		});
		
		if(GetBool(2))
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				UnsetBool(2);
				_AuxCard.unitAbilities.AddExternAuto(delegate(CardState cs, Card effectOwner) {
					if(cs == CardState.EndTurn)
					{
						_AuxCard.unitAbilities.ReturnToHand(_AuxCard);	
					}
				});
				EndEffect();
			}
			else
			{
				Game.HandleCallFromHand();
			}
		}
	}
	
	void StealthBeastEvilFerret_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) && c.clan == "Murakumo")
			{
				_AuxCard = c;
				Game.CallFromHand(c);
				SetBool(2);
				ClearPointer(false);
			}
		}
	}
	#endregion
	
	#region Burning Horn Dragon 
	void BurningHornDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(!OwnerCard.IsVanguard() && GetVanguard().name.Contains("Overlord"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion

	#region Apocalypse Bat 
	void ApocalypseBat_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{	
			Card c = OwnerCard.boostedUnit;
			if(c.name.Contains("Blaster") && Game.field.GetNumberOfCardsInSoul() >= 1)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void ApocalypseBat_Active()
	{
		ShowAndDelay();	
	}
	
	void ApocalypseBat_Update()
	{
		DelayUpdate(delegate {
			SoulCharge(1);
		});	
		
		SoulChargeUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 6000);	
			EndEffect();
		});
	}
	#endregion
	
	#region Flame of Promise, Aermo  
	void FlameofPromiseAermo_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{	
			Card c = OwnerCard.boostedUnit;
			if(c.name.Contains("Overlord") && Game.field.GetNumberOfCardsInSoul() >= 1)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void FlameofPromiseAermo_Active()
	{
		ShowAndDelay();	
	}
	
	void FlameofPromiseAermo_Update()
	{
		DelayUpdate(delegate {
			SoulCharge(1);
		});	
		
		SoulChargeUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 6000);	
			EndEffect();
		});
	}
	#endregion
	
	#region Devil Child 
	void DevilChild_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.clan == "Dark Irregulars" && c.IsVanguard() && Game.field.GetNumberOfCardsInSoul() >= 6)
			{
				IncreasePowerByBattle(c, 4000);
			}
		}
	}
	#endregion
	
	#region Little Witch, LuLu 
	void LittleWitchLuLu_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Soul_Ride)
		{
			if(GetVanguard().clan == "Oracle Think Tank" && GetVanguard().grade >= 3)
			{
				DisplayConfirmationWindow();
			}	
		}
		else if(cs == CardState.CallFromSoul)
		{
			if(Game.field.CountSoul(delegate(Card c) { return c.clan == "Oracle Think Tank"; }) >= 2)
			{
				if(GetVanguard().clan == "Oracle Think Tank")
				{
					SetBool(1);
					DisplayConfirmationWindow();	
				}
			}
		}
	}
			
	bool LittleWitchLuLu_OnCancel()
	{
		UnsetBool(1);	
		return true;
	}
	
	void LittleWitchLuLu_Active()
	{
		ShowAndDelay();	
	}
	
	void LittleWitchLuLu_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				SetBool (2);
				Game.field.ViewSoul(2, delegate(Card c) { return c.clan == "Oracle Think Tank"; });
			}
			else
			{
				CallFromSoul(OwnerCard);
			}
		});
		
		if(GetBool(2))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(2);
				SoulBlast(Game.field.GetLastSelectedList());
			}
		}
		
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Photon Archer, Griflet 
	void PhotonArcherGriflet_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && CB (2))
			{
				if(VC ())
				{
					if(NumRG(delegate(Card c) { return c.clan == "Gold Paladin" && !c.IsStand(); }) > 0)
					{
						DisplayConfirmationWindow();	
					}
				}
				else
				{
					if(NumRG(delegate(Card c) { return c.clan == "Gold Paladin" && c.grade <= 2 && !c.IsStand(); }) > 0)
					{
						DisplayConfirmationWindow();
					}
				}
			}
		}
	}
	
	void PhotonArcherGriflet_Active()
	{
		ShowAndDelay();
	}
	
	void PhotonArcherGriflet_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2, delegate {
				if(VC ())
				{
					SelectUnit("Choose one of your Gold Paladin rear-guards.", 1, true,
								delegate {
									StandUnit(Unit);
								}, 
								delegate { return Unit.clan == "Gold Paladin" && !Unit.IsStand(); }, delegate { });
				}
				else
				{
					SelectUnit("Choose one of your grade 1 or less Gold Paladin rear-guards.", 1, true,
								delegate {
									StandUnit(Unit);
								}, 
								delegate { return Unit.clan == "Gold Paladin" && Unit.grade <= 1 && !Unit.IsStand(); }, delegate { });				
				}
			});
		});
	}
	
	void PhotonArcherGriflet_Pointer()
	{
		CounterBlast_Pointer();
	}
	#endregion
	
	#region Nightmare Doll, Amy 
	void NightmareDollAmy_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(VC () && Game.playerDeck.Size() > 0)
			{
				Game.SoulCharge();
				IncreasePowerByTurn(OwnerCard, 2000);
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(VC () && HitsVanguard() && Megablast_Check(5, 8))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void NightmareDollAmy_Active()
	{
		Megablast_Active(5, 8);	
	}
	
	void NightmareDollAmy_Update()
	{
		Megablast_Update(delegate {
			Game.field.InitFieldIterator();
			while(Game.field.HasNextField())
			{
				Card c = Game.field.CurrentFieldCard();
				if(c != null && c.clan == "Pale Moon")
				{
					MoveToSoul(c);	
				}
			}
			
			if(Game.field.CountSoul(delegate(Card c) { return c.clan == "Pale Moon"; }) > 0)
			{
				int n = min (5, Game.field.GetNumberOfCardsInSoul());
				Game.field.ViewSoul(n, delegate(Card c) { return c.clan == "Pale Moon"; });
				SetBool(1);
				UnblockAllZones();
				Game.CallFromSoul_AddConstraint(delegate(Card c) {
					if(IsBlocked(c.pos))
					{
						return true;
					}
					
					Block(c.pos);
					return false;
				});
			}
		});
		
		if(GetBool(1))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(1);
				_AuxIdVector = Game.field.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					_AuxCard = Game.field.GetSoulByID(_AuxIdVector[0]);
					_AuxIdVector.RemoveAt(0);
					CallFromSoul(_AuxCard);
				}
				else
				{
					Game.CallFromSoul_RemoveConstraint();
					EndEffect();	
				}
			}
		}
		
		CallFromSoulUpdate(delegate {
			if(_AuxIdVector.Count > 0)
			{
				_AuxCard = Game.field.GetSoulByID(_AuxIdVector[0]);
				_AuxIdVector.RemoveAt(0);
				CallFromSoul(_AuxCard);					
			}
			else
			{
				Game.CallFromSoul_RemoveConstraint();
				EndEffect();	
			}
		});
	}
	#endregion
	
	public delegate bool boolCardFunction(Card c);
	int NumRG(boolCardFunction fnc)
	{
		int cnt = 0;
		Game.field.InitFieldIterator();
		while(Game.field.HasNextField())
		{
			Card c = Game.field.CurrentFieldCard();
			if(c != null && !c.IsVanguard() && fnc(c))
			{
				cnt++;	
			}
		}
		return cnt;
	}
	
	#region Rune Weaver 
	void RuneWeaver_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{	
			if(VanguardIs("Dark Irregulars") && HandSize("Dark Irregulars") > 0)
			{	
				DisplayConfirmationWindow();
			}
		}
	}
	
	void RuneWeaver_Active()
	{
		ShowAndDelay();	
	}
	
	void RuneWeaver_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, true, 
			delegate {
				FromHandToSoul(Game.playerHand.GetCurrentCardObject(), Game.playerHand.GetCurrentCard());
			},
			delegate {
				return _SIH_Card.clan == "Dark Irregulars";
			},
			delegate {
				
			}, "Choose one Dark Irregulars from your hand.");
		});
	}
	
	void RuneWeaver_Pointer()
	{
		SelectInHand_Pointer();	
	}
	#endregion
	
	#region Stealth Beast, Million Rat 
	void StealthBeastMillionRat_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CheckCounterBlast(1)	&&
				GetVanguard().clan == "Murakumo" &&
				Game.playerDeck.SearchForID(CardIdentifier.STEALTH_BEAST__MILLION_RAT) != null)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void StealthBeastMillionRat_Active()
	{
		FlipCardInDamageZone(1);
		ShowAndDelay();
	}
	
	void StealthBeastMillionRat_Update()
	{
		DelayUpdate(delegate {
			SetBool(1);
			Game.playerDeck.ViewDeck(CardIdentifier.STEALTH_BEAST__MILLION_RAT);
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
				SetBool(2);
			}
		}
		
		if(GetBool(2))
		{
			if(Game._MouseHelper.GetAttachedCard() != null)
			{
				UnsetBool(2);
				_AuxCard = Game._MouseHelper.GetAttachedCard();
				_AuxCard.unitAbilities.AddExternAuto(StealthBeastMillionRat_ExternAuto);					
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
	
	void StealthBeastMillionRat_ExternAuto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.EndTurn)
		{
			//_AuxCard.unitAbilities.CurrentExternAbility = _AuxCard.unitAbilities.LastExternAbility;
			_AuxCard.unitAbilities.FromFieldToDeck(_AuxCard, true);	
		}
	}
	#endregion
	
	#region Canvas Koala 
	void CanvasKoala_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && GetNumAnotherRear("Great Nature") >= 4 && Game.playerDeck.Size() > 0)
			{
				DrawCardWithoutDelay();	
			}
		}
	}
	#endregion
	
	#region Oracle Guardian, Shisa  
	void OracleGuardianShisa_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && GetNumAnotherRear("Oracle Think Tank") >= 4 && Game.playerDeck.Size() > 0)
			{
				DrawCardWithoutDelay();	
			}
		}
	}
	#endregion
	
	#region Drawing Dread  
	void DrawingDread_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && GetNumAnotherRear("Pale Moon") >= 4 && Game.playerDeck.Size() > 0)
			{
				DrawCardWithoutDelay();	
			}
		}
	}
	#endregion
	
	#region Cyber Beast  
	void CyberBeast_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && GetNumAnotherRear("Dark Irregulars") >= 4 && Game.playerDeck.Size() > 0)
			{
				DrawCardWithoutDelay();	
			}
		}
	}
	#endregion
	
	#region Future Knight, Llew
	public void FutureKnightLlew_Active()
	{
		FlipCardInDamageZone(1);
		ShowOnScreen(OwnerCard);
		EnableMouse();
		DisplayHelpMessage("Select a 'Flogal'");	
		_AuxInt = 0;
		Game.bEffectOnGoing = true;
		
	}
	
	public int FutureKnightLlew_Field()
	{
		if(!OwnerCard.IsVanguard())
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).grade == 1)
			{
				if(Game.field.GetRearCardByID(CardIdentifier.FLOGAL) != null)
				{
					if(Game.field.GetRearCardByID(CardIdentifier.BARCGAL) != null)
					{
						if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
						{
							if(Game.playerDeck.SearchForID(CardIdentifier.BLASTER_BLADE) != null)
							{
								return 1;
							}
						}
					}
				}
			}
		}	
		
		return 0;
	}
	
	public void FutureKnightLlew_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions pos = Util.GetMousePosition();
			if(!Util.IsEnemyPosition(pos) && pos != fieldPositions.VANGUARD_CIRCLE)
			{
				Card temp = Game.field.GetCardAt(pos);
				if(temp != null)
				{
					if(_AuxInt == 0 && temp.cardID != CardIdentifier.FLOGAL)
					{
						return;	
					}
					
					if(_AuxInt == 1 && temp.cardID != CardIdentifier.FUTURE_KNIGHT_LLEW)
					{
						return;	
					}
					
					if(_AuxInt == 2 && temp.cardID != CardIdentifier.BARCGAL)
					{
						return;	
					}
					
					MoveToSoul(temp);
					_AuxCard = temp;
					
					_AuxInt++;
					
					if(_AuxInt == 3)
					{
						DisableMouse();
						ClearMessage();
						_AuxBool = true;
					}
					else
					{
						if(_AuxInt == 1)
						{
							DisplayHelpMessage("Select a 'Future Knight, Llew'");
						}
						else if(_AuxInt == 2)
						{
							DisplayHelpMessage("Select a 'Barcgal'");	
						}
					}
				}
			}
		}
	}
	
	public void FutureKnightLlew_Update()
	{
		if(_AuxBool)
		{
			if(!_AuxCard.AnimationOngoing())
			{
				_AuxBool = false;
				Card temp = Game.playerDeck.SearchForID(CardIdentifier.BLASTER_BLADE);
				Game.RideFromDeck(temp);
				Game.bEffectOnGoing = false;
			}
		}
	}
	#endregion
	
	#region Swordsman of the Blaze, Palamedes 
	public void SwordsmanoftheBlazePalamedes_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			if(Game.field.GetNumberWithClanAndGradeEqual("Royal Paladin", 3) >= 2)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Intelli-mouse
	public void IntelliMouse_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EndTurn)
		{
			if(_AuxCard != null)
			{
				RetireUnit(_AuxCard);
				_AuxCard = null;	
			}
		}
	}
	
	public int IntelliMouse_Field()
	{
		if(!OwnerCard.IsVanguard())
		{
			if(Game.field.GetNumberOfRearWithClanName("Great Nature") > 0)
			{
				return 1;	
			}
		}
		
		return 0;
	}
	
	public void IntelliMouse_Active()
	{
		ShowOnScreen(OwnerCard);
		StartEffect();
		RestUnit(OwnerCard);
		DisplayHelpMessage("Choose one of you Great Nature rear-guards.");
		EnableMouse();
	}
	
	public void IntelliMouse_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Great Nature")
				{
					IncreasePowerByTurn(c, 4000);
					_AuxCard = c;
					ClearMessage();
					DisableMouse();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Cosmo Beak
	void CosmoBeak_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(CheckCounterBlast(2) && NumRearGuards("Dimension Police") > 1)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void CosmoBeak_Active()
	{
		ShowAndDelay();
		FlipCardInDamageZone(2);
	}
	
	void CosmoBeak_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose another of your Dimension Police.");	
		});
	}
	
	void CosmoBeak_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Dimension Police")
				{	
					IncreasePowerByTurn(c, 4000);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Secretary Angel
	public void SecretaryAngel_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			if(Game.field.GetUnitsSoulWithClanName("Oracle Think Tank") >= 6)
			{
				StartEffect();
				ShowAndDelay();	
			}
		}
	}
	
	public void SecretaryAngel_Active()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EnableMouse("Choose a card from your hand.");
		});
	}
	
	public void SecretaryAngel_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn)
			{
				ReturnCardFromHandToDeck(true, false);	
				DisableMouse();
				EndEffect();
				ConfirmAttack();
			}
		}
	}
	#endregion
	
	#region Oracle Guardian, Red Eye 
	public void OracleGuardianRedEye(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits)
		{
			if(GetVanguard().clan == "Oracle Think Tank" && Game.playerDeck.Size() > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void OracleGuardianRedEye_Active()
	{
		ShowAndDelay();	
	}
	
	public void OracleGuardianRedEye_Update()
	{
		DelayUpdate(delegate {
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	
	#region Megacolony Battler B 
	void MegacolonyBattlerB_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null)
			{
				if(GetAttacker() == c &&
					GetDefensor().IsVanguard() &&
					CheckCounterBlast(1) &&
					EnemyRestRearUnits() > 0)
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void MegacolonyBattlerB_Active()
	{
		ShowAndDelay();	
	}
	
	void MegacolonyBattlerB_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your opponent's rear-guards.");	
		});
	}
	
	void MegacolonyBattlerB_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null && !c.IsStand())
				{
					CantStandUntilNextTurn(c);
					ClearPointer();
				}
			}
		}
	}
	#endregion

	#region Chaos Dragon, Dinochaos
	public bool ChaosDragon_Hand()
	{
		if(GetVanguard().grade == 2)
		{
			if(Game.field.GetNumberOfRearWithClanName("Tachikaze") >= 2)
			{
				return true;
			}	
		}
		
		return false;
	}
	
	public void ChaosDragon_Active()
	{
		StartEffect();
		ShowOnScreen(OwnerCard);
		ShowCardInHand(OwnerCard);
		EnableMouse();
		DisplayHelpMessage("Choose two of your Tachikaze rear-guards, and retire them.");
		_AuxInt = 2;
	}
	
	public void ChaosDragon_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Tachikaze")
				{
					RetireUnit(c);
					_AuxInt--;
					if(_AuxInt <= 0)
					{
						ClearMessage();
						DisableMouse();
						Game.Ride(OwnerCard);
						EndEffect();
					}
				}
			}
		}
	}
	#endregion
	
	#region Ultimate Lifeform, Cosmo Lord
	public int Lifeform_Field()
	{
		if(GetNumberRearStandClanName("Nova Grappler") > 0 && OwnerCard.IsVanguard())
		{
			return 1;	
		}
		
		return 0;
	}
	
	public void Lifeform_Active()
	{
		ShowOnScreen();
		StartEffect();
		EnableMouse();
		DisplayHelpMessage("Choose one of your \"Nova Grappler\" rear-guards.");
	}
	
	public void Lifeform_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Nova Grappler" && c.IsStand())
				{
					RestUnit(c);
					IncreasePowerByTurn(OwnerCard, 3000);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
				
	public int GetNumberRearStandClanName(string clanName)
	{
		return Game.field.GetNumberOfRear() - Game.field.GetNumberOfRearUnitsRestedWithClanName(clanName);	
	}
	
	#region Promise Daughter
	public void Promise_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.playerHand.GetNumberOfCardsWithClanName("Oracle Think Tank") > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void Promise_Active()
	{
		ShowOnScreen();
		EnableMouse();
		DisplayHelpMessage("Discard one Oracle Think Tank from your hand.");
	}
	
	public void Promise_Pointer()
	{
		if(AcceptInput())
		{
			Card c = Game.playerHand.GetCurrentCardObject();
			if(c != null && c._HandleMouse.mouseOn && c.clan == "Oracle Think Tank")
			{
				DiscardSelectedCard();
				IncreasePowerByBattle(OwnerCard, 5000);
				DisableMouse();
				ClearMessage();
				EndEffect();
				ConfirmAttack();
			}
		}
	}
	#endregion
	
	#region Hungry Clown
	public void HungryClown_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits)
		{	
			if(GetVanguard().clan == "Pale Moon")
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void HungryClown_Active()
	{
		ShowAndDelay();	
	}
	
	public void HungryClown_Update()
	{
		DelayUpdate(delegate {
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	/// @endcond
	/// @cond
	
	#region Battering Minotaur
	public void BatteringMinotaur_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() > 0)
			{
				SetCard(OwnerCard);
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	public void BatteringMinotaur_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		_AuxCard = OwnerCard;
		IncreasePowerByBattle(3000);
		ConfirmAttack();
	}
	#endregion
	
	#region Dark Knight of Nightmareland 
	int DarkKnightofNightmareland_Field()
	{
		if(RC() && GetNumUnits("Dark Irregulars") >= 2)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void DarkKnightofNightmareland_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void DarkKnightofNightmareland_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit("Choose one of your Dark Irregulars.", 1, true, 
			delegate {
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit.clan == "Dark Irregulars";
			},
			delegate {
				
			}, true);
		});
	}
	
	void DarkKnightofNightmareland_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Battle Sister, Glace 
	void BattleSisterGlace_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetNumberOfCardsInSoul() <= 0)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Queen of Heart
	public void QueenOfHeart_Auto(CardState cs)
	{
		if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.cardID == CardIdentifier.KING_OF_SWORD)
			{
				_AuxCard = OwnerCard.boostedUnit;
				IncreasePowerByBattle(4000);	
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Beast Knight, Garmore 
	void BeastKnightGarmore_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(GetVanguard().clan == "Royal Paladin" &&
				Game.playerHand.GetNumberOfCardsWithClanName("Royal Paladin") > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void BeastKnightGarmore_Active()
	{
		ShowAndDelay();
	}
	
	void BeastKnightGarmore_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose a Royal Paladin card from your hand.");	
		});	
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
	
	void BeastKnightGarmore_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn && c.clan == "Royal Paladin")
			{
				DiscardSelectedCard();
				DisableMouse();
				ClearMessage();
				Game.playerDeck.ViewDeck(CardIdentifier.SNOGAL, CardIdentifier.BRUGAL);
				SetBool(1);
			}
		}
	}
	#endregion
	
	#region Nightmare Painter 
	void NightmarePainter_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Shadow Paladin")
			{
				if(Game.playerHand.GetNumberOfCardsWithClanName("Shadow Paladin") > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void NightmarePainter_Active()
	{
		ShowAndDelay();	
	}
	
	void NightmarePainter_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one Shadow Paladin card from your hand.");	
		});
		
		FromHandToSoulUpdate(delegate {
			EndEffect();	
		});
	}
	
	void NightmarePainter_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) && c.clan == "Shadow Paladin")
			{
				FromHandToSoul(c,Game.playerHand.GetCurrentCard());	
				ClearPointer();
			}
		}
	}
	#endregion
	
	#region Madcap Marionette 
	void MadcapMarionette_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Pale Moon")
			{
				if(Game.playerHand.GetNumberOfCardsWithClanName("Pale Moon") > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void MadcapMarionette_Active()
	{
		ShowAndDelay();	
	}
	
	void MadcapMarionette_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one Pale Moon card from your hand.");	
		});
		
		FromHandToSoulUpdate(delegate {
			EndEffect();	
		});
	}
	
	void MadcapMarionette_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) && c.clan == "Pale Moon")
			{
				FromHandToSoul(c,Game.playerHand.GetCurrentCard());	
			}
		}
	}
	#endregion
	
	#region Dream Painter  
	void DreamPainter_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Royal Paladin")
			{
				if(Game.playerHand.GetNumberOfCardsWithClanName("Royal Paladin") > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void DreamPainter_Active()
	{
		ShowAndDelay();	
	}
	
	void DreamPainter_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one Royal Paladin card from your hand.");	
		});
		
		FromHandToSoulUpdate(delegate {
			EndEffect();	
		});
	}
	
	void DreamPainter_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) && c.clan == "Royal Paladin")
			{
				FromHandToSoul(c,Game.playerHand.GetCurrentCard());	
				ClearPointer();
			}
		}
	}
	#endregion
	
	/*
	 * [ACT](RC):[Put this unit into your soul] Choose up to one of your «Dimension Police», 
	 * and that unit gets [Power]+3000 until end of turn. */
	
	#region Silent Sage, Sharon 
	int SilentSageSharon_Field()
	{
		if(!OwnerCard.IsVanguard() && Game.field.GetNumberOfCardsWithClanName("Royal Paladin") > 1)
		{
			return 1;
		}
		
		return 0;
	}
	
	void SilentSageSharon_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void SilentSageSharon_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			EnableMouse("Choose one of your Royal Paladin units.");
		});	
	}
	
	void SilentSageSharon_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Royal Paladin")
				{
					IncreasePowerByTurn(c, 3000);
					ClearPointer();
				}
			}
		}
	}
	#endregion
	
	#region Guide Dolphin 
	int GuideDolphin_Field()
	{
		if(!OwnerCard.IsVanguard() && Game.field.GetNumberOfCardsWithClanName("Dimension Police") > 1)
		{
			return 1;
		}
		
		return 0;
	}
	
	void GuideDolphin_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void GuideDolphin_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			EnableMouse("Choose one of your Dimension Police units.");
		});	
	}
	
	void GuideDolphin_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Dimension Police")
				{
					IncreasePowerByTurn(c, 3000);
					ClearPointer();
				}
			}
		}
	}
	#endregion
	
	#region Super Dimensional Robo, Dailady 
	void SuperDimensionalRoboDailady_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(!OwnerCard.IsVanguard() && GetDefensor().IsVanguard())
			{
				StartEffect();
				ShowAndDelay();	
			}
		}
	}
	
	void SuperDimensionalRoboDailady_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your Dimension Police units.");	
		});
	}
	
	void SuperDimensionalRoboDailady_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Dimension Police")
				{
					IncreasePowerByTurn(c, 3000);
					Game.bBlockMouseOnce = true;
					ClearPointer();
				}
			}
		}
	}
	#endregion
	
	#region Free Traveler 
	void FreeTraveler_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Dark Irregulars") && Game.playerDeck.Count(delegate(Card c) { return c.clan == "Dark Irregulars" && c.grade <= 2; }) > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void FreeTraveler_Active()
	{
		ShowAndDelay();	
	}
	
	void FreeTraveler_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate { 
				SetBool(1);
				Game.playerDeck.ViewDeck(1, delegate(Card c) { return c.clan == "Dark Irregulars" && c.grade >= 2; });
			});
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					SoulCharge(_AuxIdVector);
				}
				else
				{
					EndEffect();
				}
			}
		}
		
		SoulChargeUpdate(delegate {
			EndEffect();	
			ShuffleDeck();
		});
	}
	
	void FreeTraveler_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Anthrodroid
	int Anthrodroid_Field()
	{
		if(GetVanguard().clan == "Nova Grappler" && !OwnerCard.IsVanguard() && CheckCounterBlast(1))
		{
			return 1;
		}
		
		return 0;	
	}
	
	void Anthrodroid_Active()
	{
		ShowAndDelay();
		FlipCardInDamageZone(1);
	}
	
	void Anthrodroid_Update()
	{
		DelayUpdate(delegate {
			StandUnit(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Top Gun 
	void TopGun_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Rest_NotMe || cs == CardState.Rest)
		{
			if(OwnerCard.IsVanguard())
			{
				IncreasePowerByTurn(OwnerCard, 1000);	
			}
		}
	}
	#endregion
	
	#region Phantom Bringer Demon 
	int PhantomBringerDemon_Field()
	{
		if(!OwnerCard.IsVanguard() && CheckCounterBlast(1) && NumRearGuards("Shadow Paladin") >= 2 &&
			Game.playerDeck.SearchForID(CardIdentifier.PHANTOM_BLASTER_OVERLORD) != null)
		{
			return 1;
		}
		
		return 0;
	}
	
	void PhantomBringerDemon_Active()
	{
		ShowAndDelay();
		StartEffect();
	}
	
	void PhantomBringerDemon_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose two of your Shadow Paladin rear-guards.");	
			_AuxInt = 2;
		});
	}
	
	void PhantomBringerDemon_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Shadow Paladin")
				{
					RetireUnit(c);
					_AuxInt--;
					if(_AuxInt <= 0)
					{
						FromDeckToHand(CardIdentifier.PHANTOM_BLASTER_OVERLORD);
						ClearPointer();	
					}
				}
			}
		}
	}
	#endregion
	
	#region Doom Bringer Griffin   
	int DoomBringerGriffin_Field()
	{
		if(!OwnerCard.IsVanguard() && CheckCounterBlast(1) && NumRearGuards("Kagero") >= 2 &&
			Game.playerDeck.SearchForID(CardIdentifier.DRAGONIC_OVERLORD_THE_END) != null)
		{
			return 1;
		}
		
		return 0;
	}
	
	void DoomBringerGriffin_Active()
	{
		ShowAndDelay();
		StartEffect();
	}
	
	void DoomBringerGriffin_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose two of your Kagero rear-guards.");	
			_AuxInt = 2;
		});
	}
	
	void DoomBringerGriffin_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Kagero")
				{
					RetireUnit(c);
					_AuxInt--;
					if(_AuxInt <= 0)
					{
						FromDeckToHand(CardIdentifier.DRAGONIC_OVERLORD_THE_END);
						ClearPointer();	
					}
				}
			}
		}
	}
	#endregion
	
	#region White Hare of Inaba 
	void WhiteHareofInaba_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Oracle Think Tank" && 
				Game.playerHand.GetNumberOfCardsWithClanName("Oracle Think Tank") > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void WhiteHareofInaba_Active()
	{
		ShowAndDelay();
	}	
	
	void WhiteHareofInaba_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one Oracle Think Tank from your hand.");	
		});
		
		FromHandToSoulUpdate(delegate {
			EndEffect();	
		});
	}
	
	void WhiteHareofInaba_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) && c.clan == "Oracle Think Tank")
			{
				FromHandToSoul(c, Game.playerHand.GetCurrentCard());
				ClearPointer(false);
			}
		}
	}
	#endregion
	
	#region Battle Maiden, Tagitsuhime 
	void BattleMaidenTagitsuhime_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(!OwnerCard.IsVanguard() && Game.field.GetUnitsSoulWithClanName("Oracle Think Tank") >= 6)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Powerful Sage, Bairon 
	void PowerfulSageBairon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard())
			{
				ShowAndDelay();
				StartEffect();
			}
		}
	}
	
	void PowerfulSageBairon_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your Royal Paladin units.");	
		});
	}
	
	void PowerfulSageBairon_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Royal Paladin")
				{
					IncreasePowerByTurn(c, 3000);
					ClearPointer();
				}
			}
		}
	}
	#endregion
	
	#region Super Electromagnetic Lifeform, Storm
	public void SuperLifeform_Auto(CardState cs)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetAttacker() == OwnerCard)
			{
				if(Game.field.GetNumberOfDamageCardsFacedown() > 0)
				{
					ShowOnScreen(OwnerCard);
					UnflipCardInDamageZone(1);
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Fullbau
	void Fullbau_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.BLASTER_JAVELIN &&
				Game.playerDeck.SearchForID(CardIdentifier.BLASTER_DARK) != null)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void Fullbau_Update()
	{
		DelayUpdate(delegate {
			FromDeckToHand(CardIdentifier.BLASTER_DARK);
			ShuffleDeck();
			EndEffect();
		});
	}
	#endregion
	
	#region Stealth Beast, Leaf Raccoon 
	void StealthBeastLeafRaccoon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.IsVanguard() && c.clan == "Murakumo")
			{
				if(Game.playerHand.Size() > Game.enemyHand.Size())
				{
					IncreasePowerByBattle(c, 4000);	
				}
			}
		}
	}
	#endregion
	
	#region Midnight Invader 
	void MidnightInvader_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && VanguardIs("Pale Moon"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Stealth Fiend, Dart Spider 
	int StealthFiendDartSpider_Field()
	{
		if(GetVanguard().clan == "Murakumo" && !OwnerCard.IsVanguard())
		{
			return 1;	
		}
		
		return 0;	
	}
	
	void StealthFiendDartSpider_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void StealthFiendDartSpider_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);	
			UnflipCardInDamageZone(1);
			EndEffect();
		});
	}
	#endregion
	
	#region Hysteric Shirley 
	int HystericShirley_Field()
	{
		if(!OwnerCard.IsVanguard() && GetVanguard().clan == "Dark Irregulars")
		{
			return 1;	
		}
		
		return 0;
	}
	
	void HystericShirley_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void HystericShirley_Update()
	{	
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	
	#region Skyhigh Walker  
	int SkyhighWalker_Field()
	{
		if(GetVanguard().clan == "Pale Moon" && !OwnerCard.IsVanguard())
		{
			return 1;	
		}
		
		return 0;	
	}
	
	void SkyhighWalker_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void SkyhighWalker_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);	
			UnflipCardInDamageZone(1);
			EndEffect();
		});
	}
	#endregion
	
	#region Larva Mutant, Giraffa 
	void LarvaMutantGiraffa_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.PUPA_MUTANT__GIRAFFA &&
				Game.playerDeck.SearchForID(CardIdentifier.ELITE_MUTANT__GIRAFFA) != null)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void LarvaMutantGiraffa_Update()
	{
		DelayUpdate(delegate {
			FromDeckToHand(CardIdentifier.ELITE_MUTANT__GIRAFFA);
			ShuffleDeck();
			EndEffect();
		});
	}
	#endregion
	
	#region Amber Dragon, Dawn 
	void AmberDragonDawn_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.AMBER_DRAGON__DAYLIGHT &&
				Game.playerDeck.SearchForID(CardIdentifier.AMBER_DRAGON__DUSK) != null)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void AmberDragonDawn_Update()
	{
		DelayUpdate(delegate {
			FromDeckToHand(CardIdentifier.AMBER_DRAGON__DUSK);
			ShuffleDeck();
			EndEffect();
		});
	}
	#endregion 
	
	#region Blaujunger
	void Blaujunger_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.BLAUPANZER &&
				Game.playerDeck.SearchForID(CardIdentifier.BLAUKLUGER) != null)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void Blaujunger_Update()
	{
		DelayUpdate(delegate {
			FromDeckToHand(CardIdentifier.BLAUKLUGER);
			ShuffleDeck();
			EndEffect();
		});
	}
	#endregion 
	
	#region Knight of Loyalty, Bedivere 
	void KnightofLoyaltyBedivere_Auto(CardState cs)
	{	
		if(cs == CardState.Attacking)
		{
			if(!OwnerCard.IsVanguard() &&
				GetVanguard().name.Contains("Blaster"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Knight of Friendship, Kay 
	void KnightofFriendshipKay_Auto(CardState cs)
	{	
		if(cs == CardState.Attacking)
		{
			if(!OwnerCard.IsVanguard() &&
				GetVanguard().name.Contains("Blaster"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Knight of Nullity, Masquerade 
	void KnightofNullityMasquerade_Auto(CardState cs)
	{	
		if(cs == CardState.Attacking)
		{
			if(!OwnerCard.IsVanguard() &&
				GetVanguard().name.Contains("Blaster"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Enigman Flow 
	void EnigmanFlow_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.ENIGMAN_RIPPLE &&
				Game.playerDeck.SearchForID(CardIdentifier.ENIGMAN_WAVE) != null)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void EnigmanFlow_Update()
	{
		DelayUpdate(delegate {
			FromDeckToHand(CardIdentifier.ENIGMAN_WAVE);
			ShuffleDeck();
			EndEffect();
		});
	}
	#endregion
	
	#region Dark Soul Conductor 
	void DarkSoulConductor_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromGC)
		{
			if(GetVanguard().clan == "Dark Irregulars" && Game.playerDeck.Size() >= 2)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void DarkSoulConductor_Active()
	{
		ShowAndDelay();	
	}
	
	void DarkSoulConductor_Update()
	{
		DelayUpdate(delegate {
			SoulCharge(2);	
		});
		
		SoulChargeUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Big League Bear 
	void BigLeagueBear_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromGC)
		{
			if(GetVanguard().clan == "Pale Moon" && Game.playerDeck.Size() >= 2)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void BigLeagueBear_Active()
	{
		ShowAndDelay();	
	}
	
	void BigLeagueBear_Update()
	{
		DelayUpdate(delegate {
			SoulCharge(2);	
		});
		
		SoulChargeUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Breakthrough Dragon 
	void BreakthroughDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			Card c = OwnerCard.IsBoostedBy;
			if(c.clan == "Narukami")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	#endregion
	
	#region Hex Cannon Wyvern 
	void HexCannonWyvern_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetDamage() >= 3)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Dragon Monk, Ensei 
	void DragonMonkEnsei_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard())
			{
				if((VC () && NumRearGuards("Narukami") >= 4) || (RC () && NumRearGuards("Narukami") >= 5))
				{
					StartEffect();
					ShowAndDelay();
				}
			}
		}
	}
	
	void DragonMonkEnsei_Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Flame of Victory 
	int FlameofVictory_Field()
	{
		if(RC () && GetNumUnits("Gold Paladin") > 1)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void FlameofVictory_Active()
	{	
		StartEffect();
		ShowAndDelay();
	}
	
	void FlameofVictory_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit("Choose one of your Gold Paladin units.", 1, true,
						delegate {
							IncreasePowerByTurn(Unit, 3000);	
						},
						delegate {
							return Unit.clan == "Gold Paladin";	
						},
						delegate {
								
						}
			);
		});
	}
	
	void FlameofVictory_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Circular Saw, Kiriel 
	void CircularSawKiriel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(LimitBreak() && OwnerCard.IsVanguard() && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
			ConfirmAttack();
		}
		else if(cs == CardState.Ride)
		{
			if(CheckCounterBlast(2))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void CircularSawKiriel_Active()
	{
		ShowAndDelay();	
	}
	
	void CircularSawKiriel_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				EnableMouse("Choose one face-up card from your damage zone.");	
			});	
		});
		
		CallFromDamageUpdate(delegate {
			FromDeckToDamage(Game.playerDeck.TopCard());
			EndEffect();	
		});
	}
	
	void CircularSawKiriel_Pointer()
	{
		if(CounterBlast_Pointer()) return;
		
		if(AcceptInput())
		{
			Card c = Game.LastDamageCardSelected;
			if(c != null && c._HandleMouse.mouseOn && c.IsFaceup() && c.clan == "Angel Feather")
			{
				CallFromDamage(c);
				ClearPointer(false);
			}
		}
	}
	#endregion
	
	#region One Who Gazes at the Truth
	public void OneWhoGazes_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 1 && GetVanguard().clan == "Oracle Think Tank")
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
			else 
			{
				ConfirmAttack();	
			}
		}
	}
	
	public void OneWhoGazes_Active()
	{
		ShowOnScreen(OwnerCard);
		SoulBlast(1);
	}
	
	public void OneWhoGazes_Update()
	{
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 3000);
			EndEffect();
			ConfirmAttack();
		});
	}
	#endregion
	
	#region Dual Axe Archdragon
	public void DualAxe_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			if(Game.enemyField.GetNumberOfRearUnits() <= 2)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
			
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Turquoise Blue, Tyrrhenia
	void TurquoiseBlueTyrrhenia_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 2 && NumRearGuards("Bermuda Triangle") > 1)
			{
				if(GetDefensor().IsVanguard() && GetAttacker().IsBoostedBy == OwnerCard && GetAttacker().clan == "Bermuda Triangle")
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}	
		}
	}
	
	void TurquoiseBlueTyrrhenia_Active()
	{
		ShowAndDelay();	
	}
	
	void TurquoiseBlueTyrrhenia_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose another of your Bermuda Triangle rear-guards.");
		});
	}
	
	void TurquoiseBlueTyrrhenia_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Bermuda Triangle" && c != OwnerCard)
				{
					ReturnToHand(c);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Bull's Eye, Mia 
	void BullsEyeMia_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			if(HitsVanguard())
			{
				Card c = OwnerCard.boostedUnit;
				if(GetAttacker() == c && c.clan == "Pale Moon" && Game.playerDeck.Size() > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void BullsEyeMia_Active()
	{
		ShowAndDelay();	
	}
	
	void BullsEyeMia_Update()
	{
		DelayUpdate(delegate {
			SoulCharge(1);	
		});	
		
		SoulChargeUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Courting Succubus 
	void CourtingSuccubus_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			if(HitsVanguard())
			{
				Card c = OwnerCard.boostedUnit;
				if(GetAttacker() == c && c.clan == "Dark Irregulars" && Game.playerDeck.Size() > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void CourtingSuccubus_Active()
	{
		ShowAndDelay();	
	}
	
	void CourtingSuccubus_Update()
	{
		DelayUpdate(delegate {
			SoulCharge(1);	
		});	
		
		SoulChargeUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Purple Trapezist 
	void PurpleTrapezist_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{	
			if(GetNumAnotherRear("Pale Moon") > 0 && VanguardIs("Pale Moon"))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void PurpleTrapezist_Active()
	{
		ShowAndDelay();	
	}
	
	void PurpleTrapezist_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Pale Moon rear-guards.", 1, false,
				delegate {
					MoveToSoul(Unit);	
			},
			delegate { return Unit.clan == "Pale Moon"; },
			delegate {
				if(Game.field.CountSoul(delegate(Card c) { return c.cardID != CardIdentifier.PURPLE_TRAPEZIST; }) > 0)
				{
					SetBool(1);
					Game.field.ViewSoul(1, delegate(Card c) { return c.cardID != CardIdentifier.PURPLE_TRAPEZIST; });
				}
				else
				{
					EndEffect();	
				}
			});
		});
		
		if(GetBool(1))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(1);
				_AuxIdVector = Game.field.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));
				}
				else
				{
					EndEffect();	
				}
			}
		}
		
		CallFromSoulUpdate(delegate { EndEffect(); });
	}
	
	void PurpleTrapezist_Pointer()
	{
		SelectUnit_Pointer();
	}
	#endregion
	
	#region Gattling Claw Dragon
	public int ClawDragon_Field()
	{
		if(!OwnerCard.IsVanguard())
		{
			if(GetVanguard().clan == "Kagero")
			{
				if(Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(0) > 0)
				{
					if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
					{
						return 1;
					}
				}
			}
		}
		
		return 0;
	}
	
	public void ClawDragon_Active()
	{
		StartEffect();
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		MoveToSoul(OwnerCard);
		EnableMouse();
		DisplayHelpMessage("Choose one your opponent's grade 0 rear-guards, and retire it.");
	}
	
	public void ClawDragon_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null)
				{
					RetireEnemyUnit(c);
					ClearMessage();
					DisableMouse();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Vermillion Gatekeeper
	public void Vermillion_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.RideAboveIt)
		{
			if(GetVanguard().clan == "Dark Irregulars" && Game.playerDeck.Size() > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void Vermillion_Active()
	{
		ShowOnScreen();
		Delay(1);
	}
	
	public void Vermillion_Update()
	{
		DelayUpdate(delegate {
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	
	#region Witch of Nostrum, Arianrhod
	int Arianrhod_Field()
	{
		if(OwnerCard.IsStand() && Game.playerHand.Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void Arianrhod_Active()
	{
		ShowAndDelay();	
	}
	
	void Arianrhod_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose a card from your hand.");	
		});
	}
	
	void Arianrhod_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c))
			{
				DiscardSelectedCard();
				DrawCardWithoutDelay();
				DisableMouse();
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Raging Dragon, Blastsaurus
	public void RagingDragonBlastsaurus_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.DropZoneFromRC)
		{
			if(Game.playerHand.Size() > 0 && Game.playerDeck.SearchForID(CardIdentifier.RAGING_DRAGON__BLASTSAURUS) != null)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void RagingDragonBlastsaurus_Active()
	{
		ShowOnScreen();
		EnableMouse("Choose a card from your hand.");
	}
	
	public void RagingDragonBlastsaurus_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn)
			{
				DiscardSelectedCard();
				DisableMouse();
				_AuxIdVector = new List<CardIdentifier>();
				_AuxIdVector.Add(CardIdentifier.RAGING_DRAGON__BLASTSAURUS);
				CallFromDeck(_AuxIdVector);
			}
		}
	}
	
	public void RagingDragonBlastsaurus_Update()
	{
		CallFromDeckUpdate(delegate {
			ShuffleDeck();
			EndEffect();	
		});
	}
	#endregion
	
	#region Glory Maker 
	void GloryMaker_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.IsVanguard() &&
				OwnerCard.boostedUnit.clan == "Dimension Police" &&
				Game.field.GetDamage() >= 4)
			{
				IncreasePowerByBattle(OwnerCard.boostedUnit, 4000);
				ModifyRealPower += 4000;
			}
		}
	}
	#endregion
	
	#region Flask Marmoset 
	int FlaskMarmoset_Field()
	{
		if(RC () && CB (2))
		{
			return 1;	
		}
		return 0;
	}
	
	void FlaskMarmoset_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Great Nature");	
		}
	}
	
	void FlaskMarmoset_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();	
		}
	}
	
	void FlaskMarmoset_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(2, delegate {
				SelectUnit("Choose one of your Great Nature rear-guards.", 1, true,
					delegate {
						IncreasePowerByTurn(Unit, 4000);
						Unit.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
							if(s == CardState.EndTurn)
							{
								Unit.unitAbilities.RetireUnit(Unit);
							}
						});
					}, delegate { return Unit.clan == "Great Nature"; }, delegate { });
			});
		});
	}
	
	void FlaskMarmoset_Pointer()
	{
		if(SelectUnit_Pointer()) return;
		if(CounterBlast_Pointer()) return;
	}
	#endregion
	
	#region Death Warden Ant Lion 
	void DeathWardenAntLion_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				StartEffect();
				SoulCharge(1);
			}
		}
	}
	
	void DeathWardenAntLion_Update()
	{
		DelayUpdate(delegate {
			IncreasePowerByTurn(OwnerCard, 2000);
			EndEffect();
		});
		
		Megablast_Update(delegate {
			for(int i = 0; i < 6; i++)
			{
				Card c = EnemyField(i);
				if(c != null && !c.IsVanguard() && !c.IsStand())
				{
					CantStandUntilNextTurn(c);	
				}
			}
		});
	}
	
	int DeathWardenAntLion_Field()
	{
		if(Megablast_Check(5, 8))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void DeathWardenAntLion_Active()
	{
		StartEffect();
		ShowOnScreen();
		Megablast_Active(5, 8);
	}
	#endregion
	
	#region Armed Instructor, Bison 
	void ArmedInstructorBison_Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.UnitSendToDropZoneFromRC)
		{
			if(LimitBreak() && VC() && effectOwner.clan == "Great Nature" && Game.field.GetNumberOfDamageCardsFacedown() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	int ArmedInstructorBison_Field()
	{
		if(VC () && CB (2) && NumRearGuards("Great Nature") > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void ArmedInstructorBison_Active()
	{
		SetBool(1);
		StartEffect();
		ShowAndDelay();	
	}
	
	void ArmedInstructorBison_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				CounterBlast(2, delegate {
					SelectUnit("Choose one of your Great Nature rear-guards.", 1, true,
					delegate {
						IncreasePowerByTurn(Unit, 4000);
						Unit.unitAbilities.AddExternAuto(delegate (CardState cs, Card effectOwner) {
							if(cs == CardState.EndTurn)
							{
								RetireUnit(Unit);	
							}
						});
					},
					delegate {
						return Unit.clan == "Great Nature";
					},
					delegate {
						
					});
				});
			}
			else 
			{
				Flipup(min (2, Game.field.GetNumberOfDamageCardsFacedown()),
				delegate {
					EndEffect();	
				});
			}
		});
	}
	
	void ArmedInstructorBison_Pointer()
	{
		Flipup_Pointer();
		SelectUnit_Pointer();
		CounterBlast_Pointer();
	}
	#endregion
	
	#region Enigman Cyclone 
	void EnigmanCyclone_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && OwnerCard.GetPower() >= 14000)
			{
				SetBool(1);	
			}
			ConfirmAttack();
		}
		else if(cs == CardState.AttackHits)
		{
			if(VC() && HitsVanguard() && NumEnemyRG(delegate(Card c) { return true; }) > 0 && GetBool(1))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);	
		}
	}	
	
	void EnigmanCyclone_Update()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
			delegate {
				RetireEnemyUnit(EnemyUnit);	
			},
			delegate {
				return true;
			},
			delegate {
				
			});
		});
	}
	
	void EnigmanCyclone_Pointer()
	{
		SelectEnemyUnit_Pointer();	
	}
	#endregion
	
	#region Lady Justice 
	void LadyJustice_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && VanguardIs("Dimension Police"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Destruction Dragon, Dark Rex 
	void DestructionDragonDarkRex_Auto(CardState cs) 
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BindZone_AttackNotHit)
		{
			if(GetAttacker().IsVanguard() && GetAttacker().grade >= 3 && GetAttacker().clan == "Tachikaze" && NumRearGuards("Tachikaze") >= 3 && LimitBreak())
			{
				SetBool(1);
			}
		}
		else if(cs == CardState.BindZone_EndBattle)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				SetBool(2);
				DisplayConfirmationWindow();
			}
		}
	}
	
	void DestructionDragonDarkRex_Active()
	{
		if(GetBool(2))
		{
			ShowAndDelay();	
		}
		else 
		{
			ShowAndDelay();
			ShowCardInHand(OwnerCard, Game.playerHand.GetCurrentCard());
		}
	}
	
	void DestructionDragonDarkRex_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(2))
			{
				UnsetBool(2);
				SelectUnit("Choose three of your Tachikaze rear-guards.", 3, true,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.clan == "Tachikaze";
				},
				delegate {
					RideFromBind(OwnerCard);	
				});
			}
			else
			{
				if(NumRearGuards("Tachikaze") > 0 || GetVanguard().clan == "Tachikaze")
				{
					SelectUnit("Choose one of your Tachikaze units.", 1, true, 
					delegate {
						IncreasePowerByTurn(Unit, 3000);	
					},
					delegate {
						return Unit.clan == "Tachikaze";	
					},
					delegate {
						FromHandToBind(OwnerCard, Game.playerHand.GetCurrentCard());
					}, true);
				}
				else
				{
					FromHandToBind(OwnerCard, Game.playerHand.GetCurrentCard());
				}
			}
		});
		
		FromHandToBindUpdate(delegate {
			EndEffect();	
		});
	}
	
	bool DestructionDragonDarkRex_Hand()
	{
		return true;
	}
	
	bool DestructionDragonDarkRex_Cancel()
	{
		UnsetBool(2);
		return true;
	}
	
	void DestructionDragonDarkRex_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Tear Knight, Valeria 
	void TearKnightValeria_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() && VanguardIs("Aqua Force") && Game.numBattle >= 4 && NumEnemyRG(delegate(Card c) { return true; }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void TearKnightValeria_Update()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true, 
			delegate {
				RetireEnemyUnit(EnemyUnit);	
			},
			delegate {
				return true;	
			},
			delegate {
				
			});
		});
	}
	
	void TearKnightValeria_Pointer()
	{
		SelectEnemyUnit_Pointer();
	}
	#endregion
	
	void RideFromBind(Card c)
	{
		Game.field.RemoveFromBindZone(c);
		Game.field.Ride(c, true);
		Game.SendPacket(GameAction.RIDE_FROM_BIND, c.cardID);
	}
	
	#region Battle Cupid, Nociel 
	void BattleCupidNociel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.UsedToGuard)
		{
			if(Game.playerHand.GetNumberOfCardsWithClanName("Angel Feather") > 0 &&
				GetVanguard().clan == "Angel Feather")
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void BattleCupidNociel_Active()
	{
		ShowAndDelay();	
	}
	
	void BattleCupidNociel_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose an Angel Feather from your hand.");	
			SetBool(1);
		});
	}
	
	void BattleCupidNociel_Pointer()
	{
		if(AcceptInput())
		{
			if(GetBool(1))
			{
				Card c = HandSelectedCard();
				if(ValidHand(c) && c.clan == "Angel Feather")
				{
					UnsetBool(1);
					FromHandToDamage(c);	
				}
			}
			else
			{
				Card c = Game.LastDamageCardSelected;
				if(ValidHand(c))
				{
					FromDamageToHand(c);
					ClearPointer();
				}
			}
		}
	}
	#endregion
	
	#region Enigman Rain
	void EnigmanRain_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(RealPower(OwnerCard) >= 12000 && OwnerCard.IsVanguard())
			{
				SetBool(1);	
			}
			
			ConfirmAttack();
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetBool(1) &&
				GetDefensor().IsVanguard() &&
				OwnerCard.IsVanguard() &&
				Game.field.GetNumberOfUnitRested() > 0)
			{
				ShowAndDelay();
				StartEffect();
			}
		}	
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);	
		}
	}
	
	void EnigmanRain_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your rested rear-guards.");	
		});
	}
	
	void EnigmanRain_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && !c.IsStand())
				{
					StandUnit(c);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region God-eating Zombie Shark  
	void GodeatingZombieShark_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			Card c = OwnerCard.IsBoostedBy;
			if(c != null && c.clan == "Granblue")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	#endregion
	
	#region Stormride Ghost Ship 
	void StormrideGhostShip_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.CallFromDrop_NotMe || cs == CardState.CallFromDrop)
		{
			if(Game.LastCallFromDrop.clan == "Granblue")
			{
				OwnerCard.RemoveRestraint();
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			Card c = OwnerCard.IsBoostedBy;
			if(c.clan == "Granblue" && VC ())
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
		}
	}
	#endregion
	
	#region Undead Pirate of the Frigid Night 
	void UndeadPirateoftheFrigidNight_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.playerHand.Size() < Game.enemyHand.Size())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Sea Navigator, Silver  
	void SeaNavigatorSilver_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard())
			{
				if(NumRearGuards("Granblue") >= 4)
				{
					if(Game.playerDeck.Size() > 0)
					{
						StartEffect();
						ShowAndDelay();
					}
				}
			}
		}
	}
	
	void SeaNavigatorSilver_Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Monoculus Tiger  
	void MonoculusTiger_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && GetNumAnotherRear("Great Nature") > 0)
			{
				DisplayConfirmationWindow();
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	void MonoculusTiger_Active()
	{
		ShowAndDelay();	
	}
	
	void MonoculusTiger_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Great Nature rear-guards.", 1, true, 
			delegate { IncreasePowerByTurn(Unit, 4000);	Unit.unitAbilities.AddExternAuto(delegate (CardState cs, Card effectOwner) { if(cs == CardState.EndTurn) Unit.unitAbilities.RetireUnit(Unit);});},
			delegate { return Unit.clan == "Great Nature"; },
			delegate { ConfirmAttack(); });
		});
	}
	
	void MonoculusTiger_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Yellow Bolt 
	int YellowBolt_Field()
	{
		if(OwnerCard.IsStand())
		{
			return 1;	
		}
		
		return 0;
	}
	
	void YellowBolt_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void YellowBolt_Update()
	{
		DelayUpdate(delegate {
			RestUnit(OwnerCard);
			SoulCharge(1);
		});
		
		SoulChargeUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Listener of Truth, Dindrane 
	void ListenerofTruthDindrane_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.CallFromDeck)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 1 && VanguardIs("Gold Paladin"))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void ListenerofTruthDindrane_Active()
	{
		ShowAndDelay();	
	}
	
	void ListenerofTruthDindrane_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Avatar of the Plains, Behemoth 
	void AvatarofthePlainsBehemoth_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(OwnerCard.IsVanguard())
			{
				if(GetDefensor().IsVanguard() &&
					Game.field.GetNumberOfRearUnitsRestedWithClanName("Neo Nectar") > 0 &&
					CheckCounterBlast(2))
				{	
					SetBool(1);
					DisplayConfirmationWindow();
				}
			}
			else
			{
				if(GetDefensor().IsVanguard() &&
					Game.field.GetNumberOfRearUnitsRestedWithClanNameAndGradeLessOrEqual("Neo Nectar", 1) > 0 &&
					CheckCounterBlast(2))
				{	
					
					SetBool(2);
					DisplayConfirmationWindow();
				}					
			}
		}
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);
			UnsetBool(2);
		}
	}
	
	void AvatarofthePlainsBehemoth_Active()
	{
		ShowAndDelay();
		FlipCardInDamageZone(2);
	}
	
	void AvatarofthePlainsBehemoth_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				EnableMouse("Choose one of your Neo Nectar rear-guards.");	
			}
			
			if(GetBool(2))
			{
				EnableMouse ("Choose one of your grade 1 or less Neo Nectar rear-guards.");	
			}
		});
	}
	
	void AvatarofthePlainsBehemoth_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && !c.IsStand() && c.clan == "Neo Nectar")
				{
					if(GetBool(1))
					{
						StandUnit(c);
						ClearPointer();
					}
					
					if(GetBool(2))
					{
						if(c.grade <= 1)
						{
							StandUnit(c);
							ClearPointer();
						}
					}
				}
			}
		}
	}
	#endregion
	
	#region Magnet Crocodile 
	void MagnetCrocodile_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Great Nature"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Raging Dragon, Sparksaurus 
	public void RagingDragonSparksaurus_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.DropZoneFromRC)
		{
			if(Game.playerHand.Size() > 0 && Game.playerDeck.SearchForID(CardIdentifier.RAGING_DRAGON__SPARKSAURUS) != null)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void RagingDragonSparksaurus_Active()
	{
		ShowOnScreen();
		EnableMouse("Choose a card from your hand.");
	}
	
	public void RagingDragonSparksaurus_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn)
			{
				DiscardSelectedCard();
				DisableMouse();
				_AuxIdVector = new List<CardIdentifier>();
				_AuxIdVector.Add(CardIdentifier.RAGING_DRAGON__SPARKSAURUS);
				CallFromDeck(_AuxIdVector);
			}
		}
	}
	
	public void RagingDragonSparksaurus_Update()
	{
		CallFromDeckUpdate(delegate {
			ShuffleDeck();
			EndEffect();	
		});
	}
	#endregion
	
	#region Follower, Reas
	public void FollowerReas_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{	
			ConfirmAttack();
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.cardID == CardIdentifier.CHAIN_ATTACK_SUTHERLAND)
			{
				IncreasePowerByBattle(OwnerCard.boostedUnit, 4000);	
			}
		}
	}
	#endregion
	
	#region Stealth Beast, Chigasumi
	public void Chigasumi_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.playerHand.Size() > Game.enemyHand.Size())
			{
				ShowOnScreen(OwnerCard);
				_AuxCard = OwnerCard;
				IncreasePowerByBattle(3000);
			}
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Monster Frank
	public int MonsterFrank_HasOnDropEffect()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 3 && Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).grade == 2)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public void MonsterFrank_Active()
	{
		Game.field.CloseDeck();
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(3);
		RideFromDropZone(OwnerCard);
	}
	#endregion

	#region Winged Dragon, Slashptero 
	void WingedDragonSlashptero_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(GetNumUnits("Tachikaze") >= 1 && CurrentPhaseIs(GamePhase.ATTACK))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void WingedDragonSlashptero_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your Tachikaze units.", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);	
			},
			delegate {
				return Unit.clan == "Tachikaze";	
			},
			delegate {
				
			}, true);
		});
	}
	
	void WingedDragonSlashptero_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion	
	
	#region Winged Dragon, Beamptero 
	void WingedDragonBeamptero_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(GetNumUnits("Tachikaze") >= 1 && CurrentPhaseIs(GamePhase.ATTACK))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void WingedDragonBeamptero_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your Tachikaze units.", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);	
			},
			delegate {
				return Unit.clan == "Tachikaze";	
			},
			delegate {
				
			}, true);
		});
	}
	
	void WingedDragonBeamptero_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion	
	
	#region Military Dragon, Raptor Soldier 
	void MilitaryDragonRaptorSoldier_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.MILITARY_DRAGON__RAPTOR_SERGEANT)
			{
				StartEffect();
				ShowAndDelay();
			}
			else 
			{
				Forerunner("Tachikaze");	
			}
		}
	}
	
	void MilitaryDragonRaptorSoldier_Active()
	{
		Forerunner_Active();
	}
	
	void MilitaryDragonRaptorSoldier_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			int m = min (7, Game.playerDeck.Size());
			Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, m, delegate(Game2DCard c) { return c._CardInfo.cardID == CardIdentifier.MILITARY_DRAGON__RAPTOR_COLONEL || c._CardInfo.cardID == CardIdentifier.MILITARY_DRAGON__RAPTOR_CAPTAIN; });
			SetBool(1);
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					FromDeckToHand(_AuxIdVector[0]);
					ShuffleDeck();
				}
				EndEffect();	
			}
		}
	}
	#endregion	
	
	#region Aqua Breath Dracokid 
	void AquaBreathDracokid_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Aqua Force");	
		}
	}
	
	bool AquaBreathDracokid_Cancel()
	{
		UnsetBool(1);
		return true;
	}
	
	int AquaBreathDracokid_Field()
	{
		if(RC () && GetNumUnits("Aqua Force") >= 2)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void AquaBreathDracokid_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	void AquaBreathDracokid_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit("Choose one of your Aqua Force units.", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 1000);
				Unit.unitAbilities.AddExternAuto(delegate (CardState cs, Card effectOwner) {
					if(cs == CardState.AttackHits)
					{
						if(VanguardIs("Aqua Force") && Game.numBattle >= 4)
						{
							DrawCardWithoutDelay();	
						}	
					}
				});
			},
			delegate {
				return Unit.clan == "Aqua Force";
			},
			delegate {
				
			}, true);
		});
	}
	
	void AquaBreathDracokid_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Thunder Spear Wielding Exorcist Knight 
	void ThunderSpearWieldingExorcistKnight_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Narukami"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			ConfirmAttack();	
		}
	}
	
	int ThunderSpearWieldingExorcistKnight_Field()
	{
		if(CB(1))
		{
			return 1;
		}	
		
		return 0;	
	}
	
	void ThunderSpearWieldingExorcistKnight_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void ThunderSpearWieldingExorcistKnight_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, 
			delegate {
				if(VanguardIs("Narukami"))
				{
					OwnerCard.RemoveRestraint();	
				}
			});
		});
	}
	
	void ThunderSpearWieldingExorcistKnight_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Compass Lion 
	void CompassLion_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EndTurn)
		{
			if(NumRG(delegate(Card c) { return true; }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}	
	}
	
	void CompassLion_Update()
	{	
		DelayUpdate(delegate {
			SelectUnit("Choose one of your rear-guards.", 1, true,
			delegate {
				RetireUnit(Unit);
			},
			delegate {
				return true; 
			},
			delegate {
			
			});
		});
	}
	
	void CompassLion_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Coiling Duckbill 
	void CoilingDuckbill_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(CurrentPhaseIs(GamePhase.MAIN_PHASE))
			{
				if(NumRearGuards("Great Nature") >= 2)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
		}
	}
	
	void CoilingDuckbill_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Great Nature units.", 1, true, 
			delegate {
				SelectAnimField(Unit);
				Unit.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
					if(s == CardState.DropZoneFromRC)
					{
						if(CurrentPhaseIs(GamePhase.ENDTURN))
						{
							DrawCardWithoutDelay();	
						}
					}
				});
			},
			delegate {
				return Unit.clan == "Great Nature" && Unit != OwnerCard;
			},
			delegate {
				
			});
		});
	}
	
	void CoilingDuckbill_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Interdimensional Ninja, Tsukikage 
	void InterdimensionalNinjaTsukikage_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			if(OwnerCard.IsBoostedBy.clan == "Dimension Police")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	#endregion
	
	#region Veteran Strategic Commander 
	void VeteranStrategicCommander_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Aqua Force"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void VeteranStrategicCommander_Active()
	{
		ShowAndDelay();	
	}
	
	void VeteranStrategicCommander_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void VeteranStrategicCommander_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion
	
	#region Whale Supply Fleet, Kairin Maru 
	void WhaleSupplyFleetKairinMaru_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && GetNumAnotherRear("Aqua Force") >= 4)
			{
				DrawCardWithoutDelay();
			}
		}
	}
	#endregion
	
	#region Dragon Monk, Ginkaku 
	void DragonMonkGinkaku_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Narukami"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void DragonMonkGinkaku_Active()
	{
		ShowAndDelay();	
	}
	
	void DragonMonkGinkaku_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void DragonMonkGinkaku_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion
	
	#region Exorcist Mage, Koh Koh 
	void ExorcistMageKohKoh_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Narukami");	
		}
	}
	
	void ExorcistMageKohKoh_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	bool ExorcistMageKohKoh_Cancel()
	{
		UnsetBool (1);
		return true;
	}
	
	int ExorcistMageKohKoh_Field()
	{
		if(RC () && Game.field.GetNumberOfCardsInSoul() >= 1)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void ExorcistMageKohKoh_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			SoulBlast(1);
		});
		
		SoulBlastUpdate(delegate {
			SelectUnit("Choose one of your Narukami units", 1, true,
			delegate {
				SelectAnimField(Unit);
				Unit.bBlockPersistentUntilEndTurn = true;
			},
			delegate {
				return Unit.clan == "Narukami";
			},
			delegate {
				
			}, true);	
		});
	}
	
	void ExorcistMageKohKoh_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Dragon Monk, Kinkaku  
	void DragonMonkKinkaku_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Narukami"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void DragonMonkKinkaku_Active()
	{
		ShowAndDelay();	
	}
	
	void DragonMonkKinkaku_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void DragonMonkKinkaku_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion
	
	#region Cosmic Mothership 
	void CosmicMothership_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Dimension Police"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void CosmicMothership_Active()
	{
		ShowAndDelay();	
	}
	
	void CosmicMothership_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void CosmicMothership_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion
	
	#region Reliable Strategic Commander 
	void ReliableStrategicCommander_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Aqua Force"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void ReliableStrategicCommander_Active()
	{
		ShowAndDelay();	
	}
	
	void ReliableStrategicCommander_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void ReliableStrategicCommander_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion
	
	#region Stealth Beast, Spell Hound 
	void StealthBeastSpellHound_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Murakumo"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void StealthBeastSpellHound_Active()
	{
		ShowAndDelay();	
	}
	
	void StealthBeastSpellHound_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void StealthBeastSpellHound_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion
	
	#region Stealth Rogue of Summoning, Jiraiya 
	int StealthRogueofSummoningJiraiya_Field()
	{
		if(CB (1) && VanguardIs("Murakumo") && RC ())
		{
			return 1;	
		}
		
		return 0;
	}
	
	void StealthRogueofSummoningJiraiya_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void StealthRogueofSummoningJiraiya_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				FromFieldToDeck(OwnerCard, true);
				SetBool(1);
				Game.playerDeck.ViewDeck(1, delegate(Card c) {
					return c.cardID == CardIdentifier.STEALTH_BEAST__GIGANTOAD;	
				});
			});
		});
		
		if(GetBool(1) && !Game.playerDeck.IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = Game.playerDeck.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck(_AuxIdVector);	
			}
			else
			{
				EndEffect();	
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
			ShuffleDeck();
		});
	}
	
	void StealthRogueofSummoningJiraiya_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Stealth Beast, Night Panther 
	int StealthBeastNightPanther_Field()
	{
		if(CB(1))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void StealthBeastNightPanther_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void StealthBeastNightPanther_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByTurn(OwnerCard, 1000);
				EndEffect();
			});
		});
	}
	
	void StealthBeastNightPanther_Pointer()
	{
		CounterBlast_Pointer();
	}
	#endregion
	
	#region Stealth Beast, Flame Fox 
	void StealthBeastFlameFox_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.cardID == CardIdentifier.PLATINUM_BLOND_FOX_SPIRIT__TAMAMO && Game.field.GetNumberOfCardsInSoul() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void StealthBeastFlameFox_Active()
	{
		ShowAndDelay();	
	}
	
	void StealthBeastFlameFox_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
			EndEffect();
		});
	}
	#endregion
	
	#region Savage Magus 
	void SavageMagus_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Tachikaze"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void SavageMagus_Active()
	{
		ShowAndDelay();	
	}
	
	void SavageMagus_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void SavageMagus_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion

	#region Transport Dragon, Brachioporter 
	void TransportDragonBrachioporter_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(CB (1) && VanguardIs("Tachikaze"))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void TransportDragonBrachioporter_Active()
	{
		ShowAndDelay();	
	}
	
	void TransportDragonBrachioporter_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, 
			delegate {
				SetBool(1);
				Game.playerDeck.ViewDeck(1, delegate(Game2DCard c) { return c._CardInfo.cardID == CardIdentifier.CARRIER_DRAGON__BRACHIOCARRIER; });
			});
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromDeck(_AuxIdVector);
				}
				else
				{
					EndEffect();	
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			ShuffleDeck();
			EndEffect();
		});
	}
	
	void TransportDragonBrachioporter_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Officer Cadet, Erikk  
	void OfficerCadetErikk_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Aqua Force");
		}
	}
	
	void OfficerCadetErikk_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	void OfficerCadetErikk_Update()
	{
		Forerunner_Update();
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				MoveToSoul(OwnerCard);
				SetBool(1);
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (5, Game.playerDeck.Size()), delegate(Game2DCard c) { return c._CardInfo.grade >= 3 && c._CardInfo.clan == "Aqua Force"; });
			});
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					FromDeckToHand(_AuxIdVector[0]);
					ShuffleDeck();
				}
				EndEffect();
			}
		}
	}
	
	bool OfficerCadetErikk_Cancel()
	{	
		UnsetBool(1);
		return true;
	}
	
	void OfficerCadetErikk_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Baby Ptero 
	void BabyPtero_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Tachikaze");
		}
	}
	
	void BabyPtero_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	void BabyPtero_Update()
	{
		Forerunner_Update();
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				MoveToSoul(OwnerCard);
				SetBool(1);
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, 5, delegate(Game2DCard c) { return c._CardInfo.grade >= 3 && c._CardInfo.clan == "Tachikaze"; });
			});
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					FromDeckToHand(_AuxIdVector[0]);
					ShuffleDeck();
				}
				EndEffect();
			}
		}
	}
	
	bool BabyPtero_Cancel()
	{	
		UnsetBool(1);
		return true;
	}
	
	void BabyPtero_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Carrier Dragon, Brachiocarrier 
	void CarrierDragonBrachiocarrier_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(CB (1) && VanguardIs("Tachikaze"))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void CarrierDragonBrachiocarrier_Active()
	{
		ShowAndDelay();	
	}
	
	void CarrierDragonBrachiocarrier_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, 
			delegate {
				SetBool(1);
				Game.playerDeck.ViewDeck(1, delegate(Game2DCard c) { return c._CardInfo.cardID == CardIdentifier.CITADEL_DRAGON__BRACHIOCASTLE; });
			});
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromDeck(_AuxIdVector);
				}
				else
				{
					EndEffect();	
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			ShuffleDeck();
			EndEffect();
		});
	}
	
	void CarrierDragonBrachiocarrier_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Savage Warlock 
	void SavageWarlock_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Tachikaze"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void SavageWarlock_Active()
	{
		ShowAndDelay();	
	}
	
	void SavageWarlock_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void SavageWarlock_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion
	
	#region Tulip Musketeer, Mina 
	void TulipMusketeerMina_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Neo Nectar"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void TulipMusketeerMina_Active()
	{
		ShowAndDelay();	
	}
	
	void TulipMusketeerMina_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void TulipMusketeerMina_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion
	
	#region Boon Bana-na 
	void BoonBanana_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			if(HitsVanguard() && OwnerCard.boostedUnit.clan == "Neo Nectar")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void BoonBanana_Active()
	{
		ShowAndDelay();
	}
	
	void BoonBanana_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Fruits Basket Elf 
	void FruitsBasketElf_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Attacking_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null && GetDefensor().IsVanguard() && VanguardIs("Neo Nectar") && c.clan == "Neo Nectar")
			{
				DisplayConfirmationWindow ();	
			}
		}
	}
	
	void FruitsBasketElf_Active()
	{
		ShowAndDelay();	
	}
	
	void FruitsBasketElf_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, 
			delegate {
				Game.SendPacket(GameAction.OPPONENT_CANNOT_NORMAL_GUARD_ENDBATTLE);
				Game.SendPacket(GameAction.OPPONENT_CANNOT_RECEIVEDAMAGE_ENDBATTLE);
				EndEffect();
			});
		});
	}
	
	void FruitsBasketElf_Pointer()
	{	
		CounterBlast_Pointer();
	}
	#endregion
	
	#region Tulip Musketeer, Almira 
	void TulipMusketeerAlmira_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Neo Nectar"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void TulipMusketeerAlmira_Active()
	{
		ShowAndDelay();	
	}
	
	void TulipMusketeerAlmira_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void TulipMusketeerAlmira_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion	

	#region Poison Mushroom 
	void PoisonMushroom_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && GetNumAnotherRear("Neo Nectar") >= 4)
			{
				DrawCardWithoutDelay();
			}
		}
	}
	#endregion
	
	#region Fighting Saucer 
	void FightingSaucer_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB (1) && VanguardIs("Dimension Police"))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void FightingSaucer_Active()
	{
		ShowAndDelay();	
	}
	
	void FightingSaucer_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true, 
				delegate {
					FromDamageToDeck(_SID_Card);	
					Game.field.RemoveFromHelpZone(OwnerCard);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
				});
			}
		});
	}
	
	void FightingSaucer_Pointer()
	{
		CounterBlast_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion	
	
	#region Cosmic Rider 
	void CosmicRider_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(GetNumUnits("Dimension Police") >= 2)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void CosmicRider_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Dimension Police units.", 1 , true,
			delegate {
				IncreasePowerByTurn(Unit, 2000);
			},
			delegate {
				return Unit.clan == "Dimension Police" && Unit != OwnerCard;
			},
			delegate {
				
			}, true);
		});
	}
	
	void CosmicRider_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Assault Monster, Gunrock 
	void AssaultMonsterGunrock_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().GetPower() <= 8000)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Storm Rider, Diamantes 
	void StormRiderDiamantes_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && GetDefensor().IsVanguard() && VanguardIs("Aqua Force") && Game.numBattle == 1)
			{
				IncreasePowerByBattle(OwnerCard, 2000);
				SetBool(1);
			}
			
			ConfirmAttack();	
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1) && BackRowUnit() != null && BackRowUnit().clan == "Aqua Force")
			{
				Game.field.Move(OwnerCard);
			}
			
			UnsetBool(1);
		}
	}
	#endregion
	
	#region Storm Rider, Eugen 
	void StormRiderEugen_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && GetDefensor().IsVanguard() && VanguardIs("Aqua Force") && Game.numBattle == 1)
			{
				IncreasePowerByBattle(OwnerCard, 2000);
				SetBool(1);
			}
			
			ConfirmAttack();	
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1) && BackRowUnit() != null && BackRowUnit().clan == "Aqua Force")
			{
				Game.field.Move(OwnerCard);
			}
			
			UnsetBool(1);
		}
	}
	#endregion
	
	#region Assault Dragon, Pachyphalos 
	void AssaultDragonPachyphalos_Auto(CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetBool(1))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();	
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);	
		}
		else if(cs == CardState.UnitSendToDropZoneFromRC)
		{
			if(ownerEffect.clan == "Tachikaze")
			{
				SetBool(1);	
			}
		}
	}
	#endregion	
	
	#region Storm Rider, Basil 
	void StormRiderBasil_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && GetDefensor().IsVanguard() && VanguardIs ("Aqua Force") && Game.numBattle == 1)
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
				SetBool(1);
			}
			ConfirmAttack();	
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				if(BackRowUnit() != null) 
				{
					Game.field.Move(OwnerCard);
				}
			}
		}
	}
	#endregion
	
	#region Hydro Hurricane Dragon 
	void HydroHurricaneDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetBool(1) && VC () && Game.numBattle >= 4)
			{
				StartEffect();
				ShowAndDelay();
				SetBool(2);
			}
		}
	}
	
	int HydroHurricaneDragon_Field()
	{
		if(VC () && LimitBreak() && CB (2))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void HydroHurricaneDragon_Active()
	{
		StartEffect();
		ShowAndDelay();	
	}
	
	void HydroHurricaneDragon_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(2))
			{
				RetireAllEnemyUnits();
				UnsetBool(2);
				EndEffect();
			}
			else
			{
				CounterBlast(2, 
				delegate {
					IncreasePowerByTurn(OwnerCard, 3000);
					SetBool(1);
					EndEffect();
				});
			}
		});
	}
	
	void HydroHurricaneDragon_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Cyclone Blitz
	public void CycloneBlitz_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetVanguard().clan == "Spike Brothers" && Game.field.GetNumberOfCardsInSoul() >= 1)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	public void CycloneBlitz_Active()
	{
		ShowOnScreen(OwnerCard);
		SoulBlast(1);	
	}
	
	public void CycloneBlitz_Update()
	{
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 3000);
			ConfirmAttack();
			EndEffect();
		});
	}
	#endregion
	
	#region Dark Metal Dragon
	void DarkMetalDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DriveCheck)
		{
			if(OwnerCard.IsVanguard() &&
				Game.DriveCard.clan == "Shadow Paladin")
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}
	#endregion
	
	#region Gururubau
	void Gururubau_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(!OwnerCard.IsVanguard() && GetVanguard().clan == "Shadow Paladin")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	 
	#region Calculator Hippo 
	void CalculatorHippo_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			Card c = OwnerCard.IsBoostedBy;
			if(c.clan == "Great Nature")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	#endregion
	
	#region Citadel Dragon, Brachiocastle 
	void CitadelDragonBrachiocastle_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(CB (1) && VanguardIs("Tachikaze"))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void CitadelDragonBrachiocastle_Active()
	{	
		ShowAndDelay();
	}
	
	void CitadelDragonBrachiocastle_Update()
	{	
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				Game.playerDeck.ViewDeck(1, delegate(Game2DCard c) { return c._CardInfo.cardID == CardIdentifier.TRANSPORT_DRAGON__BRACHIOPORTER; });
				SetBool(1);
			});
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromDeck(_AuxIdVector);
				}
				else
				{
					EndEffect();	
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();
		});
	}
	
	void CitadelDragonBrachiocastle_Pointer()
	{
		CounterBlast_Pointer();
	}
	#endregion
	
	#region Pencil Hero, Hammsuke 
	void PencilHeroHammsuke_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(CurrentPhaseIs(GamePhase.ENDTURN) && VanguardIs("Great Nature") && CB (1) &&
				Game.playerDeck.Count(delegate(Card c) { return c.cardID == CardIdentifier.PENCIL_HERO__HAMMSUKE; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void PencilHeroHammsuke_Active()
	{
		ShowAndDelay();	
	}
	
	void PencilHeroHammsuke_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate { 
				FromDeckToHand(CardIdentifier.PENCIL_HERO__HAMMSUKE);
				EndEffect();
			});
		});
	}
	
	void PencilHeroHammsuke_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Pencil Knight, Hammsuke 
	void PencilKnightHammsuke_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(CurrentPhaseIs(GamePhase.ENDTURN) && VanguardIs("Great Nature") && CB (1) &&
				Game.playerDeck.Count(delegate(Card c) { return c.cardID == CardIdentifier.PENCIL_KNIGHT__HAMMSUKE; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void PencilKnightHammsuke_Active()
	{
		ShowAndDelay();	
	}
	
	void PencilKnightHammsuke_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate { 
				FromDeckToHand(CardIdentifier.PENCIL_KNIGHT__HAMMSUKE);
				EndEffect();
			});
		});
	}
	
	void PencilKnightHammsuke_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Pencil Squire, Hammsuke 
	void PencilSquireHammsuke_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(CurrentPhaseIs(GamePhase.ENDTURN) && VanguardIs("Great Nature") && CB (1) &&
				Game.playerDeck.Count(delegate(Card c) { return c.cardID == CardIdentifier.PENCIL_SQUIRE__HAMMSUKE; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void PencilSquireHammsuke_Active()
	{
		ShowAndDelay();	
	}
	
	void PencilSquireHammsuke_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate { 
				FromDeckToHand(CardIdentifier.PENCIL_SQUIRE__HAMMSUKE);
				EndEffect();
			});
		});
	}
	
	void PencilSquireHammsuke_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Ruler Chameleon  
	void RulerChameleon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(CurrentPhaseIs(GamePhase.ENDTURN) && VanguardIs("Great Nature") && CB (1) &&
				Game.playerDeck.Count(delegate(Card c) { return c.cardID == CardIdentifier.RULER_CHAMELEON; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void RulerChameleon_Active()
	{
		ShowAndDelay();	
	}
	
	void RulerChameleon_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate { 
				FromDeckToHand(CardIdentifier.RULER_CHAMELEON);
				EndEffect();
			});
		});
	}
	
	void RulerChameleon_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Emblem Master 
	void EmblemMaster_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && CB (1) && VanguardIs("Dark Irregulars") && Game.playerDeck.Size() >= 3)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void EmblemMaster_Active()
	{
		ShowAndDelay();	
	}
	
	void EmblemMaster_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate { SoulCharge(3); });	
		});
		
		SoulChargeUpdate(delegate { EndEffect(); });
	}
	
	void EmblemMaster_Pointer() 
	{
		CounterBlast_Pointer();
	}
	#endregion
	
	#region Critical Hit Angel 
	int CriticalHitAngel_Field()
	{
		if(RC () && GetNumUnits("Angel Feather") > 1)
		{
			return 1;		
		}
		
		return 0;
	}
	
	void CriticalHitAngel_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void CriticalHitAngel_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit("Choose one Angel Feather from your field.", 1, true,
				       delegate {
							IncreasePowerByTurn(Unit, 3000);
					   },
				       delegate {
							return Unit.clan == "Angel Feather";
					   },
					   delegate {
				
					   }
			);
		});
	}
	
	void CriticalHitAngel_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Lop Ear Shooter 
	void LopEarShooter_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.CallFromDeck)
		{
			if(HandSize() > 0 && VanguardIs("Gold Paladin") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void LopEarShooter_Active()
	{
		ShowAndDelay();	
	}
	
	void LopEarShooter_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, false, delegate { DiscardSelectedCard(); }, delegate { return true; }, 
			delegate { 
				SetBool(1);
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (3, Game.playerDeck.Size()), "");
			}, "Choose a card from your hand.");
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool NoCall = true;
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.clan == "Gold Paladin")
					{
						NoCall = false;
						CallFromDeck(_AuxIdVector);
					}
				}
			
				if(NoCall)
				{
					if(Game.playerDeck.Size() > 0)
					{
						SetBool(2);
						Game.playerDeck.DisableCloseButton();
						Game.playerDeck.ViewDeck(min(3, Game.playerDeck.Size()), SearchMode.TOP_CARD, min (3, Game.playerDeck.Size()), "");
						DisplayHelpMessage("Choose the order in which you want to return your cards. (From top to bottom)");
					}
					else
					{
						EndEffect();	
					}
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			if(Game.playerDeck.Size() <= 0) EndEffect();
			else
			{
				SetBool(2);
				Game.playerDeck.DisableCloseButton();
				Game.playerDeck.ViewDeck(min(2, Game.playerDeck.Size()), SearchMode.TOP_CARD, min (2, Game.playerDeck.Size()), "");
				DisplayHelpMessage("Choose the order in which you want to return your cards. (From top to bottom)");
			}
			
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);	
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
					Game.playerDeck.RemoveFromDeck(c);
					Game.playerDeck.AddToBottom(c);
				}
				Game.playerDeck.EnableCloseButton();
				EndEffect();
			}
		}
	}
	
	void LopEarShooter_Pointer()
	{
		SelectInHand_Pointer();	
	}
	#endregion
	
	#region Tick Tock Flamingo 
	void TickTockFlamingo_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(CurrentPhaseIs(GamePhase.MAIN_PHASE) && GetNumAnotherRear("Great Nature") > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void TickTockFlamingo_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Great Nature rear-guards.", 1, true,
			delegate {
				SelectAnimField(Unit);
				Unit.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
					if(s == CardState.DropZoneFromRC)
					{
						if(CurrentPhaseIs(GamePhase.ENDTURN) && Game.field.GetNumberOfDamageCardsFacedown() > 0)
						{
							Unit.unitAbilities.CurrentExternAbility = Unit.unitAbilities.LastExternAbility;
							Unit.unitAbilities.ShowOnScreen();
							StartEffect();
							SetBool(1);
						}
					}
				});
				
				Unit.unitAbilities.AddExternUpdate(delegate {
					if(GetBool(1))
					{
						UnsetBool(1);
						SelectInDamage(1, true, 
						delegate {
							FlipupCard(_SID_Card);	
						});
					}
				});
			},
			delegate { return Unit.clan == "Great Nature" && Unit != OwnerCard; }, delegate { });
		});
	}
	
	void TickTockFlamingo_Pointer()
	{
		SelectUnit_Pointer();	
		SelectInDamage_Pointer();
	}
	#endregion
	
	#region Spring Breeze Messenger 
	void SpringBreezeMessenger_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Gold Paladin");	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null && HitsVanguard() && GetAttacker() == c && CB (1) && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void SpringBreezeMessenger_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();	
		}
		else 	
		{
			ShowAndDelay();
		}
	}	
	
	void SpringBreezeMessenger_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				MoveToSoul(OwnerCard);
				SetBool(2);
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (3, Game.playerDeck.Size()), "");
			});
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				
				bool bNoCall = true;
				
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.clan == "Gold Paladin")
					{
						bNoCall = false;
						CallFromDeck(_AuxIdVector);	
					}
				}
				
				if(bNoCall)
				{
					SetBool(3);
					DisplayHelpMessage("Choose the order in which you want to return the cards to your deck. (From top to bottom).");
					Game.playerDeck.ViewDeck(min (3, Game.playerDeck.Size()), SearchMode.TOP_CARD, min (3, Game.playerDeck.Size()), "");
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			RestUnit(CallFromDeckList[0]);
			
			if(Game.playerDeck.Size() <= 0)
			{
				EndEffect();	
			}
			else
			{
				SetBool(3);
				DisplayHelpMessage("Choose the order in which you want to return the cards to your deck. (From top to bottom).");
				Game.playerDeck.ViewDeck(min (2, Game.playerDeck.Size()), SearchMode.TOP_CARD, min (2, Game.playerDeck.Size()), "");	
			}
		});
		
		if(GetBool(3))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(3);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
					Game.playerDeck.RemoveFromDeck(c);
					Game.playerDeck.AddToBottom(c);
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	
	void SpringBreezeMessenger_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Happy Bell, Nociel 
	int HappyBellNociel_Field()
	{
		if(GetVanguard().clan == "Angel Feather" && RC () && HandSize("Angel Feather") > 0)
		{
			return 1;
		}
		
		return 0;
	}
	
	void HappyBellNociel_Active()
	{
		StartEffect();
		ShowAndDelay();	
	}
	
	void HappyBellNociel_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);	
			SelectInHand(1, false, 
				         delegate {
							FromHandToDamage(_SIH_Card);
						 },
						 delegate {
							return _SIH_Card.clan == "Angel Feather";
						 },
						 delegate {
							SelectInDamage(1, true, 
									       delegate {
												FromDamageToHand(_SID_Card);
										   }
							);
						 },
						 "Choose one Angel Feather from your hand."
			);
		});
	}
	
	void HappyBellNociel_Pointer()
	{
		SelectInHand_Pointer();
		SelectInDamage_Pointer();
	}
	#endregion
	
	#region Magician of Quantum Mechanics 
	int MagicianofQuantumMechanics_Field()
	{
		if(CB (1) && RC ())
		{
			return 1;
		}
		
		return 0;
	}
	
	void MagicianofQuantumMechanics_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void MagicianofQuantumMechanics_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(2))
			{
				UnsetBool(2);
				MoveToSoul(_AuxCard);
				if(Game.field.CountSoul(delegate(Card c) { return c.cardID == OwnerCard.cardID; }) > 0)
				{
					Game.field.ViewSoul(1, delegate(Card c) { return c.cardID == OwnerCard.cardID; });
					SetBool(1);
				}
			}
			else 
			{
				CounterBlast(1, delegate { 
					MoveToSoul(OwnerCard);
					if(VanguardIs("Pale Moon") && Game.field.CountSoul(delegate(Card c) {
						return c.cardID != OwnerCard.cardID;	
					}) > 0)
					{
						SetBool(1);
						Game.field.ViewSoul(1, delegate (Card c) { return c.cardID != OwnerCard.cardID; });
					}
				});
			}
		});
		
		if(GetBool(1))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(1);
				Card c = Game.field.GetSoulByID(Game.field.GetLastSelectedList()[0]);
				
				c.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
					if(s == CardState.EndTurn)
					{
						StartEffect();
						ShowAndDelay();	
						SetBool(2);
						_AuxCard = c;
					}
				});
				
				CallFromSoul(c);
			}
		}
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	
	void MagicianofQuantumMechanics_Pointer()
	{
		CounterBlast_Pointer();
	}
	#endregion
	
	#region Dancing Wolf
	void DancingWolf_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Stand)
		{
			if(CurrentPhaseIs(GamePhase.ATTACK))
			{
				IncreasePowerByTurn(OwnerCard, 3000);	
			}
		}
	}
	#endregion
	
	#region Heatnail Salamander 
	void HeatnailSalamander_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			if(GetAttacker().IsBoostedBy != null &&
				GetAttacker().IsBoostedBy == OwnerCard &&
				GetAttacker().clan == "Kagero" &&
				Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(1) > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.EndTurn)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				FromFieldToDeck(OwnerCard);
			}
		}
	}
	
	void HeatnailSalamander_Active()
	{
		ShowAndDelay();
		SetBool(1);
	}
	
	void HeatnailSalamander_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your opponent grade 1 rear-guards.");	
		});
	}
	
	void HeatnailSalamander_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null && c.grade <= 1)
				{
					RetireEnemyUnit(c);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Street Bouncer 
	void StreetBouncer_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(GetVanguard().clan == "Nova Grappler")
			{
				_AuxCard = GetSameColum(OwnerCard.pos);
				if(_AuxCard != null && _AuxCard.IsStand() && _AuxCard.clan == "Nova Grappler")
				{
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	void StreetBouncer_Active()
	{
		ShowAndDelay();	
	}
	
	void StreetBouncer_Update()
	{
		DelayUpdate(delegate {
			RestUnit(OwnerCard);	
			RestUnit(_AuxCard);
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Malevolent Djinn 
	int MalevolentDjinn_Field()
	{
		if(RC () && GetNumUnits("Narukami") > 1)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void MalevolentDjinn_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void MalevolentDjinn_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit("Choose a Narukami unit.", 1, true,
					   delegate {
					   		IncreasePowerByTurn(Unit, 3000);	
					   },
					   delegate {
							return Unit.clan == "Narukami";
					   },
					   delegate {
							
					   }
			);
		});
	}
	#endregion
	
	#region Moai the Great 
	void MoaitheGreat_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			Card c = OwnerCard.IsBoostedBy;
			if(c.clan == "Nova Grappler")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	#endregion
	
	#region Wingal Brave 
	void WingalBrave_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Royal Paladin");
		}
		else if(cs == CardState.AttackHits_NotMe)
		{	
			Card c = OwnerCard.boostedUnit;
			if(c != null && GetAttacker() == c)
			{
				if(GetAttacker().name.Contains("Blaster"))
				{
					DisplayConfirmationWindow();
					SetBool(1);
				}
			}
		}
	}
	
	void WingalBrave_Active()
	{
		if(GetBool(1))
		{
			ShowAndDelay();	
		}
		else
		{
			Forerunner_Active();
		}
	}
	
	void WingalBrave_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				MoveToSoul(OwnerCard);
				UnsetBool(1);
				Game.playerDeck.ViewDeck("", 3, "Blaster");
				SetBool(2);
			}	
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				FromDeckToHand(Game.playerDeck.GetLastSelectedList()[0]);
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Dimensional Robo, Daibattles 
	int DimensionalRoboDaibattles_HasOnSoulEffect()
	{
		if(GetVanguard().clan == "Dimension Police")
		{
			return 1;	
		}
		
		return 0;
	}
	
	void DimensionalRoboDaibattles_Active()
	{
		StartEffect();
		ShowAndDelay();
		Game.field.CloseDeck();
	}
	
	void DimensionalRoboDaibattles_Update()
	{
		DelayUpdate(delegate {
			Game.SoulBlast(OwnerCard);
			IncreasePowerByTurn(GetVanguard(), 3000);
			EndEffect();
		});
	}
	#endregion
	
	#region World Snake, Ouroboros 
	void WorldSnakeOuroboros_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{	
			if(VanguardIs("Neo Nectar"))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void WorldSnakeOuroboros_Active()
	{
		ShowAndDelay();	
	}
	
	void WorldSnakeOuroboros_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();	
			},
			delegate {
				return true;	
			},
			delegate {
				DrawCardWithoutDelay();	
			}, "Choose a card from your hand.");
		});
	}
	
	void WorldSnakeOuroboros_Pointer()
	{
		SelectInHand_Pointer();
	}
	#endregion
	
	#region Broccolini Musketeer, Kirah 
	void BroccoliniMusketeerKirah_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Neo Nectar");	
		}
	}
	
	bool BroccoliniMusketeerKirah_Cancel()
	{
		UnsetBool(1);
		return true;
	}
	
	int BroccoliniMusketeerKirah_Field()
	{
		if(RC () && CB (1))
		{
			return 1;	
		}
		
		return 0;	
	}
	
	void BroccoliniMusketeerKirah_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	void BroccoliniMusketeerKirah_Update()
	{
		Forerunner_Update();	
		
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				int m = min (5, Game.playerDeck.Size());
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, m, delegate(Game2DCard c) {
					return c._CardInfo.grade >= 3 && c._CardInfo.clan == "Neo Nectar";	
				});
				SetBool(2);
			});
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					FromDeckToHand(_AuxIdVector[0]);
					ShuffleDeck();
				}
				
				EndEffect();
			}
		}
	}
	
	void BroccoliniMusketeerKirah_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Savage War Chief 
	void SavageWarChief_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{	
			if(OwnerCard.IsBoostedBy.clan == "Tachikaze")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	#endregion
	
	#region Exploding Tomato 
	void ExplodingTomato_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard())
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void ExplodingTomato_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your Neo Nectar units.", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit.clan == "Neo Nectar";
			},
			delegate {
					
			},
			true);
		});
	}
	
	void ExplodingTomato_Pointer()
	{
		SelectUnit_Pointer();			
	}
	#endregion
	
	#region World Bearing Turtle, Ahkbara 
	void WorldBearingTurtleAhkbara_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && RC ())
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void WorldBearingTurtleAhkbara_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your Neo Nectar units.", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit.clan == "Neo Nectar";
			},
			delegate {
				
			}, true);
		});
	}
	
	void WorldBearingTurtleAhkbara_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Black Lily Musketeer, Hermann 
	void BlackLilyMusketeerHermann_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			if(OwnerCard.IsBoostedBy.clan == "Neo Nectar")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	#endregion 	
	
	#region Mysterious Navy Admiral, Gogoth 
	void MysteriousNavyAdmiralGogoth_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			if(HitsVanguard() && GetAttacker() == OwnerCard.boostedUnit)
			{
				if(GetAttacker().clan == "Dimension Police")
				{
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	void MysteriousNavyAdmiralGogoth_Active()
	{
		ShowAndDelay();	
	}
	
	void MysteriousNavyAdmiralGogoth_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Psychic Grey 
	void PsychicGrey_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{	
			Card c = OwnerCard.boostedUnit;
			if(c.IsVanguard() && c.clan == "Dimension Police")
			{
				if(GetDefensor().GetPower() <= 8000)
				{
					IncreasePowerByBattle(c, 4000);
				}
			}
		}
	}
	#endregion
	
	#region Tank Mouse 
	int TankMouse_Field()
	{
		if(OwnerCard.IsStand())
		{
			return 1;	
		}
		return 0;
	}
	
	void TankMouse_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void TankMouse_Update()
	{
		DelayUpdate(delegate {
			RestUnit(OwnerCard);
			SelectUnit("Choose one of your Great Nature rear-guards.", 1, true,
				delegate { 
					IncreasePowerByTurn(Unit, 4000);
					Unit.unitAbilities.AddExternAuto(delegate (CardState cs, Card effectOwner) {
						if(cs == CardState.EndTurn)
						{
							Unit.unitAbilities.RetireUnit(Unit);	
						}
					});
			 	}, delegate {
				 	return Unit.clan == "Great Nature";
				}, delegate { }
			);
		});
	}
	
	void TankMouse_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Thermometer Giraffe 
	void ThermometerGiraffe_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.clan == "Great Nature" && c.IsVanguard() && Game.enemyField.GetDamageFaceup() >= 2)
			{
				IncreasePowerByBattle(c, 4000);	
			}
		}
	}
	#endregion
	
	#region Silver Thorn Dragon Tamer, Luquier 
	void SilverThornDragonTamerLuquier_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.CallFromSoul_NotMe)
		{
			if(VC ())
			{
				if(Game.LastCallFromSoul.clan == "Pale Moon")
				{
					IncreasePowerByTurn(OwnerCard, 3000);	
				}
			}
		}
	}
	
	int SilverThornDragonTamerLuquier_Field()
	{
		if(VC() && LimitBreak() && CB(3))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void SilverThornDragonTamerLuquier_Active()
	{
		StartEffect();
		ShowAndDelay();	
	}
	
	void SilverThornDragonTamerLuquier_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(3, delegate {
				_AuxInt = 0;
				SetBool(1);
				UnblockAllZones();
				Game.CallFromSoul_AddConstraint(delegate (Card c) { return IsBlocked(c.pos); });				
			});
		});
		
		if(GetBool(1))
		{
			UnsetBool(1);
			
			if(Game.field.CountSoul(delegate(Card c) { return c.clan == "Pale Moon" && c.grade == _AuxInt; }) > 0)
			{
				Game.field.ViewSoul(1, delegate(Card c) { return c.clan == "Pale Moon" && c.grade == _AuxInt; });
				SetBool(2);
				_AuxInt++;
			}
			else if(_AuxInt == 3)
			{
				EndEffect();
			}
			else
			{
				_AuxInt++;
				SetBool(1);
			}
		}
		
		if(GetBool(2))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(2);
				_AuxIdVector = Game.field.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));	
				}
				else
				{
					if(_AuxInt <= 3)
					{
						SetBool(1);	
					}
					else
					{
						EndEffect();	
						Game.CallFromSoul_RemoveConstraint();
					}
				}
			}
		}
		
		CallFromSoulUpdate(delegate {
			Card c = Game.LastCallFromSoul;
			Block(c.pos);
			if(_AuxInt <= 3)
			{
				SetBool(1);	
			}
			else
			{
				EndEffect();
				Game.CallFromSoul_RemoveConstraint();
			}
		});
	}
	
	void SilverThornDragonTamerLuquier_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Coral Assault 
	void CoralAssault_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Aqua Force") && Game.numBattle >= 3)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}	
			ConfirmAttack();
		}
	}
	#endregion	
	
	#region Glass Beads Dragon 
	void GlassBeadsDragon_Auto(CardState cs)
	{	
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetVanguard().clan == "Neo Nectar" && CheckCounterBlast(2))
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void GlassBeadsDragon_Active()
	{
		FlipCardInDamageZone(2);
		ShowAndDelay();
	}
	
	void GlassBeadsDragon_Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Moonlight Witch, Vaha 
	void MoonlightWitchVaha_Auto(CardState cs)
	{	
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetVanguard().clan == "Shadow Paladin" && CheckCounterBlast(2))
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void MoonlightWitchVaha_Active()
	{
		FlipCardInDamageZone(2);
		ShowAndDelay();
	}
	
	void MoonlightWitchVaha_Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Nightmare Summoner, Raqiel 
	void NightmareSummonerRaqiel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && LB (4) && GetDefensor().IsVanguard())
			{	
				IncreasePowerByBattle(OwnerCard, 5000);
			}
			ConfirmAttack();
		}
		else if(cs == CardState.Ride)
		{
			if(CB (2) && Game.field.GetUnitsSoulWithClanName("Pale Moon") > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void NightmareSummonerRaqiel_Active()
	{
		ShowAndDelay();	
	}
	
	void NightmareSummonerRaqiel_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SetBool(1);
				Game.field.ViewSoul(1, delegate(Card c) {
					return c.BelongsToClan("Pale Moon");	
				});
			});
		});
		
		if(GetBool(1) && !Game.field.ViewingSoul())
		{
			UnsetBool(1);
			_AuxIdVector = Game.field.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));
			}
			else
			{
				EndEffect();	
			}
		}
				
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	
	void NightmareSummonerRaqiel_Pointer()
	{
		CounterBlast_Pointer();
	}	
	#endregion
	
	#region Knight of Passion, Bagdemagus 
	void KnightofPassionBagdemagus_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && GetVanguard().name.Contains("Ezel"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Advance of the Black Chains, Kahedin 
	void AdvanceoftheBlackChainsKahedin_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackNotHit_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null && c.BelongsToClan("Gold Paladin") && GetDefensor().IsVanguard() && CB (1) && RC () && GetNumAnotherRear("Gold Paladin") > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void AdvanceoftheBlackChainsKahedin_Active()
	{
		ShowAndDelay();	
	}
	
	void AdvanceoftheBlackChainsKahedin_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit("Choose another of your Gold Paladin rear-guards.", 1, false,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Gold Paladin") && Unit != OwnerCard;
				},
				delegate {
					SetBool(1);
					Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, 1, delegate(Game2DCard c) {
						return c._CardInfo.BelongsToClan("Gold Paladin");	
					});
				});
			});
		});
		
		if(GetBool(1) && !Game.playerDeck.IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = Game.playerDeck.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				Game.bBlockUnitReplacing = true;
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				Card c = Game.playerDeck.DrawCard();
				Game.playerDeck.AddToBottom(c);
				EndEffect();	
			}
		}
		
		CallFromDeckUpdate(delegate {
			Game.bBlockUnitReplacing = false;
			RestUnit(CallFromDeckList[0]);
			EndEffect();
		});
	}
	
	void AdvanceoftheBlackChainsKahedin_Pointer()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer();
	}
	#endregion
	
	#region Dreaming Sage, Corron 
	void DreamingSageCorron_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Gold Paladin");	
		}
	}
	
	bool DreamingSageCorron_Cancel()
	{
		UnsetBool(1);	
		return true;
	}
	
	void DreamingSageCorron_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	int DreamingSageCorron_Field()
	{
		if(RC () && CB (1))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void DreamingSageCorron_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (5, Game.playerDeck.Size()), delegate(Game2DCard c) {
					return c._CardInfo.name.Contains("Ezel");	
				});
				SetBool(2);
			});
		});
		
		if(GetBool(2) && Game.playerDeck.IsOpen())
		{
			UnsetBool(2);
			_AuxIdVector = Game.playerDeck.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				FromDeckToHand(_AuxIdVector[0]);	
			}
			ShuffleDeck();
			EndEffect();
		}
	}
	
	void DreamingSageCorron_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Dusty Plasma Dragon 
	void DustyPlasmaDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && GetVanguard().name.Contains("Vermillion"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Exorcist Demonic Dragon, Indigo 
	void ExorcistDemonicDragonIndigo_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.BelongsToClan("Narukami") && RC ())
			{
				IncreasePowerByBattle(c, 3000);	
			}
		}
	}
	#endregion
	
	#region Stealth Fiend, Oboro Cart 
	void StealthFiendOboroCart_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(VanguardIs("Murakumo") && CB (1) && NumRG(delegate (Card c) { return c.cardID != CardIdentifier.STEALTH_FIEND__OBORO_CART && c.BelongsToClan("Murakumo"); }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void StealthFiendOboroCart_Active()
	{
		ShowAndDelay();	
	}
	
	void StealthFiendOboroCart_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your Murakumo	rear-guards not named Stealth Fiend, Oboro Cart", 1, false,
			delegate {
				SelectAnimField(Unit);
				SetBool(1);
				Game.playerDeck.ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.cardID == Unit.cardID;	
				});
			},
			delegate {
				return Unit.BelongsToClan("Murakumo") && Unit.cardID != CardIdentifier.STEALTH_FIEND__OBORO_CART;
			},
			delegate {
				
			});
		});
		
		if(GetBool(1) && !Game.playerDeck.IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = Game.playerDeck.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();	
			}
		}
		
		CallFromDeckUpdate(delegate {
			Card c = CallFromDeckList[0];
			c.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
				if(s == CardState.EndTurn)
				{
					FromFieldToDeck(c, true);	
				}
			});
			ShuffleDeck();
			EndEffect();
		});
	}
	
	void StealthFiendOboroCart_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Stealth Dragon, Magatsu Wind 
	void StealthDragonMagatsuWind_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.STEALTH_DRAGON__MAGATSU_BREATH)
			{
				StartEffect();
				ShowAndDelay();
			}
			else
			{
				Forerunner("Murakumo");	
			}
		}
	}
	
	void StealthDragonMagatsuWind_Active()
	{
		Forerunner_Active();	
	}
	
	void StealthDragonMagatsuWind_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			SetBool(1);
			Game.playerDeck.ViewDeck(1,SearchMode.TOP_CARD,min (7, Game.playerDeck.Size()),delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM || c._CardInfo.cardID == CardIdentifier.STEALTH_DRAGON__MAGATSU_GALE;	
			});
		});
		
		if(GetBool(1) && Game.playerDeck.IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = Game.playerDeck.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{	
				FromDeckToHand(_AuxIdVector[0]);
			}
			EndEffect();
		}
	}
	#endregion
	
	#region Storm Rider, Lysander 
	void StormRiderLysander_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetDefensor().IsVanguard() && VanguardIs("Aqua Force") && CB (1) && GetSameColum(OwnerCard.pos) != null && GetSameColum(OwnerCard.pos).BelongsToClan("Aqua Force") && RC ())
			{
				DisplayConfirmationWindow();
			}		
		}
	}
	
	void StormRiderLysander_Active()
	{
		ShowAndDelay();	
	}
	
	void StormRiderLysander_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				Game.field.Move(OwnerCard);
				EndEffect();
			});
		});
	}
	
	void StormRiderLysander_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Storm Rider, Damon 
	void StormRiderDamon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetDefensor().IsVanguard() && VanguardIs("Aqua Force") && CB (1) && GetSameColum(OwnerCard.pos) != null && GetSameColum(OwnerCard.pos).BelongsToClan("Aqua Force") && RC ())
			{
				DisplayConfirmationWindow();
			}		
		}
	}
	
	void StormRiderDamon_Active()
	{
		ShowAndDelay();	
	}
	
	void StormRiderDamon_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				Game.field.Move(OwnerCard);
				EndEffect();
			});
		});
	}
	
	void StormRiderDamon_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Storm Rider, Nicolas 
	void StormRiderNicolas_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetDefensor().IsVanguard() && VanguardIs("Aqua Force") && CB (1) && GetSameColum(OwnerCard.pos) != null && GetSameColum(OwnerCard.pos).BelongsToClan("Aqua Force") && RC ())
			{
				DisplayConfirmationWindow();
			}		
		}
	}
	
	void StormRiderNicolas_Active()
	{
		ShowAndDelay();	
	}
	
	void StormRiderNicolas_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				Game.field.Move(OwnerCard);
				EndEffect();
			});
		});
	}
	
	void StormRiderNicolas_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Barking Wyvern 
	void BarkingWyvern_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(HandSize("Pale Moon") > 0)
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	void BarkingWyvern_Active()
	{
		ShowAndDelay();	
	}
	
	void BarkingWyvern_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();	
			},
			delegate {
				return _SIH_Card.BelongsToClan("Pale Moon");	
			},
			delegate {
				int power = 0;
				if(VC ()) power = 6000;
				else if(RC ()) power = 3000;
				IncreasePowerByBattle(OwnerCard, power);
				ConfirmAttack();
			},
			"Choose a card from your hand.");
		});
	}
	
	void BarkingWyvern_Pointer()
	{
		SelectInHand_Pointer();
	}
	#endregion
	
	#region Fire Juggler 
	void FireJuggler_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DriveCheck_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null && c.IsVanguard() && Game.DriveCard.BelongsToClan("Pale Moon") && Game.DriveCard.grade == 3)
			{
				SetBool(1);	
			}
		}
		else if(cs == CardState.EndBattle_NotMe)
		{
			if(GetBool(1) && Game.field.CountSoul(delegate(Card c) { return c.cardID != CardIdentifier.FIRE_JUGGLER; }) > 0)
			{
				DisplayConfirmationWindow();
			}
			UnsetBool(1);
		}
	}
	
	void FireJuggler_Active()
	{
		ShowAndDelay();	
	}
	
	void FireJuggler_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			Game.field.ViewSoul(1, delegate(Card c) {
				return c.cardID != CardIdentifier.FIRE_JUGGLER;	
			});
			SetBool(2);
		});
		
		if(GetBool(2) && !Game.field.ViewingSoul())
		{
			UnsetBool(2);
			_AuxIdVector = Game.field.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));	
			}
			else
			{
				EndEffect();	
			}
		}
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Tri-holl Dracokid 
	void TrihollDracokid_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && VanguardIs("Aqua Force") && Game.numBattle >= 3)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
			
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Aqua Force");	
		}
	}
	
	void TrihollDracokid_Active()
	{	
		Forerunner_Active();
	}
	
	void TrihollDracokid_Update()
	{
		Forerunner_Update();
	}
	#endregion
	
	#region Battle Deity, Susanoo 
	void BattleDeitySusanoo_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && GetVanguard().name.Contains("Amaterasu"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion	
	
	#region Battle Maiden, Sayorihime  
	void BattleMaidenSayorihime_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && GetVanguard().name.Contains("Amaterasu"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion	
	
	#region Battle Siren, Theresa 
	void BattleSirenTheresa_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(RC () && VanguardIs("Aqua Force") && Game.numBattle >= 3)
			{
				IncreasePowerByTurn(GetVanguard(), 3000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Blaster Dark Spirit  
	void BlasterDarkSpirit_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.CallFromDeck)
		{
			if(CB (1) && NumEnemyRG(delegate(Card c) {
				return c.grade >= 2 && (c.pos == fieldPositions.ENEMY_FRONT_LEFT || c.pos == fieldPositions.ENEMY_FRONT_RIGHT); 
			}) > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.BeingAttacked)
		{
			if(RC())
			{
				SetBool(1);
			}
		}
		else if(cs == CardState.EnemyEndBattle)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				RetireUnit(OwnerCard);
			}			
		}
	}
	
	void BlasterDarkSpirit_Active()
	{
		ShowAndDelay();	
	}
	
	void BlasterDarkSpirit_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectEnemyUnit("Choose one of your opponent's grade 2 or greater rear-guards.", 1, true,
				delegate {
					RetireEnemyUnit(EnemyUnit);	
				},
				delegate {
					return EnemyUnit.grade >= 2 && (EnemyUnit.pos == fieldPositions.ENEMY_FRONT_LEFT || EnemyUnit.pos == fieldPositions.ENEMY_FRONT_RIGHT);
				},
				delegate {
					
				});
			});
		});
	}
	
	void BlasterDarkSpirit_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion	

	#region Blaster Blade Spirit 
	void BlasterBladeSpirit_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.CallFromDeck)
		{
			if(CB (1) && NumEnemyRG(delegate(Card c) {
				return c.grade >= 2 && (c.pos == fieldPositions.ENEMY_FRONT_LEFT || c.pos == fieldPositions.ENEMY_FRONT_RIGHT); 
			}) > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.BeingAttacked)
		{
			if(RC())
			{
				SetBool(1);
			}
		}
		else if(cs == CardState.EnemyEndBattle)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				RetireUnit(OwnerCard);
			}			
		}
	}
	
	void BlasterBladeSpirit_Active()
	{
		ShowAndDelay();	
	}
	
	void BlasterBladeSpirit_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectEnemyUnit("Choose one of your opponent's grade 2 or greater rear-guards.", 1, true,
				delegate {
					RetireEnemyUnit(EnemyUnit);	
				},
				delegate {
					return EnemyUnit.grade >= 2 && (EnemyUnit.pos == fieldPositions.ENEMY_FRONT_LEFT || EnemyUnit.pos == fieldPositions.ENEMY_FRONT_RIGHT);
				},
				delegate {
					
				});
			});
		});
	}
	
	void BlasterBladeSpirit_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Fantasy Petal Storm, Shirayuki 
	void FantasyPetalStormShirayuki_Auto(CardState cs)
	{
		if(cs == CardState.BeingAttacked)
		{
			if(VC () && LB (4) && CB (1) && Game.playerHand.GetByID(CardIdentifier.FANTASY_PETAL_STORM__SHIRAYUKI) != null)
			{
				DisplayConfirmationWindow();
			}
		}	
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	
	void FantasyPetalStormShirayuki_Active()
	{
		ShowAndDelay();	
	}
	
	void FantasyPetalStormShirayuki_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectInHand(1, true,
				delegate {
					DiscardSelectedCard();	
				},
				delegate {
					return _SIH_Card.cardID == CardIdentifier.FANTASY_PETAL_STORM__SHIRAYUKI;	
				},
				delegate {
					IncreaseEnemyPowerByBattle(GetAttacker(), -20000);
				}, "Choose a card named \"Fantasy Petal Storm, Shirayuki\" from your hand.");
			});
		});
	}
	
	void FantasyPetalStormShirayuki_Pointer()
	{
		CounterBlast_Pointer();	
		SelectInHand_Pointer();
	}
	#endregion
	
	#region Evil-eye Princess, Euryale 
	void EvileyePrincessEuryale_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(Game.field.GetUnitsSoulWithClanName("Oracle Think Tank") >= 6 &&
				Game.enemyHand.Size() > 0)
			{
				ShowAndDelay();
			}
		}
	}
	
	void EvileyePrincessEuryale_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose a card from your opponent hand.");	
		});
	}
	
	void EvileyePrincessEuryale_Pointer()
	{	
		if(AcceptInput())
		{
			Card c = Game.LastEnemyHandSelected;
			if(c != null && c._HandleEnemyMouse.mouseOn)
			{
				//c.unitAbilities.AddExternAuto(EvileyePrincessEuryale_AutoExtern);
				EnemyReturnToHandFromBindEndTurn(c);
				BindEnemyCardFromHand(c);	
				ClearPointer();
			}
		}
	}
	/*
	void EvileyePrincessEuryale_AutoExtern(CardState cs)
	{
		if(cs == CardState.EnemyEndTurn)
		{
			Debug.Log("EnemyEndTurn State");
			_AuxCard.unitAbilities.FromBindToHand(_AuxCard);
			//Game.bEndEvent = true;
		}
	}
	*/
	#endregion
	
	#region Hope Child, Turiel 
	void HopeChildTuriel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Angel Feather");	
		}
	}
	
	void HopeChildTuriel_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	void HopeChildTuriel_Update()
	{
		Forerunner_Update();
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			CounterBlast(1,
			delegate {
				SelectInHand(1, false,
				delegate {
					FromHandToDamage(_SIH_Card);
				},
				delegate {
					return _SIH_Card.clan == "Angel Feather";
				},
				delegate {
					SelectInDamage(1, true,
					delegate {
						FromDamageToHand(_SID_Card);	
					});
				}, "Choose an Angel Feather from your hand.");
			});
		});
	}
	
	void HopeChildTuriel_Pointer()
	{
		CounterBlast_Pointer();	
		SelectInHand_Pointer();
		SelectInDamage_Pointer();
	}
	
	int HopeChildTuriel_Field()
	{
		if(VanguardIs("Angel Feather") && CB (1) && RC () && HandSize("Angel Feather") > 0)
		{
			return 1;
		}
		
		return 0;	
	}
	#endregion
	
	#region Spiked Club Stealth Rogue, Arahabaki 
	void SpikedClubStealthRogueArahabaki_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.IsBoosted)
		{
			Card c = OwnerCard.IsBoostedBy;
			if(c != null && c.BelongsToClan("Murakumo"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	#endregion
	
	#region Frontline Valkyrie, Laurel 
	void FrontlineValkyrieLaurel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() &&
				GetVanguard().clan == "Neo Nectar")
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Hey Yo Pineapple 
	void HeyYoPineapple_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetNumberOfCardsWithClanName("Neo Nectar") >= 4)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Lord of the Demonic Winds, Vayu 
	void LordoftheDemonicWindsVayu_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{	
			if(VC () && CB (1))
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	void LordoftheDemonicWindsVayu_Active()
	{
		ShowAndDelay();	
	}
	
	void LordoftheDemonicWindsVayu_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByBattle(OwnerCard, NumRG(delegate(Card c) { return c.cardID == CardIdentifier.LORD_OF_THE_DEMONIC_WINDS__VAYU; }) * 10000);
				EndEffect();
				ConfirmAttack();
			});
		});
	}
	
	void LordoftheDemonicWindsVayu_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	void EnemyReturnToHandFromBindEndTurn(Card c)
	{
		Game.SendPacket(GameAction.CARDSTATE_FROM_BIND_TO_HAND_END_TURN, Game.enemyHand.GetIndex (c));	
	}
	
	public void FromBindToHand(Card c)
	{
		Game.field.RemoveFromBindZone(c);
		Game.playerHand.AddToHand(c);
		ShowCardInHand(c);
		Game.SendPacket(GameAction.FROM_BIND_TO_HAND);
	}
	
	void BindEnemyCardFromHand(Card c)
	{
		Game.EnemyBindHand(c);
		Game.SendPacket(GameAction.BIND_HAND, Game.enemyHand.GetIndex (c));
	}
	
	#region Cat Butler
	public void CatButler_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackNotHit_NotMe)
		{
			if(!OwnerCard.IsVanguard() && GetVanguard().grade <= 2 && GetVanguard().clan == "Nova Grappler")
			{
				if(GetAttacker().IsVanguard())
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void CatButler_Active()
	{
		StartEffect();
		ShowOnScreen();
		Delay(1);
	}
	
	public void CatButler_Update()
	{
		DelayUpdate(delegate {
			RetireUnit(OwnerCard);
			StandUnit(GetVanguard());	
			EndEffect();
		});
	}
	#endregion
	
	#region Platinum Ace
	void PlatinumAce_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(OwnerCard.IsVanguard() && RealPower(OwnerCard) >= 13000)
			{
				IncreaseCriticalByBattle(OwnerCard, 1);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	/*
	 * [AUTO](RC):[Choose a card from your hand, and discard it] When an attack hits during the battle that this unit boosted, you may pay the cost. If you do, draw a card.
	 * */
	
	#region Battle Siren, Cynthia 
	void BattleSirenCynthia_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null && c == GetAttacker() && HandSize() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void BattleSirenCynthia_Active()
	{
		ShowAndDelay();	
	}
	
	void BattleSirenCynthia_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();	
			},
			delegate {
				return true;	
			},
			delegate {
				DrawCardWithoutDelay();	
			}, "Choose a card from your hand.");
		});
	}
	
	void BattleSirenCynthia_Pointer()
	{
		SelectInHand_Pointer();	
	}
	#endregion
	
	#region Battle Siren, Dorothea 
	void BattleSirenDorothea_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.IsVanguard() && c.clan == "Aqua Force" && Game.numBattle >= 3)
			{
				IncreasePowerByBattle(c, 4000);	
			}
		}
	}
	#endregion
	
	#region Hula Hoop Capybara  
	void HulaHoopCapybara_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetAttacker() == OwnerCard.boostedUnit &&
			   Game.playerHand.Size() > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void HulaHoopCapybara_Active()
	{
		ShowAndDelay();	
	}
	
	void HulaHoopCapybara_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose a card from your hand.");	
		});
	}
	
	void HulaHoopCapybara_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn)
			{
				DiscardSelectedCard();
				DisableMouse();
				ClearMessage();
				DrawCardWithoutDelay();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Navy Dolphin, Amur 
	void NavyDolphinAmur_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetAttacker() == OwnerCard.boostedUnit &&
			   Game.playerHand.Size() > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void NavyDolphinAmur_Active()
	{
		ShowAndDelay();	
	}
	
	void NavyDolphinAmur_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose a card from your hand.");	
		});
	}
	
	void NavyDolphinAmur_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn)
			{
				DiscardSelectedCard();
				DisableMouse();
				ClearMessage();
				DrawCardWithoutDelay();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Sword Magician, Sarah 
	void SwordMagicianSarah_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DriveCheck)
		{
			if(Game.DriveCard.clan == "Pale Moon" && Game.DriveCard.grade == 3 && VC() && Game.field.GetNumberOfRearWithClanNameAndGradeGreaterOrEqual("Pale Moon", 3) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			if(VC ())
			{
				Card c = OwnerCard.IsBoostedBy;
				if(c.clan == "Pale Moon")
				{
					IncreasePowerByBattle(OwnerCard, 3000);	
				}
			}
		}
	}
	
	void SwordMagicianSarah_Active()
	{
		ShowAndDelay();	
	}
	
	void SwordMagicianSarah_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one grade 3 Pale Moon rear-guard.", 1, false, 
				delegate { MoveToSoul(Unit); }, delegate { return Unit.clan == "Pale Moon" && Unit.grade >= 3; }, 
				delegate { SetBool(1); Game.field.ViewSoul(1, delegate(Card c) { return c.clan == "Pale Moon"; });});
		});
		
		if(GetBool(1))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(1);
				CallFromSoul(Game.field.GetSoulByID(Game.field.GetLastSelectedList()[0]));
			}
		}
		
		CallFromSoulUpdate(delegate { EndEffect(); });
	}
	
	void SwordMagicianSarah_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Fire Breeze, Carrie 
	void FireBreezeCarrie_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(VanguardIs("Pale Moon") && CB (2))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void FireBreezeCarrie_Active()
	{
		ShowAndDelay();
	}
	
	void FireBreezeCarrie_Update()
	{
		DelayUpdate (delegate { CounterBlast(2,	delegate {DrawCardWithoutDelay(); EndEffect();});});
	}
	
	void FireBreezeCarrie_Pointer()
	{
		CounterBlast_Pointer();
	}
	#endregion
	
	#region Darkness Maiden, Macha 
	void DarknessMaidenMacha_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Shadow Paladin" &&
				CheckCounterBlast(2) &&
				Game.playerDeck.GetNumGradeLessOrEqual(1) > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void DarknessMaidenMacha_Active()
	{
		FlipCardInDamageZone(2);
		ShowAndDelay();
	}
	
	void DarknessMaidenMacha_Update()
	{
		DelayUpdate(delegate {
			Game.playerDeck.ViewDeck("Shadow Paladin", 1);	
			DisplayHelpMessage("Search for up to one grade 1 or less Shadow Paladin.");
			SetBool(1);
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				Card c = Game.playerDeck.SearchForID(Game.playerDeck.GetLastSelectedList()[0]);
				Game.playerDeck.RemoveFromDeck(c);
				Game.CallFromDeck_SameColum(c, OwnerCard.pos);
				ClearMessage();
				SetBool(2);
			}
		}
	
		if(GetBool(2))
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				
				UnsetBool(2);
				ShuffleDeck();
				EndEffect();
			}
			else
			{	
				Game.HandleCallFromDeck();
			}
		}
	}
	#endregion
	
	#region Skull Witch, Nemain 
	void SkullWitchNemain_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}	
		else if(cs == CardState.Call)
		{
			if(CheckCounterBlast(1) &&
				Game.playerHand.GetNumberOfCardsWithClanName("Shadow Paladin") > 0 &&
				GetVanguard().clan == "Shadow Paladin")
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void SkullWitchNemain_Active()
	{
		FlipCardInDamageZone(1);
		ShowAndDelay();
	}
	
	void SkullWitchNemain_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose a Shadow Paladin card from your hand.");	
		});
		
		DrawCardUpdate(delegate {
			EndEffect();	
		});
	}	
	
	void SkullWitchNemain_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn && c.clan == "Shadow Paladin")
			{
				DiscardSelectedCard();
				DisableMouse();
				ClearMessage();
				DrawCard(2);
			}
		}
	}
	#endregion
	
	#region Stealth Beast, White Mane 
	void StealthBeastWhiteMane_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard())
			{
				if(GetVanguard().clan == "Murakumo")
				{
					UnflipCardInDamageZone(1);	
				}
			}
		}
	}
	#endregion
	
	#region Watering Elf 
	int WateringElf_Field()
	{
		return 1;	
	}
	
	void WateringElf_Active()
	{
		StartEffect();
		ShowAndDelay();	
	}
	
	void WateringElf_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			EnableMouse("Choose one of your Neo Nectar units.");
		});
	}
	
	void WateringElf_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Neo Nectar")
				{
					IncreasePowerByTurn(c, 3000);
					ClearPointer();
				}
			}
		}
	}
	#endregion
	
	#region Girl Who Crossed the Gap 
	void GirlWhoCrossedtheGap_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Pale Moon");	
		}
	}
	
	void GirlWhoCrossedtheGap_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	void GirlWhoCrossedtheGap_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			CounterBlast(1,
			delegate {
				if(VanguardIs("Pale Moon") && Game.field.CountSoul(delegate(Card c) { return c.cardID != CardIdentifier.GIRL_WHO_CROSSED_THE_GAP; }) > 0)
				{
					Game.field.ViewSoul(1, delegate(Card c) { return c.cardID != CardIdentifier.GIRL_WHO_CROSSED_THE_GAP; });
					SetBool(2);
				}
			});
		});
		
		if(GetBool(2))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(2);
				_AuxIdVector = Game.field.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));
				}
				else
				{
					EndEffect();	
				}
			}
		}
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	
	int GirlWhoCrossedtheGap_Field()
	{
		if(CB (1) && RC())
		{
			return 1;	
		}
		
		return 0;
	}
	
	void GirlWhoCrossedtheGap_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Jumping Glenn 
	void JumpingGlenn_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.CallFromSoul)
		{
			if(GetVanguard().clan == "Pale Moon")
			{
				IncreasePowerByTurn(OwnerCard, 3000);	
			}
		}
	}
	#endregion
	
	#region Speedster 
	void Speedster_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(GetNumUnits("Dimension Police") >= 2)
			{	
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void Speedster_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your \"Dimension Police\" units.", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 2000);	
			},
			delegate {
				return Unit.clan == "Dimension Police" && Unit != OwnerCard;
			},
			delegate {
				
			}, true);
		});
	}
	
	void Speedster_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion	
	
	#region Arboros Dragon, Ratoon 
	void ArborosDragonRatoon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.ARBOROS_DRAGON__BRANCH)
			{
				StartEffect();
				ShowAndDelay();
			}
			else if(GetVanguard().clan == "Neo Nectar")
			{
				Forerunner("Neo Nectar");	
			}
		}
	}
	
	void ArborosDragonRatoon_Active()
	{
		Forerunner_Active();	
	}
	
	void ArborosDragonRatoon_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			int m = min (7, Game.playerDeck.Size());
			Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, m, delegate(Game2DCard c) { return c._CardInfo.cardID == CardIdentifier.ARBOROS_DRAGON__SEPHIROT || c._CardInfo.cardID == CardIdentifier.ARBOROS_DRAGON__TIMBER;});
			SetBool(1);
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					FromDeckToHand(_AuxIdVector[0]);
					ShuffleDeck();
					EndEffect();
				}
				else
				{
					EndEffect();	
				}
			}
		}
	}
	#endregion
		
	#region Silver Spear Demon, Gusion 
	int SilverSpearDemonGusion_Field()
	{
		if(CheckCounterBlast(2))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void SilverSpearDemonGusion_Active()
	{
		ShowAndDelay();
		StartEffect();
		FlipCardInDamageZone(2);
	}
	
	void SilverSpearDemonGusion_Update()
	{	
		DelayUpdate(delegate {
			IncreasePowerByTurn(OwnerCard, 4000);	
		});
	}
	#endregion
	/// @endcond
	
	/// @cond
	#region Garnet Dragon, Flash 
	void GarnetDragonFlash_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{	
			if(GetDefensor().IsVanguard())
			{
				StartEffect();
				ShowAndDelay();	
			}
		}
	}
	
	void GarnetDragonFlash_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your Kagero units.");	
		});
	}
	
	void GarnetDragonFlash_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsPlayerPosition(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Kagero")
				{
					IncreasePowerByTurn(c, 3000);
					ClearPointer();
					Game.bBlockMouseOnce = true;
				}
			}
		}
	}
	#endregion
	
	#region Evil Eye Basilisk 
	void EvilEyeBasilisk_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && VanguardIs("Dark Irregulars"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	int RealPower(Card c)
	{
		return c.GetPower();
		/*
		int boostedPower = 0;
		if(c.IsBoostedBy != null)
		{
			boostedPower += c.IsBoostedBy.GetPower();	
		}
		
		return c.GetPower() - boostedPower - ModifyRealPower;
		*/
	}
	
	#region Knight of Harvest, Gene 
	void KnightofHarvestGene_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() &&
				GetVanguard().clan == "Neo Nectar" &&
				!OwnerCard.IsVanguard() &&
				Game.playerDeck.SearchForID(CardIdentifier.KNIGHT_OF_VERDURE__GENE) != null)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void KnightofHarvestGene_Active()
	{
		ShowAndDelay();	
	}
	
	void KnightofHarvestGene_Update()
	{
		DelayUpdate(delegate {
			FromFieldToDeck(OwnerCard);
			SetBool(1);
			Game.playerDeck.ViewDeck(2, CardIdentifier.KNIGHT_OF_VERDURE__GENE);
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromDeckUpdate(delegate {
			for(int i = 0; i < CallFromDeckList.Count; i++)
			{
				RestUnit(CallFromDeckList[i]);	
			}
			ShuffleDeck();
			EndEffect();	
		});
	}
	#endregion 
	
	#region Knight of Verdure, Gene 
	void KnightofVerdureGene_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() &&
				GetVanguard().clan == "Neo Nectar" &&
				!OwnerCard.IsVanguard() &&
				Game.playerDeck.SearchForID(CardIdentifier.KNIGHT_OF_HARVEST__GENE) != null)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void KnightofVerdureGene_Active()
	{
		ShowAndDelay();	
	}
	
	void KnightofVerdureGene_Update()
	{
		DelayUpdate(delegate {
			FromFieldToDeck(OwnerCard);
			SetBool(1);
			Game.playerDeck.ViewDeck(1, CardIdentifier.KNIGHT_OF_HARVEST__GENE);
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromDeckUpdate(delegate {
			for(int i = 0; i < CallFromDeckList.Count; i++)
			{
				RestUnit(CallFromDeckList[i]);	
			}
			ShuffleDeck();
			EndEffect();	
		});
	}
	#endregion
	
	#region Blade Seed Squire  
	void BladeSeedSquire_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() &&
				GetVanguard().clan == "Neo Nectar" &&
				!OwnerCard.IsVanguard() &&
				Game.playerDeck.SearchForID(CardIdentifier.KNIGHT_OF_VERDURE__GENE) != null)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void BladeSeedSquire_Active()
	{
		ShowAndDelay();	
	}
	
	void BladeSeedSquire_Update()
	{
		DelayUpdate(delegate {
			FromFieldToDeck(OwnerCard);
			SetBool(1);
			Game.playerDeck.ViewDeck(1, CardIdentifier.KNIGHT_OF_VERDURE__GENE);
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromDeckUpdate(delegate {
			for(int i = 0; i < CallFromDeckList.Count; i++)
			{
				RestUnit(CallFromDeckList[i]);	
			}
			ShuffleDeck();
			EndEffect();	
		});
	}
	#endregion
	
	#region Titan of the Pyroxene Mine 
	void TitanofthePyroxeneMine_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			if(OwnerCard.IsBoostedBy.clan == "Aqua Force")
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}	
		}
	}
	#endregion
	
	#region Platinum Blond Fox Spirit, Tamamo 
	void PlatinumBlondFoxSpiritTamamo_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && LB (4) && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
			
			ConfirmAttack();
		}
	}
	
	int PlatinumBlondFoxSpiritTamamo_Field()
	{
		if(VC () && CB (1) && NumRG(delegate(Card c) { return c.grade >= 2 && c.BelongsToClan("Murakumo"); }) > 0)
		{
			return 1;
		}
		
		return 0;
	}
	
	void PlatinumBlondFoxSpiritTamamo_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void PlatinumBlondFoxSpiritTamamo_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit("Choose one of your grade 2 Murakumo rear-guards.", 1, false,
				delegate {
					SelectAnimField(Unit);
					SetBool(1);
					Game.playerDeck.ViewDeck(1, delegate(Game2DCard c) {
						return c._CardInfo.name == Unit.name;	
					});
				},
				delegate {
					return Unit.BelongsToClan("Murakumo") && Unit.grade >= 2;	
				},
				delegate {
					
				});
			});
		});
		
		if(GetBool(1) && !Game.playerDeck.IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = Game.playerDeck.GetLastSelectedList();
			if(_AuxIdVector.Count  > 0)
			{
				CallFromDeck(_AuxIdVector);	
			}
			else
			{
				EndEffect();	
			}
		}
		
		CallFromDeckUpdate(delegate {
			Card tmpCard = CallFromDeckList[0];
			tmpCard.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
				if(s == CardState.EndTurn)
				{
					FromFieldToDeck(tmpCard, true);	
				}
			});
			EndEffect();
		});
	}
	
	void PlatinumBlondFoxSpiritTamamo_Pointer()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer();
	}
	#endregion
	
	#region Distant Sea Advisor, Vassilis 
	void DistantSeaAdvisorVassilis_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.AttackHits)
		{
			if(VanguardIs("Aqua Force"))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void DistantSeaAdvisorVassilis_Active()
	{
		ShowAndDelay();	
	}
	
	void DistantSeaAdvisorVassilis_Update()
	{
		DelayUpdate (delegate {
			SelectInHand(1, true, delegate { DiscardSelectedCard(); }, delegate { return true; }, delegate { DrawCardWithoutDelay(); }, "Choose a card from your hand.");	
		});	
	}
	
	void DistantSeaAdvisorVassilis_Pointer()
	{
		SelectInHand_Pointer();	
	}
	#endregion
	
	#region Battle Sister, Souffle 
	void BattleSisterSouffle_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.IsBoosted)
		{
			Card c = OwnerCard.IsBoostedBy;
			if(c.clan == "Oracle Think Tank")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	#endregion
	
	#region Caped Stealth Rogue, Shanaou  
	void CapedStealthRogueShanaou_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(!OwnerCard.IsVanguard())
			{
				if(GetDefensor().IsVanguard() &&
					GetVanguard().clan == "Murakumo")
				{
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	void CapedStealthRogueShanaou_Active()
	{
		ShowAndDelay();	
	}
	
	void CapedStealthRogueShanaou_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region John the Ghostie 
	void JohntheGhostie_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackNotHit_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null && GetAttacker() == c && c.clan == "Granblue")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void JohntheGhostie_Active()
	{
		ShowAndDelay();	
	}
	
	void JohntheGhostie_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Stealth Fighter 
	void StealthFighter_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackNotHit_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(HitsVanguard() && c != null && GetAttacker() == c && c.clan == "Narukami")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void StealthFighter_Active()
	{
		ShowAndDelay();	
	}
	
	void StealthFighter_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Pinky Piggy 
	void PinkyPiggy_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackNotHit_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(HitsVanguard() && c != null && GetAttacker() == c && c.clan == "Pale Moon")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void PinkyPiggy_Active()
	{
		ShowAndDelay();	
	}
	
	void PinkyPiggy_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Moonsault Swallow 
	void MoonsaultSwallow_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackNotHit_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(HitsVanguard() && c != null && GetAttacker() == c && c.clan == "Oracle Think Tank")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void MoonsaultSwallow_Active()
	{
		ShowAndDelay();	
	}
	
	void MoonsaultSwallow_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Mirage Maker  
	void MirageMaker_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackNotHit_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(HitsVanguard() && c != null && GetAttacker() == c && c.clan == "Dark Irregulars")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void MirageMaker_Active()
	{
		ShowAndDelay();	
	}
	
	void MirageMaker_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Lizard Soldier, Yowsh  
	void LizardSoldierYowsh_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 1 && VanguardIs("Narukami"))
			{
				DisplayConfirmationWindow();	
			}
			else 
			{
				ConfirmAttack();	
			}
		}
	}
	
	void LizardSoldierYowsh_Active()
	{
		ShowAndDelay();	
	}
	
	void LizardSoldierYowsh_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 3000);	
			EndEffect();
			ConfirmAttack();
		});
	}
	#endregion
	
	#region Waving Owl 
	void WavingOwl_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackNotHit_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null && GetAttacker() == c && c.clan == "Gold Paladin")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void WavingOwl_Active()
	{
		ShowAndDelay();	
	}
	
	void WavingOwl_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	/*
	 * [AUTO](VC/RC): When this unit attacks, if the number of cards in your hand is greater than your opponent's, this unit gets [Power]+3000 until end of that battle.
	 * */
	
	#region Greed Shade 
	void GreedShade_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.playerHand.Size() > Game.enemyHand.Size())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	/*
	 * [AUTO](RC):When this unit attacks, if you have a vanguard with "Dimensional Robo" in its card name, this unit gets [Power]+3000 until end of that battle.
	 */
	#region Dimensional Robo, Daidragon 
	void DimensionalRoboDaidragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetVanguard().name.Contains("Dimensional Robo") && RC ())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Water Lily Musketeer, Ruth 
	void WaterLilyMusketeerRuth_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetVanguard().name.Contains("Musketeer") && RC ())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Cherry Blossom Musketeer, Augusto 
	void CherryBlossomMusketeerAugusto_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetVanguard().name.Contains("Musketeer") && RC ())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	/*
	 * AUTO [R]: When an attack hits a vanguard during the battle that this unit boosted a «Nova Grappler», you may return this unit to your hand.
	 * */
	
	#region Almighty Reporter  
	void AlmightyReporter_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(HitsVanguard() && c != null && GetAttacker() == c && c.clan == "Nova Grappler")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void AlmightyReporter_Active()
	{
		ShowAndDelay();	
	}
	
	void AlmightyReporter_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Stream Trooper 
	void StreamTrooper_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(HitsVanguard() && c != null && GetAttacker() == c && c.clan == "Aqua Force")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void StreamTrooper_Active()
	{
		ShowAndDelay();	
	}
	
	void StreamTrooper_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Element Glider   
	void ElementGlider_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackNotHit_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(HitsVanguard() && c != null && GetAttacker() == c && c.clan == "Great Nature")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void ElementGlider_Active()
	{
		ShowAndDelay();	
	}
	
	void ElementGlider_Update()
	{
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Little Battler, Tron 
	void LittleBattlerTron_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.clan == "Gold Paladin" && c.IsVanguard() && Game.field.GetNumberOfRear() > Game.enemyField.GetNumberOfRearUnits())
			{	
				IncreasePowerByBattle(c, 4000);
			}
		}
	}
	#endregion
	
	#region Grapple Mania 
	void GrappleMania_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null)
			{
				if(GetDefensor().IsVanguard() &&
					GetAttacker() == c &&
					c.clan == "Nova Grappler" &&
					Game.field.GetNumberOfDamageCardsFacedown() > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
		else if(cs == CardState.EndTurn)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				FromFieldToDeck(OwnerCard);
				ShuffleDeck();
			}
		}
	}
	
	void GrappleMania_Active()
	{
		ShowAndDelay();	
	}
	
	void GrappleMania_Update()
	{	
		DelayUpdate(delegate {
			UnflipCardInDamageZone(1);
			SetBool(1);
			EndEffect();
		});
	}
	#endregion
	
	#region Flame Seed Salamander
	void FlameSeedSalamander_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null)
			{
				if(GetDefensor().IsVanguard() &&
					GetAttacker() == c &&
					c.clan == "Kagero" &&
					Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(0) > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
		else if(cs == CardState.EndTurn)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				FromFieldToDeck(OwnerCard);
				ShuffleDeck();
			}
		}
	}
	
	void FlameSeedSalamander_Active()
	{
		ShowAndDelay();	
	}
	
	void FlameSeedSalamander_Update()
	{	
		DelayUpdate(delegate {
			SetBool(1);
			EnableMouse("Choose one of you opponent grade 0 rear-guards.");
		});
	}
	
	void FlameSeedSalamander_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null && c.grade == 0)
				{
					RetireEnemyUnit(c);
					ClearPointer();
				}
			}
		}
	}
	#endregion

	#region Lizard Soldier, Raopia 
	void LizardSoldierRaopia_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.IsVanguard() &&
				OwnerCard.boostedUnit.clan == "Kagero" &&
				Game.enemyField.GetNumberOfRearUnits() <= 2)
			{
				IncreasePowerByBattle(OwnerCard.boostedUnit, 4000);
			}
		}
	}
	#endregion
	
	#region Mermaid Idol, Felucca 
	void MermaidIdolFelucca_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Bermuda Triangle" && Game.playerDeck.Size() > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void MermaidIdolFelucca_Active()
	{
		ShowAndDelay();	
	}
	
	void MermaidIdolFelucca_Update()
	{
		DelayUpdate(delegate {
			SoulCharge(1);	
		});
		
		SoulChargeUpdate(delegate {
			EndEffect();
		});
	}
	#endregion
	
	#region Prism on the Water, Myrtoa 
	void PrismontheWaterMyrtoa_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Bermuda Triangle")
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.AuxState)
		{
			StartEffect();
			DisplayOpponentWindow("Do you want to draw a card?");	
		}
	}
	
	void PrismontheWaterMyrtoa_Active()
	{
		DrawCardWithoutDelay();
		EndEffect();
		Game._AbilityManager.AddAbility(CardState.AuxState, OwnerCard);
	}
	
	void PrismontheWaterMyrtoa_Update()
	{
		DelayUpdate(delegate {
			DisplayConfirmationWindow();
		});
	}
	
	void PrismontheWaterMyrtoa_OnAccept()
	{
		OpponentDrawCard();
	}
	
	void PrismontheWaterMyrtoa_OnCancel()
	{
		EndEffect();
		Game.SendAction(GameAction.END_EVENT);
	}
	
	bool PrismontheWaterMyrtoa_OnWindowCancel()
	{
		Game._AbilityManager.AddAbility(CardState.AuxState, OwnerCard);
		return true;
	}
	#endregion
	
	#region Dark Cat 
	void DarkCat_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Oracle Think Tank")
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.AuxState)
		{
			StartEffect();
			DisplayOpponentWindow("Do you want to draw a card?");	
		}
	}
	
	void DarkCat_Active()
	{
		DrawCardWithoutDelay();
		EndEffect();
		Game._AbilityManager.AddAbility(CardState.AuxState, OwnerCard);
	}
	
	void DarkCat_Update()
	{
		DelayUpdate(delegate {
			DisplayConfirmationWindow();
		});
	}
	
	void DarkCat_OnAccept()
	{
		OpponentDrawCard();
	}
	
	void DarkCat_OnCancel()
	{
		EndEffect();
		Game.SendAction(GameAction.END_EVENT);
	}
	
	bool DarkCat_OnWindowCancel()
	{
		Game._AbilityManager.AddAbility(CardState.AuxState, OwnerCard);
		return true;
	}
	#endregion
	
	#region Jumping Jill
	public void Jumping_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.CallFromSoul)
		{
			if(GetVanguard().clan == "Pale Moon")
			{
				IncreasePowerByTurn(OwnerCard, 3000);	
			}
		}
	}
	#endregion
	
	#region Sword Dancer Angel 
	void SwordDancerAngel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Draw)
		{
			IncreasePowerByTurn(OwnerCard, 1000);	
		}
	}
	#endregion
	
	#region Spirit Exceed
	public int SpiritExceed_Drop()
	{
		if(Game.field.GetRearCardByID(CardIdentifier.SAMURAI_SPIRIT) != null && Game.field.GetRearCardByID(CardIdentifier.KNIGHT_SPIRIT) != null)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).grade >= 2)
			{
				return 1;	
			}
		}
		
		return 0;
	}
	
	public void SpiritExceed_Active()
	{
		Game.bEffectOnGoing = true;
		Game.field.CloseDeck();
		ShowOnScreen(OwnerCard);
		_AuxInt = 2;
		EnableMouse();
		DisplayHelpMessage("Choose a Samurai Spirit unit and move it to your soul.");
	}
	
	public void SpiritExceed_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions pos = Util.GetMousePosition();
			if(!Util.IsEnemyPosition(pos) && pos != fieldPositions.VANGUARD_CIRCLE)
			{
				Card tmp = Game.field.GetCardAt(pos);
				if(tmp != null)
				{
					if(_AuxInt == 2)
					{
						if(tmp.cardID == CardIdentifier.SAMURAI_SPIRIT)
						{
							MoveToSoul(tmp);
							_AuxInt = 1;
							DisplayHelpMessage("Choose a Knight Spirit unit and move it to your soul.");
						}
					}
					else if(_AuxInt == 1)
					{
						if(tmp.cardID == CardIdentifier.KNIGHT_SPIRIT)
						{
							MoveToSoul(tmp);
							_AuxInt = 0;
						}
					}
					
					if(_AuxInt == 0)
					{
						RideFromDropZone(OwnerCard);
						DisableMouse();
						ClearMessage();
						Game.bEffectOnGoing = false;
					}
				}
			}
		}
	}
	#endregion
	
	#region Alluring Succubus
	public void Alluring_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Call || s == CardState.Ride)
		{
			if(GetVanguard().clan == "Dark Irregulars" && Game.playerDeck.Size() > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void Alluring_Active()
	{
		ShowOnScreen();
		Delay (1);
	}
	
	public void Alluring_Update()
	{
		DelayUpdate(delegate {
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	
	#region Faithful Angel
	public void FaithfulAngel_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			if(Game.field.GetUnitsSoulWithClanName("Oracle Think Tank") >= 6)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public void FaithfulAngel_Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EnableMouse("Select a card from your hand.");
		});
	}
	
	public void FaithfulAngel_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn)
			{
				ReturnCardFromHandToDeck(true, false);
				DisableMouse();
				EndEffect();
				ConfirmAttack();
			}
		}
	}
	#endregion
	
	#region Toolkit Boy
	void ToolkitBoy_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			if(GetDefensor().IsVanguard() &&
				OwnerCard.boostedUnit != null &&
				OwnerCard.boostedUnit == GetAttacker())
			{
				ShowAndDelay();
				StartEffect();
			}
		}
	}
	
	void ToolkitBoy_Update()
	{
		DelayUpdate(delegate {
			UnflipCardInDamageZone(1);
			EndEffect();
		});
	}
	#endregion
	
	#region Machining Mantis
	public void Mantis_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Call || s == CardState.Ride)
		{	
			if(Game.field.SoulNameContains("Machining") > 0)
			{
				IncreasePowerByTurn(OwnerCard, 3000);	
			}
		}
	}
	#endregion
	
	#region Ruin Shade
	public void RuinShade_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Granblue" && Game.playerDeck.Size() >= 2)
			{
				Game.bEffectOnGoing = true;
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public void RuinShade_Active()
	{
		_AuxInt = 2;
		_AuxCard2 = null;
		ShowOnScreen(OwnerCard);
		_AuxCard = OwnerCard;
		IncreasePowerByBattle(2000);
		_AuxBool = true;
	}	
	
	public void RuinShade_Update()
	{
		if(_AuxBool)
		{
			if(_AuxInt > 0)
			{
				if(_AuxCard2 == null || !_AuxCard2.AnimationOngoing())
				{
					_AuxCard2 = SendCardFromDeckToDrop();
					_AuxInt--;
				}
			}
			else
			{
				Game.bEffectOnGoing = false;
				_AuxBool = false;
				_AuxCard2 = null;
				ConfirmAttack();
			}
		}
	}
	#endregion
	
	#region Water Gang 
	void WaterGang_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(CheckCounterBlast(2) &&
				GetVanguard().clan == "Megacolony")
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void WaterGang_Active()
	{
		ShowAndDelay();
		FlipCardInDamageZone(2);
	}
	
	void WaterGang_Update()
	{	
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Silence Joker
	public int SilenceJoker_Field()
	{
		if(GetVanguard().clan == "Spike Brothers" && Game.field.GetNumberOfDamageCardsFacedown() >= 1 && !OwnerCard.IsVanguard())
		{
			return 1;	
		}
		
		return 0;
	}
	
	public void SilenceJoker_Active()
	{
		ShowOnScreen(OwnerCard);
		MoveToSoul(OwnerCard);
		UnflipCardInDamageZone(1);
	}
	#endregion
	
	#region Gold Rutile
	public void GoldRutile_Auto(CardState cs, Card card)
	{
		if(cs == CardState.AttackHits)
		{
			if(card.IsVanguard())
			{				
				if(GetDefensor().IsVanguard())	
				{
					if(Game.field.GetNumberOfUnitRested() > 1 && Game.field.GetNumberOfCardsWithClanName("Nova Grappler") > 1)
					{
						if(Game.field.GetNumberOfDamageCardsFaceup() >= 2)
						{
							SetCard(card);
							DisplayConfirmationWindow();
						}
					}
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			if(card.IsVanguard())
			{
				if(GetAttacker() != OwnerCard)
				{
					if(GetDefensor().IsVanguard())
					{
						if(Game.field.GetNumberOfDamageCardsFacedown() >= 1)
						{
							ShowOnScreen(card);
							UnflipCardInDamageZone(1);
						}
					}
				}
			}
		}
	}
	
	public void GoldRutile_Active()
	{
		ShowOnScreen(GetCard());
		FlipCardInDamageZone(2);
		EnableMouse();
		DisplayHelpMessage("Select a Nova Grappler Rear-guard unit and Stand it");
	}
	
	public void GoldRutile_HandlePointer()
	{
		if(AcceptInput())
		{
			fieldPositions pos = Util.GetMousePosition();
			if(!Util.IsEnemyPosition(pos))
			{
				Card tmpCard = Game.field.GetCardAt(pos);
				if(!tmpCard.IsVanguard())
				{
					StandUnit(tmpCard);
					DisableMouse();
					ClearMessage();
				}
			}
			
			Game.bBlockMouseOnce = true;
		}
	}
	#endregion
	
	#region Beast Deity, Yamatano Drake 
	void BeastDeityYamatanoDrake_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Stand)
		{
			if(CurrentPhaseIs(GamePhase.ATTACK) && RC ())
			{	
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
	#endregion
	
	#region Beast Deity, Golden Anglet  
	void BeastDeityGoldenAnglet_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Stand)
		{
			if(CurrentPhaseIs(GamePhase.ATTACK) && RC ())
			{	
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
	#endregion
	
	#region Beast Deity, Blank Marsh Beast Deity, Blank Marsh
	void BeastDeityBlankMarsh_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null && c.BelongsToClan("Nova Grappler") && c == GetAttacker() && GetDefensor().IsVanguard() && CB (1) && RC ())
			{
				if(NumRG(delegate(Card ca) { return ca != OwnerCard && ca.IsStand() && ca.name.Contains("Beast Deity"); }) > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void BeastDeityBlankMarsh_Active()
	{
		ShowAndDelay();	
	}
	
	void BeastDeityBlankMarsh_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				SelectUnit("Choose one of your rear-guards with \"Beast Deity\" in its name.", 1, true,
				delegate {
					StandUnit(Unit);	
				},
				delegate {
					return Unit.name.Contains("Beast Deity") && !Unit.IsStand();	
				},
				delegate {
					
				});
			});
		});
	}
	
	void BeastDeityBlankMarsh_Pointer()
	{
		CounterBlast_Pointer();	
		SelectUnit_Pointer();
	}
	#endregion
	
	#region Mobile Hospital, Elysium 
	void MobileHospitalElysium_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(HandSize("Angel Feather") > 0)
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	void MobileHospitalElysium_Active()
	{
		ShowAndDelay();	
	}
	
	void MobileHospitalElysium_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return _SIH_Card.BelongsToClan("Angel Feather");
			},
			delegate {
				if(RC())
				{
					IncreasePowerByBattle(OwnerCard, 3000);	
				}
				else if(VC ())
				{
					IncreasePowerByBattle(OwnerCard, 6000);
				}
			}, "Choose an Angel feather from your hand.");
		});
	}
	
	void MobileHospitalElysium_Pointer()
	{
		SelectInHand_Pointer();	
	}
	#endregion
	
	#region Hollow Nomady 
	void HollowNomady_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && VanguardIs("Nova Grappler"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Lady Bomb
	public void LadyBomb_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 2 && Game.enemyField.GetNumberOfRearUnits() > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void LadyBomb_Active()
	{
		ShowOnScreen(OwnerCard);	
		FlipCardInDamageZone(2);
		DisplayHelpMessage("Choose one of your opponent's rear-guards, and that unit cannot [Stand] during your opponent's next stand phase.");
		EnableMouse();
	}
	
	public void LadyBomb_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null)
				{
					CantStandUntilNextTurn(c);
					ClearMessage();
					DisableMouse();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Spike Brothers Assault Squad
	public void AssaultSquad_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.clan == "Spike Brothers")
			{
				_AuxBool = true;
			}
			else
			{
				_AuxBool = false;	
			}
		}
		if(cs == CardState.AttackHits_NotMe)
		{
			if(_AuxBool)
			{
				_AuxBool = false;
				StandUnit(OwnerCard);
			}
		}
	}
	#endregion
	
	#region Cray Soldier
	public void CraySoldier_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.clan == "Nova Grappler")
			{
				_AuxBool = true;
			}
			else
			{
				_AuxBool = false;	
			}
		}
		if(cs == CardState.AttackHits_NotMe)
		{
			if(_AuxBool)
			{
				_AuxBool = false;
				StandUnit(OwnerCard);
			}
		}
	}
	#endregion
	
	#region Enigman Shine
	void EnigmanShine_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard())
			{
				StartEffect();
				ShowAndDelay();	
			}
		}
	}
	
	void EnigmanShine_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your Dimension Police units.");	
		});
	}
	
	void EnigmanShine_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Dimension Police")
				{
					IncreasePowerByTurn(c, 3000);
					DisableMouse();
					ClearMessage();
					EndEffect();
					Game.bBlockMouseOnce = true;
				}
			}
		}
	}
	#endregion
	
	#region Bermuda Triangle Cadet, Shizuku 
	void BermudaTriangleCadetShizuku_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().clan == "Bermuda Triangle")
			{
				StartEffect();
				DisplayConfirmationWindow();
				SetBool(1);
			}
		}
	}
	
	void BermudaTriangleCadetShizuku_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			ShowAndDelay();
		}
		else
		{
			FlipCardInDamageZone(1);
			ShowAndDelay();
			SetBool(2);
		}
	}
	
	int BermudaTriangleCadetShizuku_Field()
	{
		if(!OwnerCard.IsVanguard() && CheckCounterBlast(1) && Game.playerDeck.Size() >= 5)
		{
			return 1;
		}
		
		return 0;
	}
	
	void BermudaTriangleCadetShizuku_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(2))
			{
				UnsetBool(2);
				MoveToSoul(OwnerCard);
				DisplayHelpMessage("Search for up to one grade 3 Bermuda Triangle.");
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, 5, "");
				SetBool(3);
			}
			else
			{
				CallFromSoul(OwnerCard);	
			}
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
		
		if(GetBool(3))
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{	
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.grade == 3 && c.clan == "Bermuda Triangle")
					{
						FromDeckToHand(_AuxIdVector[0]);
						ShuffleDeck();
						EndEffect();
					}
				}
			}
		}
	}
	#endregion

	#region Silent Tom
	public void SilentTom_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetVanguard().clan == "Oracle Think Tank")
			{
				Game.SendPacket(GameAction.BLOCK_GUARD_END_BATTLE, 0);
				ConfirmAttack();
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	#endregion
	
	#region Rocket Hammer Man
	public int RocketHammer_Field()
	{
		if(Game.field.GetNumberOfRearWithClanName("Nova Grappler") > 0 && !OwnerCard.IsVanguard())
		{
			return 1;	
		}
			
		return 0;
	}
	
	public void RocketHammer_Active()
	{
		ShowOnScreen();
		StartEffect();
		EnableMouse();
		DisplayHelpMessage("Choose one of your Nova Grappler rear-guards.");
		RestUnit(OwnerCard);
	}
	
	public void RocketHammer_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Nova Grappler" && c != OwnerCard)
				{
					IncreasePowerByTurn(c, 2000);
					ClearMessage();
					DisableMouse();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Stealth Millipede 
	void StealthMillipede_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.clan == "Megacolony" &&
				c.IsVanguard() &&
				AllEnemyUnitsRested())
			{
				IncreasePowerByBattle(c, 4000);
			}
		}
	}
	#endregion
	
	#region Twin Swordsman, MUSASHI
	public void Musashi_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetNumberOfRear() > Game.enemyField.GetNumberOfRearUnits())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Clay-doll Mechanic
	public void ClayDollMechanic_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Nova Grappler")
			{
				ShowOnScreen(OwnerCard);
				UnflipCardInDamageZone(1);	
			}
		}
	}
	#endregion
	
	#region Cosmo Roar 
	int CosmoRoar_Field()
	{
		if(!OwnerCard.IsVanguard() &&
			OwnerCard.IsStand())
		{
			return 1;
		}
		
		return 0;
	}
	
	void CosmoRoar_Active()
	{
		RestUnit(OwnerCard);
		ShowAndDelay();	
	}
	
	void CosmoRoar_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose another of your Dimension Police rear-guards.");	
		});
	}
	
	void CosmoRoar_Pointer()
	{
		if(AcceptInput())
		{	
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Dimension Police" && c != OwnerCard)
				{
					IncreasePowerByTurn(c, 2000);
					EndEffect();
					DisableMouse();
					ClearMessage();
				}
			}
		}
	}
	#endregion
	
	#region Evil Shade
	public void EvilShade_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.clan == "Granblue")
			{
				if(Game.playerDeck.Size() > 1)
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void EvilShade_Active()
	{
		ShowOnScreen(OwnerCard);
		SendCardFromDeckToDrop();
		SendCardFromDeckToDrop();
		IncreasePowerByBattle(OwnerCard.boostedUnit, 4000);	
		EndEffect();
	}
	#endregion
	
	#region Scientist Monkey Rue
	public void MonkeyRue_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	
	public int MonkeyRue_Field()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 2)
		{
			if(Game.field.GetNumberOfRearWithClanName("Great Nature") > 0)
			{
				return 1;	
			}
		}
			
		return 0;
	}
	
	public void MonkeyRue_Active()
	{
		StartEffect();
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(2);
		EnableMouse();
		DisplayHelpMessage("Choose one of your Great Nature rear-guards, and that units gets [Power]+4000 until end of turn.");
	}
	
	public void MonkeyRue_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Great Nature")
				{	
					IncreasePowerByTurn(c, 4000);
					c.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
						if(s == CardState.EndTurn)
						{
							c.unitAbilities.RetireUnit(c);	
						}
					});
					ClearPointer();
				}
			}
		}
	}
	#endregion
		
	#region Binoculus Tiger 
	void BinoculusTiger_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetNumAnotherRear("Great Nature") > 0)
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	void BinoculusTiger_Active()
	{
		ShowAndDelay();	
	}
	
	void BinoculusTiger_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Great Nature rear-guards.", 1, true,
						delegate {
							IncreasePowerByTurn(Unit, 4000);
							Unit.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
								if(s == CardState.EndTurn)
								{
									Unit.unitAbilities.RetireUnit(Unit);	
								}
							});
						},
						delegate {
							return Unit.clan == "Great Nature" && Unit != OwnerCard;	
						},
						delegate {
							ConfirmAttack();
						}
			);
		});
	}
	
	void BinoculusTiger_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	int GetNumAnotherRear(string clan)
	{
		int n = 0;
		if(OwnerCard.clan == clan)
		{
			n = 1;	
		}
		
		if(VC ())
		{
			return NumRearGuards(clan);	
		}
		else
		{
			return NumRearGuards(clan) - n;	
		}
		
	}
	
	#region Bloody Calf 
	public void BloodyCalf_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Call || s == CardState.Ride)
		{
			if(CB(2) && GetVanguard().clan == "Dark Irregulars" && Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(1) > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void BloodyCalf_Active()
	{
		ShowAndDelay();	
	}
	
	public void BloodyCalf_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2, delegate {
				EnableMouse("Choose one of your opponent's grade 1 or less rear-guards.");	
			});
		});
	}
	
	public void BloodyCalf_Pointer()
	{
		if(CounterBlast_Pointer()) return;
		
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null && c.grade <= 1)
				{
					RetireEnemyUnit(c);
					DisableMouse();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Oracle Guardian, Blue Eye 
	public void OracleGuardianBlueEye_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();
		}	
		else if(s == CardState.Boost)
		{
			if(Game.field.GetUnitsSoulWithClanName("Oracle Think Tank") >= 6)
			{
				ShowAndDelay();
			}
		}
	}
	
	public void OracleGuardianBlueEye_Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EnableMouse("Choose a card from your hand.");
		});
	}
	
	public void OracleGuardianBlueEye_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(c != null && c._HandleMouse.mouseOn)
			{
				ReturnCardFromHandToDeck(true, false);	
				DisableMouse();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Desert Gunner, Shiden 
	void DesertGunnerShiden_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(GetVanguard().clan == "Narukami" && Game.enemyField.GetNumberOfRearUnits() > 0)
			{
				ShowAndDelay();
				StartEffect();
			}
		}
	}
	
	void DesertGunnerShiden_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your opponent's rear-guards.");
		});
	}
	
	void DesertGunnerShiden_Pointer()
	{	
		SelectEnemyUnit(delegate {
			CantInterceptUntilEndTurn(EnemyUnit);
		});
	}
	#endregion
	
	#region Desert Gunner, Raien 
	void DesertGunnerRaien_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(GetVanguard().clan == "Narukami" && Game.enemyField.GetNumberOfRearUnits() > 0)
			{
				ShowAndDelay();
				StartEffect();
			}
		}
	}
	
	void DesertGunnerRaien_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your opponent's rear-guards.");
		});
	}
	
	void DesertGunnerRaien_Pointer()
	{	
		SelectEnemyUnit(delegate {
			CantInterceptUntilEndTurn(EnemyUnit);
		});
	}
	#endregion	

	#region Photon Bomber Wyvern 
	void PhotonBomberWyvern_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null && c.clan == "Narukami" && c.IsVanguard() && Game.enemyField.GetDamage() >= 3)
			{
				IncreasePowerByBattle(OwnerCard.boostedUnit, 4000);	
			}
		}
	}
	#endregion
	
	#region High Dog Breeder, Akane
	public void BreederAkane_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 2)
			{
				if(Game.playerDeck.GetNumberOfCardsWithClanAndRace("Royal Paladin", "High Beast") > 0)
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void BreederAkane_Active()
	{
		ShowOnScreen(OwnerCard);
		Game.playerDeck.ViewDeck(1, SearchMode.ALL_DECK, "Royal Paladin", "High Beast");
		_AuxBool = true;
		FlipCardInDamageZone(2);
	}
	
	public void BreederAkane_Update()
	{
		if(_AuxBool)
		{
			if(!Game.playerDeck.IsOpen())	
			{
				_AuxBool = false;
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromDeckUpdate(delegate(){
			EndEffect();	
		});
	}
	#endregion
	
	#region Bellicosity Dragon
	public void BellDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetAttacker().IsVanguard())
			{
				if(GetVanguard().clan == "Kagero")
				{
					ShowOnScreen();
					UnflipCardInDamageZone(1);	
				}
			}
		}
	}
	#endregion
	
	#region Death Army Lady 
	public void DeathArmyLady_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.DriveCheck_NotMe)
		{
			if(!OwnerCard.IsVanguard() && Game.DriveCard != null && Game.DriveCard.clan == "Nova Grappler" && Game.DriveCard.grade == 3)
			{
				ShowAndDelay();	
			}
		}
	}
	
	public void DeathArmyLady_Update()
	{
		DelayUpdate(delegate {
			StandUnit(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Death Army Guy
	public void DeathArmyGuy_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.DriveCheck_NotMe)
		{
			if(!OwnerCard.IsVanguard() && Game.DriveCard != null && Game.DriveCard.clan == "Nova Grappler" && Game.DriveCard.grade == 3)
			{
				ShowAndDelay();	
			}
		}
	}
	
	public void DeathArmyGuy_Update()
	{
		DelayUpdate(delegate {
			StandUnit(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Gwynn the Ripper
	public void Ripper_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Call || s == CardState.Ride)
		{
			if(GetVanguard().clan == "Dark Irregulars" && 
			   Game.field.GetNumberOfDamageCardsFaceup() >= 2 &&
			   Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(2) > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void Ripper_Active()
	{
		ShowOnScreen();
		FlipCardInDamageZone(2);
		EnableMouse();
		DisplayHelpMessage("Choose one of your opponent rear-guards.");
	}
	
	public void Ripper_Pointer()
	{	
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null && c.grade <= 2)
				{
					RetireEnemyUnit(c);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Rough Seas Banshee
	public int RoughSeas_Field()
	{
		if(!OwnerCard.IsVanguard())
		{
			if(GetVanguard().clan == "Granblue")
			{
				return 1;	
			}
		}
		
		return 0;
	}
	
	public void RoughSeas_Active()
	{
		ShowOnScreen(OwnerCard);
		MoveToSoul(OwnerCard);
		DrawCard();
	}
	#endregion
	
	#region Psychic Bird
	public int PsychicBird_Field()
	{
		if(!OwnerCard.IsVanguard())
		{
			if(GetVanguard().clan == "Oracle Think Tank")
			{
				return 1;	
			}
		}
		
		return 0;
	}
	
	public void PsychicBird_Active()
	{
		ShowOnScreen(OwnerCard);
		MoveToSoul(OwnerCard);
		DrawCard();
	}
	#endregion
	
	#region Margal
	public int Margal_Field()
	{
		if(!OwnerCard.IsVanguard())
		{
			return 1;	
		}
		
		return 0;
	}
	
	public void Margal_Active()
	{
		StartEffect();
		ShowOnScreen(OwnerCard);
		MoveToSoul(OwnerCard);
		EnableMouse();
		DisplayHelpMessage("Choose one of your Royal Paladin, and that units gets [Power]+3000.");
	}
	
	public void Margal_Pointer()
	{
		if(AcceptInput())	
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Royal Paladin")
				{
					IncreasePowerByTurn(c, 3000);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Toypugal
	public void Toypugal_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Boost)
		{
			if(Game.field.GetNumberWithClanAndGradeEqual("Royal Paladin", 3) >= 2)
			{
				IncreasePowerByBattle(OwnerCard, 3000);
				IncreasePowerByBattle(OwnerCard.boostedUnit, 3000);
			}
		}
	}
	#endregion
	
	#region Pongal
	public int Pongal_Field()
	{
		if(!OwnerCard.IsVanguard())
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
			{
				if(GetVanguard().clan == "Royal Paladin")
				{
					if(Game.playerDeck.SearchForID(CardIdentifier.SOUL_SAVER_DRAGON) != null)
					{
						return 1;	
					}
				}
			}
		}
		
		return 0;
	}
	
	public void Pongal_Active()
	{
		StartEffect();
		ShowOnScreen(OwnerCard);
		MoveToSoul(OwnerCard);
		Game.playerDeck.ViewDeck(CardIdentifier.SOUL_SAVER_DRAGON);
		_AuxBool = true;
		FlipCardInDamageZone(1);
	}
	
	public void Pongal_Update()
	{
		if(_AuxBool)
		{
			if(!Game.playerDeck.IsOpen())	
			{
				_AuxBool = false;
				Card c = Game.playerDeck.SearchForID(CardIdentifier.SOUL_SAVER_DRAGON);
				Game.playerDeck.RemoveFromDeck(c);
				Game.playerHand.AddToHand(c);
				Game.SendPacket(GameAction.DRAW_FROM_DECK_AND_SHOW, c.cardID);
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Skull Juggler
	public void SkullJ_Auto(CardState s)
	{	
		if(s == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(s == CardState.Call || s == CardState.Ride)
		{
			if(GetVanguard().clan == "Pale Moon" && Game.playerDeck.Size() > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void SkullJ_Active()
	{
		ShowOnScreen();
		Delay(1);
	}
	
	public void SkullJ_Update()
	{
		DelayUpdate(delegate {
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	
	#region Pearl Sisters, Perla 
	void PearlSistersPerla_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() && Game.field.GetNumberOfCardsInSoul() >= 1 &&
			   ((OwnerCard.IsVanguard() && NumRearGuards("Bermuda Triangle") > 0) || (!OwnerCard.IsVanguard() && NumRearGuards("Bermuda Triangle") > 1)))
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void PearlSistersPerla_Active()
	{
		ShowAndDelay();	
	}
	
	void PearlSistersPerla_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);
		});
		
		SoulBlastUpdate(delegate {
			EnableMouse("Choose another of your Bermuda Triangle rear-guards.");	
		});
	}
	
	void PearlSistersPerla_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Bermuda Triangle" && c != OwnerCard)
				{
					ReturnToHand(c);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Carrier of the Life Water 
	void CarrieroftheLifeWater_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(RC() && c != null && GetAttacker() == c && c.clan == "Angel Feather")
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void CarrieroftheLifeWater_Active()
	{	
		ShowAndDelay();
	}
	
	void CarrieroftheLifeWater_Update()
	{	
		DelayUpdate(delegate {
			ReturnToHand(OwnerCard);
			EndEffect();
		});
	}
	#endregion
	
	#region Clutch Rifle Angel 
	void ClutchRifleAngel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.clan == "Angel Feather" && c.IsVanguard() &&
				Game.field.GetDamage() >= Game.enemyField.GetDamage())
			{
				IncreasePowerByBattle(c, 4000);
			}
		}
	}
	#endregion
	
	/*
	 * [AUTO](RC): [Soul Blast (1)] When this unit boosts a card named "School Dominator, Apt", you may pay the cost.
	 * If you do, the boosted unit gets [Power] +5000 until end of that battle.
	 * */
	
	#region Feather Penguin 
	void FeatherPenguin_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}	
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.cardID == CardIdentifier.SCHOOL_DOMINATOR__APT && Game.field.GetNumberOfCardsInSoul() >= 1)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void FeatherPenguin_Active()
	{
		ShowAndDelay();	
	}
	
	void FeatherPenguin_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
			EndEffect();			
		});
	}
	#endregion
	
	
	
	#region Lightning Charger  
	void LightningCharger_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}	
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.cardID == CardIdentifier.CIRCULAR_SAW__KIRIEL && Game.field.GetNumberOfCardsInSoul() >= 1)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void LightningCharger_Active()
	{
		ShowAndDelay();	
	}
	
	void LightningCharger_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
			EndEffect();			
		});
	}
	#endregion
	
	#region Skeleton Assault Troops Captain 
	void SkeletonAssaultTroopsCaptain_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Granblue");	
		}
	}
	
	int SkeletonAssaultTroopsCaptain_Field()
	{
		if(RC () && CB (1) && Game.playerDeck.Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void SkeletonAssaultTroopsCaptain_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);	
			Forerunner_Active();	
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void SkeletonAssaultTroopsCaptain_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1, 
						 delegate {
							MoveToSoul(OwnerCard);
							SetBool(2);
							Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (5, Game.playerDeck.Size()), "");
						 }
			);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.grade == 3 && c.clan == "Granblue")
					{
						FromDeckToHand(_AuxIdVector[0]);	
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	
	void SkeletonAssaultTroopsCaptain_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Little Fighter, Cron 
	void LittleFighterCron_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Gold Paladin");	
		}
	}
	
	int LittleFighterCron_Field()
	{
		if(RC () && CB (1) && Game.playerDeck.Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void LittleFighterCron_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);	
			Forerunner_Active();	
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void LittleFighterCron_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1, 
						 delegate {
							MoveToSoul(OwnerCard);
							SetBool(2);
							Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (5, Game.playerDeck.Size()), "");
						 }
			);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.grade >= 3 && c.clan == "Gold Paladin")
					{
						FromDeckToHand(_AuxIdVector[0]);	
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	
	void LittleFighterCron_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Spark Kid Dragoon 
	void SparkKidDragoon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Narukami");	
		}
	}
	
	int SparkKidDragoon_Field()
	{
		if(RC () && CB (1) && Game.playerDeck.Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void SparkKidDragoon_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);	
			Forerunner_Active();	
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void SparkKidDragoon_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1, 
						 delegate {
							MoveToSoul(OwnerCard);
							SetBool(2);
							Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (5, Game.playerDeck.Size()), "");
						 }
			);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.grade >= 3 && c.clan == "Narukami")
					{
						FromDeckToHand(_AuxIdVector[0]);	
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	
	void SparkKidDragoon_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Conviction Dragon, Chromejailer Dragon 
	int ConvictionDragonChromejailerDragon_Field()
	{
		int n = 0;
		if(VC () && LB (4) && CB (2) && NumRearGuards("Gold Paladin") >= 2)
		{
			n++;	
		}
		
		if(VC () && CB (1) && Game.playerHand.GetByID(CardIdentifier.CONVICTION_DRAGON__CHROMEJAILER_DRAGON) != null)
		{
			n++;	
		}
		
		return n;
	}
	
	void ConvictionDragonChromejailerDragon_Active(int idx)
	{
		if(idx == 1)
		{
			SetBool(1);	
		}
		else if(idx == 2)
		{
			SetBool(2);	
		}
		
		StartEffect();
		ShowAndDelay();
	}
	
	void ConvictionDragonChromejailerDragon_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				CounterBlast(2,
				delegate {
					SelectUnit("Choose two of your Gold Paladin rear-guards.", 2, true,
					delegate {
						RetireUnit (Unit);	
					},
					delegate {
						return Unit.BelongsToClan("Gold Paladin");	
					},
					delegate {
						IncreasePowerAndCriticalByTurn(OwnerCard, 10000, 1);	
					});
				});
			}
			
			if(GetBool(2))
			{
				UnsetBool(2);	
				CounterBlast(1,
				delegate {
					SelectInHand(1, false,
					delegate {
						DiscardSelectedCard();
					},
					delegate {
						return _SIH_Card.cardID == CardIdentifier.CONVICTION_DRAGON__CHROMEJAILER_DRAGON;
					},
					delegate {
						Game.playerDeck.ViewDeck(2, SearchMode.TOP_CARD, 4, delegate(Game2DCard c) {
							return c._CardInfo.BelongsToClan("Gold Paladin");
						});
						SetBool(3);
					}, "Choose a card named \"Conviction Dragon, Chromejailer Dragon\" from your hand.");	
				});
			}
		});
		
		if(GetBool(3) && !Game.playerDeck.IsOpen())
		{
			UnsetBool(3);
			_AuxIdVector = Game.playerDeck.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();	
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
	
	void ConvictionDragonChromejailerDragon_Pointer()
	{	
		CounterBlast_Pointer();
		SelectUnit_Pointer();
		SelectInHand_Pointer();
	}
	#endregion
	
	#region Acorn Master 
	void AcornMaster_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Great Nature");	
		}
	}
	
	int AcornMaster_Field()
	{
		if(RC () && CB (1) && Game.playerDeck.Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void AcornMaster_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);	
			Forerunner_Active();	
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void AcornMaster_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1, 
						 delegate {
							MoveToSoul(OwnerCard);
							SetBool(2);
							Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (5, Game.playerDeck.Size()), "");
						 }
			);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.grade == 3 && c.clan == "Great Nature")
					{
						FromDeckToHand(_AuxIdVector[0]);	
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	
	void AcornMaster_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Tri-stinger Dragon 
	void TristingerDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && LB (4) && GetDefensor().IsVanguard() && Game.numBattle >= 3 && Game.field.GetNumberOfDamageCardsFaceup() > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}
	
	bool TristingerDragon_Cancel()
	{
		UnsetBool(1);	
		return true;
	}
	
	void TristingerDragon_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void TristingerDragon_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				Flipup(min (2, Game.field.GetNumberOfDamageCardsFaceup()),
				delegate {
					EndEffect();
					ConfirmAttack();
				});
			}
			else
			{
				CounterBlast(2,
				delegate {
					SelectUnit("Choose one of your Aqua Force rear-guards.", 1, true,
					delegate {
						IncreasePowerByTurn(Unit, 3000);	
					},
					delegate {
						return Unit.BelongsToClan("Aqua Force");	
					},
					delegate {
							
					});
				});
			}
		});
	}
	
	int TristingerDragon_Field()
	{
		if(VC () && CB (2) && NumRearGuards("Aqua Force") > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void TristingerDragon_Pointer()
	{	
		CounterBlast_Pointer();
		SelectUnit_Pointer();
		Flipup_Pointer();
	}
	#endregion
	
	#region Battle Sister, Cookie 
	void BattleSisterCookie_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && LB (4) && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
			
			ConfirmAttack();
		}
		else if(cs == CardState.Ride)
		{
			if(CB (2) && Game.playerDeck.Size() >= 2)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void BattleSisterCookie_Active()
	{
		ShowAndDelay();	
	}
	
	void BattleSisterCookie_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				DrawCard(2);	
			});
		});
		
		DrawCardUpdate(delegate {
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();	
			},
			delegate {
				return true;	
			},
			delegate {
				
			}, "Choose a card from your hand.");
		});
	}
	
	void BattleSisterCookie_Pointer()
	{
		CounterBlast_Pointer();
		SelectInHand_Pointer();
	}
	#endregion
	
	#region Battler of the Twin Brush, Polaris 
	void BattleroftheTwinBrushPolaris_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			if(VC () && LB (4) && GetDefensor().IsVanguard() && NumRG(delegate(Card c) { return c.BelongsToClan("Great Nature"); }) > 0)
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();
			}
		}
	}
	
	void BattleroftheTwinBrushPolaris_Active()
	{
		ShowAndDelay();	
	}
	
	void BattleroftheTwinBrushPolaris_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SelectUnit("Choose one of your \"Great Nature\" rear-guards.", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 4000);	
					StandUnit(Unit);
					Unit.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
						if(s == CardState.EndTurn)
						{
							RetireUnit(Unit);	
						}
					});
				},
				delegate {
					return Unit.BelongsToClan("Great Nature");
				},
				delegate {
					ConfirmAttack();
				});
			});
		});
	}
	
	void BattleroftheTwinBrushPolaris_Pointer()
	{
		CounterBlast_Pointer();	
		SelectUnit_Pointer();
	}
	#endregion
	
	#region Starlight Melody Tamer, Farah 
	int StarlightMelodyTamerFarah_Field()
	{
		if(VC () && LB (4) && CB (1) && PersonaBlast() && Game.playerDeck.Size() >= 2)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void StarlightMelodyTamerFarah_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void StarlightMelodyTamerFarah_Update()
	{
		DelayUpdate(delegate {
			PersonaBlast_Active(delegate {
				SoulCharge(2);
			}, false);
		});
		
		SoulChargeUpdate(delegate {
			SetBool(1);
			Game.field.ViewSoul(1, delegate(Card c) {
				return c.BelongsToClan("Pale Moon");	
			});
		});
		
		if(GetBool(1) && !Game.field.ViewingSoul())
		{
			UnsetBool(1);
			_AuxIdVector = Game.field.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				_AuxCard = Game.field.GetSoulByID(_AuxIdVector[0]);
				CallFromSoul(_AuxCard);
			}
			else
			{
				EndEffect();	
			}
		}
		
		CallFromSoulUpdate(delegate {
			IncreasePowerByTurn(_AuxCard, 3000);
			EndEffect();	
		});
	}
	
	void StarlightMelodyTamerFarah_Pointer()
	{
		PersonaBlast_Pointer();
	}
	#endregion
	
	#region Fortress Ammonite 
	void FortressAmmonite_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}	
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card c = OwnerCard.boostedUnit;
			if(c != null && GetAttacker() == c)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void FortressAmmonite_Active()
	{
		ShowAndDelay();	
	}
	
	void FortressAmmonite_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();	
			},
			delegate {
				return true;	
			},
			delegate {
				DrawCardWithoutDelay();	
			}, "Choose a card from your hand.");
		});
	}
	
	void FortressAmmonite_Pointer()
	{
		SelectInHand_Pointer();	
	}
	#endregion
	
	#region Thermometer Angel  
	void ThermometerAngel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Angel Feather");	
		}
	}
	
	int ThermometerAngel_Field()
	{
		if(RC () && CB (1) && Game.playerDeck.Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void ThermometerAngel_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);	
			Forerunner_Active();	
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void ThermometerAngel_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1, 
						 delegate {
							MoveToSoul(OwnerCard);
							SetBool(2);
							Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (5, Game.playerDeck.Size()), "");
						 }
			);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.grade == 3 && c.clan == "Angel Feather")
					{
						FromDeckToHand(_AuxIdVector[0]);	
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	
	void ThermometerAngel_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
		
	#region Devil in Shadow   
	void DevilinShadow_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Dark Irregulars");	
		}
	}
	
	int DevilinShadow_Field()
	{
		if(RC () && CB (1) && Game.playerDeck.Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void DevilinShadow_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);	
			Forerunner_Active();	
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void DevilinShadow_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1, 
						 delegate {
							MoveToSoul(OwnerCard);
							SetBool(2);
							Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (5, Game.playerDeck.Size()), "");
						 }
			);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.grade == 3 && c.clan == "Dark Irregulars")
					{
						FromDeckToHand(_AuxIdVector[0]);	
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	
	void DevilinShadow_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
		
	#region Innocent Magician   
	void InnocentMagician_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Pale Moon");	
		}
	}
	
	int InnocentMagician_Field()
	{
		if(RC () && CB (1) && Game.playerDeck.Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void InnocentMagician_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);	
			Forerunner_Active();	
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void InnocentMagician_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1, 
						 delegate {
							MoveToSoul(OwnerCard);
							SetBool(2);
							Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (5, Game.playerDeck.Size()), "");
						 }
			);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.grade == 3 && c.clan == "Pale Moon")
					{
						FromDeckToHand(_AuxIdVector[0]);	
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	
	void InnocentMagician_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Battle Sister, Eclair   
	void BattleSisterEclair_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Oracle Think Tank");	
		}
	}
	
	int BattleSisterEclair_Field()
	{
		if(RC () && CB (1) && Game.playerDeck.Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void BattleSisterEclair_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);	
			Forerunner_Active();	
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void BattleSisterEclair_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1, 
						 delegate {
							MoveToSoul(OwnerCard);
							SetBool(2);
							Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min (5, Game.playerDeck.Size()), "");
						 }
			);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.grade == 3 && c.clan == "Oracle Think Tank")
					{
						FromDeckToHand(_AuxIdVector[0]);	
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	
	void BattleSisterEclair_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Black Celestial Maiden, Kali 
	void BlackCelestialMaidenKali_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetNumberOfRear() > Game.enemyField.GetNumberOfRearUnits())
			{
				if(VC())
				{
					IncreasePowerByBattle(OwnerCard, 3000);
				}
				else
				{
					IncreasePowerByBattle(OwnerCard, 1000);	
				}
			}
			
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Beast Deity, Scarlet Bird 
	public void BeastDeityScarletBird_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits)
		{
			if(HitsVanguard() && GetVanguard().clan == "Nova Grappler")
			{
				StartEffect();
				ShowAndDelay();	
			}
		}
	}
	
	public void BeasBeastDeityScarletBird_Update()
	{
		DelayUpdate(delegate {
			int n = min (5, Game.playerDeck.Size());
			Game.playerDeck.ViewDeck(n, SearchMode.TOP_CARD, n, "");	
			DisplayHelpMessage("Choose the order in which the remaining cards will be put into the bottom. (From top to bottom). If there is a \"Beast Deity, Azure Dragon\", it will put into your hand.");
			SetBool(2);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool bRode = false;
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{
					if(_AuxIdVector[i] == CardIdentifier.BEAST_DEITY__AZURE_DRAGON && !bRode)
					{
						bRode = true;
						FromDeckToHand(CardIdentifier.BEAST_DEITY__AZURE_DRAGON);	
						_AuxIdVector.RemoveAt(0);
					}
					else
					{
						Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
						Game.playerDeck.RemoveFromDeck(c);
						Game.playerDeck.AddToBottom(c);	
					}
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Beast Deity, Black Tortoise 
	public void BeastDeityBlackTortoise_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits)
		{
			if(HitsVanguard() && GetVanguard().clan == "Nova Grappler")
			{
				StartEffect();
				ShowAndDelay();	
			}
		}
	}
	
	public void BeastDeityBlackTortoise_Update()
	{
		DelayUpdate(delegate {
			int n = min (5, Game.playerDeck.Size());
			Game.playerDeck.ViewDeck(n, SearchMode.TOP_CARD, n, "");	
			DisplayHelpMessage("Choose the order in which the remaining cards will be put into the bottom. (From top to bottom). If there is a \"Beast Deity, Azure Dragon\", it will put into your hand.");
			SetBool(2);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool bRode = false;
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{
					if(_AuxIdVector[i] == CardIdentifier.BEAST_DEITY__AZURE_DRAGON && !bRode)
					{
						bRode = true;
						FromDeckToHand(CardIdentifier.BEAST_DEITY__AZURE_DRAGON);	
						_AuxIdVector.RemoveAt(0);
					}
					else
					{
						Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
						Game.playerDeck.RemoveFromDeck(c);
						Game.playerDeck.AddToBottom(c);	
					}
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Goddess of the Half Moon, Tsukuyomi
	public void HalfMoon_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Ride)
		{
			if(Game.field.GetSoulByID(CardIdentifier.GODHAWK__ICHIBYOSHI) != null &&
			   Game.field.GetSoulByID(CardIdentifier.GODDESS_OF_THE_CRESCENT_MOON__TSUKUYOMI) != null)
			{
				if(Game.playerDeck.Size() >= 2)
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
		else if(s == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen();
				Delay(1);
				SetBool(1);
			}
		}
	}
	
	public void HalfMoon_Active()
	{	
		ShowOnScreen();
		Delay(1);			
	}
	
	public void HalfMoon_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				Game.playerDeck.ViewDeck(5, SearchMode.TOP_CARD, 5, "");	
				DisplayHelpMessage("Choose the order in which the remaining cards will be put into the bottom. (From top to bottom). If there is a \"Goddess of the Full Moon, Tsukuyomi\", it will be ride.");
				UnsetBool(1);
				SetBool(2);
			}
			else
			{
				SoulCharge (2);
			}
		});
		
		SoulChargeUpdate(delegate {
			EndEffect();	
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool bRode = false;
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{
					if(_AuxIdVector[i] == CardIdentifier.GODDESS_OF_THE_FULL_MOON__TSUKUYOMI && !bRode)
					{
						bRode = true;
						Game.RideFromDeck(Game.playerDeck.SearchForID(CardIdentifier.GODDESS_OF_THE_FULL_MOON__TSUKUYOMI));	
						_AuxIdVector.RemoveAt(0);
						Game.bRideThisTurn = false;
					}
					else
					{
						Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
						Game.playerDeck.RemoveFromDeck(c);
						Game.playerDeck.AddToBottom(c);	
					}
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Stealth Dragon, Cursed Breath 
	public void StealthDragonCursedBreath_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() &&
				GetVanguard().clan == "Murakumo")
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public void StealthDragonCursedBreath_Update()
	{
		DelayUpdate(delegate {
			Game.playerDeck.ViewDeck(5, SearchMode.TOP_CARD, 5, "");	
			DisplayHelpMessage("Choose the order in which the remaining cards will be put into the bottom. (From top to bottom). If there is a \"Covert Demonic Dragon, Mandala Lord\", it will be put into your hand.");
			SetBool(2);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool bRode = false;
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{
					if(_AuxIdVector[i] == CardIdentifier.COVERT_DEMONIC_DRAGON__MANDALA_LORD && !bRode)
					{
						bRode = true;
						FromDeckToHand(CardIdentifier.COVERT_DEMONIC_DRAGON__MANDALA_LORD);
						_AuxIdVector.RemoveAt(0);
					}
					else
					{
						Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
						Game.playerDeck.RemoveFromDeck(c);
						Game.playerDeck.AddToBottom(c);	
					}
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Stealth Dragon, Turbulent Edge  
	public void StealthDragonTurbulentEdge_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() &&
				GetVanguard().clan == "Murakumo")
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public void StealthDragonTurbulentEdge_Update()
	{
		DelayUpdate(delegate {
			Game.playerDeck.ViewDeck(5, SearchMode.TOP_CARD, 5, "");	
			DisplayHelpMessage("Choose the order in which the remaining cards will be put into the bottom. (From top to bottom). If there is a \"Covert Demonic Dragon, Mandala Lord\", it will be put into your hand.");
			SetBool(2);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool bRode = false;
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{
					if(_AuxIdVector[i] == CardIdentifier.COVERT_DEMONIC_DRAGON__MANDALA_LORD && !bRode)
					{
						bRode = true;
						FromDeckToHand(CardIdentifier.COVERT_DEMONIC_DRAGON__MANDALA_LORD);
						_AuxIdVector.RemoveAt(0);
					}
					else
					{
						Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
						Game.playerDeck.RemoveFromDeck(c);
						Game.playerDeck.AddToBottom(c);	
					}
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Drangal
	public void Drangal_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen();
				Delay(1);
				SetBool(1);
			}
		}
	}
	
	public void Drangal_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				Game.playerDeck.ViewDeck(5, SearchMode.TOP_CARD, 5, "");	
				DisplayHelpMessage("Choose the order in which the remaining cards will be put into the bottom. (From top to bottom). If there is a \"Knight of Quests, Galahad\", it will be ride.");
				UnsetBool(1);
				SetBool(2);
			}
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool bRode = false;
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{	
					if(_AuxIdVector[i] == CardIdentifier.KNIGHT_OF_QUESTS__GALAHAD && !bRode)
					{
						bRode = true;
						Game.RideFromDeck(Game.playerDeck.SearchForID(CardIdentifier.KNIGHT_OF_QUESTS__GALAHAD));	
						_AuxIdVector.RemoveAt(0);
						Game.bRideThisTurn = false;
					}
					else
					{
						Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
						Game.playerDeck.RemoveFromDeck(c);
						Game.playerDeck.AddToBottom(c);	
					}
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Peek-a-boo 
	void Peekaboo_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Soul_BeginMain)
		{
			if(Game.field.GetNumberOfCardsInSoul() > 1 && VanguardIs("Pale Moon"))
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.EndTurn)
		{
			if(RC () && VanguardIs("Pale Moon"))
			{
				MoveToSoul(OwnerCard);
			}
		}
	}	
	
	void Peekaboo_Active()
	{
		ShowAndDelay();	
	}
	
	void Peekaboo_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1, delegate(Card c) {
				return c != OwnerCard;	
			});
		});
		
		SoulBlastUpdate(delegate {
			CallFromSoul(OwnerCard);	
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Goddess of the Crescent Moon, Tsukuyomi 
	public void GoddessoftheCrescentMoonTsukuyomi_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen();
				Delay(1);
				SetBool(1);
			}
		}
	}
	
	public void GoddessoftheCrescentMoonTsukuyomi_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				Game.playerDeck.ViewDeck(5, SearchMode.TOP_CARD, 5, "");	
				DisplayHelpMessage("Choose the order in which the remaining cards will be put into the bottom. (From top to bottom). If there is a \"Goddess of the Half Moon, Tsukuyomi\", it will be ride.");
				UnsetBool(1);
				SetBool(2);
			}
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool bRode = false;
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{	
					if(_AuxIdVector[i] == CardIdentifier.GODDESS_OF_THE_HALF_MOON__TSUKUYOMI && !bRode)
					{
						bRode = true;
						Game.RideFromDeck(Game.playerDeck.SearchForID(CardIdentifier.GODDESS_OF_THE_HALF_MOON__TSUKUYOMI));	
						_AuxIdVector.RemoveAt(0);
						Game.bRideThisTurn = false;
					}
					else
					{
						Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
						Game.playerDeck.RemoveFromDeck(c);
						Game.playerDeck.AddToBottom(c);	
					}
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Knight of Quests, Galahad 
	public void KnightofQuestsGalahad_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen();
				Delay(1);
				SetBool(1);
			}
		}
	}
	
	public void KnightofQuestsGalahad_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				Game.playerDeck.ViewDeck(5, SearchMode.TOP_CARD, 5, "");	
				DisplayHelpMessage("Choose the order in which the remaining cards will be put into the bottom. (From top to bottom). If there is a \"KnKnight of Tribulations, Galahad\", it will be ride.");
				UnsetBool(1);
				SetBool(2);
			}
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool bRode = false;
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{	
					if(_AuxIdVector[i] == CardIdentifier.KNIGHT_OF_TRIBULATIONS__GALAHAD && !bRode)
					{
						bRode = true;
						Game.RideFromDeck(Game.playerDeck.SearchForID(CardIdentifier.KNIGHT_OF_TRIBULATIONS__GALAHAD));	
						_AuxIdVector.RemoveAt(0);
						Game.bRideThisTurn = false;
					}
					else
					{
						Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
						Game.playerDeck.RemoveFromDeck(c);
						Game.playerDeck.AddToBottom(c);	
					}
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Knight of Tribulations, Galahad 
	public void KnightofTribulationsGalahad_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen();
				Delay(1);
				SetBool(1);
			}
		}
		else if(s == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.KNIGHT_OF_GODLY_SPEED__GALAHAD)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void KnightofTribulationsGalahad_Active()
	{
		ShowAndDelay();
		SetBool(3);
	}
	
	public void KnightofTribulationsGalahad_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				Game.playerDeck.ViewDeck(5, SearchMode.TOP_CARD, 5, "");	
				DisplayHelpMessage("Choose the order in which the remaining cards will be put into the bottom. (From top to bottom). If there is a \"Knight of Godly Speed, Galahad\", it will be ride.");
				UnsetBool(1);
				SetBool(2);
			}
			
			if(GetBool(3))
			{
				UnsetBool(3);
				SoulCharge(2);
			}
		});
		
		SoulChargeUpdate(delegate {
			EndEffect();	
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool bRode = false;
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{	
					if(_AuxIdVector[i] == CardIdentifier.KNIGHT_OF_GODLY_SPEED__GALAHAD && !bRode)
					{
						bRode = true;
						Game.RideFromDeck(Game.playerDeck.SearchForID(CardIdentifier.KNIGHT_OF_GODLY_SPEED__GALAHAD));	
						_AuxIdVector.RemoveAt(0);
						Game.bRideThisTurn = false;
					}
					else
					{
						Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
						Game.playerDeck.RemoveFromDeck(c);
						Game.playerDeck.AddToBottom(c);	
					}
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	 
	#region Battle Sister, Vanilla 
	public void BattleSisterVanilla_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.UsedToGuard)
		{
			if(Game.field.GetUnitsSoulWithClanName("Oracle Think Tank") >= 6)
			{
				AddExtraShield(5000);	
			}
		}
	}
	#endregion
	
	/*
	 * [AUTO](RC):When an attack hits during the battle that this unit boosted, you may Soul Charge (1). 
	 * If you do, return this unit to your deck, and shuffle your deck. 
	 */
	
	#region Dark Queen of Nightmareland
	public void DarkQueenofNightmareland_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits_NotMe)
		{
			if(OwnerCard.boostedUnit != null && GetAttacker() == OwnerCard.boostedUnit &&
			   Game.playerDeck.Size() > 0 && !OwnerCard.IsVanguard())
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void DarkQueenofNightmareland_Active()
	{
		ShowAndDelay();	
	}
	
	public void DarkQueenofNightmareland_Update()
	{	
		DelayUpdate(delegate {
			SoulCharge(1);	
		});
		
		SoulChargeUpdate(delegate {
			FromFieldToDeck(OwnerCard);
			ShuffleDeck();
			EndEffect();
		});
	}
	#endregion
	
	#region Rainbow Magician 
	public void RainbowMagician_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits_NotMe)
		{
			if(OwnerCard.boostedUnit != null && GetAttacker() == OwnerCard.boostedUnit &&
			   Game.playerDeck.Size() > 0 && !OwnerCard.IsVanguard())
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void RainbowMagician_Active()
	{
		ShowAndDelay();	
	}
	
	public void RainbowMagician_Update()
	{	
		DelayUpdate(delegate {
			SoulCharge(1);	
		});
		
		SoulChargeUpdate(delegate {
			FromFieldToDeck(OwnerCard);
			ShuffleDeck();
			EndEffect();
		});
	}
	#endregion
	
	#region Black Cannon Tiger 
	public void BlackCannonTiger_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits_NotMe)
		{
			if(OwnerCard.boostedUnit != null && GetAttacker() == OwnerCard.boostedUnit &&
			   Game.playerDeck.Size() > 0 && !OwnerCard.IsVanguard())
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void BlackCannonTiger_Active()
	{
		ShowAndDelay();	
	}
	
	public void BlackCannonTiger_Update()
	{	
		DelayUpdate(delegate {
			SoulCharge(1);	
		});
		
		SoulChargeUpdate(delegate {
			FromFieldToDeck(OwnerCard);
			ShuffleDeck();
			EndEffect();
		});
	}
	#endregion	

	#region Godhawk, Ichibyoshi 
	public void GodhawkIchibyoshi_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.BeginMain)
		{
			ShowOnScreen();
			Delay(1);
			SetBool(1);
		}
	}
	
	public void GodhawkIchibyoshi_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				Game.playerDeck.ViewDeck(5, SearchMode.TOP_CARD, 5, "");	
				DisplayHelpMessage("Choose the order in which the remaining cards will be put into the bottom. (From top to bottom). If there is a \"Goddess of the Crescent Moon, Tsukuyomi\", it will be ride.");
				UnsetBool(1);
				SetBool(2);
			}
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				bool bRode = false;
				for(int i = 0; i < _AuxIdVector.Count; i++)
				{	
					if(_AuxIdVector[i] == CardIdentifier.GODDESS_OF_THE_CRESCENT_MOON__TSUKUYOMI && !bRode)
					{
						bRode = true;
						Game.RideFromDeck(Game.playerDeck.SearchForID(CardIdentifier.GODDESS_OF_THE_CRESCENT_MOON__TSUKUYOMI));	
						_AuxIdVector.RemoveAt(0);
						Game.bRideThisTurn = false;
					}
					else
					{
						Card c = Game.playerDeck.SearchForID(_AuxIdVector[i]);
						Game.playerDeck.RemoveFromDeck(c);
						Game.playerDeck.AddToBottom(c);	
					}
				}
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Gloom Flyman 
	void GloomFlyman_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.UsedToGuard)
		{	
			if(GetVanguard().clan == "Megacolony" &&
				Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(0) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void GloomFlyman_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your opponent's grade 0 rear-guards.");
		});
	}
	
	void GloomFlyman_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null && c.IsStand() && c.grade == 0)
				{
					RestEnemyUnit(c);
					ClearMessage();
					DisableMouse();
					EndEffect();
				}
			}
		}
	}
	#endregion

	#region Cannon Fire Dragon, Cannon Gear
	public void CannonFireDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(Game.field.GetNumberOfRear() > 0)
			{
				StartEffect();
				ShowOnScreen(OwnerCard);
				EnableMouse();
				DisplayHelpMessage("Choose one of your rear-guards, and retire it.");
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			if(OwnerCard.IsVanguard() && OwnerCard.IsBoostedBy.clan == "Tachikaze")
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}	
		}
	}
	
	public void CannonFireDragon_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null)
				{
					RetireUnit(c);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Ravenous Dragon, Gigarex
	public void Gigarex_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.UnitSendToDropZoneFromRC)
		{
			Card c = Game.field.LastCardSentToDrop;
			if(c != null && c.clan == "Tachikaze")
			{
				IncreasePowerByTurn(OwnerCard, 1000);	
			}
		}
	}
	#endregion
	
	#region Savage Warrior 
	public void SavageWarrior_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.UnitSendToDropZoneFromRC)
		{
			Card c = Game.field.LastCardSentToDrop;
			if(c != null && c.clan == "Tachikaze")
			{
				IncreasePowerByTurn(OwnerCard, 1000);	
			}
		}
	}
	#endregion
	
	#region Savage Destroyer 
	public void SavageDestroyer_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.UnitSendToDropZoneFromRC)
		{
			Card c = Game.field.LastCardSentToDrop;
			if(c != null && c.clan == "Tachikaze")
			{
				IncreasePowerByTurn(OwnerCard, 1000);	
			}
		}
	}
	#endregion
	
	#region Nightmare Baby
	public void NightmareBaby_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.cardID == CardIdentifier.BLUE_DUST)
			{
				_AuxCard = OwnerCard.boostedUnit;
				IncreasePowerByBattle(4000);
			}
		}
	}
	#endregion
	
	#region Boomerang Thrower
	public void Boomerang_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Ride)
		{
			Card c = Game.field.GetTopCardFromSoul();
			if(c != null && c.clan == "Nova Grappler")
			{
				OwnerCard.CanAttackBackRow = true;
			}
		}
		else if(cs == CardState.EndTurn)
		{
			OwnerCard.CanAttackBackRow = false;	
		}
	}
	#endregion
	
	#region Swift Archer, FUSHIMI
	public void Fushimi_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Ride)
		{
			Card c = Game.field.GetTopCardFromSoul();
			if(c != null && c.clan == "Murakumo")
			{
				OwnerCard.CanAttackBackRow = true;
			}
		}
		else if(cs == CardState.EndTurn)
		{
			OwnerCard.CanAttackBackRow = false;	
		}
	}
	#endregion
	
	#region Winged Dragon, Skyptero
	public void WingedDragonSkyptero_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
			{
				if(GetVanguard().clan == "Tachikaze")
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void WingedDragonSkyptero_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		FromDropToHand(OwnerCard);
		EndEffect();
	}
	#endregion
	
	#region Assault Dragon, Blightops
	public void AssaultDragonBlightops_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 1 && Game.playerDeck.SearchForID(CardIdentifier.IRONCLAD_DRAGON_SHIELDON) != null)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void AssaultDragonBlightops_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		Card temp = Game.playerDeck.SearchForID(CardIdentifier.IRONCLAD_DRAGON_SHIELDON);
		Game.playerDeck.RemoveFromDeck(temp);
		Game.playerHand.AddToHand(temp);
		ShowCardInHand(temp);
	}
	#endregion
	
	#region Stealth Rogue of Body Replacement, Kokuenmaru 
	void StealthRogueofBodyReplacementKokuenmaru_Auto(CardState cs)
	{	
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{	
			SetBool(1);
			Forerunner("Murakumo");
		}
	}
	
	bool StealthRogueofBodyReplacementKokuenmaru_Cancel()
	{
		UnsetBool(1);
        return true;
	}
	
	void StealthRogueofBodyReplacementKokuenmaru_Active()
	{
		if(GetBool (1))
		{	
			UnsetBool(1);
			Forerunner_Active();
		}
        else
        {
            StartEffect();
            ShowAndDelay();
        }
	}

    void StealthRogueofBodyReplacementKokuenmaru_Update()
    {
        Forerunner_Update();

        DelayUpdate(delegate {
            CounterBlast(1,
            delegate {  
                MoveToSoul(OwnerCard);
                SetBool(2);
                Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min(5, Game.playerDeck.Size()), delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Murakumo") && c._CardInfo.grade >= 3;
				});
            });
        });

        if(GetBool(2) && !Game.playerDeck.IsOpen())
        {
            UnsetBool(2);
            _AuxIdVector = Game.playerDeck.GetLastSelectedList();
            if(_AuxIdVector.Count > 0)
            {
                FromDeckToHand(_AuxIdVector[0]);
            }
            EndEffect();
            ShuffleDeck();
        }
    }

    void StealthRogueofBodyReplacementKokuenmaru_Pointer()
    {
        CounterBlast_Pointer();
    }

    int StealthRogueofBodyReplacementKokuenmaru_Field()
    {
        if(RC() && CB(1)) 
        {
            return 1;
        }

        return 0;
    }
	#endregion
	
	#region Hades Ringmaster
	public void HadesRingmaster_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.RideAboveIt)
		{
			if(GetVanguard().clan == "Pale Moon" && Game.playerDeck.Size() > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void HadesRingmaster_Active()
	{
		ShowOnScreen();
		Delay(1);
	}
	
	public void HadesRingmaster_Update()
	{	
		DelayUpdate(delegate {
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	
	#region Dreamy Fortress 
	void DreamyFortress_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EnemyTurn_FromRCToDrop)
		{
			if(IsInSoul(CardIdentifier.DREAMY_FORTRESS))
			{
				StartEffect();
				ShowAndDelay();
			}
			else
			{
				Game.bEndEvent = true;	
				Game.EffectOnGoingEnemyTurn = false;
			}
		}
	}
	
	void DreamyFortress_Update()
	{
		DelayUpdate(delegate {
			CallFromSoul(Game.field.GetSoulByID(CardIdentifier.DREAMY_FORTRESS));	
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();
			Game.bEndEvent = true;
			Game.EffectOnGoingEnemyTurn = false;
		});
	}
	#endregion
	
	#region Dreamy Ammonite 
	void DreamyAmmonite_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EnemyTurn_FromRCToDrop)
		{
			if(IsInSoul(CardIdentifier.DREAMY_AMMONITE))
			{
				StartEffect();
				ShowAndDelay();
			}
			else
			{
				Game.bEndEvent = true;	
				Game.EffectOnGoingEnemyTurn = false;
			}
		}
	}
	
	void DreamyAmmonite_Update()
	{
		DelayUpdate(delegate {
			CallFromSoul(Game.field.GetSoulByID(CardIdentifier.DREAMY_AMMONITE));	
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();
			Game.bEndEvent = true;
			Game.EffectOnGoingEnemyTurn = false;
		});
	}
	#endregion
	
	#region Lily of the Valley Musketeer, Kaivant
	void LilyoftheValleyMusketeerKaivant_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB(1) && NumRG(delegate(Card c) { return c != OwnerCard && c.name.Contains("Musketeer"); }) > 0 && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void LilyoftheValleyMusketeerKaivant_Active()
	{
		ShowAndDelay();	
	}
	
	void LilyoftheValleyMusketeerKaivant_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit("Choose one of your rear-guards with \"Musketeer\" in its card name.", 1, false,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.name.Contains("Musketeer") && Unit != OwnerCard; 	
				},
				delegate {
					SetBool(1);
					Game.playerDeck.ViewDeck(1, 
						SearchMode.TOP_CARD, 
						min (4, Game.playerDeck.Size()), 
						"",
						delegate(Game2DCard c) {
							return c._CardInfo.name.Contains("Musketeer");
						}
					);
				});
			});
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector != null && _AuxIdVector.Count > 0)
				{
					CallFromDeck(_AuxIdVector);
				}
				else
				{
					EndEffect();	
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			ShuffleDeck();
			EndEffect();
		});
	}
	
	void LilyoftheValleyMusketeerKaivant_Pointer()
	{
		CounterBlast_Pointer();	
		SelectUnit_Pointer();
	}
	#endregion

	#region Lily of the Valley Musketeer, Rebecca 
	void LiLilyoftheValleyMusketeerRebecca_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB(1) && NumRG(delegate(Card c) { return c != OwnerCard && c.name.Contains("Musketeer"); }) > 0 && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void LilyoftheValleyMusketeerRebecca_Active()
	{
		ShowAndDelay();	
	}
	
	void LilyoftheValleyMusketeerRebecca_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit("Choose one of your rear-guards with \"Musketeer\" in its card name.", 1, false,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.name.Contains("Musketeer") && Unit != OwnerCard; 	
				},
				delegate {
					SetBool(1);
					Game.playerDeck.ViewDeck(1, 
						SearchMode.TOP_CARD, 
						min (4, Game.playerDeck.Size()), 
						"",
						delegate(Game2DCard c) {
							return c._CardInfo.name.Contains("Musketeer");
						}
					);
				});
			});
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector != null && _AuxIdVector.Count > 0)
				{
					CallFromDeck(_AuxIdVector);
				}
				else
				{
					EndEffect();	
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			ShuffleDeck();
			EndEffect();
		});
	}
	
	void LilyoftheValleyMusketeerRebecca_Pointer()
	{
		CounterBlast_Pointer();	
		SelectUnit_Pointer();
	}
	#endregion
		
	#region Exculpate the Blaster
	public bool ExculpateTheBlaster_CanRide()
	{
		if(GetVanguard().grade == 3 && GetVanguard().clan == "Royal Paladin")
		{
			return true;	
		}	
		return false;
	}
	
	public bool ExculpateTheBlaster_CanAttack()
	{
		if(!OwnerCard.IsVanguard() ||
		   (OwnerCard.IsVanguard() && Game.field.GetSoulByID(CardIdentifier.BLASTER_BLADE) != null))
		{
			return true;
		}
		
		return false;
	}
	
	public int ExculpateTheBlaster_Field()
	{
		if(OwnerCard.IsVanguard())
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 3)
			{
				return 1;	
			}
		}
		
		return 0;
	}
	
	public void ExculpateTheBlaster_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(3);
		_AuxBool = true;
	}
	
	public bool ExculpateTheBlaster_SpecialAttack()
	{
		if(_AuxBool)
		{
			_AuxBool = false;
			_AuxBool2 = true;
			StartEffect();
			return true;
		}
		
		return false;	
	}
	
	public void ExculpateTheBlaster_Update()
	{
		if(_AuxBool2)
		{
			_AuxBool2 = false;
			_AuxIdVector = new List<CardIdentifier>();
			Game.field.InitSoulIterator();
			while(Game.field.HasNextSoul())
			{
				Card c = Game.field.CurrentSoulCard();
				if(c.cardID != CardIdentifier.BLASTER_BLADE)
				{
					_AuxIdVector.Add(c.cardID);
				}
			}
			IncreasePowerByTurn(OwnerCard, _AuxIdVector.Count * 2000);
			SoulBlast(_AuxIdVector);
		}
		
		SoulBlastUpdate(delegate {
			if(_AuxBool3)
			{
				_AuxBool3 = false;
				EndEffect();
			}
			else
			{
				ConfirmAttack(AttackType.ALL);
				EndEffect();
			}
		});
	}
	
	public void ExculpateTheBlaster_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			RetireUnit(OwnerCard);
		}
		else if(cs == CardState.EndBattle)
		{
			StartEffect();
			Card c = Game.field.GetDropByID(CardIdentifier.BLASTER_BLADE); 
			if(c != null)
			{
				RideFromDropZone(c);	
			}
			else
			{
				RideFromSoul(CardIdentifier.BLASTER_BLADE);
			}
			
			RestUnit(GetVanguard());
			
			_AuxIdVector = new List<CardIdentifier>();
			Game.field.InitSoulIterator();
			while(Game.field.HasNextSoul())
			{
				Card tmp = Game.field.CurrentSoulCard();
				_AuxIdVector.Add(tmp.cardID);	
			}
			
			_AuxBool3 = true;
			SoulBlast(_AuxIdVector);
		}
	}
	
	public void RideFromSoul(CardIdentifier id)
	{
		Card c = Game.field.GetSoulByID(id);
		if(c != null)
		{
			Game.RideFromSoul(c);
		}
	}
	#endregion
	
	#region Nitro Juggler
	public void NitroJuggler_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();
		}	
		else if(s == CardState.Ride || s == CardState.Call)
		{
			if(GetVanguard().clan == "Pale Moon")
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void NitroJuggler_Active()
	{	
		ShowOnScreen();
		Delay(1);
	}
	
	public void NitroJuggler_Update()
	{
		DelayUpdate(delegate() {
			Game.SoulCharge();	
			EndEffect();
		});
	}
	#endregion
	
	#region Riot General, Gyras 
	void RiotGeneralGyras_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(GetBool (1) && VC () && Game.playerDeck.Size() > 0)
			{
				Card c = SendCardFromDeckToDrop();
				if(c.clan == "Narukami")
				{
					IncreaseCriticalByBattle(OwnerCard, 1);
					IncreasePowerByBattle(OwnerCard, 3000);
				}
			}
			
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(VC())
			{
				Game.SoulCharge();
				IncreasePowerByTurn(OwnerCard, 2000);
			}
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);	
		}
		else if(cs == CardState.Attacking_NotMe)
		{
			if(GetBool(1) && VC() && GetAttacker().clan == "Narukami" && Game.playerDeck.Size() > 0)
			{
				Card c = SendCardFromDeckToDrop();
				if(c.clan == "Narukami")
				{
					IncreaseCriticalByBattle(GetAttacker(), 1);
					IncreasePowerByBattle(GetAttacker(), 3000);
				}
			}
		}
	}
	
	int RiotGeneralGyras_Field()
	{
		if(VC () && Megablast_Check(5, 8))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void RiotGeneralGyras_Active()
	{
		Megablast_Active(5, 8);	
	}
	
	void RiotGeneralGyras_Update()
	{
		Megablast_Update(delegate {
			SetBool(1);
			SelectAnimField(OwnerCard);			
		});
	}
	#endregion
	
	#region Lizard Soldier, Saishin 
	void LizardSoldierSaishin_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Narukami");	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{	
			Card c = OwnerCard.boostedUnit;
			
			if(HitsVanguard() && c != null && GetAttacker() == OwnerCard.boostedUnit && c.clan == "Narukami")
			{
				if(CB (1) && RC () && Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(0) > 0)
				{
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	void LizardSoldierSaishin_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void LizardSoldierSaishin_Update()
	{
		Forerunner_Update();
		
		DelayUpdate (delegate {
			CounterBlast(1,
					 	 delegate {
							MoveToSoul(OwnerCard);
							SelectEnemyUnit("Choose an opponent's grade 0 rear-guard.",
					          				1,
											true,
										    delegate {
												RetireEnemyUnit(EnemyUnit);
											},
											delegate {
												return EnemyUnit.grade == 0;
											},
											delegate {
											
											});
					 	 }
			);	
		});
	}
	
	void LizardSoldierSaishin_Pointer()
	{
		CounterBlast_Pointer();
		SelectEnemyUnit_Pointer();
	}
	#endregion
	
	#region Pulse Wave, Adriel 
	void PulseWaveAdriel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			Card c = OwnerCard.IsBoostedBy;
			if(c.clan == "Angel Feather")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	#endregion
	
	int NumRearGuards(string clan, string nameContains)
	{
		int cnt = 0;
		Game.field.InitFieldIterator();
		while(Game.field.HasNextField())
		{
			Card c = Game.field.CurrentFieldCard();
			if(c != null && c.clan == clan && c.name.Contains(nameContains))
			{
				cnt++;	
			}
		}
		return cnt;
	}
	
	#region Master Fraudo
	public void MasterFraudo_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetVanguard().clan == "Megacolony" && Game.field.GetNumberOfCardsInSoul() >= 3)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			if(OwnerCard.IsVanguard())
			{
				if(OwnerCard.IsBoostedBy.clan == "Megacolony")
				{
					IncreasePowerByBattle(OwnerCard, 3000);	
				}
			}
		}
	}
	
	public void MasterFraudo_Active()
	{
		ShowOnScreen(OwnerCard);
		SoulBlast(3);
	}
	
	public void MasterFraudo_Update()
	{
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});	
	}
	#endregion
	
	#region Chain-Attack Sutherland
	public void ChainAttackSutherland_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(CurrentPhaseIs(GamePhase.MAIN_PHASE))
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
	#endregion
	
	#region Machining Worker Ant
	public void WorkerAnt_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Call)
		{
			Game.field.InitFieldIterator();
			while(Game.field.HasNextField())
			{
				Card c = Game.field.CurrentFieldCard();
				if(c != null && c.name.Contains("Machining") && c.IsStand())
				{
					StartEffect();
					ShowOnScreen();
					EnableMouse();
					DisplayHelpMessage("Choose one of your rear-guards with \"Machining\" in its name.");
					break;
				}
			}
		}
	}
	
	public void WorkerAnt_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);	
				if(c != null && c.name.Contains("Machining") && c.IsStand())
				{
					StandUnit(c);
					EndEffect();
					DisableMouse();
					ClearMessage();
				}
			}
		}
	}
	#endregion
	
	#region Battle Sister, Maple 
	void BattleSisterMaple_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.playerHand.Size() >= 4)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Super Idol, Ceram 
	void SuperIdolCeram_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(CheckCounterBlast(1))
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	void SuperIdolCeram_Active()
	{
		FlipCardInDamageZone(1);
		ShowAndDelay();	
	}
	
	void SuperIdolCeram_Update()
	{
		DelayUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 3000);
			ConfirmAttack();
			EndEffect();
		});
	}
	#endregion
	
	#region Dragon Monk, Gojo
	//Dragon Monk, Gojo
	public void DragonMonkGojo_Active()
	{
		RestUnit(Game._LastUnitAbilityCard);
		ShowOnScreen(Game._LastUnitAbilityCard);
		
		Game.bBlockMouse = true;
		bEnablePointer = true;
		
		Game._GameHelper.CustomMessage("Select a card in your hand and discard it");
		
		_AuxBool = true;
		Game.bEffectOnGoing = true;
	}
	
	public void DragonMonkGojo_HandlePointer()
	{
		if(AcceptInput())
		{
			if(_AuxBool)
			{
				_AuxBool = false;
				return;
			}
			
			Card tmp = Game.playerHand.GetCurrentCardObject();
			Game.playerHand.RemoveFromHand(Game.playerHand.GetCurrentCard());
			Game.field.AddToDropZone(tmp);
			executeAbility = 4;
			Game.SendPacket (GameAction.ENEMY_DISCARD, tmp.cardID);
			Game._GameHelper.DisableCustomMessage();
			Game.bBlockMouse = false;
			bEnablePointer = false;
			
			Game.bBlockMouseOnce = true;
			Game.bEffectOnGoing = false;
		}
	}
	
	public int DragonMonkGojo_CheckActive()
	{
		if(Game.playerHand.Size() > 0)
		{
			if(Game._LastUnitAbilityCard.IsStand())
			{
				return 1;	
			}
		}
		return 0;
	}
	#endregion
	
	#region Guard Griffin
	public void Griffin_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{	
			ConfirmAttack();
		}
		else if(cs == CardState.UsedToGuard)
		{
			if(GetVanguard().clan == "Kagero" && Game.field.GetNumberOfDamageCardsFaceup() >= 1)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void Griffin_Active()
	{
		ShowOnScreen();	
		FlipCardInDamageZone(1);
		AddExtraShield(5000);
		EndEffect();
	}
	#endregion
	 
	#region Masked Police, Grander 
	public void MaskedPoliceGrander_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			if(!OwnerCard.IsVanguard())
			{
				if(GetVanguard().clan == "Dimension Police")
				{
					IncreasePowerByTurn(GetVanguard(), 2000);	
				}
			}
			
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Dragon Dancer, Lourdes 
	public void DragonDancerLourdes_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			if(Game.enemyField.GetNumberOfRearUnits() <= 2)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region School Dominator, Apt 
	void SchoolDominatorApt_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && GetDefensor().IsVanguard() && LimitBreak())
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
			ConfirmAttack();
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && NumRearGuards("Great Nature") > 0 && VC() && HandSize("Great Nature") > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void SchoolDominatorApt_Active()
	{
		ShowAndDelay();	
	}
	
	void SchoolDominatorApt_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your Great Nature rear-guards.", 1, false,
						delegate { RetireUnit(Unit); }, delegate { return Unit.clan == "Great Nature"; },
						delegate {
							SelectInHand(1, false, delegate { Game.CallFromHand(_SIH_Card); SetBool(1); }, delegate { return Unit.clan == "Great Nature"; }, delegate { }, "Choose a Great Nature from your hand.");
						}
			);
		});
		
		if(GetBool(1))
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				UnsetBool(1);
				EndEffect();
			}
			else
			{
				Game.HandleCallFromHand();	
			}
		}
	}
	
	void SchoolDominatorApt_Pointer()
	{
		if(SelectInHand_Pointer()) return;
		if(SelectUnit_Pointer()) return;
	}
	#endregion
	
	#region Lamp Camel 
	void LampCamel_Auto(CardState cs)
	{
		if(cs == CardState.AttackHits)
		{
			if(VanguardIs("Great Nature") && CB (2))
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	
	void LampCamel_Active()
	{
		ShowAndDelay();
	}
	
	void LampCamel_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2, delegate {
				DrawCardWithoutDelay();
				EndEffect();				
			});
		});
	}
	
	void LampCamel_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion

	#region White Hare in the Moon's Shadow, Pellinore 
	void WhiteHareintheMoonShadowPellinore_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(LimitBreak() && VC() && NumRearGuards("Gold Paladin") >= 2)
			{
				DisplayConfirmationWindow();
			}
			else
			{
				ConfirmAttack();	
			}
		}
		else if(cs == CardState.CallFromDeck)
		{
			if(GetEnemyVanguard().grade >= 2 && HandSize("Gold Paladin") > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void WhiteHareintheMoonShadowPellinore_Active()
	{
		ShowAndDelay();	
	}
	
	bool WhiteHareintheMoonShadowPellinore_OnCancel()
	{
		UnsetBool(1);
		return true;
	}
	
	void WhiteHareintheMoonShadowPellinore_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				SelectInHand(1, false, delegate { DiscardSelectedCard(); }, delegate { return _SIH_Card.clan == "Gold Paladin";},
				                       delegate { Game.RideFromField(OwnerCard, false); EndEffect(); },"Choose a Gold Paladin from your hand.");
			}
			else
			{
				SelectUnit("Choose two of your Gold Paladin rear-guards.", 2, false,
							delegate {
								FromFieldToDeck(Unit, true);	
							}, delegate {
								return Unit.clan == "Gold Paladin";
							}, delegate {
								int n = min (2, GetNumUnits("Gold Paladin"));
								SelectUnit("Choose up to two of your Gold Paladin units.", n, true,
											delegate { IncreasePowerByTurn(Unit, 5000);	},
										    delegate { return Unit.clan == "Gold Paladin"; },
											delegate { EndEffect(); ConfirmAttack();  }, true
								);
							}
				);
			}
		});
	}
	
	void WhiteHareintheMoonShadowPellinore_Pointer()
	{
		if(SelectUnit_Pointer()) return;
		if(SelectInHand_Pointer()) return;
	}
	#endregion
	
	#region Emerald Witch, LaLa 
	void EmeraldWitchLaLa_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(HandSize() > 0 && GetVanguard().clan == "Oracle Think Tank" &&
				Game.field.GetNumberOfCardsInSoul() <= 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void EmeraldWitchLaLa_Active()
	{
		ShowAndDelay();	
	}
	
	void EmeraldWitchLaLa_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, true, 
				delegate {
					DiscardSelectedCard();
					DrawCardWithoutDelay();
				},
				delegate { return true; }, delegate { }, "Choose a card from your hand.");
		});
	}
	
	void EmeraldWitchLaLa_Pointer()
	{
		SelectInHand_Pointer();	
	}
	#endregion

	#region Decadent Succubus
	public void DecadentSuccubus_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Call_NotMe)
		{
			if(OwnerCard.IsVanguard())
			{
				if(Game.field.LastUnitCalled.clan == "Dark Irregulars")
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void DecadentSuccubus_Active()
	{
		ShowAndDelay();
	}
	
	public void DecadentSuccubus_Update()
	{
		DelayUpdate(delegate {
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	
	#region Elephant Juggler 
	public void ElephantJuggler_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Call_NotMe)
		{
			if(OwnerCard.IsVanguard())
			{
				if(Game.field.LastUnitCalled.clan == "Pale Moon")
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void ElephantJuggler_Active()
	{
		ShowAndDelay();
	}
	
	public void ElephantJuggler_Update()
	{
		DelayUpdate(delegate {
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	
	#region Vacuum Mammoth 
	public void VacuumMammoth_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Call_NotMe)
		{
			if(OwnerCard.IsVanguard())
			{
				if(Game.field.LastUnitCalled.clan == "Tachikaze")
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void VacuumMammoth_Active()
	{
		ShowAndDelay();
	}
	
	public void VacuumMammoth_Update()
	{
		DelayUpdate(delegate {
			Game.SoulCharge();
			EndEffect();
		});
	}
	#endregion
	
	#region Demoinic Dragon Berserker, Yaksha
	//Demonic Dragon Berserker, Yaksha
	public void DemonicDragonBerserkerYaksha_CheckHandAbility(CardState cs, Card card)
	{
		if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).grade == 2)
			{
				if(CurrentPhaseIs(GamePhase.MAIN_PHASE))
				{
					_AuxCard = OwnerCard;
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void DemonicDragonBerserkerYaksha_ActiveAbility()
	{
		ShowOnScreen(OwnerCard);
		//Game.SendPacket(GameAction.SHOW_CARD_HAND, _Card.cardID, Game.playerHand.Size() - 1);
		//executeAbility = 3;
		Game.playerHand.RemoveFromHand(OwnerCard);
		Game.Ride(OwnerCard);
	}
	#endregion
	
	#region Flame of Hope, Aermo
	public void FlameOfHopeAermo_Auto(CardState cs, Card card)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			if(!card.IsVanguard())
			{
				if(card.boostedUnit == GetAttacker())
				{
					SetCard(card);
					DisplayConfirmationWindow();
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
	}
	
	public void FlameOfHopeAermo_Active()
	{
		ShowOnScreen();
		EnableMouse("Select a card from you hand and discard it.");
	}
	
	public void FlameOfHopeAermo_HandlePointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c))
			{
				DiscardSelectedCard();
				DrawCardWithoutDelay();
				ClearPointer();
			}
		}
	}
	#endregion
	
	#region Precipice Whirlwind, Sagramore 
	public void PrecipiceWhirlwindSagramore_Auto(CardState cs)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			if(!OwnerCard.IsVanguard())
			{
				if(OwnerCard.boostedUnit == GetAttacker())
				{
					DisplayConfirmationWindow();
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
	}
	
	public void PrecipiceWhirlwindSagramore_Active()
	{
		ShowOnScreen();
		EnableMouse("Select a card from you hand and discard it.");
	}
	
	public void PrecipiceWhirlwindSagramore_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c))
			{
				DiscardSelectedCard();
				DrawCardWithoutDelay();
				ClearPointer();
			}
		}
	}
	#endregion
	
	#region Lightning of Hope, Helena 
	public void LightningofHopeHelena_Auto(CardState cs)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			if(!OwnerCard.IsVanguard())
			{
				if(OwnerCard.boostedUnit == GetAttacker())
				{
					DisplayConfirmationWindow();
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
	}
	
	public void LightningofHopeHelena_Active()
	{
		ShowOnScreen();
		EnableMouse("Select a card from you hand and discard it.");
	}
	
	public void LightningofHopeHelena_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c))
			{
				DiscardSelectedCard();
				DrawCardWithoutDelay();
				ClearPointer();
			}
		}
	}
	#endregion
	
	#region School Hunter, Leo-pald 
	void SchoolHunterLeopald_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && GetDefensor().IsVanguard() && NumRearGuards("Great Nature") > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();
			}
		}
		else if(cs == CardState.UnitSendToDropZoneFromRC)
		{
			if(VC() && LimitBreak() && CB (1) && CurrentPhaseIs(GamePhase.ENDTURN))
			{
				Card c = Game.field.GetTopCardFromDrop();
				if(c.clan == "Great Nature" && Game.field.ThereIsOpenRC())
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void SchoolHunterLeopald_Active()
	{
		ShowAndDelay();	
	}
	
	void SchoolHunterLeopald_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectUnit("Choose one of your Great Nature rear-guards.", 1, true, 
						delegate {
							IncreasePowerByTurn(Unit, 4000);
							Unit.unitAbilities.AddExternAuto(delegate(CardState cs, Card effectOwner) {
								if(cs == CardState.EndTurn)
								{
									Unit.unitAbilities.RetireUnit(Unit);
								}
							});
						},
						delegate {
							return Unit.clan == "Great Nature";
						},
						delegate {
							ConfirmAttack();
						}
				);
			}
			else
			{
				CounterBlast(1, delegate {
					CallFromDrop(Game.field.GetTopCardFromDrop());	
				});				
			}
		});
		
		CallFromDropUpdate(delegate {
			EndEffect();	
		});
	}
	
	bool SchoolHunterLeopald_OnWindowCancel()
	{
		UnsetBool(1);
		return true;
	}
	
	void SchoolHunterLeopald_Pointer()
	{
		if(CounterBlast_Pointer()) return;
		if(SelectUnit_Pointer()) return;
	}
	#endregion
	
	#region Charjgal
	void Charjgal_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.cardID == CardIdentifier.GREAT_SILVER_WOLF__GARMORE)
			{
				if(Game.field.GetNumberOfCardsInSoul() >= 1)
				{
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	void Charjgal_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void Charjgal_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
			EndEffect();
		});
	}
	#endregion
	
	#region Magical Police, Quilt 
	public void MagicalPoliceQuilt_Auto(CardState cs)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			if(!OwnerCard.IsVanguard())
			{
				if(OwnerCard.boostedUnit == GetAttacker())
				{
					DisplayConfirmationWindow();
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
	}
	
	public void MagicalPoliceQuilt_Active()
	{
		ShowOnScreen();
		EnableMouse("Select a card from you hand and discard it.");
	}
	
	public void MagicalPoliceQuilt_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c))
			{
				DiscardSelectedCard();
				DrawCardWithoutDelay();
				ClearPointer();
			}
		}
	}
	#endregion
	
	#region Devil Summoner
	public void DevilSummoner_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(Game.playerDeck.Size() > 0)
			{
				StartEffect();
				ShowOnScreen(OwnerCard);
				_AuxCard = RevealTopCard();
				Delay(2);
			}
		}
	}
	
	public void DevilSummoner_Update()
	{
		DelayUpdate(delegate{
			if(_AuxCard != null)
			{
				if(_AuxCard.clan == "Spike Brothers" && (_AuxCard.grade == 1 || _AuxCard.grade == 2))
				{
					_AuxIdVector = new List<CardIdentifier>();
					_AuxIdVector.Add(_AuxCard.cardID);
					CallFromDeck(_AuxIdVector);
					HideTopCard();
				}
				else
				{
					HideTopCard();
					Game.playerDeck.Shuffle();
					EndEffect();
				}
			}
		});
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Star Call Trumpeter 
	void StarCallTrumpeter_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Royal Paladin" &&
				CheckCounterBlast(2) &&
				Game.playerDeck.GetNumberNameContainAndGradeLess("Blaster", 2) > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void StarCallTrumpeter_Active()
	{
		ShowAndDelay();	
		FlipCardInDamageZone(2);
	}
	
	void StarCallTrumpeter_Update()
	{
		DelayUpdate(delegate {
			Game.playerDeck.ViewDeck("", 2, "Blaster");
			SetBool(1);
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				CallFromDeck(Game.playerDeck.GetLastSelectedList());	
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Luck Bird
	public void LuckBird_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Call)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 2)
			{
				if(GetVanguard().clan == "Oracle Think Tank")
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void LuckBird_Active()
	{
		ShowOnScreen(OwnerCard);
		SoulBlast(2);
	}
	
	public void LuckBird_Update()
	{
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Red Lighting
	public int RedLighting_Field()
	{
		if(!OwnerCard.IsVanguard())
		{
			if(GetVanguard().clan == "Nova Grappler")
			{
				return 1;
			}
		}
		
		return 0;
	}
	
	public void RedLighting_Active()
	{
		ShowOnScreen(OwnerCard);
		MoveToSoul(OwnerCard);
		UnflipCardInDamageZone(1);
	}
	#endregion
	
	#region Doranbau
	void Doranbau_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.cardID == CardIdentifier.BLASTER_DARK)
			{
				IncreasePowerByBattle(OwnerCard.boostedUnit, 4000);	
			}
		}
	}
	#endregion
	
	#region Lily Knight of the Valley 
	void LilyKnightoftheValley_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.cardID == CardIdentifier.IRIS_KNIGHT)
			{
				IncreasePowerByBattle(OwnerCard.boostedUnit, 4000);	
			}
		}
	}
	#endregion
	
	#region Dueling Dragon, ZANBAKU
	public void Zanbaku_Persistent()
	{
		int power = 0;
		
		if(Game.field.IsNotClan("Murakumo") > 0)
		{
			power -= 2000;	
		}
	}
	
	public void Zanbaku_AutoEnemyTurn(CardState cs)
	{
		if(cs == CardState.EnemyBeginRide)
		{
			if(GetEnemyVanguard().grade >= 3)
			{
				//StartEffect();
				ShowOnScreen();
				DisplayOpponentWindow("You may discard one card from you hand.\nIf you don't do it, you can't normal ride this turn.");
			}
		}
	}
	
	public void Zanbaku_OnOpponentAccept()
	{
		EnemyHasToDiscardOneCard();	
	}
	
	public void Zanbaku_OnOpponentCancel()
	{
		EnemyCannotNormalRide();
	}
	#endregion
	
	#region Navalgazer Dragon 
	void NavalgazerDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && Game.numBattle >= 3)
			{
				IncreasePowerByTurn(OwnerCard, 3000);	
			}
			
			ConfirmAttack();	
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetBool(1) && HitsVanguard() && Game.numBattle >= 3 && VC ())
			{
				if(NumRG(delegate(Card c) { return !c.IsStand() && c.clan == "Aqua Force"; }) > 0)
				{
					StartEffect();
					ShowAndDelay();
					SetBool(2);
				}
			}
		}
	}
	
	int NavalgazerDragon_Field()
	{
		if(VC () && LimitBreak() && CB (2))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void NavalgazerDragon_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void NavalgazerDragon_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(2))
			{
				UnsetBool(2);
				int n = min(2, NumRG(delegate(Card c) { return !c.IsStand() && c.clan == "Aqua Force"; }));
				SelectUnit("Choose " + n + " Aqua Force rear-guards.", n, true,
				delegate {
					StandUnit(Unit);
				},
				delegate {
					return Unit.clan == "Aqua Force" && !Unit.IsStand();
				},
				delegate {
					
				});
			}
			else
			{
			CounterBlast(2,
				delegate {
					IncreasePowerByTurn(OwnerCard, 3000);
					SetBool(1);
					EndEffect();
				});
			}
		});
	}
	
	void NavalgazerDragon_Pointer()
	{
		CounterBlast_Pointer();	
		SelectUnit_Pointer();
	}
	#endregion
	
	#region Covert Demonic Dragon, Magatsu Storm 
	void CovertDemonicDragonMagatsuStorm_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			for(int i = 0; i < cardStorage.Count; i++)
			{
				FromFieldToDeck(cardStorage[i], true);	
			}
			cardStorage.Clear();
			Game.field.RemoveFromHelpZone(OwnerCard);
		}
	}
	
	int CovertDemonicDragonMagatsuStorm_Field()
	{
		if(VC () && LimitBreak() && CB (2))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void CovertDemonicDragonMagatsuStorm_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void CovertDemonicDragonMagatsuStorm_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SetBool(1);
				Game.playerDeck.ViewDeck(2, delegate(Game2DCard c) {
					return c._CardInfo.cardID == CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM;	
				});
			});
		});
		
		if(GetBool(1) && !Game.playerDeck.IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = Game.playerDeck.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck(_AuxIdVector);	
			}
			else
			{
				EndEffect();	
			}
		}
		
		CallFromDeckUpdate(delegate {
			cardStorage = new List<Card>();
				
			for(int i = 0; i < CallFromDeckList.Count; i++)
			{	
				cardStorage.Add(CallFromDeckList[i]);
			}
			
			Game.field.AddToHelpZone(OwnerCard);
			
			ShuffleDeck();
			EndEffect();
		});
	}
	
	void CovertDemonicDragonMagatsuStorm_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Marine General of the Full Tides, Xenophon  
	void MarineGeneraloftheFullTidesXenophon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && Game.numBattle >= 3)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			if(RC () && Game.numBattle >= 3)
			{
				IncreasePowerByBattle(OwnerCard, 1000);	
			}
			
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Key Anchor, Dabid 
	void KeyAnchorDabid_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(CB (1))
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	void KeyAnchorDabid_Active()
	{
		ShowAndDelay();	
	}
	
	void KeyAnchorDabid_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByBattle(OwnerCard, 3000);	
				ConfirmAttack();
			});
		});
	}
	
	void KeyAnchorDabid_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Marine General of the Restless Tides, Algos 
	void MarineGeneraloftheRestlessTidesAlgos_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && VanguardIs("Aqua Force") && Game.numBattle == 4)
			{
				DrawCardWithoutDelay();
			}
		}
	}
	#endregion
	
	#region Top Idol, Flores
	public void TopIdolFlores_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 2 &&
			   Game.field.GetNumberOfRearWithClanName("Bermuda Triangle") > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public void TopIdolFlores_Active()
	{
		ShowOnScreen(OwnerCard);
		SoulBlast(2);
	}
	
	public void TopIdolFlores_Update()
	{
		SoulBlastUpdate(delegate() {
			DisplayHelpMessage("Choose one of your Bermuda Triangle rear-guards, and return it to your hand.");
			_AuxBool = true;
		});
		
		if(_AuxBool)
		{
			if(AcceptInput())
			{
				fieldPositions p = Util.GetMousePosition();
				if(IsRearGuard(p))
				{
					Card c = GetCardAt(p);
					if(c != null && c.clan == "Bermuda Triangle")
					{
						_AuxBool = false;
						ReturnToHand(c);
						ClearMessage();
						EndEffect();
					}
				}
			}
		}
	}
	#endregion
	
	#region Prowling Dragon, Striken
	public void Striken_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.Attacked)
		{
			if(OwnerCard.IsVanguard() && GetAttacker().IsBoostedBy == null)
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
		}
		else if(s == CardState.RideAboveIt)
		{
			if(GetVanguard().clan == "Kagero")
			{
				StartEffect();
				ShowOnScreen();
				Delay(1);
			}
		}
	}
	
	public void Striken_Update()
	{
		DelayUpdate(delegate {
			IncreasePowerAndCriticalByTurn(GetVanguard(), 5000, 1);
			EndEffect();	
		});
	}
	#endregion
	
	#region Failure Scientist, Ponkichi 
	void FailureScientistPonkichi_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Great Nature") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void FailureScientistPonkichi_Active()
	{
		ShowAndDelay();	
	}
	
	void FailureScientistPonkichi_Update()
	{	
		DelayUpdate(delegate {
			if(GetBool(1))
			{	
				SelectInDamage(1, true, delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1, delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	void FailureScientistPonkichi_Pointer()
	{
		if(SelectInDamage_Pointer()) return;
		if(CounterBlast_Pointer()) return;		
	}
	#endregion

	#region See-saw Game Winner  
	void SeesawGameWinner_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Pale Moon") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void SeesawGameWinner_Active()
	{
		ShowAndDelay();	
	}
	
	void SeesawGameWinner_Update()
	{	
		DelayUpdate(delegate {
			if(GetBool(1))
			{	
				SelectInDamage(1, true, delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1, delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	void SeesawGameWinner_Pointer()
	{
		if(SelectInDamage_Pointer()) return;
		if(CounterBlast_Pointer()) return;		
	}
	#endregion
	
	#region Beast in Hand 
	void BeastinHand_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Dark Irregulars") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void BeastinHand_Active()
	{
		ShowAndDelay();	
	}
	
	void BeastinHand_Update()
	{	
		DelayUpdate(delegate {
			if(GetBool(1))
			{	
				SelectInDamage(1, true, delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1, delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	void BeastinHand_Pointer()
	{
		if(SelectInDamage_Pointer()) return;
		if(CounterBlast_Pointer()) return;		
	}
	#endregion
	
	#region Beautiful Harpuia 
	void BeautifulHarpuia_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Dark Irregulars") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void BeautifulHarpuia_Active()
	{
		ShowAndDelay();	
	}
	
	void BeautifulHarpuia_Update()
	{	
		DelayUpdate(delegate {
			if(GetBool(1))
			{	
				SelectInDamage(1, true, delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1, delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	void BeautifulHarpuia_Pointer()
	{
		if(SelectInDamage_Pointer()) return;
		if(CounterBlast_Pointer()) return;		
	}
	#endregion
	
	#region Doctroid Megalos 
	void DoctroidMegalos_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Angel Feather") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void DoctroidMegalos_Active()
	{
		ShowAndDelay();	
	}
	
	void DoctroidMegalos_Update()
	{	
		DelayUpdate(delegate {
			if(GetBool(1))
			{	
				SelectInDamage(1, true, delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1, delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	void DoctroidMegalos_Pointer()
	{
		if(SelectInDamage_Pointer()) return;
		if(CounterBlast_Pointer()) return;		
	}
	#endregion
	
	#region Master of Pain  
	void MasterofPain_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Gold Paladin") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void MasterofPain_Active()
	{
		ShowAndDelay();	
	}
	
	void MasterofPain_Update()
	{	
		DelayUpdate(delegate {
			if(GetBool(1))
			{	
				SelectInDamage(1, true, delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1, delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	void MasterofPain_Pointer()
	{
		if(SelectInDamage_Pointer()) return;
		if(CounterBlast_Pointer()) return;		
	}
	#endregion
	
	#region Doctroid Micros 
	void DoctroidMicros_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Angel Feather") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void DoctroidMicros_Active()
	{
		ShowAndDelay();	
	}
	
	void DoctroidMicros_Update()
	{	
		DelayUpdate(delegate {
			if(GetBool(1))
			{	
				SelectInDamage(1, true, delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1, delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	void DoctroidMicros_Pointer()
	{
		if(SelectInDamage_Pointer()) return;
		if(CounterBlast_Pointer()) return;		
	}
	#endregion
	
	#region Disciple of Pain  
	void DiscipleofPain_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Gold Paladin") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void DiscipleofPain_Active()
	{
		ShowAndDelay();	
	}
	
	void DiscipleofPain_Update()
	{	
		DelayUpdate(delegate {
			if(GetBool(1))
			{	
				SelectInDamage(1, true, delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1, delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	void DiscipleofPain_Pointer()
	{
		if(SelectInDamage_Pointer()) return;
		if(CounterBlast_Pointer()) return;		
	}
	#endregion
	
	#region See-saw Game Loser  
	void SeesawGameLoser_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Angel Feather") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void SeesawGameLosern_Active()
	{
		ShowAndDelay();	
	}
	
	void SeesawGameLoser_Update()
	{	
		DelayUpdate(delegate {
			if(GetBool(1))
			{	
				SelectInDamage(1, true, delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1, delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	void SeesawGameLoser_Pointer()
	{
		if(SelectInDamage_Pointer()) return;
		if(CounterBlast_Pointer()) return;		
	}
	#endregion
	
	#region Explosion Scientist, Bunta 
	void ExplosionScientistBunta_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(CB (1) && VanguardIs("Great Nature") && Game.playerDeck.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(1);
		}
	}
	
	void ExplosionScientistBunta_Active()
	{
		ShowAndDelay();	
	}
	
	void ExplosionScientistBunta_Update()
	{	
		DelayUpdate(delegate {
			if(GetBool(1))
			{	
				SelectInDamage(1, true, delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1, delegate {
					FromDeckToDamage(Game.playerDeck.TopCard());
					Game.field.AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	void ExplosionScientistBunta_Pointer()
	{
		if(SelectInDamage_Pointer()) return;
		if(CounterBlast_Pointer()) return;		
	}
	#endregion
	
	void FromDamageToDeck(Card c)
	{
		int idx = Game.field.GetDamageIndexOf(c);
		Game.field.RemoveFromDamage(c);
		Game.playerDeck.AddCard(c);
		c.TurnUp();
		Game.SendPacket(GameAction.FROM_DAMAGE_TO_DECK, idx);		
	}
	
	#region Lark Pigeon
	public void LarkPigeon_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.BeginGuard)
		{
			if(OwnerCard._Coord == CardCoord.SOUL)
			{
				if(GetVanguard().clan == "Pale Moon" && Game.playerHand.Size () <= 0)
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}	
	}
	
	public void LarkPigeon_Active()
	{
		ShowOnScreen();
		Delay(1);
	}
	
	public void LarkPigeon_Update()
	{
		DelayUpdate(delegate {
			FromSoulToGC(OwnerCard);
			EndEffect();			
		});
	}
	
	public void FromSoulToGC(Card c)
	{
		Game.field.RemoveFromSoulByCard(c);
		Game.guardZone.AddToGuardZone(c, true);
		GetDefensor().AddExtraShield(c.shield);
		Game.SendPacket(GameAction.FROM_SOUL_TO_GC, c.cardID);
	}
	#endregion
	
	#region Unite Attacker
	public void UniteAttacker_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				Game.SoulCharge();
				IncreasePowerByTurn(OwnerCard, 2000);
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(Megablast_Check(5, 8))
			{
				StartEffect();
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public void UniteAttacker_Active()
	{
		ShowOnScreen(OwnerCard);
		Megablast_Active(5, 8);
	}
	
	public void UnitAttacker_Update()
	{
		Megablast_Update(delegate() {
			Game.playerDeck.ViewDeck(5, SearchMode.TOP_CARD, 5, "Spike Brothers");
			_AuxBool = true;	
		});
		
		if(_AuxBool)
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxBool = false;
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				CallFromDeck(_AuxIdVector);
			}
		}
		
		CallFromDeckUpdate(delegate() {
			EndEffect();	
		});
	}
	#endregion

	#region Chappie the Ghostie
	public void ChappieTheGhostie_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.UsedToGuard)
		{
			if(Game.playerDeck.GetNumberOfCardsWithClan("Granblue") > 0)
			{
				ShowOnScreen(OwnerCard);
				StartEffect();
				Game.playerDeck.ViewDeck(1, SearchMode.ALL_DECK, "Granblue");
				_AuxBool = true;
			}
		}
	}
	
	public void ChappieTheGhostie_Update()
	{
		if(_AuxBool)
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxBool = false;
				SendCardFromDeckToDrop(Game.playerDeck.SearchForID(Game.playerDeck.GetLastSelectedList()[0]));
				EndEffect();
				Game.playerDeck.Shuffle();
			}
		}
	}
	#endregion
	
	/*
	 * [AUTO]: When this unit is placed on (VC) or (RC), reveal the top card of your deck.
	 * If the revealed card is a «Royal Paladin», call it to rear-guard, and if it is not,
	 * shuffle your deck. */
	
	#region Gigantech Charger
	public void GigantechCharger_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			StartEffect();
			ShowOnScreen(OwnerCard);
			_AuxCard = RevealTopCard();
			Delay(2);
		}
	}
	
	public void GigantechCharger_Update()
	{
		DelayUpdate(delegate {
			HideTopCard();
			if(_AuxCard.clan == "Royal Paladin")
			{
				_AuxIdVector = new List<CardIdentifier>();
				_AuxIdVector.Add(_AuxCard.cardID);
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();	
			}
		});
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Spiritual Tree Sage, Irminsul 
	public void SpiritualTreeSageIrminsul_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			StartEffect();
			ShowOnScreen(OwnerCard);
			_AuxCard = RevealTopCard();
			Delay(2);
		}
	}
	
	public void SpiritualTreeSageIrminsul_Update()
	{
		DelayUpdate(delegate {
			HideTopCard();
			if(_AuxCard.clan == "Neo Nectar" && (_AuxCard.grade == 1 || _AuxCard.grade == 2))
			{
				_AuxIdVector = new List<CardIdentifier>();
				_AuxIdVector.Add(_AuxCard.cardID);
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();
				ShuffleDeck();
			}
		});
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
			ShuffleDeck();
		});
	}
	#endregion
	
	#region Conjurer of Mithril  
	public void ConjurerofMithril_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			StartEffect();
			ShowOnScreen(OwnerCard);
			_AuxCard = RevealTopCard();
			Delay(2);
		}
	}
	
	public void ConjurerofMithril_Update()
	{
		DelayUpdate(delegate {
			HideTopCard();
			if(_AuxCard.clan == "Royal Paladin" && (_AuxCard.grade == 1 || _AuxCard.grade == 2))
			{
				_AuxIdVector = new List<CardIdentifier>();
				_AuxIdVector.Add(_AuxCard.cardID);
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();	
				ShuffleDeck();
			}
		});
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
			ShuffleDeck();
		});
	}
	#endregion
	
	#region Demonic Dragon Mage, Mahoraga 
	void DemonicDragonMageMahoraga_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(CurrentPhaseIs(GamePhase.MAIN_PHASE))
			{
				IncreasePowerByTurn(OwnerCard, 5000);	
			}
		}
	}
	#endregion
	
	#region Thunder Break Dragon 
	void ThunderBreakDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && GetDefensor().IsVanguard() && LimitBreak())
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
			ConfirmAttack();
		}
		else if(cs == CardState.Ride)
		{
			if(CB (2) && Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(2) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void ThunderBreakDragon_Active()
	{
		ShowAndDelay();	
	}
	
	void ThunderBreakDragon_Update()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's grade 2 or less rear-guards.", 1, true,
							delegate {
								RetireEnemyUnit(EnemyUnit);	
							},
							delegate {
								return EnemyUnit.grade <= 2;	
							},
							delegate {
								
							}
			);
		});
	}
	
	void ThunderBreakDragon_Pointer()
	{
		SelectEnemyUnit_Pointer();	
	}
	#endregion
	
	#region Djinn of the Lightning Flash 
	void DjinnoftheLightningFlash_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ())
			{
				IncreasePowerByBattle(OwnerCard, 4000);
			}
			else
			{
				if(VanguardIs("Narukami"))
				{
					IncreasePowerByBattle(OwnerCard, 2000);	
				}
			}
			
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Djinn of the Lightning Flare 
	void DjinnoftheLightningFlare_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ())
			{
				IncreasePowerByBattle(OwnerCard, 4000);
			}
			else
			{
				if(VanguardIs("Narukami"))
				{
					IncreasePowerByBattle(OwnerCard, 2000);	
				}
			}
			
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Djinn of the Lightning Spark 
	void DjinnoftheLightningSpark_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ())
			{
				IncreasePowerByBattle(OwnerCard, 4000);
			}
			else
			{
				if(VanguardIs("Narukami"))
				{
					IncreasePowerByBattle(OwnerCard, 2000);	
				}
			}
			
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Death Seeker, Thanatos 
	void DeathSeekerThanatos_Auto(CardState cs)
	{
		if(cs == CardState.Attacking) ConfirmAttack();
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && RC() && CB(1) && VanguardIs("Granblue") && Game.field.GetUnitsDropWithClanNameExcept("Granblue", CardIdentifier.DEATH_SEEKER__THANATOS) > 0)	
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void DeathSeekerThanatos_Active()
	{
		ShowAndDelay();	
	}
	
	void DeathSeekerThanatos_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
				         delegate {
							RetireUnit(OwnerCard);	
							Game.field.ViewDropZoneExcept(1, "Granblue", CardIdentifier.DEATH_SEEKER__THANATOS);
							SetBool(1);
						 });
		});
		
		if(GetBool(1))
		{
			if(!Game.field.ViewingDropZone())
			{
				UnsetBool(1);
				CallFromDrop(Game.field.GetDropByID(Game.field.GetLastSelectedList()[0]));	
			}
		}
		
		CallFromDropUpdate(delegate {
			EndEffect();	
		});
	}
	
	void DeathSeekerThanatos_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Violent Vesper 
	public void ViolentVesper_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			StartEffect();
			ShowOnScreen(OwnerCard);
			_AuxCard = RevealTopCard();
			Delay(2);
		}
	}
	
	public void ViolentVesper_Update()
	{
		DelayUpdate(delegate {
			HideTopCard();
			if(_AuxCard.clan == "Megacolony")
			{
				_AuxIdVector = new List<CardIdentifier>();
				_AuxIdVector.Add(_AuxCard.cardID);
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();	
			}
		});
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Dark Mage, Badhabh Caar 
	public void DarkMageBadhabhCaar_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			StartEffect();
			ShowOnScreen(OwnerCard);
			_AuxCard = RevealTopCard();
			Delay(2);
		}
	}
	
	public void DarkMageBadhabhCaar_Update()
	{
		DelayUpdate(delegate {
			HideTopCard();
			if(_AuxCard.clan == "Shadow Paladin")
			{
				_AuxIdVector = new List<CardIdentifier>();
				_AuxIdVector.Add(_AuxCard.cardID);
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();	
			}
		});
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Solitary Knight, Gancelot
	//Solitary Knight, Gancelot
	public bool CheckHandGancelot()
	{
		Card tmpCard = Game.playerDeck.SearchForID(CardIdentifier.BLASTER_BLADE);
		if(tmpCard == null)
		{
			return false;	
		}
		else
		{
			return true;	
		}
	}
	
	public void GancelotActive()
	{
		if(Game._LastUnitAbilityCard.bIsInhand)
		{
			_Card = Game._LastUnitAbilityCard;
			ShowOnScreen(_Card);
			Game.playerDeck.AddCard(Game.playerHand.RemoveFromHand(Game.playerHand.GetCurrentCard()));
			Game.playerDeck.SetDeckPosition();
			Game.SendPacket(GameAction.RETURN_FROM_HAND_TO_DECK);
			Card tmpCard = Game.playerDeck.RemoveFromDeck(Game.playerDeck.SearchForID_GetIndex(CardIdentifier.BLASTER_BLADE));
			Game.SendPacket(GameAction.DRAW_FROM_DECK, 1);
			Game.playerHand.AddToHand(tmpCard);
			Game.SendPacket(GameAction.SHOW_CARD_HAND, tmpCard.cardID, Game.playerHand.Size() - 1);
			Game.playerDeck.Shuffle();
		}
		else
		{
			//Field effect	
			ShowOnScreen(Game._LastUnitAbilityCard);
			FlipCardInDamageZone(2);
			_AuxCard = OwnerCard;
			_Power = 5000;
			_Critical = 1;
			executeAbility = 2;
		}
	}
	
	public int CheckActiveGancelot()
	{
		if(Game.field.SearchInSoulForID(CardIdentifier.BLASTER_BLADE) != null)
		{
			if(Game._LastUnitAbilityCard.IsVanguard())
			{
				if(Game.field.GetNumberOfDamageCardsFaceup() >= 2)
				{
					return 1;	
				}
			}
		}
		
		return 0;
	}
	#endregion
	
	#region Edel Rose
	public bool EdelRose_Hand()
	{
		Card tmpCard = Game.playerDeck.SearchForID(CardIdentifier.WERWOLF_SIEGER);
		if(tmpCard == null)
		{
			return false;	
		}
		else
		{
			return true;	
		}
	}
	
	public void EdelRose_Active()
	{
		if(Game._LastUnitAbilityCard.bIsInhand)
		{
			_Card = Game._LastUnitAbilityCard;
			ShowOnScreen(_Card);
			Game.playerDeck.AddCard(Game.playerHand.RemoveFromHand(Game.playerHand.GetCurrentCard()));
			Game.playerDeck.SetDeckPosition();
			Game.SendPacket(GameAction.RETURN_FROM_HAND_TO_DECK);
			Card tmpCard = Game.playerDeck.RemoveFromDeck(Game.playerDeck.SearchForID_GetIndex(CardIdentifier.WERWOLF_SIEGER));
			Game.SendPacket(GameAction.DRAW_FROM_DECK, 1);
			Game.playerHand.AddToHand(tmpCard);
			Game.SendPacket(GameAction.SHOW_CARD_HAND, tmpCard.cardID, Game.playerHand.Size() - 1);
			Game.playerDeck.Shuffle();
		}
		else
		{
			ShowOnScreen();
			FlipCardInDamageZone(2);
			IncreasePowerAndCriticalByTurn(OwnerCard, 5000, 1);
		}
	}
	
	public int EdelRose_Field()
	{
		if(Game.field.SearchInSoulForID(CardIdentifier.WERWOLF_SIEGER) != null)
		{
			if(OwnerCard.IsVanguard())
			{
				if(Game.field.GetNumberOfDamageCardsFaceup() >= 2)
				{
					return 1;	
				}
			}
		}
		
		return 0;
	}
	#endregion
	
	#region Oasis Girl
	public int OasisGirl_FieldCheck()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
		{
			return 1;
		}
		return 0;
	}
	
	public void OasisGirl_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		_AuxCard = OwnerCard;
		IncreasePowerByTurn(1000);
	}
	#endregion
	
	#region Evil Slaying Swordsman, Haugan 
	public int EvilSlayingSwordsmanHaugan_Field()
	{
		if(CB(1))
		{
			return 1;
		}
		
		return 0;
	}
	
	public void EvilSlayingSwordsmanHaugan_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void EvilSlayingSwordsmanHaugan_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				IncreasePowerByTurn(OwnerCard, 1000);
				EndEffect();
			});
		});
	}
	
	void EvilSlayingSwordsmanHaugan_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion	
	
	#region Tear Knight, Cyprus  
	public int TearKnightCyprus_Field()
	{
		if(CB(1))
		{
			return 1;
		}
		
		return 0;
	}
	
	public void TearKnightCyprus_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void TearKnightCyprus_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				IncreasePowerByTurn(OwnerCard, 1000);
				EndEffect();
			});
		});
	}
	
	void TearKnightCyprus_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion	
	
	#region Thumbtack Fighter, Resanori  
	public int ThumbtackFighterResanori_Field()
	{
		if(CB(1))
		{
			return 1;
		}
		
		return 0;
	}
	
	public void ThumbtackFighterResanori_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void ThumbtackFighterResanori_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				IncreasePowerByTurn(OwnerCard, 1000);
				EndEffect();
			});
		});
	}
	
	void ThumbtackFighterResanori_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion	
	
	#region Lizard Soldier, Riki 
	public int LizardSoldierRiki_Field()
	{
		if(CB(1))
		{
			return 1;
		}
		
		return 0;
	}
	
	public void LizardSoldierRiki_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void LizardSoldierRiki_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				IncreasePowerByTurn(OwnerCard, 1000);
				EndEffect();
			});
		});
	}
	
	void LizardSoldierRiki_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion	
	
	#region Lancet Shooter 
	public int LancetShooter_Field()
	{
		if(CB(1))
		{
			return 1;
		}
		
		return 0;
	}
	
	public void LancetShooter_Active()
	{
		ShowAndDelay();
		StartEffect();
	}
	
	void LancetShooter_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				IncreasePowerByTurn(OwnerCard, 1000);
				EndEffect();
			});
		});
	}
	
	void LancetShooter_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Plasmabite Dragon 
	void PlasmabiteDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(CB (1))
			{
				DisplayConfirmationWindow();	
			}
			else 
			{
				ConfirmAttack();	
			}
		}
	}
	
	void PlasmabiteDragon_Active()
	{
		ShowAndDelay();	
	}
	
	void PlasmabiteDragon_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
				delegate {
					IncreasePowerByBattle(OwnerCard, 3000);
					EndEffect();
				}
			);	
		});
	}
	#endregion
	
	#region Rising Phoenix 
	void RisingPhoenix_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 2 && VanguardIs("Narukami"))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void RisingPhoenix_Active()
	{
		ShowAndDelay();	
	}
	
	void RisingPhoenix_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(2);	
		});	
		
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Child Frank  
	public int ChildFrank_Field()
	{
		if(CB(1))
		{
			return 1;
		}
		
		return 0;
	}
	
	public void ChildFrank_Active()
	{
		ShowAndDelay();
	}
	
	void ChildFrank_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				IncreasePowerByTurn(OwnerCard, 1000);
			});
		});
	}
	
	void ChildFrank_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Caramel Popcorn 
	public int CaramelPopcorn_FieldCheck()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
		{
			return 1;
		}
		return 0;
	}
	
	public void CaramelPopcorn_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		IncreasePowerByTurn(OwnerCard, 1000);
	}
	#endregion
	
	#region Cursed Lancer 
	void CursedLancer_Auto(CardState cs)
	{	
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() &&
				GetVanguard().clan == "Shadow Paladin" &&
				Game.field.GetNumberOfDamageCardsFacedown() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void CursedLancer_Update()
	{
		DelayUpdate(delegate {
			UnflipCardInDamageZone(1);
			EndEffect();
		});
	}
	#endregion
	
	#region Soul Guiding Elf
	public int SoulGuidingElf_FieldCheck()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
		{
			return 1;
		}
		return 0;
	}
	
	public void SoulGuidingElf_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		_AuxCard = OwnerCard;
		IncreasePowerByTurn(1000);
	}
	#endregion
	
	#region Iron Tail Dragon
	public int IronTailDragon_FieldCheck()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
		{
			return 1;
		}
		return 0;
	}
	
	public void IronTailDragon_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		_AuxCard = OwnerCard;
		IncreasePowerByTurn(1000);
	}
	#endregion
	
	#region Accelerated Command 
	void AcceleratedCommand_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(GetNumAnotherRear("Aqua Force") > 0 || VanguardIs("Aqua Force"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void AcceleratedCommand_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Aqua Force units.", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 2000);
			},
			delegate {
				return Unit.clan == "Aqua Force" && Unit != OwnerCard;
			},
			delegate {
				
			}, true);
		});
	}
	
	void AcceleratedCommand_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion	
	
	#region Splash Assault 
	void SplashAssault_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Aqua Force") && Game.numBattle >= 3)
			{	
				IncreasePowerByBattle(OwnerCard, 3000);
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
		
	#region Providence Strategist 
	void ProvidenceStrategist_Auto(CardState cs)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard())
			{	
				if((VC () && NumRearGuards("Gold Paladin") >= 4) || (RC () && NumRearGuards("Gold Paladin") >= 5))
				{	
					if(Game.playerDeck.Size() > 0)
					{
						StartEffect();
						ShowAndDelay();
					}
				}	
			}
		}
	}
	
	void ProvidenceStrategist_Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Sleygal Sword 
	int SleygalSword_Field()
	{
		if((VC () && NumRearGuards("Gold Paladin") >= 4) || (RC () && NumRearGuards("Gold Paladin") >= 5) && CB (1))
		{
			return 1;	
		}
		return 0;
	}
	
	void SleygalSword_Active()
	{
		ShowAndDelay();
		StartEffect();
	}
	
	void SleygalSword_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				IncreasePowerByTurn(OwnerCard, 2000);
				EndEffect();
			});
		});
	}
	
	void SleygalSword_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Battlefield Storm, Sagramore 
	void BattlefieldStormSagramore_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(CB (1))
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	void BattlefieldStormSagramore_Active()
	{
		StartEffect();
		ShowAndDelay();	
	}
	
	void BattlefieldStormSagramore_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				IncreasePowerByBattle(OwnerCard, 3000);
				ConfirmAttack();
				EndEffect();
			});
		});
	}
	
	void BattlefieldStormSagramore_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Sleygal Double Edge 
	int SleygalDoubleEdge_Field()
	{
		if((VC () && NumRearGuards("Gold Paladin") >= 4) || (RC () && NumRearGuards("Gold Paladin") >= 5) && CB (1))
		{
			return 1;	
		}
		return 0;
	}
	
	void SleygalDoubleEdge_Active()
	{
		ShowAndDelay();
		StartEffect();
	}
	
	void SleygalDoubleEdge_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				IncreasePowerByTurn(OwnerCard, 2000);
				EndEffect();
			});
		});
	}
	
	void SleygalDoubleEdge_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	/*
	 * AUTO [V/R]: When this unit's attack hits a vanguard, if you have four or more other «Nova Grappler» rear-guards, draw a card.
	 */
	
	#region Marvelous Hani 
	void MarvelousHani_Auto(CardState cs)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard())
			{	
				if((VC () && NumRearGuards("Nova Grappler") >= 4) || (RC () && NumRearGuards("Nova Grappler") >= 5))
				{	
					if(Game.playerDeck.Size() > 0)
					{
						StartEffect();
						ShowAndDelay();
					}
				}	
			}
		}
	}
	
	void MarvelousHani_Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	#region Ripple Banshee 
	void RippleBanshee_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(GetNumUnits("Granblue") > 1)
			{
				ShowAndDelay();
			}
		}
	}
	
	void RippleBanshee_Active()
	{
		//ShowAndDelay();	
	}
	
	void RippleBanshee_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Granblue units.", 1, true,
						delegate {
							IncreasePowerByTurn(Unit, 2000);	
						},
						delegate {
							return Unit.clan == "Granblue" && Unit != OwnerCard;	
						},
						delegate {
							
						});
		});
	}
	
	void RippleBanshee_Pointer()
	{
		SelectUnit_Pointer(true);	
	}
	#endregion
	
	/*
	 * [AUTO]:When this unit is placed on (RC), choose another of your «Gold Paladin», and that unit gets [Power]+2000 until end of turn.  
	 */
	
	#region Battle Flag Knight, Laudine 
	void BattleFlagKnightLaudine_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(GetNumUnits("Gold Paladin") > 1)
			{
				ShowAndDelay();
			}
		}
	}
	
	void BattleFlagKnightLaudine_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Gold Paladin units.", 1, true,
						delegate {
							IncreasePowerByTurn(Unit, 2000);	
						},
						delegate {
							return Unit.clan == "Gold Paladin" && Unit != OwnerCard;	
						},
						delegate {
							
						});
		});
	}
	
	void BattleFlagKnightLaudine_Pointer()
	{
		SelectUnit_Pointer(true);	
	}
	#endregion
	
	/*
	 * [AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits, if you have a «Dimension Police» vanguard, you may pay the cost. If you do, draw a card.
	 */
	#region Operator Girl, Mika 
	void OperatorGirlMika_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(CB (2) && VanguardIs("Dimension Police"))
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void OperatorGirlMika_Active()
	{
		ShowAndDelay();	
	}
	
	void OperatorGirlMika_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				DrawCardWithoutDelay();
				EndEffect();
			});
		});
	}
	
	void OperatorGirlMika_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Maiden of Rainbow Wood 
	void MaidenofRainbowWood_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(CB (2) && VanguardIs("Neo Nectar"))
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void MaidenofRainbowWood_Active()
	{
		ShowAndDelay();	
	}
	
	void MaidenofRainbowWood_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				DrawCardWithoutDelay();
				EndEffect();
			});
		});
	}
	
	void MaidenofRainbowWood_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Wyvern Supply Unit 
	void WyvernSupplyUnit_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(GetNumUnits("Narukami") > 1)
			{
				ShowAndDelay();
			}
		}
	}
	
	void WyvernSupplyUnit_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Narukami units.", 1, true,
						delegate {
							IncreasePowerByTurn(Unit, 2000);	
						},
						delegate {
							return Unit.clan == "Narukami" && Unit != OwnerCard;	
						},
						delegate {
							
						});
		});
	}
	
	void WyvernSupplyUnit_Pointer()
	{
		SelectUnit_Pointer(true);	
	}
	#endregion
	
	#region Blessing Owl 
	void BlessingOwl_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(GetNumUnits("Gold Paladin") > 1)
			{
				ShowAndDelay();
			}
		}
	}
	
	void BlessingOwl_Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose another of your Gold Paladin units.", 1, true,
						delegate {
							IncreasePowerByTurn(Unit, 2000);	
						},
						delegate {
							return Unit.clan == "Gold Paladin" && Unit != OwnerCard;	
						},
						delegate {
							
						});
		});
	}
	
	void BlessingOwl_Pointer()
	{
		SelectUnit_Pointer(true);	
	}
	#endregion
	
	#region Silver Fang Witch 
	void SilverFangWitch_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 2)
			{
				if(VanguardIs("Gold Paladin") && Game.playerDeck.Size() > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void SilverFangWitch_Active()
	{
		ShowAndDelay();	
	}
	
	void SilverFangWitch_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(2);	
		});
		
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
	#endregion
	
	/*
	 * [AUTO](VC/RC):When another of your grade 3 «Narukami» is placed on (RC), this unit gets [Power]+3000 until end of turn.
	 * */
	
	#region Satellitefall Dragon 
	void SatellitefallDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call_NotMe)
		{
			Card c = Game.LastCall;
			if(c.clan == "Gold Paladin" && c.grade == 3)
			{
				IncreasePowerByTurn(OwnerCard, 3000);	
			}
		}
	}
	#endregion
	
	#region Multimeter Giraffe 
	void MultimeterGiraffe_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.enemyField.GetDamageFaceup() >= 2)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Dreadcharge Dragon 
	void DreadchargeDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call_NotMe)
		{
			Card c = Game.LastCall;
			if(c.clan == "Narukami" && c.grade == 3)
			{
				IncreasePowerByTurn(OwnerCard, 3000);	
			}
		}
	}
	#endregion
	
	#region Captain Nightkid  
	void CaptainNightkid_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Granblue");	
		}
	}
	
	void CaptainNightkid_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void CaptainNightkid_Update()
	{
		Forerunner_Update();	
		
		DelayUpdate(delegate {
			CounterBlast(1,
						delegate {
							MoveToSoul(OwnerCard);
							SetBool(2);
							Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min(10, Game.playerDeck.Size()), "");
						});	
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(2);	
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					Card c = Game.playerDeck.SearchForID(_AuxIdVector[0]);
					if(c.clan == "Granblue")
					{
						SendCardFromDeckToDrop(c);
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	
	int CaptainNightkid_Field()
	{
		if(RC () && CB (1) && Game.playerDeck.Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void CaptainNightkid_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Hades Steersman 
	void HadesSteersman_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZone_Ride)
		{
			if(GetVanguard().grade == 3 && GetVanguard().clan == "Granblue" && OwnerCard._Coord == CardCoord.DROP)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void HadesSteersman_Active()
	{
		ShowAndDelay();	
	}
	
	void HadesSteersman_Update()
	{
		DelayUpdate(delegate {
			CallFromDrop(OwnerCard, fieldPositions.REAR_GUARD_CENTER);
			EndEffect();
		});
	}
	#endregion
	
	#region Gigantech Crusher 
	void GigantechCrusher_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && NumUnitsCalled("Gold Paladin") >= 4)
			{
				IncreasePowerByBattle(OwnerCard, 10000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	int NumUnitsCalled(string clan)
	{
		int num = 0;
		for(int i = 0; i < Game.UnitsCalled.Count; i++)
		{
			if(Game.UnitsCalled[i].clan == clan)
			{
				num++;	
			}
		}
		return num;
	}
	
	#region Sacred Guardian Beast, Elephas  
	void SacredGuardianBeastElephas_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetVanguard().clan == "Gold Paladin" && CB (2) && 
				Game.playerDeck.Count(delegate(Card c) {
										 return c.GetTriggerType() == TriggerIcon.NONE && c.clan == "Gold Paladin" && c.grade == 0;
									  }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void SacredGuardianBeastElephas_Active()
	{
		ShowAndDelay();	
	}
	
	void SacredGuardianBeastElephas_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2, delegate {	
						SetBool(1);
						Game.playerDeck.ViewDeck(1, delegate(Card c) {
													 return c.GetTriggerType() == TriggerIcon.NONE && c.clan == "Gold Paladin" && c.grade == 0;
												  });
			});
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
	
	void SacredGuardianBeastElephas_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Gigantech Commander 
	void GigantechCommander_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetNumberOfRear() > Game.enemyField.GetNumberOfRearUnits())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Holy Mage, Manawydan 
	void HolyMageManawydan_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			Card c = OwnerCard.IsBoostedBy;
			if(c.clan == "Gold Paladin")
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}	
	#endregion
	
	#region Dragon Spirit 
	void DragonSpirit_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.cardID == CardIdentifier.ICE_PRISON_NECROMANCER__COCYTUS)
			{
				if(Game.field.GetNumberOfCardsInSoul() >= 1)
				{
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	void DragonSpirit_Active()
	{
		ShowAndDelay();
	}	
	
	void DragonSpirit_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
			EndEffect();
		});
	}
	#endregion
	
	#region Dragon Dancer, RaiRai 
	void DragonDancerRaiRai_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.Boost)
		{
			Card c = OwnerCard.boostedUnit;
			if(c.cardID == CardIdentifier.ICE_PRISON_NECROMANCER__COCYTUS)
			{
				if(Game.field.GetNumberOfCardsInSoul() >= 1)
				{
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	void DragonDancerRaiRai_Active()
	{
		ShowAndDelay();
	}	
	
	void DragonDancerRaiRai_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard.boostedUnit, 5000);
			EndEffect();
		});
	}
	#endregion
	
	#region Undead Pirate of the Cursed Rifle Undead 
	void PirateoftheCursedRifle_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.playerHand.Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	void PirateoftheCursedRifle_Active()
	{
		ShowAndDelay();	
	}
	
	void PirateoftheCursedRifle_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, true, 
						delegate {
							DiscardSelectedCard();	
						}, 
						delegate {
							return true;	
						},
						delegate {
							IncreasePowerByBattle(OwnerCard, 4000);	
						},
						"Choose a card from your hand.");
		});
	}
	
	void PirateoftheCursedRifle_Pointer()
	{
		SelectInHand_Pointer();	
	}
	#endregion
	
	#region Megacolony Battler A
	public void BattlerA_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromGC)
		{
			SoulChargeFromDrop(OwnerCard);
		}
	}
	#endregion
	
	#region Blazer Idols
	public void BlazerIdols_Auto(CardState cs)
	{
		if(cs == CardState.Call)
		{
			if(Game.field.GetNumberOfCardsWithClanName("Bermuda Triangle") > 1)
			{
				StartEffect();
				ShowAndDelay();
				EnableMouse("Choose one of your Bermuda Triangle rear-guards.");
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
	}
	
	public void BlazerIdols_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Bermuda Triangle")
				{
					IncreasePowerByTurn(c, 2000);
					DisableMouse();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Snow White of the Corals, Claire
	public void SnowWhiteoftheCoralsClaire_Auto(CardState cs)
	{
		if(cs == CardState.Call)
		{
			if(Game.field.GetNumberOfCardsWithClanName("Bermuda Triangle") > 1)
			{
				StartEffect();
				ShowAndDelay();
				EnableMouse("Choose one of your Bermuda Triangle rear-guards.");
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
	}
	
	public void SnowWhiteoftheCoralsClaire_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Bermuda Triangle")
				{
					IncreasePowerByTurn(c, 2000);
					DisableMouse();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Wyvern Strike, Tejas
	public void WyvernStrike_Auto(CardState cs, Card card)
	{
		if(cs == CardState.Attacking)
		{
			if(ExistsBackUnitSameColumn(card.pos) && IsSameColumn(card, GetDefensor()))
			{
				DisplayConfirmationWindow();
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	public void WyvernStrike_Active()
	{
		ShowOnScreen(OwnerCard);
		ChangeTarget(GetBackUnitSameColumn(OwnerCard.pos));
		ConfirmAttack();
	}
	#endregion
	
	#region Demonic Dragon Madonna, Joka
	public void DemonicDragonMadonnaJoka_Auto(CardState cs, Card card)
	{
		if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(CurrentPhaseIs(GamePhase.MAIN_PHASE))
			{
				if(!card.IsVanguard())
				{
					_AuxCard = card;
					IncreasePowerByTurn(3000);
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Demonic Dragon Mage, Rakshasa
	public void DemonicDragonMageRakshasa_Auto(CardState cs, Card card)
	{
		if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(CurrentPhaseIs(GamePhase.MAIN_PHASE))
			{
				if(!card.IsVanguard())
				{
					_AuxCard = card;
					IncreasePowerByTurn(3000);
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Wyvern Strike, Jarran
	public void WyvernStrikeJarran_Auto(CardState cs, Card card)
	{
		if(cs == CardState.Boost)
		{
			if(!card.IsVanguard())
			{
				if(card.boostedUnit.cardID == CardIdentifier.WYVERN_STRIKE_TEJAS)
				{
					_AuxCard = card.boostedUnit;
					IncreasePowerByBattle(4000);
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Core Memory, Armaros 
	void CoreMemoryArmaros_Auto(CardState cs)
	{
		if(cs == CardState.Attacking) ConfirmAttack();
		else if(cs == CardState.AttackHits)
		{
			if(GetVanguard().clan == "Angel Feather" && CB(2))
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void CoreMemoryArmaros_Active()
	{
		ShowAndDelay();	
	}
	
	void CoreMemoryArmaros_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2, delegate {
				DrawCardWithoutDelay();
				EndEffect();
			});
		});
	}
	
	void CoreMemoryArmaros_Pointer()
	{
		if(CounterBlast_Pointer()) return;	
	}
	#endregion
	
	#region Dragon Knight, Aleph
	public int DragonKnightAleph_Field()
	{
		if(CurrentPhaseIs(GamePhase.MAIN_PHASE))
		{
			if(OwnerCard.IsVanguard() && Game.field.GetNumberOfDamageCardsFaceup() > 0)
			{
				if(Game.field.IsCardInRear(CardIdentifier.EMBODIMENT_OF_ARMOR_BAHR))
				{
					if(Game.field.IsCardInRear(CardIdentifier.EMBODIMENT_OF_SPEAR_THAR))
					{
						if(Game.playerDeck.SearchForID(CardIdentifier.EMBODIMENT_OF_VICTORY_ALEPH) != null)
						{
							return 1;
						}
					}
				}
			}
		}
		return 0;
	}
	
	public void DragonKnightAleph_Active()
	{
		ShowOnScreen(OwnerCard);
		EnableMouse();
		DisplayHelpMessage("Select a Embodiment of Armor, Bahr and move it them to the soul.");
		FlipCardInDamageZone(1);
		_AuxBool = true;
	}
	
	public void DragonKnightAleph_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions curPos = Util.GetMousePosition();
			if(!Util.IsEnemyPosition(curPos) && curPos != fieldPositions.VANGUARD_CIRCLE)
			{
				Card curCard = Game.field.GetCardAt(curPos);
				if(curCard != null)
				{
					if(_AuxBool)
					{
						if(curCard.cardID == CardIdentifier.EMBODIMENT_OF_ARMOR_BAHR)
						{
							MoveToSoul(curCard);
							DisplayHelpMessage("Select a Embodiment of Spear, Thar and move it them to the soul.");
							_AuxBool = false;
						}
					}
					else
					{
						if(curCard.cardID == CardIdentifier.EMBODIMENT_OF_SPEAR_THAR)
						{
							_AuxCard = curCard;
							MoveToSoul(curCard);
							DisableMouse();
							ClearMessage();
							_AuxBool2 = true;
						}
					}
				}
			}
		}
	}
	
	public void DragonKnightAleph_Update()
	{
		if(_AuxBool2)
		{
			if(!_AuxCard.AnimationOngoing())
			{
				Card temp = Game.playerDeck.SearchForID(CardIdentifier.EMBODIMENT_OF_VICTORY_ALEPH);
				Game.playerDeck.RemoveFromDeck(temp);
				Game.RideFromDeck(temp);
				_AuxBool2 = false;
			}
		}
	}
	#endregion
	
	#region Barcgal
	public void Barcgal_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Royal Paladin")
			{
				SetCard(OwnerCard);
				DisplayConfirmationWindow();
				_AuxBool = true;
			}			
		}
	}
	
	public void Barcgal_Active()
	{
		if(_AuxBool)
		{
			ShowOnScreen(OwnerCard);
			CallFromSoul(OwnerCard);
			_AuxBool = false;
		}
		else
		{
			StartEffect();
			ShowOnScreen(OwnerCard);
			RestUnit(OwnerCard);
			Game.playerDeck.ViewDeck(CardIdentifier.FLOGAL, CardIdentifier.FUTURE_KNIGHT_LLEW);
			_AuxBool2 = true;
		}
	}
	
	public int Barcgal_Field()
	{
		if(CurrentPhaseIs(GamePhase.MAIN_PHASE) && OwnerCard.IsStand())
		{
			Card temp1 = Game.playerDeck.SearchForID(CardIdentifier.FLOGAL);
			Card temp2 = Game.playerDeck.SearchForID(CardIdentifier.FUTURE_KNIGHT_LLEW);
			if(temp1 != null || temp2 != null)
			{
				return 1;	
			}
		}
		return 0;
	}

	public void Barcgal_Update()
	{
		if(_AuxBool2)
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxBool2 = false;
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
		
		CallFromDeckUpdate(delegate {
			EndEffect();
			Game.playerDeck.Shuffle();
		});
	}
	#endregion
	
	#region Dudley Dan
	public void DudleyDan_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.IsVanguard())
			{
				if(Game.field.GetNumberOfDamageCardsFaceup() >= 2)
				{
					if(Game.playerHand.Size() > 0)
					{
						if(Game.field.GetNumberOfRear() < 5)
						{
							if(Game.playerDeck.GetNumberOfCardsWithClan("Spike Brothers") > 0)
							{
								StartEffect();
								DisplayConfirmationWindow();
							}
						}
					}
				}
			}
		}
	}
	
	public void DudleyDan_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(2);
		//_AuxBool = true;
		DisplayHelpMessage("Choose one card from your hand and put it into your soul.");
		EnableMouse();
	}
	
	public void DudleyDan_Update()
	{
		FromHandToSoulUpdate(delegate {
			Game.playerDeck.ViewDeck(1, SearchMode.ALL_DECK, "Spike Brothers");
			_AuxBool = true;
		});	
		
		if(_AuxBool)
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxBool = false;
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();
			Game.playerDeck.Shuffle();
		});
	}
	
	public void DudleyDan_Pointer()
	{
		if(AcceptInput())
		{
			Card c = Game.playerHand.GetCurrentCardObject();
			if(c._HandleMouse.mouseOn)
			{
				FromHandToSoul(c, Game.playerHand.GetCurrentCard());	
				DisableMouse();
				ClearMessage();
			}
		}
	}
	#endregion
	
	#region Stil Vampir
	public void StillVampir_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard() && Game.playerDeck.Size() > 0)
			{
				IncreasePowerByTurn(OwnerCard, 2000);
				Game.SoulCharge();
			}
		}
		else if(s == CardState.EndTurn)
		{
			if(_AuxBool)
			{
				StartEffect();
				ShowOnScreen();
				_AuxBool = false;
				OpponentRideFromSoul();
			}
		}
	}
	
	public int StillVampir_Field()
	{
		if(Megablast_Check(5, 8) && Game.enemyField.GetNumberOfRearUnits() > 0)
		{
			return 1;		
		}
		
		return 0;
	}
	
	public void StillVampir_Active()
	{
		StartEffect();
		ShowOnScreen();
		Megablast_Active(5, 8);
	}
	
	public void StillVampir_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null)
				{
					EnemyRideFromField(c, false);	
					EndEffect();
					DisableMouse();
					ClearMessage();
				}
			}
		}
	}
	
	public void StillVampir_Update()
	{
		Megablast_Update(delegate {
			EnableMouse();
			DisplayHelpMessage("Choose one of your opponent rear-guards.");
			_AuxBool = true;	
		});
	}
	#endregion
	
	#region Player of the Holy Bow, Viviane 
	void PlayeroftheHolyBowViviane_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() &&
				CheckCounterBlast(1) &&
				Game.playerDeck.Size() > 0 &&
				Game.field.ThereIsOpenRC())
			{
				Card c = OwnerCard.IsBoostedBy;
				if(c != null && c.clan == "Gold Paladin")
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void PlayeroftheHolyBowViviane_Active()
	{
		ShowAndDelay();
	}
	
	void PlayeroftheHolyBowViviane_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, 1, "");
				SetBool(1);
			});	
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromDeck(_AuxIdVector);	
				}
				else
				{
					Game.playerDeck.AddToBottom(Game.playerDeck.DrawCard());
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
	
	void PlayeroftheHolyBowViviane_Pointer()
	{
		if(CounterBlast_Pointer()) return;	
	}
	#endregion
	
	#region Player of the Holy Axe, Nimue 
	void PlayeroftheHolyAxeNimue_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() &&
				CheckCounterBlast(1) &&
				Game.playerDeck.Size() > 0 &&
				Game.field.ThereIsOpenRC())
			{
				Card c = OwnerCard.IsBoostedBy;
				if(c != null && c.clan == "Gold Paladin")
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	void PlayeroftheHolyAxeNimue_Active()
	{
		ShowAndDelay();
	}
	
	void PlayeroftheHolyAxeNimue_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, 1, "");
				SetBool(1);
			});	
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromDeck(_AuxIdVector);	
				}
				else
				{
					Game.playerDeck.AddToBottom(Game.playerDeck.DrawCard());
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
	
	void PlayeroftheHolyAxeNimue_Pointer()
	{
		if(CounterBlast_Pointer()) return;	
	}
	#endregion
	
	#region Deadly Nightmare 
	int DeadlyNightmare_Drop()
	{
		if(Game.field.GetNumberOfCardsInSoul() >= 2 && NumRearGuards("Granblue") > 0 && VanguardIs("Granblue"))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void DeadlyNightmare_Active()
	{
		StartEffect();
		ShowAndDelay();
		Game.field.CloseDeck();
	}
	
	void DeadlyNightmare_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(2);
		});
		
		SoulBlastUpdate(delegate {
			SelectUnit("Choose a Granblue rear-guard", 1, false, 
				       delegate {
					        RetireUnit(Unit);
					   },
			 		   delegate {
							return Unit.clan == "Granblue";
					   },
					   delegate {
							CallFromDrop(OwnerCard);
					   });			
		});
		
		CallFromDropUpdate(delegate {
			EndEffect();	
		});
	}
	
	void DeadlyNightmare_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Crimson Lion Cub, Kyrph 
	void CrimsonLionCubKyrph_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Gold Paladin");
			SetBool(1);
		}
	}
	
	int CrimsonLionCubKyrph_Field()
	{	
		if(RC() && IsInRear(CardIdentifier.KNIGHT_OF_ELEGANT_SKILLS__GARETH) &&
			Game.playerDeck.SearchForID(CardIdentifier.INCANDESCENT_LION__BLOND_EZEL) != null &&
			GetVanguard().cardID == CardIdentifier.KNIGHT_OF_SUPERIOR_SKILLS__BEAUMAINS)
		{
			return 1;	
		}
		
		return 0;
	}
	
	void CrimsonLionCubKyrph_Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			ShowAndDelay();	
		}
	}
	
	void CrimsonLionCubKyrph_Update()
	{
		Forerunner_Update();	
		
		DelayUpdate(delegate {
			SelectUnit("Choose a card named \"Knight of Elegant Skills, Gareth\" from your RC", 1, false,
					    delegate {
							MoveToSoul(Unit);
						},
						delegate {
							return Unit.cardID == CardIdentifier.KNIGHT_OF_ELEGANT_SKILLS__GARETH;
					 	},
						delegate {
							SelectUnit("Choose a card named \"Crimson Lion Cub, Kyrph\" from your RC", 1, false,
					                   delegate {
											MoveToSoul(Unit);
									   },
									   delegate {
											return Unit.cardID == CardIdentifier.CRIMSON_LION_CUB__KYRPH;
									   },
									   delegate {
											Game.RideFromDeck(Game.playerDeck.SearchForID(CardIdentifier.INCANDESCENT_LION__BLOND_EZEL));
											ShuffleDeck();
											EndEffect();
									   });
						});
		});
	}
	
	void CrimsonLionCubKyrph_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
			
	bool CB(int n)
	{
		return CheckCounterBlast(n);		
	}
			
	bool VC()
	{
		return OwnerCard.IsVanguard();		
	}
	
	bool RC()
	{
		return !OwnerCard.IsVanguard();	
	}
	
	#region Incandescent Lion, Blond Ezel 
	void IncandescentLionBlondEzel_Persistent()
	{
		int power = 0;
		if(IsPlayerTurn() && OwnerCard.IsVanguard())
		{
			power += 1000 * NumRearGuards("Gold Paladin");	
		}
		SetPersistentPower(OwnerCard, power);
	}
	
	int IncandescentLionBlondEzel_Field()
	{
		if(LimitBreak() && CheckCounterBlast(2) && Game.playerDeck.Size() > 0 &&
			Game.field.ThereIsOpenRC() && OwnerCard.IsVanguard())
		{
			return 1;	
		}
		
		return 0;
	}
	
	void IncandescentLionBlondEzel_Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	void IncandescentLionBlondEzel_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2, delegate {
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, 1, "");
				SetBool(1);
			});	
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromDeck(_AuxIdVector);	
				}
				else
				{
					Game.playerDeck.AddToBottom(Game.playerDeck.DrawCard());
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			IncreasePowerByTurn(OwnerCard, CallFromDeckList[0].power);
			EndEffect();	
		});
	}
	
	void IncandescentLionBlondEzel_Pointer()
	{
		if(CounterBlast_Pointer()) return;	
	}
	#endregion
	
	#region Ice Prison Necromancer, Cocytus 
	void IcePrisonNecromancerCocytus_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(OwnerCard.IsVanguard() && LimitBreak() && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 5000);
			}
			ConfirmAttack();
		}
		else if(cs == CardState.Ride)
		{
			if(CheckCounterBlast(2)	&& Game.field.NumDropZoneClanName("Granblue") > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void IcePrisonNecromancerCocytus_Active()
	{
		ShowAndDelay();	
		FlipCardInDamageZone(2);
	}
	
	void IcePrisonNecromancerCocytus_Update()
	{
		DelayUpdate(delegate {
			Game.field.ViewDropZone(1, "Granblue");
			SetBool(1);
		});
		
		if(GetBool(1))
		{
			if(!Game.field.ViewingDropZone())
			{
				UnsetBool(1);
				CallFromDrop(Game.field.GetDropByID(Game.field.GetLastSelectedList()[0]));
			}
		}
		
		CallFromDropUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Nightmare Doll, Alice
	public void Alice_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits)
		{
			if(GetVanguard().clan == "Pale Moon" && !OwnerCard.IsVanguard() &&
			   Game.field.GetNumberOfDamageCardsFaceup() >= 1 &&
			   Game.field.GetNumberOfCardsInSoulExcept(CardIdentifier.NIGHTMARE_DOLL__ALICE) > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void Alice_Active()
	{
		ShowOnScreen();
		Delay(1);
		FlipCardInDamageZone(1);
	}
	
	public void Alice_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			Game.field.ViewSoul(1, SearchMode.ALL_EXCEPT, CardIdentifier.NIGHTMARE_DOLL__ALICE, "Pale Moon");
			SetBool (1);
		});
		
		if(GetBool (1))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(1);
				CallFromSoul(Game.field.GetSoulByID(Game.field.GetLastSelectedList()[0]));
			}
		}
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	/// @endcond
	/// @cond
	#region Midnight Bunny 
	public void MidnightBunny_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits_NotMe)
		{
			if(GetVanguard().clan == "Pale Moon" && !OwnerCard.IsVanguard() &&
			   Game.field.GetNumberOfDamageCardsFaceup() >= 1 &&
			   Game.field.GetNumberOfCardsInSoulExcept(CardIdentifier.MIDNIGHT_BUNNY) > 0 &&
			   OwnerCard.boostedUnit != null &&
			   GetAttacker() == OwnerCard.boostedUnit)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void MidnightBunny_Active()
	{
		ShowOnScreen();
		Delay(1);
		FlipCardInDamageZone(1);
	}
	
	public void MidnightBunny_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			Game.field.ViewSoul(1, SearchMode.ALL_EXCEPT, CardIdentifier.MIDNIGHT_BUNNY, "Pale Moon");
			SetBool (1);
		});
		
		if(GetBool (1))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(1);
				CallFromSoul(Game.field.GetSoulByID(Game.field.GetLastSelectedList()[0]));
			}
		}
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Mirror Demon
	public void MirrorDemon_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits)
		{
			if(GetVanguard().clan == "Pale Moon" && !OwnerCard.IsVanguard() &&
			   Game.field.GetNumberOfDamageCardsFaceup() >= 1 &&
			   Game.field.GetNumberOfCardsInSoulExcept(CardIdentifier.MIRROR_DEMON) > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void MirronDemon_Active()
	{
		ShowOnScreen();
		FlipCardInDamageZone(1);
		Delay(1);
	}
	
	public void MirronDemon_Update()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			Game.field.ViewSoul(1, SearchMode.ALL_EXCEPT, CardIdentifier.MIRROR_DEMON, "Pale Moon");
			SetBool (1);
		});
		
		if(GetBool (1))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(1);
				CallFromSoul(Game.field.GetSoulByID(Game.field.GetLastSelectedList()[0]));
			}
		}
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
		
	#region Imprisoned Fallen Angel, Saraqael
	public int Saraqael_Field()
	{
		if(Game.field.GetNumberOfCardsInSoul() >= 3 && (OwnerCard.bRestraintVanguard || OwnerCard.bRestraintRearGuard))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public void Saraqael_Active()
	{
		StartEffect();
		ShowOnScreen();
		SoulBlast(3);
	}
	
	public void Saraqael_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.IsBoosted)
		{
			if(OwnerCard.IsVanguard() && OwnerCard.IsBoostedBy.clan == "Dark Irregulars")	
			{
				IncreasePowerByBattle(OwnerCard, 5000);	
			}
		}
	}
	
	public void Saraqael_Update()
	{
		SoulBlastUpdate(delegate {
			OwnerCard.RemoveRestraint();	
			EndEffect();	
		});
	}
	#endregion
	
	#region Lizard Soldier, Conroe
	public void LizardSoldierConroe_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Kagero")
			{
				DisplayConfirmationWindow();
				_AuxBool = true;
			}			
		}
	}
	
	public void LizardSoldierConroe_Active()
	{
		if(_AuxBool)
		{
			ShowOnScreen(OwnerCard);
			CallFromSoul(OwnerCard);
			_AuxBool = false;
		}
		else
		{
			ShowOnScreen(OwnerCard);
			RetireUnit(OwnerCard);
			Game.playerDeck.ViewDeck("Kagero", 1); 
			_AuxBool2 = true;
			FlipCardInDamageZone(1);
		}
	}
	
	public int LizardSoldierConroe_Field()
	{
		if(CurrentPhaseIs(GamePhase.MAIN_PHASE) && !OwnerCard.IsVanguard() && Game.field.GetNumberOfDamageCardsFaceup() >= 1)
		{
			if(Game.playerDeck.ThereIsUnitGradeOrLess(1))
			{
				return 1;	
			}
		}
		return 0;
	}

	public void LizardSoldierConroe_Update()
	{
		if(_AuxBool2)
		{
			if(!Game.playerDeck.IsOpen())
			{
				Game.playerDeck.Shuffle();
				_AuxBool2 = false;
				Card tempCard = Game.playerDeck.SearchForID(Game.playerDeck.GetLastSelectedList()[0]);
				Game.playerDeck.RemoveFromDeck(tempCard);
				//tempCard.TurnUp();
				Game.playerHand.AddToHand(tempCard);
				Game.SendPacket(GameAction.DRAW_FROM_DECK_AND_SHOW, tempCard.cardID);
				Game.bBlockMouseOnce = true;
			}
		}
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Dancing Cutlass
	public void DancingCutlass_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 2)
			{
				if(GetVanguard().clan == "Granblue")
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void DancingCutlass_Active()
	{
		ShowOnScreen(OwnerCard);
		SoulBlast(2);	
	}
	
	public void DancingCutlass_Update()
	{
		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();	
			EndEffect();
		});
	}
	#endregion
		
	#region Mobile Hospital, Feather Palace 
	void MobileHospitalFeatherPalace_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(VC ())
			{
				Game.SoulCharge();
				IncreasePowerByTurn(OwnerCard, 2000);
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(VC() && Megablast_Check(5, 8) && HitsVanguard())
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void MobileHospitalFeatherPalace_Active()
	{
		Megablast_Active(5, 8);	
	}
	
	void MobileHospitalFeatherPalace_Update()
	{
		Megablast_Update(delegate {
			Heal (NumRearGuards("Angel Feather"));	
		});
	}
	
	void MobileHospitalFeatherPalace_Pointer()
	{
		Heal_Pointer();	
	}
	#endregion
	
	#region Miracle Feather Nurse 
	void MiracleFeatherNurse_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.HEAVENLY_INJECTOR)
			{	
				StartEffect();
				ShowAndDelay();
			}
			else if(VanguardIs("Angel Feather"))
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void MiracleFeatherNurse_Active()
	{
		ShowAndDelay();
		SetBool(2);
	}
	
	void MiracleFeatherNurse_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(2))
			{
				UnsetBool(2);
				CallFromSoul(OwnerCard);
			}
			else
			{
				DisplayHelpMessage("Choose up to one \"Cosmo Healer, Ergodiel\" or \"Fate Healer, Ergodiel\".");
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min(7, Game.playerDeck.Size()), "");
				SetBool(1);
			}
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				ClearMessage();
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CardIdentifier id = _AuxIdVector[0];
					if(id == CardIdentifier.COSMO_HEALER__ERGODIEL || id == CardIdentifier.FATE_HEALER__ERGODIEL)
					{
						FromDeckToHand(id);
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Schoolyard Prodigy, Lox 
	void SchoolyardProdigyLox_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.BRINGER_OF_KNOWLEDGE__LOX)
			{	
				StartEffect();
				ShowAndDelay();
			}
			else if(VanguardIs("Great Nature"))
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void SchoolyardProdigyLox_Active()
	{
		ShowAndDelay();
		SetBool(2);
	}
	
	void SchoolyardProdigyLox_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(2))
			{
				UnsetBool(2);
				CallFromSoul(OwnerCard);
			}
			else
			{
				DisplayHelpMessage("Choose up to one \"Guardian of Truth, Lox\" or \"Law Official, Lox\".");
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, min(7, Game.playerDeck.Size()), "");
				SetBool(1);
			}
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				ClearMessage();
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CardIdentifier id = _AuxIdVector[0];
					if(id == CardIdentifier.GUARDIAN_OF_TRUTH__LOX || id == CardIdentifier.LAW_OFFICIAL__LOX)
					{
						FromDeckToHand(id);
					}
				}
				ShuffleDeck();
				EndEffect();
			}
		}
	}
	#endregion
	
	#region Master Swordsman, Nightstorm  
	void MasterSwordsmanNightstorm_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Granblue") && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Skeleton Demon World Knight 
	void SkeletonDemonWorldKnight_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.BeginMain)
		{
			if(VC () && HandSize("Granblue") > 0 && GetEnemyVanguard().grade >= 3)
			{	
				DisplayConfirmationWindow();
			}
		}
	}
	
	void SkeletonDemonWorldKnight_Active()
	{
		ShowAndDelay();	
	}
	
	void SkeletonDemonWorldKnight_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, 
					     false,
				         delegate {
							DiscardSelectedCard();
						 },
						 delegate {
							return _SIH_Card.clan == "Granblue";
						 },
						 delegate {
							if(Game.field.GetDropByID(CardIdentifier.ICE_PRISON_NECROMANCER__COCYTUS) != null)
							{
								RideFromDropZone(Game.field.GetDropByID(CardIdentifier.ICE_PRISON_NECROMANCER__COCYTUS));
								Game.bRideThisTurn = false;	
							}
							EndEffect();
					    }, 
			            "Choose a Granblue from your hand."
			);
		});
	}
	
	void SkeletonDemonWorldKnight_Pointer()
	{
		SelectInHand_Pointer();	
	}
	#endregion
	
	#region Skeleton Colossus 
	void SkeletonColossus_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.BeginMain)
		{
			if(VC () && HandSize("Granblue") > 0 && GetEnemyVanguard().grade >= 2)
			{	
				DisplayConfirmationWindow();
			}
		}
	}
	
	void SkeletonColossus_Active()
	{
		ShowAndDelay();	
	}
	
	void SkeletonColossus_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, 
					     false,
				         delegate {
							DiscardSelectedCard();
						 },
						 delegate {
							return _SIH_Card.clan == "Granblue";
						 },
						 delegate {
							if(Game.field.GetDropByID(CardIdentifier.SKELETON_DEMON_WORLD_KNIGHT) != null)
							{
								RideFromDropZone(Game.field.GetDropByID(CardIdentifier.SKELETON_DEMON_WORLD_KNIGHT));
								Game.bRideThisTurn = false;	
							}
							EndEffect();
					    }, 
			            "Choose a Granblue from your hand."
			);
		});
	}
	
	void SkeletonColossus_Pointer()
	{
		SelectInHand_Pointer();	
	}
	#endregion
	
	#region Deadly Spirit 
	int DeadlySpirit_Drop()
	{
		if(Game.field.GetNumberOfCardsInSoul() >= 2 && Game.field.GetNumberOfRearWithClanNameAndGradeGreaterOrEqual("Granblue", 1) > 0 &&
			VanguardIs("Granblue"))
		{
			return 1;	
		}
		
		return 0;
	}
	
	void DeadlySpirit_Active()
	{
		StartEffect();
		ShowAndDelay();
		Game.field.CloseDeck();
	}
	
	void DeadlySpirit_Update()
	{
		DelayUpdate(delegate {
			SoulBlast(2);	
		});
		
		SoulBlastUpdate(delegate {
			SelectUnit("Choose a grade 1 or greater Granblue rear-guard.",
					   1,
				       false,
				       delegate {
							RetireUnit(Unit);
					   },
					   delegate {
							return Unit.clan == "Granblue" && Unit.grade >= 1;
					   },
					   delegate {
							CallFromDrop(OwnerCard);			
					   }
			);
		});
		
		CallFromDropUpdate(delegate {
			EndEffect();	
		});
	}
	
	void DeadlySpirit_Pointer()
	{
		SelectUnit_Pointer();	
	}
	#endregion
	
	#region Drill Bullet, Geniel 
	void DrillBulletGeniel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VanguardIs("Angel Feather") && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region The Phoenix, Calamity Flame 
	void ThePhoenixCalamityFlame_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.CardPutInDamage)
		{
			if(VanguardIs("Angel Feather"))
			{
				IncreasePowerByTurn(OwnerCard, 2000);	
			}
		}
		
	}
	#endregion
	
	#region Thousand Ray Pegasus 
	void ThousandRayPegasus_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.CardPutInDamage)
		{
			if(VanguardIs("Angel Feather"))
			{
				IncreasePowerByTurn(OwnerCard, 2000);	
			}
		}
		
	}
	#endregion
	
	#region Million Ray Pegasus 
	void MillionRayPegasus_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.CardPutInDamage)
		{
			if(VanguardIs("Angel Feather"))
			{
				IncreasePowerByTurn(OwnerCard, 2000);	
			}
		}
	}
	#endregion
	
	#region Iron Heart, Mastema 
	void IronHeartMastema_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetDamage() >= Game.enemyField.GetDamage())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Three Star Chef, Pietro 
	void ThreeStarChefPietro_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && VanguardIs("Granblue") && Game.field.GetNumberOfDamageCardsFacedown() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void ThreeStarChefPietro_Update()
	{
		DelayUpdate(delegate {
			Flipup(1,
				delegate {
					EndEffect();		
				}
			);	
		});
	}
	
	void ThreeStarChefPietro_Pointer()
	{
		Flipup_Pointer();	
	}
	#endregion
	
	#region Muscle Hercules 
	void MuscleHercules_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(VanguardIs("Nova Grappler") && Game.field.GetNumberOfDamageCardsFacedown() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void MuscleHercules_Update()
	{
		DelayUpdate(delegate {
			Flipup(1,
				delegate {
					EndEffect();		
				}
			);	
		});
	}
	
	void MuscleHercules_Pointer()
	{
		Flipup_Pointer();	
	}
	#endregion
	
	#region Kungfu Kid, Bolta 
	void KungfuKidBolta_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetNumberOfRear() > Game.enemyField.GetNumberOfRearUnits())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Cup Bowler 
	void CupBowler_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Rest_NotMe)
		{
			Card c = Game.LastRest;
			if(!c.IsVanguard() && c.clan == "Nova Grappler")
			{
				IncreasePowerByTurn(OwnerCard, 1000);	
			}
		}
	}
	#endregion
	
	#region Demonic Dragon Berserker, Garuda 
	void DemonicDragonBerserkerGaruda_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && VanguardIs("Narukami") && Game.field.GetNumberOfDamageCardsFacedown() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void DemonicDragonBerserkerGaruda_Update()
	{
		DelayUpdate(delegate {
			Flipup(1,
				delegate {
					EndEffect();		
				}
			);	
		});
	}
	
	void DemonicDragonBerserkerGaruda_Pointer()
	{
		Flipup_Pointer();	
	}
	#endregion
	
	#region Mage of Calamity, Tripp 
	void MageofCalamityTripp_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(HitsVanguard() && VanguardIs("Gold Paladin") && Game.field.GetNumberOfDamageCardsFacedown() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	void MageofCalamityTripp_Update()
	{
		DelayUpdate(delegate {
			Flipup(1,
				delegate {
					EndEffect();		
				}
			);	
		});
	}
	
	void MageofCalamityTripp_Pointer()
	{
		Flipup_Pointer();	
	}
	#endregion
	
	#region Brutal Jack
	public int BrutalJack_Field()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 1 && (OwnerCard.bRestraintVanguard || OwnerCard.bRestraintRearGuard))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public void BrutalJack_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		OwnerCard.RemoveRestraint();
	}
	
	public void BrutalJack_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.IsBoosted)
		{
			if(OwnerCard.IsVanguard() && OwnerCard.IsBoostedBy != null && OwnerCard.IsBoostedBy.clan == "Nova Grappler")
			{
				_AuxCard = OwnerCard;
				IncreasePowerByBattle(5000);	
			}
		}
	}
	#endregion
	
	#region Screamin' and Dancin' Announcer, Shout
	public int ScreamingShout_FieldCheck()
	{
		if(CurrentPhaseIs(GamePhase.MAIN_PHASE) && OwnerCard.IsStand() && Game.playerHand.Size() > 0)
		{
			return 1;	
		}
		return 0;
	}
	
	public void ScreamingShout_Active()
	{
		ShowOnScreen(OwnerCard);
		RestUnit(OwnerCard);
		EnableMouse();
		DisplayHelpMessage("Choose a card from you hand and discard it.");
		_AuxBool = true;
		Game.bEffectOnGoing = true;
	}
	
	public void ScreamingShout_Pointer()
	{
		if(AcceptInput())
		{
			if(_AuxBool)
			{
				_AuxBool = false;
				return;
			}
			
			DisableMouse();
			DiscardSelectedCard();
			DrawCard();
			ClearMessage();
			Game.bEffectOnGoing = false;
		}
	}
	#endregion
	
	#region Lady of the Sunlight Forest 
	public int LadyoftheSunlightForest_FieldCheck()
	{
		if(CurrentPhaseIs(GamePhase.MAIN_PHASE) && OwnerCard.IsStand() && Game.playerHand.Size() > 0)
		{
			return 1;	
		}
		return 0;
	}
	
	public void LadyoftheSunlightForest_Active()
	{
		ShowOnScreen(OwnerCard);
		RestUnit(OwnerCard);
		EnableMouse();
		DisplayHelpMessage("Choose a card from you hand and discard it.");
		_AuxBool = true;
		Game.bEffectOnGoing = true;
	}
	
	public void LadyoftheSunlightForest_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c))
			{
				DisableMouse();
				DiscardSelectedCard();
				DrawCardWithoutDelay();
				ClearMessage();
				Game.bEffectOnGoing = false;
			}
		}
	}
	#endregion
	
	#region Tyrant, Deathrex
	public void TyrantDeathrex_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(OwnerCard.IsVanguard())	
			{
				ShowOnScreen(OwnerCard);
				_AuxCard = OwnerCard;
				IncreasePowerByBattle(5000);
				ConfirmAttack();
			}
			else
			{
				ConfirmAttack();	
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(OwnerCard.IsVanguard())	
			{
				if(Game.field.GetNumberOfRear() > 0)
				{
					EnableMouse();
					ShowOnScreen(OwnerCard);
					DisplayHelpMessage("Choose one of you rear-guards and retire it");
					Game.bEffectOnGoing = true;
				}
			}
		}
	}
	
	public void TyrantDeathrex_Pointer()
	{
		if(AcceptInput())	
		{
			fieldPositions pos = Util.GetMousePosition();
			if(!Util.IsEnemyPosition(pos) && pos != fieldPositions.VANGUARD_CIRCLE)
			{
				Card temp = Game.field.GetCardAt(pos);
				if(temp != null)
				{
					DisableMouse();
					ClearMessage();
					Game.bEffectOnGoing = false;
					RetireUnit(temp);
				}
			}
		}
	}
	#endregion
	
	#region Hungry Dumpty
	public void HungryDumpty_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Nova Grappler")
			{
				if(Game.field.GetNumberOfDamageCardsFacedown() >= 1)
				{
					ShowOnScreen(OwnerCard);
					UnflipCardInDamageZone(1);
				}
			}
		}
	}
	#endregion
	
	bool IsInRear(CardIdentifier id)
	{
		return Game.field.GetRearCardByID(id) != null;	
	}
	
	//+5000 Shield at Intercept
	#region Security Guardian
	public void SecurityGuardian_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Oracle Think Tank")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Titan of the Infinite Trench 
	public void TitanoftheInfiniteTrench_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Aqua Force")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region NGM Prototype
	public void NGMPrototype_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Nova Grappler")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Globe Armadillo 
	public void GlobeArmadillo_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Great Nature")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Shieldblade Dragoon 
	public void ShieldbladeDragoon_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Narukami")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Sacred Guardian Beast, Nemean Lion 
	public void SacredGuardianBeastNemeanLion_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Gold Paladin")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Charging Chariot Knight 
	void ChargingChariotKnight_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.playerHand.Size() < Game.enemyHand.Size())
			{	
				IncreasePowerByBattle(OwnerCard, 3000);
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Brightjet Dragon 
	void BrightjetDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.playerHand.Size() < Game.enemyHand.Size())
			{	
				IncreasePowerByBattle(OwnerCard, 3000);
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Holy Zone, Penemue 
	public void HolyZonePenemue_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Angel Feather")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Colossal Wings, Simurgh 
	public void ColossalWingsSimurgh_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Neo Nectar")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Demon World Castle, Fatalita
	public void Fatalita_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Shadow Paladin")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Diva of Clear Waters, Izumi 
	public void DivaofClearWatersIzumi_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Bermuda Triangle")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Dragon Knight, Berger
	public void Berger_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Kagero")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Knight of Truth, Gordon
	public void Gordon_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Royal Paladin")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Skeleton Swrodsman
	public void SkeletonSwordsman_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Granblue")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Panzer Gale
	public void PanzerGale_Auto(CardState cs)
	{
		if(cs == CardState.Intercept)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Spike Brothers")
			{
				ShowOnScreen(OwnerCard);
				AddPowerToGuardZone(5000);
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	#endregion
	
	#region Soul Saver Dragon
	public void SoulSaverDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(OwnerCard.IsVanguard() && GetDefensor().IsVanguard())
			{
				_AuxCard = OwnerCard;
				IncreasePowerByBattle(3000);
			}
			
			ConfirmAttack();
		}
		else if(cs == CardState.Ride)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 5 && Game.field.GetNumberOfRearWithClanName("Royal Paladin") > 0)
			{
				Game.bEffectOnGoing = true;
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public void SoulSaverDragon_Active()
	{
		ShowOnScreen(OwnerCard);
		SoulBlast(5);
	}
	
	public void SoulSaverDragon_Update()
	{
		SoulBlastUpdate(delegate {
				int numUnits = Game.field.GetNumberOfRearWithClanName("Royal Paladin");
				if(3 > numUnits)
				{
					_AuxInt = numUnits;	
				}
				else
				{
					_AuxInt = 3;	
				}
				EnableMouse();
				DisplayHelpMessage("Choose " + _AuxInt + " Royal Paladin units."); 
				ClearAuxBool20Array();
		});
	}
	
	public void SoulSaverDragon_Pointer()
	{
		if(AcceptInput())
		{
			if(_AuxInt > 0)
			{
				fieldPositions p = Util.GetMousePosition();
				Debug.Log ((int)p);
				if(!Util.IsEnemyPosition(p) && p != fieldPositions.VANGUARD_CIRCLE && !_AuxBool20Array[(int)p])
				{
					Card c = Game.field.GetCardAt(p);
					if(c != null && c.clan == "Royal Paladin")
					{
						_AuxInt--;
						IncreasePowerByTurn(c, 5000);
						_AuxBool20Array[(int)p] = true;
						if(_AuxInt <= 0)
						{
							DisableMouse();
							ClearMessage();
							ClearAuxBool20Array();
							Game.bEffectOnGoing = false;
						}
					}
				}
			}
		}
	}
	#endregion
	
	#region Demonic Dragon Mage, Kimnara
	public int Kimnara_Field()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
		{
			if(!OwnerCard.IsVanguard())	
			{
				if(GetVanguard().clan == "Kagero")
				{
					if(Game.enemyField.GetNumberOfUnitGradeEqualOrLessThan(1) > 0)
					{
						return 1;	
					}
				}
			}
		}
		return 0;
	}
	
	public void Kimnara_Active()
	{
		FlipCardInDamageZone(1);
		MoveToSoul(OwnerCard);
		ShowOnScreen(OwnerCard);
		EnableMouse();
		DisplayHelpMessage("Choose up to one of your opponent's grade 1 rear-guards, and retire it.");
		StartEffect();
	}
	
	public void Kimnara_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null && c.grade <= 1)
				{
					RetireUnit(c);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Blazing Core Dragon
	public int BlazingCoreDragon_Field()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 1 && OwnerCard.IsVanguard())
		{
			if(Game.field.GetRearCardByID(CardIdentifier.IRON_TAIL_DRAGON) != null)
			{
				if(Game.field.GetRearCardByID(CardIdentifier.GATTLING_CLAW_DRAGON) != null)
				{
					return 1;	
				}
			}
		}
			
		return 0;
	}
	
	public void BlazingCoreDragon_Active()
	{
		StartEffect();
		ShowOnScreen(OwnerCard);
		EnableMouse();
		DisplayHelpMessage("Choose a unit named \"Iron Tail Dragon\" and put it into your soul.");
		_AuxBool = true;
		FlipCardInDamageZone(1);
	}
	
	public void BlazingCore_Pointer()
	{
		if(AcceptInput())	
		{	
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null)
				{
					if(c.cardID == CardIdentifier.IRON_TAIL_DRAGON && _AuxBool)
					{
						MoveToSoul(c);
						_AuxBool = false;
						DisplayHelpMessage("Choose a unit named \"Gatling Claw Dragon\" and put it into your soul.");
					}
					else if(c.cardID == CardIdentifier.GATTLING_CLAW_DRAGON && !_AuxBool)
					{
						MoveToSoul(c);
						ClearMessage();
						DisableMouse();
						Game.RideFromDeck(Game.playerDeck.SearchForID(CardIdentifier.BLAZING_FLARE_DRAGON));
						EndEffect();
					}
				}
			}
		}
	}
	#endregion
	
	#region Blazing Flare Dragon
	public void BlazingFlareDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(CurrentPhaseIs(GamePhase.MAIN_PHASE))
			{
				OwnerCard.IncreasePowerUntilEndTurn (3000);	
			}
		}
	}
	
	public int BlazingFlareDragon_Field()
	{
		if(Game.enemyField.GetNumberOfRearUnits() > 0 && OwnerCard.IsVanguard())
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 5)
			{
				return 1;	
			}
		}
		
		return 0;
	}
	
	public void BlazingFlareDragon_Active()
	{
		ShowOnScreen(OwnerCard);
		Game.bEffectOnGoing = true;
		_AuxBool = true;
		Game.field.ViewSoul(5);
		_AuxCard2 = null;
	}
	
	public void BlazingFlareDragon_Update()
	{
		if(_AuxBool)
		{
			if(!Game.field.ViewingSoul())
			{
				_AuxInt = 5;
				_AuxBool = false;
				_AuxBool2 = true;
				_AuxIdVector = Game.field.GetLastSelectedList();
			}
		}
		
		if(_AuxBool2)
		{
			if(_AuxCard2 == null || !_AuxCard2.AnimationOngoing())
			{
				_AuxInt--;
				_AuxCard2 = Game.field.GetSoulByID(_AuxIdVector[0]);
				_AuxIdVector.RemoveAt(0);
				Game.SoulBlast(_AuxCard2);
				if(_AuxInt <= 0)
				{
					_AuxBool2 = false;
					EnableMouse();
					DisplayHelpMessage("Choose one of your opponent's rear-guards, and retire it");
				}
			}
		}
	}
	
	public void BlazingFlareDragon_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null)
				{
					RetireEnemyUnit(c);
					DisableMouse();
					ClearMessage();
					Game.bEffectOnGoing = false;
				}
			}
		}
	}	
	#endregion
	
	#region Miracle Beauty 
	void MiracleBeauty_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Stand)
		{
			if(CurrentPhaseIs(GamePhase.ATTACK) &&
				GetVanguard().clan == "Dimension Police")
			{
				Card c = GetSameColum(OwnerCard.pos);
				if(c != null)
				{
					StandUnit(c);	
				}
			}
		}
	}
	#endregion
	
	#region Swordsman of the Explosive Flames, Palamedes
	public void Palamedes_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			int n = NumRG(delegate(Card c) {
				return c.BelongsToClan("Royal Paladin") && c.grade == 3;	
			});
			
			if(GetVanguard().BelongsToClan("Royal Paladin") && GetVanguard().grade == 3)
			{
				n++;	
			}
			
			if(n >= 2)
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			ConfirmAttack();
		}
	}
	#endregion

	#region General Seifried
	public void GeneralSeifried_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DriveCheck)
		{
			if(OwnerCard.IsVanguard() && Game.DriveCard != null && Game.DriveCard.clan == "Spike Brothers" && Game.DriveCard.grade == 3)
			{
				if(Game.field.GetNumberOfRear() < 5)
				{
					Game.bEffectOnGoing = true;
					Game.bBlockDriveCheck = true;
					DisplayConfirmationWindow();
				}
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			if(OwnerCard.IsVanguard() && OwnerCard.IsBoostedBy != null && OwnerCard.IsBoostedBy.clan == "Spike Brothers")
			{
				_AuxCard = OwnerCard;
				IncreasePowerByBattle(3000);	
			}
		}
	}
	
	public void GeneralSeifried_Active()
	{
		ShowOnScreen(OwnerCard);
		DisplayHelpMessage("Choose an open (RC) to call this unit.");
		Game.bBlockUnitReplacing = true;
		CallFromDrive();
		_AuxBool = true;
	}
	
	public void GeneralSeifried_Update()
	{
		if(_AuxBool)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				_AuxBool = false;
				Game.bEffectOnGoing = false;
				Game.bBlockDriveCheck = false;
				Game.bBlockUnitReplacing = false;
				ClearMessage();
			}
			else
			{
				Game.HandleSpecialCallFromDrive();	
			}
		}
	}
	#endregion
	
	#region Spike Bouncer
	public void SpikeBouncer_Auto(CardState s)
	{
		if(s == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(s == CardState.AttackHits_NotMe)
		{
			if(GetAttacker().clan == "Spike Brothers" && GetDefensor().IsVanguard())
			{
				IncreasePowerByTurn(OwnerCard, 3000);	
			}
		}
	}
	#endregion
	
	#region Dumbbell Kangaroo 
	public void DumbbellKangaroo_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(OwnerCard.IsVanguard())
			{
				if(Game.field.GetNumberOfDamageCardsFaceup() >= 2 && GetDefensor().IsVanguard())
				{
					if(Game.field.GetNumberOfRearUnitsRestedWithClanName("Great Nature") > 0)
					{
						Game.bEffectOnGoing = true;
						DisplayConfirmationWindow();
					}
				}
			}
			else
			{
				if(Game.field.GetNumberOfDamageCardsFaceup() >= 2 && GetDefensor().IsVanguard())
				{
					if(Game.field.GetNumberOfRearUnitsRestedWithClanNameAndGradeLessOrEqual("Great Nature", 1) > 0)
					{
						Game.bEffectOnGoing = true;
						DisplayConfirmationWindow();
					}	
				}
			}
		}
	}
	
	public void DumbbellKangaroo_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(2);
		EnableMouse();
		if(OwnerCard.IsVanguard())
		{
			DisplayHelpMessage("Choose one of your Great Nature rear-guards and [Stand] it.");
		}
		else
		{
			DisplayHelpMessage("Choose one of your Grade 1 or less Great Nature rear-guards and [Stand] it.");		
		}
	}
	
	public void DumbbellKangaroo_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			
			if(!Util.IsEnemyPosition(p) && p != fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				
				if(c != null && !c.IsStand() && c.clan == "Great Nature")
				{
					if(OwnerCard.IsVanguard())
					{
						StandUnit(c);
						DisableMouse();
						ClearMessage();
						Game.bEffectOnGoing = false;
					}
					else
					{
						if(c.grade <= 1)
						{
							StandUnit(c);	
							DisableMouse();
							ClearMessage();
							Game.bEffectOnGoing = false;
						}
					}
				}
			}
		}
	}
	#endregion
	
	#region Lion Heat
	public void LionHeat_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(OwnerCard.IsVanguard())
			{
				if(Game.field.GetNumberOfDamageCardsFaceup() >= 2 && GetDefensor().IsVanguard())
				{
					if(Game.field.GetNumberOfRearUnitsRestedWithClanName("Nova Grappler") > 0)
					{
						Game.bEffectOnGoing = true;
						DisplayConfirmationWindow();
					}
				}
			}
			else
			{
				if(Game.field.GetNumberOfDamageCardsFaceup() >= 2 && GetDefensor().IsVanguard())
				{
					if(Game.field.GetNumberOfRearUnitsRestedWithClanNameAndGradeLessOrEqual("Nova Grappler", 1) > 0)
					{
						Game.bEffectOnGoing = true;
						DisplayConfirmationWindow();
					}	
				}
			}
		}
	}
	
	public void LionHeat_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(2);
		EnableMouse();
		if(OwnerCard.IsVanguard())
		{
			DisplayHelpMessage("Choose one of your Nova Grappler rear-guards and [Stand] it.");
		}
		else
		{
			DisplayHelpMessage("Choose one of your Grade 1 or less Nova Grappler rear-guards and [Stand] it.");		
		}
	}
	
	public void LionHeat_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			
			if(!Util.IsEnemyPosition(p) && p != fieldPositions.VANGUARD_CIRCLE)
			{
				Card c = Game.field.GetCardAt(p);
				
				if(c != null && !c.IsStand() && c.clan == "Nova Grappler")
				{
					if(OwnerCard.IsVanguard())
					{
						StandUnit(c);
						DisableMouse();
						ClearMessage();
						Game.bEffectOnGoing = false;
					}
					else
					{
						if(c.grade <= 1)
						{
							StandUnit(c);	
							DisableMouse();
							ClearMessage();
							Game.bEffectOnGoing = false;
						}
					}
				}
			}
		}
	}
	#endregion
	
	#region Seal Dragon, Blockade
	public void SealDragonBlockade_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				Game.SendPacket(GameAction.BLOCK_INTERCEPT_UNTIL_ENDTURN);	
			}
		}
		else if(cs == CardState.Ride)
		{
			Game.SendPacket(GameAction.BLOCK_INTERCEPT_UNTIL_ENDTURN);	
		}
	}
	#endregion
	
	#region Miss Splendor
	public void MissSplendor_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			Game.SendPacket(GameAction.BLOCK_INTERCEPT_UNTIL_ENDBATTLE);
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Turboraizer
	public void Turboraizer_Auto(CardState cs)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Nova Grappler")
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			_AuxCard = OwnerCard.boostedUnit;
			IncreasePowerByBattle(3000);
			_AuxBool = true; //Means that this unit boost this turn.
		}
		else if(cs == CardState.EndTurn)
		{
			if(_AuxBool)
			{
				FromFieldToDeck(OwnerCard);
			}
		}
	}
	
	public void Turboraizer_Active()
	{
		ShowAndDelay();
	}
	
	public void Turboraizer_Update()
	{
		DelayUpdate(delegate {
			CallFromSoul(OwnerCard);	
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Battleraizer
	public void Battleraizer_Auto(CardState cs)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Nova Grappler")
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			_AuxCard = OwnerCard.boostedUnit;
			IncreasePowerByBattle(3000);
			_AuxBool = true; //Means that this unit boost this turn.
		}
		else if(cs == CardState.EndTurn)
		{
			if(_AuxBool)
			{
				FromFieldToDeck(OwnerCard);
			}
		}
	}
	
	public void Battleraizer_Active()
	{
		ShowAndDelay();
	}
	
	public void Battleraizer_Update()
	{
		DelayUpdate(delegate {
			CallFromSoul(OwnerCard);	
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Dragon Egg
	public void DragonEgg_Auto(CardState cs)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Tachikaze")
			{
				StartEffect();
				DisplayConfirmationWindow();
				_AuxBool = true;
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(GetVanguard().clan == "Tachikaze")
			{
				if(Game.field.GetNumberOfDamageCardsFaceup() >= 1)
				{
					StartEffect();
					DisplayConfirmationWindow();	
					_AuxBool2 = true;
				}
			}
		}
	}
	
	public void DragonEgg_Active()
	{
		ShowOnScreen(OwnerCard);
		
		if(_AuxBool)
		{
			_AuxBool = false;
			CallFromSoul(OwnerCard);
		}
		
		if(_AuxBool2)
		{
			FlipCardInDamageZone(1);
			_AuxBool2 = false;
			FromDropToHand(OwnerCard);
		}
	}
	
	public void DragonEgg_Update()
	{
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	#endregion
	
	#region Bermuda Triangle Cadet, Weddell 
	public void BermudaTriangleCadetWeddell_Auto(CardState cs)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Bermuda Triangle")
			{
				StartEffect();
				DisplayConfirmationWindow();
				_AuxBool = true;
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	
	public int BermudaTriangleCadetWeddell_Field()
	{
		if(NumRearGuards("Bermuda Triangle") > 1 && 
		   !OwnerCard.IsVanguard() &&
			GetVanguard().clan == "Bermuda Triangle")
		{
			return 1;	
		}
		
		return 0;
	}
	
	public void BermudaTriangleCadetWeddell_Active()
	{
		ShowOnScreen(OwnerCard);
		
		if(_AuxBool)
		{
			_AuxBool = false;
			CallFromSoul(OwnerCard);
		}
		else
		{
			StartEffect();
			ShowAndDelay();	
		}
	}
	
	public void BermudaTriangleCadetWeddell_Update()
	{
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
		
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			EnableMouse("Choose one of your Bermuda Triangle rear-guards.");
		});
	}
	
	void BermudaTriangleCadetWeddell_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Bermuda Triangle")
				{
					ReturnToHand(c);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
	#endregion
	
	#region Intelli-idol, Melville
	void IntelliidolMelville_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DriveCheck)
		{
			if(Game.DriveCard.grade == 3 && Game.DriveCard.clan == "Bermuda Triangle" &&
			   NumRearGuards("Bermuda Triangle") > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void IntelliidolMelville_Active()
	{
		ShowAndDelay();	
	}
	
	void IntelliidolMelville_Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your Bermuda Triangle rear-guards.");	
		});
		
		if(GetBool(2))
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				UnsetBool(2);
				Game.bBlockUnitReplacing = false;
				EndEffect();
			}
			else
			{
				Game.HandleSpecialCall();	
			}
		}
	}
	
	void IntelliidolMelville_Pointer()
	{
		if(AcceptInput())
		{
			if(GetBool(1))
			{
				Card c = HandSelectedCard();
				if(c != null && c._HandleMouse.mouseOn && c.clan == "Bermuda Triangle")
				{
					Game.bBlockUnitReplacing = true;
					Game.Call(c);	
					DisableMouse();
					ClearMessage();
					UnsetBool(1);
					SetBool(2);
				}
			}
			else
			{
				fieldPositions p = Util.GetMousePosition();
				if(IsRearGuard(p))
				{
					Card c = Game.field.GetCardAt(p);
					if(c != null && c.clan == "Bermuda Triangle")
					{
						ReturnToHand(c);
						SetBool(1);
						DisplayHelpMessage("Choose one Bermuda Triangle from your hand.");
					}
				}
			}
		}
	}
	#endregion
	
	#region Bermuda Triangle Cadet, Riviere
	void BermudaTriangleCadetRiviere_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.MERMAID_IDOL__RIVIERE)
			{
				StartEffect();
				ShowAndDelay();	
			}
			else if(GetVanguard().clan == "Bermuda Triangle")
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	void BermudaTriangleCadetRiviere_Active()
	{
		ShowAndDelay();
		SetBool(2);
	}
	
	void BermudaTriangleCadetRiviere_Update()
	{
		DelayUpdate(delegate {
			if(GetBool(2))
			{
				CallFromSoul(OwnerCard);
			}
			else
			{
				DisplayHelpMessage("Search for up to one card named \"Super Idol, Riviere\" or \"Top Idol, Riviere\". Just close the window if the card is not there.");
				Game.playerDeck.ViewDeck(1, SearchMode.TOP_CARD, 7, "");	
				SetBool(1);
			}
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0 && (_AuxIdVector[0] == CardIdentifier.SUPER_IDOL__RIVIERE ||
			       					 		  _AuxIdVector[0] == CardIdentifier.TOP_IDOL__RIVIERE))
				{
					FromDeckToHand(_AuxIdVector[0]);
				}
				ShuffleDeck();
				ClearMessage();
				EndEffect();
			}
		}
	}
	#endregion

	#region Bermuda Triangle Cadet, Caravel
	public void Caravel_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call)
		{
			if(Game.field.GetNumberOfCardsInSoul() >= 2)
			{
				if(GetVanguard().clan == "Bermuda Triangle")	
				{
					StartEffect();
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void Caravel_Active()
	{
		ShowOnScreen(OwnerCard);
		SoulBlast(2);
	}
	
	public void Caravel_Update()
	{
		SoulBlastUpdate(delegate {
			EndEffect();
			DrawCardWithoutDelay();
		});
	}
	#endregion
	
	#region Guiding Zombie
	public void GuidingZombie_Auto(CardState cs)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Granblue")
			{
				SetCard(OwnerCard);
				DisplayConfirmationWindow();
				_AuxBool = true;
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
	}
	
	public void GuidingZombie_Active()
	{
		ShowOnScreen(OwnerCard);
		
		if(_AuxBool)
		{
			_AuxBool2 = true;
			Game.bEffectOnGoing = true;
			_AuxBool = false;
			Game.Call(OwnerCard);
			Game.field.RemoveFromSoulByCard(OwnerCard);
			Game.bBlockMouseOnce = true;
		}
		else 
		{
			MoveToSoul(OwnerCard);
			_AuxInt = 3;
			_AuxBool3 = true;
			Game.bEffectOnGoing = true;
		}
	}
	
	public int GuidingZombie_Field()
	{
		if(Game.playerDeck.Size() >= 3 && !OwnerCard.IsVanguard())
		{
			return 1;	
		}
		return 0;
	}
	
	public void GuidingZombie_Update()
	{
		if(_AuxBool2)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				_AuxBool2 = false;
				Game.bEffectOnGoing = false;
			}
		}
		
		if(_AuxBool3)
		{
			if(_AuxInt <= 0)
			{
				Game.bEffectOnGoing = false;
				_AuxBool3 = false;
			}
			else
			{
				if(_AuxCard == null || !_AuxCard.AnimationOngoing())
				{
					Game.field.FixDropZonePosition();
					_AuxInt--;
					_AuxCard = SendCardFromDeckToDrop();
				}
			}
		}
	}
	#endregion
	
	#region Sunny Smile Angel 
	public void SunnySmileAngel_Auto(CardState cs)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Angel Feather")
			{
				SetCard(OwnerCard);
				DisplayConfirmationWindow();
				Game.bEffectOnGoing = true;
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			_AuxCard = OwnerCard.boostedUnit;
			IncreasePowerByBattle(3000);
			_AuxBool = true; //Means that this unit boost this turn.
		}
		else if(cs == CardState.EndTurn)
		{
			if(_AuxBool)
			{
				_AuxBool = false;
				Game.bEffectOnGoing = true;
				Game.SendPacket(GameAction.RETURN_FROM_FIELD_TO_DECK, OwnerCard.pos);
				Game.field.RemoveFrom(OwnerCard.pos);
				OwnerCard.SetRotation(0,180,0);
				Game.playerDeck.ReturnToDeck(OwnerCard);
				_AuxBool2 = true;
			}
		}
	}
	
	public void SunnySmileAngel_Active()
	{
		ShowOnScreen(OwnerCard);
		Game.Call(OwnerCard);
		Game.field.RemoveFromSoulByCard(OwnerCard);
		Game.bBlockMouseOnce = true;
		_AuxBool3 = true;
	}
	
	public void SunnySmileAngel_Update()
	{
		if(_AuxBool2)
		{
			if(!Game.playerDeck.AnimationOngoing())
			{
				_AuxBool2 = false;
				Game.bEffectOnGoing = false;
				Game.playerDeck.Shuffle();
			}
		}
		
		if(_AuxBool3)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				Game.bEffectOnGoing = false;	
				_AuxBool3 = false;
			}
		}
	}
	#endregion
	
	#region Lozenge Magus
	public void LozengeMagus_Auto(CardState cs)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Oracle Think Tank")
			{
				SetCard(OwnerCard);
				DisplayConfirmationWindow();
				Game.bEffectOnGoing = true;
			}
		}
		else if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			_AuxCard = OwnerCard.boostedUnit;
			IncreasePowerByBattle(3000);
			_AuxBool = true; //Means that this unit boost this turn.
		}
		else if(cs == CardState.EndTurn)
		{
			if(_AuxBool)
			{
				_AuxBool = false;
				Game.bEffectOnGoing = true;
				Game.SendPacket(GameAction.RETURN_FROM_FIELD_TO_DECK, OwnerCard.pos);
				Game.field.RemoveFrom(OwnerCard.pos);
				OwnerCard.SetRotation(0,180,0);
				Game.playerDeck.ReturnToDeck(OwnerCard);
				_AuxBool2 = true;
			}
		}
	}
	
	public void LozengeMagus_Active()
	{
		ShowOnScreen(OwnerCard);
		Game.Call(OwnerCard);
		Game.field.RemoveFromSoulByCard(OwnerCard);
		Game.bBlockMouseOnce = true;
		_AuxBool3 = true;
	}
	
	public void LozengeMagus_Update()
	{
		if(_AuxBool2)
		{
			if(!Game.playerDeck.AnimationOngoing())
			{
				_AuxBool2 = false;
				Game.bEffectOnGoing = false;
				Game.playerDeck.Shuffle();
			}
		}
		
		if(_AuxBool3)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				Game.bEffectOnGoing = false;	
				_AuxBool3 = false;
			}
		}
	}
	#endregion
	
	#region Magician Girl, Kirara
	public void MagicianGirlKirara_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.AttackHits)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 2)
			{
				if(GetVanguard().clan == "Nova Grappler")
				{
					Game.bEffectOnGoing = true;
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	public void MagicianGirlKirara_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(2);
		DrawCard();
	}
	#endregion
	
	#region Oracle Guardian, Apollon
	public void OracleGuardianApollon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(CB (2))
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void OracleGuardianApollon_Active()
	{
		FlipCardInDamageZone(2);
		ShowAndDelay();
	}
	
	void OracleGuardinApollon_Update()
	{
		DelayUpdate(delegate {
			if(VC())
			{
				DrawCard(2);
			}	
			else
			{
				DrawCardWithoutDelay();	
				EndEffect();
			}
		});
		
		DrawCardUpdate(delegate {
			EnableMouse("Select a card from your hand and return it to your deck.");
		});
	}
	
	public void OracleGuardianApollon_Pointer()
	{
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c))
			{
				ReturnCardFromHandToDeck();
				ClearPointer();
			}
		}
	}
	#endregion
	
	#region Weather Girl, Milk
	public void WeatherGirlMilk_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Boost)
		{
			if(OwnerCard.boostedUnit.clan == "Oracle Think Tank" && OwnerCard.boostedUnit.IsVanguard())
			{
				if(Game.playerHand.Size() >= 4)
				{
					_AuxCard = OwnerCard.boostedUnit;
					IncreasePowerByBattle(4000);
				}
			}
		}
	}
	#endregion
	
	#region Battle Sister, Mocha
	public void BattleSisterMocha_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(Game.playerHand.Size() >= 4)
			{
				ShowOnScreen(OwnerCard);
				_AuxCard = OwnerCard;
				IncreasePowerByBattle(3000);
			}
			ConfirmAttack();
		}
	}
	#endregion
	
	#region Golden Beast Tamer
	public int GoldenBeastTamer_Field()
	{
		if(Game.field.GetNumberOfCardsInSoul() >= 3)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public void GoldenBeastTamer_Active()
	{
		StartEffect();
		ShowOnScreen();
		SoulBlast(3);
	}
	
	public void GoldenBeastTamer_Update()
	{
		SoulBlastUpdate(delegate {
			OwnerCard.RemoveRestraint();
			EndEffect();
		});
		
		DelayUpdate(delegate {
			if(_AuxBool)
			{
				_AuxBool = false;
				Game.field.ViewSoul(1, "Pale Moon", "Chimera", "");
				_AuxBool2 = true;
			}
		});
		
		if(_AuxBool2)
		{
			if(!Game.field.ViewingSoul())
			{
				_AuxBool2 = false;
				CallFromSoul(Game.field.GetSoulByID(Game.field.GetLastSelectedList()[0]));
			}
		}
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	
	public void GoldenBeastTamer_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				Card frontLeft = Game.field.GetCardAt(fieldPositions.FRONT_GUARD_LEFT);
				Card frontRight = Game.field.GetCardAt(fieldPositions.FRONT_GUARD_RIGHT);
				
				if(frontLeft != null)
				{
					IncreasePowerByTurn(frontLeft, 3000);
				}
				
				if(frontRight != null)
				{
					IncreasePowerByTurn(frontRight, 3000);	
				}
			}
		}
		else if(cs == CardState.Ride)
		{
			if(Game.field.GetSoulClanAndRace("Pale Moon", "Chimera") > 0)
			{
				ShowOnScreen();
				Delay(1);
				_AuxBool = true;
				StartEffect();
			}
		}
	}
	#endregion
	
	#region Machining Stag Beetle
	public void MachiningStagBeetle_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride)
		{
			if(Game.field.SoulNameContains("Machining") > 0)
			{
				StartEffect();
				ShowOnScreen();
				Delay(1);
			}
		}
	}
	
	public void MachiningStagBeetle_Update()
	{
		DelayUpdate(delegate {
			Game.field.ViewSoul(2, "Megacolony", "", "Machining");
			_AuxBool = true;
		});
		
		if(_AuxBool)
		{
			if(!Game.field.ViewingSoul())
			{
				_AuxBool = false;
				_AuxBool2 = true;
				_AuxIdVector = Game.field.GetLastSelectedList();
				_AuxInt = _AuxIdVector.Count;
				_AuxInt2 = 0;
				_AuxBool3 = true;
				_AuxCard = null;
				_AuxCard2 = null;
			}
		}
		
		if(_AuxBool2)
		{
			if(_AuxInt > 0)
			{
				if(_AuxBool3)
				{
					_AuxBool3 = false;
					if(_AuxCard == null)
					{
						_AuxCard = Game.field.GetSoulByID(_AuxIdVector[0]);
						_AuxInt2 += _AuxCard.power;
						CallFromSoul(_AuxCard);
					}
					else if(_AuxCard2 == null)
					{
						_AuxCard2 = Game.field.GetSoulByID(_AuxIdVector[0]);
						_AuxInt2 += _AuxCard2.power;
						CallFromSoul(_AuxCard2);							
					}
					_AuxIdVector.RemoveAt(0);
				}
			}	
			else
			{
				_AuxBool2 = false;
				IncreasePowerByTurn(OwnerCard, _AuxInt2);
				if(_AuxCard != null)
				{
					RestUnit(_AuxCard);
					_AuxCard = null;
				}
				
				if(_AuxCard2 != null)
				{
					RestUnit(_AuxCard2);
					_AuxCard2 = null;
				}
				EndEffect();
			}
		}
		
		CallFromSoulUpdate(delegate {
			_AuxInt--;
			if(_AuxInt > 0)
			{
				_AuxBool3 = true;	
			}
		});
	}
	#endregion
	
	#region Weather Forecaster, Miss Mist
	public void MissMist_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.UsedToGuard)
		{
			if(GetAttacker().grade <= 2 & GetAttacker().IsVanguard() && GetDefensor().clan == "Oracle Think Tank")
			{
				ShowOnScreen();
				GetDefensor().PerfectGuard();	
			}
		}
	}
	#endregion
	
	/*
	 * [AUTO]:When this unit is put into the drop zone from (GC), put this unit into your soul.
	 * */
	
	#region Rock the Wall
	public void RockTheWall_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromGC)
		{
			ShowOnScreen(OwnerCard);
			SoulChargeFromDrop(OwnerCard);	
		}
	}
	#endregion
	
	#region Coongal
	public void Coongal_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromGC)
		{
			ShowOnScreen(OwnerCard);
			SoulChargeFromDrop(OwnerCard);	
		}
	}
	#endregion
	
	#region Redshoe, Milly
	public void RedshoeMilly_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromGC)
		{
			ShowOnScreen(OwnerCard);
			SoulChargeFromDrop(OwnerCard);	
		}
	}
	#endregion
	
	#region Dusk Illusionist, Robert
	public void Robert_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard() && Game.playerDeck.Size() > 0)
			{
				ShowOnScreen();
				Game.SoulCharge();
				_AuxCard = LookAtTopDeckCard();
				Game.playerDeck.RemoveFromDeck(_AuxCard);
				Game._CardMenu.OpenDeckMenu(_AuxCard);
				SetBool(1);
			}
		}
	}
	
	public void Robert_Update()
	{
		if(GetBool(1))
		{
			if(!_AuxCard.bIsFaceUP)
			{
				UnsetBool(1);
				EndEffect();	
			}
		}
	
		Megablast_Update(delegate {
			for(int i = 1; i < 6; i++)
			{
				Card c = EnemyField (i);
				if(c != null && c.grade <= 1)
				{
					EnemyMoveToSoul(EnemyField(i));
				}
			}
			EndEffect();
		});
	}
	
	public int Robert_Field()
	{
		if(Megablast_Check(5, 8))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public void Robert_Active()
	{
		ShowOnScreen();
		Megablast_Active(5, 8);
		StartEffect();
	}
	#endregion
	
	#region Embodiment of Victory, Aleph
	public int EmbodimentVictoryAleph_Field()
	{
		int count = 0;
		
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 4)
		{
			count++;	
		}
		
		if(Game.field.GetNumberOfDamageCardsFacedown() > 0)
		{
			if(Game.field.GetSoulByID(CardIdentifier.DRAGON_KNIGHT_ALEPH) != null &&
			   Game.field.GetSoulByID(CardIdentifier.EMBODIMENT_OF_ARMOR_BAHR) != null &&
			   Game.field.GetSoulByID(CardIdentifier.EMBODIMENT_OF_SPEAR_THAR) != null)
			{
				count++;	
			}
		}
		
		return count;
	}
	
	public void EmbodimentVictoryAleph_Activate(int idx)
	{
		if(idx == 1 && Game.field.GetNumberOfDamageCardsFaceup() < 4)
		{
			idx = 2;	
		}
		
		if(idx == 1)
		{
			ShowOnScreen(OwnerCard);
			FlipCardInDamageZone(4);
			SetPowerAndCriticalUp(OwnerCard, 3000, 1);
		}
		else if(idx == 2)
		{
			_AuxCard = Game.field.GetSoulByID(CardIdentifier.DRAGON_KNIGHT_ALEPH);
			Game.SoulBlast(_AuxCard);
			_AuxBool = true;
			_AuxInt = 1;
		}
	}
	
	public void EmbodimentVictoryAleph_Update()
	{
		if(_AuxBool)
		{
			if(!_AuxCard.AnimationOngoing())
			{
				Game.field.RemoveFromSoulByCard(_AuxCard);
				Game.field.AddToDropZone(_AuxCard);
				_AuxInt++;
				
				if(_AuxInt == 2)
				{
					_AuxCard = Game.field.GetSoulByID(CardIdentifier.EMBODIMENT_OF_ARMOR_BAHR);
					Game.SoulBlast(_AuxCard);
				}
				else if(_AuxInt == 3)
				{
					_AuxCard = Game.field.GetSoulByID(CardIdentifier.EMBODIMENT_OF_SPEAR_THAR);
					Game.SoulBlast(_AuxCard);
				}
				else if(_AuxInt == 4)
				{
					UnflipCardInDamageZone(5);
					_AuxBool = false;
				}
			}
		}
	}
	#endregion
	
	#region MR. Invincible
	public void MrInvincible_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen(OwnerCard);
				_AuxCard = Game.SoulCharge();
				UnflipCardInDamageZone(1);
				_AuxBool = true;
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(Megablast_Check(5, 8))
			{
				DisplayConfirmationWindow();	
			}
		}	
	}
	
	public void MrInvincible_FreeUpdate()
	{
		Megablast_Update(delegate() {
			Game.field.StandAllUnits();
			Game.SendPacket(GameAction.STAND_ALL_UNITS);
			Game.bEffectOnGoing = false;
		});
	}
	
	public void MrInvincible_Active()
	{
		Megablast_Active(5, 8);
		Game.bEffectOnGoing = true;
	}
	#endregion
	
	#region Stealth Fiend, Kurama Lord 
	public void StealthFiendKuramaLord_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				Game.SoulCharge();
				UnflipCardInDamageZone(1);
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(Megablast_Check(5, 8))
			{
				DisplayConfirmationWindow();	
			}
		}	
	}
	
	public void StealthFiendKuramaLord_FreeUpdate()
	{
		Megablast_Update(delegate() {
			Game.field.StandAllUnits();
			Game.SendPacket(GameAction.STAND_ALL_UNITS);
			Game.bEffectOnGoing = false;
		});
	}
	
	public void StealthFiendKuramaLord_Active()
	{
		Megablast_Active(5, 8);
	}
	#endregion
	
	#region Shield Seed Squire 
	void ShieldSeedSquire_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			Forerunner("Neo Nectar");	
		}
		else if(cs == CardState.AttackHits)
		{
			if(!OwnerCard.IsVanguard())
			{
				if(GetDefensor().IsVanguard() &&
					GetVanguard().clan == "Neo Nectar" &&
					Game.playerDeck.SearchForID(CardIdentifier.BLADE_SEED_SQUIRE) != null)
				{
					DisplayConfirmationWindow();	
					SetBool(1);
				}
			}
		}
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);	
		}
	}
	
	void ShieldSeedSquire_Active()
	{
		if(GetBool(1))
		{
			ShowAndDelay();
		}
		else
		{
			Forerunner_Active();
		}
	}
	
	void ShieldSeedSquire_Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			UnsetBool(1);
			SetBool(2);
			Game.playerDeck.ViewDeck(CardIdentifier.BLADE_SEED_SQUIRE);
		});
		
		if(GetBool(2))
		{
			if(!Game.playerDeck.IsOpen())	
			{
				UnsetBool(2);
				CallFromDeck(Game.playerDeck.GetLastSelectedList());	
			}
		}
		
		CallFromDeckUpdate(delegate {
			RestUnit(CallFromDeckList[0]);
			EndEffect();	
			ShuffleDeck();
		});
	}
	#endregion
	
	#region Stealth Dragon, Voidgelga 
	void StealthDragonVoidgelga_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CheckCounterBlast(1) &&
				GetVanguard().clan == "Murakumo" &&
				Game.playerDeck.SearchForID(CardIdentifier.STEALTH_DRAGON__VOIDGELGA) != null)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	void StealthDragonVoidgelga_Active()
	{
		ShowAndDelay();	
		FlipCardInDamageZone(1);
	}
	
	void StealthDragonVoidgelga_Update()
	{
		DelayUpdate(delegate {
			SetBool(1);
			Game.playerDeck.ViewDeck(CardIdentifier.STEALTH_DRAGON__VOIDGELGA);
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);	
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromDeckUpdate(delegate {
			ShuffleDeck();
			Card c = CallFromDeckList[0];
			c.unitAbilities.AddExternAuto(delegate(CardState cs, Card effectOwner) {
				if(cs == CardState.EndTurn)
				{
					c.unitAbilities.FromFieldToDeck(c, true);
				}
			});
			EndEffect();	
		});
	}
	#endregion
	
	#region Demon Eater
	public void DemonEater_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen(OwnerCard);
				Game.SoulCharge();
				_AuxCard = OwnerCard;
				IncreasePowerByTurn(2000);
				_AuxBool = true;
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(Megablast_Check(5, 8))
			{
				DisplayConfirmationWindow();	
			}
		}	
	}
	
	public void DemonEater_FreeUpdate()
	{
		Megablast_Update(delegate() {
			RetireAllEnemyUnits();
			Game.bEffectOnGoing = false;
		});
	}
	
	public void DemonEater_Active()
	{
		Megablast_Active(5, 8);
	}
	#endregion
	
	#region Knight of Purgatory, Skull Face 
	public void KnightofPurgatorySkullFace_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen(OwnerCard);
				Game.SoulCharge();
				_AuxCard = OwnerCard;
				IncreasePowerByTurn(2000);
				_AuxBool = true;
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(Megablast_Check(5, 8))
			{
				DisplayConfirmationWindow();	
			}
		}	
	}
	
	public void KnightofPurgatorySkullFace_FreeUpdate()
	{
		Megablast_Update(delegate() {
			RetireAllEnemyUnits();
			Game.bEffectOnGoing = false;
		});
	}
	
	public void KnightofPurgatorySkullFace_Active()
	{
		Megablast_Active(5, 8);
	}
	#endregion
	
	#region King of Demonic Seas, Basskirk
	public void Basskirk_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen(OwnerCard);
				Game.SoulCharge();
				_AuxCard = OwnerCard;
				IncreasePowerByTurn(2000);
				_AuxBool = true;
			}
		}	
	}
	
	public int Basskirk_Field()
	{
		if(Megablast_Check(5, 8))
		{
			if(Game.field.GetUnitsDropWithClanName("Granblue") > 0 || Game.field.GetUnitsSoulWithClanName("Granblue") > 0)
			{
				return 1;		
			}
		}
		
		return 0;
	}
	
	public void Basskirk_FreeUpdate()
	{
		Megablast_Update(delegate() {
			Game.field.ViewDropZone(5, "Granblue");
			_AuxInt = -1;
			_AuxBool4 = true;
			DisplayHelpMessage("Choose up to five Granblue units and call them to separate (RC).");
			Game.bBlockUnitReplacing = true;
		});
		
		
		if(_AuxBool4)
		{
			if(!Game.field.ViewingDropZone())
			{
				_AuxIdVector = Game.field.GetLastSelectedList();
				_AuxInt = _AuxIdVector.Count;	
				_AuxBool4 = false;
				_AuxBool5 = true;
			}
		}
		
		if(_AuxBool5)
		{
			if(_AuxInt >= 0)
			{
				if(Game._MouseHelper.GetAttachedCard() == null)
				{
					_AuxInt--;
					_AuxCard2 = Game.field.GetDropByID(_AuxIdVector[0]);
					_AuxIdVector.RemoveAt(0);
					CallFromDrop(_AuxCard2);
				}
				else
				{
					Game.HandleCallFromDrop();		
				}
			}
			else
			{
				Game.bEffectOnGoing = false;
				Game.bBlockUnitReplacing = false;
				ClearMessage();
				_AuxBool5 = false;
			}	
		}
	}
	
	public void Basskirk_Active()
	{
		Megablast_Active(5, 8);
		Game.bEffectOnGoing = true;
	}
	#endregion
	
	#region Demon Slaying Knight, Lohengrim
	public void Lohengrim_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen(OwnerCard);
				Game.SoulCharge();
				_AuxCard = OwnerCard;
				IncreasePowerByTurn(2000);
				_AuxBool = true;
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(Megablast_Check(5, 8))
			{
				DisplayConfirmationWindow();	
			}
		}	
	}
	
	public void Lohengrim_FreeUpdate()
	{
		Megablast_Update(delegate() {
			RetireAllEnemyUnits();	
		});
	}
	
	public void Lohengrim_Active()
	{
		Megablast_Active(5, 8);
	}
	#endregion
	
	#region Vortex Dragon
	public void VortexDragon_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard())
			{
				ShowOnScreen(OwnerCard);
				Game.SoulCharge();
				_AuxCard = OwnerCard;
				IncreasePowerByTurn(2000);
				_AuxBool = true;
			}
		}
	}
	
	public void VortexDragon_FreeUpdate()
	{
		Megablast_Update(delegate() {
			EnableMouse();
			_AuxInt = 3;
			DisplayHelpMessage("Choose up to three opponent's rear-guards, and retire them.");	
		});
	}
	
	public void VortexDragon_Active()
	{
		Megablast_Active(5, 8);
		Game.bEffectOnGoing = true;
	}
	
	public int VortexDragon_Field()
	{
		if(Megablast_Check(5, 8) &&
		   Game.enemyField.GetNumberOfRearUnits() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public void VortexDragon_Pointer()
	{
		if(AcceptInput())	
		{
			fieldPositions pos = Util.GetMousePosition();
			if(Util.IsEnemyPosition(pos) && pos != fieldPositions.ENEMY_VANGUARD)
			{
				Card temp = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(pos));
				if(temp != null)
				{
					RetireEnemyUnit(temp);
					_AuxInt--;
					if(_AuxInt == 0 || Game.enemyField.GetNumberOfRearUnits() == 0)
					{
						DisableMouse();
						ClearMessage();
						Game.bEffectOnGoing = false;
						return;
					}
					DisplayHelpMessage("Choose up to three of your opponnet's rear-guards, and retire them.");
				}
			}
		}
	}
	#endregion
	
	#region Negromarl
	public void Negromarl_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 2 && Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Granblue" &&
			   Game.field.DropZone.Count > 0)
			{
				Game.bEffectOnGoing = true;
				DisplayConfirmationWindow();
			}
		}
	}
	
	public void Negromarl_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(2);
		Game.field.ViewDropZone(1);
		_AuxBool = true;
	}
	
	public void Negromarl_Update()
	{
		if(_AuxBool)
		{
			if(!Game.field.ViewingDropZone())
			{
				_AuxBool = false;
				_AuxBool2 = true;
				_AuxIdVector = Game.field.GetLastSelectedList();
				_AuxCard = Game.field.GetDropByID(_AuxIdVector[0]);
				_AuxIdVector.Clear();
				CallFromDrop(_AuxCard);
			}
		}
		
		if(_AuxBool2)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				Game.bEffectOnGoing = false;	
				_AuxBool2 = false;
			}
			else
			{
				Game.HandleCallFromDrop();	
			}
		}
	}
	#endregion
	
	#region Vajra Emperor, Indra 
	void VajraEmperorIndra_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && CB (1) && GetNumRear(OwnerCard.cardID) > 0)
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack();	
			}
		}
	}
	
	void VajraEmperorIndra_Active()
	{
		ShowAndDelay();	
	}
	
	void VajraEmperorIndra_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, 
						 delegate {
			 				IncreaseCriticalByBattle(OwnerCard, GetNumRear(OwnerCard.cardID));
							EndEffect();
				            ConfirmAttack();
			    	  	 });	
		});
	}
	
	void VajraEmperorIndra_Pointer()
	{
		CounterBlast_Pointer();	
	}
	#endregion
	
	#region Dragonic Deathscythe 
	void DragonicDeathscythe_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(VanguardIs("Narukami") && CB (2) && Game.enemyField.GetNumberOfRearUnitsWithGradeLessOrEqual(2) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void DragonicDeathscythe_Active()
	{
		ShowAndDelay();	
	}
	
	void DragonicDeathscythe_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
				         delegate {
							SelectEnemyUnit("Choose an opponent's grade 2 or less rear-guard.",
					          				1,
											true,
										    delegate {
												RetireEnemyUnit(EnemyUnit);
											},
											delegate {
												return EnemyUnit.grade <= 2;
											},
											delegate {
											
											});
						 });	
		});
	}
	
	void DragonicDeathscythe_Pointer()
	{
		if(CounterBlast_Pointer()) return;
		if(SelectEnemyUnit_Pointer()) return;
	}
	#endregion
	
	/**
	 * Returns the number of rear-guards with the corresponding ID.
	 */
	int GetNumRear(CardIdentifier id)
	{
		int cnt = 0;
		Game.field.InitFieldIterator();
		while(Game.field.HasNextField())
		{
			Card c = Game.field.CurrentFieldCard();
			if(c != null && c.cardID == id && !c.IsVanguard())
			{
				cnt++;	
			}
		}
		return cnt;
	}
	
	#region Young Pegasus Knight
	public void YoungPegasusKnight(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.CardPutInSoul)
		{
			if((CurrentPhaseIs(GamePhase.MAIN_PHASE) || CurrentPhaseIs(GamePhase.STANDBY_PHASE)) &&
			   !OwnerCard.IsVanguard() &&
			   GetVanguard().clan == "Royal Paladin")
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
	#endregion
	
	#region Doreen the Thruster
	public void Doreen_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.CardPutInSoul)
		{
			if((CurrentPhaseIs(GamePhase.MAIN_PHASE) || CurrentPhaseIs(GamePhase.STANDBY_PHASE)) &&
			   !OwnerCard.IsVanguard() &&
			   GetVanguard().clan == "Dark Irregulars")
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
	#endregion
	
	#region Great Sage, Barron
	public void GreatSageBarron_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();
		}
		else if(cs == CardState.CardPutInSoul)
		{
			if((CurrentPhaseIs(GamePhase.MAIN_PHASE) || CurrentPhaseIs(GamePhase.STANDBY_PHASE)) &&
			   !OwnerCard.IsVanguard() &&
			   GetVanguard().clan == "Royal Paladin")
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
	#endregion
		
	#region Karma Queen
	public void KarmaQueen_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 2)
			{
				if(Game.enemyField.GetNumberOfRearUnits() > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public void KarmaQueen_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(2);
		EnableMouse();
		Game.bEffectOnGoing = true;
	}
	
	public void KarmaQueen_Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions pos = Util.GetMousePosition();
			if(Util.IsEnemyPosition(pos) && pos != fieldPositions.ENEMY_VANGUARD)
			{
				Card temp = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(pos));
				if(temp != null)
				{
					CantStandUntilNextTurn(temp);
					ClearMessage();
					DisableMouse();
					Game.bEffectOnGoing = false;
				}
			}
		}
	}
	#endregion
	
	#region Maiden of Libra
	public void MaidenOfLibra_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 2)
			{
				if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Oracle Think Tank")
				{
					if(GetAttacker() == OwnerCard)
					{
						DisplayConfirmationWindow();
					}
				}
			}
		}
	}
	
	public void MaidenOfLibra_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(2);
		DrawCard();
	}
	#endregion
	
	#region Stalth Beast, Hagakure
	public void Hagakure_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.UsedToGuard)
		{
			if(Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Nubatama" && Game.field.GetNumberOfDamageCardsFaceup() >= 1)
			{
				if(Game.playerHand.Size() < Game.enemyHand.Size())	
				{
					Game.bEffectOnGoing = true;
					DisplayConfirmationWindow();	
				}
			}
		}
	}
	
	public void Hagakure_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		EnemyHasToDiscardOneCard();
	}
	#endregion
	
	#region Stealth Dragon, Voidmaster
	public void StealthDragonVoidmaster_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{
			if(OwnerCard.IsVanguard() && (Game.playerHand.Size() > Game.enemyHand.Size()))
			{
				ShowOnScreen(OwnerCard);
				_AuxCard = OwnerCard;
				IncreasePowerByBattle(3000);
				ConfirmAttack();
			}
			else
			{
				ConfirmAttack();	
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 1 && (Game.playerHand.Size() < Game.enemyHand.Size()))
			{
				DisplayConfirmationWindow();
				Game.bEffectOnGoing = true;
			}
		}
	}
	
	public void StealthDragonVoidmaster_Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(1);
		EnemyHasToDiscardOneCard();
		Game.bEffectOnGoing = false;
	}
	#endregion
	/// @endcond
	
	/*OMITTED*/
	
	#region 1GENERIC_FUNCTIONS
	public void PerfectGuard()
	{
		Game.SendPacket(GameAction.PERFECT_GUARD);
		Game.guardZone.ActivePerfectGuard();
		GetDefensor().PerfectGuard();
	}
	
	public Card LookAtTopDeckCard()
	{
		Card temp = Game.playerDeck.TopCard();
		temp.TurnUp();
		return temp;
	}
	
	public void MoveToSoul(Card card)
	{
		card.Stand();
		Game.field.MoveToSoul(card.pos);
		Game.field.RemoveFrom(card.pos);
		Game.field.FixSoulPosition();
		Game.SendPacket(GameAction.FROM_FIELD_TO_SOUL, card.pos);
	}
	
	public Card GetVanguard()
	{
		return Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE);	
	}
	
	
	public Card RevealTopCard()
	{
		Card toRet = Game.playerDeck.TopCard();
		toRet.TurnUp();
		Game.SendPacket(GameAction.REVEAL_TOP_CARD, toRet.cardID);	
		return toRet;
	}
	
	public void HideTopCard()
	{
		Game.playerDeck.TopCard().TurnDown();
		Game.SendPacket(GameAction.HIDE_TOP_CARD);
	}
	
	public void Delay(float seconds)
	{
		_Delay_Time = seconds;	
		_Delay_Bool = true;
	}
	
	public void DelayUpdate(Void0ParamsDelegate func)
	{
		if(_Delay_Bool)
		{
			if(_Delay_Time >= 0)
			{
				_Delay_Time -= Time.deltaTime; 	
			}
			else
			{
				_Delay_Bool = false;
				func();
			}
		}	
	}
	
	public bool FHTS_Bool1 = false;
	public Card FHTS_Card = null;
	
	public void FromHandToSoul(Card c, int position)
	{
		FHTS_Bool1 = true;
		FHTS_Card = c;
		Game.FromHandToSoul(c, position);
	}
	
	public void FromHandToSoulUpdate(Void0ParamsDelegate func)
	{
		if(FHTS_Bool1)
		{
			if(FHTS_Card == null || !FHTS_Card.AnimationOngoing())
			{
				if(FHTS_Card != null)
				{
					Game.playerHand.RemoveFromHand(FHTS_Card);
					Game.field.AddToSoul(FHTS_Card);
				}
				
				FHTS_Bool1 = false;
				FHTS_Card = null;
				func();
			}
		}
	}
	
	public bool FromHandToBind_Bool1 = false;
	public Card FromHandToBind_Card = null;
	
	public void FromHandToBind(Card c, int position)
	{
		FromHandToBind_Bool1 = true;
		FromHandToBind_Card = c;
		Game.FromHandToBind(c, position);
	}
	
	public void FromHandToBindUpdate(Void0ParamsDelegate func)
	{
		if(FromHandToBind_Bool1)
		{
			if(FromHandToBind_Card == null || !FromHandToBind_Card.AnimationOngoing())
			{
				if(FromHandToBind_Card != null)
				{
					Game.playerHand.RemoveFromHand(FromHandToBind_Card);
					Game.field.AddToBindZone(FromHandToBind_Card);
				}
				
				FromHandToBind_Bool1 = false;
				FromHandToBind_Card = null;
				func();
			}
		}
	}
	
	public Card BackRowUnit()
	{
		fieldPositions p = OwnerCard.pos;
		if(IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE)
		{
			if(p == fieldPositions.FRONT_GUARD_LEFT)
			{
				return Game.field.GetCardAt(fieldPositions.REAR_GUARD_LEFT);	
			}
			
			if(p == fieldPositions.FRONT_GUARD_RIGHT)
			{
				return Game.field.GetCardAt(fieldPositions.REAR_GUARD_RIGHT);	
			}
			
			if(p == fieldPositions.VANGUARD_CIRCLE)
			{
				return Game.field.GetCardAt(fieldPositions.REAR_GUARD_CENTER);	
			}
		}
		
		return null;
	}
	
	public void FromDropToHand(Card c)
	{
		Game.field.RemoveFromDropzone(c);
		Game.playerHand.AddToHand(c);
		Game.SendPacket(GameAction.FROM_DROP_TO_HAND, c.cardID);
	}
	
	public void EnemyCannotNormalRide()
	{
		Game.SendPacket(GameAction.BLOCK_NORMALRIDE);
	}
	
	public void DisplayOpponentWindow(string str)
	{
		Game.OppWindowRequestedBy = OwnerCard;
		Game.DisplayOpponentWindow(str);	
	}
	
	public void ShowOnScreen()
	{
		ShowOnScreen(OwnerCard);	
	}
	
	public Card GetEnemyVanguard()
	{
		return Game.enemyField.GetCardAt(EnemyFieldPosition.VANGUARD);			
	}	

	public void AddPowerToGuardZone(int power)
	{
		AddExtraShield(power);
		Game.guardZone.AddExtraPower(power);
		Game.SendPacket(GameAction.ADD_POWER_TO_GUARDZONE, power);
	}
	
	public void ShowAndDelay()
	{
		if(Game.bCheckAutoMode) return;

		ShowOnScreen();
		StartEffect();
		Delay(1);		
	}
	
	public int NumRearGuards(string clan)
	{
		return Game.field.GetNumberOfRearWithClanName(clan);
	}
	
	/**
	 *	Add an [AUTO] ability to a specific card. The [AUTO] ability remains until the end of the turn. 
	 */
	
	public void AddExternAuto(AutoDelegate fnc)
	{
		ExternAuto.Add(fnc);	
	}
	
	void SelectInDamage(int n, bool bEnd, Void0ParamsDelegate fnc)
	{
		_SID_n = n;
		_SID_Active = true;
		_SID_fnc = fnc;
		_SID_End = bEnd;
		EnableMouse("Choose a card from your damage zone.");
	}
	
	bool SelectInDamage_Pointer()
	{
		if(_SID_Active)
		{
			if(AcceptInput())
			{
				_SID_Card = Game.LastDamageCardSelected;
				if(ValidHand(_SID_Card))
				{
					_SID_fnc();
					_SID_n--;
					if(_SID_n <= 0)
					{
						ClearPointer(_SID_End);
						_SID_Active = false;
					}
				}
			}
		}
		
		return _SID_Active;
	}
	
	void SelectInHand(int n, bool bEnd, Void0ParamsDelegate fnc, delegateConstraint constraint, Void0ParamsDelegate fnc_end, string msg)
	{
		_SIH_n = n;
		_SIH_Active = true;
		_SIH_fnc = fnc;
		_SIH_constraint = constraint;
		_SIH_fnc_end = fnc_end;
		_SIH_End = bEnd;
		EnableMouse(msg);
	}
	
	bool SelectInHand_Pointer()
	{
		if(_SIH_Active)
		{
			if(AcceptInput())
			{
				_SIH_Card = HandSelectedCard();
				if(ValidHand(_SIH_Card) && _SIH_constraint())
				{
					_SIH_fnc();
					_SIH_n--;
					if(_SIH_n <= 0)
					{
						ClearPointer(_SIH_End);
						_SIH_Active = false;
						_SIH_fnc_end();
					}
				}
			}
		}
		
		return _SIH_Active;
	}
	
	bool SB(int n)
	{
		return n >= Game.field.GetNumberOfCardsInSoul();	
	}
	
	bool VanguardIs(string clan)
	{
		return GetVanguard().clan == clan;	
	}
	
	int HandSize(string clan = "")
	{
		if(clan == "")
		{
			return Game.playerHand.Size();
		}
		else
		{
			return Game.playerHand.GetNumberOfCardsWithClanName(clan);	
		}
	}
	
	void Heal(int num)
	{
		_H_n = num;
		_H_Active = true;
		EnableMouse("Choose " + _H_n + " card(s) from your damage zone.");
	}
	
	bool Heal_Pointer()
	{
		if(_H_Active)
		{
			if(AcceptInput())
			{
				Card c = Game.LastDamageCardSelected;
				if(c != null)
				{
					FromDamageToDrop(c);
					_H_n--;
					if(_H_n <= 0)
					{
						ClearPointer();
						_H_Active = false;
					}
				}
			}
			return true;
		}
		return false;
	}
	
	void FromDamageToDrop(Card c)
	{
		int idx = Game.field.GetDamageIndexOf(c);
		Game.field.RemoveFromDamage(c);	
		Game.field.AddToDropZone(c);
		Game.SendPacket(GameAction.FROM_DAMAGE_TO_DROP, idx);
	}
	
	bool IsInSoul(CardIdentifier id)
	{
		return 	Game.field.GetSoulByID(id) != null;
	}
	
	void CantInterceptUntilEndTurn(Card c)
	{
		Game.SendPacket(GameAction.UNIT_CANNOT_INTERCEPT_ENDTURN, c.pos);	
	}
	
	int max(int a, int b)
	{
		if(a < b)
		{
			return b;	
		}
		
		return a;
	}
	
	int min(int a, int b)
	{
		if(a > b)
		{
			return b;	
		}
		
		return a;
	}
	
	bool bSelectVanguard = false;
	
	void SelectUnit(string msg, int n, Void0ParamsDelegate fnc, bool bEnd = true)
	{
		_SU_n = n;
		_SU_fnc = fnc;
		_SU_Active = true;
		EnableMouse(msg);
		_SU_EndEffect = bEnd;
		_SU_constraint = null;
		_SU_fnc_end = null;
		bSelectVanguard = false;
	}
	
	void SelectUnit(string msg, int n, bool bEnd, Void0ParamsDelegate fnc, delegateConstraint constr, Void0ParamsDelegate fnc_end, bool bVC = false)
	{
		_SU_n = n;
		_SU_fnc = fnc;
		_SU_Active = true;
		EnableMouse(msg);
		_SU_EndEffect = bEnd;
		_SU_constraint = constr;
		_SU_fnc_end = fnc_end;
		bSelectVanguard = bVC;
	}
	
	bool SelectUnit_Pointer(bool bSelectVG = false)
	{
		if(_SU_Active)
		{
			if(AcceptInput())
			{
				fieldPositions p = Util.GetMousePosition();
				if(IsRearGuard(p) || (bSelectVG && p == fieldPositions.VANGUARD_CIRCLE) || (bSelectVanguard && p == fieldPositions.VANGUARD_CIRCLE))
				{
					Unit = Game.field.GetCardAt(p);
					if(Unit != null && (_SU_constraint == null || _SU_constraint()))
					{
						_SU_fnc();
						_SU_n--;
						if(_SU_n <= 0)
						{
							_SU_Active = false;
							ClearPointer(_SU_EndEffect);
							if(_SU_fnc_end != null)
							{
								_SU_fnc_end();
							}
						}
					}
				}
			}
			
			return true;
		}
		
		return false;
	}
	
	void PersonaBlast_Active(Void0ParamsDelegate fnc, bool bEnd = true)
	{
		_PB_EndEffect = bEnd;
		_PB_Active = true;
		_PB_func = fnc;
		EnableMouse("Choose a card named \"" + OwnerCard.name + "\" from your hand.");	
	}
	
	bool PersonaBlast_Pointer()
	{
		if(_PB_Active)
		{
			if(AcceptInput())
			{
				Card c = HandSelectedCard();
				if(ValidHand(c) && c.cardID == OwnerCard.cardID)
				{
					DiscardSelectedCard();
					ClearPointer(_PB_EndEffect);
					_PB_Active = false;
					_PB_func();
				}
			}
			return true;
		}
		
		return false;
	}
	
	bool PersonaBlast()
	{
		return Game.playerHand.GetByID(OwnerCard.cardID) != null;	
	}
	
	bool HitsVanguard()
	{
		return GetDefensor().IsVanguard();	
	}
	
	//There is at least one unit with clan name != clan on the field (rear or vanguard)
	bool NoClan(string clan)
	{
		Game.field.InitFieldIterator();
		while(Game.field.HasNextField())
		{
			Card c = Game.field.CurrentFieldCard();
			if(c != null && c.clan != clan)
			{
				return true;	
			}
		}
		
		return false;
	}
	
	void SelectEnemyUnit(Void0ParamsDelegate fnc, bool bEndEffect = true)
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null)
				{
					EnemyUnit = c;
					fnc();
					ClearPointer(bEndEffect);
				}
			}
		}		
	}
	
	Void0ParamsDelegate SEU_End;
	Void0ParamsDelegate SEU_Func;
	delegateConstraint SEU_Constraint;
	bool SEU_Active = false;
	bool SEU_bEndEffect;
	int SEU_num;
	
	void SelectEnemyUnit(string msg, int n, bool bEndEffect, Void0ParamsDelegate fnc, delegateConstraint constraint, Void0ParamsDelegate fncEnd)
	{
		SEU_Func = fnc;
		SEU_Constraint = constraint;
		SEU_End = fncEnd;
		SEU_bEndEffect = bEndEffect;
		SEU_num = n;
		SEU_Active = true;
		EnableMouse(msg);
	}
	
	bool DD_toBottom;
	List<CardIdentifier> DD_List;
	Card DD_Card;
	bool DD_Active = false;
	
	void FromDropToDeck(List<CardIdentifier> v, bool toBottom = false)
	{
		DD_Card     = null;
		DD_List     = v;
		DD_toBottom = toBottom;
		DD_Active   = true;
	}
	
	void FromDropToDeckUpdate(Void0ParamsDelegate DD_fnc)
	{
		if(DD_Active)
		{
			if(DD_Card == null || !DD_Card.AnimationOngoing())
			{
				if(DD_Card != null)
				{
					Game.field.RemoveFromDropzone(DD_Card);
					if(DD_toBottom)
					{
						Game.playerDeck.AddToBottom(DD_Card);
					}
					else
					{
						Game.playerDeck.AddCard(DD_Card);	
					}
					DD_Card.TurnDown();
				}
				
				if(DD_List.Count > 0)
				{
					DD_Card = Game.field.GetDropByID(DD_List[0]);
					DD_List.RemoveAt(0);
					
					Vector3 newPos = Game.field.fieldInfo.GetPosition((int)fieldPositions.DECK_ZONE);
					
					DD_Card.GoTo(newPos.x, newPos.z);
					Game.SendPacket(GameAction.FROM_DROP_TO_DECK, DD_Card.cardID);
				}
				else
				{
					DD_Active = false;
					Game.field.FixDropZonePosition();
					DD_fnc();
				}
			}
		}
	}
	
	bool SelectEnemyUnit_Pointer()
	{
		if(SEU_Active)
		{
			if(AcceptInput())
			{
				fieldPositions p = Util.GetMousePosition();
				if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
				{
					EnemyUnit = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
					if(EnemyUnit != null && SEU_Constraint())
					{
						SEU_Func();
						SEU_num--;
						if(SEU_num <= 0)
						{
							ClearPointer(SEU_bEndEffect);
							SEU_Active = false;
							SEU_End();
						}
					}
				}
			}
		}	
		
		return SEU_Active;
	}
	
	void FromDamageToHand(Card c)
	{
		int idx = Game.field.GetDamageIndexOf(c);
		Game.field.RemoveFromDamage(c);
		Game.playerHand.AddToHand(c);
		Game.SendPacket(GameAction.FROM_DAMAGE_TO_HAND, idx);
		ShowCardInHand(c);
	}
	
	void FromHandToDamage(Card c)
	{
		int idx = Game.playerHand.GetIndexOf(c);
		Game.playerHand.RemoveFromHand(c);	
		Game.field.AddToDamageZone(c);
		Game.SendPacket(GameAction.FROM_HAND_TO_DAMAGE, c.cardID, idx);
	}
	
	void Forerunner(string clan)
	{
		if(GetVanguard().clan == clan)
		{
			DisplayConfirmationWindow();	
		}
	}
	
	void FromDeckToDamage(Card c)
	{
		Game.playerDeck.RemoveFromDeck(c);
		Game.field.AddToDamageZone(c);
		c.TurnDown();
		Game.SendPacket(GameAction.FROM_DECK_TO_DAMAGE, c.cardID);
	}
	
	void CallFromDamage(Card c)
	{
		Game.CallFromDamage(c);	
		_CFDamage_Active = true;
	}
	
	void CallFromDamageUpdate(Void0ParamsDelegate fnc)
	{
		if(_CFDamage_Active)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				_CFDamage_Active = false;
				fnc();
			}
			else
			{
				Game.HandleCallFromDamage();	
			}
		}
	}
	
	void CounterBlast(int n, CounterBlastDelegate fnc)
	{
		_CB_num = n;
		
		if(Game.field.GetNumberOfDamageCardsFaceup() == n)
		{
			FlipCardInDamageZone(2);
			fnc();
		}
		else
		{
			_CB_Active = true;
			_CB_fnc = fnc;
			EnableMouse("Choose " + _CB_num + " face-up cards from your damage zone.");
		}
	}
	
	bool CounterBlast_Pointer()
	{
		if(_CB_Active)
		{
			if(AcceptInput())
			{
				Card c = Game.LastDamageCardSelected;
				if(c != null && c._HandleMouse.mouseOn && c.IsFaceup())
				{
					Flipdown(c);
					_CB_num--;
					if(_CB_num <= 0)
					{
						_CB_Active = false;
						ClearPointer(false);	
						_CB_fnc();
					}
				}
			}
			
			return true;
		}
		
		return false;
	}
	
	void BlockNormalGuardEndBattle(int min = 0, int max = 99)
	{
		Game.SendPacket(GameAction.BLOCK_GUARD_END_BATTLE, max);
		Game.SendPacket(GameAction.BLOCK_GUARD_END_BATTLE_MIN, min);
	}
	
	void Flipup(int n, CounterBlastDelegate fnc)
	{
		_CB_num = n;
		
		if(Game.field.GetNumberOfDamageCardsFacedown() == n)
		{
			UnflipCardInDamageZone(n);
			fnc();
		}
		else
		{
			_CB_Active = true;
			_CB_fnc = fnc;
			EnableMouse("Choose " + _CB_num + " face-down cards from your damage zone.");
		}
	}
	
	bool Flipup_Pointer()
	{
		if(_CB_Active)
		{
			if(AcceptInput())
			{
				Card c = Game.LastDamageCardSelected;
				if(c != null && c._HandleMouse.mouseOn && !c.IsFaceup())
				{
					FlipupCard(c);
					_CB_num--;
					if(_CB_num <= 0)
					{
						_CB_Active = false;
						ClearPointer(false);	
						_CB_fnc();
					}
				}
			}
			
			return true;
		}
		
		return false;
	}

	void FlipupCard(Card c)
	{
		c.TurnUp();
		Game.SendPacket(GameAction.FLIPUP, Game.field.GetDamageIndexOf(c));
	}
	
	void Flipdown(Card c)
	{
		c.TurnDown();
		Game.SendPacket(GameAction.FLIPDOWN, Game.field.GetDamageIndexOf(c));
	}
	
	bool LimitBreak()
	{
		return Game.field.GetDamage() >= 4;	
	}
	
	void SelectAnimField(Card c)
	{
		c.DoSelectAnim();
		Game.SendPacket(GameAction.SELECT_ANIM_FIELD, c.pos);
	}
	
	void Forerunner_Active()
	{
		ShowOnScreen();
		CallFromSoul(OwnerCard);	
	}
	
	void Forerunner_Update()
	{
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
	
	void IncreaseEnemyPowerByBattle(Card c, int power)
	{
		if(power < 0)
		{
			if(-power > c.GetPower())
			{
				power = -c.GetPower();	
			}
		}
		Game.SendPacket(GameAction.INCREASE_ENEMY_POWER_BATTLE, c.pos, power);
	}
	
	void IncreaseEnemyPowerByTurn(Card c, int power)
	{
		if(power < 0)
		{
			if(-power > c.GetPower())
			{
				power = -c.GetPower();	
			}
		}
		Game.SendPacket(GameAction.INCREASE_ENEMY_POWER_TURN, c.pos, power);
	}
	
	void RestEnemyUnit(Card c)
	{
		c.RestEnemy();
		Game.SendPacket(GameAction.REST_ENEMY_UNIT, c.pos);
	}
	
	bool ValidHand(Card c)
	{	
		return c != null && c._HandleMouse.mouseOn;
	}
	
	int EnemyStandRearUnits()
	{
		return Game.enemyField.GetNumberOfRearUnits() - Game.enemyField.GetNumberOfRearGuardRested();	
	}
	
	int EnemyRestRearUnits()
	{
		return Game.enemyField.GetNumberOfRearGuardRested();	
	}
	
	bool IsPlayerPosition(fieldPositions p)
	{
		return IsRearGuard(p) || p == fieldPositions.VANGUARD_CIRCLE;	
	}
	
	void OpponentDrawCard()
	{
		Game.SendPacket(GameAction.OPPONENT_DRAW);
	}
	
	public void FromDeckToHand(CardIdentifier id)
	{
		Card tmpCard = Game.playerDeck.RemoveFromDeck(Game.playerDeck.SearchForID_GetIndex(id));
		Game.SendPacket(GameAction.DRAW_FROM_DECK, 1);
		Game.playerHand.AddToHand(tmpCard);
		Game.SendPacket(GameAction.SHOW_CARD_HAND, tmpCard.cardID, Game.playerHand.Size() - 1);
	}
	
	/**
	 * Add a Update function to a specific card. The update function remains until the end of the turn.
	 * For each Update function added MUST be a [AUTO] ability added using AddExternAuto
	 */
	public void AddExternUpdate(Void0ParamsDelegate fnc)
	{
		ExternUpdate.Add(fnc);	
	}
	
	/**
	 * Add an amount equal to "shield" to the power of the unit currenty being attacked.
	 */
	public void AddExtraShield(int shield)
	{
		GetDefensor().AddExtraShield(shield);
		Game.SendPacket(GameAction.ADD_EXTRA_SHIELD, shield);
	}
	
	/**
	 * Move a card on the field to the deck
	 */
	public void FromFieldToDeck(Card c, bool bBottom = false)
	{
		Game.SendPacket(GameAction.RETURN_FROM_FIELD_TO_DECK, c.pos);
		Game.field.RemoveFrom(c.pos);
		c.SetRotation(0,180,0);
		Game.playerDeck.ReturnToDeck(c, bBottom);		
	}
	
	/**
	 * When an effect says: "Call to a separate RC". Call this function and then use Block() and IsBlocked()
	 */ 
	public void UnblockAllZones()
	{
		Unblock(fieldPositions.VANGUARD_CIRCLE);
		Unblock(fieldPositions.REAR_GUARD_CENTER);
		Unblock(fieldPositions.REAR_GUARD_LEFT);
		Unblock(fieldPositions.REAR_GUARD_RIGHT);
		Unblock(fieldPositions.FRONT_GUARD_LEFT);
		Unblock(fieldPositions.FRONT_GUARD_RIGHT);
	}
	
	/**
	 * Unblock a RC or VC, don't use this function. Use UnblockAllZones instead.
	 */
	public void Unblock(fieldPositions p)
	{
		_AuxBool20Array[(int)p] = false;	
	}
	
	/**
	 * Block a RC or VC, to see if a zone is blocked or not, use IsBlocked()
	 */
	public void Block(fieldPositions p)
	{
		_AuxBool20Array[(int)p] = true;	
	}
	
	/**
	 * Returns true if the RC or VC is blocked. False otherwise.
	 */
	public bool IsBlocked(fieldPositions p)
	{
		return _AuxBool20Array[(int)p];	
	}
	
	/**
	 * Returns true if a Counter Blast with n cards can be performed.
	 */
	public bool CheckCounterBlast(int n)
	{
		return Game.field.GetNumberOfDamageCardsFaceup() >= n;			
	}
	
	
	/**
	 * Increase the critical of "c" in an amount equal to "critical"
	 */
	public void IncreaseCriticalByBattle(Card c, int critical)
	{
		c.IncreaseCritical(critical);	
		Game.SendPacket(GameAction.CRITICAL_INCREASE, c.pos, critical);
	}
	
	/**
	 * Move and enemy unit to his/her soul. c MUST be an enemy unit.
	 */
	public void EnemyMoveToSoul(Card c)
	{
		if(c != null)
		{
			Game.SendPacket(GameAction.OPPONENT_MOVE_SOUL, c.pos);	
		}
	}
	
	/**
	 * Shuffle deck.
	 */
	public void ShuffleDeck()
	{
		Game.playerDeck.Shuffle();
		Game.bDeckHasBeenShuffledThisTurn = true;
	}
	
	/**
	 * When the player puts her/his mouse over a card in hand. That card is stored and can be retrieved with this function.
	 */
	public Card HandSelectedCard()
	{
		return Game.playerHand.GetCurrentCardObject();	
	}
	
	/**
	 * Returns the position of the current selected card in hand
	 */
	public int HandPos()
	{
		return Game.playerHand.GetCurrentCard();	
	}
	
	/**
	 * Call this function is you want to be able to use Pointer functions (Select cards from hand, field, drop, etc...)
	 */
	public void EnableMouse(string str)
	{
		EnableMouse();
		DisplayHelpMessage(str);
	}
	
	/**
	 * Use this function to iterate through all enemy cards. Use a for(int i = 0; i < 6; i++) EnemyField(i)
	 */
	public Card EnemyField(int idx)
	{
		if(idx == 0)
		{
			return Game.enemyField.GetCardAt(EnemyFieldPosition.VANGUARD);	
		}
		
		if(idx == 1)
		{
			return Game.enemyField.GetCardAt(EnemyFieldPosition.FRONT_LEFT);	
		}
		
		if(idx == 2)
		{
			return Game.enemyField.GetCardAt(EnemyFieldPosition.FRONT_RIGHT);	
		}
		
		if(idx == 3)
		{
			return Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_LEFT);	
		}
		
		if(idx == 4)
		{
			return Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_RIGHT);	
		}
		
		if(idx == 5)
		{
			return Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_CENTER);	
		}
		
		return null;
	}
	
	bool SC_WithSelection = false;
	List<CardIdentifier> SC_List = null;
	
	/**
	 * Soul Charge n cards, use SoulChargeUpdate() inside a Update function
	 */ 
	public void SoulCharge(int n)
	{
		SC_Int = n;
		SC_Bool = true;
	}
	
	public void SoulCharge(List<CardIdentifier> v)
	{
		SC_Int = v.Count;
		SC_Bool = true;		
		SC_WithSelection = true;
		SC_List = v;
	}
	
	/**
	 * When Soul Charge is finished (After call SoulCharge()) the delegate function "func" is executed.
	 */
	public void SoulChargeUpdate(Void0ParamsDelegate func)
	{
		if(SC_Bool)
		{
			if(SC_Card == null || !SC_Card.AnimationOngoing())
			{
				if(SC_Int > 0)
				{
					SC_Int--;
					if(SC_WithSelection)
					{
						SC_Card = Game.SoulCharge (SC_List[0]);
						SC_List.RemoveAt(0);
					}
					else
					{
						SC_Card = Game.SoulCharge();
					}
				}
				else
				{
					SC_Bool = false;
					func();
				}
			}
		}
	}
	
	public void DrawCard(int n)
	{
		DC_n = n;
		DC_bool = true;
		DC_time = 0;
	}
	
	public void DrawCardUpdate(Void0ParamsDelegate func)
	{
		if(DC_bool)
		{
			DC_time -= Time.deltaTime;
			
			if(DC_n > 0)
			{
				if(DC_time <= 0)
				{
					DrawCardWithoutDelay();
					DC_n--;
					DC_time = 1.2f;
				}
			}
			else
			{
				DC_bool = false;
				func();
			}
		}
	}	

	public void SetBool(int i)
	{
		if(i == 1)
		{
			_AuxBool = true;	
		}
		else if(i == 2)
		{
			_AuxBool2 = true;
		}
		else if(i == 3)
		{
			_AuxBool3 = true;	
		}
		else if(i == 4)
		{
			_AuxBool4 = true;	
		}
		else if(i == 5)
		{
			_AuxBool5 = true;	
		}
		else if(i == 6)
		{
			_AuxBool6 = true;	
		}
	}
	
	public void UnsetBool(int i)
	{
		if(i == 1)
		{
			_AuxBool = false;	
		}
		else if(i == 2)
		{
			_AuxBool2 = false;	
		}
		else if(i == 3)
		{
			_AuxBool3 = false;	
		}
		else if(i == 4)
		{
			_AuxBool4 = false;	
		}
		else if(i == 5)
		{
			_AuxBool5 = false;	
		}
		else if(i == 6)
		{
			_AuxBool6 = false;	
		}
	}
	
	public bool GetBool(int i)
	{
		if(i == 1)
		{
			return _AuxBool;	
		}
		else if(i == 2)
		{
			return _AuxBool2;	
		}
		else if(i == 3)
		{
			return _AuxBool3;	
		}
		else if(i == 4)
		{
			return _AuxBool4;
		}
		else if(i == 5)
		{
			return _AuxBool5;	
		}
		else if(i == 6)
		{
			return _AuxBool6;	
		}
		
		return false;
	}	
	
	void ClearPointer(bool bEnd = true)
	{
		ClearMessage();
		DisableMouse();
		if(bEnd)
		{
			EndEffect();
		}
	}
	
	bool LB(int n)
	{
		return n >= Game.field.GetDamage();	
	}
	
	public void OpponentRetireUnit()
	{
		Game.SendPacket(GameAction.OPPONENT_RETIRE_UNIT);	
	}
	
	public void OpponentRideFromSoul()
	{
		Game.SendPacket(GameAction.OPPONENT_RIDE_FROM_SOUL);	
	}
	
	public void EnemyRideFromField(Card c, bool bActiveAutoEffects)
	{
		Game.EnemyRideFromField(c, bActiveAutoEffects);
	}
	
	public void CallFromSoul(Card c)
	{
		_CFS_AuxCard = c;
		Game.Call(c);
		Game.bBlockMouseOnce = true;
		_CFS_AuxBool3 = true;	
	}
	
	public void CallFromSoulUpdate(Void0ParamsDelegate func)
	{
		if(_CFS_AuxBool3)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				_CFS_AuxBool3 = false;
				Game.field.RemoveFromSoulByCard(_CFS_AuxCard);
				_CFS_AuxCard.TurnUp();
				func();
			}
			else
			{
				Game.HandleSpecialCall();	
			}
		}
	}
	
	public bool IsSameColumn(Card c1, Card c2)
	{
		if(c1.pos == fieldPositions.ENEMY_FRONT_LEFT  ||
		   c1.pos == fieldPositions.ENEMY_REAR_LEFT   ||
	       c1.pos == fieldPositions.FRONT_GUARD_RIGHT ||
		   c1.pos == fieldPositions.REAR_GUARD_RIGHT)
		{
		   if(c2.pos == fieldPositions.ENEMY_FRONT_LEFT  ||
		  	  c2.pos == fieldPositions.ENEMY_REAR_LEFT   ||
	          c2.pos == fieldPositions.FRONT_GUARD_RIGHT ||
		      c2.pos == fieldPositions.REAR_GUARD_RIGHT)
			{
				return true;	
			}
		}
		
		if(c1.pos == fieldPositions.ENEMY_FRONT_RIGHT ||
		   c1.pos == fieldPositions.ENEMY_REAR_RIGHT  ||
	       c1.pos == fieldPositions.FRONT_GUARD_LEFT  ||
		   c1.pos == fieldPositions.REAR_GUARD_LEFT)
		{
		   if(c2.pos == fieldPositions.ENEMY_FRONT_RIGHT  ||
		  	  c2.pos == fieldPositions.ENEMY_REAR_RIGHT   ||
	          c2.pos == fieldPositions.FRONT_GUARD_LEFT   ||
		      c2.pos == fieldPositions.REAR_GUARD_LEFT)
			{
				return true;	
			}
		}
		
		if(c1.pos == fieldPositions.ENEMY_REAR_CENTER  ||
		   c1.pos == fieldPositions.ENEMY_VANGUARD     ||
	       c1.pos == fieldPositions.REAR_GUARD_CENTER  ||
		   c1.pos == fieldPositions.VANGUARD_CIRCLE)
		{
		   if(c2.pos == fieldPositions.ENEMY_REAR_CENTER  ||
		  	  c2.pos == fieldPositions.ENEMY_VANGUARD     ||
	          c2.pos == fieldPositions.REAR_GUARD_CENTER  ||
		      c2.pos == fieldPositions.VANGUARD_CIRCLE)
			{
				return true;	
			}
		}
		
		return false;
	}
	
	public void DrawCard()
	{
		executeAbility = 4;
	}
	
	public Card DiscardSelectedCard()
	{
		Card tmp = Game.playerHand.GetCurrentCardObject();
		Game.playerHand.RemoveFromHand(Game.playerHand.GetCurrentCard());
		Game.field.AddToDropZone(tmp);
		Game.SendPacket (GameAction.ENEMY_DISCARD, tmp.cardID);	
		return tmp;
	}
	
	public void EnemyHasToDiscardOneCard()
	{
		Game.SendConfirmation();
		Game.SendPacket(GameAction.ALLY_DISCARD);
		Game.WaitForOponnent();	
	}
	
	public Card ReturnCardFromHandToDeck(bool bottom = false, bool shuffle = true)
	{
		Card tmp = Game.playerHand.GetCurrentCardObject();
		Game.playerHand.RemoveFromHand(Game.playerHand.GetCurrentCard());
		
		if(!bottom)
		{
			Game.playerDeck.AddCard(tmp);
		}
		else 
		{
			Game.playerDeck.AddToBottom(tmp);	
		}
		
		if(shuffle)
		{
			Game.playerDeck.Shuffle();
		}
		
		Game.SendPacket (GameAction.RETURN_CARD_FROM_HAND_TO_DECK);	
		return tmp;
	}
	
	public void DisplayHelpMessage(string msg)
	{
		Game._GameHelper.CustomMessage(msg);
	}
	
	public void ClearMessage()
	{
		Game._GameHelper.DisableCustomMessage();	
	}
	
	public void EnableMouse()
	{
		Game.bBlockMouse = true;
		bEnablePointer = true;	
	}
	
	public void DisableMouse()
	{
		Game.bBlockMouse = false;
		bEnablePointer = false;		
		ClearMessage();
	}
	
	public void DisplayConfirmationWindow(int id = -1)
	{
		if(Game.bCheckAutoMode) return;

		currentActiveExternId = id;
		StartEffect();
		bWindowActive = true;
		Game.ActivePopUpQuestion(GetCard());	
	}
	
	public void SetCard(Card card)
	{
		Game._LastUnitAbilityCard = card;	
		_Card = card;
	}
	
	public Card GetCard()
	{
		return OwnerCard;
		//return Game._LastUnitAbilityCard;	
	}
	
	public void ConfirmAttack()
	{
		//Game._AttackType = AttackType.NONE;
		//Game.bConfirmAttack = true;	
	}
	
	public void DeclareAttack(AttackType type)
	{
		Game._AttackType = type;
		Game.bConfirmAttack = true;			
	}
	
	public void ConfirmAttack(AttackType type)
	{
		Game._AttackType = type;
		Game.bConfirmAttack = true;	
	}
	
	public bool ExistsBackUnitSameColumn(fieldPositions pos)
	{
		if(pos == fieldPositions.VANGUARD_CIRCLE)
		{
			return (Game.enemyField.Center_Rear != null);	
		}
		
		if(pos == fieldPositions.FRONT_GUARD_LEFT)
		{
			return (Game.enemyField.Right_Rear != null);	
		}
		
		if(pos == fieldPositions.FRONT_GUARD_RIGHT)
		{
			return (Game.enemyField.Left_Rear != null);	
		}
		
		return false;
	}
	
	public Card GetBackUnitSameColumn(fieldPositions pos)
	{
		if(pos == fieldPositions.VANGUARD_CIRCLE)
		{
			return Game.enemyField.Center_Rear;	
		}
		
		if(pos == fieldPositions.FRONT_GUARD_LEFT)
		{
			return Game.enemyField.Right_Rear;	
		}
		
		if(pos == fieldPositions.FRONT_GUARD_RIGHT)
		{
			return Game.enemyField.Left_Rear;	
		}
		
		return null;
	}
	
	public Card GetSameColum(fieldPositions p)
	{
		if(p == fieldPositions.VANGUARD_CIRCLE)   return Game.field.GetCardAt(fieldPositions.REAR_GUARD_CENTER);
		if(p == fieldPositions.FRONT_GUARD_LEFT)  return Game.field.GetCardAt(fieldPositions.REAR_GUARD_LEFT);
		if(p == fieldPositions.FRONT_GUARD_RIGHT) return Game.field.GetCardAt(fieldPositions.REAR_GUARD_RIGHT);
		if(p == fieldPositions.REAR_GUARD_LEFT)   return Game.field.GetCardAt(fieldPositions.FRONT_GUARD_LEFT);
		if(p == fieldPositions.REAR_GUARD_RIGHT)  return Game.field.GetCardAt(fieldPositions.FRONT_GUARD_RIGHT);
		if(p == fieldPositions.REAR_GUARD_CENTER) return Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE);
		return null;
	}
	
	public bool CurrentPhaseIs(GamePhase phase)
	{
		if(Game.gamePhase == phase)
		{
			return true;	
		}
		
		return false;
	}
	
	public void ChangeTarget(Card newTarget)
	{
		Game.CardToAttack = newTarget;
	}
	
	public Card GetAttacker()
	{
		return Game.CardAttacking;	
	}
	
	public Card GetDefensor()
	{
		return Game.CardToAttack;	
	}
	
	public void RetireEnemyUnit(Card card)
	{
		if(!card.bCanBeRetireByEffects)
		{
			SelectAnimField(card);
			return;
		}

		card.retireUnitOwner = OwnerCard;

		Game._AbilityManager.AddAbility(CardState.EnemyTurn_FromRCToDrop, card);
		Game.SendPacket(GameAction.ADD_CARD_TO_ABILITYSTACK, card.pos);
		
		Game.enemyField.ClearZone(Util.TransformToEquivalentEnemyPosition(card.pos));
		Game.enemyField.AddToDropZone(card, true);		
		Game.SendPacket(GameAction.SEND_TO_DROPZONE_ALLY, card.pos);
		
		Game.playerHand.CheckHandEffects(CardState.Hand_EnemyToDropFromRG);
		Game.field.CheckAbilities(CardState.EnemyCardSendToDropZone);
	}
	
	public void RetireUnit(Card card)
	{		
		if(!card.bCanBeRetireByEffects)
		{
			SelectAnimField(card);
			return;
		}

		Game.field.ClearZone(card.pos);
		Game.field.AddToDropZone(card);
		Game.SendPacket(GameAction.SEND_TO_DROPZONE, card.pos);
		
		if(!card.IsVanguard())
		{
			Game.field.CheckAbilitiesExcept(card.pos, CardState.UnitSendToDropZoneFromRC, card);
			card.CheckAbilities(CardState.DropZoneFromRC);	
		}
	}
	
	public bool IsPlayerTurn()
	{
		return CurrentPhaseIs(GamePhase.ATTACK) || CurrentPhaseIs(GamePhase.DRAW) || CurrentPhaseIs(GamePhase.MAIN_PHASE) || CurrentPhaseIs(GamePhase.STANDBY_PHASE);	
	}
	
	public void RetireAllEnemyUnits()
	{
		Card temp = Game.enemyField.GetCardAt(EnemyFieldPosition.FRONT_LEFT);
		if(temp != null)
		{
			RetireEnemyUnit(temp);	
		}
		
		temp = Game.enemyField.GetCardAt(EnemyFieldPosition.FRONT_RIGHT);
		if(temp != null)
		{
			RetireEnemyUnit(temp);	
		}
		
		temp = Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_CENTER);
		if(temp != null)
		{
			RetireEnemyUnit(temp);	
		}
		
		temp = Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_LEFT);
		if(temp != null)
		{
			RetireEnemyUnit(temp);	
		}
		
		temp = Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_RIGHT);
		if(temp != null)
		{
			RetireEnemyUnit(temp);	
		}
	}
	
	public void AddExternPersistent(Card c, DelegateContainer.ObjectParam func)
	{
		ExternPersistent.Add(new ExternPersistentContainer(c, func));	
	}
	
	public void RemoveExternPersistent(Card c)
	{
		int idx = 0;
		while(idx < ExternPersistent.Count)
		{
			if(ExternPersistent[idx].OwnerCard == c)
			{
				ExternPersistent.RemoveAt(idx);	
			}
			else
			{
				idx++;	
			}
		}
	}
	
	//Generic functions.
	public void IncreasePowerByBattle(Card card, int power)
	{
		card.IncreasePower(power);
		Game.SendPacket(GameAction.POWER_INCREASE, card.pos, power);
	}
	
	public void IncreasePowerByTurn(Card card, int power)
	{
		card.IncreasePowerUntilEndTurn(power);
		Game.SendPacket(GameAction.INCREASE_POWER_END_TURN, card.pos, power);
	}
	
	public void StandUnit(Card card)
	{
		card.bBecomeStandThisTurn = true;
		card.Stand();
		Game.SendPacket(GameAction.STAND_UNIT, card.pos);
		card.CheckAbilities(CardState.Stand, card);
		Game.field.CheckAbilitiesExcept(card.pos, CardState.Stand_NotMe, card);
	}
	
	public void IncreasePowerByTurn(int power)
	{
		executeAbility = 1;
		_Power = power;
		_Card = GetCard();
	}
	
	public void IncreasePowerByBattle(int power)
	{
		executeAbility = 0;
		_Power = power;
		_Card = _AuxCard;		
	}
	
	public void RideFromDropZone(Card _card)
	{
		Game.field.RemoveFromDropzone(_card);
		Game.field.Ride (_card);
		Game.SendPacket(GameAction.RIDE_FROM_DROP, _card.cardID);
	}
	
	public void SetPowerAndCriticalUp(Card card, int power, int critical)
	{
		executeAbility = 2;
		_Power = power;
		_Critical = critical;
		_AuxCard = card;
	}
			
	public void IncreasePowerAndCriticalByTurn(Card card, int power, int critical)
	{
		card.IncreasePowerUntilEndTurn(power);
		Game.SendPacket(GameAction.INCREASE_POWER_END_TURN, card.pos, power);
		card.IncreaseCriticalUntilEndTurn(critical);
		Game.SendPacket(GameAction.INCREASE_CRITICAL_END_TURN, card.pos, critical);
	}
	
	public void FlipCardInDamageZone(int num)
	{
		while(num-- != 0)
		{
			Game.field.FlipDamageZoneCard();
			Game.SendPacket(GameAction.FLIPDAMAGE);	
		}
	}
	
	public void UnflipCardInDamageZone(int num)
	{
		while(num-- != 0)
		{
			Game.field.UnflipDamageZoneCard();
			Game.SendPacket(GameAction.UNFLIPDAMAGE);	
		}
	}
	
	public void RestUnit(Card card)
	{
		Game.LastRest = card;
		
		card.Rest();
		Game.SendPacket(GameAction.REST_UNIT, card.pos);
		
		card.CheckAbilities(CardState.Rest);
		Game.field.CheckAbilitiesExcept(card.pos, CardState.Rest_NotMe);
	}
	
	public void SetPersistentPower_CommitChange(Card card, int power)
	{
		if(_LastPersistenPower == -1 || _LastPersistenPower != power)
		{
			_LastPersistenPower = power;
			card.SetPersistentPower(power);
			Game.SendPacket(GameAction.PERSISTENT_POWER, card.pos, power);
		}		
	}
	
	int currPersistentPower = 0;
	
	public void SetPersistentPower(Card card, int power)
	{
		currPersistentPower = power;
	}

	public void SetPersistentCritical(Card card, int critical)
	{
		if(_LastPersistenCritical == -1 || _LastPersistenCritical != critical)
		{
			_LastPersistenCritical = critical;
			card.SetPersistentCritical(critical);
			Game.SendPacket(GameAction.PERSISTENT_CRITICAL, card.pos, critical);
		}
	}
	
	public void DrawCardWithoutDelay()
	{
		Game.playerHand.AddToHand(Game.playerDeck.DrawCard());
		Game.SendPacket(GameAction.DRAW_FROM_DECK, 1);	
		Game.field.CheckAbilities(CardState.Draw);
	}
	
	public void CantStandUntilNextTurn(Card card)
	{
		card.NegateStand();
		Game.SendPacket(GameAction.NEGATE_ENEMY_STAND, card.pos);
	}
	
	public void ShowCardInHand(Card card, int position = -1)
	{
		int handPosition = position;
		if(handPosition == -1)
		{
			handPosition = Game.playerHand.Size() - 1;	
		}
		
		Game.SendPacket(GameAction.SHOW_CARD_HAND, card.cardID, position);	
	}
	
	public void SoulChargeFromDrop(Card card)
	{
		card.Stand();
		Game.field.MoveToSoul(card);
		Game.field.RemoveFromDropzone(card);
		Game.field.FixSoulPosition();
		Game.SendPacket(GameAction.FROM_DROP_TO_SOUL, card.cardID);
	}
	
	public Card SendCardFromDeckToDrop()
	{
		Card tmp = Game.playerDeck.DrawCard();
		tmp.TurnUp();
		Game.field.AddToDropZone(tmp);
		/*
		Game.field.AddToDropZoneList(tmp);
		Vector3 newPos = Game.field.fieldInfo.GetPosition((int)fieldPositions.DROP_ZONE);
		tmp.GoTo(newPos.x, newPos.y, newPos.z);
		*/
		Game.SendPacket(GameAction.FROM_DECK_TO_DROP, tmp.cardID);
		
		return tmp;
	}
	
	public Card SendCardFromDeckToDrop(Card c)
	{
		Card tmp = c;
		Game.playerDeck.RemoveFromDeck(tmp);
		tmp.TurnUp();
		Game.field.AddToDropZone(tmp);
		/*
		Game.field.AddToDropZoneList(tmp);
		Vector3 newPos = Game.field.fieldInfo.GetPosition((int)fieldPositions.DROP_ZONE);
		tmp.GoTo(newPos.x, newPos.y, newPos.z);
		*/
		Game.SendPacket(GameAction.FROM_DECK_TO_DROP, tmp.cardID);
		
		return tmp;
	}
	
	
	public void ReturnToHand(Card c)
	{
		bool bIsVanguard = c.IsVanguard();
		Game.SendPacket(GameAction.RETURN_FROM_FIELD_TO_HAND, c.pos);
		Game.field.RemoveFrom(c.pos);
		Game.playerHand.AddToHand(c);
		if(!bIsVanguard)
		{
			c.CheckAbilities(CardState.HandFromRear);
			Game.field.CheckAbilitiesExcept(c.pos, CardState.HandFromRear_NotMe, c);
		}
	}
	
	public void CallFromDrive()
	{
		Game.CallFromDrive();
	}
	
	public void CallFromDeck(List<CardIdentifier> v)
	{
		_CFDAux_IDVector = v;
		_CFDAux_Bool1 = true;
		_CFDAux_Int1 = v.Count;
		CallFromDeckList.Clear();
	}
	
	public void CallFromDeckUpdate(Void0ParamsDelegate func)
	{
		if(_CFDAux_Bool1)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				if(_CFDAux_Int1 <= 0)
				{
					_CFDAux_Bool1 = false;
					func();	
				}
				else
				{
					_CFDAux_Card = Game.playerDeck.SearchForID(_CFDAux_IDVector[0]);
					CallFromDeckList.Add(Game.playerDeck.SearchForID(_CFDAux_IDVector[0]));
					_CFDAux_IDVector.RemoveAt(0);
					Game.playerDeck.RemoveFromDeck(_CFDAux_Card);
					Game.CallFromDeck(_CFDAux_Card);
					_CFDAux_Card.TurnUp();
					_CFDAux_Int1--;
				}
			}
			else
			{
				Game.HandleCallFromDeck();	
			}
		}			
	}
	
	public void CallFromDropUpdate(Void0ParamsDelegate func)
	{
		if(_DropCall_AuxBool)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				Debug.Log ("Calling unit.");
				_DropCall_AuxBool = false;
				func();
			}
			else
			{
				Debug.Log ("HandleCallFromDrop");
				Game.HandleCallFromDrop();	
			}
		}
	}
	
	public void CallFromDrop(Card card)
	{
		Game.CallFromDrop(card);	
		_DropCall_AuxBool = true;
	}
	
	public void CallFromDrop(Card card, fieldPositions p)
	{
		Game.CallFromDrop(card, p);	
	}
	
	public bool Megablast_Check(int damage, int soul)
	{
		return Game.field.GetNumberOfDamageCardsFaceup() >= damage && Game.field.GetNumberOfCardsInSoul() >= soul;
	}
	
	public void Megablast_Active(int damage, int soul)
	{
		ShowOnScreen(OwnerCard);
		_Megablast_AuxBool3 = true;
		_Megablast_AuxInt   = soul;
		FlipCardInDamageZone(damage);
		Game.field.ViewSoul(soul);
		DisplayHelpMessage("Choose " + soul + " cards from your soul and send them to drop zone.");
	}
	
	bool AllEnemyUnitsRested()
	{
		return (Game.enemyField.GetNumberOfRearGuardRested() == Game.enemyField.GetNumberOfRearUnits()) &&
				!Game.enemyField.GetCardAt(EnemyFieldPosition.VANGUARD).IsStand();
	}
	
	public void Megablast_Update(MegablastEffect func)
	{
		if(_Megablast_AuxBool3)
		{
			if(!Game.field.ViewingSoul())
			{
				_Megablast_AuxBool2 = true;
				_Megablast_AuxBool3 = false;
				_AuxIdVector = Game.field.GetLastSelectedList();
			}
		}	
		
		if(_Megablast_AuxBool2)
		{
			if(_Megablast_AuxCard == null || !_Megablast_AuxCard.AnimationOngoing())
			{
				if(_Megablast_AuxInt >= 0)
				{
					if(_Megablast_AuxCard != null)
					{
						Game.field.RemoveFromSoulByCard(_Megablast_AuxCard);
						Game.field.AddToDropZone(_Megablast_AuxCard);	
					}
					
					_Megablast_AuxInt--;
					_Megablast_AuxCard = Game.field.GetSoulByID(_AuxIdVector[0]);
					_AuxIdVector.RemoveAt(0);
					Game.SoulBlast(_Megablast_AuxCard);	
				}
				else
				{
					ClearMessage();
					func();
					_Megablast_AuxBool2 = false;
				}
			}
		}
	}
	
	public bool IsRearGuard(fieldPositions p)
	{
		return !Util.IsEnemyPosition(p) && p != fieldPositions.VANGUARD_CIRCLE;
	}
	
	public void StartEffect()
	{
		if(Game.bCheckAutoMode)
		{
			Game.bAutoCanBeTriggered = true;
			return;
		}

		Game.GameChat.AddChatMessage("ADMIN", "StartEffect() method called.");
		Game.GameChat.SetTab(ChatTab.HELP);
		Game.bEffectOnGoing = true;
		Game.SendPacket(GameAction.EFFECT_ON);
	}
	
	public void EndEffect()
	{
		Game.SendPacket(GameAction.EFFECT_OFF);
		Game.bEffectOnGoing = false;	
	}
	
	public Card GetCardAt(fieldPositions p)
	{
		return Game.field.GetCardAt(p);	
	}
	
	public void SoulBlast(int n, FieldGlobalVar.CountConstraint _f = null)
	{
		if(_f == null)
		{
			Game.field.ViewSoul(n);
		}
		else
		{
			Game.field.ViewSoul(n, _f);
		}
		
		_SBAux_Bool1 = true;
		_SBAux_Int1 = n;
		DisplayHelpMessage("Choose " + n + " cards from your soul and send them to your drop zone.");
	}
	
	public void SoulBlast(List<CardIdentifier> L)
	{
		_SBAux_IDVector = L;
		_SBAux_Int1 = L.Count;
		_SBAux_Bool2 = true;
		_SBAux_Card1 = null;
	}
	
	public void SoulBlastUpdate(Void0ParamsDelegate func)
	{
		if(_SBAux_Bool1)
		{
			if(!Game.field.ViewingSoul())
			{
				_SBAux_Bool1 = false;
				_SBAux_IDVector = Game.field.GetLastSelectedList();
				_SBAux_Bool2 = true;
			}
		}
		
		if(_SBAux_Bool2)
		{
			if(_SBAux_Int1 > 0)
			{
				if(_SBAux_Card1 == null || !_SBAux_Card1.AnimationOngoing())
				{
					if(_SBAux_Card1 != null)
					{
						Game.field.RemoveFromSoulByCard(_SBAux_Card1);
						Game.field.AddToDropZone(_SBAux_Card1);	
					}
					
					_SBAux_Card1 = Game.field.GetSoulByID(_SBAux_IDVector[0]);
					_SBAux_IDVector.RemoveAt(0);
					Game.SoulBlast(_SBAux_Card1);
					Debug.Log(_SBAux_Card1.cardID);
					_SBAux_Int1--;
				}
			}
			else
			{
				if(_SBAux_Card1 != null)
				{
					Game.field.RemoveFromSoulByCard(_SBAux_Card1);
					Game.field.AddToDropZone(_SBAux_Card1);	
					_SBAux_Card1 = null;
				}
				
				_SBAux_Bool2 = false;
				ClearMessage();
				func();	
			}
		}
	}

	int GetNumUnits(string clan)
	{
		int n = 0;
		if(GetVanguard().clan == clan) n = 1;
		return NumRearGuards(clan) + n;
	}
	
	int GetNumUnits(CardIdentifier id)
	{
		int n = 0;
		if(GetVanguard().cardID == id) n = 1;
		return GetNumRear(id) + n;
	}
	
	int NumEnemyRG(boolCardFunction fnc)
	{
		int cnt = 0;
		for(int i = 0; i < 6; i++) 
		{
			if(EnemyField(i) != null && fnc(EnemyField(i)))	
			{
				cnt++;
			}
		}
		return cnt;
	}
	
	Card FromBindToDeck_Card = null;
	bool FromBindToDeck_Active = false;
	bool FromBindToDeck_toBottom = false;
	
	void FromBindToDeck(Card c, bool toBottom = false)
	{
		Vector3 newPosition = Game.field.fieldInfo.GetPosition((int)fieldPositions.DECK_ZONE);
		c.FromBindTo(newPosition);
		FromBindToDeck_Card = c;
		FromBindToDeck_Active = true;
		FromBindToDeck_toBottom = toBottom;
		Game.SendPacket (GameAction.FROM_BIND_TO_DECK, c.cardID);
	}
	
	void FromBindToDeckUpdate(Void0ParamsDelegate fnc)
	{
		if(FromBindToDeck_Active)
		{
			if(!FromBindToDeck_Card.AnimationOngoing())
			{
				Game.field.RemoveFromBindZone(FromBindToDeck_Card);
				
				if(FromBindToDeck_toBottom) 
				{
					Game.playerDeck.AddToBottom(FromBindToDeck_Card);	
				}
				else
				{
					Game.playerDeck.AddCard(FromBindToDeck_Card);
				}
				
				FromBindToDeck_Active = false;
				FromBindToDeck_Card = null;
				fnc();
			}
		}
	}
	
	//Contains the cards that will be removed from deck and added to bindzone.
	List<Card> BindFromDeck_CardList = null;
	//Current Card that is being bound.
	Card BindFromDeck_Card = null;
	//Tells if BindFromDeckUpdate method will be executed or not in each frame.
	bool BindFromDeck_Active = false;
	
	/**
	 * Take a Card Object List and remove them from deck by one by and put them into the Bind Zone. An animation occurs.
	 * When all cards are in the BindZone. Delegate function of BindFromDeckUpdate method is called.
	 * All cards objects in the list must be in the deck.
	 * The cards will be bind starting from index 0 of the list.
	 */
	void BindFromDeck(List<Card> L)
	{
		BindFromDeck_CardList = L;
		BindFromDeck_Card     = null;
		BindFromDeck_Active   = true;
	}
	
	/**
	 * This method performs the animation of the cards that will be send to Bind Zone. And also performs
	 * the remove from deck, add to bind and networking communication. This method must be call in a
	 * Update function after a BindFromDeck method was called. When all Cards passed in the BindFromDeck
	 * argument were sent to BindZone, func delegate will be executed.
	 */
	void BindFromDeckUpdate(Void0ParamsDelegate func)
	{
		if(BindFromDeck_Active)
		{
			if(BindFromDeck_Card == null || !BindFromDeck_Card.AnimationOngoing())
			{
				if(BindFromDeck_Card != null)
				{
					//Remove from deck and add to BindZone.
					Game.playerDeck.RemoveFromDeck(BindFromDeck_Card);
					Game.field.AddToBindZone(BindFromDeck_Card);
					BindFromDeck_Card = null;
				}
				
				//Send the next card in the list, if any. If not, func delegate is called.
				if(BindFromDeck_CardList.Count > 0)
				{
					BindFromDeck_Card = BindFromDeck_CardList[0];
					BindFromDeck_CardList.RemoveAt(0);
					BindFromDeck_Card.TurnUp();
					BindFromDeck_Card.BindAnim();
					Game.SendPacket (GameAction.BIND_FROM_DECK, BindFromDeck_Card.cardID);
				}
				else
				{
					BindFromDeck_Active = false;
					func();
				}
			}
		}
	}
	
	void FromFieldToDamage(Card c)
	{
		Game.field.RemoveFrom(c.pos);	
		Game.field.AddToDamageZone(c);
		Game.SendPacket(GameAction.FROM_FIELD_TO_DAMAGE, c.pos);
	}
	
	#endregion
	public int currentActiveExternId = -1;

	public int contPower = 0;
	public int contCritical = 0;
	
	//Update function, It is called every frame.
	public void Update()
	{
		if(Game == null)
		{
			//Game.GameChat.AddChatMessage("ADMIN", "Game = null");
			return;
		}		
		//Debug.Log ("Updating: " + OwnerCard.cardID);
		/*
		if(OwnerCard._Coord == CardCoord.FIELD && _UnitObject == null)
		{
			UpdatePersistentAbilities(OwnerCard);
		}
		*/
		
		FreeUpdate(OwnerCard.cardID);	
		
		if(Game.OppWindowRequestedBy == OwnerCard)
		{
			if(Game.LastOpponentWindow != OPPWINDOW.NONE)
			{
				if(Game.LastOpponentWindow == OPPWINDOW.ACCEPT)
				{
					OnOpponentAccept();	
				}
				else if(Game.LastOpponentWindow == OPPWINDOW.DENIED)
				{
					OnOpponentCancel();	
				}
				Game.LastOpponentWindow = OPPWINDOW.NONE;
				Game.OppWindowRequestedBy = null;
			}
		}
		
		bool bExternEnablePointer = false;
		for(int i = 0; i < ExternEffects.Count; i++)
		{
			if(ExternEffects[i].bEnablePointer)
			{
				bExternEnablePointer = true;
				break;
			}
		}
		
		if(bExternEnablePointer || bEnablePointer || (_UnitObject != null && _UnitObject.bEnablePointer))
		{
			HandlePointerEvents();	
		}
		
		if(executeAbility != -1 && !Game.bShowCardEffect)
		{
			if(executeAbility == 0)
			{
				IncreasePowerByBattle(_AuxCard, _Power);
			}
			else if(executeAbility == 1)
			{
				IncreasePowerByTurn(_AuxCard, _Power);
			}
			else if(executeAbility == 2)
			{
				IncreasePowerAndCriticalByTurn(_AuxCard, _Power, _Critical);	
			}
			else if(executeAbility == 3)
			{
				Game.playerHand.RemoveFromHand(Game.playerHand.GetIndexOf(_Card));
				Game.Ride(_Card);
			}
			else if(executeAbility == 4)
			{
				Game.playerHand.AddToHand(Game.playerDeck.DrawCard());
				Game.SendPacket(GameAction.DRAW_FROM_DECK, 1);
			}
			executeAbility = -1;
			Game.bEffectOnGoing = false;
		}
		
		bool bExternWindowOpen = false;
		for(int i = 0; i < ExternEffects.Count; i++)
		{
			if(ExternEffects[i].bWindowActive)
			{
				bExternWindowOpen = true;
				break;
			}
		}
		
		if(Game.LastPPAnswer != 0 && (bExternWindowOpen || bWindowActive || (_UnitObject != null && _UnitObject.bWindowActive)))
		{
			if(Game.LastPPAnswer == 1)
			{
				//Game.GameChat.AddChatMessage("ADMIN", "LastPPAnswer = " + OwnerCard.unitAbilities.currentActiveExternId);
				ActiveAbility(GetCard(), 1, OwnerCard.unitAbilities.currentActiveExternId);
				//OwnerCard.unitAbilities.currentActiveExternId = -1;
			}
			else
			{
				OnCancel(OwnerCard);
				Game.bCardMenuJustClosed = true;
				Game.bEffectOnGoing = false;
				Game.bBlockDriveCheck = false;
				Game.bBlockMouseOnce = true;
				/*
				if(Game.bAttacking)
				{
					Game.bConfirmAttack = true;
				}
				*/

			}
			Game.LastPPAnswer = 0;	
			bWindowActive = false;

			if(OwnerCard.unitAbilities.currentActiveExternId != -1)
			{
				ExternEffects[OwnerCard.unitAbilities.currentActiveExternId].bWindowActive = false;
			}

			if(_UnitObject != null)
			{
				_UnitObject.bWindowActive = false;	
			}
		}
	} 
	
	public bool AcceptInput()
	{
		return Input.GetMouseButtonUp(0);	
	}
}

public class DummyExternEffect : UnitObject {
	
}