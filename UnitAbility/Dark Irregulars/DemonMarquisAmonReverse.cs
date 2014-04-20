using UnityEngine;
using System.Collections;

public class DemonMarquisAmonReverse : UnitObject {
	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) > 0
		   && !GetBool(1))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your \"Dark Irregulars\" rear-guards.", 1, true,
			delegate {
				LockUnit(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Dark Irregulars");
			},
			delegate {
				int n = NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); });
				IncreasePowerByTurn(OwnerCard, 1000 * n);
				if(n >= 6)
				{
					IncreasePowerAndCriticalByTurn(OwnerCard, 0, 1);
				}
				SetBool(1);
			});
		});
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			UnsetBool(1);
		}
	}

	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.DEMON_WORLD_MARQUIS__AMON))
		{
			AddContPower(2000);
		}
	}
}
