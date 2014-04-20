using UnityEngine;
using System.Collections;

public class ApprenticeGunnerSolon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs(OwnerCard.clan))
			{
				SetBool(1);
				Forerunner(OwnerCard.clan);
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
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

	public override int Act ()
	{
		if(RC()
		   && HandSize() > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return true;
			},
			delegate {
				if(VanguardIs("Aqua Force")
				   && GetDeck().Size() > 0)
				{
					DrawCardWithoutDelay();
				}
			}, "Choose a card from your hand.");
		});
	}
}
