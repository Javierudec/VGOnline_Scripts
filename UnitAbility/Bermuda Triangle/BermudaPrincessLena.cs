using UnityEngine;
using System.Collections;

public class BermudaPrincessLena : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn() && OwnerCard.IsVanguard() && NumUnits (delegate(Card c) { return c.BelongsToClan("Bermud Triangle"); }) >= 4)
		{
			AddContPower(3000);
		}
	}
	
	public override void Auto(CardState s, Card effectOwner)
	{
		if(s == CardState.Ride)
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			Game.field.InitFieldIterator();
			while(Game.field.HasNextField())
			{
				Card c = Game.field.CurrentFieldCard();
				if(c != null && !c.IsVanguard())
				{
					ReturnToHand(c);	
				}
				EndEffect();
			}
		});
	}
}
