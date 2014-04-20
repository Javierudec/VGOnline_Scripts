using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardDataBase
{
	private List<CardInformation> Card;
	
	public CardDataBase ()
	{
		Card = new List<CardInformation> ();
		
		Card.Add (new CardInformation (0, //Grade
			                          TriggerIcon.CRITICAL, //Trigger
									  SkillIcon.BOOST, //Skill
									  10000, //Shield
									  "Bringer of Good Luck, Epona", //Name
									  "Sylph", //Race
									  "Royal Paladin", //Clan
			                          1, //Critical
			                          5000, //Power
									  "n630", //Material
			                          CardIdentifier.BRINGER_OF_GOOD_LUCK_EPONA
									  ));	
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Knight of Conviction, Bors",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          10000, 
									  "n688", 
									  CardIdentifier.KNIGHT_OF_CONVICTION_BORS
			                          ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Blaster Blade",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          9000, 
									  "n664",
									  CardIdentifier.BLASTER_BLADE
			                          ));

		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Solitary Knight, Gancelot",
									  "Elf", 
									  "Royal Paladin", 
			                          1, 
			                          9000, 
									  "n693", 
			                          CardIdentifier.SOLITARY_KNIGHT_GANCELOT
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Knight of the Harp, Tristan",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          8000, 
									  "n674",
									  CardIdentifier.KNIGHT_OF_THE_HARP_TRISTAN
			                          ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Wingal",
									  "High Beast", 
									  "Royal Paladin", 
			                          1, 
			                          6000, 
									  "n661",
									  CardIdentifier.WINGAL
			                          ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Starlight Unicorn",
									  "High Beast", 
									  "Royal Paladin", 
			                          1, 
			                          6000, 
									  "n659",
								      CardIdentifier.STARLIGHT_UNICORN
			                          ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Little Sage, Maron",
									  "Giant", 
									  "Royal Paladin", 
			                          1, 
			                          8000, 
									  "n653",
			                          CardIdentifier.LITTLE_SAGE_MARON
			                          ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.HEAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Yggdrasil Maiden, Elaine",
									  "Elf", 
									  "Royal Paladin", 
			                          1, 
			                          5000, 
									  "n642",
			                          CardIdentifier.YGGDRASIL_MAIDEN_ELAINE
			                          ));

		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Stardust Trumpeter",
									  "Angel", 
									  "Royal Paladin", 
			                          1, 
			                          6000, 
									  "n639",
									  CardIdentifier.STARDUST_TRUMPETER
			                          ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Knight of Rose, Morgana",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          6000, 
									  "n649",
									  CardIdentifier.KNIGHT_OF_ROSE_MORGANA
			                          ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Crimson Butterfly, Brigitte",
									  "Salamander", 
									  "Royal Paladin", 
			                          1, 
			                          10000, 
									  "n681",
			                          CardIdentifier.CRIMSON_BUTTERFLY_BRIGITTE
			                          ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Convenant Knight, Randolf",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          8000, 
									  "n666",
									  CardIdentifier.COVENANT_KNIGHT_RANDOLF
			                          ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Knight of Silence, Gallatin",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          10000, 
									  "n675",
									  CardIdentifier.KNIGHT_OF_SILENCE_GALLATIN
			                          ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.STAND, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Flogal",
									  "High Beast", 
									  "Royal Paladin", 
			                          1, 
			                          5000, 
									  "n632",
			                          CardIdentifier.FLOGAL
			                          ));

		Card.Add (new CardInformation (0, 
			                          TriggerIcon.DRAW, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Weapons Dealer, Govannon",
									  "Gnome", 
									  "Royal Paladin", 
			                          1, 
			                          5000, 
									  "n640",
			                          CardIdentifier.WEAPONS_DEALER_GOVANNON
			                          ));

		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Dragonic Overlord",
									  "Flame Dragon", 
									  "Kagero", 
			                          1, 
			                          11000, 
									  "kagero001",
			                          CardIdentifier.DRAGONIC_OVERLORD
			                          ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Dragon Monk, Goku",
									  "Warbeast", 
									  "Kagero", 
			                          1, 
			                          10000, 
									  "kagero002",
			                          CardIdentifier.DRAGON_MONK_GOKU
			                          ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Demonic Dragon Berserker, Yaksha",
									  "Dragonman", 
									  "Kagero", 
			                          1, 
			                          9000, 
									  "kagero003",
			                          CardIdentifier.DEMONIC_DRAGON_BERSERKER_YAKSHA
			                          ));

		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Dragon Knight, Nehalem",
									  "Human", 
									  "Kagero", 
			                          1, 
			                          10000, 
									  "kagero004",
			                          CardIdentifier.DRAGON_KNIGHT_NEHALEM
			                          ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Berserk Dragon",
									  "Flame Dragon", 
									  "Kagero", 
			                          1, 
			                          9000, 
									  "kagero005",
			                          CardIdentifier.BERSERK_DRAGON
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Wyvern Strike, Tejas",
									  "Winged Dragon", 
									  "Kagero", 
			                          1, 
			                          8000, 
									  "kagero006",
			                          CardIdentifier.WYVERN_STRIKE_TEJAS
									  ));

		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Embodiment of Armor, Bahr",
									  "Demon", 
									  "Kagero", 
			                          1, 
			                          8000, 
									  "kagero007",
			                          CardIdentifier.EMBODIMENT_OF_ARMOR_BAHR
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Dragon Monk, Gojo",
									  "Gillman", 
									  "Kagero", 
			                          1, 
			                          7000, 
									  "kagero008",
			                          CardIdentifier.DRAGON_MONK_GOJO
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Flame of Hope, Aermo",
									  "Salamander", 
									  "Kagero", 
			                          1, 
			                          6000, 
									  "kagero009",
			                          CardIdentifier.FLAME_OF_HOPE_AERMO
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Demonic Dragon Madonna, Joka",
									  "Dragonman", 
									  "Kagero", 
			                          1, 
			                          6000, 
									  "kagero010",
			                          CardIdentifier.DEMONIC_DRAGON_MADONNA_JOKA
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Wyvern Strike, Jarran",
									  "Winged Dragon", 
									  "Kagero", 
			                          1, 
			                          6000, 
									  "kagero011",
			                          CardIdentifier.WYVERN_STRIKE_JARRAN
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Lizard Runner, Undeux",
									  "Dragonman", 
									  "Kagero", 
			                          1, 
			                          6000, 
									  "kagero012",
			                          CardIdentifier.LIZARD_RUNNER_UNDEUX
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.DRAW, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Dragon Dancer, Monica",
									  "Human", 
									  "Kagero", 
			                          1, 
			                          5000, 
									  "kagero013",
			                          CardIdentifier.DRAGON_DANCER_MONICA
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.STAND, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Lizard Soldier, Ganlu",
									  "Dragonman", 
									  "Kagero", 
			                          1, 
			                          5000, 
									  "kagero014",
			                          CardIdentifier.LIZARD_SOLDIER_GANLU
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.HEAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Dragon Monk, Genjo",
									  "Human", 
									  "Kagero", 
			                          1, 
			                          5000, 
									  "kagero015",
			                          CardIdentifier.DRAGON_MONK_GENJO
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Demonic Dragon Mage, Rakshasa",
									  "Dragonman", 
									  "Kagero", 
			                          1, 
			                          3000, 
									  "kagero016",
			                          CardIdentifier.DEMONIC_DRAGON_MAGE_RAKSHASA
									  ));

		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Gold Rutile",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          10000, 
									  "NovaGrappler001",
			                          CardIdentifier.GOLD_RUTILE
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Death Metal Droid",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          10000, 
									  "NovaGrappler002",
			                          CardIdentifier.DEATH_METAL_DROID
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Mr. Invincible",
									  "Dragonman", 
									  "Nova Grappler", 
			                          1, 
			                          10000, 
									  "NovaGrappler003",
			                          CardIdentifier.MR_INVINCIBLE
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "King of Sword",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          10000, 
									  "NovaGrappler004",
			                          CardIdentifier.KING_OF_SWORD
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Super Electromagnetic Lifeform, Storm",
									  "Alien", 
									  "Nova Grappler", 
			                          1, 
			                          9000, 
									  "NovaGrappler005",
			                          CardIdentifier.SUPER_ELECTROMAGNETIC_LIFEFORM_STORM
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "NGM Prototype",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          8000, 
									  "NovaGrappler006",
			                          CardIdentifier.NGM_PROTOTYPE
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Tough Boy",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          8000, 
									  "NovaGrappler007",
			                          CardIdentifier.TOUGH_BOY
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Oasis Girl",
									  "Workeroid", 
									  "Nova Grappler", 
			                          1, 
			                          7000, 
									  "NovaGrappler008",
			                          CardIdentifier.OASIS_GIRL
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Screamin' and Dancin' Announcer, Shout",
									  "Alien", 
									  "Nova Grappler", 
			                          1, 
			                          7000, 
									  "NovaGrappler009",
			                          CardIdentifier.SCREAMIN_AND_DANCIN_ANNOUNCER_SHOUT
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Queen of Heart",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          6000, 
									  "NovaGrappler010",
			                          CardIdentifier.QUEEN_OF_HEART
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Shining Lady",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          5000, 
									  "NovaGrappler011",
			                          CardIdentifier.SHINING_LADY
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Battering Minotaur",
									  "Warbeast", 
									  "Nova Grappler", 
			                          1, 
			                          6000, 
									  "NovaGrappler012",
			                          CardIdentifier.BATTERING_MINOTAUR
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.STAND, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Cannon Ball",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          5000, 
									  "NovaGrappler013",
			                          CardIdentifier.CANNON_BALL
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.HEAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Ring Girl, Clara",
									  "Workeroid", 
									  "Nova Grappler", 
			                          1, 
			                          5000, 
									  "NovaGrappler014",
			                          CardIdentifier.RING_GIRL_CLARA
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.STAND, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Battleraizer",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          3000, 
									  "NovaGrappler015",
			                          CardIdentifier.BATTLERAIZER
									  ));

		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "King of Knights, Alfred",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          10000, 
									  "Royal001",
			                          CardIdentifier.KING_OF_KNIGHTS_ALFRED
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Barcgal",
									  "Hight Beast", 
									  "Royal Paladin", 
			                          1, 
			                          4000, 
									  "Royal002",
			                          CardIdentifier.BARCGAL
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Embodiment of Spear, Tahr",
									  "Demon", 
									  "Kagero", 
			                          1, 
			                          5000, 
									  "kagero017",
			                          CardIdentifier.EMBODIMENT_OF_SPEAR_THAR
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Dragon Knight, Aleph",
									  "Human", 
									  "Kagero", 
			                          1, 
			                          9000, 
									  "kagero018",
			                          CardIdentifier.DRAGON_KNIGHT_ALEPH
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Embodiment of Victory, Aleph",
									  "Demon", 
									  "Kagero", 
			                          1, 
			                          10000, 
									  "kagero019",
			                          CardIdentifier.EMBODIMENT_OF_VICTORY_ALEPH
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "CEO Amaterasu",
									  "Noble", 
									  "Oracle Think Tank", 
			                          1, 
			                          10000, 
									  "OracleThinkTank001",
			                          CardIdentifier.CEO_AMATERASU
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Battle Sister, Cocoa",
									  "Elf", 
									  "Oracle Think Tank", 
			                          1, 
			                          6000, 
									  "OracleThinkTank002",
			                          CardIdentifier.BATTLE_SISTER_COCOA
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Oracle Guardian, Apollon",
									  "Battleroid", 
									  "Oracle Think Tank", 
			                          1, 
			                          10000, 
									  "OracleThinkTank003",
			                          CardIdentifier.ORACLE_GUARDIAN_APOLLON
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  0, 
									  "Battle Sister, Chocolat",
									  "Elf", 
									  "Oracle Think Tank", 
			                          1, 
			                          6000, 
									  "OracleThinkTank004",
			                          CardIdentifier.BATTLE_SISTER_CHOCOLAT
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Oracle Guardian, Gemini",
									  "Battleroid", 
									  "Oracle Think Tank", 
			                          1, 
			                          8000, 
									  "OracleThinkTank005",
			                          CardIdentifier.ORACLE_GUARDIAN_GEMINI
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Maiden of Libra",
									  "Angel", 
									  "Oracle Think Tank", 
			                          1, 
			                          9000, 
									  "OracleThinkTank006",
			                          CardIdentifier.MAIDEN_OF_LIBRA
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Battle Sister, Mocha",
									  "Human", 
									  "Oracle Think Tank", 
			                          1, 
			                          8000, 
									  "OracleThinkTank007",
			                          CardIdentifier.BATTLE_SISTER_MOCHA
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.DRAW, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Dream Eater",
									  "High Beast", 
									  "Oracle Think Tank", 
			                          1, 
			                          5000, 
									  "OracleThinkTank008",
			                          CardIdentifier.DREAM_EATER
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Oracle Guardian, Nike",
									  "Battleroid", 
									  "Oracle Think Tank", 
			                          1, 
			                          5000, 
									  "OracleThinkTank009",
			                          CardIdentifier.ORACLE_GUARDIAN_NIKE
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.DRAW, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Miracle Kid",
									  "High Beast", 
									  "Oracle Think Tank", 
			                          1, 
			                          5000, 
									  "OracleThinkTank010",
			                          CardIdentifier.MIRACLE_KID
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Weather Girl, Milk",
									  "Sylph", 
									  "Oracle Think Tank", 
			                          1, 
			                          6000, 
									  "OracleThinkTank011",
			                          CardIdentifier.WEATHER_GIRL_MILK
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.HEAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Lozenge Magus",
									  "Elf", 
									  "Oracle Think Tank", 
			                          1, 
			                          3000, 
									  "OracleThinkTank012",
			                          CardIdentifier.LOZENGE_MAGUS
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Oracle Guardian, Wiseman",
									  "Battleroid", 
									  "Oracle Think Tank", 
			                          1, 
			                          10000, 
									  "OracleThinkTank013",
			                          CardIdentifier.ORACLE_GUARDIAN_WISEMAN
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Asura Kaiser",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          11000, 
									  "NovaGrappler016",
			                          CardIdentifier.ASURA_KAISER
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Demon Slaying Knight, Lohengrin",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          10000, 
									  "Royal003",
			                          CardIdentifier.DEMON_SLAYING_KNIGHT_LOHENGRIM
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  0, 
									  "Flash Shield, Iseult",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          6000, 
									  "Royal004",
			                          CardIdentifier.FLASH_SHIELD_ISEULT
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Future Knight, Llew",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          4000, 
									  "Royal005",
			                          CardIdentifier.FUTURE_KNIGHT_LLEW
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Vortex Dragon",
									  "Flame Dragon", 
									  "Kagero", 
			                          1, 
			                          10000, 
									  "Kagero020",
			                          CardIdentifier.VORTEX_DRAGON
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  0, 
									  "Wyvern Guard, Barri",
									  "Dragonman", 
									  "Kagero", 
			                          1, 
			                          6000, 
									  "Kagero021",
			                          CardIdentifier.WYVERN_GUARD_BARRI
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Lizard Soldier, Conroe",
									  "Dragonman", 
									  "Kagero", 
			                          1, 
			                          5000, 
									  "Kagero022",
			                          CardIdentifier.LIZARD_SOLIDER_CONROE
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Juggernaut Maximum",
									  "Giant", 
									  "Spike Brothers", 
			                          1, 
			                          11000, 
									  "SpikeBrothers001",
			                          CardIdentifier.JUGGERNAUT_MAXIMUM
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Brutal Jack",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          11000, 
									  "NovaGrappler017",
			                          CardIdentifier.BRUTAL_JACK
		));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Tyrant, Deathrex",
									  "Dinodragon", 
									  "Tachikaze", 
			                          1, 
			                          10000, 
									  "Tachikaze001",
			                          CardIdentifier.TYRANT_DEATHREX
		));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Assault Dragon, Blightops",
									  "Dinodragon", 
									  "Tachikaze", 
			                          1, 
			                          9000, 
									  "Tachikaze002",
			                          CardIdentifier.ASSAULT_DRAGON_BLIGHTOPS
		));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Stealth Dragon, Voidmaster",
									  "Shadow Dragon", 
									  "Nubatama", 
			                          1, 
			                          9000, 
									  "Nubatama001",
			                          CardIdentifier.STEALTH_DRAGON_VOIDMASTER
		));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Demon Eater",
									  "Elf", 
									  "Dark Irregulars", 
			                          1, 
			                          10000, 
									  "DarkIrregulars001",
			                          CardIdentifier.DEMON_EATER
		));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Monster Frank",
									  "Workeroid", 
									  "Granblue", 
			                          1, 
			                          10000, 
									  "Granblue001",
			                          CardIdentifier.MONSTER_FRANK
		));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Commodore Blueblood",
									  "Vampire", 
									  "Granblue", 
			                          1, 
			                          10000, 
									  "Granblue002",
			                          CardIdentifier.COMMODORE_BLUEBLOOD
		));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Hell Spider",
									  "Insect", 
									  "Megacolony", 
			                          1, 
			                          10000, 
									  "Megacolony001",
			                          CardIdentifier.HELL_SPIDER
		));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Bloody Hercules",
									  "Insect", 
									  "Megacolony", 
			                          1, 
			                          10000, 
									  "Megacolony002",
			                          CardIdentifier.BLOODY_HERCULES
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Clay-doll Mechanic",
									  "Alien", 
									  "Nova Grappler", 
			                          1, 
			                          7000, 
									  "NovaGrappler018",
			                          CardIdentifier.CLAY_DOLL_MECHANIC
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.STAND, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Lucky Girl",
									  "High Beast", 
									  "Nova Grappler", 
			                          1, 
			                          5000, 
									  "NovaGrappler019",
			                          CardIdentifier.LUCKY_GIRL
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Sonic Noa",
									  "Dinodragon", 
									  "Tachikaze", 
			                          1, 
			                          8000, 
									  "Tachikaze003",
			                          CardIdentifier.SONIC_NOA
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Ironclad Dragon, Shieldon",
									  "Dinodragon", 
									  "Tachikaze", 
			                          1, 
			                          6000, 
									  "Tachikaze004",
			                          CardIdentifier.IRONCLAD_DRAGON_SHIELDON
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Stealth Beast, Chigasumi",
									  "Warbeast", 
									  "Nubatama", 
			                          1, 
			                          8000, 
									  "Nubatama002",
			                          CardIdentifier.STEALTH_BEAST_CHIGASUMI
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Stealth Dragon, Dreadmaster",
									  "Shadow Dragon", 
									  "Nubatama", 
			                          1, 
			                          7000, 
									  "Nubatama003",
			                          CardIdentifier.STEALTH_DRAGON_DREADMASTER
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Stealth Beast, Hagakure",
									  "Warbeast", 
									  "Nubatama", 
			                          1, 
			                          5000, 
									  "Nubatama004",
			                          CardIdentifier.STEALTH_BEAST_HAGAKURE
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Blue Dust",
									  "Human", 
									  "Dark Irregulars", 
			                          1, 
			                          9000, 
									  "DarkIrregulars002",
			                          CardIdentifier.BLUE_DUST
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Nightmare Baby",
									  "Demon", 
									  "Dark Irregulars", 
			                          1, 
			                          6000, 
									  "DarkIrregulars003",
			                          CardIdentifier.NIGHTMARE_BABY
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Rock the Wall",
									  "Ogre", 
									  "Dark Irregulars", 
			                          1, 
			                          5000, 
									  "DarkIrregulars004",
			                          CardIdentifier.ROCK_THE_WALL
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Highspeed, Brakki",
									  "Warbeast", 
									  "Spike Brothers", 
			                          1, 
			                          9000, 
									  "SpikeBrothers002",
			                          CardIdentifier.HIGHSPEED_BRAKKI
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Wonder Boy",
									  "Goblin", 
									  "Spike Brothers", 
			                          1, 
			                          8000, 
									  "SpikeBrothers003",
			                          CardIdentifier.WONDER_BOY
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Redshoe, Milly",
									  "Succubus", 
									  "Spike Brothers", 
			                          1, 
			                          5000, 
									  "SpikeBrothers004",
			                          CardIdentifier.REDSHOE_MILLY
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Dandy Guy, Romario",
									  "Zombie", 
									  "Granblue", 
			                          1, 
			                          8000, 
									  "Granblue003",
			                          CardIdentifier.DANDY_GUY_ROMARIO
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Guiding Zombie",
									  "Zombie", 
									  "Granblue", 
			                          1, 
			                          5000, 
									  "Granblue004",
			                          CardIdentifier.GUIDING_ZOMBIE
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Karma Queen",
									  "Insect", 
									  "Megacolony", 
			                          1, 
			                          7000, 
									  "Megacolony003",
			                          CardIdentifier.KARMA_QUEEN
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Madame Mirage",
									  "Insect", 
									  "Megacolony", 
			                          1, 
			                          6000, 
									  "Megacolony004",
			                          CardIdentifier.MADAME_MIRAGE
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Lake Maiden, Lien",
									  "Elf", 
									  "Royal Paladin", 
			                          1, 
			                          7000, 
									  "Royal006",
			                          CardIdentifier.LAKE_MAIDEN_LIEN
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Hungry Dumpty",
									  "Alien", 
									  "Nova Grappler", 
			                          1, 
			                          9000, 
									  "NovaGrappler020",
			                          CardIdentifier.HUNGRY_DUMPTY
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Bermuda Triangle Cadet, Caravel",
									  "Mermaid", 
									  "Bermuda Triangle", 
			                          1, 
			                          3000, 
									  "BermudaTriangle001",
			                          CardIdentifier.BERMUDA_TRIANGLE_CADET_CARAVEL
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Blazer Idols",
									  "Mermaid", 
									  "Bermuda Triangle", 
			                          1, 
			                          6000, 
									  "BermudaTriangle002",
			                          CardIdentifier.BLAZER_IDOLS
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Top Idol, Aqua",
									  "Mermaid", 
									  "Bermuda Triangle", 
			                          1, 
			                          10000, 
									  "BermudaTriangle003",
			                          CardIdentifier.TOP_IDOL_AQUA
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  0, 
									  "Top Idol, Flores",
									  "Mermaid", 
									  "Bermuda Triangle", 
			                          1, 
			                          10000, 
									  "BermudaTriangle004",
			                          CardIdentifier.TOP_IDOL_FLORES
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  0, 
									  "Gust Jinn",
									  "Demon", 
									  "Granblue", 
			                          1, 
			                          6000, 
									  "Granblue005",
			                          CardIdentifier.GUST_JINN
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Spirit Exceed",
									  "Ghost", 
									  "Granblue", 
			                          1, 
			                          10000, 
									  "Granblue006",
			                          CardIdentifier.SPIRIT_EXCEED
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "King of Demoniac Seas, Basskirk",
									  "Gillman", 
									  "Granblue", 
			                          1, 
			                          10000, 
									  "Granblue007",
			                          CardIdentifier.KING_OF_DEMONIC_SEAS_BASSKIRK
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Rough Seas Banshee",
									  "Ghost", 
									  "Granblue", 
			                          1, 
			                          4000, 
									  "Granblue008",
			                          CardIdentifier.ROUGH_SEAS_BANSHEE
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Evil Shade",
									  "Ghost", 
									  "Granblue", 
			                          1, 
			                          6000, 
									  "Granblue009",
			                          CardIdentifier.EVIL_SHADE
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.STAND, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Skeleton Lookout",
									  "Skeleton", 
									  "Granblue", 
			                          1, 
			                          5000, 
									  "Granblue010",
			                          CardIdentifier.SKELETON_LOOKOUT
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Knight Spirit",
									  "Ghost", 
									  "Granblue", 
			                          1, 
			                          5000, 
									  "Granblue011",
			                          CardIdentifier.KNIGHT_SPIRIT
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Skeleton Swordsman",
									  "Skeleton", 
									  "Granblue", 
			                          1, 
			                          8000, 
									  "Granblue012",
			                          CardIdentifier.SKELETON_SWORDSMAN
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Ruin Shade",
									  "Ghost", 
									  "Granblue", 
			                          1, 
			                          9000, 
									  "Granblue013",
			                          CardIdentifier.RUIN_SHADE
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.HEAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Rock the Ghostie",
									  "Ghost", 
									  "Granblue", 
			                          1, 
			                          5000, 
									  "Granblue014",
			                          CardIdentifier.RICK_THE_GHOSTIE
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Samurai Spirit",
									  "Ghost", 
									  "Granblue", 
			                          1, 
			                          7000, 
									  "Granblue015",
			                          CardIdentifier.SAMURAI_SPIRIT
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Witch Doctor of the Abyss, Negromarl",
									  "Demon", 
									  "Granblue", 
			                          1, 
			                          8000, 
									  "Granblue016",
			                          CardIdentifier.WITCH_DOCTOR_OF_THE_ABYSS_NEGROMARL
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Captain Nightmist",
									  "Vampire", 
									  "Granblue", 
			                          1, 
			                          8000, 
									  "Granblue017",
			                          CardIdentifier.CAPTAIN_NIGHTMIST
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Dancing Cutlass",
									  "Ghost", 
									  "Granblue", 
			                          1, 
			                          5000, 
									  "Granblue018",
			                          CardIdentifier.DANCING_CUTLASS
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Chappie the Ghostie",
									  "Ghost", 
									  "Granblue", 
			                          1, 
			                          5000, 
									  "Granblue019",
			                          CardIdentifier.CHAPPIE_THE_GHOSTIE
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Sky Diver",
									  "Workeroid", 
									  "Spike Brothers", 
			                          1, 
			                          11000, 
									  "SpikeBrothers005",
			                          CardIdentifier.SKY_DIVER
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Panzer Gale",
									  "Ogre", 
									  "Spike Brothers", 
			                          1, 
			                          8000, 
									  "SpikeBrothers006",
			                          CardIdentifier.PANZER_GALE
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Sonic Breaker",
									  "Ogre", 
									  "Spike Brothers", 
			                          1, 
			                          5000, 
									  "SpikeBrothers007",
			                          CardIdentifier.SONIC_BREAKER
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.DRAW, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Cheerful Lynx",
									  "Warbeast", 
									  "Spike Brothers", 
			                          1, 
			                          5000, 
									  "SpikeBrothers008",
			                          CardIdentifier.CHEERFUL_LYNX
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  10000, 
									  "Unite Attacker",
									  "Ogre", 
									  "Spike Brothers", 
			                          1, 
			                          10000, 
									  "SpikeBrothers009",
			                          CardIdentifier.UNITE_ATTACKER
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Silence Joker",
									  "Ghost", 
									  "Spike Brothers", 
			                          1, 
			                          4000, 
									  "SpikeBrothers010",
			                          CardIdentifier.SILENCE_JOKER
							 	      ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Mecha Trainer",
									  "Workeroid", 
									  "Spike Brothers", 
			                          1, 
			                          5000, 
									  "SpikeBrothers011",
			                          CardIdentifier.MECHA_TRAINER
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Spike Brothers Assault Squad",
									  "Goblin", 
									  "Spike Brothers", 
			                          1, 
			                          4000, 
									  "SpikeBrothers012",
			                          CardIdentifier.SPIKE_BROTHERS_ASSAULT_SQUAD
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Dudley Dan",
									  "Ogre", 
									  "Spike Brothers", 
			                          1, 
			                          4000, 
									  "SpikeBrothers013",
			                          CardIdentifier.DUDLEY_DAN
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.HEAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Cheer Girl, Tiara",
									  "Workeroid", 
									  "Spike Brothers", 
			                          1, 
			                          5000, 
									  "SpikeBrothers014",
			                          CardIdentifier.CHEER_GIRL_TIARA
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Cyclone Blitz",
									  "Ogre", 
									  "Spike Brothers", 
			                          1, 
			                          6000, 
									  "SpikeBrothers015",
			                          CardIdentifier.CYCLONE_BLITZ
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "General Seifried",
									  "Demon", 
									  "Spike Brothers", 
			                          1, 
			                          10000, 
									  "SpikeBrothers016",
			                          CardIdentifier.GENERAL_SEIFRIED
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  0, 
									  "Cheer Girl, Marilyn",
									  "Succubus", 
									  "Spike Brothers", 
			                          1, 
			                          6000, 
									  "SpikeBrothers017",
			                          CardIdentifier.CHEER_GIRL_MARILYN
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Devil Summoner",
									  "Demon", 
									  "Spike Brothers", 
			                          1, 
			                          7000, 
									  "SpikeBrothers018",
			                          CardIdentifier.DEVIL_SUMMONER
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Treasured, Black Panther",
									  "Workeroid", 
									  "Spike Brothers", 
			                          1, 
			                          10000, 
									  "SpikeBrothers019",
			                          CardIdentifier.TREASURED_BLACK_PANTHER
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Young Pegasus Knight",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          6000, 
									  "Royal007",
			                          CardIdentifier.YOUNG_PEGASUS_KNIGHT
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "High Dog Breeder, Akane",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          8000, 
									  "Royal008",
			                          CardIdentifier.HIGH_DOG_BREEDER_AKANE
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Soul Guiding Elf",
									  "Elf", 
									  "Royal Paladin", 
			                          1, 
			                          7000, 
									  "Royal009",
			                          CardIdentifier.SOUL_GUIDING_ELF
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.DRAW, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Margal",
									  "High Beast", 
									  "Royal Paladin", 
			                          1, 
			                          4000, 
									  "Royal010",
			                          CardIdentifier.MARGAL
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.STAND, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Pixy Fife and Drum",
									  "Sylph", 
									  "Royal Paladin", 
			                          1, 
			                          5000, 
									  "Royal011",
			                          CardIdentifier.PIXY_FIFE_AND_DRUM
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Soul Saver Dragon",
									  "Workeroid", 
									  "Royal Paladin", 
			                          1, 
			                          10000, 
									  "Royal012",
			                          CardIdentifier.SOUL_SAVER_DRAGON
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Knight of Truth, Gordon",
									  "Human", 
									  "Royal Paladin", 
			                          1, 
			                          8000, 
									  "Royal013",
			                          CardIdentifier.KNIGHT_OF_TRUTH_GORDON
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Pongal",
									  "High Beast", 
									  "Royal Paladin", 
			                          1, 
			                          7000, 
									  "Royal014",
			                          CardIdentifier.PONGAL
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Great Sage, Barron",
									  "Giant", 
									  "Royal Paladin", 
			                          1, 
			                          8000, 
									  "Royal015",
			                          CardIdentifier.GREAT_SAGE_BARRON
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Gigantech Charger",
									  "Giant", 
									  "Royal Paladin", 
			                          1, 
			                          9000, 
									  "Royal016",
			                          CardIdentifier.GIGANTECH_CHARGER
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Seal Dragon, Blockade",
									  "Flame Dragon", 
									  "Kagero", 
			                          1, 
			                          10000, 
									  "kagero023",
			                          CardIdentifier.SEAL_DRAGON_BLOCKADE
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Blazing Core Dragon",
									  "Flame Dragon", 
									  "Kagero", 
			                          1, 
			                          9000, 
									  "kagero024",
			                          CardIdentifier.BLAZING_CORE_DRAGON
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Chain-Attack Sutherland",
									  "Human", 
									  "Kagero", 
			                          1, 
			                          8000, 
									  "kagero025",
			                          CardIdentifier.CHAIN_ATTACK_SUTHERLAND
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Demonic Dragon Mage, Kimnara",
									  "Dragonman", 
									  "Kagero", 
			                          1, 
			                          6000, 
									  "kagero026",
			                          CardIdentifier.DEMONIC_DRAGON_MAGE_KIMNARA
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.STAND, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Lizard Runner, Nald",
									  "Dragonman", 
									  "Kagero", 
			                          1, 
			                          5000, 
									  "kagero027",
			                          CardIdentifier.LIZARD_RUNNER_NALD
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Dragon Knight, Berger",
									  "Human", 
									  "Kagero", 
			                          1, 
			                          8000, 
									  "kagero028",
			                          CardIdentifier.DRAGON_KNIGHT_BERGER
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Blazing Flare Dragon",
									  "Flame Dragon", 
									  "Kagero", 
			                          1, 
			                          10000, 
									  "kagero029",
			                          CardIdentifier.BLAZING_FLARE_DRAGON
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.DRAW, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Gattling Claw Dragon",
									  "Flame Dragon", 
									  "Kagero", 
			                          1, 
			                          4000, 
									  "kagero030",
			                          CardIdentifier.GATTLING_CLAW_DRAGON
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Follower_Reas",
									  "Human", 
									  "Kagero", 
			                          1, 
			                          6000, 
									  "kagero031",
			                          CardIdentifier.FOLLOWER_REAS
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Iron Tail Dragon",
									  "Flame Dragon", 
									  "Kagero", 
			                          1, 
			                          7000, 
									  "kagero032",
			                          CardIdentifier.IRON_TAIL_DRAGON
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Silent Tom",
									  "Ghost", 
									  "Oracle Think Tank", 
			                          1, 
			                          8000, 
									  "OracleThinkTank014",
			                          CardIdentifier.SILENT_TOM
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Luck Bird",
									  "High Beast", 
									  "Oracle Think Tank", 
			                          1, 
			                          5000, 
									  "OracleThinkTank015",
			                          CardIdentifier.LUCK_BIRD
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Scarlet Witch, CoCo",
									  "Human", 
									  "Oracle Think Tank", 
			                          1, 
			                          10000, 
									  "OracleThinkTank016",
			                          CardIdentifier.SCARLET_WITCH_COCO
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Psychic Bird",
									  "High Beast", 
									  "Oracle Think Tank", 
			                          1, 
			                          4000, 
									  "OracleThinkTank017",
			                          CardIdentifier.PSYCHIC_BIRD
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.STAND, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Emergency Alarmer",
									  "Workeroid", 
									  "Oracle Think Tank", 
			                          1, 
			                          5000, 
									  "OracleThinkTank018",
			                          CardIdentifier.EMERGENCY_ALARMER
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Security Guardian",
									  "Battleroid", 
									  "Oracle Think Tank", 
			                          1, 
			                          8000, 
									  "OracleThinkTank019",
			                          CardIdentifier.SECURITY_GUARDIAN
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "One Who Gazes at the Truth",
									  "Human", 
									  "Oracle Think Tank", 
			                          1, 
			                          6000, 
									  "OracleThinkTank020",
			                          CardIdentifier.ONE_WHO_GAZES_AT_THE_TRUTH
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Winged Dragon, Skyptero",
									  "Dinodragon", 
									  "Tachikaze", 
			                          1, 
			                          6000, 
									  "Tachikaze005",
			                          CardIdentifier.WINGED_DRAGON_SKYPTERO
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Dragon Egg",
									  "Dinodragon", 
									  "Tachikaze", 
			                          1, 
			                          4000, 
									  "Tachikaze006",
			                          CardIdentifier.DRAGON_EGG
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Cannon Fire Dragon, Cannon Gear",
									  "Dinodragon", 
									  "Tachikaze", 
			                          1, 
			                          11000, 
									  "Tachikaze007",
			                          CardIdentifier.CANNON_FIRE_DRAGON_CANNON_GEAR
									  ));

		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Cannon Fire Dragon, Cannon Gear",
									  "Dinodragon", 
									  "Tachikaze", 
			                          1, 
			                          11000, 
									  "Tachikaze007",
			                          CardIdentifier.CANNON_FIRE_DRAGON_CANNON_GEAR
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Lion Heat",
									  "Warbeast", 
									  "Nova Grappler", 
			                          1, 
			                          10000, 
									  "NovaGrappler021",
			                          CardIdentifier.LION_HEAT
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  0, 
									  "Twin Blader",
									  "Battleroid", 
									  "Nova Grappler", 
			                          1, 
			                          6000, 
									  "NovaGrappler022",
			                          CardIdentifier.TWIN_BLADER
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Magician Girl, Kirara",
									  "Workeroid", 
									  "Nova Grappler", 
			                          1, 
			                          9000, 
									  "NovaGrappler023",
			                          CardIdentifier.MAGICIAN_GIRL_KIRARA
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.CRITICAL, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Red Lighting",
									  "Alien", 
									  "Nova Grappler", 
			                          1, 
			                          4000, 
									  "NovaGrappler024",
			                          CardIdentifier.RED_LIGHTING
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.DRAW, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Three Minutes",
									  "Human", 
									  "Nova Grappler", 
			                          1, 
			                          5000, 
									  "NovaGrappler025",
			                          CardIdentifier.THREE_MINUTES
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Cray Soldier",
									  "Alien", 
									  "Nova Grappler", 
			                          1, 
			                          4000, 
									  "NovaGrappler026",
			                          CardIdentifier.CRAY_SOLDIER
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  5000, 
									  "Master Fraudo",
									  "Insect", 
									  "Megacolony", 
			                          1, 
			                          10000, 
									  "Megacolony005",
			                          CardIdentifier.MASTER_FRAUDE
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Lady Bomb",
									  "Insect", 
									  "Megacolony", 
			                          1, 
			                          9000, 
									  "Megacolony006",
			                          CardIdentifier.LADY_BOMB
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Megacolony Battler A",
									  "Alien", 
									  "Megacolony", 
			                          1, 
			                          5000, 
									  "Megacolony007",
			                          CardIdentifier.MEGACOLONY_BUTTLER_A
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Phantom Black",
									  "Insect", 
									  "Megacolony", 
			                          1, 
			                          8000, 
									  "Megacolony008",
			                          CardIdentifier.PHANTOM_BLACK
									  ));
		
		Card.Add (new CardInformation (3, 
			                          TriggerIcon.NONE, 
									  SkillIcon.TWIN_DRIVE, 
									  0, 
									  "Scientist Monkey Rue",
									  "Warbeast", 
									  "Great Nature", 
			                          1, 
			                          10000, 
									  "GreatNature001",
			                          CardIdentifier.SCIENTIST_MONKEY_RUE
									  ));
		
		Card.Add (new CardInformation (2, 
			                          TriggerIcon.NONE, 
									  SkillIcon.INTERCEPT, 
									  5000, 
									  "Geograph Giant",
									  "High Beast", 
									  "Great Nature", 
			                          1, 
			                          10000, 
									  "GreatNature002",
			                          CardIdentifier.GEOGRAPH_GIANT
									  ));
		
		Card.Add (new CardInformation (1, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  5000, 
									  "Silver Wolf",
									  "High Beast", 
									  "Great Nature", 
			                          1, 
			                          8000, 
									  "GreatNature003",
			                          CardIdentifier.SILVER_WOLF
									  ));
		
		Card.Add (new CardInformation (0, 
			                          TriggerIcon.NONE, 
									  SkillIcon.BOOST, 
									  10000, 
									  "Intelli-mouse",
									  "High Beast", 
									  "Great Nature", 
			                          1, 
			                          4000, 
									  "GreatNature004",
			                          CardIdentifier.INTELLI_MOUSE
									  ));
		
		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Herbivorous Dragon, Brutosaurus",
"Dinodragon",
"Tachikaze",
1,
5000,
"Tachikaze018",
CardIdentifier.HERBIVOROUS_DRAGON__BRUTOSAURUS
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Rainbow Magician",
"Elf",
"Pale Moon",
1,
4000,
"PaleMoon017",
CardIdentifier.RAINBOW_MAGICIAN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Vacuum Mammoth",
"High Beast",
"Tachikaze",
1,
9000,
"Tachikaze015",
CardIdentifier.VACUUM_MAMMOTH
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Savage Destroyer",
"Human",
"Tachikaze",
1,
8000,
"Tachikaze016",
CardIdentifier.SAVAGE_DESTROYER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Raging Dragon, Sparksaurus",
"Dinodragon",
"Tachikaze",
1,
5000,
"Tachikaze017",
CardIdentifier.RAGING_DRAGON__SPARKSAURUS
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Spiral Master",
"Gillman",
"Pale Moon",
1,
5000,
"PaleMoon015",
CardIdentifier.SPIRAL_MASTER
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Candy Clown",
"Demon",
"Pale Moon",
1,
5000,
"PaleMoon016",
CardIdentifier.CANDY_CLOWN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dark Metal Bicorn",
"High Beast",
"Pale Moon",
1,
8000,
"PaleMoon013",
CardIdentifier.DARK_METAL_BICORN
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Dynamite Juggler",
"Goblin",
"Pale Moon",
1,
5000,
"PaleMoon014",
CardIdentifier.DYNAMITE_JUGGLER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Elephant Juggler",
"Giant",
"Pale Moon",
1,
9000,
"PaleMoon011",
CardIdentifier.ELEPHANT_JUGGLER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Hungry Clown",
"Ogre",
"Pale Moon",
1,
9000,
"PaleMoon012",
CardIdentifier.HUNGRY_CLOWN
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Blitzritter",
"Elf",
"Dark Irregulars",
1,
5000,
"DarkIrregulars020",
CardIdentifier.BLITZRITTER
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Hades Puppet Master",
"Ghost",
"Dark Irregulars",
1,
5000,
"DarkIrregulars021",
CardIdentifier.HADES_PUPPET_MASTER
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Cursed Doctor",
"Human",
"Dark Irregulars",
1,
5000,
"DarkIrregulars022",
CardIdentifier.CURSED_DOCTOR
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Dark Queen of Nightmareland",
"Human",
"Dark Irregulars",
1,
4000,
"DarkIrregulars023",
CardIdentifier.DARK_QUEEN_OF_NIGHTMARELAND
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Poet of Darkness, Amon",
"Demon",
"Dark Irregulars",
1,
6000,
"DarkIrregulars019",
CardIdentifier.POET_OF_DARKNESS__AMON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Decadent Succubus",
"Succubus",
"Dark Irregulars",
1,
9000,
"DarkIrregulars017",
CardIdentifier.DECADENT_SUCCUBUS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Prisoner Beast",
"Chimera",
"Dark Irregulars",
1,
8000,
"DarkIrregulars018",
CardIdentifier.PRISONER_BEAST
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Death Army Guy",
"Battleroid",
"Nova Grappler",
1,
7000,
"NovaGrappler030",
CardIdentifier.DEATH_ARMY_GUY
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Godhawk, Ichibyoshi",
"High Beast",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank031",
CardIdentifier.GODHAWK__ICHIBYOSHI
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Death Army Lady",
"Battleroid",
"Nova Grappler",
1,
9000,
"NovaGrappler029",
CardIdentifier.DEATH_ARMY_LADY
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Drangal",
"High Beast",
"Royal Paladin",
1,
5000,
"RoyalPaladin026",
CardIdentifier.DRANGAL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Oracle Guardian, Blue Eye",
"Battleroid",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank030",
CardIdentifier.ORACLE_GUARDIAN__BLUE_EYE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Toypugal",
"High Beast",
"Royal Paladin",
1,
6000,
"RoyalPaladin025",
CardIdentifier.TOYPUGAL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Ravenous Dragon, Megarex",
"Dinodragon",
"Tachikaze",
1,
10000,
"Tachikaze013",
CardIdentifier.RAVENOUS_DRAGON__MEGAREX
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Savage Warrior",
"Human",
"Tachikaze",
1,
6000,
"Tachikaze014",
CardIdentifier.SAVAGE_WARRIOR
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Barking Cerberus",
"Chimera",
"Pale Moon",
1,
10000,
"PaleMoon008",
CardIdentifier.BARKING_CERBERUS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Skull Juggler",
"Demon",
"Pale Moon",
1,
7000,
"PaleMoon009",
CardIdentifier.SKULL_JUGGLER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Hades Ringmaster",
"Demon",
"Pale Moon",
1,
5000,
"PaleMoon010",
CardIdentifier.HADES_RINGMASTER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Raging Dragon, Blastsaurus",
"Dinodragon",
"Tachikaze",
1,
9000,
"Tachikaze012",
CardIdentifier.RAGING_DRAGON__BLASTSAURUS
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Vermillion Gatekeeper",
"Demon",
"Dark Irregulars",
1,
5000,
"DarkIrregulars016",
CardIdentifier.VERMILLION_GATEKEEPER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Barking Manticore",
"Chimera",
"Pale Moon",
1,
10000,
"PaleMoon007",
CardIdentifier.BARKING_MANTICORE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Alluring Succubus",
"Succubus",
"Dark Irregulars",
1,
7000,
"DarkIrregulars015",
CardIdentifier.ALLURING_SUCCUBUS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Werwolf Sieger",
"Warbeast",
"Dark Irregulars",
1,
10000,
"DarkIrregulars013",
CardIdentifier.WERWOLF_SIEGER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Demon of Aspiration, Amon",
"Demon",
"Dark Irregulars",
1,
8000,
"DarkIrregulars014",
CardIdentifier.DEMON_OF_ASPIRATION__AMON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Imprisoned Fallen Angel, Saraqael",
"Angel",
"Dark Irregulars",
1,
11000,
"DarkIrregulars012",
CardIdentifier.IMPRISONED_FALLEN_ANGEL__SARAQAEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Super Dimensional Robo, Daiyusha",
"Battleroid",
"Dimension Police",
1,
10000,
"DimensionPolice004",
CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAIYUSHA
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dual Axe Archdragon",
"Flame Dragon",
"Kagero",
1,
10000,
"Kagero036",
CardIdentifier.DUAL_AXE_ARCHDRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Knight of Godly Speed, Galahad",
"Human",
"Royal Paladin",
1,
11000,
"RoyalPaladin024",
CardIdentifier.KNIGHT_OF_GODLY_SPEED__GALAHAD
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Archbird",
"High Beast",
"Tachikaze",
1,
6000,
"Tachikaze011",
CardIdentifier.ARCHBIRD
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Hades Hypnotist",
"Demon",
"Pale Moon",
1,
6000,
"PaleMoon006",
CardIdentifier.HADES_HYPNOTIST
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Crimson Beast Tamer",
"Elf",
"Pale Moon",
1,
8000,
"PaleMoon004",
CardIdentifier.CRIMSON_BEAST_TAMER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Mirror Demon",
"Demon",
"Pale Moon",
1,
8000,
"PaleMoon005",
CardIdentifier.MIRROR_DEMON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Doreen the Thruster",
"Elf",
"Dark Irregulars",
1,
6000,
"DarkIrregulars011",
CardIdentifier.DOREEN_THE_THRUSTER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dusk Illusionist, Robert",
"Elf",
"Pale Moon",
1,
10000,
"PaleMoon003",
CardIdentifier.DUSK_ILLUSIONIST__ROBERT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Gwynn the Ripper",
"Elf",
"Dark Irregulars",
1,
9000,
"DarkIrregulars009",
CardIdentifier.GWYNN_THE_RIPPER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"March Rabbit of Nightmareland",
"Warbeast",
"Dark Irregulars",
1,
6000,
"DarkIrregulars010",
CardIdentifier.MARCH_RABBIT_OF_NIGHTMARELAND
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Edel Rose",
"Vampire",
"Dark Irregulars",
1,
9000,
"DarkIrregulars008",
CardIdentifier.EDEL_ROSE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Ultimate Lifeform, Cosmo Lord",
"Alien",
"Nova Grappler",
1,
10000,
"NovaGrappler028",
CardIdentifier.ULTIMATE_LIFEFORM__COSMO_LORD
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Goddess of the Half Moon, Tsukuyomi",
"Noble",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank029",
CardIdentifier.GODDESS_OF_THE_HALF_MOON__TSUKUYOMI
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Goddess of the Full Moon, Tsukuyomi",
"Noble",
"Oracle Think Tank",
1,
11000,
"OracleThinkTank028",
CardIdentifier.GODDESS_OF_THE_FULL_MOON__TSUKUYOMI
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Swordsman of the Explosive Flames, Palamedes",
"Salamander",
"Royal Paladin",
1,
10000,
"RoyalPaladin023",
CardIdentifier.SWORDSMAN_OF_THE_EXPLOSIVE_FLAMES__PALAMEDES
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Ravenous Dragon, Gigarex",
"Dinodragon",
"Tachikaze",
1,
10000,
"Tachikaze010",
CardIdentifier.RAVENOUS_DRAGON__GIGAREX
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Nightmare Doll, Alice",
"Workeroid",
"Pale Moon",
1,
10000,
"PaleMoon002",
CardIdentifier.NIGHTMARE_DOLL__ALICE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Demon World Marquis, Amon",
"Demon",
"Dark Irregulars",
1,
10000,
"DarkIrregulars007",
CardIdentifier.DEMON_WORLD_MARQUIS__AMON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Stil Vampir",
"Vampire",
"Dark Irregulars",
1,
10000,
"DarkIrregulars006",
CardIdentifier.STIL_VAMPIR
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Circle Magus",
"Human",
"Oracle Think Tank",
1,
7000,
"OracleThinkTank027",
CardIdentifier.CIRCLE_MAGUS
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Workerpod, Saturday",
"Workeroid",
"Dimension Police",
1,
6000,
"DimensionPolice003",
CardIdentifier.WORKERPOD__SATURDAY
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Bloody Calf",
"Elf",
"Dark Irregulars",
1,
7000,
"DarkIrregulars005",
CardIdentifier.BLOODY_CALF
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Karenroid, Daisy",
"Battleroid",
"Dimension Police",
1,
8000,
"DimensionPolice002",
CardIdentifier.KARENROID__DAISY
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Blue Ray Dracokid",
"Flame Dragon",
"Kagero",
1,
5000,
"Kagero035",
CardIdentifier.BLUE_RAY_DRACOKID
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Masked Police, Grander",
"Human",
"Dimension Police",
1,
8000,
"DimensionPolice001",
CardIdentifier.MASKED_POLICE__GRANDER
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Victory Maker",
"High Beast",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank026",
CardIdentifier.VICTORY_MAKER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Flame Edge Dragon",
"Flame Dragon",
"Kagero",
1,
9000,
"Kagero033",
CardIdentifier.FLAME_EDGE_DRAGON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dragon Dancer, Lourdes",
"Human",
"Kagero",
1,
6000,
"Kagero034",
CardIdentifier.DRAGON_DANCER__LOURDES
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Faithful Angel",
"Angel",
"Oracle Think Tank",
1,
7000,
"OracleThinkTank023",
CardIdentifier.FAITHFUL_ANGEL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Goddess of the Crescent Moon, Tsukuyomi",
"Noble",
"Oracle Think Tank",
1,
7000,
"OracleThinkTank024",
CardIdentifier.GODDESS_OF_THE_CRESCENT_MOON__TSUKUYOMI
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Sister, Vanilla",
"Elf",
"Oracle Think Tank",
1,
6000,
"OracleThinkTank025",
CardIdentifier.BATTLE_SISTER__VANILLA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Oracle Guardian, Red Eye",
"Battleroid",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank022",
CardIdentifier.ORACLE_GUARDIAN__RED_EYE
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Alabaster Owl",
"High Beast",
"Royal Paladin",
1,
5000,
"RoyalPaladin022",
CardIdentifier.ALABASTER_OWL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Secretary Angel",
"Angel",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank021",
CardIdentifier.SECRETARY_ANGEL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Borgal",
"High Beast",
"Royal Paladin",
1,
6000,
"RoyalPaladin021",
CardIdentifier.BORGAL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Knight of Quests, Galahad",
"Human",
"Royal Paladin",
1,
7000,
"RoyalPaladin020",
CardIdentifier.KNIGHT_OF_QUESTS__GALAHAD
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Swordsman of the Blaze, Palamedes",
"Salamander",
"Royal Paladin",
1,
8000,
"RoyalPaladin019",
CardIdentifier.SWORDSMAN_OF_THE_BLAZE__PALAMEDES
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Gigantech Dozer",
"Giant",
"Royal Paladin",
1,
8000,
"RoyalPaladin018",
CardIdentifier.GIGANTECH_DOZER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Tribulations, Galahad",
"Human",
"Royal Paladin",
1,
9000,
"RoyalPaladin017",
CardIdentifier.KNIGHT_OF_TRIBULATIONS__GALAHAD
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Black Cannon Tiger",
"High Beast",
"Tachikaze",
1,
4000,
"Tachikaze009",
CardIdentifier.BLACK_CANNON_TIGER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Midnight Bunny",
"Warbeast",
"Pale Moon",
1,
7000,
"PaleMoon001",
CardIdentifier.MIDNIGHT_BUNNY
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Pack Dragon, Tinyrex",
"Dinodragon",
"Tachikaze",
1,
5000,
"Tachikaze019",
CardIdentifier.PACK_DRAGON__TINYREX
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Savage Shaman",
"Human",
"Tachikaze",
1,
5000,
"Tachikaze020",
CardIdentifier.SAVAGE_SHAMAN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Turquoise Beast Tamer",
"Elf",
"Pale Moon",
1,
6000,
"PaleMoon018",
CardIdentifier.TURQUOISE_BEAST_TAMER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Enigman Ripple",
"Alien",
"Dimension Police",
1,
6000,
"DimensionPolice017",
CardIdentifier.ENIGMAN_RIPPLE
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Army Penguin",
"Workeroid",
"Dimension Police",
1,
5000,
"DimensionPolice020",
CardIdentifier.ARMY_PENGUIN
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Cosmo Fang",
"Battleroid",
"Dimension Police",
1,
5000,
"DimensionPolice021",
CardIdentifier.COSMO_FANG
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Justice Cobalt",
"Alien",
"Dimension Police",
1,
5000,
"DimensionPolice019",
CardIdentifier.JUSTICE_COBALT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Glory Maker",
"Alien",
"Dimension Police",
1,
6000,
"DimensionPolice018",
CardIdentifier.GLORY_MAKER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Enigroid Comrade",
"Battleroid",
"Dimension Police",
1,
10000,
"DimensionPolice016",
CardIdentifier.ENIGROID_COMRADE
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Abyss Freezer",
"Angel",
"Shadow Paladin",
1,
5000,
"ShadowPaladin044",
CardIdentifier.ABYSS_FREEZER
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Darkside Trumpeter",
"Angel",
"Shadow Paladin",
1,
5000,
"ShadowPaladin045",
CardIdentifier.DARKSIDE_TRUMPETER
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Abyss Healer",
"Angel",
"Shadow Paladin",
1,
5000,
"ShadowPaladin046",
CardIdentifier.ABYSS_HEALER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Blaster Javelin",
"Human",
"Shadow Paladin",
1,
6000,
"ShadowPaladin041",
CardIdentifier.BLASTER_JAVELIN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Enigman Shine",
"Alien",
"Dimension Police",
1,
9000,
"DimensionPolice015",
CardIdentifier.ENIGMAN_SHINE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Zappbau",
"High Beast",
"Shadow Paladin",
1,
6000,
"ShadowPaladin042",
CardIdentifier.ZAPPBAU
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Grim Reaper",
"Demon",
"Shadow Paladin",
1,
5000,
"ShadowPaladin043",
CardIdentifier.GRIM_REAPER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Doranbau",
"High Beast",
"Shadow Paladin",
1,
6000,
"ShadowPaladin040",
CardIdentifier.DORANBAU
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Black Sage, Charon",
"Giant",
"Shadow Paladin",
1,
8000,
"ShadowPaladin038",
CardIdentifier.BLACK_SAGE__CHARON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Witch of Nostrum, Arianrhod",
"Elf",
"Shadow Paladin",
1,
7000,
"ShadowPaladin039",
CardIdentifier.WITCH_OF_NOSTRUM__ARIANRHOD
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Demon World Castle, DonnerSchlag",
"Golem",
"Shadow Paladin",
1,
10000,
"ShadowPaladin036",
CardIdentifier.DEMON_WORLD_CASTLE__DONNERSCHLAG
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Demon World Castle, Fatalita",
"Golem",
"Shadow Paladin",
1,
8000,
"ShadowPaladin037",
CardIdentifier.DEMON_WORLD_CASTLE__FATALITA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Beast Knight, Garmore",
"Human",
"Royal Paladin",
1,
8000,
"RoyalPaladin028",
CardIdentifier.BEAST_KNIGHT__GARMORE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Armored Fairy, Shubiela",
"Battleroid",
"Nova Grappler",
1,
10000,
"NovaGrappler033",
CardIdentifier.ARMORED_FAIRY__SHUBIELA
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Blaujunger",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler034",
CardIdentifier.BLAUJUNGER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Amber Dragon, Dawn",
"Flame Dragon",
"Kagero",
1,
5000,
"Kagero041",
CardIdentifier.AMBER_DRAGON__DAWN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Water Gang",
"Insect",
"Megacolony",
1,
9000,
"Megacolony014",
CardIdentifier.WATER_GANG
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Gloom Flyman",
"Insect",
"Megacolony",
1,
7000,
"Megacolony015",
CardIdentifier.GLOOM_FLYMAN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Violent Vesper",
"Insect",
"Megacolony",
1,
9000,
"Megacolony013",
CardIdentifier.VIOLENT_VESPER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lizard Soldier, Raopia",
"Dragonman",
"Kagero",
1,
6000,
"Kagero040",
CardIdentifier.LIZARD_SOLDIER__RAOPIA
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Larva Mutant, Giraffa",
"Insect",
"Megacolony",
1,
5000,
"Megacolony016",
CardIdentifier.LARVA_MUTANT__GIRAFFA
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Enigman Flow",
"Alien",
"Dimension Police",
1,
5000,
"DimensionPolice014",
CardIdentifier.ENIGMAN_FLOW
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Death Warden Ant Lion",
"Insect",
"Megacolony",
1,
10000,
"Megacolony012",
CardIdentifier.DEATH_WARDEN_ANT_LION
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Cosmo Roar",
"Battleroid",
"Dimension Police",
1,
6000,
"DimensionPolice013",
CardIdentifier.COSMO_ROAR
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Twin Order",
"Battleroid",
"Dimension Police",
1,
10000,
"DimensionPolice011",
CardIdentifier.TWIN_ORDER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Platinum Ace",
"Alien",
"Dimension Police",
1,
9000,
"DimensionPolice012",
CardIdentifier.PLATINUM_ACE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Enigman Rain",
"Alien",
"Dimension Police",
1,
10000,
"DimensionPolice010",
CardIdentifier.ENIGMAN_RAIN
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Fullbau",
"High Beast",
"Shadow Paladin",
1,
5000,
"ShadowPaladin035",
CardIdentifier.FULLBAU
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Darkness, Rugos",
"Human",
"Shadow Paladin",
1,
10000,
"ShadowPaladin033",
CardIdentifier.KNIGHT_OF_DARKNESS__RUGOS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Blaster Dark",
"Human",
"Shadow Paladin",
1,
9000,
"ShadowPaladin034",
CardIdentifier.BLASTER_DARK
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Silver Spear Demon, Gusion",
"Demon",
"Shadow Paladin",
1,
10000,
"ShadowPaladin031",
CardIdentifier.SILVER_SPEAR_DEMON__GUSION
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dark Mage, Badhabh Caar",
"Elf",
"Shadow Paladin",
1,
9000,
"ShadowPaladin032",
CardIdentifier.DARK_MAGE__BADHABH_CAAR
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Fang of Light, Garmore",
"Human",
"Royal Paladin",
1,
10000,
"RoyalPaladin027",
CardIdentifier.FANG_OF_LIGHT__GARMORE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Amber Dragon, Dusk",
"Flame Dragon",
"Kagero",
1,
9000,
"Kagero039",
CardIdentifier.AMBER_DRAGON__DUSK
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Blaukluger",
"Battleroid",
"Nova Grappler",
1,
9000,
"NovaGrappler032",
CardIdentifier.BLAUKLUGER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Commander Laurel",
"Alien",
"Dimension Police",
1,
4000,
"DimensionPolice009",
CardIdentifier.COMMANDER_LAUREL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Elite Mutant, Giraffa",
"Insect",
"Megacolony",
1,
9000,
"Megacolony010",
CardIdentifier.ELITE_MUTANT__GIRAFFA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Paralyze Madonna",
"Insect",
"Megacolony",
1,
6000,
"Megacolony011",
CardIdentifier.PARALYZE_MADONNA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Diamond Ace",
"Alien",
"Dimension Police",
1,
6000,
"DimensionPolice008",
CardIdentifier.DIAMOND_ACE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Cosmo Beak",
"Battleroid",
"Dimension Police",
1,
8000,
"DimensionPolice007",
CardIdentifier.COSMO_BEAK
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Enigman Wave",
"Alien",
"Dimension Police",
1,
9000,
"DimensionPolice006",
CardIdentifier.ENIGMAN_WAVE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Dark Shield, Mac Lir",
"Human",
"Shadow Paladin",
1,
6000,
"ShadowPaladin030",
CardIdentifier.DARK_SHIELD__MAC_LIR
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dark Metal Dragon",
"Abyss Dragon",
"Shadow Paladin",
1,
10000,
"ShadowPaladin028",
CardIdentifier.DARK_METAL_DRAGON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Gururubau",
"High Beast",
"Shadow Paladin",
1,
7000,
"ShadowPaladin029",
CardIdentifier.GURURUBAU
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Evil Armor General, Giraffa",
"Insect",
"Megacolony",
1,
10000,
"Megacolony009",
CardIdentifier.EVIL_ARMOR_GENERAL__GIRAFFA
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Amber Dragon, Eclipse",
"Flame Dragon",
"Kagero",
1,
10000,
"Kagero037",
CardIdentifier.AMBER_DRAGON__ECLIPSE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Stern Blaukluger",
"Battleroid",
"Nova Grappler",
1,
10000,
"NovaGrappler031",
CardIdentifier.STERN_BLAUKLUGER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Heatnail Salamander",
"Salamander",
"Kagero",
1,
6000,
"Kagero038",
CardIdentifier.HEATNAIL_SALAMANDER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Skull Witch, Nemain",
"Elf",
"Shadow Paladin",
1,
3000,
"ShadowPaladin027",
CardIdentifier.SKULL_WITCH__NEMAIN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Enigman Storm",
"Alien",
"Dimension Police",
1,
10000,
"DimensionPolice005",
CardIdentifier.ENIGMAN_STORM
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Fighting Battleship, Prometheus",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler039",
CardIdentifier.FIGHTING_BATTLESHIP__PROMETHEUS
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Grapple Mania",
"Workeroid",
"Nova Grappler",
1,
4000,
"NovaGrappler040",
CardIdentifier.GRAPPLE_MANIA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Snogal",
"High Beast",
"Royal Paladin",
1,
6000,
"RoyalPaladin029",
CardIdentifier.SNOGAL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Toolkit Boy",
"Workeroid",
"Nova Grappler",
1,
5000,
"NovaGrappler038",
CardIdentifier.TOOLKIT_BOY
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dancing Wolf",
"Warbeast",
"Nova Grappler",
1,
7000,
"NovaGrappler036",
CardIdentifier.DANCING_WOLF
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Blaupanzer",
"Battleroid",
"Nova Grappler",
1,
6000,
"NovaGrappler037",
CardIdentifier.BLAUPANZER
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Red Gem Carbuncle",
"High Beast",
"Kagero",
1,
5000,
"Kagero045",
CardIdentifier.RED_GEM_CARBUNCLE
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Flame Seed Salamander",
"Salamander",
"Kagero",
1,
4000,
"Kagero046",
CardIdentifier.FLAME_SEED_SALAMANDER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Eisenkugel",
"Battleroid",
"Nova Grappler",
1,
10000,
"NovaGrappler035",
CardIdentifier.EISENKUGEL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Amber Dragon, Daylight",
"Flame Dragon",
"Kagero",
1,
6000,
"Kagero044",
CardIdentifier.AMBER_DRAGON__DAYLIGHT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Lava Arm Dragon",
"Flame Dragon",
"Kagero",
1,
10000,
"Kagero043",
CardIdentifier.LAVA_ARM_DRAGON
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Medical Battler, Ranpli",
"Insect",
"Megacolony",
1,
5000,
"Megacolony024",
CardIdentifier.MEDICAL_BATTLER__RANPLI
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Garnet Dragon, Flash",
"Flame Dragon",
"Kagero",
1,
9000,
"Kagero042",
CardIdentifier.GARNET_DRAGON__FLASH
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Sharp Nail Scorpio",
"Insect",
"Megacolony",
1,
5000,
"Megacolony021",
CardIdentifier.SHARP_NAIL_SCORPIO
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Raider Mantis",
"Insect",
"Megacolony",
1,
5000,
"Megacolony022",
CardIdentifier.RAIDER_MANTIS
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Sonic Cicada",
"Insect",
"Megacolony",
1,
5000,
"Megacolony023",
CardIdentifier.SONIC_CICADA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Millipede",
"Insect",
"Megacolony",
1,
6000,
"Megacolony020",
CardIdentifier.STEALTH_MILLIPEDE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Tail Joe",
"Insect",
"Megacolony",
1,
8000,
"Megacolony018",
CardIdentifier.TAIL_JOE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Pupa Mutant, Giraffa",
"Insect",
"Megacolony",
1,
6000,
"Megacolony019",
CardIdentifier.PUPA_MUTANT__GIRAFFA
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Justice Rose",
"Alien",
"Dimension Police",
1,
5000,
"DimensionPolice022",
CardIdentifier.JUSTICE_ROSE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Ironcutter Beetle",
"Insect",
"Megacolony",
1,
10000,
"Megacolony017",
CardIdentifier.IRONCUTTER_BEETLE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Darkness Maiden, Macha",
"Human",
"Shadow Paladin",
1,
8000,
"ShadowPaladin026",
CardIdentifier.DARKNESS_MAIDEN__MACHA
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Phantom Blaster Dragon",
"Abyss Dragon",
"Shadow Paladin",
1,
10000,
"ShadowPaladin025",
CardIdentifier.PHANTOM_BLASTER_DRAGON
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Brugal",
"High Beast",
"Royal Paladin",
1,
4000,
"RoyalPaladin030",
CardIdentifier.BRUGAL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Cursed Lancer",
"Human",
"Shadow Paladin",
1,
9000,
"ShadowPaladin047",
CardIdentifier.CURSED_LANCER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Megacolony Battler B",
"Insect",
"Megacolony",
1,
6000,
"Megacolony025",
CardIdentifier.MEGACOLONY_BATTLER_B
));
		
		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Guide Dolphin",
"High Beast",
"Dimension Police",
1,
4000,
"DimensionPolice026",
CardIdentifier.GUIDE_DOLPHIN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dark Soul Conductor",
"Elf",
"Dark Irregulars",
1,
8000,
"DarkIrregulars026",
CardIdentifier.DARK_SOUL_CONDUCTOR
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Hysteric Shirley",
"Human",
"Dark Irregulars",
1,
4000,
"DarkIrregulars027",
CardIdentifier.HYSTERIC_SHIRLEY
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Big League Bear",
"High Beast",
"Pale Moon",
1,
8000,
"PaleMoon020",
CardIdentifier.BIG_LEAGUE_BEAR
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Madcap Marionette",
"Workeroid",
"Pale Moon",
1,
6000,
"PaleMoon021",
CardIdentifier.MADCAP_MARIONETTE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Doom Bringer Griffin",
"High Beast",
"Kagero",
1,
5000,
"Kagero050",
CardIdentifier.DOOM_BRINGER_GRIFFIN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Top Gun",
"Battleroid",
"Nova Grappler",
1,
10000,
"NovaGrappler042",
CardIdentifier.TOP_GUN
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"The Gong",
"Workeroid",
"Nova Grappler",
1,
5000,
"NovaGrappler044",
CardIdentifier.THE_GONG
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Super Dimensional Robo, Dailady",
"Battleroid",
"Dimension Police",
1,
9000,
"DimensionPolice025",
CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAILADY
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Anthrodroid",
"Battleroid",
"Nova Grappler",
1,
6000,
"NovaGrappler043",
CardIdentifier.ANTHRODROID
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"White Hare of Inaba",
"High Beast",
"Oracle Think Tank",
1,
6000,
"OracleThinkTank034",
CardIdentifier.WHITE_HARE_OF_INABA
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Battle Sister, Ginger",
"Elf",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank035",
CardIdentifier.BATTLE_SISTER__GINGER
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Death Feather Eagle",
"High Beast",
"Shadow Paladin",
1,
5000,
"ShadowPaladin055",
CardIdentifier.DEATH_FEATHER_EAGLE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Maiden, Tagitsuhime",
"Noble",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank033",
CardIdentifier.BATTLE_MAIDEN__TAGITSUHIME
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Phantom Bringer Demon",
"Demon",
"Shadow Paladin",
1,
5000,
"ShadowPaladin054",
CardIdentifier.PHANTOM_BRINGER_DEMON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dream Painter",
"Sylph",
"Royal Paladin",
1,
6000,
"RoyalPaladin037",
CardIdentifier.DREAM_PAINTER
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Silent Sage, Sharon",
"Giant",
"Royal Paladin",
1,
4000,
"RoyalPaladin038",
CardIdentifier.SILENT_SAGE__SHARON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Nightmare Painter",
"Sylph",
"Shadow Paladin",
1,
6000,
"ShadowPaladin053",
CardIdentifier.NIGHTMARE_PAINTER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Powerful Sage, Bairon",
"Giant",
"Royal Paladin",
1,
9000,
"RoyalPaladin036",
CardIdentifier.POWERFUL_SAGE__BAIRON
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Stealth Beast, Cat Rogue",
"Warbeast",
"Murakumo",
1,
5000,
"Murakumo016",
CardIdentifier.STEALTH_BEAST__CAT_ROGUE
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Stealth Fiend, Yukihime",
"Ghost",
"Murakumo",
1,
5000,
"Murakumo017",
CardIdentifier.STEALTH_FIEND__YUKIHIME
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Stealth Fiend, Dart Spider",
"Insect",
"Murakumo",
1,
4000,
"Murakumo018",
CardIdentifier.STEALTH_FIEND__DART_SPIDER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Stealth Beast, White Mane",
"Warbeast",
"Murakumo",
1,
9000,
"Murakumo012",
CardIdentifier.STEALTH_BEAST__WHITE_MANE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Rogue of Silence, Shijimamaru",
"Human",
"Murakumo",
1,
8000,
"Murakumo013",
CardIdentifier.STEALTH_ROGUE_OF_SILENCE__SHIJIMAMARU
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Beast, Leaf Raccoon",
"High Beast",
"Murakumo",
1,
6000,
"Murakumo014",
CardIdentifier.STEALTH_BEAST__LEAF_RACCOON
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Stealth Beast, Moon Edge",
"High Beast",
"Murakumo",
1,
5000,
"Murakumo015",
CardIdentifier.STEALTH_BEAST__MOON_EDGE
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Chestnut Bullet",
"Dryad",
"Neo Nectar",
1,
5000,
"NeoNectar019",
CardIdentifier.CHESTNUT_BULLET
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Dancing Sunflower",
"Dryad",
"Neo Nectar",
1,
5000,
"NeoNectar020",
CardIdentifier.DANCING_SUNFLOWER
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Sweet Honey",
"Insect",
"Neo Nectar",
1,
5000,
"NeoNectar021",
CardIdentifier.SWEET_HONEY
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Watering Elf",
"Elf",
"Neo Nectar",
1,
4000,
"NeoNectar022",
CardIdentifier.WATERING_ELF
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lily Knight of the Valley",
"Bioroid",
"Neo Nectar",
1,
6000,
"NeoNectar017",
CardIdentifier.LILY_KNIGHT_OF_THE_VALLEY
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Pea Knight",
"Dryad",
"Neo Nectar",
1,
6000,
"NeoNectar018",
CardIdentifier.PEA_KNIGHT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lady of the Sunlight Forest",
"Elf",
"Neo Nectar",
1,
7000,
"NeoNectar015",
CardIdentifier.LADY_OF_THE_SUNLIGHT_FOREST
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Blade Seed Squire",
"Bioroid",
"Neo Nectar",
1,
7000,
"NeoNectar016",
CardIdentifier.BLADE_SEED_SQUIRE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Corolla Dragon",
"Forest Dragon",
"Neo Nectar",
1,
8000,
"NeoNectar013",
CardIdentifier.COROLLA_DRAGON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Caramel Popcorn",
"Dryad",
"Neo Nectar",
1,
7000,
"NeoNectar014",
CardIdentifier.CARAMEL_POPCORN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Colossal Wings, Simurgh",
"High Beast",
"Neo Nectar",
1,
8000,
"NeoNectar011",
CardIdentifier.COLOSSAL_WINGS__SIMURGH
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Spiritual Tree Sage, Irminsul",
"Dryad",
"Neo Nectar",
1,
7000,
"NeoNectar012",
CardIdentifier.SPIRITUAL_TREE_SAGE__IRMINSUL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Verdure, Gene",
"Bioroid",
"Neo Nectar",
1,
9000,
"NeoNectar010",
CardIdentifier.KNIGHT_OF_VERDURE__GENE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Magical Police, Quilt",
"Human",
"Dimension Police",
1,
6000,
"DimensionPolice024",
CardIdentifier.MAGICAL_POLICE__QUILT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Devil Child",
"Demon",
"Dark Irregulars",
1,
6000,
"DarkIrregulars025",
CardIdentifier.DEVIL_CHILD
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Flame of Promise, Aermo",
"Salamander",
"Kagero",
1,
4000,
"Kagero049",
CardIdentifier.FLAME_OF_PROMISE__AERMO
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Burning Horn Dragon",
"Flame Dragon",
"Kagero",
1,
9000,
"Kagero048",
CardIdentifier.BURNING_HORN_DRAGON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Apocalypse Bat",
"Ghost",
"Shadow Paladin",
1,
4000,
"ShadowPaladin052",
CardIdentifier.APOCALYPSE_BAT
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Stealth Beast, Evil Ferret",
"High Beast",
"Murakumo",
1,
5000,
"Murakumo011",
CardIdentifier.STEALTH_BEAST__EVIL_FERRET
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Knight of Purgatory, Skull Face",
"Human",
"Shadow Paladin",
1,
10000,
"ShadowPaladin051",
CardIdentifier.KNIGHT_OF_PURGATORY__SKULL_FACE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Dragon, Turbulent Edge",
"Winged Dragon",
"Murakumo",
1,
6000,
"Murakumo009",
CardIdentifier.STEALTH_DRAGON__TURBULENT_EDGE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Beast, Million Rat",
"High Beast",
"Murakumo",
1,
6000,
"Murakumo010",
CardIdentifier.STEALTH_BEAST__MILLION_RAT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Stealth Dragon, Cursed Breath",
"Winged Dragon",
"Murakumo",
1,
8000,
"Murakumo008",
CardIdentifier.STEALTH_DRAGON__CURSED_BREATH
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Caped Stealth Rogue, Shanaou",
"Demon",
"Murakumo",
1,
8000,
"Murakumo007",
CardIdentifier.CAPED_STEALTH_ROGUE__SHANAOU
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Stealth Beast, Bloody Mist",
"Warbeast",
"Murakumo",
1,
10000,
"Murakumo006",
CardIdentifier.STEALTH_BEAST__BLOODY_MIST
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Stealth Fiend, Kurama Lord",
"Noble",
"Murakumo",
1,
10000,
"Murakumo004",
CardIdentifier.STEALTH_FIEND__KURAMA_LORD
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Frontline Valkyrie, Laurel",
"Bioroid",
"Neo Nectar",
1,
10000,
"NeoNectar004",
CardIdentifier.FRONTLINE_VALKYRIE__LAUREL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Knight of Harvest, Gene",
"Bioroid",
"Neo Nectar",
1,
10000,
"NeoNectar005",
CardIdentifier.KNIGHT_OF_HARVEST__GENE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Stealth Dragon, Voidgelga",
"Abyss Dragon",
"Murakumo",
1,
9000,
"Murakumo005",
CardIdentifier.STEALTH_DRAGON__VOIDGELGA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Hey Yo Pineapple",
"Dryad",
"Neo Nectar",
1,
8000,
"NeoNectar008",
CardIdentifier.HEY_YO_PINEAPPLE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Shield Seed Squire",
"Bioroid",
"Neo Nectar",
1,
5000,
"NeoNectar009",
CardIdentifier.SHIELD_SEED_SQUIRE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Iris Knight",
"Bioroid",
"Neo Nectar",
1,
10000,
"NeoNectar007",
CardIdentifier.IRIS_KNIGHT
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Avatar of the Plains, Behemoth",
"High Beast",
"Neo Nectar",
1,
10000,
"NeoNectar006",
CardIdentifier.AVATAR_OF_THE_PLAINS__BEHEMOTH
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Phantom Blaster Overlord",
"Abyss Dragon",
"Shadow Paladin",
1,
11000,
"ShadowPaladin048",
CardIdentifier.PHANTOM_BLASTER_OVERLORD
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dragonic Overlord the End",
"Flame Dragon",
"Kagero",
1,
11000,
"Kagero047",
CardIdentifier.DRAGONIC_OVERLORD_THE_END
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Miracle Beauty",
"Alien",
"Dimension Police",
1,
10000,
"DimensionPolice023",
CardIdentifier.MIRACLE_BEAUTY
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Street Bouncer",
"Alien",
"Nova Grappler",
1,
8000,
"NovaGrappler041",
CardIdentifier.STREET_BOUNCER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Evil-eye Princess, Euryale",
"Noble",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank032",
CardIdentifier.EVIL_EYE_PRINCESS__EURYALE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Moonlight Witch, Vaha",
"Elf",
"Shadow Paladin",
1,
9000,
"ShadowPaladin049",
CardIdentifier.MOONLIGHT_WITCH__VAHA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Nullity, Masquerade",
"Human",
"Shadow Paladin",
1,
9000,
"ShadowPaladin050",
CardIdentifier.KNIGHT_OF_NULLITY__MASQUERADE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Loyalty, Bedivere",
"Human",
"Royal Paladin",
1,
9000,
"RoyalPaladin033",
CardIdentifier.KNIGHT_OF_LOYALTY__BEDIVERE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Knight of Friendship, Kay",
"Human",
"Royal Paladin",
1,
7000,
"RoyalPaladin034",
CardIdentifier.KNIGHT_OF_FRIENDSHIP__KAY
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Wingal Brave",
"High Beast",
"Royal Paladin",
1,
5000,
"RoyalPaladin035",
CardIdentifier.WINGAL_BRAVE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Stealth Fiend, Midnight Crow",
"Warbeast",
"Murakumo",
1,
8000,
"Murakumo002",
CardIdentifier.STEALTH_FIEND__MIDNIGHT_CROW
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Stealth Beast, Leaves Mirage",
"Warbeast",
"Murakumo",
1,
6000,
"Murakumo003",
CardIdentifier.STEALTH_BEAST__LEAVES_MIRAGE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Maiden of Blossom Rain",
"Dryad",
"Neo Nectar",
1,
6000,
"NeoNectar003",
CardIdentifier.MAIDEN_OF_BLOSSOM_RAIN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Maiden of Trailing Rose",
"Dryad",
"Neo Nectar",
1,
11000,
"NeoNectar001",
CardIdentifier.MAIDEN_OF_TRAILING_ROSE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Glass Beads Dragon",
"Forest Dragon",
"Neo Nectar",
1,
9000,
"NeoNectar002",
CardIdentifier.GLASS_BEADS_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"King of Diptera, Beelzebub",
"Demon",
"Dark Irregulars",
1,
10000,
"DarkIrregulars024",
CardIdentifier.KING_OF_DIPTERA__BEELZEBUB
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Mistress Hurricane",
"Chimera",
"Pale Moon",
1,
10000,
"PaleMoon019",
CardIdentifier.MISTRESS_HURRICANE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Star Call Trumpeter",
"Angel",
"Royal Paladin",
1,
8000,
"RoyalPaladin032",
CardIdentifier.STAR_CALL_TRUMPETER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Covert Demonic Dragon, Mandala Lord",
"Abyss Dragon",
"Murakumo",
1,
11000,
"Murakumo001",
CardIdentifier.COVERT_DEMONIC_DRAGON__MANDALA_LORD
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Majesty Lord Blaster",
"Human",
"Royal Paladin",
1,
10000,
"RoyalPaladin031",
CardIdentifier.MAJESTY_LORD_BLASTER
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Sky High Walker",
"Goblin",
"Pale Moon",
1,
4000,
"PaleMoon022",
CardIdentifier.SKYHIGH_WALKER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Conjurer of Mithril",
"Elf",
"Royal Paladin",
1,
7000,
"RoyalPaladin039",
CardIdentifier.CONJURER_OF_MITHRIL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Demonic Dragon Mage, Mahoraga",
"Dragonman",
"Kagero",
1,
5000,
"Kagero051",
CardIdentifier.DEMONIC_DRAGON_MAGE__MAHORAGA
));
		
		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Circular Saw, Kiriel",
"Angel",
"Angel Feather",
1,
10000,
"AngelFeather001",
CardIdentifier.CIRCULAR_SAW__KIRIEL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Cupid, Nociel",
"Angel",
"Angel Feather",
1,
6000,
"AngelFeather002",
CardIdentifier.BATTLE_CUPID__NOCIEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Ice Prison Necromancer, Cocytus",
"Skeleton",
"Granblue",
1,
10000,
"Granblue020",
CardIdentifier.ICE_PRISON_NECROMANCER__COCYTUS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Incandescent Lion, Blond Ezel",
"Human",
"Gold Paladin",
1,
10000,
"GoldPaladin001",
CardIdentifier.INCANDESCENT_LION__BLOND_EZEL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Player of the Holy Bow, Viviane",
"Elf",
"Gold Paladin",
1,
9000,
"GoldPaladin002",
CardIdentifier.PLAYER_OF_THE_HOLY_BOW__VIVIANE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dragonic Kaiser Vermillion",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami001",
CardIdentifier.DRAGONIC_KAISER_VERMILLION
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Desert Gunner, Shiden",
"Human",
"Narukami",
1,
9000,
"Narukami002",
CardIdentifier.DESERT_GUNNER__SHIDEN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Beast Deity, Azure Dragon",
"Battleroid",
"Nova Grappler",
1,
11000,
"NovaGrappler045",
CardIdentifier.BEAST_DEITY__AZURE_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Cosmo Healer, Ergodiel",
"Angel",
"Angel Feather",
1,
10000,
"AngelFeather003",
CardIdentifier.COSMO_HEALER__ERGODIEL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Core Memory, Armaros",
"Angel",
"Angel Feather",
1,
9000,
"AngelFeather004",
CardIdentifier.CORE_MEMORY__ARMAROS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Love Machine Gun, Nociel",
"Angel",
"Angel Feather",
1,
8000,
"AngelFeather005",
CardIdentifier.LOVE_MACHINE_GUN__NOCIEL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Pure Keeper, Requiel",
"Angel",
"Angel Feather",
1,
6000,
"AngelFeather006",
CardIdentifier.PURE_KEEPER__REQUIEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Deadly Swordmaster",
"Ghost",
"Granblue",
1,
11000,
"Granblue021",
CardIdentifier.DEADLY_SWORDMASTER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Death Seeker, Thanatos",
"Noble",
"Granblue",
1,
10000,
"Granblue022",
CardIdentifier.DEATH_SEEKER__THANATOS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Knight of Fury, Agravain",
"Demon",
"Gold Paladin",
1,
10000,
"GoldPaladin003",
CardIdentifier.KNIGHT_OF_FURY__AGRAVAIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Sleygal Dagger",
"High Beast",
"Gold Paladin",
1,
7000,
"GoldPaladin004",
CardIdentifier.SLEYGAL_DAGGER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Halo Shield, Mark",
"Human",
"Gold Paladin",
1,
6000,
"GoldPaladin005",
CardIdentifier.HALO_SHIELD__MARK
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Vajra Emperor, Indra",
"Noble",
"Narukami",
1,
10000,
"Narukami003",
CardIdentifier.VAJRA_EMPEROR__INDRA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dragonic Deathscythe",
"Thunder Dragon",
"Narukami",
1,
9000,
"Narukami004",
CardIdentifier.DRAGONIC_DEATHSCYTHE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Wyvern Guard, Guld",
"Winged Dragon",
"Narukami",
1,
6000,
"Narukami005",
CardIdentifier.WYVERN_GUARD__GULD
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Mobile Hospital, Feather Palace",
"Golem",
"Angel Feather",
1,
10000,
"AngelFeather007",
CardIdentifier.MOBILE_HOSPITAL__FEATHER_PALACE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Drill Bullet, Geniel",
"Angel",
"Angel Feather",
1,
10000,
"AngelFeather008",
CardIdentifier.DRILL_BULLET__GENIEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"The Phoenix, Calamity Flame",
"Salamander",
"Angel Feather",
1,
10000,
"AngelFeather009",
CardIdentifier.THE_PHOENIX__CALAMITY_FLAME
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Gattling Shot, Barbiel",
"Angel",
"Angel Feather",
1,
10000,
"AngelFeather010",
CardIdentifier.GATTLING_SHOT__BARBIEL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Fate Healer, Ergodiel",
"Angel",
"Angel Feather",
1,
9000,
"AngelFeather011",
CardIdentifier.FATE_HEALER__ERGODIEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Miracle Feather Nurse",
"Angel",
"Angel Feather",
1,
4000,
"AngelFeather012",
CardIdentifier.MIRACLE_FEATHER_NURSE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Master Swordsman, Nightstorm",
"Vampire",
"Granblue",
1,
10000,
"Granblue023",
CardIdentifier.MASTER_SWORDSMAN__NIGHTSTORM
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Skeleton Demon World Knight",
"Skeleton",
"Granblue",
1,
9000,
"Granblue024",
CardIdentifier.SKELETON_DEMON_WORLD_KNIGHT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Deadly Spirit",
"Ghost",
"Granblue",
1,
9000,
"Granblue025",
CardIdentifier.DEADLY_SPIRIT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Three Star Chef, Pietro",
"Skeleton",
"Granblue",
1,
9000,
"Granblue026",
CardIdentifier.THREE_STAR_CHEF__PIETRO
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Deadly Nightmare",
"Ghost",
"Granblue",
1,
7000,
"Granblue027",
CardIdentifier.DEADLY_NIGHTMARE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Superior Skills, Beaumains",
"Human",
"Gold Paladin",
1,
10000,
"GoldPaladin006",
CardIdentifier.KNIGHT_OF_SUPERIOR_SKILLS__BEAUMAINS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Mage of Calamity, Tripp",
"Angel",
"Gold Paladin",
1,
9000,
"GoldPaladin007",
CardIdentifier.MAGE_OF_CALAMITY__TRIPP
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Player of the Holy Axe, Nimue",
"Human",
"Gold Paladin",
1,
7000,
"GoldPaladin008",
CardIdentifier.PLAYER_OF_THE_HOLY_AXE__NIMUE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Crimson Lion Cub, Kyrph",
"Human",
"Gold Paladin",
1,
5000,
"GoldPaladin009",
CardIdentifier.CRIMSON_LION_CUB__KYRPH
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Riot General, Gyras",
"Human",
"Narukami",
1,
10000,
"Narukami006",
CardIdentifier.RIOT_GENERAL__GYRAS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Thunderstorm Dragoon",
"Human",
"Narukami",
1,
10000,
"Narukami007",
CardIdentifier.THUNDERSTORM_DRAGOON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Demonic Dragon Berserker, Garuda",
"Thunder Dragon",
"Narukami",
1,
9000,
"Narukami008",
CardIdentifier.DEMONIC_DRAGON_BERSERKER__GARUDA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Desert Gunner, Raien",
"Human",
"Narukami",
1,
7000,
"Narukami009",
CardIdentifier.DESERT_GUNNER__RAIEN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Photon Bomber Wyvern",
"Winged Dragon",
"Narukami",
1,
6000,
"Narukami010",
CardIdentifier.PHOTON_BOMBER_WYVERN
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Lizard Soldier, Saishin",
"Dragonman",
"Narukami",
1,
5000,
"Narukami011",
CardIdentifier.LIZARD_SOLDIER__SAISHIN
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Beast Deity, White Tiger",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler046",
CardIdentifier.BEAST_DEITY__WHITE_TIGER
));

		Card.Add (new CardInformation (3,
TriggerIcon.DRAW,
SkillIcon.TWIN_DRIVE,
0,
"Pulse Wave, Adriel",
"Angel",
"Angel Feather",
1,
10000,
"AngelFeather013",
CardIdentifier.PULSE_WAVE__ADRIEL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Million Ray Pegasus",
"High Beast",
"Angel Feather",
1,
9000,
"AngelFeather014",
CardIdentifier.MILLION_RAY_PEGASUS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Iron Heart, Mastema",
"Angel",
"Angel Feather",
1,
8000,
"AngelFeather015",
CardIdentifier.IRON_HEART__MASTEMA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Holy Zone, Penemue",
"Angel",
"Angel Feather",
1,
8000,
"AngelFeather016",
CardIdentifier.HOLY_ZONE__PENEMUE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Burst Shot, Bethnael",
"Angel",
"Angel Feather",
1,
8000,
"AngelFeather017",
CardIdentifier.BURST_SHOT__BETHNAEL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Thousand Ray Pegasus",
"High Beast",
"Angel Feather",
1,
7000,
"AngelFeather018",
CardIdentifier.THOUSAND_RAY_PEGASUS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Heavenly Injector",
"Angel",
"Angel Feather",
1,
7000,
"AngelFeather019",
CardIdentifier.HEAVENLY_INJECTOR
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lancet Shooter",
"Angel",
"Angel Feather",
1,
7000,
"AngelFeather020",
CardIdentifier.LANCET_SHOOTER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Carrier of the Life Water",
"High Beast",
"Angel Feather",
1,
6000,
"AngelFeather021",
CardIdentifier.CARRIER_OF_THE_LIFE_WATER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Clutch Rifle Angel",
"Angel",
"Angel Feather",
1,
6000,
"AngelFeather022",
CardIdentifier.CLUTCH_RIFLE_ANGEL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lightning Charger",
"Human",
"Angel Feather",
1,
6000,
"AngelFeather023",
CardIdentifier.LIGHTNING_CHARGER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Thermometer Angel",
"Angel",
"Angel Feather",
1,
4000,
"AngelFeather024",
CardIdentifier.THERMOMETER_ANGEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Rocket Dash Unicorn",
"High Beast",
"Angel Feather",
1,
5000,
"AngelFeather025",
CardIdentifier.ROCKET_DASH_UNICORN
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Bouquet Toss Messenger",
"Angel",
"Angel Feather",
1,
5000,
"AngelFeather026",
CardIdentifier.BOUQUET_TOSS_MESSENGER
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Aurora Ribbon Pigeon",
"High Beast",
"Angel Feather",
1,
5000,
"AngelFeather027",
CardIdentifier.AURORA_RIBBON_PIGEON
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Critical Hit Angel",
"Angel",
"Angel Feather",
1,
4000,
"AngelFeather028",
CardIdentifier.CRITICAL_HIT_ANGEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Happy Bell, Nociel",
"Angel",
"Angel Feather",
1,
4000,
"AngelFeather029",
CardIdentifier.HAPPY_BELL__NOCIEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Sunny Smile Angel",
"Angel",
"Angel Feather",
1,
3000,
"AngelFeather030",
CardIdentifier.SUNNY_SMILE_ANGEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"God-eating Zombie Shark",
"Zombie",
"Granblue",
1,
10000,
"Granblue028",
CardIdentifier.GOD_EATING_ZOMBIE_SHARK
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Stormride Ghost Ship",
"Ghost",
"Granblue",
1,
11000,
"Granblue029",
CardIdentifier.STORMRIDE_GHOST_SHIP
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Undead Pirate of the Frigid Night",
"Ghost",
"Granblue",
1,
8000,
"Granblue030",
CardIdentifier.UNDEAD_PIRATE_OF_THE_FRIGID_NIGHT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Sea Navigator, Silver",
"Vampire",
"Granblue",
1,
7000,
"Granblue031",
CardIdentifier.SEA_NAVIGATOR__SILVER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Skeleton Colossus",
"Skeleton",
"Granblue",
1,
7000,
"Granblue032",
CardIdentifier.SKELETON_COLOSSUS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Child Frank",
"Workeroid",
"Granblue",
1,
7000,
"Granblue033",
CardIdentifier.CHILD_FRANK
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"John the Ghostie",
"Ghost",
"Granblue",
1,
6000,
"Granblue034",
CardIdentifier.JOHN_THE_GHOSTIE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Ripple Banshee",
"Ghost",
"Granblue",
1,
6000,
"Granblue035",
CardIdentifier.RIPPLE_BANSHEE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dragon Spirit",
"Ghost",
"Granblue",
1,
6000,
"Granblue036",
CardIdentifier.DRAGON_SPIRIT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Undead Pirate of the Cursed Rifle",
"Ghost",
"Granblue",
1,
6000,
"Granblue037",
CardIdentifier.UNDEAD_PIRATE_OF_THE_CURSED_RIFLE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Captain Nightkid",
"Vampire",
"Granblue",
1,
5000,
"Granblue038",
CardIdentifier.CAPTAIN_NIGHTKID
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Skeleton Assault Troops Captain",
"Skeleton",
"Granblue",
1,
4000,
"Granblue039",
CardIdentifier.SKELETON_ASSAULT_TROOPS_CAPTAIN
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Ghoul Cannonball",
"Ghost",
"Granblue",
1,
5000,
"Granblue040",
CardIdentifier.GHOUL_CANNONBALL
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Hook-wielding Zombie",
"Zombie",
"Granblue",
1,
5000,
"Granblue041",
CardIdentifier.HOOK_WIELDING_ZOMBIE
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Doctor Rouge",
"Vampire",
"Granblue",
1,
5000,
"Granblue042",
CardIdentifier.DOCTOR_ROUGE
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Hades Steersman",
"Ghost",
"Granblue",
1,
3000,
"Granblue043",
CardIdentifier.HADES_STEERSMAN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Gigantech Crusher",
"Giant",
"Gold Paladin",
1,
10000,
"GoldPaladin010",
CardIdentifier.GIGANTECH_CRUSHER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Holy Mage, Manawydan",
"Elf",
"Gold Paladin",
1,
10000,
"GoldPaladin011",
CardIdentifier.HOLY_MAGE__MANAWYDAN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Gigantech Commander",
"Giant",
"Gold Paladin",
1,
8000,
"GoldPaladin012",
CardIdentifier.GIGANTECH_COMMANDER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Sacred Guardian Beast, Elephas",
"High Beast",
"Gold Paladin",
1,
8000,
"GoldPaladin013",
CardIdentifier.SACRED_GUARDIAN_BEAST__ELEPHAS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Providence Strategist",
"Human",
"Gold Paladin",
1,
7000,
"GoldPaladin014",
CardIdentifier.PROVIDENCE_STRATEGIST
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Knight of Elegant Skills, Gareth",
"Human",
"Gold Paladin",
1,
8000,
"GoldPaladin015",
CardIdentifier.KNIGHT_OF_ELEGANT_SKILLS__GARETH
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Waving Owl",
"High Beast",
"Gold Paladin",
1,
6000,
"GoldPaladin016",
CardIdentifier.WAVING_OWL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Little Battler, Tron",
"Giant",
"Gold Paladin",
1,
6000,
"GoldPaladin017",
CardIdentifier.LITTLE_BATTLER__TRON
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Little Fighter, Cron",
"Giant",
"Gold Paladin",
1,
4000,
"GoldPaladin018",
CardIdentifier.LITTLE_FIGHTER__CRON
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Greeting Drummer",
"Human",
"Gold Paladin",
1,
5000,
"GoldPaladin019",
CardIdentifier.GREETING_DRUMMER
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Flame of Victory",
"Salamander",
"Gold Paladin",
1,
4000,
"GoldPaladin020",
CardIdentifier.FLAME_OF_VICTORY
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Breakthrough Dragon",
"Thunder Dragon",
"Narukami",
1,
10000,
"Narukami012",
CardIdentifier.BREAKTHROUGH_DRAGON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Hex Cannon Wyvern",
"Winged Dragon",
"Narukami",
1,
8000,
"Narukami013",
CardIdentifier.HEX_CANNON_WYVERN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dragon Monk, Ensei",
"Human",
"Narukami",
1,
7000,
"Narukami014",
CardIdentifier.DRAGON_MONK__ENSEI
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Red River Dragoon",
"Human",
"Narukami",
1,
8000,
"Narukami015",
CardIdentifier.RED_RIVER_DRAGOON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Fighter",
"Demon",
"Narukami",
1,
6000,
"Narukami016",
CardIdentifier.STEALTH_FIGHTER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lizard Soldier, Yowsh",
"Dragonman",
"Narukami",
1,
6000,
"Narukami017",
CardIdentifier.LIZARD_SOLDIER__YOWSH
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Spark Kid Dragoon",
"Human",
"Narukami",
1,
4000,
"Narukami018",
CardIdentifier.SPARK_KID_DRAGOON
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Dragon Dancer, Catharina",
"Human",
"Narukami",
1,
5000,
"Narukami019",
CardIdentifier.DRAGON_DANCER__CATHARINA
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Malevolent Djinn",
"Demon",
"Narukami",
1,
4000,
"Narukami020",
CardIdentifier.MALEVOLENT_DJINN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Moai the Great",
"Alien",
"Nova Grappler",
1,
10000,
"NovaGrappler047",
CardIdentifier.MOAI_THE_GREAT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Beast Deity, Black Tortoise",
"Battleroid",
"Nova Grappler",
1,
8000,
"NovaGrappler048",
CardIdentifier.BEAST_DEITY__BLACK_TORTOISE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Marvelous Hani",
"Alien",
"Nova Grappler",
1,
7000,
"NovaGrappler049",
CardIdentifier.MARVELOUS_HANI
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Almighty Reporter",
"Workeroid",
"Nova Grappler",
1,
6000,
"NovaGrappler050",
CardIdentifier.ALMIGHTY_REPORTER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Beast Deity, Scarlet Bird",
"Battleroid",
"Nova Grappler",
1,
6000,
"NovaGrappler051",
CardIdentifier.BEAST_DEITY__SCARLET_BIRD
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Red Card Dealer",
"Alien",
"Nova Grappler",
1,
5000,
"NovaGrappler052",
CardIdentifier.RED_CARD_DEALER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Greed Shade",
"Ghost",
"Granblue",
1,
8000,
"Granblue044",
CardIdentifier.GREED_SHADE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Coongal",
"High Beast",
"Gold Paladin",
1,
5000,
"GoldPaladin021",
CardIdentifier.COONGAL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Flag Knight, Laudine",
"Human",
"Gold Paladin",
1,
8000,
"GoldPaladin022",
CardIdentifier.BATTLE_FLAG_KNIGHT__LAUDINE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Satellitefall Dragon",
"Cosmo Dragon",
"Gold Paladin",
1,
10000,
"GoldPaladin023",
CardIdentifier.SATELLITEFALL_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dreadcharge Dragon",
"Thunder Dragon",
"Narukami",
1,
10000,
"Narukami021",
CardIdentifier.DREADCHARGE_DRAGON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Brightlance Dragoon",
"Human",
"Narukami",
1,
10000,
"Narukami022",
CardIdentifier.BRIGHTLANCE_DRAGOON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Rising Phoenix",
"High Beast",
"Narukami",
1,
5000,
"Narukami023",
CardIdentifier.RISING_PHOENIX
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Turboraizer",
"Battleroid",
"Nova Grappler",
1,
3000,
"NovaGrappler053",
CardIdentifier.TURBORAIZER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Muscle Hercules",
"Alien",
"Nova Grappler",
1,
10000,
"NovaGrappler054",
CardIdentifier.MUSCLE_HERCULES
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Kungfu Kid, Bolta",
"Battleroid",
"Nova Grappler",
1,
8000,
"NovaGrappler055",
CardIdentifier.KUNGFU_KID__BOLTA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Cup Bowler",
"Human",
"Nova Grappler",
1,
9000,
"NovaGrappler056",
CardIdentifier.CUP_BOWLER
));
		
		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"School Hunter, Leo-pald",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature005",
CardIdentifier.SCHOOL_HUNTER__LEO_PALD
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Guardian of Truth, Lox",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature006",
CardIdentifier.GUARDIAN_OF_TRUTH__LOX
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Binoculus Tiger",
"High Beast",
"Great Nature",
1,
9000,
"GreatNature007",
CardIdentifier.BINOCULUS_TIGER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Silver Thorn Dragon Tamer, Luquier",
"Elf",
"Pale Moon",
1,
10000,
"PaleMoon023",
CardIdentifier.SILVER_THORN_DRAGON_TAMER__LUQUIER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dark Lord of Abyss",
"Human",
"Dark Irregulars",
1,
11000,
"DarkIrregulars028",
CardIdentifier.DARK_LORD_OF_ABYSS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Emerald Witch, LaLa",
"Human",
"Oracle Think Tank",
1,
7000,
"OracleThinkTank036",
CardIdentifier.EMERALD_WITCH__LALA
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"White Hare in the Moon's Shadow, Pellinore",
"Human",
"Gold Paladin",
1,
10000,
"GoldPaladin024",
CardIdentifier.WHITE_HARE_IN_THE_MOON_____S_SHADOW__PELLINORE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Chief Nurse, Shamsiel",
"Angel",
"Angel Feather",
1,
10000,
"AngelFeather031",
CardIdentifier.CHIEF_NURSE__SHAMSIEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"School Dominator, Apt",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature008",
CardIdentifier.SCHOOL_DOMINATOR__APT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Lamp Camel",
"High Beast",
"Great Nature",
1,
9000,
"GreatNature009",
CardIdentifier.LAMP_CAMEL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Monoculus Tiger",
"High Beast",
"Great Nature",
1,
7000,
"GreatNature010",
CardIdentifier.MONOCULUS_TIGER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Cable Sheep",
"High Beast",
"Great Nature",
1,
6000,
"GreatNature011",
CardIdentifier.CABLE_SHEEP
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Sword Magician, Sarah",
"Human",
"Pale Moon",
1,
10000,
"PaleMoon024",
CardIdentifier.SWORD_MAGICIAN__SARAH
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Fire Breeze, Carrie",
"Elf",
"Pale Moon",
1,
9000,
"PaleMoon025",
CardIdentifier.FIRE_BREEZE__CARRIE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Peek-a-boo",
"Workeroid",
"Pale Moon",
1,
8000,
"PaleMoon026",
CardIdentifier.PEEK_A_BOO
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Magician of Quantum Mechanics",
"Demon",
"Pale Moon",
1,
6000,
"PaleMoon027",
CardIdentifier.MAGICIAN_OF_QUANTUM_MECHANICS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Blade Wing Reijy",
"Human",
"Dark Irregulars",
1,
10000,
"DarkIrregulars029",
CardIdentifier.BLADE_WING_REIJY
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Emblem Master",
"Human",
"Dark Irregulars",
1,
9000,
"DarkIrregulars030",
CardIdentifier.EMBLEM_MASTER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Yellow Bolt",
"Human",
"Dark Irregulars",
1,
7000,
"DarkIrregulars031",
CardIdentifier.YELLOW_BOLT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Listener of Truth, Dindrane",
"Human",
"Gold Paladin",
1,
6000,
"GoldPaladin025",
CardIdentifier.LISTENER_OF_TRUTH__DINDRANE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Pencil Hero, Hammsuke",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature012",
CardIdentifier.PENCIL_HERO__HAMMSUKE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dumbbell Kangaroo",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature013",
CardIdentifier.DUMBBELL_KANGAROO
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Magnet Crocodile",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature014",
CardIdentifier.MAGNET_CROCODILE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Law Official, Lox",
"High Beast",
"Great Nature",
1,
9000,
"GreatNature015",
CardIdentifier.LAW_OFFICIAL__LOX
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Pencil Squire, Hammsuke",
"High Beast",
"Great Nature",
1,
6000,
"GreatNature016",
CardIdentifier.PENCIL_SQUIRE__HAMMSUKE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Thermometer Giraffe",
"High Beast",
"Great Nature",
1,
6000,
"GreatNature017",
CardIdentifier.THERMOMETER_GIRAFFE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Tank Mouse",
"High Beast",
"Great Nature",
1,
6000,
"GreatNature018",
CardIdentifier.TANK_MOUSE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Flask Marmoset",
"High Beast",
"Great Nature",
1,
5000,
"GreatNature019",
CardIdentifier.FLASK_MARMOSET
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Midnight Invader",
"Chimera",
"Pale Moon",
1,
10000,
"PaleMoon028",
CardIdentifier.MIDNIGHT_INVADER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dancing Princess of the Night Sky",
"Elf",
"Pale Moon",
1,
8000,
"PaleMoon029",
CardIdentifier.DANCING_PRINCESS_OF_THE_NIGHT_SKY
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Bull's Eye, Mia",
"Warbeast",
"Pale Moon",
1,
7000,
"PaleMoon030",
CardIdentifier.BULL_____S_EYE__MIA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Purple Trapezist",
"Succubus",
"Pale Moon",
1,
6000,
"PaleMoon031",
CardIdentifier.PURPLE_TRAPEZIST
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Evil Eye Basilisk",
"Demon",
"Dark Irregulars",
1,
10000,
"DarkIrregulars032",
CardIdentifier.EVIL_EYE_BASILISK
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Hades Carriage of the Witching Hour",
"Demon",
"Dark Irregulars",
1,
8000,
"DarkIrregulars033",
CardIdentifier.HADES_CARRIAGE_OF_THE_WITCHING_HOUR
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Free Traveler",
"Human",
"Dark Irregulars",
1,
8000,
"DarkIrregulars034",
CardIdentifier.FREE_TRAVELER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Courting Succubus",
"Succubus",
"Dark Irregulars",
1,
7000,
"DarkIrregulars035",
CardIdentifier.COURTING_SUCCUBUS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Sky Witch, NaNa",
"Human",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank037",
CardIdentifier.SKY_WITCH__NANA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Sister, Glace",
"Human",
"Oracle Think Tank",
1,
8000,
"OracleThinkTank038",
CardIdentifier.BATTLE_SISTER__GLACE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Little Witch, LuLu",
"Human",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank039",
CardIdentifier.LITTLE_WITCH__LULU
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Photon Archer, Griflet",
"Giant",
"Gold Paladin",
1,
10000,
"GoldPaladin026",
CardIdentifier.PHOTON_ARCHER__GRIFLET
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Lop Ear Shooter",
"Human",
"Gold Paladin",
1,
9000,
"GoldPaladin027",
CardIdentifier.LOP_EAR_SHOOTER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Spring Breeze Messenger",
"Human",
"Gold Paladin",
1,
5000,
"GoldPaladin028",
CardIdentifier.SPRING_BREEZE_MESSENGER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Calculator Hippo",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature020",
CardIdentifier.CALCULATOR_HIPPO
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Schoolbag Sea Lion",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature021",
CardIdentifier.SCHOOLBAG_SEA_LION
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Red Pencil Rhino",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature022",
CardIdentifier.RED_PENCIL_RHINO
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Pencil Knight, Hammsuke",
"High Beast",
"Great Nature",
1,
8000,
"GreatNature023",
CardIdentifier.PENCIL_KNIGHT__HAMMSUKE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Globe Armadillo",
"High Beast",
"Great Nature",
1,
8000,
"GreatNature024",
CardIdentifier.GLOBE_ARMADILLO
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Explosion Scientist, Bunta",
"High Beast",
"Great Nature",
1,
8000,
"GreatNature025",
CardIdentifier.EXPLOSION_SCIENTIST__BUNTA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Multimeter Giraffe",
"High Beast",
"Great Nature",
1,
8000,
"GreatNature026",
CardIdentifier.MULTIMETER_GIRAFFE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Canvas Koala",
"High Beast",
"Great Nature",
1,
7000,
"GreatNature027",
CardIdentifier.CANVAS_KOALA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Thumbtack Fighter, Resanori",
"High Beast",
"Great Nature",
1,
7000,
"GreatNature028",
CardIdentifier.THUMBTACK_FIGHTER__RESANORI
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Tick Tock Flamingo",
"High Beast",
"Great Nature",
1,
7000,
"GreatNature029",
CardIdentifier.TICK_TOCK_FLAMINGO
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Bringer of Knowledge, Lox",
"High Beast",
"Great Nature",
1,
7000,
"GreatNature030",
CardIdentifier.BRINGER_OF_KNOWLEDGE__LOX
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Element Glider",
"High Beast",
"Great Nature",
1,
6000,
"GreatNature031",
CardIdentifier.ELEMENT_GLIDER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Failure Scientist, Ponkichi",
"High Beast",
"Great Nature",
1,
6000,
"GreatNature032",
CardIdentifier.FAILURE_SCIENTIST__PONKICHI
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Feather Penguin",
"High Beast",
"Great Nature",
1,
6000,
"GreatNature033",
CardIdentifier.FEATHER_PENGUIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Hula Hoop Capybara",
"High Beast",
"Great Nature",
1,
6000,
"GreatNature034",
CardIdentifier.HULA_HOOP_CAPYBARA
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Acorn Master",
"High Beast",
"Great Nature",
1,
4000,
"GreatNature035",
CardIdentifier.ACORN_MASTER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Schoolyard Prodigy, Lox",
"High Beast",
"Great Nature",
1,
4000,
"GreatNature036",
CardIdentifier.SCHOOLYARD_PRODIGY__LOX
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Triangle Cobra",
"High Beast",
"Great Nature",
1,
5000,
"GreatNature037",
CardIdentifier.TRIANGLE_COBRA
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Fortune-bringing Cat",
"High Beast",
"Great Nature",
1,
5000,
"GreatNature038",
CardIdentifier.FORTUNE_BRINGING_CAT
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Alarm Chicken",
"High Beast",
"Great Nature",
1,
5000,
"GreatNature039",
CardIdentifier.ALARM_CHICKEN
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Eraser Alpaca",
"High Beast",
"Great Nature",
1,
5000,
"GreatNature040",
CardIdentifier.ERASER_ALPACA
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Dictionary Goat",
"High Beast",
"Great Nature",
1,
5000,
"GreatNature041",
CardIdentifier.DICTIONARY_GOAT
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Ruler Chameleon",
"High Beast",
"Great Nature",
1,
3000,
"GreatNature042",
CardIdentifier.RULER_CHAMELEON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Nightmare Doll, Amy",
"Workeroid",
"Pale Moon",
1,
10000,
"PaleMoon032",
CardIdentifier.NIGHTMARE_DOLL__AMY
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dreamy Fortress",
"Chimera",
"Pale Moon",
1,
9000,
"PaleMoon033",
CardIdentifier.DREAMY_FORTRESS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"See-saw Game Loser",
"Giant",
"Pale Moon",
1,
8000,
"PaleMoon034",
CardIdentifier.SEE_SAW_GAME_LOSER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Drawing Dread",
"Giant",
"Pale Moon",
1,
7000,
"PaleMoon035",
CardIdentifier.DRAWING_DREAD
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Jumping Glenn",
"Elf",
"Pale Moon",
1,
7000,
"PaleMoon036",
CardIdentifier.JUMPING_GLENN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dreamy Ammonite",
"Chimera",
"Pale Moon",
1,
7000,
"PaleMoon037",
CardIdentifier.DREAMY_AMMONITE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"See-saw Game Winner",
"Goblin",
"Pale Moon",
1,
6000,
"PaleMoon038",
CardIdentifier.SEE_SAW_GAME_WINNER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Pinky Piggy",
"High Beast",
"Pale Moon",
1,
6000,
"PaleMoon039",
CardIdentifier.PINKY_PIGGY
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Girl Who Crossed the Gap",
"Elf",
"Pale Moon",
1,
5000,
"PaleMoon040",
CardIdentifier.GIRL_WHO_CROSSED_THE_GAP
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Innocent Magician",
"Human",
"Pale Moon",
1,
4000,
"PaleMoon041",
CardIdentifier.INNOCENT_MAGICIAN
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Flyer Flyer",
"Goblin",
"Pale Moon",
1,
5000,
"PaleMoon042",
CardIdentifier.FLYER_FLYER
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Cracker Musician",
"Workeroid",
"Pale Moon",
1,
5000,
"PaleMoon043",
CardIdentifier.CRACKER_MUSICIAN
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Popcorn Boy",
"Human",
"Pale Moon",
1,
5000,
"PaleMoon044",
CardIdentifier.POPCORN_BOY
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Poison Juggler",
"Goblin",
"Pale Moon",
1,
4000,
"PaleMoon045",
CardIdentifier.POISON_JUGGLER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Demon Chariot of the Witching Hour",
"Demon",
"Dark Irregulars",
1,
10000,
"DarkIrregulars036",
CardIdentifier.DEMON_CHARIOT_OF_THE_WITCHING_HOUR
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Beast in Hand",
"Elf",
"Dark Irregulars",
1,
8000,
"DarkIrregulars037",
CardIdentifier.BEAST_IN_HAND
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Cyber Beast",
"Demon",
"Dark Irregulars",
1,
7000,
"DarkIrregulars038",
CardIdentifier.CYBER_BEAST
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Demon Bike of the Witching Hour",
"Demon",
"Dark Irregulars",
1,
6000,
"DarkIrregulars039",
CardIdentifier.DEMON_BIKE_OF_THE_WITCHING_HOUR
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Beautiful Harpuia",
"Elf",
"Dark Irregulars",
1,
6000,
"DarkIrregulars040",
CardIdentifier.BEAUTIFUL_HARPUIA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Mirage Maker",
"Demon",
"Dark Irregulars",
1,
6000,
"DarkIrregulars041",
CardIdentifier.MIRAGE_MAKER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Rune Weaver",
"Human",
"Dark Irregulars",
1,
6000,
"DarkIrregulars042",
CardIdentifier.RUNE_WEAVER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Greedy Hand",
"Human",
"Dark Irregulars",
1,
5000,
"DarkIrregulars043",
CardIdentifier.GREEDY_HAND
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Devil in Shadow",
"Human",
"Dark Irregulars",
1,
4000,
"DarkIrregulars044",
CardIdentifier.DEVIL_IN_SHADOW
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Mad Hatter of Nightmareland",
"Human",
"Dark Irregulars",
1,
5000,
"DarkIrregulars045",
CardIdentifier.MAD_HATTER_OF_NIGHTMARELAND
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Hungry Egg of Nightmareland",
"Demon",
"Dark Irregulars",
1,
5000,
"DarkIrregulars046",
CardIdentifier.HUNGRY_EGG_OF_NIGHTMARELAND
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Cheshire Cat of Nightmareland",
"High Beast",
"Dark Irregulars",
1,
5000,
"DarkIrregulars047",
CardIdentifier.CHESHIRE_CAT_OF_NIGHTMARELAND
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Dark Knight of Nightmareland",
"Demon",
"Dark Irregulars",
1,
4000,
"DarkIrregulars048",
CardIdentifier.DARK_KNIGHT_OF_NIGHTMARELAND
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Battle Sister, Souffle",
"Elf",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank040",
CardIdentifier.BATTLE_SISTER__SOUFFLE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Oracle Guardian, Shisa",
"Battleroid",
"Oracle Think Tank",
1,
7000,
"OracleThinkTank041",
CardIdentifier.ORACLE_GUARDIAN__SHISA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Moonsault Swallow",
"High Beast",
"Oracle Think Tank",
1,
6000,
"OracleThinkTank042",
CardIdentifier.MOONSAULT_SWALLOW
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Battle Sister, Eclair",
"Elf",
"Oracle Think Tank",
1,
4000,
"OracleThinkTank043",
CardIdentifier.BATTLE_SISTER__ECLAIR
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Master of Pain",
"Elf",
"Gold Paladin",
1,
8000,
"GoldPaladin029",
CardIdentifier.MASTER_OF_PAIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Disciple of Pain",
"Elf",
"Gold Paladin",
1,
6000,
"GoldPaladin030",
CardIdentifier.DISCIPLE_OF_PAIN
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Speeder Hound",
"High Beast",
"Gold Paladin",
1,
5000,
"GoldPaladin031",
CardIdentifier.SPEEDER_HOUND
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Doctroid Megalos",
"Workeroid",
"Angel Feather",
1,
8000,
"AngelFeather032",
CardIdentifier.DOCTROID_MEGALOS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Doctroid Micros",
"Workeroid",
"Angel Feather",
1,
6000,
"AngelFeather033",
CardIdentifier.DOCTROID_MICROS
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Hope Child, Turiel",
"Angel",
"Angel Feather",
1,
5000,
"AngelFeather034",
CardIdentifier.HOPE_CHILD__TURIEL
));
		
		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Ultimate Dimensional Robo, Great Daiyusha",
"Battleroid",
"Dimension Police",
1,
11000,
"DimensionPolice027",
CardIdentifier.ULTIMATE_DIMENSIONAL_ROBO__GREAT_DAIYUSHA
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Galactic Beast, Zeal",
"Alien",
"Dimension Police",
1,
10000,
"DimensionPolice028",
CardIdentifier.GALACTIC_BEAST__ZEAL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Arboros Dragon, Sephirot",
"Forest Dragon",
"Neo Nectar",
1,
10000,
"NeoNectar023",
CardIdentifier.ARBOROS_DRAGON__SEPHIROT
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"White Lily Musketeer, Cecilia",
"Bioroid",
"Neo Nectar",
1,
10000,
"NeoNectar024",
CardIdentifier.WHITE_LILY_MUSKETEER__CECILIA
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Blue Storm Dragon, Maelstrom",
"Tear Dragon",
"Aqua Force",
1,
11000,
"AquaForce001",
CardIdentifier.BLUE_STORM_DRAGON__MAELSTROM
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Hydro Hurricane Dragon",
"Tear Dragon",
"Aqua Force",
1,
10000,
"AquaForce002",
CardIdentifier.HYDRO_HURRICANE_DRAGON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Storm Rider, Basil",
"Aquaroid",
"Aqua Force",
1,
8000,
"AquaForce003",
CardIdentifier.STORM_RIDER__BASIL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Sealed Demon Dragon, Dungaree",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami024",
CardIdentifier.SEALED_DEMON_DRAGON__DUNGAREE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Operator Girl, Mika",
"Human",
"Dimension Police",
1,
9000,
"DimensionPolice029",
CardIdentifier.OPERATOR_GIRL__MIKA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dimensional Robo, Daidragon",
"Battleroid",
"Dimension Police",
1,
9000,
"DimensionPolice030",
CardIdentifier.DIMENSIONAL_ROBO__DAIDRAGON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Cherry Blossom Musketeer, Augusto",
"Bioroid",
"Neo Nectar",
1,
9000,
"NeoNectar025",
CardIdentifier.CHERRY_BLOSSOM_MUSKETEER__AUGUSTO
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Lily of the Valley Musketeer, Kaivant",
"Bioroid",
"Neo Nectar",
1,
9000,
"NeoNectar026",
CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__KAIVANT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Maiden of Rainbow Wood",
"Dryad",
"Neo Nectar",
1,
9000,
"NeoNectar027",
CardIdentifier.MAIDEN_OF_RAINBOW_WOOD
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Water Lily Musketeer, Ruth",
"Bioroid",
"Neo Nectar",
1,
7000,
"NeoNectar028",
CardIdentifier.WATER_LILY_MUSKETEER__RUTH
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lily of the Valley Musketeer, Rebecca",
"Bioroid",
"Neo Nectar",
1,
7000,
"NeoNectar029",
CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__REBECCA
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Military Dragon, Raptor Colonel",
"Dinodragon",
"Tachikaze",
1,
10000,
"Tachikaze021",
CardIdentifier.MILITARY_DRAGON__RAPTOR_COLONEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Destruction Dragon, Dark Rex",
"Dinodragon",
"Tachikaze",
1,
10000,
"Tachikaze022",
CardIdentifier.DESTRUCTION_DRAGON__DARK_REX
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Tear Knight, Valeria",
"Aquaroid",
"Aqua Force",
1,
9000,
"AquaForce004",
CardIdentifier.TEAR_KNIGHT__VALERIA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Emerald Shield, Paschal",
"Aquaroid",
"Aqua Force",
1,
6000,
"AquaForce005",
CardIdentifier.EMERALD_SHIELD__PASCHAL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Armed Instructor, Bison",
"Warbeast",
"Great Nature",
1,
10000,
"GreatNature043",
CardIdentifier.ARMED_INSTRUCTOR__BISON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Enigman Cyclone",
"Alien",
"Dimension Police",
1,
10000,
"DimensionPolice031",
CardIdentifier.ENIGMAN_CYCLONE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Lady Justice",
"Alien",
"Dimension Police",
1,
10000,
"DimensionPolice032",
CardIdentifier.LADY_JUSTICE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Subterranean Beast, Magma Lord",
"Alien",
"Dimension Police",
1,
10000,
"DimensionPolice033",
CardIdentifier.SUBTERRANEAN_BEAST__MAGMA_LORD
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Devourer of Planets, Zeal",
"Alien",
"Dimension Police",
1,
9000,
"DimensionPolice034",
CardIdentifier.DEVOURER_OF_PLANETS__ZEAL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dimensional Robo, Dailander",
"Battleroid",
"Dimension Police",
1,
6000,
"DimensionPolice035",
CardIdentifier.DIMENSIONAL_ROBO__DAILANDER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Dimensional Robo, Goyusha",
"Battleroid",
"Dimension Police",
1,
5000,
"DimensionPolice036",
CardIdentifier.DIMENSIONAL_ROBO__GOYUSHA
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Larva Beast, Zeal",
"Alien",
"Dimension Police",
1,
4000,
"DimensionPolice037",
CardIdentifier.LARVA_BEAST__ZEAL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Arboros Dragon, Timber",
"Forest Dragon",
"Neo Nectar",
1,
9000,
"NeoNectar030",
CardIdentifier.ARBOROS_DRAGON__TIMBER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Arboros Dragon, Ratoon",
"Forest Dragon",
"Neo Nectar",
1,
4000,
"NeoNectar031",
CardIdentifier.ARBOROS_DRAGON__RATOON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Military Dragon, Raptor Captain",
"Dinodragon",
"Tachikaze",
1,
9000,
"Tachikaze023",
CardIdentifier.MILITARY_DRAGON__RAPTOR_CAPTAIN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Winged Dragon, Slashptero",
"Dinodragon",
"Tachikaze",
1,
9000,
"Tachikaze024",
CardIdentifier.WINGED_DRAGON__SLASHPTERO
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Assault Dragon, Pachyphalos",
"Dinodragon",
"Tachikaze",
1,
8000,
"Tachikaze025",
CardIdentifier.ASSAULT_DRAGON__PACHYPHALOS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Winged Dragon, Beamptero",
"Dinodragon",
"Tachikaze",
1,
7000,
"Tachikaze026",
CardIdentifier.WINGED_DRAGON__BEAMPTERO
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Military Dragon, Raptor Soldier",
"Dinodragon",
"Tachikaze",
1,
4000,
"Tachikaze027",
CardIdentifier.MILITARY_DRAGON__RAPTOR_SOLDIER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Storm Rider, Diamantes",
"Aquaroid",
"Aqua Force",
1,
9000,
"AquaForce006",
CardIdentifier.STORM_RIDER__DIAMANTES
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Tear Knight, Lazarus",
"Aquaroid",
"Aqua Force",
1,
10000,
"AquaForce007",
CardIdentifier.TEAR_KNIGHT__LAZARUS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Storm Rider, Eugen",
"Aquaroid",
"Aqua Force",
1,
6000,
"AquaForce008",
CardIdentifier.STORM_RIDER__EUGEN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Torpedo Rush Dragon",
"Tear Dragon",
"Aqua Force",
1,
6000,
"AquaForce009",
CardIdentifier.TORPEDO_RUSH_DRAGON
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Aqua Breath Dracokid",
"Tear Dragon",
"Aqua Force",
1,
5000,
"AquaForce010",
CardIdentifier.AQUA_BREATH_DRACOKID
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Thunder Spear Wielding Exorcist Knight",
"Human",
"Narukami",
1,
10000,
"Narukami025",
CardIdentifier.THUNDER_SPEAR_WIELDING_EXORCIST_KNIGHT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Compass Lion",
"High Beast",
"Great Nature",
1,
11000,
"GreatNature044",
CardIdentifier.COMPASS_LION
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Coiling Duckbill",
"High Beast",
"Great Nature",
1,
7000,
"GreatNature045",
CardIdentifier.COILING_DUCKBILL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Interdimensional Ninja, Tsukikage",
"Alien",
"Dimension Police",
1,
10000,
"DimensionPolice038",
CardIdentifier.INTERDIMENSIONAL_NINJA__TSUKIKAGE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Cosmic Mothership",
"Battleroid",
"Dimension Police",
1,
8000,
"DimensionPolice039",
CardIdentifier.COSMIC_MOTHERSHIP
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Cosmic Rider",
"Battleroid",
"Dimension Police",
1,
8000,
"DimensionPolice040",
CardIdentifier.COSMIC_RIDER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Assault Monster, Gunrock",
"Alien",
"Dimension Police",
1,
8000,
"DimensionPolice041",
CardIdentifier.ASSAULT_MONSTER__GUNROCK
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Eye of Destruction, Zeal",
"Alien",
"Dimension Police",
1,
7000,
"DimensionPolice042",
CardIdentifier.EYE_OF_DESTRUCTION__ZEAL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dimensional Robo, Daimariner",
"Battleroid",
"Dimension Police",
1,
7000,
"DimensionPolice043",
CardIdentifier.DIMENSIONAL_ROBO__DAIMARINER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Mysterious Navy Admiral, Gogoth",
"Alien",
"Dimension Police",
1,
6000,
"DimensionPolice044",
CardIdentifier.MYSTERIOUS_NAVY_ADMIRAL__GOGOTH
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Psychic Grey",
"Alien",
"Dimension Police",
1,
6000,
"DimensionPolice045",
CardIdentifier.PSYCHIC_GREY
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Speedster",
"Battleroid",
"Dimension Police",
1,
6000,
"DimensionPolice046",
CardIdentifier.SPEEDSTER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Fighting Saucer",
"Battleroid",
"Dimension Police",
1,
6000,
"DimensionPolice047",
CardIdentifier.FIGHTING_SAUCER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Warrior of Destiny, Dai",
"Human",
"Dimension Police",
1,
4000,
"DimensionPolice048",
CardIdentifier.WARRIOR_OF_DESTINY__DAI
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Gem Monster, Jewelmine",
"Alien",
"Dimension Police",
1,
5000,
"DimensionPolice049",
CardIdentifier.GEM_MONSTER__JEWELMINE
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Noise Monster, Decibelon",
"Alien",
"Dimension Police",
1,
5000,
"DimensionPolice050",
CardIdentifier.NOISE_MONSTER__DECIBELON
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Dissection Monster, Kaizon",
"Alien",
"Dimension Police",
1,
5000,
"DimensionPolice051",
CardIdentifier.DISSECTION_MONSTER__KAIZON
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Dimensional Robo, Daibattles",
"Battleroid",
"Dimension Police",
1,
4000,
"DimensionPolice052",
CardIdentifier.DIMENSIONAL_ROBO__DAIBATTLES
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Black Lily Musketeer, Hermann",
"Bioroid",
"Neo Nectar",
1,
10000,
"NeoNectar032",
CardIdentifier.BLACK_LILY_MUSKETEER__HERMANN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"World Snake, Ouroboros",
"High Beast",
"Neo Nectar",
1,
10000,
"NeoNectar033",
CardIdentifier.WORLD_SNAKE__OUROBOROS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Exploding Tomato",
"Dryad",
"Neo Nectar",
1,
9000,
"NeoNectar034",
CardIdentifier.EXPLODING_TOMATO
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"World Bearing Turtle, Ahkbara",
"High Beast",
"Neo Nectar",
1,
9000,
"NeoNectar035",
CardIdentifier.WORLD_BEARING_TURTLE__AHKBARA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Tulip Musketeer, Almira",
"Bioroid",
"Neo Nectar",
1,
8000,
"NeoNectar036",
CardIdentifier.TULIP_MUSKETEER__ALMIRA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Poison Mushroom",
"Dryad",
"Neo Nectar",
1,
7000,
"NeoNectar037",
CardIdentifier.POISON_MUSHROOM
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Arboros Dragon, Branch",
"Forest Dragon",
"Neo Nectar",
1,
7000,
"NeoNectar038",
CardIdentifier.ARBOROS_DRAGON__BRANCH
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Tulip Musketeer, Mina",
"Bioroid",
"Neo Nectar",
1,
6000,
"NeoNectar039",
CardIdentifier.TULIP_MUSKETEER__MINA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Boon Bana-na",
"Dryad",
"Neo Nectar",
1,
6000,
"NeoNectar040",
CardIdentifier.BOON_BANA_NA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Fruits Basket Elf",
"Elf",
"Neo Nectar",
1,
6000,
"NeoNectar041",
CardIdentifier.FRUITS_BASKET_ELF
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Broccolini Musketeer, Kirah",
"Bioroid",
"Neo Nectar",
1,
4000,
"NeoNectar042",
CardIdentifier.BROCCOLINI_MUSKETEER__KIRAH
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Night Queen Musketeer, Daniel",
"Bioroid",
"Neo Nectar",
1,
5000,
"NeoNectar043",
CardIdentifier.NIGHT_QUEEN_MUSKETEER__DANIEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Four Leaf Fairy",
"Sylph",
"Neo Nectar",
1,
5000,
"NeoNectar044",
CardIdentifier.FOUR_LEAF_FAIRY
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Maiden of Morning Glory",
"Dryad",
"Neo Nectar",
1,
5000,
"NeoNectar045",
CardIdentifier.MAIDEN_OF_MORNING_GLORY
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Hibiscus Musketeer, Hanah",
"Bioroid",
"Neo Nectar",
1,
5000,
"NeoNectar046",
CardIdentifier.HIBISCUS_MUSKETEER__HANAH
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Savage War Chief",
"Human",
"Tachikaze",
1,
10000,
"Tachikaze028",
CardIdentifier.SAVAGE_WAR_CHIEF
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Citadel Dragon, Brachiocastle",
"Dinodragon",
"Tachikaze",
1,
9000,
"Tachikaze029",
CardIdentifier.CITADEL_DRAGON__BRACHIOCASTLE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Savage Warlock",
"Human",
"Tachikaze",
1,
8000,
"Tachikaze030",
CardIdentifier.SAVAGE_WARLOCK
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Carrier Dragon, Brachiocarrier",
"Dinodragon",
"Tachikaze",
1,
7000,
"Tachikaze031",
CardIdentifier.CARRIER_DRAGON__BRACHIOCARRIER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Military Dragon, Raptor Sergeant",
"Dinodragon",
"Tachikaze",
1,
7000,
"Tachikaze032",
CardIdentifier.MILITARY_DRAGON__RAPTOR_SERGEANT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Savage Magus",
"Human",
"Tachikaze",
1,
6000,
"Tachikaze033",
CardIdentifier.SAVAGE_MAGUS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Fortress Ammonite",
"High Beast",
"Tachikaze",
1,
6000,
"Tachikaze034",
CardIdentifier.FORTRESS_AMMONITE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Transport Dragon, Brachioporter",
"Dinodragon",
"Tachikaze",
1,
5000,
"Tachikaze035",
CardIdentifier.TRANSPORT_DRAGON__BRACHIOPORTER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Baby Ptero",
"Dinodragon",
"Tachikaze",
1,
4000,
"Tachikaze036",
CardIdentifier.BABY_PTERO
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Dragon Bird, Firepteryx",
"Dinodragon",
"Tachikaze",
1,
5000,
"Tachikaze037",
CardIdentifier.DRAGON_BIRD__FIREPTERYX
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Carry Trilobite",
"Insect",
"Tachikaze",
1,
5000,
"Tachikaze038",
CardIdentifier.CARRY_TRILOBITE
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Matriarch's Bombardment Beast",
"High Beast",
"Tachikaze",
1,
5000,
"Tachikaze039",
CardIdentifier.MATRIARCH_____S_BOMBARDMENT_BEAST
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Ironclad Dragon, Steelsaurus",
"Dinodragon",
"Tachikaze",
1,
5000,
"Tachikaze040",
CardIdentifier.IRONCLAD_DRAGON__STEELSAURUS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Titan of the Pyroxene Mine",
"Battleroid",
"Aqua Force",
1,
10000,
"AquaForce011",
CardIdentifier.TITAN_OF_THE_PYROXENE_MINE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Distant Sea Advisor, Vassilis",
"Aquaroid",
"Aqua Force",
1,
10000,
"AquaForce012",
CardIdentifier.DISTANT_SEA_ADVISOR__VASSILIS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Veteran Strategic Commander",
"Aquaroid",
"Aqua Force",
1,
8000,
"AquaForce013",
CardIdentifier.VETERAN_STRATEGIC_COMMANDER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Whale Supply Fleet, Kairin Maru",
"High Beast",
"Aqua Force",
1,
7000,
"AquaForce014",
CardIdentifier.WHALE_SUPPLY_FLEET__KAIRIN_MARU
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Tear Knight, Theo",
"Aquaroid",
"Aqua Force",
1,
8000,
"AquaForce015",
CardIdentifier.TEAR_KNIGHT__THEO
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stream Trooper",
"Aquaroid",
"Aqua Force",
1,
6000,
"AquaForce016",
CardIdentifier.STREAM_TROOPER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Reliable Strategic Commander",
"Aquaroid",
"Aqua Force",
1,
6000,
"AquaForce017",
CardIdentifier.RELIABLE_STRATEGIC_COMMANDER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Officer Cadet, Erikk",
"Aquaroid",
"Aqua Force",
1,
4000,
"AquaForce018",
CardIdentifier.OFFICER_CADET__ERIKK
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Mothership Intelligence",
"Workeroid",
"Aqua Force",
1,
5000,
"AquaForce019",
CardIdentifier.MOTHERSHIP_INTELLIGENCE
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Enemy Seeking Seagull Soldier",
"High Beast",
"Aqua Force",
1,
5000,
"AquaForce020",
CardIdentifier.ENEMY_SEEKING_SEAGULL_SOLDIER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Black Celestial Maiden, Kali",
"Noble",
"Narukami",
1,
10000,
"Narukami026",
CardIdentifier.BLACK_CELESTIAL_MAIDEN__KALI
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dragon Monk, Kinkaku",
"Demon",
"Narukami",
1,
8000,
"Narukami027",
CardIdentifier.DRAGON_MONK__KINKAKU
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lightning Sword Wielding Exorcist Knight",
"Human",
"Narukami",
1,
8000,
"Narukami028",
CardIdentifier.LIGHTNING_SWORD_WIELDING_EXORCIST_KNIGHT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dragon Monk, Ginkaku",
"Demon",
"Narukami",
1,
6000,
"Narukami029",
CardIdentifier.DRAGON_MONK__GINKAKU
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Exorcist Mage, Koh Koh",
"Human",
"Narukami",
1,
3000,
"Narukami030",
CardIdentifier.EXORCIST_MAGE__KOH_KOH
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Mischievous Girl, Kyon-she",
"Zombie",
"Narukami",
1,
5000,
"Narukami031",
CardIdentifier.MISCHIEVOUS_GIRL__KYON_SHE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Blackboard Parrot",
"High Beast",
"Great Nature",
1,
5000,
"GreatNature046",
CardIdentifier.BLACKBOARD_PARROT
));
		
		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Covert Demonic Dragon, Magatsu Storm",
"Abyss Dragon",
"Murakumo",
1,
10000,
"Murakumo019",
CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Blue Storm Supreme Dragon, Glory Maelstrom",
"Tear Dragon",
"Aqua Force",
1,
11000,
"AquaForce021",
CardIdentifier.BLUE_STORM_SUPREME_DRAGON__GLORY_MAELSTROM
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Goddess of the Sun, Amaterasu",
"Noble",
"Oracle Think Tank",
1,
11000,
"OracleThinkTank044",
CardIdentifier.GODDESS_OF_THE_SUN__AMATERASU
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Ultra Beast Deity, Illuminal Dragon",
"Battleroid",
"Nova Grappler",
1,
11000,
"NovaGrappler057",
CardIdentifier.ULTRA_BEAST_DEITY__ILLUMINAL_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Crimson Impact, Metatron",
"Angel",
"Angel Feather",
1,
10000,
"AngelFeather035",
CardIdentifier.CRIMSON_IMPACT__METATRON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Blazing Lion, Platina Ezel",
"Human",
"Gold Paladin",
1,
11000,
"GoldPaladin032",
CardIdentifier.BLAZING_LION__PLATINA_EZEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Conviction Dragon, Chromejailer Dragon",
"Abyss Dragon",
"Gold Paladin",
1,
10000,
"GoldPaladin033",
CardIdentifier.CONVICTION_DRAGON__CHROMEJAILER_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dragonic Kaiser Vermillion THE BLOOD",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami032",
CardIdentifier.DRAGONIC_KAISER_VERMILLION______THE_BLOOD_____
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Fantasy Petal Storm, Shirayuki",
"Ghost",
"Murakumo",
1,
11000,
"Murakumo020",
CardIdentifier.FANTASY_PETAL_STORM__SHIRAYUKI
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Platinum Blond Fox Spirit, Tamamo",
"High Beast",
"Murakumo",
1,
10000,
"Murakumo021",
CardIdentifier.PLATINUM_BLOND_FOX_SPIRIT__TAMAMO
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Tri-stinger Dragon",
"Tear Dragon",
"Aqua Force",
1,
10000,
"AquaForce022",
CardIdentifier.TRI_STINGER_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Battle Sister, Cookie",
"Elf",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank045",
CardIdentifier.BATTLE_SISTER__COOKIE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Battler of the Twin Brush, Polaris",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature047",
CardIdentifier.BATTLER_OF_THE_TWIN_BRUSH__POLARIS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Lord of the Demonic Winds, Vayu",
"Noble",
"Narukami",
1,
10000,
"Narukami033",
CardIdentifier.LORD_OF_THE_DEMONIC_WINDS__VAYU
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Starlight Melody Tamer, Farah",
"Warbeast",
"Pale Moon",
1,
11000,
"PaleMoon046",
CardIdentifier.STARLIGHT_MELODY_TAMER__FARAH
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Nightmare Summoner, Raqiel",
"Elf",
"Pale Moon",
1,
10000,
"PaleMoon047",
CardIdentifier.NIGHTMARE_SUMMONER__RAQIEL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Blaster Blade Spirit",
"Human",
"Royal Paladin",
1,
10000,
"RoyalPaladin040",
CardIdentifier.BLASTER_BLADE_SPIRIT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Blaster Dark Spirit",
"Human",
"Shadow Paladin",
1,
10000,
"ShadowPaladin056",
CardIdentifier.BLASTER_DARK_SPIRIT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Stealth Dragon, Magatsu Gale",
"Abyss Dragon",
"Murakumo",
1,
9000,
"Murakumo022",
CardIdentifier.STEALTH_DRAGON__MAGATSU_GALE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Fiend, Oboro Cart",
"Demon",
"Murakumo",
1,
6000,
"Murakumo023",
CardIdentifier.STEALTH_FIEND__OBORO_CART
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Stealth Dragon, Magatsu Wind",
"Abyss Dragon",
"Murakumo",
1,
4000,
"Murakumo024",
CardIdentifier.STEALTH_DRAGON__MAGATSU_WIND
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Storm Rider, Lysander",
"Aquaroid",
"Aqua Force",
1,
10000,
"AquaForce023",
CardIdentifier.STORM_RIDER__LYSANDER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Storm Rider, Damon",
"Aquaroid",
"Aqua Force",
1,
9000,
"AquaForce024",
CardIdentifier.STORM_RIDER__DAMON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Siren, Theresa",
"Mermaid",
"Aqua Force",
1,
8000,
"AquaForce025",
CardIdentifier.BATTLE_SIREN__THERESA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Storm Rider, Nicolas",
"Aquaroid",
"Aqua Force",
1,
7000,
"AquaForce026",
CardIdentifier.STORM_RIDER__NICOLAS
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Tri-holl Dracokid",
"Tear Dragon",
"Aqua Force",
1,
5000,
"AquaForce027",
CardIdentifier.TRI_HOLL_DRACOKID
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Deity, Susanoo",
"Noble",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank046",
CardIdentifier.BATTLE_DEITY__SUSANOO
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Maiden, Sayorihime",
"Noble",
"Oracle Think Tank",
1,
7000,
"OracleThinkTank047",
CardIdentifier.BATTLE_MAIDEN__SAYORIHIME
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Beast Deity, Yamatano Drake",
"Battleroid",
"Nova Grappler",
1,
10000,
"NovaGrappler058",
CardIdentifier.BEAST_DEITY__YAMATANO_DRAKE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Hollow Nomad",
"Alien",
"Nova Grappler",
1,
10000,
"NovaGrappler059",
CardIdentifier.HOLLOW_NOMAD
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Beast Deity, Golden Anglet",
"Battleroid",
"Nova Grappler",
1,
9000,
"NovaGrappler060",
CardIdentifier.BEAST_DEITY__GOLDEN_ANGLET
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Beast Deity, Blank Marsh",
"Battleroid",
"Nova Grappler",
1,
7000,
"NovaGrappler061",
CardIdentifier.BEAST_DEITY__BLANK_MARSH
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Mobile Hospital, Elysium",
"Golem",
"Angel Feather",
1,
10000,
"AngelFeather036",
CardIdentifier.MOBILE_HOSPITAL__ELYSIUM
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Passion, Bagdemagus",
"Human",
"Gold Paladin",
1,
9000,
"GoldPaladin035",
CardIdentifier.KNIGHT_OF_PASSION__BAGDEMAGUS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Advance of the Black Chains, Kahedin",
"Human",
"Gold Paladin",
1,
7000,
"GoldPaladin036",
CardIdentifier.ADVANCE_OF_THE_BLACK_CHAINS__KAHEDIN
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Dreaming Sage, Corron",
"Giant",
"Gold Paladin",
1,
5000,
"GoldPaladin037",
CardIdentifier.DREAMING_SAGE__CORRON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dusty Plasma Dragon",
"Thunder Dragon",
"Narukami",
1,
9000,
"Narukami035",
CardIdentifier.DUSTY_PLASMA_DRAGON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Exorcist Demonic Dragon, Indigo",
"Thunder Dragon",
"Narukami",
1,
6000,
"Narukami036",
CardIdentifier.EXORCIST_DEMONIC_DRAGON__INDIGO
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Barking Wyvern",
"Winged Dragon",
"Pale Moon",
1,
10000,
"PaleMoon048",
CardIdentifier.BARKING_WYVERN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Fire Juggler",
"Human",
"Pale Moon",
1,
7000,
"PaleMoon049",
CardIdentifier.FIRE_JUGGLER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Spiked Club Stealth Rogue, Arahabaki",
"Demon",
"Murakumo",
1,
10000,
"Murakumo025",
CardIdentifier.SPIKED_CLUB_STEALTH_ROGUE__ARAHABAKI
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Stealth Beast, Gigantoad",
"High Beast",
"Murakumo",
1,
10000,
"Murakumo026",
CardIdentifier.STEALTH_BEAST__GIGANTOAD
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Stealth Dragon, Royale Nova",
"Abyss Dragon",
"Murakumo",
1,
10000,
"Murakumo027",
CardIdentifier.STEALTH_DRAGON__ROYALE_NOVA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Stealth Beast, Spell Hound",
"Warbeast",
"Murakumo",
1,
8000,
"Murakumo028",
CardIdentifier.STEALTH_BEAST__SPELL_HOUND
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Rogue of Summoning, Jiraiya",
"Demon",
"Murakumo",
1,
7000,
"Murakumo029",
CardIdentifier.STEALTH_ROGUE_OF_SUMMONING__JIRAIYA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Dragon, Magatsu Breath",
"Abyss Dragon",
"Murakumo",
1,
7000,
"Murakumo030",
CardIdentifier.STEALTH_DRAGON__MAGATSU_BREATH
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Beast, Night Panther",
"Warbeast",
"Murakumo",
1,
7000,
"Murakumo031",
CardIdentifier.STEALTH_BEAST__NIGHT_PANTHER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stealth Beast, Flame Fox",
"High Beast",
"Murakumo",
1,
6000,
"Murakumo032",
CardIdentifier.STEALTH_BEAST__FLAME_FOX
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Stealth Rogue of Body Replacement, Kokuenmaru",
"Demon",
"Murakumo",
1,
4000,
"Murakumo033",
CardIdentifier.STEALTH_ROGUE_OF_BODY_REPLACEMENT__KOKUENMARU
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Fox Tamer, Izuna",
"Human",
"Murakumo",
1,
5000,
"Murakumo034",
CardIdentifier.FOX_TAMER__IZUNA
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Stealth Fiend, Monster Lantern",
"Ghost",
"Murakumo",
1,
5000,
"Murakumo035",
CardIdentifier.STEALTH_FIEND__MONSTER_LANTERN
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Stealth Fiend, Rokuro Lady",
"Ghost",
"Murakumo",
1,
5000,
"Murakumo036",
CardIdentifier.STEALTH_FIEND__ROKURO_LADY
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Stealth Fiend, Karakasa Spirit",
"Ghost",
"Murakumo",
1,
5000,
"Murakumo037",
CardIdentifier.STEALTH_FIEND__KARAKASA_SPIRIT
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Stealth Fiend, River Child",
"Gillman",
"Murakumo",
1,
5000,
"Murakumo038",
CardIdentifier.STEALTH_FIEND__RIVER_CHILD
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Stealth Beast, Cat Devil",
"Warbeast",
"Murakumo",
1,
4000,
"Murakumo039",
CardIdentifier.STEALTH_BEAST__CAT_DEVIL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Deck Sweeper",
"Aquaroid",
"Aqua Force",
1,
4000,
"AquaForce028",
CardIdentifier.DECK_SWEEPER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Light Signals Penguin Soldier",
"High Beast",
"Aqua Force",
1,
5000,
"AquaForce029",
CardIdentifier.LIGHT_SIGNALS_PENGUIN_SOLDIER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Officer Cadet, Astraea",
"Aquaroid",
"Aqua Force",
1,
4000,
"AquaForce030",
CardIdentifier.OFFICER_CADET__ASTRAEA
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Pyroxene Beam Blue Dragon Soldier",
"Dragonman",
"Aqua Force",
1,
5000,
"AquaForce031",
CardIdentifier.PYROXENE_BEAM_BLUE_DRAGON_SOLDIER
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Supersonic Sailor",
"Aquaroid",
"Aqua Force",
1,
4000,
"AquaForce032",
CardIdentifier.SUPERSONIC_SAILOR
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Gentle Jimm",
"Ghost",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank048",
CardIdentifier.GENTLE_JIMM
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Oracle Guardian, Sphinx",
"Battleroid",
"Oracle Think Tank",
1,
8000,
"OracleThinkTank049",
CardIdentifier.ORACLE_GUARDIAN__SPHINX
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Rock Witch, GaGa",
"Human",
"Oracle Think Tank",
1,
7000,
"OracleThinkTank050",
CardIdentifier.ROCK_WITCH__GAGA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Sister, Cream",
"Elf",
"Oracle Think Tank",
1,
6000,
"OracleThinkTank051",
CardIdentifier.BATTLE_SISTER__CREAM
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Machine-gun Talk, Ryan",
"Ghost",
"Oracle Think Tank",
1,
6000,
"OracleThinkTank052",
CardIdentifier.MACHINE_GUN_TALK__RYAN
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Solar Maiden, Uzume",
"Noble",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank053",
CardIdentifier.SOLAR_MAIDEN__UZUME
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Supple Bamboo Princess, Kaguya",
"Noble",
"Oracle Think Tank",
1,
4000,
"OracleThinkTank054",
CardIdentifier.SUPPLE_BAMBOO_PRINCESS__KAGUYA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Heroic Hani",
"Battleroid",
"Nova Grappler",
1,
8000,
"NovaGrappler062",
CardIdentifier.HEROIC_HANI
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Transraizer",
"Battleroid",
"Nova Grappler",
1,
7000,
"NovaGrappler063",
CardIdentifier.TRANSRAIZER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Burstraizer",
"Battleroid",
"Nova Grappler",
1,
7000,
"NovaGrappler064",
CardIdentifier.BURSTRAIZER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stoic Hani",
"Alien",
"Nova Grappler",
1,
6000,
"NovaGrappler065",
CardIdentifier.STOIC_HANI
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Transmigrating Evolution, Miraioh",
"Battleroid",
"Nova Grappler",
1,
4000,
"NovaGrappler066",
CardIdentifier.TRANSMIGRATING_EVOLUTION__MIRAIOH
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Lionet Heat",
"Warbeast",
"Nova Grappler",
1,
4000,
"NovaGrappler067",
CardIdentifier.LIONET_HEAT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Crimson Drive, Aphrodite",
"Angel",
"Angel Feather",
1,
9000,
"AngelFeather037",
CardIdentifier.CRIMSON_DRIVE__APHRODITE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Examine Angel",
"Angel",
"Angel Feather",
1,
7000,
"AngelFeather038",
CardIdentifier.EXAMINE_ANGEL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Crimson Mind, Baruch",
"Angel",
"Angel Feather",
1,
7000,
"AngelFeather039",
CardIdentifier.CRIMSON_MIND__BARUCH
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Emergency Vehicle",
"Workeroid",
"Angel Feather",
1,
6000,
"AngelFeather040",
CardIdentifier.EMERGENCY_VEHICLE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Candlelight Angel",
"Angel",
"Angel Feather",
1,
6000,
"AngelFeather041",
CardIdentifier.CANDLELIGHT_ANGEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Crimson Heart, Nahas",
"Angel",
"Angel Feather",
1,
5000,
"AngelFeather042",
CardIdentifier.CRIMSON_HEART__NAHAS
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Rampage Cart Angel",
"Angel",
"Angel Feather",
1,
5000,
"AngelFeather043",
CardIdentifier.RAMPAGE_CART_ANGEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Fever Therapy Nurse",
"Angel",
"Angel Feather",
1,
4000,
"AngelFeather044",
CardIdentifier.FEVER_THERAPY_NURSE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Vocal Chicken",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature048",
CardIdentifier.VOCAL_CHICKEN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
0,
"Melodica Cat",
"High Beast",
"Great Nature",
1,
9000,
"GreatNature049",
CardIdentifier.MELODICA_CAT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Parabola Moose",
"High Beast",
"Great Nature",
1,
8000,
"GreatNature050",
CardIdentifier.PARABOLA_MOOSE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Barcode Zebra",
"High Beast",
"Great Nature",
1,
7000,
"GreatNature051",
CardIdentifier.BARCODE_ZEBRA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Recorder Dog",
"High Beast",
"Great Nature",
1,
7000,
"GreatNature052",
CardIdentifier.RECORDER_DOG
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Sharpener Beaver",
"High Beast",
"Great Nature",
1,
6000,
"GreatNature053",
CardIdentifier.SHARPENER_BEAVER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Protractor Peacock",
"High Beast",
"Great Nature",
1,
6000,
"GreatNature054",
CardIdentifier.PROTRACTOR_PEACOCK
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Gardening Mole",
"High Beast",
"Great Nature",
1,
5000,
"GreatNature055",
CardIdentifier.GARDENING_MOLE
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Castanet Donkey",
"High Beast",
"Great Nature",
1,
4000,
"GreatNature056",
CardIdentifier.CASTANET_DONKEY
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Holy Mage of the Gale",
"Human",
"Gold Paladin",
1,
6000,
"GoldPaladin038",
CardIdentifier.HOLY_MAGE_OF_THE_GALE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Stronghold of the Black Chains, Hoel",
"Human",
"Gold Paladin",
1,
4000,
"GoldPaladin039",
CardIdentifier.STRONGHOLD_OF_THE_BLACK_CHAINS__HOEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Dantegal",
"High Beast",
"Gold Paladin",
1,
5000,
"GoldPaladin040",
CardIdentifier.DANTEGAL
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Runebau",
"High Beast",
"Gold Paladin",
1,
4000,
"GoldPaladin041",
CardIdentifier.RUNEBAU
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Exorcist Mage, Roh Roh",
"Human",
"Narukami",
1,
7000,
"Narukami037",
CardIdentifier.EXORCIST_MAGE__ROH_ROH
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Deity Sealing Kid, Soh Koh",
"Demon",
"Narukami",
1,
6000,
"Narukami038",
CardIdentifier.DEITY_SEALING_KID__SOH_KOH
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Spark Edge Dracokid",
"Thunder Dragon",
"Narukami",
1,
5000,
"Narukami039",
CardIdentifier.SPARK_EDGE_DRACOKID
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Exorcist Mage, Lin Lin",
"Human",
"Narukami",
1,
4000,
"Narukami040",
CardIdentifier.EXORCIST_MAGE__LIN_LIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Magical Partner",
"Elf",
"Pale Moon",
1,
6000,
"PaleMoon050",
CardIdentifier.MAGICAL_PARTNER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Smiling Presenter",
"Human",
"Pale Moon",
1,
5000,
"PaleMoon051",
CardIdentifier.SMILING_PRESENTER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Pure Heart Jewel Knight, Ashlei",
"Elf",
"Royal Paladin",
1,
11000,
"RoyalPaladin041",
CardIdentifier.PURE_HEART_JEWEL_KNIGHT__ASHLEY
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Leading Jewel Knight, Salome",
"Elf",
"Royal Paladin",
1,
10000,
"RoyalPaladin042",
CardIdentifier.LEADING_JEWEL_KNIGHT__SALOME
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Liberator of the Round Table, Alfred",
"Human",
"Gold Paladin",
1,
11000,
"GoldPaladin042",
CardIdentifier.LIBERATOR_OF_THE_ROUND_TABLE__ALFRED
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Oracle Queen, Himiko",
"Noble",
"Genesis",
1,
11000,
"Genesis001",
CardIdentifier.ORACLE_QUEEN__HIMIKO
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Eternal Goddess, Iwanagahime",
"Noble",
"Genesis",
1,
11000,
"Genesis002",
CardIdentifier.ETERNAL_GODDESS__IWANAGAHIME
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Eradicator, Dragonic Descendant",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami041",
CardIdentifier.ERADICATOR__DRAGONIC_DESCENDANT
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Eradicator, Gauntlet Buster Dragon",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami042",
CardIdentifier.ERADICATOR__GAUNTLET_BUSTER_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Beast Deity, Ethics Buster",
"Battleroid",
"Nova Grappler",
1,
11000,
"NovaGrappler068",
CardIdentifier.BEAST_DEITY__ETHICS_BUSTER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dogmatize Jewel Knight, Sybill",
"Giant",
"Royal Paladin",
1,
8000,
"RoyalPaladin043",
CardIdentifier.DOGMATIZE_JEWEL_KNIGHT__SYBILL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Flashing Jewel Knight, Iseult",
"Human",
"Royal Paladin",
1,
6000,
"RoyalPaladin044",
CardIdentifier.FLASHING_JEWEL_KNIGHT__ISEULT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Halo Liberator, Mark",
"Human",
"Gold Paladin",
1,
6000,
"GoldPaladin043",
CardIdentifier.HALO_LIBERATOR__MARK
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Liberator of the Flute, Escrad",
"Human",
"Gold Paladin",
1,
9000,
"GoldPaladin044",
CardIdentifier.LIBERATOR_OF_THE_FLUTE__ESCRAD
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Battle Deity of the Night, Artemis",
"Noble",
"Genesis",
1,
10000,
"Genesis003",
CardIdentifier.BATTLE_DEITY_OF_THE_NIGHT__ARTEMIS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Broom Witch, Caraway",
"Human",
"Genesis",
1,
9000,
"Genesis004",
CardIdentifier.BROOM_WITCH__CARAWAY
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Goddess of Self-sacrifice, Kushinada",
"Noble",
"Genesis",
1,
6000,
"Genesis005",
CardIdentifier.GODDESS_OF_SELF_SACRIFICE__KUSHINADA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Supreme Army Eradicator, Zuitan",
"Human",
"Narukami",
1,
9000,
"Narukami043",
CardIdentifier.SUPREME_ARMY_ERADICATOR__ZUITAN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Eradicator Wyvern Guard, Guld",
"Winged Dragon",
"Narukami",
1,
6000,
"Narukami044",
CardIdentifier.ERADICATOR_WYVERN_GUARD__GULD
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Grateful Catapult",
"Ogre",
"Spike Brothers",
1,
11000,
"SpikeBrothers020",
CardIdentifier.GRATEFUL_CATAPULT
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Bad End Dragger",
"Demon",
"Spike Brothers",
1,
11000,
"SpikeBrothers021",
CardIdentifier.BAD_END_DRAGGER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dignified Silver Dragon",
"Cosmo Dragon",
"Royal Paladin",
1,
10000,
"RoyalPaladin045",
CardIdentifier.DIGNIFIED_SILVER_DRAGON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Fellowship Jewel Knight, Tracie",
"Elf",
"Royal Paladin",
1,
9000,
"RoyalPaladin046",
CardIdentifier.FELLOWSHIP_JEWEL_KNIGHT__TRACIE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Jewel Knight, Prizme",
"High Beast",
"Royal Paladin",
1,
7000,
"RoyalPaladin047",
CardIdentifier.JEWEL_KNIGHT__PRIZME
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Dreaming Jewel Knight, Tiffany",
"Elf",
"Royal Paladin",
1,
5000,
"RoyalPaladin048",
CardIdentifier.DREAMING_JEWEL_KNIGHT__TIFFANY
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Curved Blade Liberator, Josephus",
"Human",
"Gold Paladin",
1,
7000,
"GoldPaladin045",
CardIdentifier.CURVED_BLADE_LIBERATOR__JOSEPHUS
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Wingal Liberator",
"High Beast",
"Gold Paladin",
1,
5000,
"GoldPaladin046",
CardIdentifier.WINGAL_LIBERATOR
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Witch of Wolves, Saffron",
"Human",
"Genesis",
1,
10000,
"Genesis006",
CardIdentifier.WITCH_OF_WOLVES__SAFFRON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Maiden, Izunahime",
"Noble",
"Genesis",
1,
10000,
"Genesis007",
CardIdentifier.BATTLE_MAIDEN__IZUNAHIME
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Maiden, Sahohime",
"Noble",
"Genesis",
1,
9000,
"Genesis008",
CardIdentifier.BATTLE_MAIDEN__SAHOHIME
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Twilight Hunter, Artemis",
"Noble",
"Genesis",
1,
9000,
"Genesis009",
CardIdentifier.TWILIGHT_HUNTER__ARTEMIS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Maiden, Tatsutahime",
"Noble",
"Genesis",
1,
7000,
"Genesis010",
CardIdentifier.BATTLE_MAIDEN__TATSUTAHIME
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Battle Maiden, Tamayorihime",
"Noble",
"Genesis",
1,
5000,
"Genesis011",
CardIdentifier.BATTLE_MAIDEN__TAMAYORIHIME
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Aiming for the Stars, Artemis",
"Noble",
"Genesis",
1,
4000,
"Genesis012",
CardIdentifier.AIMING_FOR_THE_STARS__ARTEMIS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Martial Arts General, Daimu",
"Human",
"Narukami",
1,
10000,
"Narukami045",
CardIdentifier.MARTIAL_ARTS_GENERAL__DAIMU
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Twin Gun Eradicator, Hakushou",
"Human",
"Narukami",
1,
9000,
"Narukami046",
CardIdentifier.TWIN_GUN_ERADICATOR__HAKUSHOU
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Eradicator, Saucer Cannon Wyvern",
"Winged Dragon",
"Narukami",
1,
8000,
"Narukami047",
CardIdentifier.ERADICATOR__SAUCER_CANNON_WYVERN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Eradicator of the Ceremonial Bonfire, Castor",
"Elf",
"Narukami",
1,
7000,
"Narukami048",
CardIdentifier.ERADICATOR_OF_THE_CEREMONIAL_BONFIRE__CASTOR
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Ambush Dragon Eradicator, Linchu",
"Human",
"Narukami",
1,
5000,
"Narukami049",
CardIdentifier.AMBUSH_DRAGON_ERADICATOR__LINCHU
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Armored Heavy Gunner",
"Battleroid",
"Nova Grappler",
1,
10000,
"NovaGrappler069",
CardIdentifier.ARMORED_HEAVY_GUNNER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Beast Deity, Hatred Chaos",
"Battleroid",
"Nova Grappler",
1,
9000,
"NovaGrappler070",
CardIdentifier.BEAST_DEITY__HATRED_CHAOS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Rabbit House",
"Golem",
"Spike Brothers",
1,
10000,
"SpikeBrothers023",
CardIdentifier.RABBIT_HOUSE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dudley Mason",
"Giant",
"Spike Brothers",
1,
9000,
"SpikeBrothers024",
CardIdentifier.DUDLEY_MASON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Knight of Explosive Axe, Gorneman",
"Human",
"Royal Paladin",
1,
10000,
"RoyalPaladin049",
CardIdentifier.KNIGHT_OF_EXPLOSIVE_AXE__GORNEMAN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Uncompromising Knight, Idell",
"Human",
"Royal Paladin",
1,
8000,
"RoyalPaladin050",
CardIdentifier.UNCOMPROMISING_KNIGHT__IDELL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Delicate Knight, Claudin",
"Human",
"Royal Paladin",
1,
8000,
"RoyalPaladin051",
CardIdentifier.DELICATE_KNIGHT__CLAUDIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Stinging Jewel Knight, Sherrie",
"Elf",
"Royal Paladin",
1,
7000,
"RoyalPaladin052",
CardIdentifier.STINGING_JEWEL_KNIGHT__SHERRIE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Rushgal",
"High Beast",
"Royal Paladin",
1,
6000,
"RoyalPaladin053",
CardIdentifier.RUSHGAL
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Jewel Knight, Glitme",
"High Beast",
"Royal Paladin",
1,
5000,
"RoyalPaladin054",
CardIdentifier.JEWEL_KNIGHT__GLITME
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Blazing Jewel Knight, Rachelle",
"Human",
"Royal Paladin",
1,
5000,
"RoyalPaladin055",
CardIdentifier.BLAZING_JEWEL_KNIGHT__RACHELLE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Primgal",
"High Beast",
"Royal Paladin",
1,
4000,
"RoyalPaladin056",
CardIdentifier.PRIMGAL
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Dedicated Jewel Knight, Tabitha",
"Human",
"Royal Paladin",
1,
5000,
"RoyalPaladin057",
CardIdentifier.DEDICATED_JEWEL_KNIGHT__TABITHA
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Enthusiastic Jewel Knight, Polly",
"Human",
"Royal Paladin",
1,
5000,
"RoyalPaladin058",
CardIdentifier.ENTHUSIASTIC_JEWEL_KNIGHT__POLLY
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Muungal",
"High Beast",
"Gold Paladin",
1,
10000,
"GoldPaladin047",
CardIdentifier.MUUNGAL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Far Bow, Safir",
"Human",
"Gold Paladin",
1,
8000,
"GoldPaladin048",
CardIdentifier.KNIGHT_OF_FAR_BOW__SAFIR
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Break Fist, Segwarides",
"Giant",
"Gold Paladin",
1,
8000,
"GoldPaladin049",
CardIdentifier.KNIGHT_OF_BREAK_FIST__SEGWARIDES
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Guiding Falconee",
"Elf",
"Gold Paladin",
1,
6000,
"GoldPaladin050",
CardIdentifier.GUIDING_FALCONEE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Liberator, Flare Mane Stallion",
"High Beast",
"Gold Paladin",
1,
6000,
"GoldPaladin051",
CardIdentifier.LIBERATOR__FLARE_MANE_STALLION
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Holy Squire, Enide",
"Human",
"Gold Paladin",
1,
4000,
"GoldPaladin052",
CardIdentifier.HOLY_SQUIRE__ENIDE
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Liberator of Hope, Epona",
"Sylph",
"Gold Paladin",
1,
5000,
"GoldPaladin053",
CardIdentifier.LIBERATOR_OF_HOPE__EPONA
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Flogal Liberator",
"High Beast",
"Gold Paladin",
1,
5000,
"GoldPaladin054",
CardIdentifier.FLOGAL_LIBERATOR
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Scheduler Angel",
"Angel",
"Genesis",
1,
10000,
"Genesis013",
CardIdentifier.SCHEDULER_ANGEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Mice Guard, Antares",
"Battleroid",
"Genesis",
1,
10000,
"Genesis014",
CardIdentifier.MICE_GUARD__ANTARES
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Clever Jake",
"Ghost",
"Genesis",
1,
8000,
"Genesis015",
CardIdentifier.CLEVER_JAKE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Witch of Owls, Paprika",
"Human",
"Genesis",
1,
8000,
"Genesis016",
CardIdentifier.WITCH_OF_OWLS__PAPRIKA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Mice Guard, Orion",
"Battleroid",
"Genesis",
1,
8000,
"Genesis017",
CardIdentifier.MICE_GUARD__ORION
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Maiden, Mihikarihime",
"Noble",
"Genesis",
1,
8000,
"Genesis018",
CardIdentifier.BATTLE_MAIDEN__MIHIKARIHIME
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Bowstring of Heaven and Earth, Artemis",
"Noble",
"Genesis",
1,
7000,
"Genesis019",
CardIdentifier.BOWSTRING_OF_HEAVEN_AND_EARTH__ARTEMIS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Witch of Cats, Cumin",
"Human",
"Genesis",
1,
7000,
"Genesis020",
CardIdentifier.WITCH_OF_CATS__CUMIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Snipe Snake",
"High Beast",
"Genesis",
1,
6000,
"Genesis021",
CardIdentifier.SNIPE_SNAKE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Mice Guard, Sirius",
"Battleroid",
"Genesis",
1,
6000,
"Genesis022",
CardIdentifier.MICE_GUARD__SIRIUS
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Cluster Hamster",
"High Beast",
"Genesis",
1,
4000,
"Genesis023",
CardIdentifier.CLUSTER_HAMSTER
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Cyber Tiger",
"High Beast",
"Genesis",
1,
5000,
"Genesis024",
CardIdentifier.CYBER_TIGER
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Battle Maiden, Kukurihime",
"Noble",
"Genesis",
1,
4000,
"Genesis025",
CardIdentifier.BATTLE_MAIDEN__KUKURIHIME
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Bandit Danny",
"Ghost",
"Genesis",
1,
5000,
"Genesis026",
CardIdentifier.BANDIT_DANNY
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Fancy Monkey",
"High Beast",
"Genesis",
1,
5000,
"Genesis027",
CardIdentifier.FANCY_MONKEY
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Spark Cockerel",
"High Beast",
"Genesis",
1,
5000,
"Genesis028",
CardIdentifier.SPARK_COCKEREL
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
0,
"Patrol Guardian",
"Battleroid",
"Genesis",
1,
10000,
"Genesis029",
CardIdentifier.PATROL_GUARDIAN
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Large Pot Witch, Laurie",
"Human",
"Genesis",
1,
5000,
"Genesis030",
CardIdentifier.LARGE_POT_WITCH__LAURIE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Demonic Dragon Berserker, Jandira",
"Dragonman",
"Narukami",
1,
10000,
"Narukami050",
CardIdentifier.DEMONIC_DRAGON_BERSERKER__JANDIRA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Blood Axe Dragoon",
"Human",
"Narukami",
1,
8000,
"Narukami051",
CardIdentifier.BLOOD_AXE_DRAGOON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Demonic Dragon Mage, Majira",
"Dragonman",
"Narukami",
1,
8000,
"Narukami052",
CardIdentifier.DEMONIC_DRAGON_MAGE__MAJIRA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Sword Dance Eradicator, Hisen",
"Thunder Dragon",
"Narukami",
1,
6000,
"Narukami053",
CardIdentifier.SWORD_DANCE_ERADICATOR__HISEN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dragon Dancer, Agnes",
"Human",
"Narukami",
1,
6000,
"Narukami054",
CardIdentifier.DRAGON_DANCER__AGNES
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Thunder Fist Eradicator, Doui",
"Thunder Dragon",
"Narukami",
1,
6000,
"Narukami055",
CardIdentifier.THUNDER_FIST_ERADICATOR__DOUI
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Eradicator, Strike-dagger Dragon",
"Thunder Dragon",
"Narukami",
1,
5000,
"Narukami056",
CardIdentifier.ERADICATOR__STRIKE_DAGGER_DRAGON
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Djinn of the Clapping Thunder",
"Noble",
"Narukami",
1,
4000,
"Narukami057",
CardIdentifier.DJINN_OF_THE_CLAPPING_THUNDER
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Divine Spear Eradicator, Pollux",
"Human",
"Narukami",
1,
5000,
"Narukami058",
CardIdentifier.DIVINE_SPEAR_ERADICATOR__POLLUX
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Eradicator, Spy Eye Wyvern",
"Winged Dragon",
"Narukami",
1,
5000,
"Narukami059",
CardIdentifier.ERADICATOR__SPY_EYE_WYVERN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Bloody Rain",
"Vampire",
"Nova Grappler",
1,
8000,
"NovaGrappler071",
CardIdentifier.BLOODY_RAIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Beast Deity, Hilarity Destroyer",
"Battleroid",
"Nova Grappler",
1,
7000,
"NovaGrappler072",
CardIdentifier.BEAST_DEITY__HILARITY_DESTROYER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Machinery Angel",
"Angel",
"Nova Grappler",
1,
6000,
"NovaGrappler073",
CardIdentifier.MACHINERY_ANGEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Beast Deity, Riot Horn",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler074",
CardIdentifier.BEAST_DEITY__RIOT_HORN
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Battle Arm Leprechaun",
"Elf",
"Nova Grappler",
1,
4000,
"NovaGrappler075",
CardIdentifier.BATTLE_ARM_LEPRECHAUN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Anti-Battleroid Gunner",
"Ogre",
"Spike Brothers",
1,
10000,
"SpikeBrothers025",
CardIdentifier.ANTI_BATTLEROID_GUNNER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Blow Kiss, Olivia",
"Succubus",
"Spike Brothers",
1,
9000,
"SpikeBrothers026",
CardIdentifier.BLOW_KISS__OLIVIA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Go For Break",
"Warbeast",
"Spike Brothers",
1,
8000,
"SpikeBrothers027",
CardIdentifier.GO_FOR_BREAK
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Charging Bill Collector",
"Ogre",
"Spike Brothers",
1,
8000,
"SpikeBrothers028",
CardIdentifier.CHARGING_BILL_COLLECTOR
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"UFO",
"Goblin",
"Spike Brothers",
1,
7000,
"SpikeBrothers029",
CardIdentifier.UFO
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Tyrant Receiver",
"Demon",
"Spike Brothers",
1,
6000,
"SpikeBrothers030",
CardIdentifier.TYRANT_RECEIVER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dudley Phantom",
"Ghost",
"Spike Brothers",
1,
6000,
"SpikeBrothers031",
CardIdentifier.DUDLEY_PHANTOM
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Reign of Terror, Thermidor",
"Demon",
"Spike Brothers",
1,
5000,
"SpikeBrothers032",
CardIdentifier.REIGN_OF_TERROR__THERMIDOR
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Baby Face, Isaac",
"Human",
"Spike Brothers",
1,
4000,
"SpikeBrothers033",
CardIdentifier.BABY_FACE__ISAAC
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Blaster Blade Liberator",
"Human",
"Gold Paladin",
1,
9000,
"GoldPaladin055",
CardIdentifier.BLASTER_BLADE_LIBERATOR
));
		
		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Prophecy Celestial, Ramiel",
"Angel",
"Angel Feather",
1,
11000,
"AngelFeather045",
CardIdentifier.PROPHECY_CELESTIAL__RAMIEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Solidify Celestial, Zerachiel",
"Angel",
"Angel Feather",
1,
11000,
"AngelFeather046",
CardIdentifier.SOLIDIFY_CELESTIAL__ZERACHIEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Goddess of Good Luck, Fortuna",
"Noble",
"Genesis",
1,
11000,
"Genesis031",
CardIdentifier.GODDESS_OF_GOOD_LUCK__FORTUNA
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Hellfire Seal Dragon, Blockade Inferno",
"Flame Dragon",
"Kagero",
1,
11000,
"Kagero052",
CardIdentifier.HELLFIRE_SEAL_DRAGON__BLOCKADE_INFERNO
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dauntless Drive Dragon",
"Flame Dragon",
"Kagero",
1,
11000,
"Kagero053",
CardIdentifier.DAUNTLESS_DRIVE_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Eradicator, Sweep Command Dragon",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami060",
CardIdentifier.ERADICATOR__SWEEP_COMMAND_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Blue Flight Dragon, Trans-core Dragon",
"Tear Dragon",
"Aqua Force",
1,
11000,
"AquaForce033",
CardIdentifier.BLUE_FLIGHT_DRAGON__TRANS_CORE_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Last Card, Revonn",
"Tear Dragon",
"Aqua Force",
1,
11000,
"AquaForce034",
CardIdentifier.LAST_CARD__REVONN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Adamantine Celestial, Aniel",
"Angel",
"Angel Feather",
1,
6000,
"AngelFeather047",
CardIdentifier.ADAMANTINE_CELESTIAL__ANIEL
));

		Card.Add (new CardInformation (10,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               0,
		                               "No Name",
		                               "DummyRace",
		                               "DummyClan",
		                               1,
		                               0,
		                               "NoImage",
		                               CardIdentifier.DUMMY_ID_0
		                               ));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Seal Dragon, Rinocross",
"Flame Dragon",
"Kagero",
1,
6000,
"Kagero055",
CardIdentifier.SEAL_DRAGON__RINOCROSS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Ancient Dragon, Spinodriver",
"Dinodragon",
"Tachikaze",
1,
11000,
"Tachikaze041",
CardIdentifier.ANCIENT_DRAGON__SPINODRIVER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Ancient Dragon, Tyrannolegend",
"Dinodragon",
"Tachikaze",
1,
11000,
"Tachikaze042",
CardIdentifier.ANCIENT_DRAGON__TYRANNOLEGEND
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Ravenous Dragon, Battlerex",
"Dinodragon",
"Tachikaze",
1,
10000,
"Tachikaze043",
CardIdentifier.RAVENOUS_DRAGON__BATTLEREX
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Ancient Dragon, Paraswall",
"Dinodragon",
"Tachikaze",
1,
6000,
"Tachikaze044",
CardIdentifier.ANCIENT_DRAGON__PARASWALL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Armor Break Dragon",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami061",
CardIdentifier.ARMOR_BREAK_DRAGON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Fiendish Sword Eradicator, Cho-Ou",
"Demon",
"Narukami",
1,
9000,
"Narukami062",
CardIdentifier.FIENDISH_SWORD_ERADICATOR__CHO_OU
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Thundering Ripple, Genovious",
"Aquaroid",
"Aqua Force",
1,
10000,
"AquaForce035",
CardIdentifier.THUNDERING_RIPPLE__GENOVIOUS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Tear Knight, Lucas",
"Aquaroid",
"Aqua Force",
1,
9000,
"AquaForce036",
CardIdentifier.TEAR_KNIGHT__LUCAS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Mobile Hospital, Assault Hospice",
"Golem",
"Angel Feather",
1,
10000,
"AngelFeather048",
CardIdentifier.MOBILE_HOSPITAL__ASSAULT_HOSPICE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Reverse Aura Phoenix",
"High Beast",
"Angel Feather",
1,
10000,
"AngelFeather049",
CardIdentifier.REVERSE_AURA_PHOENIX
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Essence Celestial, Becca",
"Angel",
"Angel Feather",
1,
10000,
"AngelFeather050",
CardIdentifier.ESSENCE_CELESTIAL__BECCA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Wild Shot Celestial, Raguel",
"Angel",
"Angel Feather",
1,
9000,
"AngelFeather051",
CardIdentifier.WILD_SHOT_CELESTIAL__RAGUEL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Candle Celestial, Sariel",
"Angel",
"Angel Feather",
1,
8000,
"AngelFeather052",
CardIdentifier.CANDLE_CELESTIAL__SARIEL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Underlay Celestial, Hesediel",
"Angel",
"Angel Feather",
1,
6000,
"AngelFeather053",
CardIdentifier.UNDERLAY_CELESTIAL__HESEDIEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Mice Guard, La Superba",
"Battleroid",
"Genesis",
1,
10000,
"Genesis032",
CardIdentifier.MICE_GUARD__LA_SUPERBA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Witch of Birds, Chamomile",
"Human",
"Genesis",
1,
9000,
"Genesis033",
CardIdentifier.WITCH_OF_BIRDS__CHAMOMILE
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Witch of Frogs, Melissa",
"Human",
"Genesis",
1,
7000,
"Genesis034",
CardIdentifier.WITCH_OF_FROGS__MELISSA
));

		Card.Add (new CardInformation (3,
		                               TriggerIcon.NONE,
		                               SkillIcon.TWIN_DRIVE,
		                               0,
		                               "Demonic Dragon Berserker, Gandaruba",
		                               "Dragonman",
		                               "Kagero",
		                               1,
		                               10000,
		                               "Kagero056",
		                               CardIdentifier.DEMONIC_DRAGON_BERSERKER__GANDARUBA
		                               ));

		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Seal Dragon, Hunger Hell Dragon",
		                               "Flame Dragon",
		                               "Kagero",
		                               1,
		                               10000,
		                               "Kagero057",
		                               CardIdentifier.SEAL_DRAGON__HUNGER_HELL_DRAGON
		                               ));
		
		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Seal Dragon, Jakado",
		                               "Flame Dragon",
		                               "Kagero",
		                               1,
		                               9000,
		                               "Kagero058",
		                               CardIdentifier.SEAL_DRAGON__JAKADO
		                               ));

		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Seal Dragon, Chambray",
		                               "Flame Dragon",
		                               "Kagero",
		                               1,
		                               4000,
		                               "Kagero059",
		                               CardIdentifier.SEAL_DRAGON__CHAMBRAY
		                               ));
		
		Card.Add (new CardInformation (3,
		                               TriggerIcon.NONE,
		                               SkillIcon.TWIN_DRIVE,
		                               0,
		                               "Savage Hunter",
		                               "Human",
		                               "Tachikaze",
		                               1,
		                               10000,
		                               "Tachikaze045",
		                               CardIdentifier.SAVAGE_HUNTER
		                               ));
		
		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Ancient Dragon, Cryolophor",
		                               "Dinodragon",
		                               "Tachikaze",
		                               1,
		                               10000,
		                               "Tachikaze046",
		                               CardIdentifier.ANCIENT_DRAGON__CRYOLOPHOR
		                               ));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Ancient Dragon, Beamankylo",
"Dinodragon",
"Tachikaze",
1,
9000,
"Tachikaze047",
CardIdentifier.ANCIENT_DRAGON__BEAMANKYLO
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Ancient Dragon, Iguanogorg",
"Dinodragon",
"Tachikaze",
1,
7000,
"Tachikaze048",
CardIdentifier.ANCIENT_DRAGON__IGUANOGORG
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Demonic Sword Eradicator, Raioh",
"Demon",
"Narukami",
1,
10000,
"Narukami063",
CardIdentifier.DEMONIC_SWORD_ERADICATOR__RAIOH
));

		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Iron Blood Eradicator, Shuki",
		                               "Human",
		                               "Narukami",
		                               1,
		                               7000,
		                               "Narukami064",
		                               CardIdentifier.IRON_BLOOD_ERADICATOR__SHUKI
		                               ));
		
		Card.Add (new CardInformation (3,
		                               TriggerIcon.NONE,
		                               SkillIcon.TWIN_DRIVE,
		                               0,
		                               "Optics Cannon Titan",
		                               "Golem",
		                               "Aqua Force",
		                               1,
		                               10000,
		                               "AquaForce038",
		                               CardIdentifier.OPTICS_CANNON_TITAN
		                               ));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Rising Ripple, Pavroth",
"Aquaroid",
"Aqua Force",
1,
9000,
"AquaForce039",
CardIdentifier.RISING_RIPPLE__PAVROTH
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Starting Ripple, Alecs",
"Aquaroid",
"Aqua Force",
1,
4000,
"AquaForce040",
CardIdentifier.STARTING_RIPPLE__ALECS
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Booting Celestial, Sandalphon",
"Angel",
"Angel Feather",
1,
10000,
"AngelFeather054",
CardIdentifier.BOOTING_CELESTIAL__SANDALPHON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Capsule Gift Nurse",
"Angel",
"Angel Feather",
1,
8000,
"AngelFeather055",
CardIdentifier.CAPSULE_GIFT_NURSE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Doctroid Argus",
"Workeroid",
"Angel Feather",
1,
8000,
"AngelFeather056",
CardIdentifier.DOCTROID_ARGUS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Marking Celestial, Arabhaki",
"Angel",
"Angel Feather",
1,
7000,
"AngelFeather057",
CardIdentifier.MARKING_CELESTIAL__ARABHAKI
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Order Celestial, Yeqon",
"Angel",
"Angel Feather",
1,
7000,
"AngelFeather058",
CardIdentifier.ORDER_CELESTIAL__YEQON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Drug Store Nurse",
"Angel",
"Angel Feather",
1,
6000,
"AngelFeather059",
CardIdentifier.DRUG_STORE_NURSE
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"First Aid Celestial, Penuel",
"Angel",
"Angel Feather",
1,
5000,
"AngelFeather060",
CardIdentifier.FIRST_AID_CELESTIAL__PENUEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Cure Drop Angel",
"Angel",
"Angel Feather",
1,
4000,
"AngelFeather061",
CardIdentifier.CURE_DROP_ANGEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Punishment Celestial, Shamihaza",
"Angel",
"Angel Feather",
1,
5000,
"AngelFeather062",
CardIdentifier.PUNISHMENT_CELESTIAL__SHAMIHAZA
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Celestial, Landing Pegasus",
"High Beast",
"Angel Feather",
1,
5000,
"AngelFeather063",
CardIdentifier.CELESTIAL__LANDING_PEGASUS
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Care Celestial, Tamiel",
"Angel",
"Angel Feather",
1,
5000,
"AngelFeather064",
CardIdentifier.CARE_CELESTIAL__TAMIEL
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Healing Celestial, Ramiel",
"Angel",
"Angel Feather",
1,
5000,
"AngelFeather065",
CardIdentifier.HEALING_CELESTIAL__RAMIEL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Hazard Bob",
"Ghost",
"Genesis",
1,
8000,
"Genesis035",
CardIdentifier.HAZARD_BOB
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Pineapple Lo",
"Ghost",
"Genesis",
1,
6000,
"Genesis036",
CardIdentifier.PINEAPPLE_LO
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Witch of Prohibited Books, Cinnamon",
"Human",
"Genesis",
1,
5000,
"Genesis037",
CardIdentifier.WITCH_OF_PROHIBITED_BOOKS__CINNAMON
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Vivid Rabbit",
"Warbeast",
"Genesis",
1,
4000,
"Genesis038",
CardIdentifier.VIVID_RABBIT
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Seal Dragon, Spike Hell Dragon",
"Flame Dragon",
"Kagero",
1,
10000,
"Kagero060",
CardIdentifier.SEAL_DRAGON__SPIKE_HELL_DRAGON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Seal Dragon, Corduroy",
"Flame Dragon",
"Kagero",
1,
9000,
"Kagero061",
CardIdentifier.SEAL_DRAGON__CORDUROY
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Breath of Demise, Vulcanis",
"Salamander",
"Kagero",
1,
8000,
"Kagero062",
CardIdentifier.BREATH_OF_DEMISE__VULCANIS
));
		
		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Dragon Knight, Lotf",
		                               "Human",
		                               "Kagero",
		                               1,
		                               8000,
		                               "Kagero063",
		                               CardIdentifier.DRAGON_KNIGHT__RUTOF
		                               ));

		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Demonic Dragon Berserker, Kumbhanda",
		                               "Dragonman",
		                               "Kagero",
		                               1,
		                               8000,
		                               "Kagero064",
		                               CardIdentifier.DEMONIC_DRAGON_BERSERKER__KUBANDA
		                               ));

		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Seal Dragon, Flannel",
		                               "Flame Dragon",
		                               "Kagero",
		                               1,
		                               7000,
		                               "Kagero065",
		                               CardIdentifier.SEAL_DRAGON__FLANNEL
		                               ));

		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Seal Dragon, Kersey",
		                               "Flame Dragon",
		                               "Kagero",
		                               1,
		                               7000,
		                               "Kagero066",
		                               CardIdentifier.SEAL_DRAGON__KERSEY
		                               ));

		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Breath of Origin, Rolamandri",
		                               "Salamander",
		                               "Kagero",
		                               1,
		                               6000,
		                               "Kagero067",
		                               CardIdentifier.BREATH_OF_PRIMORDIAL__ROLAMANDRI
		                               ));

		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Demonic Dragon Mage, Sagara",
		                               "Dragonman",
		                               "Kagero",
		                               1,
		                               6000,
		                               "Kagero068",
		                               CardIdentifier.DEMONIC_DRAGON_MAGE__SHAGARA
		                               ));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Seal Dragon, Terrycloth",
"Flame Dragon",
"Kagero",
1,
5000,
"Kagero069",
CardIdentifier.SEAL_DRAGON__TERRYCLOTH
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Demonic Dragon Mage, Diva",
"Dragonman",
"Kagero",
1,
4000,
"Kagero070",
CardIdentifier.DEMONIC_DRAGON_MAGE__DIVA
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Red Pulse Dracokid",
"Flame Dragon",
"Kagero",
1,
4000,
"Kagero071",
CardIdentifier.RED_PULSE_DRACOKID
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Seal Dragon, Biera",
"Flame Dragon",
"Kagero",
1,
5000,
"Kagero072",
CardIdentifier.SEAL_DRAGON__BIERA
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Seal Dragon, Dobi",
"Flame Dragon",
"Kagero",
1,
5000,
"Kagero073",
CardIdentifier.SEAL_DRAGON__DOBI
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Seal Dragon, Shading",
"Flame Dragon",
"Kagero",
1,
5000,
"Kagero074",
CardIdentifier.SEAL_DRAGON__SHADING
));

		Card.Add (new CardInformation (0,
		                               TriggerIcon.DRAW,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Seal Dragon, Artpique",
		                               "Flame Dragon",
		                               "Kagero",
		                               1,
		                               4000,
		                               "Kagero075",
		                               CardIdentifier.SEAL_DRAGON__ARTPITCH
		                               ));

		Card.Add (new CardInformation (3,
		                               TriggerIcon.NONE,
		                               SkillIcon.TWIN_DRIVE,
		                               0,
		                               "Ancient Dragon, Stegobuster",
		                               "Dinodragon",
		                               "Tachikaze",
		                               1,
		                               10000,
		                               "Tachikaze049",
		                               CardIdentifier.ANCIENT_DRAGON__STEGOBUSTER
		                               ));

		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Ancient Dragon, Dinocrowd",
		                               "Dinodragon",
		                               "Tachikaze",
		                               1,
		                               9000,
		                               "Tachikaze050",
		                               CardIdentifier.ANCIENT_DRAGON__DEINO_CLAWED
		                               ));

		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Launcher Mammoth",
		                               "High Beast",
		                               "Tachikaze",
		                               1,
		                               9000,
		                               "Tachikaze051",
		                               CardIdentifier.LAUNCHER_MAMMOTH
		                               ));
		
		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Savage Archer",
		                               "Human",
		                               "Tachikaze",
		                               1,
		                               8000,
		                               "Tachikaze052",
		                               CardIdentifier.SAVAGE_ARCHER
		                               ));

		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Ancient Dragon, Tri-Plasma",
		                               "Dinodragon",
		                               "Tachikaze",
		                               1,
		                               7000,
		                               "Tachikaze053",
		                               CardIdentifier.ANCIENT_DRAGON__TRI_PLASMA
		                               ));
		
		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Ancient Dragon, Gattling Allo",
		                               "Dinodragon",
		                               "Tachikaze",
		                               1,
		                               7000,
		                               "Tachikaze054",
		                               CardIdentifier.ANCIENT_DRAGON__GATTLING_ALLO
		                               ));
		
		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Savage Illuminator",
		                               "Human",
		                               "Tachikaze",
		                               1,
		                               6000,
		                               "Tachikaze055",
		                               CardIdentifier.SAVAGE_ILLUMINATOR
		                               ));
		
		Card.Add (new CardInformation (0,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Ancient Dragon, Baby Rex",
		                               "Dinodragon",
		                               "Tachikaze",
		                               1,
		                               5000,
		                               "Tachikaze056",
		                               CardIdentifier.ANCIENT_DRAGON__BABY_REX
		                               ));
		
		Card.Add (new CardInformation (0,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Savage Patriarch",
		                               "Human",
		                               "Tachikaze",
		                               1,
		                               4000,
		                               "Tachikaze057",
		                               CardIdentifier.SAVAGE_PATRIARCH
		                               ));
		
		Card.Add (new CardInformation (0,
		                               TriggerIcon.CRITICAL,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Ancient Dragon, Dinodile",
		                               "Dinodragon",
		                               "Tachikaze",
		                               1,
		                               4000,
		                               "Tachikaze058",
		                               CardIdentifier.ANCIENT_DRAGON__DINODILE
		                               ));
		
		Card.Add (new CardInformation (0,
		                               TriggerIcon.DRAW,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Ancient Dragon, Titanocargo",
		                               "Dinodragon",
		                               "Tachikaze",
		                               1,
		                               5000,
		                               "Tachikaze059",
		                               CardIdentifier.ANCIENT_DRAGON__TITANOCARGO
		                               ));
		
		Card.Add (new CardInformation (0,
		                               TriggerIcon.STAND,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Ancient Dragon, Caudinoise",
		                               "Dinodragon",
		                               "Tachikaze",
		                               1,
		                               5000,
		                               "Tachikaze060",
		                               CardIdentifier.ANCIENT_DRAGON__CAUDINOISE
		                               ));
		
		Card.Add (new CardInformation (0,
		                               TriggerIcon.HEAL,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Ancient Dragon, Ornithohealer",
		                               "Dinodragon",
		                               "Tachikaze",
		                               1,
		                               5000,
		                               "Tachikaze061",
		                               CardIdentifier.ANCIENT_DRAGON__ORNITHOHEALER
		                               ));
		
		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Dragon Dancer, Julia",
		                               "Human",
		                               "Narukami",
		                               1,
		                               7000,
		                               "Narukami065",
		                               CardIdentifier.DRAGON_DANCER__JULIA
		                               ));
		
		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Lizard Soldier, Ryoshin",
		                               "Dragonman",
		                               "Narukami",
		                               1,
		                               6000,
		                               "Narukami066",
		                               CardIdentifier.LIZARD_SOLDIER__RYUUSHIN
		                               ));

		Card.Add (new CardInformation (0,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Eradicator, First Thunder Dracokid",
		                               "Thunder Dragon",
		                               "Narukami",
		                               1,
		                               5000,
		                               "Narukami067",
		                               CardIdentifier.ERADICATOR__FIRST_THUNDER_DRACOKID
		                               ));
		
		Card.Add (new CardInformation (0,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Flag of Raijin, Corposant",
		                               "Sylph",
		                               "Narukami",
		                               1,
		                               4000,
		                               "Narukami068",
		                               CardIdentifier.FLAG_OF_RAIJIN__CORPOSANT
		                               ));

		Card.Add (new CardInformation (3,
		                               TriggerIcon.NONE,
		                               SkillIcon.TWIN_DRIVE,
		                               0,
		                               "Mobile Battleship, Archelon",
		                               "Battleroid",
		                               "Aqua Force",
		                               1,
		                               10000,
		                               "AquaForce041",
		                               CardIdentifier.MOBILE_BATTLESHIP__AKERON
		                               ));

		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Twin Strike Brave Shooter",
		                               "Aquaroid",
		                               "Aqua Force",
		                               1,
		                               9000,
		                               "AquaForce042",
		                               CardIdentifier.TWIN_STRIKE_BRAVE_SHOOTER
		                               ));

		Card.Add (new CardInformation (2,
		                               TriggerIcon.NONE,
		                               SkillIcon.INTERCEPT,
		                               5000,
		                               "Titan of the Beam Rifle",
		                               "Golem",
		                               "Aqua Force",
		                               1,
		                               8000,
		                               "AquaForce043",
		                               CardIdentifier.OPTICS_MUSKET_TITAN
		                               ));

		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Silent Ripple, Sotirio",
		                               "Aquaroid",
		                               "Aqua Force",
		                               1,
		                               7000,
		                               "AquaForce044",
		                               CardIdentifier.SILENT_RIPPLE__SOTIRIO
		                               ));
		
		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Shortstop Brave Shooter",
		                               "Aquaroid",
		                               "Aqua Force",
		                               1,
		                               7000,
		                               "AquaForce045",
		                               CardIdentifier.SHORTSTOP_BRAVE_SHOOTER
		                               ));
		
		Card.Add (new CardInformation (1,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               5000,
		                               "Battle Siren, Euphenia",
		                               "Mermaid",
		                               "Aqua Force",
		                               1,
		                               6000,
		                               "AquaForce046",
		                               CardIdentifier.BATTLE_SIREN__EUPHENIA
		                               ));
		
		Card.Add (new CardInformation (0,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Advance Party Brave Shooter",
		                               "Aquaroid",
		                               "Aqua Force",
		                               1,
		                               5000,
		                               "AquaForce047",
		                               CardIdentifier.ADVANCE_PARTY_BRAVE_SHOOTER
		                               ));

		Card.Add (new CardInformation (0,
		                               TriggerIcon.NONE,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Battle Siren, Cagli",
		                               "Mermaid",
		                               "Aqua Force",
		                               1,
		                               4000,
		                               "AquaForce048",
		                               CardIdentifier.BATTLE_SIREN__CARRI
		                               ));

		Card.Add (new CardInformation (0,
		                               TriggerIcon.CRITICAL,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Jet Ski Rider",
		                               "Aquaroid",
		                               "Aqua Force",
		                               1,
		                               5000,
		                               "AquaForce049",
		                               CardIdentifier.JET_SKI_RIDER
		                               ));
		
		Card.Add (new CardInformation (0,
		                               TriggerIcon.HEAL,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Ice Flow Angel",
		                               "High Beast",
		                               "Aqua Force",
		                               1,
		                               5000,
		                               "AquaForce050",
		                               CardIdentifier.ICE_FLOW_ANGEL
		                               ));

		Card.Add (new CardInformation (0,
		                               TriggerIcon.STAND,
		                               SkillIcon.BOOST,
		                               10000,
		                               "Mass Production Sailor",
		                               "Aquaroid",
		                               "Aqua Force",
		                               1,
		                               4000,
		                               "AquaForce051",
		                               CardIdentifier.MASS_PRODUCTION_SAILOR
		                               ));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Revenger, Raging Form Dragon",
"Abyss Dragon",
"Shadow Paladin",
1,
11000,
"ShadowPaladin057",
CardIdentifier.REVENGER__RAGING_FORM_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Wolf Fang Liberator, Garmore",
"Human",
"Gold Paladin",
1,
11000,
"GoldPaladin056",
CardIdentifier.WOLF_FANG_LIBERATOR__GARMORE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Eradicator, Vowing Saber Dragon Reverse",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami069",
CardIdentifier.ERADICATOR__VOWING_SABER_DRAGON______REVERSE_____
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Demon Conquering Dragon, Dungaree Unlimited",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami070",
CardIdentifier.DEMON_CONQUERING_DRAGON__DUNGAREE______UNLIMITED_____
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Star-vader, Nebula Lord Dragon",
"Cyber Dragon",
"Link Joker",
1,
11000,
"LinkJoker001",
CardIdentifier.STAR_VADER__NEBULA_LORD_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Schwarzschild Dragon",
"Cyber Dragon",
"Link Joker",
1,
10000,
"LinkJoker002",
CardIdentifier.SCHWARZSCHILD_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Demon Marquis, Amon Reverse",
"Demon",
"Dark Irregulars",
1,
11000,
"DarkIrregulars049",
CardIdentifier.DEMON_MARQUIS__AMON______REVERSE_____
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Silver Thorn Dragon Queen, Luquier Reverse",
"Elf",
"Pale Moon",
1,
11000,
"PaleMoon052",
CardIdentifier.SILVER_THORN_DRAGON_QUEEN__LUQUIER______REVERSE_____
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Witch of Cursed Talisman, Etain",
"Elf",
"Shadow Paladin",
1,
10000,
"ShadowPaladin058",
CardIdentifier.WITCH_OF_CURSED_TALISMAN__ETAIN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dark Cloak Revenger, Tartu",
"Human",
"Shadow Paladin",
1,
9000,
"ShadowPaladin059",
CardIdentifier.DARK_CLOAK_REVENGER__TARTU
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Dark Revenger, Mac Lir",
"Human",
"Shadow Paladin",
1,
6000,
"ShadowPaladin060",
CardIdentifier.DARK_REVENGER__MAC_LIR
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Barcgal Liberator",
"High Beast",
"Gold Paladin",
1,
7000,
"GoldPaladin057",
CardIdentifier.BARCGAL_LIBERATOR
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Iron Fan Eradicator, Rasetsunyo",
"Human",
"Narukami",
1,
9000,
"Narukami071",
CardIdentifier.IRON_FAN_ERADICATOR__RASETSUNYO
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Barrier Star-vader, Promethium",
"Cyberoid",
"Link Joker",
1,
6000,
"LinkJoker003",
CardIdentifier.BARRIER_STAR_VADER__PROMETHIUM
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"King of Masks, Dantarian",
"Human",
"Dark Irregulars",
1,
11000,
"DarkIrregulars050",
CardIdentifier.KING_OF_MASKS__DANTARIAN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Master of Fifth Element",
"Vampire",
"Dark Irregulars",
1,
10000,
"DarkIrregulars051",
CardIdentifier.MASTER_OF_FIFTH_ELEMENT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Amon's Follower, Vlad Specula",
"Vampire",
"Dark Irregulars",
1,
6000,
"DarkIrregulars052",
CardIdentifier.AMON_____S_FOLLOWER__VLAD_SPECULA
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Miracle Pop, Eva",
"Elf",
"Pale Moon",
1,
11000,
"PaleMoon053",
CardIdentifier.MIRACLE_POP__EVA
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Nightmare Doll, Chelsea",
"Workeroid",
"Pale Moon",
1,
10000,
"PaleMoon054",
CardIdentifier.NIGHTMARE_DOLL__CHELSEA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Silver Thorn Hypnos, Lydia",
"Human",
"Pale Moon",
1,
6000,
"PaleMoon055",
CardIdentifier.SILVER_THORN_HYPNOS__LYDIA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Barrier Troop Revenger, Dorint",
"Human",
"Shadow Paladin",
1,
7000,
"ShadowPaladin061",
CardIdentifier.BARRIER_TROOP_REVENGER__DORINT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Revenger, Dark Bond Trumpeter",
"Angel",
"Shadow Paladin",
1,
6000,
"ShadowPaladin062",
CardIdentifier.REVENGER__DARK_BOND_TRUMPETER
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Frontline Revenger, Claudas",
"Human",
"Shadow Paladin",
1,
5000,
"ShadowPaladin063",
CardIdentifier.FRONTLINE_REVENGER__CLAUDAS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Liberator, Bagpipe Angel",
"Angel",
"Gold Paladin",
1,
9000,
"GoldPaladin058",
CardIdentifier.LIBERATOR__BAGPIPE_ANGEL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Lightning Axe Wielding Exorcist Knight",
"Human",
"Narukami",
1,
9000,
"Narukami072",
CardIdentifier.LIGHTNING_AXE_WIELDING_EXORCIST_KNIGHT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Homing Eradicator, Rochishin",
"Dragonman",
"Narukami",
1,
8000,
"Narukami073",
CardIdentifier.HOMING_ERADICATOR__ROCHISHIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lightning Hammer Wielding Exorcist Knight",
"Human",
"Narukami",
1,
4000,
"Narukami075",
CardIdentifier.LIGHTNING_HAMMER_WIELDING_EXORCIST_KNIGHT
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Exorcist Mage, Dan Dan",
"Zombie",
"Narukami",
1,
5000,
"Narukami076",
CardIdentifier.EXORCIST_MAGE__DAN_DAN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Schrodinger's Lion",
"Cyber Beast",
"Link Joker",
1,
10000,
"LinkJoker004",
CardIdentifier.SCHR__DINGER_____S_LION
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Gravity Collapse Dragon",
"Cyber Dragon",
"Link Joker",
1,
9000,
"LinkJoker005",
CardIdentifier.GRAVITY_COLLAPSE_DRAGON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"One Who Opens the Black Door",
"Cyber Fairy",
"Link Joker",
1,
7000,
"LinkJoker006",
CardIdentifier.ONE_WHO_OPENS_THE_BLACK_DOOR
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Star-vader, Dust Tail Unicorn",
"Cyber Beast",
"Link Joker",
1,
5000,
"LinkJoker007",
CardIdentifier.STAR_VADER__DUST_TAIL_UNICORN
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Micro-hole Dracokid",
"Cyber Dragon",
"Link Joker",
1,
4000,
"LinkJoker008",
CardIdentifier.MICRO_HOLE_DRACOKID
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Werbear Soldner",
"Warbeast",
"Dark Irregulars",
1,
10000,
"DarkIrregulars053",
CardIdentifier.WERBEAR_SOLDNER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Amon's Follower, Psycho Glaive",
"Elf",
"Dark Irregulars",
1,
9000,
"DarkIrregulars054",
CardIdentifier.AMON_____S_FOLLOWER__PSYCHO_GLAIVE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Amon's Follower, Ron Geenlin",
"Human",
"Dark Irregulars",
1,
9000,
"DarkIrregulars055",
CardIdentifier.AMON_____S_FOLLOWER__RON_GEENLIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Amon's Follower, Fool's Palm",
"Elf",
"Dark Irregulars",
1,
7000,
"DarkIrregulars056",
CardIdentifier.AMON_____S_FOLLOWER__FOOL_____S_PALM
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Fire Ring Gryphon",
"Chimera",
"Pale Moon",
1,
10000,
"PaleMoon056",
CardIdentifier.FIRE_RING_GRYPHON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Silver Thorn Marionette, Lillian",
"Workeroid",
"Pale Moon",
1,
10000,
"PaleMoon057",
CardIdentifier.SILVER_THORN_MARIONETTE__LILLIAN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Silver Thorn Beast Tamer, Maricica",
"Elf",
"Pale Moon",
1,
9000,
"PaleMoon058",
CardIdentifier.SILVER_THORN_BEAST_TAMER__MARICICA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Silver Thorn Rising Dragon",
"Winged Dragon",
"Pale Moon",
1,
9000,
"PaleMoon059",
CardIdentifier.SILVER_THORN_RISING_DRAGON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Demon World Castle, Zerschlagen",
"Golem",
"Shadow Paladin",
1,
10000,
"ShadowPaladin064",
CardIdentifier.DEMON_WORLD_CASTLE__ZERSCHLAGEN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Sharkbau Revenger",
"High Beast",
"Shadow Paladin",
1,
8000,
"ShadowPaladin065",
CardIdentifier.SHARKBAU_REVENGER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Demon World Castle, Zweispeer",
"Golem",
"Shadow Paladin",
1,
8000,
"ShadowPaladin066",
CardIdentifier.DEMON_WORLD_CASTLE__ZWEISPEER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Revenger of Malice, Dilan",
"Elf",
"Shadow Paladin",
1,
6000,
"ShadowPaladin067",
CardIdentifier.REVENGER_OF_MALICE__DILAN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Sonbau",
"High Beast",
"Shadow Paladin",
1,
6000,
"ShadowPaladin068",
CardIdentifier.SONBAU
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Spinbau Revenger",
"High Beast",
"Shadow Paladin",
1,
4000,
"ShadowPaladin069",
CardIdentifier.SPINBAU_REVENGER
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Revenger, Air Raid Dragon",
"Abyss Dragon",
"Shadow Paladin",
1,
5000,
"ShadowPaladin070",
CardIdentifier.REVENGER__AIR_RAID_DRAGON
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Revenger, Waking Angel",
"Angel",
"Shadow Paladin",
1,
5000,
"ShadowPaladin071",
CardIdentifier.REVENGER__WAKING_ANGEL
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Gigantech Pillar Fighter",
"Giant",
"Gold Paladin",
1,
10000,
"GoldPaladin059",
CardIdentifier.GIGANTECH_PILLAR_FIGHTER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Cloudy Sky Liberator, Geraint",
"Human",
"Gold Paladin",
1,
9000,
"GoldPaladin060",
CardIdentifier.CLOUDY_SKY_LIBERATOR__GERAINT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Peekgal",
"High Beast",
"Gold Paladin",
1,
8000,
"GoldPaladin061",
CardIdentifier.PEEKGAL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"May Rain Liberator, Bruno",
"Human",
"Gold Paladin",
1,
7000,
"GoldPaladin062",
CardIdentifier.MAY_RAIN_LIBERATOR__BRUNO
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Sunrise Unicorn",
"High Beast",
"Gold Paladin",
1,
6000,
"GoldPaladin063",
CardIdentifier.SUNRISE_UNICORN
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Liberator, Cheer Up Trumpeter",
"Angel",
"Gold Paladin",
1,
5000,
"GoldPaladin064",
CardIdentifier.LIBERATOR__CHEER_UP_TRUMPETER
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Dawn Liberator, Murron",
"Giant",
"Gold Paladin",
1,
5000,
"GoldPaladin065",
CardIdentifier.DAWN_LIBERATOR__MURRON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Suppression Eradicator, Dokkasei",
"Human",
"Narukami",
1,
7000,
"Narukami077",
CardIdentifier.SUPPRESSION_ERADICATOR__DOKKASEI
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Eradicator, Blade Hang Dracokid",
"Thunder Dragon",
"Narukami",
1,
5000,
"Narukami078",
CardIdentifier.ERADICATOR__BLADE_HANG_DRACOKID
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Eradicator, Blue Gem Carbuncle",
"High Beast",
"Narukami",
1,
5000,
"Narukami079",
CardIdentifier.ERADICATOR__BLUE_GEM_CARBUNCLE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Catastrophe Stinger",
"Cyber Golem",
"Link Joker",
1,
10000,
"LinkJoker009",
CardIdentifier.CATASTROPHE_STINGER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Innocent Blade, Heartless",
"Cyberoid",
"Link Joker",
1,
10000,
"LinkJoker010",
CardIdentifier.INNOCENT_BLADE__HEARTLESS
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Furious Claw Star-vader, Niobium",
"Cyberoid",
"Link Joker",
1,
9000,
"LinkJoker011",
CardIdentifier.FURIOUS_CLAW_STAR_VADER__NIOBIUM
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Gamma Burst, Fenrir",
"Cyber Beast",
"Link Joker",
1,
8000,
"LinkJoker012",
CardIdentifier.GAMMA_BURST__FENRIR
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"One Who Shoots Gravitational Singularities",
"Cyber Fairy",
"Link Joker",
1,
8000,
"LinkJoker013",
CardIdentifier.ONE_WHO_SHOOTS_GRAVITATIONAL_SINGULARITIES
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"La Mort",
"Cyber Golem",
"Link Joker",
1,
8000,
"LinkJoker014",
CardIdentifier.LA_MORT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Gravity Ball Dragon",
"Cyber Dragon",
"Link Joker",
1,
7000,
"LinkJoker015",
CardIdentifier.GRAVITY_BALL_DRAGON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Demonic Claw Star-vader, Lanthanum",
"Cyberoid",
"Link Joker",
1,
7000,
"LinkJoker016",
CardIdentifier.DEMONIC_CLAW_STAR_VADER__LANTHANUM
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Strafe Star-vader, Ruthenium",
"Cyberoid",
"Link Joker",
1,
6000,
"LinkJoker017",
CardIdentifier.STRAFE_STAR_VADER__RUTHENIUM
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Paradox Nail, Fenrir",
"Cyber Beast",
"Link Joker",
1,
6000,
"LinkJoker018",
CardIdentifier.PARADOX_NAIL__FENRIR
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"White Night, Fenrir",
"Cyber Beast",
"Link Joker",
1,
4000,
"LinkJoker019",
CardIdentifier.WHITE_NIGHT__FENRIR
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Star-vader, Vice Soldiert",
"Cyber Golem",
"Link Joker",
1,
5000,
"LinkJoker020",
CardIdentifier.STAR_VADER__VICE_SOLDIERT
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Star-vader, Scouting Ferris",
"Cyber Beast",
"Link Joker",
1,
5000,
"LinkJoker021",
CardIdentifier.STAR_VADER__SCOUTING_FERRIS
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Star-vader, Moon Commander",
"Cyber Fairy",
"Link Joker",
1,
5000,
"LinkJoker022",
CardIdentifier.STAR_VADER__MOON_COMMANDER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Number of Terror",
"Human",
"Dark Irregulars",
1,
10000,
"DarkIrregulars057",
CardIdentifier.NUMBER_OF_TERROR
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Amon's Follower, Hell's Draw",
"Succubus",
"Dark Irregulars",
1,
9000,
"DarkIrregulars058",
CardIdentifier.AMON_____S_FOLLOWER__HELL_____S_DRAW
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Werleopard Soldat",
"Warbeast",
"Dark Irregulars",
1,
8000,
"DarkIrregulars059",
CardIdentifier.WERLEOPARD_SOLDAT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Flog Knight",
"Human",
"Dark Irregulars",
1,
8000,
"DarkIrregulars060",
CardIdentifier.FLOG_KNIGHT
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Amon's Follower, Hell's Deal",
"Succubus",
"Dark Irregulars",
1,
7000,
"DarkIrregulars061",
CardIdentifier.AMON_____S_FOLLOWER__HELL_____S_DEAL
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Amon's Follower, Phu Geenlin",
"Human",
"Dark Irregulars",
1,
7000,
"DarkIrregulars062",
CardIdentifier.AMON_____S_FOLLOWER__PHU_GEENLIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dimension Creeper",
"Demon",
"Dark Irregulars",
1,
7000,
"DarkIrregulars063",
CardIdentifier.DIMENSION_CREEPER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Werhase Bandit",
"Warbeast",
"Dark Irregulars",
1,
6000,
"DarkIrregulars064",
CardIdentifier.WERHASE_BANDIT
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Amon's Follower, Fate Collector",
"Elf",
"Dark Irregulars",
1,
5000,
"DarkIrregulars065",
CardIdentifier.AMON_____S_FOLLOWER__FATE_COLLECTOR
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Werfuchs Hexer",
"Warbeast",
"Dark Irregulars",
1,
4000,
"DarkIrregulars066",
CardIdentifier.WERFUCHS_HEXER
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Amon's Follower, Cruel Hand",
"Elf",
"Dark Irregulars",
1,
5000,
"DarkIrregulars067",
CardIdentifier.AMON_____S_FOLLOWER__CRUEL_HAND
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Amon's Follower, Psychic Waitress",
"Elf",
"Dark Irregulars",
1,
5000,
"DarkIrregulars068",
CardIdentifier.AMON_____S_FOLLOWER__PSYCHIC_WAITRESS
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Amon's Follower, Meteor Cracker",
"Demon",
"Dark Irregulars",
1,
5000,
"DarkIrregulars069",
CardIdentifier.AMON_____S_FOLLOWER__METEOR_CRACKER
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Amon's Follower, Hell's Trick",
"Succubus",
"Dark Irregulars",
1,
5000,
"DarkIrregulars070",
CardIdentifier.AMON_____S_FOLLOWER__HELL_____S_TRICK
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Huge Knife Throwing Expert",
"Giant",
"Pale Moon",
1,
10000,
"PaleMoon060",
CardIdentifier.HUGE_KNIFE_THROWING_EXPERT
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Tightrope Holder",
"Giant",
"Pale Moon",
1,
8000,
"PaleMoon061",
CardIdentifier.TIGHTROPE_HOLDER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Flying Hippogriff",
"Chimera",
"Pale Moon",
1,
8000,
"PaleMoon062",
CardIdentifier.FLYING_HIPPOGRIFF
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Silver Thorn Assistant, Irina",
"Warbeast",
"Pale Moon",
1,
7000,
"PaleMoon063",
CardIdentifier.SILVER_THORN_ASSISTANT__IRINA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Silver Thorn Beast Tamer, Ana",
"Elf",
"Pale Moon",
1,
7000,
"PaleMoon064",
CardIdentifier.SILVER_THORN_BEAST_TAMER__ANA
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Silver Thorn Breathing Dragon",
"Winged Dragon",
"Pale Moon",
1,
7000,
"PaleMoon065",
CardIdentifier.SILVER_THORN_BREATHING_DRAGON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Tightrope Tumbler",
"Goblin",
"Pale Moon",
1,
7000,
"PaleMoon066",
CardIdentifier.TIGHTROPE_TUMBLER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Elegant Elephant",
"High Beast",
"Pale Moon",
1,
6000,
"PaleMoon067",
CardIdentifier.ELEGANT_ELEPHANT
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Silver Thorn Assistant, Ionela",
"Warbeast",
"Pale Moon",
1,
5000,
"PaleMoon068",
CardIdentifier.SILVER_THORN_ASSISTANT__IONELA
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Journeying Tone, Willy",
"High Beast",
"Pale Moon",
1,
4000,
"PaleMoon069",
CardIdentifier.JOURNEYING_TONE__WILLY
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Silver Thorn Barking Dragon",
"Dinodragon",
"Pale Moon",
1,
5000,
"PaleMoon070",
CardIdentifier.SILVER_THORN_BARKING_DRAGON
));

		Card.Add (new CardInformation (0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Silver Thorn Marionette, Natasha",
"Workeroid",
"Pale Moon",
1,
5000,
"PaleMoon071",
CardIdentifier.SILVER_THORN_MARIONETTE__NATASHA
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Silver Thorn Beast Tamer, Serge",
"Human",
"Pale Moon",
1,
5000,
"PaleMoon072",
CardIdentifier.SILVER_THORN_BEAST_TAMER__SERGE
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Silver Thorn Juggler, Nadia",
"Elf",
"Pale Moon",
1,
5000,
"PaleMoon073",
CardIdentifier.SILVER_THORN_JUGGLER__NADIA
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Blaster Dark Revenger",
"Human",
"Shadow Paladin",
1,
9000,
"ShadowPaladin072",
CardIdentifier.BLASTER_DARK_REVENGER
));
		
		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Perfect Raizer",
"Battleroid",
"Nova Grappler",
1,
11000,
"NovaGrappler076",
CardIdentifier.PERFECT_RAIZER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dueling Dragon, ZANBAKU",
"Abyss Dragon",
"Murakumo",
1,
11000,
"Murakumo040",
CardIdentifier.DUELING_DRAGON__ZANBAKU
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Hi-powered Raizer Custom",
"Battleroid",
"Nova Grappler",
1,
8000,
"NovaGrappler077",
CardIdentifier.HI_POWERED_RAIZER_CUSTOM
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Golden Beast Tamer",
"Human",
"Pale Moon",
1,
10000,
"PaleMoon074",
CardIdentifier.GOLDEN_BEAST_TAMER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Machining Stag Beetle",
"Insect",
"Megacolony",
1,
10000,
"Megacolony026",
CardIdentifier.MACHINING_STAG_BEETLE
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Imperial Daughter",
"Human",
"Oracle Think Tank",
1,
11000,
"OracleThinkTank055",
CardIdentifier.IMPERIAL_DAUGHTER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Weather Forecaster, Miss Mist",
"Ghost",
"Oracle Think Tank",
1,
6000,
"OracleThinkTank056",
CardIdentifier.WEATHER_FORECASTER__MISS_MIST
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Miss Splendor",
"Alien",
"Nova Grappler",
1,
10000,
"NovaGrappler078",
CardIdentifier.MISS_SPLENDOR
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Rocket Hammer Man",
"Human",
"Nova Grappler",
1,
6000,
"NovaGrappler079",
CardIdentifier.ROCKET_HAMMER_MAN
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Twin Swordsman, MUSASHI",
"Warbeast",
"Murakumo",
1,
9000,
"Murakumo041",
CardIdentifier.TWIN_SWORDSMAN__MUSASHI
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Promise Daughter",
"Human",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank057",
CardIdentifier.PROMISE_DAUGHTER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Bellicosity Dragon",
"Flame Dragon",
"Kagero",
1,
9000,
"Kagero076",
CardIdentifier.BELLICOSITY_DRAGON
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Guard Griffin",
"Chimera",
"Kagero",
1,
6000,
"Kagero077",
CardIdentifier.GUARD_GRIFFIN
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Sage of Guidance, Zenon",
"Giant",
"Royal Paladin",
1,
6000,
"RoyalPaladin059",
CardIdentifier.SAGE_OF_GUIDANCE__ZENON
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Savage King",
"Human",
"Tachikaze",
1,
9000,
"Tachikaze062",
CardIdentifier.SAVAGE_KING
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Boomerang Thrower",
"Human",
"Nova Grappler",
1,
9000,
"NovaGrappler080",
CardIdentifier.BOOMERANG_THROWER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Raizer Custom",
"Battleroid",
"Nova Grappler",
1,
6000,
"NovaGrappler081",
CardIdentifier.RAIZER_CUSTOM
));

		Card.Add (new CardInformation (0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Wall Boy",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler082",
CardIdentifier.WALL_BOY
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Cat Butler",
"Warbeast",
"Nova Grappler",
1,
5000,
"NovaGrappler083",
CardIdentifier.CAT_BUTLER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Jumping Jill",
"Workeroid",
"Pale Moon",
1,
9000,
"PaleMoon075",
CardIdentifier.JUMPING_JILL
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Nitro Juggler",
"Workeroid",
"Pale Moon",
1,
9000,
"PaleMoon076",
CardIdentifier.NITRO_JUGGLER
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Starting Presenter",
"Demon",
"Pale Moon",
1,
6000,
"PaleMoon077",
CardIdentifier.STARTING_PRESENTER
));

		Card.Add (new CardInformation (0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Hoop Magician",
"Human",
"Pale Moon",
1,
5000,
"PaleMoon078",
CardIdentifier.HOOP_MAGICIAN
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Lark Pigeon",
"Warbeast",
"Pale Moon",
1,
5000,
"PaleMoon079",
CardIdentifier.LARK_PIGEON
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Swift Archer, FUSHIMI",
"Warbeast",
"Murakumo",
1,
9000,
"Murakumo042",
CardIdentifier.SWIFT_ARCHER__FUSHIMI
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Left Arrester",
"Warbeast",
"Murakumo",
1,
8000,
"Murakumo043",
CardIdentifier.LEFT_ARRESTER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Right Arrester",
"Warbeast",
"Murakumo",
1,
8000,
"Murakumo044",
CardIdentifier.RIGHT_ARRESTER
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Machining Mantis",
"Insect",
"Megacolony",
1,
9000,
"Megacolony027",
CardIdentifier.MACHINING_MANTIS
));

		Card.Add (new CardInformation (1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Machining Hornet",
"Insect",
"Megacolony",
1,
7000,
"Megacolony028",
CardIdentifier.MACHINING_HORNET
));

		Card.Add (new CardInformation (0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Machining Worker Ant",
"Insect",
"Megacolony",
1,
5000,
"Megacolony029",
CardIdentifier.MACHINING_WORKER_ANT
));

		Card.Add (new CardInformation (0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Shelter Beetle",
"Insect",
"Megacolony",
1,
5000,
"Megacolony030",
CardIdentifier.SHELTER_BEETLE
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Prowling Dragon, Striken",
"Winged Dragon",
"Kagero",
1,
10000,
"Kagero078",
CardIdentifier.PROWLING_DRAGON__STRIKEN
));

		Card.Add (new CardInformation (2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Spike Bouncer",
"Ogre",
"Spike Brothers",
1,
8000,
"SpikeBrothers034",
CardIdentifier.SPIKE_BOUNCER
));

		Card.Add (new CardInformation (3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Exculpate the Blaster",
"Human",
"Royal Paladin",
1,
12000,
"RoyalPaladin060",
CardIdentifier.EXCULPATE_THE_BLASTER
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Top Idol, Pacifica",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle005",
CardIdentifier.TOP_IDOL__PACIFICA
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Top Idol, Riviere",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle006",
CardIdentifier.TOP_IDOL__RIVIERE
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Bermuda Princess, Lena",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle007",
CardIdentifier.BERMUDA_PRINCESS__LENA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Pearl Sisters, Perle",
"Mermaid",
"Bermuda Triangle",
1,
7000,
"BermudaTriangle008",
CardIdentifier.PEARL_SISTERS__PERLE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Pearl Sisters, Perla",
"Mermaid",
"Bermuda Triangle",
1,
9000,
"BermudaTriangle009",
CardIdentifier.PEARL_SISTERS__PERLA
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Girls' Rock, Rio",
"Mermaid",
"Bermuda Triangle",
1,
8000,
"BermudaTriangle010",
CardIdentifier.GIRLS______ROCK__RIO
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Mermaid Idol, Elly",
"Mermaid",
"Bermuda Triangle",
1,
6000,
"BermudaTriangle011",
CardIdentifier.MERMAID_IDOL__ELLY
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Super Idol, Ceram",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle012",
CardIdentifier.SUPER_IDOL__CERAM
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Super Idol, Riviere",
"Mermaid",
"Bermuda Triangle",
1,
9000,
"BermudaTriangle013",
CardIdentifier.SUPER_IDOL__RIVIERE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Mermaid Idol, Flute",
"Mermaid",
"Bermuda Triangle",
1,
8000,
"BermudaTriangle014",
CardIdentifier.MERMAID_IDOL__FLUTE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Turquoise Blue, Tyrrhenia",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle015",
CardIdentifier.TURQUOISE_BLUE__TYRRHENIA
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Bermuda Triangle Cadet, Weddell",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle016",
CardIdentifier.BERMUDA_TRIANGLE_CADET__WEDDELL
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Bermuda Triangle Cadet, Riviere",
"Mermaid",
"Bermuda Triangle",
1,
4000,
"BermudaTriangle017",
CardIdentifier.BERMUDA_TRIANGLE_CADET__RIVIERE
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Velvet Voice, Raindear",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle018",
CardIdentifier.VELVET_VOICE__RAINDEAR
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Rainbow Light, Carine",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle019",
CardIdentifier.RAINBOW_LIGHT__CARINE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Intelli-idol, Melville",
"Mermaid",
"Bermuda Triangle",
1,
9000,
"BermudaTriangle020",
CardIdentifier.INTELLI_IDOL__MELVILLE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Snow White of the Corals, Claire",
"Mermaid",
"Bermuda Triangle",
1,
8000,
"BermudaTriangle021",
CardIdentifier.SNOW_WHITE_OF_THE_CORALS__CLAIRE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Diva of Clear Waters, Izumi",
"Mermaid",
"Bermuda Triangle",
1,
8000,
"BermudaTriangle022",
CardIdentifier.DIVA_OF_CLEAR_WATERS__IZUMI
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Mermaid Idol, Sedna",
"Mermaid",
"Bermuda Triangle",
1,
8000,
"BermudaTriangle023",
CardIdentifier.MERMAID_IDOL__SEDNA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Prism on the Water, Myrtoa",
"Mermaid",
"Bermuda Triangle",
1,
7000,
"BermudaTriangle024",
CardIdentifier.PRISM_ON_THE_WATER__MYRTOA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Mermaid Idol, Felucca",
"Mermaid",
"Bermuda Triangle",
1,
7000,
"BermudaTriangle025",
CardIdentifier.MERMAID_IDOL__FELUCCA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Mermaid Idol, Riviere",
"Mermaid",
"Bermuda Triangle",
1,
7000,
"BermudaTriangle026",
CardIdentifier.MERMAID_IDOL__RIVIERE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Navy Dolphin, Amur",
"Mermaid",
"Bermuda Triangle",
1,
6000,
"BermudaTriangle027",
CardIdentifier.NAVY_DOLPHIN__AMUR
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Comical Rainie",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle028",
CardIdentifier.COMICAL_RAINIE
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Cooking Caspi",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle029",
CardIdentifier.COOKING_CASPI
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Sleeping Beauty, Mousse",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle030",
CardIdentifier.SLEEPING_BEAUTY__MOUSSE
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Drive Quartet, Ressac",
"Mermaid",
"Bermuda Triangle",
1,
4000,
"BermudaTriangle031",
CardIdentifier.DRIVE_QUARTET__RESSAC
));

Card.Add (new CardInformation(0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Drive Quartet, Flows",
"Mermaid",
"Bermuda Triangle",
1,
4000,
"BermudaTriangle032",
CardIdentifier.DRIVE_QUARTET__FLOWS
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Drive Quartet, Shuplu",
"Mermaid",
"Bermuda Triangle",
1,
4000,
"BermudaTriangle033",
CardIdentifier.DRIVE_QUARTET__SHUPLU
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Drive Quartet, Bubblin",
"Mermaid",
"Bermuda Triangle",
1,
4000,
"BermudaTriangle034",
CardIdentifier.DRIVE_QUARTET__BUBBLIN
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Bermuda Triangle Cadet, Shizuku",
"Mermaid",
"Bermuda Triangle",
1,
4000,
"BermudaTriangle035",
CardIdentifier.BERMUDA_TRIANGLE_CADET__SHIZUKU
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Goddess of Flower Divination, Sakuya",
"Noble",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank058",
CardIdentifier.GODDESS_OF_FLOWER_DIVINATION__SAKUYA
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Meteor Break Wizard",
"Human",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank059",
CardIdentifier.METEOR_BREAK_WIZARD
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Sister, Maple",
"Elf",
"Oracle Think Tank",
1,
6000,
"OracleThinkTank060",
CardIdentifier.BATTLE_SISTER__MAPLE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dark Cat",
"High Beast",
"Oracle Think Tank",
1,
7000,
"OracleThinkTank061",
CardIdentifier.DARK_CAT
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Sword Dancer Angel",
"Angel",
"Oracle Think Tank",
1,
8000,
"OracleThinkTank062",
CardIdentifier.SWORD_DANCER_ANGEL
));
		
		Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Great Silver Wolf, Garmore",
"Human",
"Gold Paladin",
1,
10000,
"GoldPaladin066",
CardIdentifier.GREAT_SILVER_WOLF__GARMORE
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Sleygal Double Edge",
"High Beast",
"Gold Paladin",
1,
10000,
"GoldPaladin067",
CardIdentifier.SLEYGAL_DOUBLE_EDGE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Sleygal Sword",
"High Beast",
"Gold Paladin",
1,
9000,
"GoldPaladin068",
CardIdentifier.SLEYGAL_SWORD
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Battlefield Storm, Sagramore",
"Human",
"Gold Paladin",
1,
10000,
"GoldPaladin069",
CardIdentifier.BATTLEFIELD_STORM__SAGRAMORE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Sacred Guardian Beast, Nemean Lion",
"High Beast",
"Gold Paladin",
1,
8000,
"GoldPaladin070",
CardIdentifier.SACRED_GUARDIAN_BEAST__NEMEAN_LION
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Charging Chariot Knight",
"Human",
"Gold Paladin",
1,
8000,
"GoldPaladin071",
CardIdentifier.CHARGING_CHARIOT_KNIGHT
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Evil Slaying Swordsman, Haugan",
"Human",
"Gold Paladin",
1,
7000,
"GoldPaladin072",
CardIdentifier.EVIL_SLAYING_SWORDSMAN__HAUGAN
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Precipice Whirlwind, Sagramore",
"Human",
"Gold Paladin",
1,
6000,
"GoldPaladin073",
CardIdentifier.PRECIPICE_WHIRLWIND__SAGRAMORE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Charjgal",
"High Beast",
"Gold Paladin",
1,
6000,
"GoldPaladin074",
CardIdentifier.CHARJGAL
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Blessing Owl",
"High Beast",
"Gold Paladin",
1,
6000,
"GoldPaladin075",
CardIdentifier.BLESSING_OWL
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Silver Fang Witch",
"Human",
"Gold Paladin",
1,
5000,
"GoldPaladin076",
CardIdentifier.SILVER_FANG_WITCH
));
		
		Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Silent Punisher",
"Demon",
"Gold Paladin",
1,
5000,
"GoldPaladin077",
CardIdentifier.SILENT_PUNISHER
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Grassland Breeze, Sagramore",
"Human",
"Gold Paladin",
1,
6000,
"GoldPaladin078",
CardIdentifier.GRASSLAND_BREEZE__SAGRAMORE
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Weapons Dealer, Gwydion",
"Gnome",
"Gold Paladin",
1,
5000,
"GoldPaladin079",
CardIdentifier.WEAPONS_DEALER__GWYDION
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Fortune Bell",
"Sylph",
"Gold Paladin",
1,
5000,
"GoldPaladin080",
CardIdentifier.FORTUNE_BELL
));

Card.Add (new CardInformation(0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Elixir Sommelier",
"Elf",
"Gold Paladin",
1,
5000,
"GoldPaladin081",
CardIdentifier.ELIXIR_SOMMELIER
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Thunder Break Dragon",
"Thunder Dragon",
"Narukami",
1,
10000,
"Narukami080",
CardIdentifier.THUNDER_BREAK_DRAGON
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Djinn of the Lightning Flash",
"Demon",
"Narukami",
1,
10000,
"Narukami081",
CardIdentifier.DJINN_OF_THE_LIGHTNING_FLASH
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Plasmabite Dragon",
"Thunder Dragon",
"Narukami",
1,
10000,
"Narukami082",
CardIdentifier.PLASMABITE_DRAGON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Shieldblade Dragoon",
"Human",
"Narukami",
1,
8000,
"Narukami083",
CardIdentifier.SHIELDBLADE_DRAGOON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Djinn of the Lightning Flare",
"Demon",
"Narukami",
1,
8000,
"Narukami084",
CardIdentifier.DJINN_OF_THE_LIGHTNING_FLARE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Brightjet Dragon",
"Thunder Dragon",
"Narukami",
1,
8000,
"Narukami085",
CardIdentifier.BRIGHTJET_DRAGON
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lizard Soldier, Riki",
"Dragonman",
"Narukami",
1,
7000,
"Narukami086",
CardIdentifier.LIZARD_SOLDIER__RIKI
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Lightning of Hope, Helena",
"Sylph",
"Narukami",
1,
6000,
"Narukami087",
CardIdentifier.LIGHTNING_OF_HOPE__HELENA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Djinn of the Lightning Spark",
"Demon",
"Narukami",
1,
6000,
"Narukami088",
CardIdentifier.DJINN_OF_THE_LIGHTNING_SPARK
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dragon Dancer, RaiRai",
"Human",
"Narukami",
1,
6000,
"Narukami089",
CardIdentifier.DRAGON_DANCER__RAIRAI
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Wyvern Supply Unit",
"Dragonman",
"Narukami",
1,
6000,
"Narukami090",
CardIdentifier.WYVERN_SUPPLY_UNIT
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Lizard Soldier, Sishin",
"Dragonman",
"Narukami",
1,
6000,
"Narukami091",
CardIdentifier.LIZARD_SOLDIER__SISHIN
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Yellow Gem Carbuncle",
"High Beast",
"Narukami",
1,
5000,
"Narukami092",
CardIdentifier.YELLOW_GEM_CARBUNCLE
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Old Dragon Mage",
"Flame Dragon",
"Narukami",
1,
5000,
"Narukami093",
CardIdentifier.OLD_DRAGON_MAGE
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Zephyr Kid, Hayate",
"Demon",
"Narukami",
1,
5000,
"Narukami094",
CardIdentifier.ZEPHYR_KID__HAYATE
));

Card.Add (new CardInformation(0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Demonic Dragon Nymph, Seiobo",
"Dragonman",
"Narukami",
1,
5000,
"Narukami095",
CardIdentifier.DEMONIC_DRAGON_NYMPH__SEIOBO
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Navalgazer Dragon",
"Tear Dragon",
"Aqua Force",
1,
10000,
"AquaForce052",
CardIdentifier.NAVALGAZER_DRAGON
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Marine General of the Full Tides, Xenophon",
"Aquaroid",
"Aqua Force",
1,
10000,
"AquaForce053",
CardIdentifier.MARINE_GENERAL_OF_THE_FULL_TIDES__XENOPHON
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Key Anchor, Dabid",
"Aquaroid",
"Aqua Force",
1,
10000,
"AquaForce054",
CardIdentifier.KEY_ANCHOR__DABID
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Marine General of the Restless Tides, Algos",
"Aquaroid",
"Aqua Force",
1,
9000,
"AquaForce056",
CardIdentifier.MARINE_GENERAL_OF_THE_RESTLESS_TIDES__ALGOS
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Coral Assault",
"Aquaroid",
"Aqua Force",
1,
8000,
"AquaForce057",
CardIdentifier.CORAL_ASSAULT
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Titan of the Infinite Trench",
"Battleroid",
"Aqua Force",
1,
8000,
"AquaForce058",
CardIdentifier.TITAN_OF_THE_INFINITE_TRENCH
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Tear Knight, Cyprus",
"Aquaroid",
"Aqua Force",
1,
7000,
"AquaForce060",
CardIdentifier.TEAR_KNIGHT__CYPRUS
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Accelerated Command",
"High Beast",
"Aqua Force",
1,
6000,
"AquaForce061",
CardIdentifier.ACCELERATED_COMMAND
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Splash Assault",
"Aquaroid",
"Aqua Force",
1,
6000,
"AquaForce062",
CardIdentifier.SPLASH_ASSAULT
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Siren, Cynthia",
"Mermaid",
"Aqua Force",
1,
6000,
"AquaForce063",
CardIdentifier.BATTLE_SIREN__CYNTHIA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Siren, Dorothea",
"Mermaid",
"Aqua Force",
1,
6000,
"AquaForce064",
CardIdentifier.BATTLE_SIREN__DOROTHEA
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Officer Cadet of the First Battle",
"Aquaroid",
"Aqua Force",
1,
6000,
"AquaForce065",
CardIdentifier.OFFICER_CADET_OF_THE_FIRST_BATTLE
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Battleship Intelligence",
"Workeroid",
"Aqua Force",
1,
5000,
"AquaForce066",
CardIdentifier.BATTLESHIP_INTELLIGENCE
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Pyroxene Communications Sea Otter Soldier",
"High Beast",
"Aqua Force",
1,
5000,
"AquaForce067",
CardIdentifier.PYROXENE_COMMUNICATIONS_SEA_OTTER_SOLDIER
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Dolphin Soldier of High Speed Raids",
"High Beast",
"Aqua Force",
1,
5000,
"AquaForce068",
CardIdentifier.DOLPHIN_SOLDIER_OF_HIGH_SPEED_RAIDS
));

Card.Add (new CardInformation(0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Medical Officer of the Rainbow Elixir",
"Aquaroid",
"Aqua Force",
1,
5000,
"AquaForce069",
CardIdentifier.MEDICAL_OFFICER_OF_THE_RAINBOW_ELIXIR
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Demonic Lord, Dudley Emperor",
"Workeroid",
"Spike Brothers",
1,
10000,
"SpikeBrothers035",
CardIdentifier.DEMONIC_LORD__DUDLEY_EMPEROR
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Spectral Duke Dragon",
"Abyss Dragon",
"Gold Paladin",
1,
10000,
"GoldPaladin082",
CardIdentifier.SPECTRAL_DUKE_DRAGON
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Reckless Express",
"Workeroid",
"Spike Brothers",
1,
7000,
"SpikeBrothers036",
CardIdentifier.RECKLESS_EXPRESS
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Martial Arts Mutant, Master Beetle",
"Insect",
"Megacolony",
1,
11000,
"Megacolony031",
CardIdentifier.MARTIAL_ARTS_MUTANT__MASTER_BEETLE
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"White Dragon Knight, Pendragon",
"Human",
"Royal Paladin",
1,
10000,
"RoyalPaladin061",
CardIdentifier.WHITE_DRAGON_KNIGHT__PENDRAGON
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Origin Mage, Ildona",
"Elf",
"Shadow Paladin",
1,
10000,
"ShadowPaladin073",
CardIdentifier.ORIGIN_MAGE__ILDONA
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dragonic Lawkeeper",
"Flame Dragon",
"Kagero",
1,
10000,
"Kagero079",
CardIdentifier.DRAGONIC_LAWKEEPER
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Jelly Beans",
"Demon",
"Spike Brothers",
1,
10000,
"SpikeBrothers037",
CardIdentifier.JELLY_BEANS
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dudley Daisy",
"Succubus",
"Spike Brothers",
1,
7000,
"SpikeBrothers038",
CardIdentifier.DUDLEY_DAISY
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Bewitching Officer, Lady Butterfly",
"Insect",
"Megacolony",
1,
10000,
"Megacolony032",
CardIdentifier.BEWITCHING_OFFICER__LADY_BUTTERFLY
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Toxic Trooper",
"Insect",
"Megacolony",
1,
9000,
"Megacolony033",
CardIdentifier.TOXIC_TROOPER
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Toxic Soldier",
"Insect",
"Megacolony",
1,
7000,
"Megacolony034",
CardIdentifier.TOXIC_SOLDIER
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Gigantech Destroyer",
"Giant",
"Gold Paladin",
1,
10000,
"GoldPaladin083",
CardIdentifier.GIGANTECH_DESTROYER
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Black Dragon Knight, Vortimer",
"Human",
"Gold Paladin",
1,
9000,
"GoldPaladin084",
CardIdentifier.BLACK_DRAGON_KNIGHT__VORTIMER
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Black Dragon Whelp, Vortimer",
"Human",
"Gold Paladin",
1,
4000,
"GoldPaladin085",
CardIdentifier.BLACK_DRAGON_WHELP__VORTIMER
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dudley Douglass",
"Ogre",
"Spike Brothers",
1,
9000,
"SpikeBrothers039",
CardIdentifier.DUDLEY_DOUGLASS
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Fierce Leader, Zachary",
"Ogre",
"Spike Brothers",
1,
9000,
"SpikeBrothers040",
CardIdentifier.FIERCE_LEADER__ZACHARY
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Field Driller",
"Ogre",
"Spike Brothers",
1,
7000,
"SpikeBrothers041",
CardIdentifier.FIELD_DRILLER
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Medical Manager",
"Goblin",
"Spike Brothers",
1,
7000,
"SpikeBrothers042",
CardIdentifier.MEDICAL_MANAGER
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Smart Leader, Dark Bringer",
"Demon",
"Spike Brothers",
1,
5000,
"SpikeBrothers043",
CardIdentifier.SMART_LEADER__DARK_BRINGER
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Kungfu Kicker",
"Warbeast",
"Spike Brothers",
1,
5000,
"SpikeBrothers044",
CardIdentifier.KUNGFU_KICKER
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Iron Fist Mutant, Roly Poly",
"Insect",
"Megacolony",
1,
8000,
"Megacolony035",
CardIdentifier.IRON_FIST_MUTANT__ROLY_POLY
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Transmutated Thief, Steal Spider",
"Insect",
"Megacolony",
1,
7000,
"Megacolony036",
CardIdentifier.TRANSMUTATED_THIEF__STEAL_SPIDER
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Machining Mosquito",
"Insect",
"Megacolony",
1,
7000,
"Megacolony037",
CardIdentifier.MACHINING_MOSQUITO
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Pest Professor, Mad Fly",
"Insect",
"Megacolony",
1,
6000,
"Megacolony038",
CardIdentifier.PEST_PROFESSOR__MAD_FLY
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Megacolony Battler C",
"Insect",
"Megacolony",
1,
5000,
"Megacolony039",
CardIdentifier.MEGACOLONY_BATTLER_C
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Awaking Dragonfly",
"Insect",
"Megacolony",
1,
5000,
"Megacolony040",
CardIdentifier.AWAKING_DRAGONFLY
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Flash Edge Valkyrie",
"Elf",
"Gold Paladin",
1,
8000,
"GoldPaladin086",
CardIdentifier.FLASH_EDGE_VALKYRIE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Scout of Darkness, Vortimer",
"Human",
"Gold Paladin",
1,
7000,
"GoldPaladin087",
CardIdentifier.SCOUT_OF_DARKNESS__VORTIMER
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Blade Feather Valkyrie",
"Elf",
"Gold Paladin",
1,
7000,
"GoldPaladin088",
CardIdentifier.BLADE_FEATHER_VALKYRIE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"War-horse, Raging Storm",
"High Beast",
"Gold Paladin",
1,
6000,
"GoldPaladin089",
CardIdentifier.WAR_HORSE__RAGING_STORM
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Falcon Knight of the Azure",
"Human",
"Gold Paladin",
1,
4000,
"GoldPaladin090",
CardIdentifier.FALCON_KNIGHT_OF_THE_AZURE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Determination, Lamorak",
"Elf",
"Royal Paladin",
1,
10000,
"RoyalPaladin062",
CardIdentifier.KNIGHT_OF_DETERMINATION__LAMORAK
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Knight of Fighting Spirit, Dordona",
"Human",
"Shadow Paladin",
1,
10000,
"ShadowPaladin074",
CardIdentifier.KNIGHT_OF_FIGHTING_SPIRIT__DORDONA
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Cross Shot, Garp",
"Human",
"Kagero",
1,
10000,
"Kagero080",
CardIdentifier.CROSS_SHOT__GARP
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Twin Shine Swordsman, Marhaus",
"Human",
"Royal Paladin",
1,
10000,
"RoyalPaladin063",
CardIdentifier.TWIN_SHINE_SWORDSMAN__MARHAUS
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Gyro Slinger",
"Ogre",
"Spike Brothers",
1,
7000,
"SpikeBrothers045",
CardIdentifier.GYRO_SLINGER
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Commander, Garry Gannon",
"Ogre",
"Spike Brothers",
1,
6000,
"SpikeBrothers046",
CardIdentifier.COMMANDER__GARRY_GANNON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Eagle Knight of the Skies",
"Human",
"Royal Paladin",
1,
8000,
"RoyalPaladin064",
CardIdentifier.EAGLE_KNIGHT_OF_THE_SKIES
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Miru Biru",
"High Beast",
"Royal Paladin",
1,
6000,
"RoyalPaladin065",
CardIdentifier.MIRU_BIRU
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Omniscience Madonna",
"Workerloid",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank063",
CardIdentifier.OMNISCIENCE_MADONNA
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Onmyoji of the Moonlit Night",
"Human",
"Oracle Think Tank",
1,
8000,
"OracleThinkTank064",
CardIdentifier.ONMYOJI_OF_THE_MOONLIT_NIGHT
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Blue Scale Deer",
"High Beast",
"Oracle Think Tank",
1,
8000,
"OracleThinkTank065",
CardIdentifier.BLUE_SCALE_DEER
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Petal Fairy",
"Sylph",
"Oracle Think Tank",
1,
6000,
"OracleThinkTank066",
CardIdentifier.PETAL_FAIRY
));
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dragonic Executioner",
"Flame Dragon",
"Kagero",
1,
10000,
"Kagero081",
CardIdentifier.DRAGONIC_EXECUTIONER
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dragon Armored Knight",
"Human",
"Kagero",
1,
10000,
"Kagero082",
CardIdentifier.DRAGON_ARMORED_KNIGHT
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Grapeshot Wyvern",
"Winged Dragon",
"Kagero",
1,
6000,
"Kagero083",
CardIdentifier.GRAPESHOT_WYVERN
));
		
		Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Infinite Corrosion Form, Death Army Cosmo Lord",
"Alien",
"Nova Grappler",
1,
10000,
"NovaGrappler084",
CardIdentifier.INFINITE_CORROSION_FORM__DEATH_ARMY_COSMO_LORD
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Death Army Bishop",
"Battleroid",
"Nova Grappler",
1,
7000,
"NovaGrappler085",
CardIdentifier.DEATH_ARMY_BISHOP
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Brutal Joker",
"Battleroid",
"Nova Grappler",
1,
10000,
"NovaGrappler086",
CardIdentifier.BRUTAL_JOKER
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Death Army Knight",
"Battleroid",
"Nova Grappler",
1,
9000,
"NovaGrappler087",
CardIdentifier.DEATH_ARMY_KNIGHT
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Death Army Rook",
"Battleroid",
"Nova Grappler",
1,
10000,
"NovaGrappler088",
CardIdentifier.DEATH_ARMY_ROOK
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Death Army Pawn",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler089",
CardIdentifier.DEATH_ARMY_PAWN
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Minimum Raizer",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler090",
CardIdentifier.MINIMUM_RAIZER
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Battle Sister, Fromage",
"Elf",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank067",
CardIdentifier.BATTLE_SISTER__FROMAGE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Sister, Macaron",
"Elf",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank068",
CardIdentifier.BATTLE_SISTER__MACARON
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Sister, Omelet",
"Human",
"Oracle Think Tank",
1,
7000,
"OracleThinkTank069",
CardIdentifier.BATTLE_SISTER__OMELET
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Sister, Tarte",
"Elf",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank071",
CardIdentifier.BATTLE_SISTER__TARTE
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Battle Sister, Waffle",
"Elf",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank072",
CardIdentifier.BATTLE_SISTER__WAFFLE
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Battle Sister, Tiramisu",
"Elf",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank073",
CardIdentifier.BATTLE_SISTER__TIRAMISU
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Battle Sister, Assam",
"Elf",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank074",
CardIdentifier.BATTLE_SISTER__ASSAM
));

Card.Add (new CardInformation(0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Battle Sister, Chai",
"Elf",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank075",
CardIdentifier.BATTLE_SISTER__CHAI
));
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Eternal Idol, Pacifica",
"Mermaid",
"Bermuda Triangle",
1,
11000,
"BermudaTriangle036",
CardIdentifier.ETERNAL_IDOL__PACIFICA
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"PRISM-Promise, Labrador",
"Mermaid",
"Bermuda Triangle",
1,
11000,
"BermudaTriangle037",
CardIdentifier.PR___ISM_PROMISE__LABRADOR
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"PRISM-Image, Vert",
"Mermaid",
"Bermuda Triangle",
1,
11000,
"BermudaTriangle038",
CardIdentifier.PR___ISM_IMAGE__VERT
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Aurora Star, Coral",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle039",
CardIdentifier.AURORA_STAR__CORAL
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"PRISM-Promise, Celtic",
"Mermaid",
"Bermuda Triangle",
1,
9000,
"BermudaTriangle040",
CardIdentifier.PR___ISM_PROMISE__CELTIC
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"PRISM-Image, Clear",
"Mermaid",
"Bermuda Triangle",
1,
7000,
"BermudaTriangle041",
CardIdentifier.PR___ISM_IMAGE__CLEAR
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Shining Singer, Ionia",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle042",
CardIdentifier.SHINING_SINGER__IONIA
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"PRISM-Smile, Ligurian",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle043",
CardIdentifier.PR___ISM_SMILE__LIGURIAN
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Shiny Star, Coral",
"Mermaid",
"Bermuda Triangle",
1,
9000,
"BermudaTriangle044",
CardIdentifier.SHINY_STAR__CORAL
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"PRISM-Romance, Lumiere",
"Mermaid",
"Bermuda Triangle",
1,
9000,
"BermudaTriangle045",
CardIdentifier.PR___ISM_ROMANCE__LUMIERE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Sweets Harmony, Mona",
"Mermaid",
"Bermuda Triangle",
1,
7000,
"BermudaTriangle046",
CardIdentifier.SWEETS_HARMONY__MONA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"PRISM-Romance, Mercure",
"Mermaid",
"Bermuda Triangle",
1,
7000,
"BermudaTriangle047",
CardIdentifier.PR___ISM_ROMANCE__MERCURE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Mirror Diva, Biscayne",
"Mermaid",
"Bermuda Triangle",
1,
6000,
"BermudaTriangle048",
CardIdentifier.MIRROR_DIVA__BISCAYNE
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Angelic Star, Coral",
"Mermaid",
"Bermuda Triangle",
1,
4000,
"BermudaTriangle049",
CardIdentifier.ANGELIC_STAR__CORAL
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dancing Fan Princess, Minato",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle050",
CardIdentifier.DANCING_FAN_PRINCESS__MINATO
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"PRISM-Romance, Etoile",
"Mermaid",
"Bermuda Triangle",
1,
10000,
"BermudaTriangle051",
CardIdentifier.PR___ISM_ROMANCE__ETOILE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Intelli-beauty, Loire",
"Mermaid",
"Bermuda Triangle",
1,
8000,
"BermudaTriangle052",
CardIdentifier.INTELLI_BEAUTY__LOIRE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"PRISM-Image, Rosa",
"Mermaid",
"Bermuda Triangle",
1,
8000,
"BermudaTriangle053",
CardIdentifier.PR___ISM_IMAGE__ROSA
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"PRISM-Smile, Scotia",
"Mermaid",
"Bermuda Triangle",
1,
8000,
"BermudaTriangle054",
CardIdentifier.PR___ISM_SMILE__SCOTIA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Fresh Star, Coral",
"Mermaid",
"Bermuda Triangle",
1,
7000,
"BermudaTriangle055",
CardIdentifier.FRESH_STAR__CORAL
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"PRISM-Promise, Leyte",
"Mermaid",
"Bermuda Triangle",
1,
6000,
"BermudaTriangle056",
CardIdentifier.PR___ISM_PROMISE__LEYTE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Mascot Lady, Oria",
"Mermaid",
"Bermuda Triangle",
1,
6000,
"BermudaTriangle057",
CardIdentifier.MASCOT_LADY__ORIA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Library Madonna, Rion",
"Mermaid",
"Bermuda Triangle",
1,
6000,
"BermudaTriangle058",
CardIdentifier.LIBRARY_MADONNA__RION
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Dolphin Friend, Plage",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle059",
CardIdentifier.DOLPHIN_FRIEND__PLAGE
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"PRISM-Smile, Coro",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle060",
CardIdentifier.PR___ISM_SMILE__CORO
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Costume Change, Alk",
"Mermaid",
"Bermuda Triangle",
1,
4000,
"BermudaTriangle061",
CardIdentifier.COSTUME_CHANGE__ALK
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Gunslinger Star, Florida",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle062",
CardIdentifier.GUNSLINGER_STAR__FLORIDA
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"PRISM-Miracle, Canary",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle063",
CardIdentifier.PR___ISM_MIRACLE__CANARY
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"PRISM-Miracle, Adria",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle064",
CardIdentifier.PR___ISM_MIRACLE__ADRIA
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Mystery Smile, Aral",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle065",
CardIdentifier.MYSTERY_SMILE__ARAL
));

Card.Add (new CardInformation(0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"PRISM-Miracle, Timor",
"Mermaid",
"Bermuda Triangle",
1,
5000,
"BermudaTriangle066",
CardIdentifier.PR___ISM_MIRACLE__TIMOR
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Heartful Ale, Fundy",
"Mermaid",
"Bermuda Triangle",
1,
4000,
"BermudaTriangle067",
CardIdentifier.HEARTFUL_ALE__FUNDY
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"PRISM-Miracle, Irish",
"Mermaid",
"Bermuda Triangle",
1,
4000,
"BermudaTriangle068",
CardIdentifier.PR___ISM_MIRACLE__IRISH
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Alfred Early",
"Human",
"Royal Paladin",
1,
10000,
"RoyalPaladin066",
CardIdentifier.ALFRED_EARLY
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Holy Disaster Dragon",
"Cosmo Dragon",
"Royal Paladin",
1,
10000,
"RoyalPaladin067",
CardIdentifier.HOLY_DISASTER_DRAGON
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Steel Spear Liberator, Bleoberis",
"Human",
"Gold Paladin",
1,
11000,
"GoldPaladin091",
CardIdentifier.STEEL_SPEAR_LIBERATOR__BLEOBERIS
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Wisdom Keeper, Metis",
"Noble",
"Genesis",
1,
11000,
"Genesis039",
CardIdentifier.WISDOM_KEEPER__METIS
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Eradicator, Electric Shaper Dragon",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami096",
CardIdentifier.ERADICATOR__ELECTRIC_SHAPER_DRAGON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Story Teller",
"Human",
"Dark Irregulars",
1,
9000,
"DarkIrregulars072",
CardIdentifier.STORY_TELLER
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Pretty Celeb, Charlotte",
"Mermaid",
"Bermuda Triangle",
1,
9000,
"BermudaTriangle069",
CardIdentifier.PRETTY_CELEB__CHARLOTTE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dandelion Musketeer, Mirkka",
"Bioroid",
"Neo Nectar",
1,
6000,
"NeoNectar047",
CardIdentifier.DANDELION_MUSKETEER__MIRKKA
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Unrivaled Brush Wielder, Ponga",
"High Beast",
"Great Nature",
1,
10000,
"GreatNature057",
CardIdentifier.UNRIVALED_BRUSH_WIELDER__PONGA
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Water General of Wave-like Spirals, Benedict",
"Aquaroid",
"Aqua Force",
1,
10000,
"AquaForce070",
CardIdentifier.WATER_GENERAL_OF_WAVE_LIKE_SPIRALS__BENEDICT
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Hexagonal Magus",
"Human",
"Oracle Think Tank",
1,
11000,
"OracleThinkTank076",
CardIdentifier.HEXAGONAL_MAGUS
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Battle Sister, Parfait",
"Elf",
"Oracle Think Tank",
1,
11000,
"OracleThinkTank077",
CardIdentifier.BATTLE_SISTER__PARFAIT
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Battle Sister, Monaka",
"Elf",
"Oracle Think Tank",
1,
11000,
"OracleThinkTank078",
CardIdentifier.BATTLE_SISTER__MONAKA
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Stellar Magus",
"Human",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank079",
CardIdentifier.STELLAR_MAGUS
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Sister, Cocotte",
"Elf",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank080",
CardIdentifier.BATTLE_SISTER__COCOTTE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Briolette Magus",
"Human",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank081",
CardIdentifier.BRIOLETTE_MAGUS
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Tetra Magus",
"Human",
"Oracle Think Tank",
1,
6000,
"OracleThinkTank082",
CardIdentifier.TETRA_MAGUS
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Oracle Agent, Roys",
"Human",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank083",
CardIdentifier.ORACLE_AGENT__ROYS
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Cuore Magus",
"Human",
"Oracle Think Tank",
1,
9000,
"OracleThinkTank084",
CardIdentifier.CUORE_MAGUS
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Crescent Magus",
"Human",
"Oracle Think Tank",
1,
6000,
"OracleThinkTank085",
CardIdentifier.CRESCENT_MAGUS
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Sailand Magus",
"Human",
"Oracle Think Tank",
1,
10000,
"OracleThinkTank086",
CardIdentifier.SAILAND_MAGUS
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Battle Sister, Caramel",
"Elf",
"Oracle Think Tank",
1,
8000,
"OracleThinkTank087",
CardIdentifier.BATTLE_SISTER__CARAMEL
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Ripis Magus",
"Human",
"Oracle Think Tank",
1,
7000,
"OracleThinkTank088",
CardIdentifier.RIPIS_MAGUS
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Battle Sister, Lemonade",
"Elf",
"Oracle Think Tank",
1,
5000,
"OracleThinkTank089",
CardIdentifier.BATTLE_SISTER__LEMONADE
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Pentagonal Magus",
"Human",
"Oracle Think Tank",
1,
11000,
"OracleThinkTank090",
CardIdentifier.PENTAGONAL_MAGUS
));
		Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Immortal, Asura Kaiser",
"Battleroid",
"Nova Grappler",
1,
11000,
"NovaGrappler091",
CardIdentifier.IMMORTAL__ASURA_KAISER
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Galaxy Blaukluger",
"Battleroid",
"Nova Grappler",
1,
11000,
"NovaGrappler092",
CardIdentifier.GALAXY_BLAUKLUGER
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Mond Blaukluger",
"Battleroid",
"Nova Grappler",
1,
11000,
"NovaGrappler093",
CardIdentifier.MOND_BLAUKLUGER
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Mars Blaukluger",
"Battleroid",
"Nova Grappler",
1,
9000,
"NovaGrappler094",
CardIdentifier.MARS_BLAUKLUGER
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Flower Lei Leprechaun",
"Battleroid",
"Nova Grappler",
1,
7000,
"NovaGrappler095",
CardIdentifier.FLOWER_LEI_LEPRECHAUN
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Blau Dunkelheit",
"Battleroid",
"Nova Grappler",
1,
6000,
"NovaGrappler096",
CardIdentifier.BLAU_DUNKELHEIT
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Jupiter Blaukluger",
"Battleroid",
"Nova Grappler",
1,
10000,
"NovaGrappler097",
CardIdentifier.JUPITER_BLAUKLUGER
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Grosse Baer",
"Battleroid",
"Nova Grappler",
1,
9000,
"NovaGrappler098",
CardIdentifier.GROSSE_BAER
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Daredevil Samurai",
"Battleroid",
"Nova Grappler",
1,
9000,
"NovaGrappler099",
CardIdentifier.DAREDEVIL_SAMURAI
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Polar Stern",
"Battleroid",
"Nova Grappler",
1,
7000,
"NovaGrappler100",
CardIdentifier.POLAR_STERN
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Morgenrot",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler101",
CardIdentifier.MORGENROT
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Pluto Blaukluger",
"Battleroid",
"Nova Grappler",
1,
10000,
"NovaGrappler102",
CardIdentifier.PLUTO_BLAUKLUGER
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Bear Down Samurai",
"Battleroid",
"Nova Grappler",
1,
7000,
"NovaGrappler103",
CardIdentifier.BEAR_DOWN_SAMURAI
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Blade Arm Leprechaun",
"Battleroid",
"Nova Grappler",
1,
4000,
"NovaGrappler104",
CardIdentifier.BLADE_ARM_LEPRECHAUN
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Schones Wetter",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler105",
CardIdentifier.SCHONES_WETTER
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Schneeregen",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler106",
CardIdentifier.SCHNEEREGEN
));

Card.Add (new CardInformation(0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Regenbogen",
"Battleroid",
"Nova Grappler",
1,
5000,
"NovaGrappler107",
CardIdentifier.REGENBOGEN
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Starker Wind",
"Battleroid",
"Nova Grappler",
1,
4000,
"NovaGrappler108",
CardIdentifier.STARKER_WIND
));
		Card.Add (new CardInformation(4,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Transcendence Dragon, Dragonic Nouvelle Vague",
"Flame Dragon",
"Kagero",
1,
13000,
"Kagero084",
CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Cruel Dragon",
"Flame Dragon",
"Kagero",
1,
11000,
"Kagero085",
CardIdentifier.CRUEL_DRAGON
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Blast Bulk Dragon",
"Flame Dragon",
"Kagero",
1,
11000,
"Kagero086",
CardIdentifier.BLAST_BULK_DRAGON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Nouvellecritic Dragon",
"Flame Dragon",
"Kagero",
1,
9000,
"Kagero087",
CardIdentifier.NOUVELLECRITIC_DRAGON
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dragonic Gaias",
"Tear Dragon",
"Kagero",
1,
6000,
"Kagero088",
CardIdentifier.DRAGONIC_GAIAS
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Dragon Dancer, Maria",
"Human",
"Kagero",
1,
6000,
"Kagero089",
CardIdentifier.DRAGON_DANCER__MARIA
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dragon Knight, Neshart",
"Human",
"Kagero",
1,
9000,
"Kagero090",
CardIdentifier.DRAGON_KNIGHT__NESHART
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dragon Knight, Ashgar",
"Human",
"Kagero",
1,
7000,
"Kagero091",
CardIdentifier.DRAGON_KNIGHT__ASHGAR
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Nouvelleroman Dragon",
"Flame Dragon",
"Kagero",
1,
7000,
"Kagero092",
CardIdentifier.NOUVELLEROMAN_DRAGON
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dragon Knight, Morteza",
"Human",
"Kagero",
1,
10000,
"Kagero093",
CardIdentifier.DRAGON_KNIGHT__MORTEZA
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Bakingrim Dragon",
"Flame Dragon",
"Kagero",
1,
10000,
"Kagero094",
CardIdentifier.BAKINGRIM_DRAGON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Genie Soldat",
"Golem",
"Kagero",
1,
11000,
"Kagero095",
CardIdentifier.GENIE_SOLDAT
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Demonic Dragon Mage, Kongara",
"Dragonman",
"Kagero",
1,
8000,
"Kagero096",
CardIdentifier.DEMONIC_DRAGON_MAGE__KONGARA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Scale Dragon of the Magma Cave",
"Winged Dragon",
"Kagero",
1,
6000,
"Kagero097",
CardIdentifier.SCALE_DRAGON_OF_THE_MAGMA_CAVE
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Solitary Liberator, Gancelot",
"Elf",
"Gold Paladin",
1,
11000,
"GoldPaladin092",
CardIdentifier.SOLITARY_LIBERATOR__GANCELOT
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Dignified Gold Dragon",
"Cosmo Dragon",
"Gold Paladin",
1,
10000,
"GoldPaladin093",
CardIdentifier.DIGNIFIED_GOLD_DRAGON
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Onslaught Liberator, Maelzion",
"Human",
"Gold Paladin",
1,
10000,
"GoldPaladin094",
CardIdentifier.ONSLAUGHT_LIBERATOR__MAELZION
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Liberator of Silence, Gallatin",
"Human",
"Gold Paladin",
1,
10000,
"GoldPaladin095",
CardIdentifier.LIBERATOR_OF_SILENCE__GALLATIN
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Liberator of Royalty, Phallon",
"Giant",
"Gold Paladin",
1,
9000,
"GoldPaladin096",
CardIdentifier.LIBERATOR_OF_ROYALTY__PHALLON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Zoom Down Eagle",
"High Beast",
"Gold Paladin",
1,
8000,
"GoldPaladin098",
CardIdentifier.ZOOM_DOWN_EAGLE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Zoigal Liberator",
"High Beast",
"Gold Paladin",
1,
8000,
"GoldPaladin099",
CardIdentifier.ZOIGAL_LIBERATOR
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Little Liberator, Marron",
"Giant",
"Gold Paladin",
1,
7000,
"GoldPaladin101",
CardIdentifier.LITTLE_LIBERATOR__MARRON
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Pomerugal Liberator",
"High Beast",
"Gold Paladin",
1,
7000,
"GoldPaladin102",
CardIdentifier.POMERUGAL_LIBERATOR
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Future Liberator, Llew",
"Human",
"Gold Paladin",
1,
6000,
"GoldPaladin103",
CardIdentifier.FUTURE_LIBERATOR__LLEW
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Angelic Liberator",
"Angel",
"Gold Paladin",
1,
6000,
"GoldPaladin104",
CardIdentifier.ANGELIC_LIBERATOR
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Strike Liberator",
"Human",
"Gold Paladin",
1,
5000,
"GoldPaladin105",
CardIdentifier.STRIKE_LIBERATOR
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Armed Liberator, Gwydion",
"Gnome",
"Gold Paladin",
1,
5000,
"GoldPaladin106",
CardIdentifier.ARMED_LIBERATOR__GWYDION
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Fortune Liberator",
"Sylph",
"Gold Paladin",
1,
5000,
"GoldPaladin107",
CardIdentifier.FORTUNE_LIBERATOR
));

Card.Add (new CardInformation(0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Elixir Liberator",
"Elf",
"Gold Paladin",
1,
5000,
"GoldPaladin108",
CardIdentifier.ELIXIR_LIBERATOR
)); 
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Eradicator, Vowing Sword Dragon",
"Thunder Dragon",
"Narukami",
1,
11000,
"Narukami097",
CardIdentifier.ERADICATOR__VOWING_SWORD_DRAGON
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Barrage Eradicator, Zion",
"Human",
"Narukami",
1,
10000,
"Narukami098",
CardIdentifier.BARRAGE_ERADICATOR__ZION
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Discharging Dragon",
"Thunder Dragon",
"Narukami",
1,
10000,
"Narukami099",
CardIdentifier.DISCHARGING_DRAGON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Eradicator, Thunder Boom Dragon",
"Thunder Dragon",
"Narukami",
1,
10000,
"Narukami100",
CardIdentifier.ERADICATOR__THUNDER_BOOM_DRAGON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Eradicator, Spark Rain Dragon",
"Thunder Dragon",
"Narukami",
1,
9000,
"Narukami101",
CardIdentifier.ERADICATOR__SPARK_RAIN_DRAGON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Assassin Sword Eradicator, Susei",
"Human",
"Narukami",
1,
8000,
"Narukami102",
CardIdentifier.ASSASSIN_SWORD_ERADICATOR__SUSEI
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Dragon Dancer, Veronica",
"Human",
"Narukami",
1,
8000,
"Narukami103",
CardIdentifier.DRAGON_DANCER__VERONICA
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Lightning Blade Eradicator, Jeem",
"Demon",
"Narukami",
1,
8000,
"Narukami104",
CardIdentifier.LIGHTNING_BLADE_ERADICATOR__JEEM
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
0,
"Eradicator, Demolition Dragon",
"Thunder Dragon",
"Narukami",
1,
7000,
"Narukami105",
CardIdentifier.ERADICATOR__DEMOLITION_DRAGON
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Dust Storm Eradicator, Toko",
"Human",
"Narukami",
1,
7000,
"Narukami106",
CardIdentifier.DUST_STORM_ERADICATOR__TOKO
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Eradicator of Fire, Kohkaiji",
"Demon",
"Narukami",
1,
6000,
"Narukami107",
CardIdentifier.ERADICATOR_OF_FIRE__KOHKAIJI
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Stone Bullet Eradicator, Houki",
"Human",
"Narukami",
1,
6000,
"Narukami108",
CardIdentifier.STONE_BULLET_ERADICATOR__HOUKI
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Eradicator, Yellow Gem Carbuncle",
"High Beast",
"Narukami",
1,
5000,
"Narukami109",
CardIdentifier.ERADICATOR__YELLOW_GEM_CARBUNCLE
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Eradicator, Dragon Mage",
"Flame Dragon",
"Narukami",
1,
5000,
"Narukami110",
CardIdentifier.ERADICATOR__DRAGON_MAGE
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Zephyr Eradicator, Hayate",
"Demon",
"Narukami",
1,
5000,
"Narukami111",
CardIdentifier.ZEPHYR_ERADICATOR__HAYATE
));

Card.Add (new CardInformation(0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Worm Toxin Eradicator, Seiobo",
"Dragonman",
"Narukami",
1,
5000,
"Narukami112",
CardIdentifier.WORM_TOXIN_ERADICATOR__SEIOBO
));		
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Illusionary Revenger, Mordred Phantom",
"Elf",
"Shadow Paladin",
1,
11000,
"ShadowPaladin075",
CardIdentifier.ILLUSIONARY_REVENGER__MORDRED_PHANTOM
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Venomous Breath Dragon",
"Abyss Dragon",
"Shadow Paladin",
1,
10000,
"ShadowPaladin076",
CardIdentifier.VENOMOUS_BREATH_DRAGON
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Revenger of Labyrinth, Araun",
"Elf",
"Shadow Paladin",
1,
10000,
"ShadowPaladin077",
CardIdentifier.REVENGER_OF_LABYRINTH__ARAUN
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Revenger of Darkness, Rugos",
"Human",
"Shadow Paladin",
1,
10000,
"ShadowPaladin078",
CardIdentifier.REVENGER_OF_DARKNESS__RUGOS
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Nullity Revenger, Masquerade",
"Human",
"Shadow Paladin",
1,
9000,
"ShadowPaladin079",
CardIdentifier.NULLITY_REVENGER__MASQUERADE
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Coilbau Revenger",
"High Beast",
"Shadow Paladin",
1,
8000,
"ShadowPaladin081",
CardIdentifier.COILBAU_REVENGER
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Revenger Fortress, Fatalita",
"Golem",
"Shadow Paladin",
1,
8000,
"ShadowPaladin082",
CardIdentifier.REVENGER_FORTRESS__FATALITA
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Sacrilege Revenger, Berith",
"Demon",
"Shadow Paladin",
1,
7000,
"ShadowPaladin083",
CardIdentifier.SACRILEGE_REVENGER__BERITH
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Transient Revenger, Masquerade",
"Human",
"Shadow Paladin",
1,
7000,
"ShadowPaladin084",
CardIdentifier.TRANSIENT_REVENGER__MASQUERADE
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Buranbau Revenger",
"High Beast",
"Shadow Paladin",
1,
6000,
"ShadowPaladin085",
CardIdentifier.BURANBAU_REVENGER
));

Card.Add (new CardInformation(0,
TriggerIcon.NONE,
SkillIcon.BOOST,
10000,
"Revenger of Fear, Fritz",
"Human",
"Shadow Paladin",
1,
6000,
"ShadowPaladin086",
CardIdentifier.REVENGER_OF_FEAR__FRITZ
));

Card.Add (new CardInformation(0,
TriggerIcon.CRITICAL,
SkillIcon.BOOST,
10000,
"Grim Revenger",
"Demon",
"Shadow Paladin",
1,
5000,
"ShadowPaladin087",
CardIdentifier.GRIM_REVENGER
));

Card.Add (new CardInformation(0,
TriggerIcon.DRAW,
SkillIcon.BOOST,
5000,
"Freezing Revenger",
"Angel",
"Shadow Paladin",
1,
5000,
"ShadowPaladin088",
CardIdentifier.FREEZING_REVENGER
));

Card.Add (new CardInformation(0,
TriggerIcon.STAND,
SkillIcon.BOOST,
10000,
"Awaking Revenger",
"High Beast",
"Shadow Paladin",
1,
5000,
"ShadowPaladin089",
CardIdentifier.AWAKING_REVENGER
));

Card.Add (new CardInformation(0,
TriggerIcon.HEAL,
SkillIcon.BOOST,
10000,
"Healing Revenger",
"Angel",
"Shadow Paladin",
1,
5000,
"ShadowPaladin090",
CardIdentifier.HEALING_REVENGER
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Star-vader, Infinite Zero Dragon",
"Cyber Dragon",
"Link Joker",
1,
11000,
"LinkJoker023",
CardIdentifier.STAR_VADER__INFINITE_ZERO_DRAGON
));
		
Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Raid Star-vader, Francium",
"Cyberoid",
"Link Joker",
1,
10000,
"LinkJoker024",
CardIdentifier.RAID_STAR_VADER__FRANCIUM
));

Card.Add (new CardInformation(3,
TriggerIcon.NONE,
SkillIcon.TWIN_DRIVE,
0,
"Twilight Baron",
"Cyber Golem",
"Link Joker",
1,
10000,
"LinkJoker025",
CardIdentifier.TWILIGHT_BARON
));
		
Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Soaring Star-vader, Krypton",
"Cyberoid",
"Link Joker",
1,
10000,
"LinkJoker026",
CardIdentifier.SOARING_STAR_VADER__KRYPTON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Star-vader, Mobius Breath Dragon",
"Cyber Dragon",
"Link Joker",
1,
9000,
"LinkJoker027",
CardIdentifier.STAR_VADER__MOBIUS_BREATH_DRAGON
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Unrivaled Star-vader, Radon",
"Cyberoid",
"Link Joker",
1,
9000,
"LinkJoker028",
CardIdentifier.UNRIVALED_STAR_VADER__RADON
));
		
Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Star-vader, Pulsar Bear",
"Cyber Beast",
"Link Joker",
1,
8000,
"LinkJoker029",
CardIdentifier.STAR_VADER__PULSAR_BEAR
));

Card.Add (new CardInformation(2,
TriggerIcon.NONE,
SkillIcon.INTERCEPT,
5000,
"Swift Star-vader, Strontium",
"Cyber Fairy",
"Link Joker",
1,
8000,
"LinkJoker030",
CardIdentifier.SWIFT_STAR_VADER__STRONTIUM
));

Card.Add (new CardInformation(1,
TriggerIcon.NONE,
SkillIcon.BOOST,
5000,
"Hollow Twin Blades, Binary Star",
"Cyberoid",
"Link Joker",
1,
8000,
"LinkJoker031",
CardIdentifier.HOLLOW_TWIN_BLADES__BINARY_STAR
));

		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Pursuit Star-vader, Fermium",
		                              "Cyberoid",
		                              "Link Joker",
		                              1,
		                              7000,
		                              "LinkJoker032",
		                              CardIdentifier.PURSUIT_STAR_VADER__FERMIUM
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Demonic Bullet Star-vader, Neon",
		                              "Cyberoid",
		                              "Link Joker",
		                              1,
		                              7000,
		                              "LinkJoker033",
		                              CardIdentifier.DEMONIC_BULLET_STAR_VADER__NEON
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Star-vader, Aurora Eagle",
		                              "Cyber Beast",
		                              "Link Joker",
		                              1,
		                              6000,
		                              "LinkJoker034",
		                              CardIdentifier.STAR_VADER__AURORA_EAGLE
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Nova Star-vader, Actinium",
		                              "Cyberoid",
		                              "Link Joker",
		                              1,
		                              6000,
		                              "LinkJoker035",
		                              CardIdentifier.NOVA_STAR_VADER__ACTINIUM
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.CRITICAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Star-vader, Meteor Liger",
		                              "Cyber Beast",
		                              "Link Joker",
		                              1,
		                              5000,
		                              "LinkJoker036",
		                              CardIdentifier.STAR_VADER__METEOR_LIGER
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.DRAW,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Star-vader, Nebula Captor",
		                              "Cyber Fairy",
		                              "Link Joker",
		                              1,
		                              5000,
		                              "LinkJoker037",
		                              CardIdentifier.STAR_VADER__NEBULA_CAPTOR
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.STAND,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Keyboard Star-vader, Bismuth",
		                              "Cyberoid",
		                              "Link Joker",
		                              1,
		                              5000,
		                              "LinkJoker038",
		                              CardIdentifier.KEYBOARD_STAR_VADER__BISMUTH
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.HEAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Star-vader, Stellar Garage",
		                              "Cyber Fairy",
		                              "Link Joker",
		                              1,
		                              5000,
		                              "LinkJoker039",
		                              CardIdentifier.STAR_VADER__STELLAR_GARAGE
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Super Dimensional Robo, Daikaiser",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              11000,
		                              "DimensionPolice053",
		                              CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAIKAISER
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Electro-star Combination, Cosmogreat",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              10000,
		                              "DimensionPolice054",
		                              CardIdentifier.ELECTRO_STAR_COMBINATION__COSMOGREAT
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Dimensional Robo, Daifighter",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              10000,
		                              "DimensionPolice055",
		                              CardIdentifier.DIMENSIONAL_ROBO__DAIFIGHTER
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Dimensional Robo, Kaizard",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              9000,
		                              "DimensionPolice056",
		                              CardIdentifier.DIMENSIONAL_ROBO__KAIZARD
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Dimensional Robo, Daidriller",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              8000,
		                              "DimensionPolice057",
		                              CardIdentifier.DIMENSIONAL_ROBO__DAIDRILLER
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Dimensional Robo, Daitiger",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              7000,
		                              "DimensionPolice058",
		                              CardIdentifier.DIMENSIONAL_ROBO__DAITIGER
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Dimensional Robo, Daibrave",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              7000,
		                              "DimensionPolice059",
		                              CardIdentifier.DIMENSIONAL_ROBO__DAIBRAVE
		                              ));
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Dimensional Robo, Daicrane",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              5000,
		                              "DimensionPolice060",
		                              CardIdentifier.DIMENSIONAL_ROBO__DAICRANE
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Dimensional Robo, Goflight",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              5000,
		                              "DimensionPolice061",
		                              CardIdentifier.DIMENSIONAL_ROBO__GOFLIGHT
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Dimensional Robo, Gorescue",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              5000,
		                              "DimensionPolice062",
		                              CardIdentifier.DIMENSIONAL_ROBO__GORESCUE
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Regalia of Wisdom, Angelica",
		                              "Human",
		                              "Genesis",
		                              1,
		                              11000,
		                              "Genesis040",
		                              CardIdentifier.REGALIA_OF_WISDOM__ANGELICA
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Battle Maiden, Mizuha",
		                              "Noble",
		                              "Genesis",
		                              1,
		                              10000,
		                              "Genesis041",
		                              CardIdentifier.BATTLE_MAIDEN__MIZUHA
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Goddess of Trees, Jupiter",
		                              "Noble",
		                              "Genesis",
		                              1,
		                              9000,
		                              "Genesis042",
		                              CardIdentifier.GODDESS_OF_TREES__JUPITER
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Battle Maiden, Shitateruhime",
		                              "Noble",
		                              "Genesis",
		                              1,
		                              8000,
		                              "Genesis043",
		                              CardIdentifier.BATTLE_MAIDEN__SHITATERUHIME
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Existence Angel",
		                              "Angel",
		                              "Genesis",
		                              1,
		                              7000,
		                              "Genesis044",
		                              CardIdentifier.EXISTENCE_ANGEL
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Apple Witch, Cider",
		                              "Human",
		                              "Genesis",
		                              1,
		                              7000,
		                              "Genesis045",
		                              CardIdentifier.APPLE_WITCH__CIDER
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Reflector Angel",
		                              "Angel",
		                              "Genesis",
		                              1,
		                              6000,
		                              "Genesis046",
		                              CardIdentifier.REFLECTOR_ANGEL
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.CRITICAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Lemon Witch, Limonccino",
		                              "Human",
		                              "Genesis",
		                              1,
		                              5000,
		                              "Genesis047",
		                              CardIdentifier.LEMON_WITCH__LIMONCCINO
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Sanctuary Guard Dragon",
		                              "Cosmo Dragon",
		                              "Royal Paladin",
		                              1,
		                              11000,
		                              "RoyalPaladin068",
		                              CardIdentifier.SANCTUARY_GUARD_DRAGON
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Battle Flag Knight, Constance",
		                              "Human",
		                              "Royal Paladin",
		                              1,
		                              9000,
		                              "RoyalPaladin069",
		                              CardIdentifier.BATTLE_FLAG_KNIGHT__CONSTANCE
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Pathetic Jewel Knight, Olwen",
		                              "Elf",
		                              "Royal Paladin",
		                              1,
		                              8000,
		                              "RoyalPaladin070",
		                              CardIdentifier.PATHETIC_JEWEL_KNIGHT__OLWEN
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Regret Jewel Knight, Urien",
		                              "Elf",
		                              "Royal Paladin",
		                              1,
		                              7000,
		                              "RoyalPaladin071",
		                              CardIdentifier.REGRET_JEWEL_KNIGHT__URIEN
		                              ));

		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Rendgal",
		                              "High Beast",
		                              "Royal Paladin",
		                              1,
		                              7000,
		                              "RoyalPaladin072",
		                              CardIdentifier.RENDGAL
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Rainbow-calling Bard",
		                              "Human",
		                              "Royal Paladin",
		                              1,
		                              6000,
		                              "RoyalPaladin073",
		                              CardIdentifier.RAINBOW_CALLING_BARD
		                              ));

		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Starting Legend, Ambrosius",
		                              "Human",
		                              "Royal Paladin",
		                              1,
		                              4000,
		                              "RoyalPaladin074",
		                              CardIdentifier.STARTING_LEGEND__AMBROSIUS
		                              ));

		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "No Life King, Death Anchor",
		                              "Ghost",
		                              "Dark Irregulars",
		                              1,
		                              10000,
		                              "DarkIrregulars073",
		                              CardIdentifier.NO_LIFE_KING__DEATH_ANCHOR
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Flirtatious Succubus",
		                              "Succubus",
		                              "Dark Irregulars",
		                              1,
		                              9000,
		                              "DarkIrregulars074",
		                              CardIdentifier.FLIRTATIOUS_SUCCUBUS
		                              ));

		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Dragon Undead, Skull Dragon",
		                              "Skeleton",
		                              "Granblue",
		                              1,
		                              10000,
		                              "Granblue045",
		                              CardIdentifier.DRAGON_UNDEAD__SKULL_DRAGON
		                              ));

		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Stamp Sea Otter",
		                              "High Beast",
		                              "Great Nature",
		                              1,
		                              6000,
		                              "GreatNature058",
		                              CardIdentifier.STAMP_SEA_OTTER
		                              ));

		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Eradicator, Spark Horn Dragon",
		                              "Thunder Dragon",
		                              "Narukami",
		                              1,
		                              10000,
		                              "Narukami113",
		                              CardIdentifier.ERADICATOR__SPARK_HORN_DRAGON
		                              ));

		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Crimson Witch, Radish",
		                              "Elf",
		                              "Genesis",
		                              1,
		                              10000,
		                              "Genesis048",
		                              CardIdentifier.CRIMSON_WITCH__RADISH
		                              ));

		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Cleanup Celestial, Ramiel \"Reverse\"",
		                              "Angel",
		                              "Angel Feather",
		                              1,
		                              11000,
		                              "AngelFeather066",
		                              CardIdentifier.CLEANUP_CELESTIAL__RAMIEL______REVERSE_____
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Strongest Beast Deity, Ethics Buster Extreme",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              11000,
		                              "NovaGrappler109",
		                              CardIdentifier.STRONGEST_BEAST_DEITY__ETHICS_BUSTER_EXTREME
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Deadliest Beast Deity, Ethics Buster \"Reverse\"",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              11000,
		                              "NovaGrappler110",
		                              CardIdentifier.DEADLIEST_BEAST_DEITY__ETHICS_BUSTER______REVERSE_____
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Dark Dimensional Robo, \"Reverse\" Daiyusha",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              11000,
		                              "DimensionPolice063",
		                              CardIdentifier.DARK_DIMENSIONAL_ROBO_______REVERSE______DAIYUSHA
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Original Saver, Zero",
		                              "Alien",
		                              "Dimension Police",
		                              1,
		                              11000,
		                              "DimensionPolice064",
		                              CardIdentifier.ORIGINAL_SAVER__ZERO
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Star-vader, Chaos Breaker Dragon",
		                              "Cyber Dragon",
		                              "Link Joker",
		                              1,
		                              11000,
		                              "LinkJoker040",
		                              CardIdentifier.STAR_VADER__CHAOS_BREAKER_DRAGON
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Blue Wave Dragon, Tetra-drive Dragon",
		                              "Tear Dragon",
		                              "Aqua Force",
		                              1,
		                              11000,
		                              "AquaForce071",
		                              CardIdentifier.BLUE_WAVE_DRAGON__TETRA_DRIVE_DRAGON
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Emergency Celestial, Danielle",
		                              "Angel",
		                              "Angel Feather",
		                              1,
		                              9000,
		                              "AngelFeather067",
		                              CardIdentifier.EMERGENCY_CELESTIAL__DANIELLE
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Beast Deity, Brainy Papio",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              9000,
		                              "NovaGrappler111",
		                              CardIdentifier.BEAST_DEITY__BRAINY_PAPIO
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              0,
		                              "Beast Deity, Solar Falcon",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              6000,
		                              "NovaGrappler112",
		                              CardIdentifier.BEAST_DEITY__SOLAR_FALCON
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              0,
		                              "Dimensional Robo, Daishield",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              6000,
		                              "DimensionPolice065",
		                              CardIdentifier.DIMENSIONAL_ROBO__DAISHIELD
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Star-vader, Colony Maker",
		                              "Cyber Fairy",
		                              "Link Joker",
		                              1,
		                              9000,
		                              "LinkJoker041",
		                              CardIdentifier.STAR_VADER__COLONY_MAKER
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Lord of the Seven Seas, Nightmist",
		                              "Vampire",
		                              "Granblue",
		                              1,
		                              11000,
		                              "Granblue046",
		                              CardIdentifier.LORD_OF_THE_SEVEN_SEAS__NIGHTMIST
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Ice Prison Hades Emperor, Cocytus \"Reverse\"",
		                              "Skeleton",
		                              "Granblue",
		                              1,
		                              11000,
		                              "Granblue047",
		                              CardIdentifier.ICE_PRISON_HADES_EMPEROR__COCYTUS______REVERSE_____
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Cobalt Wave Dragon",
		                              "Tear Dragon",
		                              "Aqua Force",
		                              1,
		                              10000,
		                              "AquaForce072",
		                              CardIdentifier.COBALT_WAVE_DRAGON
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "School Punisher, Leo-pald \"Reverse\"",
		                              "High Beast",
		                              "Great Nature",
		                              1,
		                              11000,
		                              "GreatNature059",
		                              CardIdentifier.SCHOOL_PUNISHER__LEO_PALD______REVERSE_____
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Honorary Professor, Chatnoir",
		                              "High Beast",
		                              "Great Nature",
		                              1,
		                              11000,
		                              "GreatNature060",
		                              CardIdentifier.HONORARY_PROFESSOR__CHATNOIR
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Operation Celestial, Armen",
		                              "Angel",
		                              "Angel Feather",
		                              1,
		                              10000,
		                              "AngelFeather068",
		                              CardIdentifier.OPERATION_CELESTIAL__ARMEN
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Nursing Celestial, Narelle",
		                              "Angel",
		                              "Angel Feather",
		                              1,
		                              7000,
		                              "AngelFeather069",
		                              CardIdentifier.NURSING_CELESTIAL__NARELLE
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Beast Deity, Max Beat",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              7000,
		                              "NovaGrappler113",
		                              CardIdentifier.BEAST_DEITY__MAX_BEAT
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Energy Charger",
		                              "Workeroid",
		                              "Nova Grappler",
		                              1,
		                              5000,
		                              "NovaGrappler114",
		                              CardIdentifier.ENERGY_CHARGER
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Space Dragon, Dogurumadora",
		                              "Alien",
		                              "Dimension Police",
		                              1,
		                              10000,
		                              "DimensionPolice066",
		                              CardIdentifier.SPACE_DRAGON__DOGURUMADORA
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Dimensional Robo, Daiheart",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              9000,
		                              "DimensionPolice067",
		                              CardIdentifier.DIMENSIONAL_ROBO__DAIHEART
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Dimensional Robo, Gocannon",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              6000,
		                              "DimensionPolice068",
		                              CardIdentifier.DIMENSIONAL_ROBO__GOCANNON
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Dimensional Robo, Daimagnum",
		                              "Battleroid",
		                              "Dimension Police",
		                              1,
		                              5000,
		                              "DimensionPolice069",
		                              CardIdentifier.DIMENSIONAL_ROBO__DAIMAGNUM
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Knight of Entropy",
		                              "Cyber Golem",
		                              "Link Joker",
		                              1,
		                              10000,
		                              "LinkJoker042",
		                              CardIdentifier.KNIGHT_OF_ENTROPY
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Paradise Elk",
		                              "Cyber Beast",
		                              "Link Joker",
		                              1,
		                              9000,
		                              "LinkJoker043",
		                              CardIdentifier.PARADISE_ELK
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Earnest Star-vader, Selenium",
		                              "Cyberoid",
		                              "Link Joker",
		                              1,
		                              5000,
		                              "LinkJoker044",
		                              CardIdentifier.EARNEST_STAR_VADER__SELENIUM
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Demonic Seas Necromancer, Barbaros",
		                              "Gillman",
		                              "Granblue",
		                              1,
		                              10000,
		                              "Granblue048",
		                              CardIdentifier.DEMONIC_SEAS_NECROMANCER__BARBAROS
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Sea Strolling Banshee",
		                              "Ghost",
		                              "Granblue",
		                              1,
		                              6000,
		                              "Granblue049",
		                              CardIdentifier.SEA_STROLLING_BANSHEE
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Tidal Assault",
		                              "Aquaroid",
		                              "Aqua Force",
		                              1,
		                              9000,
		                              "AquaForce073",
		                              CardIdentifier.TIDAL_ASSAULT
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Wheel Assault",
		                              "Aquaroid",
		                              "Aqua Force",
		                              1,
		                              7000,
		                              "AquaForce074",
		                              CardIdentifier.WHEEL_ASSAULT
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Bubble Edge Dracokid",
		                              "Tear Dragon",
		                              "Aqua Force",
		                              1,
		                              5000,
		                              "AquaForce075",
		                              CardIdentifier.BUBBLE_EDGE_DRACOKID
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Abacus Bear",
		                              "Warbeast",
		                              "Great Nature",
		                              1,
		                              10000,
		                              "GreatNature061",
		                              CardIdentifier.ABACUS_BEAR
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Washup Raccoon",
		                              "High Beast",
		                              "Great Nature",
		                              1,
		                              7000,
		                              "GreatNature062",
		                              CardIdentifier.WASHUP_RACCOON
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Dressing Barrage, Sahariel",
		                              "Angel",
		                              "Angel Feather",
		                              1,
		                              10000,
		                              "AngelFeather070",
		                              CardIdentifier.DRESSING_BARRAGE__SAHARIEL
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Surgical Celestial, Batariel",
		                              "Angel",
		                              "Angel Feather",
		                              1,
		                              8000,
		                              "AngelFeather071",
		                              CardIdentifier.SURGICAL_CELESTIAL__BATARIEL
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Twinkleknife Angel",
		                              "Angel",
		                              "Angel Feather",
		                              1,
		                              8000,
		                              "AngelFeather072",
		                              CardIdentifier.TWINKLEKNIFE_ANGEL
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Anesthesia Celestial, Rumael",
		                              "Angel",
		                              "Angel Feather",
		                              1,
		                              6000,
		                              "AngelFeather073",
		                              CardIdentifier.ANESTHESIA_CELESTIAL__RUMAEL
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Tender Pigeon",
		                              "High Beast",
		                              "Angel Feather",
		                              1,
		                              6000,
		                              "AngelFeather074",
		                              CardIdentifier.TENDER_PIGEON
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Penetrate Celestial, Gadriel",
		                              "Angel",
		                              "Angel Feather",
		                              1,
		                              5000,
		                              "AngelFeather075",
		                              CardIdentifier.PENETRATE_CELESTIAL__GADRIEL
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Death Army Commander",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              10000,
		                              "NovaGrappler115",
		                              CardIdentifier.DEATH_ARMY_COMMANDER
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Beast Deity, Damned Leo",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              10000,
		                              "NovaGrappler116",
		                              CardIdentifier.BEAST_DEITY__DAMNED_LEO
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Gatling Raizer",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              8000,
		                              "NovaGrappler117",
		                              CardIdentifier.GATLING_RAIZER
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Beast Deity, Desert Gator",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              7000,
		                              "NovaGrappler118",
		                              CardIdentifier.BEAST_DEITY__DESERT_GATOR
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Beast Deity, Night Jackal",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              5000,
		                              "NovaGrappler119",
		                              CardIdentifier.BEAST_DEITY__NIGHT_JACKAL
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.CRITICAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Beast Deity, Death Stinger",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              5000,
		                              "NovaGrappler120",
		                              CardIdentifier.BEAST_DEITY__DEATH_STINGER
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.DRAW,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Beast Deity, Banpauros",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              5000,
		                              "NovaGrappler121",
		                              CardIdentifier.BEAST_DEITY__BANPAUROS
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.STAND,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Beast Deity, Bright Cobra",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              5000,
		                              "NovaGrappler122",
		                              CardIdentifier.BEAST_DEITY__BRIGHT_COBRA
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.HEAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Beast Deity, Rescue Bunny",
		                              "Battleroid",
		                              "Nova Grappler",
		                              1,
		                              5000,
		                              "NovaGrappler123",
		                              CardIdentifier.BEAST_DEITY__RESCUE_BUNNY
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Combined Monster, Bugleed",
		                              "Alien",
		                              "Dimension Police",
		                              1,
		                              8000,
		                              "DimensionPolice070",
		                              CardIdentifier.COMBINED_MONSTER__BUGLEED
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Electric Monster, Whipple",
		                              "Alien",
		                              "Dimension Police",
		                              1,
		                              8000,
		                              "DimensionPolice071",
		                              CardIdentifier.ELECTRIC_MONSTER__WHIPPLE
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Analytic Monster, Gigabolt",
		                              "Alien",
		                              "Dimension Police",
		                              1,
		                              7000,
		                              "DimensionPolice072",
		                              CardIdentifier.ANALYTIC_MONSTER__GIGABOLT
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Beam Monster, Raydram",
		                              "Alien",
		                              "Dimension Police",
		                              1,
		                              6000,
		                              "DimensionPolice073",
		                              CardIdentifier.BEAM_MONSTER__RAYDRAM
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Hypnosis Monster, Necrory",
		                              "Alien",
		                              "Dimension Police",
		                              1,
		                              4000,
		                              "DimensionPolice074",
		                              CardIdentifier.HYPNOSIS_MONSTER__NECRORY
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.CRITICAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Demonic Eye Monster, Gorgon",
		                              "Alien",
		                              "Dimension Police",
		                              1,
		                              5000,
		                              "DimensionPolice075",
		                              CardIdentifier.DEMONIC_EYE_MONSTER__GORGON
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Supermassive Star, Lady Gunner",
		                              "Cyberoid",
		                              "Link Joker",
		                              1,
		                              10000,
		                              "LinkJoker045",
		                              CardIdentifier.SUPERMASSIVE_STAR__LADY_GUNNER
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Destruction Star-vader, Tungsten",
		                              "Cyberoid",
		                              "Link Joker",
		                              1,
		                              8000,
		                              "LinkJoker046",
		                              CardIdentifier.DESTRUCTION_STAR_VADER__TUNGSTEN
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Prison Gate Star-vader, Palladium",
		                              "Cyberoid",
		                              "Link Joker",
		                              1,
		                              7000,
		                              "LinkJoker047",
		                              CardIdentifier.PRISON_GATE_STAR_VADER__PALLADIUM
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Asteroid Belt, Lady Gunner",
		                              "Cyberoid",
		                              "Link Joker",
		                              1,
		                              6000,
		                              "LinkJoker048",
		                              CardIdentifier.ASTEROID_BELT__LADY_GUNNER
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Star-vader, Chaos Beat Dragon",
		                              "Cyber Dragon",
		                              "Link Joker",
		                              1,
		                              6000,
		                              "LinkJoker049",
		                              CardIdentifier.STAR_VADER__CHAOS_BEAT_DRAGON
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Black Ring Chain, Pleiades",
		                              "Cyber Fairy",
		                              "Link Joker",
		                              1,
		                              4000,
		                              "LinkJoker050",
		                              CardIdentifier.BLACK_RING_CHAIN__PLEIADES
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Corrosion Dragon, Corrupt Dragon",
		                              "Zombie",
		                              "Granblue",
		                              1,
		                              9000,
		                              "Granblue050",
		                              CardIdentifier.CORROSION_DRAGON__CORRUPT_DRAGON
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Peter the Ghostie",
		                              "Ghost",
		                              "Granblue",
		                              1,
		                              5000,
		                              "Granblue051",
		                              CardIdentifier.PETER_THE_GHOSTIE
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.DRAW,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Sorrowful Gunshot, Nightflare",
		                              "Vampire",
		                              "Granblue",
		                              1,
		                              5000,
		                              "Granblue052",
		                              CardIdentifier.SORROWFUL_GUNSHOT__NIGHTFLARE
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Discerning Eye, Sky Trooper",
		                              "Warbeast",
		                              "Aqua Force",
		                              1,
		                              10000,
		                              "AquaForce076",
		                              CardIdentifier.DISCERNING_EYE__SKY_TROOPER
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Marine General of Raging Current, Melthos",
		                              "Aquaroid",
		                              "Aqua Force",
		                              1,
		                              10000,
		                              "AquaForce077",
		                              CardIdentifier.MARINE_GENERAL_OF_RAGING_CURRENT__MELTHOS
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Battle Siren, Callista",
		                              "Mermaid",
		                              "Aqua Force",
		                              1,
		                              9000,
		                              "AquaForce078",
		                              CardIdentifier.BATTLE_SIREN__CALLISTA
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Abyssal Sniper",
		                              "Aquaroid",
		                              "Aqua Force",
		                              1,
		                              8000,
		                              "AquaForce079",
		                              CardIdentifier.ABYSSAL_SNIPER
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Deuteriumgun Dragon",
		                              "Dragonman",
		                              "Aqua Force",
		                              1,
		                              8000,
		                              "AquaForce080",
		                              CardIdentifier.DEUTERIUMGUN_DRAGON
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Ocean Current Rescuing Turtle Soldier",
		                              "High Beast",
		                              "Aqua Force",
		                              1,
		                              7000,
		                              "AquaForce081",
		                              CardIdentifier.OCEAN_CURRENT_RESCUING_TURTLE_SOLDIER
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Shallows Sweeper",
		                              "Aquaroid",
		                              "Aqua Force",
		                              1,
		                              7000,
		                              "AquaForce082",
		                              CardIdentifier.SHALLOWS_SWEEPER
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Heavy Rush Dragon",
		                              "Dragonman",
		                              "Aqua Force",
		                              1,
		                              6000,
		                              "AquaForce083",
		                              CardIdentifier.HEAVY_RUSH_DRAGON
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Patrol Swimming Seal Soldier",
		                              "High Beast",
		                              "Aqua Force",
		                              1,
		                              6000,
		                              "AquaForce084",
		                              CardIdentifier.PATROL_SWIMMING_SEAL_SOLDIER
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Apprentice Gunner, Solon",
		                              "Aquaroid",
		                              "Aqua Force",
		                              1,
		                              4000,
		                              "AquaForce085",
		                              CardIdentifier.APPRENTICE_GUNNER__SOLON
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.DRAW,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Battle Siren, Marika",
		                              "Mermaid",
		                              "Aqua Force",
		                              1,
		                              4000,
		                              "AquaForce086",
		                              CardIdentifier.BATTLE_SIREN__MARIKA
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Cosmic Cheetah",
		                              "High Beast",
		                              "Great Nature",
		                              1,
		                              8000,
		                              "GreatNature063",
		                              CardIdentifier.COSMIC_CHEETAH
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Whistle Hyena",
		                              "High Beast",
		                              "Great Nature",
		                              1,
		                              8000,
		                              "GreatNature064",
		                              CardIdentifier.WHISTLE_HYENA
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Telescope Rabbit",
		                              "High Beast",
		                              "Great Nature",
		                              1,
		                              5000,
		                              "GreatNature065",
		                              CardIdentifier.TELESCOPE_RABBIT
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.CRITICAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Holder Hedgehog",
		                              "High Beast",
		                              "Great Nature",
		                              1,
		                              5000,
		                              "GreatNature066",
		                              CardIdentifier.HOLDER_HEDGEHOG
		                              ));

		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Shura Stealth Dragon, Kujikiricongo",
		                              "Abyss Dragon",
		                              "Nubatama",
		                              1,
		                              11000,
		                              "Nubatama005",
		                              CardIdentifier.SHURA_STEALTH_DRAGON__KUJIKIRICONGO
		                              ));

		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Shura Stealth Dragon, Kabukicongo",
		                              "Abyss Dragon",
		                              "Nubatama",
		                              1,
		                              11000,
		                              "Nubatama006",
		                              CardIdentifier.SHURA_STEALTH_DRAGON__KABUKICONGO
		                              ));

		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              0,
		                              "Stealth Beast, Mijingakure",
		                              "Warbeast",
		                              "Nubatama",
		                              1,
		                              6000,
		                              "Nubatama007",
		                              CardIdentifier.STEALTH_BEAST_MIJINGAKURE
		                              ));

		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Stealth Fiend, Daidarahoushi",
		                              "Demon",
		                              "Nubatama",
		                              1,
		                              10000,
		                              "Nubatama008",
		                              CardIdentifier.STEALTH_FIEND_DAIDARAHOUSHI
		                              ));

		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Stealth Beast, Tamahagane",
		                              "Warbeast",
		                              "Nubatama",
		                              1,
		                              9000,
		                              "Nubatama009",
		                              CardIdentifier.STEALTH_BEAST_TAMAHAGANE
		                              ));

		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Stealth Beast, Kuroko",
		                              "Warbeast",
		                              "Nubatama",
		                              1,
		                              5000,
		                              "Nubatama010",
		                              CardIdentifier.STEALTH_BEAST_KUROKO
		                              ));

		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Stealth Rogue of a Thousand Knives, Oborozakura",
		                              "Demon",
		                              "Nubatama",
		                              1,
		                              10000,
		                              "Nubatama011",
		                              CardIdentifier.STEALTH_ROGUE_OF_A_THOUSAND_KNIVES_OBOROZAKURA
		                              ));

		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Stealth Dragon, Kokujou",
		                              "Abyss Dragon",
		                              "Nubatama",
		                              1,
		                              9000,
		                              "Nubatama012",
		                              CardIdentifier.STEALTH_DRAGON_KOKUJOU
		                              ));

		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Stealth Fiend, Gozuou",
		                              "Warbeast",
		                              "Nubatama",
		                              1,
		                              8000,
		                              "Nubatama013",
		                              CardIdentifier.STEALTH_FIEND_GOZUOU
		                              ));

		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Stealth Rogue of the Night, Sakurafubuki",
		                              "Demon",
		                              "Nubatama",
		                              1,
		                              8000,
		                              "Nubatama014",
		                              CardIdentifier.STEALTH_ROGUE_OF_THE_NIGHT_SAKURAFUBUKI
		                              ));

		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Tempest Stealth Rogue, Fuuki",
		                              "Demon",
		                              "Nubatama",
		                              1,
		                              7000,
		                              "Nubatama015",
		                              CardIdentifier.TEMPEST_STEALTH_ROGUE_FUUKI
		                              ));

		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Stealth Dragon, Kodachifubuki",
		                              "Abyss Dragon",
		                              "Nubatama",
		                              1,
		                              7000,
		                              "Nubatama016",
		                              CardIdentifier.STEALTH_DRAGON_KODACHI_FUBUKI
		                              ));

		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Stealth Fiend, Mezuou",
		                              "Warbeast",
		                              "Nubatama",
		                              1,
		                              6000,
		                              "Nubatama017",
		                              CardIdentifier.STEALTH_FIEND_MEZUOU
		                              ));

		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Festive Stealth Rogue, Shutenmaru",
		                              "Demon",
		                              "Nubatama",
		                              1,
		                              4000,
		                              "Nubatama018",
		                              CardIdentifier.FESTIVE_STEALTH_ROGUE_SHUTENMARU
		                              ));

		Card.Add (new CardInformation(0,
		                              TriggerIcon.CRITICAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Stealth Dragon, Kurogane",
		                              "Abbys Dragon",
		                              "Nubatama",
		                              1,
		                              5000,
		                              "Nubatama019",
		                              CardIdentifier.STEALTH_DRAGON_KUROGANE
		                              ));

		Card.Add (new CardInformation(0,
		                              TriggerIcon.DRAW,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Stealth Fiend, Otsuzura",
		                              "Warbeast",
		                              "Nubatama",
		                              1,
		                              5000,
		                              "Nubatama020",
		                              CardIdentifier.STEALTH_FIEND_OTSUZURA
		                              ));

		Card.Add (new CardInformation(0,
		                              TriggerIcon.HEAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Stealth Fiend, Zashikihime",
		                              "Ghost",
		                              "Nubatama",
		                              1,
		                              5000,
		                              "Nubatama021",
		                              CardIdentifier.STEALTH_FIEND_ZASHIKIHIME
		                              ));

		Card.Add (new CardInformation(0,
		                              TriggerIcon.STAND,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Stealth Fiend, Mashiromomen",
		                              "Demon",
		                              "Nubatama",
		                              1,
		                              5000,
		                              "Nubatama022",
		                              CardIdentifier.STEALTH_FIEND_MASHIROMOMEN
		                              ));

		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Broken Heart Jewel Knight, Ashlei \"Reverse\"",
		                              "Elf",
		                              "Royal Paladin",
		                              1,
		                              11000,
		                              "RoyalPaladin075",
		                              CardIdentifier.BROKEN_HEART_JEWEL_KNIGHT__ASHLEI________EVERSE_____
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Liberator of Bonds, Gancelot Zenith",
		                              "Elf",
		                              "Gold Paladin",
		                              1,
		                              11000,
		                              "GoldPaladin109",
		                              CardIdentifier.LIBERATOR_OF_BONDS__GANCELOT_ZENITH
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Salvation Lion, Grand Ezel Scissors",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              11000,
		                              "GoldPaladin110",
		                              CardIdentifier.SALVATION_LION__GRAND_EZEL_SCISSORS
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Sunlight Goddess, Yatagarasu",
		                              "Noble",
		                              "Genesis",
		                              1,
		                              11000,
		                              "Genesis049",
		                              CardIdentifier.SUNLIGHT_GODDESS__YATAGARASU
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Omniscience Regalia, Minerva",
		                              "Noble",
		                              "Genesis",
		                              1,
		                              11000,
		                              "Genesis050",
		                              CardIdentifier.OMNISCIENCE_REGALIA__MINERVA
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Dauntless Dominate Dragon \"Reverse\"",
		                              "Flame Dragon",
		                              "Kagero",
		                              1,
		                              11000,
		                              "Kagero098",
		                              CardIdentifier.DAUNTLESS_DOMINATE_DRAGON______REVERSE_____
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Eradicator, Ignition Dragon",
		                              "Thunder Dragon",
		                              "Narukami",
		                              1,
		                              11000,
		                              "Narukami114",
		                              CardIdentifier.ERADICATOR__IGNITION_DRAGON
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Eradicator, Tempest Bolt Dragon",
		                              "Thunder Dragon",
		                              "Narukami",
		                              1,
		                              11000,
		                              "Narukami115",
		                              CardIdentifier.ERADICATOR__TEMPEST_BOLT_DRAGON
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Sanctuary of Light, Planetal Dragon",
		                              "Cosmo Dragon",
		                              "Royal Paladin",
		                              1,
		                              10000,
		                              "RoyalPaladin076",
		                              CardIdentifier.SANCTUARY_OF_LIGHT__PLANETAL_DRAGON
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Banding Jewel Knight, Miranda",
		                              "Elf",
		                              "Royal Paladin",
		                              1,
		                              9000,
		                              "RoyalPaladin077",
		                              CardIdentifier.BANDING_JEWEL_KNIGHT__MIRANDA
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              0,
		                              "Summoning Jewel Knight, Gloria",
		                              "Giant",
		                              "Royal Paladin",
		                              1,
		                              6000,
		                              "RoyalPaladin078",
		                              CardIdentifier.SUMMONING_JEWEL_KNIGHT__GLORIA
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              0,
		                              "Sword Formation Liberator, Igraine",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              6000,
		                              "GoldPaladin111",
		                              CardIdentifier.SWORD_FORMATION_LIBERATOR__IGRAINE
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              0,
		                              "Goddess of the Shield, Aegis",
		                              "Noble",
		                              "Genesis",
		                              1,
		                              6000,
		                              "Genesis051",
		                              CardIdentifier.GODDESS_OF_THE_SHIELD__AEGIS
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Covert Demonic Dragon, Kagurabloom",
		                              "Abyss Dragon",
		                              "Murakumo",
		                              1,
		                              11000,
		                              "Murakumo045",
		                              CardIdentifier.COVERT_DEMONIC_DRAGON__KAGURABLOOM
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Covert Demonic Dragon, Hyakki Vogue \"Reverse\"",
		                              "Abyss Dragon",
		                              "Murakumo",
		                              1,
		                              11000,
		                              "Murakumo046",
		                              CardIdentifier.COVERT_DEMONIC_DRAGON__HYAKKI_VOGUE______REVERSE_____
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              0,
		                              "Silver Collar Snowstorm, Sasame",
		                              "Ghost",
		                              "Murakumo",
		                              1,
		                              6000,
		                              "Murakumo047",
		                              CardIdentifier.SILVER_COLLAR_SNOWSTORM__SASAME
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Eradicator, Lorentz Force Dragon",
		                              "Thunder Dragon",
		                              "Narukami",
		                              1,
		                              9000,
		                              "Narukami116",
		                              CardIdentifier.ERADICATOR__LORENTZ_FORCE_DRAGON
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Maiden of Venus Trap \"Reverse\"",
		                              "Bioroid",
		                              "Neo Nectar",
		                              1,
		                              11000,
		                              "NeoNectar048",
		                              CardIdentifier.MAIDEN_OF_VENUS_TRAP______REVERSE_____
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Lord of the Deep Forests, Master Wisteria",
		                              "Bioroid",
		                              "Neo Nectar",
		                              1,
		                              11000,
		                              "NeoNectar049",
		                              CardIdentifier.LORD_OF_THE_DEEP_FORESTS__MASTER_WISTERIA
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              0,
		                              "Red Rose Musketeer, Antonio",
		                              "Bioroid",
		                              "Neo Nectar",
		                              1,
		                              6000,
		                              "NeoNectar050",
		                              CardIdentifier.RED_ROSE_MUSKETEER__ANTONIO
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Sanctuary of Light, Determinator",
		                              "Human",
		                              "Royal Paladin",
		                              1,
		                              9000,
		                              "RoyalPaladin079",
		                              CardIdentifier.SANCTUARY_OF_LIGHT__DETERMINATOR
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Linking Jewel Knight, Tilda",
		                              "Elf",
		                              "Royal Paladin",
		                              1,
		                              9000,
		                              "RoyalPaladin080",
		                              CardIdentifier.LINKING_JEWEL_KNIGHT__TILDA
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Sanctuary of Light, Planet Lancer",
		                              "Human",
		                              "Royal Paladin",
		                              1,
		                              4000,
		                              "RoyalPaladin081",
		                              CardIdentifier.SANCTUARY_OF_LIGHT__PLANET_LANCER
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Treasure Liberator, Calogrenant",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              10000,
		                              "GoldPaladin112",
		                              CardIdentifier.TREASURE_LIBERATOR__CALOGRENANT
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Blue Sky Liberator, Hengist",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              9000,
		                              "GoldPaladin113",
		                              CardIdentifier.BLUE_SKY_LIBERATOR__HENGIST
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Knight of Scorching Scales, Eliwood",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              9000,
		                              "GoldPaladin114",
		                              CardIdentifier.KNIGHT_OF_SCORCHING_SCALES__ELIWOOD
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Battle Maiden, Amenohoakari",
		                              "Noble",
		                              "Genesis",
		                              1,
		                              5000,
		                              "Genesis054",
		                              CardIdentifier.BATTLE_MAIDEN__AMENOHOAKARI
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Vorpal Cannon Dragon",
		                              "Flame Dragon",
		                              "Kagero",
		                              1,
		                              10000,
		                              "Kagero099",
		                              CardIdentifier.VORPAL_CANNON_DRAGON
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Fire God, Agni",
		                              "Noble",
		                              "Kagero",
		                              1,
		                              10000,
		                              "Kagero100",
		                              CardIdentifier.FIRE_GOD__AGNI
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Dominate Drive Dragon",
		                              "Flame Dragon",
		                              "Kagero",
		                              1,
		                              9000,
		                              "Kagero101",
		                              CardIdentifier.DOMINATE_DRIVE_DRAGON
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Dragon Knight, Akram",
		                              "Human",
		                              "Kagero",
		                              1,
		                              4000,
		                              "Kagero102",
		                              CardIdentifier.DRAGON_KNIGHT__AKRAM
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Dragon Knight, Sadig",
		                              "Human",
		                              "Kagero",
		                              1,
		                              5000,
		                              "Kagero103",
		                              CardIdentifier.DRAGON_KNIGHT__SADIG
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Investigating Stealth Rogue, Amakusa",
		                              "Demon",
		                              "Murakumo",
		                              1,
		                              10000,
		                              "Murakumo048",
		                              CardIdentifier.INVESTIGATING_STEALTH_ROGUE__AMAKUSA
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Stealth Rogue of Demonic Hair, Gurenjishi",
		                              "Demon",
		                              "Murakumo",
		                              1,
		                              9000,
		                              "Murakumo049",
		                              CardIdentifier.STEALTH_ROGUE_OF_DEMONIC_HAIR__GURENJISHI
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Stealth Rogue of Umbrella, Sukerokku",
		                              "Demon",
		                              "Murakumo",
		                              1,
		                              7000,
		                              "Murakumo050",
		                              CardIdentifier.STEALTH_ROGUE_OF_UMBRELLA__SUKEROKKU
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Certain Kill Eradicator, Ouei",
		                              "Human",
		                              "Narukami",
		                              1,
		                              7000,
		                              "Narukami117",
		                              CardIdentifier.CERTAIN_KILL_ERADICATOR__OUEI
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Spiritual Sphere Eradicator, Nata",
		                              "Demon",
		                              "Narukami",
		                              1,
		                              5000,
		                              "Narukami118",
		                              CardIdentifier.SPIRITUAL_SPHERE_ERADICATOR__NATA
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "White Rose Musketeer, Alberto",
		                              "Bioroid",
		                              "Neo Nectar",
		                              1,
		                              9000,
		                              "NeoNectar051",
		                              CardIdentifier.WHITE_ROSE_MUSKETEER__ALBERTO
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Maiden of Cherry Bloom",
		                              "Bioroid",
		                              "Neo Nectar",
		                              1,
		                              9000,
		                              "NeoNectar052",
		                              CardIdentifier.MAIDEN_OF_CHERRY_BLOOM
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Maiden of Cherry Stone",
		                              "Bioroid",
		                              "Neo Nectar",
		                              1,
		                              7000,
		                              "NeoNectar053",
		                              CardIdentifier.MAIDEN_OF_CHERRY_STONE
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Knight of Courage, Ector",
		                              "Human",
		                              "Royal Paladin",
		                              1,
		                              10000,
		                              "RoyalPaladin082",
		                              CardIdentifier.KNIGHT_OF_COURAGE__ECTOR
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Mystical Hermit",
		                              "Human",
		                              "Royal Paladin",
		                              1,
		                              10000,
		                              "RoyalPaladin083",
		                              CardIdentifier.MYSTICAL_HERMIT
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Jewel Knight, Treanme",
		                              "High Beast",
		                              "Royal Paladin",
		                              1,
		                              8000,
		                              "RoyalPaladin084",
		                              CardIdentifier.JEWEL_KNIGHT__TREANME
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Sanctuary of Light, Little Storm",
		                              "Human",
		                              "Royal Paladin",
		                              1,
		                              7000,
		                              "RoyalPaladin085",
		                              CardIdentifier.SANCTUARY_OF_LIGHT__LITTLE_STORM
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Jewel Knight, Melme",
		                              "High Beast",
		                              "Royal Paladin",
		                              1,
		                              6000,
		                              "RoyalPaladin086",
		                              CardIdentifier.JEWEL_KNIGHT__MELME
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Security Jewel Knight, Arwen",
		                              "Elf",
		                              "Royal Paladin",
		                              1,
		                              6000,
		                              "RoyalPaladin087",
		                              CardIdentifier.SECURITY_JEWEL_KNIGHT__ARWEN
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Desire Jewel Knight, Heloise",
		                              "Human",
		                              "Royal Paladin",
		                              1,
		                              5000,
		                              "RoyalPaladin088",
		                              CardIdentifier.DESIRE_JEWEL_KNIGHT__HELOISE
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.CRITICAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Jewel Knight, Noble Stinger",
		                              "Sylph",
		                              "Royal Paladin",
		                              1,
		                              5000,
		                              "RoyalPaladin089",
		                              CardIdentifier.JEWEL_KNIGHT__NOBLE_STINGER
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.DRAW,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Jewel Knight, Sacred Unicorn",
		                              "High Beast",
		                              "Royal Paladin",
		                              1,
		                              5000,
		                              "RoyalPaladin090",
		                              CardIdentifier.JEWEL_KNIGHT__SACRED_UNICORN
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.STAND,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Jewel Knight, Opt Harpist",
		                              "Elf",
		                              "Royal Paladin",
		                              1,
		                              5000,
		                              "RoyalPaladin091",
		                              CardIdentifier.JEWEL_KNIGHT__OPT_HARPIST
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.HEAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Jewel Knight, Hirumi",
		                              "High Beast",
		                              "Royal Paladin",
		                              1,
		                              5000,
		                              "RoyalPaladin092",
		                              CardIdentifier.JEWEL_KNIGHT__HIRUMI
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Sacred Guardian Beast, Ceryneian",
		                              "High Beast",
		                              "Gold Paladin",
		                              1,
		                              10000,
		                              "GoldPaladin115",
		                              CardIdentifier.SACRED_GUARDIAN_BEAST__CERYNEIAN
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Liberator, Burning Blow",
		                              "Salamander",
		                              "Gold Paladin",
		                              1,
		                              10000,
		                              "GoldPaladin116",
		                              CardIdentifier.LIBERATOR__BURNING_BLOW
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Dorgal Liberator",
		                              "High Beast",
		                              "Gold Paladin",
		                              1,
		                              9000,
		                              "GoldPaladin117",
		                              CardIdentifier.DORGAL_LIBERATOR
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Twin Holy Beast, Black Lion",
		                              "High Beast",
		                              "Gold Paladin",
		                              1,
		                              8000,
		                              "GoldPaladin118",
		                              CardIdentifier.TWIN_HOLY_BEAST__BLACK_LION
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Green Axe Knight, Taliesyn",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              8000,
		                              "GoldPaladin119",
		                              CardIdentifier.GREEN_AXE_KNIGHT__TALIESYN
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Knight of Passion, Tor",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              7000,
		                              "GoldPaladin120",
		                              CardIdentifier.KNIGHT_OF_PASSION__TOR
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Twin Holy Beast, White Lion",
		                              "High Beast",
		                              "Gold Paladin",
		                              1,
		                              7000,
		                              "GoldPaladin121",
		                              CardIdentifier.TWIN_HOLY_BEAST__WHITE_LION
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Flying Sword Liberator, Gorlois",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              6000,
		                              "GoldPaladin122",
		                              CardIdentifier.FLYING_SWORD_LIBERATOR__GORLOIS
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Throw Blade Knight, Maleagant",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              5000,
		                              "GoldPaladin123",
		                              CardIdentifier.THROW_BLADE_KNIGHT__MALEAGANT
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Scarlet Lion Cub, Caria",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              5000,
		                              "GoldPaladin124",
		                              CardIdentifier.SCARLET_LION_CUB__CARIA
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.STAND,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Liberator, Ground Crack",
		                              "Giant",
		                              "Gold Paladin",
		                              1,
		                              5000,
		                              "GoldPaladin125",
		                              CardIdentifier.LIBERATOR__GROUND_CRACK
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.HEAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Nappgal Liberator",
		                              "High Beast",
		                              "Gold Paladin",
		                              1,
		                              5000,
		                              "GoldPaladin126",
		                              CardIdentifier.NAPPGAL_LIBERATOR
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Angelic Wiseman",
		                              "Angel",
		                              "Genesis",
		                              1,
		                              10000,
		                              "Genesis055",
		                              CardIdentifier.ANGELIC_WISEMAN
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Myth Guard, Fomalhaut",
		                              "Battleroid",
		                              "Genesis",
		                              1,
		                              10000,
		                              "Genesis056",
		                              CardIdentifier.MYTH_GUARD__FOMALHAUT
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Grape Witch, Grappa",
		                              "Human",
		                              "Genesis",
		                              1,
		                              9000,
		                              "Genesis057",
		                              CardIdentifier.GRAPE_WITCH__GRAPPA
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Myth Guard, Denebola",
		                              "Battleroid",
		                              "Genesis",
		                              1,
		                              9000,
		                              "Genesis058",
		                              CardIdentifier.MYTH_GUARD__DENEBOLA
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Battle Maiden, Kayanarumi",
		                              "Noble",
		                              "Genesis",
		                              1,
		                              8000,
		                              "Genesis059",
		                              CardIdentifier.BATTLE_MAIDEN__KAYANARUMI
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Orange Witch, Valencia",
		                              "Human",
		                              "Genesis",
		                              1,
		                              7000,
		                              "Genesis060",
		                              CardIdentifier.ORANGE_WITCH__VALENCIA
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Myth Guard, Achernar",
		                              "Battleroid",
		                              "Genesis",
		                              1,
		                              7000,
		                              "Genesis061",
		                              CardIdentifier.MYTH_GUARD__ACHERNAR
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Goddess of Union, Juno",
		                              "Noble",
		                              "Genesis",
		                              1,
		                              7000,
		                              "Genesis062",
		                              CardIdentifier.GODDESS_OF_UNION__JUNO
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Ordain Owl",
		                              "High Beast",
		                              "Genesis",
		                              1,
		                              6000,
		                              "Genesis063",
		                              CardIdentifier.ORDAIN_OWL
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Spectral Sheep",
		                              "High Beast",
		                              "Genesis",
		                              1,
		                              4000,
		                              "Genesis064",
		                              CardIdentifier.SPECTRAL_SHEEP
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Dragon Knight, Jalal",
		                              "Human",
		                              "Kagero",
		                              1,
		                              10000,
		                              "Kagero104",
		                              CardIdentifier.DRAGON_KNIGHT__JALAL
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Flame Star Seal Dragon Knight",
		                              "Flame Dragon",
		                              "Kagero",
		                              1,
		                              9000,
		                              "Kagero105",
		                              CardIdentifier.FLAME_STAR_SEAL_DRAGON_KNIGHT
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Dragon Knight, Lezar",
		                              "Human",
		                              "Kagero",
		                              1,
		                              8000,
		                              "Kagero106",
		                              CardIdentifier.DRAGON_KNIGHT__LEZAR
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Demonic Dragon Mage, Taksaka",
		                              "Dragonman",
		                              "Kagero",
		                              1,
		                              8000,
		                              "Kagero107",
		                              CardIdentifier.DEMONIC_DRAGON_MAGE__TAKSAKA
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Diable Drive Dragon",
		                              "Flame Dragon",
		                              "Kagero",
		                              1,
		                              7000,
		                              "Kagero108",
		                              CardIdentifier.DIABLE_DRIVE_DRAGON
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Explosive Claw Seal Dragon Knight",
		                              "Flame Dragon",
		                              "Kagero",
		                              1,
		                              6000,
		                              "Kagero109",
		                              CardIdentifier.EXPLOSIVE_CLAW_SEAL_DRAGON_KNIGHT
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Calamity Tower Wyvern",
		                              "Winged Dragon",
		                              "Kagero",
		                              1,
		                              5000,
		                              "Kagero110",
		                              CardIdentifier.CALAMITY_TOWER_WYVERN
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Prison Egg Seal Dragon Knight",
		                              "Flame Dragon",
		                              "Kagero",
		                              1,
		                              4000,
		                              "Kagero111",
		                              CardIdentifier.PRISON_EGG_SEAL_DRAGON_KNIGHT
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.CRITICAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Lizard Soldier, Goraha",
		                              "Dragonman",
		                              "Kagero",
		                              1,
		                              5000,
		                              "Kagero112",
		                              CardIdentifier.LIZARD_SOLDIER__GORAHA
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.DRAW,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Fire of Repose, Gira",
		                              "Salamander",
		                              "Kagero",
		                              1,
		                              5000,
		                              "Kagero113",
		                              CardIdentifier.FIRE_OF_REPOSE__GIRA
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.STAND,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Wyvern Strike, Free",
		                              "Winged Dragon",
		                              "Kagero",
		                              1,
		                              5000,
		                              "Kagero114",
		                              CardIdentifier.WYVERN_STRIKE__FREE
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.HEAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Dragon Dancer, Barbara",
		                              "Human",
		                              "Kagero",
		                              1,
		                              5000,
		                              "Kagero115",
		                              CardIdentifier.DRAGON_DANCER__BARBARA
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Stealth Beast, Chain Geek",
		                              "Warbeast",
		                              "Murakumo",
		                              1,
		                              8000,
		                              "Murakumo051",
		                              CardIdentifier.STEALTH_BEAST__CHAIN_GEEK
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Stealth Beast, Deathly Dagger",
		                              "Warbeast",
		                              "Murakumo",
		                              1,
		                              6000,
		                              "Murakumo052",
		                              CardIdentifier.STEALTH_BEAST__DEATHLY_DAGGER
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Stealth Rogue of Kite, Goemon",
		                              "Demon",
		                              "Murakumo",
		                              1,
		                              5000,
		                              "Murakumo053",
		                              CardIdentifier.STEALTH_ROGUE_OF_KITE__GOEMON
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.CRITICAL,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Stealth Rogue of Dagger, Yaiba",
		                              "Demon",
		                              "Murakumo",
		                              1,
		                              5000,
		                              "Murakumo054",
		                              CardIdentifier.STEALTH_ROGUE_OF_DAGGER__YAIBA
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.STAND,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Stealth Rogue of Dark Night, Krog",
		                              "Demon",
		                              "Murakumo",
		                              1,
		                              5000,
		                              "Murakumo055",
		                              CardIdentifier.STEALTH_ROGUE_OF_DARK_NIGHT__KROG
		                              ));
		
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Roaring Thunder Bow, Zafura",
		                              "Human",
		                              "Narukami",
		                              1,
		                              10000,
		                              "Narukami119",
		                              CardIdentifier.ROARING_THUNDER_BOW__ZAFURA
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Plasma Scimitar Dragoon",
		                              "Human",
		                              "Narukami",
		                              1,
		                              8000,
		                              "Narukami120",
		                              CardIdentifier.PLASMA_SCIMITAR_DRAGOON
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Dragon Dancer, Agatha",
		                              "Human",
		                              "Narukami",
		                              1,
		                              7000,
		                              "Narukami121",
		                              CardIdentifier.DRAGON_DANCER__AGATHA
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Wyvern Strike, Zaroos",
		                              "Winged Dragon",
		                              "Narukami",
		                              1,
		                              6000,
		                              "Narukami122",
		                              CardIdentifier.WYVERN_STRIKE__ZAROOS
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Wishing Djinn",
		                              "Demon",
		                              "Narukami",
		                              1,
		                              4000,
		                              "Narukami123",
		                              CardIdentifier.WISHING_DJINN
		                              ));
		
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Jackin' Pumpkin",
		                              "Dryad",
		                              "Neo Nectar",
		                              1,
		                              8000,
		                              "NeoNectar054",
		                              CardIdentifier.JACKIN______PUMPKIN
		                              ));
		
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Lotus Druid",
		                              "Bioroid",
		                              "Neo Nectar",
		                              1,
		                              6000,
		                              "NeoNectar055",
		                              CardIdentifier.LOTUS_DRUID
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Maiden of Physalis",
		                              "Bioroid",
		                              "Neo Nectar",
		                              1,
		                              5000,
		                              "NeoNectar056",
		                              CardIdentifier.MAIDEN_OF_PHYSALIS
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.DRAW,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Maiden of Egg Plant",
		                              "Bioroid",
		                              "Neo Nectar",
		                              1,
		                              5000,
		                              "NeoNectar057",
		                              CardIdentifier.MAIDEN_OF_EGG_PLANT
		                              ));
		
		Card.Add (new CardInformation(0,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              10000,
		                              "Blue Rose Musketeer, Ernest",
		                              "Bioroid",
		                              "Neo Nectar",
		                              1,
		                              4000,
		                              "NeoNectar058",
		                              CardIdentifier.BLUE_ROSE_MUSKETEER__ERNEST
		                              ));
									  
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Star-vader, \"Omega\" Glendios",
		                              "Cyber Golem",
		                              "Link Joker",
		                              1,
		                              11000,
		                              "LinkJoker051",
		                              CardIdentifier.STAR_VADER_OMEGA_GLENDIOS
		                              ));

		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Revenger, Desperate Dragon",
		                              "Abyss Dragon",
		                              "Shadow Paladin",
		                              1,
		                              11000,
		                              "ShadowPaladin091",
		                              CardIdentifier.REVENGER_DESPERATE_DRAGON
		                              ));
									  
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Revenger, Dragruler Phantom",
		                              "Abyss Dragon",
		                              "Shadow Paladin",
		                              1,
		                              11000,
		                              "ShadowPaladin092",
		                              CardIdentifier.REVENGER_DRAGRULER_PHANTOM
		                              ));
									  
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Liberator, Monarch Sanctuary Alfred",
		                              "Human",
		                              "Gold Paladin",
		                              1,
		                              11000,
		                              "GoldPaladin127",
		                              CardIdentifier.LIBERATOR_MONARCH_SANCTUARY_ALFRED
		                              ));
									  
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Dragonic Overlord",
		                              "Flame Dragon",
		                              "Kagero",
		                              1,
		                              11000,
		                              "Kagero116",
		                              CardIdentifier.DRAGONIC_OVERLORD_BREAK_RIDE
		                              ));
									  
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Dragonic Overlord \"The Re-birth\" Reverse",
		                              "Flame Dragon",
		                              "Kagero",
		                              1,
		                              11000,
		                              "Kagero117",
		                              CardIdentifier.DRAGONIC_OVERLORD_THE_REBIRTH
		                              ));
									  
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Star-vader, \"Reverse\" Cradle",
		                              "Cyber Golem",
		                              "Link Joker",
		                              1,
		                              11000,
		                              "LinkJoker052",
		                              CardIdentifier.STARVADER_REVERSE_CRADLE
		                              ));
	
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Silver Thorn Dragon Empress, Venus Luquier",
		                              "Elf",
		                              "Pale Moon",
		                              1,
		                              11000,
		                              "PaleMoon080",
		                              CardIdentifier.SILVER_THORN_DRAGON_EMPRESS_VENUS_LUQUIER
		                              ));	
									  
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Blue Storm Karma Dragon, Maelstrom Reverse",
		                              "Tear Dragon",
		                              "Aqua Force",
		                              1,
		                              11000,
		                              "AquaForce087",
		                              CardIdentifier.BLUE_STORM_KARMA_DRAGON_MAELSTROM_REVERSE
		                              ));	
									  
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Revenger, Bloodmaster",
		                              "Demon",
		                              "Shadow Paladin",
		                              1,
		                              5000,
		                              "ShadowPaladin093",
		                              CardIdentifier.REVENGER_BLOODMASTER
		                              ));
									  
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              0,
		                              "Hatred Prison Revenger, Kuesaru",
		                              "Elf",
		                              "Shadow Paladin",
		                              1,
		                              6000,
		                              "ShadowPaladin094",
		                              CardIdentifier.HATRED_PRISON_REVENGER_KUESARU
		                              ));
									  
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              5000,
		                              "Black-winged Swordbreaker",
		                              "Angel",
		                              "Shadow Paladin",
		                              1,
		                              6000,
		                              "ShadowPaladin095",
		                              CardIdentifier.BLACKWINGED_SWORDBREAKER
		                              ));
									  
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Liberator, Holy Shine Dragon",
		                              "Cosmo Dragon",
		                              "Gold Paladin",
		                              1,
		                              11000,
		                              "GoldPaladin128",
		                              CardIdentifier.LIBERATOR_HOLY_SHINE_DRAGON
		                              ));
									  
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Liberator, Star Rain Trumpeter",
		                              "Angel",
		                              "Gold Paladin",
		                              1,
		                              9000,
		                              "GoldPaladin129",
		                              CardIdentifier.LIBERATOR_STAR_RAIN_TRUMPETER
		                              ));
									  
		Card.Add (new CardInformation(2,
		                              TriggerIcon.NONE,
		                              SkillIcon.INTERCEPT,
		                              5000,
		                              "Dragonic Burnout",
		                              "Flame Dragon",
		                              "Kagero",
		                              1,
		                              9000,
		                              "Kagero118",
		                              CardIdentifier.DRAGONIC_BURNOUT
		                              ));
									  
		Card.Add (new CardInformation(1,
		                              TriggerIcon.NONE,
		                              SkillIcon.BOOST,
		                              0,
		                              "Dragon Knight, Gimel",
		                              "Human",
		                              "Kagero",
		                              1,
		                              6000,
		                              "Kagero119",
		                              CardIdentifier.DRAGON_KNIGHT_GIMEL
		                              ));
									  
		Card.Add (new CardInformation(3,
		                              TriggerIcon.NONE,
		                              SkillIcon.TWIN_DRIVE,
		                              0,
		                              "Star-vader, Freeze Ray Dragon",
		                              "Cyber Dragon",
		                              "Link Joker",
		                              1,
		                              10000,
		                              "LinkJoker053",
		                              CardIdentifier.STARVADER_FREEZE_RAY_DRAGON
		                              ));
	}
	
	
private void AddSpecialConditions (Card _card, CardIdentifier id)
	{
		//Limit Break 4
		if(id == CardIdentifier.SHURA_STEALTH_DRAGON__KUJIKIRICONGO 
		   || id == CardIdentifier.STRONGEST_BEAST_DEITY__ETHICS_BUSTER_EXTREME 
		   || id == CardIdentifier.DEADLIEST_BEAST_DEITY__ETHICS_BUSTER______REVERSE_____ 
		   || id == CardIdentifier.DARK_DIMENSIONAL_ROBO_______REVERSE______DAIYUSHA 
		   || id == CardIdentifier.ORIGINAL_SAVER__ZERO
		   || id == CardIdentifier.STAR_VADER__CHAOS_BREAKER_DRAGON
		   || id == CardIdentifier.BLUE_WAVE_DRAGON__TETRA_DRIVE_DRAGON
		   || id == CardIdentifier.SHURA_STEALTH_DRAGON__KABUKICONGO
		   || id == CardIdentifier.LORD_OF_THE_SEVEN_SEAS__NIGHTMIST
		   || id == CardIdentifier.ICE_PRISON_HADES_EMPEROR__COCYTUS______REVERSE_____
		   || id == CardIdentifier.COBALT_WAVE_DRAGON
		   || id == CardIdentifier.SCHOOL_PUNISHER__LEO_PALD______REVERSE_____
		   || id == CardIdentifier.HONORARY_PROFESSOR__CHATNOIR
		   || id == CardIdentifier.STEALTH_FIEND_DAIDARAHOUSHI
		   || id == CardIdentifier.SPACE_DRAGON__DOGURUMADORA
		   || id == CardIdentifier.BROKEN_HEART_JEWEL_KNIGHT__ASHLEI________EVERSE_____
		   || id == CardIdentifier.LIBERATOR_OF_BONDS__GANCELOT_ZENITH
		   || id == CardIdentifier.SALVATION_LION__GRAND_EZEL_SCISSORS
		   || id == CardIdentifier.SUNLIGHT_GODDESS__YATAGARASU
		   || id == CardIdentifier.OMNISCIENCE_REGALIA__MINERVA
		   || id == CardIdentifier.DAUNTLESS_DOMINATE_DRAGON______REVERSE_____
		   || id == CardIdentifier.ERADICATOR__IGNITION_DRAGON
		   || id == CardIdentifier.ERADICATOR__TEMPEST_BOLT_DRAGON
		   || id == CardIdentifier.SANCTUARY_OF_LIGHT__PLANETAL_DRAGON
		   || id == CardIdentifier.COVERT_DEMONIC_DRAGON__KAGURABLOOM
		   || id == CardIdentifier.COVERT_DEMONIC_DRAGON__HYAKKI_VOGUE______REVERSE_____
		   || id == CardIdentifier.MAIDEN_OF_VENUS_TRAP______REVERSE_____
		   || id == CardIdentifier.LORD_OF_THE_DEEP_FORESTS__MASTER_WISTERIA
		   || id == CardIdentifier.STAR_VADER_OMEGA_GLENDIOS
		   || id == CardIdentifier.REVENGER_DESPERATE_DRAGON
		   || id == CardIdentifier.REVENGER_DRAGRULER_PHANTOM
		   || id == CardIdentifier.LIBERATOR_MONARCH_SANCTUARY_ALFRED
		   || id == CardIdentifier.DRAGONIC_OVERLORD_BREAK_RIDE
		   || id == CardIdentifier.DRAGONIC_OVERLORD_THE_REBIRTH
		   || id == CardIdentifier.STARVADER_REVERSE_CRADLE
		   || id == CardIdentifier.SILVER_THORN_DRAGON_EMPRESS_VENUS_LUQUIER
		   || id == CardIdentifier.BLUE_STORM_KARMA_DRAGON_MAELSTROM_REVERSE
		   || id == CardIdentifier.LIBERATOR_HOLY_SHINE_DRAGON)
		{
			_card.bHasLimitBreak4 = true;
		}

		//Lord
		if(id == CardIdentifier.SHURA_STEALTH_DRAGON__KUJIKIRICONGO 
		   || id == CardIdentifier.STRONGEST_BEAST_DEITY__ETHICS_BUSTER_EXTREME 
		   || id == CardIdentifier.DEADLIEST_BEAST_DEITY__ETHICS_BUSTER______REVERSE_____ 
		   || id == CardIdentifier.DARK_DIMENSIONAL_ROBO_______REVERSE______DAIYUSHA
		   || id == CardIdentifier.ORIGINAL_SAVER__ZERO
		   || id == CardIdentifier.STAR_VADER__CHAOS_BREAKER_DRAGON
		   || id == CardIdentifier.BLUE_WAVE_DRAGON__TETRA_DRIVE_DRAGON
		   || id == CardIdentifier.SHURA_STEALTH_DRAGON__KABUKICONGO
		   || id == CardIdentifier.LORD_OF_THE_SEVEN_SEAS__NIGHTMIST
		   || id == CardIdentifier.ICE_PRISON_HADES_EMPEROR__COCYTUS______REVERSE_____
		   || id == CardIdentifier.SCHOOL_PUNISHER__LEO_PALD______REVERSE_____
		   || id == CardIdentifier.HONORARY_PROFESSOR__CHATNOIR
		   || id == CardIdentifier.BROKEN_HEART_JEWEL_KNIGHT__ASHLEI________EVERSE_____
		   || id == CardIdentifier.LIBERATOR_OF_BONDS__GANCELOT_ZENITH
		   || id == CardIdentifier.SALVATION_LION__GRAND_EZEL_SCISSORS
		   || id == CardIdentifier.SUNLIGHT_GODDESS__YATAGARASU
		   || id == CardIdentifier.OMNISCIENCE_REGALIA__MINERVA
		   || id == CardIdentifier.DAUNTLESS_DOMINATE_DRAGON______REVERSE_____
		   || id == CardIdentifier.ERADICATOR__IGNITION_DRAGON
		   || id == CardIdentifier.ERADICATOR__TEMPEST_BOLT_DRAGON
		   || id == CardIdentifier.COVERT_DEMONIC_DRAGON__KAGURABLOOM
		   || id == CardIdentifier.COVERT_DEMONIC_DRAGON__HYAKKI_VOGUE______REVERSE_____
		   || id == CardIdentifier.MAIDEN_OF_VENUS_TRAP______REVERSE_____
		   || id == CardIdentifier.LORD_OF_THE_DEEP_FORESTS__MASTER_WISTERIA
		   || id == CardIdentifier.REVENGER_DESPERATE_DRAGON
		   || id == CardIdentifier.REVENGER_DRAGRULER_PHANTOM
		   || id == CardIdentifier.LIBERATOR_MONARCH_SANCTUARY_ALFRED
		   || id == CardIdentifier.DRAGONIC_OVERLORD_BREAK_RIDE
		   || id == CardIdentifier.DRAGONIC_OVERLORD_THE_REBIRTH
		   || id == CardIdentifier.STARVADER_REVERSE_CRADLE
		   || id == CardIdentifier.SILVER_THORN_DRAGON_EMPRESS_VENUS_LUQUIER
		   || id == CardIdentifier.BLUE_STORM_KARMA_DRAGON_MAELSTROM_REVERSE
		   || id == CardIdentifier.LIBERATOR_HOLY_SHINE_DRAGON)
		{
			_card.bLord = true;
		}

		//Sentinel
		if(id == CardIdentifier.STEALTH_BEAST_MIJINGAKURE
		   || id == CardIdentifier.BEAST_DEITY__SOLAR_FALCON
		   || id == CardIdentifier.DIMENSIONAL_ROBO__DAISHIELD
		   || id == CardIdentifier.SUMMONING_JEWEL_KNIGHT__GLORIA
		   || id == CardIdentifier.SWORD_FORMATION_LIBERATOR__IGRAINE
		   || id == CardIdentifier.GODDESS_OF_THE_SHIELD__AEGIS
		   || id == CardIdentifier.SILVER_COLLAR_SNOWSTORM__SASAME
		   || id == CardIdentifier.RED_ROSE_MUSKETEER__ANTONIO
		   || id == CardIdentifier.HATRED_PRISON_REVENGER_KUESARU
		   || id == CardIdentifier.DRAGON_KNIGHT_GIMEL)
		{
			_card.bSentinel = true;
		}


		if (id == CardIdentifier.KING_OF_KNIGHTS_ALFRED) {
			_card.bCanBeBoostedVanguard = false;	
		}
		else if(id == CardIdentifier.NIGHTMARE_DOLL__CHELSEA)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.CLEANUP_CELESTIAL__RAMIEL______REVERSE_____)
		{
			_card.bHasLimitBreak4 = true;
			_card.bLord = true;
		}
		else if(id == CardIdentifier.MIRACLE_POP__EVA)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__VLAD_SPECULA)
		{
			_card.bSentinel = true;
		}
		else if(id == CardIdentifier.SILVER_THORN_HYPNOS__LYDIA)
		{
			_card.bSentinel = true;
		}
		else if(id == CardIdentifier.DARK_REVENGER__MAC_LIR)
		{
			_card.bSentinel = true;
		}
		else if(id == CardIdentifier.BARRIER_STAR_VADER__PROMETHIUM)
		{
			_card.bSentinel = true;
		}
		else if(id == CardIdentifier.MASTER_OF_FIFTH_ELEMENT)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.SCHWARZSCHILD_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.KING_OF_MASKS__DANTARIAN)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.SILVER_THORN_DRAGON_QUEEN__LUQUIER______REVERSE_____)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.WITCH_OF_CURSED_TALISMAN__ETAIN)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.DEMON_MARQUIS__AMON______REVERSE_____)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.STAR_VADER__NEBULA_LORD_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.ERADICATOR__VOWING_SABER_DRAGON______REVERSE_____)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.DEMON_CONQUERING_DRAGON__DUNGAREE______UNLIMITED_____)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.WOLF_FANG_LIBERATOR__GARMORE)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.REVENGER__RAGING_FORM_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.OPTICS_CANNON_TITAN)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.BLUE_STORM_DRAGON__MAELSTROM)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.SAVAGE_HUNTER)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.THUNDERING_RIPPLE__GENOVIOUS)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.ARMOR_BREAK_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__SPINODRIVER)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.RAVENOUS_DRAGON__BATTLEREX)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__TYRANNOLEGEND)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.SEAL_DRAGON__RINOCROSS)
		{
			_card.bSentinel = true;
		}
		else if(id == CardIdentifier.ERADICATOR__SWEEP_COMMAND_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.LAST_CARD__REVONN)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.DAUNTLESS_DRIVE_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.GODDESS_OF_GOOD_LUCK__FORTUNA)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.HELLFIRE_SEAL_DRAGON__BLOCKADE_INFERNO)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.ERADICATOR__SPARK_HORN_DRAGON)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.INCANDESCENT_LION__BLOND_EZEL)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.ULTIMATE_DIMENSIONAL_ROBO__GREAT_DAIYUSHA)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.DARK_LORD_OF_ABYSS)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.BLUE_FLIGHT_DRAGON__TRANS_CORE_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.PROPHECY_CELESTIAL__RAMIEL)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.SOLIDIFY_CELESTIAL__ZERACHIEL)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
        else if(id == CardIdentifier.FLASHING_JEWEL_KNIGHT__ISEULT)
        {
            _card.bSentinel = true;
        }
        else if(id == CardIdentifier.ERADICATOR_WYVERN_GUARD__GULD)
        {
            _card.bSentinel = true;
        }
        else if(id == CardIdentifier.GODDESS_OF_SELF_SACRIFICE__KUSHINADA)
        {
            _card.bSentinel = true;
        }
        else if(id == CardIdentifier.HALO_LIBERATOR__MARK)
        {
            _card.bSentinel = true;
        }
        else if(id == CardIdentifier.RABBIT_HOUSE)
        {
            _card.bHasLimitBreak4 = true;
        }
        else if(id == CardIdentifier.ARMORED_HEAVY_GUNNER)
        {
            _card.bHasLimitBreak4 = true;
        }
		else if(id == CardIdentifier.BATTLE_DEITY_OF_THE_NIGHT__ARTEMIS)
		{
			_card.bHasLimitBreak4 = true;	
		}
		else if(id == CardIdentifier.ERADICATOR__GAUNTLET_BUSTER_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.BAD_END_DRAGGER)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.GRATEFUL_CATAPULT)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.BEAST_DEITY__ETHICS_BUSTER)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.ORACLE_QUEEN__HIMIKO)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.ERADICATOR__DRAGONIC_DESCENDANT)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}	
		else if(id == CardIdentifier.ETERNAL_GODDESS__IWANAGAHIME)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.LIBERATOR_OF_THE_ROUND_TABLE__ALFRED)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.LEADING_JEWEL_KNIGHT__SALOME)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.PURE_HEART_JEWEL_KNIGHT__ASHLEY)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.SANCTUARY_GUARD_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__MIZUHA)
		{	
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.WITCH_OF_WOLVES__SAFFRON)
		{
			_card.bHasLimitBreak4 = true;	
		}
		else if(id == CardIdentifier.REGALIA_OF_WISDOM__ANGELICA)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAIKAISER)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;	
		}
		else if(id == CardIdentifier.STAR_VADER__INFINITE_ZERO_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.TWILIGHT_BARON)
		{
			_card.bHasLimitBreak4 = true;
		}	
		else if(id == CardIdentifier.ILLUSIONARY_REVENGER__MORDRED_PHANTOM)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}	
		else if(id == CardIdentifier.DISCHARGING_DRAGON)
		{
			_card.bHasLimitBreak4 = true;	
		}
		else if(id == CardIdentifier.ERADICATOR__VOWING_SWORD_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.SOLITARY_LIBERATOR__GANCELOT)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}	
		else if(id == CardIdentifier.GENIE_SOLDAT)
		{
			_card.bRestraintVanguard = true;
			_card.bRestraintRearGuard = true;
		}
		else if(id == CardIdentifier.DRAGON_DANCER__MARIA)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.BLAST_BULK_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.CRUEL_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.PLUTO_BLAUKLUGER)
		{
			_card.bHasLimitBreak4 = true;	
		}
		else if(id == CardIdentifier.BLAU_DUNKELHEIT)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.MOND_BLAUKLUGER)
		{
			_card.bHasLimitBreak4 = true;
			_card.bLord = true;
		}
		else if(id == CardIdentifier.GALAXY_BLAUKLUGER)
		{
			_card.bHasLimitBreak4 = true;
			_card.bLord = true;	
		}
		else if(id == CardIdentifier.PENTAGONAL_MAGUS)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.TETRA_MAGUS)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.BATTLE_SISTER__PARFAIT)
		{
			_card.bHasLimitBreak4 = true;
			_card.bLord = true;
		}
		else if(id == CardIdentifier.BATTLE_SISTER__MONAKA)
		{
			_card.bHasLimitBreak4 = true;
			_card.bLord = true;
		}
		else if (id == CardIdentifier.BRUTAL_JACK) {
			_card.bRestraintVanguard = true;
			_card.bRestraintRearGuard = true;
		}
		else if(id == CardIdentifier.GOLDEN_BEAST_TAMER)
		{
			_card.bRestraintVanguard = true;
			_card.bRestraintRearGuard = true;
		}
		else if(id == CardIdentifier.PROWLING_DRAGON__STRIKEN)
		{
			_card.bRestraintVanguard = true;	
		}
		else if(id == CardIdentifier.IMPRISONED_FALLEN_ANGEL__SARAQAEL)
		{
			_card.bRestraintRearGuard = true;
			_card.bRestraintVanguard = true;
		}
		else if(id == CardIdentifier.MERMAID_IDOL__ELLY)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.STORMRIDE_GHOST_SHIP)
		{
			_card.bRestraintRearGuard = true;
			_card.bRestraintVanguard = true;			
		}
		else if(id == CardIdentifier.THUNDER_SPEAR_WIELDING_EXORCIST_KNIGHT)
		{
			_card.bRestraintRearGuard = true;
			_card.bRestraintVanguard = true;				
		}
		else if(id == CardIdentifier.DJINN_OF_THE_LIGHTNING_FLASH)
		{
			_card.bCanAttackRearGuard = false;	
		}
		else if(id == CardIdentifier.DJINN_OF_THE_LIGHTNING_FLARE)
		{
			_card.bCanAttackRearGuard = false;	
		}
		else if(id == CardIdentifier.DJINN_OF_THE_LIGHTNING_SPARK)
		{
			_card.bCanAttackRearGuard = false;	
		}
		else if(id == CardIdentifier.BLUE_STORM_SUPREME_DRAGON__GLORY_MAELSTROM)
		{
			_card.bLord = true;	
		}
		else if(id == CardIdentifier.GODDESS_OF_THE_SUN__AMATERASU)
		{
			_card.bLord = true;	
		}
		else if(id == CardIdentifier.ULTRA_BEAST_DEITY__ILLUMINAL_DRAGON)
		{
			_card.bLord = true;	
		}
		else if(id == CardIdentifier.BLAZING_LION__PLATINA_EZEL)
		{
			_card.bLord = true;	
		}	
		else if(id == CardIdentifier.DRAGONIC_KAISER_VERMILLION______THE_BLOOD_____)
		{
			_card.bLord = true;	
		}
		else if(id == CardIdentifier.FANTASY_PETAL_STORM__SHIRAYUKI)
		{
			_card.bLord = true;	
		}
		else if(id == CardIdentifier.STARLIGHT_MELODY_TAMER__FARAH)
		{
			_card.bLord = true;	
		}
		else if(id == CardIdentifier.BLASTER_BLADE_SPIRIT)
		{
			_card.secondaryClan = "Gold Paladin";	
		}
		else if(id == CardIdentifier.EXORCIST_DEMONIC_DRAGON__INDIGO)
		{
			_card.SetBoostConstraint(delegate(Card tmpC)
			{
				return tmpC.grade > 2 && _card.pos != fieldPositions.VANGUARD_CIRCLE;
			});
		}
		else if(id == CardIdentifier.DEITY_SEALING_KID__SOH_KOH)
		{
			_card.bRestraintRearGuard = true;
			_card.bRestraintVanguard = true;
			
			_card.SetBoostConstraint(delegate(Card tmpC)
			{
				return tmpC.IsVanguard();	
			}, "This unit cannot boost a rear-guard.");
		}
		else if(id == CardIdentifier.ETERNAL_IDOL__PACIFICA)
		{
			_card.bLord = true;	
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.PR___ISM_PROMISE__LABRADOR)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.PR___ISM_IMAGE__VERT)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}	
		else if(id == CardIdentifier.AURORA_STAR__CORAL)
		{
			_card.bHasLimitBreak4 = true;	
		}
		else if(id == CardIdentifier.SHINING_SINGER__IONIA)
		{
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.STEEL_SPEAR_LIBERATOR__BLEOBERIS)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.WISDOM_KEEPER__METIS)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.ERADICATOR__ELECTRIC_SHAPER_DRAGON)
		{
			_card.bLord = true;
			_card.bHasLimitBreak4 = true;
		}
		else if(id == CardIdentifier.EMERALD_SHIELD__PASCHAL)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.BATTLE_SISTER_CHOCOLAT)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.FLASH_SHIELD_ISEULT)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.CABLE_SHEEP)
		{
			_card.bSentinel = true;
		}
		else if(id == CardIdentifier.WYVERN_GUARD__GULD)
		{
			_card.bSentinel = true;
		}	
		else if(id == CardIdentifier.HALO_SHIELD__MARK)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.PURE_KEEPER__REQUIEL)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.MAIDEN_OF_BLOSSOM_RAIN)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.STEALTH_BEAST__LEAVES_MIRAGE)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.PARALYZE_MADONNA)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.DIAMOND_ACE)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.DARK_SHIELD__MAC_LIR)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.MERMAID_IDOL__ELLY)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.HADES_HYPNOTIST)
		{	
			_card.bSentinel = true;
		}
		else if(id == CardIdentifier.ARCHBIRD)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.MARCH_RABBIT_OF_NIGHTMARELAND)
		{
			_card.bSentinel = true;
		}	
		else if(id == CardIdentifier.TWIN_BLADER)
		{
			_card.bSentinel = true;
		}	
		else if(id == CardIdentifier.GUST_JINN)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.WYVERN_GUARD_BARRI)
		{
			_card.bSentinel = true;	
		}
		else if(id == CardIdentifier.CHEER_GIRL_MARILYN)
		{
			_card.bSentinel = true;
		}	
		else if(id == CardIdentifier.HEXAGONAL_MAGUS)
		{
			_card.bHasLimitBreak4 = true;
			_card.bLord = true;
		}
		else if(id == CardIdentifier.IMMORTAL__ASURA_KAISER)
		{
			_card.bHasLimitBreak4 = true;
			_card.bLord = true;
		}
        else if(id == CardIdentifier.DIGNIFIED_SILVER_DRAGON)
        {
            _card.bHasLimitBreak4 = true;
        }
	}
	
	public void FillCardWithData (Card _card, CardIdentifier id)
	{
		int index = (int)id;
		_card.grade = Card [index].grade;
		_card.trigger = Card [index].trigger;
		_card.skill = Card [index].skill;
		_card.shield = Card [index].shield;
		_card.name = Card [index].name;
		_card.race = Card [index].race;
		_card.clan = Card [index].clan;
		_card.critical = Card [index].critical;
		_card.power = Card [index].power;
		_card.secondaryClan = Card[index].secondaryClan;
		//_card.faceUpMat = Resources.Load(Card[index].mat, typeof(Material)) as Material;
		Material mat = Resources.Load (Card [index].mat, typeof(Material)) as Material;
		_card.faceUpMat = new Material (Shader.Find ("Diffuse"));
		_card.faceUpMat.mainTexture = Resources.Load ("CardHelper/" + _card.clan + "/" + Card [index].mat) as Texture;//mat.mainTexture;
		_card.faceUpMat.mainTextureOffset = mat.mainTextureOffset;
		_card.faceUpMat.mainTextureScale = mat.mainTextureScale;
		_card.cardID = id;
		
		AddSpecialConditions (_card, id);
	}
	
	public string GetImageName (CardIdentifier id)
	{
		int index = (int)id;
		return Card [index].mat;
	}

	public List<CardInformation> GetAllCards ()
	{
		return Card;	
	}
	
	public CardInformation GetCardInfo (CardIdentifier id)
	{
		int index = (int)id;
		return Card [index];		
	}
}

