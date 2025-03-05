using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public Transform hotbarParent; // ホットバーの親オブジェクト
    public Image selectionCursor; // カーソル用の Image
    public int selectedSlotIndex = 0; // 選択中のスロット（最初は 0）

    private Slot[] hotbarSlots;

    void Start()
    {
        // ホットバーのスロットを取得
        hotbarSlots = hotbarParent.GetComponentsInChildren<Slot>();

        // 初期位置にカーソルをセット
        UpdateCursorPosition();
    }

    void Update()
    {
        // 1〜9キーでスロットを選択
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                selectedSlotIndex = i;
                UpdateCursorPosition();
            }
        }

        // マウスホイールで切り替え
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f) SelectNextSlot();
        else if (scroll < 0f) SelectPreviousSlot();
    }

    void SelectNextSlot()
    {
        selectedSlotIndex = (selectedSlotIndex + 1) % hotbarSlots.Length;
        UpdateCursorPosition();
    }

    void SelectPreviousSlot()
    {
        selectedSlotIndex = (selectedSlotIndex - 1 + hotbarSlots.Length) % hotbarSlots.Length;
        UpdateCursorPosition();
    }

    void UpdateCursorPosition()
    {
        if (hotbarSlots.Length == 0) return;

        // 選択中のスロットの位置にカーソルを移動
        selectionCursor.transform.position = hotbarSlots[selectedSlotIndex].transform.position;
    }
    public Item GetSelectedItem()
    {
        Debug.Log("選択スロット: " + selectedSlotIndex);
        if (selectedSlotIndex >= 0 && selectedSlotIndex < hotbarSlots.Length)
        {
            Item selectedItem = hotbarSlots[selectedSlotIndex].GetItem();
            Debug.Log("取得アイテム: " + (selectedItem != null ? selectedItem.itemName : "null"));
            return selectedItem;
        }
        return null;
    }
}
