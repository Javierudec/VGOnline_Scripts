using UnityEngine;
using System.Collections;

public class WitchOfCursedTalismanEtain : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacked)
		{
			if(VC ()
			   && LimitBreak(4)
			   && CB(2)
			   && NumUnits(delegate(Card c) { return c.BelongsToClan("Shadow Paladin"); }) >= 2
			   && NumEnemyUnits(delegate(Card d) { return d != GetAttacker() && d != GetAttacker().IsBoostedBy; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC()
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SelectUnit("Choose two of your \"Shadow Paladin\" rear-guards.", 2, false,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Shadow Paladin");
				},
				delegate {
					SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
					delegate {
						RetireEnemyUnit(EnemyUnit);
					},
					delegate {
						return EnemyUnit != GetAttacker() && EnemyUnit != GetAttacker().IsBoostedBy;
					},
					delegate {

					});
				});
			});
		});
	}
}
