using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositionGet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ターゲットの座標を取得
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                Debug.Log(hit.collider.gameObject.transform.position);
            }
        }
    }
}
