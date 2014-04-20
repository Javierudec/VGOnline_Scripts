using UnityEngine;
using System.Collections;

public class BlasterDark : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.BLASTER_JAVELIN) != null)
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Ride)
		{
			if(CheckCounterBlast(2) &&
			   Game.enemyField.GetNumberOfRearUnits() > 0)
			{
				StartEffect();
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();
		FlipCardInDamageZone(2);
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			EnableMouse("Choose one of your opponent's rear-guards.");	
		});
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions p = Util.GetMousePosition();
			if(Util.IsEnemyPosition(p) && p != fieldPositions.ENEMY_VANGUARD)
			{	
				Card c = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(p));
				if(c != null)
				{	
					RetireEnemyUnit(c);
					DisableMouse();
					ClearMessage();
					EndEffect();
				}
			}
		}
	}
}
