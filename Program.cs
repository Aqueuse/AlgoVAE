using System.Reflection;

namespace AlgoVAE {
    public class Defi {
        private static void Main() {
            Test(nameof(SommeDesNombres), 5, 15);
        }

        //  Défi 1 : Somme des nombres entiers naturels
        //  par exemple :
        //
        //  1 + 2 + 3 + 4 + 5 = 15

        //  1 + 2 = 3
        //  3 + 3 = 6
        //  6 + 4 = 10
        //  10 + 5 = 15

        //  x + n

        private static int SommeDesNombres(int number) {
            int incrementeur = 0;
            int incrementedNumber = 0;

            while (incrementeur <= number) {
                Console.WriteLine(incrementedNumber);
                incrementedNumber += incrementeur;
                incrementeur += 1;
            }

            return incrementedNumber;
        }

        private static void QuickTest(string methodName, int number)
        {
            MethodInfo? method = typeof(Defi).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if (method == null)
            {
                Console.WriteLine("⚠️ method not found");
                return;
            }

            object? result = method.Invoke(null, [number]);

            if (result == null)
            {
                Console.WriteLine("⚠️ the method returned null");
                return;
            }

            if (result is int)
                Console.WriteLine("result : " + result);
        }

        private static void Test(string methodName, int number, int expectedValue)        {
            MethodInfo? method = typeof(Defi).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if (method == null) {
                Console.WriteLine("⚠️ method not found");
                return;
            }

            object? result = method.Invoke(null, [number]);

            if (result == null) {
                Console.WriteLine("⚠️ the method returned null");
                return;
            }

            if (result is int intResult && intResult == expectedValue)
                Console.WriteLine("✅ success : " + result);
            else
                Console.WriteLine("❌ failed : " + result);
        }
    }    
}
