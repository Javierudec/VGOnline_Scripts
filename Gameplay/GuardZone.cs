using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuardZone {
	public List<Card> cards;
	private List<Vector3> positions;
	private Vector3 playerRotation;
	private Vector3 enemyRotation;
	private int extraShield = 0;
	private bool bPerfectGuard = false;
	Gameplay game;
	Field field;
	EnemyField enemyField;
	
	public GuardZone()
	{
		cards = new List<Card>();	
		positions = new List<Vector3>();
		
		playerRotation = new Vector3(0.0f, 90.0f, 0.0f);
		enemyRotation = new Vector3(0.0f, -90.0f, 0.0f);
		
		positions.Add(new Vector3(-3.684313f, 0.5970612f, 0.1129827f));
		positions.Add (new Vector3(4.237865f, 0.5970612f, 0.1129827f));
		positions.Add (new Vector3(-0.005577564f, 0.5748787f, 1.502353f));
		positions.Add(new Vector3(-0.005577564f, 0.7560673f, -2.236243f));
	}
	
	public void SetGame(Gameplay _game)
	{
		game = _game;	
	}
	
	public void SetField(Field _field)
	{
		field = _field;	
	}
	
	public void SetEnemyField(EnemyField _enemyField)
	{
		enemyField = _enemyField;	
	}
	
	public void AddToGuardZone(Card _card, bool bPlayerView)
	{
		cards.Add(_card);
		_card.TurnUp();

		Vector3 newPosition = positions[(cards.Count - 1) % 4];
		Vector3 newAngle;

		if(bPlayerView) newAngle = playerRotation;
		else newAngle = enemyRotation;

		_card.MoveAndRotate(newPosition, newAngle);

		_card._Coord = CardCoord.GUARD;
	}
	
	public void CleanGuardZone(EnemyField field)
	{
		for(int i = 0; i < cards.Count; i++)
		{
			field.AddToDropZone(cards[i], false);	
		}
		cards.Clear();
		extraShield = 0;
		
		field.ResetShield();
	}
	
	public void Remove(Card c, bool myGuardian = false)
	{
		cards.Remove(c);
		game.CardToAttack.extraShield -= c.shield;
		
		if(myGuardian)
		{
			field.AddToDropZone(c);
			c.CheckAbilities(CardState.DropZoneFromGC);
			field.CheckAbilities(CardState.DropZoneFromGC_NotMe, c);
			if(c.bSentinel)
			{
				bPerfectGuard = false;	
				game.CardToAttack.bCanBeHit = true;
			}
		}
		else
		{
			enemyField.AddToDropZone(c, false);
		}
	}

	public void CleanGuardZone(Field field)
	{
		for(int i = 0; i < cards.Count; i++)
		{
			field.AddToDropZone(cards[i]);	
			cards[i].CheckAbilities(CardState.DropZoneFromGC);
			field.CheckAbilities(CardState.DropZoneFromGC_NotMe, cards[i]);
		}
		cards.Clear();
		bPerfectGuard = false;
		
		field.ResetShield();
	}	
	
	public int GetTotalDefense()
	{
		int defense = 0;
		for(int i = 0; i < cards.Count; i++)
		{
			defense += cards[i].shield;	
		}
		return defense + extraShield;
	}
	
	public void AddExtraPower(int power)
	{
		extraShield += power;
	}
	
	public void ActivePerfectGuard()
	{
		bPerfectGuard = true;	
	}
	
	public bool GetPerfectGuard()
	{
		return bPerfectGuard;	
	}
	
	public void Update()
	{
		//Debug.Log ("Card on Guardian Circle: " + cards.Count);
		
		for(int i = 0; i < cards.Count; i++)
		{
			cards[i].Update();
		}
	}
}
