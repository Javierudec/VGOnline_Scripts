using UnityEngine;
using System.Collections;

public class KingOfMasksDantarian : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4)
			   && GetVanguard().BelongsToClan("Dark Irregulars"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC()
			   && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
				SetBool(1);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool (1);
				SoulCharge(1);
			}
			else
			{
				IncreasePowerByTurn(GetVanguard(), 10000);
				int n = min(3, NumUnits (delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }));
				SelectUnit("Choose " + n + " of your \"Dark Irregulars\" rear-guards.", n, true,
				delegate {
					Unit.unitAbilities.AddUnitObject(new KingOfMasksDantarianEXT());
				},
				delegate {
					return Unit.BelongsToClan("Dark Irregulars");
				},
				delegate {

				});
			}
		});

		SoulChargeUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 1000);
			EndEffect();
		});
	}
}

public class KingOfMasksDantarianEXT : UnitObject {
	public override void Cont ()
	{
		if(RC ())
		{
			AddContPower(1000 * NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }));
		}
	}
}
