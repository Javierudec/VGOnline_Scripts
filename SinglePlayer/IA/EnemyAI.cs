using UnityEngine;
using System.Collections;

public class EnemyAI {
	private string name = "Enemy AI";

	protected void SetName(string _name)
	{
		name = _name;
	}

	public string GetName()
	{
		return name;
	}

	//Rock-Paper-Scissors game.
	public Choose GetChoosePaperGame()
	{
		return (Choose)Random.Range(0, 2);
	}

	//Select starting turn.
	public bool ChooseFirstTurn()
	{
		return true;
	}	
}
