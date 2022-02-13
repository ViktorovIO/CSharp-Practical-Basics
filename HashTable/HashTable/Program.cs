using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем новую хеш таблицу
            var hashTable = new HashTable();

            // Добавляем данные в хеш таблицу в виде пар Ключ/Значение
            hashTable.Insert("Лев Толстой", "Волей-неволей человек должен признать, что жизнь его не ограничивается его личностью от рождения и до смерти и что цель, сознаваемая им, есть цель достижимая и что в стремлении к ней — в сознании большей и большей своей греховности и в большем и большем осуществлении всей истины в своей жизни и в жизни мира и состоит и состояло и всегда будет состоять дело его жизни, неотделимой от жизни всего мира.");
            hashTable.Insert("Борис Пастернак", "Жить и сгорать у всех в обычае, Но жизнь тогда лишь обессмертишь, Когда ей к свету и величию Своею жертвой путь прочертишь.");
            hashTable.Insert("Джордж Бернард Шоу", "Ты не научишься кататься на коньках, если боишься быть смешным. Лед жизни скользок.");
            hashTable.Insert("Фредерик Стендаль", "Очень малой степени надежды достаточно, чтобы вызвать к жизни любовь. Через два-три дня надежда может исчезнуть; тем не менее любовь уже родилась.");

            // Выводим значения на экран
            ShowHashTable(hashTable, "Хэш-таблица создана.");
            Console.ReadLine();

            // Удаляем элемент с ключом "Фредерик Стендаль" из хеш таблицы и выводим измененную таблицу на экран
            hashTable.Delete("Фредерик Стендаль");
            ShowHashTable(hashTable, "Удаление элемента и хэш-таблицы.");
            Console.ReadLine();

            // Получаем значение из таблицы по ключу
            Console.WriteLine("Лев Толстой когда-то написал:");
            var text = hashTable.Search("Лев Толстой");
            Console.WriteLine(text);
            Console.ReadLine();

            // Добавим еще одно значение с индексным ключом
            hashTable.Insert("Федор Достоевский", "Описание цветка с любовью к природе гораздо более заключает в себе гражданского чувства, чем обличение взяточников…");

            // Выводим значения
            ShowHashTable(hashTable, "Добавлен новый элемент. ");
            Console.ReadLine();

            // Конец программы
            Console.WriteLine("Для выхода из программы нажмите Enter");
            Console.ReadLine();
        }

        /// <summary>
        /// Выводим хеш-таблицу.
        /// </summary>
        /// <param name="hashTable"> Хеш таблица. </param>
        /// <param name="title"> Заголовок перед выводом таблицы. </param>
        private static void ShowHashTable(HashTable hashTable, string title)
        {
            // Проверяем входные аргументы.
            if (hashTable == null)
            {
                throw new ArgumentNullException(nameof(hashTable));
            }

            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            // Выводим все имеющиеся пары ключ/значение
            Console.WriteLine(title);
            foreach (var item in hashTable.Items)
            {
                // Выводим хеш
                Console.WriteLine(item.Key);

                // Выводим значения
                foreach (var value in item.Value)
                {
                    Console.WriteLine($"\t 'Ключ: '{value.Key} :: 'Значение: '{value.Value}");
                }
            }
            Console.WriteLine();
        }
    }
}
