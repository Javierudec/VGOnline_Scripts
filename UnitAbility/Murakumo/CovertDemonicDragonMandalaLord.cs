using UnityEngine;
using System.Collections;

public class CovertDemonicDragonMandalaLord : UnitObject {
	public override void Cont()
	{
		if(NumUnits(delegate(Card c) { return !c.BelongsToClan("Murakumo"); }) > 0)
		{
			AddContPower(-2000);
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacked)
		{
			if(Game.playerHand.GetByID(OwnerCard.cardID) != null &&
			   CB(1) &&
			   OwnerCard.IsVanguard())
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();	
		FlipCardInDamageZone(1);
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
				IncreaseEnemyPowerByBattle(GetAttacker(), -10000);
				ClearPointer();
			}
		}
	}
}
