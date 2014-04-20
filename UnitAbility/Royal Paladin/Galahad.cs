using UnityEngine;
using System.Collections;

public class Galahad : UnitObject {
	public override void Cont()
	{
		if(Game.field.GetSoulByID(CardIdentifier.KNIGHT_OF_QUESTS__GALAHAD) == null ||
		   Game.field.GetSoulByID(CardIdentifier.KNIGHT_OF_TRIBULATIONS__GALAHAD) == null ||
		   Game.field.GetSoulByID(CardIdentifier.DRANGAL) == null)
		{
			AddContPower(-2000);	
		}
	}
	
	public override int Act()
	{
		if(OwnerCard.IsVanguard() && Game.field.GetNumberOfDamageCardsFaceup() >= 2 &&
		   Game.field.GetUnitsSoulWithClanName("Royal Paladin") >= 6)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active()
	{
		ShowOnScreen();
		FlipCardInDamageZone(2);
		IncreasePowerAndCriticalByTurn(OwnerCard, 3000, 1);
	}
}
