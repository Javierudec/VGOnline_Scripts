using UnityEngine;
using System.Collections;

public class SchoolPunisherLeopaldReverse : UnitObject {
	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Great Nature"); }) > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your \"Great Nature\" rear-guards.", 1, false,
			delegate {
				LockUnit(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Great Nature");
			},
			delegate {
				int num = NumUnits (delegate(Card c) { return c.BelongsToClan("Great Nature"); });
				SelectUnit ("Choose " + num + " of your \"Great Nature\" rear-guards.", num, true,
				delegate {
					IncreasePowerByTurn(Unit, 4000);
					Unit.unitAbilities.AddUnitObject(new SchoolPunisherLeopaldReverseEXT1());
					Unit.unitAbilities.AddUnitObject(new SchoolPunisherLeopaldReverseEXT2());
				},
				delegate {
					return Unit.BelongsToClan("Great Nature");
				},
				delegate {

				});
			});
		});
	}

	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.SCHOOL_HUNTER__LEO_PALD))
		{
			AddContPower(2000);
		}
	}
}

public class SchoolPunisherLeopaldReverseEXT1 : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			if(RC ())
			{
				RetireUnit(OwnerCard);
			}
		}
	}
}

public class SchoolPunisherLeopaldReverseEXT2 : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DropZoneFromRC)
		{
			if(CurrentPhaseIs(GamePhase.ENDTURN))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			OnlyOpenRC(true);
			CallFromDrop(OwnerCard);
		});

		CallFromDropUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect();
		});
	}
}
