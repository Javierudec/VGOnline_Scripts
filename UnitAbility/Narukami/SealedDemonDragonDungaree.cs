using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SealedDemonDragonDungaree : UnitObject {
	List<Card> _AuxList_Card;
	
	public override void Cont()
	{
		if(cardStorage.Count <= 0)
		{
			AddContPower(-2000);
		}
	}
	
	public override int Act()
	{
		if(VC () 
		   && LimitBreak(4) 
		   && CB (1) 
		   && cardStorage.Count > 0 
		   && GetBool(2))
		{
			return 1;
		}
		
		return 0;
	}
	
	public override void Active()
	{
		UnsetBool(2);
		StartEffect();
		ShowAndDelay();
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Ride)
		{
			cardStorage.Clear();
			SetBool(2);
			
			if(Game.playerDeck.Size() >= 2)
			{
				StartEffect();
				
				cardStorage.Add(Game.playerDeck.GetByIndex(0));
				cardStorage.Add(Game.playerDeck.GetByIndex(1));
				
				_AuxList_Card = new List<Card>();
				_AuxList_Card.Add(Game.playerDeck.GetByIndex(0));
				_AuxList_Card.Add(Game.playerDeck.GetByIndex(1));
				
				BindFromDeck(_AuxList_Card);
			}
		}
		else if(cs == CardState.BeginMain)
		{
			SetBool(2);	
		}
	}
	
	public override void Update()
	{
		BindFromDeckUpdate(delegate {
			EndEffect();
		});
		
		DelayUpdate(delegate {
			CounterBlast(1, 
			             delegate {
				Game.field.bCloseEnable = false;
				Game.field.ViewBindZone(1, 
				                        delegate(Card c) { 
					for(int i = 0; i < cardStorage.Count; i++) 
					{
						if(c == cardStorage[i])
						{
							return true;	
						}
					}
					return false;
				});
				SetBool(1);
			});
		});
		
		if(GetBool(1))
		{
			if(!Game.field.ViewingBindZone())
			{
				_AuxIdVector = Game.field.GetLastSelectedList();
				UnsetBool(1);
				Game.field.bCloseEnable = true;
				FromBindToDeck(Game.field.GetBoundByID(_AuxIdVector[0]), true);
			}
		}
		
		FromBindToDeckUpdate(delegate {
			if(NumEnemyUnits(delegate(Card c) { return c.pos == fieldPositions.ENEMY_FRONT_LEFT || c.pos == fieldPositions.ENEMY_FRONT_RIGHT; }) > 0)
			{
				SelectEnemyUnit("Choose one of your opponent's front row rear-guards.", 1, true,
				delegate {
					RetireEnemyUnit(EnemyUnit);
				},
				delegate {
					return EnemyUnit.pos == fieldPositions.ENEMY_FRONT_LEFT || EnemyUnit.pos == fieldPositions.ENEMY_FRONT_RIGHT;
				},
				delegate {
					
				});
			}	
			else
			{
				EndEffect();
			}
		});
		
	}
}
