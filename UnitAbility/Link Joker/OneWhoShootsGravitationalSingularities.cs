using UnityEngine;
using System.Collections;

public class OneWhoShootsGravitationalSingularities : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(RC()
			   && GetDefensor().IsVanguard()
			   && VanguardIs("Link Joker")
			   && NumEnemyUnits(delegate(Card c) { return c.IsLocked(); }, true, true) > 0
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update()
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
