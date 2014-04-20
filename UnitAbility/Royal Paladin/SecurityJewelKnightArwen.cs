using UnityEngine;
using System.Collections;

public class SecurityJewelKnightArwen : UnitObject {
	public override int Act ()
	{
		if(RC()
		   && NumUnitsDrop(delegate(Card c) { return c.name.Contains("Ashlei") && c.grade == 3; }) > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SetBool(1);
			Game.field.ViewDropZone(1, delegate(Card c) {
				return c.grade == 3 && c.name.Contains("Ashlei");
			});
		});

		ResolveDropOpening(1,
		delegate {
			FromDropToDeck(_AuxIdVector, true);
		},
		delegate {
			EndEffect();
		});

		FromDropToDeckUpdate(delegate {
			if(VanguardIs("Royal Paladin")
			   && NumUnits (delegate(Card c) { return c.grade == 3 && c.name.Contains("Ashlei"); }) > 0)
			{
				SelectUnit ("Choose one of your grade 3 units with \"Ashlei\" in its card name.", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 5000);
				},
				delegate {
					return Unit.grade == 3 && Unit.name.Contains("Ashlei");
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
