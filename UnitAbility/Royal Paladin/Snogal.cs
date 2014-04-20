using UnityEngine;
using System.Collections;

public class Snogal : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn() && !OwnerCard.IsVanguard())
		{	
			Game.field.InitFieldIterator();
			while(Game.field.HasNextField())
			{
				Card c = Game.field.CurrentFieldCard();
				if(c != null && c != OwnerCard && c.cardID == CardIdentifier.SNOGAL)
				{
					AddContPower(1000);	
				}
			}
		}
	}
}
