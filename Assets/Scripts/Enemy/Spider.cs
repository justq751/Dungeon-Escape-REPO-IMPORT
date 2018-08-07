using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidPrefab;

    //Элемент интерфейса
    public int Health { get; set; }

    //Использовать для инициализации
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    //Оверрайд чтобы избавиться от предупреждения
    public override void Update()
    {

    }

    public override void Movement()
    {
        
    }

    public void Attack()
    {
        Instantiate(acidPrefab, transform.position, Quaternion.identity);
    }

    //Элемент интерфейса
    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }

        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }

    
}
