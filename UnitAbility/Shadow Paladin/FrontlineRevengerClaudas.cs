using UnityEngine;
using System.Collections;

public class FrontlineRevengerClaudas : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Shadow Paladin"))
			{
				SetBool(1);
				Forerunner("Shadow Paladin");
			}
		}
	}

	public override int Act ()
	{
		if(RC ()
		   && CB (1))
		{
			return 1;
		}

		return 0;
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

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate (delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				if(VanguardIs("Shadow Paladin")
				   && GetVanguard().grade >= 3
				   && GetDeck().Size() > 0)
				{
					SetBool(2);
					GetDeck().ViewDeck(1, delegate(Game2DCard c) {
						return c._CardInfo.cardID == CardIdentifier.BLASTER_DARK_REVENGER;
					});
				}
				else
				{
					EndEffect();
				}
			});
		});

		ResolveDeckOpening(2, 
		delegate {
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
