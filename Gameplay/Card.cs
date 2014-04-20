using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card {
	CardAnimationManager _CardAnimationManager = null;
	HandleEffects _HandleEffects = null;
	private GameObject go;
	private Material faceDownMat;
	public Material faceUpMat;
	private bool bRest; //If a card is in horizontal position this variable is true.
	private bool bDoRestAnimation;
	private bool bDoStandAnimation;
	private bool bDoEnemyRestAnimation;
	private bool bDoEnemyStandAnimation;
	public bool bDoAnimatedFlip;
	public int grade;
	public TriggerIcon trigger;
	public SkillIcon skill;
	public int shield;
	public string name;
	public string race;
	public string clan;
	public string secondaryClan;
	public int critical;
	public int extraCritical;
	public int endTurnCritical;
	public int extraShield = 0;
	public int power;
	public int extraPower;
	public int endTurnPower;
	public CardIdentifier cardID;
	public bool bBecomeStandThisTurn = false;
	private bool bIsVanguard = false;
	public fieldPositions pos = fieldPositions.DECK_ZONE;
	public Card boostedUnit = null;
	public bool bIsFaceUP = false;
	public bool bIsInhand = false;
	private float flipOffsetY = 0.0f;
	private Vector3 OriginalPosition;
	private Vector3 OriginalAngle;
	private int persistentPower = 0;
	public bool bDisableTwinDrive = false;
	public bool bCanBeBoostedRearGuard = true;
	public bool bCanBeBoostedVanguard = true;
	private int persistentCritical = 0;
	public bool bRestrainRemoved = false;
	public bool bRestraintVanguard_Aux = false;
	public bool bRestraintRearGuard_Aux = false;
	public bool bRestraintVanguard = false;
	public bool bRestraintRearGuard = false;
	public bool bSentinel = false;
	public bool bBlockInterceptEndTurn = false;
	public bool bCanAttackRearGuard = true;
	public bool bBlockPersistentUntilEndTurn = false;
	public bool bHasLimitBreak4 = false;
	public bool bCanBeRetireByEffects = true;
	bool bFromBindToAnimation = false;
	float fAnimationDelay = 0.0f;
	public bool bLord = false;
	bool bBlockBoostConstraintEndTurn = false;

	public Card retireUnitOwner = null;
	
	public delegate void void0();
	public delegate bool boolDelegate(Card tmpC);
	boolDelegate CheckBoostConstraint = null;
	void0 fnc = null;
	
	Vector3 originalScale;
	
	public bool bCanStand = true;
	
	private int originalExtraPower = 0;
	private int originalEndPower = 0;
	
	public Card IsBoostedBy = null;
	
	public UnitAbility unitAbilities;
	
	//Return to deck animation
	private bool bGoingToAnimation = false;
	private bool bZReached = false;
	private bool bXReached = false;
	private bool bYReached = false;
	
	private Vector3 CustomPosition;
	
	public bool bCanBeHit = true;
	
	private Color OriginalColor;
	
	public CardCoord _Coord = CardCoord.DECK;
	
	public HandleMouse _HandleMouse = null;
	public HandleEnemyMouse _HandleEnemyMouse = null;
	
	public bool CanAttackBackRow = false;
	
	bool bDoSelectAnim = false;
	float fSelectColor;
	bool bFadeOut = false;
	
	bool bBindAnim = false;
	float bindScaleZ = 1.0f;
	string boostConstraintName = "";
	
	//Lock
	bool bIsLocked    = false;
	bool bLockAnim    = false;
	bool bUnlockAnim  = false;
	bool bIsOmegaLock = false;

	Color finalColor;
	float duration;
	float interpolateDuration = 0.4f;
	bool bFadeIn = true;

	List<string> extraClanList = new List<string>();
	
	public Card()
	{
		faceUpMat         = Resources.Load("n84", typeof(Material)) as Material;
		faceDownMat       = Resources.Load("FaceDownCard", typeof(Material)) as Material;
		
		Material mat = Resources.Load("FaceDownCard", typeof(Material)) as Material;
		faceDownMat = new Material (Shader.Find ("Diffuse"));
		faceDownMat.mainTexture = Resources.Load("FaceDownCard") as Texture;//mat.mainTexture;
		faceDownMat.mainTextureOffset = mat.mainTextureOffset;
		faceDownMat.mainTextureScale = mat.mainTextureScale;
		
		bRest             = false;
		bDoRestAnimation  = false;
		bDoEnemyRestAnimation = false;
		bDoStandAnimation = false;
		bDoAnimatedFlip = false;
		extraPower = 0;
		extraCritical = 0;
		endTurnPower = 0;
		
		secondaryClan = "None";
		
		unitAbilities = new UnitAbility(this);
		
		faceDownMat.color = Color.white;

		_CardAnimationManager = new CardAnimationManager(this);
	}
	
	public void Lock()
	{
		bIsLocked = true;
		bLockAnim = true;
		OriginalColor = faceUpMat.color;
		finalColor = Color.black;
		duration = interpolateDuration;
		bFadeIn = true;
	}
	
	public void Unlock()
	{
		bIsLocked = false;
		bUnlockAnim = true;
		OriginalColor = faceDownMat.color;
		finalColor = Color.black;
		duration = interpolateDuration;
		bFadeIn = true;
	}

	public void AddExtraClan(string clanName)
	{
		extraClanList.Add(clanName);
	}

	public void RemoveAllExtraClans()
	{
		extraClanList.Clear();
	}

	public void RemoveExtraClan(string clanName)
	{

	}
	
	public bool IsLocked()
	{
		return bIsLocked;	
	}

	public bool IsOmegaLock()
	{
		return bIsOmegaLock;
	}

	public void SetOmegaLock(bool value)
	{
		bIsOmegaLock = value;
	}

	public bool CanAttackPos(fieldPositions p)
	{
		if(!bCanAttackRearGuard && (p == fieldPositions.ENEMY_FRONT_RIGHT || p == fieldPositions.ENEMY_FRONT_LEFT))
		{
			return false;	
		}
		
		return true;	
	}
	
	public void DoSelectAnim()
	{
		bDoSelectAnim = true;
		fSelectColor = 1.0f;
		bFadeOut = true;
	}
	
	public void AddExtraShield(int extra)
	{
		extraShield += extra;
	}
	
	public int GetDefensePower()
	{
		return extraShield + GetPower();	
	}
	
	public void PerfectGuard()
	{
		bCanBeHit = false;	
	}
	
	public void SetGameObject(GameObject go, HandleMouse _m)
	{
		this.go = go;
		_m.SetCard(this);
		_HandleMouse = _m;
		originalScale = go.transform.localScale;
		_HandleEffects = (HandleEffects)go.GetComponent("HandleEffects");
	}

	public void SetGameObject(GameObject go, HandleEnemyMouse _m)
	{
		this.go = go;
		_m.SetCard(this);
		_HandleEnemyMouse = _m;
		originalScale = go.transform.localScale;
		_HandleEffects = (HandleEffects)go.GetComponent("HandleEffects");
	}
	
	public void SetGameObject(GameObject go)
	{
		this.go = go;
	}
	
	public GameObject GetGameObject()
	{
		return go;	
	}
	
	public bool CanBeHit()
	{
		return bCanBeHit;	
	}
	
	public void NegateStand()
	{
		bCanStand = false;	
		OriginalColor = faceUpMat.color;
		faceUpMat.color = Color.green;
	}
	
	public void IsTargetted(bool b)
	{
		if(b)
		{
			faceUpMat.color = Color.red;
		}
		else
		{
			faceUpMat.color = Color.white;	
		}
	}
	
	public void ClearNegateStand()
	{
		if(!bCanStand)
		{
			bCanStand = true;	
			faceUpMat.color = Color.white;
		}
	}
	
	public void NormalizeMaterial()
	{
		faceUpMat.color = Color.white;	
	}
	
	public void TurnUp()
	{
		go.renderer.material = faceUpMat;
		bIsFaceUP = true;
	}
	
	public bool IsFaceup()
	{
		return bIsFaceUP;
	}
	
	public void TurnDown()
	{
		go.renderer.material = faceDownMat;	
		bIsFaceUP = false;
	}
	
	public void SetFaceUpMaterial(Material mat)
	{
		faceUpMat = mat;	
	}
	
	public void BindAnim()
	{
		bBindAnim = true;	
		bindScaleZ = originalScale.z;
	}

	public bool MouseOn(float _x, float _y)
	{
		if(_x > go.transform.position.x && _y > go.transform.position.y && _x < (go.transform.position.x + 5.0f) && _y < (go.transform.position.y + 8.0f))
		{
			return true;	
		}
		
		return false; 
	}
	
	//Every frame...
	public void Update()
	{
		unitAbilities.Update();
		int speed = 100;
		int extra_power_original = originalEndPower + originalExtraPower;
		int extra_power_current = endTurnPower + extraPower;
		if(extra_power_current < extra_power_original)
		{
			if(endTurnPower < originalEndPower)
			{
				endTurnPower += speed;	
			}
			else
			{
				endTurnPower = originalEndPower;	
			}
			
			if(extraPower < originalExtraPower)
			{
				extraPower += speed;
			}
			else
			{
				extraPower = originalExtraPower;	
			}
		}
		else if(extra_power_current > extra_power_original)
		{
			if(endTurnPower > originalEndPower)
			{
				endTurnPower -= speed;	
			}
			else
			{
				endTurnPower = originalEndPower;	
			}
			
			if(extraPower > originalExtraPower)
			{
				extraPower -= speed;
			}
			else
			{
				extraPower = originalExtraPower;	
			}
		}

		_CardAnimationManager.Update();

		/*
		if(bDoRestAnimation)
		{
			if(go.transform.eulerAngles.y > 90.0f)
			{
				go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, go.transform.eulerAngles.y - 20.0f, go.transform.eulerAngles.z);
			}
			else
			{
				go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, 90.0f, go.transform.eulerAngles.z);
				bDoRestAnimation = false;
			}
		}
		*/
		
		if(bDoEnemyRestAnimation)
		{
			if(go.transform.eulerAngles.y < 90.0f)
			{
				go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, go.transform.eulerAngles.y + 20.0f, go.transform.eulerAngles.z);
			}
			else
			{
				go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, 90.0f, go.transform.eulerAngles.z);
				bDoEnemyRestAnimation = false;
			}
		}
		
		if(bDoEnemyStandAnimation)
		{
			if(go.transform.eulerAngles.y >= 90.0f)
			{
				go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, go.transform.eulerAngles.y - 20.0f, go.transform.eulerAngles.z);
			}
			else
			{
				go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, 0.0f, go.transform.eulerAngles.z);
				bDoEnemyStandAnimation = false;
			}
		}
		
		if(bDoStandAnimation)
		{
			if(go.transform.eulerAngles.y < 180.0f)
			{
				go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, go.transform.eulerAngles.y + 20.0f, go.transform.eulerAngles.z);
			}
			else
			{
				go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, 180.0f, go.transform.eulerAngles.z);
				bDoStandAnimation = false;	
			}
		}
		
		if(bDoAnimatedFlip)
		{
			go.transform.eulerAngles += new Vector3(0.0f, 0.0f, 10.0f);
			
			if(go.transform.eulerAngles.z <= 90.0f)
			{
				flipOffsetY += 1.0f;	
				if(flipOffsetY >= 35.0f)
				{
					flipOffsetY = 35.0f;	
				}
			}
			else
			{
				flipOffsetY -= 0.5f;
				if(flipOffsetY < 0.0f)
				{
					flipOffsetY = 0.0f;	
				}
			}
			
			go.transform.position = new Vector3(OriginalPosition.x, OriginalPosition.y + flipOffsetY, OriginalPosition.z);
			
			if(go.transform.eulerAngles.z >= 330.0f)
			{
				go.transform.position = new Vector3(OriginalPosition.x, OriginalPosition.y, OriginalPosition.z);
				go.transform.eulerAngles = OriginalAngle;
				bDoAnimatedFlip = false;	
				flipOffsetY = 0.0f;
			} 
			else if(go.transform.eulerAngles.z >= 90.0f && go.transform.eulerAngles.z < 270.0f)
			{
				TurnUp();
				go.transform.eulerAngles = new Vector3(go.transform.eulerAngles.x, go.transform.eulerAngles.y, 270.0f);
			}
		}
		
		if(bFromBindToAnimation)
		{
			if(fAnimationDelay <= 0)
			{
				bFromBindToAnimation = false;
				if(fnc != null)
				{
					fnc();
					fnc = null;
				}
			}
			else
			{
				fAnimationDelay -= Time.deltaTime;	
			}
		}
		
		if(bGoingToAnimation)
		{
			float _speed = 60;
			
			Vector3 CurPosition = go.transform.position;
			//go.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
			if(!bXReached)
			{
				if(Mathf.Abs (CurPosition.x - CustomPosition.x) > 0.5f)
				{
					if(CurPosition.x < CustomPosition.x)
						CurPosition.x += _speed * Time.deltaTime;
					else
						CurPosition.x -= _speed * Time.deltaTime;
				}
				else
				{
					CurPosition.x = CustomPosition.x;	
					bXReached = true;
				}
			}
			
			if(!bYReached)
			{
				if(Mathf.Abs (CurPosition.y - CustomPosition.y) > 0.5f)
				{
					if(CurPosition.y < CustomPosition.y)
						CurPosition.y += _speed * Time.deltaTime;
					else
						CurPosition.y -= _speed * Time.deltaTime;
				}
				else
				{
					CurPosition.y = CustomPosition.y;	
					bYReached = true;
				}
			}
			
			if(!bZReached)
			{
				if(Mathf.Abs (CurPosition.z - CustomPosition.z) > 0.5f)
				{
					if(CurPosition.z < CustomPosition.z)
						CurPosition.z += _speed * Time.deltaTime;
					else
						CurPosition.z -= _speed * Time.deltaTime;
				}
				else
				{
					CurPosition.z = CustomPosition.z;	
					bZReached = true;
				}
			}
			
			go.transform.position = new Vector3(CurPosition.x, CurPosition.y, CurPosition.z);
			if(bXReached && bZReached && bYReached)
			{
				bGoingToAnimation = false;	
				//TurnDown();
			}
		}
		
		if(bDoSelectAnim)
		{	
			if(bFadeOut)
			{
				fSelectColor -= 0.01f;
			}
			else
			{
				fSelectColor += 0.01f;	
			}
			
			if(fSelectColor >= 1.0f)
			{
				bDoSelectAnim = false;	
				if(faceUpMat != null)
				{
					faceUpMat.color = Color.white;
				}
				
				faceDownMat.color = Color.white;
			}
			
			if(fSelectColor <= 0.80f)
			{
				bFadeOut = false;	
			}
			
			if(faceUpMat != null)
			{
				faceUpMat.color = new Color(fSelectColor, fSelectColor, 1.0f, 1.0f);
			}
			faceDownMat.color = new Color(fSelectColor, fSelectColor, 1.0f, 1.0f);
		}
		
		if(bBindAnim)
		{
			go.transform.localScale = new Vector3(go.transform.localScale.x ,go.transform.localScale.y, bindScaleZ);
			bindScaleZ -= 0.05f * bindScaleZ;
			if(bindScaleZ <= 0.3f)
			{
				bindScaleZ = 0.0f;
				go.transform.localScale = new Vector3(go.transform.localScale.x ,go.transform.localScale.y, bindScaleZ);
				go.transform.position = new Vector3(-100.0f, -100.0f, -100.0f);
				go.transform.localScale = originalScale;
				bBindAnim = false;
			}
		}
		
		if(bLockAnim)
		{
			duration -= Time.deltaTime;
      		float mLerp = (interpolateDuration - duration ) / interpolateDuration;
			if(bFadeIn)
			{
				faceUpMat.color = Color.Lerp(OriginalColor, finalColor, mLerp);
				if(faceUpMat.color == finalColor)
				{
					go.renderer.material = faceDownMat;	
					faceDownMat.color = finalColor;
					faceUpMat.color = OriginalColor;
					bFadeIn = false;
					duration = interpolateDuration;
				}
			}
			else
			{
				faceDownMat.color = Color.Lerp(finalColor, OriginalColor, mLerp);
				if(faceDownMat.color == OriginalColor)
				{
					bLockAnim = false;
					_HandleEffects.ActiveLockEffect(pos);
				}				
			}
		}
		
		if(bUnlockAnim)
		{
			duration -= Time.deltaTime;
      		float mLerp = (interpolateDuration - duration ) / interpolateDuration;
			if(bFadeIn)
			{
				faceDownMat.color = Color.Lerp(OriginalColor, finalColor, mLerp);
				if(faceDownMat.color == finalColor)
				{
					go.renderer.material = faceUpMat;	
					faceUpMat.color = finalColor;
					faceDownMat.color = OriginalColor;
					bFadeIn = false;
					duration = interpolateDuration;
				}
			}
			else
			{
				faceUpMat.color = Color.Lerp(finalColor, OriginalColor, mLerp);
				if(faceUpMat.color == OriginalColor)
				{
					bUnlockAnim = false;
					_HandleEffects.EndLockEffect();
					if(_Coord == CardCoord.ENEMY_FIELD)
					{
						StandEnemy();	
					}
					else
					{
						Stand();	
					}
				}				
			}
		}
	}
	
	public bool AnimationOngoing()
	{
		return bDoAnimatedFlip        || 
			   bDoEnemyRestAnimation  || 
		       bDoEnemyStandAnimation ||
			   bDoRestAnimation       ||
			   bDoStandAnimation      ||
			   bGoingToAnimation      || 
			   bBindAnim              ||
			   bLockAnim              ||
			   bFromBindToAnimation   ||
			   _CardAnimationManager.IsActive();	
	}
	
	public void Stand()
	{
		bDoStandAnimation = true;
		bRest = false;
	}
	
	public void Rest()
	{
		//bDoRestAnimation = true;
		_CardAnimationManager.AddAnimation(new CARest(this));
		bRest = true;
	}

	public void MoveAndRotate(Vector3 finalPosition)
	{
		_CardAnimationManager.AddAnimation(new CAMoveAndRotate(this, finalPosition));
	}

	public void Move(Vector3 finalPosition)
	{
		_CardAnimationManager.AddAnimation(new CAMove(this, finalPosition));
	}

	public void MoveAndRotate(Vector3 newPosition, Vector3 newAngle)
	{
		_CardAnimationManager.AddAnimation(new CAMoveAndRotate(this, newPosition, newAngle));

	}

	public void RestEnemy()
	{
		bDoEnemyRestAnimation = true;
		bRest = true;
	}
	
	public void StandEnemy()
	{
		bDoEnemyStandAnimation = true;
		bRest = false;
	}
	
	public void SetBoostConstraint(boolDelegate bd, string name = "")
	{
		CheckBoostConstraint = bd;	
		boostConstraintName = name;
	}
	
	public List<string> GetContSkillsNames()
	{
		List<string> listToRet = new List<string>();
		
		if(bRestraintRearGuard || bRestraintVanguard)
		{
			listToRet.Add("Restraint");	
		}
		
		if(CheckBoostConstraint != null)
		{
			listToRet.Add(boostConstraintName);
		}
		
		return listToRet;
	}
	
	public int GetContSkillNumber()
	{
		int count = 0;
		if(bRestraintRearGuard || bRestraintVanguard)
		{
			count++;	
		}
		
		if(CheckBoostConstraint != null)
		{
			count++;	
		}
		return count;
	}
	
	public void RemoveCONTAbility(string option)
	{
		if(option == "Restraint")
		{
			RemoveRestraint();	
		}
		else if(option == boostConstraintName)
		{
			bBlockBoostConstraintEndTurn = true;	
		}
	}
	
	public bool CanBoost(Card c = null)
	{
		return skill == SkillIcon.BOOST && (c == null || CheckBoostConstraint == null || bBlockBoostConstraintEndTurn || CheckBoostConstraint(c));	
	}
	
	public bool IsStand()
	{
		return !bRest;	
	}
	
	public int GetPower()
	{
		return power + extraPower + endTurnPower + persistentPower;	
	}
	
	public int GetTotalPower()
	{
		return power + originalExtraPower + originalEndPower + persistentPower;	
	}
	
	public void IncreasePower(int power)
	{
		originalExtraPower += power;
	}
	
	public void IncreasePowerUntilEndTurn(int power)
	{
		originalEndPower += power;
	}
	
	public void IncreaseCriticalUntilEndTurn(int critical)
	{
		endTurnCritical += critical;	
	}
	
	public void IncreaseCritical(int power)
	{
		extraCritical += power;	
	}
	
	public void ResetPower()
	{
		originalExtraPower = 0;	
		extraCritical = 0;
		extraShield = 0;
		bCanBeHit = true;
	}
	
	public bool IsPowerUp()
	{
		return extraPower != 0;	
	}

	public bool IsTrigger()
	{
		return trigger != TriggerIcon.NONE;	
	}
	
	public TriggerIcon GetTriggerType()
	{
		return trigger;	
	}
	
	public bool IsVanguard()
	{
		return bIsVanguard;	
	}
	
	public void SetIsVanguard(bool b)
	{
		bIsVanguard = b;	
	}
	
	public int GetCritical()
	{
		return critical + extraCritical + endTurnCritical + persistentCritical;
	}
	
	public bool hasTwinDrive()
	{
		return skill == SkillIcon.TWIN_DRIVE && !bDisableTwinDrive;	
	}
	
	public void BlockInterceptEndTurn()
	{
		bBlockInterceptEndTurn = true;	
	}
	
	public bool CanIntercept()
	{
		return skill == SkillIcon.INTERCEPT && !bBlockInterceptEndTurn;	
	}
	
	public void SetGame(Gameplay Game)
	{
		unitAbilities.SetGame(Game);	
	}
	
	public void CheckAbilities(CardState cs, Card effectOwner = null)
	{
		unitAbilities.CheckAbilities(cs, this, effectOwner);	
	}
	
	public void CheckExternAbilities(int id, CardState cs, Card effectOwner = null)
	{
		unitAbilities.CheckExternAbilities(id, cs, effectOwner);	
	}
	
	public void ResetEndTurnEffects()
	{
		originalEndPower = 0;
		endTurnCritical = 0;
		bDisableTwinDrive = false;
		bBlockInterceptEndTurn = false;
		bBlockPersistentUntilEndTurn = false;
		bBlockBoostConstraintEndTurn = false;
		bBecomeStandThisTurn = false;
		if(bRestrainRemoved)
		{
			bRestrainRemoved = false;
			bRestraintVanguard = bRestraintVanguard_Aux;
			bRestraintRearGuard = bRestraintRearGuard_Aux;
		}
	}
	
	public void AnimatedFlipup()
	{
		bDoAnimatedFlip = true;
		OriginalPosition = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z);
		OriginalAngle = go.transform.eulerAngles;
	}
	
	public void SetPersistentPower(int power)
	{
		persistentPower = power;
	}
	
	public void SetPersistentCritical(int critical)
	{
		persistentCritical = critical;	
	}
	
	public void GoTo(float newX, float newZ)
	{
		CustomPosition = new Vector3(newX, go.transform.position.y, newZ);
		
		bGoingToAnimation = true;
		bXReached = bZReached = false;
		bYReached = true;
	}

	public void GoTo(float newX, float newY, float newZ)
	{
		CustomPosition = new Vector3(newX, newY, newZ);
		
		bGoingToAnimation = true;
		bXReached = bZReached = bYReached = false;
	}
	
	public void SetRotation(float newX, float newY, float newZ)
	{
		go.transform.eulerAngles = new Vector3(newX, newY, newZ);	
	}
	
	public bool CanBeBoostedRearGuard()
	{
		return bCanBeBoostedRearGuard;	
	}
	
	public bool CanBeBoostedVanguard()
	{
		return bCanBeBoostedVanguard;	
	}
	
	public bool CanAttack()
	{
		bool bConstraint1 = true;
		
		//Restraint
		if(IsVanguard())
		{
			bConstraint1 = !bRestraintVanguard;	
		}
		else
		{
			bConstraint1 = !bRestraintRearGuard;	
		}
		
		return bConstraint1 && !IsLocked();
	}
	
	public bool BelongsToClan(string clanName)
	{
		return clanName == clan || clanName == secondaryClan || extraClanList.Contains(clanName);	
	}
	
	public void RemoveRestraint()
	{
		bRestraintRearGuard_Aux = bRestraintRearGuard;
		bRestraintVanguard_Aux  = bRestraintVanguard;
		bRestraintVanguard = false;
		bRestraintRearGuard = false;
		bRestrainRemoved = true;
	}
	
	public bool CanStand()
	{
		return bCanStand && !IsLocked();	
	}
	
	public int GetPersistentPower()
	{
		return persistentPower; 	
	}
	
	public void FromBindTo(Vector3 newPosition)
	{
		//Active code section in update method. Starts movement.
		bFromBindToAnimation = true;
		//Set the card position to Bind Position. 
		GetGameObject().transform.position = new Vector3(-15.96682f, 1.117453f, -1.65997f);
		
		//Set a delay, after that the card starts to move.
		fAnimationDelay = 0.7f;
		//Restore original form.
		go.transform.localScale = new Vector3(go.transform.localScale.x ,go.transform.localScale.y, 6.559607f);
	}
	
	public void FromEnemyBindTo(Vector2 newPosition, void0 _fnc)
	{
		fnc = _fnc;
		
		//Active code section in update method. Starts movement.
		bFromBindToAnimation = true;
		//Set the card position to Bind Position. 
		GetGameObject().transform.position = new Vector3(15.13079f, 2.502588f, 1.428336f);
		
		//Set a delay, after that the card starts to move.
		fAnimationDelay = 0.7f;
		//Restore original form.
		go.transform.localScale = new Vector3(go.transform.localScale.x ,go.transform.localScale.y, 6.559607f);
	}
	
	public void SetOpacity(bool bOpacity)
	{
		if(!bOpacity)
		{
			faceUpMat.color = new Color(faceUpMat.color.r, faceUpMat.color.g, faceUpMat.color.b, 0.6f);	
		}
		else
		{
			faceUpMat.color = new Color(faceUpMat.color.r, faceUpMat.color.g, faceUpMat.color.b, 1.0f);	
		}
	}
}

public enum CardCoord
{
	FIELD,
	DECK,
	DROP,
	DAMAGE,
	HAND,
	SOUL,
	ENEMY_HAND,
	NONE,
	BIND,
	ENEMY_BIND,
	ENEMY_DAMAGE,
	ENEMY_FIELD,
	GUARD
}