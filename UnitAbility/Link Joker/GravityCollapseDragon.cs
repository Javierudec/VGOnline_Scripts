using UnityEngine;
using System.Collections;

public class GravityCollapseDragon : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul (CardIdentifier.GRAVITY_BALL_DRAGON))
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride)
		{
			if(Game.field.GetLastVanguard().cardID == CardIdentifier.GRAVITY_BALL_DRAGON
			   && IsInSoul(CardIdentifier.MICRO_HOLE_DRACOKID)
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
			delegate {
				LockEnemyUnit(EnemyUnit);
			},
			delegate {
				return true;
			},
			delegate {

			});
		});
	}
}
