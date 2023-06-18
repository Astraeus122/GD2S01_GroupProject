using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    // Different enemy types -- Apendix 2
    public enum EnemyType
    {
        BasicEnemy, // Your current enemy
        AdvancedEnemy, // A new, more powerful enemy
                       // Add more enemy types as needed following a  similar pattern
    }
    // List of observers that are observing this enemy
    private List<IObserver<Enemy>> observers = new List<IObserver<Enemy>>();

    // Enemy stats
    private int health;
    private int damage;
    public string Name { get; private set; }

    // Setters
    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    // Constructor to set initial values
    public Enemy(int health, int damage)
    {
        this.health = health;
        this.damage = damage;
    }

    public void Initialize(int health, int damage, string name)
    {
        SetHealth(health);
        SetDamage(damage);
        this.Name = name;

        Debug.Log("Enemy " + Name + " has been initialized with " + health + " health and " + damage + " damage.");
    }

    public void Attack()
    {
        Debug.Log("Enemy " + Name + " is attacking!");
    }

    // Method for an observer to subscribe to this enemy
    public IDisposable Subscribe(IObserver<Enemy> observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
        return new Unsubscriber<Enemy>(observers, observer);
    }

    // Method to notify observers of a state change
    protected virtual void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnNext(this);
        }
    }

    // Additional methods for actions the enemy can take
}

internal class Unsubscriber<Enemy> : IDisposable
{
    private List<IObserver<Enemy>> _observers;
    private IObserver<Enemy> _observer;

    internal Unsubscriber(List<IObserver<Enemy>> observers, IObserver<Enemy> observer)
    {
        this._observers = observers;
        this._observer = observer;
    }

    public void Dispose()
    {
        if (_observers.Contains(_observer))
            _observers.Remove(_observer);
    }
}
