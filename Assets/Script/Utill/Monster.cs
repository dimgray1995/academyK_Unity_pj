using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Character : MonoBegaviour{}
//���� public class Monster : Character �� ���
public class Monster : MonoBehaviour
{

    #region

    public int monId;
    MonsterClass mData;

    float curHp;
    float atkPow;
    float moveSpeed;

    PlayerCharacter target;

    #endregion

    public void DataSetting()
    {
    
        mData = CSVDataReader.Instance.MonsterDic[monId];//���� ��������Ʈ�� ���������� ����� ��� ���� ������ ����

        curHp = mData.MaxHp;
        atkPow = mData.atkPower;
        moveSpeed = mData.moveSpeed;
        
        SpriteRenderer render = GetComponent<SpriteRenderer>();

        //�̰��� �ʿ��� ����
        /*
         * mData�� �� / ��������Ʈ �̸��� ���� �˾Ƶδ� ���� �ʿ�
         * ���� �����?
         * string modelName = mData.modelName; / mData.spriteName;
         * 
         * ���������� ���� �ٲ� ��
         * render.sprite = CSVDatareader.Instance.spriteData[modelName];
         *
         */

        render.sprite = CSVDataReader.Instance.spriteData["E71"];
        gameObject.SetActive(true);

        target = FindObjectOfType<PlayerCharacter>();

    }

  
    void Update()
    {
        
        Vector3 targetPos = target.gameObject.transform.position;
        Vector3 myPos = transform.position;

        Vector3 moveVector = Vector3.Normalize(targetPos - myPos);

        transform.position = myPos + moveVector * Time.deltaTime;

    }
}
