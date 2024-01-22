using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
	
	// Materialを入れる
	Material myMaterial;
	
	// Emissionの最小値
	private float minEmission = 0.3f;
	// Emissionの強度
	private float magEmission = 2.0f;
	// 角度
	private int degree = 0;
	// ターゲットのデフォルトの色
	Color defaultColor = Color.white;
	
	float plungerY = -5f;
	
	Vector3 pos = new Vector3();
	
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("SpringController Start");
        this.defaultColor = Color.white;
        // オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer> ().material;
        
        // オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor*minEmission);

        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        SpringJoint sj = this.GetComponent<SpringJoint>();
        //Debug.Log("SpringController Update");
        if (Input.GetKey(KeyCode.DownArrow))
        {
        	//Debug.Log("plungerY -> " + plungerY.ToString());
	        
	        this.transform.position = pos;
	        sj.spring = 0;
	        // rb.AddForce(pos, ForceMode.Force);
        }
        else
        {
	        sj.spring = 70;
        	// rb.velocity = Vector3.zero;
        
        }
        
		// 光らせる強度を計算する
		Color emissionColor = 
		this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);

		// エミッションに色を設定する
		myMaterial.SetColor ("_EmissionColor", emissionColor);

    }
}
