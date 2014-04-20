using UnityEngine;
using System.Collections;

public class MartialArtsMutanMasterBeetle : UnitObject {
	public override void Auto (CardState cs, Card effectOwner = null)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && VC() && CB (3) && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				DisplayConfirmationWindow();
			}
			else
			{
				ConfirmAttack();
			}
		}
	}
	
	public override void Cont()
	{
		int power = 0;
		if(NumUnits(delegate(Card c) { return !c.BelongsToClan("Megacolony"); }, true) > 0)
		{
			power -= 2000;	
		}
		SetPower(power);
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(3,
			delegate {
				int m = NumEnemyUnits(delegate(Card c) { return true; });
				SelectEnemyUnit("Choose up to two of your opponent's rear-guards.", min(2, m), true,
				delegate {
					CantStandUntilNextTurn(EnemyUnit);
				},
				delegate {
					return true;
				},
				delegate {
					ConfirmAttack();
				});
			});
		});
	}
	
	public override void Pointer()
	{
		CounterBlast_Pointer();
		SelectEnemyUnit_Pointer();
	}
}
