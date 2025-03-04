
using UnityEngine;
using UnityEngine.UI;

public class CraftButtonController : MonoBehaviour
{
    [SerializeField] Button rockButton;
    [SerializeField] Button woodButton;
    [SerializeField] GameObject stick;
    [SerializeField] GameObject pickAxe;
    [SerializeField] GameObject sword;

    private Button _button;


    public void Start()
    {
        _button = GetComponent<Button>();
        Init();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("èâä˙âª");
            Init();
        }
    }

    public void Init()
    {
        stick.gameObject.SetActive(false);
        pickAxe.gameObject.SetActive(false);
        sword.gameObject.SetActive(false);
        rockButton.gameObject.SetActive(true);
        woodButton.gameObject.SetActive(true);
    }

    public void OnClick()
    {
        Debug.Log("Ç®Ç≥ÇÍÇΩÇÊ");
        rockButton.gameObject.SetActive(false);
        woodButton.gameObject.SetActive(false);
        if (_button.tag == "RockButton")
        {
            pickAxe.gameObject.SetActive(true);
            sword.gameObject.SetActive(true);

        }
        else if (_button.tag == "WoodButton")
        {
            stick.gameObject.SetActive(true);
            pickAxe.gameObject.SetActive(true);
            sword.gameObject.SetActive(true);
        }
    }



}
