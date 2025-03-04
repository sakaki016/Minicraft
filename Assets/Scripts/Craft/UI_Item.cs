
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using TMPro;

///*
// * 動くかわからないがおいておく
// */
//public class UI_Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
//{

//    private Canvas canvas;
//    private RectTransform rectTransform;
//    private CanvasGroup canvasGroup;
//    private Image image;
//    private Item item;
//    private TextMeshProUGUI amountText;

//    private void Awake()
//    {
//        rectTransform = GetComponent<RectTransform>();
//        canvasGroup = GetComponent<CanvasGroup>();
//        canvas = GetComponentInParent<Canvas>();
//        image = transform.Find("image").GetComponent<Image>();
//        amountText = transform.Find("amountText").GetComponent<TextMeshProUGUI>();
//    }

//    public void OnBeginDrag(PointerEventData eventData)
//    {
//        canvasGroup.alpha = .5f;
//        canvasGroup.blocksRaycasts = false;
//        UI_ItemDrag.Instance.Show(item);
//    }


//    public void OnEndDrag(PointerEventData eventData)
//    {
//        canvasGroup.alpha = 1f;
//        canvasGroup.blocksRaycasts = true;
//        UI_ItemDrag.Instance.Hide();
//    }

//    public void OnPointerDown(PointerEventData eventData)
//    {
//        if (eventData.button == PointerEventData.InputButton.Right)
//        {
//            // 複数個ある場合はスプリット
//            if (item != null)
//            {
//                // スタック可能アイテムが
//                if (item.IsStackable())
//                {
//                    // 2個～あり、
//                    if (item.amount > 1)
//                    {
//                        // スプリットできる場合
//                        if (item.GetItemHolder().CanAddItem())
//                        {
//                            int splitAmount = Mathf.FloorToInt(item.amount / 2f);
//                            item.amount -= splitAmount;
//                            Item duplicateItem = new Item { itemScriptableObject = item.itemScriptableObject, amount = splitAmount };
//                            item.GetItemHolder().AddItem(duplicateItem);
//                        }
//                    }
//                }
//            }
//        }
//    }

//    public void SetSprite(Sprite sprite)
//    {
//        image.sprite = sprite;
//    }

//    public void SetAmountText(int amount)
//    {
//        if (amount <= 1)
//        {
//            amountText.text = "";
//        }
//        else
//        {
//            amountText.text = amount.ToString();　// 1以上ある場合
//        }
//    }

//    public void Hide()
//    {
//        gameObject.SetActive(false);
//    }

//    public void Show()
//    {
//        gameObject.SetActive(true);
//    }

//    public void SetItem(Item item)
//    {
//        this.item = item;
//        SetSprite(item.GetSprite());
//        SetAmountText(item.amount);
//    }

//    public void OnDrag(PointerEventData eventData)
//    {
//        throw new System.NotImplementedException();
//    }
//}

