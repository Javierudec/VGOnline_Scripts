using UnityEngine;
using System.Collections;

public class AmberDragonDusk : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.AMBER_DRAGON__DAYLIGHT) != null)
		{
			AddContPower(1000);	
		}
	}
	
	void AmberDragonDusk_Auto(CardState cs)
	{
		if(cs == CardState.Attacking)
		{	
			if(GetDefensor().IsVanguard() &&
			   OwnerCard.IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
}
