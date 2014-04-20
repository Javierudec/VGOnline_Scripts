using UnityEngine;
using System.Collections;

public class PenetrateCelestialGadriel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner(OwnerCard.clan);
		}
		else if(cs == CardState.BeginMain)
		{
			if(VanguardIs("Angel Feather")
			   && CB(1)
			   && GetDeck().Size() > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			SetBool(2);
			StartEffect();
			ShowAndDelay();
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			ShowAndDelay();
		}
		else
		{
			Forerunner_Active();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			if(GetBool(2))
			{
				UnsetBool(2);
				SelectInDamage(1, true,
				delegate {
					FromDamageToDeck(_SID_Card);
					RemoveFromHelpZone(OwnerCard);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					MoveToSoul(OwnerCard);
					FromDeckToDamage(GetDeck().TopCard(), true);
					AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
}
