using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If the number of «Dark Irregulars» in your soul is eight or more, this 
 * unit gets [Power]+1000.
 *
 * [AUTO](VC):At the beginning of your main phase, Soul Charge (1), and this unit gets
 * [Power]+2000 until end of turn.
 * 
 * [AUTO](VC):[Choose five face up «Dark Irregulars» from your damage zone, and put 
 * them into your soul] When this unit attacks, you may pay the cost. If you do, 
 * this unit gets [Power]+10000/[Critical]+1 until end of turn, and at the 
 * beginning of the end phase of that turn, put five cards from the top of your 
 * deck into your damage zone.
 */

public class NoLifeKingDeathAnchor : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) >= 8)
		{
			AddContPower(1000);	
		}
	}

	public override void Active()
	{
		ShowAndDelay();
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.BeginMain)
		{
			if(VC ()
			   && GetDeck ().Size() > 0)
			{
				SetBool(1);
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			StartEffect();
			ShowAndDelay();
			SetBool(2);
		}
		else if(cs == CardState.Attacking)
		{
			if(VC() && 
			   NumUnitsDamage(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) >= 5)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SoulCharge(1);
			}
			else if(GetBool(2))
			{
				UnsetBool(2);
				for(int i = 0; i < 5; i++)
				{
					FromDeckToDamage(GetDeck().TopCard(), true);
				}
				RemoveFromHelpZone(OwnerCard);
				EndEffect();
			}
			else
			{
				SelectInDamage(5, true,
				delegate {
					FromDamageToSoul(_SID_Card);
				},
				delegate(Card c) {
					return c.BelongsToClan("Dark Irregulars");
				},
				delegate {
					IncreasePowerAndCriticalByTurn(OwnerCard, 10000, 1);
					AddToHelpZone(OwnerCard);
				});
			}
		});

		SoulChargeUpdate(delegate {
			IncreasePowerByTurn(OwnerCard, 2000);
			EndEffect();
		});
	}
}
