using UnityEngine;
using System.Collections;

/*
 * [AUTO]: Forerunner (When a unit of the same clan rides this unit,
 * you may call this unit to (RC))
 * 
 * [ACT](RC):[Counter Blast (1) - Cards with "Seal Dragon" in its card
 * name & Put this unit into your soul] If you have a «Kagero» vanguard, 
 * choose one of your opponent's rear-guards, retire it, and your opponent 
 * looks at up to four cards from the top of his or her deck, searches for 
 * up to one grade 2 unit, calls it to (RC), and shuffles his or her deck.
 */

public class SealDragonTerrycloth : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Kagero"))
			{
				SetBool(1);
				Forerunner("Kagero");
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
		if(RC () 
		   && CB(1, delegate(Card c) { return c.name.Contains("Seal Dragon"); }))
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

	public override void EndEvent ()
	{
		EndEffect();
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			CounterBlast(1,
			delegate {
				if(VanguardIs("Kagero"))
				{
					if(NumEnemyUnits(delegate(Card c) { return true; }) > 0)
					{
						SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, false,
						delegate {
							RetireEnemyUnit(EnemyUnit);
						},
						delegate {
							return true;
						},
						delegate {
							OpponentCallFromDeckLookingAtTop(4, 2, 2);
						});
					}
				}
				else
				{
					EndEffect();
				}
			},
			delegate (Card c) {
				return c.name.Contains("Seal Dragon");
			});
		});
	}
}
