using UnityEngine;
using System.Collections;

public class FlyingSwordLiberatorGorlois : UnitObject {
	public override int Act ()
	{
		if(RC ()
		   && NumUnitsDamage(delegate(Card c) { return c.name.Contains("Gancelot") && c.grade == 3; }) > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SetBool(1);
			Game.field.ViewDropZone(1, delegate(Card c) {
				return c.name.Contains("Gancelot");
			});
		});

		ResolveDropOpening(1,
		delegate {
			if(VanguardIs("Gold Paladin")
			   && NumUnits (delegate(Card c) { return c.name.Contains("Gancelot") && c.grade == 3; }, true) > 0)
			{
				SelectUnit("Choose one of your grade 3 units with \"Gancelot\" in its card name.", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 5000);
				},
				delegate {
					return Unit.grade == 3 && Unit.name.Contains("Gancelot");
				},
				delegate {

				}, true);
			}
			else
			{
				EndEffect();
			}
		},
		delegate {
			EndEffect();
		});
	}
}
