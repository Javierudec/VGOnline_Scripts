using UnityEngine;
using System.Collections;

public class CEOAmaterasu : UnitObject {
	Card _AuxCard;

	public override void Cont()
	{
		if(!CurrentPhaseIs(GamePhase.ENEMY_TURN) && !CurrentPhaseIs(GamePhase.GUARD))
		{
			if(Game.playerHand.Size() >= 4 && OwnerCard.IsVanguard())
			{
				AddContPower(4000);
			}
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.BeginMain)
		{
			if(OwnerCard.IsVanguard() && Game.playerDeck.Size() > 0)
			{
				ShowOnScreen(OwnerCard);
				Game.SoulCharge();
				_AuxCard = LookAtTopDeckCard();
				Game.playerDeck.RemoveFromDeck(_AuxCard);
				Game._CardMenu.OpenDeckMenu(_AuxCard);
				_AuxBool = true;
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(NumUnitsInSoul(delegate(Card c) { return true; }) >= 8
			   && CB(5))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public void CEOAmaterasu_Active()
	{
		ShowAndDelay();
		Game.bEffectOnGoing = true;
	}
	
	public void CEOAmaterasu_Update()
	{
		DelayUpdate(delegate {
			CounterBlast(5,
			delegate {
				SoulBlast(8);
			});
		});

		SoulBlastUpdate(delegate {
			int maxCards = 5;
			if(maxCards > Game.playerDeck.Size())
			{
				maxCards = Game.playerDeck.Size();	
			}
			Game._PopupNumber.Open("How many cards you want to draw?", 0, maxCards);
			_AuxBool4 = true;
		});
		
		if(_AuxBool4)
		{
			if(!Game._PopupNumber.IsOpen())
			{
				_AuxBool4 = false;
				for(int i = 0; i < Game._PopupNumber.GetCurrentValue(); i++)
				{
					DrawCardWithoutDelay();
				}
				Game.bEffectOnGoing = false;
			}
		}
	}
}
