using UnityEngine;
using System.Collections;

public class GravityBallDragon : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.MICRO_HOLE_DRACOKID))
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().grade == 2
			   && GetVanguard().BelongsToClan("Link Joker")
			   && GetVanguard().cardID != CardIdentifier.GRAVITY_COLLAPSE_DRAGON
			   && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min(7, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.GRAVITY_COLLAPSE_DRAGON;
			});
		});

		ResolveDeckOpening(1,
		delegate {
			RideFromDeck(GetDeck().SearchForID(_AuxIdVector[0]));
			EndEffect();
			ShuffleDeck();
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
