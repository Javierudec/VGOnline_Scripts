using UnityEngine;
using System.Collections;

public class BlueWaveDragonTetraDriveDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor ().IsVanguard())
			{
				SetBool(1);
			}
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1))
			{
				if(VC ()
				   && Game.numBattle == 2)
				{
					SelectAnimField(OwnerCard);
					SetBool(2);
				}
			}

			UnsetBool(1);
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(2);
		}
		else if(cs == CardState.Attacking_NotMe)
		{
			if(GetDefensor().IsVanguard())
			{
				SetBool(3);
			}
		}
		else if(cs == CardState.EndBattle_NotMe)
		{
			if(GetBool(3))
			{
				if(Game.numBattle == 4
				   && CB(2)
				   && HandSize (delegate(Card c) { return c.BelongsToClan("Aqua Force"); }) >= 2)
				{
					SetBool(4);
					DisplayConfirmationWindow();
				}
			}

			UnsetBool(3);
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(4);
		return true;
	}

	public override int Act ()
	{
		if(VC ()
		   && CB(1))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(4))
			{
				UnsetBool(4);
				CounterBlast(2,
				delegate {
					SelectInHand(2, true,
					delegate {
						DiscardSelectedCard();
					},
					delegate {
						return _SIH_Card.BelongsToClan("Aqua Force");
					},
					delegate {
						StandUnit(OwnerCard); 
					}, "Choose two \"Aqua Force\" from your hand.");
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					IncreasePowerByTurn(OwnerCard, 2000);
					EndEffect();
				});
			}
		});
	}
}
