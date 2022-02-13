using System;

namespace HashTable
{
    /// <summary>
    /// Элемент данных хеш таблицы
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Ключ
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Создаем новый экземпляр Item
        /// </summary>
        /// <param name="key"> Ключ </param>
        /// <param name="value"> Значение </param>
        public Item(string key, string value)
        {
            // Проверяем входные данные на корректность
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            // Устанавливаем значения
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Приводим объект к строке
        /// </summary>
        /// <returns> Возвращается ключ объекта </returns>
        public override string ToString()
        {
            return Key;
        }
    }
}
