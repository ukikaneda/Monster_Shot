using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

//ゲームオブジェクトにアタッチすると、ARRaycastManager.csを必要な依存関係として自動的に加える。
[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(Text))]
[RequireComponent(typeof(AudioSource))]
public class ARRaycast2 : MonoBehaviour
{
     //ARで表示するfield
    [SerializeField] GameObject arObject;
     //ARで表示するstaff
    [SerializeField] GameObject arStaff;
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
    public bool isGenerated = false;
    bool isCalledOnce = false;

    public GameObject zombieSpawnPoint1;
    public GameObject zombieSpawnPoint2;
    public GameObject zombieSpawnPoint3;
    public GameObject zombieSpawnPoint4;
    public GameObject zombieSpawnPoint5;
    public GameObject zombieSpawnPoint6;
    public GameObject zombieSpawnPoint7;
    public GameObject zombieSpawnPoint8;
    
    [Header("Set Enemy Prefab")]
    //敵プレハブ
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public GameObject enemyPrefab5;
    public GameObject enemyPrefab6;
    public GameObject enemyPrefab7;
    public GameObject enemyPrefab8;

    [Header("Set Interval Min and Max")]
    //時間間隔の最小値
    [Range(1f,7f)]
    public float minTime1 = 6f; 
    //時間間隔の最大値
    [Range(3f,25f)]
    public float maxTime1 = 20f; 

    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;

    public GameObject spawnTarget;
    //targetプレハブ
    public GameObject targetPrefab;
    
    //plasmaプレハブ
    public GameObject plasma;
    //plasmaが生成されるポジションを保有するオブジェクト
    public GameObject plasmaSpawnPoint;
    //Plasmaのスピード
    public float shotSpeed;

    public AudioSource bgmAudioSource;
    [SerializeField] private AudioSource spse;
    [SerializeField] private AudioSource clse;

    [SerializeField] private AudioClip spawnSound;
    [SerializeField] private AudioClip clearSound;
    [SerializeField] AudioClip shotSound;

    //ゲームの制限時間
    [SerializeField] float gameTime = 60.0f;
    //UITextコンポーネント
    Text uiText;
    //残り時間タイマー
    float currentTime;

    //Plasmaの発射間隔のカウント
    private float timeBetweenShot = 0.5f;
    private float timer;
  
    [SerializeField] GameObject startTap;
    [SerializeField] GameObject tapUiPlate;

    public GameObject targetGenerator;

    private bool m_PlaneVisible = true;
    ARPlaneManager m_ARPlaneManager;

    private Animator animator;

    void Awake()
    {
        //RequireComponentで追加されたARRaycastManager.csを代入する。
        raycastManager = GetComponent<ARRaycastManager>();
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
    }     
    void Start()
    {
        interval = GetRandomTime();
        bgmAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        time += Time.deltaTime;

         foreach (var plane in m_ARPlaneManager.trackables)
        {
           plane.gameObject.SetActive(m_PlaneVisible);
        }
          
        if (!isGenerated && Input.GetMouseButtonDown(0))
        {
             m_PlaneVisible = !m_PlaneVisible;

            //rayを照射して平面に当たっていた場合。
            if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults))
            {

                //arObjectが非アクティブの場合、アクティブにする。
                if (arObject.activeSelf == false)
                {
                    arObject.SetActive(true);
                    arStaff.SetActive(true);
                    
                    arObject.transform.position = hitResults[0].pose.position;
                    isGenerated = true;
                    //Textコンポーネント取得
                    uiText = GetComponent<Text>();
                    //残り時間を設定
                    currentTime = gameTime;
                    this.uiText = GameObject.Find("Timer").GetComponent<Text>();
                    
                    startTap.SetActive(false);
                    tapUiPlate.SetActive(false);
                    
                }
            }
        }

        if (arObject.activeSelf == true)
        {
            currentTime -= Time.deltaTime;
            timer += Time.deltaTime;
            //残り時間テキスト更新
            uiText.text = string.Format("TIME : {0:F}",currentTime);
            
                if (!isCalledOnce)
                {
                    isCalledOnce = true;
                    GameObject createdTargetPrefab = Instantiate(targetPrefab) as GameObject;
                    createdTargetPrefab.transform.position = spawnTarget.transform.position;
                }
                if (isGenerated && Input.GetMouseButtonDown(0) && timer > timeBetweenShot)
                {
                    timer = 0.0f;
                     //plasmaをインスタンス化して発射
                     GameObject createdPlasma = Instantiate(plasma) as GameObject;
                     createdPlasma.transform.position = plasmaSpawnPoint.transform.position;
                     //発射ベクトル  
                     Vector3 force;
                     //発射の向きと速度を決定
                     force = plasmaSpawnPoint.transform.forward * shotSpeed;
                     //発射の向きと速度を決定
                     createdPlasma.GetComponent<Rigidbody>().AddForce(force);
                     
                     //発射時の音を再生
                     Destroy(createdPlasma,2.0f);
                     spse.PlayOneShot(spawnSound);
                }
                if(time > interval )
                {
                    //enemyをインスタンス化
                    GameObject createdEnemyPrefab1 = Instantiate(enemyPrefab1) as GameObject;
                    createdEnemyPrefab1.transform.position = zombieSpawnPoint1.transform.position;

                    GameObject createdEnemyPrefab2 = Instantiate(enemyPrefab2) as GameObject;
                    createdEnemyPrefab2.transform.position = zombieSpawnPoint2.transform.position;
                      
                    GameObject createdEnemyPrefab3 = Instantiate(enemyPrefab3) as GameObject;
                    createdEnemyPrefab3.transform.position = zombieSpawnPoint3.transform.position;

                    GameObject createdEnemyPrefab4 = Instantiate(enemyPrefab4) as GameObject;
                    createdEnemyPrefab4.transform.position = zombieSpawnPoint4.transform.position;

                    GameObject createdEnemyPrefab5 = Instantiate(enemyPrefab5) as GameObject;
                    createdEnemyPrefab5.transform.position = zombieSpawnPoint5.transform.position;

                    GameObject createdEnemyPrefab6 = Instantiate(enemyPrefab6) as GameObject;
                    createdEnemyPrefab6.transform.position = zombieSpawnPoint6.transform.position;

                    GameObject createdEnemyPrefab7 = Instantiate(enemyPrefab7) as GameObject;
                    createdEnemyPrefab7.transform.position = zombieSpawnPoint7.transform.position;

                    GameObject createdEnemyPrefab8 = Instantiate(enemyPrefab8) as GameObject;
                    createdEnemyPrefab8.transform.position = zombieSpawnPoint8.transform.position;

                    time = 0f;
                }
                        //0以下にはならない
                    if (currentTime <= 0.0f)
                    {
                        clse.PlayOneShot(clearSound);
                        currentTime = 0.0f;
                        Invoke("scene", 1);
                    }
        }

    }
    public void bgmAudio()
    {
        if (arObject.activeSelf == true)
        {
            bgmAudioSource.Play();
        }
    }
    void scene()
    {
        SceneManager.LoadScene("Clear");
    }
    private float GetRandomTime()
    {
        return Random.Range(minTime1,maxTime1);
    }
    //カウントダウンを行っているか？
    public bool IsCountingDown()
    {
        //カウンターが０でなければ、カウント中
        return currentTime > 0.0f;
    }
}