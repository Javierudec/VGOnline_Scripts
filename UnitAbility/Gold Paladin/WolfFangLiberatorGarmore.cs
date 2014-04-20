using UnityEngine;
using System.Collections;

public class WolfFangLiberatorGarmore : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && NumUnits(delegate(Card c) { return c.name.Contains("Liberator"); }) > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB (3, delegate(Card c) { return c.name.Contains("Liberator"); })
		   && GetDeck ().Size() > 0
		   && OpenRC())
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
		if(!GetBool(1))
		{
			StartEffect();
		}

		ShowAndDelay();
	}

	public override void Update()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectUnit("Choose one of your rear-guards with \"Liberator\" in its card name.", 1, true,
				delegate {
					FromFieldToDeck(Unit, true);
				},
				delegate {
					return Unit.name.Contains("Liberator");
				},
				delegate {
					IncreasePowerByBattle(OwnerCard, 4000);
				});
			}
			else if(GetBool(3))
			{
				UnsetBool(3);
				SetBool(2);
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, 1, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Gold Paladin");
				});
			}
			else
			{
				CounterBlast(3,
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
			if(OpenRC()
			   && GetDeck().Size() > 0)
			{
				ShowAndDelay();
				SetBool(3);
			}
			else
			{
				EndEffect();
			}
		});
	}
}
