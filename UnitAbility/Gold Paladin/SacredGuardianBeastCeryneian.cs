using UnityEngine;
using System.Collections;

public class SacredGuardianBeastCeryneian : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(RC ()
			   && GetDefensor().IsVanguard())
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your \"Gold Paladin\".", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit.BelongsToClan("Gold Paladin");
			},
			delegate {

			}, true);
		});
	}
}
