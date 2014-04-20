using UnityEngine;
using System.Collections;

public class EnigmanStorm : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.ENIGMAN_WAVE) != null)
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Attacking)
		{
			if(OwnerCard.IsVanguard() && OwnerCard.GetPower() >= 15000)
			{
				IncreaseCriticalByBattle(OwnerCard, 1);
			}
		}
	}
}
