using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldGlobalVar
{
	public delegate bool CountConstraint(Card c);
};

public class Field {
	public delegate void OnCardListenedDel(Card c);

	public FieldWatcher fieldWatcher;

	GUIStyle exitBtnStyle = new GUIStyle();
	GUIStyle leftArrowBtnStyle = new GUIStyle();
	GUIStyle rightArrowBtnStyle = new GUIStyle();

	public FieldInformation fieldInfo;
	public Card Vanguard;
	public Card Left_Front;
	public Card Right_Front;
	public Card Left_Rear;
	public Card Right_Rear;
	public Card Center_Rear;
	public List<Card> Soul; //Last Card is the vanguard, not soul.
	private Vector3 delta;
	private TextMesh VanguardPower;
	private TextMesh FrontRightPower;
	private TextMesh FrontLeftPower;
	private TextMesh RearRightPower;
	private TextMesh RearLeftPower;
	private TextMesh RearCenterPower;
	public List<Card> DamageZone;
	public List<Card> DropZone;
	public List<Card> BindZone;
	private List<Card> HelpZone;
	private TextMesh VC;
	private TextMesh FRC;
	private TextMesh FLC;
	private TextMesh RRC;
	private TextMesh RLC;
	private TextMesh RCC;
	List<Card> returnList;
	public bool bCloseEnable = true;
	private Card lastVanguard = null;
	
	public Card LastCardSentToDrop = null;
	public Card LastUnitCalled = null;
	bool bViewSoulMode = false;
	
	private bool bViewingDeck = false;
	private Texture2D ViewBackground;
	private List<Game2DCard> CardsWatching;
	private List<Game2DCard> TotalCards;
	private Gameplay _Game;
	private int cur2DCardSelected;
	private int curOffset;
	private int numSelections = 0;
	private List<CardIdentifier> CardSelectedVector; 
	private bool bViewMode = false;
	private bool bViewDropZoneMode = false;
	
	private GameObject CriticalLeft = null;
	private GameObject CriticalVanguard = null;
	private GameObject CriticalRight = null;
	
	private GameObject CallEffect = null;
	private bool bCallEffectAnimation = false;
	private float CallEffect_Scale = 10;
	private float CallEffect_SpeedScale = 1.0045f;
	private float CallEffectTimer = 0;
	private float MaxTimeCallEffect = 2;
	
	private int CurrentSoulIter = 0;
	private int CurrentFieldIter = 0;
	
	public Field(Gameplay game)
	{	
		CriticalLeft = GameObject.FindGameObjectWithTag("CriticalFrontLeft");
		CriticalVanguard = GameObject.FindGameObjectWithTag("CriticalVanguard");
		CriticalRight = GameObject.FindGameObjectWithTag("CriticalFrontRight");
		returnList = new List<Card>();
		CallEffect = GameObject.FindGameObjectWithTag("CallEffect");
		
		fieldInfo = new FieldInformation();
		Soul      = new List<Card>();
		Vanguard  = null;
		Left_Rear = null;
		Left_Front = null;
		Center_Rear = null;
		Right_Rear = null;
		Left_Rear = null;
		delta     = new Vector3(0.0f, 0.06f, 0.0f);

		VanguardPower   = (TextMesh)GameObject.FindGameObjectWithTag("VanguardPowerText").GetComponent("TextMesh");
		FrontRightPower = (TextMesh)GameObject.FindGameObjectWithTag("FrontRightPowerText").GetComponent("TextMesh");
		FrontLeftPower  = (TextMesh)GameObject.FindGameObjectWithTag("FrontLeftPowerText").GetComponent("TextMesh");
		RearRightPower  = (TextMesh)GameObject.FindGameObjectWithTag("RearRightPowerText").GetComponent("TextMesh");
		RearLeftPower   = (TextMesh)GameObject.FindGameObjectWithTag("RearLeftPowerText").GetComponent("TextMesh");
		RearCenterPower = (TextMesh)GameObject.FindGameObjectWithTag("RearCenterPowerText").GetComponent("TextMesh");
		VC  = (TextMesh)GameObject.FindGameObjectWithTag("VC").GetComponent("TextMesh");
		FRC = (TextMesh)GameObject.FindGameObjectWithTag("FRC").GetComponent("TextMesh");
		FLC = (TextMesh)GameObject.FindGameObjectWithTag("FLC").GetComponent("TextMesh");
		RRC = (TextMesh)GameObject.FindGameObjectWithTag("RRC").GetComponent("TextMesh");
		RLC = (TextMesh)GameObject.FindGameObjectWithTag("RLC").GetComponent("TextMesh");
		RCC = (TextMesh)GameObject.FindGameObjectWithTag("RCC").GetComponent("TextMesh");
		VC.text = "";
		FRC.text = "";
		FLC.text = "";
		RRC.text = "";
		RLC.text = "";
		RCC.text = "";
				
		VanguardPower.text    = "";
		FrontRightPower.text  = "";
		FrontLeftPower.text   = "";
		RearRightPower.text   = "";
		RearLeftPower.text    = "";
		RearCenterPower.text  = "";
		
		DamageZone = new List<Card>();
		DropZone   = new List<Card>();
		BindZone   = new List<Card>();
		
		VanguardPower.renderer.material.color   = Color.yellow;
		FrontRightPower.renderer.material.color = Color.yellow;
		FrontLeftPower.renderer.material.color  = Color.yellow;
		RearRightPower.renderer.material.color  = Color.yellow;
		RearLeftPower.renderer.material.color   = Color.yellow;
		RearCenterPower.renderer.material.color = Color.yellow;
		
		ViewBackground = Resources.Load ("ViewCardBackground") as Texture2D;
		
		CardsWatching = new List<Game2DCard>();
		TotalCards = new List<Game2DCard>();
		
		_Game = game;
		
		CardSelectedVector = new List<CardIdentifier>();
		fieldWatcher = new FieldWatcher(game);
		HelpZone = new List<Card>();

		exitBtnStyle.normal.background = Resources.Load("GUI/exit") as Texture2D;
		exitBtnStyle.hover.background  = Resources.Load("GUI/exit_hover") as Texture2D;
		
		leftArrowBtnStyle.normal.background = Resources.Load("GUI/left_arrow") as Texture2D;
		leftArrowBtnStyle.hover.background  = Resources.Load("GUI/left_arrow_hover") as Texture2D;
		
		rightArrowBtnStyle.normal.background = Resources.Load("GUI/right_arrow") as Texture2D;
		rightArrowBtnStyle.hover.background  = Resources.Load("GUI/right_arrow_hover") as Texture2D;
	}
	
	public void CheckAbilitiesHelpZone(CardState cs)
	{
		for(int i = 0; i < HelpZone.Count; i++)
		{
			HelpZone[i].CheckAbilities(cs);	
		}
	}
	
	public void CheckAbilitiesBind(CardState cs)
	{
		for(int i = 0; i < BindZone.Count; i++)
		{
			BindZone[i].CheckAbilities(cs);	
		}
	}
	
	public void AddToHelpZone(Card c)
	{
		HelpZone.Add(c);
	}	

	public Card GetDamageAtIndex(int index)
	{
		return DamageZone[index];
	}
	
	public void RemoveFromHelpZone(Card c)
	{
		HelpZone.Remove(c);	
	}
	
	public void AddToBindZone(Card c)
	{
		BindZone.Add(c);
		c._Coord = CardCoord.BIND;
	}
	
	public int GetSoulClanAndRace(string clan, string race)
	{
		int num = 0;
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(Soul[i].clan == clan && Soul[i].race == race)
			{
				num++;	
			}
		}
		return num;
	}
	
	public void InitFieldIterator()
	{
		CurrentFieldIter = 0;	
	}
	
	public bool HasNextField()
	{
		return (CurrentFieldIter < 6);
	}
	
	public Card CurrentFieldCard()
	{
		if(CurrentFieldIter == 0)
		{
			CurrentFieldIter++;
			if(Left_Front != null)
			{
				return Left_Front;	
			}
		}
		
		if(CurrentFieldIter == 1)
		{
			CurrentFieldIter++;
			if(Vanguard != null)
			{
				return Vanguard;	
			}
		}
		
		if(CurrentFieldIter == 2)
		{
			CurrentFieldIter++;
			if(Right_Front != null)
			{
				return Right_Front;	
			}
		}
		
		if(CurrentFieldIter == 3)
		{
			CurrentFieldIter++;
			if(Left_Rear != null)
			{
				return Left_Rear;	
			}
		}

		if(CurrentFieldIter == 4)
		{
			CurrentFieldIter++;
			if(Center_Rear != null)
			{
				return Center_Rear;	
			}
		}
		
		if(CurrentFieldIter == 5)
		{
			CurrentFieldIter++;
			if(Right_Rear != null)
			{
				return Right_Rear;	
			}
		}
		
		return null;
	}
	
	public int IsNotClan(string str)
	{
		int num = 0;
		InitFieldIterator();
		while(HasNextField())
		{
			Card c = CurrentFieldCard();
			if(c != null && c.clan != str)
			{
				num++;	
			}
		}
		return num;
	}
	
	public void InitSoulIterator()
	{
		CurrentSoulIter = 0;	
	}
	
	public bool HasNextSoul()
	{
		return CurrentSoulIter < (Soul.Count - 1);	
	}
	
	public Card CurrentSoulCard()
	{
		return Soul[CurrentSoulIter++];
	}
	
	public void CheckBindZoneAbilities(CardState cs)
	{	
		for(int i = 0; i < BindZone.Count; i++)
		{
			Debug.Log(BindZone[i].cardID);
			BindZone[i].CheckAbilities(cs);
		}
	}
	
	public void CallAnimation(Card c)
	{
		if(c != null)
		{
			
			bCallEffectAnimation = true;
			CallEffectTimer = MaxTimeCallEffect;
			CallEffect_Scale = 8;
			CallEffect.renderer.material.color = new Color(CallEffect.renderer.material.color.r, 
														   CallEffect.renderer.material.color.b,
														   CallEffect.renderer.material.color.g,
												  		   1);
			CallEffect.transform.localScale = new Vector3(CallEffect_Scale, 1, CallEffect_Scale);

			if(c.pos == fieldPositions.VANGUARD_CIRCLE || c.pos == fieldPositions.REAR_GUARD_CENTER)
			{
				//CallEffect.transform.position = c.GetGameObject().transform.position + new Vector3(0, -0.55f, 0);
				CallEffect.transform.position = fieldInfo.GetPosition((int)c.pos) + new Vector3(0, -0.55f, 0);
			}
			else
			{
				CallEffect.transform.position = c.GetGameObject().transform.position + new Vector3(0, -0.5f, 0);
			}
		}
	}

	public Card GetLastVanguard()
	{
		return lastVanguard;
	}

	public void Ride(Card card, bool bActiveEvents = true)
	{
		_Game.SendGameChatMessage(card.name + ", Ride!", ChatTab.GAME);
	
		//Reseting current status. 
		ResetCard(card);

		if(Soul.Count > 0)
		{
			Soul[Soul.Count - 1].SetIsVanguard(false);
			Soul[Soul.Count - 1]._Coord = CardCoord.SOUL;
			lastVanguard = Soul[Soul.Count - 1];
		}
		
		Soul.Add (card);	
		card._Coord = CardCoord.FIELD;
		card.SetIsVanguard(true);
		Vanguard = card;

		//Vanguard.GetGameObject().transform.position = fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + delta * (Soul.Count - 1);
		//Vanguard.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();

		Vanguard.MoveAndRotate(fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + delta * (Soul.Count - 1), fieldInfo.GetCardRotation());

		VanguardPower.text = card.GetPower() + "";
		card.pos = fieldPositions.VANGUARD_CIRCLE;
		
		CallAnimation(card);
		FixSoulPosition();
		
		if(Soul.Count > 1 && bActiveEvents)
		{
			Soul[Soul.Count - 2].CheckAbilities(CardState.RideAboveIt);
			Soul[Soul.Count - 2].CheckAbilities(CardState.LeaveField);
		}
		
		CheckAbilitiesDrop(CardState.DropZone_Ride);
		CheckAbilitiesSoul(CardState.Soul_Ride);

		if(bActiveEvents)
		{
			CheckAbilitiesExcept(card.pos, CardState.Ride_NotMe, card);
			card.CheckAbilities(CardState.Ride);
		}
	}

	public void ViewRearGuards(OnCardListenedDel onCardListened)
	{
		if(Left_Front  != null) onCardListened(Left_Front);
		if(Right_Front != null) onCardListened(Right_Front);
		if(Left_Rear   != null) onCardListened(Left_Rear);
		if(Center_Rear != null) onCardListened(Center_Rear);
		if(Right_Rear  != null) onCardListened(Right_Rear);
	}

	public void FixSoulPosition()
	{
		for(int i = 0; i < Soul.Count; i++)
		{
			//Soul[i].GetGameObject().transform.position = fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + delta * i;	

			//Soul[i].MoveAndRotate(fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + delta * i, Soul[i].GetGameObject().r);
			if(i == (Soul.Count - 1) && !Soul[i].IsStand())
			{
				Soul[i].MoveAndRotate(fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + delta * i, new Vector3(Soul[i].GetGameObject().transform.eulerAngles.x, 90, Soul[i].GetGameObject().transform.eulerAngles.z));
			}
			else
			{
				Soul[i].MoveAndRotate(fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + delta * i, fieldInfo.GetCardRotation());
			}
		}
	}
	
	public void AddToSoul(Card card)
	{
		card.NormalizeMaterial();
		
		Soul.Insert(0, card);
		card._Coord = CardCoord.SOUL;
		
		CheckAbilities(CardState.CardPutInSoul);
	}
	
	public void EraseExternFunctions()
	{
		InitFieldIterator();
		while(HasNextField())
		{
			Card c = CurrentFieldCard();
			if(c != null)
			{
				c.unitAbilities.ExternAuto.Clear();
				c.unitAbilities.ExternUpdate.Clear();
			}
		}
	}

	public void ResetCard(Card card)
	{
		//Reseting current status. 
		card.Stand();
		card.unitAbilities.UnsetBool(1);
		card.unitAbilities.UnsetBool(2);
		card.unitAbilities.UnsetBool(3);
		card.unitAbilities.UnsetBool(4);
		card.ResetEndTurnEffects();
		card.ResetPower();
	}
	
	public void Call(Card card, fieldPositions pos)
	{
		_Game.SendGameChatMessage(card.name + ", Call!", ChatTab.GAME);
		_Game.UnitsCalled.Add(card);
		_Game.LastCall = card;

		//Reseting current status. 
		ResetCard(card);

		card._Coord = CardCoord.FIELD;
		card.pos = pos;
		
		if(pos == fieldPositions.FRONT_GUARD_LEFT)
		{
			if(Left_Front != null)
			{
				AddToDropZone(RemoveFrom(pos));	
			}
			
			Left_Front = card;
			Left_Front.GetGameObject().transform.position    = fieldInfo.GetPosition((int)fieldPositions.FRONT_GUARD_LEFT);
			Left_Front.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
			FrontLeftPower.text = card.GetPower() + "";
		}
		else if(pos == fieldPositions.FRONT_GUARD_RIGHT)
		{
			if(Right_Front != null)
			{
				Debug.Log("Adding to DropZone");
				AddToDropZone(RemoveFrom(pos));
			}
			
			Right_Front = card;
			Right_Front.GetGameObject().transform.position    = fieldInfo.GetPosition((int)fieldPositions.FRONT_GUARD_RIGHT);
			Right_Front.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
			FrontRightPower.text = card.GetPower() + "";
		}
		else if(pos == fieldPositions.REAR_GUARD_CENTER)
		{
			if(Center_Rear != null)
				AddToDropZone(RemoveFrom(pos));
			
			Center_Rear = card;
			Center_Rear.GetGameObject().transform.position    = fieldInfo.GetPosition((int)fieldPositions.REAR_GUARD_CENTER);
			Center_Rear.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
			RearCenterPower.text = card.GetPower() + "";
		}
		else if(pos == fieldPositions.REAR_GUARD_LEFT)
		{
			if(Left_Rear != null)
				AddToDropZone(RemoveFrom(pos));
			
			Left_Rear = card;
			Left_Rear.GetGameObject().transform.position    = fieldInfo.GetPosition((int)fieldPositions.REAR_GUARD_LEFT);
			Left_Rear.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
			RearLeftPower.text = card.GetPower() + "";
		}
		else if(pos == fieldPositions.REAR_GUARD_RIGHT)
		{
			if(Right_Rear != null)
				AddToDropZone(RemoveFrom(pos));
			
			Right_Rear = card;
			Right_Rear.GetGameObject().transform.position    = fieldInfo.GetPosition((int)fieldPositions.REAR_GUARD_RIGHT);
			Right_Rear.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
			RearRightPower.text = card.GetPower() + "";
		}
		
		card.CheckAbilities(CardState.Call);
		LastUnitCalled = card;
		CheckAbilities(CardState.Call_NotMe, card);
		
		CallAnimation(card);
	}
	
	public void RemoveFromDropzone(Card _c)
	{
		DropZone.Remove(_c);
	}
	
	//This is call every frame.
	public void Update()
	{
		fieldWatcher.Update();

		if(bCallEffectAnimation)
		{	
			if(CallEffectTimer <= 0)
			{
				bCallEffectAnimation = false;	
				CallEffect.transform.position = new Vector3(-100.0f, -100.0f, -100.0f);
			}
			else
			{
				CallEffectTimer -= Time.deltaTime;
				CallEffect.transform.eulerAngles = new Vector3(CallEffect.transform.eulerAngles.x, CallEffect.transform.eulerAngles.y +  60 * Time.deltaTime, CallEffect.transform.eulerAngles.z);
				CallEffect.transform.localScale = new Vector3(CallEffect_Scale, 1 ,CallEffect_Scale);
				CallEffect_Scale *= CallEffect_SpeedScale;
				
				
				CallEffect.renderer.material.color = new Color(CallEffect.renderer.material.color.r, 
				  	  									       CallEffect.renderer.material.color.b,
														       CallEffect.renderer.material.color.g,
												  		       CallEffect.renderer.material.color.a - 0.01f);	
				
			}
		}	
		
		UpdatePowerTexts();
		UpdateCards();
		
		if(bViewingDeck)
		{
			bool bMouseOn = false;
			for(int i = 0; i < CardsWatching.Count; i++) 
			{
				if(Util.MouseOn(CardsWatching[i]._x, CardsWatching[i]._y, CardsWatching[i].GetWidth(), CardsWatching[i].GetHeight(), Input.mousePosition))
				{
					cur2DCardSelected = i;	
					_Game._CardMenuHelper.SetCard(CardsWatching[cur2DCardSelected]._CardInfo.cardID);
					bMouseOn = true;
				}
			}

			if(bViewDropZoneMode && Input.GetMouseButtonUp(0) && !_Game._CardMenu.IsOpen() && bMouseOn)
			{
				//_Game.GameChat.AddChatMessage("JAVIER", "OnDropList");

				if(_Game.bBlockDropMenu)
				{
					_Game.bBlockDropMenu = false;
					return;
				}

				if(cur2DCardSelected < CardsWatching.Count && cur2DCardSelected >= 0)
				{
					Card tmpCard = SearchInDropZoneByID(CardsWatching[cur2DCardSelected]._CardInfo.cardID);	
					if(tmpCard != null)
					{
						_Game._CardMenu.OpenOnDropList(tmpCard, CardsWatching[cur2DCardSelected]._x, CardsWatching[cur2DCardSelected]._y);	
					}
				}
			}
 
			if(bViewSoulMode && Input.GetMouseButtonUp(0) && !_Game._CardMenu.IsOpen() && bMouseOn)
			{
				if(cur2DCardSelected < CardsWatching.Count && cur2DCardSelected >= 0)
				{
					Card tmpCard = GetSoulByID(CardsWatching[cur2DCardSelected]._CardInfo.cardID);	
					if(tmpCard != null)
					{
						_Game._CardMenu.OpenOnSoulList(tmpCard, CardsWatching[cur2DCardSelected]._x, CardsWatching[cur2DCardSelected]._y);	
					}
				}
			}
			
			if(!bViewMode)
			{
				if(numSelections <= 0)
				{
					CloseDeck();
				}
				
				if(Input.GetMouseButtonUp(0) && bMouseOn)
				{	
					if(DeleteFromCard2DArray(cur2DCardSelected))
					{
						numSelections--;	
					}
				}
			}
		}
	}
	
	private bool DeleteFromCard2DArray(int CurrentWatchingIdx)
	{
		if(CurrentWatchingIdx >= CardsWatching.Count || CurrentWatchingIdx < 0)
		{
			return false;	
		}
		
		Game2DCard temp = CardsWatching[CurrentWatchingIdx];
		TotalCards.Remove(temp);
		CardsWatching.Clear();
		for(int i = 0; i < 8; i++)
		{
			if((curOffset + i) < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[curOffset + i]);
			}
		}
		CardSelectedVector.Add(temp._CardInfo.cardID);
		Debug.Log (temp._CardInfo.cardID);
		return true;
	}
	
	public List<CardIdentifier> GetLastSelectedList()
	{
		return CardSelectedVector;	
	}
	
	public void CheckAbilitiesSoul(CardState s)
	{
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			Soul[i].CheckAbilities(s);	
		}
	}
	
	public void ResetPersistentPower(Card c)
	{
		c.SetPersistentPower(0);
		_Game.SendPacket(GameAction.PERSISTENT_POWER, c.pos, 0);	
	}

	void ResetSingleCard(Card c)
	{
		if(c != null)
		{
			c.unitAbilities.contPower    = 0;
			c.unitAbilities.contCritical = 0;
			c.RemoveAllExtraClans();
		}
	}

	public void ResetContPower()
	{
		ResetSingleCard(Vanguard);
		ResetSingleCard(Left_Front);
		ResetSingleCard(Right_Front);
		ResetSingleCard(Right_Rear);
		ResetSingleCard(Center_Rear);
		ResetSingleCard(Left_Rear);
	}

	public void UpdateContPower()
	{
		if(Vanguard != null)    Vanguard.unitAbilities.UpdatePersistentAbilities(Vanguard);
		if(Left_Front != null)  Left_Front.unitAbilities.UpdatePersistentAbilities(Left_Front);
		if(Right_Front != null) Right_Front.unitAbilities.UpdatePersistentAbilities(Right_Front);
		if(Right_Rear != null)  Right_Rear.unitAbilities.UpdatePersistentAbilities(Right_Rear);
		if(Left_Rear != null)   Left_Rear.unitAbilities.UpdatePersistentAbilities(Left_Rear);
		if(Center_Rear != null) Center_Rear.unitAbilities.UpdatePersistentAbilities(Center_Rear);
	}

	public void CommitContPower()
	{
		if(Vanguard != null)    Vanguard.unitAbilities.CommitContPower();
		if(Left_Front != null)  Left_Front.unitAbilities.CommitContPower();
		if(Right_Front != null) Right_Front.unitAbilities.CommitContPower();
		if(Right_Rear != null)  Right_Rear.unitAbilities.CommitContPower();
		if(Left_Rear != null)   Left_Rear.unitAbilities.CommitContPower();
		if(Center_Rear != null) Center_Rear.unitAbilities.CommitContPower();
	}

	private void UpdateCards()
	{
		ResetContPower();
		UpdateContPower();
		CommitContPower();

		if(Vanguard != null)
		{
			Vanguard.Update();
		}
		
		if(Left_Front != null)
		{
			Left_Front.Update();
		}
		
		if(Right_Front != null)
		{
			Right_Front.Update();
		}
		
		if(Center_Rear != null)
		{
			Center_Rear.Update();
		}
		
		if(Left_Rear != null)
		{
			Left_Rear.Update();
		}
		
		if(Right_Rear != null)
		{
			Right_Rear.Update();
		}
		
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			Soul[i].Update();	
		}
		
		for(int i = 0; i < DropZone.Count; i++)
		{	
			DropZone[i].Update();
		}
		
		for(int i = 0; i < BindZone.Count; i++)
		{
			BindZone[i].Update();	
		}
		
		for(int i = 0; i < DamageZone.Count; i++)
		{
			DamageZone[i].Update();	
		}
	}
	
	public void RemoveFromBindZone(Card c)
	{
		BindZone.Remove(c);	
	}
	
	public void UpdatePowerTexts()
	{
		if(Vanguard != null && Vanguard.bIsFaceUP && !Vanguard.bDoAnimatedFlip && !Vanguard.IsLocked())    
		{
			VanguardPower.text   = Vanguard.GetPower() + "";
			VC.text = Vanguard.GetCritical() + "";

			CriticalVanguard.SetActive(true);
		}
		else
		{
			VanguardPower.text = "";
			CriticalVanguard.SetActive(false);
	
			VC.text = "";
		}
			
		if(Left_Front != null && !Left_Front.IsLocked()) 
		{
			FrontLeftPower.text  = Left_Front.GetPower() + "";
			FLC.text = Left_Front.GetCritical() + "";
			CriticalLeft.gameObject.SetActive(true);
		}
		else
		{
			FrontLeftPower.text = "";
			FLC.text = "";
			CriticalLeft.gameObject.SetActive(false);
		}
		
		if(Right_Front != null && !Right_Front.IsLocked()) 
		{
			FrontRightPower.text = Right_Front.GetPower() + "";
			FRC.text = Right_Front.GetCritical() + "";
			CriticalRight.gameObject.SetActive(true);
		}
		else
		{
			FrontRightPower.text = "";
			FRC.text = "";
			CriticalRight.gameObject.SetActive(false);
		}
		
		
		if(Center_Rear != null && !Center_Rear.IsLocked()) 
		{
			RearCenterPower.text = Center_Rear.GetPower() + "";
		}
		else
		{
			RearCenterPower.text = "";	
		}
		
		if(Left_Rear != null && !Left_Rear.IsLocked())
		{
			RearLeftPower.text   = Left_Rear.GetPower() + "";
		}
		else
		{
			RearLeftPower.text = "";	
		}
		
		if(Right_Rear != null && !Right_Rear.IsLocked()) {
			RearRightPower.text  = Right_Rear.GetPower() + "";
		}
		else
		{
			RearRightPower.text = "";	
		}
	}
	
	public List<Card> GetUnitList()
	{
		returnList.Clear();
		InitFieldIterator();
		while(HasNextField())
		{
			Card c = CurrentFieldCard();
			if(c != null)
			{
				returnList.Add(c);	
			}
		}
		return returnList;
	}
	
	public void AddToDamageZone(Card card)
	{
		card._Coord = CardCoord.DAMAGE;
		DamageZone.Add(card);
		card.TurnUp();
		/*
		card.GetGameObject().transform.position = new Vector3(-16.16396f, 0.5685959f, -5.766267f);
		card.GetGameObject().transform.position += new Vector3(0.0f, 0.01f * (DamageZone.Count - 1), -2.0f * (DamageZone.Count - 1));
		card.GetGameObject().transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
		*/

		Vector3 newPosition = new Vector3(-16.16396f, 0.5685959f, -5.766267f) + new Vector3(0.0f, 0.01f * (DamageZone.Count - 1), -2.0f * (DamageZone.Count - 1));
		Vector3 newAngle    = new Vector3(0.0f, 90.0f, 0.0f);

		card.MoveAndRotate(newPosition, newAngle);

		CheckAbilities(CardState.CardPutInDamage, card);
		CheckAbilitiesDamage(CardState.DamageZone_CardPutInDamage, card);
	}

	public void CheckAbilitiesDamage(CardState cs, Card effectOwner)
	{
		for(int i = 0; i < DamageZone.Count; i++)
		{
			DamageZone[i].CheckAbilities(cs, effectOwner);
		}
	}
	
	public void CheckAbilitiesDrop(CardState cs)
	{
		for(int i = 0; i < DropZone.Count; i++)
		{
			DropZone[i].CheckAbilities(cs);	
		}
	}
	
	public int CountSoul(FieldGlobalVar.CountConstraint fnc)
	{
		int cnt = 0;
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(fnc(Soul[i]))
			{
				cnt++;	
			}
		}
		return cnt;
	}
	
	public int DropCount(FieldGlobalVar.CountConstraint fnc)
	{
		int cnt = 0;
		for(int i = 0; i < DropZone.Count; i++)
		{
			if(fnc(DropZone[i]))
			{
				cnt++;	
			}
		}
		return cnt;
	}
	
	public void AddToDropZone(Card card)
	{
		LastCardSentToDrop = card;
		card._Coord = CardCoord.DROP;
		card.NormalizeMaterial();
		DropZone.Add(card);
		card.TurnUp();
		card.Stand();

		card.MoveAndRotate(fieldInfo.GetPosition((int)fieldPositions.DROP_ZONE) + new Vector3(0.0f, 0.01f * (DropZone.Count - 1), 0.0f),
		                   new Vector3(0.0f, 180.0f, 0.0f));

		//card.GetGameObject().transform.position = fieldInfo.GetPosition((int)fieldPositions.DROP_ZONE) + new Vector3(0.0f, 0.01f * (DropZone.Count - 1), 0.0f);
		//card.GetGameObject().transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
	}
	
	public void FixDropZonePosition()
	{
		for(int i = 0; i < DropZone.Count; i++)
		{
			DropZone[i].GetGameObject().transform.position = fieldInfo.GetPosition((int)fieldPositions.DROP_ZONE) + new Vector3(0.0f, 0.01f * i, 0.0f);
		}
	}
	
	public int GetNumberWithClanAndGradeEqual(string clan, int grade)
	{
		int cnt = 0;
		InitFieldIterator();
		while(HasNextField())
		{
			Card c = CurrentFieldCard();
			if(c != null && c.clan == clan && c.grade == grade)
			{
				cnt++;
			}
		}
		return cnt;
	}
	
	public void AddToDropZoneList(Card card)
	{
		card._Coord = CardCoord.DROP;
		card.NormalizeMaterial();
		DropZone.Add(card);		
	}
	
	public void FixPosition()
	{
		for(int i = 0; i < DamageZone.Count; i++)
		{
			/*
			DamageZone[i].GetGameObject().transform.position = new Vector3(-16.16396f, 0.5685959f, -5.766267f);
			DamageZone[i].GetGameObject().transform.position += new Vector3(0.0f, 0.01f * i, -2.0f * i);
			DamageZone[i].GetGameObject().transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
			*/

			Vector3 newPosition = new Vector3(-16.16396f, 0.5685959f, -5.766267f) + new Vector3(0.0f, 0.01f * i, -2.0f * i);
			Vector3 newAngle    = new Vector3(0.0f, 90.0f, 0.0f);

			DamageZone[i].MoveAndRotate(newPosition, newAngle);
		}
	}
	
	public Card RemoveFrom(fieldPositions pos)
	{
		Card CardToReturn = null;
		
		if(pos == fieldPositions.FRONT_GUARD_LEFT)
		{
			CardToReturn = Left_Front;
			Left_Front = null;
		}
		else if(pos == fieldPositions.FRONT_GUARD_RIGHT)
		{
			CardToReturn = Right_Front;
			Right_Front = null;
		}
		else if(pos == fieldPositions.REAR_GUARD_CENTER)
		{
			CardToReturn = Center_Rear;
			Center_Rear = null;
		}
		else if(pos == fieldPositions.REAR_GUARD_LEFT)
		{
			CardToReturn = Left_Rear;
			Left_Rear = null;
		}
		else if(pos == fieldPositions.REAR_GUARD_RIGHT)
		{
			CardToReturn = Right_Rear;
			Right_Rear = null;
		}
		
		return CardToReturn;
	}
	
	public Card GetCardAt(fieldPositions pos)
	{
		if(pos == fieldPositions.FRONT_GUARD_LEFT) return Left_Front;
		else if(pos == fieldPositions.FRONT_GUARD_RIGHT) return Right_Front;
		else if(pos == fieldPositions.REAR_GUARD_CENTER) return Center_Rear;
		else if(pos == fieldPositions.REAR_GUARD_LEFT) return Left_Rear;
		else if(pos == fieldPositions.REAR_GUARD_RIGHT) return Right_Rear;
		else if(pos == fieldPositions.VANGUARD_CIRCLE)  return Vanguard;
		else return null;
	}
	
	public void StandAllUnits()
	{
		if(Vanguard != null)
		{
			Vanguard.Stand();
		}
		
		if(Left_Front != null)
		{
			Left_Front.Stand();
		}
		
		if(Right_Front != null)
		{
			Right_Front.Stand();
		}
		
		if(Center_Rear != null)
		{
			Center_Rear.Stand();
		}
		
		if(Left_Rear != null)
		{
			Left_Rear.Stand();
		}
		
		if(Right_Rear != null)
		{
			Right_Rear.Stand();
		}
	}
	
	public void DoStandPhase()
	{
		if(Vanguard != null)
		{
			if(Vanguard.CanStand())
			{
				Vanguard.Stand();
			}
			
			Vanguard.ClearNegateStand();
		}
		
		
		if(Left_Front != null)
		{
			if(Left_Front.CanStand())
			{
				Left_Front.Stand();
			}
			
			Left_Front.ClearNegateStand();
		}
		
		if(Right_Front != null)
		{
			if(Right_Front.CanStand())
			{
				Right_Front.Stand();
			}
			
			Right_Front.ClearNegateStand();
		}
		
		if(Center_Rear != null)
		{
			if(Center_Rear.CanStand())
			{
				Center_Rear.Stand();
			}
			
			Center_Rear.ClearNegateStand();
		}
		
		if(Left_Rear != null)
		{
			if(Left_Rear.CanStand())
			{
				Left_Rear.Stand();
			}
			
			Left_Rear.ClearNegateStand();
		}
		
		if(Right_Rear != null)
		{
			if(Right_Rear.CanStand())
			{
				Right_Rear.Stand();
			}
			
			Right_Rear.ClearNegateStand();
		}		
	}
	
	public void ResetPowers()
	{
		if(Vanguard != null)
			Vanguard.ResetPower();
		if(Left_Front != null)
			Left_Front.ResetPower();
		if(Right_Front != null)
			Right_Front.ResetPower();
		if(Center_Rear != null)
			Center_Rear.ResetPower();
		if(Left_Rear != null)
			Left_Rear.ResetPower();
		if(Right_Rear != null)
			Right_Rear.ResetPower();
	}
	
	public void ResetTurnPowers()
	{
		if(Vanguard != null)
			Vanguard.ResetEndTurnEffects();
		if(Left_Front != null)
			Left_Front.ResetEndTurnEffects();
		if(Right_Front != null)
			Right_Front.ResetEndTurnEffects();
		if(Center_Rear != null)
			Center_Rear.ResetEndTurnEffects();
		if(Left_Rear != null)
			Left_Rear.ResetEndTurnEffects();
		if(Right_Rear != null)
			Right_Rear.ResetEndTurnEffects();
	}
	
	public void ClearZone(fieldPositions pos)
	{
		if(pos == fieldPositions.FRONT_GUARD_LEFT)
			Left_Front = null;
		
		if(pos == fieldPositions.FRONT_GUARD_RIGHT)
			Right_Front = null;
		
		if(pos == fieldPositions.REAR_GUARD_CENTER)
		{
			Center_Rear = null;	
		}
		
		if(pos == fieldPositions.REAR_GUARD_RIGHT)
		{
			Right_Rear = null;	
		}
		
		if(pos == fieldPositions.REAR_GUARD_LEFT)
		{
			Left_Rear = null;	
		}
	}
	
	public int GetDamage()
	{
		return DamageZone.Count;	
	}
	
	public Card RemoveFromDamage()
	{
		if(DamageZone.Count > 0)
		{
			for(int i = 0; i < DamageZone.Count - 2; i++)
			{
				if(!DamageZone[i].bIsFaceUP)
				{
					Card tmpCard = DamageZone[i];
					DamageZone[i].TurnUp();
					DamageZone.RemoveAt(i);
					FixPosition();
					return tmpCard;	
				}
			}
			
			Card tmpCard2 = DamageZone[0];
			DamageZone[0].TurnUp();
			DamageZone.RemoveAt(0);
			FixPosition();
			return tmpCard2;
		}
		
		return null;
	}
	
	public int RemoveFromDamage(Card c)
	{
		if(c == null)
		{
			return -1;
		}

		int idx = -1;
		for(int i = 0; i < DamageZone.Count; i++)
		{
			if(DamageZone[i] == c)
			{
				idx = i;	
			}
		}
		
		DamageZone.Remove(c);
		FixPosition();
		
		return idx;
	}
	
	public bool CanApplyStandTrigger()
	{
		if(Left_Front != null && !Left_Front.IsStand())
			return true;
		
		if(Right_Front != null && !Right_Front.IsStand())
			return true;
		
		if(Left_Rear != null && !Left_Rear.IsStand())
			return true;
		
		if(Right_Rear != null && !Right_Rear.IsStand())
			return true;
		
		if(Center_Rear != null && !Center_Rear.IsStand())
			return true;
		
		return false;
	}
	
	public int GetNumberOfUnitRested()
	{
		int num = 0;
		if(Left_Front != null && !Left_Front.IsStand())
			num++;
		
		if(Right_Front != null && !Right_Front.IsStand())
			num++;
		
		if(Left_Rear != null && !Left_Rear.IsStand())
			num++;
		
		if(Right_Rear != null && !Right_Rear.IsStand())
			num++;
		
		if(Center_Rear != null && !Center_Rear.IsStand())
			num++;	
		
		if(Vanguard != null && !Vanguard.IsStand())
			num++;	
		
		return num;
	}
	
	public int GetNumberOfRearRested()
	{
		int num = 0;
		if(Left_Front != null && !Left_Front.IsStand())
			num++;
		
		if(Right_Front != null && !Right_Front.IsStand())
			num++;
		
		if(Left_Rear != null && !Left_Rear.IsStand())
			num++;
		
		if(Right_Rear != null && !Right_Rear.IsStand())
			num++;
		
		if(Center_Rear != null && !Center_Rear.IsStand())
			num++;		
		
		return num;
	}
	
	public int GetNumberOfRearUnitsRestedWithClanName(string clanName)
	{
		int num = 0;
		if(Left_Front != null && !Left_Front.IsStand() && Left_Front.clan == clanName)
			num++;
		
		if(Right_Front != null && !Right_Front.IsStand() && Right_Front.clan == clanName)
			num++;
		
		if(Left_Rear != null && !Left_Rear.IsStand() && Left_Rear.clan == clanName)
			num++;
		
		if(Right_Rear != null && !Right_Rear.IsStand() && Right_Rear.clan == clanName)
			num++;
		
		if(Center_Rear != null && !Center_Rear.IsStand() && Center_Rear.clan == clanName)
			num++;	
		
		return num;
	}
	
	public int GetNumberOfRearUnitsRestedWithClanNameAndGradeLessOrEqual(string clanName, int grade)
	{
		int num = 0;
		if(Left_Front != null && !Left_Front.IsStand() && Left_Front.clan == clanName && Left_Front.grade <= grade)
			num++;
		
		if(Right_Front != null && !Right_Front.IsStand() && Right_Front.clan == clanName && Right_Front.grade <= grade)
			num++;
		
		if(Left_Rear != null && !Left_Rear.IsStand() && Left_Rear.clan == clanName && Left_Rear.grade <= grade)
			num++;
		
		if(Right_Rear != null && !Right_Rear.IsStand() && Right_Rear.clan == clanName && Right_Rear.grade <= grade)
			num++;
		
		if(Center_Rear != null && !Center_Rear.IsStand() && Center_Rear.clan == clanName && Center_Rear.grade <= grade)
			num++;	
		
		return num;
	}
	
	public int GetNumberOfRearWithClanNameAndGradeGreaterOrEqual(string clanName, int grade)
	{
		int num = 0;
		if(Left_Front != null && Left_Front.clan == clanName && Left_Front.grade >= grade)
			num++;
		
		if(Right_Front != null && Right_Front.clan == clanName && Right_Front.grade >= grade)
			num++;
		
		if(Left_Rear != null && Left_Rear.clan == clanName && Left_Rear.grade >= grade)
			num++;
		
		if(Right_Rear != null && Right_Rear.clan == clanName && Right_Rear.grade >= grade)
			num++;
		
		if(Center_Rear != null && Center_Rear.clan == clanName && Center_Rear.grade >= grade)
			num++;	
		
		return num;		
	}
	
	public int RearGuardNameContains(string str)
	{
		int num = 0;
		if(Left_Front != null && Left_Front.name.Contains(str))
			num++;
		
		if(Right_Front != null && Right_Front.name.Contains(str))
			num++;
		
		if(Left_Rear != null && Left_Rear.name.Contains(str))
			num++;
		
		if(Right_Rear != null && Right_Rear.name.Contains(str))
			num++;
		
		if(Center_Rear != null && Center_Rear.name.Contains(str))
			num++;	
		
		return num;		
	}
	
	
	
	public int SoulNameContains(string str)
	{
		int num = 0;
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(Soul[i].name.Contains(str))
			{
				num++;	
			}
		}
		return num;
	}
	
	public int NameContains(string str)
	{
		int num = RearGuardNameContains(str);
		
		if(Vanguard.name.Contains(str))
		{
			num++;	
		}
		
		return num;
	}
	
	public int GetUnitsDropWithClanName(string clanName)
	{
		int cnt = 0;
		for(int i = 0; i < DropZone.Count; i++)
		{
			if(DropZone[i].clan == clanName)
			{
				cnt++;
			}
		}
		return cnt;
	}
	
	public int GetUnitsDropWithClanNameExcept(string clanName, CardIdentifier id)
	{
		int cnt = 0;
		for(int i = 0; i < DropZone.Count; i++)
		{
			if(DropZone[i].clan == clanName && DropZone[i].cardID != id)
			{
				cnt++;
			}
		}
		return cnt;
	}
	
	public int GetUnitsSoulWithClanName(string clanName)
	{
		int cnt = 0;
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(Soul[i].clan == clanName)
			{
				cnt++;
			}
		}
		return cnt;		
	}
	
	public Card GetDropByID(CardIdentifier id)
	{
		for(int i = 0; i < DropZone.Count; i++)
		{
			if(DropZone[i].cardID == id)
			{
				return DropZone[i];	
			}
		}
		
		return null;
	}
	
	public int GetNumberOfDamageCardsFaceup()
	{
		int ret = 0;
		for(int i = 0; i < DamageZone.Count; i++)
		{
			if(DamageZone[i].bIsFaceUP)
				ret++;
		}
		return ret;
	}
	
	public int GetNumberOfDamageCardsFacedown()
	{
		int ret = 0;
		for(int i = 0; i < DamageZone.Count; i++)
		{
			if(!DamageZone[i].bIsFaceUP)
				ret++;
		}
		return ret;
	}
	
	public void FlipDamageZoneCard()
	{
		for(int i = 0; i < DamageZone.Count; i++)
		{
			if(DamageZone[i].bIsFaceUP)
			{
				DamageZone[i].TurnDown();	
				return;
			}
		}
	}
	
	public void UnflipDamageZoneCard()
	{
		for(int i = 0; i < DamageZone.Count; i++)
		{
			if(!DamageZone[i].bIsFaceUP)
			{
				DamageZone[i].TurnUp();	
				return;
			}
		}	
	}
	
	public int GetDamageIndexOf(Card c)
	{
		for(int i = 0; i < DamageZone.Count; i++)
		{
			if(c == DamageZone[i])
			{
				return i;	
			}
		}
		
		return -1;
	}
	
	public int GetNumberOfCardsWithClanName(string name)
	{
		int num = 0;
		
		if(Vanguard != null)
		{
			if(Vanguard.clan == name)
			{
				num++;	
			}
		}
		
		if(Left_Front != null)
		{
			if(Left_Front.clan == name)
			{
				num++;	
			}
		}
			
		if(Right_Front != null)
		{
			if(Right_Front.clan == name)
			{
				num++;	
			}
		}
		
		if(Center_Rear != null)
		{
			if(Center_Rear.clan == name)
			{
				num++;	
			}
		}
		
		if(Left_Rear != null)
		{
			if(Left_Rear.clan == name)
			{
				num++;	
			}
		}
		
		if(Right_Rear != null)
		{
			if(Right_Rear.clan == name)
			{
				num++;	
			}
		}
		
		return num;
	}
	
	public int GetNumberOfRearWithClanName(string name)
	{
		int num = 0;
				
		if(Left_Front != null)
		{
			if(Left_Front.clan == name)
			{
				num++;	
			}
		}
			
		if(Right_Front != null)
		{
			if(Right_Front.clan == name)
			{
				num++;	
			}
		}
		
		if(Center_Rear != null)
		{
			if(Center_Rear.clan == name)
			{
				num++;	
			}
		}
		
		if(Left_Rear != null)
		{
			if(Left_Rear.clan == name)
			{
				num++;	
			}
		}
		
		if(Right_Rear != null)
		{
			if(Right_Rear.clan == name)
			{
				num++;	
			}
		}
		
		return num;
	}
	
	public int GetNumberOfRear()
	{
		int num = 0;
				
		if(Left_Front != null)
		{
				num++;	
		}
			
		if(Right_Front != null)
		{
				num++;	
		}
		
		if(Center_Rear != null)
		{
				num++;	
		}
		
		if(Left_Rear != null)
		{
				num++;	
		}
		
		if(Right_Rear != null)
		{
				num++;	
		}
		
		return num;
	}
	
	public Card SearchInSoulForID(CardIdentifier s_id)
	{
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(s_id == Soul[i].cardID)
			{
				return Soul[i];	
			}
		}
		return null;
	}
	
	public void CheckAbilities(CardState cs, Card effectOwner = null)
	{
		if(Vanguard != null)
		{
			Vanguard.CheckAbilities(cs, effectOwner);
		}
		
		if(Left_Front != null)
		{
			Left_Front.CheckAbilities(cs, effectOwner);
		}
			
		if(Right_Front != null)
		{
			Right_Front.CheckAbilities(cs, effectOwner);
		}
		
		if(Center_Rear != null)
		{
			Center_Rear.CheckAbilities(cs, effectOwner);
		}
		
		if(Left_Rear != null)
		{
			Left_Rear.CheckAbilities(cs, effectOwner);
		}
		
		if(Right_Rear != null)
		{
			Right_Rear.CheckAbilities(cs, effectOwner);
		}	
	}
	
	public void CheckAbilitiesEnemyTurn(CardState cs)
	{
		InitFieldIterator();
		while(HasNextField())
		{
			Card c = CurrentFieldCard();
			if(c != null)
			{
				c.unitAbilities.CheckAbilitiesEnemyTurn(cs);	
			}
		}
	}
	
	public void CheckAbilitiesExcept(fieldPositions pos, CardState cs, Card effectOwner = null)
	{
		if(Vanguard != null && pos != fieldPositions.VANGUARD_CIRCLE)
		{
			Vanguard.CheckAbilities(cs, effectOwner);
		}
		
		if(Left_Front != null && pos != fieldPositions.FRONT_GUARD_LEFT)
		{
			Left_Front.CheckAbilities(cs, effectOwner);
		}
			
		if(Right_Front != null && pos != fieldPositions.FRONT_GUARD_RIGHT)
		{
			Right_Front.CheckAbilities(cs, effectOwner);
		}
		
		if(Center_Rear != null && pos != fieldPositions.REAR_GUARD_CENTER)
		{
			Center_Rear.CheckAbilities(cs, effectOwner);
		}
		
		if(Left_Rear != null && pos != fieldPositions.REAR_GUARD_LEFT)
		{
			Left_Rear.CheckAbilities(cs, effectOwner);
		}
		
		if(Right_Rear != null && pos != fieldPositions.REAR_GUARD_RIGHT)
		{
			Right_Rear.CheckAbilities(cs, effectOwner);
		}	
	}
	
	public void RemoveFromSoulByCard(Card card)
	{
		Soul.Remove(card);
		/*
		for(int i = 0; i < Soul.Count; i++)
		{
			if(Soul[i] == card)
			{
				Soul.RemoveAt(i);	
				FixSoulPosition();
				return;
			}
		}
		*/
	}
	
	public void ResetShield()
	{
		if(Vanguard != null)
		{
			Vanguard.extraShield = 0;
			
		}
		
		if(Left_Front != null)
		{
			Left_Front.extraShield = 0;
			
		}
		
		if(Right_Front != null)
		{
			Right_Front.extraShield = 0;
			
		}
		
		if(Center_Rear != null)
		{
			Center_Rear.extraShield = 0;
			
		}
		
		if(Left_Rear != null)
		{
			Left_Rear.extraShield = 0;
			
		}
		
		if(Right_Rear != null)
		{
			Right_Rear.extraShield = 0;
			
		}		
	}	
	
	public int GetNumberOfCardsInSoulExcept(CardIdentifier id)
	{
		int cnt = 0;
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(Soul[i].cardID != id)
			{
				cnt++;
			}
		}
		return cnt;
	}
	
	public int GetNumberOfCardsInSoul()
	{
		return Soul.Count - 1;	
	}
	
	public Card GetTopCardFromSoul()
	{
		if(Soul.Count <= 1)
			return null;
		
		return Soul[Soul.Count - 2];		
	}
	
	public bool IsCardInRear(CardIdentifier id)
	{
		if(Left_Front != null)
		{
			if(Left_Front.cardID == id)
			{
				return true;	
			}
		}
			
		if(Right_Front != null)
		{
			if(Right_Front.cardID == id)
			{
				return true;	
			}
		}
		
		if(Center_Rear != null)
		{
			if(Center_Rear.cardID == id)
			{
				return true;	
			}
		}
		
		if(Left_Rear != null)
		{
			if(Left_Rear.cardID == id)
			{
				return true;	
			}
		}
		
		if(Right_Rear != null)
		{
			if(Right_Rear.cardID == id)
			{	
				return true;
			}
		}
		
		return false;
	}
	
	public Card GetRearCardByID(CardIdentifier id)
	{
		if(Left_Front != null)
		{
			if(Left_Front.cardID == id)
			{
				return Left_Front;	
			}
		}
			
		if(Right_Front != null)
		{
			if(Right_Front.cardID == id)
			{
				return Right_Front;	
			}
		}
		
		if(Center_Rear != null)
		{
			if(Center_Rear.cardID == id)
			{
				return Center_Rear;	
			}
		}
		
		if(Left_Rear != null)
		{
			if(Left_Rear.cardID == id)
			{
				return Left_Rear;	
			}
		}
		
		if(Right_Rear != null)
		{
			if(Right_Rear.cardID == id)
			{	
				return Right_Rear;
			}
		}
		
		return null;	
	}
	
	public Card GetFieldByID(CardIdentifier id)
	{
		if(Vanguard != null)
		{
			if(Vanguard.cardID == id)
			{
				return Vanguard;	
			}
		}
		
		if(Left_Front != null)
		{
			if(Left_Front.cardID == id)
			{
				return Left_Front;	
			}
		}
			
		if(Right_Front != null)
		{
			if(Right_Front.cardID == id)
			{
				return Right_Front;	
			}
		}
		
		if(Center_Rear != null)
		{
			if(Center_Rear.cardID == id)
			{
				return Center_Rear;	
			}
		}
		
		if(Left_Rear != null)
		{
			if(Left_Rear.cardID == id)
			{
				return Left_Rear;	
			}
		}
		
		if(Right_Rear != null)
		{
			if(Right_Rear.cardID == id)
			{	
				return Right_Rear;
			}
		}
		
		return null;		
	}
	
	public void MoveToSoul(fieldPositions pos)
	{
		Card CardToMove = null;
		CardToMove = GetCardAt(pos);
		AddToSoul(CardToMove);
		Vector3 newPosition = fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + new Vector3(0, -0.01f, 0);
		CardToMove.GoTo(newPosition.x, newPosition.z);
	}
	
	public void MoveToSoul(Card card)
	{
		Card CardToMove = card;
		AddToSoul(CardToMove);
		Vector3 newPosition = fieldInfo.GetPosition((int)fieldPositions.VANGUARD_CIRCLE) + new Vector3(0, -0.01f, 0);
		CardToMove.GoTo(newPosition.x, newPosition.z);
	}
	
	public Card GetSoulByID(CardIdentifier id)
	{
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(Soul[i].cardID == id)
			{
				return Soul[i];	
			}
		}
		return null;
	}
	
	//Soul
	public void ViewBindZone()
	{
		bViewMode = true;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		
		for(int i = 0; i < BindZone.Count; i++)
		{
			TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(BindZone[i].cardID)));
		}
		
		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}
		
		cur2DCardSelected = -1;
		curOffset = 0;
		numSelections = 0;
		CardSelectedVector.Clear();
	}
	
	//Soul
	public void ViewSoul()
	{
		bViewSoulMode = true;
		
		bViewMode = true;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(Soul[i].cardID)));
		}
		
		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}
		
		cur2DCardSelected = -1;
		curOffset = 0;
		numSelections = 0;
		CardSelectedVector.Clear();
	}
	
	public void ViewDropZone()
	{
		_Game.bBlockDropMenu = false;
		bViewDropZoneMode = true;
		bViewMode = true;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		
		for(int i = 0; i < DropZone.Count; i++)
		{
			TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(DropZone[i].cardID)));
		}

		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}
		
		cur2DCardSelected = 0;
		curOffset = 0;
		numSelections = 0;
		CardSelectedVector.Clear();		
	}
	
	public int NumDropZoneClanName(string clan)
	{
		int cnt = 0;
		for(int i = 0; i < DropZone.Count; i++)
		{
			if(DropZone[i].clan == clan)
			{
				cnt++;	
			}
		}
		return cnt;
	}
	
	public bool ThereIsOpenRC()
	{
		return Left_Rear == null   ||
			   Right_Rear == null  ||
			   Right_Front == null ||
			   Left_Front == null  ||
			   Center_Rear == null;
	}
	
	public int NumOpenRC()
	{
		int num = 0;
		if(Left_Rear   == null) num++;
		if(Right_Rear  == null) num++;
		if(Right_Front == null) num++;
		if(Left_Front  == null) num++;
		if(Center_Rear == null) num++;
		return num;
	}
	
	public void ViewDropZone(int cnt, string clanName)
	{
		bViewDropZoneMode = false;
		bViewMode = false;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		
		for(int i = 0; i < DropZone.Count; i++)
		{
			if(DropZone[i].clan == clanName)
			{
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(DropZone[i].cardID)));
			}
		}
		
		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}
		
		cur2DCardSelected = -1;
		curOffset = 0;
		numSelections = cnt;
		if(numSelections > TotalCards.Count)
		{
			numSelections = TotalCards.Count;	
		}
		CardSelectedVector.Clear();		
	}
	
	public void ViewDropZoneExcept(int cnt, string clanName, CardIdentifier id)
	{
		bViewDropZoneMode = false;
		bViewMode = false;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		
		for(int i = 0; i < DropZone.Count; i++)
		{
			if(DropZone[i].clan == clanName && DropZone[i].cardID != id)
			{
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(DropZone[i].cardID)));
			}
		}
		
		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}
		
		cur2DCardSelected = -1;
		curOffset = 0;
		numSelections = cnt;
		if(numSelections > TotalCards.Count)
		{
			numSelections = TotalCards.Count;	
		}
		CardSelectedVector.Clear();		
	}

	public void ViewDropZone(int cnt)
	{
		bViewDropZoneMode = false;
		bViewMode = false;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		
		for(int i = 0; i < DropZone.Count; i++)
		{
			TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(DropZone[i].cardID)));
		}
		
		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}
		
		cur2DCardSelected = -1;
		curOffset = 0;
		numSelections = cnt;
		if(numSelections > TotalCards.Count)
		{
			numSelections = TotalCards.Count;	
		}
		CardSelectedVector.Clear();		
	}
	
	private void InitViewSoul(int numSelections)
	{
		bViewMode = false;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		bViewDropZoneMode = true;	
		this.numSelections = numSelections;
	}
	
	private void FillViewSoul()
	{
		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}
		
		cur2DCardSelected = -1;
		curOffset = 0;
		CardSelectedVector.Clear();		
		
		if(numSelections > TotalCards.Count)
		{
			numSelections = TotalCards.Count;	
		}
	}
	
	private void InitViewBindZone(int numSelections)
	{
		bViewMode = false;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		bViewDropZoneMode = true;	
		this.numSelections = numSelections;
	}
	
	private void FillViewBindZone()
	{
		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}
		
		cur2DCardSelected = -1;
		curOffset = 0;
		CardSelectedVector.Clear();		
		
		if(numSelections > TotalCards.Count)
		{
			numSelections = TotalCards.Count;	
		}
	}
	
	public void ViewSoul(int numSelections)
	{
		InitViewSoul(numSelections);
		
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(Soul[i].cardID)));
		}
		
		FillViewSoul();
	}
	
	public void ViewDropZone(int n, FieldGlobalVar.CountConstraint fnc)
	{
		bViewDropZoneMode = false;
		bViewMode = false;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		
		for(int i = 0; i < DropZone.Count; i++)
		{
			if(fnc(DropZone[i]))
			{
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(DropZone[i].cardID)));
			}
		}
		
		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}
		
		cur2DCardSelected = -1;
		curOffset = 0;
		numSelections = n;
		CardSelectedVector.Clear();		
	}
	
	public void ViewSoul(int numSelections, FieldGlobalVar.CountConstraint fnc)
	{
		InitViewSoul(numSelections);
		
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(fnc(Soul[i]) && !Soul[i].IsVanguard())
			{
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(Soul[i].cardID)));
			}
		}
		
		FillViewSoul();
	}
	
	public void ViewBindZone(int numSelections, FieldGlobalVar.CountConstraint fnc)
	{
		InitViewBindZone(numSelections);
		
		for(int i = 0; i < BindZone.Count; i++)
		{
			if(fnc(BindZone[i]))
			{
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(BindZone[i].cardID)));
			}
		}
		
		FillViewBindZone();
	}
	
	public void ViewSoul(int numSelections, SearchMode mode, CardIdentifier id, string clan)
	{
		InitViewSoul(numSelections);
		
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(mode == SearchMode.ALL_EXCEPT)
			{
				if(Soul[i].cardID != id && Soul[i].clan == clan)
				{
					TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(Soul[i].cardID)));
				}
			}
		}
		
		FillViewSoul();
	}	
	
	public void ViewSoul(string clan)
	{
		InitViewSoul(1);
		
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(Soul[i].clan == clan)
			{
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(Soul[i].cardID)));
			}
		}
		
		FillViewSoul();
	}

	public void ViewSoul(int numSelections, string clanName, string raceName, string nameContains)
	{
		bViewMode = false;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		bViewDropZoneMode = true;
		
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(Soul[i].clan == clanName && (Soul[i].race == raceName || raceName == "") && 
			   (Soul[i].name.Contains(nameContains) || nameContains == ""))
			{
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(Soul[i].cardID)));
			}
		}
		
		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}
		
		cur2DCardSelected = -1;
		curOffset = 0;
		this.numSelections = numSelections;
		if(this.numSelections > TotalCards.Count)
		{
			this.numSelections = TotalCards.Count;	
		}
		CardSelectedVector.Clear();		
	}
	
	public Card GetBoundByID(CardIdentifier id)
	{
		for(int i = 0; i < BindZone.Count; i++) 
		{
			if(BindZone[i].cardID == id)
			{
				return BindZone[i];	
			}
		}
		
		return null;
	}
	
	public void CloseDeck()
	{
		bViewingDeck = false;	
		bViewDropZoneMode = false;
		bViewSoulMode = false;
	}
	
	public void DrawGUI()
	{
		fieldWatcher.Draw();

		if(bViewingDeck)
		{
			float _x = Screen.width / 2 - 300 + 160;
			float _y = Screen.height / 2 - 63;
			GUI.DrawTexture(new Rect(_x, _y, 600, 146), ViewBackground);
			
			for(int i = 0; i < CardsWatching.Count; i++)
			{
				CardsWatching[i].DrawAt(_x + (CardsWatching[i].GetWidth() + 5) * i + 45, _y + 30); 	
			}

			if(GUI.Button(new Rect(_x - 5, _y + 50, 38, 38), "", leftArrowBtnStyle))
			{
				if(cur2DCardSelected > 0)
				{
					cur2DCardSelected--;
				}
				else
				{
					if(curOffset > 0)
					{
						curOffset--;
						CardsWatching.RemoveAt(CardsWatching.Count - 1);
						CardsWatching.Insert(0, TotalCards[curOffset]); 
					}
				}
				
				_Game._CardMenuHelper.SetCard(CardsWatching[cur2DCardSelected]._CardInfo.cardID);
			}

			if(GUI.Button(new Rect(_x + 570, _y + 50, 38, 38), "", rightArrowBtnStyle))
			{
				if(cur2DCardSelected < CardsWatching.Count - 1)
				{
					cur2DCardSelected++;	
				}
				else
				{
					if(curOffset < (TotalCards.Count - 8))
					{
						curOffset++;
						CardsWatching.RemoveAt(0);
						CardsWatching.Add(TotalCards[curOffset]); 
					}
				}
				_Game._CardMenuHelper.SetCard(CardsWatching[cur2DCardSelected]._CardInfo.cardID);
			}

			if(GUI.Button (new Rect(_x + 575, _y - 5, 28, 28), "", exitBtnStyle))
			{
				if(bCloseEnable)
				{
					CloseDeck();
				}
			}
		}
	}
	
	public Card SearchInDropZoneByID(CardIdentifier _id)
	{
		for(int i = 0; i < DropZone.Count; i++)
		{
			if(_id == DropZone[i].cardID)
			{
				return DropZone[i];	
			}
		}
		return null;
	}
	
	public bool ViewingSoul()
	{
		return bViewingDeck;	
	}
	
	public bool ViewingBindZone()
	{
		return bViewingDeck;	
	}
	
	public bool ViewingDropZone()
	{
		return bViewingDeck;	
	}
	
	public Card GetTopCardFromDrop()
	{
		if(DropZone.Count > 0)
		{
			return DropZone[DropZone.Count - 1];	
		}
		
		return null;
	}
	
	public void Move(Card card)
	{
		_Game.SendPacket(GameAction.MOVE_ALLY, card.pos);
		
		if(card.pos == fieldPositions.FRONT_GUARD_LEFT)
		{
			Vector3 RearLeftPos = fieldInfo.GetPosition((int)fieldPositions.REAR_GUARD_LEFT);
			Vector3 FrontLeftPos = fieldInfo.GetPosition((int)fieldPositions.FRONT_GUARD_LEFT);
			
			if(Left_Rear != null)
			{
				Left_Front     = Left_Rear;
				Left_Rear      = card;
				Left_Front.pos = fieldPositions.FRONT_GUARD_LEFT;
				Left_Rear.pos  = fieldPositions.REAR_GUARD_LEFT;
				
				Left_Front.GoTo(FrontLeftPos.x, FrontLeftPos.z);
				Left_Rear.GoTo(RearLeftPos.x, RearLeftPos.z);
			}
			else
			{
				Left_Rear      = card;
				Left_Rear.pos  = fieldPositions.REAR_GUARD_LEFT;
				Left_Rear.GoTo(RearLeftPos.x, RearLeftPos.z);
				ClearZone(fieldPositions.FRONT_GUARD_LEFT);
			}
		}
		else if(card.pos == fieldPositions.REAR_GUARD_LEFT)
		{
			Vector3 RearLeftPos = fieldInfo.GetPosition((int)fieldPositions.REAR_GUARD_LEFT);
			Vector3 FrontLeftPos = fieldInfo.GetPosition((int)fieldPositions.FRONT_GUARD_LEFT);
			
			if(Left_Front != null)
			{
				Left_Rear      = Left_Front;
				Left_Front     = card;
				Left_Front.pos = fieldPositions.FRONT_GUARD_LEFT;
				Left_Rear.pos  = fieldPositions.REAR_GUARD_LEFT;
				
				Left_Front.GoTo(FrontLeftPos.x, FrontLeftPos.z);
				Left_Rear.GoTo(RearLeftPos.x, RearLeftPos.z);
			}
			else
			{
				Left_Front      = card;
				Left_Front.pos  = fieldPositions.FRONT_GUARD_LEFT;
				Left_Front.GoTo(FrontLeftPos.x, FrontLeftPos.z);
				ClearZone(fieldPositions.REAR_GUARD_LEFT);
			}
		}
		else if(card.pos == fieldPositions.FRONT_GUARD_RIGHT)
		{
			Vector3 RearRightPos = fieldInfo.GetPosition((int)fieldPositions.REAR_GUARD_RIGHT);
			Vector3 FrontRightPos = fieldInfo.GetPosition((int)fieldPositions.FRONT_GUARD_RIGHT);
			
			if(Right_Rear != null)
			{
				Right_Front     = Right_Rear;
				Right_Rear      = card;
				Right_Front.pos = fieldPositions.FRONT_GUARD_RIGHT;
				Right_Rear.pos  = fieldPositions.REAR_GUARD_RIGHT;
				
				Right_Front.GoTo(FrontRightPos.x, FrontRightPos.z);
				Right_Rear.GoTo(RearRightPos.x, RearRightPos.z);
			}
			else
			{
				Right_Rear      = card;
				Right_Rear.pos  = fieldPositions.REAR_GUARD_RIGHT;
				Right_Rear.GoTo(RearRightPos.x, RearRightPos.z);
				ClearZone(fieldPositions.FRONT_GUARD_RIGHT);
			}
		}
		else if(card.pos == fieldPositions.REAR_GUARD_RIGHT)
		{
			Vector3 RearRightPos = fieldInfo.GetPosition((int)fieldPositions.REAR_GUARD_RIGHT);
			Vector3 FrontRightPos = fieldInfo.GetPosition((int)fieldPositions.FRONT_GUARD_RIGHT);
			
			if(Right_Front != null)
			{
				Right_Rear      = Right_Front;
				Right_Front     = card;
				Right_Front.pos = fieldPositions.FRONT_GUARD_RIGHT;
				Right_Rear.pos  = fieldPositions.REAR_GUARD_RIGHT;
				
				Right_Front.GoTo(FrontRightPos.x, FrontRightPos.z);
				Right_Rear.GoTo(RearRightPos.x, RearRightPos.z);
			}
			else
			{
				Right_Front      = card;
				Right_Front.pos  = fieldPositions.FRONT_GUARD_RIGHT;
				Right_Front.GoTo(FrontRightPos.x, FrontRightPos.z);
				ClearZone(fieldPositions.REAR_GUARD_RIGHT);
			}
		}
	}
}

