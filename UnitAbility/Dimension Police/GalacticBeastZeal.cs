using UnityEngine;
using System.Collections;

public class GalacticBeastZeal : UnitObject {
	public override void Cont()
	{
		if(IsInSoul(CardIdentifier.DEVOURER_OF_PLANETS__ZEAL))
		{
			AddContPower(2000);	
		}
	}
	
	public override int Act()
	{
		if(VC () 
		   && LimitBreak(4) 
		   && CB(2) 
		   && GetBool(1))
		{
			return 1;	
		}
		return 0;
	}
	
	public override void Active()
	{
		StartEffect();
		UnsetBool(1);
		ShowAndDelay();
	}
	
	public override void Update() 
	{
		DelayUpdate(delegate {
			CounterBlast(2, 
			             delegate {
				IncreaseEnemyPowerByTurn(GetEnemyVanguard(), -1000 * NumUnits(delegate(Card c) { return c.BelongsToClan("Dimension Police"); }));
				EndEffect();
			});
		});
	}	

	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.EndTurn)
		{
			SetBool(1);	
		}
		else if(cs == CardState.Ride) 
		{
			SetBool(1);	
		}
	}
}
