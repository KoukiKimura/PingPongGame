using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRegulator : MonoBehaviour
{
	// Materialを入れる
	Material myMaterial;
	
	// Emissionの最小値
	private float minEmission = 0.3f;
	// Emissionの強度
	private float magEmission = 2.0f;
	// 角度
	private int degree = 0;
	// 発行速度
	private int speed = 10;
	// ターゲットのデフォルトの色
	Color defaultColor = Color.white;
	
	// スコアを表示するオブジェクト
	public GameObject scoreText;
	// スコアを表示するバリュー
	public long scoreValue;
	
    // Start is called before the first frame update
    void Start()
    {
        // タグによって光らせる色を変える
        if (tag == "SmallStarTag"){
        	this.defaultColor = Color.white;
        } else if (tag == "LargeStarTag"){
        	this.defaultColor = Color.yellow;
        } else if (tag == "SmallCloudTag" || tag == "LargeCloudTag"){
        	this.defaultColor = Color.cyan;
        }
        
        // オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer> ().material;
        
        // オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor*minEmission);
        
        // シーン中のGameOverTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {		
        if (this.degree >= 0){
        	// 光らせる強度を計算する
        	Color emissionColor = 
        		this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);
        	
        	// エミッションに色を設定する
        	myMaterial.SetColor ("_EmissionColor", emissionColor);
        	
        	// 現在の角度を小さくする
        	this.degree -= this.speed;
        	
		}

    }
    
    // 衝突時に飛ばれる関数
    void OnCollisionEnter(Collision other){
        	long textValue = 0;

	        // タグによってスコアを変える
	        if (tag == "SmallStarTag"){
	        	textValue = 5;
				Debug.Log ("SmallStarTag");
				Debug.Break ();
	        } else if (tag == "LargeStarTag"){
	        	textValue = 10;
			Debug.Log ("textValue : " + textValue.ToString());
			Debug.Log ("scoreValue : " + scoreValue.ToString());
				Debug.Log ("LargeStarTag");
				Debug.Break ();
	        } else if (tag == "SmallCloudTag" || tag == "LargeCloudTag"){
	        	textValue = 20;
				Debug.Log ("SmallCloudTag");
				Debug.Break ();
	        }
			Debug.Log ("textValue : " + textValue.ToString());
			Debug.Log ("scoreValue : " + scoreValue.ToString());
	        scoreValue = scoreValue + textValue;
        	this.scoreText.GetComponent<Text> ().text = scoreValue.ToString();

			Debug.Log ("scoreValue : " + scoreValue.ToString());
    }
}
