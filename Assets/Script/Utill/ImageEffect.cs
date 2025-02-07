using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageEffect : MonoBehaviour
{
    Image myImage;
    public float test;
    // Start is called before the first frame update
    private void Start()
    {
        myImage = GetComponent<Image>();

    }

    private void Update()
    {

        //if  ���� ������ Ÿ���̶��, �ϳ��� ������Ʈ���� �������� ������ ���� ��ũ��Ʈ�� ���� �� �ִ�.


        angle += Time.deltaTime * test;
        //angle = Mathf.Sin(angle);
        float alpha = (Mathf.Sin(angle) + 1) / 2f;

        myImage.color = new Color(1,1,1,Mathf.Sin(angle));
        //    if (angle >= 1)
        //    {
        //        angle -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        angle += Time.deltaTime;
        //    }
        //    myImage.color = new Color(1, 1, 1, angle);
        //�̷������� �����ص� �ȴ�.
    }

    float angle = 0;

    IEnumerator Effect()
    {
        while (true)
        {
            if(angle >= 1)
            {
                angle = 0;
            }
            else
            {
                angle += Time.deltaTime;
            }
            myImage.color = new Color(1,1,1,angle);
        }
    }
}
