using UnityEngine;
using UnityEngine.UI;
public class HP : MonoBehaviour {
    public int currentHealth;
    public Slider hpbar;

    private void Start()
    {
        currentHealth = 100;
        hpbar.maxValue = 100;
        hpbar.value = 100;
    }
    public void Damage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth < 0)
            currentHealth = 0;
        hpbar.value = currentHealth;
    }
    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > 100)
            currentHealth = 100;
        hpbar.value = currentHealth;
    }
    public bool IsDead()
    {
        return currentHealth == 0;
    }
}
