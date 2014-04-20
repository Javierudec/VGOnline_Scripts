using UnityEngine;
using System.Collections;

public class DiscerningEyeSkyTrooper : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC ()
			   && Game.DriveCard.grade == 3
			   && Game.DriveCard.BelongsToClan("Aqua Force")
			   && NumUnits (delegate(Card c) { return !c.IsStand(); }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your rear-guards.", 1, true,
			delegate {
				StandUnit(Unit);
			},
			delegate {
				return !Unit.IsStand();
			},
			delegate {

			});
		});
	}
}
