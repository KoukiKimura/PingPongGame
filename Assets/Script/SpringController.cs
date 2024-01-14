using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
	
	// Materialを入れる
	Material myMaterial;
	// ターゲットのデフォルトの色
	Color defaultColor = Color.white;
	
	float plungerY = 3.5f;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
        this.defaultColor = Color.white;
        // オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer> ().material;
        
        // オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor*minEmission);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
        	plungerY = Mathf.Clamp(plungerY + 0.5f, -3.5f, 0);
        	
        	pos.y = plungerY;
        }
        else
        {
        	plungerY = Mathf.Clamp(plungerY - 1, -3.5f, 0);
        	pos.y = plungerY;
        }
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(pos);
        
		// 光らせる強度を計算する
		Color emissionColor = 
		this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);

		// エミッションに色を設定する
		myMaterial.SetColor ("_EmissionColor", emissionColor);

    }
}
