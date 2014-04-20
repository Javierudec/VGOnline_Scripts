using UnityEngine;
using System.Collections;

public class BattleSisterCocoa : UnitObject {
	Card card;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(VanguardIs("Oracle Think Tank")
			   && GetDeck ().Size() > 0)
			{
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			card = LookAtTopDeckCard();
			Game._CardMenu.OpenDeckMenu(card);
			SetBool(1);
		});

		if(GetBool(1) && !Game._CardMenu.IsOpen())
		{
			UnsetBool(1);
			EndEffect();
		}
	}
}
