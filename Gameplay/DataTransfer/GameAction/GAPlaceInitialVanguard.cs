using UnityEngine;
using System.Collections;

public class GAPlaceInitialVanguard : GameActionObject {
	public override void Run (DataTransfer data)
	{
		Card vanguard = game.getEnemyDeck().DrawCard();
		game.getDB().FillCardWithData(vanguard, data.getID());
		game.getEnemyField().Ride(vanguard);
		vanguard.TurnDown();
	}
}
