using UnityEngine;
using System.Collections;

public class Brugal : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn() && !OwnerCard.IsVanguard())
		{	
			Game.field.InitFieldIterator();
			while(Game.field.HasNextField())
			{
				Card c = Game.field.CurrentFieldCard();
				if(c != null && c != OwnerCard && c.cardID == CardIdentifier.BRUGAL)
				{
					AddContPower(1000);	
				}
			}
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().clan == "Royal Paladin")
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();	
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CallFromSoul(OwnerCard);	
		});
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
}
