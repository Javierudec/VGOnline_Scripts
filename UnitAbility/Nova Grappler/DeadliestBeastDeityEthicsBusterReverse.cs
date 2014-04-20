using UnityEngine;
using System.Collections;

public class DeadliestBeastDeityEthicsBusterReverse : UnitObject {
	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(2)
		   && HandSize (delegate(Card c) { return c.name.Contains("Beast Deity"); }) >= 2
		   && NumUnits (delegate(Card c) { return c.BelongsToClan("Nova Grappler"); }) >= 2)
		{
			return 1;
		}

		return 0;
	}

	public override void Cont ()
	{
		if(VC()
		   && IsInSoul (CardIdentifier.BEAST_DEITY__ETHICS_BUSTER))
		{
			AddContPower(2000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard())
			{
				SetBool(2);
			}
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(2) 
			   && GetBool(1)
			   && VC ())
			{
				StandUnit(OwnerCard);
			}

			UnsetBool(2);
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SelectInHand(2, false,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return _SIH_Card.name.Contains("Beast Deity");
				},
				delegate {
					SelectUnit("Choose two of your \"Nova Grappler\" rear-guards.", 2, true,
					delegate {
						LockUnit(Unit);
					},
					delegate {
						return Unit.BelongsToClan("Nova Grappler");
					},
					delegate {
						SelectAnimField(OwnerCard);
						SetBool(1);
					});
				}, "Choose two card from your hand with \"Beast Deity\" in its card name.");
			});
		});
	}
}
