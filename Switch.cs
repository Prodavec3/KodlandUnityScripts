using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject rifle;
    [SerializeField] GameObject uzi;

    public enum Weapon { Pistol, Shotgun, Rifle, Uzi };
    Weapon weapon;
    int level = 0;
    // Start is called before the first frame update
    public void LevelUp()
    {
        level += 1;
        if (level > 4)
        {
            level = 4;
        }
        switch (level)
        {
            case 1:
                ChooseWeapon(Weapon.Pistol);
                break;
            case 2:
                ChooseWeapon(Weapon.Shotgun);
                break;
            case 3:
                ChooseWeapon(Weapon.Rifle);
                break;
            case 4:
                ChooseWeapon(Weapon.Uzi);
                break;
            default:
                print("Такого уровня нет");
                break;
        }
    }
    void Start()
    {
        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChooseWeapon(Weapon.Pistol);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChooseWeapon(Weapon.Shotgun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChooseWeapon(Weapon.Rifle);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChooseWeapon(Weapon.Uzi);
        }
        if (Input.GetMouseButton(0))
        {
            switch (weapon)
            {
                case Weapon.Pistol:
                    pistol.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Shotgun:
                    shotgun.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Uzi:
                    uzi.GetComponent<Gun>().Shoot();
                    break;
            }
        }
    }

    public void ChooseWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        switch (weapon)
        {
            case Weapon.Pistol:
                pistol.SetActive(true);
                shotgun.SetActive(false);
                rifle.SetActive(false);
                uzi.SetActive(false);
                break;
            case Weapon.Shotgun:
                pistol.SetActive(false);
                shotgun.SetActive(true);
                rifle.SetActive(false);
                uzi.SetActive(false);
                break;
            case Weapon.Rifle:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(true);
                uzi.SetActive(false);
                break;
            case Weapon.Uzi:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(false);
                uzi.SetActive(true);
                break;
            default:
                print("Такого оружия нет");
                break;
        }
    }
}
