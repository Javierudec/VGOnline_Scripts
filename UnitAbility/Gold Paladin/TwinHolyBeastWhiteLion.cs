using UnityEngine;
using System.Collections;

public class TwinHolyBeastWhiteLion : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(CB (1)
			   && GetVanguard().name.Contains("Ezel")
			   && GetDeck().Size() >= 2)
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			RemoveFromHelpZone(OwnerCard);
			SetBool(1);
			StartEffect();
			ShowAndDelay();
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectInDamage(1, true,
				delegate {
					FromDamageToDeck(_SID_Card);
					ShuffleDeck();
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					SoulCharge(1);
				});

				SoulChargeUpdate(delegate {
					FromDeckToDamage(GetDeck().TopCard());
					AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
}
