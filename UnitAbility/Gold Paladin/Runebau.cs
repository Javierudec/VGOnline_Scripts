using UnityEngine;
using System.Collections;

/*
 * [ACT](RC):[Counter Blast (1) & Put this unit into your 
 * soul] Look at the top card of your deck, search for up 
 * to one «Gold Paladin» from among them, call it to an open
 * (RC), and put the rest on the bottom of your deck.
 */

public class Runebau : UnitObject {
	public override int Act ()
	{
		if(RC () && CB (1) && GetDeck().Size() > 0)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Gold Paladin");
				});
			});
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				Game.bBlockUnitReplacing = true;
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				GetDeck().AddToBottom(GetDeck().DrawCard());
				EndEffect();
			}
		}
		
		CallFromDeckUpdate(delegate {
			Game.bBlockUnitReplacing = false;
			EndEffect();	
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
