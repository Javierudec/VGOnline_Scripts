using UnityEngine;
using System.Collections;

public class SamuraiSpirit : UnitObject {
	public override int EffectOnDrop ()
	{
		if(CB(1)
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Granblue"); }) > 0
		   && VanguardIs("Granblue"))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit ("Choose one of your \"Granblue\" rear-guards.", 1, false,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Granblue");
				},
				delegate {
					CallFromDrop(OwnerCard);
				});
			});
		});

		CallFromDropUpdate(delegate {
			EndEffect();
		});
	}
}
