using UnityEngine;

public class HealthBarHUDTester : MonoBehaviour
{
    public void Heal(int health)
    {
        PlayerStats.instance.Heal(health);
    }

    public void Hurt(int dmg)
    {
        PlayerStats.instance.TakeDamage(dmg);
    }
}
