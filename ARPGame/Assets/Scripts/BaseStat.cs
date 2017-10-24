using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BaseStat
{
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int BaseValue { get; set; }
    public int FinalValue { get; set; }

    public List<StatBonus> BaseAdditives { get; set; }


    public BaseStat(string statName, int baseValue)
    {
        BaseAdditives = new List<StatBonus>();
        BaseValue = baseValue;
        StatName = statName;;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    public int GetCalculatedStatValue()
    {
        FinalValue = BaseValue;
        BaseAdditives.ForEach(x => FinalValue += x.BonusValue);
        return FinalValue;
    }
}
