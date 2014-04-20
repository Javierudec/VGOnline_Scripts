using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Counter Blast (1)-card with "Battle Sister" in its card name] 
 * When this unit's attack hits a vanguard, if you have an «Oracle Think Tank» 
 * vanguard, you may pay the cost. If you do, look at the top card of your 
 * deck, search for up to one card with "Battle Sister" in its card name from among them, 
 * reveal it to your opponent, put it into your hand, and put the 
 * rest on the bottom of your deck.
 */

public class BattleSisterCocotte : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard() && VanguardIs("Oracle Think Tank") && GetDeck().Size() > 0 && CB (1, delegate(Card c) { return c.name.Contains("Battle Sister"); }))
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
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, 1, delegate(Game2DCard c) {
					return c._CardInfo.name.Contains("Battle Sister");	
				});
			},
			delegate(Card c) {
				return c.name.Contains("Battle Sister");
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
			EndEffect();
		}
	}
}
