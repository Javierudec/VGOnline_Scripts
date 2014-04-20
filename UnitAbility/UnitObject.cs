using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitObject {
	public List<CardIdentifier> _AuxIdVector;
	public List<Card> _SaveCards;
	
	public delegate void Void0ParamsDelegate();
	public delegate void CounterBlastDelegate();
	public delegate void AutoDelegate(CardState s);
	public delegate void cardFunction(Card c);
	public delegate bool delegateConstraint();
	public delegate bool boolCardFunction(Card c);
	public delegate void positionFunction(fieldPositions p);
	
	CounterBlastDelegate _CB_fnc;	
	Void0ParamsDelegate SEU_End;
	Void0ParamsDelegate SEU_Func;
	Void0ParamsDelegate _SU_fnc;
	Void0ParamsDelegate _SU_fnc_end;	
	Void0ParamsDelegate _SIH_fnc;
	Void0ParamsDelegate _SIH_fnc_end;
	Void0ParamsDelegate _SID_fnc;
	delegateConstraint SEU_Constraint;
	delegateConstraint _SU_constraint;
	delegateConstraint _SIH_constraint;
	boolCardFunction _CB_CheckCard = null;
	
	public Gameplay Game = null;
	public Card _AuxCard1 = null;
	public Card OwnerCard = null;
	public Card Unit = null;
	public Card _SBAux_Card1 = null;
	public Card _SIH_Card = null;
	public Card EnemyUnit = null;
	public Card _SID_Card = null;
	public Card _CFS_AuxCard = null;
	public Card _CFDAux_Card = null;
	public Card SC_Card = null;
	public Card FHTS_Card = null;
	public int id = -1;
	public int _AuxInt1 = 0;
	public int currPersistentPower = 0;
	public int _SIH_n = 0;
	public int SC_Int = 0;
	public int _CB_num = 0;
	public int SEU_num;
	public int DC_n = 0;
	public int _SBAux_Int1 = 0;
	public int _SU_n = 0;
	public int _SID_n = 0;
	public int _CFDAux_Int1 = 0;
	public float DC_time = 0;
	public float _Delay_Time = 0;
	public bool FHTS_Bool1 = false;
	public bool _CFDAux_Bool1 = false;
	public bool SC_Bool = false;
	public bool _Delay_Bool = false;
	public bool _CFS_AuxBool3 = false;
	public bool bEnablePointer = false;
	public bool bWindowActive = false;
	public bool _CB_Active = false;
	public bool _SIH_Active = false;
	public bool _SU_Active = false;
	public bool _CFH_Active = false;
	public bool _SIH_End = false;
	public bool _SID_End = false;
	public bool _SU_EndEffect = true;
	public bool SEU_Active = false;
	public bool DC_bool = false;
	public bool bSelectVanguard = false;
	public bool SEU_bEndEffect;
	public bool _SBAux_Bool1 = false;
	public bool _SBAux_Bool2 = false;
	public bool _SID_Active = false;
	public bool _AuxBool = false;
	public bool _AuxBool2 = false;
	public bool _AuxBool3 = false;
	public bool _AuxBool4 = false;
	public bool _AuxBool5 = false;
	public bool _AuxBool6 = false;
	public bool _CFDamage_Active = false;
	public bool SC_WithSelection = false;
	public List<CardIdentifier> _SBAux_IDVector = null;
	public List<CardIdentifier> _CFDAux_IDVector;
	public List<CardIdentifier> SC_List = null;
	public List<Card> CallFromDeckList;
	public List<Card> cardStorage = new List<Card>();

	public UnitObject()
	{
		OnInstanceInit();
	}

	public virtual void OnInstanceInit()
	{

	}

	public FieldWatcher GetFieldWatcher()
	{
		return Game.field.fieldWatcher;
	}

	public List<Card> GetDropZone()
	{
		return Game.field.DropZone;
	}

	public List<Card> GetSoulZone()
	{
		return Game.field.Soul;
	}

	public void SetGame(Gameplay _Game)
	{
		CallFromDeckList = new List<Card>();
		Game = _Game;	
	}
	
	public void SetOwnerCard(Card _Card)
	{
		OwnerCard = _Card;	
	}

	public void FromSoulToDeck(Card c)
	{
		if(c._Coord != CardCoord.SOUL)
		{
			return;
		}

		GetSoulZone().Remove(c);
		GetDeck().AddCard(c);
		Game.SendPacket(GameAction.FROM_SOUL_TO_DECK, c.cardID);
	}

	public virtual void Auto(CardState cs, Card ownerEffect = null)
	{
		/*
		if(cs == CardState.DeclareAttack)
		{
			ConfirmAttack();	
		}
		*/
	}
	
	public virtual void AutoHand(CardState cs)
	{
		
	}

	public virtual void DecisionWindowAccept()
	{

	}

	public virtual void DecisionWindowDenied()
	{

	}

	public virtual void EndEvent()
	{
		EndEffect();
	}
	
	public virtual bool Cancel()
	{
		return true;
	}

	public virtual void Cont()
	{
		
	}
	
	public virtual void Update()
	{
		
	}
	
	public virtual void Active()
	{
		StartEffect();
		ShowAndDelay();
		Game.field.CloseDeck();
	}
	
	public virtual void Active(int idAbility)
	{
		Active();
	}
	
	public virtual void SelectionCardNameOnClose(string nameSelected)
	{
		
	}
	
	public virtual void Pointer()
	{
		CounterBlast_Pointer();
		SelectInHand_Pointer();
		SelectInEnemyHand_Pointer();
		SelectUnit_Pointer();
		SelectEnemyUnit_Pointer();
		SelectInDamage_Pointer();
		SelectInEnemyDamage_Pointer();
        Flipup_Pointer();
		Heal_Pointer();
		SelectOpenRC_Pointer();
	}
	
	public virtual bool EffectOnHand()
	{
		return false;	
	}
	
	public virtual void SelectionWindowOnClose(Card unitAffected, string optionSelected)
	{
		
	}
	
	public virtual int EffectOnDamage()
	{
		return 0;	
	}
	
	public virtual int EffectOnSoul()
	{
		return 0;	
	}

	public virtual int EffectOnDrop()
	{
		return 0;
	}
	
	public virtual int Act()
	{
		return 0;
	}

	public void MoveToOpenRC(Card c, fieldPositions p)
	{
		Game.SendPacket(GameAction.MOVE_TO_OPENRC, (int)c.pos, (int)p, 0);
		Game.field.ClearZone(c.pos);

		c.pos = p;

		if(p == fieldPositions.FRONT_GUARD_LEFT) Game.field.Left_Front = c;
		else if(p == fieldPositions.FRONT_GUARD_RIGHT) Game.field.Right_Front = c;
		else if(p == fieldPositions.REAR_GUARD_CENTER) Game.field.Center_Rear = c;
		else if(p == fieldPositions.REAR_GUARD_RIGHT) Game.field.Right_Rear = c;
		else if(p == fieldPositions.REAR_GUARD_LEFT)  Game.field.Left_Rear = c;

		Vector3 newVector = Game.field.fieldInfo.GetPosition((int)p);
		c.GoTo(newVector.x, newVector.z);
	}
	

	Card FDTGC_Card = null;
	bool FDTGC_Active = false;

	public void FromDeckToGuardianCircle(Card c)
	{
		FDTGC_Card = c;
		FDTGC_Active = true;
		Game.SendPacket(GameAction.FROM_DECK_TO_GUARDIANCIRCLE, c.cardID);
	}

	public void FromDeckToGuardianCircleUpdate(Void0ParamsDelegate f)
	{
		if(FDTGC_Active)
		{
			if(!FDTGC_Card.AnimationOngoing())
			{
				FDTGC_Active = false;
				GetDeck().DrawCard();
				Game.guardZone.AddToGuardZone(FDTGC_Card, true);
				GetDefensor().AddExtraShield(FDTGC_Card.shield);
				//Game.guardZone.AddExtraPower(FDTGC_Card.shield);
				f();
			}
		}
	}

	public void ExchangePositions(Card c1, Card c2)
	{
		if(c1 == null || c2 == null) return;
		if(c1._Coord != CardCoord.FIELD || c2._Coord != CardCoord.FIELD) return;

		Game.SendPacket(GameAction.EXCHANGE, (int)c1.pos, (int)c2.pos, 0);

		fieldPositions p1 = c1.pos;
		fieldPositions p2 = c2.pos;

		if(p1 == fieldPositions.REAR_GUARD_CENTER)      Game.field.Center_Rear = c2;
		else if(p1 == fieldPositions.REAR_GUARD_LEFT)   Game.field.Left_Rear   = c2;
		else if(p1 == fieldPositions.REAR_GUARD_RIGHT)  Game.field.Right_Rear  = c2;
		else if(p1 == fieldPositions.FRONT_GUARD_LEFT)  Game.field.Left_Front  = c2;
		else if(p1 == fieldPositions.FRONT_GUARD_RIGHT) Game.field.Right_Front = c2;

		if(p2 == fieldPositions.REAR_GUARD_CENTER)      Game.field.Center_Rear = c1;
		else if(p2 == fieldPositions.REAR_GUARD_LEFT)   Game.field.Left_Rear   = c1;
		else if(p2 == fieldPositions.REAR_GUARD_RIGHT)  Game.field.Right_Rear  = c1;
		else if(p2 == fieldPositions.FRONT_GUARD_LEFT)  Game.field.Left_Front  = c1;
		else if(p2 == fieldPositions.FRONT_GUARD_RIGHT) Game.field.Right_Front = c1;

		c1.pos = p2;
		c2.pos = p1;

		Vector3 c1NewPos = Game.field.fieldInfo.GetPosition((int)c1.pos);
		Vector3 c2NewPos = Game.field.fieldInfo.GetPosition((int)c2.pos);

		c1.GoTo(c1NewPos.x, c1NewPos.z);
		c2.GoTo(c2NewPos.x, c2NewPos.z);
	}

	public void OpponentFromFieldToDamage()
	{
		Game.SendPacket (GameAction.OPPONENT_FROM_FIELD_TO_DAMAGE);
	}

	public void EnemyFromDamageToDrop(Card c)
	{
		int index = Game.enemyField.GetDamageIndexOf(c);
		Game.SendPacket(GameAction.ENEMY_FROM_DAMAGE_TO_DROP, index);
	}

	public void FromFieldToDamage(Card c)
	{
		Game.field.RemoveFrom(c.pos);	
		Game.field.AddToDamageZone(c);
		Game.SendPacket(GameAction.FROM_FIELD_TO_DAMAGE, c.pos);
	}

    public void OpponentDrawCard()
    {
        Game.SendPacket(GameAction.OPPONENT_DRAW);
    }

	public void SetAttackType(AttackType t)
	{
		OwnerCard.unitAbilities._AttackType = t;
	}

	public void RideFromSoul(Card c) 
	{
		Game.RideFromSoul(c);
	}

	public void FromSoulToHand(Card c)
	{
		Game.field.RemoveFromSoulByCard(c);
		Game.playerHand.AddToHand(c);
		Game.SendPacket(GameAction.FROM_SOUL_TO_HAND, c.cardID);
	}
		              
	public int NumUnitsDamage(boolCardFunction f = null)
	{
		int count = 0;
		for(int i = 0; i < Game.field.DamageZone.Count; i++)
		{
			if(f == null || f(Game.field.DamageZone[i]))
			{
				count++;
			}
		}
		return count;
	}

	public void OpponentFromHandToBind(int index)
	{
		Game.SendPacket(GameAction.OPPONENT_FROM_HAND_TO_BIND, index);
	}

	public int NumEnemyUnitsBind(boolCardFunction f = null)
	{
		int count = 0;
		for(int i = 0; i < Game.enemyField.BindZone.Count; i++)
		{
			if(f == null || f(Game.enemyField.BindZone[i]))
			{
				count++;
			}
		}
		return count;
	}

	public void ResolveDeckOpening(int id, Void0ParamsDelegate success, Void0ParamsDelegate failure)
	{
		if(GetBool(id) && !GetDeck().IsOpen())
		{
			UnsetBool(id);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				success();
			}
			else
			{
				failure();
			}
		}	
	}

	public void ResolveDropOpening(int id, Void0ParamsDelegate success, Void0ParamsDelegate failure)
	{
		if(GetBool(id) && !Game.field.ViewingDropZone())
		{
			UnsetBool(id);
			_AuxIdVector = Game.field.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				success();
			}
			else
			{
				failure();
			}
		}	
	}

	public void ResolveEnemyBindOpening(int id, Void0ParamsDelegate success, Void0ParamsDelegate failure)
	{
		if(GetBool(id) && !Game.enemyField.ViewingBind())
		{
			UnsetBool(id);
			_AuxIdVector = Game.enemyField.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				success();
			}
			else
			{
				failure();
			}
		}	
	}

	public Card GetEnemyVanguard()
	{
		return Game.enemyField.GetCardAt(EnemyFieldPosition.VANGUARD);			
	}

	public void IncreaseEnemyPowerByTurn(Card c, int power)
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

	public void BlockNormalGuardEndBattle(int min = 0, int max = 99)
	{
		Game.SendPacket(GameAction.BLOCK_GUARD_END_BATTLE, max);
		Game.SendPacket(GameAction.BLOCK_GUARD_END_BATTLE_MIN, min);
	}

    public void ResolveSoulOpening(int id, Void0ParamsDelegate success, Void0ParamsDelegate failure)
    {
        if (GetBool(id) && !Game.field.ViewingSoul())
        {
            UnsetBool(id);
            _AuxIdVector = Game.field.GetLastSelectedList();
            if (_AuxIdVector.Count > 0)
            {
                success();
            }
            else
            {
                failure();
            }
        }
    }

	bool DD_toBottom;
	List<CardIdentifier> DD_List;
	Card DD_Card;
	bool DD_Active = false;

	public void FromDropToDeck(Card c, bool toBottom = false)
	{
		List<CardIdentifier> list = new List<CardIdentifier>();

		list.Add(c.cardID);
		FromDropToDeck(list, toBottom);
	}

	public void FromDropToDeck(List<CardIdentifier> v, bool toBottom = false)
	{
		DD_Card     = null;
		DD_List     = v;
		DD_toBottom = toBottom;
		DD_Active   = true;
	}
	
	public void FromDropToDeckUpdate(Void0ParamsDelegate DD_fnc)
	{
		if(DD_Active)
		{
			if(DD_Card == null || !DD_Card.AnimationOngoing())
			{
				if(DD_List.Count > 0)
				{
					DD_Card = Game.field.GetDropByID(DD_List[0]);
					DD_Card.TurnDown();
					
					DD_List.RemoveAt(0);
					Game.field.RemoveFromDropzone(DD_Card);

					if(DD_toBottom)
					{
						Game.playerDeck.AddToBottom(DD_Card);
					}
					else
					{
						Game.playerDeck.AddCard(DD_Card);	
					}

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

	public bool _DropCall_AuxBool = false;

	public void CallFromDropUpdate(Void0ParamsDelegate func)
	{
		if(_DropCall_AuxBool)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				_DropCall_AuxBool = false;
				func();
			}
			else
			{
				Game.HandleCallFromDrop();	
			}
		}
	}
	
	public void CallFromDrop(Card card)
	{
		Game.CallFromDrop(card);	
		_DropCall_AuxBool = true;
	}
	
	public int NumOpenRC()
	{
		return Game.field.NumOpenRC();	
	}

	public int NumEnemyOpenRC()
	{
		return Game.enemyField.NumOpenRC();
	}
	
	public void SelectAnimField(Card c)
	{
		c.DoSelectAnim();
		Game.SendPacket(GameAction.SELECT_ANIM_FIELD, c.pos);
	}
	
	public void RideFromDeck(Card c)
	{
		Game.RideFromDeck(c);	
	}
	
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

	public void OpponentFromBindToDrop(CardIdentifier id)
	{
		Game.SendPacket(GameAction.OPPONENT_FROM_BIND_TO_DROP, id);
	}

	public void FromBindToDrop(Card c)
	{
		Game.field.RemoveFromBindZone (c);
		Game.field.AddToDropZone(c);
		Game.SendPacket(GameAction.FROM_BIND_TO_DROP, c.cardID);
	}

	/**
	 * Shuffle deck.
	 */
	public void ShuffleDeck()
	{
		Game.playerDeck.Shuffle();
	}
	
	/**
	 * Returns true if a Counter Blast with n cards can be performed.
	 */
	public bool CheckCounterBlast(int n)
	{
		return Game.field.GetNumberOfDamageCardsFaceup() >= n;			
	}

	public void WinGame()
	{
		Game.WinByCardEffect();
	}
	
	public bool CB(int n)
	{
		return CheckCounterBlast(n);		
	}
	
	public bool CB(int n, boolCardFunction f)
	{
		int count = 0;
		for(int i = 0; i < Game.field.DamageZone.Count; i++)
		{
			Card tmp = Game.field.DamageZone[i];
			if(tmp != null && tmp.IsFaceup() && f(tmp))
			{
				count++;	
			}
		}
		return count >= n;
	}
			
	public void AddContClan(string clanName)
	{
		OwnerCard.AddExtraClan(clanName);
	}

	public void OmegaLock(Card enemyCard)
	{
		Game.SendPacket(GameAction.OMEGA_LOCK, enemyCard.pos);
	}

	public bool VC()
	{
		return OwnerCard.IsVanguard();		
	}
	
	public bool RC()
	{
		return !OwnerCard.IsVanguard();	
	}
	
	public void ConfirmAttack()
	{
		/*
		Game._AttackType = AttackType.NONE;
		Game.bConfirmAttack = true;	
		*/
	}
	
	public bool LimitBreak(int n)
	{
		return n <= Game.field.GetDamage();	
	}
	
	public bool IsPlayerTurn()
	{
		return CurrentPhaseIs(GamePhase.ATTACK) || CurrentPhaseIs(GamePhase.DRAW) || CurrentPhaseIs(GamePhase.MAIN_PHASE) || CurrentPhaseIs(GamePhase.STANDBY_PHASE);	
	}
	
	public Card GetAttacker()
	{
		return Game.CardAttacking;	
	}
	
	public Card GetDefensor()
	{
		return Game.CardToAttack;	
	}
	
	public int NumGuardians(boolCardFunction fnc = null)
	{
		int count = 0;
		for(int i = 0; i < Game.guardZone.cards.Count; i++)
		{
			if(fnc == null || fnc(Game.guardZone.cards[i]))
			{
				count++;	
			}
		}
		return count;
	}
	
	public int NumUnits(boolCardFunction fnc, bool bCountVanguard = false, bool bCountLocked = false)
	{
		int cnt = 0;
		Game.field.InitFieldIterator();
		while(Game.field.HasNextField())
		{
			Card c = Game.field.CurrentFieldCard();
			if(c != null && fnc(c) && (bCountLocked || !c.IsLocked()))
			{
				if(c.IsVanguard())
				{
					if(bCountVanguard)
					{
						cnt++;
					}
				}
				else
				{
					cnt++;	
				}
			}
		}
		return cnt;
	}
	
	public int NumEnemyUnits(boolCardFunction fnc, bool bCountVanguard = false, bool bCountLockedCards = false)
	{
		int cnt = 0;
		for(int i = 0; i < 6; i++) 
		{
			if(EnemyField(i) != null && fnc(EnemyField(i)) && (!bCountLockedCards || EnemyField(i).IsLocked()))	
			{
				if(i == 0)
				{
					if(bCountVanguard)
					{
						cnt++;
					}
				}
				else
				{
					cnt++;	
				}
			}
		}
		return cnt;
	}
	
	public bool EnemyIsInBackRow(Card c)
	{
		return c.pos == fieldPositions.ENEMY_REAR_CENTER || c.pos == fieldPositions.ENEMY_REAR_LEFT || c.pos == fieldPositions.ENEMY_REAR_RIGHT;
	}

	public void LockUnit(Card c)
	{
		c.Lock();
		Game.SendPacket(GameAction.LOCK_ENEMY, c.pos);
	}

	public void UnlockUnit(Card c)
	{
		c.Unlock();
		Game.SendPacket(GameAction.UNLOCK_ENEMY, c.pos);
	}

	public void LockEnemyUnit(Card c)
	{
		c.Lock();
		Game.SendPacket(GameAction.LOCK, c.pos);
		Game.field.CheckAbilities(CardState.EnemyIsLocked, c);
	}
	
	public void SetPower(int power)
	{
		currPersistentPower = power;

		//new system
		OwnerCard.unitAbilities.contPower += power;
	}

	public void AddContPower(int power)
	{
		SetPower(power);
	}

	public Card LookAtTopDeckCard()
	{
		Card temp = Game.playerDeck.TopCard();
		temp.TurnUp();
		return temp;
	}

	public void AddContCritical(int critical)
	{
		OwnerCard.unitAbilities.contCritical += critical;
	}

	public bool _H_Active = false;
	public int _H_n = 0;
	public Void0ParamsDelegate _H_f = null;

	public void Heal(int num, Void0ParamsDelegate f)
	{
		_H_n = num;
		_H_Active = true;
		EnableMouse("Choose " + _H_n + " card(s) from your damage zone.");
		_H_f = f;
	}
	
	public bool Heal_Pointer()
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
						_H_f();
						_H_Active = false;
					}
				}
			}
			return true;
		}
		return false;
	}
	
	public void DisplayConfirmationWindow()
	{
		if(Game.bCheckAutoMode) return;

		OwnerCard.unitAbilities.currentActiveExternId = id;
		//Game.GameChat.AddChatMessage("ADMIN", "idExtern = " + OwnerCard.unitAbilities.currentActiveExternId);
		
		StartEffect();
		bWindowActive = true;
		//Game.LastPPAnswer = 0;
		Game.ActivePopUpQuestion(OwnerCard);	
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
		Game.SendPacket (GameAction.EFFECT_ON);
		Game.bRideThisTurn = true;
	}
	
	public void EndEffect()
	{
		Game.SendPacket (GameAction.EFFECT_OFF);
		Game.bEffectOnGoing = false;	
	}
	
	public void ShowAndDelay()
	{
		if(Game.bCheckAutoMode) return;

		ShowOnScreen();
		StartEffect();
		Delay(1);		
	}
	
	public void ShowOnScreen()
	{
		ShowOnScreen(OwnerCard);	
	}
	
	public void ShowOnScreen(Card card)
	{
		Game.ShowCardEffect(Resources.Load ("CardHelper/" + Game.Data.GetCardInfo(card.cardID).clan + "/" + Game.Data.GetImageName(card.cardID)) as Texture2D);
		Game.SendPacket(GameAction.SHOW_CARD, card.cardID);
	}
	
	public void Delay(float seconds)
	{
		_Delay_Time = seconds;	
		_Delay_Bool = true;
	}
	
	public void DelayUpdate(Void0ParamsDelegate func, int id = -1)
	{
		if(_Delay_Bool && (id == -1 || GetBool(id)))
		{
			if(_Delay_Time >= 0)
			{
				_Delay_Time -= Time.deltaTime; 	
			}
			else
			{
				if(id != -1) 
				{
					UnsetBool(id);
				}

				_Delay_Bool = false;
				func();
			}
		}	
	}
	
	public void CounterBlast(int n, CounterBlastDelegate fnc, boolCardFunction f = null)
	{
		_CB_num = n;
		_CB_CheckCard = f;
		if(Game.field.GetNumberOfDamageCardsFaceup() == n && f == null)
		{
			FlipCardInDamageZone(n);
			fnc();
		}
		else
		{
			_CB_Active = true;
			_CB_fnc = fnc;
			EnableMouse("Choose " + _CB_num + " face-up cards from your damage zone.");
		}
	}
	
	public bool CounterBlast_Pointer()
	{
		if(_CB_Active)
		{
			if(AcceptInput())
			{
				Card c = Game.LastDamageCardSelected;
				if(c != null && c._HandleMouse.mouseOn && c.IsFaceup() && (_CB_CheckCard == null || _CB_CheckCard(c)))
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
	
	public void SelectEnemyUnit(string msg, int n, bool bEndEffect, Void0ParamsDelegate fnc, delegateConstraint constraint, Void0ParamsDelegate fncEnd)
	{
		if(n == 0)
		{
			fncEnd();
			if(bEndEffect)
			{
				EndEffect();	
			}
		}
		else
		{	
			SEU_Func = fnc;
			SEU_Constraint = constraint;
			SEU_End = fncEnd;
			SEU_bEndEffect = bEndEffect;
			SEU_num = n;
			SEU_Active = true;
			EnableMouse(msg);
		}
	}
	
	public bool SelectEnemyUnit_Pointer()
	{
		if(SEU_Active)
		{
			if(AcceptInput())
			{
				fieldPositions p = Util.GetMousePosition();
				if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
				{
					EnemyUnit = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
					if(EnemyUnit != null && SEU_Constraint() && !EnemyUnit.IsLocked())
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

	public void OpponentCallFromDeckLookingAtTop(int numCardsOnTop, int minGrade, int MaxGrade)
	{
		Game.SendPacket (GameAction.OPPONENT_CALL_FROM_TOP_DECK, numCardsOnTop, minGrade, MaxGrade);
	}

	public void FromHandToDamage(Card c)
	{
		int idx = Game.playerHand.GetIndexOf(c);
		Game.playerHand.RemoveFromHand(c);	
		Game.field.AddToDamageZone(c);
		Game.SendPacket(GameAction.FROM_HAND_TO_DAMAGE, c.cardID, idx);
	}

	public int min(int a, int b)
	{
		if(a > b)
		{
			return b;	
		}
		
		return a;
	}

	public void CantInterceptUntilEndTurn(Card c)
	{
		Game.SendPacket(GameAction.UNIT_CANNOT_INTERCEPT_ENDTURN, c.pos);	
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
	
	public void CantStandUntilNextTurn(Card card)
	{
		card.NegateStand();
		Game.SendPacket(GameAction.NEGATE_ENEMY_STAND, card.pos);
	}
	
	public void FlipCardInDamageZone(int num)
	{
		while(num-- != 0)
		{
			Game.field.FlipDamageZoneCard();
			Game.SendPacket(GameAction.FLIPDAMAGE);	
		}
	}
	
	/**
	 * Call this function is you want to be able to use Pointer functions (Select cards from hand, field, drop, etc...)
	 */
	public void EnableMouse(string str)
	{
		EnableMouse();
		DisplayHelpMessage(str);
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
	
	public bool AcceptInput()
	{
		return Input.GetMouseButtonUp(0);	
	}
	
	public bool CancelInput()
	{
		return Input.GetMouseButtonUp(1);	
	}
	
	public void Flipdown(Card c)
	{
		c.TurnDown();
		Game.SendPacket(GameAction.FLIPDOWN, Game.field.GetDamageIndexOf(c));
	}
	
	public void ClearPointer(bool bEnd = true)
	{
		ClearMessage();
		DisableMouse();
		if(bEnd)
		{
			EndEffect();
		}
	}
	
	public void DisplayHelpMessage(string msg)
	{
		Game._GameHelper.CustomMessage(msg);
	}
	
	public void ClearMessage()
	{
		Game._GameHelper.DisableCustomMessage();	
	}
	
	public Deck GetDeck()
	{
		return Game.playerDeck;
	}

	public void IncreaseEnemyPowerByBattle(Card c, int power)
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

	public bool _AuxBool7 = false;

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
		else if(i == 7)
		{
			_AuxBool7 = true;
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
		else if(i == 7)
		{
			return _AuxBool7;
		}
		
		return false;
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
		else if(i == 7)
		{
			_AuxBool7 = false;
		}
	}
	
	public int _SIG_n;
	public Void0ParamsDelegate _SIG_fnc;
	public bool _SIG_Active;
	public bool _SIG_EndEffect;
	public delegateConstraint _SIG_Constraint;
	public Void0ParamsDelegate _SIG_fnc_end;
	public Card Guardian;
	
	public void SelectInGuard(string msg, int n, bool bEnd, Void0ParamsDelegate fnc, delegateConstraint constr, Void0ParamsDelegate fnc_end)
	{
		if(n == 0)
		{
			fnc_end();
			if(bEnd)
			{
				EndEffect();	
			}
		}
		else
		{
			_SIG_n = n;
			_SIG_fnc = fnc;
			_SIG_Active = true;
			EnableMouse(msg + "\n\nRight-Click to end the effect. (If the effect says \"up to\", for example)");
			_SIG_EndEffect = bEnd;
			_SIG_Constraint = constr;
			_SIG_fnc_end = fnc_end;
		}
	}
	
	public bool SelectInGuard_Pointer(bool bCancelAllowed = false)
	{
		if(_SIG_Active)
		{
			if(CancelInput() && bCancelAllowed)
			{
				_SIG_Active = false;
				ClearPointer(_SIG_EndEffect);
				if(_SIG_fnc_end != null)
				{
					_SIG_fnc_end();
				}				
			}
			
			if(AcceptInput())
			{
				Guardian = Game.LastGuardCardSelected;
				
				if(Guardian != null) Game.GameChat.AddChatMessage("ADMIN", Guardian.cardID + "");
				else Game.GameChat.AddChatMessage("ADMIN", "Guardian = null");
				
				if(Guardian != null && (_SIG_Constraint == null || _SIG_Constraint()))
				{
					_SIG_fnc();
					_SIG_n--;
					if(_SIG_n <= 0)
					{
						_SIG_Active = false;
						ClearPointer(_SIG_EndEffect);
						if(_SIG_fnc_end != null)
						{
							_SIG_fnc_end();
						}
					}
				}
			}
			
			return true;
		}
		
		return false;
	}
	
	public void RetireEnemyGuardian(Card c)
	{
		//Game.GameChat.AddChatMessage("ADMIN", "Retiring: " + c.cardID);
		
		int id = Game.guardZone.cards.IndexOf(c);
		Game.guardZone.Remove(c);
		Game.SendPacket(GameAction.ENEMY_REMOVE_FROM_GUARDIAN, id); 
	}

	Card FromBindToDeck_Card = null;
	bool FromBindToDeck_Active = false;
	bool FromBindToDeck_toBottom = false;
	
	public void FromBindToDeck(Card c, bool toBottom = false)
	{
		Vector3 newPosition = Game.field.fieldInfo.GetPosition((int)fieldPositions.DECK_ZONE);
		c.FromBindTo(newPosition);
		FromBindToDeck_Card = c;
		FromBindToDeck_Active = true;
		FromBindToDeck_toBottom = toBottom;
		Game.SendPacket (GameAction.FROM_BIND_TO_DECK, c.cardID);
	}
	
	public void FromBindToDeckUpdate(Void0ParamsDelegate fnc)
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
	public void BindFromDeck(List<Card> L)
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
	public void BindFromDeckUpdate(Void0ParamsDelegate func)
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

	public void SelectUnit(string msg, int n, bool bEnd, Void0ParamsDelegate fnc, delegateConstraint constr, Void0ParamsDelegate fnc_end, bool bVC = false)
	{
		if(n == 0)
		{
			fnc_end();
			if(bEnd)
			{
				EndEffect();	
			}
		}
		else
		{
			_SU_n = n;
			_SU_fnc = fnc;
			_SU_Active = true;
			EnableMouse(msg + "\n\nRight-Click to end the effect. (If the effect says \"up to\", for example)");
			_SU_EndEffect = bEnd;
			_SU_constraint = constr;
			_SU_fnc_end = fnc_end;
			bSelectVanguard = bVC;
		}
	}
	
	public bool SelectUnit_Pointer(bool bCancelAllowed = false)
	{
		if(_SU_Active)
		{
			if(CancelInput() && bCancelAllowed)
			{
				_SU_Active = false;
				ClearPointer(_SU_EndEffect);
				if(_SU_fnc_end != null)
				{
					_SU_fnc_end();
				}				
			}
			
			if(AcceptInput())
			{
				fieldPositions p = Util.GetMousePosition();
				if(IsRearGuard(p) || (bSelectVanguard && p == fieldPositions.VANGUARD_CIRCLE))
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

	public EnemyPhase GetEnemyPhase()
	{
		return Game.enemyPhase;
	}
	
	public bool OpenRC()
	{
		return Game.field.ThereIsOpenRC();
	}
	
	public void OpponentRetireUnit()
	{
		Game.ownerCardCallEvent = OwnerCard;
		Game.SendPacket(GameAction.OPPONENT_RETIRE_UNIT);	
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

	public void PerformAdditionalDriveCheck()
	{
		Game.bPerformAdditionalDriveCheck = true;
	}

	public void FromDriveToDrop(Card c)
	{
		Game.SendPacket(GameAction.FROM_DRIVE_TO_DROP);
		Game.field.AddToDropZone(c);
		Game.bIgnoreDriveToHand = true;
	}
	
	public void DrawCardWithoutDelay()
	{
		Game.playerHand.AddToHand(Game.playerDeck.DrawCard());
		Game.SendPacket(GameAction.DRAW_FROM_DECK, 1);	
		Game.field.CheckAbilities(CardState.Draw);
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

	public void OpponentOpenDecisionWindow(string text)
	{
		Game.ownerCardCallEvent = OwnerCard;
		Game.SendPacket (GameAction.OPEN_DECISIONWINDOW, OwnerCard.pos, id, text);
	}
	
	public bool IsRearGuard(fieldPositions p)
	{
		return !Util.IsEnemyPosition(p) && p != fieldPositions.VANGUARD_CIRCLE;
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
	
	public bool VanguardIs(string clan)
	{
		return GetVanguard().BelongsToClan(clan);
	}

	public bool _FLIPUP_Active = false;

	public void Flipup(int n, CounterBlastDelegate fnc)
	{
		_CB_num = n;
		
		if(Game.field.GetNumberOfDamageCardsFacedown() == n)
		{
			UnflipCardInDamageZone(n);
			fnc();
		}
		else
		{
			_FLIPUP_Active = true;
			_CB_fnc = fnc;
			EnableMouse("Choose " + _CB_num + " face-down cards from your damage zone.");
		}
	}
	
	public bool Flipup_Pointer(bool bCancelAllowed = false)
	{
		if(_FLIPUP_Active)
		{
			if(CancelInput() && bCancelAllowed)
			{
				_FLIPUP_Active = false;
				ClearPointer(false);
				_CB_fnc();
			}
			
			if(AcceptInput())
			{
				Card c = Game.LastDamageCardSelected;
				if(c != null && c._HandleMouse.mouseOn && !c.IsFaceup())
				{
					FlipupCard(c);
					_CB_num--;
					if(_CB_num <= 0)
					{
						_FLIPUP_Active = false;
						ClearPointer(false);	
						_CB_fnc();
					}
				}
			}
			
			return true;
		}
		
		return false;
	}

	public void FlipupCard(Card c)
	{
		c.TurnUp();
		Game.SendPacket(GameAction.FLIPUP, Game.field.GetDamageIndexOf(c));
	}

	public int GetFaceupDamage()
	{
		return Game.field.GetNumberOfDamageCardsFaceup();	
	}
	
	public int GetFacedownDamage()
	{
		return Game.field.GetNumberOfDamageCardsFacedown();
	}

	public void EnemyHasToDiscardOneCard()
	{
		//Game.SendConfirmation();
		Game.ownerCardCallEvent = OwnerCard;
		Game.SendPacket (GameAction.REGISTER_ID, id);
		Game.SendPacket(GameAction.ALLY_DISCARD);
		//Game.WaitForOponnent();	
	}

	public void OpponentBindHandCardFaceDownReturnEndTurn()
	{
		Game.SendPacket(GameAction.BIND_HAND_FACEDOWN_RETURN_ENDTURN);
	}

	public bool CanSoulBlast(int n) 
	{
		return Game.field.GetNumberOfCardsInSoul() >= n;	
	}

    public bool CanSoulBlast(int n, boolCardFunction f)
    {
        int count = 0;
        for (int i = 0; i < Game.field.Soul.Count - 1; i++)
        {
            Card tmp = Game.field.Soul[i];
            if (f(tmp))
            {
                count++;
            }
        }
        return count >= n;
    }
	
	public int HandSize()
	{
		return Game.playerHand.Size();
	}
	
	public int HandSize(boolCardFunction f)
	{
		int count = 0;
		for(int i = 0; i < HandSize(); i++)
		{
			Card c = Game.playerHand.GetCardAtIndex(i);
			if(c != null && f(c)) count++;
		}
		return count;
	}
	
	public void CallFromHand(Card c)
	{
		_CFH_Active = true;
		Game.CallFromHand(c);	
	}
	
	public void CallFromHandUpdate(Void0ParamsDelegate f)
	{
		if(_CFH_Active)
		{
			if(Game._MouseHelper.GetAttachedCard() == null)
			{
				_CFH_Active = false;
				f();
			}
			else
			{
				Game.HandleCallFromHand();
			}
		}	
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
						_SBAux_Card1.CheckAbilities(CardState.DropFromSoul);
						Game.field.CheckAbilitiesExcept(_SBAux_Card1.pos, CardState.DropFromSoul_NotMe, _SBAux_Card1);
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
	
	public void SelectInHand(int n, bool bEnd, Void0ParamsDelegate fnc, delegateConstraint constraint, Void0ParamsDelegate fnc_end, string msg)
	{
		_SIH_n = n;
		_SIH_Active = true;
		_SIH_fnc = fnc;
		_SIH_constraint = constraint;
		_SIH_fnc_end = fnc_end;
		_SIH_End = bEnd;
		EnableMouse(msg);
	}
	
	public bool SelectInHand_Pointer(bool bForceEnd = false, Void0ParamsDelegate newEndFunction = null)
	{
		if(_SIH_Active)
		{
			if(CancelInput() && bForceEnd)
			{
				ClearPointer(_SIH_End);
				_SIH_Active = false;

				if(newEndFunction == null)
				{
					_SIH_fnc_end();
				}
				else
				{
					newEndFunction();
				}
			}
			
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

	public Card _SIEH_Card = null;
	int _SIEH_n = 0;
	bool _SIEH_Active = false;
	Void0ParamsDelegate _SIEH_fnc = null;
	delegateConstraint _SIEH_constraint = null;
	bool _SIEH_End = false;
	Void0ParamsDelegate _SIEH_fnc_end = null;

	public void SelectInEnemyHand(int n, bool bEnd, Void0ParamsDelegate fnc, delegateConstraint constraint, Void0ParamsDelegate fnc_end, string msg)
	{
		_SIEH_n = n;
		_SIEH_Active = true;
		_SIEH_fnc = fnc;
		_SIEH_constraint = constraint;
		_SIEH_fnc_end = fnc_end;
		_SIEH_End = bEnd;
		EnableMouse(msg);
	}
	
	public bool SelectInEnemyHand_Pointer(bool bForceEnd = false, Void0ParamsDelegate newEndFunction = null)
	{
		if(_SIEH_Active)
		{
			if(CancelInput() && bForceEnd)
			{
				ClearPointer(_SIEH_End);
				_SIEH_Active = false;
				
				if(newEndFunction == null)
				{
					_SIEH_fnc_end();
				}
				else
				{
					newEndFunction();
				}
			}
			
			if(AcceptInput())
			{
				_SIEH_Card = Game.LastEnemyHandSelected;
				if(_SIEH_Card != null && _SIEH_Card._HandleEnemyMouse.mouseOn && _SIEH_constraint())
				{
					_SIEH_fnc();
					_SIEH_n--;
					if(_SIEH_n <= 0)
					{
						ClearPointer(_SIEH_End);
						_SIEH_Active = false;
						_SIEH_fnc_end();
					}
				}
			}
		}
		
		return _SIH_Active;
	}
	
	public Card DiscardSelectedCard()
	{
		Card tmp = Game.playerHand.GetCurrentCardObject();
		Game.playerHand.RemoveFromHand(Game.playerHand.GetCurrentCard());
		Game.field.AddToDropZone(tmp);
		Game.SendPacket (GameAction.ENEMY_DISCARD, tmp.cardID);	
		return tmp;
	}
	
	public void UnflipCardInDamageZone(int num)
	{
		while(num-- != 0)
		{
			Game.field.UnflipDamageZoneCard();
			Game.SendPacket(GameAction.UNFLIPDAMAGE);	
		}
	}
	
	/**
	 * When the player puts her/his mouse over a card in hand. That card is stored and can be retrieved with this function.
	 */
	public Card HandSelectedCard()
	{
		return Game.playerHand.GetCurrentCardObject();	
	}

	public void RideFromDropZone(Card _card)
	{
		Game.field.RemoveFromDropzone(_card);
		Game.field.Ride (_card);
		Game.SendPacket(GameAction.RIDE_FROM_DROP, _card.cardID);
	}
	
	public bool ValidHand(Card c)
	{	
		return c != null && c._HandleMouse.mouseOn;
	}
	
	public int CardsInSoul()
	{
		return Game.field.GetNumberOfCardsInSoul();	
	}
	
	public int NumUnitsDrop(boolCardFunction f)
	{
		int num = 0;
		for(int i = 0; i < Game.field.DropZone.Count; i++)
		{
			if(f == null || f(Game.field.DropZone[i]))
			{
				num++;	
			}
		}
		return num;
	}

	public int NumUnitsInSoul(boolCardFunction f)
	{
		int num = 0;
		for(int i = 0; i < Game.field.Soul.Count - 1; i++)
		{
			if(f == null || f(Game.field.Soul[i]))
			{
				num++;	
			}
		}
		return num;
	}

	public int NumUnitsInBind(boolCardFunction f)
	{
		int num = 0;
		for(int i = 0; i < Game.field.BindZone.Count; i++)
		{
			if(f == null || f(Game.field.BindZone[i]))
			{
				num++;	
			}
		}
		return num;
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

	public bool FromHandToBind_Bool1 = false;
	public Card FromHandToBind_Card = null;
	public bool FromHandToBind_Facedown = false;
	
	public void FromHandToBind(Card c, int position, bool bFaceDown = false)
	{
		FromHandToBind_Bool1 = true;
		FromHandToBind_Card = c;
		FromHandToBind_Facedown = bFaceDown;
		Game.FromHandToBind(c, position, bFaceDown);
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
					if(FromHandToBind_Facedown)
					{
						FromHandToBind_Card.TurnDown();
					}
				}
				
				FromHandToBind_Bool1 = false;
				FromHandToBind_Card = null;
				func();
			}
		}
	}

	public Card SendCardFromDeckToDrop()
	{
		Card tmp = Game.playerDeck.DrawCard();
		tmp.TurnUp();
		Game.field.AddToDropZone(tmp);
		Game.SendPacket(GameAction.FROM_DECK_TO_DROP, tmp.cardID);
		
		return tmp;
	}

	Card  millCard = null;
	int   millNum = 0;
	bool  millActive = false;
	float millTime = 0;
	float currMillTime = 0;

	public void Mill(int n)
	{
		millNum = n;
		millActive = true;
		millTime = 0.5f;
		currMillTime = millTime;
	}

	public void MillUpdate(Void0ParamsDelegate f)
	{
		if(millActive)
		{
			currMillTime -= Time.deltaTime;
			if(millCard == null || currMillTime <= 0)
			{
				if(millNum <= 0)
				{
					millActive = false;
					f();
				}
				else
				{
					millCard = SendCardFromDeckToDrop();
					currMillTime = millTime;
					millNum--;
				}
			}
		}
	}

	public void FromBindToHand(Card c)
	{
		Game.field.RemoveFromBindZone(c);
		Game.playerHand.AddToHand(c);
		ShowCardInHand(c);
		Game.SendPacket(GameAction.FROM_BIND_TO_HAND);
	}
	
	public bool IsFrontRow(Card c, bool bVanguard = false)
	{
		if(bVanguard) 
		{
			return c.pos == fieldPositions.ENEMY_FRONT_LEFT || c.pos == fieldPositions.ENEMY_FRONT_RIGHT || c.pos == fieldPositions.ENEMY_VANGUARD;	
		}
		else
		{
			return c.pos == fieldPositions.ENEMY_FRONT_LEFT || c.pos == fieldPositions.ENEMY_FRONT_RIGHT;	
		}
	}
	
	public Card FromHandToDeck(Card c, bool bottom = false, bool shuffle = true)
	{
		int position = Game.playerHand.GetIndexOf(c);
		Game.playerHand.RemoveFromHand(c);
		Game.playerHand.FixPositions();
		
		if(!bottom)
		{
			Game.playerDeck.AddCard(c);
		}
		else 
		{
			Game.playerDeck.AddToBottom(c);	
		}
		
		if(shuffle)
		{
			Game.playerDeck.Shuffle();
		}
		
		Game.SendPacket (GameAction.FROM_HAND_TO_DECK, position);	
		return c;
	}


	positionFunction _SORC_f = null;
	bool _SORC_Active = false;

	public void SelectOpenRC(positionFunction f)
	{
		_SORC_f = f;
		_SORC_Active = true;
		EnableMouse("Choose one of your open (RC).");
	}

	public void SelectOpenRC_Pointer()
	{
		if(_SORC_Active)
		{
			if(AcceptInput())
			{
				fieldPositions p = Game.LastOpenRC;
				if(p != fieldPositions.DECK_ZONE && p != fieldPositions.VANGUARD_CIRCLE)
				{
					_SORC_Active = false;
					ClearPointer(false);
					_SORC_f(p);
				}
			}
		}
	}

	boolCardFunction _SID_Constraint = null;
	Void0ParamsDelegate _SID_EndFnc = null;

	public void SelectInDamage(int n, bool bEnd, Void0ParamsDelegate fnc, boolCardFunction bcf = null, Void0ParamsDelegate efnc = null)
	{
		_SID_n = n;
		_SID_Active = true;
		_SID_fnc = fnc;
		_SID_End = bEnd;
		_SID_Constraint = bcf;
		_SID_EndFnc = efnc;
		EnableMouse("Choose a card from your damage zone.");
	}
	
	public bool SelectInDamage_Pointer()
	{
		if(_SID_Active)
		{
			if(AcceptInput())
			{
				_SID_Card = Game.LastDamageCardSelected;
				if(ValidHand(_SID_Card) && (_SID_Constraint == null || _SID_Constraint(_SID_Card)))
				{
					_SID_fnc();
					_SID_n--;
					if(_SID_n <= 0)
					{
						ClearPointer(_SID_End);
						_SID_Active = false;
						if(_SID_EndFnc != null)
						{
							_SID_EndFnc();
						}
					}
				}
			}
		}
		
		return _SID_Active;
	}

	boolCardFunction _ESID_Constraint = null;
	Void0ParamsDelegate _ESID_EndFnc = null;
	int _ESID_n;
	bool _ESID_Active = false;
	Void0ParamsDelegate _ESID_fnc;
	public Card _ESID_Card = null;
	bool _ESID_End;
	
	public void SelectInEnemyDamage(int n, bool bEnd, Void0ParamsDelegate fnc, boolCardFunction bcf = null, Void0ParamsDelegate efnc = null)
	{
		_ESID_n = n;
		_ESID_Active = true;
		_ESID_fnc = fnc;
		_ESID_End = bEnd;
		_ESID_Constraint = bcf;
		_ESID_EndFnc = efnc;
		EnableMouse("Choose a card from your opponent's damage zone.");
	}
	
	public bool SelectInEnemyDamage_Pointer()
	{
		if(_ESID_Active)
		{
			if(AcceptInput())
			{
				_ESID_Card = Game.LastEnemyDamageCardSelected;
				if(_ESID_Card != null && _ESID_Card._HandleEnemyMouse.mouseOn && (_ESID_Constraint == null || _ESID_Constraint(_ESID_Card)))
				{
					_ESID_fnc();
					_ESID_n--;
					if(_ESID_n <= 0)
					{
						ClearPointer(_ESID_End);
						_ESID_Active = false;
						if(_ESID_EndFnc != null)
						{
							_ESID_EndFnc();
						}
					}
				}
			}
		}
		
		return _ESID_Active;
	}

	public void CallFromDamage(Card c)
	{
		Game.CallFromDamage(c);	
		_CFDamage_Active = true;
	}
	
	public void CallFromDamageUpdate(Void0ParamsDelegate fnc)
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

	public void FromDamageToDrop(Card c)
	{
		int idx = Game.field.GetDamageIndexOf(c);
		Game.field.RemoveFromDamage(c);	
		Game.field.AddToDropZone(c);
		Game.SendPacket(GameAction.FROM_DAMAGE_TO_DROP, idx);
	}

	public void FromDamageToSoul(Card c)
	{
		int idx = Game.field.GetDamageIndexOf(c);
		Game.field.RemoveFromDamage(c);
		//Game.field.AddToSoul(OwnerCard);
		Game.field.MoveToSoul(c);
		Game.SendPacket (GameAction.FROM_DAMAGE_TO_SOUL, idx);
	}

	public void DoDamageToVanguard()
	{
		Game.SendPacket(GameAction.FORCE_DAMAGE_CHECK, 1);
	}

	public void FromDamageToDeck(Card c, bool bBottom = false)
	{
		int idx = Game.field.GetDamageIndexOf(c);
		Game.field.RemoveFromDamage(c);

		if(bBottom)
		{
			Game.playerDeck.AddToBottom(c);
		}
		else
		{
			Game.playerDeck.AddCard(c);
		}

		Game.playerDeck.SetDeckPosition();
		//c.TurnUp();
		Game.SendPacket(GameAction.FROM_DAMAGE_TO_DECK, idx);		
	}
	
	public void FromDeckToDamage(Card c, bool bFaceup = false)
	{
		Game.playerDeck.RemoveFromDeck(c);
		Game.field.AddToDamageZone(c);
		if(bFaceup)
		{
			c.TurnUp();
			Game.SendPacket(GameAction.FROM_DECK_TO_DAMAGE_FACEUP, c.cardID);
		}
		else
		{
			c.TurnDown();
			Game.SendPacket(GameAction.FROM_DECK_TO_DAMAGE, c.cardID);
		}
	}

	public void FromDamageToHand(Card c)
	{
		int idx = Game.field.GetDamageIndexOf(c);
		Game.field.RemoveFromDamage(c);
		Game.playerHand.AddToHand(c);
		Game.SendPacket(GameAction.FROM_DAMAGE_TO_HAND, idx);
		ShowCardInHand(c);
	}

	public void Forerunner(string clan)
	{
		if(GetVanguard().clan == clan)
		{
			DisplayConfirmationWindow();	
		}
	}
	
	public void Forerunner_Active()
	{
		ShowOnScreen();
		CallFromSoul(OwnerCard);	
	}
	
	public void Forerunner_Update()
	{
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
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
	
	public void FromDeckToHand(CardIdentifier id)
	{
		Card tmpCard = Game.playerDeck.RemoveFromDeck(Game.playerDeck.SearchForID_GetIndex(id));
		Game.SendPacket(GameAction.DRAW_FROM_DECK, 1);
		Game.playerHand.AddToHand(tmpCard);
		Game.SendPacket(GameAction.SHOW_CARD_HAND, tmpCard.cardID, Game.playerHand.Size() - 1);
	}
	
	public Card RevealTopCard(bool bShowToOpponent = true)
	{
		GetDeck().SetDeckPosition();
		Card toRet = Game.playerDeck.TopCard();
		toRet.TurnUp();
		if(bShowToOpponent) {
			Game.SendPacket(GameAction.REVEAL_TOP_CARD, toRet.cardID);	
		}	
		return toRet;
	}
	
	public void HideTopCard()
	{
		Game.playerDeck.TopCard().TurnDown();
		Game.SendPacket(GameAction.HIDE_TOP_CARD);
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
	
	public void AddPowerToGuardZone(int power)
	{
		AddExtraShield(power);
		Game.guardZone.AddExtraPower(power);
		Game.SendPacket(GameAction.ADD_POWER_TO_GUARDZONE, power);
	}
	
	/**
	 * Add an amount equal to "shield" to the power of the unit currenty being attacked.
	 */
	public void AddExtraShield(int shield)
	{
		GetDefensor().AddExtraShield(shield);
		Game.SendPacket(GameAction.ADD_EXTRA_SHIELD, shield);
	}
	
	public bool CurrentPhaseIs(GamePhase phase)
	{
		if(Game.gamePhase == phase)
		{
			return true;	
		}
		
		return false;
	}
	
	public void FromDropToHand(Card c)
	{
		Game.field.RemoveFromDropzone(c);
		Game.playerHand.AddToHand(c);
		Game.SendPacket(GameAction.FROM_DROP_TO_HAND, c.cardID);
	}
	
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
	
	public void OpenSelectionList(Card owner, List<string> options, string title)
	{
		Game._SelectionListWindow.SetCaption(title);
		Game._SelectionListWindow.Set(OwnerCard, owner, options);	
	}
	
	public void OpenSelectionCardNameList(Card owner, string title, DelegateCardNameWindow.f fnc = null)
	{
		Game._SelectionCardNameWindow.SetCaption(title);
		if(fnc != null)
		{
			Game._SelectionCardNameWindow.SetConstraint(fnc);
		}
		Game._SelectionCardNameWindow.Set(owner);
	}
	
	public void RemoveCONTAbility(Card c, string option)
	{
		c.RemoveCONTAbility(option);
		SendMessageToOpponent(c.name + " has lost: [CONT]" + option + " until end of turn.");
	}
	
	public void SendMessageToOpponent(string message)
	{
		Game.SendPacket(GameAction.MESSAGE, message);	
	}
	
	public bool BindEnemyUnit(Card c)
	{
		Game.SendPacket(GameAction.SEND_TO_BINDZONE_ALLY, c.pos);
		Game.enemyField.RemoveFrom(Util.TransformToEquivalentEnemyPosition(c.pos));
		Game.enemyField.AddToBindZone(c);
		c.BindAnim();
		return true;
	}

	public void OpponentFromBindToHand(Card c)
	{
		Game.SendPacket(GameAction.ENEMY_FROM_BIND_TO_HAND, c.cardID);
	}

	public void ForEachUnitOnField(cardFunction f)
	{
		Game.field.InitFieldIterator();
		while(Game.field.HasNextField())
		{
			Card tmp = Game.field.CurrentFieldCard();
			if(tmp != null)
			{
				f(tmp);	
			}
		}
	}
	
	public void ForEachEnemyUnitOnField(cardFunction f)
	{
		Card tmp;
		tmp = Game.enemyField.GetCardAt(EnemyFieldPosition.FRONT_LEFT); if(tmp != null) f(tmp);
		tmp = Game.enemyField.GetCardAt(EnemyFieldPosition.FRONT_RIGHT); if(tmp != null) f(tmp);
		tmp = Game.enemyField.GetCardAt(EnemyFieldPosition.VANGUARD); if(tmp != null) f(tmp);
		tmp = Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_LEFT); if(tmp != null) f(tmp);
		tmp = Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_RIGHT); if(tmp != null) f(tmp);
		tmp = Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_CENTER); if(tmp != null) f(tmp);
	}
	
	public void CreateSaveCardStore()
	{
		_SaveCards = new List<Card>();	
	}
	
	public void SaveCard(Card c)
	{
		_SaveCards.Add(c);	
	}
	
	public void ForEachSavedCard(cardFunction f)
	{
		for(int i = 0; i < _SaveCards.Count; i++)
		{
			f(_SaveCards[i]);	
		}
	}
	
	public List<Card> GetSavedCardsList()
	{
		return _SaveCards;	
	}
	
	public void AddToHelpZone(Card c)
	{
		Game.field.AddToHelpZone(c);	
	}
	
	public void RemoveFromHelpZone(Card c)
	{
		Game.field.RemoveFromHelpZone(c);	
	}
	
	public void ForceOpponentToCallFromBind(int quantity, List<Card> allowedCards)
	{
		Game.SendPacket(GameAction.CREATE_AUXILIAR_INT_ARRAY);
		for(int i = 0; i < allowedCards.Count; i++)
		{
			Game.SendPacket(GameAction.ADD_TO_INT_ARRAY, (int)allowedCards[i].cardID);	
		}
		Game.SendPacket (GameAction.FORCE_CALL_FROM_BIND, quantity);
		Game.SendConfirmation();
	}
	
	public void ShowCardInHand(Card card, int position = -1)
	{
		int handPosition = position;
		if(handPosition == -1)
		{
			handPosition = Game.playerHand.GetCurrentCard();
		}
		
		Game.SendPacket(GameAction.SHOW_CARD_HAND, card.cardID, handPosition);	
	}
	
	public void BlockIntercept()
	{
		Game.SendPacket(GameAction.BLOCK_INTERCEPT_UNTIL_ENDBATTLE);	
	}
	
	public bool IsInSoul(CardIdentifier id)
	{
		return 	Game.field.GetSoulByID(id) != null;
	}
	
	/**
	 * Move a card on the field to the deck
	 */
	public void FromFieldToDeck(Card c, bool bBottom = false)
	{
		Game.SendPacket(GameAction.RETURN_FROM_FIELD_TO_DECK, c.pos);
		Game.field.RemoveFrom(c.pos);
		c.SetRotation(0,180,0);
		c.TurnDown();
		Game.playerDeck.ReturnToDeck(c, bBottom);		
	}
	
	public PlayerHand GetHand()
	{
		return Game.playerHand;	
	}
		
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
	
	public EnemyHand GetEnemyHand()
	{
		return Game.enemyHand;	
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

	public fieldPositions GetSameColumPosition(fieldPositions p)
	{
		if(p == fieldPositions.VANGUARD_CIRCLE)   return fieldPositions.REAR_GUARD_CENTER;
		if(p == fieldPositions.FRONT_GUARD_LEFT)  return fieldPositions.REAR_GUARD_LEFT;
		if(p == fieldPositions.FRONT_GUARD_RIGHT) return fieldPositions.REAR_GUARD_RIGHT;
		if(p == fieldPositions.REAR_GUARD_LEFT)   return fieldPositions.FRONT_GUARD_LEFT;
		if(p == fieldPositions.REAR_GUARD_RIGHT)  return fieldPositions.FRONT_GUARD_RIGHT;
		if(p == fieldPositions.REAR_GUARD_CENTER) return fieldPositions.VANGUARD_CIRCLE;
		return fieldPositions.DECK_ZONE;
	}
	
	public void RetireEnemyUnit(Card card)
	{
		if(!card.bCanBeRetireByEffects)
		{
			SelectAnimField(card);
			return;
		}

		card.retireUnitOwner = OwnerCard;

		/*
		Game._AbilityManager.AddAbility(CardState.EnemyTurn_FromRCToDrop, card);
		Game.SendPacket(GameAction.ADD_CARD_TO_ABILITYSTACK, card.pos);
		*/
		
		Game.enemyField.ClearZone(Util.TransformToEquivalentEnemyPosition(card.pos));
		Game.enemyField.AddToDropZone(card, true);		
		Game.SendPacket(GameAction.SEND_TO_DROPZONE_ALLY, card.pos);	
		
		Game.playerHand.CheckHandEffects(CardState.Hand_EnemyToDropFromRG);
		Game.field.CheckAbilities(CardState.EnemyCardSendToDropZone);
	}
	
	public void StandUnit(Card card)
	{
		card.bBecomeStandThisTurn = true;
		card.Stand();
		Game.SendPacket(GameAction.STAND_UNIT, card.pos);
		card.CheckAbilities(CardState.Stand, card);
		Game.field.CheckAbilitiesExcept(card.pos, CardState.Stand_NotMe, card);
	}
	
	public void OnlyOpenRC(bool b)
	{
		Game.bBlockUnitReplacing = b;	
	}
	
	public void RestUnit(Card card)
	{
		Game.LastRest = card;
		
		card.Rest();
		Game.SendPacket(GameAction.REST_UNIT, card.pos);
		
		card.CheckAbilities(CardState.Rest);
		Game.field.CheckAbilitiesExcept(card.pos, CardState.Rest_NotMe);
	}
	
	public void IncreasePowerAndCriticalByTurn(Card card, int power, int critical)
	{
		card.IncreasePowerUntilEndTurn(power);
		Game.SendPacket(GameAction.INCREASE_POWER_END_TURN, card.pos, power);
		card.IncreaseCriticalUntilEndTurn(critical);
		Game.SendPacket(GameAction.INCREASE_CRITICAL_END_TURN, card.pos, critical);
	}
	
	public void ReturnToHand(Card c)
	{
		bool bIsVanguard = c.IsVanguard();
		fieldPositions cardPos = c.pos;
		Game.SendPacket(GameAction.RETURN_FROM_FIELD_TO_HAND, c.pos);
		Game.field.RemoveFrom(c.pos);
		Game.playerHand.AddToHand(c);
		if(!bIsVanguard)
		{
			c.CheckAbilities(CardState.HandFromRear);

			//Game.GameChat.AddChatMessage("ADMIN", c.name + " returns to hand." + " " + cardPos);

			Game.field.CheckAbilitiesExcept(cardPos, CardState.HandFromRear_NotMe, c);
		}
	}
	
	/**
	 * Increase the critical of "c" in an amount equal to "critical"
	 */
	public void IncreaseCriticalByBattle(Card c, int critical)
	{
		c.IncreaseCritical(critical);	
		Game.SendPacket(GameAction.CRITICAL_INCREASE, c.pos, critical);
	}
	
	public bool IsInFrontRow(Card c)
	{
		return c.pos == fieldPositions.FRONT_GUARD_RIGHT || c.pos == fieldPositions.VANGUARD_CIRCLE || c.pos == fieldPositions.FRONT_GUARD_LEFT;	
	}
	
	public bool IsInBackRow(Card c)
	{
		return c.pos == fieldPositions.REAR_GUARD_LEFT || c.pos == fieldPositions.REAR_GUARD_CENTER || c.pos == fieldPositions.REAR_GUARD_RIGHT;	
	}
	
	public void SoulChargeFromDrop(Card card)
	{
		card.Stand();
		Game.field.MoveToSoul(card);
		Game.field.RemoveFromDropzone(card);
		Game.field.FixSoulPosition();
		Game.SendPacket(GameAction.FROM_DROP_TO_SOUL, card.cardID);
	}
	
	public Card GetEnemyBackRow(Card c)
	{
		if(c.pos == fieldPositions.ENEMY_FRONT_LEFT)  return Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_LEFT);
		if(c.pos == fieldPositions.ENEMY_FRONT_RIGHT) return Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_RIGHT);
		if(c.pos == fieldPositions.ENEMY_VANGUARD)    return Game.enemyField.GetCardAt(EnemyFieldPosition.REAR_CENTER);
		return null;
	}
	
	public void PerfectGuard()
	{
		Game.SendPacket(GameAction.PERFECT_GUARD);
		Game.guardZone.ActivePerfectGuard();
		GetDefensor().PerfectGuard();
	}
	
	public bool IsInHand(CardIdentifier id)
	{
		return HandSize(delegate(Card c) { return c.cardID == id; }) > 0;	
	}
	
	public void BlockEnemyTriggerEffects()
	{
		Game.SendPacket(GameAction.BLOCK_EFFECT_TRIGGER_THIS_BATTLE);
	}
	
	public void BlockEnemyGuard(int grade)
	{
		Game.SendPacket(GameAction.BLOCK_GUARD_END_BATTLE, grade);	
	}
	
	public void RideFromHand(Card c)
	{
		Game.playerHand.RemoveFromHand(c);
		Game.Ride(c);
	}
}
