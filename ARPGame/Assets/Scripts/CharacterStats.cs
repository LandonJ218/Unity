using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public List<BaseStat> stats = new List<BaseStat>();

    void Start()
    {
        stats.Add(new BaseStat(4, "Power", "Your power level."));
        stats[0].AddStatBonus(new StatBonus(5));
        Debug.Log(stats[0].GetCalculatedStatValue());
    }

    public void AddStatBonuses(List<BaseStat> statsToModify)
    {
        foreach(BaseStat stat in statsToModify)
        {
            stats.Find(x => x.StatName == stat.StatName).AddStatBonus(new StatBonus(stat.BaseValue));
        }
    }

    public void RemoveStatBonuses(List<BaseStat> statsToModify)
    {
        foreach (BaseStat stat in statsToModify)
        {
            stats.Find(x=> x.StatName == stat.StatName).RemoveStatBonus(new StatBonus(stat.BaseValue));
        }
    }
}
