namespace ChallengeLibrary
{
    public static class CleanListChallenge
    {
        //Implemente uma função que recebe uma lista de objetos e retorne uma nova lista apenas com os objetos únicos, ou seja, sem repetições.
        public static List<int> RemoveDuplicatedItems(List<int> list)
        {
            List<int> result = new List<int>();
            foreach (int item in list)
            {
                if (list.Count(c => c == item) == 1)
                    result.Add(item);
            }
            return result;
        }
    }
}
