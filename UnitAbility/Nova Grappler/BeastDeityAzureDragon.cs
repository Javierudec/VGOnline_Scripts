using UnityEngine;
using System.Collections;

public class BeastDeityAzureDragon : UnitObject {
	public override void Cont()
	{
		if(NumUnits(delegate(Card c) { return !c.BelongsToClan("Nova Grappler"); }) > 0)
		{
			AddContPower(-2000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard()
			   && HandSize(delegate(Card c) { return c.cardID == CardIdentifier.BEAST_DEITY__AZURE_DRAGON; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	void BeastDeityAzureDragon_Active()
	{
		ShowAndDelay();	
	}
	
	void BeastDeityAzureDragon_Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, false,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return _SIH_Card.cardID == CardIdentifier.BEAST_DEITY__AZURE_DRAGON;
			},
			delegate {
				int n = min (2, Game.field.GetNumberOfRearRested());
				SelectUnit ("Choose up to two of your rear-guards.", n, true,
				delegate {
					StandUnit(Unit);
				},
				delegate {
					return true;
				},
				delegate {

				});
			}, "Choose a card named \"Beasy Deity, Azure Dragon\" from your hand.");
		});
	}
}
