using UnityEngine;
using System.Collections;

public class HandleMouse : MonoBehaviour {
	private Card OwnerCard = null;
	private Gameplay Game;
	public bool mouseOn = false;
	// Use this for initialization
	void Start () {
		//OwnerCard = (Card)gameObject.GetComponent("Card");
		Game = (Gameplay)GameObject.FindGameObjectWithTag("MainCamera").GetComponent("Gameplay");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetCard(Card card)
	{
		OwnerCard = card;	
	}
	
	void OnMouseUp()
	{
		if(Game.field.ViewingDropZone()) return;

		if(OwnerCard != null && !OwnerCard.IsLocked())
		{
			if(Input.GetKey(KeyCode.A))
			{
				OwnerCard.unitAbilities.ReturnToHand(OwnerCard);
			}

			//Game.GameChat.AddChatMessage("ADMIN", "OwnerCard: " + OwnerCard.name);
			
			if(OwnerCard._Coord == CardCoord.GUARD)
			{
				Game.LastGuardCardSelected = OwnerCard;	
			}
			
			if(Game.gamePhase == GamePhase.MAIN_PHASE &&
			   Game._MouseHelper.GetAttachedCard() == null &&
			   (OwnerCard._Coord == CardCoord.HAND || OwnerCard._Coord == CardCoord.FIELD || OwnerCard._Coord == CardCoord.DROP) && 
			   !Game._CardMenu.IsOpen() &&
		       !Game.playerDeck.IsOpen() &&
			   !Game.bEffectOnGoing &&
			   !Game.field.ViewingSoul())
			{
				if(Game.bBlockMouseOnce)
				{
					Game.bBlockMouseOnce = false;
					return;
				}
				
				if(OwnerCard._Coord == CardCoord.HAND || OwnerCard._Coord == CardCoord.FIELD)
				{
					Game._CardMenu.Open(OwnerCard);	
				}
				else if(OwnerCard._Coord == CardCoord.DROP)
				{
					Game._CardMenu.OpenOnDrop(OwnerCard);	
				}
			}	
			
			if(OwnerCard._Coord == CardCoord.DAMAGE)
			{
				Game.LastDamageCardSelected = OwnerCard;
				/*
				Debug.Log ("Heal Drive Trigger");
				
				int idx = Game.field.RemoveFromDamage(OwnerCard);
				Game.field.AddToDropZone(OwnerCard);	
				Game.SendPacket(GameAction.HEAL_TRIGGER_SELECT, idx);
				
				Game.bHealDriveTrigger = false;
				Game.bChooseEffect = false;
				Game.bEffectOnGoing = false;
				Game._GameHelper.SetToNormal();
				*/
				
			}
			
			if(OwnerCard._Coord == CardCoord.DAMAGE && !Game.bHealTrigger)
			{
				Game._CardMenu.Open (OwnerCard);
			}
			
			if(OwnerCard._Coord == CardCoord.DAMAGE && Game.bHealTrigger && (Game.field.GetDamageIndexOf(OwnerCard) != (Game.field.GetDamage() - 1)))
			{
				int idx = Game.field.RemoveFromDamage(OwnerCard);
				Game.field.AddToDropZone(OwnerCard);	
				Game.SendPacket(GameAction.HEAL_TRIGGER_SELECT, idx);
				Game.bEffectOnGoing = false;
				Game.bHealTrigger = false;
				//Game.bChooseEffect = false;
				Game.bDamageCheckTrigger = false;
				Game._GameHelper.SetToNormal();
				Game.DamageCheck();
			}
			
			if(Game.gamePhase == GamePhase.GUARD)
			{
				if(Game.bBlockMouseOnce)
				{
					Game.bBlockMouseOnce = false;
					return;
				}
				
				if(Game.bEffectOnGoing)
				{
					return;	
				}
				
				if(Game.bDamageCheckTrigger)
				{
					return ;	
				}
				
				if(OwnerCard._Coord == CardCoord.HAND && Game.bCanNormalGuard)
				{
					if(Game.playerHand.GetCurrentCardObject().grade <= Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).grade)
					{
						int grade = Game.playerHand.GetCurrentCardObject().grade;
						if(Game.bBlockGuardEndBattle && grade <= Game.bMaxGuardGradeBlocked && grade >= Game.bMinGuardGradeBlocked)
						{
							return;	
						}
						
						Card tempCard = Game.playerHand.RemoveFromHand(Game.playerHand.GetCurrentCard());
						Game.guardZone.AddToGuardZone(tempCard, true);
						Game.SendPacket(GameAction.ADD_TO_GUARDZONE, tempCard.cardID);
						Game.CardToAttack.AddExtraShield(tempCard.shield);
						tempCard.CheckAbilities(CardState.UsedToGuard);
					}
				}
				else if(OwnerCard._Coord == CardCoord.FIELD && !Game.bBlockInterceptUntilEndTurn && !Game.bBlockInterceptUntilEndBattle)
				{
					fieldPositions tmp = Util.GetMousePosition();
					if(tmp == fieldPositions.FRONT_GUARD_LEFT || tmp == fieldPositions.FRONT_GUARD_RIGHT)
					{
						if(Game.field.GetCardAt(tmp).CanIntercept())
						{
							Card tempCard = Game.field.GetCardAt(tmp);
							if(tempCard != Game.CardToAttack)
							{
								Game.CardToAttack.AddExtraShield(tempCard.shield);
								Game.field.ClearZone(tempCard.pos);
								Game.SendPacket(GameAction.INTERCEPT, tempCard.pos); 
								Game.SendPacket(GameAction.CLEAR_ZONE, tempCard.pos);
								Game.guardZone.AddToGuardZone(tempCard, true);
								tempCard.CheckAbilities(CardState.Intercept);
							}
						}
					}					
				}	
			}
		}
	}
	
	void OnMouseOver()
	{
		if(Game.field.ViewingDropZone()) return;

		if(OwnerCard != null)
		{	
			mouseOn = true;
			if(!Game._CardMenu.IsOpen() && Game._MouseHelper.GetAttachedCard() == null && !Game.field.ViewingDropZone() && (OwnerCard.IsFaceup() || OwnerCard._Coord == CardCoord.DAMAGE))
			{
				Game._CardMenuHelper.SetCard(OwnerCard.cardID);
			}
			
			if(OwnerCard._Coord == CardCoord.HAND && !Game._CardMenu.IsOpen())
			{
				Game.playerHand.SetCardSelected(OwnerCard);
			}
		}
	}
	
	void OnMouseExit()
	{
		if(Game.field.ViewingDropZone()) return;

		mouseOn = false;	
	}
}
