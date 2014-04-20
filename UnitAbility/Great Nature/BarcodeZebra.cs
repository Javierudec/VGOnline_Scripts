using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (VC) or (RC),
 * reveal the top card of your deck. 
 * If the revealed card is a grade 1 or 2 «Angel Feather», 
 * call that card to (RC), and if it is not, shuffle your deck.
 */

public class BarcodeZebra : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(!GetBool(1))
			{
				SetBool(1);
				_AuxCard1 = RevealTopCard();
				Delay(2);
			}
			else
			{
				UnsetBool(1);
				if(_AuxCard1 != null && _AuxCard1.BelongsToClan("Great Nature") && (_AuxCard1.grade == 1 || _AuxCard1.grade == 2))
				{
					_AuxIdVector = new System.Collections.Generic.List<CardIdentifier>();
					_AuxIdVector.Add(_AuxCard1.cardID);
					CallFromDeck(_AuxIdVector);
				}
				else
				{
					ShuffleDeck();	
				}
			}
		});
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
}
