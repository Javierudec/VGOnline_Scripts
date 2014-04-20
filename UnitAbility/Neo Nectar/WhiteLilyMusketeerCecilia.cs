using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (1) & Choose five normal units with "Musketeer" 
 * in its card name from your drop zone, and put the chosen cards on the bottom
 * of your deck in any order] Search your deck for up to two cards named "White 
 * Lily Musketeer, Cecilia", call them to separate (RC), and shuffle your deck. 
 * This ability cannot be used for the rest of that turn.
 * 
 * [ACT](VC):[Choose one of your rear-guards with "Musketeer" in its card name, 
 * and retire it] Look at up to five cards from the top of your deck, search for
 * up to one card with "Musketeer" in its card name from among them, call it to 
 * (RC), and shuffle your deck. This ability cannot be used for the rest of that turn.
 */

public class WhiteLilyMusketeerCecilia : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			UnsetBool(6);
			UnsetBool(7);
		}
	}

	public override int Act ()
	{
		int n = 0;

		if(VC ()
		   && LimitBreak(4)
		   && CB(1)
		   && NumUnitsDamage(delegate(Card c) { return c.name.Contains("Musketeer") && c.GetTriggerType() == TriggerIcon.NONE; }) > 0
		   && !GetBool(6))
		{
			n++;
		}

		if(VC ()
		   && NumUnits(delegate(Card c) { return c.name.Contains("Musketeer"); }) > 0
		   && GetDeck ().Size() > 0
		   && !GetBool(7))
		{
			n++;
		}

		return n;
	}

	public override void Active (int idAbility)
	{
		StartEffect();
		ShowAndDelay();
		SetBool(idAbility);
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			bool bFirstAbility = false;
			bool bSecondAbility = false;

			if(GetBool(1))
			{
				UnsetBool(1);

				if(VC ()
				   && LimitBreak(4)
				   && CB(1)
				   && NumUnitsDamage(delegate(Card c) { return c.name.Contains("Musketeer") && c.GetTriggerType() == TriggerIcon.NONE; }) > 0)
				{
					bFirstAbility = true;
				}
				else
				{
					bSecondAbility = true;
				}
			}

			if(GetBool(2))
			{
				UnsetBool(2);
				bSecondAbility = true;
			}

			if(bFirstAbility)
			{
				SetBool(6);
				CounterBlast(1,
				delegate {
					SetBool(3);
					Game.field.ViewDropZone(1, 
					delegate(Card c) {
						return c.name.Contains("Musketeer") && c.GetTriggerType() == TriggerIcon.NONE;
					});
				});
			}

			if(bSecondAbility)
			{
				SetBool(7);
				SelectUnit("Choose one of your rear-guards with \"Musketeer\" in its card name.", 1, false,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.name.Contains("Musketeer");
				},
				delegate {
					int num = min (5, GetDeck ().Size());
					SetBool(5);
					GetDeck ().ViewDeck(1, SearchMode.TOP_CARD, num, delegate(Game2DCard c) {
						return c._CardInfo.name.Contains("Musketeer");
					});
				});
			}
		});

		ResolveDeckOpening(5,
		delegate {
			OnlyOpenRC(true);
			CallFromDeck (_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		ResolveDropOpening(3,
		delegate {
			FromDropToDeck(_AuxIdVector, true);
		},
		delegate {
			EndEffect();
		});

		FromDropToDeckUpdate(delegate {
			SetBool(4);
			GetDeck ().ViewDeck(2, delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.WHITE_LILY_MUSKETEER__CECILIA;
			});
		});

		ResolveDeckOpening(4,
		delegate {
			OnlyOpenRC(true);
			CallFromDeck (_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect();
			ShuffleDeck();
		});
	}
}
