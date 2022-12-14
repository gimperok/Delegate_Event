using Delegate_Event;

Account acc1 = new Account(200);  //создаем банковский счет с указанной суммой

acc1.Notify += PrintConsole;  //добавляем в событие метод, который будет уведомлять об операциях

acc1.Put(100);       //кладем на счет 100 у.е.
Thread.Sleep(1000); //добавляем небольшую задержку

acc1.Take(180);       //пытаемся снять со счета 180 у.е. (Операция проходит успешно, т.к средств хватает)
Thread.Sleep(1000);  //добавляем небольшую задержку

acc1.Take(200);  //пытаемся снять со счета 200 у.е. (Отказ. Недостаточно средств на счете)

void PrintConsole(string text) => Console.WriteLine(text); //создаем метод, который соответствует по сигнатуре делегату AccountHandler