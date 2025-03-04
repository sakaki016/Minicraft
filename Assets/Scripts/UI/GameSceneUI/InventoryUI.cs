using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] Transform slotParent; // スロットの親オブジェクト
    [SerializeField] GameObject slotPrefab; // スロットのプレハブ
    private InventoryManager inventory;
    [SerializeField] GameObject backgroundPanel;

    [SerializeField] CameraController cameraController;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerAction playerAction;
    
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
        if (slotParent == null)
        {
            Debug.LogError("slotParent が設定されていません！");
            return;
        }

        // すべてのスロットを取得
        Transform[] slots = slotParent.GetComponentsInChildren<Transform>();

        if (slots.Length < 45)
        {
            Debug.LogError("スロットの数が不足しています！");
            return;
        }

        // すべてのスロットのアイコンと数量をクリア
        for (int i = 0; i < 45; i++)
        {
            Transform slot = slots[i];

            // Slot の子オブジェクトにある ItemImage を取得
            Image itemImage = slot.Find("ItemImage")?.GetComponent<Image>();
            if (itemImage != null)
            {
                itemImage.sprite = null; // アイコンをクリア
                itemImage.enabled = false; // 非表示にする
            }

            // Slot の子オブジェクトにある Number (数量表示) を取得
            TextMeshProUGUI text = slot.Find("Number")?.GetComponent<TextMeshProUGUI>();
            if (text != null)
            {
                text.text = ""; // 数量をクリア
            }
        }

        // アイテムをスロットに反映
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (i >= 45) break; // スロット数を超えたら終了

            Transform slot = slots[i];

            // Slot の子オブジェクトにある ItemImage を取得
            Image itemImage = slot.Find("ItemImage")?.GetComponent<Image>();
            if (itemImage != null)
            {
                itemImage.sprite = inventory.items[i].icon;
                itemImage.enabled = true; // アイコンを表示
            }

            // Slot の子オブジェクトにある Number (数量表示) を取得
            TextMeshProUGUI text = slot.Find("Number")?.GetComponent<TextMeshProUGUI>();
            if (text != null)
            {
                int itemCount = inventory.items[i].count; // アイテムの数を取得
                text.text = (itemCount > 1) ? itemCount.ToString() : ""; // 1個のときは非表示
            }
        }
    }

}