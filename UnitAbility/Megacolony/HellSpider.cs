using UnityEngine;
using System.Collections;

public class HellSpider : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn())
		{
			if(Game.enemyField.GetNumberOfRearGuardRested() == Game.enemyField.GetNumberOfRearUnits())
			{
				if(!Game.enemyField.GetCardAt(EnemyFieldPosition.VANGUARD).IsStand())
				{
					AddContPower(3000);
				}
			}
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(Game.field.GetNumberOfDamageCardsFaceup() >= 2)
			{
				if(Game.enemyField.GetNumberOfRearUnits() > 0)
				{
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public override void Active()
	{
		ShowOnScreen(OwnerCard);
		FlipCardInDamageZone(2);
		EnableMouse();
		Game.bEffectOnGoing = true;
	}
	
	public override void Pointer()
	{
		if(AcceptInput())
		{
			fieldPositions pos = Util.GetMousePosition();
			if(Util.IsEnemyPosition(pos) && pos != fieldPositions.ENEMY_VANGUARD)
			{
				Card temp = Game.enemyField.GetCardAt(Util.TransformToEquivalentEnemyPosition(pos));
				if(temp != null)
				{
					CantStandUntilNextTurn(temp);
					ClearMessage();
					DisableMouse();
					Game.bEffectOnGoing = false;
				}
			}
		}
	}
}
