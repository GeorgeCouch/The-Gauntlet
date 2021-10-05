using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Powerup
{
    public float speedModifier;
    public float healthModifier;
    public float maxHealthModifier;
    public float fireRateModifier;
    public float duration;
    public bool isPermanent;

    public void OnActivate(TankData target)
    {
        target.forwardSpeed += speedModifier;
        target.MaxHealth += healthModifier;
        // Reset to CurrentMax Health if Health is greater
        if (target.MaxHealth > target.CurrentMaxHealth)
        {
            target.MaxHealth = target.CurrentMaxHealth;
        }
        target.CurrentMaxHealth += maxHealthModifier;
        target.ShootDelay += fireRateModifier;
    }

    public void OnDeactivate(TankData target)
    {
        target.forwardSpeed -= speedModifier;
        target.MaxHealth -= healthModifier;
        target.CurrentMaxHealth -= maxHealthModifier;
        target.ShootDelay -= fireRateModifier;
    }

}
