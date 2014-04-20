using UnityEngine;
using System.Collections;

public class SilverThornDragonQueenLuquierReverse : UnitObject {
	Card unitCalled;

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(1)
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Pale Moon"); }) > 0
		   && NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Pale Moon"); }) > 0)
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
				SelectUnit("Choose one of your \"Pale Moon\" rear-guards.", 1, false,
				delegate {
					LockUnit(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Pale Moon");
				},
				delegate {
					SetBool(1);
					Game.field.ViewSoul(1, delegate(Card c) {
						return c.BelongsToClan("Pale Moon");
					});
				});
			});
		});

		ResolveSoulOpening(1,
		delegate {
			unitCalled = Game.field.GetSoulByID(_AuxIdVector[0]);
			CallFromSoul(unitCalled);
		},
		delegate {
			EndEffect();
		});

		CallFromSoulUpdate(delegate {
			IncreasePowerByTurn(unitCalled, 5000);
			EndEffect();
		});
	}

	public override void Cont ()
	{
		if(VC()
		   && IsInSoul(CardIdentifier.SILVER_THORN_DRAGON_TAMER__LUQUIER))
		{
			AddContPower(2000);
		}
	}
}
