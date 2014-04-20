using UnityEngine;
using System.Collections;

public class GoddessOfUnionJuno : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Regalia"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}
}
