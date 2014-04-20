using UnityEngine;
using System.Collections;

public class StrongestBeastDeityEthicsBusterExtreme : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC ()
			   && LimitBreak(4)
			   && Game.DriveCard.grade >= 1
			   && Game.DriveCard.name.Contains("Beast Deity")
			   && NumUnits(delegate(Card c) { return c.BelongsToClan("Nova Grappler") && !c.IsStand(); }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			SelectUnit ("Choose one of your \"Nova Grappler\" rear-guards.", 1, true,
			delegate {
				StandUnit(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Nova Grappler") && !Unit.IsStand();
			},
			delegate {

			});
		});
	}

	public override void Cont ()
	{
		if(VC()
		   && IsInSoul(CardIdentifier.BEAST_DEITY__ETHICS_BUSTER))
		{
			AddContPower(2000);
		}
	}
}
