using UnityEngine;
using System.Collections;

public class PrisonEggSealDragonKnight : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Kagero"))
			{
				SetBool(1);
				Forerunner("Kagero");
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
		   && HandSize() > 0
		   && GetDeck().Size() > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			if(VanguardIs("Kagero"))
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
