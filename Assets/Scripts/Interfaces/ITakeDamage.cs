using System;

public interface ITakeDamage
{
    public event EventHandler<float> OnDamageTaken;
    public void TakeDamage(float damage);
}