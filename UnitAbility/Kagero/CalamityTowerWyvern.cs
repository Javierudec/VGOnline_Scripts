using UnityEngine;
using System.Collections;

public class CalamityTowerWyvern : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(CanSoulBlast(2)
			   && VanguardIs("Kagero")
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(2);
		});

		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
}
