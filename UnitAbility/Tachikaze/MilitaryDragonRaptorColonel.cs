using UnityEngine;
using System.Collections;

public class MilitaryDragonRaptorColonel : UnitObject {
	int _AuxInt;

	public override void Cont()
	{
		if(IsInSoul(CardIdentifier.MILITARY_DRAGON__RAPTOR_CAPTAIN))
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () 
			   && LimitBreak(4) 
			   && CB (1) 
			   && NumUnits(delegate(Card c) { return c.BelongsToClan("Tachikaze"); }) >= 2)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();
		_AuxInt = 0;
	}	
	
	public override void Update()
	{
		DelayUpdate(delegate {	
			CounterBlast(1,
			             delegate {
				SelectUnit("Choose two of your Tachikaze rear-guards.", 2, true,
				           delegate {
					RetireUnit(Unit);	
					_AuxInt += Unit.power;
				},
				delegate {
					return Unit.clan == "Tachikaze";
				},
				delegate {
					IncreasePowerByBattle(OwnerCard, _AuxInt);
				});
			});
		});
	}
}
