using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

  public static GameController Instance;

  [SerializeField] private RectTransform fillHealthBarTransform_;
  [SerializeField] private float timerMultiplier = 2.0f;  

  private float originalWidth;

  [SerializeField] private EnemyController enemyController_;
  [SerializeField] private RectTransform enemyTimeRemaining_;
  [SerializeField] private float enemyTimeMultiplier_ = 12.0f;
  [SerializeField] private GameObject enemyTimer_;

  public float accumulatedTime_;

  public static Zone.ZType CurrentPlayerZone = Zone.ZType.Outside;

  private float width = 540.0f;

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

    originalWidth = fillHealthBarTransform_.sizeDelta.x;
    width = originalWidth;
    Ingredientes = new()
    {
        Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoKevin"), 
        Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoKaren"), 
        Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoMustang"), 
        Resources.Load<ObjetivoSO>("ScriptableObjects/ObjetivoTonTorres"), 
    };
    GenerateReceta();
  }

  void Update() {
    // MaskTimer();
    // EnemyTimer();

  }

  void MaskTimer(){
    if(!enemyController_.gameObject.activeInHierarchy){
      fillHealthBarTransform_.sizeDelta = new Vector2(width - (accumulatedTime_ += Time.deltaTime * timerMultiplier), 20.0f);
      if(fillHealthBarTransform_.sizeDelta.x <= 0.0f){
        enemyController_.gameObject.SetActive(true);
      }
    }
  }

  void EnemyTimer(){
    if(enemyController_.gameObject.activeInHierarchy){
      enemyTimer_.SetActive(true);
      enemyTimeRemaining_.sizeDelta = new Vector2(width -= Time.deltaTime * enemyTimeMultiplier_, 20.0f);
      if(enemyTimeRemaining_.sizeDelta.x <= 0.0f){
        enemyController_.gameObject.SetActive(false);
        enemyTimeRemaining_.sizeDelta = new Vector2(originalWidth, 0.0f);
      }
    }
  }

<<<<<<< HEAD
  public void SpawnGuard(bool b){
    enemyController_.gameObject.SetActive(b);
  } 
=======
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
        }
    }
    void YOUWIN()
    {
        Debug.Log("YOU WIN!");
    }
>>>>>>> 4295e940e9cc4fdd2b009b26b3174f7d1569e120

}
