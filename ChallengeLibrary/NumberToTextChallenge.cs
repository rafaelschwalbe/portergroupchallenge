namespace ChallengeLibrary
{
    public static class NumberToTextChallenge
    {
        //Implemente uma função que recebe um número inteiro e retorne uma string com a representação por extenso desse número.Exemplo: 123 -> "cento e vinte e três"
        //Como você implementou a função que retorna a representação por extenso do número no desafio 1? Quais foram os principais desafios encontrados?

        public static string NumberToText(int number)
        {
            if (number == 0)
            {
                return "zero";
            }

            if (number == 100)
            {
                return "cem";
            }

            if (number == 1000000000)
            {
                return "um bilhão";
            }

            if (number < 0 || number > 1000000000)
            {
                return "Número fora do intervalo suportado.";
            }

            string[] units = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            string[] dozens = { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            string[] hundreds = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
            string[] thousands = { "", "mil", "milhão", "bilhão", "trilhão", "quadrilhão", "quintilhão", "sextilhão", "septilhão", "octilhão", "nonilhão", "decilhão" };

            if (number < 20)
            {
                return units[number];
            }

            if (number < 100)
            {
                int dozen = number / 10;
                int unit = number % 10;

                if (unit == 0)
                {
                    return dozens[dozen];
                }
                else
                {
                    return dozens[dozen] + " e " + units[unit];
                }
            }

            if (number < 1000)
            {
                int hundred = number / 100;
                int residue = number % 100;

                if (residue == 0)
                {
                    return hundreds[hundred];
                }
                else
                {
                    return hundreds[hundred] + " e " + NumberToText(residue);
                }
            }

            if (number < 1000000000)
            {
                for (int i = 1; i <= thousands.Length - 1; i++)
                {
                    int divisor = (int)Math.Pow(1000, i);
                    if (number < divisor * 1000)
                    {
                        int prefix = number / divisor;
                        int suffix = number % divisor;

                        string result = NumberToText(prefix) + " " + thousands[i];

                        if (suffix > 0)
                        {
                            result += " e " + NumberToText(suffix);
                        }

                        return result;
                    }
                }
            }

            return "Número fora do intervalo válido.";
        }

    }
}
