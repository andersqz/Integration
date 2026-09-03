
namespace Integration.Application.Utils
{
    public static class Util
    {
        public static DateOnly? ConverterData(int valor)
        {
            if (valor == 0)
                return null;

            return DateOnly.FromDateTime(new DateTime(1800, 12, 28).AddDays(valor));
        }

        public static int ConverterDataParaInt(DateOnly data)
        {
            var dataBase = new DateOnly(1800, 12, 28);

            return data.DayNumber - dataBase.DayNumber;
        }

    }
}