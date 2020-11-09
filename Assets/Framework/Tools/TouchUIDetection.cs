using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public static class TouchUIDetection
{
    public static bool IsPointerOverGameObject()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            pressPosition = Input.mousePosition,
            position = Input.mousePosition
        };

        List<RaycastResult> list = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, list);
        return list.Count > 0;
        // }
    }
    //方法二 通过UI事件发射射线
    //是 2D UI 的位置，非 3D 位置
    public static bool IsPointerOverGameObject(Vector2 screenPosition)
    {
        //实例化点击事件
        PointerEventData eventDataCurrentPosition = new PointerEventData(UnityEngine.EventSystems.EventSystem.current)
        {
            //将点击位置的屏幕坐标赋值给点击事件
            position = new Vector2(screenPosition.x, screenPosition.y)
        };

        List<RaycastResult> results = new List<RaycastResult>();
        //向点击处发射射线
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
    //方法三 通过画布上的 GraphicRaycaster 组件发射射线
    public static bool IsPointerOverGameObject(Canvas canvas, Vector2 screenPosition)
    {
        //实例化点击事件
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            //将点击位置的屏幕坐标赋值给点击事件
            position = screenPosition
        };
        //获取画布上的 GraphicRaycaster 组件
        GraphicRaycaster uiRaycaster = canvas.gameObject.GetComponent<GraphicRaycaster>();

        List<RaycastResult> results = new List<RaycastResult>();
        // GraphicRaycaster 发射射线
        uiRaycaster.Raycast(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}
