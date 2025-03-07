using UnityEngine;

public class ItemAssets : MonoBehaviour
{

    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public Transform pfItemWorld;

    public Sprite s_Wood;
    public Sprite s_Rock;
    public Sprite s_Stick;
    public Sprite s_Sword_Wood;
    public Sprite s_Sword_Rock;
    public Sprite s_Ax_Wood;
    public Sprite s_Ax_Rock;
    public Sprite s_PickeAx_Wood;
    public Sprite s_PickeAx_Rock;
    public Sprite s_Shovel_Wood;
    public Sprite s_Shovel_Rock;
}
