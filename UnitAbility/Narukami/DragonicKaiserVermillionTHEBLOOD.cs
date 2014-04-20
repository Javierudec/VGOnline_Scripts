using UnityEngine;
using System.Collections;

public class DragonicKaiserVermillionTHEBLOOD : UnitObject {
	public override void Cont()
	{
		if(VC () && IsInSoul(CardIdentifier.DRAGONIC_KAISER_VERMILLION))
		{
			AddContPower(2000);	
		}
	}
	
	public override int Act()
	{
		if(VC() && LimitBreak (5) && CB (3))
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
	
	public override void Update()
	{	
		DelayUpdate(delegate {
			CounterBlast(3,
			             delegate {
				IncreasePowerAndCriticalByTurn(OwnerCard, 5000, 1);
				SetAttackType(AttackType.FRONT_ROW);
			});
		});
	}

	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.EndTurn)
		{
			SetAttackType(AttackType.NONE);
		}
	}
}
