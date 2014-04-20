using UnityEngine;
using System.Collections;

public class BeastDeityMaxBeat : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Stand)
		{
			if(RC()
			   && CB(1, delegate(Card c) { return c.name.Contains("Beast Deity"); })
			   && CurrentPhaseIs(GamePhase.ATTACK)
			   && VanguardIs("Nova Grappler")
			   && NumUnits (delegate(Card c) { return c != OwnerCard && !c.IsStand(); }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			CounterBlast(1,
			delegate {
				SelectUnit("Choose another of your \"Nova Grappler\" rear-guards.", 1, true,
				delegate {
					StandUnit(Unit);
				},
				delegate {
					return Unit.name.Contains("Beast Deity");
				},
				delegate {

				});
			},
			delegate(Card c) {
				return c.name.Contains("Beast Deity");
			});
		});
	}
}
