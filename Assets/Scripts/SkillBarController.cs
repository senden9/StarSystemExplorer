using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarController : MonoBehaviour
{

    public Image ImageCooldown;
    bool isCooldown;
    public Text cooldownCounter;
    public float cooldown;
    private float cooldownNumber;
    public string key;

    void Start()
    {
        cooldownNumber = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown == false)
        {
            cooldownNumber = cooldown;
            cooldownCounter.text = "";
        }
        if (Input.GetKeyDown(key))
        {
            isCooldown = true;
        }

        if (isCooldown)
        {
            if (ImageCooldown.fillAmount == 0) {
                ImageCooldown.fillAmount = 1;
            }
            ImageCooldown.fillAmount =ImageCooldown.fillAmount - ( 1 / cooldown * Time.deltaTime);

            //if (ImageCooldown.fillAmount >= 1)
            //{
            //    ImageCooldown.fillAmount = 0;
            //    isCooldown = false;

            //}
            if (ImageCooldown.fillAmount <= 0)
            {
                isCooldown = false;
            }
            cooldownNumber -= Time.deltaTime;
            SetCountText();
        }

    }

    void SetCountText()
    {
        cooldownCounter.text = cooldownNumber.ToString();
    }
}
