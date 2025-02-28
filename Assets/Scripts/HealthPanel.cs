using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    public GameObject[] icons;

    public void Update()
    {
        UpdateLife(PlayerStats.instance.Health);
    }

    public void UpdateLife(int life)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i < life) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }
}
