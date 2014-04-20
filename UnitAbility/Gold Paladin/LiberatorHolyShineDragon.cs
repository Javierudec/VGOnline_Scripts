using UnityEngine;
using System.Collections;

public class LiberatorHolyShineDragon : UnitObject {
	bool bAuto1 = false;
	bool bAuto2 = false;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			if(VC()
			   && LimitBreak(4)
			   && NumUnitsInSoul(delegate(Card c) { return c.grade == 3; }) > 0)
			{
				bAuto1 = true;
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.Ride)
		{
			if(CB(1, delegate(Card c) { return c.name.Contains("Liberator"); })
			   && GetDeck().Size() > 0
			   && OpenRC())
			{
				bAuto2 = true;
				DisplayConfirmationWindow();
			}
		}
	}

	public override bool Cancel ()
	{
		bAuto1 = false;
		bAuto2 = false;
		return true;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(bAuto1) 
			{
				SetBool(1);
				Game.field.ViewSoul(1, delegate(Card c) { return c.grade == 3; });
			}
			else if(bAuto2)
			{
				CounterBlast(1,
				delegate {
					SetBool(2);
					GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, 1, delegate(Game2DCard c) {
						return c._CardInfo.BelongsToClan("Gold Paladin");
					});
				},
				delegate(Card c) {
					return c.name.Contains("Liberator");
				});
			}
		});

		ResolveSoulOpening(1,
		delegate {
			RideFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));
			FromSoulToHand(Game.field.GetSoulByID(CardIdentifier.LIBERATOR_HOLY_SHINE_DRAGON));
			EndEffect();
		},
		delegate {
			EndEffect();
		});

		ResolveDeckOpening(2,
		delegate {
			OnlyOpenRC(true);
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
		});

		CallFromDeckUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect();
		});
	}
}
