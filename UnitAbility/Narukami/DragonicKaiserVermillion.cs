using UnityEngine;
using System.Collections;

public class DragonicKaiserVermillion : UnitObject {
	public override int Act()
	{
		if(VC() && LimitBreak(4) && CB(3))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.EndTurn)
		{
			SetAttackType(AttackType.NONE);	
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(3, delegate {
				IncreasePowerByTurn(OwnerCard, 2000);
				SetAttackType(AttackType.FRONT_ROW);
				EndEffect();
			});	
		});
	}
}
