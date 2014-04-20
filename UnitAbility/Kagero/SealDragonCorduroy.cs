using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast (1) - Cards with "Seal Dragon" in its card name] 
 * When this unit is placed on (VC) or (RC), if you have a «Kagerō» vanguard,
 * you may pay the cost. If you do, choose one of your opponent's rear-guards,
 * retire it, and your opponent looks at up to four cards from the top of his or
 * her deck, searches for up to one grade 2 unit, calls it to (RC), and shuffles 
 * his or her deck.
 */

public class SealDragonCorduroy : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(CB(1, delegate(Card c) { return c.name.Contains("Seal Dragon"); })
			   && VanguardIs("Kagero")
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active ()
	{
		ShowAndDelay();
	}

	public override void EndEvent ()
	{
		EndEffect();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectEnemyUnit("Choose one of your opponent's rear-guards", 1, false,
				delegate {
					RetireEnemyUnit(EnemyUnit);
				},
				delegate {
					return true;
				},
				delegate {
					OpponentCallFromDeckLookingAtTop(4, 2, 2); //Numbers of cards at top, grade of the unit. (min, max)
				});
			},
			delegate(Card c) {
				return c.name.Contains("Seal Dragon");
			});
		});
	}
}
