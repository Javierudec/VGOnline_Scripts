using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyField {
	public EnemyFieldInformation fieldInfo;
	public Card Vanguard;
	public Card Left_Front;
	public Card Right_Front;
	public Card Left_Rear;
	public Card Right_Rear;
	public Card Center_Rear;
	private List<Card> Soul; //Last Card is the vanguard, not soul.
	private Vector3 delta;
	private TextMesh VanguardPower;
	private TextMesh FrontRightPower;
	private TextMesh FrontLeftPower;
	private TextMesh RearRightPower;
	private TextMesh RearLeftPower;
	private TextMesh RearCenterPower;
	//Critical information
	private TextMesh VC;
	private TextMesh FRC;
	private TextMesh FLC;
	private TextMesh RRC;
	private TextMesh RLC;
	private TextMesh RCC;
	private List<Card> DamageZone;
	private List<Card> DropZone;
	public List<Card> BindZone;
	private Gameplay Game;
	
	private GameObject CriticalLeft = null;
	private GameObject CriticalVanguard = null;
	private GameObject CriticalRight = null;
	
	private GameObject CallEffect = null;
	private bool bCallEffectAnimation = false;
	private float CallEffect_Scale = 10;
	private float CallEffect_SpeedScale = 1.0045f;
	private float CallEffectTimer = 0;
	private float MaxTimeCallEffect = 2;
	
	public EnemyField(Gameplay _Game)
	{
		CriticalLeft = GameObject.FindGameObjectWithTag("EnemyCriticalFrontLeft");
		CriticalVanguard = GameObject.FindGameObjectWithTag("EnemyCriticalVanguard");
		CriticalRight = GameObject.FindGameObjectWithTag("EnemyCriticalFrontRight");
		
		CallEffect = GameObject.FindGameObjectWithTag("CallEffect");
		
		fieldInfo = new EnemyFieldInformation();
		Soul      = new List<Card>();
		Vanguard  = null;
		Left_Rear = null;
		Left_Front = null;
		Center_Rear = null;
		Right_Rear = null;
		Left_Rear = null;
		delta     = new Vector3(0.0f, 0.01f, 0.0f);
		
		VanguardPower   = (TextMesh)GameObject.FindGameObjectWithTag("VPEnemy").GetComponent("TextMesh");
		FrontRightPower = (TextMesh)GameObject.FindGameObjectWithTag("FRPEnemy").GetComponent("TextMesh");
		FrontLeftPower  = (TextMesh)GameObject.FindGameObjectWithTag("FLPEnemy").GetComponent("TextMesh");
		RearRightPower  = (TextMesh)GameObject.FindGameObjectWithTag("RRPEnemy").GetComponent("TextMesh");
		RearLeftPower   = (TextMesh)GameObject.FindGameObjectWithTag("RLPEnemy").GetComponent("TextMesh");
		RearCenterPower = (TextMesh)GameObject.FindGameObjectWithTag("RCPEnemy").GetComponent("TextMesh");
		
		VC  = (TextMesh)GameObject.FindGameObjectWithTag("VCE").GetComponent("TextMesh");
		FRC = (TextMesh)GameObject.FindGameObjectWithTag("FRCE").GetComponent("TextMesh");
		FLC = (TextMesh)GameObject.FindGameObjectWithTag("FLCE").GetComponent("TextMesh");
		RRC = (TextMesh)GameObject.FindGameObjectWithTag("RRCE").GetComponent("TextMesh");
		RLC = (TextMesh)GameObject.FindGameObjectWithTag("RLCE").GetComponent("TextMesh");
		RCC = (TextMesh)GameObject.FindGameObjectWithTag("RCCE").GetComponent("TextMesh");
				
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
		
		VC.text = "";
		FRC.text = "";
		FLC.text = "";
		RRC.text = "";
		RLC.text = "";
		RCC.text = "";
		
		Game = _Game;
		
	}
	
	public Card GetDamageAtIndex(int idx)
	{
		if(idx < DamageZone.Count)
		{
			return DamageZone[idx];	
		}
		
		return null;
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

	public void AddToBindZone(Card c)
	{
		BindZone.Add(c);
		c._Coord = CardCoord.ENEMY_BIND;
	}
	
	public void CallAnimation(Card c, Vector3 position)
	{
		if(c != null && CallEffect != null)
		{
			
			bCallEffectAnimation = true;
			CallEffectTimer = MaxTimeCallEffect;
			CallEffect_Scale = 8;
			CallEffect.renderer.material.color = new Color(CallEffect.renderer.material.color.r, 
														   CallEffect.renderer.material.color.b,
														   CallEffect.renderer.material.color.g,
												  		   1);
			CallEffect.transform.localScale = new Vector3(CallEffect_Scale, 1, CallEffect_Scale);
			//CallEffect.transform.position = c.GetGameObject().transform.position + new Vector3(0, -0.5f, 0);
			CallEffect.transform.position = position + new Vector3(0, -0.5f, 0);
		}
	}

	public void Ride(Card card)
	{
		if(Soul.Count > 0)
			Soul[Soul.Count - 1].SetIsVanguard(false);
		Soul.Add (card);
		
		card.pos = fieldPositions.ENEMY_VANGUARD;
		card._Coord = CardCoord.ENEMY_FIELD;

		card.SetIsVanguard(true);
		Vanguard = card;

		for(int i = 0; i < Soul.Count - 1; i++)
		{
			Soul[i].GetGameObject().transform.position = fieldInfo.GetPosition((int)EnemyFieldPosition.VANGUARD) + delta * i;
		}

		Vector3 newPosition = fieldInfo.GetPosition((int)EnemyFieldPosition.VANGUARD) + delta * (Soul.Count - 1);

		Vanguard.TurnUp();	
		Vanguard.MoveAndRotate(newPosition, fieldInfo.GetCardRotation());

		//Vanguard.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
		VanguardPower.text = card.GetPower() + "";

		CallAnimation(card, newPosition);
	}
	
	public void DoStandPhase()
	{
		if(Vanguard != null)
		{
			if(Vanguard.CanStand())
			{
				Vanguard.StandEnemy();
			}
			
			Vanguard.ClearNegateStand();
		}
		
		
		if(Left_Front != null)
		{
			if(Left_Front.CanStand())
			{
				Left_Front.StandEnemy();
			}
			
			Left_Front.ClearNegateStand();
		}
		
		if(Right_Front != null)
		{
			if(Right_Front.CanStand())
			{
				Right_Front.StandEnemy();
			}
			
			Right_Front.ClearNegateStand();
		}
		
		if(Center_Rear != null)
		{
			if(Center_Rear.CanStand())
			{
				Center_Rear.StandEnemy();
			}
			
			Center_Rear.ClearNegateStand();
		}
		
		if(Left_Rear != null)
		{
			if(Left_Rear.CanStand())
			{
				Left_Rear.StandEnemy();
			}
			
			Left_Rear.ClearNegateStand();
		}
		
		if(Right_Rear != null)
		{
			if(Right_Rear.CanStand())
			{
				Right_Rear.StandEnemy();
			}
			
			Right_Rear.ClearNegateStand();
		}		
	}
	
	public void Call(Card card, EnemyFieldPosition pos)
	{
		card.pos = (fieldPositions)((int)pos + 9);

		card._Coord = CardCoord.ENEMY_FIELD;
		
		card.TurnUp();

		Vector3 newPosition, newAngle;
		
		if(pos == EnemyFieldPosition.FRONT_LEFT)
		{
			if(Left_Front != null)
			{
				AddToDropZone(RemoveFrom(pos), false);	
			}
			
			Left_Front = card;
			//Left_Front.GetGameObject().transform.position    = fieldInfo.GetPosition((int)pos);
			//Left_Front.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
			FrontLeftPower.text = card.GetPower() + "";
		}
		else if(pos == EnemyFieldPosition.FRONT_RIGHT)
		{
			if(Right_Front != null)
			{
				Debug.Log("Adding to DropZone");
				AddToDropZone(RemoveFrom(pos), false);
			}
			
			Right_Front = card;
			//Right_Front.GetGameObject().transform.position    = fieldInfo.GetPosition((int)pos);
			//Right_Front.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
			FrontRightPower.text = card.GetPower() + "";
		}
		else if(pos == EnemyFieldPosition.REAR_CENTER)
		{
			if(Center_Rear != null)
				AddToDropZone(RemoveFrom(pos), false);
			
			Center_Rear = card;
			//Center_Rear.GetGameObject().transform.position    = fieldInfo.GetPosition((int)pos);
			//Center_Rear.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
			RearCenterPower.text = card.GetPower() + "";
		}
		else if(pos == EnemyFieldPosition.REAR_LEFT)
		{
			if(Left_Rear != null)
				AddToDropZone(RemoveFrom(pos), false);
			
			Left_Rear = card;
			//Left_Rear.GetGameObject().transform.position    = fieldInfo.GetPosition((int)pos);
			//Left_Rear.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
			RearLeftPower.text = card.GetPower() + "";
		}
		else if(pos == EnemyFieldPosition.REAR_RIGHT)
		{
			if(Right_Rear != null)
				AddToDropZone(RemoveFrom(pos), false);
			
			Right_Rear = card;
			//Right_Rear.GetGameObject().transform.position    = fieldInfo.GetPosition((int)pos);
			//Right_Rear.GetGameObject().transform.eulerAngles = fieldInfo.GetCardRotation();
			RearRightPower.text = card.GetPower() + "";
		}

		newPosition = fieldInfo.GetPosition((int)pos);
		newAngle    = fieldInfo.GetCardRotation();

		card.MoveAndRotate(newPosition, newAngle);
		CallAnimation(card, newPosition);
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

	private void UpdateViewMode()
	{
		if(bViewingDeck)
		{
			for(int i = 0; i < CardsWatching.Count; i++) 
			{
				if(Util.MouseOn(CardsWatching[i]._x, CardsWatching[i]._y, CardsWatching[i].GetWidth(), CardsWatching[i].GetHeight(), Input.mousePosition))
				{
					cur2DCardSelected = i;	
					Game._CardMenuHelper.SetCard(CardsWatching[cur2DCardSelected]._CardInfo.cardID);
				}
			}

			/*
			if(bViewDropZoneMode && Input.GetMouseButtonUp(0) && !_Game._CardMenu.IsOpen())
			{
				if(cur2DCardSelected < CardsWatching.Count && cur2DCardSelected >= 0)
				{
					Card tmpCard = SearchInDropZoneByID(CardsWatching[cur2DCardSelected]._CardInfo.cardID);	
					if(tmpCard != null)
					{
						Game._CardMenu.OpenOnDropList(tmpCard, CardsWatching[cur2DCardSelected]._x, CardsWatching[cur2DCardSelected]._y);	
					}
				}
			}
			*/

			/*
			if(bViewSoulMode && Input.GetMouseButtonUp(0) && !_Game._CardMenu.IsOpen())
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
			*/
			
			if(!bViewMode)
			{
				if(numSelections <= 0)
				{
					CloseDeck();
				}
				
				if(Input.GetMouseButtonUp(0))
				{	
					if(DeleteFromCard2DArray(cur2DCardSelected))
					{
						numSelections--;	
					}
				}
			}
		}
	}
	
	//This is call every frame.
	public void Update()
	{
		if(bCallEffectAnimation)
		{	
			if(CallEffectTimer <= 0)
			{
				bCallEffectAnimation = false;	
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
		UpdateViewMode();
	}
	
	private void UpdateCards()
	{
		if(Vanguard != null)
			Vanguard.Update();
		
		if(Left_Front != null)
			Left_Front.Update();
		
		if(Right_Front != null)
			Right_Front.Update();
		
		if(Center_Rear != null)
			Center_Rear.Update();
		
		if(Left_Rear != null)
			Left_Rear.Update();
		
		if(Right_Rear != null)
			Right_Rear.Update();
		
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			Soul[i].Update();	
		}
		
		for(int i = 0; i < BindZone.Count; i++)
		{
			BindZone[i].Update();	
		}
		
		for(int i = 0; i < DamageZone.Count; i++)
		{
			DamageZone[i].Update();	
		}

		for(int i = 0; i < DropZone.Count; i++)
		{
			DropZone[i].Update();
		}
	}
	
	public Card GetCardFromBindByID(CardIdentifier id)
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
	
	public void RemoveFromBindZone(Card c)
	{
		BindZone.Remove(c);	
	}
	
	public void RemoveFromDropZone(Card c)
	{
		DropZone.Remove(c);	
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
	
	public Card SearchInDropZone(CardIdentifier id)
	{
		for(int i =0; i < DropZone.Count; i++)
		{
			if(id == DropZone[i].cardID)
			{
				return DropZone[i];	
			}
		}
		return null;
	}
	
	public int GetNumberOfRearGuardRested()
	{		
		int num = 0;
		
		if(Left_Front != null && !Left_Front.IsStand())
		{
			num++;	
		}
		
		if(Right_Front != null && !Right_Front.IsStand())
		{
			num++;
		}
		
		if(Center_Rear != null && !Center_Rear.IsStand())
		{
			num++;
		}
		
		if(Left_Rear != null && !Left_Rear.IsStand())
		{
			num++;
		}
		
		if(Right_Rear != null && !Right_Rear.IsStand())
		{
			num++;
		}
		
		return num;
	}
	
	public int GetNumberOfRearUnitsWithGradeLessOrEqual(int grade)
	{
		int num = 0;
		
		if(Left_Front != null && Left_Front.grade <= grade)
		{
			num++;	
		}
		
		if(Right_Front != null && Right_Front.grade <= grade)
		{
			num++;
		}
		
		if(Center_Rear != null && Center_Rear.grade <= grade)
		{
			num++;
		}
		
		if(Left_Rear != null && Left_Rear.grade <= grade)
		{
			num++;
		}
		
		if(Right_Rear != null && Right_Rear.grade <= grade)
		{
			num++;
		}
		
		return num;	
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
			VC.text = "";
			CriticalVanguard.SetActive(false);
		}
			
		if(Left_Front != null && !Left_Front.IsLocked()) 
		{
			FrontLeftPower.text  = Left_Front.GetPower() + "";
			FLC.text = Left_Front.GetCritical() + "";
			CriticalLeft.SetActive(true);
		}
		else
		{
			FrontLeftPower.text = "";
			FLC.text = "";
			CriticalLeft.SetActive(false);
		}
		
		if(Right_Front != null && !Right_Front.IsLocked()) 
		{
			FrontRightPower.text = Right_Front.GetPower() + "";
			FRC.text = Right_Front.GetCritical() + "";
			CriticalRight.SetActive(true);
		}
		else
		{
			FrontRightPower.text = "";
			FRC.text = "";
			CriticalRight.SetActive(false);
		}
		
		if(Center_Rear != null && !Center_Rear.IsLocked()) 
		{
			RearCenterPower.text = Center_Rear.GetPower() + "";
		}
		else
		{
			RearCenterPower.text = "";	
		}
		
		if(Left_Rear != null && !Left_Rear.IsLocked()) {
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
	
	public int GetDamageFaceup()
	{
		int cnt = 0;
		for(int i = 0; i < DamageZone.Count; i++)
		{
			if(DamageZone[i].IsFaceup())
			{
				cnt++;	
			}
		}
		return 0;
	}
	
	public void AddToDamageZone(Card card)
	{
		card._Coord = CardCoord.ENEMY_DAMAGE;
		DamageZone.Add(card);
		card.TurnUp();

		Vector3 newPosition = new Vector3(15.70469f, 0.7570782f, 5.772846f) + new Vector3(0.0f, 0.01f * (DamageZone.Count - 1), 2.0f * (DamageZone.Count - 1));
		Vector3 newAngle    = new Vector3(0.0f, -90.0f, 0.0f);

		card.MoveAndRotate(newPosition, newAngle);

		//card.GetGameObject().transform.position = new Vector3(15.70469f, 0.7570782f, 5.772846f) + new Vector3(0.0f, 0.01f * (DamageZone.Count - 1), 2.0f * (DamageZone.Count - 1));
		//card.GetGameObject().transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
	}
	
	public void FixPosition()
	{
		for(int i = 0; i < DamageZone.Count; i++)
		{
			Vector3 newPosition = new Vector3(15.70469f, 0.7570782f, 5.772846f) + new Vector3(0.0f, 0.01f * i, 2.0f * i);
			Vector3 newAngle    = new Vector3(0.0f, -90.0f, 0.0f);

			DamageZone[i].MoveAndRotate(newPosition, newAngle);

			//DamageZone[i].GetGameObject().transform.position = new Vector3(15.70469f, 0.7570782f, 5.772846f) + new Vector3(0.0f, 0.01f * i, 2.0f * i);
			//DamageZone[i].GetGameObject().transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
		}
	}
	
	public void AddToDropZone(Card card, bool bFromField)
	{
		DropZone.Add(card);
		card.TurnUp();
		card.StandEnemy();
		//card.GetGameObject().transform.position = fieldInfo.GetPosition((int)fieldPositions.DROP_ZONE) + new Vector3(0.0f, 0.01f * (DropZone.Count - 1), 0.0f);
		//card.GetGameObject().transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

		card.MoveAndRotate(fieldInfo.GetPosition((int)fieldPositions.DROP_ZONE) + new Vector3(0.0f, 0.01f * (DropZone.Count - 1), 0.0f),
		                   new Vector3(0.0f, 0.0f, 0.0f));

		if(bFromField)
		{
			//Game.playerHand.CheckHandEffects(CardState.EnemyCardSendToDropZone);
			//Game.field.CheckAbilities(CardState.EnemyCardSendToDropZone);
		}
	}
	
	public int DropZoneSize()
	{
		return DropZone.Count;	
	}
	
	public void AddToDropZoneList(Card card)
	{
		DropZone.Add(card);
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
	
	public Card RemoveFrom(EnemyFieldPosition pos)
	{
		Card CardToReturn = null;
		
		if(pos == EnemyFieldPosition.FRONT_LEFT)
		{
			CardToReturn = Left_Front;
			Left_Front = null;
		}
		else if(pos == EnemyFieldPosition.FRONT_RIGHT)
		{
			CardToReturn = Right_Front;
			Right_Front = null;
		}
		else if(pos == EnemyFieldPosition.REAR_CENTER)
		{
			CardToReturn = Center_Rear;
			Center_Rear = null;
		}
		else if(pos == EnemyFieldPosition.REAR_LEFT)
		{
			CardToReturn = Left_Rear;
			Left_Rear = null;
		}
		else if(pos == EnemyFieldPosition.REAR_RIGHT)
		{
			CardToReturn = Right_Rear;
			Right_Rear = null;
		}
		
		return CardToReturn;
	}
	
	public Card GetCardAt(EnemyFieldPosition pos)
	{
		if(pos == EnemyFieldPosition.FRONT_LEFT) return Left_Front;
		else if(pos == EnemyFieldPosition.FRONT_RIGHT) return Right_Front;
		else if(pos == EnemyFieldPosition.REAR_CENTER) return Center_Rear;
		else if(pos == EnemyFieldPosition.REAR_LEFT) return Left_Rear;
		else if(pos == EnemyFieldPosition.REAR_RIGHT) return Right_Rear;
		else if(pos == EnemyFieldPosition.VANGUARD)  
		{
			//Debug.Log("Vanguard");
			return Vanguard;
		}
		else return null;
	}
	
	public void StandAllUnits()
	{
		if(Vanguard != null)
		{
			Vanguard.StandEnemy();
			
		}
		
		if(Left_Front != null)
		{
			Left_Front.StandEnemy();
			
		}
		
		if(Right_Front != null)
		{
			Right_Front.StandEnemy();
			
		}
		
		if(Center_Rear != null)
		{
			Center_Rear.StandEnemy();
			
		}
		
		if(Left_Rear != null)
		{
			Left_Rear.StandEnemy();
			
		}
		
		if(Right_Rear != null)
		{
			Right_Rear.StandEnemy();
			
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
	
	public void ClearZone(EnemyFieldPosition pos)
	{
		if(pos == EnemyFieldPosition.FRONT_LEFT)
			Left_Front = null;
		
		if(pos == EnemyFieldPosition.FRONT_RIGHT)
			Right_Front = null;

		if(pos == EnemyFieldPosition.REAR_CENTER)
		{
			Center_Rear = null;	
		}
		
		if(pos == EnemyFieldPosition.REAR_RIGHT)
		{
			Right_Rear = null;	
		}
		
		if(pos == EnemyFieldPosition.REAR_LEFT)
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
	
	public Card RemoveFromDamage(int idx)
	{
		Card cardToReturn = DamageZone[idx];
		DamageZone.RemoveAt(idx);
		FixPosition();
		return cardToReturn;
	}
	
	public void RemoveFromDamage(Card c)
	{
		DamageZone.Remove(c);
		FixPosition();
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
	
	public int GetNumberOfUnitGradeEqualOrLessThan(int _grade)
	{
		int num = 0;
		if(Left_Front != null && Left_Front.grade <= _grade)
			num++;
		
		if(Right_Front != null && Right_Front.grade <= _grade)
			num++;
		
		if(Center_Rear != null && Center_Rear.grade <= _grade)
			num++;
		
		if(Left_Rear != null && Left_Rear.grade <= _grade)
			num++;
		
		if(Right_Rear != null && Right_Rear.grade <= _grade)
			num++;
		
		return num;
	}
	
	public int GetNumberOfRearUnits()
	{
		int num = 0;
		if(Left_Front != null)
			num++;
		
		if(Right_Front != null)
			num++;
		
		if(Center_Rear != null)
			num++;
		
		if(Left_Rear != null)
			num++;
		
		if(Right_Rear != null)
			num++;
		
		return num;		
	}
	
	public Card GetCardFromSoulByID(CardIdentifier id)
	{
		for(int i = 0; i < Soul.Count - 1; i++)
		{
			if(Soul[i].cardID == id)
			{
				return Soul[i];	
			}
		}

		return null;
		/*
		for(int i = Soul.Count - 2; i >= 0; i--)
		{
			if(Soul[i].cardID == id)
			{
				return Soul[i];	
			}
		}
		
		return null;
		*/
	}
	
	public void AddToSoul(Card card)
	{
		Soul.Insert(0, card);	
	}
	
	public void RemoveFromSoul(Card card)
	{
		Soul.Remove(card);
	}
	
	public void MoveToSoul(EnemyFieldPosition pos)
	{
		Card CardToMove = null;
		CardToMove = GetCardAt(pos);
		AddToSoul(CardToMove);
		Vector3 newPosition = fieldInfo.GetPosition((int)EnemyFieldPosition.VANGUARD) + new Vector3(0, -0.01f, 0);
		CardToMove.GoTo(newPosition.x, newPosition.z);
	}
	
	public void MoveToSoul(Card c)
	{
		Card CardToMove = c;
		AddToSoul(CardToMove);
		Vector3 newPosition = fieldInfo.GetPosition((int)EnemyFieldPosition.VANGUARD) + new Vector3(0, -0.01f, 0);
		CardToMove.GoTo(newPosition.x, newPosition.z);
	}
	
	public void Move(Card card)
	{
		
		if(card.pos == fieldPositions.ENEMY_FRONT_LEFT)
		{
			Vector3 RearLeftPos = fieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_REAR_LEFT));
			Vector3 FrontLeftPos = fieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_FRONT_LEFT));
			
			if(Left_Rear != null)
			{
				Left_Front     = Left_Rear;
				Left_Rear      = card;
				Left_Front.pos = fieldPositions.ENEMY_FRONT_LEFT;
				Left_Rear.pos  = fieldPositions.ENEMY_REAR_LEFT;
				
				Left_Front.GoTo(FrontLeftPos.x, FrontLeftPos.z);
				Left_Rear.GoTo(RearLeftPos.x, RearLeftPos.z);
			}
			else
			{
				Left_Rear      = card;
				Left_Rear.pos  = fieldPositions.ENEMY_REAR_LEFT;
				Left_Rear.GoTo(RearLeftPos.x, RearLeftPos.z);
				ClearZone(Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_FRONT_LEFT));
			}
		}
		else if(card.pos == fieldPositions.ENEMY_REAR_LEFT)
		{
			Vector3 RearLeftPos = fieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_REAR_LEFT));
			Vector3 FrontLeftPos = fieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_FRONT_LEFT));
			
			if(Left_Front != null)
			{
				Left_Rear      = Left_Front;
				Left_Front     = card;
				Left_Front.pos = fieldPositions.ENEMY_FRONT_LEFT;
				Left_Rear.pos  = fieldPositions.ENEMY_REAR_LEFT;
				
				Left_Front.GoTo(FrontLeftPos.x, FrontLeftPos.z);
				Left_Rear.GoTo(RearLeftPos.x, RearLeftPos.z);
			}
			else
			{
				Left_Front      = card;
				Left_Front.pos  = fieldPositions.ENEMY_FRONT_LEFT;
				Left_Front.GoTo(FrontLeftPos.x, FrontLeftPos.z);
				ClearZone(Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_REAR_LEFT));
			}
		}
		else if(card.pos == fieldPositions.ENEMY_FRONT_RIGHT)
		{
			Vector3 RearRightPos = fieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_REAR_RIGHT));
			Vector3 FrontRightPos = fieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_FRONT_RIGHT));
			
			if(Right_Rear != null)
			{
				Right_Front     = Right_Rear;
				Right_Rear      = card;
				Right_Front.pos = fieldPositions.ENEMY_FRONT_RIGHT;
				Right_Rear.pos  = fieldPositions.ENEMY_REAR_RIGHT;
				
				Right_Front.GoTo(FrontRightPos.x, FrontRightPos.z);
				Right_Rear.GoTo(RearRightPos.x, RearRightPos.z);
			}
			else
			{
				Right_Rear      = card;
				Right_Rear.pos  = fieldPositions.ENEMY_REAR_RIGHT;
				Right_Rear.GoTo(RearRightPos.x, RearRightPos.z);
				ClearZone(Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_FRONT_RIGHT));
			}
		}
		else if(card.pos == fieldPositions.ENEMY_REAR_RIGHT)
		{
			Vector3 RearRightPos = fieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_REAR_RIGHT));
			Vector3 FrontRightPos = fieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_FRONT_RIGHT));
			
			if(Right_Front != null)
			{
				Right_Rear      = Right_Front;
				Right_Front     = card;
				Right_Front.pos = fieldPositions.ENEMY_FRONT_RIGHT;
				Right_Rear.pos  = fieldPositions.ENEMY_REAR_RIGHT;
				
				Right_Front.GoTo(FrontRightPos.x, FrontRightPos.z);
				Right_Rear.GoTo(RearRightPos.x, RearRightPos.z);
			}
			else
			{
				Right_Front      = card;
				Right_Front.pos  = fieldPositions.ENEMY_FRONT_RIGHT;
				Right_Front.GoTo(FrontRightPos.x, FrontRightPos.z);
				ClearZone(Util.TransformToEquivalentEnemyPosition(fieldPositions.ENEMY_REAR_RIGHT));
			}
		}
	}

	List<CardIdentifier>  CardSelectedVector   = new List<CardIdentifier>();
	List<Game2DCard> 	  TotalCards           = new List<Game2DCard>();
	List<Game2DCard>      CardsWatching        = new List<Game2DCard>();
	bool                  bViewMode            = false;
	bool                  bViewingDeck         = false;
	int                   numSelections        = 0;
	int                   cur2DCardSelected    = 0;
	int                   curOffset            = 0;

	private void InitViewBindZone(int numSelections)
	{
		bViewMode = false;
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
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

	public void ViewBindZone(int numSelections, FieldGlobalVar.CountConstraint fnc = null)
	{
		InitViewBindZone(numSelections);
		
		for(int i = 0; i < BindZone.Count; i++)
		{
			if(fnc(BindZone[i]) || fnc == null)
			{
				TotalCards.Add(new Game2DCard(Game.Data.GetCardInfo(BindZone[i].cardID)));
			}
		}
		
		FillViewBindZone();
	}

	public bool ViewingBind()
	{
		return bViewingDeck;
	}

	public List<CardIdentifier> GetLastSelectedList()
	{
		return CardSelectedVector;
	}

	public void CloseDeck()
	{
		bViewingDeck = false;	
		Game.bBlockMouseOnce = true;
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
		return true;
	}
}
