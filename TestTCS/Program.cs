using System;
using System.Threading.Tasks;

public class RestaurantOrder
{
    // TCS для управления Task<string> (возвращает статус заказа)
    private TaskCompletionSource<string> _orderTcs = new TaskCompletionSource<string>();

    // Task, который внешний код будет ожидать
    public Task<string> OrderStatus => _orderTcs.Task;

    // Метод, который имитирует внешнюю/долгую работу
    public void StartCooking(bool hasIngredients)
    {
        Console.WriteLine("Повар: Принял заказ, начинаю готовить...");

        // Имитируем работу в фоновом режиме (можно заменить на реальный I/O или поток)
        Task.Run(() =>
        {
            // Имитация задержки приготовления
            Task.Delay(1500).Wait();

            if (hasIngredients)
            {
                // Успех: Нажимаем кнопку "ГОТОВО" на пульте TCS
                _orderTcs.SetResult("Заказ завершен. Приятного аппетита!");
            }
            else
            {
                // Ошибка: Нажимаем кнопку "ОШИБКА" на пульте TCS
                _orderTcs.SetException(
                    new InvalidOperationException("Нет нужного соуса. Отмена заказа.")
                );
            }
        });
    }
}