using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When another «Spike Brothers» rides this unit, you may call 
 * this card to a (RC).
 * 
 * [ACT](RC):[Counter Blast (1) & Retire this unit] Search your deck for 
 * up to one grade 1 or less «Spike Brothers», reveal it to your opponent, 
 * put it into your hand, and shuffle your deck.
 */

public class MechaTrainer : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().BelongsToClan("Spike Brothers"))
			{
				SetBool(1);
				Forerunner("Spike Brothers");
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
		if(RC () && CB (1) && GetDeck().Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Update ()
	{
		Forerunner_Update();
		
		DelayUpdate (delegate {
			CounterBlast(1,
			delegate {
				RetireUnit(OwnerCard);
				SetBool(2);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Spike Brothers") && c._CardInfo.grade <= 1;	
				});
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
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
