using UnityEngine;
using System.Collections;

public class DragonicOverlordTheEnd : UnitObject {
	public override void Cont()
	{
		if(NumUnits(delegate(Card c) { return !c.BelongsToClan("Kagero"); }, true) > 0)
		{
			AddContPower(-2000);
		}
		
		if(OwnerCard.IsVanguard() && Game.field.GetSoulByID(CardIdentifier.DRAGONIC_OVERLORD) != null)
		{
			AddContPower(2000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{
			if(OwnerCard.IsVanguard() &&
			   CB(2) &&
			   Game.playerHand.GetByID(OwnerCard.cardID) != null)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();
		FlipCardInDamageZone(2);
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose a " + OwnerCard.name + " from your hand.");	
		});
	}
	
	public override void Pointer()
	{	
		if(AcceptInput())
		{
			Card c = HandSelectedCard();
			if(ValidHand(c) && c.cardID == OwnerCard.cardID)
			{
				DiscardSelectedCard();
				StandUnit(OwnerCard);
				ClearPointer(); 
			}
		}
	}	
}
