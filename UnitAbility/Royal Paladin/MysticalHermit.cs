using UnityEngine;
using System.Collections;

public class MysticalHermit : UnitObject {
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
			SelectUnit ("Choose one of your \"Royal Paladin\"", 1, true,
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
