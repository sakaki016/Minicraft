using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    [SerializeField] GameObject[] icons;

    public void Update()
    {
        UpdateLife(PlayerStats.instance.Health);
    }

    /// <summary>
    /// ライフ表示を更新
    /// </summary>
    /// <param name="life">現在のライフ</param>
    public void UpdateLife(int life)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i < life) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }
}
