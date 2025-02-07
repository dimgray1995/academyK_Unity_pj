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

        //if  사인 형태의 타입이라면, 하나의 컴포넌트에서 여러개의 연출을 가진 스크립트를 만들 수 있다.


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
        //이런식으로 진행해도 된다.
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
