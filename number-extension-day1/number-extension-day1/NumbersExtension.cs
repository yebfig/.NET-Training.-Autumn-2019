//Даны два целых знаковых четырехбайтовых числа и две позиции битов i и j (i<=j). Реализовать алгоритм вставки первых (j - i + 1) битов второго числа в первое так, чтобы биты второго числа занимали позиции с бита i по бит j (биты нумеруются справа налево). Решение оформить в виде статического метода InsertNumberIntoAnother статического класса NumbersExtension. Разработать модульные тесты (NUnit и MS Unit Test - (DDT))) для тестирования метода. (Ниже схема-пояснение к алгоритму). Примерные тест-кейсы
namespace number_extension_day1
{
    public static class NumbersExtension
    {
        public static int InsertNumberIntoAnother(int first, int second, int i, int j)
        {
            if (i < 0 || i > 31 || j < 0 || j > 31 )
                throw new ArgumentOutOfRangeException(nameof(i),"i and j must be between 0 and 31"); //change nameof

            if (i > j)
                throw new ArgumentException("i must be less than or equal to j");
           
            int length = j - i + 1;

            uint mask = length == 32 ? uint.MaxValue : (1U << length) - 1; //00001111
            uint secondMask = (mask & (uint)second)<<i; // second: 01101010 => 00001010 => 00101000
            uint cleanMask = ~(mask << i);//11000011
            return (int)(((uint)first &  cleanMask) | secondMask);
        }
    }
}
