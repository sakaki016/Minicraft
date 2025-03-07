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

        // スロットを取得（slotParent の直接の子にある Slot スクリプトがアタッチされたオブジェクトのみ）
        Slot[] slots = slotParent.GetComponentsInChildren<Slot>();

        if (slots.Length < 45)
        {
            Debug.LogError($"スロットの数が不足しています！現在のスロット数: {slots.Length}");
            return;
        }

        // すべてのスロットのアイコンと数量をクリア
        for (int i = 0; i < slots.Length; i++)
        {
            Image itemImage = slots[i].transform.Find("ItemImage")?.GetComponent<Image>();
            TextMeshProUGUI text = slots[i].transform.Find("Number")?.GetComponent<TextMeshProUGUI>();

            if (itemImage != null)
            {
                itemImage.sprite = null;
                itemImage.gameObject.SetActive(false); // ここで非アクティブにする
            }

            if (text != null)
            {
                text.text = "";
            }
        }

        // アイテムをスロットに反映
        for (int i = 0; i < Mathf.Min(inventory.items.Count, slots.Length); i++)
        {
            Item item = inventory.items[i]; // 追加するアイテム
            if (item == null) continue; // 念のため

            Image itemImage = slots[i].transform.Find("ItemImage")?.GetComponent<Image>();
            TextMeshProUGUI text = slots[i].transform.Find("Number")?.GetComponent<TextMeshProUGUI>();
            if (text == null)
            {
                Debug.LogError("スロット " + i + " の Number が見つかりません！");
                continue;
            }
            if (itemImage != null)
            {
                itemImage.sprite = item.icon;
                itemImage.gameObject.SetActive(true); // アイテムがある場合は表示
            }

            if (text != null)
            {
                int itemCount = inventory.items[i].amount;
                Debug.Log("スロット " + i + " のアイテム数: " + itemCount);

                text.text = (itemCount > 1) ? itemCount.ToString() : ""; // 1個のときは非表示
            }
        }
    }

}