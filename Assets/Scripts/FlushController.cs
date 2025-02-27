using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour
{
    public static FlushController instance;
    Image img;


    void Start()
    {
        img = GetComponent<Image>();
        img.color = Color.clear;
    }

    public void RedFlush()
    {
        this.img.color = new Color(0.5f, 0f, 0f, 0.5f);
    }

    public void NoFlush()
    {
        img.color = Color.clear;
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
