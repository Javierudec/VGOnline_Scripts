using UnityEngine;
using System.Collections;

public class GoddessOfFlowerDivinationSakuya : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn() &&
		   Game.playerHand.Size() >= 4)
		{
			AddContPower(4000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Ride)
		{
			ShowAndDelay();
			StartEffect();
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			Game.field.InitFieldIterator();
			while(Game.field.HasNextField())
			{
				Card c = Game.field.CurrentFieldCard();
				if(c != null && !c.IsVanguard() && c.clan == "Oracle Think Tank")
				{
					ReturnToHand(c);
				}
			}
			EndEffect();
		});
	}
}
