using System;

public interface ITakeDamage
{
    public event Action<float> OnDamageTaken;
    public void TakeDamage(float damage);
}