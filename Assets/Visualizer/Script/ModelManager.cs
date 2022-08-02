using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModelManager : MonoBehaviour
{
   

    [SerializeField]
    public GameObject[] models;

    public GameObject canvas;

    [SerializeField]
    private ParticleSystem smoke;

    private float timer = 0;
    
    public float timeToSwitchModels = 5f;

    public int currentModelIndex = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < models.Length; i++)
        {
            if (i == currentModelIndex)
            {
                models[i].SetActive(true);
            }
            else
                models[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

       
           

        if (timer > timeToSwitchModels)
        {
            smoke.Play();
            if (currentModelIndex < models.Length - 1)
            {
                currentModelIndex++;
            }
            else
            {
                currentModelIndex = 0;
            }

            for (int i = 0; i < models.Length; i++)
            {
                if (i == currentModelIndex)
                {
                    models[i].SetActive(true);

                }
                else
                    models[i].SetActive(false);


            }


            timer = 0;
        }

        
    }

    private IEnumerator ChangeModel()
    {
        yield return new WaitForSeconds(0.0f);
        currentModelIndex++;
    }

    //public void SensUp()
    //{
    //    for(int i = 0; i < modelScripts.Length; i++)
    //    {
    //        modelScripts[i].sensitivity += 10;
    //    }
    //}

    //public void SensDown()
    //{
    //    for (int i = 0; i < modelScripts.Length; i++)
    //    {
    //        modelScripts[i].sensitivity -= 10;
    //    }
    //}

    //public void DepthUp()
    //{
    //    for (int i = 0; i < modelScripts.Length; i++)
    //    {
    //        modelScripts[i].zDepth += 10;
    //    }
    //}

    //public void DepthDown()
    //{
    //    for (int i = 0; i < modelScripts.Length; i++)
    //    {
    //        modelScripts[i].zDepth -= 10;
    //    }
    //}
}
