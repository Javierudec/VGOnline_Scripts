using UnityEngine;
using System.Collections;

public class PerfectRaizer : UnitObject {
	public override void Cont()
	{
		if(Game.field.NameContains("Raizer") <= 1)
		{
			AddContPower(-2000);
		}
		
		if(OwnerCard.IsVanguard() && IsPlayerTurn())
		{
			int n = Game.field.SoulNameContains("Raizer");
			
			AddContPower(n * 3000);
			
			if(n >= 4)
			{
				AddContCritical(1);	
			}
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Ride)
		{
			Game.field.InitFieldIterator();
			while(Game.field.HasNextField())
			{
				Card c = Game.field.CurrentFieldCard();
				if(c != null && !c.IsVanguard() && c.name.Contains("Raizer"))
				{
					MoveToSoul(c);
				}
			}
		}
	}
}
