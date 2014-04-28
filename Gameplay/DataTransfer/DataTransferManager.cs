using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DataTransferManager {
	static DataTransferManager dataTransferManager = null;

	Dictionary<GameAction, GameActionObject> gameActions = null;

	DataTransferManager()
	{
		gameActions = new Dictionary<GameAction, GameActionObject>();

		foreach(GameAction ga in Enum.GetValues(typeof(GameAction)))
		{
			gameActions[ga] = null;
		}

		gameActions[GameAction.PLACE_INITIAL_VANGUARD] = new GAPlaceInitialVanguard();
		gameActions[GameAction.DYNAMICTEXT_GAMEPHASE]  = new GADynamicTextGamePhase();
		gameActions[GameAction.FROM_SOUL_TO_DECK]      = new GAFromSoulToDeck();
		gameActions[GameAction.FROM_SOUL_TO_HAND]      = new GAFromSoulToHand();
		gameActions[GameAction.ENEMY_REST]             = new GAEnemyRest();
	}

	public static DataTransferManager getTransferManager()
	{
		if(dataTransferManager == null)
		{
			dataTransferManager = new DataTransferManager();
		}

		return dataTransferManager;
	}

	public void ExecuteDataTransfer(DataTransfer dataTransfer)
	{
		if(gameActions[dataTransfer.getGameAction()] == null)
		{
			return;
		}

		gameActions[dataTransfer.getGameAction()].Run(dataTransfer);
	}
}
