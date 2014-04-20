using UnityEngine;
using System.Collections;

/*
 * [ACT](RC):[Soul Blast (1)] If you have an «Oracle Think Tank» vanguard, 
 * draw a card, and put this unit on the top of your deck.
 */

public class BrioletteMagus : UnitObject {
	public override int Act ()
	{
		if(RC () && CanSoulBlast(1) && VanguardIs("Oracle Think Tank") && GetDeck().Size() > 0)
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
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			DrawCard(1);	
		});
		
		DrawCardUpdate(delegate {
			FromFieldToDeck(OwnerCard, false);
			EndEffect();
		});
	}
}
