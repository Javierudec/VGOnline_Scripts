using UnityEngine;
using System.Collections;

public class AbacusBear : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC ()
			   && Game.DriveCard.grade == 3
			   && Game.DriveCard.BelongsToClan("Great Nature"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			int n = NumUnits (delegate(Card c) { return c.BelongsToClan("Great Nature"); });
			SelectUnit("Choose up to " + n + " of your \"Great Nature\" rear-guards.", n, true,
			delegate {
				IncreasePowerByTurn(Unit, 4000);
				Unit.unitAbilities.AddUnitObject(new AbacusBearEXT());
			},
			delegate {
				return Unit.BelongsToClan("Great Nature");
			},
			delegate {

			});
		});
	}

	public override void Pointer ()
	{
		SelectUnit_Pointer(true);
	}
}

public class AbacusBearEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			RetireUnit(OwnerCard);
		}
	}
}
