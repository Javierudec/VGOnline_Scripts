using UnityEngine;
using System.Collections;

public class BrokenHeartJewelKnightAshleiReverse : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.PURE_HEART_JEWEL_KNIGHT__ASHLEY))
		{
			AddContPower(2000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			UnsetBool(2);
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB (1)
		   && NumUnits (delegate(Card c) { return c.name.Contains("Jewel Knight"); }) > 0
		   && !GetBool(2))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SetBool(2);
			CounterBlast(1,
			delegate {
				SelectUnit ("Choose one of your rear-guards with \"Jewel Knight\" in its card name.", 1, false,
				delegate {
					LockUnit(Unit);
				},
				delegate {
					return Unit.name.Contains("Jewel Knight");
				},
				delegate {
					if(NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) > 0)
					{
						SelectEnemyUnit ("Choose one of your opponent's rear-guards in the front row.", 1, false,
						delegate {
							RetireEnemyUnit(EnemyUnit);
						},
						delegate {
							return IsFrontRow(EnemyUnit);
						},
						delegate {
							SearchJewelKnight();
						});
					}
					else
					{
						SearchJewelKnight();
					}
				});
			});
		});

		ResolveDeckOpening(1,
		delegate {
			CallFromDeck (_AuxIdVector);
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

	void SearchJewelKnight()
	{
		if(GetDeck().Size() > 0)
		{
			SetBool(1);
			GetDeck().ViewDeck(1, delegate(Game2DCard c) {
				return c._CardInfo.name.Contains("Jewel Knight");
			});
		}
		else
		{
			EndEffect();
		}
	}
}
