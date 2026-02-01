using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

  public static GameController Instance;

  [SerializeField] private RectTransform fillHealthBarTransform_;
  [SerializeField] private float timerMultiplier = 2.0f;  

  private float originalWidth_;
  public GameObject menu_;
  public GameObject gameOverCanvas_;
  public GameObject winCanvas_;

  [SerializeField] private EnemyController enemyController_;
  [SerializeField] private RectTransform enemyTimeRemaining_;
  [SerializeField] private float enemyTimeMultiplier_ = 12.0f;
  [SerializeField] private GameObject enemyTimer_;
  private float enemyWidth_ = 670.0f;
  private float enemyOriginalWidth_ = 670.0f;
  private bool isEmpty_;
  private bool isReset_;
  private bool isInvincible;

  public float accumulatedTime_;

  [Header("AQUI? ESTOY LOCO?")]
  public Zone.ZType CurrentPlayerZone = Zone.ZType.Outside;
  public void UpdateCurrentPlayerZone(Zone.ZType zone)
  {
        Debug.Log(zone);
        CurrentPlayerZone = zone;
        AudioGod.Instance?.UpdateMusicByZone(zone);
  }

  private float width = 670.0f;

  public List<Collectable.Type> PreHoldedTypes;
  public List<Collectable.Type> HoldedTypes;
  public List<ObjetivoSO> Ingredientes;
  public List<ObjetivoSO> Receta;
  public int Completados = 0;
  public ObjetivoSO ObjetivoActual;

  void Start() {
    if (Instance == null)
    {
        Instance = this;
    }
    else Destroy(gameObject);
    accumulatedTime_ = 0.0f;

    originalWidth_ = fillHealthBarTransform_.sizeDelta.x;
    width = originalWidth_;
    Ingredientes = new()
    {
        Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoKevin"), 
        Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoKaren"), 
        Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoMustang"), 
        Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoTonTorres"), 
    };
    GenerateReceta();
    menu_.SetActive(true);
  }

  void Update() {
    MaskTimer();
    EnemyTimer();

    if(Input.GetButtonDown("Cancel")){
      if(!menu_.activeInHierarchy){
        menu_.SetActive(true);
      }
      else{
        menu_.SetActive(false);
      }
    }
  }

  public void RefillMaskBar(){
    fillHealthBarTransform_.sizeDelta = new Vector2(originalWidth_, 0.0f);
    width = originalWidth_;
    accumulatedTime_ = 0.0f;
  }

  public void RefillEnemyBar(){
    enemyController_.isLeaving_ = true;
    enemyController_.isIdle_ = true;
    enemyTimeRemaining_.sizeDelta = new Vector2(enemyOriginalWidth_, 0.0f);
    enemyWidth_ = enemyOriginalWidth_;
    enemyTimer_.SetActive(false);
  }

  void MaskTimer(){
    if(!isEmpty_ && !isReset_){
      fillHealthBarTransform_.sizeDelta = new Vector2(width - (accumulatedTime_ += Time.deltaTime * timerMultiplier), 70.0f);
      if(fillHealthBarTransform_.sizeDelta.x <= 0.0f){
        enemyController_.isIdle_ = true;
        isEmpty_ = true;
      }
    }
    if(isEmpty_) {
      SpawnGuard(false);
    }
  }

  void EnemyTimer(){
    if(!enemyController_.isIdle_){
      if(!enemyController_.isLeaving_){
        enemyTimeRemaining_.sizeDelta = new Vector2(enemyWidth_ -= Time.deltaTime * enemyTimeMultiplier_, 70.0f);
        if(enemyTimeRemaining_.sizeDelta.x <= 0.0f){
          RefillEnemyBar();
        }
      }
    }
  }

  public void SpawnGuard(bool b){
    enemyController_.isIdle_ = false;
    enemyController_.isLeaving_ = false;
    enemyTimer_.SetActive(true);
  } 

    void GenerateReceta()
    {
        Receta.Add(Ingredientes[0]);
        List<int> usados = new() { 0 };

        int r = 0;
        for (int i = 0; i < Ingredientes.Count - 1; i++)
        {
            while (usados.Contains(r))
            {
                r = Random.Range(1, Ingredientes.Count);
            }
            usados.Add(r);
            Receta.Add(Ingredientes[r]);
        }
        ObjetivoActual = Ingredientes[0];
        InitObjective();
    }

    public void InitObjective()
    {
        PortraitManager.Instance.UpdatePortrait(ObjetivoActual.portrait);
    }

    public bool IsCorrectMaskCorrect() {

        return HoldedTypes.Count == ObjetivoActual.RequiredObjects.Count &&
            HoldedTypes.ToHashSet().SetEquals(ObjetivoActual.RequiredObjects.ToHashSet());
    }

    public void TryNextObjective()
    {
        if (IsCorrectMaskCorrect())
        {
            RefillMaskBar();
            isReset_ = true;
            enemyController_.isLeaving_ = true;
            RefillEnemyBar();
            isInvincible = true;

            Debug.Log("HELL YEA");
            NextObjective();
        }
    }
    public void NextObjective()
    {
        Completados++;
        if (Completados == Receta.Count)
        {
            YOUWIN();
        }
        else
        {
            ObjetivoActual = Receta[Completados];
            InitObjective();
            isReset_ = false;
        }
    }
    void YOUWIN()
    {
      winCanvas_.SetActive(true);
      Time.timeScale = 0.0f;  
    }

}
