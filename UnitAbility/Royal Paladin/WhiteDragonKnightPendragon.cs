using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage): At the beginning of your main phase, 
 * look at up to five cards from the top of your deck, search for up to one grade 3 «Royal Paladin» from among them, ride it,
 * and shuffle your deck.
 * [AUTO]:When this unit is placed on (VC), this unit gets [Power]+5000 until end of turn.
 */

public class WhiteDragonKnightPendragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.BeginMain)
		{
			if(VC () && LimitBreak(4) && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Ride)
		{
			IncreasePowerByTurn(OwnerCard, 5000);	
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, 5, delegate(Game2DCard c) {
				return c._CardInfo.BelongsToClan("Royal Paladin") && c._CardInfo.grade == 3;
			});
		});
		
		if(GetBool(1) && GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				RideFromDeck(GetDeck().SearchForID(_AuxIdVector[0]));
			}
			EndEffect();
			ShuffleDeck();
		}
	}
}
