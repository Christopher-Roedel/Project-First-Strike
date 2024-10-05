using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour
{

    private TMP_Text text;
    public int currentMag;
    public int currentReserves;
    public int maxAmmo;
    public int magSize;
    string continuityZero = "";
    string continuityZeroZero = "";

    int reloadTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = currentMag + " | " + currentReserves;

        InvokeRepeating("SimulateAmmoUse", 0, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SimulateAmmoUse()
    {
        
        if(currentMag > 0)
        {
            currentMag -= 1;
        }
        else
        {
            reloadTimer += 1;
            if(reloadTimer >= 5)
            {
                reloadTimer = 0;
                int transferAmmo = magSize;
                if(currentReserves - magSize <= 0)
                {
                    transferAmmo = currentReserves;
                }

                currentMag = transferAmmo;
                currentReserves -= transferAmmo;
            }
        }

        if(currentMag < 10)
        {
            continuityZero = "0";
        }
        else
        {
            continuityZero = "";
        }

        if(currentReserves < 100)
        {
            if(currentReserves < 10)
            {
                continuityZeroZero = "00";
            }
            else
            {
                continuityZeroZero = "0";
            }
        }
        else
        {
            continuityZeroZero = "";
        }

        text.text = continuityZero + currentMag + " | " + continuityZeroZero + currentReserves;
    }
}
