using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy:MonoBehaviour
{
    void Start()
    {
        TypeFactory typeFactory = new TypeFactory();
        SizeFactory sizeFactory = new SizeFactory();

        Cube cube = (Cube)typeFactory.GetMonster((int)Type.Cube).DateItem;
        cube.GetInfo();

        Sphere sphere = (Sphere)typeFactory.GetMonster((int)Type.Sphere).DateItem;
        sphere.GetInfo();

        Big big = (Big)sizeFactory.GetMonster((int)Size.Big).DateItem;
        big.GetInfo();

        Medium medium = (Medium)sizeFactory.GetMonster((int)Size.Medium).DateItem;
        medium.GetInfo();

        Small small = (Small)sizeFactory.GetMonster((int)Size.Small).DateItem;
        small.GetInfo();

        GameObject monster = GameObject.CreatePrimitive(sphere.GetInfo());
        monster.transform.position = new Vector3(0, 1.5f, 0);
        float size = medium.GetInfo();
        monster.transform.localScale = new Vector3(size,size,size);
    }
    class MonsterFactoryDateItem
    {
        public MonsterFactoryDateItem(object dataItem)
        {
            _dateItem = dataItem;
        }
        private object _dateItem;
        public object DateItem { get { return _dateItem; } }
    }
    interface MonsterFactory
    {
        MonsterFactoryDateItem GetMonster(int type);
    }

    abstract class AbstractMonsterFactory : MonsterFactory
    {
        public abstract MonsterFactoryDateItem GetMonster(int type);
    }
    class TypeFactory : AbstractMonsterFactory
    {
        public override MonsterFactoryDateItem GetMonster(int type)
        {
            MonsterFactoryDateItem monsterFactoryDateItem = null;

            switch ((Type)type)
            {
                case Type.Cube:
                    monsterFactoryDateItem = new MonsterFactoryDateItem(new Cube());
                    break;
                case Type.Sphere:
                    monsterFactoryDateItem = new MonsterFactoryDateItem(new Sphere());
                    break;
            }

            return monsterFactoryDateItem;
        }
    }


    class SizeFactory : AbstractMonsterFactory
    {
        public override MonsterFactoryDateItem GetMonster(int size)
        {
            MonsterFactoryDateItem monsterFactoryDateItem = null;

            switch ((Size)size)
            {
                case Size.Big:
                    monsterFactoryDateItem = new MonsterFactoryDateItem(new Big());
                    break;
                case Size.Medium:
                    monsterFactoryDateItem = new MonsterFactoryDateItem(new Medium());
                    break;
                case Size.Small:
                    monsterFactoryDateItem = new MonsterFactoryDateItem(new Small());
                    break;
            }

            return monsterFactoryDateItem;
        }
    }



    #region Type
    enum Type
    {
        Sphere = 1,
        Cube = 2

    }
    class Sphere
    {
        public PrimitiveType GetInfo()
        {
            return PrimitiveType.Sphere;
        }
    }

    class Cube
    {
        public PrimitiveType GetInfo()
        {
            return PrimitiveType.Cube;
        }
    }


    #endregion Type

    #region Size
    enum Size {
        Big=1,
        Medium = 2,
        Small = 3
    }

    class Big
    {
        public int GetInfo()
        {
            return 3;
        }
    }

    class Medium
    {
        public int GetInfo()
        {
            return 2;
        }
    }

    class Small
    {
        public int GetInfo()
        {
            return 1;
        }
    }
    #endregion Size

}
