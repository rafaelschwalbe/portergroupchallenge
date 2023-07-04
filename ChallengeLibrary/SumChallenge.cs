namespace ChallengeLibrary
{
    public static class SumChallenge
    {
        //Implemente uma função que recebe um array de inteiros e retorne a soma desses números.O array pode ter até 1 milhão de números.
        public static long SumIntArray(int[] array)
        {
            if (array.Length > 1000000)
                throw new ArgumentException("O tamanho máximo do array é de 1.000.000");

            return array.Sum();
        }

        //Como você lidou com a performance na implementação do desafio 2, considerando que o array pode ter até 1 milhão de números?
        //performance não me pareceu um problema dessa função, o que pode ocorrer com essa função é o valor da soma ultrapassar o long.MaxValue causando uma overflow exception
    }
}