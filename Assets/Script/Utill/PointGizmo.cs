using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGizmo : MonoBehaviour
{

    private void OnDrawGizmos()
    {
        //���� ��ġ ������ �˱����� ���
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,0.5f);
        
    }

}
