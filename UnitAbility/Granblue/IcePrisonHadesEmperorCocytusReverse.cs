using UnityEngine;
using System.Collections;

public class IcePrisonHadesEmperorCocytusReverse : UnitObject {
	Card unitCalled = null;

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && GetDeck().Size() >= 3
		   && NumUnits (delegate(Card c) { return c.BelongsToClan("Granblue"); }) > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			Mill (3);
		});

		MillUpdate(delegate {
			SelectUnit ("Choose one of your \"Granblue\" rear-guards.", 1, false,
			delegate {
				LockUnit(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Granblue");
			},
			delegate {
				SetBool(1);
				Game.field.ViewDropZone(1, delegate(Card c) {
					return c.BelongsToClan("Granblue");
				});
			});
		});

		ResolveDropOpening(1,
		delegate {
			unitCalled = Game.field.GetDropByID(_AuxIdVector[0]);
			CallFromDrop (unitCalled);
		},
		delegate {
			EndEffect();
		});

		CallFromDropUpdate(delegate {
			IncreasePowerByTurn(unitCalled, 3000);
			EndEffect();
		});
	}

	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul (CardIdentifier.ICE_PRISON_NECROMANCER__COCYTUS))
		{
			AddContPower(2000);
		}
	}
}
