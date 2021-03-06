using UnityEngine;
using System.Collections;

/*
 * [AUTO]: [Counter Blast (1)] During your end phase,
 * when this unit is put into your drop zone from (RC),
 * if you have a «Great Nature» vanguard, you may pay the cost. 
 * If you do, search your deck for up to one card named "Melodica Cat",
 * call it to (RC), and shuffle your deck.
 */

public class VocalChicken : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.DropZoneFromRC)
		{
			if(CurrentPhaseIs(GamePhase.ENDTURN) && CB (1) && VanguardIs("Great Nature"))
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
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.cardID == CardIdentifier.MELODICA_CAT;
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
