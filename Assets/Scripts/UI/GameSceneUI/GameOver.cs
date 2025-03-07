using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject time;
    private float _passedTime;

    void Start()
    {
        _passedTime = Time.time;
    }

    void Update()
    {
        time.GetComponent<TextMeshProUGUI>().text = "Passed Time: " + _passedTime.ToString("F2") + "s";
    }
}
