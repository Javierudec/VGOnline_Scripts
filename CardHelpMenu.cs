using UnityEngine;
using System.Collections;
using System.Collections.Generic;
		
		//Each time a card is selected with mouse or an effect is activated, the left menu will show the respective card
		//with its description. This class will manage that feature.
		
public class CardHelpMenu : MonoBehaviour {
	public GUIStyle backgroundStyle;
	private List<Texture2D> cardTextures;
	public Texture2D currentCardTexture;
	public Texture2D drawPhaseOff;
	public Texture2D drawPhaseOn;
	public Texture2D mainPhaseOff;
	public Texture2D mainPhaseOn;
	public Texture2D battlePhaseOff;
	public Texture2D battlePhaseOn;
	public Texture2D endPhaseOff;
	public Texture2D endPhaseOn;
	public Texture2D effectBackground;
	private GamePhase _CurrentPhase;
	private string desc = "";
	public bool bRenderGamePhases = true;
	private CardDataBase _Data;
	
	private float xCorr = 1.0f;
	private float yCorr = 1.0f;
	Vector2 scrollPosition;
	
	// Use this for initialization
	void Start () {
		xCorr = Screen.width / 1024.0f;
		yCorr = Screen.height / 768.0f;
		
		desc = "AUTO[V]: When this unit attacks, if it is the thid battle of that turn or more, this unit" +
				  " gets +3000 until end of that battle.\n\n" +
				   "AUTO[R]: When this unit attacks, if you have an <<Aqua Force>> vanguard, and if it is the third" +
				   "battle of that turn or more, this unit gets +1000 until end of that battle";
		
		cardTextures = new List<Texture2D>();
		cardTextures.Add(Resources.Load("n688") as Texture2D);	
		
		_Data = new CardDataBase();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public string GetDesc()
	{
		return desc;	
	}
	
	public void DrawGUI()
	{
		
		GUI.Box (new Rect(0,0,342 * xCorr,595 * yCorr), "", backgroundStyle);
		if(currentCardTexture != null)
		{
			GUI.DrawTexture(new Rect(15 * xCorr, 16 * yCorr, 217 * xCorr, 319 * yCorr), currentCardTexture);
		}
		
		if(bRenderGamePhases)
		{
			if(_CurrentPhase == GamePhase.DRAW)
				GUI.DrawTexture(new Rect(260 * xCorr, 22 * yCorr, drawPhaseOn.width, drawPhaseOn.height), drawPhaseOn);
			else
				GUI.DrawTexture(new Rect(260 * xCorr, 22 * yCorr, drawPhaseOff.width, drawPhaseOff.height), drawPhaseOff);
			
			if(_CurrentPhase == GamePhase.MAIN_PHASE)
				GUI.DrawTexture(new Rect(260 * xCorr, 106 * yCorr, mainPhaseOn.width, mainPhaseOn.height), mainPhaseOn);
			else
				GUI.DrawTexture(new Rect(260 * xCorr, 106 * yCorr, mainPhaseOff.width, mainPhaseOff.height), mainPhaseOff);
			
			if(_CurrentPhase == GamePhase.ATTACK)
				GUI.DrawTexture(new Rect(260 * xCorr, 186 * yCorr, battlePhaseOn.width, battlePhaseOn.height), battlePhaseOn);
			else
				GUI.DrawTexture(new Rect(260 * xCorr, 186 * yCorr, battlePhaseOff.width, battlePhaseOff.height), battlePhaseOff);
		
			if(_CurrentPhase == GamePhase.ENDTURN || _CurrentPhase == GamePhase.ENEMY_TURN)
				GUI.DrawTexture(new Rect(260 * xCorr, 268 * yCorr, endPhaseOn.width, endPhaseOn.height), endPhaseOn);
			else
				GUI.DrawTexture(new Rect(260 * xCorr, 268 * yCorr, endPhaseOff.width, endPhaseOff.height), endPhaseOff);
		}

		GUI.DrawTexture(new Rect(5, 360, effectBackground.width, effectBackground.height), effectBackground);

		scrollPosition = GUI.BeginScrollView(new Rect(20, 390, 300, 160), scrollPosition, new Rect(0, 0, 300, 300), GUIStyle.none, new GUIStyle(GUI.skin.verticalScrollbar));

		int saveFont = GUI.skin.label.fontSize;
		GUI.skin.label.fontSize = 11;
		GUI.skin.label.normal.textColor = Color.black;
		GUI.Label(new Rect(1, 1, 280, 300), desc);
		GUI.skin.label.normal.textColor = Color.white;
		GUI.Label(new Rect(0, 0, 280, 300), desc);
		GUI.skin.label.fontSize = saveFont;

		GUI.EndScrollView();
	}
	
	public void SetCard(CardIdentifier id)
	{		
		desc = _Data.GetCardInfo(id).name + " (" + _Data.GetCardInfo(id).clan + ", " + _Data.GetCardInfo(id).race + ")\n\n";
		currentCardTexture = Resources.Load("CardHelper/" + _Data.GetCardInfo(id).clan + "/" +  _Data.GetCardInfo(id).mat) as Texture2D;
		
		if(id == CardIdentifier.BLADE_ARM_LEPRECHAUN)
		{
			desc += "[AUTO](RC):[Soul Blast (1)] When this unit boosts a unit with \"Blau\" in its card name, " +
				    "you may pay the cost. If you do, the boosted unit gets [Power]+6000 until end of that battle.";	
		}
		else if(id == CardIdentifier.MACHINING_SPARK_HERCULES)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (2)-card with \"Machining\" in its card name]" + 
				    " When this unit attacks a vanguard, if all of your opponent's vanguard and rear-guards are [Rest], you may pay the cost. If you do, this unit gets" + 
					" [Power]+10000/[Critical]+1 until end of turn, and choose one of your opponent's rear-guards, and that unit cannot [Stand] during your opponent's next stand phase.\n\n" + 
					"[ACT](VC):[Soul Blast (1)-card with \"Machining\" in its card name] [Rest] all of your opponent's rear-guards, and this unit gets [Power]+2000 until end of turn.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.UNRIVALED_BLADE_ROGUE_CYCLOMATOOTH)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage):When a \"Megacolony\" rides this unit, choose your vanguard, that unit gets [Power]+10000 until" + 
				    " end of turn, and [Rest] all of your opponent's units, and all of your opponent's units cannot [Stand] during your opponent's next stand phase.\n\n" + 
					"[CONT](VC):During your turn, if all of your opponent's vanguard and rear-guards are [Rest], this unit gets [Power]+2000.\n\n" + 
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.SHARP_FANG_WITCH_FODLA)
		{
			desc += "[AUTO]:[Counter Blast (1)] When this unit is placed on (VC) or (RC), if you have a \"Shadow Paladin\" vanguard, you may pay the cost. If you do, search your deck for up to two grade 0" + 
				    " \"Shadow Paladin\", call them to separate (RC), and shuffle your deck.";
		}
		else if(id == CardIdentifier.MACHINING_LADYBUG)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with \"[CONT]: Sentinel\" in a deck)\n\n" + 
				    "[AUTO]:[Counter Blast (1)] When this is placed on (GC) from your hand, if you have a \"Megacolony\"" + 
					" vanguard, you may pay the cost. If you do, reveal the five cards from the top of your deck, call all \"Megacolony\"" + 
					" from among them to (GC) as [Rest], and put the rest into the drop zone.";
		}
		else if(id == CardIdentifier.BLUE_STORM_GUARDIAN_DRAGON_ICEFALL_DRAGON)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with \"[CONT]: Sentinel\" in a deck)\n\n" + 
					"[AUTO]:[Counter Blast (1)] When this is placed on (GC) from your hand, if you have a \"Aqua Force\" vanguard," + 
					" you may pay the cost. If you do, reveal the five cards from the top of your deck, call all \"Aqua Force\" from " + 
					"among them to (GC) as [Rest], and put the rest into the drop zone.";
		}
		else if(id == CardIdentifier.LIBERATOR_STAR_RAIN_TRUMPETER)
		{
			desc += "[AUTO]:[Choose a card named \"Blaster Blade Liberator\" from your soul or drop zone, and put it on top of your deck] " + 
				    "When this unit is placed on (RC), if you have a \"Gold Paladin\" vanguard, you may pay the cost. If you do, shuffle your " + 
					"deck, look at the top card of your deck, search for up to one \"Gold Paladin\", call it to an open (RC), and put the rest on the bottom of your deck.";
		}
		else if(id == CardIdentifier.DRAGONIC_BURNOUT)
		{
			desc += "[AUTO]:[Soul Blast (1)] When this unit is placed on (RC), if you have a \"Kagero\" vanguard, choose one card with \"Overlord\" in its card name from your" + 
					" drop zone, and you may put it on the bottom of your deck. If you do, you may pay the cost. If you do, choose one of your opponent's rear-guards, and retire it.";
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT_GIMEL)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with \"[CONT]: Sentinel\" in a deck)[AUTO]:[Counter Blast (1)] " + 
					"When this is placed on (GC) from your hand, if you have a \"Kagero\" vanguard, you may pay the cost. If you do, reveal the" + 
					" five cards from the top of your deck, call all \"Kagero\" from among them to (GC) as [Rest], and put the rest into the drop zone.";
		}
		else if(id == CardIdentifier.STARVADER_FREEZE_RAY_DRAGON)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):When your opponent's rear-guard is locked due to an " + 
					"effect from one of your cards, this unit gets [Power]+3000 until end of turn.\n\n" + 
					"[AUTO](VC):When a card is put into your damage zone, choose up to one of your opponent's rear-guards, and lock it. " + 
					"(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's turn.)";
		}
		else if(id == CardIdentifier.REVENGER_BLOODMASTER)
		{
			desc += "[AUTO]:[Counter Blast (1)] When this unit is placed on (RC), if you have a \"Shadow Paladin\" vanguard, you may pay the cost. " + 
				    "If you do, put the top card of your deck face down into your damage zone, and draw two cards.";
		}
		else if(id == CardIdentifier.LIBERATOR_HOLY_SHINE_DRAGON)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):At the end of your turn, choose one grade 3 " + 
				    "\"Gold Paladin\" from your soul, and you may ride it. If you do, choose one card named \"Liberator, Holy Shine Dragon\" from your soul, and put it into your hand.\n\n" + 
					"[AUTO]:[Counter Blast (1)-card with \"Liberator\" in its card name] When this unit is placed on (VC), you may pay the cost. If you do, look at the top card of your deck," + 
					" search for up to one \"Gold Paladin\", call it to an open (RC), and put the rest on the bottom of your deck.\n\n" + 
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.HATRED_PRISON_REVENGER_KUESARU)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with \"[CONT]: Sentinel\" in a deck)\n\n" + 
				    "[AUTO]:[Counter Blast (1)] When this is placed on (GC) from your hand, if you have a \"Shadow Paladin\" vanguard, you may pay the cost. " + 
					"If you do, reveal the five cards from the top of your deck, call all \"Shadow Paladin\" from among them to (GC) as [Rest], and put the rest into the drop zone.";
		}
		else if(id == CardIdentifier.BLACKWINGED_SWORDBREAKER)
		{
			desc += "[AUTO]:[Soul Blast (1)] When this unit is placed on (RC) from your deck, if you have a \"Shadow Paladin\" vanguard, you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.SILVER_THORN_DRAGON_EMPRESS_VENUS_LUQUIER)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (2)-card with \"Silver Thorn\" in its card name] Soul Charge (2)," + 
				    " choose up to five \"Pale Moon\" from your soul whose total grades are six or less, and call them to separate (RC). This ability cannot be used for the rest of that turn.\n\n" + 
					"[CONT](VC):If you have a card named \"Silver Thorn Dragon Tamer, Luquier\" in your soul, this unit gets [Power]+2000.\n\n" + 
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.STARVADER_REVERSE_CRADLE)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):When a unit with \"Reverse\" in its card name is placed on your (RC), choose one of your opponent's rear-guards," + 
				    " lock it, and this unit gets [Power]+5000 until end of turn. This ability cannot be used for the rest of that turn. (The locked card is turned face down, and cannot do anything. It turns face up at" + 
					" the end of the owner's turn.)\n\n" + 
					"[CONT](VC):All of your rear-guards with \"Reverse\" in its card name are also \"Link Joker\".\n\n" + 
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.DRAGONIC_OVERLORD_BREAK_RIDE)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage):When a \"Kagero\" rides this unit, choose your vanguard, and until end of turn, that unit gets " +
				    "[Power]+10000 and \"[AUTO](VC):[Counter Blast (1) and Choose a \"Kagero\" from your hand, and discard it] At the end of the battle that this unit attacked a rear-guard, you may" + 
					" pay the cost. If you do, [Stand] this unit. This ability cannot be used for the rest of that turn. (This ability cannot be used even if the cost is not paid.)\".\n\n" + 
					"[AUTO](VC):When this unit attacks, if the number of rear-guards you have is more than your opponent's, this unit gets [Power]+2000 until end of that battle.\n\n" + 
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.DRAGONIC_OVERLORD_THE_REBIRTH)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1) and Choose one of your \"Kagero\" rear-guards or more, and lock them] If the number " + 
				    "of locked cards you have is five or more, until end of turn, this unit gets [Power]+10000, and \"[AUTO](VC):[Choose two \"Kagero\" from your hand, and discard them] At the end of the battle " + 
					"that this unit attacked a vanguard, you may pay the cost. If you do, [Stand] this unit. This ability cannot be used for the rest of that turn. (This ability cannot be used even if the cost is" + 
					" not paid.)\".(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's turn.)\n\n" + 
					"[CONT](VC):If you have a card named \"Dragonic Overlord\" in your soul, this unit gets [Power]+2000.\n\n" + 
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.LIBERATOR_MONARCH_SANCTUARY_ALFRED)
		{
			desc += "[AUTO](VC) Limit Break 5 (This ability is active if you have five or more damage):When your unit named \"Blaster Blade Liberator\" is placed on (RC) from your deck," + 
					" this unit gets [Power]+10000/[Critical]+1 until end of turn.\n\n" + 
					"[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (3) and Soul Blast (2)] Put all of your rear-guards and locked cards on" + 
					" top of your deck in any order, and look at five cards from the top of your deck, search for up to five cards with \"Liberator\" in its card name, call them to separate (RC)," + 
					" and put the rest on the bottom of your deck in any order. This ability cannot be used for the rest of that turn.\n\n" + 
					"[CONT](VC):During your turn, this unit gets [Power]+1000 for each of your \"Gold Paladin\" rear-guards.\n\n" + 
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.BLUE_STORM_KARMA_DRAGON_MAELSTROM_REVERSE)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1) and Choose one of your rear-guards, [Rest] it, and lock it] When this unit attacks a vanguard," + 
				    " if it is the fourth battle of that turn or more, you may pay the cost. If you do, until end of that battle, this unit gets [Power]+5000/[Critical]+1 and \"[AUTO](VC): At the end of the battle that " + 
					"this unit attacked, if the attack did not hit during that battle, draw a card, choose one opponent's rear-guards, and retire it.\".(The locked card is turned face down, and cannot do anything. " + 
					"It turns face up at the end of the owner's turn.)\n\n" + 
					"[CONT](VC): If you have a card named \"Blue Storm Dragon, Maelstrom\" in your soul, this unit gets [Power]+2000.\n\n" + 
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.STAR_VADER_OMEGA_GLENDIOS)
		{
			desc += "[AUTO](VC) Limit Break 5 (This ability is active if you have five or more damage):At the beginning of your main phase, if the number of your opponent's locked cards is five or more, you win.\n\n" +
				    "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1) and Choose one card with \"Reverse\" in its card name from your hand, and discard it]" +
					" All of your opponent's locked cards cannot be unlocked during your opponent's next end phase.\n\n" +
					"[AUTO](VC):When a unit with \"Reverse\" in its card name is placed on your (RC), choose one of your opponent's rear-guards, and lock it. This ability cannot be used for the rest of that turn.\n\n" +
					"[CONT](VC):All of your rear-guards with \"Reverse\" in its card name are also \"Link Joker\", and during your turn, those units get [Power]+4000.";
		}
		else if(id == CardIdentifier.REVENGER_DRAGRULER_PHANTOM)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1) and Choose two of your rear-guards with \"Revenger\" in its card name, and retire them]" + 
					" This unit gets [Power]+10000 until end of turn, and if the number of cards in your opponent's damage zone is four or less, choose your opponent's vanguard, and deal one damage to it. " + 
					"(Damage check is performed)\n\n" + 
					"[CONT](VC):If you have a card named \"Illusionary Revenger, Mordred Phantom\" in your soul, this unit gets [Power]+2000.\n\n" + 
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE_KIMNARA)
		{
			desc += "[ACT](RC):[Counter Blast (1)] and Put this unit into your soul] If you have a \"Kagero\" vanguard, choose up to one of your opponent's grade 1 rear-guards, and retire it.";
		}
		else if(id == CardIdentifier.FLAME_STAR_SEAL_DRAGON_KNIGHT)
		{
			desc +=  "[ACT](VC/RC):[Counter Blast (1)] If you have a vanguard with \"Seal Dragon\" in its card name, all of your opponent's units cannot intercept until end of turn.";
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT_BERGER)
		{
			desc += "[AUTO]:When this unit intercepts, if you have a \"Kagero\" vanguard, this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.REVENGER_DESPERATE_DRAGON)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1)-card with \"Revenger\" in its card name] " +
					"When this unit attacks a vanguard, if the number of rear-guards you have is more than your opponent's, you may pay the cost. If you do, this unit" +
					"gets [Power]+5000/[Critical]+1 until end of that battle.\n\n" +
					"[AUTO](VC):[Choose one of your \"Shadow Paladin\" rear-guards, and retire it] At the beginning of your main phase, you may pay the cost. If you do, " +
					"your opponent chooses one of his or her rear-guards, and retires it.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.BLUE_ROSE_MUSKETEER__ERNEST)
		{
			desc += "[ACT](RC):[Counter Blast (1) and Put this unit on the bottom of your deck] If you have a \"Neo Nectar\" vanguard, " +
					"look at up to four cards from the top of your deck, search for up to one card with \"Musketeer\" in its card name, " +
					"call it to (RC), and shuffle your deck.";
		}
		else if(id == CardIdentifier.CHAIN_ATTACK_SUTHERLAND)
		{
			desc += "[AUTO](VC/RC):During your main phase, when an opponent's rear-guard is put into the drop zone, this unit get [Power] +3000 until end of turn.";
		}
		else if(id == CardIdentifier.BLAZING_CORE_DRAGON)
		{
			desc += "[ACT](VC): [Counter Blast (1) and Choose a unit named \"Iron Tail Dragon\" and a unit named \"Gatling Claw Dragon\" from your (RC)," +
					"and put them into your soul] Search your deck for up to one card named \"Blazing Flare Dragon\", ride it, and shuffle your deck.";
		}
		else if(id == CardIdentifier.MAIDEN_OF_PHYSALIS)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit" +
					"boosted a \"Neo Nectar\", you may pay the cost. If you do, look at up to five cards from the top of your deck," +
					"search for up to one grade 1 \"Neo Nectar\", call it to (RC) as [Rest], and shuffle your deck.";
		}
		else if(id == CardIdentifier.JACKIN______PUMPKIN)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (1) - \"Neo Nectar\"] When this unit attacks, if you have a \"Neo Nectar\" vanguard, " +
					"you may pay the cost. If you do, this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.WISHING_DJINN)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Put this unit into your soul and Choose a card from your hand, and discard it] If you have a \"Narukami\" vanguard, draw a card.";
		}
		else if(id == CardIdentifier.WYVERN_STRIKE__ZAROOS)
		{
			desc += "[ACT](RC):[Rest] this unit] Choose another of your \"Narukami\", and that unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.DRAGON_DANCER__AGATHA)
		{
			desc += "[AUTO](RC):[Soul Blast (1)] When your opponent's rear-guard is put into the drop zone due to an effect from one of your cards, if you have a \"Narukami\"" +
					"vanguard, you may pay the cost. If you do, choose another of your \"Narukami\", and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.ROARING_THUNDER_BOW__ZAFURA)
		{
			desc += "[AUTO](VC/RC):When this unit's attack hits a vanguard, if you have a \"Narukami\" vanguard, choose a card from your damage zone, and turn it face up.";
		}
		else if(id == CardIdentifier.PLASMA_SCIMITAR_DRAGOON)
		{
			desc += "[AUTO](RC):When your grade 3 \"Narukami\" is placed on (VC), this unit gets [Power]+10000 until end of turn.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__DEATHLY_DAGGER)
		{
			desc += "[AUTO](RC):When this unit boosts a \"Murakumo\", if the number of units you have with the same name as the " +
					"boosted unit is two or greater, the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_KITE__GOEMON)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Soul Blast (1)] If you have a \"Murakumo\" vanguard, choose one of your open (RC), and move this unit. (The state of the card does not change)";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__CHAIN_GEEK)
		{
			desc += "[CONT](VC/RC): During your turn, if the number of \"Murakumo\" rear-guards you have is four or more, this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.PRISON_EGG_SEAL_DRAGON_KNIGHT)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Put this unit into your soul & Choose a card from your hand, and discard it] If you have a \"Kagero\" vanguard, draw a card.";		
		}
		else if(id == CardIdentifier.CALAMITY_TOWER_WYVERN)
		{
			desc += "[AUTO]:[Soul Blast (2)] When this unit is placed on (RC), if you have a \"Kagero\" vanguard, you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.EXPLOSIVE_CLAW_SEAL_DRAGON_KNIGHT)
		{
			desc += "[AUTO](VC/RC):When this unit attacks a grade 2 unit, if you have a \"Kagero\" vanguard, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__TAKSAKA)
		{
			desc += "[AUTO](VC/RC):When this unit attacks, if the number of rear-guards you have is more than your opponent's, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DIABLE_DRIVE_DRAGON)
		{
			desc += "[AUTO](RC):When this unit attacks, if you have a vanguard with \"Dauntless\" in its card name, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT__LEZAR)
		{
			desc += "[AUTO](RC):When your grade 3 \"Kagero\" is placed on (VC), this unit gets [Power]+10000 until end of turn.";
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT__JALAL)
		{
			desc += "[AUTO](VC):When this unit's drive check reveals a \"Kagero\", this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.SPECTRAL_SHEEP)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Put this unit into your soul & Choose a card from your hand, and discard it] If you have a \"Genesis\" vanguard, draw a card.";
		}
		else if(id == CardIdentifier.GODDESS_OF_UNION__JUNO)
		{
			desc += "[AUTO](RC): When this unit attacks, if you have a vanguard with \"Regalia\" in its card name, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.MYTH_GUARD__ACHERNAR)
		{
			desc += "[AUTO](RC):When a card named \"Myth Guard, Achernar\" is put into the drop zone from your soul, if you have a \"Genesis\" vanguard, this unit gets [Power]+3000 until the end of turn.";
		}
		else if(id == CardIdentifier.ORANGE_WITCH__VALENCIA)
		{
			desc += "[AUTO]:When this card is put into the drop zone from your soul, if you have a \"Genesis\" vanguard, you may Soul Charge (2).";
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__KAYANARUMI)
		{
			desc += "[AUTO](VC/RC):When this unit attacks, if the number of rear-guards you have is more than your opponent's," +
					"this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.MYTH_GUARD__DENEBOLA)
		{
			desc += "[AUTO](RC): When a card named \"Myth Guard, Denebola\" is put into the drop zone from your soul, if " +
					"you have a \"Genesis\" vanguard, this unit gets [Power]+3000 until the end of turn.";
		}
		else if(id == CardIdentifier.MYTH_GUARD__FOMALHAUT)
		{
			desc += "[AUTO](VC):When this unit's drive check reveals a \"Genesis\", this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.ANGELIC_WISEMAN)
		{
			desc += "[AUTO](VC/RC):[Soul Blast (3)] When this unit attacks, if you have a \"Genesis\" vanguard, you may pay the cost. " +
					"If you do, this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.SCARLET_LION_CUB__CARIA)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit " +
					"boosted a vanguard with \"Ezel\" in its card name, you may pay the cost. If you do, look at up to two cards " +
					"from the top of your deck, search for up to two «Gold Paladin», call them to open (RC) as [Rest], and put " +
					"the rest on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.THROW_BLADE_KNIGHT__MALEAGANT)
		{
			desc += "[AUTO]:[Soul Blast (2)] When this unit is placed on (RC), if you have a \"Gold Paladin\" vanguard, " +
					"you may pay the cost. If you do, choose up to two cards from your damage zone, and turn them face up.";
		}
		else if(id == CardIdentifier.DORGAL_LIBERATOR)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (1)] When an attack by another of your unit with \"Liberator\" in its " +
					"card name hits a vanguard, if you have a «Gold Paladin» vanguard, you may pay the cost. If you do, this " +
					"unit gets [Power]+5000 until end of turn.";
		}
		else if(id == CardIdentifier.FLYING_SWORD_LIBERATOR__GORLOIS)
		{
			desc += "[ACT](RC):[Choose one grade 3 card with \"Gancelot\" in its card name from your drop zone, and put it on the bottom of your deck] " +
					"If you have a «Gold Paladin» vanguard, choose one of your grade 3 units with \"Gancelot\" in its card name, and that unit gets " +
					"[Power]+5000 until end of turn.";
		}
		else if(id == CardIdentifier.TWIN_HOLY_BEAST__WHITE_LION)
		{
			desc += "[AUTO]:[Counter Blast (1)] When this unit is placed on (RC), if you have a vanguard with \"Ezel\" in its card name, you may pay the cost. If you do, " +
					"Soul Charge (1), put the top card of your deck into your damage zone, and at the end of that turn, choose a card from your damage zone, return it to " +
					"your deck, and shuffle your deck.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_PASSION__TOR)
		{
			desc += "[AUTO](RC):When this unit attacks, if you have a vanguard with \"Ezel\" in its card name, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.LIBERATOR__BURNING_BLOW)
		{
			desc += "[AUTO](VC):When this unit's drive check reveals a \"Gold Paladin\", this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.SACRED_GUARDIAN_BEAST__CERYNEIAN)
		{
			desc += "[AUTO](RC):When this unit's attack hits a vanguard, choose one of your \"Gold Paladin\", and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.TWIN_HOLY_BEAST__BLACK_LION)
		{
			desc += "[CONT](VC/RC):During your turn, if the number of \"Gold Paladin\" rear-guards you have is four or more, this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.DESIRE_JEWEL_KNIGHT__HELOISE)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):When this unit boosts, if the number of other rear-guards you have with \"Jewel Knight\" in its card name is three or more, +" +
					"the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SECURITY_JEWEL_KNIGHT__ARWEN)
		{
			desc += "[ACT](RC):[Choose one grade 3 card with \"Ashlei\" in its card name from your drop zone, and put it on the bottom of your deck] " +
					"If you have a \"Royal Paladin\" vanguard, choose one of your grade 3 units with \"Ashlei\" in its card name, and that unit gets [Power]+5000 " +
					"until end of turn.";
		}
		else if(id == CardIdentifier.JEWEL_KNIGHT__MELME)
		{
			desc += "[AUTO]:[Counter Blast (1)] When this unit is placed on (VC) or (RC), if you have a \"Royal Paladin\" vanguard, you may pay the cost. " +
					"If you do, put the top card of your deck into your damage zone, and at the end of that turn, choose a card from your damage zone, " +
					"return it to your deck, and shuffle your deck.";
		}
		else if(id == CardIdentifier.SANCTUARY_OF_LIGHT__LITTLE_STORM)
		{
			desc += "[CONT](VC):If you have a card named \"Sanctuary of Light, Planet Lancer\" in your soul, this unit gets [Power]+1000.\n\n" +
					"[AUTO]:When a grade 2 \"Royal Paladin\" not named \"Sanctuary of Light, Determinator\" rides this unit, if you have a card " +
					"named \"Sanctuary of Light, Planet Lancer\" in your soul, look at up to seven cards from the top of your deck, search for up " +
					"to one card named \"Sanctuary of Light, Determinator\" from among them, ride it, and shufle your deck.";
		}
		else if(id == CardIdentifier.JEWEL_KNIGHT__TREANME)
		{
			desc += "[AUTO]:[Counter Blast (1)] When this unit is placed on (VC) or (RC), if you have a \"Royal Paladin\" vanguard, you may pay the cost. " +
					"If you do, put the top card of your " +
					"deck into your damage zone, and at the end of that turn, choose a card from your damage zone, return it to your deck, and shuffle your deck.";
		}
		else if(id == CardIdentifier.MYSTICAL_HERMIT)
		{
			desc += "[AUTO](RC):When this unit's attack hits a vanguard, choose one of your \"Royal Paladin\", and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_COURAGE__ECTOR)
		{
			desc += "[AUTO](VC):When this unit's drive check reveals a \"Royal Paladin\", this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.MAIDEN_OF_CHERRY_STONE)
		{
			desc += "[AUTO](RC):[Put this unit on top of your deck] When an attack hits a vanguard during the battle that this unit boosted, if" +
					"you have a \"Neo Nectar\" vanguard, you may pay the cost. If you do, search your deck up to one card named \"Maiden of Cherry Bloom\", " +
					"call it to (RC) as [Rest], and shuffle your deck.";
		}
		else if(id == CardIdentifier.MAIDEN_OF_CHERRY_BLOOM)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (1) and Soul Blast (1)] When this unit's attack hits a vanguard, if you have a \"Neo Nectar\" vanguard, you may pay the cost. " +
					"If you do, search your deck up to one card named \"Maiden of Cherry Stone\", call it to (RC) as [Rest], and shuffle your deck.";
		}
		else if(id == CardIdentifier.WHITE_ROSE_MUSKETEER__ALBERTO)
		{
			desc += "[AUTO](VC/RC):When this unit's attack hits a vanguard, if you have a \"Neo Nectar\" vanguard, choose a card from your damage zone, and turn it face up.";
		}
		else if(id == CardIdentifier.SPIRITUAL_SPHERE_ERADICATOR__NATA)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Put this unit into your soul] Choose your vanguard with \"Eradicator\" in its card name, and " +
					"until end of turn, that unit gets \"[AUTO](VC):When your opponent's rear-guard is put into the drop zone due" +
					"to an effect from one of your cards, this unit gets [Power]+3000 until end of turn.\".";
		}
		else if(id == CardIdentifier.CERTAIN_KILL_ERADICATOR__OUEI)
		{
			desc += "[AUTO](RC):[Put this unit into your soul] When your grade 3 \"Narukami\" is placed on (VC), you may pay the cost. " +
					"If you do, choose one of your opponent's rear-guards in the front row, and retire it.";
		}
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_UMBRELLA__SUKEROKKU)
		{
			desc += "[ACT](RC):[Soul Blast (1)] If you have a \"Murakumo\" vanguard, choose one of your open (RC), and move this unit. (The state of the card does not change)";
		}
		else if(id == CardIdentifier.TENDER_PIGEON)
		{
			desc += "[AUTO]:When this unit is placed on (RC), choose another of your \"Angel Feather\", and that unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.ANESTHESIA_CELESTIAL__RUMAEL)
		{
			desc += "[CONT](VC/RC):During your turn, this unit gets [Power]+2000 for each card named \"Operation Celestial, " +
					"Armen\" face up in your damage zone.";
		}
		else if(id == CardIdentifier.TEMPEST_STEALTH_ROGUE_FUUKI)
		{
			desc += "[ACT](RC):[Counter Blast (1) and Put this unit into your soul] If you have a «Nubatama» vanguard, and if " +
					"the number of cards in your opponent's hand is three or more, you may pay the cost. If you do, choose a card" +
					"at random from your opponent's hand, bind it face down, and at the end of that turn, your opponent puts that " +
					"card into his or her hand.";
		}
		else if(id == CardIdentifier.FESTIVE_STEALTH_ROGUE_SHUTENMARU)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):[Put this unit into your soul] When an attack hits a vanguard during the battle that this " +
					"unit boosted a «Nubatama» with Limit Break 4, you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.SHURA_STEALTH_DRAGON__KABUKICONGO)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1)] " +
					"When this unit attacks a vanguard, you may pay the cost. If you do, bind all of your opponent's rear-guards" +
					"face up, and if the number of cards in your opponent's bind zone is three or more, this unit gets [Power]+10000 " +
					"until end of that battle, and at the end of that turn, your opponent puts all those cards that were bound with " +
					"this effect into his or her hand.\n\n[ACT](VC):[Counter Blast (1)] This unit gets [Power]+2000 until end of turn.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.STEALTH_FIEND_MASHIROMOMEN)
		{
			desc += "[ACT](RC):[Put this unit into your soul] Choose up to one of your \"Nubatama\", and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.STEALTH_DRAGON_KODACHI_FUBUKI)
		{
			desc += "[ACT](VC/RC):[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.STEALTH_FIEND_MEZUOU)
		{
			desc += "[AUTO](RC):[Counter Blast (1)] When this unit boosts a \"Nubatama\" with Limit Break 4, you may pay the cost. If you do, the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.STEALTH_FIEND_GOZUOU)
		{
			desc += "[AUTO](VC/RC):When this unit attacks, if you have a \"Nubatama\" vanguard or rear-guard with Limit Break 4," +
					"this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.PENETRATE_CELESTIAL__GADRIEL)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):[Counter Blast (1) and Put this unit into soul] At the beginning of your ride phase, if you " +
					"have an \"Angel Feather\" vanguard, you may pay the cost. If you do, put the top card of your deck into " +
					"your damage zone, and at the end of that turn, choose a card from your damage zone, return it to your deck," +
					"and shuffle your deck.";
		}
		else if(id == CardIdentifier.TWINKLEKNIFE_ANGEL)
		{
			desc += "[ACT](VC/RC):[Counter Blast (2)] This unit gets [Power]+4000 until end of turn.";
		}
		else if(id == CardIdentifier.DRESSING_BARRAGE__SAHARIEL)
		{
			desc += "[AUTO](VC/RC):[Choose a card from your hand, and discard it] When this unit's attack hits, " +
					"if you have an \"Angel Feather\" vanguard, you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.WASHUP_RACCOON)
		{
			desc += "[AUTO]:[Counter Blast (1) and Choose three grade 1 or greater «Great Nature» not named \"Washup Raccoon\"" +
					"from your drop zone, and put them on top of your deck] During your end phase, when this unit is put into drop " +
					"zone from (RC), if you have a «Great Nature» vanguard, you may pay the cost. If you do, search your deck for up " +
					"to one card named \"Washup Raccoon\", reveal it to your opponent, put it into your hand, and shuffle your deck.";
		}
		else if(id == CardIdentifier.BUBBLE_EDGE_DRACOKID)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Put this unit into your soul] If you have an «Aqua Force» vanguard, choose one of your \"Aqua Force\"," +
					"and that unit gets \"[AUTO](VC/RC): When this unit attacks a vanguard, if it is the fourth battle of that turn or " +
					"more, draw a card.\" until end of turn.";
		}
		else if(id == CardIdentifier.ABACUS_BEAR)
		{
			desc += "[AUTO](VC):When this unit's drive check reveals a grade 3 «Great Nature», choose two of your \"Great Nature\" rear-guards, " +
					"and you may have those units get [Power]+4000 until end of turn. If you do, at the end of that turn, retire those units.";
		}
		else if(id == CardIdentifier.WHEEL_ASSAULT)
		{
			desc += "[AUTO](RC):[Counter Blast (1)] At the end of the battle this unit boosted, if you have an " +
					"\"Aqua Force\" vanguard, you may pay the cost. If you do, choose two of your \"Aqua Force\" " +
					"rear-guards, and exchange their positions. (The state of the cards does not change.)";
		}
		else if(id == CardIdentifier.DEMONIC_SEAS_NECROMANCER__BARBAROS)
		{
			desc += "[AUTO](VC):[Choose one of your grade 3 or greater «Granblue» rear-guards, and retire it] When " +
					"this unit's drive check reveals a grade 3 «Granblue», you may pay the cost. If you do, choose one \"Granblue\"" +
					"from your drop zone, and call it to an open (RC).\n\n" +
					"[CONT]:During your turn, if the number of «Granblue» rear-guards you have is four or more, this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.TIDAL_ASSAULT)
		{
			desc += "[AUTO](RC): At the end of the battle that this unit attacked a vanguard, if you have an \"Aqua Force\" vanguard, " +
					"[Stand] this unit, and this unit gets [Power]-5000 until end of turn. This ability cannot be used for the rest of that turn.";
		}
		else if(id == CardIdentifier.SEA_STROLLING_BANSHEE)
		{
			desc += "[AUTO]:[Soul Blast (1)] When this unit is placed on (RC) from your drop zone, if you have a «Granblue» vanguard, " +
					"you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.EARNEST_STAR_VADER__SELENIUM)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):When an opponent's rear-guard is locked by your effects from cards, if you have a \"Link Joker\"" +
					"vanguard, you may return this card to your hand.";
		}
		else if(id == CardIdentifier.PARADISE_ELK)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits, if you have a \"Link Joker\" vanguard, " +
					"you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_ENTROPY)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):When this unit " +
					"attacks a vanguard, this unit gets [Power]+5000 until end of that battle.\n\n" +
					"[AUTO]:[Counter Blast (2)] When this unit is placed on (VC), you may pay the cost. If you do, " +
					"choose one of your opponent's rear-guards, and lock it. \n(The locked card is turned face down, " +
					"and cannot do anything. It turns face up at the end of the owner's turn.)";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIMAGNUM)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Put this card into the soul] Choose your «Dimension Police» vanguard, and that unit gets [Power]+4000 until end of turn.";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__GOCANNON)
		{
			desc += "[ACT](RC):[Put this card into your soul and Choose another of your rear-guards with \"Dimensional Robo\"" +
					"in its card name, and put it into your soul] Choose your vanguard with \"Daiyusha\" in its card name, " +
					"and that unit gets [Critical]+1 until end of turn.";
		}
		else if(id == CardIdentifier.SPACE_DRAGON__DOGURUMADORA)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):When this " +
					"unit attacks a vanguard, this unit gets [Power]+5000 until end of that battle.\n\n" +
					"[AUTO](RC):When this unit attacks a vanguard, if you have a «Dimension Police» vanguard, this " +
					"unit gets [Power]+2000 until end of the battle.";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIHEART)
		{
			desc += "[AUTO](VC):At the beginning of your attack step, if this unit's [Power] is 13000 or greater," +
					"this unit gets \"[AUTO](VC):[Choose two grade 3 cards with \"Dimensional Robo\" in its card name " +
					"from your hand, and put them into your soul] When this unit's attack hits a vanguard, you may pay " +
					"the cost. If you do so, search your deck for up to one grade 3 card with \"Dimensional Robo\" in its" +
					"card name, ride it as [Rest], and shuffle your deck.\" until end of that battle.";
		}
		else if(id == CardIdentifier.ENERGY_CHARGER)
		{
			desc += "[AUTO]:[Soul Blast (2)] When this unit is placed on (RC), if you have a «Nova Grappler» vanguard," +
					"you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST_KUROKO)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):[Soul Blast (1)] When an attack hits a vanguard during the battle that this unit boosted, " +
					"if you have a «Nubatama» vanguard, you may pay the cost. If you do, choose up to two cards in your " +
					"opponent's bind zone, and put them into the drop zone.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__MAX_BEAT)
		{
			desc += "[AUTO](RC):[Counter Blast (1)-card with \"Beast Deity\" in its card name] During your battle phase, when " +
					"this unit becomes [Stand], if you have a «Nova Grappler» vanguard you may pay the cost. If you do, choose " +
					"another of your «Nova Grappler» rear-guards, and [Stand] it.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST_TAMAHAGANE)
		{
			desc += "[AUTO]:When this unit is placed on (VC) or (RC), if you have a \"Nubatama\" vanguard, choose up" +
					"to one of your opponent's rear-guards, bind it face up, and at the end of that turn, your opponent puts " +
					"that card into his or her hand.";
		}
		else if(id == CardIdentifier.STEALTH_FIEND_DAIDARAHOUSHI)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):When this unit" +
					"attacks a vanguard, this unit gets [Power]+5000 until end of that battle.\n\n" +
					"[AUTO](RC):When this unit attacks a vanguard, if you have a «Nubatama» vanguard, this unit gets " +
					"[Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.NURSING_CELESTIAL__NARELLE)
		{
			desc += "[AUTO]:[Choose a card with \"Celestial\" in its card name from your hand, and put it into your damage zone] " +
					"When this unit is placed on (RC), if you have an «Angel Feather» vanguard, you may pay the cost. If you do, " +
					"choose a card from your damage zone, and put it into your hand.";
		}
		else if(id == CardIdentifier.OPERATION_CELESTIAL__ARMEN)
		{
			desc += "[CONT](VC/RC):During your turn, this unit gets [Power]+2000 for each card named \"Operation Celestial, Armen\"" +
					"face up in your damage zone.";
		}
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_DEMONIC_HAIR__GURENJISHI)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (1)] When this unit's attack hits a vanguard, if you have a \"Murakumo\" vanguard, and this" +
					"unit is boosted by a «Murakumo», you may pay the cost. If you do, search your deck for up to one card named \"Stealth Rogue of Demonic Hair, Gurenjishi\"" +
					", call it to (RC), and shuffle your deck, and at the end of that turn, put the unit called with this effect on the bottom of your deck.";
		}
		else if(id == CardIdentifier.HONORARY_PROFESSOR__CHATNOIR)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage):When a \"Great Nature\"" +
					"rides this unit, choose your vanguard, and until end of turn, that unit gets [Power]+10000 and " +
					"\"[AUTO](VC):When one of your «Great Nature» rear-guards attacks a vanguard, choose one of your \"Great Nature\"" +
					"rear-guards, that unit get [Power]+4000 until end of turn, and at the end of that turn, draw a card, and retire that unit.\".\n\n" +
					"[AUTO](VC):When this unit attacks a vanguard, this unit gets [Power]+2000 until end of that battle.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.INVESTIGATING_STEALTH_ROGUE__AMAKUSA)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):When this unit attacks a vanguard, this unit gets " +
					"[Power]+5000 until end of that battle.\n\n" +
					"[AUTO](RC):When this unit attacks a vanguard, if you have a \"Murakumo\" vanguard, this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT__SADIG)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):[Put this unit into your soul] When your opponent's rear-guard is put into the drop zone due to an effect " +
					"from one of your cards, if you have a «Kagerō» vanguard, you may pay the cost. If you do, your opponent chooses one of his or her rear-guards, and retires it.";
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT__AKRAM)
		{
			desc += "[AUTO](RC):[Soul Blast (1)] When this unit boosts a unit with \"Dauntless\" in its card name, you may pay the cost. If you do, the boosted unit gets [Power]+6000 until end of that battle.";
		}
		else if(id == CardIdentifier.DOMINATE_DRIVE_DRAGON)
		{
			desc += "[AUTO](RC):When this unit attacks, if you have a vanguard with \"Dauntless\" in its card name, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.VORPAL_CANNON_DRAGON)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):When this unit attacks a vanguard, this unit gets " +
					"[Power]+5000 until end of battle.\n\n" +
					"[AUTO]:[Counter Blast (2)] When this unit is placed on (VC), you may pay the cost. If you do, choose one of your opponent's grade 2 or less rear-guards, and retire it.";
		}
		else if(id == CardIdentifier.FIRE_GOD__AGNI)
		{
			desc += "[AUTO](VC):When this unit attacks a vanguard, if this unit's battle opponent's [Power] is 12000 or greater, this unit gets [Power]+10000 until " +
					"end of that battle.\n\n" +
					"[AUTO](RC):When this unit attacks a vanguard, if you have a «Kagerō» vanguard, this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.LORD_OF_THE_SEVEN_SEAS__NIGHTMIST)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage):When a \"Granblue\" " +
					"rides this unit, choose your vanguard, and that unit gets [Power]+10000 until end of turn, and choose " +
					"up to two «Granblue» from your drop zone, call them to (RC), and the units called with this effect get " +
					"[Power]+5000 until end of turn, and at the end of that turn, retire those units.\n\n" +
					"[CONT](VC):During your turn, if the number of «Granblue» rear-guards you have is four or more, this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__AMENOHOAKARI)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):When this unit boosts a grade 3 «Genesis», you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.SCHOOL_PUNISHER__LEO_PALD______REVERSE_____)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Choose one of your «Great Nature» rear-guards, " +
					"and lock it] Choose up to two of your «Great Nature» rear-guards, those units get [Power]+4000 and \"[AUTO](RC):At the end of your turn, " +
					"retire this unit.\" and \"[AUTO]:During your end phase, when this unit is put into the drop zone from (RC), call this card to an open (RC).\" " +
					"until end of turn.\n" +
					"(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's turn)\n\n" +
					"[CONT](VC):If you have a card named \"School Hunter, Leo-pald\" in your soul, this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.KNIGHT_OF_SCORCHING_SCALES__ELIWOOD)
		{
			desc += "[AUTO](RC):[Counter Blast (1)] When your grade 3 unit with \"Ezel\" in its card name is placed on (VC), you may pay the cost. If you do, look at" +
					"the top card of your deck, search for up to one \"Gold Paladin\", call it to an open (RC), and put the rest on the bottom of your deck.";
		}
		else if(id == CardIdentifier.BLUE_SKY_LIBERATOR__HENGIST)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits, if you have a \"Gold Paladin\" vanguard, you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.TREASURE_LIBERATOR__CALOGRENANT)
		{
			desc += "[AUTO](VC):[Counter Blast (1)] When this unit's drive check reveals a grade 3 \"Gold Paladin\", you may pay the cost. If you do, look at the top " +
					"card of your deck, search for up to one «Gold Paladin», call it to an open (RC), and put the rest on the bottom of your deck.\n\n" +
					"[AUTO](VC):When this unit attacks a vanguard, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SANCTUARY_OF_LIGHT__PLANET_LANCER)
		{
			desc += "[AUTO]:When a card named \"Sanctuary of Light, Little Storm\" rides this unit, look at up to seven cards from the top of your deck, search for up to " +
					"one card named \"Sanctuary of Light, Determinator\" or \"Sanctuary of Light, Planetal Dragon\" from among them, reveal it to your opponent, put it into your" +
					"hand, and shuffle your deck.\n\n" +
					"[AUTO]:When a «Royal Paladin» not named \"Sanctuary of Light, Little Storm\" rides this unit, you may call this card to (RC).";
		}
		else if(id == CardIdentifier.SANCTUARY_OF_LIGHT__DETERMINATOR)
		{
			desc += "[CONT](VC):If you have a card named \"Sanctuary of Light, Little Storm\" in your soul, this unit gets [Power]+1000.\n\n" +
					"[AUTO]:When this unit rides a card named \"Sanctuary of Light, Little Storm\", if you have a card named \"Sanctuary of Light, Planet Lancer\"" +
					"in your soul, search your deck for up to one card with \"Sanctuary of Light\" in its card name, call it to (RC), and shuffle your deck.";
		}
		else if(id == CardIdentifier.LINKING_JEWEL_KNIGHT__TILDA)
		{
			desc += "[AUTO](RC):[Counter Blast (1)] When your grade 3 unit with \"Jewel Knight\" in its card name is placed on (VC), you may pay the cost. If you do," +
					"search your deck for up to one grade 1 or less «Royal Paladin», call it to (RC), and shuffle your deck.";
		}
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__HYAKKI_VOGUE______REVERSE_____)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Choose two of your \"Murakumo\" rear-guards, and lock them]" +
					"Choose up to three of your units named \"Covert Demonic Dragon, Hyakki Vogue \"Reverse\"\", and those units get [Power]+10000 until end of turn.\n" +
					"(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's turn.)\n\n" +
					"[AUTO](VC):[Counter Blast (2)] When this unit is placed on (VC), you may pay the cost. If you do, search your deck for up to one card named " +
					"\n\"Covert Demonic Dragon, Hyakki Vogue \"Reverse\"\", call it to (RC), and shuffle your deck, and at the end of that turn, return the unit called with" +
					"this effect to your hand.\n\n[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.RED_ROSE_MUSKETEER__ANTONIO)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with \"[CONT]: Sentinel\" in a deck)\n\n" +
					"[AUTO]:[Choose a \"Neo Nectar\" from your hand, and discard it] When this unit is placed on (GC), you may pay the cost. If you do, choose one of your " +
					"\"Neo Nectar\" that is being attacked, and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.LORD_OF_THE_DEEP_FORESTS__MASTER_WISTERIA)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1)] When a «Neo Nectar» rides this unit, you may pay the cost. " +
					"If you do, choose up to two of your «Neo Nectar» rear-guards, search your deck for up to one card with the same name as each of those units, call them to separate" +
					"(RC), shuffle your deck, and choose your vanguard, and that unit gets [Power]+10000 until end of turn.\n\n" +
					"[AUTO](VC):When this unit is boosted by a «Neo Nectar», this unit gets [Power]+2000 until end of that battle.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.MAIDEN_OF_VENUS_TRAP______REVERSE_____)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1) and Choose one of your \"Neo Nectar\" rear-guards, and lock it] " +
					"Look at up to five cards from the top of your deck, search for up to one \"Neo Nectar\", call it to (RC), and shuffle your deck, and that unit gets [Power]+5000 until" +
					"end of turn.\n" +
					"(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's turn.)\n\n" +
					"[ACT](VC):[Counter Blast (1)] This unit gets [Power]+2000 until end of turn.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.ERADICATOR__LORENTZ_FORCE_DRAGON)
		{
			desc += "[AUTO](RC):[Counter Blast(1)] When your grade 3 unit with \"Eradicator\" in its card name is placed on (VC), you may pay the cost. If you do, your " +
					"opponent chooses one of his or her rear-guards, and retires it.";
		}
		else if(id == CardIdentifier.SILVER_COLLAR_SNOWSTORM__SASAME)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with \"[CONT]: Sentinel\" in a deck)\n\n" +
					"[AUTO]:[Counter Blast (1)] When this is placed on (GC) from your hand, if you have a \"Murakumo\" vanguard, you may pay the cost. If you do, reveal the " +
					"five cards from the top of your deck, call all \"Murakumo\" from among them to (GC) as [Rest], and put the rest into the drop zone.";
		}
		else if(id == CardIdentifier.SUNLIGHT_GODDESS__YATAGARASU)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):[Soul Blast(9)] When this unit attacks a vanguard, " +
					"you may pay the cost. If you do, draw two cards, and choose up to two of your \"Genesis\" rear-guards, and [Stand] them.\n\n" +
					"[AUTO](VC): During a battle that this unit is attacked, when your \"Genesis\" guardian is put into the drop zone, put that card into " +
					"your soul. This ability cannot be used for the rest of that battle. (If two cards or more are put into the drop zone at the same time, " +
					"you may only put one of them into the soul)\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__KAGURABLOOM)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1)] When a \"Murakumo\" rides this unit, " +
					"you may pay the cost. If you do, choose your vanguard, that unit gets [Power]+10000 until end of turn, and search your deck for up to two " +
					"cards with the same name as that unit, call them to separate (RC), shuffle your deck, and at the end of that turn, return the units called with" +
					"this effect to your hand.\n\n" +
					"[AUTO](VC):When this unit is boosted by a \"Murakumo\", this unit gets [Power]+2000 until end of that battle.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.SWORD_FORMATION_LIBERATOR__IGRAINE)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with \"[CONT]: Sentinel\" in a deck)\n\n" +
					"[AUTO]:[Counter Blast (1)] When this is placed on (GC) from your hand, if you have a \"Gold Paladin\"" +
					"vanguard, you may pay the cost. If you do, reveal the five cards from the top of your deck, call all \"Gold Paladin\"" +
					"from among them to (GC) as [Rest], and put the rest into the drop zone.";
		}
		else if(id == CardIdentifier.GODDESS_OF_THE_SHIELD__AEGIS)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with \"[CONT]: Sentinel\" in a deck)\n\n" +
					"[AUTO]:[Counter Blast (1)] When this is placed on (GC) from your hand, if you have a \"Genesis\"" +
					"vanguard, you may pay the cost. If you do, reveal the five cards from the top of your deck, call all \"Genesis\"" +
					"from among them to (GC) as [Rest], and put the rest into the drop zone.";
		}
		else if(id == CardIdentifier.SUMMONING_JEWEL_KNIGHT__GLORIA)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with \"[CONT]: Sentinel\" in a deck)\n\n" +
					"[AUTO]:[Counter Blast (1)] When this is placed on (GC) from your hand, if you have a \"Royal Paladin\"" +
					"vanguard, you may pay the cost. If you do, reveal the five cards from the top of your deck, call all \"Royal Paladin\"" +
					"from among them to (GC) as [Rest], and put the rest into the drop zone.";
		}
		else if(id == CardIdentifier.BANDING_JEWEL_KNIGHT__MIRANDA)
		{
			desc += "[AUTO](RC):When this unit attacks, if you have a vanguard with \"Ashlei\" in its card name, this unit gets [Power]+2000 until end of that battle.\n\n" +
					"[AUTO](RC):When this unit's attack hits a vanguard, if you have a vanguard with \"Ashlei\" in its card name, choose one of your \"Royal Paladin\", " +
					"and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.SANCTUARY_OF_LIGHT__PLANETAL_DRAGON)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):When this unit attacks a vanguard, all of your units " +
					"with \"Sanctuary of Light\" in its card name get [Power]+3000 until end of turn.\n\n" +
					"[AUTO]:[Counter Blast (2)] When this unit is placed on (VC), you may pay the cost. If you do, search your deck for up to one card with " +
					"\"Sanctuary of Light\" in its card name, call it to (RC), and shuffle your deck.\n\n" +
					"[CONT](VC):If you have a card named \"Sanctuary of Light, Determinator\" in your soul, this unit gets [Power]+1000.";
		}
		else if(id == CardIdentifier.ERADICATOR__TEMPEST_BOLT_DRAGON)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (3)-card with \"Eradicator\" in its card name]" +
					"Retire all of each fighter's rear-guards.\n\n" +
					"[CONT](VC):During your turn, this unit gets [Power]+2000 for each fighter's open (RC).\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.ERADICATOR__IGNITION_DRAGON)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1)] When a \"Narukami\" rides this unit, " +
					"you may pay the cost. If you do, your opponent chooses two of his or her rear-guards, and retires them, and choose your vanguard, and that" +
					"unit gets [Power]+10000 until end of turn.\n\n" +
					"[AUTO](VC):When this unit attacks, if the number of rear-guards you have is more than your opponent's, this unit gets [Power]+2000 until end of that battle.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.COBALT_WAVE_DRAGON)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):When one of your rear-guards attacks a vanguard, " +
					"if it is the third battle of that turn or more, this unit gets [Power]+2000/[Critical]+1 until end of turn.\n\n" +
					"[AUTO](VC):When this unit attacks a vanguard, if it is the fourth battle of that turn or more, this unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.DAUNTLESS_DOMINATE_DRAGON______REVERSE_____)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast(1) and Choose one of your \"Kagero\" rear-guards, and lock it]" +
					"Until end of turn, this unit gets \"[AUTO](VC): When this unit's drive check reveals a grade 1 or greater \"Kagero\", choose up to one of your opponent's grade" +
					"1 or less rear-guards, retire it, and this unit gets [Power]+3000 until end of turn.\". This ability cannot be used for the rest of turn.\n" +
					"(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's turn.)\n\n" +
					"[CONT](VC): If you have a card named \"Dauntless Drive Dragon\" in your soul, this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.SALVATION_LION__GRAND_EZEL_SCISSORS)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (2) and Soul Blast (2)] Unlock all of your locked cards, " +
					"and if you have five «Gold Paladin» rear-guards, this unit gets [Power]+10000/[Critical]+1 until end of turn, and at the end of that turn, Soul Charge (1), " +
					"choose a card from your damage zone, and turn it face up.\n\n" +
					"[CONT](VC):During your turn, this unit gets [Power]+1000 for each of your «Gold Paladin» rear-guards.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.OMNISCIENCE_REGALIA__MINERVA)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1) & Soul Blast (3) & Choose three «Genesis» from your hand, " +
					"and discard them] At the end of the battle that this unit attacked, you may pay the cost. If you do, [Stand] this unit, and this unit gets [Power]+5000 until end" +
					"of turn. This ability cannot be used for the rest of that turn.\n\n" +
					"[CONT](VC):If you have a card named \"Regalia of Wisdom, Angelica\" in your soul, this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.ICE_PRISON_HADES_EMPEROR__COCYTUS______REVERSE_____)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Put three " +
					"cards from the top of your deck into your drop zone & Choose one of your \"Granblue\" rear-guards, " +
					"and lock it] Choose one «Granblue» from your drop zone, call it to (RC), and that unit gets " +
					"[Power]+3000 until end of turn.\n" +
					"(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's turn)\n\n" +
					"[CONT](VC):If you have a card named \"Ice Prison Necromancer, Cocytus\" in your soul, this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.STAR_VADER__COLONY_MAKER)
		{
			desc += "[AUTO]:[Counter Blast (1)] When this unit is placed on (RC), if you have a \"Link Joker\" vanguard, and if your opponent has a locked card, you may pay the cost. " +
					"If you do, search your deck for up to one grade 1 or less card with \"Star-vader\" in its card name, call it to (RC), and shuffle your deck.";
		}
		else if(id == CardIdentifier.LIBERATOR_OF_BONDS__GANCELOT_ZENITH)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1)-card with \"Liberator\" " +
					"in its card name and Choose one of your grade 2 or less rear-guards, and put it on the bottom of your deck] When this unit attacks" +
					"a vanguard, you may pay the cost. If you do, look at the top card of your deck, search for up to one «Gold Paladin», call it to an " +
					"open (RC), and put the rest on the bottom of your deck, and that unit gets [Power]+10000 until end of turn.\n\n" +
					"[CONT](VC):If you have a card named \"Solitary Liberator, Gancelot\" in your soul, this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.BROKEN_HEART_JEWEL_KNIGHT__ASHLEI________EVERSE_____)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1) and Choose one of your " +
					"rear-guards with \"Jewel Knight\" in its card name, and lock it] Choose up to one of your opponent's rear-guards in the front " +
					"row, and retire it, and search your deck for up to one card with \"Jewel Knight\" in its card name, call it to (RC), and shuffle " +
					"your deck. This ability cannot be used for the rest of that turn.\n(The locked card is turned face down, and cannot do anything. " +
					"It turns face up at the end of the owner's turn.)\n\n" +
					"[CONT](VC):If you have a card named \"Pure Heart Jewel Knight, Ashlei\" in your soul, this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.TELESCOPE_RABBIT)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Counter Blast (1) and [Rest] this unit] Choose one of your «Great Nature» rear-guards, " +
					"that unit gets [Power]+4000 until end of turn, and at the end of that turn, retire that unit.";
		}
		else if(id == CardIdentifier.WHISTLE_HYENA)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (1)-\"Great Nature\"] When this unit attacks, if you have a \"Great Nature\" vanguard, " +
					"you may pay the cost. If you do, this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.COSMIC_CHEETAH)
		{
			desc += "[AUTO](VC/RC):When this unit attacks, if the number of cards in your hand is less than your opponent's, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BATTLE_SIREN__MARIKA)
		{
			desc += "[ACT](RC):[Put this unit into your soul] Choose up to one of your \"Aqua Force\", and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.APPRENTICE_GUNNER__SOLON)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Put this unit into your soul and Choose a card from your hand, and discard it] If you have an \"Aqua Force\" vanguard, draw a card.";
		}
		else if(id == CardIdentifier.PATROL_SWIMMING_SEAL_SOLDIER)
		{
			desc += "[ACT](RC):[Rest this unit] Choose another of your «Aqua Force», and that unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.STRONGEST_BEAST_DEITY__ETHICS_BUSTER_EXTREME)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):When this unit's" +
					"drive check reveals a grade 1 or greater card with \"Beast Deity\" in its card name, choose one of your " +
					"\"Nova Grappler\" rear-guards, and [Stand] it.\n\n" +
					"[CONT](VC):If you have a card named \"Beast Deity, Ethics Buster\" in your soul, this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.HEAVY_RUSH_DRAGON)
		{
			desc += "[AUTO](VC/RC):When this unit attacks, if you have an \"Aqua Force\" vanguard, and if it is the second battle of that turn, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SHALLOWS_SWEEPER)
		{
			desc += "[AUTO](RC):[Choose a card from your hand, and discard it] When this unit boosts a \"Aqua Force\", " +
					"if you have an «Aqua Force» vanguard, and if it is the fourth battle of that turn or more, you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.PRISON_GATE_STAR_VADER__PALLADIUM)
		{
			desc += "[AUTO](RC):[Counter Blast (1) and Put this unit into your soul] During your opponent's end phase, when an opponent's " +
					"locked card is unlocked, if you have a «Link Joker» vanguard, you may pay the cost. If you do, lock that unit.\n" +
					"(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's next turn.)";
		}
		else if(id == CardIdentifier.OCEAN_CURRENT_RESCUING_TURTLE_SOLDIER)
		{
			desc += "[AUTO]:When this unit is placed on (VC) or (RC), reveal the top card of your deck. If the revealed card is a grade 1" +
					"or 2 \"Aqua Force\", call it to (RC), and if it is not, shuffle your deck.";
		}
		else if(id == CardIdentifier.DEUTERIUMGUN_DRAGON)
		{
			desc += "[AUTO](VC/RC):When this unit attacks, if you have an \"Aqua Force\" vanguard, and if it is the second battle of that turn, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DESTRUCTION_STAR_VADER__TUNGSTEN)
		{
			desc += "[AUTO](RC):When this unit attacks a vanguard, if your opponent has a locked card, this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.ABYSSAL_SNIPER)
		{
			desc += "[AUTO](VC/RC):When this unit attacks, if the number of rear-guards you have is more than your opponent's, this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BATTLE_SIREN__CALLISTA)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (1)] When this unit's attack hits a vanguard, if you have an \"Aqua Force\" vanguard, and if it is the fourth " +
					"battle of that turn or more, you may pay the cost. If you do, choose another of your «Aqua Force» rear-guards, [Stand] it, and that unit gets" +
					"[Power]+5000 until end of turn.";
		}
		else if(id == CardIdentifier.PETER_THE_GHOSTIE)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Counter Blast (1) and Put two cards from the top of your deck into your drop zone & Put this " +
					"unit into your soul] If you have a «Granblue» vanguard, draw a card.";
		}
		else if(id == CardIdentifier.MARINE_GENERAL_OF_RAGING_CURRENT__MELTHOS)
		{
			desc += "[AUTO](VC/RC):When this unit attacks a vanguard, if you have an «Aqua Force» vanguard, this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.DISCERNING_EYE__SKY_TROOPER)
		{
			desc += "[AUTO](VC):When this unit's drive check reveals a grade 3 «Aqua Force», choose one of your rear-guards, and [Stand] it.";
		}
		else if(id == CardIdentifier.STAR_VADER__CHAOS_BEAT_DRAGON)
		{
			desc += "[AUTO](RC):When this unit boosts a unit named \"Star-vader, Chaos Breaker Dragon\", if your opponent has a locked card, the boosted unit " +
					"gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.CORROSION_DRAGON__CORRUPT_DRAGON)
		{
			desc += "[AUTO]:When this unit is placed on (RC) from your drop zone, if you have a «Granblue» vanguard, this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.BLACK_RING_CHAIN__PLEIADES)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[ACT](RC):[Counter Blast (1) and Put this unit into your soul] Look at up to five cards from the top of your deck, " +
					"search for up to one grade 3 or greater «Link Joker» from among them, reveal it to your opponent, put it into your" +
					"hand, and shuffle your deck.";
		}
		else if(id == CardIdentifier.ASTEROID_BELT__LADY_GUNNER)
		{
			desc += "[AUTO](RC):[Choose a card from your hand, and discard it] When an attack hits during the battle that this unit boosted," +
					"you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.HYPNOSIS_MONSTER__NECRORY)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit " +
					"boosted a \"Dimension Police\" with Limit Break 4, you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.SUPERMASSIVE_STAR__LADY_GUNNER)
		{
			desc += "[AUTO](VC/RC):When this unit is boosted by a \"Link Joker\", this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__DESERT_GATOR)
		{
			desc += "[AUTO](RC):When this unit attacks, if you have a vanguard with \"Beast Deity\" in its card name, this unit gets " +
					"[Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BEAM_MONSTER__RAYDRAM)
		{
			desc += "[AUTO](RC):[Counter Blast(1)] When this unit boosts a \"Dimension Police\" that has Limit Break 4, you may pay the cost." +
					"If you do, the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ANALYTIC_MONSTER__GIGABOLT)
		{
			desc += "[AUTO](RC):When this unit attacks a vanguard, if the battle opponent's [Power] is 8000 or less, this unit " +
					"gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ELECTRIC_MONSTER__WHIPPLE)
		{
			desc += "[AUTO](VC/RC):When this unit attacks, if you have a «Dimension Police» vanguard or rear-guard with Limit Break 4, " +
					"this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.COMBINED_MONSTER__BUGLEED)
		{
			desc += "[AUTO](VC/RC): When this unit attacks a vanguard, if you have a «Dimension Police» vanguard, and if the battle " +
					"opponent's [Power] is 8000 or less, this unit gets \"[AUTO](VC/RC):When this unit's attack hits, draw a card.\" " +
					"until end of that battle.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__NIGHT_JACKAL)
		{
			desc += "[AUTO]: Forerunner (When a unit of the same clan rides this unit, you may call this unit to (RC))\n\n" +
					"[AUTO](RC):During your battle phase, when this unit becomes [Stand], this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.DEATH_ARMY_COMMANDER)
		{
			desc += "[AUTO](RC):When your vanguard's drive check reveals a grade 3 \"Nova Grappler\", [Stand] this unit.";
		}
		else if(id == CardIdentifier.GATLING_RAIZER)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (1)-\"Nova Grappler\"] When this unit attacks, if you have a \"Nova Grappler\" vanguard, " +
					"you may pay the cost. If you do, this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.STEALTH_DRAGON_KOKUJOU)
		{
			desc += "[AUTO](RC):During your turn, when an opponent’s card is put into the bind zone, if you have a \"Nubatama\" vanguard, " +
					"this unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.STAR_VADER__CHAOS_BREAKER_DRAGON)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):[Soul Blast (1)-card with " +
					"\"Star-vader\" in its card name] During your opponent's end phase, when an opponent's locked card is unlocked," +
					"you may pay the cost. If you do, retire that unit, and draw a card.\n\n" +
					"[ACT](VC):[Counter Blast (1) & Choose a card with \"Star-vader\" in its card name from your hand, and discard it]" +
					"Choose one of your opponent's rear-guards, and lock it. This ability cannot be used for the rest of that turn.\n" +
					"(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's turn)\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.ORIGINAL_SAVER__ZERO)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage):When a «Dimension Police» rides this unit, " +
					"choose your vanguard, and that unit gets [Power]+10000 until end of turn, and choose one of your opponent's vanguard, and" +
					"that unit gets [Power]-5000 until end of turn.\n\n" +
					"[AUTO](VC):When this unit is boosted by a «Dimension Police», this unit gets [Power]+2000 until end of that battle.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.DARK_DIMENSIONAL_ROBO_______REVERSE______DAIYUSHA)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Counter Blast (1) & Choose two of " +
					"your rear-guards with \"Dimensional Robo\" in its card name, and lock them] Choose one of your opponent's vanguard, and " +
					"that unit gets [Power]-10000 until end of turn. This ability cannot be used for the rest of that turn.\n" +
					"(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's turn)\n\n" +
					"[CONT](VC):If you have a card named \"Super Dimensional Robo, Daiyusha\" in your soul, this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.CLEANUP_CELESTIAL__RAMIEL______REVERSE_____)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):[Choose two of your rear-guards with \"Celestial\" " +
					"in its card name, and lock them] Choose up to three of your units with \"Celestial\" in its card name in the front row, those units " +
					"get [Power]+5000 until end of turn, and if you have a face up card named \"Cleanup Celestial, Ramiel \"Reverse\"\" in your damage zone," +
					"choose one card from your opponent's damage zone, put it into the drop zone, and your opponent chooses one of his or her rear-guards, " +
					"and puts it into the damage zone. \n(The locked card is turned face down, and cannot do anything. It turns face up at the end of the owner's turn)\n\n" +
					"[CONT](VC):If you have a card named \"Prophecy Celestial, Ramiel\" in your soul, this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.SHURA_STEALTH_DRAGON__KUJIKIRICONGO)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage):When a «Nubatama» rides this unit, choose your vanguard, and that unit" +
					"gets [Power]+10000 until end of turn, and your opponent chooses a card from his or her hand, discards it, and chooses a card from his or her hand, binds " +
					"it face down, and at the end of that turn, your opponent puts the card that was bound with this effect into his or her hand.\n\n" +
					"[AUTO](VC):When this unit attacks, if the number of cards in your opponent's hand is three or less, this unit gets [Power]+2000 until end of that battle\n\n" +
					"[CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)";
		}
		else if(id == CardIdentifier.SOUL_GUIDING_ELF)
		{
			desc += "[ACT](VC/RC):[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.WINGED_DRAGON_SKYPTERO)
		{
			desc += "[AUTO](RC): [Counter Blast (1)] When this unit is put into the drop zone from (RC), if you have a " +
					"Tachikaze vanguard, you may pay the cost. If you do, return this card to your hand.";
		}
		else if(id == CardIdentifier.CRIMSON_WITCH__RADISH)
		{
			desc += "[AUTO](VC/RC)[Counter Blast (2)] When this unit attacks if you have a Genesis vanguard you may pay the cost. " +
					"If you do this unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.DRAGON_UNDEAD__SKULL_DRAGON)
		{
			desc += "[AUTO](RC)When this unit attacks if you have a Granblue vanguard this unit gets [Power]+3000 until" +
					"end of that battle and at the beginning of the end phase of that turn retire this unit.\n\n" +
					"[ACT](Drop zone)[Counter Blast (1) amp Choose one of your grade 2 or greater Granblue rear-guards and " +
					"retire it] If you have a Granblue vanguard call this card to (RC).";
		}
		else if(id == CardIdentifier.ERADICATOR__SPARK_HORN_DRAGON)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks " +
					"a vanguard this unit gets [Power]+5000 until end of that battle.\n\n" +
					"[AUTO](VC)[Counter Blast (1)-card with 'Eradicator' in its card name] When this units attack hits a vanguard you " +
					"may pay the cost. If you do your opponent chooses one of his or her rear-guards and retires it.";
		}
		else if(id == CardIdentifier.STAMP_SEA_OTTER)
		{
			desc += "[CONT](RC)If you have a Great Nature vanguard this unit cannot be retired by effects from cards.";
		}
		else if(id == CardIdentifier.NO_LIFE_KING__DEATH_ANCHOR)
		{
			desc += "[CONT](VC)If the number of Dark Irregulars in your soul is eight or more this unit gets [Power]+1000.\n\n" +
					"[AUTO](VC)At the beginning of your main phase Soul Charge (1) and this unit gets [Power]+2000 until end of turn.\n\n" +
					"[AUTO](VC)[Choose five face up Dark Irregulars from your damage zone and put them into your soul] When this unit attacks " +
					"you may pay the cost. If you do this unit gets [Power]+10000/[Critical]+1 until end of turn and at the beginning of the end " +
					"phase of that turn put five cards from the top of your deck into your damage zone.";
		}
		else if(id == CardIdentifier.FLIRTATIOUS_SUCCUBUS)
		{
			desc += "[AUTO]When this unit is placed on (VC) or (RC) if you have a Dark Irregulars vanguard you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.SANCTUARY_GUARD_DRAGON)
		{
			desc += "[CONT](VC) Limit Break 4 (This ability is active if you have four or more damage)During your turn this unit gets [Power]+3000 " +
					"for each of your grade 1 or less Royal Paladin rear-guards.\n\n" +
					"[AUTO][Choose a Royal Paladin from your hand and discard it] When this unit placed on (VC) you may pay the cost. If you do " +
					"search your deck for up to one grade 1 or less Royal Paladin call it to (RC) and shuffle your deck.\n\n" +
					"[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.BATTLE_FLAG_KNIGHT__CONSTANCE)
		{
			desc += "[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits a vanguard if you have a Royal Paladin vanguard you may pay " +
					"the cost. If you do search your deck up to one grade 1 or less Royal Paladin call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.PATHETIC_JEWEL_KNIGHT__OLWEN)
		{
			desc += "[AUTO](VC/RC) When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets " +
					"[Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.REGRET_JEWEL_KNIGHT__URIEN)
		{
			desc += "[ACT](VC/RC)[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.RENDGAL)
		{
			desc += "[AUTO]When this unit is placed on (RC) from your deck if you have a Royal Paladin vanguard this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.RAINBOW_CALLING_BARD)
		{
			desc += "[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit named 'Sanctuary Guard Dragon' you may pay the cost. If you do the boosted " +
					"unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.STARTING_LEGEND__AMBROSIUS)
		{
			desc += "[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n" +
					"[ACT](RC)[Put this unit into your soul and Choose a card from your hand and discard it] If you have a Royal Paladin vanguard draw a card.";
		}
		else if(id == CardIdentifier.REGALIA_OF_WISDOM__ANGELICA)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage)[Soul Blast (3)] When a Genesis rides this unit you may pay the " +
					"cost. If you do draw two cards and choose your vanguard and that unit gets [Power]+10000 until end of turn.\n\n" +
					"[AUTO](VC)When this unit attacks a vanguard Soul Charge (1) and this unit gets [Power]+1000 until end of that battle.\n\n" +
					"[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__MIZUHA)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Soul Blast (3)] When this unit attacks a vanguard you may pay " +
					"the cost. If you do this unit gets [Power]+5000/[Critical]+1 until end of that battle.\n\n" +
					"[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.GODDESS_OF_TREES__JUPITER)
		{
			desc += "[AUTO](RC)When this unit attacks if you have a vanguard with 'Regalia' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__SHITATERUHIME)
		{
			desc += "[AUTO] When this unit intercepts if you have a Genesis vanguard this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.EXISTENCE_ANGEL)
		{
			desc += "[AUTO](RC)When an attack hits a vanguard during the battle that this unit boosted a Genesis you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.APPLE_WITCH__CIDER)
		{
			desc += "[AUTO] When this unit is placed on (GC) from your hand choose your vanguard with 'Regalia' in its card name and until end of that battle " +
					"that unit gets '[AUTO](VC)When one of your Genesis guardian is put into the drop zone put that card into your soul.'.";
		}
		else if(id == CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE)
		{
			desc += "[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (3), Soul Blast (3) and Choose a card " +
					"named 'Transcendence Dragon Dragonic Nouvelle Vague' from your hand and discard it] Retire all of your opponents rear-guards.\n\n" +
				    "[CONT](VC)During your turn the effects of your opponents triggers are negated.\n\n" +
				    "[CONT](VC)During a battle that this unit attacks a vanguard your opponent cannot normal call grade 0 units to (GC) from his or her hand.\n\n" +
				    "[CONT](RC)This unit gets [Power]-1000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.CRUEL_DRAGON)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1) and Soul Blast (1)] When this " +
				    "unit attacks a vanguard you may pay the cost. If you do choose one of your opponents grade 2 or less rear-guards and retire it.\n\n" +
				    "[ACT](Hand)[Reveal this card, Choose your grade 2 or greater Kagero vanguard and [Rest] it] If you put an opponents rear-guard into " +
				    "the drop zone during the main phase of that turn ride this unit as [Stand] and choose your vanguard and that unit gets [Power]-3000 until end of turn.\n\n" +
				    "[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.BLAST_BULK_DRAGON)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1) and Choose a Kagero from your hand " +
					"and discard it] When this unit attacks a vanguard you may pay the cost. If you do this unit gets [Power]+5000/[Critical]+1 until end of that battle.\n\n" +
				    "[CONT](VC)During your turn if this units [Critical] is two or greater this unit gets [Power]+5000.\n\n" +
				    "[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.NOUVELLECRITIC_DRAGON)
		{
			desc +="[AUTO][Counter Blast(1) and Choose a card named 'Transcendence Dragon Dragonic Nouvelle Vague' from your hand and reveal it] When this unit is placed on (VC) or (RC) if you have a Kagero vanguard you may pay the cost. If you do choose one of your opponents rear-guards and retire it.";
		}
		else if(id == CardIdentifier.DRAGONIC_GAIAS)
		{
			desc +="[AUTO](RC)[Soul Blast (2) and [Rest] this unit] When your Kagero normal unit in the same column as this unit attacks you may pay the cost. If you do that unit gets [Critical]+1 until end of that battle.";
		}
		else if(id == CardIdentifier.ERADICATOR__VOWING_SWORD_DRAGON)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Narukami rides this unit choose one of your opponents rear-guards in the front row retire it and choose your vanguard and that unit gets [Power]+10000 until end of turn.\n\n" +
				   "[AUTO](VC)When this unit attacks if the number of cards in your opponents damage zone is three or more this unit gets [Power]+2000 until end of that battle.\n\n" +
				   "[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.BARRAGE_ERADICATOR__ZION)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DISCHARGING_DRAGON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n" +
				   "[AUTO](RC)When this unit attacks a vanguard if you have a Narukami vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.ERADICATOR__SPARK_RAIN_DRAGON)
		{
			desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'Eradicator' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ASSASSIN_SWORD_ERADICATOR__SUSEI)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits a vanguard if you have a vanguard with 'Eradicator' in its card name you may pay the cost. If you do choose one of your opponents rear-guards in the front row and retire it.";
		}
		else if(id == CardIdentifier.DRAGON_DANCER__VERONICA)
		{
			desc +="[AUTO]When this unit intercepts if you have a Narukami vanguard this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.LIGHTNING_BLADE_ERADICATOR__JEEM)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the number of rear-guards your opponent has is two or less this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ERADICATOR__DEMOLITION_DRAGON)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Eradicator' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DUST_STORM_ERADICATOR__TOKO)
		{
			desc +="[ACT](VC/RC)[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.ERADICATOR_OF_FIRE__KOHKAIJI)
		{
			desc +="[AUTO](RC)When this unit boosts a Narukami vanguard if the number of cards in your opponents damage zone is three or more the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.WORM_TOXIN_ERADICATOR__SEIOBO)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT__ASHGAR)
		{
			desc +="[AUTO](RC) When this unit boosts a unit named 'Transcendence Dragon Dragonic Nouvelle Vague' the boosted unit gets [Power]+3000 until end of battle.";
		}
		else if(id == CardIdentifier.ILLUSIONARY_REVENGER__MORDRED_PHANTOM)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1)] When a Shadow Paladin rides this unit you may pay the cost. If you do choose your vanguard that unit gets [Power]+10000 until end of turn search your deck for up to one grade 2 or less Shadow Paladin call it to (RC) shuffle your deck and that unit gets [Power]+5000 until end of turn.\n\n" +
				   "[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+2000 until end of that battle.\n\n" +
				   "[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.VENOMOUS_BREATH_DRAGON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage) When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n" +
				   "[AUTO](RC) When this unit attacks a vanguard if you have a Shadow Paladin vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.REVENGER_OF_LABYRINTH__ARAUN)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.NULLITY_REVENGER__MASQUERADE)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Revenger' in its card name this unit gets [Power]+3000 until end of battle.";
		}
		else if(id == CardIdentifier.BLASTER_DARK_REVENGER)
		{
			desc +="[AUTO][Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have a vanguard with 'Revenger' in its card name you may pay the cost. If you do choose one of your opponents rear-guards in the front row and retire it.";
		}
		else if(id == CardIdentifier.COILBAU_REVENGER)
		{
			desc +="[AUTO](VC/RC) When this unit attacks if the number of rear-guards you have is less than your opponents this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.REVENGER_FORTRESS__FATALITA)
		{
			desc +="[AUTO] When this unit intercepts if you have a Shadow Paladin vanguard this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.SACRILEGE_REVENGER__BERITH)
		{
			desc +="[ACT](VC/RC)[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.TRANSIENT_REVENGER__MASQUERADE)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Revenger' in its card name this unit gets [Power]+3000 until end of battle.";
		}
		else if(id == CardIdentifier.BURANBAU_REVENGER)
		{
			desc +="[AUTO](RC)When this unit boosts a Shadow Paladin vanguard if the number of rear-guards you have is less than your opponents the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.HEALING_REVENGER)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.NOUVELLEROMAN_DRAGON)
		{
			desc +="[AUTO][Choose a card named 'Transcendence Dragon Dragonic Nouvelle Vague' from your hand reveal it to your opponent and put it on top of your deck] When this card is placed on (VC) or (RC) if you have a Kager vanguard you may pay the cost. If you do search your deck for up to one grade 3 or greater Kager reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.GENIE_SOLDAT)
		{
			desc +="[CONT](VC/RC) Restraint (This unit cannot attack.)\n\n" +
				   "[AUTO](VC/RC)During your main phase when an opponents rear-guard is put into the drop zone this unit loses 'Restraint' until end of turn.\n\n" +
				   "[AUTO](VC)When this unit is boosted by a Kagero this unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__KONGARA)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the number of rear-guards your opponent has is two or less this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SCALE_DRAGON_OF_THE_MAGMA_CAVE)
		{
			desc +="[AUTO](VC/RC)[Soul Blast (1)] When this unit attacks if you have a Kagero vanguard you may pay the cost. If you do this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.INFINITE_CORROSION_FORM__DEATH_ARMY_COSMO_LORD)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2)] [Stand] all of your Nova Grappler rear-guards. If four or more units [Stand] this way this unit gets [Critical]+1 until end of turn. This ability cannot be used for the rest of that turn.\n\n" +
				   "[ACT](VC)[Choose two of your rear-guards with 'Death Army' in its card name and [Rest] them] This unit gets [Power]+5000 until end of turn.";
		}
		else if(id == CardIdentifier.STAR_VADER__INFINITE_ZERO_DRAGON)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Link Joker rides this unit choose one of your opponents rear-guards in the front row and back row lock them and choose your vanguard and that unit gets [Power]+10000 until end of turn.(The locked card is turned face down and cannot do anything. It turns face up at the end of the owners turn)\n\n[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+2000 until end of that battle.\n\n[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.RAID_STAR_VADER__FRANCIUM)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.TWILIGHT_BARON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage) When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO](RC) When this unit attacks a vanguard if you have a Link Joker vanguard this unit gets [Power]+2000 until end of the battle.";
		}
		else if(id == CardIdentifier.STAR_VADER__MOBIUS_BREATH_DRAGON)
		{
			desc +="[AUTO](VC) When this units attack hits a vanguard choose one of your opponents rear-guards and lock it.(The locked card is turned face down and cannot do anything. It turns face up at the end of the owners turn)";
		}
		else if(id == CardIdentifier.UNRIVALED_STAR_VADER__RADON)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Star-vader' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.STAR_VADER__PULSAR_BEAR)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets [Power] +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SWIFT_STAR_VADER__STRONTIUM)
		{
			desc +="[AUTO]When this unit intercepts if you have a Link Joker vanguard this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.PURSUIT_STAR_VADER__FERMIUM)
		{
			desc +="[ACT](VC/RC)[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.STAR_VADER__AURORA_EAGLE)
		{
			desc +="[AUTO](RC)When this unit boosts a Link Joker vanguard if the number of rear-guards you have is more than your opponents the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.STAR_VADER__STELLAR_GARAGE)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.DEMONIC_BULLET_STAR_VADER__NEON)
		{
			desc += "[AUTO](RC):When this unit attacks, if you have a vanguard with \"Star-vader\" in its card name, this unit gets [Power]+3000 until end of that battle.";	
		}
		else if(id == CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAIKAISER)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1)] When a Dimension Police rides this unit you may pay the cost. If you do choose your vanguard that unit gets [Power]+10000/[Critical]+1 and '[AUTO](VC)When this units drive check reveals a grade 3 Dimension Police choose one of your opponents guardians retire it and any effect with 'Cannot be hit' of that retired unit is negated.' until end of turn.\n\n" +
				    "[AUTO](VC)When this unit is boosted by a Dimension Police this unit gets [Power]+2000 until end of that battle.\n\n" +
				    "[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.ELECTRO_STAR_COMBINATION__COSMOGREAT)
		{
			desc += "[AUTO][Counter Blast (2)] When this unit is placed on (RC) you may pay the cost. If you do choose another of your Dimension Police and that unit gets [Power]+4000 until end of turn.";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__KAIZARD)
		{
			desc += "[AUTO]When a Dimension Police rides this unit choose your vanguard and that unit gets [Power]+5000 until end of turn.";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIDRILLER)
		{
			desc += "[AUTO][Counter Blast (1)] When this unit is placed on (RC) you may pay the cost. If you do choose another of your units with 'Dimensional Robo' in its card name and that unit gets [Power]+4000 until end of turn.";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAITIGER)
		{
			desc += "[AUTO](RC)When this unit attacks if you have a vanguard with 'Dimensional Robo' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIBRAVE)
		{
			desc += "[ACT](Soul)[Put this card into your drop zone] Choose up to one of your Dimension Police vanguard and that unit gets '[AUTO](VC)[Counter Blast (1)] When this units attack hits a vanguard you may pay the cost. If you do draw a card.' until end of turn.";
		}
		else if(id == CardIdentifier.IMMORTAL__ASURA_KAISER)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this units drive check reveals a grade 3 Nova Grappler until end of that battle this unit gets '[AUTO](VC)[Counter Blast (2) and Choose two Nova Grappler from your hand and discard them] At the end of the battle that this unit attacked a vanguard you may pay the cost. If you do choose both one of your rear-guards and vanguard [Stand] them and this unit gets [Power]+10000 until end of turn.'. This ability cannot be used for the rest of that turn.\n\n" +
				    "[CONT](VC)If you have a card named 'Asura Kaiser' in your soul this unit gets [Power]+2000.\n\n" +
				    "[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.GALAXY_BLAUKLUGER)
		{
			desc += "[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) and Choose two Nova Grappler from your hand and discard them] When an attack by your vanguard or rear-guard with 'Blau' in its card name hits a vanguard you may pay the cost. If you do [Stand] all of your units in the same column as this unit. This ability cannot be used for the rest of that turn. (This ability cannot be used even if the cost is not paid.)\n\n" +
					"[CONT](VC)If you have a card named 'Stern Blaukluger' in your soul this unit gets [Power]+2000.\n\n" +
					"[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.MOND_BLAUKLUGER)
		{
			desc += "[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Nova Grappler rides this unit choose your vanguard and until end of turn that unit gets [Power]+10000 and '[AUTO](VC)[Counter Blast (1)] When this unit attacks a vanguard you may pay the cost. If you do [Stand] all of your Nova Grappler rear-guards.'.\n\n" +
					"[AUTO](VC)When this unit is boosted by a Nova Grappler this unit gets [Power]+2000 until end of that battle.\n\n" +
					"[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.MARS_BLAUKLUGER)
		{
			desc += "[AUTO](RC)[Counter Blast(1)] When an attack by your vanguard with 'Blau' in its card name hits a vanguard you may pay the cost. If you do [Stand] this unit and this unit gets [Power]+5000 until the end of turn.";
		}
		else if(id == CardIdentifier.BLAU_DUNKELHEIT)
		{
			desc += "[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)\n\n" +
				    "[AUTO][Choose a Nova Grappler from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Nova Grappler that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.GROSSE_BAER)
		{
			desc += "[AUTO](RC) When this unit attacks if you have a vanguard with 'Blau' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
else if(id == CardIdentifier.DAREDEVIL_SAMURAI)
{
desc +="[AUTO](RC) During your battle phase when your Nova Grappler becomes [Stand] if you have a vanguard with 'Asura' in its card name this unit gets [Power]+3000 until end of turn.";
}
else if(id == CardIdentifier.POLAR_STERN)
{
desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Blau' in its card name this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.PLUTO_BLAUKLUGER)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.[AUTO](VC)[Counter Blast (3)] When this units attack hits a vanguard you may pay the cost. If you do choose up to two of your Nova Grappler rear-guards and [Stand] them.";
}
else if(id == CardIdentifier.BEAR_DOWN_SAMURAI)
{
desc +="[AUTO](RC)During your battle phase when your Nova Grappler becomes [Stand] if you have a vanguard with 'Asura' in its card name this unit gets [Power]+3000 until end of turn.";
}
else if(id == CardIdentifier.STARKER_WIND)
{
desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Blau' in its card name this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.DEATH_ARMY_BISHOP)
{
desc +="[ACT](RC)[Counter Blast (1)] If you have a Nova Grappler vanguard choose up to two of your other rear-guards with 'Death Army' in its card name and [Stand] them. This ability cannot be used for the rest of that turn.";
}
else if(id == CardIdentifier.BRUTAL_JOKER)
{
desc +="[ACT](VC/RC)[Counter Blast (2)] This unit gets [Power]+4000 until end of turn.";
}
else if(id == CardIdentifier.DEATH_ARMY_KNIGHT)
{
desc +="[AUTO]During your main phase when this unit is placed on (RC) if you have a Nova Grappler vanguard choose up to two of your other rear-guards with 'Death Army' in its card name and [Stand] them.";
}
else if(id == CardIdentifier.DEATH_ARMY_PAWN)
{
desc +="[AUTO]When another Nova Grappler rides this unit you may call this card to (RC).[ACT](RC)[Choose another of your rear-guards with 'Death Army' in its card name and [Rest] it] If you have a Nova Grappler vanguard this unit gets [Power]+2000 until end of turn.";
}
else if(id == CardIdentifier.MINIMUM_RAIZER)
{
desc +="ENG";
}
else if(id == CardIdentifier.DRAGONIC_EXECUTIONER)
{
desc +="[AUTO](VC/RC)When this unit attacks a vanguard if you have a Kagero vanguard this unit gets [Power]+2000 until end of that battle.";
}
else if(id == CardIdentifier.DRAGON_ARMORED_KNIGHT)
{
desc +="[CONT](VC/RC)If you do not have another Kagero in the same column as this unit this card gets [Power]-2000.[ACT](VC/RC)[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
}
else if(id == CardIdentifier.GRAPESHOT_WYVERN)
{
desc +="[AUTO]When this unit is placed on (RC) choose another of your Kagero and that unit gets [Power]+2000 until end of turn.";
}
else if(id == CardIdentifier.DEMONIC_LORD__DUDLEY_EMPEROR)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp Choose two Spike Brothers from your hand and put them into your soul] When this unit attacks a vanguard you may pay the cost. If you do search your deck for up to two Spike Brothers call them to separate open (RC) and shuffle your deck.[AUTO](VC)When this unit is boosted by a Spike Brothers this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.GREAT_SAGE_BARRON)
{
desc += "[AUTO](RC): During your main phase, when a card is put into your soul, if you have a Royal Paladin vanguard, this unit gains [Power] +3000 until end of turn.";	
}
else if(id == CardIdentifier.SPECTRAL_DUKE_DRAGON)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp Choose three of your Gold Paladin rear-guards and retire them] At the beginning of the close step of the battle that this unit attacked a vanguard you may pay the cost. If you do [Stand] this unit and this unit loses 'Twin Drive' until end of turn.\n\n[CONT](VC)If you have a card named 'Black Dragon Knight Vortimer' in your soul this unit gets [Power]+1000.";
}
else if(id == CardIdentifier.HOLY_DISASTER_DRAGON)
{
desc +="[AUTO](VC/RC)[Choose a Royal Paladin from your hand and discard it] When this unit attacks you may pay the cost. If you do this unit gets [Power]+5000 until end of that battle.";
}
		else if(id == CardIdentifier.HEXAGONAL_MAGUS)
{
desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Oracle Think Tank rides this unit look at three cards from the top of your deck search for one card from among them put it into your hand put the rest on the top of your deck in any order and choose your vanguard and that unit gets [Power]+10000 until end of turn.\n\n[CONT](VC)During your turn if the number of cards in your hand is four or greater this unit gets [Power]+2000.\n\n[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
else if(id == CardIdentifier.BATTLE_SISTER__PARFAIT)
{
desc +="[CONT](VC) Limit Break 4 (This ability is active if you have four or more damage)During your turn if the number of cards in your hand is four or greater this unit gets [Power]+3000 and '[AUTO](VC)When this units attack hits a vanguard draw a card.'.[ACT](VC)[Counter Blast (2)-cards with 'Battle Sister' in its card name] If the number of cards in your hand is three or less draw a card.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
else if(id == CardIdentifier.BATTLE_SISTER__MONAKA)
{
desc +="[ACT] (VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1) amp Choose a card named 'Battle Sister Monaka' from your hand and discard it] Look at five cards from the top of your deck search for two cards from among them put them into your hand and put the rest on the bottom of your deck in any order.[ACT](VC)[Counter Blast (2)-cards with 'Battle Sister' in its card name] This unit gets [Power]+5000 until end of turn.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
		else if(id == CardIdentifier.SOLITARY_LIBERATOR__GANCELOT)
{
desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Gold Paladin rides this unit choose your vanguard and that unit gets [Power]+10000 until end of turn and choose up to three of your Gold Paladin rear-guards and those units get [Power]+5000 until end of turn.[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+2000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
else if(id == CardIdentifier.DIGNIFIED_GOLD_DRAGON)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.[AUTO](RC)When this unit attacks a vanguard if you have a Gold Paladin vanguard this unit gets [Power]+2000 until end of that battle.";
}
else if(id == CardIdentifier.ONSLAUGHT_LIBERATOR__MAELZION)
{
desc +="[AUTO](VC/RC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.LIBERATOR_OF_SILENCE__GALLATIN)
{
desc +="ENG";
}
else if(id == CardIdentifier.LIBERATOR_OF_ROYALTY__PHALLON)
{
desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Liberator' in its card name this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.BLASTER_BLADE_LIBERATOR)
{
desc +="[AUTO][Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have a vanguard with 'Liberator' in its card name you may pay the cost. If you do choose one of your opponents rear-guards in the front row and retire it.";
}
else if(id == CardIdentifier.ZOOM_DOWN_EAGLE)
{
desc +="[AUTO]When this unit intercepts if you have a Gold Paladin vanguard this unit gets [Shield]+5000 until end of that battle.";
}
else if(id == CardIdentifier.ZOIGAL_LIBERATOR)
{
desc +="[AUTO](VC/RC)When this unit attacks if you have three or more other rear-guards with 'Liberator' in its card name this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.KNIGHT_OF_ELEGANT_SKILLS__GARETH)
{
desc +="ENG";
}
else if(id == CardIdentifier.LITTLE_LIBERATOR__MARRON)
{
desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Liberator' in its card name this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.POMERUGAL_LIBERATOR)
{
desc +="[ACT](VC/RC)[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
}
else if(id == CardIdentifier.FUTURE_LIBERATOR__LLEW)
{
desc +="[AUTO](RC)When this unit boosts a Gold Paladin vanguard if you have three or more other rear-guards with 'Liberator' in its card name the boosted unit gets [Power]+4000 until end of that battle.";
}
else if(id == CardIdentifier.ELIXIR_LIBERATOR)
{
desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
}
else if(id == CardIdentifier.STELLAR_MAGUS)
{
desc +="[AUTO](VC/RC)[Counter Blast (1)] When this unit attacks a vanguard if you have an Oracle Think Tank vanguard you may pay the cost. If you do declare the card name of an Oracle Think Tank and reveal the top card of your deck. If the revealed card is the card that you declared put it your hand and if it is not choose a card from your damage zone and turn it face up.";
}
else if(id == CardIdentifier.BATTLE_SISTER__COCOTTE)
{
desc +="[AUTO](VC/RC)[Counter Blast (1)-card with 'Battle Sister' in its card name] When this units attack hits a vanguard if you have an Oracle Think Tank vanguard you may pay the cost. If you do look at the top card of your deck search for up to one card with 'Battle Sister' in its card name from among them reveal it to your opponent put it into your hand and put the rest on the bottom of your deck.";
}
else if(id == CardIdentifier.BRIOLETTE_MAGUS)
{
desc +="[ACT](RC)[Soul Blast (1)] If you have an Oracle Think Tank vanguard draw a card and put this unit on the top of your deck.";
}
else if(id == CardIdentifier.CUORE_MAGUS)
{
desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'Magus' in its card name this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.CRESCENT_MAGUS)
{
desc +="[AUTO](RC)When this unit boosts a Oracle Think Tank if you have an Oracle Think Tank vanguard declare the card name of an Oracle Think Tank and reveal the top card of your deck. If the revealed card is the card that you declared the boosted unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.BAKINGRIM_DRAGON)
		{
			desc += "[AUTO](RC):When your grade 3 \"Kagero\" is placed on (VC), this unit gets [Power]+10000 until end of turn.";	
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT__MORTEZA)
		{
			desc += "[AUTO](VC):[Choose a \"Kagero\" from your hand, and discard it] When this unit attacks, you may pay the cost. If you do, this unit gets [Power]+6000 until end of that battle.\n\n[AUTO](RC):[Choose a \"Kagero\" from your hand, and discard it] When this unit attacks, you may pay the cost. If you do, this unit gets [Power]+3000 until end of that battle.";	
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT__NESHART)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits, if you have a \"Kagero\" vanguard, you may pay the cost. If you do, draw a card.";	
		}
		else if(id == CardIdentifier.DRAGON_DANCER__MARIA)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with \"[CONT]: Sentinel\" in a deck)\n\n[AUTO]:[Choose a \"Kagero\" from your hand, and discard it] When this unit is placed on (GC), you may pay the cost. If you do, choose one of your «Kagerō» that is being attacked, and that unit cannot be hit until end of that battle.";
		}	
			
else if(id == CardIdentifier.PENTAGONAL_MAGUS)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard declare the card name of an Oracle Think Tank and reveal the top card of your deck. If the revealed card is the card that you declared this unit gets [Power]+5000/[Critical]+1 until end of that battle.\n\n[ACT](VC)[Counter Blast (2)-cards with 'Magus' in its card name] This unit gets [Power]+5000 until end of turn.\n\n[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
else if(id == CardIdentifier.RIPIS_MAGUS)
{
desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'Magus' in its card name this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.ALFRED_EARLY)
{
desc +="[AUTO]When this unit is placed on (VC) choose up to one card named 'Blaster Blade' from your soul and call it to (RC).";
}
else if(id == CardIdentifier.STEEL_SPEAR_LIBERATOR__BLEOBERIS)
{
desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1)] When a Gold Paladin rides this unit you may pay the cost. If you do look at up to two cards from the top of your deck search for up to two Gold Paladin from among them call them to separate open (RC) and put the rest on the bottom of your deck in any order and choose your vanguard and that unit gets [Power]+10000 until end of turn.[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+2000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
else if(id == CardIdentifier.WISDOM_KEEPER__METIS)
{
desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1)] When a Genesis rides this unit you may pay the cost. If you do draw a card Soul Charge (3) and choose your vanguard and that unit gets [Power]+10000 until end of turn.[AUTO](VC)When this unit attacks a vanguard Soul Charge (1) and this unit gets [Power]+1000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
else if(id == CardIdentifier.ERADICATOR__ELECTRIC_SHAPER_DRAGON)
{
desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Narukami rides this unit choose your vanguard and until end of turn that unit gets [Power]+10000 and '[AUTO](VC)When your opponents rear-guard is put into the drop zone due to an effect from one of your cards choose one of your opponents rear-guards in the back row of the same column as that retired unit and retire it.'.[AUTO](VC)When this unit attacks if the number of cards in your opponents damage zone is three or more this unit gets [Power]+2000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
else if(id == CardIdentifier.STORY_TELLER)
{
desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits if you have a Dark Irregulars vanguard you may pay the cost. If you do draw a card.";
}
else if(id == CardIdentifier.PRETTY_CELEB__CHARLOTTE)
{
desc +="[AUTO](RC)[Counter Blast (1)] When this units attack hits a vanguard if you have a Bermuda Triangle vanguard you may pay the cost. If you do return this unit to your hand choose up to one Bermuda Triangle from your hand other than a card named 'Pretty Celeb Charlotte' and call it to an open (RC).";
}
else if(id == CardIdentifier.DANDELION_MUSKETEER__MIRKKA)
{
desc +="[AUTO](RC)When this unit boosts a Neo Nectar if you have a Neo Nectar vanguard and if your deck has been shuffled by your cards effect during that turn the boosted unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.UNRIVALED_BRUSH_WIELDER__PONGA)
{
desc +="[AUTO](VC) When this unit attacks a vanguard if the battle opponents [Power] is 12000 or greater this unit gets [Power]+10000 until end of that battle.[AUTO](RC) When this unit attacks a vanguard if you have a Great Nature vanguard this unit gets [Power]+2000 until end of that battle.";
}
else if(id == CardIdentifier.WATER_GENERAL_OF_WAVE_LIKE_SPIRALS__BENEDICT)
{
desc +="[AUTO](RC)At the end of the battle that this unit attacked a vanguard if you have an Aqua Force vanguard [Stand] this unit and this unit gets [Power]-5000 until end of turn. This ability cannot be used for the rest of that turn.";
}
else if(id == CardIdentifier.RECKLESS_EXPRESS)
{
desc +="[AUTO](RC)[Soul Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+5000 until end of that battle and at the beginning of the close step of that battle return this unit to your deck and shuffle your deck.";
}
else if(id == CardIdentifier.MARTIAL_ARTS_MUTANT__MASTER_BEETLE)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (3)] When this unit attacks a vanguard you may pay the cost. If you do choose up to two of your opponents rear-guards and those units cannot [Stand] during your opponents next stand phase.[CONT](VC/RC)If you have a non-Megacolony vanguard or rear-guard this unit gets [Power]-2000.";
}
else if(id == CardIdentifier.WHITE_DRAGON_KNIGHT__PENDRAGON)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)At the beginning of your main phase look at up to five cards from the top of your deck search for up to one grade 3 Royal Paladin from among them ride it and shuffle your deck.[AUTO]When this unit is placed on (VC) this unit gets [Power]+5000 until end of turn.";
}
else if(id == CardIdentifier.ORIGIN_MAGE__ILDONA)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp Choose two of your Shadow Paladin rear-guards and retire them] When this unit attacks you may pay the cost. If you do draw two cards and this unit gets [Power] +3000 until end of that battle.[AUTO](VC)When this unit attacks a vanguard this unit gets [Power] +3000 until end of that battle.";
}
else if(id == CardIdentifier.DRAGONIC_LAWKEEPER)
{
desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1)] Bind all of your opponents rear-guards and at the beginning of the end phase of that turn your opponent chooses up to four face up cards that were bound with this effect from his or her bind zone calls them to separate (RC) and puts all other cards that were bound with this effect into the drop zone.[AUTO](VC)When this unit attacks if the number of rear-guards your opponent has is two or less this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.JELLY_BEANS)
{
desc +="[ACT](Hand)[Reveal this card to your opponent and put it on the bottom of your deck] If you have a Spike Brothers vanguard search your deck for up to one grade 2 or less Spike Brothers with 'Dudley' in its name reveal it to your opponent put it into your hand and shuffle your deck.";
}
else if(id == CardIdentifier.DUDLEY_DAISY)
{
desc +="[AUTO][Counter Blast (1)] During your battle phase when this unit is placed on (RC) if you have a Spike Brothers vanguard you may pay the cost. If you do this unit gets [Power]+5000 until end of turn.";
}
else if(id == CardIdentifier.BEWITCHING_OFFICER__LADY_BUTTERFLY)
{
desc +="[AUTO](VC/RC)When this unit attacks a vanguard if you have a Megacolony vanguard this unit gets [Power]+2000 until end of that battle.";
}
else if(id == CardIdentifier.TOXIC_TROOPER)
{
desc +="AUTO V/R When this unit attacks all of your opponents units cannot intercept until end of that battle.";
}
else if(id == CardIdentifier.TOXIC_SOLDIER)
{
desc +="[AUTO](VC/RC)When this unit attacks all of your opponents units cannot intercept until end of that battle.";
}
else if(id == CardIdentifier.GIGANTECH_DESTROYER)
{
desc +="[AUTO](VC/RC)When this unit attacks a vanguard if you have a Gold Paladin vanguard this unit gets [Power]+2000 until end of that battle.";
}
else if(id == CardIdentifier.BLACK_DRAGON_KNIGHT__VORTIMER)
{
desc +="[CONT](VC)If you have a card named 'Scout of Darkness Vortimer' in your soul this unit gets [Power]+1000.[AUTO][Choose one of your Gold Paladin rear-guards and retire it] When a card named 'Spectral Duke Dragon' rides this unit if you have a card named 'Scout of Darkness Vortimer' in your soul you may pay the cost. If you do look at up to two cards from the top of your deck search for up to two Gold Paladin from among them call them to separate open (RC) and put the rest on the bottom of your deck in any order.";
}
else if(id == CardIdentifier.BLACK_DRAGON_WHELP__VORTIMER)
{
desc +="[AUTO]When a card named 'Scout of Darkness Vortimer' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Spectral Duke Dragon' or 'Black Dragon Knight Vortimer' from among them reveal it to your opponent put it into your hand and shuffle your deck. [AUTO]When a Gold Paladin other than a card named 'Scout of Darkness Vortimer' rides this unit you may call this card to (RC).";
}
else if(id == CardIdentifier.DUDLEY_DOUGLASS)
{
desc +="[AUTO][Counter Blast (1)] During your battle phase when this unit is placed on (RC) if you have a Spike Brothers vanguard you may pay the cost. If you do this unit gets [Power]+5000 until end of turn.";
}
else if(id == CardIdentifier.FIERCE_LEADER__ZACHARY)
{
desc +="[AUTO](RC)[Soul Blast (1)] When this units attack hits a vanguard if you have a Spike Brothers vanguard you may pay the cost. If you do draw a card and at the beginning of the close step of that battle return this unit to your deck and shuffle your deck.";
}
else if(id == CardIdentifier.FIELD_DRILLER)
{
desc +="[AUTO](VC/RC)When this units attack hits a vanguard if the number of other Spike Brothers rear-guards you have is four or more draw a card.";
}
else if(id == CardIdentifier.MEDICAL_MANAGER)
{
desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Spike Brothers vanguard you may Soul Charge (1).";
}
else if(id == CardIdentifier.SMART_LEADER__DARK_BRINGER)
{
desc +="[AUTO] When another Spike Brothers rides on this unit you may call this card to (RC). [AUTO](RC) [Put this unit into your soul] When this units attack hits you may pay the cost. If you do choose up to one Spike Brothers from your hand and call it to (RC).";
}
else if(id == CardIdentifier.KUNGFU_KICKER)
{
desc +="ENG";
}
else if(id == CardIdentifier.IRON_FIST_MUTANT__ROLY_POLY)
{
desc +="AUTO When this unit intercepts if you have a Megacolony vanguard this unit gets Shield +5000.";
}
else if(id == CardIdentifier.TRANSMUTATED_THIEF__STEAL_SPIDER)
{
desc +="AUTO V/R When this units attack hits a vanguard if you have 4 or more Megacolony rear-guards draw a card.";
}
else if(id == CardIdentifier.MACHINING_MOSQUITO)
{
desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Megacolony vanguard you may Soul Charge (1).";
}
else if(id == CardIdentifier.PEST_PROFESSOR__MAD_FLY)
{
desc +="AUTO R [Choose 1 card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
}
else if(id == CardIdentifier.MEGACOLONY_BATTLER_C)
{
desc +="AUTO When another Megacolony rides this unit you may call this card to Rear-guard Circle. AUTOR [Counter Blast (1) amp Put this unit into your soul] When an attack hits during the battle that this unit boosted a Megacolony you may pay the cost. If you do choose one of your opponents rear-guards and that unit cannot Stand during your opponents next stand phase. ";
}
else if(id == CardIdentifier.AWAKING_DRAGONFLY)
{
desc +="ENG";
}
else if(id == CardIdentifier.FLASH_EDGE_VALKYRIE)
{
desc +="[AUTO][Counter Blast (1)] When this unit is placed on (RC) from your deck if you have a Gold Paladin vanguard you may pay the cost. If you do look at the top card of your deck search for up to one Gold Paladin from among them call it to an open (RC) and put the rest on the bottom of your deck.";
}
else if(id == CardIdentifier.SCOUT_OF_DARKNESS__VORTIMER)
{
desc +="[CONT](VC)If you have a card named 'Black Dragon Whelp Vortimer' in your soul this unit gets [Power] +1000.\n\n[AUTO][Choose one of your Gold Paladin rear-guards and retire it] When a card named 'Black Dragon Knight Vortimer' rides this unit if you have a card named 'Black Dragon Whelp Vortimer' in your soul you may pay the cost. If you do look at up to two cards from the top of your deck search for up to two Gold Paladin from among them call them to separate open (RC) and put the rest on the bottom of your deck in any order.";
}
else if(id == CardIdentifier.BLADE_FEATHER_VALKYRIE)
{
desc +="[AUTO](RC)[Counter Blast (1)] When an attack hits a vanguard during the battle that this unit boosted a unit named 'Flash Edge Valkyrie' if you have a Gold Paladin vanguard you may pay the cost. If you do look at the top card of your deck search for up to one Gold Paladin from among them call it to an open (RC) and put the rest on the bottom of your deck.";
}
else if(id == CardIdentifier.WAR_HORSE__RAGING_STORM)
{
desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Gold Paladin vanguard choose up to one Gold Paladin from your hand and put it into your soul.";
}
else if(id == CardIdentifier.FALCON_KNIGHT_OF_THE_AZURE)
{
desc +="[AUTO]When this unit is placed on (RC) from your deck choose another of your Gold Paladin and that unit gets [Power]+2000 until end of turn.";
}
else if(id == CardIdentifier.KNIGHT_OF_DETERMINATION__LAMORAK)
{
desc +="ENG";
}
else if(id == CardIdentifier.KNIGHT_OF_FIGHTING_SPIRIT__DORDONA)
{
desc +="ENG";
}
else if(id == CardIdentifier.CROSS_SHOT__GARP)
{
desc +="ENG";
}
else if(id == CardIdentifier.TWIN_SHINE_SWORDSMAN__MARHAUS)
{
desc +="(AUTO](VC/RC)When this unit attacks a vanguard if you have a Royal Paladin vanguard this unit gets [Power]+2000 until the end of the battle.";
}
else if(id == CardIdentifier.GYRO_SLINGER)
{
desc +="ACT V/R [Counter Blast (1)] This unit gets Power +1000 until end of turn.";
}
else if(id == CardIdentifier.COMMANDER__GARRY_GANNON)
{
desc +="AUTOR [Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
}
else if(id == CardIdentifier.EAGLE_KNIGHT_OF_THE_SKIES)
{
desc +="[AUTO](VC/RC)When this unit attacks if the number of rear-guards you have is greater than your opponents this unit gets [Power] +3000 until end of that battle.";
}
else if(id == CardIdentifier.MIRU_BIRU)
{
desc +="[AUTO](RC)[Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
}
else if(id == CardIdentifier.OMNISCIENCE_MADONNA)
{
desc +="[AUTO](VC/RC)[Choose a card from your hand and discard it] When this units attack hits if you have an Oracle Think Tank vanguard you may pay the cost. If you do draw a card.";
}
else if(id == CardIdentifier.ONMYOJI_OF_THE_MOONLIT_NIGHT)
{
desc +="[AUTO](VC/RC)When this unit attacks if the number of cards in your hand is greater than your opponents this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.BLUE_SCALE_DEER)
{
desc +="[AUTO](VC/RC)[Soul Blast (2)] When this units attack hits a vanguard if you have an Oracle Think Tank vanguard you may pay the cost. If you do draw a card.";
}
else if(id == CardIdentifier.PETAL_FAIRY)
{
desc +="[AUTO](RC)[Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
}
		else if(id == CardIdentifier.MARGAL)
		{
			desc += "[ACT](RC):[Put this unit into your soul] Choose up to one of your \"Royal Paladin\", and that unit gets [Power]+3000 until end of turn.";	
		}
		else if(id == CardIdentifier.SCIENTIST_MONKEY_RUE)
		{
			desc += "[ACT](VC/RC): [Counter Blast (2)] Choose one of your Great Nature rear-guards, and that unit gets [Power] +4000 until end of turn, and at the beginning of the end phase of that turn, retire that unit.";	
		}
		else if(id == CardIdentifier.LUCK_BIRD)
		{
			desc += "[AUTO]:[Soul Blast (2)] When this unit is placed on (RC), if you have a Oracle Think Tank vanguard, you may pay the cost. If you do, draw a card.";	
		}
		else if(id == CardIdentifier.GREAT_SILVER_WOLF__GARMORE)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.[AUTO][Counter Blast (2)] When this unit is placed on (VC) you may pay the cost. If you do search from your deck for up to one grade 2 or less Gold Paladin call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.SLEYGAL_DOUBLE_EDGE)
		{
			desc +="[ACT](VC/RC)[Counter Blast (1)] If the number of other Gold Paladin rear-guards you have is four or more this unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.SLEYGAL_SWORD)
		{
			desc +="ACTV/R[CounterBlast(1)] If the number of other Gold Paladin rear-guards you have is four or more this unit gets Power +2000 until the end of the turn.";
		}
		else if(id == CardIdentifier.BATTLEFIELD_STORM__SAGRAMORE)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until the end of that battle.";
		}
		else if(id == CardIdentifier.SACRED_GUARDIAN_BEAST__NEMEAN_LION)
		{
			desc +="[AUTO]When this unit intercepts if you have a Gold Paladin vanguard this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.CHARGING_CHARIOT_KNIGHT)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the number of cards in your hand is less than your opponents this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.EVIL_SLAYING_SWORDSMAN__HAUGAN)
		{
			desc +="Activate V/R [Counter Blast (1)] This unit gets +1000 power until the end of turn.";
		}
		else if(id == CardIdentifier.PRECIPICE_WHIRLWIND__SAGRAMORE)
		{
			desc +="AutoR[Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.CHARJGAL)
		{
			desc +="AUTO [R] [Soul Blast (1)] When this unit boostsGreat Silver Wolf Garmore you may pay the cost. If you do the boosted unit gets POWER+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.BLESSING_OWL)
		{
			desc +="[AUTO] When this unit is placed on (RC) choose another of your Gold Paladin and that unit gets [Power] +2000 until end of turn.";
		}
		else if(id == CardIdentifier.SILVER_FANG_WITCH)
		{
			desc +="AUTO [Soul Blast (2)] When this unit is placed on Rear-guard Circle if you have a Gold Paladin vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.ELIXIR_SOMMELIER)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.THUNDER_BREAK_DRAGON)
		{
		desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.[AUTO][Counter Blast (2)] When this unit is placed on (VC) you may pay the cost. If you do choose one your opponents grade 2 or less rear-guards and retire it.";
		}
		else if(id == CardIdentifier.DJINN_OF_THE_LIGHTNING_FLASH)
		{
		desc +="ContinuousV/RThis unit cannot attack a Rearguard. AutoVWhen this unit attacks this unit gets Power +4000 until the end of the battle. AutoRWhen this unit attacks and you have a Narukami Vanguard this unit gets Power +2000 until the end of the battle. ";
		}
		else if(id == CardIdentifier.PLASMABITE_DRAGON)
		{
		desc +="[AUTO] (VC/RC) [Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until the end of that battle.";
		}
		else if(id == CardIdentifier.SHIELDBLADE_DRAGOON)
		{
		desc +="[AUTO] When this unit intercepts if you have a ltNarukamigt Vanguard this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.DJINN_OF_THE_LIGHTNING_FLARE)
		{
		desc +="CONTV/R This unit cannot attack a Rearguard. AUTOV When this unit attacks this unit gets Power +4000 until the end of the battle. AUTOR When this unit attacks and you have a Narukami Vanguard this unit gets Power +2000 until the end of the battle. ";
		}
		else if(id == CardIdentifier.BRIGHTJET_DRAGON)
		{
		desc +="[AUTO][(VC)/(RC)] When the unit attacks if you have fewer cards in your hand than your opponent this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__RIKI)
		{
		desc +="[ACT][(VC)/(RC)][Counter blast(1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.LIGHTNING_OF_HOPE__HELENA)
		{
		desc +="AUTO R [Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.DJINN_OF_THE_LIGHTNING_SPARK)
		{
		desc +="ContinuousV/RThis unit cannot attack a Rearguard. AutoVWhen this unit attacks this unit gets Power +4000 until the end of the battle. AutoRWhen this unit attacks and you have a Narukami Vanguard this unit gets Power +2000 until the end of the battle. ";
		}
		else if(id == CardIdentifier.DRAGON_DANCER__RAIRAI)
		{
		desc +="Auto [R] [Soul Blast (1)] When this unit boostsThunder Break Dragon you may pay the cost. If you do the boosted unit gets POWER+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.WYVERN_SUPPLY_UNIT)
		{
		desc +="AutoWhen you place this unit on a rear-guard circle choose another Narukami unit that unit gets Power +2000 until the end of the turn.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_NYMPH__SEIOBO)
		{
		desc +="(You can only have up to 4 Heal Triggers in a Deck)";
		}
		else if(id == CardIdentifier.SILENCE_JOKER)
		{
			desc += "[ACT](RC): [Put this unit into your soul] If you have a Spike Brothers vanguard, choose up to one card from your damage zone, and turn it face up.";	
		}
		else if(id == CardIdentifier.INTELLI_MOUSE)
		{
			desc += "[ACT](RC):[Rest this unit] Choose one of your Great Nature rear-guards, and that unit gets [Power]+4000 until end of turn, and at the beginning of the end phase of that turn, retire it.";	
		}
		else if(id == CardIdentifier.LADY_BOMB)
		{
			desc += "[AUTO]:[Counter Blast (2)] When this unit is placed on (VC) or (RC), you may pay the cost. If you do, choose one of your opponent's rear-guards, and that unit cannot [Stand] during your opponent's next stand phase.";	
		}
		else if(id == CardIdentifier.BLAZER_IDOLS)
		{
			desc += "[AUTO]:When this unit is placed on (RC), choose another of your Bermuda Triangle, and that unit gets [Power]+2000 until end of turn.";	
		}
		else if(id == CardIdentifier.CRAY_SOLDIER)
		{
			desc += "[AUTO](RC): When an attack hits during the battle that this unit boosted a Nova Grappler, [Stand] this Unit.";
		}
		else if(id == CardIdentifier.CANNON_FIRE_DRAGON_CANNON_GEAR)
		{
			desc += "[AUTO]: When this Unit is placed on (VC) or (RC), choose one of your rear-guards, and retire it.\n\n" +
					"[AUTO](VC): When this unit is boosted by a Tachikaze, this unit gets [Power]+2000 until end of turn.";	
		}
		else if(id == CardIdentifier.CHAOS_DRAGON_DINOCHAOS)
		{
			desc += "[ACT](Hand):[Choose two of your Tachikaze rear-guards, and retire them] If you have a grade 2 vanguard, you may reveal this card. If you do, ride this card.";	
		}
		else if(id == CardIdentifier.ONE_WHO_GAZES_AT_THE_TRUTH)
		{
			desc += "[AUTO](VC/RC):[Soul Blast (1)] When this unit attacks, if you have an Oracle Think Tank vanguard, you may pay the cost. If you do, this unit gets [Power]+3000 until end of that battle.";	
		}
		else if(id == CardIdentifier.SECURITY_GUARDIAN)
		{
			desc += "[AUTO]:When this unit intercepts, if you have an Oracle Think Tank vanguard, this unit gets [Shield]+5000 until end of that battle.";	
		}
		else if(id == CardIdentifier.GATTLING_CLAW_DRAGON)
		{
			desc += "[ACT](RC): [Counter Blast (1) and Put this unit into your soul] If you have a Kagero Vanguard, choose up to one of your opponent's grade 0 rear-guards, and retire it.";	
		}
		else if(id == CardIdentifier.FOLLOWER_REAS)
		{
			desc += "[AUTO](RC): When this unit boosts a unit named \"Chain-attack Sutherland\", the boosted unit gets [Power]+4000 until end of that battle.";	
		}
		else if(id == CardIdentifier.GODDESS_OF_FLOWER_DIVINATION__SAKUYA)
		{
			desc +="[CONT](VC)During your turn if the number of cards in your hand is four or more this unit gets [Power]+4000.[AUTO]When this unit is placed on (VC) return all of your Oracle Think Tank rear-guards to your hand.";
		}
		else if(id == CardIdentifier.METEOR_BREAK_WIZARD)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BATTLE_SISTER__MAPLE)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the number of cards in your hand is four or more this unit gets [Power]+3000 until end of that battle.";
		}
			else if(id == CardIdentifier.DARK_CAT)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have an Oracle Think Tank vanguard each player may draw a card.";
		}
		else if(id == CardIdentifier.SWORD_DANCER_ANGEL)
		{
			desc +="[AUTO](VC/RC)When you draw a card this unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.IRON_TAIL_DRAGON)
		{
			desc += "[ACT](VC/RC): [Counter Blast (1)] This unit gets [Power] +1000 until end of turn.";	
		}
		else if(id == CardIdentifier.ROUGH_SEAS_BANSHEE)
		{
			desc += "Card Effect(s)[ACT](RC): [Put this unit into your soul] If you have a Granblue Vanguard, draw up to 1 card.";	
		}
		else if(id == CardIdentifier.EVIL_SHADE)
		{
			desc += "[AUTO](RC): [Put two cards from the top of your deck into your drop zone] When this unit boosts a Granblue vanguard, you may pay the cost. If you do, the boosted Unit gets +4000 Power until end of that battle.";	
		}
		else if(id == CardIdentifier.SAMURAI_SPIRIT)
		{
			desc += "[ACT](Drop Zone): [Counter Blast(1) and Choose 1 of your Granblue rear-guard, and retire it] If you have a Granblue vanguard, call this card to a (RC).";	
		}
		else if(id == CardIdentifier.SKELETON_SWORDSMAN)
		{
			desc += "[AUTO]: When this unit intercepts, if you have a Granblue vanguard, this unit gets [Shield] +5000 until end of that battle.";	
		}
		else if(id == CardIdentifier.SPIKE_BROTHERS_ASSAULT_SQUAD)
		{
			desc += "[AUTO](RC): When an attack hits during the battle that this unit boosted a Spike Brothers, [Stand] this unit.";	
		}
		else if(id == CardIdentifier.CYCLONE_BLITZ)
		{
			desc += "[AUTO](VC/RC): [Soul Blast (1)] When this unit attacks, and you have a Spike Brothers vanguard, you may pay the cost. If you do, this unit gets [Power] +3000 until end of that battle.";	
		}
		else if(id == CardIdentifier.DEVIL_SUMMONER)
		{
			desc += "[AUTO]: When this unit is placed on (VC) or (RC), reveal the top card of your deck. If the revealed card is a grade 1 or 2 Spike Brothers, call it to (RC), and if it is not, shuffle your deck.";	
		}
		else if(id == CardIdentifier.MASTER_FRAUDE)
		{
			desc += "[AUTO](VC/RC): [Soul Blast (3)] When this unit's attack hits, if you have a Megacolony Vanguard, you may pay the cost. If you do, draw a card.\n\n" +
					"[AUTO](VC): When this unit is boosted by a Megacolony, this unit gets [Power] +3000 until end of that battle.";	
		}
		else if(id == CardIdentifier.DRAGON_EGG)
		{
			desc += "[AUTO](VC):When another Tachikaze rides this unit, you may call this card to (RC).\n\n" +
					"[AUTO]:[Counter Blast (1)] When this unit is put into the drop zone from (RC), if you have a Tachikaze vanguard, you may pay the cost. If you do, return this card to your hand.";	
		}
		else if(id == CardIdentifier.KNIGHT_OF_CONVICTION_BORS)
		{
			if(currentCardTexture == null)
			{
				Debug.Log("currentCardTexture is null");	
			}
			desc += "[AUTO][V/R]:[Flip 1]When this unit attacks, you may pay the cost. If you do, this unit gets +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BLASTER_BLADE)
		{
			desc += "[AUTO]:[Counter Blast (2)] When this unit is placed on (VC), you may pay the cost. If you do, choose one of your opponent's rear-guards, and retire it.\n\n" +
					"[AUTO]:[Counter Blast (2)] When this unit is placed on (RC), if you have a \"Royal Paladin\" vanguard, you may pay the cost. If you do, choose one of your opponent's grade 2 or greater rear-guards, and retire it.";
		}
		else if(id == CardIdentifier.SOLITARY_KNIGHT_GANCELOT)
		{
			desc += "[ACT]V]: [Flip 2]If you have a card named 'Blaster Blade' in your soul, this unit gets +5000/+1 until end of turn.\n\n" +
				   "ACT[Hand]: [Reveal this card to you opponent, and put it on top of your deck]Search you deck for up to one card named 'Blaster Blade'" +
				   ", reveal it to your opponent, put it on your hand, and shuffle your deck";
		}
		else if(id == CardIdentifier.KNIGHT_OF_THE_HARP_TRISTAN)
		{
			desc += "[AUTO][V]: When this unit's drive check reveals a grade 3 <<Royal Paladin>>, this unit gets +5000 until end of that battle.";
		}
		else if(id == CardIdentifier.WINGAL)
		{
			desc += "[AUTO][R]: When this unit boosts a card named 'Blaster Blade', the boosted unit gets +4000 until end of that turn";
	
		}
		else if(id == CardIdentifier.STARLIGHT_UNICORN)
		{
			desc += "[AUTO]: When this unit is placed on R, choose another of your <<Royal Paladin>>, and that unit gets +2000 until end of turn.";
		}
		else if(id == CardIdentifier.LITTLE_SAGE_MARON)
		{
			desc += "";
		}
		else if(id == CardIdentifier.YGGDRASIL_MAIDEN_ELAINE)
		{
			desc += "";
		}
		else if(id == CardIdentifier.STARDUST_TRUMPETER)
		{
			desc += "";
		}
		else if(id == CardIdentifier.KNIGHT_OF_ROSE_MORGANA)
		{
			desc += "[AUTO][V/R]: [Choose a card from your hand, and discard it] When this unit attacks, you may pay the cost. If you do, this unit gets +4000 until end of turn.";
		}
		else if(id == CardIdentifier.CRIMSON_BUTTERFLY_BRIGITTE)
		{
			desc += "[AUTO][V]: When this unit's drive check reveals a grade 3 <<Royal Paladin>>, this unit gets +5000 until end of that battle.";
		}
		else if(id == CardIdentifier.COVENANT_KNIGHT_RANDOLF)
		{
			desc += "[AUTO][V/R]: When this unit attacks, if the number of cards in your hand is greater than you opponent's, this unit gets +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_SILENCE_GALLATIN)
		{
			desc += "";
		}
		else if(id == CardIdentifier.FLOGAL)
		{
			desc += "";
		}
		else if(id == CardIdentifier.WEAPONS_DEALER_GOVANNON)
		{
			desc += "";
		}
		else if(id == CardIdentifier.DRAGONIC_OVERLORD)
		{
			desc += "[CONT](VC/RC):If you do not have another Kagero vanguard or rear-guard, this unit gets [Power]-2000.\n\n" +
				   "[ACT](VC/RC):[Counter Blast (3)] Until end of turn, this unit gets [Power]+5000, gets [AUTO](VC/RC): When this unit's attack hits an opponent's rear-guard, [Stand] this unit, and loses Twin Drive!!.";			
		}
		else if(id == CardIdentifier.DRAGON_MONK_GOKU)
		{
			desc += "[AUTO](VC):When this unit's drive check reveals a grade 3 Kagero, choose an opponent's grade 1 or less rear-guard, and retire it.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_BERSERKER_YAKSHA)
		{
			desc += "[AUTO](Hand):During your main phase, when an opponent's rear-guard is put into the drop zone, if you have a grade 2 vanguard, you may reveal this card. If you do, ride this card.";
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT_NEHALEM)
		{
			desc += "";
		}
		else if(id == CardIdentifier.BERSERK_DRAGON)
		{
			desc += "[AUTO]:[Counter Blast (2)] When this unit is placed on (VC) or (RC), if you have a Kagero vanguard, you may pay the cost. If you do, choose an opponent's grade 2 or less rear-guard, and retire it.";
		}
		else if(id == CardIdentifier.WYVERN_STRIKE_TEJAS)
		{
			desc += "[CONT](VC/RC):If this unit would attack, it may instead attack an opponent's unit in the back row of the same column as this unit.";
		}
		else if(id == CardIdentifier.DRAGON_MONK_GOJO)
		{
			desc += "[ACT](VC/RC):[Rest this unit & Choose a card from your hand, and discard it] Draw a card.";
		}
		else if(id == CardIdentifier.FLAME_OF_HOPE_AERMO)
		{
			desc += "[AUTO](RC): [Choose a card from your hand, and discard it] When an attack hits during the battle that this unit boosted, you may pay the cost. If you do, draw a card.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MADONNA_JOKA)
		{
			desc += "[AUTO](RC): During your main phase, when an opponent's rear-guard is put into the drop zone, this unit gets [Power] +3000 until end of turn.";
		}
		else if(id == CardIdentifier.WYVERN_STRIKE_JARRAN)
		{
			desc += "[AUTO](RC): When this unit boosts a card named Wyvern Strike, Tejas, the boosted unit gets [Power] +4000 until end of that battle.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE_RAKSHASA)
		{
			desc += "[AUTO](RC): During your main phase, when an opponent's rear-guard is put into the Drop Zone, this units gets [Power] +3000 until end of turn.";	
		}
		else if(id == CardIdentifier.GOLD_RUTILE)
		{
			desc += "[AUTO](VC):When your rear-guard's attack hits a vanguard, choose a card from your damage zone, and turn it face up.\n\n" +
				    "[AUTO](VC):[Counter Blast (2)] When this unit's attack hits a vanguard, you may pay the cost. If you do, choose one of your Nova Grappler rear-guards, and [Stand] it.";	
		}
		else if(id == CardIdentifier.DEATH_METAL_DROID)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (1)] When this unit attacks, you may pay the cost. If you do, this unit gets [Power]+3000 until end of that battle.";	
		}
		else if(id == CardIdentifier.MR_INVINCIBLE)
		{
			desc += "[AUTO](VC):At the beginning of your main phase, Soul Charge (1), choose a card from your damage zone, and turn it face up.\n\n" +
				    "[AUTO](VC/RC):[Soul Blast (8) & Counter Blast (5)] When this unit's attack hits, you may pay the cost. If you do, [Stand] all of your units.";
		}
		else if(id == CardIdentifier.SUPER_ELECTROMAGNETIC_LIFEFORM_STORM)
		{
			desc += "[AUTO](VC/RC):When this unit's attack hits a vanguard, if you have a Nova Grappler vanguard, choose a card from your damage zone, and turn it face up.";	
		}
		else if(id == CardIdentifier.NGM_PROTOTYPE)
		{
			desc += "[AUTO]:When this Unit intercepts, if you have a «Nova Grappler» vanguard, this unit gets [Shield]+5000 until end of that battle.";	
		}
		else if(id == CardIdentifier.OASIS_GIRL)
		{
			desc += "[ACT](VC/RC):[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";	
		}
		else if(id == CardIdentifier.SCREAMIN_AND_DANCIN_ANNOUNCER_SHOUT)
		{
			desc += "[ACT](VC/RC):[Rest this unit & Choose a card from your hand, and discard it] Draw a card.";
		}	
		else if(id == CardIdentifier.QUEEN_OF_HEART)
		{
			desc += "[AUTO](RC):When this unit boosts a unit named King of Sword, the boosted unit gets [Power]+4000 until end of that battle.";	
		}
		else if(id == CardIdentifier.BATTERING_MINOTAUR)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (1)] When this unit attacks, you may pay the cost. If you do, this unit gets [Power]+3000 until end of that battle.";	
		}
		else if(id == CardIdentifier.BATTLERAIZER)
		{
			desc += "[AUTO]: When another Nova Grappler rides this unit, you may call this card to (RC).\n\n" +
					"[AUTO](RC): When this unit boosts, the boosted unit gets [Power]+3000 until end of that battle, and at the beginning of the end phase of that turn, return this unit to your deck, and shuffle your deck.";	
		}
		else if(id == CardIdentifier.KING_OF_KNIGHTS_ALFRED)
		{
			desc += "[CONT](VC):Your units cannot boost this unit.\n\n" +
				    "[CONT](VC):During your turn, this unit gets [Power]+2000 for each of your Royal Paladin rear-guards.\n\n" +
				    "[ACT](VC/RC):[Counter Blast (3)] Search your deck for up to one grade 2 or less Royal Paladin, call it to (RC), and shuffle your deck.";	
		}
		else if(id == CardIdentifier.BARCGAL)
		{
			desc += "[AUTO]:When another Royal Paladin rides this unit, you may call this card to (RC).\n\n" +
				    "[ACT](RC):[Rest this unit] Search your deck for up to one card named 'Future Knight, Llew' or 'Flogal', call it to (RC), and shuffle your deck.";	
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT_ALEPH)
		{
			desc += "[ACT](VC): [Counter-Blast 1 and Choose a unit named 'Embodiment of Armor, Bahr' and a unit named 'Embodiment of Spear, Tahr' from your (RC), and put them into your soul] Search your deck for up to one card 'Embodiment of Victory, Aleph', ride it, and shuffle your deck.";	
		}
		else if(id == CardIdentifier.EMBODIMENT_OF_VICTORY_ALEPH)
		{
			desc += "[ACT](VC/RC): [Counter-Blast 4] This unit gets [Power]+3000/[Critical]+1 until end of turn.\n\n" +
				    "[ACT](VC): [Choose a card named 'Dragon Knight, Aleph', a card named 'Embodiment of Armor, Bahr', and a card named 'Embodimento of Spear, Tahr' from your soul, and put them into your drop zone]. Turn all cards in your damage zone face up";	
		}
		else if(id == CardIdentifier.CEO_AMATERASU)
		{
			desc += "[CONT](VC):During your turn, if the number of cards in your hand is four or greater, this unit gets [Power] +4000.\n\n" +
					"[AUTO](VC):At the beginning of your main phase, Soul Charge (1), look at the top card of your deck, and put that card on the top or the bottom of your deck.\n\n" +
					"[AUTO](VC/RC):[Soul Blast (8) and Counter Blast (5)] When this unit's attack hits, you may pay the cost. If you do, draw up to five cards.";	
		}
		else if(id == CardIdentifier.BATTLE_SISTER_COCOA)
		{
			desc += "[AUTO]:When this unit is placed on (VC) or (RC), if you have a Oracle Think Tank vanguard, look at the top card of your deck, and put that card on the top or the bottom of your deck.";	
		}
		else if(id == CardIdentifier.MAIDEN_OF_LIBRA)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits, if you have an Oracle Think Tank vanguard, you may pay the cost. If you do, draw a card.";	
		}
		else if(id == CardIdentifier.BATTLE_SISTER_MOCHA)
		{
			desc += "[AUTO](VC/RC):When this unit attacks, if the number of cards in your hand is four or greater, this unit gets [Power] +3000 until end of that battle.";	
		}
		else if(id == CardIdentifier.BATTLE_SISTER_CHOCOLAT)
		{
			desc += "[CONT]:Sentinel (You may only have up to four cards with '[CONT]:Sentinel' in a deck.)\n\n" +
					"[AUTO]:[Choose a Oracle Think Tank from your hand, and discard it] When this unit is placed on (GC), you may pay the cost. If you do, choose one of your «Oracle Think Tank» that is being attacked, and that unit cannot be hit until end of that battle.";	
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN_APOLLON)
		{
			desc += "[AUTO](VC):[Counter Blast (2)] When this unit's attack hits, you may pay the cost. If you do, draw two cards, choose a card from your hand, return it to your deck, and shuffle your deck.\n\n" +
					"[AUTO](RC):[Counter Blast (2)] When this unit's attack hits, you may pay the cost. If you do, draw a card.";	
		}
		else if(id == CardIdentifier.LOZENGE_MAGUS)
		{
			desc += "[AUTO]:When another Oracle Think Tank rides this unit, you may call this card to (RC).\n\n" +
				    "[AUTO](RC):When this unit boosts, the boosted unit gets [Power]+3000 until end of that battle, and at the begininng of the end phase of that turn, return this unit to your deck, and shuffle your deck.";	
		}
		else if(id == CardIdentifier.WEATHER_GIRL_MILK)
		{
			desc += "[AUTO](RC):When this unit boosts an Oracle Think Tank vanguard, if the number of cards in your hand is four or greater, the boosted unit gets [Power]+4000 until end of that battle.";	
		}
		else if(id == CardIdentifier.ASURA_KAISER)
		{
			desc += "[CONT](VC/RC):If you do not have another Nova Grappler vanguard or rear-guard, this unit gets [Power] -2000.\n\n" +
					"[AUTO](VC):When this unit's drive check reveals a grade 3 Nova Grappler, choose one of your rear-guards, and [Stand] it.";	
		}
		else if(id == CardIdentifier.DEMON_SLAYING_KNIGHT_LOHENGRIM)
		{
			desc += "[AUTO](VC):At the beginning of your main phase, Soul Charge (1), and this unit gets [Power]+2000 until end of turn.\n\n" +
					"[AUTO](VC/RC):[Soul Blast (8) and Counter Blast (5)] When this unit's attack hits, you may pay the cost. If you do, retire all of your opponent's rear-guards.";
		}
		else if(id == CardIdentifier.FLASH_SHIELD_ISEULT)
		{
			desc += "[CONT]:Sentinel (You may only have up to four cards with '[CONT]:Sentinel' in a deck.)\n\n" +
					"[AUTO]:[Choose a Royal Paladin from your hand, and discard it] When this unit is placed on (GC), you may pay the cost. If you do, choose one of your Royal Paladin that is being attacked, and that unit cannot be hit until end of that battle.";	
		}
		else if(id == CardIdentifier.FUTURE_KNIGHT_LLEW)
		{
			desc += "[ACT](RC):[Counter Blast (1) and Choose a unit named 'Future Knight, Llew', a unit named 'Barcgal', and a unit named 'Flogal' from your (RC), and put them into your soul] If you have a grade 1 vanguard, search your deck for up to one card named 'Blaster Blade', ride it, and shuffle your deck.";	
		}
		else if(id == CardIdentifier.VORTEX_DRAGON)
		{
			desc += "[AUTO](VC): At the beginning of your main phase, [Soul Charge (1)], and this unit gets Power +2000 until the end of the turn.\n\n" +
					"[ACT](VC/RC): [Soul Blast (8) and Counter Blast (5)] Choose up to three of your opponent's rear-guards, and retire them.";	
		}
		else if(id == CardIdentifier.WYVERN_GUARD_BARRI)
		{
			desc += "[CONT]:Sentinel (You may only have up to four cards with '[CONT]:Sentinel' in a deck.)\n\n" +
					"[AUTO]:[Choose a Kagero from your hand, and discard it] When this unit is placed on (GC), you may pay the cost. If you do, choose one of your Kagero that is being attacked, and that unit cannot be hit until end of that battle.";	
		}
		else if(id == CardIdentifier.LIZARD_SOLIDER_CONROE)
		{	
			desc += "[AUTO]:When another Kagero rides this unit, you may call this card to a (RC).\n\n" +
					"[ACT](RC):[Counter Blast (1) and Retire this unit] Search your deck for up to one grade 1 or less Kagero, reveal it to your opponent, put it into your hand, and shuffle your deck.";
		}
		else if(id == CardIdentifier.JUGGERNAUT_MAXIMUM)
		{
			desc += "[CONT](VC/RC):If you do not have another Spike Brothers vanguard or rear-guard, this unit gets [Power]-2000.\n\n" +
					"[AUTO](RC):[Soul Blast (1)] When this unit attacks, you may pay the cost. If you do, this unit gets [Power]+5000 until end of that battle, and at the beginning of the close step of that battle, return this unit to your deck, and shuffle your deck.";	
		}
		else if(id == CardIdentifier.BRUTAL_JACK)
		{
			desc += "[CONT](VC/RC): Restraint (This unit cannot attack.)\n\n" +
					"[ACT](VC/RC):[Counter Blast (1)] Until end of turn, this unit loses 'Restraint'\n\n" +
					"[AUTO](VC):When this unit is boosted by a Nova Grappler, this unit gets [Power]+5000 until end of that battle.";	
		}
		else if(id == CardIdentifier.TYRANT_DEATHREX)
		{
			desc += "[AUTO](VC):When this unit attacks, this unit gets [Power]+5000 until end of that battle.\n\n" +
					"[AUTO](VC):When this unit's attack hits, choose one of your rear-guards, and retire it.";	
		}
		else if(id == CardIdentifier.ASSAULT_DRAGON_BLIGHTOPS)
		{
			desc += "[AUTO]: [Counter-Blast 1] When this unit is put into the drop zone from (RC), you may pay the cost. If you do, search your deck for up to one card named 'Ironclad Dragon, Shieldon', reveal it to your opponent, put it into your hand, and shuffle your deck.";	
		}
		else if(id == CardIdentifier.STEALTH_DRAGON_VOIDMASTER)
		{
			desc += "[AUTO](VC):When this unit attacks, if the number of cards in your hand is greater than your opponent's, this unit gets [Power]+3000 until end of that battle.\n\n" +
					"[AUTO](VC/RC):[Counter Blast (1)] When this unit's attack hits, if the number of cards in your hand is less than your opponent's, you may pay the cost. If you do, your opponent chooses a card from his or her hand, and discards it.";	
		}
		else if(id == CardIdentifier.DEMON_EATER)
		{
			desc += "[AUTO](VC):At the beginning of your main phase, Soul Charge (1), and this unit gets [Power]+2000 until end of turn.\n\n" +
					"[AUTO](VC/RC):[Soul Blast (8) and Counter Blast (5)] When this unit's attack hits, you may pay the cost. If you do, retire all of your opponent's rear-guards.";	
		}
		else if(id == CardIdentifier.MONSTER_FRANK)
		{
			desc += "[ACT][Drop zone]: [Counter-Blast 3] If you have a Grade 2 Vanguard, ride this card.";	
		}
		else if(id == CardIdentifier.HELL_SPIDER)
		{
			desc += "[CONT](VC):During your turn, if all of your opponent's vanguard and rear-guards are Rest, this unit gets [Power] +3000.\n\n" +
					"[AUTO]:[Counter-Blast 2] When this unit is placed on (VC) or (RC), you may pay the cost. If you do, choose one of your opponent's rear-guards, and the chosen unit cannot [Stand] during your opponent's next stand phase.";	
		}
		else if(id == CardIdentifier.CLAY_DOLL_MECHANIC)
		{
			desc += "[AUTO]:When this unit is placed on (RC), if you have a Nova Grappler vanguard, choose a card from your damage zone, and turn it face up.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST_CHIGASUMI)
		{
			desc += "[AUTO](VC/RC):When this unit attacks, if the number of cards in your hand is greater than your opponent's, this unit gets [Power] +3000 until end of that battle.";	
		}
		else if(id == CardIdentifier.STEALTH_DRAGON_DREADMASTER)
		{
			desc += "[AUTO](RC):[Counter Blast (1)] When an attack hits during the battle that this unit boosted a Nubatama, if the number of cards in your hand is less than your opponent's, you may pay the cost. If you do, your opponent chooses a card from his or her hand, and discards it.";	
		}
		else if(id == CardIdentifier.STEALTH_BEAST_HAGAKURE)
		{
			desc += "[AUTO]:[Counter Blast (1)] When this unit is placed on (GC), if you have a Nubatama vanguard, and the number of cards in your hand is less than your opponent's, you may pay the cost. If you do, your opponent chooses a card from his or her hand, and discards it.";	
		}
		else if(id == CardIdentifier.BLUE_DUST)
		{
			desc += "[AUTO](VC/RC):When this unit's attack hits, if you have a Dark Irregulars vanguard, you may Soul Charge (1).";	
		}
		else if(id == CardIdentifier.NIGHTMARE_BABY)
		{
			desc += "[AUTO](RC):When this unit boosts a unit named 'Blue Dust', the boosted unit gets [Power] +4000 until end of that battle.";	
		}
		else if(id == CardIdentifier.ROCK_THE_WALL)
		{
			desc += "[AUTO]:When this unit is put into the drop zone from (GC), put this card into your soul.";	
		}
		else if(id == CardIdentifier.HIGHSPEED_BRAKKI)
		{
			desc += "[AUTO](RC):[Soul Blast (1)] When this unit attacks, you may pay the cost. If you do, this unit gets [Power]+5000 until end of that battle, and at the beginning of the close step of that battle, return this unit to your deck, and shuffle your deck.";	
		}
		else if(id == CardIdentifier.REDSHOE_MILLY)
		{
			desc += "[AUTO]: When this unit is put into the drop zone from (GC), put this card into your soul.";	
		}
		else if(id == CardIdentifier.GUIDING_ZOMBIE)
		{
			desc += "[AUTO]: When another Granblue rides this unit, you may call this card to (RC).\n\n" +
					"[ACT](RC): (Put this unit into your soul) Put three cards from the top of your deck into your drop zone.";	
		}
		else if(id == CardIdentifier.KARMA_QUEEN)
		{
			desc += "[AUTO]:[Counter Blast (2)] When this unit is placed on (VC) or (RC), you may pay the cost. If you do, choose one of your opponent's rear-guards, and the chosen unit cannot [Stand] during your opponent's next stand phase.";	
		}
		else if(id == CardIdentifier.LAKE_MAIDEN_LIEN)
		{
			desc += "[ACT](VC/RC):(Rest this unit and Choose a card from your hand, and discard it) Draw a card.";
		}
		else if(id == CardIdentifier.HUNGRY_DUMPTY)
		{
			desc += "[AUTO]: When this unit is placed on (RC), if you have a Nova Grappler vanguard, choose a card from your damage zone, and turn it face up.";	
		}
		else if(id == CardIdentifier.TOP_IDOL_FLORES)
		{
			desc += "[AUTO](VC/RC):[Soul Blast (2)] When this unit's attack hits, you may pay the cost. If you do, choose one of your Bermuda Triangle rear-guards, and return it to your hand.";
		}
		else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET_CARAVEL)
		{
			desc += "[AUTO]: [Soul Blast (2)] When this unit is placed on (RC), if you have a Bermuda Triangle vanguard, you may pay the cost. If you do, draw a card.";	
		}
		else if(id == CardIdentifier.BLAZER_IDOLS)
		{
			desc += "[AUTO]:When this unit is placed on (RC), choose another of your Bermuda Triangle, and that unit gets [Power]+2000 until end of turn.";	
		}
		else if(id == CardIdentifier.SPIRIT_EXCEED)
		{
			desc += "[ACT](Drop Zone):[Choose a unit named 'Samurai Spirit' and a unit named 'Knight Spirit' from your (RC), and put them into your Soul] If you have a Grade 2 or greater Vanguard, ride this Card.";	
		}
		else if(id == CardIdentifier.RUIN_SHADE)
		{
			desc += "[AUTO](VC/RC): [Put two cards from the top of your deck into your drop zone] When this unit attacks, if you have a Granblu》 Vanguard, you may pay the cost. If you do, this unit gets [Power] +2000 until end of that battle.";	
		}
		else if(id == CardIdentifier.KING_OF_DEMONIC_SEAS_BASSKIRK)
		{
			desc += "[AUTO](VC):At the beginning of your main phase, Soul Charge (1), and this unit gets [Power]+2000 until end of turn.\n\n" +
					"[ACT](VC/RC):[Soul Blast (8) & Counter Blast (5)] Choose up to five Granblue from your drop zone, and call them to separate (RC).";	
		}
		else if(id == CardIdentifier.WITCH_DOCTOR_OF_THE_ABYSS_NEGROMARL)
		{
			desc += "[AUTO]:[Counter Blast (2)] When this unit is placed on (VC) or (RC), if you have a Granblue vanguard, you may pay the cost. If you do, choose a card from your drop zone, and call it to (RC).";	
		}
		else if(id == CardIdentifier.CAPTAIN_NIGHTMIST)
		{
			desc += "[CONT](VC):During your turn, if you have a card named 'Captain Nightmist' in your drop zone, this unit gets [Power]+3000.\n\n" +
					"[ACT](Drop Zone):[Counter Blast (1) and Choose one of your grade 1 or greater Granblue rear-guards, and retire it] If you have a Granblue vanguard, call this card to (RC).";	
		}
		else if(id == CardIdentifier.GUST_JINN)
		{
			desc += "[CONT]:Sentinel (You may only have up to four cards with '[CONT]:Sentinel' in a deck.)\n\n" +
					"[AUTO]:[Choose a Granblue from your hand, and discard it] When this unit is placed on (GC), you may pay the cost. If you do, choose one of your «Granblue» that is being attacked, and that unit cannot be hit until end of that battle.";	
		}
		else if(id == CardIdentifier.DANCING_CUTLASS)
		{
			desc += "[AUTO]: [Soul Blast (2)] When this unit is placed on (RC), if you have a Granblue Vanguard, you may pay the cost. If you do, draw a card.";	
		}
		else if(id == CardIdentifier.CHAPPIE_THE_GHOSTIE)
		{
			desc += "[AUTO]: When this unit is placed on (GC), search your deck for up to one Granblue,put it into your drop zone, and shuffle your deck.";	
		}
		else if(id == CardIdentifier.SAMURAI_SPIRIT)
		{
			desc += "[ACT](Drop Zone): [Counter Blast(1) and Choose 1 of your Granblue rear-guard, and retire it] If you have a Granblue vanguard, call this card to a (RC).";	
		}
		else if(id == CardIdentifier.SKELETON_SWORDSMAN)
		{
			desc += "[AUTO]: When this unit intercepts, if you have a Granblue vanguard, this unit gets [Shield] +5000 until end of that battle.";
		}	
		else if(id == CardIdentifier.EVIL_SHADE)
		{
			desc += "[AUTO](RC): [Put two cards from the top of your deck into your drop zone] When this unit boosts a Granblue vanguard, you may pay the cost. If you do, the boosted Unit gets +4000 Power until end of that battle.";	
		}
		else if(id == CardIdentifier.ROUGH_SEAS_BANSHEE)
		{
			desc += "[ACT](RC): [Put this unit into your soul] If you have a Granblue Vanguard, draw up to 1 card.";	
		}
		else if(id == CardIdentifier.SKY_DIVER)
		{
			desc += "[CONT](VC/RC):If you do not have another Spike Brothers vanguard or rear-guard, this unit gets [Power]-2000.\n\n" +
					"[AUTO](RC):[Put this unit into your soul] When this unit's attack hits, you may pay the cost. If you do, choose up to one Spike Brothers from your hand, and call it to (RC).";	
		}
		else if(id == CardIdentifier.SOUL_SAVER_DRAGON)
		{
			desc += "[AUTO](VC):When this unit attacks a vanguard, this unit gets [Power]+3000 until end of that battle.\n\n" +
					"[AUTO]:[Soul Blast (5)] When this unit is placed on (VC), you may pay the cost. If you do, choose up to three of your Royal Paladin rear-guards, and those units get [Power]+5000 until end of turn.";	
		}
		else if(id == CardIdentifier.BLAZING_FLARE_DRAGON)
		{
			desc += "[AUTO](VC/RC):During your main phase, when your opponent's rear-guard is put into the drop zone, this unit gets [Power]+3000 until end of turn.\n\n" +
					"[ACT](VC):[Soul Blast (5)] Choose one of your opponent's rear-guards, and retire it.";	
		}
		else if(id == CardIdentifier.SEAL_DRAGON_BLOCKADE)
		{
			desc += "[CONT](VC):During your turn, your opponent's units cannot intercept.";	
		}
		else if(id == CardIdentifier.SCARLET_WITCH_COCO)
		{
			desc += "[CONT](VC):During your turn, if you do not have any cards in your soul, this unit gets [Power]+3000.\n\n" +
					"[AUTO]:[Counter Blast (2)] When this unit is placed on (VC), if the number of cards in your soul is one or less, you may pay the cost. If you do, draw up to two cards";	
		}
		else if(id == CardIdentifier.LION_HEAT)
		{
			desc += "[AUTO](VC):[Counter Blast(2)] When this unit's attack hits a vanguard, you may pay the cost. If you do, choose one of your Nova Grappler rear-guards and [Stand] it.\n\n" +
					"[AUTO](RC):[Counter Blast(2)] When this unit's attack hits a vanguard, you may pay the cost. If you do, choose one of your Grade 1 or less Nova Grappler rear-guards and [Stand] it.";	
		}
		else if(id == CardIdentifier.GENERAL_SEIFRIED)
		{
			desc += "[AUTO](VC):When this unit's drive check reveals a grade 3 Spike Brothers, you may call that card to an open (RC).\n\n" +
					"[AUTO](VC):When this unit is boosted by a Spike Brothers, this unit gets [Power]+3000 until end of that battle.";	
		}
		else if(id == CardIdentifier.CHEER_GIRL_MARILYN)
		{
			desc += "[CONT]:Sentinel (You may only have up to four cards with '[CONT]:Sentinel' in a deck)\n\n" +
					"[AUTO]:[Choose a Spike Brothers from your hand, and discard it] When this unit is placed on (GC), you may pay the cost. If you do, choose one of your Spike Brothers, and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.YOUNG_PEGASUS_KNIGHT)
		{
			desc += "[AUTO](RC): During your main phase, when a card is put into your soul, if you have a Royal Paladin vanguard, this unit gets Power +3000 until end of turn.";	
		}
		else if(id == CardIdentifier.RAINBOW_MAGICIAN)
		{
			desc +="[AUTO]R When an attack hits during the battle that this unit boosted you may Soul Charge (1). If you do return this unit to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.VACUUM_MAMMOTH)
		{
			desc +="[AUTO]V When another of your Tachikaze is placed on Rear-guard Circle you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.SAVAGE_DESTROYER)
		{
			desc +="[AUTO]V/R During your turn when another of your Tachikaze rear-guards is put into the drop zone this unit gets Power +1000 until end of turn.";
		}
		else if(id == CardIdentifier.RAGING_DRAGON__SPARKSAURUS)
		{
			desc +="[AUTO] [Choose a card from your hand and discard it] When this unit is put into the drop zone from Rear-guard Circle you may pay the cost. If you do search your deck for up to one card named 'Raging Dragon Sparksaurus' call it to Rear-guard Circle and shuffle your deck.";
		}
		else if(id == CardIdentifier.CANDY_CLOWN)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.ELEPHANT_JUGGLER)
		{
			desc +="[AUTO]V When another of your Pale Moon is placed on Rear-guard Circle you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.HUNGRY_CLOWN)
		{
			desc +="[AUTO]V/R When this units attack hits if you have a Pale Moon vanguard you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.CURSED_DOCTOR)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.DARK_QUEEN_OF_NIGHTMARELAND)
		{
			desc +="[AUTO]R When an attack hits during the battle that this unit boosted you may Soul Charge (1). If you do return this unit to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.POET_OF_DARKNESS__AMON)
		{
			desc +="[CONT](VC/RC)During your turn if the number of Dark Irregulars in your soul is six or more this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.DECADENT_SUCCUBUS)
		{
			desc +="[AUTO](VC)When another of your Dark Irregulars is placed on (RC) you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.DEATH_ARMY_GUY)
		{
			desc +="[AUTO](RC) When your vanguards drive check reveals a grade 3 Nova Grappler [Stand] this unit.";
		}
		else if(id == CardIdentifier.GODHAWK__ICHIBYOSHI)
		{
			desc +="[AUTO]V At the beginning of your ride phase look at five cards from the top of your deck search for up to one card named 'Goddess of the Crescent Moon Tsukuyomi' from among them ride it and put the rest on the bottom of your deck in any order. If you rode you cannot normal ride during that ride phase.";
		}
		else if(id == CardIdentifier.DEATH_ARMY_LADY)
		{
			desc +="[AUTO](RC)When your vanguards drive check reveals a grade 3 Nova Grappler [Stand] this unit.";
		}
		else if(id == CardIdentifier.DRANGAL)
		{
			desc +="[AUTO](VC)At the beginning of your ride phase look at five cards from the top of your deck search for up to one card named 'Knight of Quests Galahad' from among them ride it and put the rest on the bottom of your deck in any order. If you rode you cannot normal ride during that ride phase.";
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN__BLUE_EYE)
		{
			desc +="[AUTO]R When this unit boosts if the number of Oracle Think Tank in your soul is six or more draw a card choose a card from your hand and put it on the bottom of your deck.";
		}
		else if(id == CardIdentifier.TOYPUGAL)
		{
			desc +="[AUTO](RC)When this unit boosts if the number of grade 3 Royal Paladin vanguards and/or rear-guards you have is two or more this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SAVAGE_WARRIOR)
		{
			desc +="[AUTO]V/R During your turn when another of your Tachikaze rear-guards is put into the drop zone this unit gets Power +1000 until end of turn.";
		}
		else if(id == CardIdentifier.SKULL_JUGGLER)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Pale Moon vanguard you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.HADES_RINGMASTER)
		{
			desc +="[AUTO]V When another Pale Moon rides this unit you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.RAGING_DRAGON__BLASTSAURUS)
		{
			desc +="[AUTO] [Choose a card from your hand and discard it] When this unit is put into the drop zone from Rear-guard Circle you may pay the cost. If you do search your deck for up to one card named 'Raging Dragon Blastsaurus' call it to Rear-guard Circle and shuffle your deck.";
		}
		else if(id == CardIdentifier.VERMILLION_GATEKEEPER)
		{
			desc +="[AUTO]V When another Dark Irregulars rides this unit you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.BARKING_MANTICORE)
		{
			desc +="[CONT](VC)During your turn if you have a card named 'Crimson Beast Tamer' in your soul this unit gets [Power] +3000.[AUTO]When this unit is placed on (VC) draw a card choose a card from your hand and put it into your soul.";
		}
		else if(id == CardIdentifier.ALLURING_SUCCUBUS)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Dark Irregulars vanguard you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.DEMON_OF_ASPIRATION__AMON)
		{
			desc +="[CONT](VC/RC)During your turn if the number of Dark Irregulars in your soul is six or more this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.IMPRISONED_FALLEN_ANGEL__SARAQAEL)
		{
			desc +="[CONT](VC/RC) Restraint (This unit cannot attack.)[ACT](VC/RC)[Soul Blast (3)] This unit loses 'Restraint' until end of turn.\n\n[AUTO](VC)When this unit is boosted by a Dark Irregulars this unit gets Power +5000 until end of that battle.";
		}
		else if(id == CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAIYUSHA)
		{
			desc +="[AUTO](VC)At the beginning of your attack step if this units [Power] is 14000 or greater this unit gets [Critical]+1 until end of that battle.";
		}
		else if(id == CardIdentifier.DUAL_AXE_ARCHDRAGON)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the number of rear-guards your opponent has is two or less this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_GODLY_SPEED__GALAHAD)
		{
			desc +="[CONT](VC/RC)If you do not have a card named 'Knight of Tribulations Galahad' a card named 'Knight of Quests Galahad' and a card named 'Drangal' in your soul this unit gets [Power]-2000.[ACT](VC)[Counter Blast (2)] If the number of Royal Paladin in your soul is six or more this unit gets [Power]+3000/[Critical]+1 until end of turn.";
		}
		else if(id == CardIdentifier.ARCHBIRD)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck.)[AUTO][Choose a Tachikaze from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Tachikaze that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.HADES_HYPNOTIST)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck.)[AUTO][Choose a Pale Moon from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Pale Moon that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.CRIMSON_BEAST_TAMER)
		{
			desc +="[CONT](VC/RC)During your turn if you have a card named 'Crimson Beast Tamer' in your soul this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.MIRROR_DEMON)
		{
			desc +="[AUTO]R [Counter Blast (1) amp Put this unit into your soul] When this units attack hits if you have a Pale Moon vanguard you may pay the cost. If you do choose a Pale Moon other than a card named 'Mirror Demon' from your soul and call it to Rear-guard Circle.";
		}
		else if(id == CardIdentifier.DOREEN_THE_THRUSTER)
		{
			desc +="[AUTO](RC)During your main phase when a card is put into your soul if you have a Dark Irregulars vanguard this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.DUSK_ILLUSIONIST__ROBERT)
		{
			desc +="[AUTO](VC)At the beginning of your main phase Soul Charge (1) look at the top card of your deck and put that card on the top or the bottom of your deck.\n\n[ACT](VC/RC)[Soul Blast (8) amp Counter Blast (5)] Put all of your opponents grade 1 or less rear-guards into his or her soul.";
		}
		else if(id == CardIdentifier.GWYNN_THE_RIPPER)
		{
			desc +="[AUTO][Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have a Dark Irregulars vanguard you may pay the cost. If you do choose one of your opponents grade 2 or less rear-guards and retire it.";
		}
		else if(id == CardIdentifier.MARCH_RABBIT_OF_NIGHTMARELAND)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Dark Irregulars from your hand and discard it] When this unit is placed on Guardian Circle you may pay the cost. If you do choose one of your Dark Irregulars that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.EDEL_ROSE)
		{
			desc +="[ACT](VC) [Counter Blast (2)] If you have a card named 'Werwolf Sieger' in your soul this unit gets [Power] +5000/[Critical] +1 until end of turn.\n\n[ACT](Hand) [Reveal this card to your opponent and put it on top of your deck] Search your deck for up to one card named 'Werwolf Sieger' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.ULTIMATE_LIFEFORM__COSMO_LORD)
		{
			desc +="[ACT](VC)[Choose one of your Nova Grappler rear-guards and [Rest] it] This unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.GODDESS_OF_THE_HALF_MOON__TSUKUYOMI)
		{
			desc +="[AUTO] When this unit is placed on Vanguard Circle if you have a card named 'Goddess of the Crescent Moon Tsukuyomi' and a card named 'Godhawk Ichibyoshi' in your soul you may Soul Charge (2). AUTOV At the beginning of your ride phase look at five cards from the top of your deck search for up to one card named 'Goddess of the Full Moon Tsukuyomi' from among them ride it and put the rest on the bottom of your deck in any order. If you rode you cannot normal ride during that ride phase. ";
		}
		else if(id == CardIdentifier.GODDESS_OF_THE_FULL_MOON__TSUKUYOMI)
		{
			desc +="[CONT](VC/RC)If you do not have a card named 'Goddess of the Half Moon Tsukuyomi' a card named 'Goddess of the Crescent Moon Tsukuyomi' and a card named 'Godhawk Ichibyoshi' in your soul this unit gets [Power]-2000.[ACT](VC)[Counter Blast (2)] If the number of Oracle Think Tank in your soul is six or more draw two cards choose a card from your hand and put it into your soul.";
		}
		else if(id == CardIdentifier.SWORDSMAN_OF_THE_EXPLOSIVE_FLAMES__PALAMEDES)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the number of grade 3 Royal Paladin vanguards and/or rear-guards you have is two or more this unit gets Power +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.RAVENOUS_DRAGON__GIGAREX)
		{
			desc +="[AUTO]V/R During your turn when another of your Tachikaze rear-guards is put into the drop zone this unit gets Power +1000 until end of turn.";
		}
		else if(id == CardIdentifier.NIGHTMARE_DOLL__ALICE)
		{
			desc +="[AUTO](RC)[Counter Blast (1) amp Put this unit into your soul] When this units attack hits if you have a Pale Moon vanguard you may pay the cost. If you do choose a Pale Moon other than a card named 'Nightmare Doll Alice' from your soul and call it to (RC).";
		}
		else if(id == CardIdentifier.DEMON_WORLD_MARQUIS__AMON)
		{
			desc +="[CONT](VC)During your turn this unit gets [Power]+1000 for each Dark Irregulars in your soul.[ACT](VC)[Counter Blast (1) amp Choose one of your Dark Irregulars rear-guards and put it into your soul] Your opponent chooses one of his or her rear-guards and retires it.";
		}
		else if(id == CardIdentifier.STIL_VAMPIR)
		{
			desc +="[AUTO](VC)At the beginning of your main phase Soul Charge (1) and this unit gets [Power]+2000 until end of turn.\n\n[ACT](VC/RC)[Soul Blast (8) amp Counter Blast (5)] Choose one of your opponents rear-guards and put that unit on your opponents (VC) and at the beginning of the end phase of that turn your opponent chooses a card from his or her soul and rides it.";
		}
		else if(id == CardIdentifier.CIRCLE_MAGUS)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have an Oracle Think Tank vanguard look at the top card of your deck and put that card on top of your deck.";
		}
		else if(id == CardIdentifier.BLOODY_CALF)
		{
			desc +="[AUTO][Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have a Dark Irregulars vanguard you may pay the cost. If you do choose one of your opponents grade 1 or less rear-guards and retire it.";
		}
		else if(id == CardIdentifier.MASKED_POLICE__GRANDER)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a Dimension Police vanguard your vanguard gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.FLAME_EDGE_DRAGON)
		{
			desc +="[AUTO](VC/RC)When this units attack hits if you have a Kagero vanguard you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.DRAGON_DANCER__LOURDES)
		{
			desc +="[AUTO]V/R When this unit attacks if the number of rear-guards your opponent has is two or less this unit gets Power +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.FAITHFUL_ANGEL)
		{
			desc +="[AUTO]V/R When this unit attacks if the number of Oracle Think Tank in your soul is six or more draw a card choose a card from your hand and put it on the bottom of your deck.";
		}
		else if(id == CardIdentifier.GODDESS_OF_THE_CRESCENT_MOON__TSUKUYOMI)
		{
			desc +="[AUTO]V At the beginning of your ride phase look at five cards from the top of your deck search for up to one card named 'Goddess of the Half Moon Tsukuyomi' from among them ride it and put the rest on the bottom of your deck in any order. If you rode you cannot normal ride during that ride phase.";
		}
		else if(id == CardIdentifier.BATTLE_SISTER__VANILLA)
		{
			desc +="[AUTO] When this unit is placed on Guardian Circle if the number of Oracle Think Tank in your soul is six or more this unit gets Shield +5000 until end of that battle.";
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN__RED_EYE)
		{
			desc +="[AUTO](VC/RC)When this units attack hits if you have an Oracle Think Tank vanguard you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.SECRETARY_ANGEL)
		{
			desc +="[AUTO]V/R When this unit attacks if the number of Oracle Think Tank in your soul is six or more draw a card choose a card from your hand and put it on the bottom of your deck.";
		}
		else if(id == CardIdentifier.BORGAL)
		{
			desc +="[CONT](VC/RC)During your turn if the number of Royal Paladin in your soul is six or more this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_QUESTS__GALAHAD)
		{
			desc +="[AUTO](VC)At the beginning of your ride phase look at five cards from the top of your deck search for up to one card named 'Knight of Tribulations Galahad' from among them ride it and put the rest on the bottom of your deck in any order. If you rode you cannot normal ride during that ride phase.";
		}
		else if(id == CardIdentifier.SWORDSMAN_OF_THE_BLAZE__PALAMEDES)
		{
			desc +="[AUTO]V/R When this unit attacks if the number of grade 3 Royal Paladin vanguards and/or rear-guards you have is two or more this unit gets Power +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.GIGANTECH_DOZER)
		{
			desc +="CONTV/R During your turn if the number of Royal Paladin in your soul is six or more this unit gets Power +3000.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_TRIBULATIONS__GALAHAD)
		{
			desc +="[AUTO] When a card named 'Knight of Godly Speed Galahad' rides this unit you may Soul Charge (2). AUTOV At the beginning of your ride phase look at five cards from the top of your deck search for up to one card named 'Knight of Godly Speed Galahad' from among them ride it and put the rest on the bottom of your deck in any order. If you rode you cannot normal ride during that ride phase. ";
		}
		else if(id == CardIdentifier.BLACK_CANNON_TIGER)
		{
			desc +="[AUTO](RC)When an attack hits during the battle that this unit boosted you may Soul Charge (1). If you do return this unit to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.MIDNIGHT_BUNNY)
		{
			desc +="[AUTO](RC)[Counter Blast (1) amp Put this unit into your soul] When an attack hits during the battle that this unit boosted if you have a Pale Moon vanguard you may pay the cost. If you do choose a Pale Moon other than a card named 'Midnight Bunny' from your soul and call it to (RC).";
		}
		else if(id == CardIdentifier.SAVAGE_SHAMAN)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.TURQUOISE_BEAST_TAMER)
		{
			desc +="[CONT](VC/RC)During your turn if you have a card named 'Crimson Beast Tamer' in your soul this unit gets Power +3000.";
		}
		else if(id == CardIdentifier.ENIGMAN_RIPPLE)
		{
			desc +="[CONT](VC)If you have 'Enigman Flow' in your soul this unit gets [Power]+2000.[AUTO][Choose a grade 3 Dimension Police from your hand and discard it] When this unit is placed on (RC) you may pay the cost. If you do search your deck for up to one card named 'Enigman Storm' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.GLORY_MAKER)
		{
			desc +="[AUTO](RC)When this unit boosts a Dimension Police vanguard if the number of cards in your damage zone is four or more the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.ENIGROID_COMRADE)
		{
			desc +="[CONT](VC/RC)If you do not have a unit named 'Enigman Storm' or a unit named 'Enigman Wave' on your (VC) this unit gets [Power]-5000.[AUTO](VC/RC)When this unit attacks this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.ABYSS_HEALER)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.BLASTER_JAVELIN)
		{
			desc +="[CONT](VC)If you have a card named 'Fullbau' in your soul this unit gets [Power]+2000.[AUTO][Choose a Grade 3 Shadow Paladin from your hand and discard it] When this unit is placed on (RC) you may pay the cost. If you do search your deck for up to one card named 'Phantom Blaster Dragon' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.ENIGMAN_SHINE)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard choose one of your Dimension Police and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.DORANBAU)
		{
			desc +="[AUTO](RC)When this unit boosts a unit named 'Blaster Dark' the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.WITCH_OF_NOSTRUM__ARIANRHOD)
		{
			desc +="[ACT](VC/RC)[Rest] this unit amp Choose a card from your hand and discard it] Draw a card.";
		}
		else if(id == CardIdentifier.DEMON_WORLD_CASTLE__DONNERSCHLAG)
		{
			desc +="[CONT](VC/RC)If you do not have a unit named 'Phantom Blaster Dragon' or a unit named 'Blaster Dark' on your (VC) this unit gets [Power]-5000.[AUTO](VC/RC)When this unit attacks this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.DEMON_WORLD_CASTLE__FATALITA)
		{
			desc +="[AUTO]When this unit intercepts if you have a Shadow Paladin vanguard this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.BEAST_KNIGHT__GARMORE)
		{
			desc +="[AUTO][Choose a Royal Paladin from your hand and discard it] When this unit is placed on (VC) or (RC) if you have a Royal Paladin vanguard you may pay the cost. If you do search your deck for up to one card named 'Snogal' or 'Brugal' call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.ARMORED_FAIRY__SHUBIELA)
		{
			desc +="[AUTO](VC/RC)[Soul Blast(3)] When this units attack hits if you have a Nova Grappler vanguard you may pay the cost. If you do draw a card.\n\n[AUTO](VC) When this unit is boosted by a Nova Grappler this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BLAUJUNGER)
		{
			desc +="[AUTO]When a card named 'Blaupanzer' rides this unit search your deck for up to one card named 'Blaukluger' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.AMBER_DRAGON__DAWN)
		{
			desc +="[AUTO]When a card named 'Amber Dragon Daylight' rides this unit search your deck for up to one card named 'Amber Dragon Dusk' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.WATER_GANG)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits if you have a Megacolony vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.GLOOM_FLYMAN)
		{
			desc +="[AUTO]When this unit is placed on (GC) if you have a Megacolony vanguard choose one of your opponents grade 0 rear-guards and [Rest] it.";
		}
		else if(id == CardIdentifier.VIOLENT_VESPER)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) reveal the top card of your deck. If the revealed card is a Megacolony call it to (RC) and if it is not shuffle your deck.";
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__RAOPIA)
		{
			desc +="[AUTO](RC)When this unit boosts a Kagero vanguard if the number of rear-guards your opponent has is two or less the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.LARVA_MUTANT__GIRAFFA)
		{
			desc +="[AUTO]When a card named 'Pupa Mutant Giraffa' rides this unit search your deck for up to one card named 'Elite Mutant Giraffa' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.ENIGMAN_FLOW)
		{
			desc +="[AUTO]When a card named 'Enigman Ripple' rides this unit search your deck for up to one card named 'Enigman Wave' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.DEATH_WARDEN_ANT_LION)
		{
			desc +="[AUTO](VC)At the beginning of your main phase Soul Charge (1) and this unit gets [Power]+2000 until end of turn.\n\n[ACT](VC/RC)[Soul Blast (8) amp Counter Blast (5)] All of your opponents rear-guards cannot [Stand] during your opponents next stand phase.";
		}
		else if(id == CardIdentifier.COSMO_ROAR)
		{
			desc +="[ACT](RC)[Rest] this unit] Choose another of your Dimension Police and that unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.PLATINUM_ACE)
		{
			desc +="[AUTO](VC)At the beginning of your attack step if this units [Power] is 13000 or greater this unit gets [Critical]+1 until end of that battle.";
		}
		else if(id == CardIdentifier.ENIGMAN_RAIN)
		{
			desc +="[AUTO](VC)At the beginning of your attack step if this units [Power] is 12000 or greater this unit gets '\n\n[AUTO](VC)When this units attack hits a vanguard choose one of your rear-guards and [Stand] it.' until end of that battle.";
		}
		else if(id == CardIdentifier.FULLBAU)
		{
			desc +="[AUTO]When a card named 'Blaster Javelin' rides this unit search your deck for up to one card named 'Blaster Dark' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.BLASTER_DARK)
		{
			desc +="[CONT](VC)If you have a card named 'Blaster Javelin' in your soul this unit gets [Power]+1000.[AUTO][Counter Blast (2)] When this unit is placed on (VC) you may pay the cost. If you do choose one of your opponents rear-guards and retire it.";
		}
		else if(id == CardIdentifier.SILVER_SPEAR_DEMON__GUSION)
		{
			desc +="[ACT](VC/RC)[Counter Blast (2)] This unit gets [Power]+4000 until end of turn.";
		}
		else if(id == CardIdentifier.DARK_MAGE__BADHABH_CAAR)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) reveal the top card of your deck. If the revealed card is a Shadow Paladin call it to (RC) and if it is not shuffle your deck.";
		}
		else if(id == CardIdentifier.FANG_OF_LIGHT__GARMORE)
		{
			desc +="[CONT](VC)During your turn this unit gets [Power]+1000 for each unit named 'Snogal' or 'Brugal' on your (RC). [AUTO][Choose a Royal Paladin from your hand and discard it] When this unit is placed on (VC) or (RC) if you have a Royal Paladin vanguard you may pay the cost. If you do search your deck for up to one card named 'Snogal' or 'Brugal' call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.AMBER_DRAGON__DUSK)
		{
			desc +="[CONT](VC)If you have a card named 'Amber Dragon Daylight' in your soul this unit gets [Power]+1000.[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.BLAUKLUGER)
		{
			desc +="[CONT](VC)If you have a card named 'Blaupanzer' in your soul this unit gets [Power]+1000.[AUTO](VC)When this units attack hits a vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.COMMANDER_LAUREL)
		{
			desc +="[AUTO](RC)[Choose four of your Dimension Police rear-guards and [Rest] them] When your Dimension Police vanguards attack hits you may pay the cost. If you do choose one of your vanguards and [Stand] it.";
		}
		else if(id == CardIdentifier.ELITE_MUTANT__GIRAFFA)
		{
			desc +="[CONT](VC)If you have a card named 'Pupa Mutant Giraffa' in your soul this unit gets [Power]+1000.[AUTO](VC)When this units attack hits a vanguard choose one of your opponents rear-guards and that unit cannot [Stand] during your opponents next stand phase.";
		}
		else if(id == CardIdentifier.PARALYZE_MADONNA)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck.)[AUTO][Choose a Megacolony from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Megacolony and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.DIAMOND_ACE)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Dimension Police from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Dimension Police that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.COSMO_BEAK)
		{
			desc +="[AUTO][Counter Blast (2)] When this unit is placed on (RC) you may pay the cost. If you do choose another of your Dimension Police and that unit gets [Power]+4000 until end of turn.";
		}
		else if(id == CardIdentifier.ENIGMAN_WAVE)
		{
			desc +="[CONT](VC)If you have a card named 'Enigman Ripple' in your soul this unit gets [Power]+1000.[AUTO](VC)At the beginning of your attack step if this units [Power] is 14000 or greater this unit gets '\n\n[AUTO](VC)When this units attack hits a vanguard draw a card.' until end of that battle.";
		}
		else if(id == CardIdentifier.DARK_SHIELD__MAC_LIR)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Shadow Paladin from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Shadow Paladin that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.DARK_METAL_DRAGON)
		{
			desc +="[AUTO](VC)When this units drive check reveals a Shadow Paladin this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.GURURUBAU)
		{
			desc +="[AUTO](RC)When this unit attacks a vanguard if you have a Shadow Paladin vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.EVIL_ARMOR_GENERAL__GIRAFFA)
		{
			desc +="[CONT](VC)If you have a card named 'Elite Mutant Giraffa' in your soul this unit gets [Power]+1000.[AUTO](VC)[Counter Blast (2) amp Choose two of your Megacolony rear-guards and retire them] When this units attack hits a vanguard you may pay the cost. If you do choose up to two of your opponents grade 1 or less rear-guards and retire them.";
		}
		else if(id == CardIdentifier.AMBER_DRAGON__ECLIPSE)
		{
			desc +="[CONT](VC)If you have a card named 'Amber Dragon Dusk' in your soul this unit gets [Power]+1000. [ACT](VC)[Counter Blast (2)] This unit gets '\n\n[AUTO](VC)When this units attack hits a vanguard choose up to two of your opponents rear-guards and retire them.' until end of turn.";
		}
		else if(id == CardIdentifier.STERN_BLAUKLUGER)
		{
			desc +="[CONT](VC)If you have a card named 'Blaukluger' in your soul this unit gets [Power]+1000.[AUTO](VC)[Counter Blast (2) amp Choose two Nova Grappler from your hand and discard them] When this units attack hits a vanguard you may pay the cost. If you do [Stand] all of your units in the same column as this unit and this unit loses 'Twin Drive' until end of turn.";
		}
		else if(id == CardIdentifier.HEATNAIL_SALAMANDER)
		{
			desc +="[AUTO](RC)When an attack hits a vanguard during the battle that this unit boosted a Kagero you may choose one of your opponents grade 1 rear-guards and retire it. If you do at the beginning of the end phase of that turn return this unit to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.SKULL_WITCH__NEMAIN)
		{
			desc +="[AUTO][Counter Blast (1) amp Choose a Shadow Paladin from your hand and discard it] When this unit is placed on (RC) if you have a Shadow Paladin vanguard you may pay the cost. If you do draw two cards.";
		}
		else if(id == CardIdentifier.ENIGMAN_STORM)
		{
			desc +="[CONT](VC)If you have a card named 'Enigman Wave' in your soul this unit gets [Power]+1000.[AUTO](VC)At the beginning of your attack step if this units [Power] is 15000 or greater this unit gets [Critical]+1 until end of that battle.";
		}
		else if(id == CardIdentifier.GRAPPLE_MANIA)
		{
			desc +="[AUTO](RC)When an attack hits a vanguard during the battle that this unit boosted a Nova Grappler you may choose a card from your damage zone and turn it face up. If you do at the beginning of the end phase of that turn return this unit to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.SNOGAL)
		{
			desc +="[CONT](RC)During your turn this unit gets [Power]+1000 for each other unit named 'Snogal' on your (VC) or (RC).";
		}
		else if(id == CardIdentifier.TOOLKIT_BOY)
		{
			desc +="[AUTO](RC)When an attack hits a vanguard during the battle that this unit boosted a Nova Grappler vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.DANCING_WOLF)
		{
			desc +="[AUTO](RC)During your battle phase when this unit becomes [Stand] this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.BLAUPANZER)
		{
			desc +="[CONT](VC)If you have a card named 'Blaujunger' in your soul this unit gets [Power]+2000.[AUTO][Choose a grade 3 Nova Grappler from your hand and discard it] When this unit is placed on (RC) you may pay the cost. If you do search your deck for up to one card named 'Stern Blaukluger' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.FLAME_SEED_SALAMANDER)
		{
			desc +="[AUTO](RC)When an attack hits a vanguard during the battle that this unit boosted a Kagero you may choose one of your opponents grade 0 rear-guards and retire it. If you do at the beginning of the end phase of that turn return this unit to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.EISENKUGEL)
		{
			desc +="[CONT](VC/RC)If you do not have a unit named 'Stern Blaukluger' or a unit named 'Blaukluger' on your (VC) this unit gets [Power]-5000.[AUTO](VC/RC)When this unit attacks this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.AMBER_DRAGON__DAYLIGHT)
		{
			desc +="[CONT](VC)If you have a card named 'Amber Dragon Dawn' in your soul this unit gets [Power]+2000.[AUTO][Choose a grade 3 Kagero from your hand and discard it] When this unit is placed on (RC) you may pay the cost. If you do search your deck for up to one card named 'Amber Dragon Eclipse' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.LAVA_ARM_DRAGON)
		{
			desc +="[CONT](VC/RC)If you do not have a unit named 'Amber Dragon Eclipse' or a unit named 'Amber Dragon Dusk' on your (VC) this unit gets [Power]-5000.[AUTO](VC/RC)When this unit attacks this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.MEDICAL_BATTLER__RANPLI)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.GARNET_DRAGON__FLASH)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard choose one of your Kagero and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.STEALTH_MILLIPEDE)
		{
			desc +="[AUTO](RC)When this unit boosts a Megacolony vanguard if all of your opponents vanguards and rear-guards are [Rest] the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.TAIL_JOE)
		{
			desc +="[CONT](VC/RC)During your turn if all of your opponents vanguards and rear-guards are [Rest] this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.PUPA_MUTANT__GIRAFFA)
		{
			desc +="[CONT](VC)If you have a card named 'Larva Mutant Giraffa' in your soul this unit gets [Power]+2000.[AUTO][Choose a Grade 3 Megacolony from your hand and discard it] When this unit is placed on (RC) you may pay the cost. If you do search your deck for up to one card named 'Evil Armor General Giraffa' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.JUSTICE_ROSE)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.IRONCUTTER_BEETLE)
		{
			desc +="[CONT](VC/RC)If you do not have a unit named 'Evil Armor General Giraffa' or a unit named 'Elite Mutant Giraffa' on your (VC) this unit gets [Power]-5000.[AUTO](VC/RC)When this unit attacks this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.DARKNESS_MAIDEN__MACHA)
		{
			desc +="[AUTO][Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have a Shadow Paladin vanguard you may pay the cost. If you do search your deck for up to one grade 1 or less Shadow Paladin call it to (RC) in the same column as this unit and shuffle your deck.";
		}
		else if(id == CardIdentifier.BATTLE_SISTER__FROMAGE)
{
desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (3)] If you have four or more rear-guards with 'Battle Sister' in its card name draw two cards.[CONT](VC)During your turn if you have four or more rear-guards with 'Battle Sister' in its card name this unit gets [Power]+4000.";
}
else if(id == CardIdentifier.BATTLE_SISTER__MACARON)
{
desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Battle Sister' in its card name this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.BATTLE_SISTER__OMELET)
{
desc +="[AUTO](RC)When this unit attacks if you have an Oracle Think Tank vanguard and you do not have any cards in your soul this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.WEATHER_FORECASTER__MISS_MIST)
{
desc +="[AUTO]When this unit is placed on (GC) if it is during the battle in which your opponents grade 2 or less vanguard attacked choose one of your Oracle Think Tank that is being attacked and that unit cannot be hit until end of that battle.";
}
else if(id == CardIdentifier.BATTLE_SISTER__WAFFLE)
{
desc +="[AUTO]When another Oracle Think Tank rides this unit you may call this card to (RC).[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at up to three cards from the top of your deck search for up to one card with 'Battle Sister' in its card name from among them call it to (RC) shuffle your deck and that unit gets [Power]+2000 until end of turn.";
}
else if(id == CardIdentifier.BATTLE_SISTER__CHAI)
{
desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
}
		else if(id == CardIdentifier.ETERNAL_IDOL__PACIFICA)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (3)] When this unit attacks a vanguard you may pay the cost. If you do choose up to two of your Bermuda Triangle rear-guards return them to your hand search your deck for up to one Bermuda Triangle call it to (RC) and shuffle your deck.[CONT](VC)If you have a card named 'Top Idol Pacifica' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
else if(id == CardIdentifier.PR___ISM_PROMISE__LABRADOR)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard you may choose up to three cards with 'PRISM' in its card name from your hand and call them to separate open (RC). If you called three cards this unit gets [Power]+10000/[Critical]+1 until end of that battle.[ACT](VC)[Counter Blast (1)-card with 'PRISM' in its card name] Choose one of your rear-guards with 'PRISM' in its card name and return it to your hand.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
else if(id == CardIdentifier.PR___ISM_IMAGE__VERT)
{
desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Bermuda Triangle rides this unit draw a card choose up to two of your Bermuda Triangle rear-guards return them to your hand choose your vanguard and that unit gets [Power]+10000 until end of turn.[CONT](VC)During your turn if the number of Bermuda Triangle rear-guards you have is four or more this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
}
else if(id == CardIdentifier.AURORA_STAR__CORAL)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2)] When this unit attacks a vanguard you may pay the cost. If you do Soul Charge (1) choose one of your Bermuda Triangle rear-guards return it to your hand and this unit gets [Power]+5000 until end of that battle.[CONT](VC)If you have a card named 'Shiny Star Coral' in your soul this unit gets [Power]+1000.";
}
else if(id == CardIdentifier.PR___ISM_PROMISE__CELTIC)
{
desc +="[AUTO][Soul Blast (1)] When this unit is returned to your hand from (RC) you may pay the cost. If you do choose another of your Bermuda Triangle and that unit gets [Power]+4000 until end of turn.";
}
else if(id == CardIdentifier.PR___ISM_IMAGE__CLEAR)
{
desc +="[AUTO][Soul Blast (1)] When this unit is returned to your hand from (RC) you may pay the cost. If you do choose another of your Bermuda Triangle and that unit gets [Power]+4000 until end of turn.";
}
else if(id == CardIdentifier.SHINING_SINGER__IONIA)
{
desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.[AUTO](RC)When this unit attacks a vanguard if you have a Bermuda Triangle vanguard this unit gets [Power]+2000 until end of that battle.";
}
else if(id == CardIdentifier.PR___ISM_SMILE__LIGURIAN)
{
desc +="ENG";
}
else if(id == CardIdentifier.SHINY_STAR__CORAL)
{
desc +="[CONT](VC) If you have a card named 'Fresh Star Coral' in your soul this unit gets [Power]+1000.[AUTO](VC) When this units attack hits a vanguard choose up to one of your Bermuda Triangle rear-guards in the front row return it to your hand and if you have a card named 'Fresh Star Coral' in your soul choose up to one of your Bermuda Triangle rear-guards in the back row and return it to your hand.";
}
else if(id == CardIdentifier.PR___ISM_ROMANCE__LUMIERE)
{
desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'PRISM' in its card name this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.SWEETS_HARMONY__MONA)
{
desc +="[AUTO][Counter Blast (1)] When this unit is placed on (RC) if you have a Bermuda Triangle vanguard you may pay the cost. If you do choose another of your Bermuda Triangle rear-guards and return it to your hand.";
}
else if(id == CardIdentifier.PR___ISM_ROMANCE__MERCURE)
{
desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'PRISM' in its card name this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.MIRROR_DIVA__BISCAYNE)
{
desc +="[AUTO][Soul Blast (1)] When this unit is placed on (RC) if you have a Bermuda Triangle vanguard you may pay the cost. If you do look at up to seven cards from the top of your deck search for up to one card named 'Mirror Diva Biscayne' from among them reveal it to your opponent put it into your hand and shuffle your deck.";
}
else if(id == CardIdentifier.ANGELIC_STAR__CORAL)
{
desc +="[AUTO] When a card named 'Fresh Star Coral' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Aurora Star Coral' or 'Shiny Star Coral' from among them reveal it to your opponent put it into your hand and shuffle your deck.[AUTO] When a Bermuda Triangle not named 'Fresh Star Coral' rides this unit you may call this unit to (RC).";
}
else if(id == CardIdentifier.DANCING_FAN_PRINCESS__MINATO)
{
desc +="[AUTO](RC)When your grade 3 Bermuda Triangle is placed on (VC) this unit gets [Power]+10000 until the end of turn.";
}
else if(id == CardIdentifier.PR___ISM_ROMANCE__ETOILE)
{
desc +="[AUTO](VC/RC) When this unit is boosted by a Bermuda Triangle this unit gets [Power]+2000 until end of that battle.";
}
else if(id == CardIdentifier.INTELLI_BEAUTY__LOIRE)
{
desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Bermuda Triangle vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
}
else if(id == CardIdentifier.PR___ISM_IMAGE__ROSA)
{
desc +="[AUTO](VC/RC)When this unit attacks if you have a Bermuda Triangle vanguard or rear-guard that has Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.PR___ISM_SMILE__SCOTIA)
{
desc +="[AUTO](VC/RC)[Counter Blast (1)-Bermuda Triangle] When this unit attacks if you have a Bermuda Triangle vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
}
else if(id == CardIdentifier.FRESH_STAR__CORAL)
{
desc +="[CONT](VC)If you have a card named 'Angelic Star Coral' in your soul this unit gets [Power]+1000.[AUTO]When a grade 2 Bermuda Triangle not named 'Shiny Star Coral' rides this unit if you have a card named 'Angelic Star Coral' in your soul look at up to seven cards from the top of your deck search for up to one card named 'Shiny Star Coral' from among them ride it and shuffle your deck.";
}
else if(id == CardIdentifier.PR___ISM_PROMISE__LEYTE)
{
desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit named 'PRISM-Promise Labrador' you may pay the cost. If you do the boosted unit gets [Power]+5000 until end of that battle.";
}
else if(id == CardIdentifier.MASCOT_LADY__ORIA)
{
desc +="[AUTO](RC)[Counter Blast(1)] When this unit boosts a Bermuda Triangle that has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.LIBRARY_MADONNA__RION)
{
desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Bermuda Triangle vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
}
else if(id == CardIdentifier.DOLPHIN_FRIEND__PLAGE)
{
desc +="[AUTO]When this unit is put into the drop zone from (GC) put this unit into your soul.";
}
else if(id == CardIdentifier.PR___ISM_SMILE__CORO)
{
desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))[AUTO](RC)When another of your Bermuda Triangle is returned to your hand from (RC) you may return this unit to your hand.";
}
else if(id == CardIdentifier.COSTUME_CHANGE__ALK)
{
desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Bermuda Triangle with Limit Break 4 you may pay the cost. If you do draw a card.";
}
else if(id == CardIdentifier.PR___ISM_MIRACLE__TIMOR)
{
desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
}
else if(id == CardIdentifier.HEARTFUL_ALE__FUNDY)
{
desc +="[ACT](RC)[Put this unit into your soul] Choose up to one of your Bermuda Triangle and that unit gets [Power]+3000 until end of turn.";
}
else if(id == CardIdentifier.PR___ISM_MIRACLE__IRISH)
{
desc +="[AUTO][Soul Blast (1)] When this unit is returned to your hand from (RC) you may pay the cost. If you do choose another of your Bermuda Triangle and that unit gets [Power]+4000 until end of turn.";
}
		else if(id == CardIdentifier.PHANTOM_BLASTER_DRAGON)
		{
			desc +="[CONT](VC)If you have a card named 'Blaster Dark' in your soul this unit gets [Power]+1000.[ACT](VC)[Counter Blast (2) amp Choose three of your Shadow Paladin rear-guards and retire them] This unit gets [Power]+10000/[Critical]+1 until end of turn.";
		}
		else if(id == CardIdentifier.BRUGAL)
		{
			desc +="[CONT](RC)During your turn this unit gets [Power]+1000 for each other unit named 'Brugal' on your (VC) or (RC).[AUTO]When another Royal Paladin rides this unit you may call this card to (RC).";
		}
		else if(id == CardIdentifier.CURSED_LANCER)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard if you have a Shadow Paladin vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.MEGACOLONY_BATTLER_B)
		{
			desc +="[AUTO](RC)[Counter Blast(1)] When an attack hits a vanguard during the battle that this unit boosted a Megacolony you may pay the cost. If you do choose one of your opponents rear-guards and that unit cannot [Stand] during your opponents next stand phase.";
		}
		else if(id == CardIdentifier.GUIDE_DOLPHIN)
		{
			desc +="[ACT](RC)[Put this unit into your soul] Choose up to one of your Dimension Police and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.DARK_SOUL_CONDUCTOR)
		{
			desc +="[AUTO] When this unit is put into the drop zone from Guardian Circle if you have a Dark Irregulars vanguard you may Soul Charge (2).";
		}
		else if(id == CardIdentifier.HYSTERIC_SHIRLEY)
		{
			desc +="[ACT][R] [Move this unit to soul] If you have a Dark Irregulars vanguard you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.BIG_LEAGUE_BEAR)
		{
			desc +="[AUTO]When this unit is put into the drop zone from (GC) if you have a Pale Moon vanguard you may Soul Charge (2).";
		}
		else if(id == CardIdentifier.MADCAP_MARIONETTE)
		{
			desc +="[AUTO] When this unit is placed on Vanguard Circle or Rear-guard Circle if you have a Pale Moon Vanguard choose up to one Pale Moon from your hand and put it into your soul.";
		}
		else if(id == CardIdentifier.DOOM_BRINGER_GRIFFIN)
		{
			desc +="[ACT](RC)[Counter Blast (1) amp Choose two of your Kager rear-guards and retire them] Search your deck for up to one card named 'Dragonic Overlord the End' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.TOP_GUN)
		{
			desc +="[AUTO](VC) When your Nova Grappler rear-guard becomes [Rest] this unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAILADY)
		{
			desc +="[AUTO](RC)When this units attack hits a vanguard choose one of your Dimension Police and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.ANTHRODROID)
		{
			desc +="[ACT](RC)[Counter Blast (1)] If you have a Nova Grappler vanguard [Stand] this unit.";
		}
		else if(id == CardIdentifier.WHITE_HARE_OF_INABA)
		{
			desc +="[AUTO] When this unit is placed on Vanguard Circle or Rear-guard Circle if you have a Oracle Think Tank vanguard choose up to 1 Oracle Think Tank from your hand and put it into your soul.";
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__TAGITSUHIME)
		{
			desc +="[AUTO](RC) When this unit attacks If the number of Oracle Think Tank in your soul is six or more this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.PHANTOM_BRINGER_DEMON)
		{
			desc +="[ACT](RC)[Counter Blast (1) amp Choose two of your Shadow Paladin rear-guards and retire them.] Search your deck for up to one card named 'Phantom Blaster Overlord' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.DREAM_PAINTER)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Royal Paladin vanguard choose up to one Royal Paladin from your hand and put it into your soul.";
		}
		else if(id == CardIdentifier.SILENT_SAGE__SHARON)
		{
			desc +="[ACT](RC)[Put this unit into your soul] Choose up to one of your Royal Paladin and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.NIGHTMARE_PAINTER)
		{
			desc +="[AUTO] When this unit is placed on Vanguard Circle or Rear-guard Circle if you have a Shadow Paladin vanguard choose up to 1 Shadow Paladin from your hand and put it into your soul.";
		}
		else if(id == CardIdentifier.POWERFUL_SAGE__BAIRON)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard choose one of your Royal Paladin and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.STEALTH_FIEND__DART_SPIDER)
		{
			desc +="[ACT](RC)[Put this unit into your soul] If you have a Murakumo vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__WHITE_MANE)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard if you have a Murakumo vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__LEAF_RACCOON)
		{
			desc +="[AUTO](RC) When this unit boosts a Murakumo vanguard if the number of cards in your hand is more than your opponents the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.SWEET_HONEY)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.WATERING_ELF)
		{
			desc +="[ACT](RC)[Put this unit into your soul] Choose up to one of your Neo Nectar and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.LILY_KNIGHT_OF_THE_VALLEY)
		{
			desc +="[AUTO](RC) When this unit boosts a card named 'Iris Knight' the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.LADY_OF_THE_SUNLIGHT_FOREST)
		{
			desc +="[ACT]V/R [Rest this unit amp Choose a card from your hand and discard it] Draw a card.";
		}
		else if(id == CardIdentifier.BLADE_SEED_SQUIRE)
		{
			desc +="[AUTO](RC)[Put this unit on top of your deck] When this units attack hits a vanguard if you have a Neo Nectar vanguard you may pay the cost. If you do search your deck for up to one card named 'Knight of Verdure Gene' call it to (RC) as [Rest] and shuffle your deck.";
		}
		else if(id == CardIdentifier.CARAMEL_POPCORN)
		{
			desc +="[ACT]V/R [Counter Blast (1)] This unit gets Power +1000 until end of turn.";
		}
		else if(id == CardIdentifier.COLOSSAL_WINGS__SIMURGH)
		{
			desc +="[AUTO] When this unit intercepts if you have a Neo Nectar vanguard this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.SPIRITUAL_TREE_SAGE__IRMINSUL)
		{
			desc +="[AUTO] When this Unit is placed on the Vanguard or Rearguard-Circle reveal the card on top of your deck. If that card is a Grade 1 or Grade 2 Neo Nectar call that card to a Rearguard-Circle. If it is not shuffle your deck.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_VERDURE__GENE)
		{
			desc +="[AUTO] R [Put this unit on top of your deck] When this units attack hits a vanguard if you have a Neo Nectar vanguard you may pay the cost. If you do search your deck for up to one card named 'Knight of Harvest Gene' call it to Rear-guard Circle in Rest and shuffle your deck.";
		}
		else if(id == CardIdentifier.MAGICAL_POLICE__QUILT)
		{
			desc +="[AUTO] R [Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.DEVIL_CHILD)
		{
			desc +="[AUTO](RC)When this unit boosts a Dark Irregulars vanguard if the number of Dark Irregulars in your soul is six or more the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.FLAME_OF_PROMISE__AERMO)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit with 'Overlord' in its card name you may pay the cost. If you do the boosted unit gets [Power]+6000 until end of that battle.";
		}
		else if(id == CardIdentifier.BURNING_HORN_DRAGON)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Overlord' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.APOCALYPSE_BAT)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a card with 'Blaster' in its card name you may pay the cost. If you do the boosted unit gets [Power]+6000 until end of that battle.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__EVIL_FERRET)
		{
			desc +="[AUTO]When another Murakumo rides this unit you may call this card to (RC). \n\n[ACT]RC)[Put this unit on the bottom of your deck] Choose up to one Murakumo from your hand call it to (RC) and at the beginning of the end phase of that turn return it to your hand. ";
		}
		else if(id == CardIdentifier.KNIGHT_OF_PURGATORY__SKULL_FACE)
		{
			desc +="[AUTO](VC)At the beginning of your main phase Soul Charge (1) and this unit gets [Power]+2000 until end of turn.\n\n[AUTO](VC/RC)[Soul Blast (8) amp Counter Blast (5)] When this units attack hits you may pay the cost. If you do retire all of your opponents rear-guards.";
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__TURBULENT_EDGE)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard if you have a Murakumo vanguard look at up to five cards from the top of your deck search for up to one card named 'Covert Demonic Dragon Mandala Lord' from among them reveal it to your opponent put it into your hand and put the rest on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__MILLION_RAT)
		{
			desc +="[AUTO][Counter Blast(1)] When this unit is placed on (VC) or (RC) if you have a Murakumo vanguard you may pay the cost. If you do search your deck up to one card named 'Stealth Beast Million Rat' call it to (RC) and shuffle your deck and at the beginning of the end phase of that turn put that unit on the bottom of your deck.";
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__CURSED_BREATH)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard if you have a Murakumo vanguard look at up to five cards from the top of your deck search for up to one card named 'Covert Demonic Dragon Mandala Lord' from among them reveal it to your opponent put it into your hand and put the rest on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.CAPED_STEALTH_ROGUE__SHANAOU)
		{
			desc +="[AUTO](RC)When this units attack hits a vanguard if you have a Murakumo vanguard you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.STEALTH_FIEND__KURAMA_LORD)
		{
			desc +="[AUTO](VC)At the beginning of your main phase Soul Charge (1) and choose a card from your damage zone and turn it face up.\n\n[AUTO](VC/RC)[Soul Blast (8) amp Counter Blast (5)] When this units attack hits you may pay the cost. If you do [Stand] all of your units.";
		}
		else if(id == CardIdentifier.FRONTLINE_VALKYRIE__LAUREL)
		{
			desc +="[AUTO](VC/RC)When this unit attacks a vanguard if you have a Neo Nectar vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_HARVEST__GENE)
		{
			desc +="[AUTO](RC)[Put this unit on the top of your deck] When this units attack hits a vanguard if you have a Neo Nectar vanguard you may pay the cost. If you do search your deck for up to two cards named 'Knight of Verdure Gene' call them as [Rest] to separate (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__VOIDGELGA)
		{
			desc +="[AUTO][Counter Blast(1)] When this unit is placed on (VC) or (RC) if you have a Murakumo vanguard you may pay the cost. If you do search your deck for up to one card named 'Stealth Dragon Voidgelga' call it to (RC) shuffle your deck and at the beginning of the end phase of that turn put that unit on the bottom of your deck.";
		}
		else if(id == CardIdentifier.HEY_YO_PINEAPPLE)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the number of Neo Nectar vanguards and/or rear-guards you have is four or more this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SHIELD_SEED_SQUIRE)
		{
			desc +="[AUTO]When another Neo Nectar rides this unit you may call this card to (RC).\n\n[AUTO](RC)[Put this unit on top of your deck] When this units attack hits a vanguard if you have a Neo Nectar vanguard you may pay the cost. If you do search your deck for up to one card named 'Blade Seed Squire' call it as [Rest] to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.AVATAR_OF_THE_PLAINS__BEHEMOTH)
		{
			desc +="[AUTO](VC)[Counter Blast (2)] When this units attack hits a vanguard you may pay the cost. If you do choose one of your Neo Nectar rear-guards and stand it.\n\n[AUTO](RC)[Counter Blast (2)] When this units attack hits a vanguard you may pay the cost. If you do choose one of your grade 1 or less Neo Nectar rear-guards and stand it.";
		}
		else if(id == CardIdentifier.PHANTOM_BLASTER_OVERLORD)
		{
			desc +="[CONT](VC/RC)If you have a non-Shadow Paladin vanguard or rear-guard this unit gets [Power]-2000.[CONT](VC)If you have a card named 'Phantom Blaster Dragon' in your soul this unit gets [Power]+2000.[AUTO] (VC)[Counter Blast (3) amp Choose a card named 'Phantom Blaster Overlord' from your hand and discard it] When this unit attacks you may pay the cost. If you do this unit gets [Power]+10000/[Critical]+1 until end of that turn.";
		}
		else if(id == CardIdentifier.DRAGONIC_OVERLORD_THE_END)
		{
			desc +="[CONT](VC/RC)If you have a non-Kagero vanguard or rear-guard this unit gets [Power]-2000.[CONT](VC)If you have a card named 'Dragonic Overlord' in your soul this unit gets [Power]+2000.[AUTO] (VC)[Counter Blast (2) amp Choose a card named 'Dragonic Overlord the End' from your hand and discard it] When this units attack hits you may pay the cost. If you do [Stand] this unit.";
		}
		else if(id == CardIdentifier.MIRACLE_BEAUTY)
		{
			desc +="[AUTO](RC)During your battle phase when this unit becomes [Stand] if you have a Dimension Police vanguard choose another of your rear-guard in the same column as this unit and [Stand] it.";
		}
		else if(id == CardIdentifier.STREET_BOUNCER)
		{
			desc +="[AUTO][Rest] this unit amp Choose another of your Nova Grappler rear-guard in the same column as this unit and [Rest] it] When this unit is placed on (RC) if you have a Nova Grappler vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.EVIL_EYE_PRINCESS__EURYALE)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if the number of Oracle Think Tank in your soul is six or more choose a card at random from your opponents hand bind it face down and at the beginning of the end phase of that turn your opponent puts that card into his or her hand.";
		}
		else if(id == CardIdentifier.MOONLIGHT_WITCH__VAHA)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits if you have a Shadow Paladin vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_NULLITY__MASQUERADE)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Blaster' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_LOYALTY__BEDIVERE)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Blaster' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_FRIENDSHIP__KAY)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Blaster' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.WINGAL_BRAVE)
		{
			desc +="[AUTO]When another Royal Paladin rides this unit you may call this card to (RC).\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits during the battle that this unit boosts a unit with 'Blaster' in its card name you may pay the cost. If you do search your deck for up to one card with 'Blaster' in its card name reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.STEALTH_FIEND__MIDNIGHT_CROW)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Murakumo Vanguard you may pay the cost. If you do search your deck for up to one card named 'Stealth Fiend Midnight Crow' call it to (RC) and shuffle your deck and at the beginning of the end phase of that turn put that unit on the bottom of your deck.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__LEAVES_MIRAGE)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck.)[AUTO][Choose a Murakumo from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Murakumo that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.MAIDEN_OF_BLOSSOM_RAIN)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck.)[AUTO][Choose a Neo Nectar from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Neo Nectar that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.MAIDEN_OF_TRAILING_ROSE)
		{
			desc +="[CONT](VC/RC)If you have a non-Neo Nectar vanguard or rear-guard this unit gets [Power]-2000.[AUTO] (VC)[Counter Blast (1) amp Choose a card named 'Maiden of Trailing Rose' from your hand and discard it] When this units attack hits a vanguard you may pay the cost. If you do look at up to five cards from the top of your deck search for up to two Neo Nectar from among them call the chosen cards to separate (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.GLASS_BEADS_DRAGON)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits if you have a Neo Nectar vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.KING_OF_DIPTERA__BEELZEBUB)
		{
			desc +="[CONT](VC)If the number of Dark Irregulars in your soul is eight or more this unit gets [Power]+1000.[AUTO](VC)[Counter Blast (2)] When this unit attacks if the number of Dark Irregulars in your soul is six or more you may pay the cost. If you do choose up to two of your Dark Irregulars rear-guards and those units get [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.MISTRESS_HURRICANE)
		{
			desc +="[CONT](VC)If the number of Pale Moon in your soul is eight or more this unit gets [Power]+1000.[AUTO][Counter Blast (2)] When this unit is placed on (VC) you may pay the cost. If you do choose a Pale Moon from your soul and call it to (RC).";
		}
		else if(id == CardIdentifier.STAR_CALL_TRUMPETER)
		{
			desc +="[AUTO][Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have Royal Paladin vanguard you may pay the cost. If you do search your deck for up to one grade 2 or less card with 'Blaster' in its card name call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__MANDALA_LORD)
		{
			desc +="[CONT](VC/RC) If you have a non-Murakumo vanguard or rear-guard this unit gets [Power]-2000.\n\n [AUTO](VC)[Counter Blast (1) and Choose a card named 'Covert Demonic Dragon Mandala Lord' from your hand and discard it] At the beginning of the guard step of the battle that this unit is attacked you may pay the cost. If you do choose one of your opponents attacking units and that unit gets [Power]-10000 until end of that battle.";
		}
		else if(id == CardIdentifier.MAJESTY_LORD_BLASTER)
		{
			desc += "[CONT](VC)If you have a card named 'Blaster Blade' and a card named 'Blaster Dark' in your soul this unit gets [Power]+2000/[Critical]+1.\n\n" +
					"[AUTO](VC)[Choose a unit named 'Blaster Blade' and a unit named 'Blaster Dark' from your (RC) and put them into your soul] When this unit attacks " +
					"you may pay the cost. If you do this unit gets [Power]+10000 until end of that battle.";
		}
		else if(id == CardIdentifier.SKYHIGH_WALKER)
		{
			desc +="[ACT](RC)[Put this unit into your soul] If you have a Pale Moon vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.CONJURER_OF_MITHRIL)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) reveal the top card of your deck. If the revealed card is a grade 1 or 2 Royal Paladin call it to (RC) and if it is not shuffle your deck.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__MAHORAGA)
		{
			desc +="[AUTO](RC)During your main phase when an opponents rear-guard is put into the drop zone this unit gets [Power]+5000 until end of turn.";
		}
		else if(id == CardIdentifier.CIRCULAR_SAW__KIRIEL)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO][Counter Blast (1)] When this unit is placed on (VC) you may pay the cost. If you do choose a face up Angel Feather from your damage zone call it to (RC) and put the top card of your deck face down into your damage zone.";
		}
		else if(id == CardIdentifier.BATTLE_CUPID__NOCIEL)
		{
			desc +="[AUTO][Choose an Angel Feather from your hand and put it into your damage zone] When this unit is placed on (GC) if you have an Angel Feather vanguard you may pay the cost. If you do choose a card from your damage zone and put it into your hand.";
		}
		else if(id == CardIdentifier.ICE_PRISON_NECROMANCER__COCYTUS)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO][Counter Blast (2)] When this unit is placed on (VC) you may pay the cost. If you do choose a Granblue from your drop zone and call it to (RC).";
		}
		else if(id == CardIdentifier.INCANDESCENT_LION__BLOND_EZEL)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2)] Look at the top card of your deck search for up to one Gold Paladin from among them call it to an open (RC) put the rest on the bottom of your deck and increase this units [Power] by the original [Power] of the unit called with this effect until end of turn.[CONT](VC)During your turn this unit gets [Power]+1000 for each of your Gold Paladin rear-guards.";
		}
		else if(id == CardIdentifier.PLAYER_OF_THE_HOLY_BOW__VIVIANE)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this units attack hits a vanguard if this unit is boosted by a Gold Paladin you may pay the cost and if you do look at the top card of your deck search for up to one Gold Paladin from among them call it to an open (RC) and put the rest on the bottom of your deck.";
		}
		else if(id == CardIdentifier.DRAGONIC_KAISER_VERMILLION)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (3)] Until end of turn this unit gets [Power]+2000 and '[CONT](VC)This unit battles every unit in your opponents front row in one attack.'.[CONT](VC/RC)If you have a non-Narukami vanguard or rear-guard this unit gets [Power]-2000.";
		}
		else if(id == CardIdentifier.DESERT_GUNNER__SHIDEN)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Narukami vanguard choose one of your opponents rear-guards and that unit cannot intercept until end of turn.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__AZURE_DRAGON)
		{
			desc +="[CONT](VC/RC)If you have a non-Nova Grappler vanguard or rear-guard this unit gets [Power]-2000.[AUTO] (VC)[ Choose a card named 'Beast Deity Azure Dragon' from your hand and discard it] When this units attack hits a vanguard you may pay the cost. If you do choose up to two of your rear-guards and [Stand] them.";
		}
		else if(id == CardIdentifier.COSMO_HEALER__ERGODIEL)
		{
			desc +="[CONT](VC)If you have a card named 'Fate Healer Ergodiel' in your soul this unit gets [Power]+1000.[AUTO] (VC)[Counter Blast (2) amp Choose a card named 'Cosmo Healer Ergodiel' from your hand and discard it] When this units attack hits a vanguard you may pay the cost. If you do choose a card from your damage zone and heal it.";
		}
		else if(id == CardIdentifier.CORE_MEMORY__ARMAROS)
		{
			desc +="[AUTO](VC/RC) [Counter Blast (2)] When this units attack hits if you have an Angel Feather vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.LOVE_MACHINE_GUN__NOCIEL)
		{
			desc +="[AUTO][Choose an Angel Feather from your hand and put it into your damage zone] When this unit is placed on (RC) if you have an Angel Feather vanguard you may pay the cost. If you do choose a card from your damage zone and put it into your hand.";
		}
		else if(id == CardIdentifier.PURE_KEEPER__REQUIEL)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose an Angel Feather from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Angel Feather that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.DEADLY_SWORDMASTER)
		{
			desc +="CONT [V/R] If you have a non-Granblue vanguard or rear-guard this unit gets Power -2000. [ACT][Drop Zone] [Choose a unit named 'Deadly Spirit' and a unit named 'Deadly Nightmare' from your Rear-guard Circle and retire them] If you have a grade 2 or greater Granblue vanguard ride this card. ";
		}
		else if(id == CardIdentifier.DEATH_SEEKER__THANATOS)
		{
			desc +="[AUTO](RC)[Counter Blast (1) amp Retire this unit] When this units attack hits a vanguard if you have a Granblue vanguard you may pay the cost. If you do choose a Granblue other than a card named 'Death Seeker Thanatos' from your drop zone and call it to (RC).";
		}
		else if(id == CardIdentifier.KNIGHT_OF_FURY__AGRAVAIN)
		{
			desc +="[AUTO](VC)At the beginning of your main phase Soul Charge (1) and this unit gets [Power]+2000 until end of turn.\n\n[ACT](VC)[Soul Blast (8) amp Counter Blast (5)] Until end of the game this unit gets [Critical]+1 and gets '[CONT](VC) This unit gets [Power]+1000 for each of your Gold Paladin rear-guards.'.";
		}
		else if(id == CardIdentifier.SLEYGAL_DAGGER)
		{
			desc +="[ACT](VC/RC)[Counter Blast (1)] If you have four or more other Gold Paladin rear-guards this unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.HALO_SHIELD__MARK)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck.)[AUTO][Choose a Gold Paladin from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Gold Paladin that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.VAJRA_EMPEROR__INDRA)
		{
			desc +="[AUTO](VC) [Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Critical]+1 for each unit named 'Vajra Emperor Indra' on your (RC) until end of that battle.";
		}
		else if(id == CardIdentifier.DRAGONIC_DEATHSCYTHE)
		{
			desc +="[AUTO][Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have a Narukami vanguard you may pay the cost. If you do choose one of your opponents grade 2 or less rear-guards and retire it.";
		}
		else if(id == CardIdentifier.WYVERN_GUARD__GULD)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck.)[AUTO][Choose a Narukami from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Narukami that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.MOBILE_HOSPITAL__FEATHER_PALACE)
		{
			desc +="[AUTO](VC)At the beginning of your main phase Soul Charge (1) and this unit gets [Power]+2000 until the end of turn.\n\n[AUTO](VC)[Soul Blast (8) amp Counter Blast (5)] When this units attack hits a vanguard you may pay the cost. If you do choose a card in your damage zone for each of your Angel Feather rear-guards and heal them.";
		}
		else if(id == CardIdentifier.DRILL_BULLET__GENIEL)
		{
			desc +="[AUTO](VC/RC) When this unit attacks a vanguard if you have an Angel Feather vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.THE_PHOENIX__CALAMITY_FLAME)
		{
			desc +="[AUTO](VC/RC)When a card is put into your damage zone if you have an Angel Feather vanguard this unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.FATE_HEALER__ERGODIEL)
		{
			desc +="[CONT](VC) If you have a card named 'Heavenly Injector' in your soul this unit gets [Power]+1000. [AUTO] [Choose two Angel Feather from your hand and put them into your damage zone] When a card named 'Cosmo Healer Ergodiel' rides this unit if you have a card named 'Heavenly Injector' in your soul you may pay the cost. If you do choose two cards from your damage zone and put them into your hand.";
		}
		else if(id == CardIdentifier.MIRACLE_FEATHER_NURSE)
		{
			desc +="[AUTO] When a card named 'Heavenly Injector' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Cosmo Healer Ergodiel' or 'Fate Healer Ergodiel' from among them reveal it to your opponent put it into your hand and shuffle your deck. \n\n[AUTO] When an Angel Feather other than a card named 'Heavenly Injector' rides this unit you may call this card to (RC).";
		}
		else if(id == CardIdentifier.MASTER_SWORDSMAN__NIGHTSTORM)
		{
			desc +="[AUTO](VC/RC)When this unit attacks a vanguard if you have a Granblue vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.SKELETON_DEMON_WORLD_KNIGHT)
		{
			desc +="[AUTO](VC)[Choose a Granblue from your hand and discard it] At the beginning of your ride phase if your opponent has a grade 3 or greater vanguard you may pay the cost. If you do you may choose a card named 'Ice Prison Necromancer Cocytus' from your drop zone and ride it. If you rode you cannot normal ride during that ride phase.";
		}
		else if(id == CardIdentifier.DEADLY_SPIRIT)
		{
			desc +="[ACT](Drop Zone) [Soul Blast (2) amp Choose one of your grade 1 or greater Granblue rear-guards and retire it] If you have a Granblue vanguard call this card to (RC).";
		}
		else if(id == CardIdentifier.THREE_STAR_CHEF__PIETRO)
		{
			desc +="[AUTO] [V/R] When this unit attacks hits a vanguard if you have a Granblue vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.DEADLY_NIGHTMARE)
		{
			desc +="[ACT](Drop Zone) [Soul Blast (2) amp Choose one of your Granblue rear-guards and retire it] If you have a Granblue vanguard call this card to (RC).";
		}
		else if(id == CardIdentifier.MAGE_OF_CALAMITY__TRIPP)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard if you have a Gold Paladin vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.PLAYER_OF_THE_HOLY_AXE__NIMUE)
		{
			desc +="[AUTO](VC/RC) [Counter Blast (1)] When this units attack hits a vanguard if this unit is boosted by a Gold Paladin you may pay the cost and if you do look at the top card of your deck search for up to one Gold Paladin from among them call that card to an open (RC) and put the rest on the bottom of your deck.";
		}
		else if(id == CardIdentifier.CRIMSON_LION_CUB__KYRPH)
		{
			desc +="[AUTO]When another Gold Paladin rides this unit you may call this card to (RC).\n\n[ACT](RC)[Choose a unit named 'Crimson Lion Cub Kyrph' and a unit named 'Knight of Elegant Skills Gareth' from your (RC) and put them into your soul] If you have a unit named 'Knight of Superior Skills Beaumains' on your (VC) search your deck for up to one card named 'Incandescent Lion Blond Ezel' ride it and shuffle your deck.";
		}
		else if(id == CardIdentifier.RIOT_GENERAL__GYRAS)
		{
			desc +="[AUTO](VC)At the beginning of your main phase Soul Charge (1) and this unit gets [Power]+2000 until end of turn.\n\n[ACT](VC)[Soul Blast (8) amp Counter Blast (5)] This unit gets '\n\n[AUTO](VC)When your Narukami attacks put the top card of your deck into your drop zone. If a Narukami is put into your drop zone this way the attacking unit gets [Power]+3000/[Critical]+1 until end of that battle' until end of turn.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_BERSERKER__GARUDA)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard if you have a Narukami vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.DESERT_GUNNER__RAIEN)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Narukami vanguard choose one of your opponents rear-guards and that unit cannot intercept until end of turn.";
		}
		else if(id == CardIdentifier.PHOTON_BOMBER_WYVERN)
		{
			desc +="[AUTO](RC)When this unit boosts a Narukami vanguard if the number of cards in your opponents damage zone is three or more the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__SAISHIN)
		{
			desc +="[AUTO]When another Narukami rides this unit you may call this card to (RC).\n\n[AUTO](RC)[Counter Blast (1) amp Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Narukami you may pay the cost. If you do choose one of your opponents grade 0 rear-guards and retire it.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__WHITE_TIGER)
		{
			desc +="[AUTO]When another Nova Grappler rides this unit you may call this card to (RC).\n\n[AUTO](RC)[Counter Blast (1) amp Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Nova Grappler you may pay the cost. If you do choose one of your Nova Grappler rear-guards with 'Beast Deity' in its card name and [Stand] it.";
		}
		else if(id == CardIdentifier.PULSE_WAVE__ADRIEL)
		{
			desc +="[AUTO](VC/RC) When this unit is boosted by an Angel Feather this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.MILLION_RAY_PEGASUS)
		{
			desc +="[AUTO](VC/RC)When a card is put into your damage zone if you have an Angel Feather vanguard this unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.IRON_HEART__MASTEMA)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the number of cards in your damage zone is more than or equal to your opponents this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.HOLY_ZONE__PENEMUE)
		{
			desc +="[AUTO] When this unit intercepts if you have an Angel Feather vanguard this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.THOUSAND_RAY_PEGASUS)
		{
			desc +="[AUTO](VC/RC) When a card is put into your damage zone if you have an Angel Feather vanguard this unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.HEAVENLY_INJECTOR)
		{
			desc +="[CONT](VC) If you have a card named 'Miracle Feather Nurse' in your soul this unit gets [Power]+1000. [AUTO] [Choose an Angel Feather from your hand and put it into your damage zone] When a card named 'Fate Healer Ergodiel' rides this unit if you have a card named 'Miracle Feather Nurse' in your soul you may pay the cost. If you do choose a card from your damage zone and put it into your hand.";
		}
		else if(id == CardIdentifier.LANCET_SHOOTER)
		{
			desc +="[ACT](VC/RC) [Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.CARRIER_OF_THE_LIFE_WATER)
		{
			desc +="[AUTO] (RC) When an attack hits a vanguard during the battle that this unit boosted an Angel Feather you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.CLUTCH_RIFLE_ANGEL)
		{
			desc +="[AUTO](RC)When this unit boosts an Angel Feather vanguard if the number of cards in your damage zone is more than or equal to your opponents the boosted unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.LIGHTNING_CHARGER)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit named 'Circular Saw Kiriel' you may pay the cost. If you do the boosted unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.THERMOMETER_ANGEL)
		{
			desc +="[AUTO] When another Angel Feather rides this unit you may call this card to (RC). \n\n[ACT](RC) [Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Angel Feather from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.CRITICAL_HIT_ANGEL)
		{
			desc +="[ACT](RC) [Put this unit into your soul] Choose up to one of your Angel Feather and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.HAPPY_BELL__NOCIEL)
		{
			desc +="[CONT](RC) If you have an Angel Feather vanguard this unit gets '[ACT](RC) [Put this unit into your soul amp Choose an Angel Feather from your hand and put it into your damage zone] Choose a card from your damage zone and put it into your hand.'";
		}
		else if(id == CardIdentifier.SUNNY_SMILE_ANGEL)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.) [AUTO] When another Angel Feather rides this unit you may call this card to (RC). \n\n[AUTO](RC) When this unit boosts the boosted unit gets [Power]+3000 until end of that battle and at the beginning of the end phase of that turn return this unit to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.GOD_EATING_ZOMBIE_SHARK)
		{
			desc +="[AUTO](VC/RC) When this unit is boosted by a Granblue this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.STORMRIDE_GHOST_SHIP)
		{
			desc +="[CONT](VC/RC) Restraint (This unit cannot attack.)[AUTO](VC/RC)When your Granblue is placed on (RC) from the drop zone this unit loses 'Restraint' until end of turn.\n\n[AUTO](VC)When this unit is boosted by a Granblue this unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.UNDEAD_PIRATE_OF_THE_FRIGID_NIGHT)
		{
			desc +="[AUTO](VC/RC) When this unit attacks if the number of cards in your hand is less than your opponents this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SEA_NAVIGATOR__SILVER)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard if you have four or more other Granblue rear-guards draw a card.";
		}
		else if(id == CardIdentifier.SKELETON_COLOSSUS)
		{
			desc +="[AUTO](VC) [Choose a Granblue from your hand and discard it] At the beginning of your ride phase if your opponent has a grade 2 or greater vanguard you may pay the cost. If you do you may choose a card named 'Skeleton Demon World Knight' from your drop zone and ride it. If you rode you cannot normal ride during that ride phase.";
		}
		else if(id == CardIdentifier.CHILD_FRANK)
		{
			desc +="[ACT](VC/RC) [Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.JOHN_THE_GHOSTIE)
		{
			desc +="[AUTO](RC) When an attack hits a vanguard during the battle that this unit boosted a Granblue you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.RIPPLE_BANSHEE)
		{
			desc +="[AUTO] When this unit is placed on (RC) choose another of your Granblue and that unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.DRAGON_SPIRIT)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit named 'Ice Prison Necromancer Cocytus' you may pay the cost. If you do the boosted unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.UNDEAD_PIRATE_OF_THE_CURSED_RIFLE)
		{
			desc +="[AUTO](VC/RC) [Choose a card from your hand and discard it] When this unit attacks you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.CAPTAIN_NIGHTKID)
		{
			desc +="[AUTO] When another Granblue rides this unit you may call this card to Rear-guard Circle. \n\n[ACT][R] [Counter Blast (1) amp Put this unit into your soul] Look at up to ten cards from the top of your deck search for up to one Granblue from among them put it into your drop zone and shuffle your deck. ";
		}
		else if(id == CardIdentifier.SKELETON_ASSAULT_TROOPS_CAPTAIN)
		{
			desc +="[AUTO] When another Granblue rides this unit you may call this card to Rear-guard Circle. \n\n[ACT][R] [Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Granblue from among them reveal it to your opponent put it into your hand and shuffle your deck. ";
		}
		else if(id == CardIdentifier.DOCTOR_ROUGE)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.HADES_STEERSMAN)
		{
			desc +="[AUTO] [Drop Zone] When your grade 3 Granblue is placed on Vanguard Circle you may call this card to Rear-guard Circle of the same column as that unit.";
		}
		else if(id == CardIdentifier.GIGANTECH_CRUSHER)
		{
			desc +="[AUTO](VC)When this units attack if the number of Gold Paladin rear-guards you called this turn is four or more this unit gets [Power]+10000 until end of that battle.";
		}
		else if(id == CardIdentifier.HOLY_MAGE__MANAWYDAN)
		{
			desc +="[AUTO] [V/R] When this unit is boosted by a Gold Paladin this unit gets Power +2000 until end of that battle.";
		}
		else if(id == CardIdentifier.GIGANTECH_COMMANDER)
		{
			desc +="[AUTO] [V/R] When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets Power +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SACRED_GUARDIAN_BEAST__ELEPHAS)
		{
			desc +="[AUTO] [Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have a Gold Paladin vanguard you may pay the cost. If you do search your deck for up to one grade 0 Gold Paladin normal unit call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.PROVIDENCE_STRATEGIST)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard if the number of other Gold Paladin rear-guards you have is four or more draw a card.";
		}
		else if(id == CardIdentifier.WAVING_OWL)
		{
			desc +="[AUTO] [R] When an attack hits a vanguard during the battle that this unit boosted a Gold Paladin you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.LITTLE_BATTLER__TRON)
		{
			desc +="[AUTO] [R] When this unit boosts a Gold Paladin vanguard if the number of rear-guards you have is more than your opponents the boosted unit gets Power +4000 until end of that battle.";
		}
		else if(id == CardIdentifier.LITTLE_FIGHTER__CRON)
		{
			desc +="[AUTO] When another Gold Paladin rides this unit you may call this card to Rear-guard Circle. \n\n[ACT][R] [Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Gold Paladin from among them reveal it to your opponent put it into your hand and shuffle your deck. ";
		}
		else if(id == CardIdentifier.FLAME_OF_VICTORY)
		{
			desc +="[ACT][R] [Put this unit into your soul] Choose up to one of your Gold Paladin and that unit gets Power +3000 until end of turn.";
		}
		else if(id == CardIdentifier.BREAKTHROUGH_DRAGON)
		{
			desc +="[AUTO] [V/R] When this unit is boosted by a Narukami this unit gets Power +2000 until end of that battle.";
		}
		else if(id == CardIdentifier.HEX_CANNON_WYVERN)
		{
			desc +="[AUTO] [V/R] When this unit attacks if the number of cards in your opponents damage zone is three or more this unit gets Power +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DRAGON_MONK__ENSEI)
		{
			desc +="[AUTO] [V/R] When this units attack hits a vanguard if you have four or more other Narukami rear-guards draw a card.";
		}
		else if(id == CardIdentifier.STEALTH_FIGHTER)
		{
			desc +="[AUTO] [R] When an attack hits a vanguard during the battle that this unit boosted a Narukami you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__YOWSH)
		{
			desc +="[AUTO] [V/R] [Soul Blast (1)] When this unit attacks if you have a Narukami vanguard you may pay the cost. If you do this unit gets Power +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SPARK_KID_DRAGOON)
		{
			desc +="[AUTO] When another Narukami rides this unit you may call this card to Rear-guard Circle. \n\n[ACT][R] [Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Narukami from among them reveal it to your opponent put it into your hand and shuffle your deck. ";
		}
		else if(id == CardIdentifier.MALEVOLENT_DJINN)
		{
			desc +="[ACT][R] [Put this unit into your soul] Choose up to one of your Narukami and that unit gets Power +3000 until end of turn.";
		}
		else if(id == CardIdentifier.MOAI_THE_GREAT)
		{
			desc +="[AUTO] [V/R] When this unit is boosted by a Nova Grappler this unit gets Power +2000 until end of that battle.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__BLACK_TORTOISE)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard if you have a Nova Grappler vanguard look at up to five cards from the top of your deck search for up to one card named 'Beast Deity Azure Dragon' from among them reveal it to your opponent put it into your hand and put the rest the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.MARVELOUS_HANI)
		{
			desc +="[AUTO] [V/R] When this units attack hits a vanguard if you have four or more other Nova Grappler rear-guards draw a card.";
		}
		else if(id == CardIdentifier.ALMIGHTY_REPORTER)
		{
			desc +="[AUTO] [R] When an attack hits a vanguard during the battle that this unit boosted a Nova Grappler you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__SCARLET_BIRD)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard if you have a Nova Grappler vanguard look at up to five cards from the top of your deck search for up to one card named 'Beast Deity Azure Dragon' from among them reveal it to your opponent put it into your hand and put the rest the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.GREED_SHADE)
		{
			desc +="[AUTO] [V/R] When this unit attacks if the number of cards in your hand is greater than your opponents this unit gets Power +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.COONGAL)
		{
			desc +="[AUTO]When this unit is put into the drop zone from (GC) put this unit into your soul.";
		}
		else if(id == CardIdentifier.BATTLE_FLAG_KNIGHT__LAUDINE)
		{
			desc +="[AUTO]When this unit is placed on (RC) choose another of your Gold Paladin and that unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.SATELLITEFALL_DRAGON)
		{
			desc +="[AUTO](VC/RC) When another of your grade 3 Gold Paladin is placed on (RC) this unit gets [Power]+3000 until the end of turn.";
		}
		else if(id == CardIdentifier.DREADCHARGE_DRAGON)
		{
			desc +="[AUTO](VC/RC)When another of your grade 3 Narukami is placed on (RC) this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.BRIGHTLANCE_DRAGOON)
		{
			desc +="CONT [V/R] If you do not have another Narukami in the same column as this unit this unit gets Power -2000. [ACT][V/R] [Counter Blast (1)] This unit gets Power +1000 until end of turn. ";
		}
		else if(id == CardIdentifier.RISING_PHOENIX)
		{
			desc +="[AUTO][Soul Blast(2)] When this unit is placed on (RC) if you have a Narukami vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.TURBORAIZER)
		{
			desc +="[AUTO]When another Nova Grappler rides this unit you may call this card to (RC).\n\n[AUTO](RC)When this unit boosts the boosted unit gets [Power]+3000 until end of that battle and at the begininng of the end phase of that turn return this unit to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.MUSCLE_HERCULES)
		{
			desc +="[AUTO] When this unit is placed on Vanguard Circle or Rear-guard Circle if you have a Nova Grappler vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.KUNGFU_KID__BOLTA)
		{
			desc +="[AUTO] [V/R] When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets Power +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.CUP_BOWLER)
		{
			desc +="[AUTO](VC)When your Nova Grappler rear-guard becomes [Rest] this unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.SCHOOL_HUNTER__LEO_PALD)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1)] During your end phase when one of your Great Nature rear-guards is put into the drop zone you may pay the cost. If you do call that card to an open (RC).\n\n[AUTO](VC)When this unit attacks a vanguard choose another of your Great Nature rear-guards and you may have that unit get [Power]+4000 until end of turn. If you do at the beginning of your end phase retire that unit.";
		}
		else if(id == CardIdentifier.GUARDIAN_OF_TRUTH__LOX)
		{
			desc +="[CONT](VC)If you have a card named 'Law Official Lox' in your soul this unit gets [Power]+1000.[ACT] (VC)[Counter Blast (2) amp Choose a card named 'Guardian of Truth Lox' from your hand and discard it] Choose one of your Great Nature rear-guards and that unit gets [Power]+4000/[Critical]+1 until end of turn and at the beginning of your end phase retire that unit.";
		}
		else if(id == CardIdentifier.BINOCULUS_TIGER)
		{
			desc +="[AUTO](VC/RC) When this unit attacks a vanguard choose another of your Great Nature rear-guards and you may have that unit get Power +4000 until end of turn. If you do at the beginning of your end phase retire that unit.";
		}
		else if(id == CardIdentifier.SILVER_THORN_DRAGON_TAMER__LUQUIER)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (3)] Choose up to one grade 0 grade 1 grade 2 and grade 3 Pale Moon from your soul and call them to separate (RC).\n\n[AUTO](VC)When one of your Pale Moon is placed on (RC) from your soul this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.DARK_LORD_OF_ABYSS)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2)] Soul Charge (2) and this unit gets [Power]+1000 for each Dark Irregulars in your soul until end of turn.[CONT](VC/RC)If you have a non-Dark Irregulars vanguard or rear-guard this unit gets [Power]-2000.";
		}
		else if(id == CardIdentifier.EMERALD_WITCH__LALA)
		{
			desc +="[AUTO] [Choose a card from your hand and discard it] When this unit is placed on Rear-guard Circle if you have an Oracle Think Tank vanguard and you do not have any cards in your soul you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.WHITE_HARE_IN_THE_MOON_____S_SHADOW__PELLINORE)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Choose two of your Gold Paladin rear-guards and put them on the bottom of your deck in any order] When this unit attacks you may pay the cost. If you do choose up to two of your Gold Paladin and those units get [Power]+5000 until end of turn.\n\n[AUTO][Choose a Gold Paladin from your hand and discard it] When this unit is placed on (RC) from your deck if your opponent has a grade 2 or greater vanguard you may pay the cost. If you do put this unit on your (VC).";
		}
		else if(id == CardIdentifier.CHIEF_NURSE__SHAMSIEL)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Choose an Angel Feather from your hand and put it into your damage zone] When this unit attacks a vanguard you may pay the cost. If you do choose a card from your damage zone and put it into your hand.\n\n[AUTO](VC)When a card is put into your damage zone this unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.SCHOOL_DOMINATOR__APT)
		{
			desc +="[AUTO]V Limit Break 4 (This ability is active if you have four or more damage) When this unit attacks a vanguard this unit gets Power +5000 until end of that battle.AUTOV [Choose one of your Great Nature rear-guards and retire it] When this units attack hits a vanguard you may pay the cost. If you do choose up to one Great Nature from your hand and call it to Rear-guard Circle.";
		}
		else if(id == CardIdentifier.LAMP_CAMEL)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits if you have a Great Nature vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.MONOCULUS_TIGER)
		{
			desc +="[AUTO](VC/RC) When this unit attacks a vanguard choose another of your Great Nature rear-guards and you may have that unit get Power +4000 until end of turn. If you do at the beginning of your end phase retire that unit.";
		}
		else if(id == CardIdentifier.CABLE_SHEEP)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck.)[AUTO][Choose a Great Nature from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Great Nature that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.SWORD_MAGICIAN__SARAH)
		{
			desc +="[AUTO](VC)[Choose one of your grade 3 or greater Pale Moon rear-guards and put it into your soul] When this units drive check reveals a grade 3 Pale Moon you may pay the cost. If you do choose a Pale Moon from your soul and call it to an open (RC).\n\n[AUTO](VC)When this unit is boosted by a Pale Moon this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.FIRE_BREEZE__CARRIE)
		{
			desc +="[AUTO](VC/RC) [Counter Blast (2)] When this units attack hits if you have a Pale Moon vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.PEEK_A_BOO)
		{
			desc +="[AUTO](Soul)[Soul Blast (1)] At the beginning of your main phase if you have a Pale Moon vanguard you may pay the cost. If you do call this card to (RC).\n\n[AUTO](RC)At the beginning of your end phase if you have a Pale Moon vanguard put this unit into your soul.";
		}
		else if(id == CardIdentifier.MAGICIAN_OF_QUANTUM_MECHANICS)
		{
			desc +="[ACT](RC) [Counter Blast (1) amp Put this unit into your soul] If you have a Pale Moon vanguard choose a Pale Moon other than a card named 'Magician of Quantum Mechanics' from your soul and call it to (RC) and at the beginning of your end phase put that unit into your soul. If you put that unit into your soul this way choose a card named 'Magician of Quantum Mechanics' from your soul and call it to (RC).";
		}
		else if(id == CardIdentifier.BLADE_WING_REIJY)
		{
			desc +="[CONT](VC)If the number of Dark Irregulars in your soul is fifteen or more this unit gets [Critical]+2.[AUTO]When this unit is placed on (VC) choose one of your Dark Irregulars rear-guards search your deck for up to three cards with the same name as that card put them into your soul and shuffle your deck.";
		}
		else if(id == CardIdentifier.EMBLEM_MASTER)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this units attack hits a vanguard if you have a Dark Irregulars vanguard you may pay the cost. If you do Soul Charge (3).";
		}
		else if(id == CardIdentifier.YELLOW_BOLT)
		{
			desc +="[ACT](VC/RC) [ [Rest] this unit] If you have a Dark Irregulars vanguard Soul Charge (1).";
		}
		else if(id == CardIdentifier.LISTENER_OF_TRUTH__DINDRANE)
		{
			desc +="[AUTO][Soul Blast (1)] When this unit is placed on (RC) from your deck if you have a Gold Paladin vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.PENCIL_HERO__HAMMSUKE)
		{
			desc +="[AUTO][Counter Blast (1)] During your end phase when this unit is put into the drop zone from (RC) if you have a Great Nature vanguard you may pay the cost. If you do search your deck for up to one card named 'Pencil Hero Hammsuke' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.DUMBBELL_KANGAROO)
		{
			desc +="[AUTO](VC) [Counter Blast (2)] When this units attack hits a vanguard you may pay the cost. If you do choose one of your Great Nature rear-guards and [Stand] it.\n\n[AUTO](RC) [Counter Blast (2)] When this units attack hits a vanguard you may pay the cost. If you do choose one of your grade 1 or less Great Nature rear-guards and [Stand] it.";
		}
		else if(id == CardIdentifier.MAGNET_CROCODILE)
		{
			desc +="[AUTO](VC/RC) When this unit attacks a vanguard if you have a Great Nature vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.LAW_OFFICIAL__LOX)
		{
			desc +="[CONT](VC/RC) If you have a card named 'Bringer of Knowledge Lox' in your soul this unit gets [Power] +1000.[AUTO] When a card named 'Guardian of Truth Lox' rides this unit if you have a card named 'Bringer of Knowledge Lox' in your soul choose up to two of your Great Nature rear-guards and those units get '\n\n[AUTO] During your end phase when this unit is put into the drop zone from (RC) draw a card.' until end of turn.";
		}
		else if(id == CardIdentifier.PENCIL_SQUIRE__HAMMSUKE)
		{
			desc +="[AUTO] [Counter Blast (1)] During your end phase when this unit is put into the drop zone from (RC) if you have a Great Nature vanguard you may pay the cost. If you do search your deck for up to one card named 'Pencil Squire Hammsuke' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.THERMOMETER_GIRAFFE)
		{
			desc +="[AUTO](RC) When this unit boosts a Great Nature vanguard if the number of face up cards in your opponents damage zone is two or more the boosted unit gets [Power] +4000 until end of that battle.";
		}
		else if(id == CardIdentifier.TANK_MOUSE)
		{
			desc +="[ACT](RC] [ [Rest] this unit] Choose one of your Great Nature rear-guards and that unit gets [Power] +4000 until end of turn and at the beginning of your end phase retire that unit.";
		}
		else if(id == CardIdentifier.FLASK_MARMOSET)
		{
			desc +="[AUTO] When another Great Nature rides this unit you may call this card to (RC).\n\n[ACT](RC) [Counter Blast (2)] Choose one of your Great Nature rear-guards and that unit gets [Power] +4000 until end of turn and at the beginning of your end phase retire that unit.";
		}
		else if(id == CardIdentifier.MIDNIGHT_INVADER)
		{
			desc +="[AUTO](VC/RC) When this unit attacks a vanguard if you have a Pale Moon vanguard this unit gets Power +2000 until end of that battle.";
		}
		else if(id == CardIdentifier.DANCING_PRINCESS_OF_THE_NIGHT_SKY)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Pale Moon vanguard you may pay the cost. If you do search your deck for up to one grade 2 or less Pale Moon put it into your soul and shuffle your deck.";
		}
		else if(id == CardIdentifier.BULL_____S_EYE__MIA)
		{
			desc +="[AUTO](RC) When an attack hits a vanguard during the battle that this unit boosted a Pale Moon you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.PURPLE_TRAPEZIST)
		{
			desc +="[AUTO][Choose another of your Pale Moon rear-guards and put it into your soul] When this unit is placed on (RC) if you have a Pale Moon vanguard you may pay the cost. If you do choose a Pale Moon other than a card named 'Purple Trapezist' from your soul and call it to (RC).";
		}
		else if(id == CardIdentifier.EVIL_EYE_BASILISK)
		{
			desc +="[AUTO](VC/RC) When this unit attacks a vanguard if you have a Dark Irregulars vanguard this unit gets [Power] +2000 until end of that battle.";
		}
		else if(id == CardIdentifier.HADES_CARRIAGE_OF_THE_WITCHING_HOUR)
		{
			desc +="[CONT](VC/RC) During your turn this unit gets [Power] +2000 for each card named 'Hades Carriage of the Witching Hour' in your soul.";
		}
		else if(id == CardIdentifier.FREE_TRAVELER)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Dark Irregulars vanguard you may pay the cost. If you do search your deck for up to one grade 2 or less Dark Irregulars put it into your soul and shuffle your deck.";
		}
		else if(id == CardIdentifier.COURTING_SUCCUBUS)
		{
			desc +="[AUTO](RC) When an attack hits a vanguard during the battle that this unit boosted a Dark Irregulars you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.SKY_WITCH__NANA)
		{
			desc +="[CONT](VC) During your turn if you do not have any cards in your soul this unit gets [Power] +3000.[CONT](RC) During your turn if you do not have any cards in your soul this unit gets [Power] +1000.";
		}
		else if(id == CardIdentifier.BATTLE_SISTER__GLACE)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if you do not have any cards in your soul this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.LITTLE_WITCH__LULU)
		{
			desc +="[AUTO](Soul)When another of your grade 3 or greater Oracle Think Tank is placed on (VC) you may call this card to (RC).\n\n[AUTO][Choose two Oracle Think Tank from your soul and put them into your drop zone] When this unit is placed on (RC) from your soul if you have an Oracle Think Tank vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.PHOTON_ARCHER__GRIFLET)
		{
			desc +="[AUTO](VC) [Counter Blast (2)] When this units attack hits a vanguard you may pay the cost. If you do choose one of your Gold Paladin rear-guards and [Stand] it.\n\n[AUTO](RC) [Counter Blast (2)] When this units attack hits a vanguard you may pay the cost. If you do choose one of your grade 1 or less Gold Paladin rear-guards and [Stand] it.";
		}
		else if(id == CardIdentifier.LOP_EAR_SHOOTER)
		{
			desc +="[AUTO] [Choose a card from your hand and discard it] When this unit is placed on (RC) from your deck if you have a Gold Paladin vanguard you may pay the cost. If you do look at up to three cards from the top of your deck search for up to one Gold Paladin from among them call it to (RC) and put the rest on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.SPRING_BREEZE_MESSENGER)
		{
			desc +="[AUTO] When another Gold Paladin rides this unit you may call this card to (RC).\n\n[AUTO] (RC) [Counter Blast (1) amp Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted you may pay the cost. If you do look at up to three cards from the top of your deck search for up to one Gold Paladin from among them call it to (RC) as [Rest] and put the rest on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.CALCULATOR_HIPPO)
		{
			desc +="[AUTO](VC/RC) When this unit is boosted by a Great Nature this unit gets [Power] +2000 until end of that battle.";
		}
		else if(id == CardIdentifier.SCHOOLBAG_SEA_LION)
		{
			desc +="[AUTO](VC) When this units drive check reveals a grade 3 Great Nature this unit gets [Power] +5000 until end of that battle.";
		}
		else if(id == CardIdentifier.RED_PENCIL_RHINO)
		{
			desc +="[CONT](VC/RC) If you do not have a unit named 'Guardian of Truth Lox' or a unit named 'Law Official Lox' on your (VC) this units gets [Power] -5000.[AUTO](VC/RC) When this unit attacks this unit gets [Power] +2000 until end of that battle.";
		}
		else if(id == CardIdentifier.PENCIL_KNIGHT__HAMMSUKE)
		{
			desc +="[AUTO] [Counter Blast (1)] During your end phase when this unit is put into the drop zone from (RC) if you have a Great Nature vanguard you may pay the cost. If you do search your deck for up to one card named 'Pencil Knight Hammsuke' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.GLOBE_ARMADILLO)
		{
			desc +="[AUTO] When this unit intercepts if you have a Great Nature vanguard this unit gets [Shield] +5000 until end of that battle.";
		}
		else if(id == CardIdentifier.EXPLOSION_SCIENTIST__BUNTA)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Great Nature vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.MULTIMETER_GIRAFFE)
		{
			desc +="[AUTO](VC/RC) When this unit attacks if the number of face up cards in your opponents damage zone is two or more this unit gets [Power] +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.CANVAS_KOALA)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard if the number of other Great Nature rear-guards you have is four or more draw a card.";
		}
		else if(id == CardIdentifier.THUMBTACK_FIGHTER__RESANORI)
		{
			desc +="[ACT](VC/RC)[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.TICK_TOCK_FLAMINGO)
		{
			desc +="[AUTO] During your main phase when this unit is placed on (RC) choose another of your Great Nature rear-guards and that unit gets '\n\n[AUTO] During your end phase when this unit is put into the drop zone from (RC) choose a card from your damage zone and turn it face up.' until end of turn.";
		}
		else if(id == CardIdentifier.BRINGER_OF_KNOWLEDGE__LOX)
		{
			desc +="[CONT](VC) If you have a card named 'Schoolyard Prodigy Lox' in your soul this unit gets [Power] +1000.[AUTO] When a card named 'Law Official Lox' rides this unit if you have a card named 'Schoolyard Prodigy Lox' in your soul choose up to two of your Great Nature rear-guards and those units get '\n\n[AUTO] During your end phase when this unit is put into the drop zone from (RC) draw a card.' until end of turn.";
		}
		else if(id == CardIdentifier.ELEMENT_GLIDER)
		{
			desc +="[AUTO](RC) When an attack hits a vanguard during the battle that this unit boosted a Great Nature you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.FAILURE_SCIENTIST__PONKICHI)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Great Nature vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.FEATHER_PENGUIN)
		{
			desc +="[AUTO](RC) [Soul Blast (1)] When this unit boosts a card named 'School Dominator Apt' you may pay the cost. If you do the boosted unit gets [Power] +5000 until end of that battle.";
		}
		else if(id == CardIdentifier.HULA_HOOP_CAPYBARA)
		{
			desc +="[AUTO](RC) [Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.ACORN_MASTER)
		{
			desc +="[AUTO] When another Great Nature rides this unit you may call this card to (RC).\n\n[ACT](RC) [Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Great Nature from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.SCHOOLYARD_PRODIGY__LOX)
		{
			desc +="[AUTO] When a card named 'Bringer of Knowledge Lox' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Guardian of Truth Lox' or 'Law Official Lox' from among them reveal it to your opponent put it into your hand and shuffle your deck. \n\n[AUTO] When a Great Nature other than a card named 'Bringer of Knowledge Lox' rides this unit you may call this card to (RC).";
		}
		else if(id == CardIdentifier.DICTIONARY_GOAT)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.RULER_CHAMELEON)
		{
			desc +="[AUTO][Counter Blast (1)] During your end phase when this unit is put into the drop zone from (RC) if you have a Great Nature vanguard you may pay the cost. If you do search your deck for up to one card named 'Ruler Chameleon' reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.NIGHTMARE_DOLL__AMY)
		{
			desc +="[AUTO](VC) At the beginning of your main phase Soul Charge (1) and this unit gets [Power] +2000 until end of turn.\n\n[AUTO](VC) [Counter Blast (5) amp Soul Blast (8)] When this units attack hits a vanguard you may pay the cost. If you do put all of your Pale Moon rear-guards into your soul choose up to five Pale Moon from your soul and call them to separate (RC).";
		}
		else if(id == CardIdentifier.DREAMY_FORTRESS)
		{
			desc +="[AUTO]During your opponents turn when this unit is put into the drop zone from (RC) choose a card named 'Dreamy Fortress' from your soul and call it to (RC).";
		}
		else if(id == CardIdentifier.SEE_SAW_GAME_LOSER)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Pale Moon vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.DRAWING_DREAD)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard if the number of other Pale Moon rear-guards you have is four or more draw a card.";
		}
		else if(id == CardIdentifier.JUMPING_GLENN)
		{
			desc +="[AUTO] When this unit is placed on (RC) from your soul if you have a Pale Moon vanguard this unit gets [Power] +3000 until end of turn.";
		}
		else if(id == CardIdentifier.DREAMY_AMMONITE)
		{
			desc +="[AUTO] During your opponents turn when this unit is put into the drop zone from (RC) choose a card named 'Dreamy Ammonite' from your soul and call it to (RC).";
		}
		else if(id == CardIdentifier.SEE_SAW_GAME_WINNER)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Pale Moon vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.PINKY_PIGGY)
		{
		desc += "";
		}
		else if(id == CardIdentifier.GIRL_WHO_CROSSED_THE_GAP)
		{
			desc +="[AUTO]When another Pale Moon rides this unit you may call this card to (RC).\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] If you have a Pale Moon vanguard choose a Pale Moon other than a card named 'Girl Who Crossed the Gap' from your soul and call it to (RC).";
		}
		else if(id == CardIdentifier.INNOCENT_MAGICIAN)
		{
			desc +="[AUTO] When another Pale Moon rides this unit you may call this card to (RC).\n\n[ACT](RC) [Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Pale Moon from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.POPCORN_BOY)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.POISON_JUGGLER)
		{
			desc +="[ACT](RC) [Put this unit into your soul] Choose up to one of your Pale Moon and that unit gets [Power] +3000 until end of turn.";
		}
		else if(id == CardIdentifier.DEMON_CHARIOT_OF_THE_WITCHING_HOUR)
		{
			desc +="[CONT](VC/RC) During your turn this unit gets [Power] +2000 for each card named 'Demon Chariot of the Witching Hour' in your soul.";
		}
		else if(id == CardIdentifier.BEAST_IN_HAND)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Dark Irregulars vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.CYBER_BEAST)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard if the number of other Dark Irregulars rear-guards you have is four or more draw a card.";
		}
		else if(id == CardIdentifier.DEMON_BIKE_OF_THE_WITCHING_HOUR)
		{
			desc +="[CONT](VC/RC) During your turn this unit gets [Power] +2000 for each card named 'Demon Bike of the Witching Hour' in your soul.";
		}
		else if(id == CardIdentifier.BEAUTIFUL_HARPUIA)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Dark Irregulars vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.MIRAGE_MAKER)
		{
			desc +="[AUTO](RC) When an attack hits a vanguard during the battle that this unit boosted a Dark Irregulars you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.RUNE_WEAVER)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Dark Irregulars vanguard choose up to one Dark Irregulars from your hand and put it into your soul.";
		}
		else if(id == CardIdentifier.GREEDY_HAND)
		{
			desc +="[AUTO] When another Dark Irregulars rides this unit you may call this card to (RC).\n\n[ACT](RC) [Counter Blast (1) amp Put this unit into your soul] Search your deck for up to one grade 2 or less Dark Irregulars put it into your soul and shuffle your deck.";
		}
		else if(id == CardIdentifier.DEVIL_IN_SHADOW)
		{
			desc +="[AUTO]When another Dark Irregulars rides this unit you may call this card to (RC).\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Dark Irregular from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.CHESHIRE_CAT_OF_NIGHTMARELAND)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.DARK_KNIGHT_OF_NIGHTMARELAND)
		{
			desc +="[ACT](RC) [Put this unit into your soul] Choose up to one of your Dark Irregulars and that unit gets [Power] +3000 until end of turn.";
		}
		else if(id == CardIdentifier.BATTLE_SISTER__SOUFFLE)
		{
			desc +="[AUTO](VC/RC) When this unit is boosted by an Oracle Think Tank this unit gets [Power] +2000 until end of that battle.";
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN__SHISA)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard if the number of other Oracle Think Tank rear-guards you have is four or more draw a card.";
		}
		else if(id == CardIdentifier.MOONSAULT_SWALLOW)
		{
			desc +="[AUTO](RC) When an attack hits a vanguard during the battle that this unit boosted an Oracle Think Tank you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.BATTLE_SISTER__ECLAIR)
		{
			desc +="[AUTO]When another Oracle Think Tank rides this unit you may call this card to (RC).\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Oracle Think Tank from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.MASTER_OF_PAIN)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Gold Paladin vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.DISCIPLE_OF_PAIN)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Gold Paladin vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.DOCTROID_MEGALOS)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have an Angel Feather vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.DOCTROID_MICROS)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have an Angel Feather vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.HOPE_CHILD__TURIEL)
		{
			desc +="[AUTO] When another Angel Feather rides this unit you may call this card to (RC).[CONT](RC) If you have an Angel Feather vanguard this unit gets '\n\n[ACT](RC) [Counter Blast (1) amp Put this unit into your soul amp Choose an Angel Feather from your hand and put it into your damage zone] Choose a card from your damage zone and put it into your hand'.";
		}
		else if(id == CardIdentifier.ULTIMATE_DIMENSIONAL_ROBO__GREAT_DAIYUSHA)
		{
			desc +="[CONT](VC) Limit Break 4 (This ability is active if you have four or more damage)During your turn if the number of cards in your soul with 'Dimensional Robo' in its card name is three or more this unit gets [Power]+2000/[Critical]+1.[CONT](VC/RC)If you have a non-Dimension Police vanguard or rear-guard this unit gets [Power]-2000.[CONT](VC)If you have a card named 'Super Dimensional Robo Daiyusha' in your soul this unit gets [Power]+2000.";
		}
		else if(id == CardIdentifier.GALACTIC_BEAST__ZEAL)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2)] Choose one of your opponents vanguard and that unit gets [Power]-1000 for each of your Dimension Police rear-guards until end of turn. This ability cannot be used for the rest of that turn.[CONT](VC)If you have a card named 'Devourer of Planets Zeal' in your soul this unit gets [Power]+1000.";
		}
		else if(id == CardIdentifier.ARBOROS_DRAGON__SEPHIROT)
		{
			desc +="[CONT](VC) Limit Break 4 (This ability is active if you have four or more damage)All of your Neo Nectar get '[CONT](VC/RC) During your turn if you have a unit with the same name as this unit on your (VC) or (RC) this unit gets [Power]+3000.'.[CONT](VC)If you have a card named 'Arboros Dragon Timber' in your soul this unit gets [Power]+1000.";
		}
		else if(id == CardIdentifier.WHITE_LILY_MUSKETEER__CECILIA)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast(1) amp Choose five normal units with 'Musketeer' in its card name from your drop zone and put the chosen cards on the bottom of your deck in any order] Search your deck for up to two cards named 'White Lily Musketeer Cecilia' call them to separate (RC) and shuffle your deck. This ability cannot be used for the rest of that turn.\n\n[ACT](VC)[Choose one of your rear-guards with 'Musketeer' in its card name and retire it] Look at up to five cards from the top of your deck search for up to one card with 'Musketeer' in its card name from among them call it to (RC) and shuffle your deck. This ability cannot be used for the rest of that turn.";
		}
		else if(id == CardIdentifier.BLUE_STORM_DRAGON__MAELSTROM)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard if it is the fourth battle of that turn or more until end of that battle this unit gets [Power]+5000 and '\n\n[AUTO](VC)[Counter Blast (1)] When this units attack hits you may pay the cost. If you do draw a card choose one opponents rear-guards and retire it.'.[CONT](VC/RC)If you have a non-Aqua Force vanguard or rear-guard this unit gets [Power]-2000.";
		}
		else if(id == CardIdentifier.HYDRO_HURRICANE_DRAGON)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2)] Until end of turn this unit gets [Power]+3000 and '\n\n[AUTO](VC)When this units attack hits a vanguard if it is the fourth battle of that turn or more retire all of your opponents rear-guards.'.\n\n[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.STORM_RIDER__BASIL)
		{
			desc +="[AUTO](RC)When this unit attacks a vanguard if you have an Aqua Force vanguard and if it is the first battle of that turn this unit gets [Power]+2000 until end of that battle and at the beginning of the close step of that battle choose another of your Aqua Force rear-guards in the same column as this unit and exchange positions with this unit. (The state of the card does not change.)";
		}
		else if(id == CardIdentifier.SEALED_DEMON_DRAGON__DUNGAREE)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1) amp Choose a card bound with this cards effect and put it on the bottom of the deck] Choose one of your opponents rear-guards in the front row and retire it. This ability cannot be used for the rest of that turn.[CONT](VC/RC)If you do not have any cards in your bind zone that was bound with this cards effect this unit gets [Power]-2000.\n\n[AUTO]When this unit is placed on (VC) bind two cards from the top of your deck.";
		}
		else if(id == CardIdentifier.OPERATOR_GIRL__MIKA)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits if you have a Dimension Police vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIDRAGON)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Dimensional Robo' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.CHERRY_BLOSSOM_MUSKETEER__AUGUSTO)
		{
			desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'Musketeer' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__KAIVANT)
		{
			desc +="[AUTO][Counter Blast (1) amp Choose another of your rear-guards with 'Musketeer' in its card name and retire it] When this unit is placed on (VC) or (RC) if you have a Neo Nectar vanguard you may pay the cost. If you do look at up to four cards from the top of your deck search for up to one card with 'Musketeer' in its card name from among them call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.MAIDEN_OF_RAINBOW_WOOD)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits if you have a Neo Nectar vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.WATER_LILY_MUSKETEER__RUTH)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Musketeer' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.LILY_OF_THE_VALLEY_MUSKETEER__REBECCA)
		{
			desc +="[AUTO][Counter Blast (1) amp Choose another of your rear-guards with 'Musketeer' in its card name and retire it] When this unit is placed on (VC) or (RC) if you have a Neo Nectar vanguard you may pay the cost. If you do look at up to four cards from the top of your deck search for up to one card with 'Musketeer' in its card name from among them call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.MILITARY_DRAGON__RAPTOR_COLONEL)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1) amp Choose two of your Tachikaze rear-guards and retire them] When this unit attacks a vanguard you may pay the cost. If you do increase this units [Power] by the sum of the original [Power] of the units retired as the cost until end of that battle.[CONT](VC)If you have a card named 'Military Dragon Raptor Captain' in your soul this unit gets [Power]+1000.";
		}
		else if(id == CardIdentifier.DESTRUCTION_DRAGON__DARK_REX)
		{
			desc +="[AUTO](Bind zone) Limit Break 4 (This ability is active if you have four or more damage)[Choose three of your Tachikaze rear-guards and retire them] At the beginning of the close step of the battle that your grade 3 or greater Tachikaze vanguard attacked if the attack did not hit during that battle you may pay the cost. If you do ride this card.\n\n[ACT](Hand)[Bind this card] Choose up to one of your Tachikaze and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.TEAR_KNIGHT__VALERIA)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard if you have an Aqua Force vanguard if it is the fourth battle of that turn or more choose one of your opponents rear-guards and retire it.";
		}
		else if(id == CardIdentifier.EMERALD_SHIELD__PASCHAL)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose an Aqua Force from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Aqua Force that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.ARMED_INSTRUCTOR__BISON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)During your end phase when one of your Great Nature rear-guards is put into the drop zone choose up to two cards from your damage zone and turn them face up.\n\n[ACT](VC)[Counter Blast (2)] Choose one of your Great Nature rear-guards and that unit gets [Power]+4000 until end of turn and at the beginning of the end phase of that turn retire that unit.";
		}
		else if(id == CardIdentifier.ENIGMAN_CYCLONE)
		{
			desc +="[AUTO](VC) At the beginning of your attack step if this units [Power] is 14000 or greater this unit gets '\n\n[AUTO](VC) When this units attack hits a vanguard choose one of your opponents rear-guards and retire it.' until end of that battle.";
		}
		else if(id == CardIdentifier.LADY_JUSTICE)
		{
			desc +="[AUTO](VC/RC)When this unit attacks a vanguard if you have a Dimension Police vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.SUBTERRANEAN_BEAST__MAGMA_LORD)
		{
			desc +="[AUTO](VC)At the beginning of your main phase Soul Charge (1) and this unit gets [Power]+2000 until end of turn.\n\n[ACT](VC)[Counter Blast (5) amp Soul Blast (8)] Choose one opponents vanguard that unit gets [Power]-5000 until end of turn and retire all of your opponents rear-guards with [Power] 5000 or less.";
		}
		else if(id == CardIdentifier.DEVOURER_OF_PLANETS__ZEAL)
		{
			desc +="[CONT](VC) If you have a card named 'Eye of Destruction Zeal' in your soul this unit gets [Power]+1000.[AUTO] When a card named 'Galactic Beast Zeal' rides this unit if you have a card named 'Eye of Destruction Zeal' in your soul choose one of your opponents vanguard and that unit gets [Power]-3000 until end of turn.";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAILANDER)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (RC) you may pay the cost. If you do choose another of your units with 'Dimensional Robo' in its card name and that unit gets [Power]+4000 until end of turn.";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__GOYUSHA)
		{
			desc +="[AUTO]When another Dimension Police rides this unit you may call this card to (RC).\n\n[ACT](RC)[Choose four of your rear-guards with 'Dimensional Robo' in its card names and put them into your soul] If you have a grade 2 or greater Dimension Police vanguard with 'Dimensional Robo' in its card name search your deck for up to one grade 3 card with 'Dimensional Robo' in its card name ride it and shuffle your deck.";
		}
		else if(id == CardIdentifier.LARVA_BEAST__ZEAL)
		{
			desc +="[AUTO] When a card named 'Eye of Destruction Zeal' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Galactic Beast Zeal' or 'Devourer of Planets Zeal' from among them reveal it to your opponent put it into your hand and shuffle your deck.AUTO When a Dimension Police other than a card named 'Eye of Destruction Zeal' rides this unit you may call this card to Rear-guard Circle.";
		}
		else if(id == CardIdentifier.ARBOROS_DRAGON__TIMBER)
		{
			desc +="[CONT](VC)If you have a card named 'Arboros Dragon Branch' in your soul this unit gets [Power]+1000.[AUTO]When a card named 'Arboros Dragon Sephirot' rides this unit if you have a card named 'Arboros Dragon Branch' in your soul choose one of your Neo Nectar rear-guards search your deck for up to one card with the same name as that unit call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.ARBOROS_DRAGON__RATOON)
		{
			desc +="[AUTO]When a card named 'Arboros Dragon Branch' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Arboros Dragon Sephirot' or 'Arboros Dragon Timber' from among them reveal it to your opponent put it into your hand and shuffle your deck.\n\n[AUTO]When a Neo Nectar other than a card named 'Arboros Dragon Branch' rides this unit you may call this card to (RC).";
		}
		else if(id == CardIdentifier.MILITARY_DRAGON__RAPTOR_CAPTAIN)
		{
			desc +="[CONT](VC) If you have a card named 'Military Dragon Raptor Sergeant' in your soul this unit gets Power +1000. [AUTO] When a card named 'Military Dragon Raptor Colonel' rides this unit if you have a card named 'Military Dragon Raptor Sergeant' in your soul search your deck for up to one card named 'Military Dragon Raptor Captain' call it to Rear-guard Circle and shuffle your deck. ";
		}
		else if(id == CardIdentifier.WINGED_DRAGON__SLASHPTERO)
		{
			desc +="[AUTO] During your battle phase when this unit is put into the drop zone from Rear-guard Circle choose one of your Tachikaze and that unit gets Power +3000 until end of turn.";
		}
		else if(id == CardIdentifier.ASSAULT_DRAGON__PACHYPHALOS)
		{
			desc +="[AUTO]V/R When this unit attacks if a Tachikaze is put into the drop zone from Rear-guard Circle during this turn this unit gets Power +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.WINGED_DRAGON__BEAMPTERO)
		{
			desc +="[AUTO] During your battle phase when this unit is put into the drop zone from (RC) choose one of your Tachikaze and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.MILITARY_DRAGON__RAPTOR_SOLDIER)
		{
			desc +="[AUTO] When a card named 'Military Dragon Raptor Sergeant' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Military Dragon Raptor Colonel' or 'Military Dragon Raptor Captain' from among them reveal it to your opponent put it into your hand and shuffle your deck. \n\n[AUTO] When a Tachikaze other than a card named 'Military Dragon Raptor Sergeant' rides this unit you may call this card to Rear-guard Circle. ";
		}
		else if(id == CardIdentifier.STORM_RIDER__DIAMANTES)
		{
			desc +="[AUTO](RC) When this unit attacks a vanguard if you have an Aqua Force vanguard and if it is the first battle of that turn this unit gets [Power]+2000 until end of that battle and at the beginning of the close step of that battle choose another of your Aqua Force rear-guards in the same column as this unit and exchange positions with this unit. (The state of the card does not change)";
		}
		else if(id == CardIdentifier.STORM_RIDER__EUGEN)
		{
			desc +="[AUTO](RC)When this unit attacks a vanguard if you have an Aqua Force vanguard and if it is the first battle of that turn this unit gets [Power]+2000 until end of that battle and at the beginning of the close step of that battle choose another of your Aqua Force rear-guards in the same column as this unit and exchange positions with this unit. (The state of the card does not change.)";
		}
		else if(id == CardIdentifier.TORPEDO_RUSH_DRAGON)
		{
			desc +="[AUTO](RC) When this unit boosts an Aqua Force if you have an Aqua Force vanguard if the number of battles during this turn is four or more the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.AQUA_BREATH_DRACOKID)
		{
			desc +="[AUTO]When another Aqua Force rides this unit you may call this card to (RC).\n\n[ACT](RC)[Put this unit into your soul] Choose up to one of your Aqua Force and until end of turn that unit gets [Power]+1000 and '\n\n[AUTO](VC/RC)When this units attack hits a vanguard if you have an Aqua Force vanguard if it is the fourth battle of that turn or more draw a card.'.";
		}
		else if(id == CardIdentifier.THUNDER_SPEAR_WIELDING_EXORCIST_KNIGHT)
		{
			desc +="[CONT](VC/RC) Restraint (This unit cannot attack.)[ACT](VC/RC)[Counter Blast (1)] Until end of turn if you have a Narukami vanguard this unit loses 'Restraint' until end of turn.\n\n[AUTO](VC/RC)When this unit attacks if you have a Narukami vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.COMPASS_LION)
		{
			desc +="[AUTO](VC/RC)At the beginning of your end phase choose one of your rear-guards and retire it.";
		}
		else if(id == CardIdentifier.COILING_DUCKBILL)
		{
			desc +="[AUTO]During your main phase when this unit is placed on (RC) choose another of your Great Nature rear-guards and that unit gets '\n\n[AUTO]During your end phase when this unit is put into the drop zone from (RC) draw a card.' until end of turn.";
		}
		else if(id == CardIdentifier.INTERDIMENSIONAL_NINJA__TSUKIKAGE)
		{
			desc +="[AUTO][V/R] When this unit is boosted by a Dimension Police this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.COSMIC_MOTHERSHIP)
		{
			desc +="[AUTO] [Counter Blast (1)] When this unit is placed on Vanguard Circle or Rear-guard Circle if you have a Dimension Police vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.COSMIC_RIDER)
		{
			desc +="[AUTO] When this unit is placed on Rear-guard Circle choose another of your Dimension Police and that unit gets Power +2000 until end of turn.";
		}
		else if(id == CardIdentifier.ASSAULT_MONSTER__GUNROCK)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the battle opponents [Power] is 8000 or less this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.EYE_OF_DESTRUCTION__ZEAL)
		{
			desc +="CONT V If you have a card named 'Larva Beast Zeal' in your soul this unit gets Power +1000.[AUTO] When a card named 'Devourer of Planets Zeal' rides this unit if you have a card named 'Larva Beast Zeal' in your soul choose up to one of your opponents vanguard it gets Power -3000 until end of turn.";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIMARINER)
		{
			desc +="[ACT](Soul)[Put this card into your drop zone] Choose one of your Dimension Police vanguards and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.MYSTERIOUS_NAVY_ADMIRAL__GOGOTH)
		{
			desc +="[AUTO][RC] During the battle when this unit boosts a ltDimension Policegt and the attack hits a vanguard you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.PSYCHIC_GREY)
		{
			desc +="[AUTO](RC) When this unit boosts a ltDimension Policegt vanguard if the power of the battle opponent of the boosted unit is 8000 or less the boosted unit gets Power +4000 until end of that battle.";
		}
		else if(id == CardIdentifier.SPEEDSTER)
		{
			desc +="[AUTO] When this unit is placed on Rear-guard Circle choose another of your Dimension Police and that unit gets Power +2000 until end of turn.";
		}
		else if(id == CardIdentifier.FIGHTING_SAUCER)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Dimension Police vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.WARRIOR_OF_DESTINY__DAI)
		{
			desc +="[AUTO] When another Dimension Police rides this unit you may call this card to Rear-guard Circle.\n\n[ACT] [Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Dimension Police from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.DISSECTION_MONSTER__KAIZON)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.DIMENSIONAL_ROBO__DAIBATTLES)
		{
			desc +="[ACT](Soul)[Put this unit into your drop zone] Choose one of your Dimension Police vanguards and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.BLACK_LILY_MUSKETEER__HERMANN)
		{
			desc +="[AUTO](VC/RC) When this unit is boosted by a Neo Nectar this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.WORLD_SNAKE__OUROBOROS)
		{
			desc +="[AUTO](VC/RC) [Choose 1 card from your hand and discard it] When this units attack hits and you have a Neo Nectar Vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.EXPLODING_TOMATO)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard choose 1 of your Neo Nectar and it gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.WORLD_BEARING_TURTLE__AHKBARA)
		{
			desc +="[AUTO](RC) When this units attack hits a vanguard choose 1 of your Neo Nectar and it gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.TULIP_MUSKETEER__ALMIRA)
		{
			desc +="[AUTO] [Counter Blast (1)] When this unit is placed on Vanguard Circle or Rear-guard Circle if you have a Neo Nectar vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.POISON_MUSHROOM)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard if you have four or more other Neo Nectar rear-guards draw a card.";
		}
		else if(id == CardIdentifier.ARBOROS_DRAGON__BRANCH)
		{
			desc +="[CONT](VC)If you have a card named 'Arboros Dragon Ratoon' in your soul this unit gets [Power]+1000.[AUTO]When a card named 'Arboros Dragon Timber' rides this unit if you have a card named 'Arboros Dragon Ratoon' in your soul choose one of your Neo Nectar rear-guards search your deck for up to one card with the same name as that unit call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.TULIP_MUSKETEER__MINA)
		{
			desc +="[AUTO][Counter Blast(1)] When this unit is placed on (VC) or (RC) if you have a Neo Nectar vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.BOON_BANA_NA)
		{
			desc +="[AUTO](RC) When an attack hits a vanguard during the battle that this unit boosted a Neo Nectar you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.FRUITS_BASKET_ELF)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Neo Nectar that is attacking a vanguard if you have a Neo Nectar vanguard you may pay the cost. If you do until end of that battle your opponent cannot normal call units to (GC) and the boosted unit does not deal damage even if its attack hits.";
		}
		else if(id == CardIdentifier.BROCCOLINI_MUSKETEER__KIRAH)
		{
			desc +="[AUTO] When another Neo Nectar rides this unit you may call this card to Rear-guard Circle. \n\n[ACT](RC) [Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Neo Nectar from among them reveal it to your opponent put it into your hand and shuffle your deck. ";
		}
		else if(id == CardIdentifier.HIBISCUS_MUSKETEER__HANAH)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.SAVAGE_WAR_CHIEF)
		{
			desc +="[AUTO](VC/RC) When this unit is boosted by a Tachikaze this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.CITADEL_DRAGON__BRACHIOCASTLE)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is put into the drop zone from (RC) if you have a Tachikaze vanguard you may pay the cost. If you do search your deck for up to one card named 'Transport Dragon Brachioporter' call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.SAVAGE_WARLOCK)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Tachikaze vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.CARRIER_DRAGON__BRACHIOCARRIER)
		{
			desc +="[AUTO][Counter Blast(1)] When this unit is put into the drop zone from (RC) if you have a Tachikaze vanguard you may pay the cost. If you do search your deck for up to one card named 'Citadel Dragon Brachiocastle' call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.MILITARY_DRAGON__RAPTOR_SERGEANT)
		{
			desc +="[CONT](VC) If you have a card named 'Military Dragon Raptor Soldier' in your soul this unit gets [Power]+1000. [AUTO] When a card named 'Military Dragon Raptor Captain' rides this unit if you have a card named 'Military Dragon Raptor Soldier' in your soul search your deck for up to one card named 'Military Dragon Raptor Sergeant' call it to Rear-guard Circle and shuffle your deck. ";
		}
		else if(id == CardIdentifier.SAVAGE_MAGUS)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Tachikaze vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.FORTRESS_AMMONITE)
		{
			desc +="[AUTO](RC) [Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.TRANSPORT_DRAGON__BRACHIOPORTER)
		{
			desc +="[AUTO][Counter Blast(1)] When this unit is put into the drop zone from (RC) if you have a Tachikaze vanguard you may pay the cost. If you do search your deck for up to one card named 'Carrier Dragon Brachiocarrier' call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.BABY_PTERO)
		{
			desc +="[AUTO]When another Tachikaze rides this unit you may call this card to (RC).\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Tachikaze from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.IRONCLAD_DRAGON__STEELSAURUS)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.TITAN_OF_THE_PYROXENE_MINE)
		{
			desc +="[AUTO](VC/RC) When this unit is boosted by an Aqua Force this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.DISTANT_SEA_ADVISOR__VASSILIS)
		{
			desc +="[AUTO](VC/RC) [Choose a card from your hand and discard it] When this units attack hits if you have an Aqua Force vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.VETERAN_STRATEGIC_COMMANDER)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have an Aqua Force vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.WHALE_SUPPLY_FLEET__KAIRIN_MARU)
		{
			desc +="[AUTO]V/R When this units attack hits a vanguard if you have four or more other Aqua Force rear-guards draw a card.";
		}
		else if(id == CardIdentifier.STREAM_TROOPER)
		{
			desc +="[AUTO](RC) When an attack hits a vanguard during the battle that this unit boosted a Aqua Force you may return this unit to your hand.";
		}
		else if(id == CardIdentifier.RELIABLE_STRATEGIC_COMMANDER)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have an Aqua Force vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.OFFICER_CADET__ERIKK)
		{
			desc +="[AUTO]Forerunner (When a unit with the same clan of this unit rides this unit you may call this card to (RC).\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Aqua Force from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.BLACK_CELESTIAL_MAIDEN__KALI)
		{
			desc +="[AUTO](VC)When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets [Power]+3000 until end of that battle.\n\n[AUTO](RC)When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets [Power]+1000 until end of that battle.";
		}
		else if(id == CardIdentifier.DRAGON_MONK__KINKAKU)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Narukami vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.LIGHTNING_SWORD_WIELDING_EXORCIST_KNIGHT)
		{
			desc +="[CONT](RC)This unit gets [Power]-4000.[AUTO](VC/RC)When this unit attacks if you have a Narukami vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.DRAGON_MONK__GINKAKU)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on Vanguard Circle or Rear-guard Circle if you have a Narukami vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.EXORCIST_MAGE__KOH_KOH)
		{
			desc +="[AUTO]When another Narukami rides this unit you may call this card to (RC).\n\n[ACT](RC)[Soul Blast (1)] Choose a [CONT] of one of your Narukami vanguard or rear-guards and that ability is lost until end of turn.";
		}
		else if(id == CardIdentifier.BLACKBOARD_PARROT)
		{
			desc +="[AUTO] When another Great Nature rides this unit you may call this card to Rear-guard Circle. \n\n[ACT]R [Put this unit into your soul] Choose one of your Great Nature rear-guards and that unit gets 'AUTO During your end phase when this unit is put into the drop zone from Rear-guard Circle draw a card.' until end of turn. ";
		}
		else if(id == CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2)] This unit gets [Power]+3000 until end of turn and search your deck for up to two cards named 'Covert Demonic Dragon Magatsu Storm' call them to separate (RC) shuffle your deck and at the end of that turn put the units called with this effect on the bottom of your deck in any order. [CONT](VC)If you have a card named 'Stealth Dragon Magatsu Gale' in your soul this unit gets [Power]+1000.";
		}
		else if(id == CardIdentifier.BLUE_STORM_SUPREME_DRAGON__GLORY_MAELSTROM)
		{
			desc +="[AUTO](VC) Limit Break 5 (This ability is active if you have five or more damage)[Counter Blast (1)] When this unit attacks a vanguard you may pay the cost. If you do until end of that battle this unit gets [Power]+5000 and your opponent cannot call grade 1 or greater units to (GC) from his or her hand.[CONT](VC)If you have a card named 'Blue Storm Dragon Maelstrom' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.GODDESS_OF_THE_SUN__AMATERASU)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2)] When this units attack hits a vanguard you may pay the cost. If you do search your deck for up to one Oracle Think Tank reveal it to your opponent put it into your hand and shuffle your deck.[CONT](VC)If you have a card named 'CEO Amaterasu' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.ULTRA_BEAST_DEITY__ILLUMINAL_DRAGON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (3)] When this unit attacks a vanguard you may pay the cost. If you do choose up to two of your rear-guards with 'Beast Deity' in its card name and [Stand] them.[CONT](VC)If you have a card named 'Beast Deity Azure Dragon' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.CRIMSON_IMPACT__METATRON)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1) amp Choose two of your Angel Feather rear-guards and put them into your damage zone] Choose two face up Angel Feather from your damage zone and call them to (RC). This ability cannot be used for the rest of that turn.\n\n[AUTO](VC) When this unit attacks a vanguard this unit gets [Power]+3000 until the end of that battle.";
		}
		else if(id == CardIdentifier.BLAZING_LION__PLATINA_EZEL)
		{
			desc +="[ACT](VC) Limit Break 5 (This ability is active if you have five or more damage)[Counter Blast (3)] Choose up to five of your Gold Paladin rear-guards and those units get [Power]+5000 until end of turn.[CONT](VC)If you have a card named 'Incandescent Lion Blond Ezel' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.CONVICTION_DRAGON__CHROMEJAILER_DRAGON)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp Choose two of your Gold Paladin rear-guards and retire them] This unit gets [Power]+10000/[Critical]+1 until end of turn.\n\n[ACT] (VC)[Counter Blast (1) amp Choose a card named 'Conviction Dragon Chromejailer Dragon' from your hand and discard it] Look at up to four cards from the top of your deck search for up to two Gold Paladin from among them call them to separate open (RC) and put the rest on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.DRAGONIC_KAISER_VERMILLION______THE_BLOOD_____)
		{
			desc +="[ACT](VC) Limit Break 5 (This ability is active if you have five or more damage)[Counter Blast (3)] Until end of turn this unit gets [Power]+5000/[Critical]+1 and '[CONT](VC)This unit battles all of your opponents units in the front row in one attack.'.[CONT](VC)If you have a card named 'Dragonic Kaiser Vermillion' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.FANTASY_PETAL_STORM__SHIRAYUKI)
		{
			desc +="[AUTO] (VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1) amp Choose a card named 'Fantasy Petal Storm Shirayuki' from your hand and discard it] At the beginning of the guard step of the battle that this unit was attacked you may pay the cost. If you do choose an attacking unit and that unit gets [Power]-20000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.PLATINUM_BLOND_FOX_SPIRIT__TAMAMO)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[ACT](VC)[Counter Blast (1)] Choose one of your grade 2 or greater Murakumo rear-guards search your deck up to one card with the same card name as that unit call it to (RC) shuffle your deck and at the end of that turn put the unit called with this effect on the bottom of your deck.";
		}
		else if(id == CardIdentifier.TRI_STINGER_DRAGON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard if it is the third battle of that turn or more choose up to two cards from your damage zone and turn them face up.\n\n[ACT](VC)[Counter Blast (2)] Choose one of your Aqua Force rear-guards and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.BATTLE_SISTER__COOKIE)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO][Counter Blast (2)] When this unit is placed on (VC) you may pay the cost. If you do draw two cards choose a card from your hand and discard it.";
		}
		else if(id == CardIdentifier.BATTLER_OF_THE_TWIN_BRUSH__POLARIS)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2)] When this unit attacks a vanguard you may pay the cost. If you do choose another of your Great Nature rear-guards [Stand] it and that unit gets [Power]+4000 until end of turn and at the end of that turn retire that unit.\n\n[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.HALO_SHIELD__MARK)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck.)[AUTO][Choose a Gold Paladin from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Gold Paladin that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.LORD_OF_THE_DEMONIC_WINDS__VAYU)
		{
			desc +="[AUTO](VC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+10000 for each unit named 'Lord of the Demonic Winds Vayu' on your (RC) until end of that battle.";
		}
		else if(id == CardIdentifier.WYVERN_GUARD__GULD)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck.)[AUTO][Choose a Narukami from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Narukami that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.STARLIGHT_MELODY_TAMER__FARAH)
		{
			desc +="[ACT] (VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1) amp Choose a card named 'Starlight Melody Tamer Farah' from your hand and discard it] Soul Charge (2) choose up to one Pale Moon from your soul call it to (RC) and that unit gets [Power]+3000 until end of turn.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.NIGHTMARE_SUMMONER__RAQIEL)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO][Counter Blast (2)] When this unit is placed on (VC) you may pay the cost. If you do choose up to one Pale Moon from your soul and call it to (RC).";
		}
		else if(id == CardIdentifier.BLASTER_BLADE_SPIRIT)
		{
			desc +="[AUTO][Counter Blast(1)] When this card is placed on (RC) from your deck you may pay the cost. If you do choose one of your opponents grade 2 or greater rear-guards in the front row and retire it.\n\n[AUTO](RC) At the end of the battle that this unit was attacked retire this unit.[CONT] This card is also a Gold Paladin.";
		}
		else if(id == CardIdentifier.BLASTER_DARK_SPIRIT)
		{
			desc +="[AUTO][Counter Blast (1)] When this card is placed on (RC) from your deck you may pay the cost. If you do choose one of your opponents grade 2 or less rear-guards in the front row and retire it.\n\n[AUTO](RC)At the end of the battle that this unit was attacked retire this unit.[CONT]This card is also a Gold Paladin.";
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__MAGATSU_GALE)
		{
			desc +="[CONT](VC)If you have a card named 'Stealth Dragon Magatsu Breath' in your soul this unit gets [Power]+1000.[AUTO]When a card named 'Covert Demonic Dragon Magatsu Storm' rides this unit if you have a card named 'Stealth Dragon Magatsu Breath' in your soul search your deck for up to two cards named 'Covert Demonic Dragon Magatsu Storm' call them to separate (RC) shuffle your deck and at the end of that turn put the units called with this effect on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.STEALTH_FIEND__OBORO_CART)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Murakumo vanguard you may pay the cost. If you do choose one of you Murakumo rear-guards not named 'Stealth Fiend Oboro Cart' search your deck for up to one card with the same card name as that unit call it to (RC) shuffle your deck and at the end of that turn put the unit called with this effect on the bottom of your deck.";
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__MAGATSU_WIND)
		{
			desc +="[AUTO]When a card named 'Stealth Dragon Magatsu Breath' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Covert Demonic Dragon Magatsu Storm' or 'Stealth Dragon Magatsu Gale' from among them reveal it to your opponent put it into your hand and shuffle your deck.\n\n[AUTO]When a Murakumo not named 'Stealth Dragon Magatsu Breath' rides this unit you may call this card to (RC).";
		}
		else if(id == CardIdentifier.STORM_RIDER__LYSANDER)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] At the end of the battle that this unit attacked a vanguard if you have an Aqua Force vanguard you may pay the cost. If you do choose another of your Aqua Force rear-guards in the same column as this unit and exchange positions with this unit. (The state of the card does not change.)";
		}
		else if(id == CardIdentifier.STORM_RIDER__DAMON)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] At the end of the battle that this unit attacked a vanguard if you have an Aqua Force vanguard you may pay the cost. If you do choose another of your Aqua Force rear-guards in the same column as this unit and exchange positions with this unit. (The state of the card does not change.)";
		}
		else if(id == CardIdentifier.BATTLE_SIREN__THERESA)
		{
			desc +="[AUTO](RC) When this unit attacks if you have an Aqua Force vanguard and if it is the third battle of that turn or more choose your vanguard and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.STORM_RIDER__NICOLAS)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] At the end of the battle that this unit attacked a vanguard if you have an Aqua Force vanguard you may pay the cost. If you do choose another of your Aqua Force rear-guards in the same column as this unit and exchange positions with this unit. (The state of the card does not change.)";
		}
		else if(id == CardIdentifier.TRI_HOLL_DRACOKID)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC) When this unit attacks if you have an Aqua Force vanguard and if it is the third battle of that turn or more this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BATTLE_DEITY__SUSANOO)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Amaterasu' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__SAYORIHIME)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Amaterasu' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__YAMATANO_DRAKE)
		{
			desc +="[AUTO](RC) During your battle phase when this unit becomes [Stand] this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.HOLLOW_NOMAD)
		{
			desc +="[AUTO](VC/RC) When this unit attacks a vanguard if you have a Nova Grappler vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__GOLDEN_ANGLET)
		{
			desc +="[AUTO](RC)During your battle phase when this unit becomes [Stand] this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__BLANK_MARSH)
		{
			desc +="[AUTO](RC)[Counter Blast (1) amp Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Nova Grappler you may pay the cost. If you do choose one of your rear-guards with 'Beast Deity' in its card name and [Stand] it.";
		}
		else if(id == CardIdentifier.MOBILE_HOSPITAL__ELYSIUM)
		{
			desc +="[AUTO](VC)[Choose an Angel Feather from your hand and discard it] When this unit attacks you may pay the cost. If you do this unit gets [Power]+6000 until end of that battle.\n\n[AUTO](RC)[Choose an Angel Feather from your hand and discard it] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_PASSION__BAGDEMAGUS)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Ezel' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ADVANCE_OF_THE_BLACK_CHAINS__KAHEDIN)
		{
			desc +="[AUTO](RC)[Counter Blast (1) amp Choose another of your Gold Paladin rear-guards and retire it] When an attack hits a vanguard during the battle that this unit boosted a Gold Paladin you may pay the cost. If you do look at the top card of your deck search for up to one Gold Paladin from among them call it to an open (RC) as [Rest] and put the rest on the bottom of your deck.";
		}
		else if(id == CardIdentifier.DREAMING_SAGE__CORRON)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one card with 'Ezel' in its card name reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.DUSTY_PLASMA_DRAGON)
		{
			desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'Vermillion' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.EXORCIST_DEMONIC_DRAGON__INDIGO)
		{
			desc +="[CONT](RC)This unit cannot boost grade 2 or less units.[AUTO](RC)When this unit boosts a Narukami the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BARKING_WYVERN)
		{
			desc +="[AUTO](VC)[Choose an Pale Moon from your hand and discard it] When this unit attacks you may pay the cost. If you do this unit gets [Power]+6000 until end of that battle.\n\n[AUTO](RC)[Choose an Pale Moon from your hand and discard it] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.FIRE_JUGGLER)
		{
			desc +="[AUTO](RC)When the drive check of the vanguard that this unit boosted reveals a grade 3 Pale Moon this unit gets '\n\n[AUTO](RC)[Put this unit into your soul] At the end of the battle that this unit boosted you may pay the cost. If you do choose a Pale Moon not named 'Fire Juggler' from your soul and call it to (RC).' until end of that battle.";
		}
		else if(id == CardIdentifier.SPIKED_CLUB_STEALTH_ROGUE__ARAHABAKI)
		{
			desc +="[AUTO](VC/RC)When this unit is boosted by a Murakumo this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__GIGANTOAD)
		{
			desc +="[CONT](VC)During your turn if you have another unit named 'Stealth Beast Gigantoad' on your (RC) this unit gets [Power]+3000.[CONT](RC)During your turn if you have another unit named 'Stealth Beast Gigantoad' on your (RC) this unit gets [Power]+1000.";
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__ROYALE_NOVA)
		{
			desc +="[CONT](VC/RC) If you do not have a unit named 'Covert Demonic Dragon Magatsu Storm' or 'Stealth Dragon Magatsu Gale' on your (VC) this units gets [Power]-5000. [AUTO](VC/RC) When this unit attacks this unit gets [Power]+2000 until end of battle.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__SPELL_HOUND)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Murakumo vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the end of that turn choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_SUMMONING__JIRAIYA)
		{
			desc +="[ACT](RC)[Counter Blast (1) amp Put this unit on the bottom of your deck] If you have a Murakumo vanguard search your deck for up to one card named 'Stealth Beast Gigantoad' call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.STEALTH_DRAGON__MAGATSU_BREATH)
		{
			desc +="[CONT](VC)If you have a card named 'Stealth Dragon Magatsu Wind' in your soul this unit gets [Power]+1000.[AUTO]When a card named 'Stealth Dragon Magatsu Gale' rides this unit if you have a card named 'Stealth Dragon Magatsu Wind' in your soul search your deck for up to two cards named 'Stealth Dragon Magatsu Gale' call them to separate (RC) shuffle your deck and at the end of that turn put the units called with this effect on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__NIGHT_PANTHER)
		{
			desc +="[ACT](VC/RC)[Counter Blast(1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__FLAME_FOX)
		{
			desc +="[AUTO](RC) [Soul Blast (1)] When this unit boosts a unit named Platinum Blond Fox Spirit Tamamo you may pay the cost. If you do the boosted unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.STEALTH_ROGUE_OF_BODY_REPLACEMENT__KOKUENMARU)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Murakumo from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.STEALTH_BEAST__CAT_DEVIL)
		{
			desc +="[ACT](RC)[Put this unit into your soul] Choose up to one of your Murakumo and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.DECK_SWEEPER)
		{
			desc +="[AUTO](RC)[Soul Blast(1)] When this unit boosts a unit with 'Maelstrom' in its card name you may pay the cost. If you do the boosted unit gets [Power]+6000 until end of that battle.";
		}
		else if(id == CardIdentifier.LIGHT_SIGNALS_PENGUIN_SOLDIER)
		{
			desc +="[AUTO][Soul Blast (2)] When this unit is placed on (RC) if you have an Aqua Force vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.OFFICER_CADET__ASTRAEA)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Counter Blast (1) amp Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Aqua Force you may pay the cost. If you do choose one of your Aqua Force rear-guards and [Stand] it.";
		}
		else if(id == CardIdentifier.SUPERSONIC_SAILOR)
		{
			desc +="[ACT](RC)[Put this unit into your soul] If you have a Aqua Force vanguard choose up to one card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.GENTLE_JIMM)
		{
			desc +="[AUTO](VC/RC)[Soul Blast (1) amp Choose one card from your hand and discard it] When this unit attacks a vanguard you may pay the cost. If you do choose another of your Oracle Think Tank and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.ORACLE_GUARDIAN__SPHINX)
		{
			desc +="[ACT](VC/RC) [Counter Blast (2)] This unit gets [Power]+4000 until end of turn.";
		}
		else if(id == CardIdentifier.ROCK_WITCH__GAGA)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if you do not have any cards in your soul draw a card choose a card from your hand and put it on the bottom of your deck.";
		}
		else if(id == CardIdentifier.BATTLE_SISTER__CREAM)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit named 'Battle Sister Cookie' you may pay the cost. If you do the boosted unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.MACHINE_GUN_TALK__RYAN)
		{
			desc +="[AUTO](VC/RC)[Soul Blast(1) amp Choose one card from your hand and discard it] When this unit attacks a vanguard you may pay the cost. If you do choose another of your Oracle Think Tank and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.SOLAR_MAIDEN__UZUME)
		{
			desc +="[ACT](RC)[Counter Blast (1) amp Choose two of your Oracle Think Tank rear-guards and retire them] Search your deck for up to one card named 'Goddess of the Sun Amaterasu' reveal it to your opponent put it to your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.SUPPLE_BAMBOO_PRINCESS__KAGUYA)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Put this unit into your soul] Choose up to one of your Oracle Think Tank and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.HEROIC_HANI)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Nova Grappler vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the end of that turn choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.TRANSRAIZER)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) reveal the top card of your deck. If the revealed card is a grade 1 or 2 Nova Grappler call that card to (RC) and if it is not shuffle your deck.";
		}
		else if(id == CardIdentifier.BURSTRAIZER)
		{
			desc +="[ACT](VC/RC)[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
		}
		else if(id == CardIdentifier.STOIC_HANI)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Nova Grappler vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the end of that turn choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.TRANSMIGRATING_EVOLUTION__MIRAIOH)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Nova Grappler from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.LIONET_HEAT)
		{
			desc +="[[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Put this unit into your soul] Choose up to one of your Nova Grappler and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.CRIMSON_DRIVE__APHRODITE)
		{
			desc +="[ACT](Damage Zone)[Turn this card from face up to face down] Choose your Angel Feather vanguard and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.EXAMINE_ANGEL)
		{
			desc +="[AUTO] When this unit is placed on (VC) or (RC) reveal the top card of your deck. If the revealed card is a grade 1 or 2 Angel Feather call that card to (RC) and if it is not shuffle your deck.";
		}
		else if(id == CardIdentifier.CRIMSON_MIND__BARUCH)
		{
			desc +="[ACT](Damage Zone)[Turn this card from face up to face down] Choose your Angel Feather vanguard and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.EMERGENCY_VEHICLE)
		{
			desc +="[AUTO][Counter Blast(1)] When this unit is placed on (GC) if you have an Angel Feather vanguard you may pay the cost. If you do this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.CANDLELIGHT_ANGEL)
		{
			desc +="[AUTO](RC)[Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.CRIMSON_HEART__NAHAS)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Put this unit into your soul amp Choose a unit named 'Crimson Mind Baruch' from your (RC) and put it into your soul] If you have a unit named 'Crimson Drive Aphrodite' on your (VC) search your deck for up to one card named 'Crimson Impact Metatron' ride it and shuffle your deck.";
		}
		else if(id == CardIdentifier.FEVER_THERAPY_NURSE)
		{
			desc +="[ACT](Damage Zone)[Turn this card from face up to face down] Choose your Angel Feather vanguard and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.VOCAL_CHICKEN)
		{
			desc +="[AUTO] [Counter Blast (1)] During your end phase when this unit is put into your drop zone from (RC) if you have a Great Nature vanguard you may pay the cost. If you do search your deck for up to one card named 'Melodica Cat' call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.MELODICA_CAT)
		{
			desc +="[AUTO] [Counter Blast (1)] During your end phase when this unit is put into your drop zone from (RC) if you have a Great Nature vanguard you may pay the cost. If you do search your deck for up to one card named 'Recorder Dog' call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.PARABOLA_MOOSE)
		{
			desc +="[ACT](VC/RC) [Counter Blast (2)] This unit gets [Power]+4000 until end of turn.";
		}
		else if(id == CardIdentifier.BARCODE_ZEBRA)
		{
			desc +="[AUTO] When this unit is placed on (VC) or (RC) reveal the top card of your deck. If the revealed card is a grade 1 or 2 Great Nature call that card to (RC) and if it is not shuffle your deck.";
		}
		else if(id == CardIdentifier.RECORDER_DOG)
		{
			desc +="[AUTO] [Counter Blast (1)] During your end phase when this unit is put into the drop zone from Rear-guard Circle if you have a Great Nature vanguard you may pay the cost. If you do search your deck for up to one card named 'Vocal Chicken' reveal it to your opponent call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.SHARPENER_BEAVER)
		{
			desc +="[AUTO] When this unit is placed on (RC) choose another of your grade 3 Great Nature and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.PROTRACTOR_PEACOCK)
		{
			desc +="[AUTO][Counter Blast(1)] When this unit is placed on (GC) if you have an Great Nature vanguard you may pay the cost. If you do this unit gets [Shield]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.GARDENING_MOLE)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Counter Blast (1) amp Put this unit into your soul] During your end phase when another of your Great Nature rear-guards is put into your drop zone you may pay the cost. If you do put that card into your hand.";
		}
		else if(id == CardIdentifier.CASTANET_DONKEY)
		{
			desc +="[ACT](RC)[Put this unit into your soul] Choose up to one of your Great Nature and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.HOLY_MAGE_OF_THE_GALE)
		{
			desc +="[AUTO] When this unit is placed on (RC) choose another of your grade 3 Gold Paladin and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.STRONGHOLD_OF_THE_BLACK_CHAINS__HOEL)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Put this unit into your soul] Choose up to one of your Gold Paladin and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.RUNEBAU)
		{
			desc +="[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at the top card of your deck search for up to one Gold Paladin from among them call it to an open (RC) and put the rest on the bottom of your deck.";
		}
		else if(id == CardIdentifier.EXORCIST_MAGE__ROH_ROH)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) choose a [CONT] of one of your Narukami vanguard or rear-guards and that ability is lost until end of turn.";
		}
		else if(id == CardIdentifier.DEITY_SEALING_KID__SOH_KOH)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))[CONT](VC/RC) Restraint (This unit cannot attack.)[CONT](RC) This unit cannot boost a rear-guard.";
		}
		else if(id == CardIdentifier.EXORCIST_MAGE__LIN_LIN)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) choose a [CONT] of one of your Narukami vanguard or rear-guards and that ability is lost until end of turn.";
		}
		else if(id == CardIdentifier.MAGICAL_PARTNER)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit named 'Nightmare Summoner Raqiel' you may pay the cost. If you do the boosted unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.SMILING_PRESENTER)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at up to ten cards from the top of your deck search for up to one Pale Moon from among them put it into your soul and shuffle your deck.";
		}
		else if(id == CardIdentifier.PURE_HEART_JEWEL_KNIGHT__ASHLEY)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Royal Paladin rides this unit choose your vanguard and that unit gets [Power]+10000/[Critical]+1 until end of turn.\n\n[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+2000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.LEADING_JEWEL_KNIGHT__SALOME)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks if the number of rear-guards you have with 'Jewel Knight' in its card name is four or more this unit gets [Power]+2000/[Critical]+1 until end of that battle.\n\n[ACT](VC)[Counter Blast (2) - Cards with 'Jewel Knight in its card name] Search your deck for up to one card with 'Jewel Knight' in its card name call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.LIBERATOR_OF_THE_ROUND_TABLE__ALFRED)
		{
			desc += "[CONT](VC) Limit Break 4 (This ability is active if you have four or more damage)During your turn this unit gets [Power]+2000 for each of your rear-guards with 'Liberator' in its card name.[ACT](VC)[Counter Blast (2) - Cards with 'Liberator' in its card name] Look at the top card of your deck search for up to one Gold Paladin from among them call it to an open (RC) and put the rest on the bottom of your deck.[CONT](VC/RC) Lord (If you have a unit that doesnt belong to the same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.ORACLE_QUEEN__HIMIKO)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Genesis rides this unit choose up to two of your Genesis rear-guards those units get [Power]+5000 until end of turn and choose your vanguard that unit gets [Power]+10000 and '\n\n[AUTO](VC)[Soul Blast (3)] When this unit attacks a vanguard you may pay the cost. If you do draw a card.' until end of turn.\n\n[AUTO](VC)When this unit attacks a vanguard Soul Charge (1) and this unit gets [Power]+1000 until end of turn.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.ETERNAL_GODDESS__IWANAGAHIME)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Soul Blast (6)] Retire all of your opponents rear-guards in the front row.\n\n[ACT](VC)[Soul Blast (3)] This unit gets [Power]+5000 until end of turn[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.ERADICATOR__DRAGONIC_DESCENDANT)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1) amp Choose three cards with 'Eradicator' in its card name from your hand and discard them] At the end of the battle that this unit attacked if the attack did not hit during that battle you may pay the cost. If you do [Stand] this unit and gets [Critical]+1 until end of turn. This ability cannot be used for the rest of that turn.\n\n[ACT](VC)[Counter Blast (2) - Cards with 'Eradicator' in its card name] This unit gets [Power]+5000 until end of turn.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.ERADICATOR__GAUNTLET_BUSTER_DRAGON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When an opponents rear-guard is put into the drop zone with one of your cards effects this unit gets [Power]+3000/[Critical]+1 until end of turn.\n\n[ACT](VC)[Counter Blast (2) - Cards with 'Eradicator' in their card name] Your opponent chooses one of his or her rear-guards and retires it.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.BEAST_DEITY__ETHICS_BUSTER)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Nova Grappler rides this unit choose your vanguard that unit gets [Power]+10000 and '\n\n[AUTO](VC)When this unit attacks a vanguard [Stand] all of your Nova Grappler rear-guards in your front row.' until end of turn.\n\n[AUTO](VC)When this unit is boosted by a Nova Grappler this unit gets [Power]+2000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.DOGMATIZE_JEWEL_KNIGHT__SYBILL)
		{
			desc +="[AUTO][Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have a Royal Paladin vanguard you may pay the cost. If you do search your deck for up to one grade 1 or less unit with 'Jewel Knight' in its card name call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.FLASHING_JEWEL_KNIGHT__ISEULT)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck)[AUTO][Choose a Royal Paladin from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Royal Paladin that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.HALO_LIBERATOR__MARK)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Gold Paladin from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Gold Paladin that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.LIBERATOR_OF_THE_FLUTE__ESCRAD)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Cards with 'Liberator' in its card name] When this units attack hits a vanguard if you have a Gold Paladin vanguard you may pay the cost. If you do look at the top card of your deck search for up to one Gold Paladin from among them call it to an open (RC) and put the rest on the bottom of your deck.";
		}
		else if(id == CardIdentifier.BATTLE_DEITY_OF_THE_NIGHT__ARTEMIS)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Soul Blast (3)] When this unit attacks a vanguard you may pay the cost. If you do draw two cards choose a card from your hand put it into your soul and this unit gets [Power]+5000 until end of that battle.[CONT](VC)If you have a card named 'Twilight Hunter Artemis' in your soul this unit gets [Power]+1000.";
		}
		else if(id == CardIdentifier.BROOM_WITCH__CARAWAY)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits if you have a Genesis vanguard you can pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.GODDESS_OF_SELF_SACRIFICE__KUSHINADA)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Genesis from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Genesis that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.SUPREME_ARMY_ERADICATOR__ZUITAN)
		{
			desc +="[AUTO](VC/RC)When this units attack hits a vanguard if you have a vanguard with 'Eradicator' in its card name choose a card from your damage zone turn it face up and Soul Charge (1).";
		}
		else if(id == CardIdentifier.ERADICATOR_WYVERN_GUARD__GULD)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Narukami from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Narukami that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.GRATEFUL_CATAPULT)
		{
			desc +="[AUTO] (VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp Choose a card named 'Grateful Catapult' from your hand and discard it] When this unit attacks a vanguard you may pay the cost. If you do search your deck for up to two Spike Brothers call them to separate open (RC) and shuffle your deck.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.BAD_END_DRAGGER)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Spike Brothers rides this unit choose your vanguard that unit gets [Power]+10000 and '\n\n[AUTO](VC)When one of your Spike Brothers rear-guards attacks that unit gets [Power]+10000 until end of that battle and at the end of that battle put that unit on the bottom of your deck.' until end of turn.\n\n[AUTO](VC)When this unit is boosted by a Spike Brothers this unit gets [Power]+2000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.DIGNIFIED_SILVER_DRAGON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO](RC)When this unit attacks a vanguard if you have a Royal Paladin vanguard this unit gets [Power]+2000 until end of the battle.";
		}
		else if(id == CardIdentifier.FELLOWSHIP_JEWEL_KNIGHT__TRACIE)
		{
			desc +="[AUTO](RC)When this unit attacks if the number of other rear-guards you have with 'Jewel Knight' in its card name is three or more this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.JEWEL_KNIGHT__PRIZME)
		{
			desc +="[AUTO][Choose a card from your hand and discard it] When this unit is placed on (RC) if the number of other rear-guards you have with 'Jewel Knight' in its card name is three or more you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.DREAMING_JEWEL_KNIGHT__TIFFANY)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Put this unit into your soul] Choose up to two of your rear-guards with 'Jewel Knight' in its card name and those units get [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.CURVED_BLADE_LIBERATOR__JOSEPHUS)
		{
			desc +="[AUTO][Soul Blast (1) - Cards with 'Liberator' in its card name] When this unit is placed on (RC) from your deck if you have a vanguard with 'Liberator' in its card name you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.WINGAL_LIBERATOR)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosts a unit with 'Liberator' in its card name you may pay the cost. If you do choose one card named 'Blaster Blade Liberator' from your soul and call it to an open (RC).";
		}
		else if(id == CardIdentifier.WITCH_OF_WOLVES__SAFFRON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO](RC)When this unit attacks a vanguard if you have a Genesis vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__SAHOHIME)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this units attack hits a vanguard if you have a Genesis vanguard you may pay the cost. If you do Soul Charge (3).";
		}
		else if(id == CardIdentifier.TWILIGHT_HUNTER__ARTEMIS)
		{
			desc +="[CONT](VC)If you have a card named 'Bowstring of Heaven and Earth Artemis' in your soul this unit gets [Power]+1000.[AUTO](VC)When this units attack hits a vanguard Soul Charge (2) and if you have 'Bowstring of Heaven and Earth Artemis' in your soul Soul Charge (2).";
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__TATSUTAHIME)
		{
			desc +="[AUTO](RC)[Counter Blast (2)] When an attack hits a vanguard during the battle that this unit boosted a Genesis you may pay the cost. If you do Soul Charge (3).";
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__TAMAYORIHIME)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Counter Blast (2)] When an attack hits a vanguard during the battle that this unit boosted a Genesis you may pay the cost. If you do Soul Charge (3).";
		}
		else if(id == CardIdentifier.AIMING_FOR_THE_STARS__ARTEMIS)
		{
			desc +="[AUTO]When a unit named 'Bowstring of Heaven and Earth Artemis' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Twilight Hunter Artemis' or 'Battle Deity of the Night Artemis' from among them reveal it to your opponent put it to your hand and shuffle your deck.\n\n[AUTO]When a Genesis other than a card named 'Bowstring of Heaven and Earth Artemis' rides this unit you may call this card to (RC).";
		}
		else if(id == CardIdentifier.MARTIAL_ARTS_GENERAL__DAIMU)
		{
			desc +="[AUTO](VC)At the beginning of your main phase Soul Charge (1) and this unit gets [Power]+2000 until end of turn.\n\n[ACT](VC)[Soul Blast (8) amp Counter Blast (5)] Choose one of your opponents rear-guards for each of your 'Narukami' rear-guards and retire them.";
		}
		else if(id == CardIdentifier.TWIN_GUN_ERADICATOR__HAKUSHOU)
		{
			desc +="[AUTO](RC) When an opponents rear-guard is put into the drop zone with one of your cards effects if you have a vanguard with 'Eradicator' in its card name this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.ERADICATOR__SAUCER_CANNON_WYVERN)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on a (VC) or (RC) if you have a Narukami vanguard you may pay the cost. If you do choose one of your opponents rear-guards in the front row retire it and your opponent draws a card.";
		}
		else if(id == CardIdentifier.ERADICATOR_OF_THE_CEREMONIAL_BONFIRE__CASTOR)
		{
			desc +="[AUTO][Choose a card from your hand and discard it] When this unit is placed on (RC) if you have a Narukami vanguard and the number of rear-guards your opponent has is two or less you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.AMBUSH_DRAGON_ERADICATOR__LINCHU)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Counter Blast (1) amp Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a unit with 'Eradicator' in its card name you may pay the cost. If you do choose one of your opponents grade 1 or less rear-guards and retire it.";
		}
		else if(id == CardIdentifier.ARMORED_HEAVY_GUNNER)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage) When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO](RC) When this unit attacks a vanguard if you have a Nova Grappler vanguard this unit gets [Power]+2000 until end of the battle.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__HATRED_CHAOS)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Beast Deity' in its card name this unit gets [Power]+3000 until end of the battle.";
		}
		else if(id == CardIdentifier.RABBIT_HOUSE)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO](RC)When this unit attacks a vanguard if you have a Spike Brothers vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.DUDLEY_MASON)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) amp Choose one Spike Brothers from your hand and put it into your soul] When this units attack hits a vanguard if you have a Spike Brothers vanguard you may pay the cost. If you do search your deck for up to one Spike Brothers call it to a open (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_EXPLOSIVE_AXE__GORNEMAN)
		{
			desc +="[AUTO](RC)When your grade 3 Royal Paladin is placed on (VC) this unit gets [Power]+10000 until the end of turn.";
		}
		else if(id == CardIdentifier.UNCOMPROMISING_KNIGHT__IDELL)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Royal Paladin] When this unit attacks if you have a Royal Paladin vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.DELICATE_KNIGHT__CLAUDIN)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if you have a Royal Paladin vanguard or rear-guard with Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.STINGING_JEWEL_KNIGHT__SHERRIE)
		{
			desc +="[AUTO](RC)When this unit attacks if the number of other rear-guards you have with 'Jewel Knight' in its card name is three or more this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.RUSHGAL)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Royal Paladin that has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.PRIMGAL)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Royal Paladin that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.ENTHUSIASTIC_JEWEL_KNIGHT__POLLY)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.MUUNGAL)
		{
			desc +="[AUTO](RC)When your grade 3 Gold Paladin is placed on (VC) this unit gets [Power]+10000 until the end of turn.";
		}
		else if(id == CardIdentifier.KNIGHT_OF_FAR_BOW__SAFIR)
		{
			desc +="[AUTO]When this unit is placed on (RC) from your deck if you have a Gold Paladin vanguard choose a card in your damage zone turn it face up and Soul Charge (1).";
		}
		else if(id == CardIdentifier.KNIGHT_OF_BREAK_FIST__SEGWARIDES)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Gold Paladin When this unit attacks if you have a Gold Paladin vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.GUIDING_FALCONEE)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Gold Paladin if the boosted unit have Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle";
		}
		else if(id == CardIdentifier.LIBERATOR__FLARE_MANE_STALLION)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit named 'Liberator of the Round Table Alfred' you may pay the cost. If you do the boosted unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.HOLY_SQUIRE__ENIDE)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Gold Paladin that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.SCHEDULER_ANGEL)
		{
			desc +="[AUTO] [V/R] When this unit is boosted by a Genesis this unit gets Power +2000 until end of that battle.";
		}
		else if(id == CardIdentifier.MICE_GUARD__ANTARES)
		{
			desc +="[AUTO](RC)When your grade 3 Genesis is placed on (VC) this unit gets [Power]+10000 until the end of turn.";
		}
		else if(id == CardIdentifier.CLEVER_JAKE)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Genesis] When this unit attacks if you have a Genesis vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.WITCH_OF_OWLS__PAPRIKA)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if you have a Genesis vanguard or rear-guard that has Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.MICE_GUARD__ORION)
		{
			desc +="[CONT](VC/RC)During your turn if you have a card named 'Mice Guard Sirius' in your soul this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.BOWSTRING_OF_HEAVEN_AND_EARTH__ARTEMIS)
		{
			desc +="[CONT](VC)If you have a card named 'Aiming for the Stars Artemis' in your soul this unit gets [Power]+1000.[AUTO] When a grade 2 Genesis other than a card named 'Twilight Hunter Artemis' rides this unit if you have a card named 'Aiming for the Stars Artemis' in your soul look at up to seven cards from the top of your deck search for up to one card named 'Twilight Hunter Artemis' from among them ride it and shuffle your deck.";
		}
		else if(id == CardIdentifier.WITCH_OF_CATS__CUMIN)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Genesis vanguard you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.SNIPE_SNAKE)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Genesis that has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.MICE_GUARD__SIRIUS)
		{
			desc +="CONTV/R During your turn if you have a card named 'Mice Guard Orion' in your soul this unit gets Power +3000.";
		}
		else if(id == CardIdentifier.CLUSTER_HAMSTER)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Genesis that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.BATTLE_MAIDEN__KUKURIHIME)
		{
			desc +="[ACT](RC)[Put this unit into your soul] Choose up to one of your Genesis and that unit gets Power +3000 until end of turn.";
		}
		else if(id == CardIdentifier.LARGE_POT_WITCH__LAURIE)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_BERSERKER__JANDIRA)
		{
			desc +="[AUTO](RC)When your grade 3 Narukami is placed on (VC) this unit gets [Power]+10000 until the end of turn.";
		}
		else if(id == CardIdentifier.BLOOD_AXE_DRAGOON)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Narukami] When this unit attacks if you have a Narukami vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__MAJIRA)
		{
			desc +="[AUTO]When this unit is placed on (RC) choose another of your Narukami and that unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.SWORD_DANCE_ERADICATOR__HISEN)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a card named 'Eradicator Dragonic Descendant' you may pay the cost. If you do the boosted unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.DRAGON_DANCER__AGNES)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Narukami that has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.THUNDER_FIST_ERADICATOR__DOUI)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a card named 'Eradicator Gauntlet Buster Dragon' you may pay the cost. If you do the boosted unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.ERADICATOR__STRIKE_DAGGER_DRAGON)
		{
			desc +="[[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Put this unit into soul amp Choose a unit named 'Sword Dance Eradicator Hisen' from your (RC) and put it into soul] If you have a unit named 'Supreme Army Eradicator Zuitan' on (VC) search your deck for a card named 'Eradicator Dragonic Descendant' ride it and shuffle your deck.";
		}
		else if(id == CardIdentifier.DJINN_OF_THE_CLAPPING_THUNDER)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Narukami that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.BLOODY_RAIN)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if you have a Nova Grappler vanguard or rear-guard with Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__HILARITY_DESTROYER)
		{
			desc +="[AUTO](VC/RC)[Choose a card from your hand and discard it] When this units attack hits a vanguard if you have a vanguard with 'Beast Deity' in its card name you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.MACHINERY_ANGEL)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Nova Grappler with Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BEAST_DEITY__RIOT_HORN)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)When another of your rear-guard with 'Beast Deity' in its card name becomes [Stand] in the same column as this unit [Stand] this unit.";
		}
		else if(id == CardIdentifier.BATTLE_ARM_LEPRECHAUN)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Nova Grappler that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.ANTI_BATTLEROID_GUNNER)
		{
			desc +="[AUTO](RC)When your grade 3 Spike Brothers is placed on (VC) this unit gets [Power]+10000 until the end of turn.";
		}
		else if(id == CardIdentifier.BLOW_KISS__OLIVIA)
		{
			desc +="[AUTO](RC)[Soul Blast (2)] When this units attack hits a vanguard if you have a Spike Brothers vanguard you may pay the cost. If you do choose one rear-guard in your opponents front row retire it and put this unit on the bottom of your deck.";
		}
		else if(id == CardIdentifier.GO_FOR_BREAK)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Spike Brothers] When this unit attacks if you have a Spike Brothers vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.CHARGING_BILL_COLLECTOR)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if you have a Spike Brothers vanguard or rear-guard that has Limit Break 4 this unit gets [Power]+3000 until end of that battle";
		}
		else if(id == CardIdentifier.UFO)
		{
			desc +="[AUTO][Choose a card from your hand and discard it] During your battle phase when this unit is placed on (RC) if you have a Spike Brothers vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.TYRANT_RECEIVER)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Spike Brothers that has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle";
		}
		else if(id == CardIdentifier.DUDLEY_PHANTOM)
		{
			desc +="[AUTO](RC)When this unit boosts a Spike Brothers the boosted unit gets [Power]+4000 until end of that battle and at the beginning of the close step of that battle put this unit on the bottom of your deck";
		}
		else if(id == CardIdentifier.REIGN_OF_TERROR__THERMIDOR)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)When this unit boosts a Spike Brothers normal unit rear-guard you may have the boosted unit get [Power]+3000 until end of that battle. If you do at the beginning of close step of that battle put that unit on the bottom of your deck.";
		}
		else if(id == CardIdentifier.BABY_FACE__ISAAC)
		{
			desc +="[[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Spike Brothers that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.BLASTER_BLADE_LIBERATOR)
		{
			desc +="[AUTO][Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have a vanguard with 'Liberator' in its card name you may pay the cost. If you do choose one of your opponents rear-guards in the front row and retire it.";
		}
		else if(id == CardIdentifier.PROPHECY_CELESTIAL__RAMIEL)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When an Angel Feather rides this unit choose one card from your damage zone put it into your hand put the top card of your deck into your damage zone choose your vanguard and that unit gets [Power]+10000 until end of turn.\n\n[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+2000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.SOLIDIFY_CELESTIAL__ZERACHIEL)
		{
			desc +="[CONT](VC) Limit Break 4 (This ability is active if you have four or more damage)During your turn if you have a face up card named 'Solidify Celestial Zerachiel' in your damage zone all of your units with 'Celestial' in its card name get [Power]+3000.[ACT](VC)[Counter Blast (2) - Cards with 'Celestial' in its card name] This unit gets [Power]+5000 until end of turn.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.GODDESS_OF_GOOD_LUCK__FORTUNA)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Soul Blast (3)] When this units drive check reveals a grade 1 or greater Genesis you may pay the cost. If you do put the card from that drive check into your drop zone and perform an additional drive check.\n\n[ACT](VC)[Soul Blast (3)] This unit gets [Power]+5000 until end of turn.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.HELLFIRE_SEAL_DRAGON__BLOCKADE_INFERNO)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) - Cards with 'Seal Dragon' in its card name] Retire all of your opponents grade 2 rear-guards and this unit gets [Power]+10000 until end of turn.[CONT](VC)If you have a card named 'Seal Dragon Blockade' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.DAUNTLESS_DRIVE_DRAGON)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Kager rides this unit choose your vanguard that unit gets [Power]+10000 and '\n\n[AUTO](VC)[Choose three cards from your hand and discard them] At the end of the battle that this unit attacked if this unit did not [Stand] during this turn you may pay the cost. If you do [Stand] this unit.' until end of turn.\n\n[AUTO](VC)When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets [Power]+2000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.ERADICATOR__SWEEP_COMMAND_DRAGON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp Soul Blast (2)] When an opponents rear-guard is put in the drop zone by any of your cards effect you may pay the cost. If you do draw a card choose one of your opponents rear-guards in the front row retire it and this unit gets [Power]+5000 until end of turn.\n\n[AUTO][Choose one of your rear-guards with 'Eradicator' in its card name and put it into your soul] When this unit is placed on (VC) you may pay the cost. If you do choose one of your opponents rear-guards in the front row and retire it.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.BLUE_FLIGHT_DRAGON__TRANS_CORE_DRAGON)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Aqua Force rides this unit choose your vanguard that unit gets [Power]+10000 and '\n\n[AUTO](VC)When this unit attacks a vanguard your opponent may choose a card from his or her hand and discard it. If your opponent does not until end of that battle this unit gets [Critical]+1 and your opponent cannot call units to (GC) from his or her hand.' until end of turn.\n\n[AUTO](VC)When this unit attacks a vanguard this unit gets [Power]+2000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.LAST_CARD__REVONN)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1)] When this unit attacks a vanguard if the number of Aqua Force you have as [Rest] in your front row is three you may pay the cost. If you do this unit gets [Power]+3000/[Critical]+1 until end of that battle.\n\n[ACT](VC)[Counter Blast (1)] This unit gets [Power]+2000 until end of turn.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.ADAMANTINE_CELESTIAL__ANIEL)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose one Angel Feather from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Angel Feather that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.SEAL_DRAGON__RINOCROSS)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck)[AUTO][Choose a Kagero from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Kagero that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__SPINODRIVER)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)[Choose two of your Tachikaze rear-guards and retire them] When a Tachikaze rides this unit you may pay the cost. If you do draw two cards and choose your vanguard and that unit gets [Power]+10000/[Critical]+1 until end of turn.\n\n[AUTO](VC)When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets [Power]+2000 until end of that battle. [CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__TYRANNOLEGEND)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Choose three of your rear-guards with 'Ancient Dragon' in its card name and retire them] When this unit attacks a vanguard you may pay the cost. If you do this unit gets [Power]+10000/[Critical]+1 until end of that battle.\n\n[ACT](VC)[Counter Blast (2) - Cards with 'Ancient Dragon' in its card name] This unit gets [Power]+5000 until end of turn.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.RAVENOUS_DRAGON__BATTLEREX)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this units drive check reveals a grade 3 Tachikaze choose one of your rear-guards retire it and this unit gets [Power]+10000 until end of that battle.\n\n[AUTO](VC)When this unit is boosted by a Tachikaze this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__PARASWALL)
		{
			desc +="[CONT]Sentinel (You may only have up to four cards with '[CONT]Sentinel' in a deck)[AUTO][Choose one Tachikaze from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Tachikaze that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.ARMOR_BREAK_DRAGON)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (3) amp Choose three cards from your hand and discard them] Retire all fighters rear-guards in the front row and this unit gets [Power]+10000/[Critical]+2 until end of turn.[CONT](VC/RC) Lord (If you have a unit that doesnt belong to the same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.FIENDISH_SWORD_ERADICATOR__CHO_OU)
		{
			desc +="[AUTO][Choose another of your rear-guards with 'Eradicator' in its card name and put it into your soul] When this unit is placed on (VC) or (RC) if you have a Narukami vanguard you may pay the cost. If you do choose one of your opponents rear-guards in the front row and retire it.";
		}
		else if(id == CardIdentifier.THUNDERING_RIPPLE__GENOVIOUS)
		{
			desc +="[AUTO] (VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp Choose a card named 'Thundering Ripple Genovious' from your hand and discard it] At end of the battle that this unit attacked a vanguard if the number of Aqua Force you have as [Rest] in your front row is three you may pay the cost. If you do [Stand] all of your Aqua Force rear-guards.[CONT](VC)If you have a card named 'Rising Ripple Pavroth' in your soul this unit gets [Power]+1000.";
		}
		else if(id == CardIdentifier.TEAR_KNIGHT__LUCAS)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits if you have an Aqua Force vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.EMERALD_SHIELD__PASCHAL)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose an Aqua Force from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Aqua Force that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.MOBILE_HOSPITAL__ASSAULT_HOSPICE)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO](RC)When this unit attacks a vanguard if you have a Angel Feather vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.REVERSE_AURA_PHOENIX)
		{
			desc +="[AUTO](VC)[Choose a card from your damage zone and put it into the bottom of your deck] At the beginning of your main phase you may pay the cost. If you do put the top card of your deck into your damage zone. If an Angel Feather is put into your damage zone this way this unit gets [Power]+3000 until end of turn and if it is not [Rest] this unit.";
		}
		else if(id == CardIdentifier.WILD_SHOT_CELESTIAL__RAGUEL)
		{
			desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'Celestial' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.CANDLE_CELESTIAL__SARIEL)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (RC) if you have an Angel Feather vanguard you may pay the cost. If you do search your deck for up to one Angel Feather put it into your damage zone shuffle your deck and choose a face up card from your damage zone and put it into your drop zone.";
		}
		else if(id == CardIdentifier.UNDERLAY_CELESTIAL__HESEDIEL)
		{
			desc +="[CONT](VC/RC)During your turn if you have a face up card named 'Solidify Celestial Zerachiel' in your damage zone this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.MICE_GUARD__LA_SUPERBA)
		{
			desc +="[AUTO](VC/RC) When this unit attacks a vanguard if you have a ltGenesisgt vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.WITCH_OF_BIRDS__CHAMOMILE)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is put into the drop zone from your soul if you have a Genesis vanguard you may pay the cost. If you do call this unit to (RC).";
		}
		else if(id == CardIdentifier.WITCH_OF_FROGS__MELISSA)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is put into the drop zone from your soul if you have a Genesis vanguard you may pay the cost. If you do call this unit to (RC).";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_BERSERKER__GANDARUBA)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO](RC)When this unit attacks a vanguard if you have a Kager vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.SEAL_DRAGON__JAKADO)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Seal Dragon' in its card name this unit gets [Power]+3000 until end of the battle.";
		}
		else if(id == CardIdentifier.SEAL_DRAGON__CHAMBRAY)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit with 'Blockade' in its card name you may pay the cost. If you do the boosted unit gets [Power]+6000 until end of that battle.";
		}
		else if(id == CardIdentifier.SAVAGE_HUNTER)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage) When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO](RC) When this unit attacks a vanguard if you have a Tachikaze vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__BEAMANKYLO)
		{
			desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'Ancient Dragon' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__IGUANOGORG)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is put into the drop zone from (RC) if you have a vanguard with 'Ancient Dragon' in its card name you may pay the cost. If you do call this card to (RC).";
		}
		else if(id == CardIdentifier.DEMONIC_SWORD_ERADICATOR__RAIOH)
		{
			desc +="[AUTO][Choose another of your rear-guards with 'Eradicator' in its card name and put it into your soul] When this unit is placed on (VC) or (RC) if you have a Narukami vanguard you may pay the cost. If you do choose one of your opponents rear-guard in the front row and retire it.";
		}
		else if(id == CardIdentifier.IRON_BLOOD_ERADICATOR__SHUKI)
		{
			desc +="[AUTO](RC)When an opponents rear-guard is put in the drop zone by any of your cards effect if you have a vanguard with 'Eradicator' in its card name this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.OPTICS_CANNON_TITAN)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO](RC)When this unit attacks a vanguard if you have a Aqua Force vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.RISING_RIPPLE__PAVROTH)
		{
			desc +="[CONT](VC) If you have a card named 'Silent Ripple Sotirio' in your soul this unit gets [Power]+1000.[AUTO](VC) When this units attack hits a vanguard if you have a card named 'Silent Ripple Sotirio' in your soul choose one of your Aqua Force rear-guards [Stand] it and that unit gets [Power]+3000 until end of the turn.";
		}
		else if(id == CardIdentifier.STARTING_RIPPLE__ALECS)
		{
			desc +="[AUTO] When a card named 'Silent Ripple Sotirio' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Rising Ripple Pavroth' or 'Thundering Ripple Genovious' from among them reveal it to your opponent put it into your hand and shuffle your deck.\n\n[AUTO] When a Aqua Force other than a card named 'Silent Ripple Sotirio' rides this unit you may call this card to (RC).";
		}
		else if(id == CardIdentifier.BOOTING_CELESTIAL__SANDALPHON)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.CAPSULE_GIFT_NURSE)
		{
			desc +="[AUTO](VC/RC) When this unit attacks if you have an Angel Feather vanguard or rear-guard that has Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DOCTROID_ARGUS)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Angel Feather] When this unit attacks if you have an Angel Feather vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.MARKING_CELESTIAL__ARABHAKI)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Celestial' in its card name this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.ORDER_CELESTIAL__YEQON)
		{
			desc +="[AUTO][Choose a card from your hand and discard it] When this unit is placed on (RC) if you have a Angel Feather vanguard if you have a face up card named 'Solidify Celestial Zerachiel' in your damage zone you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.DRUG_STORE_NURSE)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Angel Feather that has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.FIRST_AID_CELESTIAL__PENUEL)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Put this unit into your soul] If you have an Angel Feather vanguard choose one face up card from your damage zone with 'Celestial' in its card name call it to (RC) and put the top card of your deck face down into your damage zone.";
		}
		else if(id == CardIdentifier.CURE_DROP_ANGEL)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Angel Feather that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.HAZARD_BOB)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Genesis vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.PINEAPPLE_LO)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Genesis vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.WITCH_OF_PROHIBITED_BOOKS__CINNAMON)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a grade 3 or greater Genesis you may pay the cost. If you do Soul Charge (2).";
		}
		else if(id == CardIdentifier.VIVID_RABBIT)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at the top five cards of your deck search for up to one grade 3 or greater Genesis from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.SEAL_DRAGON__SPIKE_HELL_DRAGON)
		{
			desc +="[AUTO](VC/RC)When this unit is boosted by a Kagero this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.SEAL_DRAGON__CORDUROY)
		{
			desc +="[AUTO][Counter Blast (1) - Cards with 'Seal Dragon' in its card name] When this unit is placed on (VC) or (RC) if you have a Kagero vanguard you may pay the cost. If you do choose one of your opponents rear-guards retire it your opponent look at up to four cards from the top of his or her deck searches for up to one grade 2 from among them calls it to (RC) and your opponent shuffles his or her deck.";
		}
		else if(id == CardIdentifier.BREATH_OF_DEMISE__VULCANIS)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Kager vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.DRAGON_KNIGHT__RUTOF)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)-Kager] When this unit attacks if you have a Kager vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_BERSERKER__KUBANDA)
		{
			desc +="[AUTO](VC/RC) When this unit attacks if you have a Kager vanguard or rear-guard that has Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SEAL_DRAGON__FLANNEL)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Seal Dragon' in its card name this unit gets [Power]+3000 until end of the battle.";
		}
		else if(id == CardIdentifier.SEAL_DRAGON__KERSEY)
		{
			desc +="[AUTO][Choose a card from your hand and discard it] When this unit is placed on (RC) if you have a Kagero vanguard and if your opponent has a grade 2 vanguard or rear-guard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.BREATH_OF_PRIMORDIAL__ROLAMANDRI)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if you have a Kager vanguard you may pay the cost. If you do put the top card of your deck into your damage zone and at the beginning of your end phase choose a card from your damage zone return it to your deck and shuffle your deck.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__SHAGARA)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Kager with Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SEAL_DRAGON__TERRYCLOTH)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Counter Blast (1) - Cards with 'Seal Dragon' in its card name amp Put this unit into your soul] If you have a Kagero vanguard choose one of your opponents rear-guards retire it your opponent look at up to four cards from the top of his or her deck searches for up to one grade 2 from among them calls it to (RC) and your opponent shuffles his or her deck.";
		}
		else if(id == CardIdentifier.DEMONIC_DRAGON_MAGE__DIVA)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Kager that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.RED_PULSE_DRACOKID)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at up to five cards from the top of your deck search for up to one grade 3 or greater Kager from among them reveal it to your opponent put it into your hand and shuffle your deck.";
		}
		else if(id == CardIdentifier.SEAL_DRAGON__SHADING)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.) ";
		}
		else if(id == CardIdentifier.SEAL_DRAGON__ARTPITCH)
		{
			desc +="[ACT](RC)[Put this unit into your soul] Choose up to one of your \"Kagero\" and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__STEGOBUSTER)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__DEINO_CLAWED)
		{
			desc +="[AUTO](VC/RC)[Choose one of your rear-guards with 'Ancient Dragon' in its card name and retire it] When this unit attacks a vanguard you may pay the cost. If you do this unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.LAUNCHER_MAMMOTH)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard if you have a Tachikaze vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.SAVAGE_ARCHER)
		{
			desc +="[AUTO](VC/RC) When this unit attacks if you have a Tachikaze vanguard or rear-guard that has Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__TRI_PLASMA)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Ancient Dragon' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__GATTLING_ALLO)
		{
			desc +="[AUTO](VC/RC)[Choose another of your rear-guards with 'Ancient Dragon' in its card name and retire it] When this unit attacks a vanguard you may pay the cost. If you do this unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.SAVAGE_ILLUMINATOR)
		{
			desc +="[AUTO](RC)[Counter Blast(1)] When this unit boosts a Tachikaze that has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__BABY_REX)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO][Counter Blast (1)] When this unit is put into the drop zone from (RC) if you have a Tachikaze vanguard you may pay the cost. If you do search your deck for up to one card named 'Ancient Dragon Tyrannolegend' call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.SAVAGE_PATRIARCH)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Tachikaze that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__DINODILE)
		{
			desc +="[ACT](RC)[Put this unit into your soul] If you have a Tachikaze vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.ANCIENT_DRAGON__ORNITHOHEALER)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.DRAGON_DANCER__JULIA)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) reveal the top card of your deck. If the revealed card is a grade 1 or 2 Narukami call it to (RC) and if it is not shuffle your deck.";
		}
		else if(id == CardIdentifier.LIZARD_SOLDIER__RYUUSHIN)
		{
			desc +="[AUTO](VC/RC) When this unit attacks if the number of rear-guards your opponent has is two or less this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ERADICATOR__FIRST_THUNDER_DRACOKID)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an opponents rear-guard is put in the drop zone by any of your cards effect if you have a grade 3 or greater vanguard with 'Eradicator' in its card name you may pay the cost. If you do look at up to ten cards from the top of your deck search for up to one card named 'Eradicator Sweep Command Dragon' from among them ride it and shuffle your deck.";
		}
		else if(id == CardIdentifier.FLAG_OF_RAIJIN__CORPOSANT)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Put this unit into your soul] Choose up to one of your Narukami and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.MOBILE_BATTLESHIP__AKERON)
		{
			desc +="[AUTO](RC)When this units attack hits a vanguard choose one of your Aqua Force and that unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.TWIN_STRIKE_BRAVE_SHOOTER)
		{
			desc +="[AUTO](RC)When this unit attacks if you have an Aqua Force vanguard and if the number of rear-guards you have as [Rest] is two or less this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.OPTICS_MUSKET_TITAN)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if you have a Aqua Force vanguard or rear-guard that has Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SILENT_RIPPLE__SOTIRIO)
		{
			desc +="[CONT](VC) If you have a card named 'Starting Ripple Alecs' in your soul this unit gets [Power]+1000.[AUTO] When a grade 2 Aqua Force other than a card named 'Rising Ripple Pavroth' rides this unit if you have a card named 'Starting Ripple Alecs' in your soul look at up to seven cards from the top of your deck search for up to one card named 'Rising Ripple Pavroth' from among them ride it and shuffle your deck.";
		}
		else if(id == CardIdentifier.SHORTSTOP_BRAVE_SHOOTER)
		{
			desc +="[AUTO](RC)When this unit attacks if you have an Aqua Force vanguard and if the number of rear-guards you have as [Rest] is two or less this unit gets [Power]+3000 until end of the battle.";
		}
		else if(id == CardIdentifier.BATTLE_SIREN__EUPHENIA)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Aqua Force that has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ADVANCE_PARTY_BRAVE_SHOOTER)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)When this unit boosts if you have a Aqua Force vanguard and if the number of rear-guards you have as [Rest] is two or less the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.BATTLE_SIREN__CARRI)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted an Aqua Force that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.ICE_FLOW_ANGEL)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.MASS_PRODUCTION_SAILOR)
		{
			desc +="[CONT] You may have up to sixteen cards named 'Mass Production Sailor' in a deck.[CONT](RC) During your turn this unit gets [Power]+1000 for each other unit named 'Mass Production Sailor' on your (VC) or (RC).";
		}
		else if(id == CardIdentifier.REVENGER__RAGING_FORM_DRAGON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Choose three of your rear-guards with 'Revenger' in its card name and retire them] At the end of the battle that this unit attacked you may pay the cost. If you do choose up to one card named 'Revenger Raging Form Dragon' from your hand ride it as [Stand] choose your vanguard and that unit gets [Power]+10000 until end of turn.\n\n[AUTO](VC)[Counter Blast (1)] When this unit attacks you may pay the cost if you do this unit gets [Power]+3000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.WOLF_FANG_LIBERATOR__GARMORE)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (3) - Cards with 'Liberator' in its card name] Look at the top card of your deck search for up to one Gold Paladin from among them call it to an open (RC) and put the rest on the bottom of your deck. If it is called and you have any open (RC) you use this effect again without paying the cost.\n\n[AUTO](VC)[Choose one of your rear-guards with 'Liberator' in its card name and put it on the bottom of your deck] When this unit attacks a vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.ERADICATOR__VOWING_SABER_DRAGON______REVERSE_____)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp Choose two of your rear-guards with 'Eradicator' in its card name and lock them] Your opponent chooses two of his or her rear-guards retires them and this unit gets [Power]+10000 until end of turn.(Locked cards are turned face down and cannot do anything. Turn them face up at the end of its owners turn)[CONT](VC)If you have a card named 'Eradicator Vowing Sword Dragon' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.DEMON_CONQUERING_DRAGON__DUNGAREE______UNLIMITED_____)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp Bind the top card of your deck face up] When this unit attacks a vanguard you may pay the cost. If you do choose up to one of your opponents rear-guards in the front row retire it and this unit gets [Power]+2000 for each Narukami in your bind zone until end of turn.[CONT](VC)If you have a card named 'Sealed Demon Dragon Dungaree' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.STAR_VADER__NEBULA_LORD_DRAGON)
		{
			desc +="[CONT](VC) Limit Break 4 (This ability is active if you have four or more damage)During your turn all of your Link Joker in your front row get [Power]+3000 for each of your opponents locked units.[ACT](VC)[Counter Blast (2)] Choose one of your opponents rear-guards in the back row and lock it.(Locked cards are turned face down and cannot do anything. Turn them face up at the end of its owners turn)[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.SCHWARZSCHILD_DRAGON)
		{
			desc +="[ACT] (VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (3) amp Choose a card named 'Schwarzschild Dragon' from your hand and discard it] Choose up to three of your opponents rear-guards lock them and this unit gets [Power]+10000/[Critical]+1 until end of turn.(Locked cards are turned face down and cannot do anything. Turn them face up at the end of its owners turn)\n\n[AUTO][Counter Blast (1)] When this unit is placed on (VC) you may pay the cost. If you do look at up to five cards from the top of your deck search for up to one card named 'Schwarzschild Dragon' from among them reveal it to your opponent put it into your hand and shuffle your deck.[CONT] If you have a card named 'Gravity Collapse Dragon' in your soul this unit gets [Power]+1000.";
		}
		else if(id == CardIdentifier.DEMON_MARQUIS__AMON______REVERSE_____)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Choose one of your Dark Irregulars rear-guards and lock it] This unit gets [Power]+1000 for each Dark Irregulars in your soul until end of turn. If the number of Dark Irregulars in your soul is six or more this unit gets [Critical]+1 until end of turn. This ability cannot be used for the rest of that turn.(Locked cards are turned face down and cannot do anything. Turn them face up at the end of its owners turn)[CONT](VC)If you have a card named 'Demon World Marquis Amon' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.SILVER_THORN_DRAGON_QUEEN__LUQUIER______REVERSE_____)
		{
			desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (1) amp Choose one of your Pale Moon rear-guards and lock it] Choose one Pale Moon from your soul call it to (RC) and that unit gets [Power]+5000 until end of turn.(Locked cards are turned face down and cannot do anything. Turn them face up at the end of its owners turn)[CONT](VC) If you have a card named 'Silver Thorn Dragon Tamer Luquier' in your soul this unit gets [Power]+2000.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.WITCH_OF_CURSED_TALISMAN__ETAIN)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp choose two of your Shadow Paladin rear-guards and retire them] At the beginning of the guard step of the battle that this unit is attacked you may pay the cost. If you do choose one of your opponents rear-guards that is not boosting or attacking and retire it.\n\n[AUTO](VC) When this unit attacks a vanguard this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DARK_CLOAK_REVENGER__TARTU)
		{
			desc +="[AUTO][Counter Blast (2)] When this is placed on (VC) or (RC) if you have a Shadow Paladin vanguard you may pay the cost. If you do search your deck for up to one grade 1 or less card with 'Revenger' in its card name call it to (RC) in the same column as this unit and shuffle your deck.";
		}
		else if(id == CardIdentifier.DARK_REVENGER__MAC_LIR)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Shadow Paladin from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Shadow Paladin that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.BARCGAL_LIBERATOR)
		{
			desc +="[AUTO](RC) When an attack hits a vanguard during the battle that this unit boosts a unit named 'Blaster Blade Liberator' look at up to three cards from the top of your deck search for up to one card with 'Liberator' in its card name from among them call it to (RC) as [Rest] and put the rest on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.IRON_FAN_ERADICATOR__RASETSUNYO)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (2)] When this units attack hits if you have a Narukami vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.BARRIER_STAR_VADER__PROMETHIUM)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Link Joker from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Link Joker that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.KING_OF_MASKS__DANTARIAN)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Dark Irregulars rides this unit choose your vanguard that unit gets [Power]+10000 until end of turn choose up to three of your Dark Irregulars rear-guards and those units get '[CONT](RC)This unit gets [Power]+1000 for each Dark Irregulars in your soul.' until end of turn.\n\n[AUTO](VC)When this unit attacks a vanguard Soul Charge (1) and this unit gets [Power]+1000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.MASTER_OF_FIFTH_ELEMENT)
		{
			desc +="[CONT](VC) Limit Break 4 (This ability is active if you have four or more damage)During your turn if the number of Dark Irregulars in your soul is ten or more all of your Dark Irregulars get [Power]+3000.[AUTO](VC)[Counter Blast (1)] When this units attack hits a vanguard you may pay the cost. If you do Soul Charge (3).";
		}
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__VLAD_SPECULA)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Dark Irregulars from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Dark Irregulars that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.MIRACLE_POP__EVA)
		{
			desc +="[AUTO] Limit Break 4 (This ability is active if you have four or more damage)When a Pale Moon rides this unit choose your vanguard that unit gets [Power]+10000 and '\n\n[AUTO](VC)[Choose two of your Pale Moon rear-guards and put them into your soul] When this unit attacks you may pay the cost. If you do choose up to two Pale Moon from your soul and call them to separate (RC).' until end of turn.\n\n[AUTO](VC)When this unit attacks a vanguard Soul Charge (1) and this unit gets [Power]+1000 until end of that battle.[CONT](VC/RC) Lord (If you have a unit without a same clan as this unit this unit cannot attack)";
		}
		else if(id == CardIdentifier.NIGHTMARE_DOLL__CHELSEA)
		{
			desc +="[AUTO] (VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2) amp Choose a card named 'Nightmare Doll Chelsea' from your hand and discard it] At the beginning of the close step of the battle that this unit attacked a vanguard you may pay the cost. If you do choose up to two Pale Moon from your soul and call them to separate (RC).\n\n[AUTO](VC)When this unit is boosted by a Pale Moon this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SILVER_THORN_HYPNOS__LYDIA)
		{
			desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Pale Moon from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Pale Moon that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.BARRIER_TROOP_REVENGER__DORINT)
		{
			desc +="[AUTO](RC) When a card named 'Blaster Dark Revenger' is placed on your (VC) or (RC) of the same column as this unit if you have a vanguard with 'Revenger' in its card name choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.REVENGER__DARK_BOND_TRUMPETER)
		{
			desc +="[AUTO][Counter Blast(1)] When this unit is placed on (VC) or (RC) if you have a Shadow Paladin vanguard you may pay the cost. If you do search your deck for up to one grade 0 card with 'Revenger' in its card name call it to (RC) as [Rest] and shuffle your deck.";
		}
		else if(id == CardIdentifier.FRONTLINE_REVENGER__CLAUDAS)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] If you have a grade 3 or greater Shadow Paladin vanguard search your deck for up one card named 'Blaster Dark Revenger' call it to (RC) and shuffle your deck.";
		}
		else if(id == CardIdentifier.LIBERATOR__BAGPIPE_ANGEL)
		{
			desc +="[AUTO] When this unit is placed on (RC) from your deck choose up to two of your units with 'Liberator' in its card name and those units get [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.LIGHTNING_AXE_WIELDING_EXORCIST_KNIGHT)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Dungaree' in its card name this unit gets [Power]+3000 until end of battle.";
		}
		else if(id == CardIdentifier.HOMING_ERADICATOR__ROCHISHIN)
		{
			desc +="[AUTO](RC) When an opponents rear-guard is put into the drop zone with one of your cards effects if you have a vanguard with 'Eradicator' in its card name this unit gets [Power]+5000 until end of turn.";
		}
		else if(id == CardIdentifier.RISING_PHOENIX)
		{
			desc +="[AUTO][Soul Blast(2)] When this unit is placed on (RC) if you have a Narukami vanguard you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.LIGHTNING_HAMMER_WIELDING_EXORCIST_KNIGHT)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit with 'Dungaree' in its card name you may pay the cost. If you do the boosted unit gets [Power]+6000 until end of that battle.";
		}
		else if(id == CardIdentifier.EXORCIST_MAGE__DAN_DAN)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))[CONT](RC)If you have a Narukami vanguard all other of your units with 'Dungaree' in its card name get '\n\n[AUTO]When this unit is placed on (VC) or (RC) bind the top card of your deck.'.";
		}
		else if(id == CardIdentifier.SCHR__DINGER_____S_LION)
		{
			desc +="[AUTO](VC/RC) When this unit attacks a vanguard if you have a Link Joker vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.GRAVITY_COLLAPSE_DRAGON)
		{
			desc +="[CONT](VC)If you have a card named 'Gravity Ball Dragon' in your soul this unit gets [Power]+1000.[AUTO]When this unit rides a card named 'Gravity Ball Dragon' if you have a card named 'Micro-hole Dracokid' in soul choose up to one of your opponents rearguards and lock it.(Locked cards are turned face down and cannot do anything. Turn them face up at the end of its owners turn)";
		}
		else if(id == CardIdentifier.ONE_WHO_OPENS_THE_BLACK_DOOR)
		{
			desc +="[AUTO][Choose a card from your hand and discard it] When this unit is placed on (RC) if you have a Link Joker vanguard and if the number of rear-guards your opponent has is two or less you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.STAR_VADER__DUST_TAIL_UNICORN)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] If you have a Link Joker vanguard and your opponent has a locked card you may pay the cost. If you do choose one of your opponents rear-guards and lock it.(Locked cards are turned face down and cannot do anything. Turn them face up at the end of its owners turn)";
		}
		else if(id == CardIdentifier.MICRO_HOLE_DRACOKID)
		{
			desc +="[AUTO] When a card named 'Gravity Ball Dragon' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Gravity Collapse Dragon' or 'Schwarzschild Dragon' from among them reveal it to your opponent put it to your hand and shuffle your deck.\n\n[AUTO] When a Link Joker other than a card named 'Gravity Ball Dragon' rides this unit you may call this card to (RC).";
		}
		else if(id == CardIdentifier.WERBEAR_SOLDNER)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage) When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO] (RC) When this unit attacks a vanguard if you have a Dark Irregulars vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__PSYCHO_GLAIVE)
		{
			desc +="[AUTO][Counter Blast (1)] When this unit is placed on (VC) or (RC) if the number of Dark Irregulars in your soul is six or more you can pay the cost. If you do Soul Charge (1) and this unit gets [Power]+5000 until end of turn.";
		}
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__RON_GEENLIN)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Amon' in its card name this unit gets [Power]+3000 until end of battle.";
		}
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__FOOL_____S_PALM)
		{
			desc +="[AUTO][Choose a card from your hand and discard it] When this unit is placed on (RC) if the number of Dark Irregulars in your soul is six or more you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.FIRE_RING_GRYPHON)
		{
			desc +="[AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage)When this unit attacks a vanguard this unit gets [Power]+5000 until end of that battle.\n\n[AUTO](RC)When this unit attacks a vanguard if you have a Pale Moon vanguard this unit gets [Power]+2000 until end of that battle.";
		}
		else if(id == CardIdentifier.SILVER_THORN_BEAST_TAMER__MARICICA)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1)] When this units attack hits a vanguard if you have a Pale Moon vanguard you may pay the cost. If you do choose up to one card with 'Silver Thorn' in its card name from your soul call it to (RC) and at the end of that turn put that unit into your soul.";
		}
		else if(id == CardIdentifier.SILVER_THORN_RISING_DRAGON)
		{
			desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'Silver Thorn' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DEMON_WORLD_CASTLE__ZERSCHLAGEN)
		{
			desc +="[AUTO](RC)When your grade 3 Shadow Paladin is placed on (VC) this unit gets [Power]+10000 until end of turn.";
		}
		else if(id == CardIdentifier.SHARKBAU_REVENGER)
		{
			desc +="[AUTO](VC/RC) When this unit attacks if you have a Shadow Paladin vanguard or rear-guard that has Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.DEMON_WORLD_CASTLE__ZWEISPEER)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Shadow Paladin] When this unit attacks if you have a Shadow Paladin vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.REVENGER_OF_MALICE__DILAN)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit named 'Revenger Raging Form Dragon' you may pay the cost. If you do the boosted unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.SONBAU)
		{
			desc +="[AUTO](RC)[Counter Blast(1)] When this unit boosts a Shadow Paladin if the boosted unit has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle";
		}
		else if(id == CardIdentifier.SPINBAU_REVENGER)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Shadow Paladin with Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.GIGANTECH_PILLAR_FIGHTER)
		{
			desc +="[AUTO](VC) When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets [Power]+3000 until end of that battle.\n\n[AUTO](RC) When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets [Power]+1000 until end of that battle.";
		}
		else if(id == CardIdentifier.CLOUDY_SKY_LIBERATOR__GERAINT)
		{
			desc +="[AUTO](RC)When another of your Gold Paladin is placed on (RC) from your deck if you have a vanguard with 'Liberator' in its card name this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.PEEKGAL)
		{
			desc +="[ACT](VC/RC)[Counter Blast(2)] This unit gets [Power]+4000 until end of turn.";
		}
		else if(id == CardIdentifier.MAY_RAIN_LIBERATOR__BRUNO)
		{
			desc +="[AUTO](RC)When another of your Gold Paladin is placed on (RC) from your deck if you have a vanguard with 'Liberator' in its card name this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.SUNRISE_UNICORN)
		{
			desc +="[ACT](RC)[Rest] this unit] Choose another of your Gold Paladin and that unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.LIBERATOR__CHEER_UP_TRUMPETER)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[ACT](RC)[Put this unit into your soul] Choose one of your vanguards with 'Liberator' in its card name and that unit gets '\n\n[AUTO](VC) When one of your Gold Paladin is placed on (RC) from your deck this unit gets [Power]+3000 until end of turn.' until end of turn.";
		}
		else if(id == CardIdentifier.SUPPRESSION_ERADICATOR__DOKKASEI)
		{
			desc +="[AUTO][Rest] this unit] When this unit is placed on (RC) if you have a Narukami vanguard you may pay the cost. If you do choose up to two of your opponents rear-guards and those units cannot intercept until end of turn.";
		}
		else if(id == CardIdentifier.ERADICATOR__BLADE_HANG_DRACOKID)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an opponents rear-guard is put into the drop zone by any of your cards effect with 'Eradicator' in its card name you may pay the cost. If you do choose your vanguard with 'Vowing' in its card name and that unit gets [Power]+3000/[Critical]+1 until end of turn.";
		}
		else if(id == CardIdentifier.CATASTROPHE_STINGER)
		{
			desc +="[AUTO](RC) When your grade 3 Link Joker is placed on (VC) this unit gets [Power]+10000 until end of turn.";
		}
		else if(id == CardIdentifier.INNOCENT_BLADE__HEARTLESS)
		{
			desc +="[AUTO](VC)[Counter Blast(2)] When this units attack hits a vanguard you may pay the cost. If you do choose one of your opponents rear-guards and lock it.(Locked cards are turned face down and cannot do anything. Turn them face up at the end of its owners turn)\n\n[AUTO](VC) When this unit attacks a vanguard this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.FURIOUS_CLAW_STAR_VADER__NIOBIUM)
		{
			desc +="[AUTO](RC) When one of your opponents rear-guard becomes locked due to any of your cards effect if you have a Link Joker vanguard this unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.GAMMA_BURST__FENRIR)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if you have a Link Joker vanguard or rear-guard with Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.ONE_WHO_SHOOTS_GRAVITATIONAL_SINGULARITIES)
		{
			desc +="[AUTO](RC)When this units attack hits a vanguard if you have a Link Joker vanguard and your opponent has a locked unit choose one of your opponents rear-guard and lock it.(Locked cards are turned face down and cannot do anything. Turn them face up at the end of its owners turn)";
		}
		else if(id == CardIdentifier.LA_MORT)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Link Joker] When this unit attacks if you have a Link Joker vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.GRAVITY_BALL_DRAGON)
		{
			desc +="[CONT](VC) If you have a card named 'Micro-hole Dracokid' in your soul this unit gets [Power]+1000.[AUTO] When a grade 2 Link Joker other than a card named 'Gravity Collapse Dragon' rides this unit if you have a card named 'Micro-hole Dracokid' in your soul look at up to seven cards from the top of your deck search for up to one card named 'Gravity Collapse Dragon' from among them ride it and shuffle your deck.";
		}
		else if(id == CardIdentifier.DEMONIC_CLAW_STAR_VADER__LANTHANUM)
		{
			desc +="[AUTO](RC)When your opponents rear-guard becomes locked due to any of your cards effect if you have a Link Joker vanguard this unit gets [Power]+2000 until end of turn.";
		}
		else if(id == CardIdentifier.STRAFE_STAR_VADER__RUTHENIUM)
		{
			desc +="[AUTO](RC)[Soul Blast (1)] When this unit boosts a unit named 'Star-vader Nebula Lord Dragon' you may pay the cost. If you do the boosted unit gains [Power]+5000 during that battle.";
		}
		else if(id == CardIdentifier.PARADOX_NAIL__FENRIR)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Link Joker with Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.WHITE_NIGHT__FENRIR)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Link Joker with Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.NUMBER_OF_TERROR)
		{
			desc +="[AUTO](VC/RC) When another grade 3 Dark Irregulars is placed on (RC) this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__HELL_____S_DRAW)
		{
			desc +="[AUTO]When this unit is placed on (RC) if you have a vanguard with 'Amon' in its card name you may Soul Charge (2).";
		}
		else if(id == CardIdentifier.WERLEOPARD_SOLDAT)
		{
			desc +="[AUTO] (VC/RC) When this unit attacks if you have a Dark Irregulars Vanguard or Rear-Guard that has Limit Break 4 this unit gets [Power] +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.FLOG_KNIGHT)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Dark Irregulars] When this unit attacks if you have a Dark Irregulars vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__HELL_____S_DEAL)
		{
			desc +="[AUTO] When this unit is placed on (RC) if you have a vanguard with 'Amon' in its card name you may Soul Charge(2).";
		}
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__PHU_GEENLIN)
		{
			desc +="[AUTO](RC)When this unit attacks if you have a vanguard with 'Amon' in its card name this unit gets [Power]+3000 until end of battle.";
		}
		else if(id == CardIdentifier.DIMENSION_CREEPER)
		{
			desc +="[ACT](Soul)[Put this card into your drop zone] If you have a Dark Irregulars vanguard Soul Charge (2).";
		}
		else if(id == CardIdentifier.WERHASE_BANDIT)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Dark Irregulars if the boosted unit has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power] +3000 until end of that battle.";
		}
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__FATE_COLLECTOR)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))[CONT](RC) If the number of Dark Irregulars in your soul is six or more this unit gets '\n\n[AUTO](RC)[Put this unit into your soul] At the end of the battle that this unit boosts a Dark Irregulars you may pay the cost. If you do draw a card.'.";
		}
		else if(id == CardIdentifier.WERFUCHS_HEXER)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Dark Irregulars with Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.AMON_____S_FOLLOWER__HELL_____S_TRICK)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.HUGE_KNIFE_THROWING_EXPERT)
		{
			desc +="[AUTO](VC/RC) When another of your grade 3 Pale Moon is placed on (RC) this unit gets [Power]+3000 until the end of turn.";
		}
		else if(id == CardIdentifier.TIGHTROPE_HOLDER)
		{
			desc +="[AUTO](VC/RC)[Counter Blast (1) - Pale Moon] When this unit attacks if you have a Pale Moon vanguard you may pay the cost. If you do this unit gets [Power]+4000 until end of that battle.";
		}
		else if(id == CardIdentifier.FLYING_HIPPOGRIFF)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if you have a Pale Moon vanguard or rear-guard that has Limit Break 4 this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.SILVER_THORN_ASSISTANT__IRINA)
		{
			desc +="[AUTO] When this unit is placed on (VC) or (RC) if you have a vanguard with 'Silver Thorn' in its card name look up to two cards from the top of your deck search up to one card with 'Silver Thorn' in its card name put it into your soul and put the rest on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.SILVER_THORN_BEAST_TAMER__ANA)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When an attack hits a vanguard during the battle that this unit boosted a Pale Moon you may pay the cost. If you do choose up to one card with 'Silver Thorn' in its card name from your soul call it to (RC) and at the end of that turn put that unit into your soul.";
		}
		else if(id == CardIdentifier.SILVER_THORN_BREATHING_DRAGON)
		{
			desc +="[AUTO](RC) When this unit attacks if you have a vanguard with 'Silver Thorn' in its card name this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.TIGHTROPE_TUMBLER)
		{
			desc +="[AUTO]When this unit is placed on (RC) from your soul if you have a Pale Moon vanguard you may Soul Charge (2).";
		}
		else if(id == CardIdentifier.ELEGANT_ELEPHANT)
		{
			desc +="[AUTO](RC)[Counter Blast (1)] When this unit boosts a Pale Moon if the boosted unit has Limit Break 4 you may pay the cost. If you do the boosted unit gets [Power]+3000 until end of that battle";
		}
		else if(id == CardIdentifier.SILVER_THORN_ASSISTANT__IONELA)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC) When an attack hits a vanguard during the battle that this unit boosted a vanguard with 'Silver Thorn' in its card name look at up to two cards from the top of your deck search for up to one card with 'Silver Thorn' in its card name put it in your soul and put the rest on the bottom of your deck in any order.";
		}
		else if(id == CardIdentifier.JOURNEYING_TONE__WILLY)
		{
			desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))\n\n[AUTO](RC)[Put this unit into your soul] When an attack hits a vanguard during the battle that this unit boosted a Pale Moon that has Limit Break 4 you may pay the cost. If you do draw a card.";
		}
		else if(id == CardIdentifier.SILVER_THORN_JUGGLER__NADIA)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.DEMON_WORLD_MARQUIS__AMON)
		{
			desc +="[CONT](VC)During your turn this unit gets [Power]+1000 for each Dark Irregulars in your soul.[ACT](VC)[Counter Blast (1) amp Choose one of your Dark Irregulars rear-guards and put it into your soul] Your opponent chooses one of his or her rear-guards and retires it.";
		}
		else if(id == CardIdentifier.BLASTER_DARK_REVENGER)
		{
			desc +="[AUTO][Counter Blast (2)] When this unit is placed on (VC) or (RC) if you have a vanguard with 'Revenger' in its card name you may pay the cost. If you do choose one of your opponents rear-guards in the front row and retire it.";
		}
		else if(id == CardIdentifier.TOP_IDOL_FLORES)
		{
			desc += "[AUTO](VC/RC):[Soul Blast (2)] When this unit's attack hits, you may pay the cost. If you do, choose one of your Bermuda Triangle rear-guards, and return it to your hand.";	
		}
		else if(id == CardIdentifier.MAGICIAN_GIRL_KIRARA)
		{
			desc += "[AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits, if you have a Nova Grappler vanguard, you may pay the cost. If you do, draw a card.";	
		}
		else if(id == CardIdentifier.SILENT_TOM)
		{
			desc += "[CONT](VC/RC):During a battle that this unit attacks, if you have an Oracle Think Tank vanguard, your opponent cannot normal call grade 0 units to (GC).";	
		}
		else if(id == CardIdentifier.TWIN_BLADER)
		{
			desc += "[CONT]: Sentinel (You may only have up to four cards with [CONT]: Sentinel in a deck)\n\n" + 
					"[AUTO]:[Choose a Nova Grappler from your hand, and discard it] When this unit is placed on (GC), you may pay the cost. If you do, choose one of your Nova Grappler that is being attacked, and that unit cannot be hit until end of that battle.";	
		}
		else if(id == CardIdentifier.DUDLEY_DAN)
		{
			desc += "[AUTO](RC):[Counter Blast (2)] and Choose a Spike Brothers from your hand, and put it into your soul] When this unit boosts a vanguard, you may pay the cost. If you do, search your deck for up to one Spike Brothers, call it to an open (RC), and shuffle your deck.";	
		}
		else if(id == CardIdentifier.UNITE_ATTACKER)
		{
			desc += "[AUTO](VC): At the beginning of your main phase, Soul Charge(1), and this unit gets [Power]+2000 until end of turn.\n\n" +
					"[AUTO](VC/RC):[Soul Blast(8) & Counterblast(5)] When this unit's attack hits, you may pay the cost. If you do, look at up to 5 cards from the top of your deck, choose any number of Spike Brothers from among them, call the chosen cards to separate (RC), and shuffle your deck.";	
		}
		else if(id == CardIdentifier.MECHA_TRAINER)
		{
			desc += "[AUTO]:When another Spike Brothers rides this unit, you may call this card to a (RC).\n\n" +
					"[ACT](RC):[Counter Blast (1) and Retire this unit] Search your deck for up to one grade 1 or less Spike Brothers, reveal it to your opponent, put it into your hand, and shuffle your deck.";	
		}
		else if(id == CardIdentifier.DANCING_CUTLASS)
		{
			desc += "[AUTO]: [Soul Blast (2)] When this unit is placed on (RC), if you have a Granblue Vanguard, you may pay the cost. If you do, draw a card.";	
		}
		else if(id == CardIdentifier.GIGANTECH_CHARGER)
		{
			desc += "[AUTO]: When this unit is placed on (VC) or (RC), reveal the top card of your deck. If the revealed card is a Royal Paladin, call it to rear-guard, and if it is not, shuffle your deck.";
		}
		else if(id == CardIdentifier.HIGH_DOG_BREEDER_AKANE)
		{
			desc += "[AUTO]:[Counter Blast (2)] When this unit is placed on (VC) or (RC), you may pay the cost. If you do, search your deck for up to one Royal Paladin <High Beast>, call it to (RC), and shuffle your deck.";	
		}
		else if(id == CardIdentifier.PONGAL)
		{
			desc += "[ACT](RC):[Counter Blast (1)] and Put this unit into your soul] If you have a Royal Paladin vanguard, search your deck for up to one card named \"Soul Saver Dragon\", reveal it to your opponent, put it into your hand, and shuffle your deck.";	
		}
		else if(id == CardIdentifier.PERFECT_RAIZER)
		{
			desc +="[CONT](VC/RC) If you do not have another card with 'Raizer' in its card name on your (VC) or (RC) this unit gets [Power]-2000. [CONT](VC) During your turn this unit gets [Power]+3000 for each card in your soul with 'Raizer' in its card name.[CONT](VC) During your turn if the number of cards in your soul with 'Raizer' in its card name is four or more this unit gets [Critical]+1.[AUTO] When this unit is placed on (VC) put all rear-guards you have with 'Raizer' in its card name into your soul.";
		}
		else if(id == CardIdentifier.DUELING_DRAGON__ZANBAKU)
		{
			desc +="[CONT](VC/RC)If you have a non-Murakumo vanguard or rear-guard this unit gets [Power]-2000.[AUTO](VC)At the beginning of your opponents ride phase if your opponent has a grade 3 or greater vanguard your opponent may choose a card from his or her hand and discard it. If your opponent does not your opponent cannot normal ride during that ride phase.";
		}
		else if(id == CardIdentifier.HI_POWERED_RAIZER_CUSTOM)
		{
			desc +="[CONT](VC/RC)During your turn if you have a unit named 'Battleraizer' in the back row of the same column as this unit this unit gets [Power]+8000.";
		}
		else if(id == CardIdentifier.GOLDEN_BEAST_TAMER)
		{
			desc +="[CONT](VC/RC) Restraint (This unit cannot attack.)[ACT](VC/RC)[Soul Blast (3)] This unit loses 'Restraint' until end of turn.[CONT](VC)During your turn all of your Pale Moon rear-guards in your front row get [Power]+3000.\n\n[AUTO]When this unit is placed on (VC) choose a Pale Moon ltChimeragt from your soul and call it to (RC).";
		}
		else if(id == CardIdentifier.MACHINING_STAG_BEETLE)
		{
			desc +="[AUTO]When this unit is placed on (VC) choose up to two Megacolony with 'Machining' in its card name from your soul call them to separate (RC) as [Rest] and increase this units [Power] by the sum of the original [Power] of the units called with this effect until end of turn.";
		}
		else if(id == CardIdentifier.IMPERIAL_DAUGHTER)
		{
			desc +="[CONT](VC/RC) Restraint (This unit cannot attack.)[ACT](VC/RC)[Counter Blast (1) amp Choose another of your Oracle Think Tank rear-guards and put it into your soul] This unit loses 'Restraint' until end of turn.[CONT](VC)During your turn if you do not have any rear-guards this unit gets [Power]+10000/[Critical]+1 and loses 'Restraint'.";
		}
		else if(id == CardIdentifier.WEATHER_FORECASTER__MISS_MIST)
		{
			desc +="[AUTO]When this unit is placed on (GC) if it is during the battle in which your opponents grade 2 or less vanguard attacked choose one of your Oracle Think Tank that is being attacked and that unit cannot be hit until end of that battle.";
		}
		else if(id == CardIdentifier.MISS_SPLENDOR)
		{
			desc +="[AUTO](VC/RC)When this unit attacks your opponents units cannot intercept until end of that battle.";
		}
		else if(id == CardIdentifier.ROCKET_HAMMER_MAN)
		{
			desc +="[ACT](RC)[Rest] this unit] Choose another of your Nova Grappler and that unit gets [Power] +2000 until end of turn.";
		}
		else if(id == CardIdentifier.TWIN_SWORDSMAN__MUSASHI)
		{
			desc +="[AUTO](VC/RC)When this unit attacks if the number of rear-guards you have is more than your opponents this unit gets [Power]+3000 until end of that battle.";
		}
		else if(id == CardIdentifier.PROMISE_DAUGHTER)
		{
			desc +="[AUTO](VC/RC)[Choose an Oracle Think Tank from your hand and discard it] When this unit attacks you may pay the cost. If you do this unit gets [Power]+5000 until end of that battle.";
		}
		else if(id == CardIdentifier.BELLICOSITY_DRAGON)
		{
			desc +="[AUTO](VC/RC) When this units attack hits a vanguard if you have a Kagero vanguard choose a card from your damage zone and turn it face up.";
		}
		else if(id == CardIdentifier.GUARD_GRIFFIN)
		{
			desc +="[AUTO][Counter Blast (1)] When this units is placed on (GC) if you have a Kagero vanguard you may pay the cost. If you do this unit gets [Shield]+5000.";
		}
		else if(id == CardIdentifier.SAGE_OF_GUIDANCE__ZENON)
		{
			desc +="[AUTO]When this unit is placed on (RC) if you have a Royal Paladin vanguard reveal the top card of your deck. If the revealed card is a Royal Paladin with the same grade as your vanguard ride it and if it is not put that card into your drop zone.";
		}
		else if(id == CardIdentifier.SAVAGE_KING)
		{
			desc +="[ACT](VC/RC)[Soul Blast (1) amp Choose another of your Tachikaze rear-guard and retire it] This unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.BOOMERANG_THROWER)
		{
			desc +="[AUTO]When this unit rides a Nova Grappler this unit gets '[CONT](VC)If this unit would attack it may instead attack an opponents unit in the back row.' until end of turn.";
		}
		else if(id == CardIdentifier.RAIZER_CUSTOM)
		{
			desc +="[CONT](VC/RC)During your turn if you have a unit named 'Battleraizer' in the back row of the same column as this unit this unit gets [Power]+6000.";
		}
		else if(id == CardIdentifier.WALL_BOY)
		{
			desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
		}
		else if(id == CardIdentifier.CAT_BUTLER)
		{
			desc +="[AUTO](RC)[Retire this unit] At the beginning of the close step of the battle that your vanguard attacked if the attack did not hit during that battle you may pay the cost. If you do choose one of your grade 2 or less Nova Grappler vanguards and [Stand] it.";
		}
		else if(id == CardIdentifier.JUMPING_JILL)
		{
			desc +="[AUTO]When this unit is placed on (RC) from your soul if you have a Pale Moon vanguard this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.NITRO_JUGGLER)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Pale Moon vanguard you may Soul Charge (1).";
		}
		else if(id == CardIdentifier.STARTING_PRESENTER)
		{
			desc +="[AUTO]When another Pale Moon rides this unit you may Soul Charge (2).";
		}
		else if(id == CardIdentifier.LARK_PIGEON)
		{
			desc +="[AUTO](Soul)At the beginning of your guard step if you have a Pale Moon vanguard and you do not have any cards in your hand you may call this card to (GC) as [Rest].";
		}
		else if(id == CardIdentifier.SWIFT_ARCHER__FUSHIMI)
		{
			desc +="[AUTO]When this unit rides a Murakumo this unit gets '[CONT](VC)If this unit would attack it may instead attack an opponents unit in the back row.' until end of turn.";
		}
		else if(id == CardIdentifier.LEFT_ARRESTER)
		{
			desc +="[CONT][(RC) in the left column of the front row]If you have a Murakumo vanguard and you have a unit named 'Right Arrester' on (RC) in the right column of the front row this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.RIGHT_ARRESTER)
		{
			desc +="[CONT][(RC) in the right column of the front row]If you have a Murakumo vanguard and you have a unit named 'Left Arrester' on (RC) in the left column of the front row this unit gets [Power]+3000.";
		}
		else if(id == CardIdentifier.MACHINING_MANTIS)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Megacolony with 'Machining' in its card name in your soul this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.MACHINING_HORNET)
		{
			desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Megacolony with 'Machining' in its card name in your soul this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.MACHINING_WORKER_ANT)
		{
			desc +="[AUTO]When this unit is placed on (RC) choose one of your Megacolony rear-guards with 'Machining' in its card name and [Stand] it.";
		}
		else if(id == CardIdentifier.PROWLING_DRAGON__STRIKEN)
		{
			desc +="[CONT](VC) Restraint (This unit cannot attack.)[AUTO](VC)When this unit is attacked if there are no boosting units this unit gets [Power]+5000 until end of that battle.\n\n[AUTO]When another Kagero rides this unit choose one of your vanguards and that unit get [Power]+5000/[Critical]+1 until end of turn.";
		}
		else if(id == CardIdentifier.SPIKE_BOUNCER)
		{
			desc +="[AUTO](VC/RC)When an attack by another of your Spike Brothers hits a vanguard this unit gets [Power]+3000 until end of turn.";
		}
		else if(id == CardIdentifier.EXCULPATE_THE_BLASTER)
		{
			desc +="[CONT](Hand)If you do not have a grade 3 Royal Paladin vanguard you cannot normal ride this card.\n\n" +
			       "[CONT](VC)If you do not have a card named 'Blaster Blade' in your soul this unit cannot attack.\n\n" +
				   "[AUTO]When this card is placed on (RC) retire this unit.\n\n" +
				   "[ACT](VC)[Counter Blast (3)] Until end of turn this unit battles all of your opponents units in one attack.\n\n" +
				   "[AUTO](VC)When this unit attacks put all cards in your soul not named 'Blaster Blade' into your drop zone and this unit gets [Power]+2000 until end of turn for each card put into your drop zone this way.\n\n[AUTO](VC)At the end of the battle that this unit attacked choose a card named 'Blaster Blade' from your drop zone or soul ride it as [Rest] and put all cards in your soul into your drop zone.";
		}
else if(id == CardIdentifier.TOP_IDOL__PACIFICA)
{
desc +="[CONT](VC)During your turn if the number of Bermuda Triangle rear-guards you have is four or more this unit gets [Power]+3000.[AUTO](VC)At the beginning of your main phase Soul Charge (1) draw a card choose a card from your hand and put it on the bottom of your deck.[AUTO](VC/RC)[Soul Blast (8) amp Counter Blast (5)] When this units attack hits a vanguard you may pay the cost. If you do search your deck up to three Bermuda Triangle call them to separate (RC) and shuffle your deck.";
}
else if(id == CardIdentifier.TOP_IDOL__RIVIERE)
{
desc +="[CONT](VC) If you have a card named 'Super Idol Riviere' in your soul this unit gets [Power]+1000.[AUTO] (VC)[Counter Blast (2) amp Choose a card named 'Top Idol Riviere' from your hand and discard it] When this units attack hits a vanguard you may pay the cost. if you do choose up to three of your Bermuda Triangle rear-guards and those units get [Power]+5000 until end of turn.";
}
else if(id == CardIdentifier.BERMUDA_PRINCESS__LENA)
{
desc +="[CONT](VC)During your turn if the number of Bermuda Triangle rear-guards you have is four or more this unit gets [Power] +3000.[AUTO]When this unit is placed on (VC) return all of your Bermuda Triangle rear-guards to your hand.";
}
else if(id == CardIdentifier.PEARL_SISTERS__PERLE)
{
desc +="[AUTO]When this unit is placed on (RC) if you have a Bermuda Triangle vanguard choose one of your units named 'Pearl Sisters Perla' and that unit gets '[AUTO](VC/RC)When this units attack hits a vanguard Soul Charge (1) and draw a card.' until end of turn.";
}
else if(id == CardIdentifier.PEARL_SISTERS__PERLA)
{
desc +="[AUTO](VC/RC)[Soul Blast (1)] When this units attack hits a vanguard you may pay the cost. If you do choose another of your Bermuda Triangle rear-guards and return it to your hand.";
}
else if(id == CardIdentifier.GIRLS______ROCK__RIO)
{
desc +="[AUTO][Counter Blast (1)] When this unit is returned to your hand from (RC) if you have a Bermuda Triangle vanguard you may pay the cost. If you do Soul Charge (1) and draw a card.";
}
else if(id == CardIdentifier.MERMAID_IDOL__ELLY)
{
desc +="[CONT] Sentinel (You may only have up to four cards with '[CONT] Sentinel' in a deck)[AUTO][Choose a Bermuda Triangle from your hand and discard it] When this unit is placed on (GC) you may pay the cost. If you do choose one of your Bermuda Triangle that is being attacked and that unit cannot be hit until end of that battle.";
}
else if(id == CardIdentifier.SUPER_IDOL__CERAM)
{
desc +="[AUTO] (VC/RC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power] +3000 until end of that battle.";
}
else if(id == CardIdentifier.SUPER_IDOL__RIVIERE)
{
desc +="[CONT](VC)If you have a card named 'Mermaid Idol Riviere' in your soul this unit gets [Power]+1000.[AUTO]When a card named 'Top Idol Riviere' rides this unit if you have a card named 'Mermaid Idol Riviere' in your soul draw a card.";
}
else if(id == CardIdentifier.MERMAID_IDOL__FLUTE)
{
desc +="[CONT](VC/RC)During your turn if the number of Bermuda Triangle rear-guards you have is four or more this unit gets [Power]+3000.";
}
else if(id == CardIdentifier.TURQUOISE_BLUE__TYRRHENIA)
{
desc +="AUTOR [Soul Blast (2)] When an attack hits a vanguard during the battle that this unit boosts a Bermuda Triangle you may pay the cost. If you do choose another of your Bermuda Triangle rear-guards and return it to your hand.";
}
else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__WEDDELL)
{
desc +="AUTO When another Bermuda Triangle rides this unit you may call this card to Rear-guard Circle.ACTR [Put this unit into your soul] If you have a Bermuda Triangle vanguard choose one of your Bermuda Triangle rear-guards and return it to your hand.";
}
else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__RIVIERE)
{
desc +="[AUTO]When a card named 'Mermaid Idol Riviere' rides this unit look at up to seven cards from the top of your deck search for up to one card named 'Super Idol Riviere' or 'Top Idol Riviere' from among them reveal it to your opponent put it into your hand and shuffle your deck.[AUTO]When a Bermuda Triangle other than a card named 'Mermaid Idol Riviere' rides this unit you may call this unit to (RC).";
}
else if(id == CardIdentifier.VELVET_VOICE__RAINDEAR)
{
desc +="[AUTO](VC)[Choose one of your Bermuda Triangle rear-guards and return it to your hand] When this units drive check reveals a grade 3 Bermuda Triangle you may pay the cost. If you do choose up to one Bermuda Triangle from your hand and call it to an open (RC).";
}
else if(id == CardIdentifier.RAINBOW_LIGHT__CARINE)
{
desc +="[AUTO][Counter Blast (1)] When this unit is returned to your hand from (RC) if you have a Bermuda Triangle vanguard you may pay the cost. If you do Soul Charge (1) and draw a card.";
}
else if(id == CardIdentifier.INTELLI_IDOL__MELVILLE)
{
desc +="[AUTO]V [Choose 1 of your Bermuda rearguards and return it to your hand] When this units drive check reveals a grade 3 Bermuda you may pay the cost. If you do choose up to 1 Bermuda from your hand and call it to an open Rearguard Circle.";
}
else if(id == CardIdentifier.SNOW_WHITE_OF_THE_CORALS__CLAIRE)
{
desc +="AUTO When this card is placed on Rear-guard Circle choose another of your Bermuda Triangle unit and that unit gets Power +2000 until end of turn.";
}
else if(id == CardIdentifier.DIVA_OF_CLEAR_WATERS__IZUMI)
{
desc +="[AUTO] When this unit intercepts if you have a Bermuda Triangle vanguard this unit gets [Shield]+5000 until end of that battle.";
}
else if(id == CardIdentifier.PRISM_ON_THE_WATER__MYRTOA)
{
desc +="[AUTO] When this unit is placed on (VC) or (RC) if you have a Bermuda Triangle vanguard each player may draw a card.";
}
else if(id == CardIdentifier.MERMAID_IDOL__FELUCCA)
{
desc +="[AUTO]When this unit is placed on (VC) or (RC) if you have a Bermuda Triangle vanguard you may Soul Charge (1).";
}
else if(id == CardIdentifier.MERMAID_IDOL__RIVIERE)
{
desc +="[CONT](VC)If you have a card named 'Bermuda Triangle Cadet Riviere' in your soul this unit gets Power +1000.[AUTO]When a card named 'Super Idol Riviere' rides this unit if you have a card named 'Bermuda Triangle Cadet Riviere' in your soul draw a card.";
}
else if(id == CardIdentifier.NAVY_DOLPHIN__AMUR)
{
desc +="[AUTO](RC)[Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
}
else if(id == CardIdentifier.DRIVE_QUARTET__RESSAC)
{
desc +="CONTR If you have a unit named 'Drive Quartet Flows' on your Rear-guard Circle this unit gets Power +3000.";
}
else if(id == CardIdentifier.DRIVE_QUARTET__FLOWS)
{
desc +="(You may only have up to four cards with 'HEAL' in a deck.)[CONT](RC)If you have a unit named 'Drive Quartet Shuplu' on your (RC) this unit gets [Power]+3000.";
}
else if(id == CardIdentifier.DRIVE_QUARTET__SHUPLU)
{
desc +="[CONT](RC)If you have a unit named 'Drive Quartet Bubblin' on your (RC) this unit gets [Power]+3000.";
}
else if(id == CardIdentifier.DRIVE_QUARTET__BUBBLIN)
{
desc +="[CONT](RC)If you have a unit named 'Drive Quartet Ressac' on your (RC) this unit gets [Power]+3000.";
}
else if(id == CardIdentifier.BERMUDA_TRIANGLE_CADET__SHIZUKU)
{
desc +="[AUTO] Forerunner (When a unit of the same clan rides this unit you may call this unit to (RC))[ACT](RC)[Counter Blast (1) amp Put this unit into your soul] Look at the top five cards of your deck search for up to one grade 3 Bermuda Triangle from among them reveal it to your opponent put it into your hand and shuffle your deck.";
}
		else if(id == CardIdentifier.NAVALGAZER_DRAGON)
{
desc +="[ACT](VC) Limit Break 4 (This ability is active if you have four or more damage)[Counter Blast (2)] Until end of turn this unit gets [Power]+3000 and '[AUTO](VC)When this units attack hits a vanguard if it is the third battle of that turn or more choose up to two of your Aqua Force rear-guards and [Stand] them.'.[AUTO](VC)When this unit attacks if it is the third battle of that turn or more this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.MARINE_GENERAL_OF_THE_FULL_TIDES__XENOPHON)
{
desc +="[AUTO](VC)When this unit attacks if it is the third battle of that turn or more this unit gets [Power]+3000 until end of that battle.[AUTO](RC)When this unit attacks if you have an Aqua Force vanguard and if it is the third battle of that turn or more this unit gets [Power]+1000 until end of that battle.";
}
else if(id == CardIdentifier.KEY_ANCHOR__DABID)
{
desc +="[AUTO](VC/RC)[Counter Blast (1)] When this unit attacks you may pay the cost. If you do this unit gets [Power]+3000 until the end of that battle.";
}
else if(id == CardIdentifier.TEAR_KNIGHT__LAZARUS)
{
desc +="ENG";
}
else if(id == CardIdentifier.MARINE_GENERAL_OF_THE_RESTLESS_TIDES__ALGOS)
{
desc +="[AUTO](VC/RC)When this units attack hits a vanguard if you have an Aqua Force vanguard and if it is the fourth battle of that turn or more draw a card.";
}
else if(id == CardIdentifier.CORAL_ASSAULT)
{
desc +="[AUTO](VC/RC)When this unit attacks if you have an Aqua Force vanguard and if it is the third battle of that turn or more this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.TITAN_OF_THE_INFINITE_TRENCH)
{
desc +="[AUTO]When this unit intercepts if you have an Aqua Force vanguard this unit gets [Shield]+5000 until end of that battle.";
}
else if(id == CardIdentifier.TEAR_KNIGHT__THEO)
{
desc +="ENG";
}
else if(id == CardIdentifier.TEAR_KNIGHT__CYPRUS)
{
desc +="[ACT](VC/RC)[Counter Blast (1)] This unit gets [Power]+1000 until end of turn.";
}
else if(id == CardIdentifier.ACCELERATED_COMMAND)
{
desc +="[AUTO]When this unit is placed on (RC) choose another of your Aqua Force and that unit gets [Power]+2000 until end of turn.";
}
else if(id == CardIdentifier.SPLASH_ASSAULT)
{
desc +="[AUTO](VC/RC)When this unit attacks if you have an Aqua Force vanguard and if it is the third battle of that turn or more this unit gets [Power]+3000 until end of that battle.";
}
else if(id == CardIdentifier.BATTLE_SIREN__CYNTHIA)
{
desc +="[AUTO](RC)[Choose a card from your hand and discard it] When an attack hits during the battle that this unit boosted you may pay the cost. If you do draw a card.";
}
else if(id == CardIdentifier.BATTLE_SIREN__DOROTHEA)
{
desc +="[AUTO](RC)When this unit boosts an Aqua Force vanguard if it is the third battle of that turn or more the boosted unit gets [Power]+4000 until end of that battle.";
}
else if(id == CardIdentifier.MEDICAL_OFFICER_OF_THE_RAINBOW_ELIXIR)
{
desc +="(You may only have up to four cards with 'HEAL' in a deck.)";
}
	}
		
	public void SetGamePhase(GamePhase gp)
	{
		_CurrentPhase = gp;	
	}
		}
