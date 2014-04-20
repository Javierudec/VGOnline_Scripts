using UnityEngine;
using System.Collections;

public class NightmareDollChelsea : UnitObject {
	int n;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard())
			{
				SetBool(1);
			}
		}
		else if(cs == CardState.EndBattle)
		{
			if(VC ()
			   && LimitBreak(4)
			   && CB(2)
			   && IsInHand(OwnerCard.cardID)
			   && GetBool(1)
			   && NumUnitsInSoul(delegate(Card c) { return true; }) > 0)
			{
				DisplayConfirmationWindow();
			}

			UnsetBool(1);
		}
		else if(cs == CardState.IsBoosted)
		{
			if(VC ()
			   && OwnerCard.IsBoostedBy.BelongsToClan("Pale Moon"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			CounterBlast(2,
			delegate {
				SelectInHand(1, false,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return _SIH_Card.cardID == OwnerCard.cardID;
				},
				delegate {
					SetBool(2);
					Game.field.ViewSoul(2, delegate(Card c) {
						return c.BelongsToClan("Pale Moon");
					});
				}, "Choose a card named " + OwnerCard.name + " from your hand.");
			});
		});

		ResolveSoulOpening(2,
		delegate {
			n = _AuxIdVector.Count - 1;
			CallFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));
			_AuxIdVector.RemoveAt(0);
		},
		delegate {
			EndEffect();
		});

		CallFromSoulUpdate(delegate {
			if(n > 0)
			{
				CallFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));
				n--;
			}
			else
			{
				EndEffect();
			}
		});
	}
}
