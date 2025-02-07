using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGizmo : MonoBehaviour
{

    private void OnDrawGizmos()
    {
        //나의 위치 정보를 알기위해 사용
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,0.5f);
        
    }

}
