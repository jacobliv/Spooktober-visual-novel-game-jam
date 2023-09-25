using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChangeOnHover : MonoBehaviour , IPointerEnterHandler,IPointerExitHandler, IPointerMoveHandler{
    public  Texture2D     pointer;
    public  Texture2D     arrow;
    private RectTransform rectTransform;
    private static bool          isPointer;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();
    }
    
    
    // private bool IsCursorInsideRectTransform() {
    //     // Check if the cursor is over any UI element
    //     if (EventSystem.current.IsPointerOverGameObject())
    //     {
    //         // Convert the cursor position to a screen point
    //         Vector2 screenPoint = Input.mousePosition;
    //
    //         // Check if the screen point is inside the RectTransform
    //         return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPoint, Camera.main);
    //     }
    //
    //     return false;
    // }
    // private void OnDisable() {
    //     Cursor.SetCursor(arrow,Vector2.zero,CursorMode.ForceSoftware);
    //     isPointer = false;
    // }
    //
    public void OnPointerEnter(PointerEventData eventData) {
    //     Cursor.SetCursor(pointer,new Vector2(pointer.width/3f,0),CursorMode.ForceSoftware);
    //     isPointer = true;
    }
    //
    public void OnPointerExit(PointerEventData eventData) {
    //     Cursor.SetCursor(arrow,Vector2.zero,CursorMode.ForceSoftware);
    //
    }
    //
    public void OnPointerMove(PointerEventData eventData) {
    //     Cursor.SetCursor(pointer,new Vector2(pointer.width/3f,0),CursorMode.ForceSoftware);
    }
}
