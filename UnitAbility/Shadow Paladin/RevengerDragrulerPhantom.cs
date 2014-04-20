using UnityEngine;
using System.Collections;

public class RevengerDragrulerPhantom : UnitObject {
	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(1)
		   && NumUnits(delegate(Card c) { return c.name.Contains("Revenger"); }) >= 2)
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
				SelectUnit("Choose two of your rear-guards with \"Revenger\" in its card name.", 2, false,
				delegate {
					RetireUnit (Unit);
				},
				delegate {
					return Unit.name.Contains("Revenger");
				},
				delegate {
					IncreasePowerByTurn(OwnerCard, 10000);
					
					if(Game.enemyField.GetDamage() <= 4)
					{
						DoDamageToVanguard();
					}
					else
					{
						EndEffect ();
					}
				});
			});
		});
	}

	public override void EndEvent ()
	{
		EndEffect();
	}

	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.ILLUSIONARY_REVENGER__MORDRED_PHANTOM))
		{
			AddContPower(2000);
		}
	}
}
