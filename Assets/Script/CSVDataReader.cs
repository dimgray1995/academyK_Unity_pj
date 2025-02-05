using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVDataReader : MonoBehaviour
{
    [SerializeField] TextAsset csvTableFile; //테이블 넣기
    [SerializeField] string csvTablePath; //테이블 위치값 복사 후 넣기

    public Dictionary<int, TestClass> testDic = new Dictionary<int, TestClass>();

    // Start is called before the first frame update
    void Start()
    {

        TestClassData();


    }

    void TestClassData()
    {

        List<Dictionary<string, object>> data = CSVReader.Read(csvTableFile); //csv리더기를 통해 담아둔다.

        for (int i = 0; i < data.Count; i++)
        {
            int id = int.Parse(data[i]["id"].ToString());
            TestClass tClass = new TestClass();

            tClass.id = id;
            tClass.Speed = float.Parse(data[i]["speed"].ToString());
            tClass.MaxHp = float.Parse(data[i]["MaxHp"].ToString());
            tClass.rotationSpeed = float.Parse(data[i]["rotationSpeed"].ToString());
            //data[i]["스트링 칼럼"].ToString();

            
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

}

/*speed,MaxHp,rotationSpeed

 * 
 */
