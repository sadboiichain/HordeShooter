using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Values")]//for editor clarity
    public float currentHealth;
    public float maxHealth;
    [SerializeField] private float initialHealth;//private but visible in editor
    [Header("Events")]
    public UnityEvent onTakeDamage;
    public UnityEvent onHeal;
    public UnityEvent onDeath;

    //on start
    public void Start()
    {
        //set health to max
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        //subtract from current health
        currentHealth -= damage;
        //clamp damage to ensure it doesnt go over/under max
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //trigger the unity event for external function
        onTakeDamage.Invoke();
        //if health is less than 0,die
        if(currentHealth <= 0)
        {
            Die();
        }


        ///debug text for damage
        Debug.Log(gameObject.name +" took " +  damage + " damage!");
    }

    public void HealDamage(float damage)
    {
        //add current health
        currentHealth += damage;
        //clamp to max health
        currentHealth = Mathf.Clamp(currentHealth,0, maxHealth);
        //event functionality
        onHeal.Invoke();
    }

    public void healToFull()
    {
        //set health to max
        currentHealth = maxHealth;
    }

    public void Die()
    {
        //kill player
        currentHealth = 0;

        //do anything event based
        onDeath.Invoke();
    }

    public float healthPercent()
    {
        return currentHealth / maxHealth;
    }

}
