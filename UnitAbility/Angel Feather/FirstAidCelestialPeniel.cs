using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit, you 
 * may call this unit to (RC))
 * 
 * [ACT](RC):[Put this unit into your soul] If you have an «Angel Feather» 
 * vanguard, choose one face up card from your damage zone with "Celestial" 
 * in its card name, call it to (RC), and put the top card of your deck into 
 * your damage zone face down.
 */

public class FirstAidCelestialPeniel : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Angel Feather"))
			{
				SetBool(1);
				Forerunner("Angel Feather");
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
		if(RC ())
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

		DelayUpdate (delegate {
			MoveToSoul(OwnerCard);
			if(VanguardIs("Angel Feather")
			   && NumUnitsDamage(delegate(Card c) { return c.IsFaceup() && c.name.Contains("Celestial"); }) > 0
			   && GetDeck ().Size() > 0)
			{
				SelectInDamage(1, false,
				delegate {
					CallFromDamage(_SID_Card);
				},
				delegate(Card c) {
					return c.IsFaceup() && c.name.Contains("Celestial");
				});
			}
			else
			{
				EndEffect();
			}
		});

		CallFromDamageUpdate(delegate {
			FromDeckToDamage(GetDeck ().TopCard());
			EndEffect();
		});
	}
}
