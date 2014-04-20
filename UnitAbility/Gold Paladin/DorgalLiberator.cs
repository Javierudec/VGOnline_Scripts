using UnityEngine;
using System.Collections;

public class DorgalLiberator : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			if(GetDefensor ().IsVanguard()
			   && GetAttacker().name.Contains("Liberator")
			   && VanguardIs("Gold Paladin")
			   && CB(1))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByTurn(OwnerCard, 5000);
				EndEffect();
			});
		});
	}
}
