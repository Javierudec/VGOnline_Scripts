using UnityEngine;
using System.Collections;

public class LordOfTheDeepForestsMasterWisteria : UnitObject {
	Card firstUnit = null;
	Card secondUnit = null;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4)
			   && VanguardIs("Neo Nectar")
			   && CB(1))
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			if(VC ()
			   && OwnerCard.IsBoostedBy.BelongsToClan("Neo Nectar"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				firstUnit = secondUnit = null;

				int n = NumUnits (delegate(Card c) { return c.BelongsToClan("Neo Nectar"); });
				n = min(2, n);
				SelectUnit ("Choose " + n + " of your \"Neo Nectar\" rear-guards.", n, false,
				delegate {
					SelectAnimField(Unit);
					if(firstUnit == null)
					{
						firstUnit = Unit;
					}
					else
					{
						secondUnit = Unit;
					}
				},
				delegate {
					return Unit.BelongsToClan("Neo Nectar");
				},
				delegate {
					if(firstUnit != null)
					{
						SetBool(1);
						GetDeck().ViewDeck(1, delegate(Game2DCard c) {
							return c._CardInfo.cardID == firstUnit.cardID;
						});
					}
					else
					{
						EndEffect();
					}
				});
			});
		});

		ResolveDeckOpening(1,
		delegate {
			CallFromDeck (_AuxIdVector);
		},
		delegate {
			if(secondUnit != null)
			{
				SetBool(2);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.cardID == secondUnit.cardID;
				});
			}
			else
			{
				EndEffect();
				ShuffleDeck();
			}
		});

		ResolveDeckOpening(2,
		delegate {
			SetBool(3);
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			if(GetBool(2))
			{
				IncreasePowerByTurn(GetVanguard(), 10000);
				UnsetBool(2);
				EndEffect();
				ShuffleDeck();
			}
			else
			{
				if(secondUnit != null)
				{
					SetBool(2);
					GetDeck().ViewDeck(1, delegate(Game2DCard c) {
						return c._CardInfo.cardID == secondUnit.cardID;
					});
				}
				else
				{
					EndEffect();
					ShuffleDeck();
				}
			}
		});
	}
}
