using UnityEngine;
using System.Collections;

public class Alfred : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() && !CurrentPhaseIs(GamePhase.ENEMY_TURN) && !CurrentPhaseIs(GamePhase.GUARD))
		{
			AddContPower(Game.field.GetNumberOfRearWithClanName("Royal Paladin") * 2000);
		}
	}
	
	public override int Act()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 3 && CurrentPhaseIs(GamePhase.MAIN_PHASE))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active()
	{
		ShowOnScreen(OwnerCard);
		Game.playerDeck.ViewDeck("Royal Paladin", 2);
		_AuxBool = true;
		FlipCardInDamageZone(3);
		StartEffect();
	}
	
	public override void Update()
	{
		if(_AuxBool)
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxBool = false;
				CallFromDeck(Game.playerDeck.GetLastSelectedList());
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
			Game.playerDeck.Shuffle();
		});
	}
}
