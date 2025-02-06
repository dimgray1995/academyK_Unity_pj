using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI classNameText;
    public TextMeshProUGUI maxHpText;
    public TextMeshProUGUI atkPwrText;
    public TextMeshProUGUI criPrbText;
    public TextMeshProUGUI criDmgText;
    public TextMeshProUGUI hpRcvText;
    public TextMeshProUGUI cdnPctText;
    public TextMeshProUGUI gotDmgText;
    public TextMeshProUGUI moveSpeedText;
    public GameObject[] skills;
    public Image _image;
    public Sprite sprite;


    

    // Start is called before the first frame update

    //public TextMeshProUGUI[] skills;
    //public GameObject[] skills; //한 번에 csv 파일 넣기
    void Start()
    {
        
        //CSVDataReader.Instance. 싱글톤의 경우 직접 접근할 수 있다.

        //string warnig = CSVDataReader.Instance.ExpDic[28].ToString();
        //Debug.LogWarning(CSVDataReader.Instance.ExpDic[28].ToString());
        //Debug.Log(warnig); //변수 제작 후 출력
        //CSVDataReader.Instance.InGame;


        //int charId = CSVDataReader.Instance.curCharID;
        int charId = CSVDataReader.Instance.ReturnId();
        
        //pt = CSVDataReader.Instance.ImageDic[charId].image;
        //_image.sprite = Resources.Load(CSVDataReader.Instance.ImageDic[charId].image)as Sprite;
        //_image.sprite = pt.Split;
        ResetUI(charId);
        //GameObject.Find("Image").GetComponent<Image>().sprite = sprite;



    }


    public void GoBattle()
    {
        CSVDataReader.Instance.MoveScene(sceneName.InGameSc);
    }

    void ResetUI(int id)
    {
        int charId = CSVDataReader.Instance.ReturnId();
        string className = CSVDataReader.Instance.TypeDic[id].className;
        classNameText.text = className;

        maxHpText.text = CSVDataReader.Instance.TypeDic[id].maxHp.ToString();
        atkPwrText.text = CSVDataReader.Instance.TypeDic[id].atkPwr.ToString();
        criPrbText.text = CSVDataReader.Instance.TypeDic[id].criPrb.ToString();
        criDmgText.text = CSVDataReader.Instance.TypeDic[id].criDmg.ToString();
        hpRcvText.text = CSVDataReader.Instance.TypeDic[id].hpRcv.ToString();
        cdnPctText.text = CSVDataReader.Instance.TypeDic[id].cdnPct.ToString();
        gotDmgText.text = CSVDataReader.Instance.TypeDic[id].gotDmg.ToString();
        moveSpeedText.text = CSVDataReader.Instance.TypeDic[id].moveSpeed.ToString();
        //_image.sprite = Resources.Load(CSVDataReader.Instance.ImageDic[charId].image, typeof(Sprite)) as Sprite;
        Sprite a = Resources.Load<Sprite>("ch_01");
        _image.sprite = a;
        //GameObject.Find("Image").GetComponent<Image>().sprite = a;

        foreach (GameObject item in skills)
        {
            item.SetActive(false);
        }

        int len = 0;

        if (CSVDataReader.Instance.TypeDic[id].skill_01 != -1)
        {

            int skillId = CSVDataReader.Instance.TypeDic[id].skill_01;
            string skillName = CSVDataReader.Instance.SkillDic[skillId].skillName;
            TextMeshProUGUI _text = skills[len].transform.GetChild(1).GetComponent<TextMeshProUGUI>(); //GetChild(1)로 엠티 그룹 안에 있는 제목, 값입력 되는 곳을 가지고 온다, 즉 , 0 --> 1 번째 순서, 그러니texttmp(1)을 가지고 오는 것
            _text.text = skillName;
            skills[len].SetActive(true);
            len++;
        }
        if (CSVDataReader.Instance.TypeDic[id].skill_02 != -1)
        {

            int skillId = CSVDataReader.Instance.TypeDic[id].skill_02;
            string skillName = CSVDataReader.Instance.SkillDic[skillId].skillName;
            TextMeshProUGUI _text = skills[len].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _text.text = skillName;
            skills[len].SetActive(true);
            len++;
        }
        if (CSVDataReader.Instance.TypeDic[id].skill_03 != -1)
        {

            int skillId = CSVDataReader.Instance.TypeDic[id].skill_03;
            string skillName = CSVDataReader.Instance.SkillDic[skillId].skillName;
            TextMeshProUGUI _text = skills[len].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _text.text = skillName;
            skills[len].SetActive(true);
            len++;
        }
        if (CSVDataReader.Instance.TypeDic[id].skill_04 != -1)
        {

            int skillId = CSVDataReader.Instance.TypeDic[id].skill_04;
            string skillName = CSVDataReader.Instance.SkillDic[skillId].skillName;
            TextMeshProUGUI _text = skills[len].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _text.text = skillName;
            skills[len].SetActive(true);
            len++;
        }
        if (CSVDataReader.Instance.TypeDic[id].skill_05 != -1)
        {

            int skillId = CSVDataReader.Instance.TypeDic[id].skill_05;
            string skillName = CSVDataReader.Instance.SkillDic[skillId].skillName;
            TextMeshProUGUI _text = skills[len].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _text.text = skillName;
            skills[len].SetActive(true);
            len++;
        }
        if (CSVDataReader.Instance.TypeDic[id].skill_06 != -1)
        {

            int skillId = CSVDataReader.Instance.TypeDic[id].skill_06;
            string skillName = CSVDataReader.Instance.SkillDic[skillId].skillName;
            TextMeshProUGUI _text = skills[len].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _text.text = skillName;
            skills[len].SetActive(true);
            len++;
        }
        if (CSVDataReader.Instance.TypeDic[id].skill_07 != -1)
        {

            int skillId = CSVDataReader.Instance.TypeDic[id].skill_07;
            string skillName = CSVDataReader.Instance.SkillDic[skillId].skillName;
            TextMeshProUGUI _text = skills[len].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _text.text = skillName;
            skills[len].SetActive(true);
            len++;
        }
        if (CSVDataReader.Instance.TypeDic[id].skill_08 != -1)
        {

            int skillId = CSVDataReader.Instance.TypeDic[id].skill_08;
            string skillName = CSVDataReader.Instance.SkillDic[skillId].skillName;
            TextMeshProUGUI _text = skills[len].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _text.text = skillName;
            skills[len].SetActive(true);
            len++;
        }
    }

    public void LRBtn(bool isLeftButton)
    {
        int charId = CSVDataReader.Instance.ReturnId(isLeftButton);
        ResetUI(charId);
    }

}
