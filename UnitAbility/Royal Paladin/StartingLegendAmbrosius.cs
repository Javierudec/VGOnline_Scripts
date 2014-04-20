using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you may 
 * call this unit to (RC))
 * 
 * [ACT](RC):[Put this unit into your soul & Choose a card from your hand, and 
 * discard it] If you have a «Royal Paladin» vanguard, draw a card.
 */

public class StartingLegendAmbrosius : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Royal Paladin"))
			{
				SetBool(1);
				Forerunner("Royal Paladin");
			}
		}
	}
	
	public override int Act ()
	{
		if(RC() && HandSize() > 0)
		{
			return 1;	
		}
		
		return 0;
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
	
	public override void Update ()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectInHand(1, false,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return true;
			},
			delegate {
				if(VanguardIs("Royal Paladin"))
				{
					DrawCard(1);
				}
				else
				{
					EndEffect();	
				}
			}, "Choose a card from your hand.");
		});
		
		DrawCardUpdate(delegate {
			EndEffect();	
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
	}
}
