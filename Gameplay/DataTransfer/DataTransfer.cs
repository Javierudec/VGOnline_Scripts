using UnityEngine;
using System.Collections;

public class DataTransfer {
	CardIdentifier cardID;

	GameAction gameAction;

	int other1;
	int other2;
	int other3;

	string str1;

	public DataTransfer(CardIdentifier _cardID, GameAction _gameAction, int _other1, int _other2, int _other3, string _str1)
	{
		cardID = _cardID;
		gameAction = _gameAction;
		other1 = _other1;
		other2 = _other2;
		other3 = _other3;
		str1 = _str1;
	}

	public GameAction getGameAction()
	{
		return gameAction;
	}

	public CardIdentifier getID()
	{
		return cardID;
	}

	public string getString(int num)
	{
		if(num == 1) return str1;

		return "";
	}

	public int getInt(int num)
	{
		if(num == 1) return other1;
		else if(num == 2) return other2;
		else if(num == 3) return other3;

		return 0;
	}
}
