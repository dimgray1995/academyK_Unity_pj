using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*public class CSVDataReader : MonoBehaviour
{
    [SerializeField] TextAsset csvTableFile; //���̺� �ֱ�
    [SerializeField] string csvTablePath; //���̺� ��ġ�� ���� �� �ֱ�

    public Dictionary<int, TestClass> testDic = new Dictionary<int, TestClass>();

    // Start is called before the first frame update
    void Start()
    {

        TestClassData();


    }

    void TestClassData()
    {

        List<Dictionary<string, object>> data = CSVReader.Read(csvTableFile); //csv�����⸦ ���� ��Ƶд�.

        for (int i = 0; i < data.Count; i++)
        {
            int id = int.Parse(data[i]["id"].ToString());
            TestClass tClass = new TestClass();

            tClass.id = id;
            tClass.Speed = float.Parse(data[i]["speed"].ToString());
            tClass.MaxHp = float.Parse(data[i]["MaxHp"].ToString());
            tClass.rotationSpeed = float.Parse(data[i]["rotationSpeed"].ToString());
            //data[i]["��Ʈ�� Į��"].ToString();

            
            testDic.Add(id, tClass);

        }

    }


}

public class TestClass
{
    public int id;
    public float Speed;
    public float MaxHp;
    public float rotationSpeed;

}*/

public enum sceneName//enum�� ���� �� ����
{
    InGameSc,
    MainDisplaySc,
    SeletCHSc,
}

public class CSVDataReader : SingleTon<CSVDataReader>
{
    //public const string InGame = "InGame";//�̷������� ���� ������ �� �ִ�.



    #region SerializeField �Է¹޴� ����
    //[SerializeField] TextAsset csvTableFile;
    [SerializeField] TextAsset csvClassTableFile;
    [SerializeField] TextAsset csvEffectTableFile;
    [SerializeField] TextAsset csvExpTableFile;
    [SerializeField] TextAsset csvLvStUpTableFile;
    [SerializeField] TextAsset csvMonsterTableFile;
    [SerializeField] TextAsset csvProjectileTableFile;
    [SerializeField] TextAsset csvRiskTableFile;
    [SerializeField] TextAsset csvSkillTableFile;
    [SerializeField] TextAsset csvSpawnTableFile;
    [SerializeField] TextAsset csvStageTableFile;
    [SerializeField] TextAsset csvStUpTableFile;
    [SerializeField] TextAsset csvWaveTableFile;
    [SerializeField] TextAsset csvImageFile;
    #endregion


    #region ��ųʸ� <id, Ŭ����> ������ ���� ����
    public Dictionary<int, TypeClass> TypeDic = new Dictionary<int, TypeClass>();
    public Dictionary<int, ExpClass> ExpDic = new Dictionary<int, ExpClass>();
    public Dictionary<int, LvStUpClass> LvStUpDic = new Dictionary<int, LvStUpClass>();
    public Dictionary<int, MonsterClass> MonsterDic = new Dictionary<int, MonsterClass>();
    public Dictionary<int, ProjectileClass> ProjectileDic = new Dictionary<int, ProjectileClass>();
    public Dictionary<int, RiskClass> RiskDic = new Dictionary<int, RiskClass>();
    public Dictionary<int, SkillClass> SkillDic = new Dictionary<int, SkillClass>();
    public Dictionary<int, SpawnClass> SpawnDic = new Dictionary<int, SpawnClass>();
    public Dictionary<int, StageClass> stageDic = new Dictionary<int, StageClass>();
    public Dictionary<int, StUPClass> StUpDic = new Dictionary<int, StUPClass>();
    public Dictionary<int, WaveClass> WaveDic = new Dictionary<int, WaveClass>();
    public Dictionary<int, Sprite> ImageDic = new Dictionary<int, Sprite>();
    #endregion


    // int curCharID = PlayerPrefs.GetInt("SelectCharID",1);
    int curCharID;


    void Start()
    {
        curCharID = PlayerPrefs.GetInt("CharId", 1);
        //curCharID = PlayerPrefs.GetInt("SelectCharId");
        //Debug.Log(curCharID);
        TypeDataRoad();
        ExpDataRoad();
        LvStUpDataRoad();
        MonsterDataRoad();
        ProjectileDataRoad();
        RiskDataRoad();
        SkillDataRoad();
        SpawnDataRoad();
        StageDataRoad();
        StUPDataRoad();
        WaveDataRoad();
        //for (int i = 0; i < 10; i++) {
        //    Debug.Log(ExpDic[i].curExp.ToString());
        //Debug.Log�� ��� ���� �������� �Ѵٸ�
        //int a = ��ųʸ� ���� ����[i].���ϴ� ���̺��� �ε��ϴ� �޼ҵ忡 parse�� �ִ� ������.tostring���� ����.
        //   }

        //���⿡ �������� �̵��ض� �κ�

        //SceneManager.LoadScene(InGame);
        //MoveScene(InGame);
        // �̰� �ȵ� MoveScene(CSVDataReader.Instance.���̸�)

        //Invoke("Test",3f);//�ش� �Լ��� �Լ� ���� �� �����ð��� ���� �� �ִ�.
        //MoveScene(sceneName.InGameSc);

        //PlayerPrefs.SetInt("SelectCharID", 4);

        //curCharID = PlayerPrefs.GetInt("SelectCharID", 1);

        //�÷��� ������ ������ �� �ִ� ��Ʈ���� ���� ������ �ҷ��� �� �ִ�.

        MoveScene(sceneName.InGameSc);
        

        //PlayerPrefs.DeleteAll();
    }
    public int ReturnId()
    {
        return curCharID;
    }

    public int ReturnId(bool isLeft)
    {
        int _id = curCharID;

        int dataCnt = TypeDic.Count;

        if (isLeft)
        {
            _id--; // 1>���� �� ó�� ���س�
            //����(������ -1)
            //PlayerPrefs.SetInt("CharId", 0);//�� ���ڿ��� ������ ��
        }
        else
        {
            _id++;// 4 < Ŭ�� ó�� ����
           // PlayerPrefs.SetInt("CharId", 0);
        }

        if(_id == dataCnt+1)
        {
            _id = 1;
        }
        else if(_id == 0)
        {
            _id = 4;
        }


        PlayerPrefs.SetInt("ChartId",_id);
        curCharID = _id;
        return curCharID;
    } 

    IEnumerator ChangeScene(string _scene)
    {
        while (true)
        {
            yield return null;
            //yield return new WaitUntil; //���ҽ� üũ, ��Ʈ��ũ üũ�� ������ ����
            break;
        }
        //yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(_scene);
    }

    public void MoveScene(sceneName sceneName)
    {
        string scene = "";
        //SceneManager.LoadScene(sceneName);//enum ���� ��� �Ұ�
        switch (sceneName)
        {
            case sceneName.InGameSc:
                scene = "02_InGame";
                //SceneManager.LoadScene("02_InGame");
                break;
            case sceneName.MainDisplaySc:
                scene = "00_MainDisplay";
                //SceneManager.LoadScene("00_MainDisplay");
                break;
            case sceneName.SeletCHSc:
                scene = "01_SeletCh";
                //SceneManager.LoadScene("01_SeletCh");
                break;
        }
        IEnumerator _ChangeScene = ChangeScene(scene);
        StartCoroutine(_ChangeScene);
        StopCoroutine(_ChangeScene);
        //StartCoroutine(ChangeScene(scene));
        //StopCoroutine(ChangeScene(scene));
    }

    //void ImageCh()
    //{
    //    List<Dictionary<string, object>> ChList = CSVReader.Read(csvImageFile);

    //    for (int i = 0; i < ChList.Count; i++) { 

    //    }
    //}

    void TypeDataRoad()
    {
        List<Dictionary<string, object>> typeList = CSVReader.Read(csvClassTableFile);

        for (int i = 0; i < typeList.Count; i++)
        {
            TypeClass typeData = new TypeClass();
            int id = int.Parse(typeList[i]["id"].ToString());
            typeData.className = typeList[i]["className"].ToString();
            typeData.maxHp = float.Parse(typeList[i]["maxHp"].ToString());
            typeData.atkPwr = float.Parse(typeList[i]["atkPwr"].ToString());
            typeData.criPrb = float.Parse(typeList[i]["criPrb"].ToString());
            typeData.criDmg = float.Parse(typeList[i]["criDmg"].ToString());
            typeData.hpRcv = float.Parse(typeList[i]["hpRcv"].ToString());
            typeData.cdnPct = float.Parse(typeList[i]["cdnPct"].ToString());
            typeData.gotDmg = float.Parse(typeList[i]["gotDmg"].ToString());
            typeData.moveSpeed = float.Parse(typeList[i]["moveSpeed"].ToString());
            typeData.skill_01 = int.Parse(typeList[i]["skill_01"].ToString());
            typeData.skill_02 = int.Parse(typeList[i]["skill_02"].ToString());
            typeData.skill_03 = int.Parse(typeList[i]["skill_03"].ToString());
            typeData.skill_04 = int.Parse(typeList[i]["skill_04"].ToString());
            typeData.skill_05 = int.Parse(typeList[i]["skill_05"].ToString());
            typeData.skill_06 = int.Parse(typeList[i]["skill_06"].ToString());
            typeData.skill_07 = int.Parse(typeList[i]["skill_07"].ToString());
            typeData.skill_08 = int.Parse(typeList[i]["skill_08"].ToString());

            TypeDic.Add(id, typeData);
        }
    }
    void ExpDataRoad()
    {
        List<Dictionary<string, object>> expList = CSVReader.Read(csvExpTableFile);

        for (int i = 0; i < expList.Count; i++)
        {
            ExpClass expData = new ExpClass();
            int id = int.Parse(expList[i]["lv"].ToString());
            expData.curExp = int.Parse(expList[i]["curExp"].ToString());

            ExpDic.Add(id, expData); ;
        }
    }
    void MonsterDataRoad()
    {
        List<Dictionary<string, object>> monList = CSVReader.Read(csvMonsterTableFile);

        for (int i = 0; i < monList.Count; i++)
        {
            MonsterClass monsterData = new MonsterClass();
            int id = int.Parse(monList[i]["id"].ToString());
            monsterData.name = monList[i]["name"].ToString();
            monsterData.monType = int.Parse(monList[i]["monType"].ToString());
            monsterData.projectile_01 = int.Parse(monList[i]["projectile_01"].ToString());
            monsterData.projectile_02 = int.Parse(monList[i]["projectile_02"].ToString());
            monsterData.giveWon = float.Parse(monList[i]["giveWon"].ToString());
            monsterData.giveExp = float.Parse(monList[i]["giveExp"].ToString());
            monsterData.MaxHp = float.Parse(monList[i]["MaxHp"].ToString());
            monsterData.atkPower = float.Parse(monList[i]["atkPower"].ToString());
            monsterData.moveSpeed = float.Parse(monList[i]["moveSpeed"].ToString());
            monsterData.useSkill_01 = int.Parse(monList[i]["useSkill_01"].ToString());
            monsterData.useSkill_02 = int.Parse(monList[i]["useSkill_02"].ToString());
            monsterData.useSkill_03 = int.Parse(monList[i]["useSkill_03"].ToString());
            monsterData.useSkill_04 = int.Parse(monList[i]["useSkill_04"].ToString());
            monsterData.useSkill_05 = int.Parse(monList[i]["useSkill_05"].ToString());
            monsterData.useSkill_06 = int.Parse(monList[i]["useSkill_06"].ToString());
            monsterData.useSkill_07 = int.Parse(monList[i]["useSkill_07"].ToString());
            monsterData.useSkill_08 = int.Parse(monList[i]["useSkill_08"].ToString());

            MonsterDic.Add(id, monsterData);
        }
    }
    void LvStUpDataRoad()
    {
        List<Dictionary<string, object>> lvStList = CSVReader.Read(csvLvStUpTableFile);

        for (int i = 0; i < lvStList.Count; i++)
        {
            LvStUpClass lvStUpData = new LvStUpClass();

            int startlv = int.Parse(lvStList[i]["id"].ToString());
            lvStUpData.maxHp = float.Parse(lvStList[i]["maxHp"].ToString());
            lvStUpData.atkPwr = float.Parse(lvStList[i]["atkPwr"].ToString());
            lvStUpData.criPrb = float.Parse(lvStList[i]["criPrb"].ToString());
            lvStUpData.criDmg = float.Parse(lvStList[i]["criDmg"].ToString());
            lvStUpData.hpRcv = float.Parse(lvStList[i]["hpRcv"].ToString());
            lvStUpData.cdnPct = float.Parse(lvStList[i]["cdnPct"].ToString());

            LvStUpDic.Add(startlv, lvStUpData);
        }
    }
    void ProjectileDataRoad()
    {
        List<Dictionary<string, object>> tileList = CSVReader.Read(csvProjectileTableFile);

        for (int i = 0; i < tileList.Count; i++)
        {
            ProjectileClass projectileData = new ProjectileClass();
            int id = int.Parse(tileList[i]["id"].ToString());
            projectileData.name = tileList[i]["name"].ToString();

            ProjectileDic.Add(id, projectileData);
        }
    }
    void RiskDataRoad()
    {
        List<Dictionary<string, object>> riskList = CSVReader.Read(csvRiskTableFile);

        for (int i = 0; i < riskList.Count; i++)
        {
            RiskClass riskData = new RiskClass();
            int id = int.Parse(riskList[i]["id"].ToString());
            riskData.name = riskList[i]["name"].ToString();
            riskData.curHp = float.Parse(riskList[i]["curHp"].ToString());
            riskData.maxHp = float.Parse(riskList[i]["maxHp"].ToString());
            riskData.atkPwr = float.Parse(riskList[i]["atkPwr"].ToString());
            riskData.moveSpeed = float.Parse(riskList[i]["moveSpeed"].ToString());
            riskData.criPrb = float.Parse(riskList[i]["criPrb"].ToString());
            riskData.criDmg = float.Parse(riskList[i]["criDmg"].ToString());
            riskData.gotDmg = float.Parse(riskList[i]["gotDmg"].ToString());
            riskData.hpRcv = float.Parse(riskList[i]["hpRcv"].ToString());
            riskData.cdnPct = float.Parse(riskList[i]["cdnPct"].ToString());
            riskData.rmnRnd = int.Parse(riskList[i]["rmnRnd"].ToString());
            riskData.wonScale = float.Parse(riskList[i]["wonScale"].ToString());

            RiskDic.Add(id, riskData);
        }
    }
    void SkillDataRoad()
    {
        List<Dictionary<string, object>> skillList = CSVReader.Read(csvSkillTableFile);

        for (int i = 0; i < skillList.Count; i++)
        {

            //if(startLv != 0 && startLv % 5 == 0)
            //{
            //    //stData.testBool = true;
            //}
            //else
            //{
            //    //stData.testBool - false;
            //}
            SkillClass skillData = new SkillClass();
            int id = int.Parse(skillList[i]["id"].ToString());
            skillData.skillName = skillList[i]["skillName"].ToString();
            skillData.skillEffect_01 = int.Parse(skillList[i]["skillEffect_01"].ToString());
            skillData.skillEffect_02 = int.Parse(skillList[i]["skillEffect_02"].ToString());
            skillData.stiffTime = float.Parse(skillList[i]["stiffTime"].ToString());
            skillData.stunTime = float.Parse(skillList[i]["stunTime"].ToString());
            skillData.dotTime = float.Parse(skillList[i]["dotTime"].ToString());
            skillData.dotPeriod = float.Parse(skillList[i]["dotPeriod"].ToString());
            skillData.dotDmgPct = float.Parse(skillList[i]["dotDmgPct"].ToString());
            skillData.slowTime = float.Parse(skillList[i]["slowTime"].ToString());
            skillData.slowPct = float.Parse(skillList[i]["slowPct"].ToString());
            skillData.skillCool = float.Parse(skillList[i]["skillCool"].ToString());
            skillData.skillTime = float.Parse(skillList[i]["skillTime"].ToString());
            skillData.dmgPct_01 = float.Parse(skillList[i]["dmgPct_01"].ToString());
            skillData.dmgPct_02 = float.Parse(skillList[i]["dmgPct_02"].ToString());
            skillData.dmgPct_03 = float.Parse(skillList[i]["dmgPct_03"].ToString());
            skillData.dmgPct_04 = float.Parse(skillList[i]["dmgPct_04"].ToString());
            skillData.dmgPct_05 = float.Parse(skillList[i]["dmgPct_05"].ToString());

            SkillDic.Add(id, skillData);
        }
    }
    void SpawnDataRoad()
    {
        List<Dictionary<string, object>> spawnList = CSVReader.Read(csvSpawnTableFile);

        for (int i = 0; i < spawnList.Count; i++)
        {
            SpawnClass spawnClass = new SpawnClass();
            int id = int.Parse(spawnList[i]["id"].ToString());
            spawnClass.monNum_01 = int.Parse(spawnList[i]["monNum_01"].ToString());
            spawnClass.monNum_02 = int.Parse(spawnList[i]["monNum_02"].ToString());
            spawnClass.monNum_03 = int.Parse(spawnList[i]["monNum_03"].ToString());
            spawnClass.monNum_04 = int.Parse(spawnList[i]["monNum_04"].ToString());
            spawnClass.monNum_05 = int.Parse(spawnList[i]["monNum_05"].ToString());

            SpawnDic.Add(id, spawnClass);
        }
    }
    void StageDataRoad()
    {
        List<Dictionary<string, object>> stageList = CSVReader.Read(csvStageTableFile);

        for (int i = 0; i < stageList.Count; i++)
        {
            StageClass stageClass = new StageClass();
            int id = int.Parse(stageList[i]["id"].ToString());
            stageClass.waveId_01 = int.Parse(stageList[i]["waveId_01"].ToString());
            stageClass.waveId_02 = int.Parse(stageList[i]["waveId_02"].ToString());
            stageClass.waveId_03 = int.Parse(stageList[i]["waveId_03"].ToString());
            stageClass.waveId_04 = int.Parse(stageList[i]["waveId_04"].ToString());
            stageClass.waveId_05 = int.Parse(stageList[i]["waveId_05"].ToString());
            stageClass.waveId_06 = int.Parse(stageList[i]["waveId_06"].ToString());

            stageDic.Add(id, stageClass);
        }
    }
    void StUPDataRoad()
    {
        List<Dictionary<string, object>> stUpList = CSVReader.Read(csvStUpTableFile);

        for (int i = 0; i < stUpList.Count; i++)
        {
            StUPClass stUPData = new StUPClass();

            int id = int.Parse(stUpList[i]["startLv"].ToString());
            stUPData.upPrb = float.Parse(stUpList[i]["upPrb"].ToString());
            stUPData.useWon = int.Parse(stUpList[i]["useWon"].ToString());
            stUPData.upMaxHp = float.Parse(stUpList[i]["upMaxHp"].ToString());
            stUPData.upAtkPwr = float.Parse(stUpList[i]["upAtkPwr"].ToString());
            stUPData.upCriPrb = float.Parse(stUpList[i]["upCriPrb"].ToString());
            stUPData.upCriDmg = float.Parse(stUpList[i]["upCriDmg"].ToString());
            stUPData.upHpRcv = float.Parse(stUpList[i]["upHpRcv"].ToString());
            stUPData.upCdnPct = float.Parse(stUpList[i]["upCdnPct"].ToString());

            StUpDic.Add(id, stUPData);
        }
    }
    void WaveDataRoad()
    {
        List<Dictionary<string, object>> waveList = CSVReader.Read(csvWaveTableFile);

        for (int i = 0; i < waveList.Count; i++)
        {
            WaveClass waveClass = new WaveClass();
            int id = int.Parse(waveList[i]["id"].ToString());
            waveClass.waveType = int.Parse(waveList[i]["waveType"].ToString());
            waveClass.monId_01 = int.Parse(waveList[i]["monId_01"].ToString());
            waveClass.monId_02 = int.Parse(waveList[i]["monId_02"].ToString());
            waveClass.monId_03 = int.Parse(waveList[i]["monId_03"].ToString());
            waveClass.monId_04 = int.Parse(waveList[i]["monId_04"].ToString());
            waveClass.monId_05 = int.Parse(waveList[i]["monId_05"].ToString());
            waveClass.monId_06 = int.Parse(waveList[i]["monId_06"].ToString());
            waveClass.specialMonId_01 = int.Parse(waveList[i]["specialMonId_01"].ToString());
            waveClass.specialMonId_02 = int.Parse(waveList[i]["specialMonId_02"].ToString());
            waveClass.spawn_01 = int.Parse(waveList[i]["spawn_01"].ToString());
            waveClass.spawn_02 = int.Parse(waveList[i]["spawn_02"].ToString());
            waveClass.spawn_03 = int.Parse(waveList[i]["spawn_03"].ToString());
            waveClass.spawn_04 = int.Parse(waveList[i]["spawn_04"].ToString());

            WaveDic.Add(i, waveClass);
        }
    }
}
#region

public class ImageClass
{
    public int id;
    public Sprite image;

}
public class StUPClass
{
    public int startLv;//��ȭ ���� ����
    public float upPrb;//���� Ȯ��
    public int useWon;//��ȭ �õ� ���
    public float upMaxHp;//�ִ� ü�� ��·�
    public float upAtkPwr;//���ݷ� ��·�
    public float upCriPrb;//ġ��Ÿ Ȯ�� ��·�
    public float upCriDmg;//ġ��Ÿ ������ ��·�
    public float upHpRcv;//�ʴ� ü�� ȸ���� ��·�
    public float upCdnPct;//��ų ��Ÿ�� ������ ��·�
}
public class LvStUpClass
{
    public int id;
    public float maxHp;//������ �� �����ϴ� �ִ� ü�� ��
    public float atkPwr;//������ �� �����ϴ� ���ݷ� ��
    public float criPrb;//5�������� ����, 10���� ������ �� �����ϴ� ġ��Ÿ Ȯ�� ��
    public float criDmg;//5�������� ����, 10���� ������ �� �����ϴ� ġ��Ÿ ������ ��
    public float hpRcv;//������ �� �����ϴ� �ʴ� ü�� ȸ���� ��
    public float cdnPct;//5�������� ����, 10���� ������ �� �����ϴ� ��ų ��Ÿ�� ������ ��
}
public class TypeClass
{
    public int id;//id
    public string className;//Ŭ���� �̸�
    public float maxHp;//���� �� �ִ� ü��
    public float atkPwr;//���� �� ���ݷ�
    public float criPrb;//���� �� ġ��Ÿ Ȯ��
    public float criDmg;//���� �� ġ��Ÿ ������
    public float hpRcv;//���� �� �ʴ� ü�� ȸ����
    public float cdnPct;//���� �� ��ų ��Ÿ�� ������
    public float gotDmg;//���� �� �޴� ���ط�
    public float moveSpeed;//���� �� �̵� �ӵ�
    public int skill_01;//Skill.tbl�� id ����
    public int skill_02;//Skill.tbl�� id ����
    public int skill_03;//Skill.tbl�� id ����
    public int skill_04;//Skill.tbl�� id ����
    public int skill_05;//Skill.tbl�� id ����
    public int skill_06;//Skill.tbl�� id ����
    public int skill_07;//Skill.tbl�� id ����
    public int skill_08;//Skill.tbl�� id ����
}
public class ExpClass
{
    public int lv;//���� ����
    public int curExp;//���� ������ �������ϱ� ���� �ʿ��� ����ġ��
}
public class StageClass
{
    public int id;//id
    public int waveId_01;//Wave.tbl�� id ����
    public int waveId_02;//Wave.tbl�� id ����
    public int waveId_03;//Wave.tbl�� id ����
    public int waveId_04;//Wave.tbl�� id ����
    public int waveId_05;//Wave.tbl�� id ����
    public int waveId_06;//Wave.tbl�� id ����
}
public class WaveClass
{
    public int id;//id
    public int waveType;//���̺� ���� : 1 = �Ϲ�, 2 = �߰� ������, 3 = ������
    public int monId_01;//�Ϲ� ���� ���� : �߰� ������������ ������ �Ϸ��� ��. Monster.tbl�� id ����
    public int monId_02;//Monster.tbl�� id ����
    public int monId_03;//Monster.tbl�� id ����
    public int monId_04;//Monster.tbl�� id ����
    public int monId_05;//Monster.tbl�� id ����
    public int monId_06;//Monster.tbl�� id ����
    public int specialMonId_01;//waveType�� 1�� �ƴ� �� ���. 2�� ��� �߰� ������ ID �Է�. 3�� ��� ���� ID �Է�
    public int specialMonId_02;//waveType�� 1�� �ƴ� �� ���. 2�� ��� �߰� ������ ID �Է�. 3�� ��� ���� ID �Է�
    public int spawn_01;//Spawn.tbl�� id ����
    public int spawn_02;//Spawn.tbl�� id ����
    public int spawn_03;//Spawn.tbl�� id ����
    public int spawn_04;//Spawn.tbl�� id ����
}
public class SpawnClass
{
    public int id;//id
    public int monNum_01;//�ٰŸ� ���� �� ���� ��
    public int monNum_02;//���Ÿ� ���� �� ���� ��
    public int monNum_03;//������ ���� �� ���� ��
    public int monNum_04;//����Ʈ ���� �� ���� ��
    public int monNum_05;//���� ���� �� ���� ��
}
public class RiskClass
{
    public int id;//id
    public string name;//����ũ ��Ī
    public float curHp;//���� ü�� ���� ����
    public float maxHp;//�ִ� ü�� ���� ����
    public float atkPwr;//���ݷ� ���� ����
    public float moveSpeed;//�̵� �ӵ� ���� ����
    public float criPrb;//ġ��Ÿ Ȯ�� ���� ����
    public float criDmg;//ġ��Ÿ ������ ���� ����
    public float gotDmg;//�޴� ���ط� ���� ����
    public float hpRcv;//�ʴ� ü�� ȸ���� ���� ����
    public float cdnPct;//��ų ��Ÿ�� ������ ���� ����
    public int rmnRnd;//���ӵǴ� ����ũ ����
    public float wonScale;//��ȭ ����
}
public class MonsterClass
{
    public int id;//id
    public string name;//���� ��Ī
    public int monType;//���� Ÿ��. 1=�ٰŸ�, 2=���Ÿ�, 3=������, 4=����Ʈ, 5=����
    public int projectile_01;//������ ���ݿ� ���Ǵ� ����ü. Projectile.tbl���� id ����
    public int projectile_02;//������ ���ݿ� ���Ǵ� ����ü. Projectile.tbl���� id ����
    public float giveWon;//���͸� �׿��� �� �÷��̾ ȹ���ϴ� ��ȭ��
    public float giveExp;//���͸� �׿��� �� �÷��̾ ȹ���ϴ� ����ġ��
    public float MaxHp;//���� ���� �� �ִ� ü��
    public float atkPower;//������ ���ݷ�
    public float moveSpeed;//������ �̵� �ӵ�
    public int useSkill_01;//���Ͱ� ����ϴ� ��ų. Skill.tbl���� id ����
    public int useSkill_02;//���Ͱ� ����ϴ� ��ų. Skill.tbl���� id ����
    public int useSkill_03;//���Ͱ� ����ϴ� ��ų. Skill.tbl���� id ����
    public int useSkill_04;//���Ͱ� ����ϴ� ��ų. Skill.tbl���� id ����
    public int useSkill_05;//���Ͱ� ����ϴ� ��ų. Skill.tbl���� id ����
    public int useSkill_06;//���Ͱ� ����ϴ� ��ų. Skill.tbl���� id ����
    public int useSkill_07;//���Ͱ� ����ϴ� ��ų. Skill.tbl���� id ����
    public int useSkill_08;//���Ͱ� ����ϴ� ��ų. Skill.tbl���� id ����
}
public class ProjectileClass
{
    public int id;//id
    public string name;//����ü ��Ī
}
public class SkillClass
{
    public int id;//id
    public string skillName;//��ų ��Ī
    public int skillEffect_01;//Effect.tbl�� id ����
    public int skillEffect_02;//Effect.tbl�� id ����
    public float stiffTime;//skillEffect=1�� �� ���. ���� ���� �ð�
    public float stunTime;//skillEffect=2�� �� ���. ���� ���� �ð�
    public float dotTime;//skillEffect=4�� �� ���. Dot ���� �ð�
    public float dotPeriod;//skillEffect=4�� �� ���. Dot ó�� �ֱ�
    public float dotDmgPct;//skillEffect=4�� �� ���. 1ƽ �� ������
    public float slowTime;//skillEffect=5�� �� ���. ���ο� ���� �ð�
    public float slowPct;//skillEffect=5�� �� ���. ���ο� �ۼ�Ʈ
    public float skillCool;//��ų ��Ÿ��
    public float skillTime;//��ų ���� �ð�
    public float dmgPct_01;//��ų ������ �ۼ�Ʈ
    public float dmgPct_02;//��ų ������ �ۼ�Ʈ. ���� Ÿ���� ���� � ���
    public float dmgPct_03;//��ų ������ �ۼ�Ʈ. ���� Ÿ���� ���� � ���
    public float dmgPct_04;//��ų ������ �ۼ�Ʈ. ���� Ÿ���� ���� � ���
    public float dmgPct_05;//��ų ������ �ۼ�Ʈ. ���� Ÿ���� ���� � ���
}
#endregion

/*speed,MaxHp,rotationSpeed

 * 
 */
