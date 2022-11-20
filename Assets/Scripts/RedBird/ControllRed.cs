using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllRed : MonoBehaviour
{
    float speed = 5.0f;
    float maxH = 4.25f;
    float minH = -2.4f;

    void Start()
    {
        
    }

    void Update()
    {
        Moving();
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);

    }

    // function
    void Moving()
    {
        // 앵그리 버드는 상, 하 로만 움직임
        // TODO) 화면 터치 위치에 따라 상하 이동하도록 수정
        if(Input.GetAxis("Vertical") != 0) {
            if(transform.position.y <= minH || transform.position.y >= maxH) {
                return;
            }
            transform.Translate(0, Time.deltaTime * speed * Input.GetAxis("Vertical"), 0);
        }
    }
}
