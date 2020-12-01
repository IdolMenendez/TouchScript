using System.Collections;
using System.Collections.Generic;
using TouchScript;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Transform _target;
    void Start()
    {
        TouchManager.Instance.PointersAdded += pointersAddedHandler;
        TouchManager.Instance.PointersPressed += pointersPressHandler;

        TouchManager.Instance.PointersReleased += pointersReleasedHandler;
        TouchManager.Instance.PointersUpdated += pointesUpdateHandler;
    }

    private void pointesUpdateHandler(object sender, PointerEventArgs e)
    {
        var count = e.Pointers.Count;
        if (e.Pointers.Count > 0)
        {
            var point = e.Pointers[0];
            if (this._target != null)
            {
                print(point.Position);
                var pos = point.Position;
                Vector3 worldPos;
                var canvas = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
                RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas,pos,Camera.main,out worldPos);
                this._target.position = worldPos;
            }
        }

    }
    private void pointersReleasedHandler(object sender, PointerEventArgs e)
    {
        this._target = null;

    }
    private void pointersPressHandler(object sender, PointerEventArgs e)
    {
        var count = e.Pointers.Count;
        if (e.Pointers.Count > 0)
        {
            var point = e.Pointers[0];
            var data = point.GetOverData();
            if (data.Target)
            {
                this._target = data.Target;
            }
        }
    }
    
    private void pointersAddedHandler(object sender, PointerEventArgs e)
    {
        var count = e.Pointers.Count;
    }
}

