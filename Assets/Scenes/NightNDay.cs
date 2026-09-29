using NUnit.Framework.Internal;
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Threading;
using Unity.Mathematics;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UIElements;


public class NightNDay : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public GameObject Plr;
    public GameObject Barrier;

    public SpriteRenderer PlrSR;
    public SpriteRenderer BarrierSR;

    public bool NightMode = false;
    public bool DayMode = true;

    public bool DayBarrier = true;
    public bool NightBarrier = false; 

    public bool change = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PlrSR = Plr.GetComponent<SpriteRenderer>();
        BarrierSR = BarrierSR.GetComponent<SpriteRenderer>();
        PlrSR.color = Color.yellow;
        BarrierSR.color = Color.blue;
    }
    


    // Update is called once per frame
    void Update()
    {
        if(PlrSR.color == Color.yellow)
        {
            DayMode = true;
        }
        if (PlrSR.color == Color.blue)
        {
            NightMode = true;
        }
        if(BarrierSR.color == Color.blue)
        {
            NightBarrier = true;
        }
        if(BarrierSR.color == Color.yellow)
        {
            DayBarrier = true;
        }

        ChangeColorPLR(DayMode, NightMode);
        ChangeColorBarrier(DayBarrier, NightBarrier);

    }
    void ChangeColorPLR(bool Daymode, bool Nightmode)
    {

        if (Daymode && Input.GetKeyDown(KeyCode.Space))

        {
            PlrSR.color = Color.blue;
            DayMode = false;
        }
        if (Nightmode && Input.GetKeyDown(KeyCode.Space))
        {
            PlrSR.color = Color.yellow;
            NightMode = false; 
        }
    }
    void ChangeColorBarrier(bool Night, bool Day)
    {
        float passedtime = Time.time;
        if(passedtime >= 0.5f)
        {
            change = true;
            passedtime = 0f;
        }
        if(Night && change)
        {

            int randomnumber = UnityEngine.Random.Range(5, 11);
            StartCoroutine(NightToDay(randomnumber));
            
        }
        if (Day && change)
        {
            int randomnumber = UnityEngine.Random.Range(5, 11);
            StartCoroutine(DayToNight(randomnumber));
            

        }
    }
    IEnumerator NightToDay(int randomnumber)
    {
        
        yield return new WaitForSeconds(randomnumber);
        BarrierSR.color = Color.yellow;
        NightBarrier = false;
        Debug.Log("Daytime");

    }
    IEnumerator DayToNight(int randomnumber)
    {
        yield return new WaitForSeconds(randomnumber);
        BarrierSR.color = Color.blue;
        DayBarrier = false;
        Debug.Log("Nighttime");

    }

}
