using UnityEngine;
using System.Collections;

public class CleanupCelestialRamielReverse : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul (CardIdentifier.PROPHECY_CELESTIAL__RAMIEL))
		{
			AddContPower(2000);
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && NumUnits (delegate(Card c) { return c.name.Contains("Celestial"); }) >= 2)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit ("Choose two of your rear-guards with \"Celestial\" in its card name.", 2, false,
			delegate {
				LockUnit(Unit);
			},
			delegate {
				return Unit.name.Contains("Celestial");
			},
			delegate {
				int n = NumUnits (delegate(Card c) { return c.name.Contains("Celestial") && IsInFrontRow(c); }, true);
				SelectUnit ("Choose " + n + " of your rear-guards with \"Celestial\" in its card name in the front row.", n, false,
				delegate {
					IncreasePowerByTurn(Unit, 5000);
				},
				delegate {
					return Unit.name.Contains("Celestial") && IsInFrontRow(Unit);
				},
				delegate {
					if(NumUnitsDamage(delegate(Card c) { return c.cardID == CardIdentifier.CLEANUP_CELESTIAL__RAMIEL______REVERSE_____; }) > 0
					   && Game.enemyField.GetDamage() > 0)
					{
						SelectInEnemyDamage(1, false,
						delegate {
							Game.GameChat.AddChatMessage("ADMIN", "Enemy damage: " + _ESID_Card.name);
							EnemyFromDamageToDrop(_ESID_Card);
							if(NumEnemyUnits(delegate(Card c) { return true; }) > 0)
							{
								OpponentFromFieldToDamage();
							}
							else
							{
								EndEffect();
							}
						});
					}
					else
					{
						EndEffect();
					}
				}, true);
			});
		});
	}

	public override void EndEvent ()
	{
		EndEffect();
	}
}
