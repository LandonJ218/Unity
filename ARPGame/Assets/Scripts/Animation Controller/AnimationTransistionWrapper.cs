using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationTransistionWrapper{
    public List<AnimationTransistion> AnimationTransistions;

    public AnimationTransistionWrapper()
    {
        AnimationTransistions = new List<AnimationTransistion>();
    }
}