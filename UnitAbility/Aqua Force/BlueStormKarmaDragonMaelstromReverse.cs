using UnityEngine;
using System.Collections;

public class BlueStormKarmaDragonMaelstromReverse : UnitObject {
	bool bExtraSkill = false;
	bool bActiveExtraSkill = false;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && LimitBreak(4)
			   && CB(1)
			   && NumUnits(delegate(Card c) { return c.IsStand(); }) > 0
			   && Game.numBattle >= 4
			   && GetDefensor().IsVanguard())
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.AttackNotHit)
		{
			if(bExtraSkill)
			{
				if(VC()
				   && GetDeck().Size() > 0
				   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
				{
					bActiveExtraSkill = true;
					ShowAndDelay();
				}
			}
		}
		else if(cs == CardState.EndBattle)
		{
			bExtraSkill = false;
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(bActiveExtraSkill)
			{
				bActiveExtraSkill = false;
				DrawCard(1);
			}
			else
			{
				CounterBlast(1,
				delegate {
					SelectUnit("Choose one of your rear-guards.", 1, true,
					delegate {
						RestUnit(Unit);
						LockUnit(Unit);
					},
					delegate {
						return Unit.IsStand();
					},
					delegate {
						IncreaseCriticalByBattle(OwnerCard, 1);
						IncreasePowerByBattle(OwnerCard, 5000);
						bExtraSkill = true;
					});
				});
			}
		});

		DrawCardUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
			delegate {
				RetireEnemyUnit(EnemyUnit);
			},
			delegate {
				return true;
			},
			delegate {

			});
		});
	}

	public override void Cont ()
	{
		if(VC()
		   && IsInSoul(CardIdentifier.BLUE_STORM_DRAGON__MAELSTROM))
		{
			AddContPower(2000);
		}
	}
}
