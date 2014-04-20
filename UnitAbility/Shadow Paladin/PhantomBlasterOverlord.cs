using UnityEngine;
using System.Collections;

public class PhantomBlasterOverlord : UnitObject {
	public override void Cont()
	{
		if(NumUnits (delegate(Card c) { return !c.BelongsToClan("Shadow Paladin"); }, true) > 0)
		{
			AddContPower(-2000);
		}
		
		if(OwnerCard.IsVanguard() && Game.field.GetSoulByID(CardIdentifier.PHANTOM_BLASTER_DRAGON) != null)
		{
			AddContPower(2000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			if(OwnerCard.IsVanguard() &&
			   CB(3) &&
			   Game.playerHand.GetByID(OwnerCard.cardID) != null)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();
		FlipCardInDamageZone(3);
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
				IncreasePowerAndCriticalByTurn(OwnerCard, 10000, 1);
				ClearPointer();
			}
		}
	}
}
