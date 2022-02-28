using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int _health;
    private int _maxHealth;

    private float timeEndPoison = -1f;
    private float timePoison = 0f;
    private int damagePoison = 0;
    


    public void SetHealth(int maxHealth)
    {
        this._health = maxHealth;
        this._maxHealth = maxHealth;
    }

    private void Update()
    {
        if (Time.time <= timeEndPoison && Mathf.Floor(Time.time) != timePoison)
        {
            Debug.Log("Poison damage: " + damagePoison);
            timePoison = Mathf.Floor(Time.time);
            Damage(damagePoison);
        }
    }

    public void Poisoning(float timePoison, int damage)
    {
        timeEndPoison = timePoison;
        damagePoison = damage;
    }
    
    public int GetHealth()
    {
        return _health;
    }

    public void Damage(int damageAmount)
    {
        _health -= damageAmount;
        if (_health < 0)
        {
            _health = 0;
            Die();
        } else if (_health == 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        _health += healAmount;
        Debug.Log("Healing on " + healAmount + " HP. Now health: " + _health);
        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    public void Die()
    {
        if (transform.GetComponent<PlayerController>() != null)
            Debug.Log("Player die");
        else
            Debug.Log("Enemy die");
    }

    public float GetHealthPercent()
    {
        return (float)_health/_maxHealth;
    }

}
