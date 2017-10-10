using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public string ActionName { get; set; }
    public bool IsStatModifier { get; set; }

    public Item(List<BaseStat> _Stats, string _ObjectSlug)
    {
        this.Stats = _Stats;
        this.ObjectSlug = _ObjectSlug;
    }

    public Item(List<BaseStat> _Stats, string _ObjectSlug, string _ItemName, string _Description, string _ActionName, bool _IsStatModifier)
    {
        this.Stats = _Stats;
        this.ObjectSlug = _ObjectSlug;
        this.ItemName = _ItemName;
        this.Description = _Description;
        this.ActionName = _ActionName;
        this.IsStatModifier = _IsStatModifier;

    }

}
