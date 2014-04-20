using UnityEngine;
using System.Collections;

public class DragonicBurnout : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(CanSoulBlast(1)
			   && NumUnitsDrop(delegate(Card c) { return c.name.Contains("Overlord"); }) > 0
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			GetFieldWatcher().Reset();
			GetFieldWatcher().AddCardList(GetDropZone());
			GetFieldWatcher().SetIsExitEnabled(false);

			GetFieldWatcher().Filter(delegate(Card c) {
				return c.name.Contains("Overlord");
			});

			GetFieldWatcher().SetActionToPerform(delegate(Card c) {
				GetFieldWatcher().Close();
				FromDropToDeck(c, true);
				GetFieldWatcher().RemoveFromList(c);
			});

			GetFieldWatcher().Open();
		});

		FromDropToDeckUpdate(delegate {
			SoulBlast(1);
		});

		SoulBlastUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
			delegate {
				RetireEnemyUnit(EnemyUnit);
			},
			delegate {
				return true;
			},
			delegate {

			});
		});
	}
}
