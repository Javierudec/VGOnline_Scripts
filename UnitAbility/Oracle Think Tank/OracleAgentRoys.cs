using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1)] When this unit's attack hits a vanguard, 
 * you may pay the cost. If you do, look at up to five cards from the top of 
 * your deck, search for up to one grade 3 or greater «Oracle Think Tank» 
 * from among them, reveal it to your opponent, put it into your hand, and 
 * shuffle your deck.
 */

public class OracleAgentRoys : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() && CB (1) && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate (delegate {
			int m = min (5, GetDeck().Size());
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, m, delegate(Game2DCard c) {
				return c._CardInfo.grade >= 3 && c._CardInfo.BelongsToClan("Oracle Think Tank");	
			});
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				FromDeckToHand(_AuxIdVector[0]);	
			}
			EndEffect ();
			ShuffleDeck();
		}
	}
}
