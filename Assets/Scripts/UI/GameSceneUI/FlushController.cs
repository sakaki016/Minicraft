using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour
{
    public static FlushController instance;
    Image img;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        img = GetComponent<Image>();
        img.color = Color.clear;
    }

    /// <summary>
    /// ダメージ時に表示する赤い点滅
    /// </summary>
    public void RedFlush()
    {
        this.img.color = new Color(0.5f, 0f, 0f, 0.5f);
    }

    /// <summary>
    /// 非ダメージ時は透明にする
    /// </summary>
    public void NoFlush()
    {
        img.color = Color.clear;
    }

}
