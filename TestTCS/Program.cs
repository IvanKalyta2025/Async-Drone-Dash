using System;
using System.Threading.Tasks;

// Определяем пространство имен, которое содержит все наши классы и методы.
namespace AsyncTcsExample
{
    // ----------------------------------------------------
    // 1. ОПРЕДЕЛЕНИЕ КЛАССА (RestaurantOrder)
    // ----------------------------------------------------

    public class RestaurantOrder
    {
        // TaskCompletionSource (Пульт) для управления Task<string>
        private TaskCompletionSource<string> _orderTcs = new TaskCompletionSource<string>(); //тут мы будем управлять завершением ордера.

        // Свойство Task, которое внешний код будет await'ить
        public Task<string> OrderStatus => _orderTcs.Task; //то чего мы ожидаем завершения и цекаем это 

        public void StartCooking(bool hasIngredients)
        {
            Console.WriteLine("Повар: Принял заказ, начинаю готовить...");

            Task.Run(() =>
            {
                // Имитация задержки (приготовление)
                Task.Delay(1500).Wait();

                if (hasIngredients)
                {
                    Console.WriteLine("Повар: Заказ готов! Сигнализирую официанту.");
                    _orderTcs.SetResult("Заказ завершен. Приятного аппетита!");
                }
                else
                {
                    Console.WriteLine("Повар: Черт, нет соуса! Отправляю отмену.");
                    _orderTcs.SetException(
                        new InvalidOperationException("Нет нужного соуса. Отмена заказа.")
                    );
                }
            });
        }
    }

    // ----------------------------------------------------
    // 2. ВСПОМОГАТЕЛЬНЫЙ МЕТОД ДЛЯ ТЕСТИРОВАНИЯ
    // ----------------------------------------------------

    public class Program
    {
        // Метод для запуска одного теста и обработки результатов
        static async Task RunTcsTest(string name, bool ingredients)
        {
            Console.WriteLine($"\n--- Запуск теста: {name} ---");

            RestaurantOrder order = new RestaurantOrder();
            order.StartCooking(ingredients);

            try
            {
                // await ждет, пока кто-то вручную не вызовет SetResult или SetException
                string status = await order.OrderStatus;

                Console.WriteLine($"✅ [РЕЗУЛЬТАТ]: {status}");
            }
            catch (Exception ex)
            {
                // Ловим ошибку, переданную через SetException
                Console.WriteLine($"❌ [ОШИБКА]: {ex.Message}");
            }
        }

        // ----------------------------------------------------
        // 3. ТОЧКА ВХОДА (Явный Async Main)
        // ----------------------------------------------------
        static async Task Main(string[] args)
        {
            // Запуск обоих сценариев (успех и провал)
            await RunTcsTest("Заказ А (Успех)", true);
            await RunTcsTest("Заказ Б (Провал)", false);

            Console.WriteLine("\nТесты завершены.");
        }
    }
}