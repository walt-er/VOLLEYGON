using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadScript : MonoBehaviour
{
    public GameObject explosionPrefab;
	private int hitCount;
    private bool isAvailable = true;
    private bool isDone = false;
    public bool isFading = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll){
    	if (coll.gameObject.tag == "Ball" && isAvailable){
            // Trigger explosion here
            Quaternion parentRot = transform.rotation;
            GameObject explosion = (GameObject)Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), parentRot);
            if (GetComponent<ChangeColorScript>())
            {
                ParticleSystem.MainModule settings = explosion.GetComponent<ParticleSystem>().main;
                settings.startColor = HexToColor(GetComponent<ChangeColorScript>().hexCode);
            }

            FadeOut();
    	}
	}

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }
    public void FadeOut()
    {
        isAvailable = false;
        if (!isFading)
        {
            isFading = true;
            //iTween.MoveTo(gameObject,iTween.Hash("x",3,"time",4,"delay",1,"onupdate","myUpdateFunction","looptype",iTween.LoopType.pingPong));
            iTween.FadeTo(gameObject, iTween.Hash("alpha", 0, "time", 0.5, "onComplete", "Disappear"));
        }
    }
}
