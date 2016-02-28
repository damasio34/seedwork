namespace Damasio34.Seedwork.Extensions
{
    public static class DecimalExtension
    {
        public static decimal Arrendondar2Casas(this decimal valor)
        {
            return valor.Arrendondar(2);
        }


        public static decimal Arrendondar3Casas(this decimal valor)
        {
            return valor.Arrendondar(3);
        }

        public static decimal Arrendondar4Casas(this decimal valor)
        {
            return valor.Arrendondar(4);
        }

        public static decimal Arrendondar(this decimal valor, int casasDecimais)
        {
            return decimal.Round(valor, casasDecimais);
        }
    }
}