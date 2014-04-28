using UnityEngine;
using System.Collections;

public class GAFromSoulToHand : GameActionObject {	
	public override void Run (DataTransfer data)
	{
		Card card = game.getEnemyField().GetCardFromSoulByID(data.getID());
		game.getEnemyField().RemoveFromSoul(card);
		game.getEnemyField().Ride(card);
	}
}
