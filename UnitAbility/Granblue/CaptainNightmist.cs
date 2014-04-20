using UnityEngine;
using System.Collections;

public class CaptainNightmist : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn() && OwnerCard.IsVanguard() && Game.field.GetDropByID(CardIdentifier.CAPTAIN_NIGHTMIST) != null)
		{
			AddContPower(3000);	
		}
	}
	
	public override int EffectOnDrop ()
	{
		if(Game.field.GetNumberOfDamageCardsFaceup() >= 1 &&
		   Game.field.GetNumberOfRearWithClanNameAndGradeGreaterOrEqual("Granblue", 1) > 0 &&
		   Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE).clan == "Granblue")
		{
			return 1;	
		}

		return 0;
	}
	
	public override void Active()
	{
		Game.bEffectOnGoing = true;
		FlipCardInDamageZone(1);
		ShowOnScreen(OwnerCard);
		EnableMouse();
		DisplayHelpMessage("Choose one of your grade 1 or greater Granblue rear-guards, retire it.");
		
		Game.field.CloseDeck();
	}	
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(IsRearGuard(p))
			{
				Card c = Game.field.GetCardAt(p);
				if(c != null && c.clan == "Granblue" && c.grade >= 1)
				{
					ClearMessage();
					RetireUnit(c);
					DisableMouse();
					CallFromDrop(OwnerCard);
				}
			}
		}
	}
	
	public override void Update()
	{
		CallFromDropUpdate(delegate() {
			Game.bEffectOnGoing = false;	
		});
	}
}
