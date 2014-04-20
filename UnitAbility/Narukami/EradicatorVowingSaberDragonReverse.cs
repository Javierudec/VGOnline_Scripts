using UnityEngine;
using System.Collections;

public class EradicatorVowingSaberDragonReverse : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.ERADICATOR__VOWING_SWORD_DRAGON))
		{
			AddContPower(2000);
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(2)
		   && NumUnits(delegate(Card c) { return c.name.Contains("Eradicator"); }) >= 2)
		{
			return 1;
		}

		return 0;
	}

	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
	}

	public override void EndEvent ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			EndEffect();
		}
		else
		{
			if(NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				SetBool(1);
				OpponentRetireUnit();
			}
			else
			{
				EndEffect();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SelectUnit("Choose two of your rear-guards with \"Eradicator\" in its card name.", 2, false,
				delegate {
					LockUnit(Unit);
				},
				delegate {
					return Unit.name.Contains("Eradicator");
				},
				delegate {
					IncreasePowerByTurn(OwnerCard, 10000);
					if(NumEnemyUnits(delegate(Card c) { return true; }) > 0)
					{
						OpponentRetireUnit();
					}
					else
					{
						EndEffect();
					}
				});
			});
		});
	}
}
