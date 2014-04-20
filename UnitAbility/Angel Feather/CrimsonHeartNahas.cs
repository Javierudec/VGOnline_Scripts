using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, 
 * you may call this unit to (RC) [ACT](RC):
 * [Put this unit into your soul & Choose a unit named "Crimson Mind, Baruch" from your (RC), 
 * and put it into your soul] If you have a unit named "Crimson Drive, Aphrodite" on your (VC), 
 * search your deck for up to one card named "Crimson Impact, Metatron", ride it, and shuffle your deck.
 */

public class CrimsonHeartNahas : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			SetBool(1);
			Forerunner("Angel Feather");
		}
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
	
	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}
	
	public override int Act ()
	{
		if(RC () && GetVanguard().cardID == CardIdentifier.CRIMSON_DRIVE__APHRODITE && NumUnits(delegate(Card c) {	return c.cardID == CardIdentifier.CRIMSON_MIND__BARUCH; }) > 0)
		{
			return 1;
		}
		
		return 0;
	}
	
	public override void Update()
	{
		Forerunner_Update();
		
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit("Choose a card named \"Crimson Mind, Baruch\" from your field.", 1, false,
			delegate {
				MoveToSoul(Unit);
			},
			delegate {
				return Unit.cardID == CardIdentifier.CRIMSON_MIND__BARUCH;
			},
			delegate {
				SetBool(2);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.cardID == CardIdentifier.CRIMSON_IMPACT__METATRON;
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
				
				ShuffleDeck();
				EndEffect();	
			}
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
