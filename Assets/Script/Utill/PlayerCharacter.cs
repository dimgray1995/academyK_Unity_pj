using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    #region 변수 선언

    TypeClass cData;

    public float curHp;
    public float atkPower;
    public float moveSpeed;

    Rigidbody2D rig;

    #endregion


    private void Awake()
    {
        int charId = CSVDataReader.Instance.ReturnId();
        cData = CSVDataReader.Instance.TypeDic[charId];

        curHp = cData.maxHp;
        atkPower = cData.atkPwr;
        moveSpeed = cData.moveSpeed;

        rig = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rig.velocity = new Vector2(moveSpeed,rig.velocity.y);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rig.velocity = new Vector2(-moveSpeed, rig.velocity.y);
        }
        else
        {
            rig.velocity=new Vector2(0,rig.velocity.y);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rig.velocity = new Vector2(rig.velocity.x, moveSpeed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rig.velocity = new Vector2(rig.velocity.x, -moveSpeed);
        }
        else
        {
            rig.velocity = new Vector2(rig.velocity.x, 0);
        }
    }
}
