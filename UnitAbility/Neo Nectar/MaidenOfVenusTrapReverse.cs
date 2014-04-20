using UnityEngine;
using System.Collections;

public class MaidenOfVenusTrapReverse : UnitObject {
	int currAbility = -1;

	bool FirstAbilityConstraint()
	{
		return  VC ()
				&& LimitBreak(4)
				&& CB(1)
				&& NumUnits(delegate(Card c) { return c.BelongsToClan("Neo Nectar"); }) > 0
				&& GetDeck().Size() > 0;
	}

	public override int Act ()
	{
		int n = 0;

		if(FirstAbilityConstraint())
		{
			n++;
		}

		if(VC()
		   && CB(1))
		{
			n++;
		}

		return n;
	}

	public override void Active (int idAbility)
	{
		StartEffect();
		ShowAndDelay();
		currAbility = idAbility;
	}

	void ExecuteSecondActAbility()
	{
		CounterBlast(1,
		delegate {
			IncreasePowerByTurn(OwnerCard, 2000);
			EndEffect();
		});
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(currAbility == 1)
			{
				if(FirstAbilityConstraint())
				{
					CounterBlast(1,
					             delegate {
						SelectUnit ("Choose one of your \"Neo Nectar\" rear-guards.", 1, false,
						            delegate {
							LockUnit(Unit);
						},
						delegate {
							return Unit.BelongsToClan("Neo Nectar");
						},
						delegate {
							SetBool(1);
							GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min(5, GetDeck().Size()), delegate(Game2DCard c) {
								return c._CardInfo.BelongsToClan("Neo Nectar");
							});
						});
					});
				}
				else
				{
					ExecuteSecondActAbility();
				}
			}

		});

		ResolveDeckOpening(1,
		delegate {
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			IncreasePowerByTurn(CallFromDeckList[0], 5000);
			EndEffect();
			ShuffleDeck();
		});
	}
}
