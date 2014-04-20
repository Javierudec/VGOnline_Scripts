using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you may 
 * call this unit to (RC))
 * 
 * [AUTO](RC):[Counter Blast (1)] When an attack by your vanguard with 
 * "Blau" in its card name hits a vanguard, you may pay the cost. If you do, 
 * look at up to three cards from the top of your deck, search for up to one 
 * card with "Blau" in its card name, reveal it to your opponent, put it into your 
 * hand, and shuffle your deck.
 */

public class Morgenrot : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Nova Grappler");	
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			if(RC () && CB (1) && GetAttacker().IsVanguard() && GetAttacker().name.Contains("Blau") && GetDefensor().IsVanguard() && GetDeck().Size() > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);	
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
			SetBool(2);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD, 3, delegate(Game2DCard c) {
				return c._CardInfo.name.Contains("Blau");	
			});
		});
		
		if(GetBool(2) && !GetDeck().IsOpen())
		{
			UnsetBool(2);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				FromDeckToHand(_AuxIdVector[0]);
			}
			EndEffect();
			ShuffleDeck();
		}
	}
}
