using UnityEngine;
using System.Collections;

public class BlueStormSupremeGloryMalestrom : UnitObject {
	public override void Cont()
	{
		if(VC () 
		   && IsInSoul(CardIdentifier.BLUE_STORM_DRAGON__MAELSTROM))
		{
			AddContPower(2000);
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{	
		if(cs == CardState.Attacking)
		{
			if(Game.field.GetDamage() >= 5 
			   && CB (1) 
			   && GetDefensor().IsVanguard())
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
			CounterBlast(1,
			delegate {
				IncreasePowerByBattle(OwnerCard, 5000);
				BlockNormalGuardEndBattle(0, 0);
				EndEffect();
			});
		});
	}
}
