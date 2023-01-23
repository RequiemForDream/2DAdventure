using System;

public class EventManager 
{   
    public static event Action<int> OnMoneyChanged;
       
    public static void SendMoneyChanged(int money)
    {
        OnMoneyChanged?.Invoke(money);
    }
}
