using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1; 
    public int bulletsOf1 = 50;
    public int bulletsOf2 = 50;
    public int bulletsOf3 = 50; 

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

                    return true;
                }
                break;
            case 2:
                if (bulletsOf2 > 0)
                {
                    bulletsOf2--;
                    Debug.Log(bulletsOf2 + " #2 bullets left");
                    return true;
                }
                break;
            case 3:
                if (bulletsOf3 > 0)
                {
                    bulletsOf3--;
                    Debug.Log(bulletsOf3 + " #3 bullets left");
                    return true;
                }
                break;
        }
        return false;
    }
}
