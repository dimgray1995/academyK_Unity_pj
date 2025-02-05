using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;
    public static bool HasInstance => _instance != null;
    public static T TryGetInstance() => HasInstance ? _instance : null;
    public static T Current => _instance;

    /// <summary>
    /// �̱��� ������ ����
    /// </summary>
    /// <value>�ν��Ͻ�</value>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name + "_AutoCreated";
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// Awake���� �ν��Ͻ��� �ʱ�ȭ�մϴ�. ���� awake�� override�ؼ� ����ؾ� �Ѵٸ� base.Awake()�� ȣ���ؾ� �մϴ�.
    /// </summary>
    protected virtual void Awake()
    {
        InitializeSingleton();
    }

    /// <summary>
    /// �̱����� �ʱ�ȭ�մϴ�.
    /// </summary>
    protected virtual void InitializeSingleton()
    {
        //������ �������� �ƴ϶�� �����մϴ�.
        if (!Application.isPlaying)
        {
            return;
        }

        _instance = this as T;
    }
}