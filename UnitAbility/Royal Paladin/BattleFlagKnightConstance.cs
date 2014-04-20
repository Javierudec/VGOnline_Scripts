using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (2)] When this unit's attack hits a vanguard, 
 * if you have a «Royal Paladin» vanguard, you may pay the cost. If you do, 
 * search your deck up to one grade 1 or less «Royal Paladin», call it to (RC), 
 * and shuffle your deck.
 */

public class BattleFlagKnightConstance : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(CB(2) && GetDefensor().IsVanguard() && VanguardIs("Royal Paladin") && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}	
	}
	
	public override void Active()
	{
		ShowAndDelay();	
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.grade <= 1 && c._CardInfo.BelongsToClan("Royal Paladin");
				});
			});
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck(_AuxIdVector);	
			}
			else
			{
				EndEffect();
				ShuffleDeck();
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
