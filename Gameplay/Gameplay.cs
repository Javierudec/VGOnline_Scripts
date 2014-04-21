using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public enum AttackType
{
	NONE,
	ALL,
	FRONT_ROW
}

public enum OPPWINDOW
{
	ACCEPT,
	DENIED,
	NONE
}

public class Gameplay : MonoBehaviour {
	public GUIStyle yesButtonStyle, noButtonStyle;

	public bool bCheckAutoMode = false;
	public bool bAutoCanBeTriggered = false;
	public SelectionListGenericWindow _AbilityManagerList;

	bool bWinByCardEffect = false;
	bool bLoseByCardEffect = false;

	public GUIStyle CustomMessageStyle;

	public fieldPositions LastOpenRC = fieldPositions.DECK_ZONE;
	public bool bBlockDropMenu = false;
	public int lastIDRegistered = -1;
	public NotificacionWindow _NotificationWindow = null;
	public DecisionWindow _DecisionWindow = null;
	public bool bEnemyEffectOngoing = false;
	public Card ownerCardCallEvent = null;
	public bool bBlockEnemyTriggerEffects = false;
	bool bBlockTriggerEffects = false;
	bool bConfirmBeginGuard = false;
	public bool bDeckHasBeenShuffledThisTurn = false;
	public List<int> intArr;
	public SelectionListWindow _SelectionListWindow = null;
	public SelectionCardNameWindow _SelectionCardNameWindow = null;
	public int numBattle = 1;
	public Card LastGuardCardSelected = null;
	public bool bEnemyWaiting = false;
	public Card LastDamageCardSelected = null;
	public bool bHealDriveTrigger = false;
	public bool bHealTrigger = false;
	bool bConfirmBoost = false;
	bool bBoostWindow = false;
	bool bOpponentSurrender = false;
	bool bSurrender = false;
	public Card LastEnemyHandSelected = null;
	public Card LastEnemyDamageCardSelected = null;
	public Card LastCallFromDrop = null;
	public Card LastCall = null;
	public Card LastRest = null;
	public Card LastCallFromSoul = null;
	public bool EffectOnGoingEnemyTurn = false;
	public int bMinGuardGradeBlocked = 0;
	private DynamicText stateDynamicText = null;
	public bool bCanReceiveDamage = true;
	public bool bCanNormalGuard = true;
	
	List<Card> FromHandToBindList = null;
	
	Card DD_Card = null;
	
	//Card objects are stored here when an ability is actived in the enemy turn.
	public List<Card> EnemyTurnStackedCards = null;
	
	public List<Card> UnitsCalled = null;
	
	public bool bCallToSameColum = false;
	public fieldPositions bCallSameColPos = fieldPositions.DECK_ZONE;
	
	public AttackType _AttackType = AttackType.NONE;
	private int LastAttackedListIndex = -1;
	
	private bool bOpponentWindow = false;
	private string bOpponentWindowMessage = "";
	
	public OPPWINDOW LastOpponentWindow = OPPWINDOW.NONE;
	public Card OppWindowRequestedBy = null;
	
	//Styles
	public GUIStyle PowerIconStyle;
	public GUIStyle ConfirmationWindowStyle;
	public GUIStyle ConfirmationWindowTextStyle;
	
	private const int DRIVECHECK_DELAY = 1;
	public const int SHOW_CARD_DELAY = 1;
	
	public Card SoulBlastCardAlly = null;
	
	public bool bEndEvent = false;
	
	public bool _OppRideFromSoulEvent = false;
	public bool _OppRetireUnitEvent = false;	
	public bool _OppCallFromTopDeck = false;
	
	public bool bBlockInterceptUntilEndTurn = false;
	public bool bBlockInterceptUntilEndBattle = false;	
	public bool bBlockGuardEndBattle = false;
	public int bMaxGuardGradeBlocked = -1;
	public bool bBlockUnitReplacing = false;
	public bool bBlockNormalRideEndTurn = false;
	
	public bool bSpecialCallFromDrive = false;
	public bool bCallFromDrop = false;
	
	public AbilityManager _AbilityManager;
	public AbilityManagerExt _AbilityManagerExt;
	
	public MouseHelper _MouseHelper = null;
	//Timers
	public float ShowCardTimer = 0;
	
	public Card SoulBlastCard = null;
	public Card ReturnToDeckCard = null;
	
	private Card FromHandToSoulCard = null;
	
	public bool bCallFromDeck = false;
	
	private bool bDiscard = false;
	
	private List<Card> EnemySoulBlastQueue = null;
	
	//Blockers
	public bool bBlockDriveCheck = false;
	public bool bBlockMouse = false;
	private Card _AuxCard = null;
	public bool bBlockMouseOnce = false;
	public bool bEffectOnGoing = false;
	
	public CardMenu _CardMenu;
	
	private bool bTargetSelected = false;
	
	public Deck playerDeck;
	private EnemyDeck enemyDeck;
	
	public PlayerHand playerHand;
	public EnemyHand enemyHand;
	
	public GamePhase gamePhase;
	private bool bDoAttackOnce = true;
	
	public Field field;
	public EnemyField enemyField;
	public GuardZone guardZone;
	private Card _CardWindow;
	
	public bool bConfirmAttack = false;
	
	private bool bDrawing;
	private int cardToChange;
	private bool bPlayerTurn;
	private bool bIsCardSelectedFromHand;
	public static FieldInformation fieldInfo;
	public static EnemyFieldInformation EnemyFieldInfo;
	public CardDataBase Data;
	//private CameraPosition camera;
	Camera _MainCamera;
	
	private	bool bDriveAnimation;
	private bool bChooseTriggerEffects;
	private bool bChooseAttack;
	public bool bChooseEffect;
	private float driveTime;
	//Window that appears when two units are battling.
	private bool bShowAttackPowerWindow = false;
	private bool bShowDefensePowerWindow = false;
	
	public Card CardToAttack = null;
	public Card CardAttacking = null;
	
	public delegate void Void0ParamsDelegate();
	Void0ParamsDelegate CallFromBindCallback;
	
	public Card DriveCard;
	public bool bAttacking = false;
	
	private bool bFlipVanguard = false;
	
	private NetworkPlayer opponent;
	
	public Rect connectionWindowRect;
	public bool bPopUpOpen = false;
	public int LastPPAnswer = 0;
	
	private GameObject CardSelector;
	
	//Damage Check
	public bool bDamageCheckTrigger = false;
	private Card lastDamageCard;
	private bool bGivePowerEffect = false;
	private bool bTriggerEffect = false;
	
	//The player can do just one Ride per turn, to control this we use the bRideThisTurn variable.
	public bool bRideThisTurn = false;
	
	//Pause the game, used when networking syncro is needed.
	private bool bPauseGameplay = false;
	//When ConfirmAction is called, player can still doing some action. So bOponnentHasConfirmed is like a stacked bool.
	private bool bOponnentHasConfirmed = false;
	
	bool bTakeDamage = false;
	
	int numTurn = 1;
	int num_damage = 0;
	bool bTwinDrive = false;
	
	public GameHelper _GameHelper = null;
	
	public CardHelpMenu _CardMenuHelper;
	
	private bool bGameEnded = false;
	
	public Card _LastUnitAbilityCard = null;

	//EndGame window
	public Texture2D _BackgroundTexture;
	public Texture2D _YouWinTexture;
	public Texture2D _YouLoseTexture;
	
	public Texture2D _CardEffectTexture;
	public float _EffectTime;
	public bool bShowCardEffect = false;
	
	public bool bCardMenuJustClosed = false;
	public bool bPopupJustClosed = false;
	
	//Show card from the opponent hand.
	public const float SHOW_CARD_FROM_HAND_DELAY = 3;
	public float ShowingCardAtHandTimer = 0.0f;
	public bool bIsCardAtHandShowing = false;
	
	public PopupNumber _PopupNumber = null;
	
	//Chat
	public Chat GameChat;
	
	private GamePhase _CurrentPhase = GamePhase.NONE;
	
	private List<Card> AttackedList;
	private int CurAttackedListIndex = 0;
	
	public bool bDoPerfectGuardPerBattle = false; 
	public EnemyPhase enemyPhase = EnemyPhase.NONE;
	
	#region Gameplay variables
	public bool bSpecialCall = false;
	#endregion
	
	bool bForceToCallFromBind = false;
	int iNumberOfUnitsToCallFromBind = 0;

	bool _OppFromFieldToDamage = false;
	bool _OppBindHandFacedownReturnEndTurn = false;

	UnitObject dummyUnitObject;

	bool bConfirmEndTurn = false;

	#region Multiplayer Options
	[RPC]
	void SendInformationToOpponent_Server(int cardID, int gameAction, int other1, int other2, string str1, int other3, NetworkPlayer player)
	{

	}

	[RPC]
	void SendInformationToOpponent(int cardID, int gameAction, int other1, int other2, string str1, int other3 = 0)
	{
		CardIdentifier _cardID = (CardIdentifier)cardID;
		GameAction _gameAction = (GameAction)gameAction;
		
		if(_gameAction == GameAction.PLACE_INITIAL_VANGUARD)
		{
			//Remove a card from the deck an put it on the vanguard circle.
			Card tempCard = enemyDeck.DrawCard();
			Data.FillCardWithData(tempCard, _cardID);
			enemyField.Ride(tempCard);
			tempCard.TurnDown();
		}
		else if(_gameAction == GameAction.FROM_SOUL_TO_DECK)
		{
			Card tmpCard = enemyField.GetCardFromSoulByID(_cardID);
			enemyField.RemoveFromSoul(tmpCard);
			enemyDeck.AddCard(tmpCard);
		}
		else if(_gameAction == GameAction.FROM_SOUL_TO_HAND)
		{
			Card tmp = enemyField.GetCardFromSoulByID(_cardID);
			enemyField.RemoveFromSoul(tmp);
			enemyField.Ride(tmp);
		}
		else if(_gameAction == GameAction.DYNAMICTEXT_GAMEPHASE)
		{
			stateDynamicText.SetText(str1);
		}
		else if(_gameAction == GameAction.ENEMY_REST)
		{
			Card tmp = field.GetCardAt(Util.TransformToPlayerField((fieldPositions)other1));
			dummyUnitObject.RestUnit(tmp);
		}
		else if(_gameAction == GameAction.LOSE_BY_CARD_EFFECT)
		{
			bGameEnded = true;
			bPauseGameplay = false;
			bWinByCardEffect = false;
			bLoseByCardEffect = true;
		}
		else if(_gameAction == GameAction.FORCE_DAMAGE_CHECK)
		{
			ForceDamageCheck(other1);
		}
		else if(_gameAction == GameAction.FROM_DECK_TO_GUARDIANCIRCLE)
		{
			Card tempCard = enemyDeck.DrawCard();
			Data.FillCardWithData(tempCard, _cardID);
			guardZone.AddToGuardZone(tempCard, false);
			//guardZone.AddExtraPower(tempCard.shield);
			CardToAttack.AddExtraShield(tempCard.shield);
			tempCard.TurnUp();
		}
		else if(_gameAction == GameAction.FROM_BIND_TO_DROP)
		{
			Card tmp = enemyField.GetCardFromBindByID(_cardID);
			enemyField.RemoveFromBindZone(tmp);
			enemyField.AddToDropZone(tmp, false);
		}
		else if(_gameAction == GameAction.OPPONENT_FROM_BIND_TO_DROP)
		{
			Card tmp = field.GetBoundByID(_cardID);
			dummyUnitObject.FromBindToDrop(tmp);
		}
		else if(_gameAction == GameAction.OPPONENT_FROM_HAND_TO_BIND)
		{
			int index = playerHand.Size() - other1;
			dummyUnitObject.FromHandToBind(playerHand.GetCardAtIndex(index), index, true);
		}
		else if(_gameAction == GameAction.ENEMY_FROM_BIND_TO_HAND)
		{
			Card cardToReturn = field.GetBoundByID(_cardID);
			dummyUnitObject.FromBindToHand(cardToReturn);
		}
		else if(_gameAction == GameAction.SET_ENEMY_ENDTURN)
		{
			enemyPhase = EnemyPhase.ENDTURN;
			SendPacket(GameAction.CONFORM_ENEMY_ENDTURN);
		}
		else if(_gameAction == GameAction.CONFORM_ENEMY_ENDTURN)
		{
			bConfirmEndTurn = true;
		}
		else if(_gameAction == GameAction.MOVE_TO_OPENRC)
		{
			Card c = enemyField.GetCardAt(Util.TranformToEnemyPosition((fieldPositions)other1));

			EnemyFieldPosition p2 = Util.TranformToEnemyPosition((fieldPositions)other2);
			fieldPositions p = Util.EnemyToFieldPosition(p2);

			enemyField.ClearZone(Util.TransformToEquivalentEnemyPosition(c.pos));

			c.pos = p;
			
			if(p == fieldPositions.ENEMY_FRONT_LEFT) enemyField.Left_Front = c;
			else if(p == fieldPositions.ENEMY_FRONT_RIGHT) enemyField.Right_Front = c;
			else if(p == fieldPositions.ENEMY_REAR_CENTER) enemyField.Center_Rear = c;
			else if(p == fieldPositions.ENEMY_REAR_RIGHT) enemyField.Right_Rear = c;
			else if(p == fieldPositions.ENEMY_REAR_LEFT)  enemyField.Left_Rear = c;

			Vector3 newVector = enemyField.fieldInfo.GetPosition((int)p2);
			c.GoTo(newVector.x, newVector.z);
		}
		else if(_gameAction == GameAction.EXCHANGE)
		{
			Card c1 = enemyField.GetCardAt(Util.TranformToEnemyPosition((fieldPositions)other1));
			Card c2 = enemyField.GetCardAt(Util.TranformToEnemyPosition((fieldPositions)other2));

			fieldPositions p1 = c1.pos;
			fieldPositions p2 = c2.pos;
			
			if(p1 == fieldPositions.ENEMY_REAR_CENTER)      enemyField.Center_Rear = c2;
			else if(p1 == fieldPositions.ENEMY_REAR_LEFT)   enemyField.Left_Rear   = c2;
			else if(p1 == fieldPositions.ENEMY_REAR_RIGHT)  enemyField.Right_Rear  = c2;
			else if(p1 == fieldPositions.ENEMY_FRONT_LEFT)  enemyField.Left_Front  = c2;
			else if(p1 == fieldPositions.ENEMY_FRONT_RIGHT) enemyField.Right_Front = c2;
			
			if(p2 == fieldPositions.ENEMY_REAR_CENTER)      enemyField.Center_Rear = c1;
			else if(p2 == fieldPositions.ENEMY_REAR_LEFT)   enemyField.Left_Rear   = c1;
			else if(p2 == fieldPositions.ENEMY_REAR_RIGHT)  enemyField.Right_Rear  = c1;
			else if(p2 == fieldPositions.ENEMY_FRONT_LEFT)  enemyField.Left_Front  = c1;
			else if(p2 == fieldPositions.ENEMY_FRONT_RIGHT) enemyField.Right_Front = c1;
			
			c1.pos = p2;
			c2.pos = p1;
			
			Vector3 c1NewPos = enemyField.fieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(c1.pos));
			Vector3 c2NewPos = enemyField.fieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(c2.pos));
			
			c1.GoTo(c1NewPos.x, c1NewPos.z);
			c2.GoTo(c2NewPos.x, c2NewPos.z);
		}
		else if(_gameAction == GameAction.SET_ENEMY_MAIN)
		{
			enemyPhase = EnemyPhase.MAIN;
		}
		else if(_gameAction == GameAction.BIND_HAND_FACEDOWN_RETURN_ENDTURN)
		{
			_OppBindHandFacedownReturnEndTurn = true;
			GameChat.AddHelpMessage("Choose a card from your hand and bind it.");
		}
		else if(_gameAction == GameAction.OPPONENT_FROM_FIELD_TO_DAMAGE)
		{
			_OppFromFieldToDamage = true;
			GameChat.AddHelpMessage("Choose one of your rear-guards.");
		}
		else if(_gameAction == GameAction.ENEMY_FROM_DAMAGE_TO_DROP)
		{
			Card c = field.GetDamageAtIndex(other1);
			dummyUnitObject.FromDamageToDrop (c);
		}
		else if(_gameAction == GameAction.FROM_DRIVE_TO_DROP)
		{
			enemyField.AddToDropZone(DriveCard, false);
		}
		else if(_gameAction == GameAction.OPEN_DECISIONWINDOW)
		{
			Card tmp = enemyField.GetCardAt(Util.TranformToEnemyPosition((fieldPositions)other1));

			_DecisionWindow.Set(tmp, other2);
			_DecisionWindow.SetCaption(str1);

		}
		else if(_gameAction == GameAction.DECISIONWINDOW_ACCEPT)
		{
			Card tmp = field.GetCardAt(Util.TransformToPlayerField((fieldPositions)other1));
			if(tmp != null)
			{
				tmp.unitAbilities.DecisionWindowAccept(other2);
			}
		}
		else if(_gameAction == GameAction.REGISTER_ID)
		{
			lastIDRegistered = other1;
		}
		else if(_gameAction == GameAction.DECISIONWINDOW_DENIED)
		{
			Card tmp = field.GetCardAt(Util.TransformToPlayerField((fieldPositions)other1));


			if(tmp != null)
			{
				tmp.unitAbilities.DecisionWindowDenied(other2);
			}
			else
			{
				GameChat.AddChatMessage("ADMIN", "NULL");
			}
		}
		else if(_gameAction == GameAction.EFFECT_ON)
		{
			bEnemyEffectOngoing = true;
		}
		else if(_gameAction == GameAction.EFFECT_OFF)
		{
			bEnemyEffectOngoing = false;
		}
		else if(_gameAction == GameAction.BLOCK_EFFECT_TRIGGER_THIS_BATTLE)
		{
			bBlockTriggerEffects = true;
		}
		else if(_gameAction == GameAction.CREATE_AUXILIAR_INT_ARRAY)
		{
			intArr = new List<int>();	
		}
		else if(_gameAction == GameAction.ADD_TO_INT_ARRAY)
		{
			intArr.Add(other1);	
		}
		else if(_gameAction == GameAction.FORCE_CALL_FROM_BIND)
		{
			bForceToCallFromBind = true;
			iNumberOfUnitsToCallFromBind = other1;
			field.ViewBindZone(1, delegate(Card c) {
				for(int i = 0; i < intArr.Count; i++)
				{
					CardIdentifier tmpId = (CardIdentifier)intArr[i];
					if(tmpId == c.cardID)
					{
						return true;	
					}
				}
				return false;
			});
			bEndEvent = false;
		}
		else if(_gameAction == GameAction.OPPONENT_CANNOT_NORMAL_GUARD_ENDBATTLE)
		{
			bCanNormalGuard = false;
		}
		else if(_gameAction == GameAction.OPPONENT_CANNOT_RECEIVEDAMAGE_ENDBATTLE)
		{
			bCanReceiveDamage = false;
		}
		else if(_gameAction == GameAction.BIND_FROM_DECK)
		{
			//Take the top card of the enemy deck.
			Card c = enemyDeck.DrawCard();
			//Transform the card to the desired card identifier.
			Data.FillCardWithData(c, _cardID);
			//Add the card to the enemy bind zone.
			enemyField.AddToBindZone(c);
			//Perform the bind animation.
			c.TurnUp();
			c.BindAnim();
		}
		else if(_gameAction == GameAction.FROM_BIND_TO_DECK)
		{
			Card c = enemyField.GetCardFromBindByID(_cardID);
			
			enemyField.RemoveFromBindZone(c);
			enemyDeck.AddCard(c);
			
			c.FromEnemyBindTo(new Vector3(-15.89146f, -2.667145f, 9.565327f), 
			delegate {
				enemyDeck.SetDeckPosition();	
			});
		}
		else if(_gameAction == GameAction.OPPONENT_MOVE_SOUL)
		{
			fieldPositions p = (fieldPositions)other1;
			Card c = field.GetCardAt(Util.TransformToPlayerField(p));
			if(c != null)
			{
				MoveToSoul(c);	
			}
		}
		else if(_gameAction == GameAction.DRAW_FROM_DECK)
		{
			//Remove a number "other1" of cards from the deck an put them on the enemy hand.
			for(int i = 0; i < other1; i++)
			{
				enemyHand.AddToHand (enemyDeck.DrawCard());	
			}
		}
		else if(_gameAction == GameAction.FROM_DROP_TO_HAND)
		{
			Card c = enemyField.GetDropByID(_cardID);
			enemyField.RemoveFromDropZone(c);
			enemyHand.AddToHand(c);
		}
		else if(_gameAction == GameAction.BLOCK_GUARD_END_BATTLE)
		{
			bBlockGuardEndBattle = true;
			bMaxGuardGradeBlocked = other1;
		}
		else if(_gameAction == GameAction.BLOCK_GUARD_END_BATTLE_MIN)
		{
			bBlockGuardEndBattle = true;
			bMinGuardGradeBlocked = other1;
		}
		else if(_gameAction == GameAction.UNIT_CANNOT_INTERCEPT_ENDTURN)
		{
			fieldPositions p = Util.TransformToPlayerField((fieldPositions)other1);
			Card c = field.GetCardAt(p);
			SelectAnimField(c);
			c.BlockInterceptEndTurn();
		}
		else if(_gameAction == GameAction.RIDE_FROM_BIND)
		{
			Card c = enemyField.GetCardFromBindByID(_cardID);
			if(c != null)
			{
				enemyField.RemoveFromBindZone(c);
				enemyField.Ride(c);
			}
		}
		else if(_gameAction == GameAction.PLAY_CARD_ON_THE_FIELD)
		{
			//The opponent Call/Ride an unit from hand.
			EnemyFieldPosition pos = (EnemyFieldPosition)other1;
			if(pos != EnemyFieldPosition.VANGUARD)
			{
				Card tempCard = enemyHand.RemoveFromHand();
				Data.FillCardWithData(tempCard, _cardID);
				enemyField.Call(tempCard, pos);	
			}
			else
			{
				Card tempCard = enemyHand.RemoveFromHand();
				Data.FillCardWithData(tempCard, _cardID);
				enemyField.Ride(tempCard);	
			}
		}
		else if(_gameAction == GameAction.LOCK)
		{
			fieldPositions tmpPos = (fieldPositions)other1;
			Card card = field.GetCardAt(Util.TransformToPlayerField(tmpPos));
			card.Lock();
		}
		else if(_gameAction == GameAction.UNLOCK)
		{
			fieldPositions tmpPos = (fieldPositions)other1;
			Card card = field.GetCardAt(Util.TransformToPlayerField(tmpPos));
			card.Unlock();
		}
		else if(_gameAction == GameAction.LOCK_ENEMY)
		{
			enemyField.GetCardAt((EnemyFieldPosition)other1).Lock();	
		}
		else if(_gameAction == GameAction.OMEGA_LOCK)
		{
			fieldPositions tmpPos = (fieldPositions)other1;
			Card card = field.GetCardAt(Util.TransformToPlayerField(tmpPos));
			card.SetOmegaLock(true);
		}
		else if(_gameAction == GameAction.UNLOCK_ENEMY)
		{
			EnemyFieldPosition pos = (EnemyFieldPosition)other1;
			Card tempCard = enemyField.GetCardAt(pos);
			tempCard.Unlock();
			field.CheckAbilities(CardState.EnemyUnlockCard, tempCard);
			bEndEvent = true;
		}
		else if(_gameAction == GameAction.PLAY_CARD_FROM_SOUL)
		{
			EnemyFieldPosition pos = (EnemyFieldPosition)other1;
			Card tempCard = enemyField.GetCardFromSoulByID(_cardID);
			enemyField.RemoveFromSoul(tempCard);
			enemyField.Call(tempCard, pos);	
		}
		else if(_gameAction == GameAction.FROM_BIND_TO_FIELD)
		{
			EnemyFieldPosition pos = (EnemyFieldPosition)other1;
			Card tempCard = enemyField.GetCardFromBindByID(_cardID);
			enemyField.RemoveFromBindZone(tempCard);
			enemyField.Call(tempCard, pos);				
		}
		else if(_gameAction == GameAction.REST_UNIT)
		{
			enemyField.GetCardAt((EnemyFieldPosition)other1).RestEnemy();	
		}
		else if(_gameAction == GameAction.ADD_EXTRA_SHIELD)
		{
			if(CardToAttack != null)
			{
				CardToAttack.AddExtraShield(other1);	
			}
		}
		else if(_gameAction == GameAction.FROM_HAND_TO_BIND)
		{
			Card c = enemyHand.GetCardAtIndex(enemyHand.Size() - other1 - 1);
			Data.FillCardWithData(c, _cardID);
			
			FromHandToBindList.Add(c);
			c.BindAnim();
		}
		else if(_gameAction == GameAction.SELECT_UNIT_TO_ATTACK)
		{
			Card tempCard = field.GetCardAt(Util.TransformToPlayerField((fieldPositions)other1));
			PutSelectorOnCard(tempCard);	
			CardToAttack = tempCard;
			
			AttackedList.Add(CardToAttack);
			CurAttackedListIndex = 0;
			
			CardAttacking = enemyField.GetCardAt((EnemyFieldPosition)other2);
			bShowAttackPowerWindow = true;
			bShowDefensePowerWindow = true;
			
			SendPacket (GameAction.REQUEST_BOOT);
			//gamePhase = GamePhase.GUARD;		
		}
		else if(_gameAction == GameAction.ATTACK_ALL_UNITS)
		{
			AttackedList.Clear();
			
			Card c = field.GetCardAt(fieldPositions.FRONT_GUARD_LEFT);
			if(c != null) AttackedList.Add(c);
			
			c = field.GetCardAt(fieldPositions.FRONT_GUARD_RIGHT);
			if(c != null) AttackedList.Add(c);
			
			c = field.GetCardAt(fieldPositions.REAR_GUARD_LEFT);
			if(c != null) AttackedList.Add(c);
			
			c = field.GetCardAt(fieldPositions.REAR_GUARD_CENTER);
			if(c != null) AttackedList.Add(c);
			
			c = field.GetCardAt(fieldPositions.REAR_GUARD_RIGHT);
			if(c != null) AttackedList.Add(c);
			
			c = field.GetCardAt(fieldPositions.VANGUARD_CIRCLE);
			if(c != null) AttackedList.Add(c);
			
			CardToAttack = AttackedList[0];
			CurAttackedListIndex = 0;
			TargetCard(CardToAttack);
			
			CardAttacking = enemyField.GetCardAt((EnemyFieldPosition)other1);
			bShowAttackPowerWindow = true;
			bShowDefensePowerWindow = true;
			
			BeginGuardPhase();
			
			gamePhase = GamePhase.GUARD;			
		}
		else if(_gameAction == GameAction.ALL_FRONT)
		{
			AttackedList.Clear();
			
			Card c = field.GetCardAt(fieldPositions.FRONT_GUARD_LEFT);
			if(c != null) AttackedList.Add(c);
			
			c = field.GetCardAt(fieldPositions.FRONT_GUARD_RIGHT);
			if(c != null) AttackedList.Add(c);
			
			c = field.GetCardAt(fieldPositions.VANGUARD_CIRCLE);
			if(c != null) AttackedList.Add(c);
			
			CardToAttack = AttackedList[0];
			CurAttackedListIndex = 0;
			TargetCard(CardToAttack);
			
			CardAttacking = enemyField.GetCardAt((EnemyFieldPosition)other1);
			bShowAttackPowerWindow = true;
			bShowDefensePowerWindow = true;
			
			BeginGuardPhase();
			
			gamePhase = GamePhase.GUARD;			
		}
		else if(_gameAction == GameAction.FROM_DAMAGE_TO_DROP)
		{
			Card c = enemyField.GetDamageAtIndex(other1);
			enemyField.RemoveFromDamage(c);
			enemyField.AddToDropZone(c, false);
		}
		else if(_gameAction == GameAction.FROM_DAMAGE_TO_SOUL)
		{
			Card tempCard = enemyField.GetDamageAtIndex(other1);
			enemyField.RemoveFromDamage(tempCard);
			enemyField.AddToSoul(tempCard);
			tempCard.TurnUp();
			tempCard.SetRotation(0,0,0);
			Vector3 newPosition = EnemyFieldInfo.GetPosition((int)EnemyFieldPosition.VANGUARD) + new Vector3(0.0f, -0.002f, 0.0f);
			tempCard.GoTo (newPosition.x, newPosition.y, newPosition.z);
		}
		else if(_gameAction == GameAction.ADD_TO_GUARDZONE)
		{
			Card tempCard = enemyHand.RemoveFromHand();
			Data.FillCardWithData(tempCard, _cardID);
			guardZone.AddToGuardZone(tempCard, false);
			CardToAttack.AddExtraShield(tempCard.shield);
		}
		else if(_gameAction == GameAction.FROM_SOUL_TO_GC)
		{
			Card tempCard = enemyField.GetCardFromSoulByID(_cardID);
			enemyField.RemoveFromSoul(tempCard);
			guardZone.AddToGuardZone(tempCard, false);
			CardToAttack.AddExtraShield(tempCard.shield);			
		}
		else if(_gameAction == GameAction.END_ATTACK)
		{
			CardSelector.transform.position = new Vector3(0.0f, 100.0f, 0.0f);
			bShowAttackPowerWindow = false;
			bShowDefensePowerWindow = false;
			bAttacking = false;
			guardZone.CleanGuardZone(enemyField);
			bDoAttackOnce = true;
			bBlockGuardEndBattle = false;
		}
		else if(_gameAction == GameAction.ADD_TO_DAMAGEZONE)
		{
			Card tmpCard = enemyDeck.DrawCard();
			Data.FillCardWithData(tmpCard, _cardID);
			enemyField.AddToDamageZone(tmpCard);
		}
		else if(_gameAction == GameAction.SURRENDER)
		{
			bGameEnded = true;
			bSurrender = false;
			bOpponentSurrender = true;	
		}
		else if(_gameAction == GameAction.FROM_DAMAGE_TO_DECK)
		{
			Card c = enemyField.GetDamageAtIndex(other1);
			enemyField.RemoveFromDamage(c);
			enemyDeck.AddCard(c);
			enemyDeck.SetDeckPosition();
			//c.TurnUp();
		}
		else if(_gameAction == GameAction.END_TURN)
		{
			bBlockInterceptUntilEndTurn = false;
			
			enemyField.ResetPowers();
			enemyField.ResetTurnPowers();
			field.ResetPowers();
			field.ResetTurnPowers();
			gamePhase = GamePhase.DRAW;	
			field.DoStandPhase();
			SendPacket(GameAction.STAND_ALL_UNITS);
			numTurn++;
		}
		else if(_gameAction == GameAction.FROM_BIND_TO_HAND)
		{
			Card c = enemyField.GetCardFromBindByID(_cardID);
			if(c != null)
			{
				enemyField.RemoveFromBindZone(c);
				enemyHand.AddToHand(c);
			}
		}
		else if(_gameAction == GameAction.POWER_INCREASE)
		{
			enemyField.GetCardAt((EnemyFieldPosition)other1).IncreasePower(other2);
		}
		else if(_gameAction == GameAction.CAN_BE_RETIRED)
		{
			if(other2 == 0)
			{
				enemyField.GetCardAt((EnemyFieldPosition)other1).bCanBeRetireByEffects = false;
			}
			else
			{
				enemyField.GetCardAt((EnemyFieldPosition)other1).bCanBeRetireByEffects = true;
			}

		}
		else if(_gameAction == GameAction.FLIPDOWN)
		{
			Card c = enemyField.GetDamageAtIndex(other1);
			if(c != null)
			{
				c.TurnDown();	
			}
		}
		else if(_gameAction == GameAction.FLIPUP)
		{
			Card c = enemyField.GetDamageAtIndex(other1);
			if(c != null)
			{
				c.TurnUp();	
			}
		}
		else if(_gameAction == GameAction.INCREASE_POWER_END_TURN)
		{
			enemyField.GetCardAt((EnemyFieldPosition)other1).IncreasePowerUntilEndTurn(other2);	
		}
		else if(_gameAction == GameAction.INCREASE_CRITICAL_END_TURN)
		{
			enemyField.GetCardAt((EnemyFieldPosition)other1).IncreaseCriticalUntilEndTurn(other2);	
		}
		else if(_gameAction == GameAction.STAND_ALL_UNITS)
		{
			//enemyField.StandAllUnits();
			enemyField.DoStandPhase();
		}
		else if(_gameAction == GameAction.SEND_TO_DROPZONE)
		{
			enemyField.AddToDropZone(enemyField.GetCardAt((EnemyFieldPosition)other1), true);	
			enemyField.ClearZone((EnemyFieldPosition)other1);
		}
		else if(_gameAction == GameAction.SELECT_ANIM_DAMAGE)
		{
			enemyField.GetDamageAtIndex(other1).DoSelectAnim();	
		}
		else if(_gameAction == GameAction.DRIVE_CHECK)
		{
			if(field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).hasTwinDrive())
			{
				bTwinDrive = true;	
			}
			else 
			{
				bTwinDrive = false;	
			}
			DriveCheck();
		}
		else if(_gameAction == GameAction.PUT_CARD_ON_DRIVEZONE)
		{
			DriveCard = enemyDeck.DrawCard();
			if(DriveCard != null)
			{
				Data.FillCardWithData(DriveCard, _cardID);
				DriveCard.GetGameObject().transform.position = EnemyFieldInfo.GetPosition((int)EnemyFieldPosition.DRIVE);
				DriveCard.GetGameObject().transform.eulerAngles = EnemyFieldInfo.GetDriveRotation();
				DriveCard.TurnUp();
			}
		}
		else if(_gameAction == GameAction.SEND_DRIVE_TO_HAND)
		{
			if(DriveCard != null)
			{
				enemyHand.AddToHand(DriveCard);
				DriveCard = null;
			}
		}
		else if(_gameAction == GameAction.END_DRIVECHECK)
		{
			for(int i = 0; i < AttackedList.Count - 1; i++)
			{
				ResolveBattle(AttackedList[i]);
			}
					
			ResolveLastBattle(AttackedList[AttackedList.Count - 1]);
		}
		else if(_gameAction == GameAction.STAND_UNIT)
		{
			enemyField.GetCardAt((EnemyFieldPosition)other1).StandEnemy();	
		}
		else if(_gameAction == GameAction.REST_ENEMY_UNIT)
		{
			fieldPositions p = Util.TransformToPlayerField((fieldPositions)other1);
			Card c = field.GetCardAt(p);
			if(c != null)
			{
				c.Rest();	
			}
		}
		else if(_gameAction == GameAction.CRITICAL_INCREASE)
		{
			enemyField.GetCardAt((EnemyFieldPosition)other1).IncreaseCritical(other2);	
		}
		else if(_gameAction == GameAction.END_BATTLE)
		{
			Card temp = field.GetCardAt(Util.TransformToPlayerField((fieldPositions)(other1)));
			temp.ResetPower();
			temp.IsBoostedBy = null;
			field.CheckAbilitiesBind(CardState.BindZone_EndBattle);
			temp.CheckAbilities(CardState.EndBattle);
			field.CheckAbilitiesExcept(temp.pos, CardState.EndBattle_NotMe, temp);
			bBlockGuardEndBattle = false;
			bMinGuardGradeBlocked = 0;
			bMaxGuardGradeBlocked = 99;
			bDoPerfectGuardPerBattle = false;
			bBlockInterceptUntilEndBattle = false;
			CardToAttack.ResetPower();
			field.CheckAbilities(CardState.ClearEndBattleVariables);
		}
		else if(_gameAction == GameAction.FROM_DROP_TO_DECK)
		{
			DD_Card = enemyField.GetDropByID(_cardID);
			Vector3 newPos = EnemyFieldInfo.GetPosition((int)EnemyFieldPosition.DECK);
			DD_Card.GoTo(newPos.x, newPos.z);
		}
		else if(_gameAction == GameAction.HEAL_TRIGGER)
		{
			enemyField.AddToDropZone(enemyField.RemoveFromDamage(), false);	
		}
		else if(_gameAction == GameAction.ADD_CARD_TO_ABILITYSTACK)
		{
			//Description: When an enemy ability is resolved during your turn. The enemy effect
			//will be added to the Stack Ability and it will be performed like any normal ability does.
			//The game will be paused for current player and enemy will take the control.
			fieldPositions p = Util.TransformToPlayerField((fieldPositions)other1);
			EnemyTurnStackedCards.Add(field.GetCardAt(p));
		}
		else if(_gameAction == GameAction.CLEAR_ZONE)
		{
			enemyField.ClearZone((EnemyFieldPosition)other1);	
		}
		else if(_gameAction == GameAction.INTERCEPT)
		{
			Card c = enemyField.GetCardAt((EnemyFieldPosition)other1);
			guardZone.AddToGuardZone(enemyField.GetCardAt((EnemyFieldPosition)other1), true);	
			CardToAttack.AddExtraShield(c.shield);
		}
		else if(_gameAction == GameAction.SHOW_CARD)
		{
			ShowCardEffect(Resources.Load ("CardHelper/" + Data.GetCardInfo(_cardID).clan + "/" + Data.GetImageName(_cardID)) as Texture2D);
		}
		else if(_gameAction == GameAction.FLIPDAMAGE)
		{
			enemyField.FlipDamageZoneCard();	
		}
		else if(_gameAction == GameAction.UNFLIPDAMAGE)
		{
			enemyField.UnflipDamageZoneCard();	
		}
		else if(_gameAction == GameAction.ENEMY_REMOVE_FROM_GUARDIAN)
		{
			guardZone.Remove(guardZone.cards[other1], true);	
		}
		else if(_gameAction == GameAction.SEND_TO_DROPZONE_ALLY)
		{
			fieldPositions tmpPos = (fieldPositions)other1;
			Card card = field.GetCardAt(Util.TransformToPlayerField(tmpPos));
			
			Debug.Log("Send to drop zone ally event");
			if(!card.IsVanguard())
			{
				Debug.Log("Sent to dropzone: " + card.cardID);
				card.CheckAbilities(CardState.DropZoneFromRC);	
			}
			
			field.AddToDropZone(field.GetCardAt(Util.TransformToPlayerField(tmpPos)));
			field.ClearZone(Util.TransformToPlayerField(tmpPos));
		}
		else if(_gameAction == GameAction.SEND_TO_BINDZONE_ALLY)
		{
			fieldPositions tmpPos = (fieldPositions)other1;
			Card card = field.GetCardAt(Util.TransformToPlayerField(tmpPos));
			field.AddToBindZone(field.GetCardAt(Util.TransformToPlayerField(tmpPos)));
			field.ClearZone(Util.TransformToPlayerField(tmpPos));
			card.BindAnim();
		}
		else if(_gameAction == GameAction.ENEMY_DISCARD)
		{
			Card tmpCard = enemyHand.RemoveFromHand();	
			Data.FillCardWithData(tmpCard, _cardID);
			enemyField.AddToDropZone(tmpCard, false);
			tmpCard.TurnUp();
		}
		else if(_gameAction == GameAction.RETURN_FROM_HAND_TO_DECK)
		{
			Card tmpCard = enemyHand.RemoveFromHand();
			enemyDeck.AddCard(tmpCard);
			enemyDeck.SetDeckPosition();
		}
		else if(_gameAction == GameAction.FROM_HAND_TO_DECK)
		{
			Card tmpCard = enemyHand.RemoveFromHand(playerHand.Size() - other1 - 1);
			enemyDeck.AddCard(tmpCard);
			enemyDeck.SetDeckPosition();
		}
		else if(_gameAction == GameAction.DRAW_FROM_DECK_AND_SHOW)
		{
			Card tmpCard = enemyDeck.DrawCard();
			enemyHand.AddToHand(tmpCard);
			Data.FillCardWithData(tmpCard, _cardID);
			tmpCard.TurnUp();
			ShowingCardAtHandTimer = SHOW_CARD_FROM_HAND_DELAY;
			bIsCardAtHandShowing = true;
		}
		else if(_gameAction == GameAction.FROM_DAMAGE_TO_HAND)
		{	
			Card c = enemyField.GetDamageAtIndex(other1);
			enemyField.RemoveFromDamage(c);
			enemyHand.AddToHand(c);
		}
		else if(_gameAction == GameAction.CARDSTATE_FROM_BIND_TO_HAND_END_TURN)
		{
			Card c = playerHand.GetCardAtIndex(playerHand.Size() - other1 - 1);
			if(c != null)
			{
				Debug.Log ("Adding Ability to " + c.cardID);
				
				c.unitAbilities.AddExternAuto(delegate(CardState cs, Card effectOwner) {
					if(cs == CardState.EnemyEndTurn)
					{
						c.unitAbilities.FromBindToHand(c);
					}
				});
			}
		}
		else if(_gameAction == GameAction.FROM_HAND_TO_DAMAGE)
		{
			Card c = enemyHand.GetCardAtIndex(enemyHand.Size() - other1 - 1);
			Data.FillCardWithData(c, _cardID);
			enemyHand.RemoveFromHand(c);
			enemyField.AddToDamageZone(c);
		}
		else if(_gameAction == GameAction.SHOW_CARD_HAND)
		{
			Card tmpCard = enemyHand.GetCardAtIndex(enemyHand.Size() - other1 - 1);
			Data.FillCardWithData(tmpCard, _cardID);
			tmpCard.TurnUp();
			ShowingCardAtHandTimer = SHOW_CARD_FROM_HAND_DELAY;
			bIsCardAtHandShowing = true;
		}
		else if(_gameAction == GameAction.ATTACK_HITS)
		{	
			CardAttacking.CheckAbilities(CardState.AttackHits, CardAttacking);
			field.CheckAbilitiesExcept(CardAttacking.pos, CardState.AttackHits_NotMe, CardAttacking);
		}
		else if(_gameAction == GameAction.ADD_POWER_TO_GUARDZONE)
		{
			guardZone.AddExtraPower(other1);	
		}
		else if(_gameAction == GameAction.RETURN_FROM_FIELD_TO_DECK)
		{
			Card tempCard = enemyField.GetCardAt((EnemyFieldPosition)other1);
			enemyField.RemoveFrom((EnemyFieldPosition)other1);
			tempCard.SetRotation(0,0,0);
			enemyDeck.ReturnToDeck(tempCard);
			ReturnToDeckCard = tempCard;
		}
		else if(_gameAction == GameAction.FROM_FIELD_TO_DAMAGE)
		{
			Card tempCard = enemyField.GetCardAt((EnemyFieldPosition)other1);
			enemyField.RemoveFrom((EnemyFieldPosition)other1);
			enemyField.AddToDamageZone(tempCard);
		}
		else if(_gameAction == GameAction.SOULCHARGE)
		{
			Card tempCard = enemyDeck.DrawCard();
			Data.FillCardWithData(tempCard, _cardID);
			enemyField.AddToSoul(tempCard);
			tempCard.TurnUp();
			tempCard.SetRotation(0,0,0);
			//Vector3 newPosition = fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + new Vector3(0.0f, -0.001f, 0.0f);
			Vector3 newPosition = EnemyFieldInfo.GetPosition((int)EnemyFieldPosition.VANGUARD) + new Vector3(0.0f, -0.002f, 0.0f);
			tempCard.GoTo (newPosition.x, newPosition.y, newPosition.z);
			
		}
		else if(_gameAction == GameAction.SOULBLAST)
		{
			EnemySoulBlastQueue.Add(enemyField.GetCardFromSoulByID(_cardID));	
		}
		else if(_gameAction == GameAction.PERSISTENT_POWER)
		{
			fieldPositions pos = (fieldPositions)other1;
			
			Card temp = enemyField.GetCardAt(Util.TranformToEnemyPosition(pos));
			if(temp != null)
			{
				temp.SetPersistentPower(other2);		
			}
		}
		else if(_gameAction == GameAction.RIDE_FROM_FIELD)
		{
			Card c = enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition((fieldPositions)other1));
			fieldPositions p = c.pos;
			enemyField.RemoveFrom(Util.TransformToEquivalentEnemyPosition(c.pos));
			enemyField.Ride(c);
			SendPacket (GameAction.RIDE_FROM_FIELD_OPP, p);	
		}
		else if(_gameAction == GameAction.PERSISTENT_CRITICAL)
		{
			fieldPositions pos = (fieldPositions)other1;
			
			
			Card temp = enemyField.GetCardAt(Util.TranformToEnemyPosition(pos));
			if(temp != null)
			{
				temp.SetPersistentCritical(other2);		
			}
		}
		else if(_gameAction == GameAction.HEAL_TRIGGER_SELECT)
		{
			Card c = enemyField.RemoveFromDamage(other1);
			enemyField.AddToDropZone(c, false);
		}
		else if(_gameAction == GameAction.PLAY_CARD_FROM_DECK)
		{
			Card tempCard = enemyDeck.DrawCard();
			Data.FillCardWithData(tempCard, _cardID);
			tempCard.TurnUp();
			enemyField.Call(tempCard, (EnemyFieldPosition)other1);
		}
		else if(_gameAction == GameAction.FROM_DECK_TO_DAMAGE)
		{
			Card c = enemyDeck.DrawCard();
			Data.FillCardWithData(c, _cardID);
			enemyField.AddToDamageZone(c);
			c.TurnDown();
		}
		else if(_gameAction == GameAction.FROM_DECK_TO_DAMAGE_FACEUP)
		{
			Card c = enemyDeck.DrawCard();
			Data.FillCardWithData(c, _cardID);
			enemyField.AddToDamageZone(c);
			c.TurnUp();
		}
		else if(_gameAction == GameAction.FROM_FIELD_TO_SOUL)
		{
			Card tempCard = enemyField.GetCardAt((EnemyFieldPosition)other1);
			
			enemyField.MoveToSoul(Util.TransformToEquivalentEnemyPosition(tempCard.pos));
			enemyField.AddToSoul(tempCard);
			enemyField.RemoveFrom(Util.TransformToEquivalentEnemyPosition(tempCard.pos));
		}
		else if(_gameAction == GameAction.PLAY_CARD_FROM_DROP)
		{
			
			Card tempCard = enemyField.GetDropByID(_cardID);
			if(tempCard != null)
			{
				enemyField.RemoveFromDropZone(tempCard);
				enemyField.Call(tempCard, Util.TranformToEnemyPosition((fieldPositions)other1));
			}
			else
			{
			}
				
		}
		else if(_gameAction == GameAction.CHECK_CARD_ABILITY)
		{
			Card c = EnemyTurnStackedCards[0];
			EnemyTurnStackedCards.RemoveAt(0);
			EffectOnGoingEnemyTurn = true;
			c.CheckAbilities((CardState)other1);
		}
		else if(_gameAction == GameAction.FIELD_FROM_DAMAGE)
		{
			Card c = enemyField.GetDamageAtIndex(other2);
			enemyField.RemoveFromDamage(c);
			enemyField.Call(c, Util.TranformToEnemyPosition((fieldPositions)other1));
		}
		else if(_gameAction == GameAction.BIND_HAND)
		{
			Card c = playerHand.GetCardAtIndex(playerHand.Size() - other1 - 1);
			if(c != null)
			{
				BindHand(c);	
			}
		}
		else if(_gameAction == GameAction.RIDE_FROM_DECK)
		{
			Card tempCard = enemyDeck.DrawCard();
			Data.FillCardWithData(tempCard, _cardID);
			enemyField.Ride(tempCard);
		}
		else if(_gameAction == GameAction.RETURN_CARD_FROM_HAND_TO_DECK)
		{
			Card tempCard = enemyHand.RemoveFromHand();
			enemyDeck.AddCard(tempCard);
			enemyDeck.SetDeckPosition();
		}
		else if(_gameAction == GameAction.PERFECT_GUARD)
		{	
			guardZone.ActivePerfectGuard();
			CardToAttack.PerfectGuard();
		}
		else if(_gameAction == GameAction.MOVE_ALLY)
		{
			EnemyFieldPosition pos = Util.TranformToEnemyPosition((fieldPositions)other1);
			Card temp = enemyField.GetCardAt(pos);
			enemyField.Move(temp);	
		}
		else if(_gameAction == GameAction.NEGATE_ENEMY_STAND)
		{
			fieldPositions pos = Util.TransformToPlayerField((fieldPositions)other1);
			Card temp = field.GetCardAt(pos);
			temp.NegateStand();
		}
		else if(_gameAction == GameAction.ALLY_DISCARD)
		{
			bEffectOnGoing = true;
			GameChat.AddChatMessage("ADMIN", "ALLY_DISCARD");
			bDiscard = true;
			_GameHelper.CustomMessage("Choose a card from your hand and discard it.");
		}
		else if(_gameAction == GameAction.RIDE_FROM_DROP)
		{
			Card tempCard = enemyField.SearchInDropZone(_cardID);	
			enemyField.RemoveFromDropZone(tempCard);
			enemyField.Ride(tempCard);
		}
		else if(_gameAction == GameAction.FROM_DROP_TO_SOUL)
		{
			Card tmp = enemyField.SearchInDropZone(_cardID);
			if(tmp != null)
			{
				enemyField.MoveToSoul(tmp);
				enemyField.RemoveFromDropZone(tmp);
			}
		}
		else if(_gameAction == GameAction.FROM_DECK_TO_DROP)
		{
			Card tmp = enemyDeck.DrawCard();
			Data.FillCardWithData(tmp, _cardID);
			tmp.TurnUp();
			tmp.SetRotation(0,0,0);
			enemyField.AddToDropZone(tmp, false);
		}
		else if(_gameAction == GameAction.BLOCK_INTERCEPT_UNTIL_ENDTURN)
		{
			bBlockInterceptUntilEndTurn = true;	
		}
		else if(_gameAction == GameAction.BLOCK_INTERCEPT_UNTIL_ENDBATTLE)
		{
			bBlockInterceptUntilEndBattle = true;	
		}
		else if(_gameAction == GameAction.PLAY_CARD_FROM_DRIVE)
		{
			enemyField.Call(DriveCard, (EnemyFieldPosition)other1);
			DriveCard = null;
		}
		else if(_gameAction == GameAction.RETURN_FROM_FIELD_TO_HAND)
		{
			fieldPositions pos = (fieldPositions)other1;
			EnemyFieldPosition enemyPos = Util.TranformToEnemyPosition(pos);
			Card c = enemyField.GetCardAt(enemyPos);
			enemyField.RemoveFrom(enemyPos);
			enemyHand.AddToHand(c);
		}
		else if(_gameAction == GameAction.ATTACK_NOT_HIT)
		{
			CardAttacking.CheckAbilities(CardState.AttackNotHit);
			field.CheckAbilitiesExcept(CardAttacking.pos, CardState.AttackNotHit_NotMe);	
			field.CheckAbilitiesBind(CardState.BindZone_AttackNotHit);
		}
		else if(_gameAction == GameAction.INCREASE_ENEMY_POWER_BATTLE)
		{
			fieldPositions p = Util.TransformToPlayerField((fieldPositions)other1);
			Card c = field.GetCardAt(p);
			if(c != null)
			{
				c.IncreasePower(other2);
				SendPacket(GameAction.POWER_INCREASE, c.pos, other2);
			}
		}
		else if(_gameAction == GameAction.INCREASE_ENEMY_POWER_TURN)
		{
			fieldPositions p = Util.TransformToPlayerField((fieldPositions)other1);
			Card c = field.GetCardAt(p);
			if(c != null)
			{
				c.IncreasePowerUntilEndTurn(other2);
				SendPacket(GameAction.INCREASE_POWER_END_TURN, c.pos, other2);
			}
		}
		else if(_gameAction == GameAction.BOOST)
		{
			Card c = enemyField.GetCardAt(Util.TranformToEnemyPosition((fieldPositions)other1));
			if(c != null)
			{
				fieldPositions p = fieldPositions.DECK_ZONE;
				if(c.pos == fieldPositions.ENEMY_FRONT_LEFT)
				{
					p = fieldPositions.ENEMY_REAR_LEFT;	
				}
				
				if(c.pos == fieldPositions.ENEMY_FRONT_RIGHT)
				{
					p = fieldPositions.ENEMY_REAR_RIGHT;	
				}
				
				if(c.pos == fieldPositions.ENEMY_VANGUARD)
				{
					p = fieldPositions.ENEMY_REAR_CENTER;	
				}
				
				Card d = enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(d != null)
				{
					c.IsBoostedBy = d;	
				}
			}
		}
		else if(_gameAction == GameAction.REQUEST_BOOT)
		{
			bEffectOnGoing = true;
			GameChat.AddChatMessage("ADMIN", "REQUEST_BOOT");
			if(CanBeBoosted(CardAttacking))
			{
				bBoostWindow = true;
			}
			else
			{
				BoostUnit();	
			}
		}
		else if(_gameAction == GameAction.BEGIN_GUARD)
		{
			BeginGuardPhase();
			
			gamePhase = GamePhase.GUARD;	
		}
		else if(_gameAction == GameAction.FROM_HAND_TO_SOUL)
		{
			Card c = enemyHand.GetCardAtIndex(other1);
			Data.FillCardWithData(c, _cardID);
			enemyHand.RemoveFromHand(c);
			enemyField.AddToBindZone(c);
			c.TurnUp();
			c.BindAnim();
			/*
			FromHandToSoulCard = c;
			Vector3 newPos = EnemyFieldInfo.GetPosition((int)EnemyFieldPosition.VANGUARD);
			c.SetRotation(0,0,0);
			c.GoTo(newPos.x, newPos.y, newPos.z);
			c.TurnUp();
			*/
		}
		else if(_gameAction == GameAction.FROM_HAND_TO_SOUL)
		{
			Card c = enemyHand.GetCardAtIndex(other1);
			Data.FillCardWithData(c, _cardID);
			FromHandToSoulCard = c;
			Vector3 newPos = EnemyFieldInfo.GetPosition((int)EnemyFieldPosition.VANGUARD);
			c.SetRotation(0,0,0);
			c.GoTo(newPos.x, newPos.y, newPos.z);
			c.TurnUp();
		}
		else if(_gameAction == GameAction.REVEAL_TOP_CARD)
		{
			Card c = enemyDeck.TopCard();
			Data.FillCardWithData(c, _cardID);
			c.TurnUp();
		}
		else if(_gameAction == GameAction.HIDE_TOP_CARD)
		{
			enemyDeck.TopCard().TurnDown();	
		}
		else if(_gameAction == GameAction.TARGET_CARD)
		{
			Card c = enemyField.GetCardAt(Util.TranformToEnemyPosition((fieldPositions)other1));
			c.IsTargetted(true);
			CardToAttack = c;
		}
		else if(_gameAction == GameAction.UNTARGET_CARD)
		{
			Card c = enemyField.GetCardAt(Util.TranformToEnemyPosition((fieldPositions)other1));
			if(c != null)
			{
				c.IsTargetted(false);
			}
		}
		else if(_gameAction == GameAction.RIDE_FROM_SOUL)
		{
			Card c = enemyField.GetCardFromSoulByID(_cardID);
			if(c != null)
			{
				enemyField.RemoveFromSoul(c);
				enemyField.Ride(c);
			}
		}
		else if(_gameAction == GameAction.SELECT_ANIM_FIELD)
		{
			Card c = enemyField.GetCardAt(Util.TranformToEnemyPosition((fieldPositions)other1));
			if(c != null)
			{
				c.DoSelectAnim();	
			}
		}
		else if(_gameAction == GameAction.OPPONENT_CALL_FROM_TOP_DECK)
		{
			bEffectOnGoing = true;

			dummyUnitObject.SetBool(1);
			dummyUnitObject.GetDeck().ViewDeck(1, SearchMode.TOP_CARD, other1, delegate(Game2DCard c) {
				return c._CardInfo.grade >= other2 && c._CardInfo.grade <= other3;
			});
		}
		else if(_gameAction == GameAction.EVENT_END_BATTLE)
		{
			field.CheckAbilitiesEnemyTurn(CardState.EnemyBeginRide);
		}	
		else if(_gameAction == GameAction.EVENT_BEGIN_RIDEPHASE)
		{
			field.CheckAbilitiesEnemyTurn(CardState.EnemyEndBattle);
		}
		else if(_gameAction == GameAction.EVENT_BEGIN_ENDTURN)
		{
			//field.CheckAbilities(CardState.EnemyEndTurn);	
			field.CheckBindZoneAbilities(CardState.EnemyEndTurn);
			bEndEvent = true;
			//bEnemyWaiting = true;
		}
		else if(_gameAction == GameAction.DISPLAY_WINDOW)
		{
			bOpponentWindow = true;
			bOpponentWindowMessage = str1;
			bEffectOnGoing = true;
			GameChat.AddChatMessage("ADMIN", "DISPLAY_WINDOW");
		}
		else if(_gameAction == GameAction.PLAYER_ACCEPT)
		{
			LastOpponentWindow = OPPWINDOW.ACCEPT;
		}
		else if(_gameAction == GameAction.PLAYER_DENIED)
		{
			LastOpponentWindow = OPPWINDOW.DENIED;
		}
		else if(_gameAction == GameAction.BLOCK_NORMALRIDE)
		{
			bRideThisTurn = false;
			bEffectOnGoing = false;
		}
		else if(_gameAction == GameAction.RIDE_FROM_FIELD_OPP)
		{
			//Opponent performs a Ride on my field.
			Card c = field.GetCardAt(Util.TransformToPlayerField((fieldPositions)other1));
			if(c != null)
			{
				field.RemoveFrom(c.pos);
				field.Ride (c, false);
			}
		}
		else if(_gameAction == GameAction.OPPONENT_RIDE_FROM_SOUL)
		{
			field.ViewSoul(1);
			_OppRideFromSoulEvent = true;
		}
		else if(_gameAction == GameAction.OPPONENT_DRAW)
		{
			playerHand.AddToHand(playerDeck.DrawCard());
			SendPacket(GameAction.DRAW_FROM_DECK, 1);	
			bEffectOnGoing = false;
			bEndEvent = true;
		}
		else if(_gameAction == GameAction.END_EVENT)
		{
			//bEffectOnGoing = false;
			if(ownerCardCallEvent != null)
			{
				ownerCardCallEvent.unitAbilities.EndEvent(other1);
				ownerCardCallEvent = null;
			}
			else
			{
				bEffectOnGoing = false;	
			}
		}
		else if(_gameAction == GameAction.OPPONENT_RETIRE_UNIT)
		{
			_OppRetireUnitEvent = true;	
			_GameHelper.CustomMessage("Choose one of your rear-guards, and retire it");
			GameChat.SetTab(ChatTab.HELP);
		}
		else if(_gameAction == GameAction.MESSAGE)
		{
			GameChat.AddHelpMessage(str1);	
		}
	}
	#endregion

	public void WinByCardEffect()
	{
		bGameEnded = true;
		bPauseGameplay = false;
		bWinByCardEffect = true;
		bLoseByCardEffect = false;
		SendPacket(GameAction.LOSE_BY_CARD_EFFECT);
	}

	void BeginGuardPhase()
	{
		for(int i = 0; i < playerHand.Size(); i++)
		{
			Card c = playerHand.GetCardAtIndex(i);
			if(c != null && (c.grade > field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).grade || (c.shield == 0 && !c.bSentinel)))
			{
				c.SetOpacity(false);
			}
		}
		
		CardToAttack.CheckAbilities(CardState.BeingAttacked);	
	}

	bool _OppBindHandFacedownReturnEndTurn_Aux1 = false;

	private void UpdateDiscardEvent()
	{
		if(bDiscard)
		{
			if(Input.GetMouseButtonUp(0))
			{
				Card tmp = playerHand.GetCurrentCardObject();
				if(tmp != null && tmp._HandleMouse.mouseOn && tmp._Coord == CardCoord.HAND)
				{
					playerHand.RemoveFromHand(playerHand.GetCurrentCard());
					field.AddToDropZone(tmp);
					SendPacket (GameAction.ENEMY_DISCARD, tmp.cardID);	
					bDiscard = false;
					bEffectOnGoing = false;
					_GameHelper.DisableCustomMessage();
					//SendConfirmation();
					//WaitForOponnent();
					SendPacket(GameAction.END_EVENT, lastIDRegistered);
				}
			}
		}

		if(_OppBindHandFacedownReturnEndTurn)
		{
			if(!_OppBindHandFacedownReturnEndTurn_Aux1)
			{
				if(Input.GetMouseButtonUp(0))
				{
					Card tmp = playerHand.GetCurrentCardObject();
					if(tmp != null && tmp._HandleMouse.mouseOn && tmp._Coord == CardCoord.HAND)
					{
						dummyUnitObject.FromHandToBind(tmp, playerHand.GetCurrentCard(), true);
						_OppBindHandFacedownReturnEndTurn_Aux1 = true;
						tmp.unitAbilities.AddUnitObject(new _OppBindHandFacedownReturnEndTurnEXT());
					}
				}
			}
			else
			{
				dummyUnitObject.FromHandToBindUpdate(delegate {
					_GameHelper.DisableCustomMessage();
					SendPacket(GameAction.END_EVENT, lastIDRegistered);
					bEffectOnGoing = false; //??
					_OppBindHandFacedownReturnEndTurn_Aux1 = false;
					_OppBindHandFacedownReturnEndTurn = false;
				});
			}
		}
	}
	
	private void HealTrigger()
	{
		if((field.GetDamage() - 1) >= enemyField.GetDamage())
		{
			field.AddToDropZone(field.RemoveFromDamage());	
			SendPacket(GameAction.HEAL_TRIGGER);
		}
	}
	
	private void ShowOnScreen(Card card)
	{
		ShowCardEffect(Resources.Load ("CardHelper/" + Data.GetCardInfo(card.cardID).clan + "/" + Data.GetImageName(card.cardID)) as Texture2D);
		SendPacket(GameAction.SHOW_CARD, card.cardID);
	}
	
	public void EnemyRideFromField(Card c, bool bActiveAutoEffects)
	{
		fieldPositions p = c.pos;
		enemyField.RemoveFrom(Util.TransformToEquivalentEnemyPosition(c.pos));
		SendPacket (GameAction.RIDE_FROM_FIELD_OPP, p);
		enemyField.Ride(c);
	}
	
	public void RideFromField(Card c, bool bActiveAutoEffects)
	{
		fieldPositions p = c.pos;
		field.RemoveFrom(c.pos);
		SendPacket (GameAction.RIDE_FROM_FIELD, p);
		field.Ride(c);
	}

	bool bDamageWithoutBattle = false;

	public void ForceDamageCheck(int n = 1)
	{
		num_damage = n;
		bDamageWithoutBattle = true;
		DamageCheck();
	}

	public bool DamageCheck()
	{
		if(num_damage > 0)
		{
			num_damage--;
				
			Card tmpCard = playerDeck.DrawCard();
			field.AddToDamageZone(tmpCard);	
			SendPacket(GameAction.ADD_TO_DAMAGEZONE, tmpCard.cardID);
				
			if(tmpCard.IsTrigger() && !bBlockTriggerEffects && (field.GetDamage() < 6 || (field.GetDamage() == 6 && tmpCard.GetTriggerType() == TriggerIcon.HEAL)))
			{
				ShowOnScreen(tmpCard);
					
				lastDamageCard = tmpCard;
				bDamageCheckTrigger = true;
				bGivePowerEffect = true;
				bTriggerEffect = false;
				bEffectOnGoing = true;
				GameChat.AddChatMessage("ADMIN", "DamageCheck()");
			}
			else
			{
				DamageCheck();
			}
			return true;
		}
		else
		{
			if(bDamageWithoutBattle)
			{
				bDamageWithoutBattle = false;
				bEndEvent = true;
			}
			else
			{
				EndBattle();
				LastAttackedListIndex = -1;
			}
		}
		
		return false;
	}
	
	private void EndBattle(bool bAttackHits = true)
	{
		SendConfirmation();
		if(bAttackHits)
		{
			SendPacket(GameAction.ATTACK_HITS);
		}
		
		CardToAttack.CheckAbilities(CardState.EnemyEndBattle);
		
		gamePhase = GamePhase.ENEMY_TURN;	
		CardAttacking.ResetPower();
		CardToAttack.ResetPower();
		CardAttacking.IsBoostedBy = null;
		SendPacket(GameAction.END_BATTLE, CardAttacking.pos);
		bDoPerfectGuardPerBattle = false;
		bBlockGuardEndBattle = false;
		bMinGuardGradeBlocked = 0;
		bMaxGuardGradeBlocked = 99;
		bBlockInterceptUntilEndBattle = false;
		bCanNormalGuard = true;
		bCanReceiveDamage = true;
		bBlockTriggerEffects = false;
		field.CheckAbilities(CardState.ClearEndBattleVariables);
	}
	
	private void EndGuardPhase()
	{
		//End the guard phase
		CardSelector.transform.position = new Vector3(0.0f, 100.0f, 0.0f);
		bShowAttackPowerWindow = false;
		bShowDefensePowerWindow = false;
		//CardToAttack = null;
		CardAttacking = null;
		//guardZone.CleanGuardZone(field);
	}
	
	//RPC interfaces, the function to send and receive information trough the network is the same for all actions
	//so to do more easily the call to this method we write a few interface methods.
	
	//This method is used when no card is needed and no others argumentos are needed. Just a GameAction
	public void SendAction(GameAction action)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, 0, (int)action, 0, 0, "", 0, Network.player);
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, 0, (int)action, 0, 0, "", 0);	
		}
	}
	
	public void SendPacket(GameAction action)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, 0, (int)action, 0, 0, "", 0, Network.player);
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, 0, (int)action, 0, 0, "", 0);
		}
	}

	public void SendPacket(GameAction action, int other1, int other2, int other3)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, 0, (int)action, other1, other2, "", other3, Network.player);	
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, 0, (int)action, other1, other2, "", other3);	
		}
	}
	
	public void SendPacket(GameAction action, CardIdentifier cardID)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, (int)cardID, (int)action, 0, 0, "", 0, Network.player);
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, (int)cardID, (int)action, 0, 0, "", 0);
		}
	}
	
	public void SendPacket(GameAction action, CardIdentifier cardID, fieldPositions pos)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, (int)cardID, (int)action, (int)pos, 0, "", 0, Network.player);	
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, (int)cardID, (int)action, (int)pos, 0, "", 0);	
		}
	}
	
	public void SendPacket(GameAction action, CardIdentifier cardID, int value)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, (int)cardID, (int)action, value, 0, "", 0, Network.player);	
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, (int)cardID, (int)action, value, 0, "", 0);	
		}
	}
	
	public void SendPacket(GameAction action, fieldPositions pos)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, 0, (int)action, (int)pos, 0, "", 0, Network.player);	
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, 0, (int)action, (int)pos, 0, "", 0);	
		}
	}
	
	public void SendPacket(GameAction action, fieldPositions pos, int power)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, 0, (int)action, (int)pos, power, "", 0, Network.player);	
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, 0, (int)action, (int)pos, power, "", 0);	
		}
	}
	
	public void SendPacket(GameAction action, int quantity)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, 0, (int)action, quantity, 0, "", 0, Network.player);
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, 0, (int)action, quantity, 0, "", 0);	
		}
	}
	
	public void SendPacket(GameAction action, string str)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, 0, (int)action, 0, 0, str, 0, Network.player);
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, 0, (int)action, 0, 0, str, 0);
		}
	}

	public void SendPacket(GameAction action, fieldPositions pos, int num, string str)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC("SendInformationToOpponent_Server", RPCMode.Server, 0, (int)action, (int)pos, num, str, 0, Network.player);	
		}
		else
		{
			networkView.RPC("SendInformationToOpponent", opponent, 0, (int)action, (int)pos, num, str, 0);	
		}
	}
	//Sometimes, the player will wait for the opponent for an specific action.
	//when this action is performed and finish, opponent send a confirmation to the player
	//so the player can continue playing.
	[RPC]
	void ConfirmAction()
	{
		bOponnentHasConfirmed = true;
	}

	[RPC]
	void ConfirmAction_Server(NetworkPlayer player)
	{

	}
	
	public void SendConfirmation()
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC ("ConfirmAction_Server", RPCMode.Server, Network.player);	
		}
		else
		{
			networkView.RPC ("ConfirmAction", opponent);	
		}
	}
	
	// Use this for initialization
	void Start () 
	{	
		_MainCamera = (Camera)gameObject.GetComponent("Camera");

		_SelectionListWindow = new SelectionListWindow(Screen.width / 2, Screen.height / 2 + 100);

		_AbilityManagerList = new SelectionListGenericWindow(Screen.width / 2, Screen.height / 2 + 100);

		_SelectionCardNameWindow = new SelectionCardNameWindow(Screen.width / 2 - 50, Screen.height / 2);
		_SelectionCardNameWindow.CreateCardList();
		_SelectionCardNameWindow.SetGame(this);

		_DecisionWindow = new DecisionWindow(Screen.width / 2, Screen.height / 2 + 100);
		_DecisionWindow.SetGame(this);

		_NotificationWindow = new NotificacionWindow(Screen.width / 2, Screen.height / 2 + 100);
		_NotificationWindow.SetGame(this);
		
		FromHandToBindList = new List<Card>();
		
		AttackedList = new List<Card>();
		
		UnitsCalled = new List<Card>();
		
		EnemySoulBlastQueue = new List<Card>();
		
		_PopupNumber = new PopupNumber();
		
		_MouseHelper = new MouseHelper(this);
		GameChat = new Chat();
		
		opponent = PlayerVariables.opponent;
		
		playerHand = new PlayerHand();
		enemyHand = new EnemyHand();
		
		field = new Field(this);
		enemyField = new EnemyField(this);
		guardZone = new GuardZone();
		guardZone.SetField(field);
		guardZone.SetEnemyField(enemyField);
		guardZone.SetGame(this);
		
		fieldInfo = new FieldInformation();
		EnemyFieldInfo = new EnemyFieldInformation();
		
		Data = new CardDataBase();
		List<CardInformation> tmpList = Data.GetAllCards();
		for(int i = 0; i < tmpList.Count; i++)
		{
			_SelectionCardNameWindow.AddNewNameToTheList(tmpList[i]);	
		}
		
		//camera = (CameraPosition)GameObject.FindGameObjectWithTag("MainCamera").GetComponent("CameraPosition");
		//camera.SetLocation(CameraLocation.Hand);
	
		LoadPlayerDeck();
		LoadEnemyDeck();
		
		gamePhase = GamePhase.CHOOSE_VANGUARD;
		
		bDrawing = true;
		bIsCardSelectedFromHand = false;
		bPlayerTurn = false;
		
		bDriveAnimation = false;
		bChooseTriggerEffects = false;
		DriveCard = null;
		
		//Texture showed above a card when this is selected for an action (An attack, for instance)
		CardSelector = GameObject.FindGameObjectWithTag("CardSelector");
		_CardMenuHelper = (CardHelpMenu)GameObject.FindGameObjectWithTag("CardMenuHelper").GetComponent("CardHelpMenu");
		_GameHelper = (GameHelper)GameObject.FindGameObjectWithTag("GameHelper").GetComponent("GameHelper");
		
		bPlayerTurn = PlayerVariables.bFirstTurn;
		
		//ActivePopUpQuestion(playerDeck.DrawCard());
		_CardMenu = new CardMenu(this);
		
		_AbilityManager = new AbilityManager(this);
		_AbilityManagerExt = new AbilityManagerExt();
		
		_GameHelper.SetChat(GameChat);
		_GameHelper.SetGame(this);
		
		EnemyTurnStackedCards = new List<Card>();

		dummyUnitObject = new UnitObject();
		dummyUnitObject.SetGame(this);

		stateDynamicText = new DynamicText();
	}
	
	private void AttackHandler()
	{
		if(num_damage <= 0)
			return;
			
	}
	
	private void PutSelectorOnCard(Card card)
	{
		if(card == null)
		{
			return;
		}
		
		card.IsTargetted(true);
		
		/*
		CardSelector.transform.position = card.GetGameObject().transform.position + new Vector3(0.0f, 0.01f, 0.0f);
		CardSelector.transform.eulerAngles = card.GetGameObject().transform.eulerAngles;
		*/
	}
	
	private void RemoveSelectorFromField()
	{
		CardSelector.transform.position = new Vector3(0.0f, -100.0f, 0.0f);
	}
	
	private void LoadPlayerDeck()
	{
		playerDeck = new Deck(this);
		//Retrieve information about the cards that the players has in their deck.
		LoadDeck();	
		//Retrieve the 50 cubes corresponding to the 50 player's cards.
		GameObject[]  go = GameObject.FindGameObjectsWithTag("PlayerCard");
		
		for(int i = 0; i < 50; i++)
		{
			//Attach a GameObject to each Card Object in the player deck.
			playerDeck.linkGameObjectToCard(go[i], (HandleMouse)go[i].GetComponent("HandleMouse"), i);	
		}
		//Set the gameobjects positions to fit in the deck zone.
		playerDeck.SetDeckPosition();
	}
	
	private void LoadEnemyDeck()
	{
		enemyDeck = new EnemyDeck();
		GameObject[] go = GameObject.FindGameObjectsWithTag("EnemyCard");
		for(int i = 0; i < 50; i++)
		{
			enemyDeck.AddCard(new Card(), false);			
			enemyDeck.linkGameObjectToCard(go[i], (HandleEnemyMouse)go[i].GetComponent("HandleEnemyMouse"), i);	
		}
		enemyDeck.SetDeckPosition();
	}

	public bool bIgnoreDriveToHand = false;
	public bool bPerformAdditionalDriveCheck = false;

	private void DriveCheckHandler()
	{
		if(bBlockDriveCheck)
		{
			return;	
		}
		
		if(bDriveAnimation && !bEffectOnGoing)
		{
			driveTime -= Time.deltaTime;
			if(driveTime <= 0)
			{
				//camera.SetLocation(CameraLocation.Front);
				bDriveAnimation = false;
				
				if(DriveCard != null && DriveCard.IsTrigger())
				{
					bChooseTriggerEffects = true;	
					bChooseAttack = true;
					bChooseEffect = false;
					_GameHelper.SetPowerIncrease();
					ShowOnScreen(DriveCard);
				}
				else
				{
					if(DriveCard != null)
					{
						if(bIgnoreDriveToHand)
						{
							bIgnoreDriveToHand = false;
						}
						else
						{
							playerHand.AddToHand(DriveCard);
							SendPacket(GameAction.SEND_DRIVE_TO_HAND);
						}
					}
					DriveCard = null;
					bChooseTriggerEffects = false;
					
					if(bTwinDrive)
					{
						DriveCheck();
						bTwinDrive = false;
					}
					else if(bPerformAdditionalDriveCheck)
					{
						bPerformAdditionalDriveCheck = false;
						DriveCheck();
					}
					else
					{
						SendPacket(GameAction.END_DRIVECHECK);
						SendConfirmation();
						WaitForOponnent();
					}
				}
			}
		}
		
		if(bChooseTriggerEffects)
		{
			if(bChooseAttack)
			{
				if(Input.GetMouseButtonUp(0))
				{
					Card card = field.GetCardAt(Util.GetMousePosition());
					if(card != null)
					{
						card.IncreasePowerUntilEndTurn(5000);
						SendPacket(GameAction.INCREASE_POWER_END_TURN, Util.GetMousePosition(), 5000);
						bChooseAttack = false;
						bChooseEffect = true;
						bEffectOnGoing = true;
						GameChat.AddChatMessage("ADMIN", "bChooseAttack");
					}
				}
			}
			else if(bChooseEffect)
			{	
				_GameHelper.SetTriggerEffect(DriveCard.GetTriggerType());
				if(DriveCard.GetTriggerType() == TriggerIcon.CRITICAL)
				{
					if(Input.GetMouseButtonUp(0))
					{
						Card card = field.GetCardAt(Util.GetMousePosition());
						if(card != null)
						{	
							card.IncreaseCriticalUntilEndTurn(1);
							SendPacket(GameAction.INCREASE_CRITICAL_END_TURN, Util.GetMousePosition(), 1);
							bChooseEffect = false;
							bEffectOnGoing = false;	
						}
					}
				}
				else if(DriveCard.GetTriggerType() == TriggerIcon.DRAW)
				{
					playerHand.AddToHand(playerDeck.DrawCard());
					SendPacket(GameAction.DRAW_FROM_DECK, 1);
					field.CheckAbilities(CardState.Draw);
					bChooseEffect = false;
					bEffectOnGoing = false;
				}
				else if(DriveCard.GetTriggerType() == TriggerIcon.STAND)
				{
					//Check if it's a rested unit at least. If there is no unit to stand, this effect doesn't apply.
					if((field.GetNumberOfUnitRested() > 0 && field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).IsStand()) ||
					   (!field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).IsStand() && field.GetNumberOfUnitRested() > 1))
					{
						if(Input.GetMouseButtonUp(0))
						{
							Card card = field.GetCardAt(Util.GetMousePosition());
							if(card != null && !card.IsStand() && card != CardAttacking)
							{
								card.Stand();
								bChooseEffect = false;
								bEffectOnGoing = false;
								SendPacket(GameAction.STAND_UNIT, card.pos);
								card.CheckAbilities(CardState.Stand);
							}
						}
					}
					else
					{
						bChooseEffect = false;
						bEffectOnGoing = false;
					}
				}
				else if(DriveCard.GetTriggerType() == TriggerIcon.HEAL)
				{
					if(field.GetDamage() >= enemyField.GetDamage() && field.GetDamage() > 0)
					{
						if(Input.GetMouseButtonUp(0))
						{
							if(LastDamageCardSelected != null && LastDamageCardSelected._HandleMouse.mouseOn)
							{
								int idx = field.RemoveFromDamage(LastDamageCardSelected);
								field.AddToDropZone(LastDamageCardSelected);	
								SendPacket(GameAction.HEAL_TRIGGER_SELECT, idx);
								bChooseEffect = false;
								bEffectOnGoing = false;
								_GameHelper.SetToNormal();
							}
						}
					}
					else
					{
						bChooseEffect = false;
						bEffectOnGoing = false;						
					}
				}
			}
			else
			{
				Debug.Log ("End Drive Check");
				if(DriveCard != null)
				{
					if(!bIgnoreDriveToHand)
					{
						playerHand.AddToHand(DriveCard);
						SendPacket(GameAction.SEND_DRIVE_TO_HAND);
					}
					else
					{
						bIgnoreDriveToHand = false;
					}

					_GameHelper.SetToNormal();
					//SendPacket(GameAction.DRAW_FROM_DECK);
				}
				DriveCard = null;				
				bChooseTriggerEffects = false;

				
				if(!bTwinDrive)
				{
					SendConfirmation();
					SendPacket(GameAction.END_DRIVECHECK);
					WaitForOponnent();
					bDoAttackOnce = true;
				}
				else if(bPerformAdditionalDriveCheck)
				{
					bPerformAdditionalDriveCheck = false;
					DriveCheck();
				}
				else
				{
					bTwinDrive = false;
					DriveCheck();	
				}
			}
		}
	}
	
	public void WaitForOponnent()
	{
		if(!bOponnentHasConfirmed)
		{
			bPauseGameplay = true;	
		}
		else
		{
			bOponnentHasConfirmed = false;	
		}
	}

	public bool TryToChangePhase()
	{
		if(Input.GetMouseButtonUp(1)
		   && !_CardMenu.IsOpen()
		   && _MouseHelper.GetAttachedCard() == null)
		{
			return true;
		}

		return false;
	}

	void ResolveDamageCheckLogic()
	{
		if(bDamageCheckTrigger)
		{
			//Give +5000 power			
			if(bGivePowerEffect)
			{
				_GameHelper.SetPowerIncrease();
				if(Input.GetMouseButtonUp(0))
				{
					fieldPositions pos = Util.GetMousePosition();
					Card tempCard = field.GetCardAt(pos);
					if(tempCard != null)
					{
						tempCard.IncreasePowerUntilEndTurn(5000);
						bTriggerEffect = true;
						bGivePowerEffect = false;
						SendPacket(GameAction.INCREASE_POWER_END_TURN, pos, 5000);
						if(lastDamageCard.GetTriggerType() == TriggerIcon.HEAL)
						{	
							_GameHelper.SetTriggerEffect(lastDamageCard.GetTriggerType());
						}
						else
						{
							_GameHelper.SetToNormal();	
						}
					}
				}
			}
			
			//Give effect
			if(bTriggerEffect)
			{
				bTriggerEffect = false;
				
				if(lastDamageCard != null)
				{
					if(lastDamageCard.GetTriggerType() == TriggerIcon.DRAW)
					{
						playerHand.AddToHand(playerDeck.DrawCard());
						SendPacket(GameAction.DRAW_FROM_DECK, 1);
						field.CheckAbilities(CardState.Draw);
						bDamageCheckTrigger = false;
						bEffectOnGoing = false;
						DamageCheck();
					}
					else if(lastDamageCard.GetTriggerType() == TriggerIcon.HEAL)
					{
						if((field.GetDamage() - 1) >= enemyField.GetDamage() && field.GetDamage() > 1)
						{
							bHealTrigger = true;
						}
						else
						{
							_GameHelper.SetToNormal();
							bDamageCheckTrigger = false;
							bEffectOnGoing = false;
							DamageCheck();
						}
					}
					else
					{
						bDamageCheckTrigger = false;
						bEffectOnGoing = false;
						DamageCheck();	
					}
				}
			}
			
			return;
		}
	}

	private void Guard()
	{
		if(bDamageCheckTrigger)
		{
			return;
		}
		
		if(CurAttackedListIndex != LastAttackedListIndex)
		{
			field.CheckAbilitiesSoul(CardState.BeginGuard);
			CardToAttack.CheckAbilities(CardState.Attacked);
			LastAttackedListIndex = CurAttackedListIndex;
		}
		
		if(TryToChangePhase())
		{
			CurAttackedListIndex++;
			if(CurAttackedListIndex >= AttackedList.Count)
			{
				CardToAttack.CheckAbilities(CardState.EndGuard);

				if(CardAttacking.IsVanguard())
				{
					SendConfirmation();
					SendPacket(GameAction.DRIVE_CHECK);
					WaitForOponnent();
				}
				else
				{
					for(int i = 0; i < AttackedList.Count - 1; i++)
					{
						ResolveBattle(AttackedList[i]);
					}
					
					ResolveLastBattle(AttackedList[AttackedList.Count - 1]);
				}			
			}
			else
			{
				UntargetCard(AttackedList[CurAttackedListIndex - 1]);
				TargetCard(AttackedList[CurAttackedListIndex]);
				CardToAttack = AttackedList[CurAttackedListIndex];
			}
		}
	}
	
	private void TargetCard(Card c)
	{
		c.IsTargetted(true);
		SendPacket(GameAction.TARGET_CARD, c.pos);
	}
	
	private void UntargetCard(Card c)
	{
		c.IsTargetted(false);
		SendPacket(GameAction.UNTARGET_CARD, c.pos);
	}
	
	private void ResolveLastBattle(Card c)
	{
		bTakeDamage = false;
		
		if(c.IsVanguard())
		{
			if(AttackHits(c))
			{
				if(bCanReceiveDamage)
				{
					bTakeDamage = true;
				}
				else
				{
					SendPacket(GameAction.ATTACK_HITS);		
				}
			}
			else
			{
				SendPacket(GameAction.ATTACK_NOT_HIT);	
			}
		}
		else
		{
			ResolveBattle(c);	
		}
		
		//End the guard phase
		bShowAttackPowerWindow = false;
		bShowDefensePowerWindow = false;
		SendAction(GameAction.END_ATTACK);
		guardZone.CleanGuardZone(field);
		bBlockGuardEndBattle = false;
		bMinGuardGradeBlocked = 0;
		bMaxGuardGradeBlocked = 99;
		UntargetCard(c);
		AttackedList.Clear();
			
		//Damage 
		if(bTakeDamage)
		{
			num_damage = CardAttacking.GetCritical();
			Debug.Log ("Damage: " + num_damage);
			DamageCheck();
		}
		else
		{
			/*
			SendConfirmation();
			CardAttacking.ResetPower();
			SendPacket(GameAction.END_BATTLE, CardAttacking.pos);
			bDoPerfectGuardPerBattle = false;
			gamePhase = GamePhase.ENEMY_TURN;	
			UntargetCard(c);
			CardToAttack = null;
			CardAttacking = null;
			bBlockGuardEndBattle = false;
			*/
			EndBattle(false);
			UntargetCard(c);
			CardToAttack = CardAttacking = null;
			gamePhase = GamePhase.ENEMY_TURN;
			LastAttackedListIndex = -1;
			
			for(int i = 0; i < playerHand.Size(); i++)
			{
				Card tempCard = playerHand.GetCardAtIndex(i);
				if(tempCard != null) 
				{
					tempCard.SetOpacity(true);	
				}
			}
		}

	}
	
	private bool AttackHits(Card c)
	{
		return c.CanBeHit() && (CardAttacking.GetTotalPower() >= c.GetDefensePower());
	}
	
	private void ResolveBattle(Card c)
	{		
		if(AttackHits(c))
		{
			UntargetCard(c);
			field.AddToDropZone(c);
			field.ClearZone(c.pos);
			SendPacket(GameAction.SEND_TO_DROPZONE, c.pos);
			SendPacket(GameAction.ATTACK_HITS);
		}
		else
		{
			SendPacket(GameAction.ATTACK_NOT_HIT);	
		}
	}
	
	
	private void ChoosingVanguard()
	{		
		Card tmpCard = playerDeck.RemoveFromDeck(49);
		field.Ride(tmpCard);
		tmpCard.TurnDown();
		gamePhase = GamePhase.DRAW_HAND;
		SendPacket(GameAction.PLACE_INITIAL_VANGUARD, field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).cardID);
		//networkView.RPC ("SendInformationToOpponent", opponent, (int)field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).cardID, (int)GameAction.PLACE_INITIAL_VANGUARD, 0, 0, "", 0);
	}
	
	//Draw card from player's deck to make the player hand.
	private void DrawHand()
	{
		playerDeck.Shuffle();
		//Add five cards to the player hand
		for(int i = 0; i < 5; i++)
		{
			playerHand.AddToHand(playerDeck.DrawCard());	
		}
		//Send information about the hand to your opponent
		//networkView.RPC("SendInformationToOpponent", opponent, 0, (int)GameAction.DRAW_FROM_DECK, 5, 0, "", 0);
		SendPacket(GameAction.DRAW_FROM_DECK, 5);
		//Change to Mulligan phase
		gamePhase = GamePhase.MULLIGAN;
	}
	
	//Once the player has drawn his cards, he can choose some of his cards to replace them adding them to the deck 
	//and drawing the same amount from the deck (After shuffle deck)
	private void Mulligan()
	{
		//Initialize mouse to perfome mulligan action.
		if(bDrawing)
		{
			bDrawing = false;
			cardToChange = 0;
		}
			
		if(Input.GetMouseButtonUp(0))
		{
			//To select a card to be replaced, player must press X on the card that he want to change. 
			//Then the card automatically returns to the deck.
			Card tempCard = playerHand.GetCurrentCardObject();
			if(tempCard != null && tempCard._HandleMouse.mouseOn)
			{
				playerDeck.AddCard(playerHand.RemoveFromHand(playerHand.GetCurrentCard()));	
				playerDeck.SetDeckPosition();
				cardToChange++;
			}
		}
		else if(TryToChangePhase())
		{
			//Once the player finishes choosing his cards, he can press Z to end the Mulligan Phase.
			//And draw an equal amount of cards to the selected ones.
			//Shuffle the deck
			playerDeck.Shuffle();
			//Draw cards until you have five cards again.
			for(int i = 0; i < cardToChange; i++)
			{
				playerHand.AddToHand(playerDeck.DrawCard());	
			}
			
			bFlipVanguard = true;
			gamePhase = GamePhase.SHOW_VANGUARD;
		}	
	}
	
	private void ShowingVanguard()
	{
		
		if(bFlipVanguard)
		{
			_AuxCard = field.GetCardAt(fieldPositions.VANGUARD_CIRCLE);
			_AuxCard.AnimatedFlipup();
			bFlipVanguard = false;
			enemyField.GetCardAt(EnemyFieldPosition.VANGUARD).AnimatedFlipup();
		}
		
		if(!_AuxCard.bDoAnimatedFlip)
		{
			//Confirm that the mulligan phase has ended.
			SendConfirmation();			
			//Wait for opponent to confirm his mulligand phase.
			WaitForOponnent();
			//If player stars the game, then go to draw phase.
			//Otherwise, go to Opponent Turn Phase.
			if(bPlayerTurn)
			{
				gamePhase = GamePhase.DRAW;
			}
			else
			{
				gamePhase = GamePhase.ENEMY_TURN;	
			}	
		}
	}
	
	//Set the camera position according to the mouse position. (Must be called every frame)
	private void CameraMovement()
	{	
		if(gamePhase == GamePhase.CHOOSE_VANGUARD)
		{
			return;	
		}
		

	}
	
	private void PopUpHandler()
	{
		if(!bPopUpOpen)
		{
			return;	
		}
	}
	
	bool bEndTurnEvent = true;
	bool bUnlockEndTurnCards = true;

	private void HandleEndPhase()
	{
		if(!bEffectOnGoing && !stateDynamicText.GetIsActive())
		{
			if(bUnlockEndTurnCards)
			{
				field.InitFieldIterator();
				bUnlockEndTurnCards = false;
			}

			if(field.HasNextField())
			{
				Card tmp = field.CurrentFieldCard();

				if(tmp != null && tmp.IsLocked())
				{
					if(tmp.IsOmegaLock())
					{
						tmp.SetOmegaLock(false);
					}
					else
					{
						tmp.Unlock();
						bEffectOnGoing = true;
						SendPacket(GameAction.UNLOCK_ENEMY, tmp.pos);
					}
				}

				return;
			}


			if(bEndTurnEvent)
			{
				bEndTurnEvent = false;
				bEffectOnGoing = true;
				SendPacket(GameAction.EVENT_BEGIN_ENDTURN);
				return;
			}
			
			bEndTurnEvent = true;
			numBattle = 1;
			bDeckHasBeenShuffledThisTurn = false;
			SendPacket(GameAction.END_TURN);
			gamePhase = GamePhase.ENEMY_TURN;
			field.ResetPowers();
			field.ResetTurnPowers();
			enemyField.ResetPowers();
			enemyField.ResetTurnPowers();
			field.EraseExternFunctions();
			numTurn++;
			bDoAttackOnce = true;
			bAttacking = false;	
			UnitsCalled.Clear();
			bUnlockEndTurnCards = true;
			/*
			field.InitFieldIterator();
			while(field.HasNextField())
			{
				Card tmp = field.CurrentFieldCard();
				if(tmp != null && tmp.IsLocked())
				{
					tmp.Unlock();
					SendPacket(GameAction.UNLOCK_ENEMY, tmp.pos);
				}
			}
			*/
			field.CheckAbilities(CardState.ClearEndTurnVariables);
		}
	}
	
	public List<CardIdentifier> _AuxIdVector = null;
	bool bCallingFromBind = false;
	
	private void UpdateEvents()
	{
		if(_OppFromFieldToDamage)
		{
			if(Input.GetMouseButtonUp(0))
			{
				fieldPositions p = Util.GetMousePosition();
				if(!Util.IsEnemyPosition(p) && p != fieldPositions.VANGUARD_CIRCLE)
				{
					Card c = field.GetCardAt(p);
					if(c != null)
					{
						_OppFromFieldToDamage = false;
						c.unitAbilities._UnitObject.FromFieldToDamage(c);
						_GameHelper.DisableCustomMessage();
						GameChat.SetTab(ChatTab.CHAT);
						bEndEvent = true;
					}
				}
			}
		}

		if(_OppCallFromTopDeck)
		{
			dummyUnitObject.ResolveDeckOpening(1,
			delegate {
				dummyUnitObject.CallFromDeck(dummyUnitObject._AuxIdVector);
			},
			delegate {
				_OppCallFromTopDeck = false;
				bEffectOnGoing = false;
				bEndEvent = true;
			});

			dummyUnitObject.CallFromDeckUpdate(delegate {
				_OppCallFromTopDeck = false;
				bEffectOnGoing = false;
				bEndEvent = true;
			});
		}

		if(bForceToCallFromBind)
		{
			if(bCallingFromBind)
			{
				HandleCallFromBind();	
			}
			
			if(!field.ViewingBindZone() && !bCallingFromBind)
			{
				_AuxIdVector = field.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromBind(field.GetBoundByID(_AuxIdVector[0]), delegate {
						iNumberOfUnitsToCallFromBind--;
						if(iNumberOfUnitsToCallFromBind <= 0)
						{
							bEndEvent = true;	
							bEffectOnGoing = false;
						}
						else
						{	
							field.ViewBindZone(1, delegate(Card c) {
								for(int i = 0; i < intArr.Count; i++)
								{
									CardIdentifier tmpId = (CardIdentifier)intArr[i];
									if(tmpId == c.cardID)
									{
										return true;	
									}
								}
								return false;
							});
						}
					});
				}
				else
				{
					bEndEvent = true;	
				}
			}
		}
		
		if(_OppRetireUnitEvent)
		{
			if(Input.GetMouseButtonUp(0))
			{
				fieldPositions p = Util.GetMousePosition();
				//GameChat.AddChatMessage("ADMIN", "Retiring: " + field.GetCardAt(p).name);
				if(!Util.IsEnemyPosition(p) && p != fieldPositions.VANGUARD_CIRCLE)
				{
					Card c = field.GetCardAt(p);
					if(c != null)
					{
						_OppRetireUnitEvent = false;
						RetireUnit(c);
						_GameHelper.DisableCustomMessage();
						GameChat.SetTab(ChatTab.CHAT);
						bEndEvent = true;
					}
				}
			}
		}
		
		if(_OppRideFromSoulEvent)
		{
			if(!field.ViewingSoul())
			{
				_OppRideFromSoulEvent = false;
				Card c = field.GetSoulByID(field.GetLastSelectedList()[0]);
				RideFromSoul(c);
				bEndEvent = true;
			}
		}
		
		if(bEndEvent)
		{
			if(!bEffectOnGoing && _AbilityManager.GetStackSize() <= 0 && _AbilityManagerExt.GetStackSize() <= 0)
			{
				//GameChat.AddChatMessage("ADMIN", "Ending event...");
				bEndEvent = false;
				SendPacket (GameAction.END_EVENT, -1);	
			}
			else
			{
				/*
				GameChat.AddChatMessage("ADMIN", "Fail to end event.");
				if(bEffectOnGoing) GameChat.AddChatMessage("ADMIN", "bEffectOnGoing = true.");
				GameChat.AddChatMessage("ADMIN", "AbilityManager: "  + _AbilityManager.GetStackSize());
				GameChat.AddChatMessage("ADMIN", "AbilityManagerExt: " + _AbilityManagerExt.GetStackSize());
				*/
			}
		}		
	}
	
	// Update is called once per frame
	bool btemp = false;

	bool TriggerIsActive()
	{
		return bTriggerEffect || bDamageCheckTrigger;
	}

	void Update () {

		dummyUnitObject.FromHandToBindUpdate(delegate {

		});

		if(bEffectOnGoing != btemp)
		{
			if(bEffectOnGoing) GameChat.AddChatMessage("ADMIN", "bEffectOnGoing = true");
			if(!bEffectOnGoing) GameChat.AddChatMessage("ADMIN", "bEffectOnGoing = false");
			btemp = bEffectOnGoing;
		}

		if(Input.GetKeyUp(KeyCode.S))
		{
			if(field.ViewingSoul())
			{
				field.CloseDeck();
			}
			else
			{
				field.ViewSoul();
			}
		}
		
		UpdateEvents();
		
		if(bConfirmBoost)
		{
			if(!bEffectOnGoing && _AbilityManager.GetStackSize() <= 0 && _AbilityManagerExt.GetStackSize() <= 0)
			{
				bConfirmBoost = false;
				bConfirmBeginGuard = true;
				field.CheckAbilitiesExcept(CardAttacking.pos, CardState.Attacking_NotMe, CardAttacking);
				CardAttacking.CheckAbilities(CardState.Attacking, CardAttacking);
			}
		}
		
		if(!bEffectOnGoing && _AbilityManager.GetStackSize() > 0 && !TriggerIsActive())// && !_AbilityManagerList.IsActive())
		{
			/*
			if(_AbilityManager.ManagerListNeedsToBeOpen())
			{
 				_AbilityManagerList.Set(_AbilityManager.GetList());
				_AbilityManagerList.SetCaption("What ability do you want to active next?");
				_AbilityManagerList.OnButtonClickedCallback(delegate(string optionName, int index) {
					_AbilityManager.ExecuteAbilityWithIndex(index);
				});
			}
			else
			{
				_AbilityManager.ExecuteNextAbility();
			}
			*/
			_AbilityManager.ExecuteNextAbility();
		
		}
		
		if(!bEffectOnGoing && _AbilityManagerExt.GetStackSize() > 0)
		{
			_AbilityManagerExt.ExecuteNextAbility();	
		}
		
		if(bConfirmBeginGuard)
		{
			if(!bEffectOnGoing && _AbilityManager.GetStackSize() <= 0 && _AbilityManagerExt.GetStackSize() <= 0)
			{
				bConfirmBeginGuard = false;
				WaitForOponnent();
				SendPacket(GameAction.BEGIN_GUARD);
			}			
		}
		
		
		//Showing card at hand.
		if(_CurrentPhase != gamePhase)
		{
			_CurrentPhase = gamePhase;
			if(_CurrentPhase == GamePhase.DRAW)
			{
				stateDynamicText.SetText("DRAW PHASE");
				SendPacket(GameAction.DYNAMICTEXT_GAMEPHASE, "DRAW PHASE");

				SendGameChatMessage("Stand and Draw!", ChatTab.GAME);
			}
			else if(_CurrentPhase == GamePhase.MAIN_PHASE)
			{
				stateDynamicText.SetText("MAIN PHASE");
				SendPacket(GameAction.DYNAMICTEXT_GAMEPHASE, "MAIN PHASE");
			}
			else if(_CurrentPhase == GamePhase.ATTACK)
			{
				stateDynamicText.SetText("BATTLE PHASE");
				SendPacket(GameAction.DYNAMICTEXT_GAMEPHASE, "BATTLE PHASE");
				//stateDynamicText.SetText("BATTLE PHASE");
				SendGameChatMessage("Battle!", ChatTab.GAME);	
			}
			else if(_CurrentPhase == GamePhase.ENDTURN)
			{
				stateDynamicText.SetText("END PHASE");
				SendPacket(GameAction.DYNAMICTEXT_GAMEPHASE, "END PHASE");
				//stateDynamicText.SetText("END PHASE");
				SendGameChatMessage("Turn end.", ChatTab.GAME);	
			}
		}
		
		if(bIsCardAtHandShowing)
		{
			ShowingCardAtHandTimer -= Time.deltaTime;
			if(ShowingCardAtHandTimer <= 0.0f)
			{
				bIsCardAtHandShowing = false;
				enemyHand.HideAllCards();
			}
		}
		/*
		if(Input.GetKeyDown(KeyCode.A))
		{
			SoulBlast(field.GetTopCardFromSoul());	
			field.RemoveFromSoulByCard(field.GetTopCardFromSoul());
		}
		*/
		
		
		UpdateDiscardEvent();
		
		_MouseHelper.Update();
		
		
		if(SoulBlastCard == null && EnemySoulBlastQueue.Count > 0)
		{
			SoulBlastCard = EnemySoulBlastQueue[EnemySoulBlastQueue.Count - 1];
			EnemySoulBlastQueue.RemoveAt(EnemySoulBlastQueue.Count - 1);
			Vector3 newPosition = EnemyFieldInfo.GetPosition((int)EnemyFieldPosition.DROP);
			SoulBlastCard.GoTo(newPosition.x, newPosition.y, newPosition.z);
		}
		
		if(SoulBlastCard != null)
		{
			if(!SoulBlastCard.AnimationOngoing())
			{
				enemyField.RemoveFromSoul(SoulBlastCard);
				enemyField.AddToDropZone(SoulBlastCard, false);
				SoulBlastCard = null;
			}
		}
		
		if(FromHandToSoulCard != null)
		{
			if(!FromHandToSoulCard.AnimationOngoing())
			{
				enemyHand.RemoveFromHand(FromHandToSoulCard);
				enemyField.AddToSoul(FromHandToSoulCard);
				FromHandToSoulCard = null;
			}
		}
		
		if(DD_Card != null)
		{
			if(!DD_Card.AnimationOngoing())
			{
				enemyField.RemoveFromDropZone(DD_Card);
				enemyDeck.AddCard(DD_Card);
				DD_Card.TurnDown();
				DD_Card = null;
			}
		}
		
		//Bind From hand.
		if(BindCard != null)
		{
			if(!BindCard.AnimationOngoing())
			{
				playerHand.RemoveFromHand(BindCard);
				field.AddToBindZone(BindCard);
				BindCard = null;
			}
		}
		
		for(int i = 0; i < FromHandToBindList.Count; i++)
		{
			if(!FromHandToBindList[i].AnimationOngoing())
			{
				enemyHand.RemoveFromHand(FromHandToBindList[i]);
				enemyField.AddToBindZone(FromHandToBindList[i]);
				FromHandToBindList.RemoveAt(i);
			}
		}
		
		if(EnemyBindCard != null)
		{
			if(!EnemyBindCard.AnimationOngoing())
			{
				enemyHand.RemoveFromHand(EnemyBindCard);
				enemyField.AddToBindZone(EnemyBindCard);
				EnemyBindCard = null;
			}
		}
		/*
		
		if(SoulBlastCardAlly != null)
		{
			if(!SoulBlastCardAlly.AnimationOngoing())
			{
				field.RemoveFromSoul(SoulBlastCard);
				field.AddToDropZone(SoulBlastCard, false);
				SoulBlastCardAlly = null;
			}
		}
		*/
		
		if(ReturnToDeckCard != null)
		{
			if(!ReturnToDeckCard.AnimationOngoing())
			{
				ReturnToDeckCard.TurnDown();
				ReturnToDeckCard = null;
			}
		}
		
		_CardMenu.Update();
		
		PopUpHandler();
	
		UpdateShowCardEffect();
		HandleKeyboard();
		

		if(field.GetDamage() >= 6 || enemyField.GetDamage() >= 6)
		{
			if(bEffectOnGoing) GameChat.AddChatMessage("ADMIN", "bEffectOnGoing = true");
			if(bEnemyEffectOngoing) GameChat.AddChatMessage("ADMIN", "bEnemyEffectOngoing = true");
		}


		if(!bEffectOnGoing 
		   && (field.GetDamage() >= 6 || (enemyField.GetDamage() >= 6 && enemyField.GetDamageAtIndex(5).GetTriggerType() != TriggerIcon.HEAL)) 
		   //&& !bPauseGameplay
		   && !bEnemyEffectOngoing)
		{
			bGameEnded = true;	
			bPauseGameplay = false;
		}
		
		if(bGameEnded)
		{
			return;
		}
		
		if(bConfirmAttack)
		{
			
			bConfirmAttack = false;
			
			
			
			//bDoAttackOnce = true;
			
			
			ConfirmAttack();
		}
		
		_GameHelper.SetGamePhase(gamePhase);
		
		CameraMovement();	
		
		field.Update();
		enemyField.Update();
		playerDeck.Update();
		enemyDeck.Update();
		guardZone.Update();
		playerHand.Update();
		enemyHand.Update();
		
		if(bPauseGameplay)
		{
			if(bOponnentHasConfirmed)
			{
				bPauseGameplay = false;
				bOponnentHasConfirmed = false;
			}
			
			return;	
		}
		
		
		if(gamePhase == GamePhase.ENEMY_TURN && !bEffectOnGoing && bEnemyWaiting)
		{
			bEnemyWaiting = false;
			bEndEvent = true;
		}
		
		if(gamePhase == GamePhase.ENDTURN)
		{
			if(bConfirmEndTurn)
			{
				HandleEndPhase();
			}

			return;
		}
		
		DriveCheckHandler();
		ResolveDamageCheckLogic();
		AttackHandler();
		
		
		
		if(gamePhase == GamePhase.CHOOSE_VANGUARD)
		{
			ChoosingVanguard();
		}
		else if(gamePhase == GamePhase.SHOW_VANGUARD)
		{	
			ShowingVanguard();
		}
		else if(gamePhase == GamePhase.DRAW_HAND)
		{
			DrawHand();	
		}
		else if(gamePhase == GamePhase.MULLIGAN)
		{
			Mulligan();
		}
		else if(gamePhase == GamePhase.DRAW)
		{
			Card tmp = playerDeck.DrawCard();
			playerHand.AddToHand(tmp);

			SendPacket(GameAction.DRAW_FROM_DECK, 1);
			field.CheckAbilities(CardState.Draw);
			
			//Set some variables for the next phase.
			bRideThisTurn = true;
			gamePhase = GamePhase.STANDBY_PHASE;
			
			field.CheckAbilities(CardState.BeginMain);
			field.CheckAbilitiesSoul(CardState.Soul_BeginMain);
		}
		else if(gamePhase == GamePhase.STANDBY_PHASE)
		{
			StandByPhase();	
		}
		else if(gamePhase == GamePhase.MAIN_PHASE)
		{
			MainPhase();
		}
		else if(gamePhase == GamePhase.ATTACK)
		{
			AttackPhase();	
		}
		else if(gamePhase == GamePhase.GUARD)
		{
			Guard ();	
		}
		
	}
	
	public void StandByPhase()
	{
		if(!bEffectOnGoing)
		{
			gamePhase = GamePhase.MAIN_PHASE;
			SendPacket(GameAction.SET_ENEMY_MAIN);
			
			//GiveControl();
			SendPacket(GameAction.EVENT_BEGIN_RIDEPHASE);
		}
	}
	
	public void GiveControl()
	{	
		SendConfirmation();
		WaitForOponnent();
	}
	
	public delegate bool CallConstraint(Card c);
	CallConstraint CallFromSoulConstraint = null;
	
	public void CallFromSoul_AddConstraint(CallConstraint _f)
	{
		CallFromSoulConstraint = _f;
	}
	
	public void CallFromSoul_RemoveConstraint()
	{
		CallFromSoulConstraint = null;	
	}
	
	CallConstraint CallFromDeckConstraint = null;
	
	public void CallFromDeck_AddConstraint(CallConstraint _f)
	{
		CallFromDeckConstraint = _f;
	}
	
	public void CallFromDeck_RemoveConstraint()
	{
		CallFromDeckConstraint = null;	
	}
	
	public bool HandleSpecialCall()
	{
		if(bSpecialCall)
		{
			if(Input.GetMouseButtonUp(0))
			{
				if(bBlockMouseOnce)
				{
					bBlockMouseOnce = false;
					return true;
				}
				
				if(bBlockUnitReplacing)
				{
					Card c = field.GetCardAt(_MouseHelper.GetAttachedCard().pos);
					if(c != null)
					{
						return false;	
					}
				}
				
				Card lockCard = field.GetCardAt(_MouseHelper.GetAttachedCard().pos);
				if(lockCard != null && lockCard.IsLocked())
				{
					return false;	
				}
				
				Card AttachedCard = _MouseHelper.GetAttachedCard();
				
				if(CallFromSoulConstraint != null && CallFromSoulConstraint(AttachedCard))
				{
					return true;
				}
				
				
				field.Call(AttachedCard, AttachedCard.pos);
				LastCallFromSoul = AttachedCard;
				AttachedCard.CheckAbilities(CardState.CallFromSoul);
				field.CheckAbilitiesExcept(AttachedCard.pos, CardState.CallFromSoul_NotMe);

				SendPacket(GameAction.PLAY_CARD_FROM_SOUL, AttachedCard.cardID, (int)Util.TranformToEnemyPosition(AttachedCard.pos)); 
				/*
				networkView.RPC("SendInformationToOpponent", opponent, 
					           (int)AttachedCard.cardID, 
					           (int)GameAction.PLAY_CARD_FROM_SOUL,
						       (int)Util.TranformToEnemyPosition(AttachedCard.pos), 0, "", 0);
				*/

				bSpecialCall = false;
				_MouseHelper.UnattachCard();
				
			}
			
			return true;
		}
		
		return false;
	}
	
	
	
	public bool HandleCallFromBind()
	{
		if(bCallingFromBind)
		{
			if(Input.GetMouseButtonUp(0))
			{
				if(bBlockMouseOnce)
				{
					bBlockMouseOnce = false;
					return true;
				}
				
				if(bBlockUnitReplacing)
				{
					Card c = field.GetCardAt(_MouseHelper.GetAttachedCard().pos);
					if(c != null)
					{
						return false;	
					}
				}
				
				Card lockCard = field.GetCardAt(_MouseHelper.GetAttachedCard().pos);
				if(lockCard != null && lockCard.IsLocked())
				{
					return false;	
				}
				
				Card AttachedCard = _MouseHelper.GetAttachedCard();
				field.RemoveFromBindZone(AttachedCard);
				field.Call(AttachedCard, AttachedCard.pos);

				SendPacket(GameAction.FROM_BIND_TO_FIELD, AttachedCard.cardID, (int)Util.TranformToEnemyPosition(AttachedCard.pos));
				/*
				networkView.RPC("SendInformationToOpponent", opponent, 
					           (int)AttachedCard.cardID, 
					           (int)GameAction.FROM_BIND_TO_FIELD,
						       (int)Util.TranformToEnemyPosition(AttachedCard.pos), 0, "", 0);
				*/

				bCallingFromBind = false;
				_MouseHelper.UnattachCard();
				CallFromBindCallback();				
			}
			
			return true;
		}
		
		return false;
	}
	
	public bool HandleSpecialCallFromDrive()
	{
		if(bSpecialCallFromDrive)
		{
			if(Input.GetMouseButtonUp(0))
			{
				if(bBlockMouseOnce)
				{
					bBlockMouseOnce = false;
					return true;
				}
				
				if(bBlockUnitReplacing)
				{
					Card c = field.GetCardAt(_MouseHelper.GetAttachedCard().pos);
					if(c != null)
					{
						return false;	
					}
				}
				
				
				Card AttachedCard = _MouseHelper.GetAttachedCard();
				field.Call(AttachedCard, AttachedCard.pos);

				SendPacket(GameAction.PLAY_CARD_FROM_DRIVE, (int)Util.TranformToEnemyPosition(AttachedCard.pos));
				/*
				networkView.RPC("SendInformationToOpponent", opponent, 
					            0, 
					            (int)GameAction.PLAY_CARD_FROM_DRIVE,
						        (int)Util.TranformToEnemyPosition(AttachedCard.pos), 0, "", 0);
				*/

				bSpecialCallFromDrive = false;
				_MouseHelper.UnattachCard();
			}
			
			return true;
		}
		
		return false;
	}
	
	public void CallFromDrop(Card card, fieldPositions p)
	{
		field.RemoveFromDropzone(card);
		field.Call(card, p);
			
		LastCallFromDrop = card;
					
		card.CheckAbilities(CardState.CallFromDrop);
		field.CheckAbilitiesExcept(card.pos, CardState.CallFromDrop_NotMe);
		
		SendPacket(GameAction.PLAY_CARD_FROM_DROP, card.cardID, p);
	}
	
	public bool HandleCallFromDrop()
	{
		if(bCallFromDrop)
		{
			if(Input.GetMouseButtonUp(0))
			{
				if(bBlockMouseOnce)
				{
					bBlockMouseOnce = false;
					return true;
				}
				
				if(bBlockUnitReplacing)
				{
					Card c = field.GetCardAt(_MouseHelper.GetAttachedCard().pos);
					if(c != null)
					{
						return false;	
					}
				}
				
				Card lockCard = field.GetCardAt(_MouseHelper.GetAttachedCard().pos);
				if(lockCard != null && lockCard.IsLocked())
				{
					return false;	
				}
				
				Card AttachedCard = _MouseHelper.GetAttachedCard();
				
				if(AttachedCard != null)
				{
					CallFromDrop(AttachedCard, AttachedCard.pos);
					bCallFromDrop = false;
					_MouseHelper.UnattachCard();
				}
			}
			
			return true;
		}
		
		return false;
	}
	
	bool bCallFromDamage = false;
	
	public bool HandleCallFromDamage()
	{
		if(bCallFromDamage)
		{
			if(Input.GetMouseButtonUp(0))
			{
				if(bBlockMouseOnce)
				{
					bBlockMouseOnce = false;
					return true;
				}
				
				if(bBlockUnitReplacing)
				{
					Card c = field.GetCardAt(_MouseHelper.GetAttachedCard().pos);
					if(c != null)
					{
						return false;	
					}
				}
				
				Card AttachedCard = _MouseHelper.GetAttachedCard();
				
				if(AttachedCard != null)
				{
					int num = field.GetDamageIndexOf(AttachedCard);
					field.RemoveFromDamage(AttachedCard);
					field.Call(AttachedCard, AttachedCard.pos);
					SendPacket(GameAction.FIELD_FROM_DAMAGE, AttachedCard.pos, num);
					bCallFromDamage = false;
					_MouseHelper.UnattachCard();
				}
			}
			
			return true;
		}
		
		return false;
	}
	
	public bool HandleCallFromDeck()
	{
		if(bCallFromDeck)
		{
			if(Input.GetMouseButtonUp(0))
			{
				if(bBlockMouseOnce)
				{
					bBlockMouseOnce = false;
					return true;
				}
				
				fieldPositions pos = Util.GetMousePosition();
				
				if(!Util.IsEnemyPosition(pos) && pos != fieldPositions.VANGUARD_CIRCLE)
				{
					if(bCallToSameColum)
					{
						if(!IsSameColumn(pos, bCallSameColPos))
						{
							return true;	
						}
						
						bCallToSameColum = false;
					}
					
					Card AttachedCard = _MouseHelper.GetAttachedCard();
					
					if(CallFromDeckConstraint != null && CallFromDeckConstraint(AttachedCard))
					{
						return true;
					}
					
					field.Call(AttachedCard, AttachedCard.pos);
					AttachedCard.CheckAbilities(CardState.CallFromDeck, AttachedCard);
					field.CheckAbilitiesExcept(AttachedCard.pos, CardState.CallFromDeck_NotMe, AttachedCard);
					SendPacket(GameAction.PLAY_CARD_FROM_DECK, AttachedCard.cardID, (int)Util.TranformToEnemyPosition(AttachedCard.pos));
					/*
					networkView.RPC("SendInformationToOpponent", opponent, 
							           (int)AttachedCard.cardID, 
							           (int)GameAction.PLAY_CARD_FROM_DECK,
								       (int)Util.TranformToEnemyPosition(AttachedCard.pos), 0, "", 0);
					*/
					bCallFromDeck = false;
					_MouseHelper.UnattachCard();
					bBlockMouseOnce = true;
				}
			}
			
			return true;
		}
		
		return false;
	}
	
	private void MainPhase()
	{
		if(bBlockMouse)
		{
			return;	
		}
		
		if(bPopUpOpen)
		{
			return;	
		}
		
		
		if(HandleSpecialCall())
		{
			return;	
		}
		
		
		/*
		if(HandleCallFromDeck())
		{
			return;	
		}
		*/
		
		if(bEffectOnGoing)
		{
			return;	
		}
		
		//Select a card from your hand to play it. (Call or Ride)
		if(Input.GetMouseButtonUp(0))
		{
			if(bCardMenuJustClosed)
			{
				bCardMenuJustClosed = false;
				return;
			}
			
			if(field.ViewingSoul())
			{	
				return;
			}
			
			//The user press X to select a card from his hand and Call it or Ride it to the field.
			if(bIsCardSelectedFromHand)
			{
				Card tempCard = _MouseHelper.GetAttachedCard();
				
				Card placedUnit = field.GetCardAt(tempCard.pos);
				
				if(placedUnit == null || !placedUnit.IsLocked())
				{
					playerHand.RemoveFromHand(tempCard);
					field.Call(tempCard, tempCard.pos);
					SendPacket(GameAction.PLAY_CARD_ON_THE_FIELD, tempCard.cardID, (int)Util.TranformToEnemyPosition(tempCard.pos));
					/*
					networkView.RPC("SendInformationToOpponent", opponent, 
						           (int)tempCard.cardID, 
						           (int)GameAction.PLAY_CARD_ON_THE_FIELD,
							       (int)Util.TranformToEnemyPosition(tempCard.pos), 0, "", 0);
					*/
					_MouseHelper.UnattachCard();
					bIsCardSelectedFromHand = false;
				}
			}
		}
		else if(TryToChangePhase())
		{
			//GameChat.AddChatMessage("Battle", "Battle phase");

			if(bEffectOnGoing)	
			{
				return;
			}

			//GameChat.AddChatMessage("Battle", "Starting phase...");
			
			/*
			if(bBlockMouseOnce)
			{
				bBlockMouseOnce = false;
				return;
			}
			*/
			/*
			if(bCardMenuJustClosed)
			{
				bCardMenuJustClosed = false;
			}
			else
			{
				*/
				if(bIsCardSelectedFromHand)
				{
					bIsCardSelectedFromHand = false;
				}
				else
				{
					if(numTurn > 1)
					{
						bDoAttackOnce = true;
						numBattle = 1;
						gamePhase = GamePhase.ATTACK;	
					}
					else 
					{
						//GameChat.AddMessage("Admin", "Ending turn");
						
						gamePhase = GamePhase.ENDTURN;
						bConfirmEndTurn = false;
						SendPacket(GameAction.SET_ENEMY_ENDTURN);
						field.CheckAbilities(CardState.EndTurn);
					}
				}
			//}
		}
	}
	
	public void HandleNormalCall()
	{
		if(bIsCardSelectedFromHand)
		{
			Debug.Log("bIsCArdSelectedFromHand = true");
			Card tempCard = _MouseHelper.GetAttachedCard();
			playerHand.RemoveFromHand(tempCard);
			field.Call(tempCard, tempCard.pos);
			SendPacket(GameAction.PLAY_CARD_ON_THE_FIELD, tempCard.cardID, (int)Util.TranformToEnemyPosition(tempCard.pos));
			/*
			networkView.RPC("SendInformationToOpponent", opponent, 
				           (int)tempCard.cardID, 
				           (int)GameAction.PLAY_CARD_ON_THE_FIELD,
					       (int)Util.TranformToEnemyPosition(tempCard.pos), 0, "", 0);
			*/
			_MouseHelper.UnattachCard();
			bIsCardSelectedFromHand = false;
		}	
	}
	
	public void Call()
	{
		_MouseHelper.AttachCard(playerHand.GetCurrentCardObject());
		bIsCardSelectedFromHand = true;	
		bRideThisTurn = false;
	}
	
	public void Call(Card card)
	{
		_MouseHelper.AttachCard(card);
		
		bSpecialCall = true;
		bCardMenuJustClosed = false;
	}
	
	public bool bCallFromHand = false;
	
	public void CallFromHand(Card c)
	{
		_MouseHelper.AttachCard(c);
		bCallFromHand = true;
		bBlockMouseOnce = false;			
	}
	
	public bool HandleCallFromHand()
	{
		if(bCallFromHand)
		{
			if(Input.GetMouseButtonUp(0))
			{
				if(bBlockMouseOnce)
				{
					bBlockMouseOnce = false;
					return true;
				}
				
				if(bBlockUnitReplacing)
				{
					Card c = field.GetCardAt(_MouseHelper.GetAttachedCard().pos);
					if(c != null)
					{
						return false;	
					}
				}
				
				Card AttachedCard = _MouseHelper.GetAttachedCard();
				playerHand.RemoveFromHand(AttachedCard);
				field.Call(AttachedCard, AttachedCard.pos);
				AttachedCard.CheckAbilities(CardState.Call);

				SendPacket(GameAction.PLAY_CARD_ON_THE_FIELD, AttachedCard.cardID, (int)Util.TranformToEnemyPosition(AttachedCard.pos));
				/*
				networkView.RPC("SendInformationToOpponent", opponent, 
					           (int)AttachedCard.cardID, 
					           (int)GameAction.PLAY_CARD_ON_THE_FIELD,
						       (int)Util.TranformToEnemyPosition(AttachedCard.pos), 0, "", 0);
				*/
				bCallFromHand = false;
				_MouseHelper.UnattachCard();
			}
			
			return true;
		}
		
		return false;
	}
	
	public void CallFromDrive()
	{
		_MouseHelper.AttachCard(DriveCard);
		bSpecialCallFromDrive = true;
		DriveCard = null;
	}
	
	public void CallFromDrop(Card card)
	{
		_MouseHelper.AttachCard(card);
		bCallFromDrop = true;
		bCardMenuJustClosed = false;	
	}
	
	public void CallFromDeck(Card card)
	{
		_MouseHelper.AttachCard(card);
		bCallFromDeck = true;
		bCardMenuJustClosed = false;	
	}
	
	public void CallFromBind(Card card, Void0ParamsDelegate f)
	{
		_MouseHelper.AttachCard(card);
		bCallingFromBind = true;
		bCardMenuJustClosed = false;	
		CallFromBindCallback = f;
	}
	
	void SelectAnimField(Card c)
	{
		c.DoSelectAnim();
		SendPacket(GameAction.SELECT_ANIM_FIELD, c.pos);
	}
	
	public void CallFromDamage(Card card)
	{
		SendPacket (GameAction.SELECT_ANIM_DAMAGE, field.GetDamageIndexOf(card));
		_MouseHelper.AttachCard(card);
		bCallFromDamage = true;
	}
	
	public void CallFromDeck_SameColum(Card card, fieldPositions p)
	{
		_MouseHelper.AttachCard(card);
		card.TurnUp();
		bCallFromDeck = true;
		bCardMenuJustClosed = false;
		
		bCallToSameColum = true;
		bCallSameColPos = p;
	}
	
	public bool IsSameColumn(fieldPositions c1, fieldPositions c2)
	{
		if(c1 == c2)
		{
			return true;	
		}
		
		if(c1  == fieldPositions.ENEMY_FRONT_LEFT  ||
		   c1 == fieldPositions.ENEMY_REAR_LEFT   ||
	       c1 == fieldPositions.FRONT_GUARD_RIGHT ||
		   c1 == fieldPositions.REAR_GUARD_RIGHT)
		{
		   if(c2 == fieldPositions.ENEMY_FRONT_LEFT  ||
		  	  c2 == fieldPositions.ENEMY_REAR_LEFT   ||
	          c2 == fieldPositions.FRONT_GUARD_RIGHT ||
		      c2 == fieldPositions.REAR_GUARD_RIGHT)
			{
				return true;	
			}
		}
		
		if(c1 == fieldPositions.ENEMY_FRONT_RIGHT ||
		   c1 == fieldPositions.ENEMY_REAR_RIGHT  ||
	       c1 == fieldPositions.FRONT_GUARD_LEFT  ||
		   c1 == fieldPositions.REAR_GUARD_LEFT)
		{
		   if(c2 == fieldPositions.ENEMY_FRONT_RIGHT  ||
		  	  c2 == fieldPositions.ENEMY_REAR_RIGHT   ||
	          c2 == fieldPositions.FRONT_GUARD_LEFT   ||
		      c2 == fieldPositions.REAR_GUARD_LEFT)
			{
				return true;	
			}
		}
		
		if(c1 == fieldPositions.ENEMY_REAR_CENTER  ||
		   c1 == fieldPositions.ENEMY_VANGUARD     ||
	       c1 == fieldPositions.REAR_GUARD_CENTER  ||
		   c1 == fieldPositions.VANGUARD_CIRCLE)
		{
		   if(c2 == fieldPositions.ENEMY_REAR_CENTER  ||
		  	  c2 == fieldPositions.ENEMY_VANGUARD     ||
	          c2 == fieldPositions.REAR_GUARD_CENTER  ||
		      c2 == fieldPositions.VANGUARD_CIRCLE)
			{
				return true;	
			}
		}
		
		return false;
	}
	
	public void Ride()
	{
		Card tempCard = playerHand.GetCurrentCardObject();
		SendPacket(GameAction.PLAY_CARD_ON_THE_FIELD, tempCard.cardID, (int)EnemyFieldPosition.VANGUARD);
		field.Ride(playerHand.RemoveFromHand(playerHand.GetCurrentCard()));
		bRideThisTurn = false;
		tempCard._Coord = CardCoord.FIELD;
	}
	
	public void Ride(Card card)
	{
		SendPacket(GameAction.PLAY_CARD_ON_THE_FIELD, card.cardID, (int)EnemyFieldPosition.VANGUARD);
		field.Ride(card);
		field.FixSoulPosition();
	}
	
	public void RideFromDeck(Card card)
	{
		card.TurnUp();
		playerDeck.RemoveFromDeck(card);

		SendPacket(GameAction.RIDE_FROM_DECK, card.cardID);
		field.Ride(card);
	}
	
	public void RideFromSoul(Card c)
	{
		field.RemoveFromSoulByCard(c);
		SendPacket(GameAction.RIDE_FROM_SOUL, c.cardID);
		field.Ride (c);
	}
	
	void BoostUnit()
	{
		bEffectOnGoing = false;
		bConfirmBoost = true;
		//field.CheckAbilitiesExcept(CardAttacking.pos, CardState.Attacking_NotMe);
		//CardAttacking.CheckAbilities(CardState.Attacking);
	}
	
	void BoostUnit(Card c)
	{
		//C: Attacer
		//B: Booster
		
		Card b = field.GetCardAt(BackRow(c.pos));
		c.IncreasePower(b.GetPower());	
		SendPacket(GameAction.POWER_INCREASE, c.pos, b.GetPower());
		b.boostedUnit = c;
		b.Rest();						
		SendPacket(GameAction.REST_UNIT, b.pos);
		b.CheckAbilities(CardState.Boost);
		c.IsBoostedBy = b;
		
		SendPacket (GameAction.BOOST, c.pos);
		c.CheckAbilities(CardState.IsBoosted);
		
		//bEffectOnGoing = false;
		//bConfirmBoost = true;
		BoostUnit();
	}
	
	bool CanBeBoosted(Card c)
	{
		if(c == null) return false;
		
		if(c.IsVanguard() && !c.CanBeBoostedVanguard()) return false;
		if(!c.IsVanguard() && !c.CanBeBoostedRearGuard()) return false;
		
		Card b = field.GetCardAt(BackRow(c.pos));
		if(b == null) return false;
		if(!b.CanBoost(c)) return false;
		if(!b.IsStand()) return false;
		if(b.IsLocked()) return false;
		
		return true;
	}
	
	fieldPositions BackRow(fieldPositions p)
	{
		if(p == fieldPositions.VANGUARD_CIRCLE)   return fieldPositions.REAR_GUARD_CENTER;	
		if(p == fieldPositions.FRONT_GUARD_LEFT)  return fieldPositions.REAR_GUARD_LEFT;
		if(p == fieldPositions.FRONT_GUARD_RIGHT) return fieldPositions.REAR_GUARD_RIGHT;
		return fieldPositions.DECK_ZONE;
	}
	
	private void AttackPhase()
	{
		if(bBlockMouse || bPopUpOpen || bEffectOnGoing)
			return;
		
		if(bAttacking && !bTargetSelected)
		{
			fieldPositions mPos = Util.GetMousePosition();
			if((CardAttacking.CanAttackBackRow && Util.IsEnemyPosition(mPos)) || (!CardAttacking.CanAttackBackRow && Util.IsFrontRow(mPos)) &&
				CardAttacking.CanAttackPos(mPos))
			{
				Card c = enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(Util.GetMousePosition()));
				
				if(c._Coord == CardCoord.ENEMY_FIELD && !c.IsLocked())
				{
					CardToAttack = c;
				}
			}
			else
			{
				CardToAttack = null;	
			}
		}
		
		if(bAttacking && bDoAttackOnce)
		{
			if(CardAttacking.unitAbilities.HasSpecialAttackPattern())
			{
				bDoAttackOnce = false;
			}
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			bCardMenuJustClosed = false;
			
			if(bBlockMouseOnce)
			{
				bBlockMouseOnce = false;
				return;
			}
			
			if(!bAttacking)
			{
				fieldPositions mPos = Util.GetMousePosition();
				
				//Select with X a unit on the field, if it is in the front line then prepare for attack.
				if(mPos == fieldPositions.FRONT_GUARD_LEFT  ||
				   mPos == fieldPositions.FRONT_GUARD_RIGHT ||
				   mPos == fieldPositions.VANGUARD_CIRCLE)
				{
					Card tempCard = field.GetCardAt(mPos);
					
					if(tempCard != null && !tempCard.AnimationOngoing())
					{
						//If the card is stand
						if(tempCard.IsStand() && tempCard.CanAttack() && tempCard.unitAbilities.CanAttack())
						{
							//Then rest it and prepare to select a opponent front line unit.
							tempCard.Rest();

							SendPacket(GameAction.REST_UNIT, (int)Util.TranformToEnemyPosition(mPos));
							/*
							networkView.RPC ("SendInformationToOpponent", opponent,
								             0, //A Card identifier is not needed.
											 (int)GameAction.REST_UNIT,
										     (int)Util.TranformToEnemyPosition(mPos), 0, "", 0);
							*/
							bShowAttackPowerWindow = true;
							bShowDefensePowerWindow = true;
							CardAttacking = field.GetCardAt(mPos);
							bAttacking = true;
							bTargetSelected = false;
						}
					}
				}
			}
			else
			{
				if(bDoAttackOnce)
				{
					if(CardToAttack != null)
					{
						bDoAttackOnce = false;
						CardAttacking.CheckAbilities(CardState.DeclareAttack);
						/*
						field.CheckAbilitiesExcept(CardAttacking.pos, CardState.Attacking_NotMe);
						CardAttacking.CheckAbilities(CardState.Attacking);
						*/
						//numBattle++;
						bTargetSelected = true;
					}
				}
			}
		}
		else if(TryToChangePhase())
		{
			if(bEffectOnGoing || DriveCard != null)	
			{
				return;
			}
			
			if(bPopupJustClosed)
			{
				bPopupJustClosed = false;
			}
			else
			{
				gamePhase = GamePhase.ENDTURN;
				bConfirmEndTurn = false;
				SendPacket(GameAction.SET_ENEMY_ENDTURN);
				field.CheckAbilities(CardState.EndTurn);
				field.CheckAbilitiesHelpZone(CardState.HelpZone_EndTurn);
			}
		}
	}
	
	private void ConfirmAttack()
	{
		if(_AttackType == AttackType.NONE)
		{
			//Put a graphic identifier on the card that is being attacking.
			//Also, active DefensePower and AttackPower OnGUI codes.
			PutSelectorOnCard(CardToAttack);
			SendPacket(GameAction.SELECT_UNIT_TO_ATTACK, CardToAttack.pos, (int)CardAttacking.pos);
			/*
			networkView.RPC("SendInformationToOpponent", opponent,
							0,
						    (int)GameAction.SELECT_UNIT_TO_ATTACK,
				            (int)CardToAttack.pos,
							(int)CardAttacking.pos, "", 0);
			*/
		}
		else if(_AttackType == AttackType.ALL)
		{
			SendPacket(GameAction.ATTACK_ALL_UNITS, CardAttacking.pos);	
		}
		else if(_AttackType == AttackType.FRONT_ROW)
		{
			SendPacket(GameAction.ALL_FRONT, CardAttacking.pos);		
		}

	}
	
	private void DriveCheck()
	{		
		DriveCard = playerDeck.Drive();
		_CardMenuHelper.SetCard(DriveCard.cardID);
		CardAttacking.CheckAbilities(CardState.DriveCheck, DriveCard);
		field.CheckAbilities(CardState.DriveCheck_NotMe);
		driveTime = DRIVECHECK_DELAY;
		bDriveAnimation = true;
		SendPacket(GameAction.PUT_CARD_ON_DRIVEZONE, DriveCard.cardID);
	}
	
	private void LoadDeck()
	{
		//Load player's deck...		
		List<Card> pd = new List<Card>();
		
		for(int i = 0; i < 50; i++)
		{
			pd.Add (new Card());	
		}
		
		string deckName = PlayerVariables.DeckName;
		StreamReader reader = new StreamReader("Deck/" + deckName + ".cfd");
		
		int curIndex = 0;
		while(reader.Peek() != -1)
		{
			int id = int.Parse(reader.ReadLine());
			Data.FillCardWithData(pd[curIndex++], (CardIdentifier)id);
			pd[curIndex - 1].unitAbilities.SetUnitObject((CardIdentifier)id);
		}
		
		reader.Close();
		
		for(int i = 0; i < 50; i++)
		{
			playerDeck.AddCard(pd[i], false);
			pd[i].SetGame(this);
		}
	}
	
	void OnGUI()
	{		
		Vector3 deckInfoPos = _MainCamera.WorldToScreenPoint(fieldInfo.GetPosition((int)fieldPositions.DECK_ZONE));
		GUI.Label (new Rect(deckInfoPos.x + 10, deckInfoPos.y + 90, 100, 25), "" + playerDeck.Size());

		Vector3 deckEnemyInfoPos = _MainCamera.WorldToScreenPoint(EnemyFieldInfo.GetPosition((int)EnemyFieldPosition.DECK));
		GUI.Label (new Rect(deckEnemyInfoPos.x, deckEnemyInfoPos.y, 100, 25), "" + enemyDeck.Size());


		GameChat.DrawGUI();
		_GameHelper.DrawGUI();
		_CardMenuHelper.DrawGUI();
		playerDeck.DrawGUI();
		field.DrawGUI();
		_PopupNumber.Draw();
		DrawCardEffect();
		_CardMenu.Draw();
		
		
		if(GUI.Button(new Rect(Screen.width - 100, 0, 100, 25), "Surrender"))
		{
			bGameEnded = true;
			bSurrender = true;
			bOpponentSurrender = false;
			SendPacket(GameAction.SURRENDER);
		}

		GUI.Label (new Rect(Screen.width - 100, 45, 100, 25), "Battle: " + numBattle);
		
		_SelectionListWindow.Render();
		_AbilityManagerList.Render();
		_SelectionCardNameWindow.Render();
		_DecisionWindow.Render();
		_NotificationWindow.Render();
		
		if(bPopUpOpen)
		{
			float leftIndent = Screen.width / 2 - 597.0f / 2 + 150;
			float topIndent = Screen.height / 2 - 145.0f / 2;
			connectionWindowRect = new Rect(leftIndent, topIndent, 597.0f, 145.0f);
			GUI.Box (connectionWindowRect, "", ConfirmationWindowStyle);
			
			string text = "Do you want to active " + _CardWindow.name + " effect?";
			if(text.Length > 40)
			{
				text.Insert(22, "\n");	
			}
			
			GUI.Label(new Rect(leftIndent + 50, topIndent + 30, 300, 280), text, ConfirmationWindowTextStyle);
			
			if(GUI.Button(new Rect(leftIndent + 100 - 30, topIndent + 90 - 10, yesButtonStyle.normal.background.width, yesButtonStyle.normal.background.height), "", yesButtonStyle))
			{
				LastPPAnswer = 1;
				bPopUpOpen = false;
			}
			
			if(GUI.Button(new Rect(leftIndent + 400 - 30, topIndent + 90 - 10, noButtonStyle.normal.background.width, noButtonStyle.normal.background.height), "", noButtonStyle))
			{			
				LastPPAnswer = 2;
				bPopUpOpen = false;
				bPopupJustClosed = true;	
			}
		}
		
		if(bBoostWindow)
		{
			float leftIndent = Screen.width / 2 - 597.0f / 2 + 150;
			float topIndent = Screen.height / 2 - 145.0f / 2;
			connectionWindowRect = new Rect(leftIndent, topIndent, 597.0f, 145.0f);
			GUI.Box (connectionWindowRect, "", ConfirmationWindowStyle);
			GUI.Label(new Rect(leftIndent + 80, topIndent + 50, 300, 280), "Boost " + CardAttacking.name + "?", ConfirmationWindowTextStyle);
			
			if(GUI.Button(new Rect(leftIndent + 100, topIndent + 90, 80, 30), "Yes"))
			{
				BoostUnit(CardAttacking);
				bBoostWindow = false;
			}
			
			if(GUI.Button(new Rect(leftIndent + 400, topIndent + 90, 80, 30), "No"))
			{			
				BoostUnit();
				bBoostWindow = false;
			}
		}
		
		if(bOpponentWindow)
		{
			float leftIndent = Screen.width / 2 - 597.0f / 2 + 150;
			float topIndent = Screen.height / 2 - 145.0f / 2;
			connectionWindowRect = new Rect(leftIndent, topIndent, 597.0f, 145.0f);
			GUI.Box (connectionWindowRect, "", ConfirmationWindowStyle);
			GUI.Label(new Rect(leftIndent + 80, topIndent + 50, 300, 280), bOpponentWindowMessage, ConfirmationWindowTextStyle);
			
			if(GUI.Button(new Rect(leftIndent + 100, topIndent + 90, 80, 30), "Accept"))
			{
				bOpponentWindow = false;
				SendPacket (GameAction.PLAYER_ACCEPT);
			}
			
			if(GUI.Button(new Rect(leftIndent + 400, topIndent + 90, 80, 30), "Cancel"))
			{				
				bOpponentWindow = false;
				SendPacket (GameAction.PLAYER_DENIED);
			}
		}
		
		_CardMenuHelper.SetGamePhase(gamePhase);
		
		Rect r = new Rect(Screen.width - 100.0f, 0.0f, 150.0f, 50.0f);
		Rect UpperRect = new Rect(Screen.width - 200.0f, Screen.height / 3 - 145.0f, 140.0f, 140.0f);
		Rect LowerRect = new Rect(Screen.width - 200.0f, Screen.height * 2 / 3 - 145.0f, 140.0f, 140.0f);
		Rect DefensePowerRect;
		Rect AttackPowerRect;
		
		if(gamePhase == GamePhase.ENDTURN || gamePhase == GamePhase.GUARD)
		{
			DefensePowerRect = LowerRect;
			AttackPowerRect = UpperRect;
		}
		else
		{
			DefensePowerRect = UpperRect;
			AttackPowerRect = LowerRect;
		}
		
		if(bShowAttackPowerWindow 
		   && !playerDeck.TopCard().IsFaceup() 
		   && !playerDeck.IsOpen()
		   && !_DecisionWindow.IsOpen())
		{
			if(CardAttacking != null)
			{
				
				GUI.Box (AttackPowerRect, CardAttacking.GetPower() + "", PowerIconStyle);
			}
		}
		
		if(bShowDefensePowerWindow
		   )//&& (!playerDeck.TopCard().IsFaceup()))
		{
			if(CardToAttack != null)
			{
				int defensePower = CardToAttack.GetDefensePower();
				GUI.Box (DefensePowerRect, defensePower + "", PowerIconStyle);
			}
			else
			{
				//GUI.Box (DefensePowerRect, "0", PowerIconStyle);
			}
		}


		if(_GameHelper.ShowHelperText())
		{
			int lastFontSize = GUI.skin.label.fontSize;
			TextAnchor lastTextAnchor = GUI.skin.label.alignment;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.fontSize = 22;
			GUI.skin.label.normal.textColor = Color.black;
			GUI.Label(new Rect(341, 161, 560, 300), _GameHelper._CurText);
			GUI.skin.label.normal.textColor = Color.white;
			GUI.Label(new Rect(340, 160, 560, 300), _GameHelper._CurText);
			GUI.skin.label.fontSize = lastFontSize;
			GUI.skin.label.alignment = lastTextAnchor;
		}

		stateDynamicText.Render();

		if(bPauseGameplay)
		{
			GUI.Box(r, "Waiting");
			return;
		}

		if(bGameEnded)
		{
			RenderEndGameWindow();	
		}
	}
	
	private void RenderEndGameWindow()
	{
		//Semi-transparent black background
		Color tmpColor = GUI.color;
		GUI.color = new Color(0,0,0,0.6f);
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), _BackgroundTexture);
		//A 2D texture for "You Win!" or "You Lose!" message
		GUI.color = tmpColor;
		if(field.GetDamage() >= 6 || bSurrender || bWinByCardEffect)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2 - _YouLoseTexture.width / 2, Screen.height / 2 - _YouLoseTexture.height, _YouLoseTexture.width, _YouLoseTexture.height), _YouLoseTexture);	
		}
		
		if((field.GetDamage() < 6 && !bSurrender) || bOpponentSurrender || bLoseByCardEffect)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2 - _YouWinTexture.width / 2, Screen.height / 2 - _YouWinTexture.height, _YouWinTexture.width, _YouWinTexture.height), _YouWinTexture);
		}
		//Two buttons, one for "Return to menu" and another one for "Quit Game"
		if(GUI.Button(new Rect(Screen.width / 2 - 70.0f, 360.0f, 140.0f, 60.0f), "Return to menu"))
		{
			Network.Disconnect();
			Application.LoadLevel("MainMenu");
		}
		if(GUI.Button(new Rect(Screen.width / 2 - 70.0f, 430.0f, 140.0f, 60.0f), "Quit Game"))
		{
			Network.Disconnect();
			Application.Quit();
		}
	}

	
	private void HandleKeyboard()
	{
		//Chat
		if(Input.GetKeyUp(KeyCode.Return))
		{
			SendGameChatMessage(GameChat.GetCurrentMessage());
			/*
			GameChat.AddChatMessage(MultiplayerScript.playerName, GameChat.GetCurrentMessage());
			networkView.RPC("SyncChat", opponent, MultiplayerScript.enemyName, GameChat.GetCurrentMessage());
			*/
			GameChat.ClearChat();
		}
		
	}
	
	public void SendGameChatMessage(string msg, ChatTab tab = ChatTab.CHAT)
	{
		//if(opponent != null)
		//{
			if(tab == ChatTab.CHAT) GameChat.AddChatMessage(PlayerVariables.playerName, msg);
		else if(tab == ChatTab.GAME) GameChat.AddGameMessage(PlayerVariables.playerName, msg);
		//networkView.RPC("SyncChat", opponent, PlayerVariables.enemyName, msg, (int)tab);	
		//}
	}
	
	[RPC]
	private void SyncChat(string name, string msg, int tab)
	{
		ChatTab _t = (ChatTab)tab;
		
		if(_t == ChatTab.CHAT) GameChat.AddChatMessage(PlayerVariables.enemyName, msg);
		else if(_t == ChatTab.GAME) GameChat.AddGameMessage(PlayerVariables.enemyName, msg);
	}
	
	
	public void ShowCardEffect(Texture2D cardTex)
	{
		_EffectTime = SHOW_CARD_DELAY;	
		_CardEffectTexture = cardTex;
		bShowCardEffect = true;
	}
	
	public void UpdateShowCardEffect()
	{
		_EffectTime -= Time.deltaTime;
		if(_EffectTime <= 0 && bShowCardEffect)
		{
			bShowCardEffect = false;
		}
	}
	
	public void DrawCardEffect()
	{
		if(bShowCardEffect)
		{
			GUI.DrawTexture(new Rect(550, 200, 250, 378), _CardEffectTexture);
		}
	}
	
	void ConnectWindow(int windowID)
	{
		GUILayout.Space(15);
		GUILayout.Label("Do you want to active " + _CardWindow.name + " effect?");	
		GUILayout.Space(30);
		GUILayout.Label("X: Yes\t\t Z: No");
	}
	
	public void ActivePopUpQuestion(Card c)
	{
		bPopUpOpen = true;
		_CardWindow = c;
	}
	
	public Card SoulCharge()
	{
		Card tempCard = playerDeck.DrawCard();
		field.AddToSoul(tempCard);
		tempCard.TurnUp();
		Vector3 newPosition = fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + new Vector3(0.0f, -0.01f, 0.0f);
		
		//Vector3 newPosition = EnemyFieldInfo.GetPosition((int)EnemyFieldPosition.VANGUARD) + new Vector3(0.0f, -0.01f, 0.0f);
		
		
		tempCard.GoTo (newPosition.x, newPosition.y, newPosition.z);
		SendPacket(GameAction.SOULCHARGE, tempCard.cardID);
		
		return tempCard;
	}
	
	public Card SoulCharge(CardIdentifier id)
	{
		Card tempCard = playerDeck.SearchForID(id);
		playerDeck.RemoveFromDeck(tempCard);
		field.AddToSoul(tempCard);
		tempCard.TurnUp();
		Vector3 newPosition = fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + new Vector3(0.0f, -0.01f, 0.0f);
		
		//Vector3 newPosition = EnemyFieldInfo.GetPosition((int)EnemyFieldPosition.VANGUARD) + new Vector3(0.0f, -0.01f, 0.0f);
		
		
		tempCard.GoTo (newPosition.x, newPosition.y, newPosition.z);
		SendPacket(GameAction.SOULCHARGE, tempCard.cardID);
		
		return tempCard;
	}
	
	public void SoulBlast(Card card)
	{
		//SoulBlastCardAlly = card;
		Vector3 newPosition = fieldInfo.GetPosition((int)fieldPositions.DROP_ZONE);
		card.GoTo(newPosition.x, newPosition.y, newPosition.z);
		SendPacket(GameAction.SOULBLAST, card.cardID);
	}
	
	public void FromHandToSoul(Card c, int handPosition)
	{
		SendPacket (GameAction.FROM_HAND_TO_SOUL, c.cardID, handPosition);
		Vector3 newPos = fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE);
		c.SetRotation(0, 180, 0);
		c.GoTo(newPos.x, newPos.y, newPos.z);
	}
	
	public void FromHandToBind(Card c, int handPosition, bool bFacedown = false)
	{
		c.BindAnim();
		//int iFacedown = 0;
		//if(bFacedown) iFacedown = 1;
		SendPacket (GameAction.FROM_HAND_TO_BIND, c.cardID, handPosition);
	}
	
	public void DisplayOpponentWindow(string str)
	{
		SendPacket(GameAction.DISPLAY_WINDOW, str);
	}
	
	public void RetireUnit(Card card)
	{
		if(!card.IsVanguard())
		{
			card.CheckAbilities(CardState.DropZoneFromRC);	
		}
		
		field.ClearZone(card.pos);
		field.AddToDropZone(card);
		SendPacket(GameAction.SEND_TO_DROPZONE, card.pos);
	}
	
	private void MoveToSoul(Card card)
	{
		card.Stand();
		field.MoveToSoul(card.pos);
		field.RemoveFrom(card.pos);
		field.FixSoulPosition();
		SendPacket(GameAction.FROM_FIELD_TO_SOUL, card.pos);
	}
	
	Card BindCard = null;
	Card EnemyBindCard = null;
	
	public void EnemyBindHand(Card c)
	{
		EnemyBindCard = c;
		EnemyBindCard.BindAnim();
	}
	
	public void BindHand(Card c)
	{
		BindCard = c;
		BindCard.BindAnim();
	}

	void OnPlayerDisconnected(NetworkPlayer player)
	{
		_NotificationWindow.Set("Connection lost.",
		delegate {
			Application.LoadLevel("MainMenu");
		});
	}

	void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		_NotificationWindow.Set("Connection lost.",
		                        delegate {
			Application.LoadLevel("MainMenu");
		});
	}
}

public class _OppBindHandFacedownReturnEndTurnEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyEndTurn)
		{
			FromBindToHand (OwnerCard);
		}
	}
}



