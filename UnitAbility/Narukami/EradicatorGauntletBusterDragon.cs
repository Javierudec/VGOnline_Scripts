using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):When your opponent's rear-guard is put into the drop zone due to 
 * an effect from one of your cards, this unit gets [Power]+3000/[Critical]+1 
 * until end of turn.
 * 
 * [ACT](VC):[Counter Blast (2)-card with "Eradicator" in its card name] Your 
 * opponent chooses one of his or her rear-guards, and retires it.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class EradicatorGauntletBusterDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(VC() && LimitBreak(4))
			{
				IncreasePowerAndCriticalByTurn(OwnerCard, 3000, 1);	
			}
		}
	}
	
	public override int Act ()
	{
		if(VC() && CB(2, delegate(Card c) { return c.name.Contains("Eradicator"); }) && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				OpponentRetireUnit();
			},
			delegate(Card c) {
				return c.name.Contains("Eradicator");
			});
		});
	}
	
	public override void EndEvent ()
	{
		//Game.field.CheckAbilities(CardState.EnemyCardSendToDropZone);
		EndEffect();
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
