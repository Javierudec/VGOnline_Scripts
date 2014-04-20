using UnityEngine;
using System.Collections;

public class ScarletWitchCoCo : UnitObject {
	public override void Cont()
	{
		if(VC ()
		   && NumUnitsInSoul(delegate(Card c) { return true; }) <= 0)
		{
			AddContPower(3000);	
		}
	}
	
	public override void Auto(CardState cs, Card effetOwner)
	{
		if(cs == CardState.Ride)
		{
			if(CB(2)
			   && NumUnitsInSoul(delegate(Card c) { return true; }) <= 1)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(2);
		int maxCards = 2;
		if(maxCards > Game.playerDeck.Size ())
		{
			maxCards = Game.playerDeck.Size();	
		}
		Game._PopupNumber.Open("How many cards you want to draw?", 0, maxCards);
		_AuxBool = true;
	}
	
	public override void Update()
	{
		if(_AuxBool)
		{
			if(!Game._PopupNumber.IsOpen())
			{
				_AuxBool = false;
				for(int i = 0; i < Game._PopupNumber.GetCurrentValue(); i++)
				{
					DrawCardWithoutDelay();
				}
				Game.bEffectOnGoing = false;
			}
		}
	}
}
