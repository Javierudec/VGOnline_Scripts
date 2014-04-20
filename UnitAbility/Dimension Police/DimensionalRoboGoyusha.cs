using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When another «Dimension Police» rides this unit, you may call this 
 * card to (RC).
 * 
 * [ACT](RC):[Choose four of your rear-guards with "Dimensional Robo" in its 
 * card names, and put them into your soul] If you have a grade 2 or greater 
 * «Dimension Police» vanguard with "Dimensional Robo" in its card name, 
 * search your deck for up to one grade 3 card with "Dimensional Robo" in its 
 * card name, ride it, and shuffle your deck.
 */

public class DimensionalRoboGoyusha : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Dimension Police"))
			{
				SetBool(1);
				Forerunner("Dimension Police");
			}
		}
	}
	
	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}
	
	public override int Act ()
	{
		if(RC() && NumUnits(delegate(Card c) { return c.name.Contains("Dimensional Robo"); }) >= 4)
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
			SelectUnit("Choose four of your rear-guards with \"Dimensional Robo\" in its card names.", 4, false,
			delegate {
				MoveToSoul(Unit);
			},
			delegate {
				return Unit.name.Contains("Dimensional Robo");
			},
			delegate {
				if(GetVanguard().grade >= 2 && VanguardIs("Dimension Police") && GetVanguard().name.Contains("Dimensional Robo") && GetDeck().Size() > 0)
				{
					SetBool(2);
					GetDeck().ViewDeck(1, delegate(Game2DCard c) {
						return c._CardInfo.grade == 3 && c._CardInfo.name.Contains("Dimensional Robo");	
					});
				}
				else
				{
					EndEffect();	
				}
			});
		});
		
		if(GetBool(2) && !GetDeck().IsOpen())
		{
			UnsetBool(2);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				RideFromDeck(GetDeck().SearchForID(_AuxIdVector[0]));	
			}
			EndEffect();
			ShuffleDeck();
		}
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
