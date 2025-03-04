

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ButtonUI.Utils
{

    /*
     * Ç¢ÇÁÇ»Ç¢Ç‡ÇÃÇÕå„Ç≈è¡Ç∑
     * */
    public class Button_UI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        public Action ClickFunc = null;
        public Action MouseRightClickFunc = null;
        public Action MouseMiddleClickFunc = null;
        public Action MouseDownOnceFunc = null;
        public Action MouseUpFunc = null;
        public Action MouseOverOnceTooltipFunc = null;
        public Action MouseOutOnceTooltipFunc = null;
        public Action MouseOverOnceFunc = null;
        public Action MouseOutOnceFunc = null;
        public Action MouseOverFunc = null;
        public Action MouseOverPerSecFunc = null; //Triggers every sec if mouseOver
        public Action MouseUpdate = null;
        public Action<PointerEventData> OnPointerClickFunc;

        public enum HoverBehaviour
        {
            Custom,
            Change_Color,
            Change_Image,
            Change_SetActive,
        }
        public HoverBehaviour hoverBehaviourType = HoverBehaviour.Custom;
        private Action hoverBehaviourFunc_Enter, hoverBehaviourFunc_Exit;

        

        public void OnPointerDown(PointerEventData eventData)
        {
            if (MouseDownOnceFunc != null) MouseDownOnceFunc();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (MouseUpFunc != null) MouseUpFunc();
        }





        public class InterceptActionHandler
        {

            private Action removeInterceptFunc;

            public InterceptActionHandler(Action removeInterceptFunc)
            {
                this.removeInterceptFunc = removeInterceptFunc;
            }
            public void RemoveIntercept()
            {
                removeInterceptFunc();
            }
        }
        public InterceptActionHandler InterceptActionClick(Func<bool> testPassthroughFunc)
        {
            return InterceptAction("ClickFunc", testPassthroughFunc);
        }
        public InterceptActionHandler InterceptAction(string fieldName, Func<bool> testPassthroughFunc)
        {
            return InterceptAction(GetType().GetField(fieldName), testPassthroughFunc);
        }
        public InterceptActionHandler InterceptAction(System.Reflection.FieldInfo fieldInfo, Func<bool> testPassthroughFunc)
        {
            Action backFunc = fieldInfo.GetValue(this) as Action;
            InterceptActionHandler interceptActionHandler = new InterceptActionHandler(() => fieldInfo.SetValue(this, backFunc));
            fieldInfo.SetValue(this, (Action)delegate () {
                if (testPassthroughFunc())
                {
                    // Passthrough
                    interceptActionHandler.RemoveIntercept();
                    backFunc();
                }
            });

            return interceptActionHandler;
        }
    }
}