using UnityEngine;
using System.Collections;

public class GAEnemyRest : GameActionObject {
	public override void Run (DataTransfer data)
	{
		Card tmp = game.getField().GetCardAt(Util.TransformToPlayerField((fieldPositions)data.getInt(1)));
		game.getDummyUO().RestUnit(tmp);
	}
}
