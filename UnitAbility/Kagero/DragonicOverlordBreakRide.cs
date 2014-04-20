using UnityEngine;
using System.Collections;

public class DragonicOverlordBreakRide : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4)
			   && VanguardIs("Kagero"))
			{
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC()
			   && NumUnits (delegate(Card c) { return true; }) > NumEnemyUnits(delegate(Card c) { return true; }))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			GetVanguard().unitAbilities.AddUnitObject(new DragonicOverlordBreakRideEXT());
			EndEffect ();
		});
	}
}

public class DragonicOverlordBreakRideEXT : UnitObject
{
	bool bCanUseAuto =  false;
	bool bCanPaidAuto = true;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndBattle)
		{
			if(bCanUseAuto
			   && bCanPaidAuto
			   && VC ()
			   && CB(1)
			   && HandSize(delegate(Card c) { return c.BelongsToClan("Kagero"); }) > 0)
			{
				bCanPaidAuto = false;

				DisplayConfirmationWindow();
			}

			bCanUseAuto = false;
		}
		else if(cs == CardState.EndBattle)
		{
			bCanPaidAuto = true;
		}
		else if(cs == CardState.Attacking)
		{
			if(!GetDefensor().IsVanguard())
			{
				bCanUseAuto = true;
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
		    delegate {
				SelectInHand(1, true,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return _SIH_Card.BelongsToClan("Kagero");
				},
				delegate {
					StandUnit(OwnerCard);
				}, "Choose a \"Kagero\" from your hand.");
			});
		});
	}
}
