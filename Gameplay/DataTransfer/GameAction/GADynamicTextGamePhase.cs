using UnityEngine;
using System.Collections;

public class GADynamicTextGamePhase : GameActionObject {
	public override void Run (DataTransfer data)
	{
		game.SetCentralMessage(data.getString(1));
	}
}
