using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When another «Oracle Think Tank» rides this unit, you may 
 * call this card to (RC).
 * 
 * [ACT](RC):[Counter Blast (1) & Put this unit into your soul] Look at up to 
 * three cards from the top of your deck, search for up to one card with 
 * "Battle Sister" in its card name from among them, call it to (RC), 
 * shuffle your deck, and that unit gets [Power]+2000 until end of turn.
 */

public class BattleSisterWaffle : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().BelongsToClan("Oracle Think Tank"))
			{
				SetBool(1);
				Forerunner("Oracle Think Tank");	
			}
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
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	public override int Act ()
	{
		if(RC () && CB (1) && GetDeck().Size() >= 3)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Update ()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				SetBool(2);
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD, 3, delegate(Game2DCard c) {
					return c._CardInfo.name.Contains("Battle Sister");	
				});
			});
		});
		
		if(GetBool(2) && !GetDeck().IsOpen())
		{
			UnsetBool(2);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				ShuffleDeck();
				EndEffect();	
			}
		}
		
		CallFromDeckUpdate(delegate {
			IncreasePowerByTurn(CallFromDeckList[0], 2000);
			EndEffect();
			ShuffleDeck();
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
