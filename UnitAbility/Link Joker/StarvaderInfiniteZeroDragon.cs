using UnityEngine;
using System.Collections;

public class StarvaderInfiniteZeroDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs ("Link Joker") && LimitBreak(4))
			{
				IncreasePowerByTurn(GetVanguard(), 10000);
				if(NumEnemyUnits(delegate(Card c) { return true; }) > 0)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC () && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards in the front row.", min (1, NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) ), false,
			delegate {
				LockEnemyUnit(EnemyUnit);
			},
			delegate {
				return IsFrontRow(EnemyUnit);
			},
			delegate {
				SelectEnemyUnit("Choose one of your opponent's rear-guards in the back.", min (1, NumEnemyUnits(delegate(Card c) { return EnemyIsInBackRow(c); })), true,
				delegate {
					LockEnemyUnit(EnemyUnit);
				},
				delegate {
					return EnemyIsInBackRow(EnemyUnit);
				},
				delegate {
					
				});
			});
		});
	}
	
	public override void Pointer ()
	{
		SelectEnemyUnit_Pointer();
	}
}
