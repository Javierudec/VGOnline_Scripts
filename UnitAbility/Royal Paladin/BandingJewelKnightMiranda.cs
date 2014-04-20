using UnityEngine;
using System.Collections;

public class BandingJewelKnightMiranda : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && GetVanguard().name.Contains("Ashlei"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(RC ()
			   && GetDefensor().IsVanguard()
			   && GetVanguard().name.Contains("Ashlei"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your \"Royal Paladin\".", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit.BelongsToClan("Royal Paladin");
			},
			delegate {

			}, true);
		});
	}
}
