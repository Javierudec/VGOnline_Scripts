using UnityEngine;
using System.Collections;

public class MachiningSparkHercules : UnitObject {
	bool bActiveAuto = false;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard()
			   && VC()
			   && LimitBreak(4)
			   && CB(2, delegate(Card c) { return c.name.Contains("Machining"); })
			   && NumEnemyUnits(delegate(Card c) { return !c.IsStand(); }, true) == NumEnemyUnits(delegate(Card c) { return true; }, true))
			{
				bActiveAuto = true;
				DisplayConfirmationWindow();
			}
		}
	}
		
	public override bool Cancel ()
	{
		bActiveAuto = false;
		return true;
	}

	public override int Act ()
	{
		if(VC()
		   && CanSoulBlast(1, delegate(Card c) { return c.name.Contains("Machining"); }))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(bActiveAuto)
			{
				CounterBlast(2,
				delegate {
					IncreasePowerAndCriticalByTurn(OwnerCard, 10000, 1);
					SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
					delegate {
						CantStandUntilNextTurn(EnemyUnit);
					},
					delegate {
						return true;
					},
					delegate {

					});
				},
				delegate(Card c) {
					return c.name.Contains("Machining");
				});
			}
			else
			{
				SoulBlast(1, delegate(Card c) { return c.name.Contains("Machining"); });
			}
		});

		SoulBlastUpdate(delegate {
			IncreasePowerByTurn(OwnerCard, 2000);
			ForEachEnemyUnitOnField(delegate(Card c) {
				RestEnemyUnit(c);
			});
			EndEffect();
		});
	}
}
