using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    public GameObject monsterPrefab;
    public List<Transform> spawnPosition = new List<Transform>();
    public int monCnt=1;
    public float interval;

    // Start is called before the first frame update

    IEnumerator monGen;
    
    void Start()
    {
        monGen = MonsterGen();
        StartCoroutine(monGen);
    }



    IEnumerator MonsterGen()
    {
        int monCheckCnt = 0;
        while (monCheckCnt < monCnt)
        {
         
            int randPosIndex = Random.Range(0, spawnPosition.Count);
            Vector3 pos = spawnPosition[randPosIndex].position;

            GameObject mon = Instantiate(monsterPrefab, pos, Quaternion.identity);
            Monster monster = mon.GetComponent<Monster>();
            monster.monId = 111; // 이곳은 나중에 ID 값을 받아 수정 진행
            monster.DataSetting();


            yield return new WaitForSeconds(interval);

            monCheckCnt++;

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
