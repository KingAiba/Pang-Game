using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalInput;

    public float xLimit = 13.0f;

    public int maxHP = 10;
    public int currHP = 5;

    public bool isDead = false;

    public bool isInvincible = false;
    public float invincTime = 2;

    public GameObject projectilePrefab;
    private GameObject currProjectile;

    public TMP_Text HPtext;
    
    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
        HPtext.SetText("HP: " + currHP + "/" + maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            MovePlayer();
            FireProjectile();         
        }

    }

    public void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        if(transform.position.x >= xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
    }

    public void FireProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Space) && currProjectile == null)
        {
            currProjectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    public void AddHealth(int val)
    {
        if(!isInvincible)
        {
            currHP += val;
            HPtext.SetText("HP: " + currHP + "/" + maxHP);
            StartCoroutine(InvincibleTimer());
            if (currHP <= 0)
            {
                currHP = 0;
                isDead = true;
            }
        }
    }

    private IEnumerator InvincibleTimer()
    {
        isInvincible = true;
        Debug.Log("is invinc");
        yield return new WaitForSeconds(invincTime);
        Debug.Log("not invinc");
        isInvincible = false;
    }
}
