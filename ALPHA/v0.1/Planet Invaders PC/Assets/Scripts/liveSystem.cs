using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class liveSystem : MonoBehaviour
{
    // Start is called before the first frame update

    private int maxHeartAmount = 10;
    public int startHearts = 3;
    public int curHealth;
    private int maxHealth;
    private int healthPerHeart = 2;
    public bool isEnemy = true;

    public Image[] healthImages;
    public Sprite[] healthSprites;

    void Start()
    {
        curHealth = startHearts * healthPerHeart;
        maxHealth = maxHeartAmount * healthPerHeart;
        checkHealthAmount();
    }

    void checkHealthAmount()
    {
        for (int i = 0; i < maxHeartAmount; i++)
        {
            if (startHearts <= i)
            {
                healthImages[i].enabled = false;
            }
            else
            {
                healthImages[i].enabled = true;
            }
        }
        UpdateHearts();
    }

    void UpdateHearts() {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthImages) {
            if (empty) {
                image.sprite = healthSprites[0];
            }
            else
            {
                i++;
                if (curHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - curHealth));
                    int healtPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healtPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }

    public void TakeDamage(int amount) {
        curHealth -= amount;
        curHealth = Mathf.Clamp(curHealth, 0, startHearts * healthPerHeart);
        if (curHealth <= 0) {
            SpecialEffects.Instance.Explosion(transform.position);
            Destroy(gameObject);

        }
        UpdateHearts();
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        WeaponShotFire shot = otherCollider.gameObject.GetComponent<WeaponShotFire>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                TakeDamage(shot.damage);
                scoreScript.scoreValue += 1;
                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }
}
