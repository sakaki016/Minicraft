using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] Transform inventorySlotParent; // インベントリスロットの親オブジェクト
    [SerializeField] GameObject inventorySlotPrefab;  // インベントリスロットのプレハブ
    [SerializeField] Transform hotbarParent;          // ホットバーの親オブジェクト
    [SerializeField] GameObject hotbarSlotPrefab;       // ホットバースロットのプレハブ
    private InventoryManager inventory;
    [SerializeField] GameObject backgroundPanel;

    [SerializeField] CameraController cameraController;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerAction playerAction;

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
        UpdateUI();
        // 初期状態でインベントリを非表示にする
        inventoryPanel.SetActive(false);
        backgroundPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // "E" キーで開閉
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        bool isActive = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(isActive);
        backgroundPanel.SetActive(isActive);

        Cursor.visible = isActive;
        Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;

        cameraController.enabled = !isActive;
        playerMovement.enabled = !isActive;
        playerAction.enabled = !isActive;
    }

    public void UpdateUI()
    {
        // インベントリスロットの取得（固定スロット数が maxSlots と同じであることを前提）
        Slot[] inventorySlots = inventorySlotParent.GetComponentsInChildren<Slot>();
        if (inventorySlots.Length < inventory.maxSlots)
        {
            Debug.LogError($"スロットの数が不足しています！現在のスロット数: {inventorySlots.Length}");
            return;
        }

        // 各固定スロットごとにアイテムを反映（空の場合はクリア）
        for (int i = 0; i < inventory.maxSlots; i++)
        {
            if (inventorySlots[i] == null) continue;

            if (inventory.items[i] != null)
            {
                inventorySlots[i].SetItem(inventory.items[i].icon, inventory.items[i].amount);
                inventorySlots[i].SetItem(inventory.items[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }
        }

        // ホットバーの更新（例として、先頭から hotbarSlots 数分の固定スロットに対応）
        Slot[] hotbarSlots = hotbarParent.GetComponentsInChildren<Slot>();
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (i < inventory.maxSlots && inventory.items[i] != null)
            {
                hotbarSlots[i].SetItem(inventory.items[i].icon, inventory.items[i].amount);
                hotbarSlots[i].SetItem(inventory.items[i]);
            }
            else
            {
                hotbarSlots[i].ClearSlot();
            }
        }
    }
}
