using UnityEngine;
using System.Collections;

public class ExplosiveClawSealDragonKnight : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor ().grade == 2
			   && VanguardIs("Kagero"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
