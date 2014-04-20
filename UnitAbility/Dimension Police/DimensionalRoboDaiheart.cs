using UnityEngine;
using System.Collections;

public class DimensionalRoboDaiheart : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC()
			   && OwnerCard.GetPower() >= 13000)
			{
				SetBool(1);
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(VC()
			   && GetDefensor().IsVanguard()
			   && GetDeck().Size() > 0
			   && HandSize(delegate(Card c) { return c.name.Contains("Dimensional Robo") && c.grade == 3; }) >= 2)
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectInHand(2, false,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return _SIH_Card.grade == 3 && _SIH_Card.name.Contains("Dimensional Robo");
			},
			delegate {
				SetBool(2);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.grade == 3 && c._CardInfo.name.Contains("Dimensional Robo");
				});
			}, "Choose two grade 3 cards with \"Dimensional Robo\" in its card name.");
		});

		ResolveDeckOpening(1,
		delegate {
			Card rideUnit = GetDeck().SearchForID(_AuxIdVector[0]);
			RideFromDeck(rideUnit);
			RestUnit(rideUnit);
			EndEffect();
			ShuffleDeck();
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
