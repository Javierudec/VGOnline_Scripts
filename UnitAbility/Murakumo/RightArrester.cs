using UnityEngine;
using System.Collections;

public class RightArrester : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.pos == fieldPositions.FRONT_GUARD_RIGHT)
		{
			if(GetVanguard().clan == "Murakumo")
			{
				Card c = Game.field.GetCardAt(fieldPositions.FRONT_GUARD_LEFT);
				if(c != null && c.cardID == CardIdentifier.LEFT_ARRESTER)
				{
					AddContPower(3000);
				}
			}
		}
	}
}
