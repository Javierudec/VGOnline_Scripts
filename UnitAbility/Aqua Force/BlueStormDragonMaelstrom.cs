using UnityEngine;
using System.Collections;

public class BlueStormDragonMaelstrom : UnitObject {
	public override void Cont()
	{
		if(NumUnits(delegate(Card c) { return !c.BelongsToClan("Aqua Force"); }, true) > 0)
		{
			AddContPower(-2000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () 
			   && GetDefensor().IsVanguard() 
			   && LimitBreak(4) 
			   && Game.numBattle >= 4)
			{
				IncreasePowerByBattle(OwnerCard, 5000);
				SetBool(1);
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetBool(1) && CB (1))
			{
				UnsetBool(1);	
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();	
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				DrawCardWithoutDelay();
				SelectEnemyUnit("Choose one of your opponent's rear-guard.", 1, true,
				 delegate {
					RetireEnemyUnit(EnemyUnit);	
				},
				delegate {
					return true;	
				},
				delegate {
					
				});
			});
		});
	}
}
