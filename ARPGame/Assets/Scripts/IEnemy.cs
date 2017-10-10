using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void PerformAttack();
    void TakeDamage(int amount);
}
