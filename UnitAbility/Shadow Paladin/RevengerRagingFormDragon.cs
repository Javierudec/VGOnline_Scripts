using UnityEngine;
using System.Collections;

public class RevengerRagingFormDragon : UnitObject {
	bool unitAttacked = false;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			unitAttacked = true;

			if(VC ()
			   && CB (1))
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.EndBattle)
		{
			if(unitAttacked
			   && VC ()
			   && LimitBreak(4)
			   && NumUnits (delegate(Card c) { return c.name.Contains("Revenger"); }) >= 3
			   && HandSize(delegate(Card c) { return c.cardID == CardIdentifier.REVENGER__RAGING_FORM_DRAGON; }) > 0)
			{
				DisplayConfirmationWindow();
			}

			unitAttacked = false;
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active ()
	{
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
					IncreasePowerByBattle(OwnerCard, 3000);
				});
			}
			else
			{
				SelectUnit("Choose three of your rear-guards with \"Revenger\" in its card name.", 3, false,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.name.Contains("Revenger");
				},
				delegate {
					SelectInHand(1, true,
					delegate {
						RideFromHand(_SIH_Card);
					},
					delegate {
						return _SIH_Card.cardID == CardIdentifier.REVENGER__RAGING_FORM_DRAGON;
					},
					delegate {
						IncreasePowerByTurn(GetVanguard(), 10000);
					}, "Choose a card named \"Revenger, Raging Form Dragon\" from your hand.");
				});
			}
		});
	}
}
