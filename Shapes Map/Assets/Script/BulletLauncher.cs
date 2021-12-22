using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletLauncher : MonoBehaviour
{
    [Header("Difficulty")]
    public int maxBulletNum;
    public float minDelay;
    public float maxDelay;
    public float minBulletSpeed;
    public float maxBulletSpeed;

    [Header("debug")]
    public int add;
    
    [Space]

    public GameObject[] points;

    private GameObject bulletPrefab;
    private int bulletCount;
    private float curTime;
    private float delay;

    private int a, b, c;
    private int _add;

    private ClosedInteger closedInteger = new ClosedInteger(-3, 3);

    // Start is called before the first frame update
    void Awake()
    {
        bulletPrefab = Resources.Load<GameObject>("Bullet/Bullet");

        // GameObject bullet = Instantiate(Bullet);
        // bullet.transform.position = points[0].transform.position;
        // bullet.GetComponent<Bullet>().targetVactor = Vector3.zero;
        // bullet.GetComponent<Bullet>().Speed = 0.1f;

        // bullet = Instantiate(Bullet);
        // bullet.transform.position = points[1].transform.position;
        // bullet.GetComponent<Bullet>().targetVactor = Vector3.zero;
        // bullet.GetComponent<Bullet>().Speed = 0.1f;

        // bullet = Instantiate(Bullet);
        // bullet.transform.position = points[2].transform.position;
        // bullet.GetComponent<Bullet>().targetVactor = Vector3.zero;
        // bullet.GetComponent<Bullet>().Speed = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;

        if (curTime > delay)
        {
            int spawnPointNum = Random.Range(0, 3);

            Vector3 startPos = points[spawnPointNum].transform.position;
            Vector3 targetPos = getBetween(points, spawnPointNum, Random.Range((float)0, 1));
            float speed = Random.Range(minBulletSpeed, maxBulletSpeed);

            bulletShoot(startPos, targetPos, speed);

            delay = Random.Range(minDelay, maxDelay) + curTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int spawnPointNum = Random.Range(0, 3);

            switch (spawnPointNum)
            {
                case 0: ++a;
                break;
                case 1: ++b;
                break;
                case 2: ++c;
                break;
                
                default:
                break;
            }
            

            Debug.Log($"pointNum: {spawnPointNum}\n 0: {a}, 1: {b}, 2: {c}");
            Debug.Log($"+1: {Range(spawnPointNum + 1, points.Length)}, -1: {Range(spawnPointNum - 1, points.Length)}");
            // Debug.Log($"realNum: {}");

            Vector3 startPos = points[spawnPointNum].transform.position;
            Vector3 targetPos = getBetween(points, spawnPointNum, Random.Range((float)0, 1));
            float speed = Random.Range(minBulletSpeed, maxBulletSpeed);

            bulletShoot(startPos, targetPos, speed);

            // Debug.Log(startPos);
            // bulletShoot();
        }
    }

    private void bulletShoot(Vector3 startPos, Vector3 targetPos, float speed)
    {
        Bullet temp = Instantiate(bulletPrefab).GetComponent<Bullet>();
        temp.transform.position = startPos;
        temp.targetVactor = targetPos;
        temp.Speed = speed;
    }

    /// <summary>
    /// 게임 배열 사이를 0 ~ 1 로 받아아옴
    /// 
    /// 시계 방항으로 넣어야 정상적으로 작동
    /// </summary>
    /// <param name="array"></param>
    /// <param name="N"></param>
    /// <param name="T"></param>
    /// <returns></returns>
    private Vector3 getBetween(GameObject[] array, int N, float T)
    {
        return Vector3.Lerp(array[Range(N + 1, array.Length)].transform.position, 
            array[Range(N - 1, array.Length)].transform.position, T);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="N">array Num</param>
    /// <param name="max">array Length</param>
    /// <returns></returns>
    private int Range(int N, int max)
    {
        if (0 <= N && N < max)
        {
            return N;
        }
        else if (0 > N)
        {
            return max - 1;
        }
        else
        {
            return 0;
        }

        // switch (N)
        // {
        //     case -1: return max - 1;
        //     case 0: return 0;
        //     case 1: return 1;
        //     case 2: return 2;
        //     case 3: return 0;
            
        //     default: Debug.LogError(N);
        //     return 0;
        // }
    }

    public int BulletCount
    {
        get
        {
            return bulletCount;
        }
        set
        {
            bulletCount = value;
        }
    }
}
