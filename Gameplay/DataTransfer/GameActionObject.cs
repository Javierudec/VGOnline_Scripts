using UnityEngine;
using System.Collections;

public class GameActionObject {
	protected Gameplay game = null;

	protected GameActionObject()
	{
		game = Gameplay.getGame();
	}

	public virtual void Run(DataTransfer data)
	{
		Debug.Log("Original Function");
	}
}
