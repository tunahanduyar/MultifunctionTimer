using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class zamanlayici : MonoBehaviour


{
    public int reklambutonusaniyesi;
    int skorumuz;
    public Text skor_text;
    public float timer;
    private Text timersecond;
    AudioSource zamanlayicisesi;
    public AudioClip gerisayim;
    public GameObject sureekle;
    public GameObject sureeklemeanimasyonu;
    public GameObject timeryokol;


    void Start()
    {

        

        if (PlayerPrefs.HasKey("skor"))
        {
            skorumuz = PlayerPrefs.GetInt("skor");
            skor_text.text = skorumuz.ToString("d4");
        }
        else
        {
            PlayerPrefs.SetInt("skor", 10); 
            skor_text.text =  PlayerPrefs.GetInt("skor").ToString("d4");
        }

        timersecond = GetComponent<Text>();
        zamanlayicisesi = gameObject.GetComponent<AudioSource>();


       

    }

    void Update()
    {

        timer -= Time.deltaTime;
        timersecond.text = timer.ToString("f0");

        {

            if (timer <= reklambutonusaniyesi)

           {

               if (skorumuz >= 0005)

                {
                    sureekle.SetActive(true);

                }

           }
            

            if (timer <= 5)

            {

                if (!zamanlayicisesi.isPlaying)

                {
                    zamanlayicisesi.PlayOneShot(gerisayim);

                }

              GetComponent<Text>().color = Color.red;


            }


        }

        if (timer <= 0)
        
        {


          
            SceneManager.LoadScene("kaybetti");
            zamanlayicisesi.Stop();
            timer = 0;
            

        }
    }


    public void azalt()

    {

        if (skorumuz >= 5)
        {

            skorumuz -= 0005;
            PlayerPrefs.SetInt("skor", skorumuz);
            skor_text.text = skorumuz.ToString("d4");
            timeryokol.SetActive(false);
            zamanlayicisesi.Stop();
            sureekle.SetActive(false);
            sureeklemeanimasyonu.SetActive(true);
            Invoke("kapat", 1f);

         
        }

    }

    public void kapat()

        {
            sureeklemeanimasyonu.SetActive(false);

        }


    }
