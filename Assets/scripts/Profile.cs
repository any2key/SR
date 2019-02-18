using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Any2key.Game.Api;
using System.IO;
public class Profile
{

    private string _nickName;
    private Skills _skills;
    private Character _character;
    private Guid _guid;

    public delegate void ProfileStateChangedHandler();
    public static event ProfileStateChangedHandler ProfileStateChanged;


    public Profile()
    {
        _nickName = "B4D_m4zaFaka";
        _skills = new Skills();
        _character = new Character();
        _guid = Guid.NewGuid();
        ProfileStateChanged += DoSomething;
        _skills.SkillsStateChanged += AnotherInvoke;
        _character.CharacterStateChanged += AnotherInvoke;
    }

    public string NickName
    {
        get { return _nickName; }
        set
        {
            _nickName = value;
            if (ProfileStateChanged != null)
                ProfileStateChanged();
        }
    }
    public Skills Skills
    {
        get { return _skills; }
        set
        {
            _skills = value;
            if (ProfileStateChanged != null)
                ProfileStateChanged();
        }
    }
    public Character Character
    {
        get { return _character; }
        set
        {
            _character = value;
            if (ProfileStateChanged != null)
                ProfileStateChanged();
        }
    }
    public Guid Guid
    {
        get { return _guid; }

        set
        {
            _guid = value;
            if (ProfileStateChanged != null)
                ProfileStateChanged();
        }
    }


    public void DoSomething() { }
    public void AnotherInvoke() { ProfileStateChanged(); }
}

public class Skills
{

    public delegate void SkillsStateChangedHandler();
    public event SkillsStateChangedHandler SkillsStateChanged;

    public Skills()
    {
        _armor = 1;
        _weapon = 1;
        _rof = 1;
        _commerce = 1;
        _speed = 1;
        SkillsStateChanged += DoSomething;

    }
    private int _armor, _weapon, _rof, _commerce, _speed;


    public int Armor
    {
        get { return _armor; }
        set
        {
            _armor = value;
            if (SkillsStateChanged != null)
                SkillsStateChanged();
        }
    }

    public int Weapon
    {
        get { return _weapon; }
        set
        {
            _weapon = value;
            if (SkillsStateChanged != null)
                SkillsStateChanged();
        }
    }
    public int Rof
    {
        get { return _rof; }
        set
        {
            _rof = value;
            if (SkillsStateChanged != null)
                SkillsStateChanged();
        }
    }
    public int Commerce
    {
        get { return _commerce; }
        set
        {
            _commerce = value; if (SkillsStateChanged != null)
                SkillsStateChanged();
        }
    }
    public int Speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
            if (SkillsStateChanged != null)
                SkillsStateChanged();
        }
    }

    public void DoSomething() { }

}