using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int level = 1; 
    public int bulletsOf1 = 50;
    public int bulletsOf2 = 50;
    public int bulletsOf3 = 50;

    public Text bulletText1;
    public Text bulletText2;
    public Text bulletText3;

    void Start()
    {
        UpdateBulletTexts();
    }

    public void AdvanceLevel()
    {
        level++;
        Debug.Log("Level advanced");
    }

    public void DropLevel()
    {
        level = Mathf.Max(1, level - 1);
        Debug.Log("Level decreased");
    }

    public bool UseBullet(int bulletType)
    {
        switch (bulletType)
        {
            case 1:
                if (bulletsOf1 > 0)
                {
                    bulletsOf1--;
                    Debug.Log(bulletsOf1 + " #1 bullets left");
                    UpdateBulletTexts();
                    return true;
                }
                break;
            case 2:
                if (bulletsOf2 > 0)
                {
                    bulletsOf2--;
                    Debug.Log(bulletsOf2 + " #2 bullets left");
                    UpdateBulletTexts();
                    return true;
                }
                break;
            case 3:
                if (bulletsOf3 > 0)
                {
                    bulletsOf3--;
                    Debug.Log(bulletsOf3 + " #3 bullets left");
                    UpdateBulletTexts();
                    return true;
                }
                break;
        }
        return false;
    }

    void UpdateBulletTexts()
    {
        bulletText1.text = bulletsOf1.ToString();
        bulletText2.text = bulletsOf2.ToString();
        bulletText3.text = bulletsOf3.ToString();
    }
}
