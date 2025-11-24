using System;
using System.Threading.Tasks;

// ----------------------------------------------------
// 1. ОПРЕДЕЛЕНИЕ КЛАССА ДАННЫХ (RestaurantOrder)
// ----------------------------------------------------

public class RestaurantOrder
{
    private TaskCompletionSource<string> _orderTcs = new TaskCompletionSource<string>();
    public Task<string> OrderStatus => _orderTcs.Task;

    public void StartCooking(bool hasIngredients)
    {
        Console.WriteLine("\n[Повар] Принял заказ, начинаю готовить...");

        Task.Run(() =>
        {
            Task.Delay(1500).Wait();

            if (hasIngredients)
            {
                Console.WriteLine("[Повар] Заказ готов! Сигнализирую.");
                _orderTcs.SetResult("Заказ завершен. Приятного аппетита!");
            }
            else
            {
                Console.WriteLine("[Повар] Черт, нет соуса! Отправляю отмену.");
                _orderTcs.SetException(
                    new InvalidOperationException("Нет нужного соуса. Отмена заказа.")
                );
            }
        });
    }
}

// ----------------------------------------------------
// 2. ГЛАВНЫЙ КЛАСС ПРОГРАММЫ (Переименован в AppStarter)
// ----------------------------------------------------

public class AppStarter // <--- ИЗМЕНЕНО С 'Program'
{
    // Вспомогательный метод для запуска теста
    static async Task RunTcsTest(string name, bool ingredients)
    {
        Console.WriteLine($"\n--- ЗАПУСК ТЕСТА: {name} ---");

        RestaurantOrder order = new RestaurantOrder();
        order.StartCooking(ingredients);

        try
        {
            string status = await order.OrderStatus;
            Console.WriteLine($"✅ [РЕЗУЛЬТАТ]: {status}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ [ОШИБКА]: {ex.Message}");
        }
    }

    // ЯВНЫЙ МЕТОД MAIN
    static async Task Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("       ИНТЕРАКТИВНЫЙ ТЕСТ TCS (ЗАПУЩЕН)");
        Console.WriteLine("=================================================");

        while (true)
        {
            Console.Write("\nВведите название заказа (или 'exit' для выхода): ");
            string? orderName = Console.ReadLine();

            if (orderName == null || orderName.ToLower() == "exit")
            {
                break;
            }

            Console.Write("Есть ли ингредиенты? (y/n): ");
            string? input = Console.ReadLine();

            bool hasIngredients = (input?.ToLower() == "y" || input?.ToLower() == "yes");

            await RunTcsTest(orderName, hasIngredients);
        }

        Console.WriteLine("\nПрограмма завершена.");
    }
}