using UnityEngine;
using System.Collections;

public class LeftArrester : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.pos == fieldPositions.FRONT_GUARD_LEFT)
		{
			if(GetVanguard().clan == "Murakumo")
			{
				Card c = Game.field.GetCardAt(fieldPositions.FRONT_GUARD_RIGHT);
				if(c != null && c.cardID == CardIdentifier.RIGHT_ARRESTER)
				{
					AddContPower(3000);
				}
			}
		}
	}
}
