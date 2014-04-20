using UnityEngine;
using System.Collections;

public class SpectralSheep : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Genesis"))
			{
				SetBool(1);
				Forerunner("Genesis");
			}
		}
	}

	public override int Act ()
	{
		if(RC ()
		   && HandSize() > 0
		   && GetDeck().Size () > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate (delegate {
			MoveToSoul(OwnerCard);
			if(VanguardIs("Genesis"))
			{
				SelectInHand(1, true,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return true;
				},
				delegate {
					DrawCardWithoutDelay();
				}, "Choose a card from your hand.");
			}
			else
			{
				EndEffect();
			}
		});
	}
}
