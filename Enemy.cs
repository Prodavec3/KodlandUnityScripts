using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int damage; //урон который враг наносит
    protected int health; //здоровье врага
    protected GameObject player; //Информация о игроке
    bool dead = false; //Мертвый ли враг

    public virtual void Move() //Враг может как-то двигаться
    {

    }
    public virtual void Attack() //Враг может как-то атаковать
    {

    }
    public void OnDeath() //Умирают враги одинаково
    {
        dead = true;
        GetComponent<Animator>().SetTrigger("Death"); //изменили параметр анимации
        GetComponent<CharacterController>().enabled = false; //отключили коллайдер
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject; //Находим игрока
    }

    private void Update() //Если враг не мертв, он двигается и атакует
    {
        if (!dead)
        {
            Move();
            Attack();
        }
    }
}
