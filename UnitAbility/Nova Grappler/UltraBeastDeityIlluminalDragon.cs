using UnityEngine;
using System.Collections;

public class UltraBeastDeityIlluminalDragon : UnitObject {
	public override void Cont()
	{
		if(VC () && IsInSoul(CardIdentifier.BEAST_DEITY__AZURE_DRAGON))
		{
			AddContPower(2000);
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () 
			   && LimitBreak(4) 
			   && CB (3) 
			   && NumUnits(delegate(Card c) { return c.name.Contains("Beast Deity") && !c.IsStand(); }) > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}

	public override void Active()
	{
		ShowAndDelay();	
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(3,
			delegate {
				int n = min (2, NumUnits(delegate(Card c) { return c.name.Contains("Beast Deity") && !c.IsStand(); }));
				
				SelectUnit("Choose up to two of your rear-guards with Beast Deity in its name.", n, true,
				delegate {
					StandUnit(Unit);
				},
				delegate {
					return Unit.name.Contains("Beast Deity") && !Unit.IsStand();
				},
				delegate {
					ConfirmAttack();
				});
			});
		});
	}		
}
