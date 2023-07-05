using System.Data;

namespace ChallengeLibrary
{
    public static class MathematicalExpressionChallenge
    {
        //Implemente uma função que recebe uma string contendo uma expressão matemática simples(sem parênteses) e
        //retorne o resultado dessa expressão. Exemplo: "2 + 3 * 5" -> 17
        public static double ResolveMathematicalExpression(string expression)
        {
            string[] splitedExpression = expression.Split(' ');
            return ResolveMathematicalExpression(splitedExpression.ToList());
        }

        private static double ResolveMathematicalExpression(List<string> expression)
        {
            DataTable table = new DataTable();
            int indexOfOperator = expression.IndexOf("*");

            if(indexOfOperator == -1) 
            {
                string expressionText = string.Empty;
                foreach (var item in expression)
                {
                    expressionText += item + " ";
                }
                table.Columns.Add("expression", typeof(string), expressionText);
                DataRow finalRow = table.NewRow();
                table.Rows.Add(finalRow);
                return double.Parse((string)finalRow["expression"]);
            }
            
            table.Columns.Add("expression", typeof(string), $"{expression[indexOfOperator - 1]} {expression[indexOfOperator]} {expression[indexOfOperator + 1]}");
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            double result = double.Parse((string)row["expression"]);

            List<string> resultList = new List<string>();
            int i = 0;
            while (i < indexOfOperator - 1)
            {
                resultList.Add(expression[i]);
                i++;
            }

            resultList.Add(result.ToString());
            i = indexOfOperator + 2;

            while (i < expression.Count)
            {
                resultList.Add(expression[i]);
                i++;
            }

            if(resultList.Count > 1) { return ResolveMathematicalExpression(resultList); }

            return result;
        }
    }
}
