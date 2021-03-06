using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan 
 * rides this unit, you may call this unit to (RC))
 * [ACT](RC):[Counter Blast (1) & Put this unit into your 
 * soul] Look at up to ten cards from the top of your deck, 
 * search for up to one «Pale Moon» from among them, put 
 * it into your soul, and shuffle your deck.
 */
 
public class SmilingPresenter : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Pale Moon"))
			{
				SetBool(1);
				Forerunner("Pale Moon");
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
		if(RC () && CB (1))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				SetBool(2);
				GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min (10, GetDeck().Size()), delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Pale Moon");	
				});
			});
		});
		
		if(GetBool(2) && !GetDeck().IsOpen())
		{
			UnsetBool(2);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				SoulCharge(_AuxIdVector);		
			}
			else
			{
				EndEffect();
				ShuffleDeck();
			}
		}
		
		SoulChargeUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
	
	public override void Pointer()
	{
		CounterBlast_Pointer();	
	}
}
