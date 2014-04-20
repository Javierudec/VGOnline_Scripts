using UnityEngine;
using System.Collections;

public class LiberatorOfBondsGancelotZenith : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.SOLITARY_LIBERATOR__GANCELOT))
		{
			AddContPower(2000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && LimitBreak(4)
			   && GetDefensor().IsVanguard()
			   && CB (1, delegate(Card c) { return c.BelongsToClan("Liberator"); })
			   && NumUnits (delegate(Card c) { return c.grade <= 2; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit ("Choose one of your grade 2 or less rear-guards.", 1, false,
				delegate {
					FromFieldToDeck(Unit, true);
				},
				delegate {
					return Unit.grade <= 2;
				},
				delegate {
					SetBool(1);
					GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, 1, delegate(Game2DCard c) {
						return c._CardInfo.BelongsToClan("Gold Paladin");
					});
				});
			},
			delegate(Card c) {
				return c.name.Contains("Liberator");
			});
		});

		ResolveDeckOpening(1,
		delegate {
			OnlyOpenRC(true);
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
		});

		CallFromDeckUpdate(delegate {
			OnlyOpenRC(false);
			IncreasePowerByTurn(CallFromDeckList[0], 10000);
			EndEffect();
		});
	}
}
