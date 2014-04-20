using UnityEngine;
using System.Collections;

public class DragonKnightSadig : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner(OwnerCard.clan);
		}
		else if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(RC ()
			   && VanguardIs("Kagero")
			   && NumEnemyUnits(delegate(Card c) { return true; } ) > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			ShowAndDelay();
		}
		else
		{
			Forerunner_Active();
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate (delegate {
			MoveToSoul(OwnerCard);
			OpponentRetireUnit();
		});
	}

	public override void EndEvent ()
	{
		EndEffect();
	}
}
