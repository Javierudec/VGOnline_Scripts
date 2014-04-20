using UnityEngine;
using System.Collections;

public class DragonicOverlordTheRebirth : UnitObject {
	bool bCanUseExtraAbility = false;
	bool bCanActiveExtraAbility = false;
	bool bExtAuto = false;

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(1)
		   && NumUnits (delegate(Card c) { return c.BelongsToClan("Kagero"); }) > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Cont ()
	{
		if(VC ()
		   && NumUnitsInSoul(delegate(Card c) { return c.name.CompareTo("Dragonic Overlord") == 0; }) > 0)
		{
			AddContPower(2000);
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(bExtAuto)
			{
				SelectInHand(2, true,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return _SIH_Card.BelongsToClan("Kagero");
				},
				delegate {
					StandUnit(OwnerCard);
					bExtAuto = false;
					bCanUseExtraAbility = false;
				}, "Choose two \"Kagero\" from your hand.");
			}
			else
			{
				CounterBlast(1,
				delegate {
					ForEachUnitOnField(delegate(Card c) {
						if(!c.IsVanguard())
						{
							LockUnit (c);
						}
					});
					
					if(NumUnits (delegate(Card c) { return c.IsLocked(); }, false, true) >= 5)
					{
						IncreasePowerByTurn(OwnerCard, 10000);
						bCanUseExtraAbility = true;
					}
					
					EndEffect();
				});
			}
		});
	}

	public override bool Cancel ()
	{
		bExtAuto = false;
		bCanUseExtraAbility = false;
		return true;
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			bCanUseExtraAbility = false;
		}
		else if(cs == CardState.Attacking)
		{
			if(GetDefensor ().IsVanguard())
			{
				bCanActiveExtraAbility = true;
			}
		}
		else if(cs == CardState.EndBattle)
		{
			if(bCanUseExtraAbility
			   && bCanActiveExtraAbility
			   && VC()
			   && HandSize(delegate(Card c) { return c.BelongsToClan("Kagero"); }) >= 2)
			{
				bExtAuto = true;
				DisplayConfirmationWindow();
			}

			bCanActiveExtraAbility = false;
		}
	}
}
