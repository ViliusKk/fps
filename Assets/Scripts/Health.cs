using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public UnityEvent onDamage;
    public UnityEvent onDeath;

    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onDamage.Invoke();

        if (currentHealth <= 0)
        {
            onDeath.Invoke();
            Destroy(this);
        }
    }
}
