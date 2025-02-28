using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform slotParent; // スロットの親オブジェクト
    public GameObject slotPrefab; // スロットのプレハブ
    private InventoryManager inventory;
    public GameObject backgroundPanel;

    public CameraController cameraController; 
    public PlayerMovement playerMovement; 
    public PlayerAction playerAction;

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
        UpdateUI();
        // 最初にインベントリを非表示
        inventoryPanel.SetActive(false);
        backgroundPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // "E"キーでインベントリ開閉
        {
            ToggleInventory();
        }
    }
    public void ToggleInventory()
    {
        bool isActive = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(isActive);
        backgroundPanel.SetActive(isActive);

        // カーソルの表示/非表示
        Cursor.visible = isActive;
        Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;

        // カメラとプレイヤーの動きを無効化/有効化
        cameraController.enabled = !isActive;
        playerMovement.enabled = !isActive;
        playerAction.enabled = !isActive;
    }

    public void UpdateUI()
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in inventory.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            slot.GetComponentInChildren<Image>().sprite = item.icon;
        }
    }
}