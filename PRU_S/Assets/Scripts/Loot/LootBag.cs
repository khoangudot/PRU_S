using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject dropItemsPrefabs;
    public List<Weapon> weaponsList = new List<Weapon>();
    public GameObject weaponPrefab;
    public Player player;
    Weapon GetDropItem()
    {
        int randomNumber = Random.Range(1,100);
        List<Weapon>possibleItems = new List<Weapon>(); 
        foreach(Weapon item in weaponsList)
        {
            if(randomNumber<= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            Weapon droppedItem = possibleItems[Random.Range(0,possibleItems.Count)];
            return droppedItem;
        }
        return null;
    }
    

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Weapon droppedItem = GetDropItem();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(weaponPrefab, spawnPosition, Quaternion.identity);


            // Tìm đối tượng con chứa SpriteRenderer trong "image"
            Transform imageTransform = lootGameObject.transform.Find("Image");
            if (imageTransform != null)
            {
                SpriteRenderer spriteRenderer = imageTransform.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.sprite = droppedItem.weaponSprite;
                }
                else
                {
                    Debug.LogWarning("No SpriteRenderer found in the 'image' child.");
                }
            }
            else
            {
                Debug.LogWarning("No 'image' child found in the lootGameObject.");
            }

            float dropForce = 300f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


}
