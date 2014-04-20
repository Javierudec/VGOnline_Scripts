using UnityEngine;
using System.Collections;

public class CardInformation {
	public int grade;
	public TriggerIcon trigger;
	public SkillIcon skill;
	public int shield;
	public string name;
	public string race;
	public string clan;
	public string secondaryClan;
	public int critical;
	public int power;
	public string mat;
	public CardIdentifier cardID;
	public bool bSentinel;

	public CardInformation(int _grade, TriggerIcon _trigger, SkillIcon _skill, int _shield, string _name, string _race, string _clan, int _critical, int _power, string _mat, CardIdentifier _cardID, string _secondaryClan = "None", bool _bSentinel = false)
	{
		grade = _grade;
		trigger = _trigger;
		skill = _skill;
		shield = _shield;
		name = _name;
		race = _race;
		critical = _critical;
		power = _power;
		clan = _clan;
		mat = _mat;
		cardID = _cardID;
		secondaryClan = _secondaryClan;
		bSentinel = _bSentinel;
	}
	
	public bool BelongsToClan(string clanName)
	{
		return clanName == clan || clanName == secondaryClan;	
	}
}
