using UnityEngine;
using System.Collections;

public class StarvaderDustTailUnicorn : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Link Joker"))
			{
				SetBool(1);
				Forerunner("Link Joker");
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override int Act ()
	{
		if(RC ()
		   && CB (1))
		{
			return 1;
		}

		return 0;
	}

	public override void Active()
	{
		Forerunner_Active();
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				if(VanguardIs("Link Joker")
				   && NumEnemyUnits(delegate(Card c) { return c.IsLocked(); }, true, true) > 0
				   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
				{
					SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
					delegate {
						LockEnemyUnit(EnemyUnit);
					},
					delegate {
						return true;
					},
					delegate {

					});
				}
				else
				{
					EndEffect();
				}
			});
		});
	}
}
