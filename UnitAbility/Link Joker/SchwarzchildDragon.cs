using UnityEngine;
using System.Collections;

public class SchwarzchildDragon : UnitObject {
	public override int Act ()
	{
		if(VC()
		   && LimitBreak(4)
		   && CB(3)
		   && IsInHand(OwnerCard.cardID))
		{
			return 1;
		}

		return 0;
	}

	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				CounterBlast(1,
				delegate {
					SetBool(2);
					GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min (5, GetDeck().Size()), delegate(Game2DCard c) {
						return c._CardInfo.cardID == OwnerCard.cardID;
					});
				});
			}
			else
			{
				CounterBlast(3,
				delegate {
					SelectInHand(1, false,
					delegate {
						DiscardSelectedCard();
					},
					delegate {
						return _SIH_Card.cardID == OwnerCard.cardID;
					},
					delegate {
						int n = NumEnemyUnits(delegate(Card c) { return true; });
						SelectEnemyUnit("Choose " + n + " of your opponent's rear-guards.", n, true,
						delegate {
							LockEnemyUnit(EnemyUnit);
						},
						delegate {
							return true;
						},
						delegate {
							IncreasePowerAndCriticalByTurn(OwnerCard, 10000, 1);
						});
					}, "Choose a card named " + OwnerCard.name + " from your hand.");
				});
			}
		});

		ResolveDeckOpening(2,
		delegate {
			FromDeckToHand(_AuxIdVector[0]);
			EndEffect();
			ShuffleDeck();
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride)
		{
			if(CB(1)
			   && GetDeck().Size() > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.GRAVITY_COLLAPSE_DRAGON))
		{
			AddContPower(1000);
		}
	}
}
