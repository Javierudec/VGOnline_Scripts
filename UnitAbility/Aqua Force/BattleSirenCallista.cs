using UnityEngine;
using System.Collections;

public class BattleSirenCallista : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor ().IsVanguard()
			   && CB (1)
			   && VanguardIs("Aqua Force")
			   && Game.numBattle >= 4
			   && NumUnits(delegate(Card c) { return c.BelongsToClan("Aqua Force") && c != OwnerCard; }) > 0)
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
				SelectUnit ("Choose another of your \"Aqua Force\" rear-guards.", 1, true,
				delegate {
					StandUnit(Unit);
					IncreasePowerByTurn(Unit, 5000);
				},
				delegate {
					return Unit.BelongsToClan("Aqua Force") && Unit != OwnerCard;
				},
				delegate {

				});
			});
		});
	}
}
