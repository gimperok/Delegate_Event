using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Event
{
    internal class Account
    {
        public int Sum { get; set; }  //свойство для хранения суммы на счете

        public Account(int sum)
        {
            Sum = sum;
        }

        public event AccountHandler? Notify;  //создаем событие

        internal void Put(int sum)  //метод пополнения баланса
        {
            Sum += sum;
            Notify?.Invoke($"На ваш счет поступило {sum}$. Ваш баланс: {Sum}");  //вызываем событие
        }

        internal void Take(int sum)  // метод для снятия валюты
        {
            if (sum <= Sum)
            {
                Sum -= sum;
                Notify?.Invoke($"С вашего счета было снято: {sum}$. Баланс: {Sum}$.");  //если удалось снять сумму, вызываем событие
            }
            else Notify?.Invoke($"Вы пытаетесь снять {sum}$. Недостаточно средств! Ваш баланс {Sum}$.");  //если сумму снять не удалось, вызываем событие
        }

        public delegate void AccountHandler(string message);  //создаем делегат, который принимает сообщение
    }
}
