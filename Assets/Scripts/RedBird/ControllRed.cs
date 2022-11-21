using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllRed : MonoBehaviour
{
    float speed = 0.002f;
    float maxH = 4.25f;
    float minH = -3.5f;
    float startH = 1.0f;

    Vector3 targetPos;

    void Start()
    {
        targetPos = transform. position;
    }

    void Update()
    {
        Moving();
    }

    // void OnCollisionEnter(Collision col)
    // {
    //     Debug.Log(col.gameObject.name);

    // }

    // function
    void Moving()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPos.x = transform.position.x;
            clickPos.z = transform.position.z;
            // Debug.Log(clickPos);
            // Debug.Log(transform.position);
            clickPos.y = (clickPos.y >= maxH) ? maxH : clickPos.y;

            targetPos = clickPos;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, speed);

        if(transform.position.y <= minH) {
            // TODO) 효과
            GameManager.Instance.Heart--;
            GameManager.Instance.SetLifeText();
            targetPos.y = startH;
        }
    }

}
