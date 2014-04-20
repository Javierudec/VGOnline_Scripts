using UnityEngine;
using System.Collections;

/*
 * [ACT](Soul):[Put this card into your drop zone] Choose up to one of your 
 * «Dimension Police» vanguard, and that unit gets "[AUTO](VC):[Counter 
 * Blast (1)] When this unit's attack hits a vanguard, you may pay the cost. If 
 * you do, draw a card." until end of turn.
 */

public class DimensionalRoboDaibrave : UnitObject {
	public override int EffectOnSoul ()
	{
		if(VanguardIs("Dimension Police"))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
		Game.field.CloseDeck();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectAnimField(GetVanguard());
			GetVanguard().unitAbilities.AddUnitObject(new DimensionalRoboDaibraveExternEffect());
			EndEffect();
		});
	}
}

public class DimensionalRoboDaibraveExternEffect : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(VC () && CB(1) && GetDefensor().IsVanguard() && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				DrawCard(1);
			});
		});
		
		DrawCardUpdate(delegate {
			EndEffect();	
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
