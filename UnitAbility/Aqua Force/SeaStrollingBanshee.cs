using UnityEngine;
using System.Collections;

public class SeaStrollingBanshee : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.CallFromDrop)
		{
			if(CanSoulBlast(1)
			   && VanguardIs("Granblue")
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(1);
		});

		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
}
