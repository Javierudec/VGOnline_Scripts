using UnityEngine;
using System.Collections;

public class BeastDeityBrainyPapio : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard()
			   && CB(1, delegate(Card c) { return c.name.Contains("Beast Deity"); })
			   && VanguardIs("Nova Grappler")
			   && NumUnits (delegate(Card c) { return c.BelongsToClan("Nova Grappler") && c != OwnerCard; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit("Choose another of your \"Nova Grappler\" rear-guards.", 1, true,
				delegate {
					StandUnit(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Nova Grappler") && Unit != OwnerCard;
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
