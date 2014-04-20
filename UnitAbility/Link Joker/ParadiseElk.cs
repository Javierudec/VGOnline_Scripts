using UnityEngine;
using System.Collections;

public class ParadiseElk : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(CB(2)
			   && GetDeck().Size() > 0
			   && VanguardIs("Link Joker"))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				DrawCardWithoutDelay();
				EndEffect();
			});
		});
	}
}
