using UnityEngine;
using System.Collections;

public class RaizerCustom : UnitObject {
	public override void Cont()
	{
		Card c = GetSameColum(OwnerCard.pos);
		if(IsPlayerTurn() && c != null && c.cardID == CardIdentifier.BATTLERAIZER)
		{
			AddContPower(8000);
		}
	}
}
