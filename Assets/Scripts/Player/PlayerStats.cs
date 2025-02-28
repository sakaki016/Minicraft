using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    public static PlayerStats instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField]
    private int health = 50;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int maxTotalHealth;

    public int Health { get { return health; } }
    public int MaxHealth { get { return maxHealth; } }
    //public int MaxTotalHealth { get { return maxTotalHealth; } }

    public void Heal(int health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Health: " + health);
        ClampHealth();
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }
}
