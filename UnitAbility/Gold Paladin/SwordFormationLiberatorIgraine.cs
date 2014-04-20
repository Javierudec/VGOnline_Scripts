using UnityEngine;
using System.Collections;

public class SwordFormationLiberatorIgraine : UnitObject {
	int numCardsToCall = 0;
	Card currentCard = null;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.UsedToGuard)
		{
			if(CB (1)
			   && VanguardIs(OwnerCard.clan)
			   && GetDeck().Size() >= 5)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				if(currentCard.BelongsToClan(OwnerCard.clan))
				{
					FromDeckToGuardianCircle(currentCard);
				}
				else
				{
					SendCardFromDeckToDrop();
					ResolveQuintetWallNextCard();
				}
			}
			else
			{
				CounterBlast(1,
				delegate {
					numCardsToCall = 5;
				});
			}
		});

		FromDeckToGuardianCircleUpdate(delegate {
			ResolveQuintetWallNextCard();
		});

		if(numCardsToCall > 0 && !GetBool(1))
		{
			SetBool(1);
			currentCard = RevealTopCard();
			Delay(0.8f);
		}
	}

	void ResolveQuintetWallNextCard()
	{
		numCardsToCall--;
		if(numCardsToCall <= 0)
		{
			EndEffect();
		}
		else
		{
			UnsetBool(1);
		}
	}
}
