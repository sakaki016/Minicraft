using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject time;
    float passedTime;

    void Start()
    {
        passedTime = Time.time;
    }

    void Update()
    {
        time.GetComponent<TextMeshProUGUI>().text = "Passed Time: " + passedTime.ToString("F2") + "s";
    }
}
