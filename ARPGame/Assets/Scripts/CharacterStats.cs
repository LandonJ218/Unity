using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public List<BaseStat> stats = new List<BaseStat>();

    void Start()
    {
        stats.Add(new BaseStat("INT", 0));
        stats.Add(new BaseStat("DEX", 0));
        stats.Add(new BaseStat("STR", 0));

        LogStats();
    }

    public void AddStatBonuses(List<BaseStat> statsToModify)
    {
        foreach(BaseStat stat in statsToModify)
        {
            stats.Find(x => x.StatName == stat.StatName).AddStatBonus(new StatBonus(stat.BaseValue));
        }
        LogStats();
    }

    public void RemoveStatBonuses(List<BaseStat> statsToModify)
    {
        foreach (BaseStat stat in statsToModify)
        {
            stats.Find(x=> x.StatName == stat.StatName).RemoveStatBonus(new StatBonus(stat.BaseValue));
        }
        LogStats();
    }

    public void LogStats()
    {
        Debug.Log(gameObject + " stats:");
        foreach (BaseStat stat in stats)
        {
            Debug.Log(stat.StatName + "  " + stat.GetCalculatedStatValue());
        }
    }
}
