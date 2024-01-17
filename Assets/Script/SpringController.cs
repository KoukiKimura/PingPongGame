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
	
	float plungerY = 3.5f;
	float plungerZ = 3.5f;
	
	
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SpringController Start");
        this.defaultColor = Color.white;
        // オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer> ().material;
        
        // オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor*minEmission);

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Debug.Log("SpringController Update");
        Vector3 pos = this.transform.position;
        if (Input.GetKey(KeyCode.DownArrow))
        {
        	plungerY = Mathf.Clamp(plungerY*-1, -3.5f, 0);
        	plungerZ = Mathf.Clamp(Mathf.Sin(plungerZ-1), -3.5f, 0);
        	pos.y = plungerY;
        	pos.z = plungerZ;
        	Debug.Log("plungerY:plungerZ -> " + plungerY.ToString() + " : " + plungerZ.ToString());
	        
	        rb.AddForce(pos);
        }
        else
        {
        	plungerY = Mathf.Clamp(Mathf.Cos(plungerY), -3.5f, 0);
        	plungerZ = Mathf.Clamp(Mathf.Sin(plungerZ - 1), -3.5f, 0);
        	pos.y = plungerY;
        	pos.z = plungerZ;
        	Debug.Log("plungerY:plungerZ -> " + plungerY.ToString() + " : " + plungerZ.ToString());
        }
        
		// 光らせる強度を計算する
		Color emissionColor = 
		this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);

		// エミッションに色を設定する
		myMaterial.SetColor ("_EmissionColor", emissionColor);

    }
}
