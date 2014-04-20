using UnityEngine;
using System.Collections;

public class Blaukluger : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.BLAUPANZER) != null)
		{
			AddContPower(1000);		
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{
			if(OwnerCard.IsVanguard() &&
			   GetDefensor().IsVanguard())
			{
				UnflipCardInDamageZone(1);
			}
		}
	}
}
