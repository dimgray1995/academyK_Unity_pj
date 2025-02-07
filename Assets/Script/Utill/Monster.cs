using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Character : MonoBegaviour{}
//이후 public class Monster : Character 로 상속
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
    
        mData = CSVDataReader.Instance.MonsterDic[monId];//만약 스프라이트가 지속적으로 변경될 경우 전역 변수로 지정

        curHp = mData.MaxHp;
        atkPow = mData.atkPower;
        moveSpeed = mData.moveSpeed;
        
        SpriteRenderer render = GetComponent<SpriteRenderer>();

        //이곳에 필요한 것은
        /*
         * mData에 모델 / 스프라이트 이름이 뭔지 알아두는 것이 필요
         * 접근 방법은?
         * string modelName = mData.modelName; / mData.spriteName;
         * 
         * 실질적으로 값을 바꿀 땐
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
