using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float healts = 100f;
            float damage = 15f;
            float defense = 100f;

            int fraction;
            int fractionEnemy;
            int berserk; // Режим берсерка 

            int strike = 0; // Ударить снова 


            // Проверяем фракцию игрока
            do
            {
                string input; // ввод клавиатуры - фраккция игрока

                Console.WriteLine("Из какой ты фракции?");
                Console.WriteLine(" 1 - Добро \n 2 - Зло \n 3 - Нейтральный \n");
                input = Console.ReadLine();
                int.TryParse(input, out fraction);

                //Console.WriteLine("Ты ввёл в консоль " + fraction);
            } while (fraction > 4 | fraction < 1);


            // Проверяем кого будем бить
            do
            {
                string input2;

                Console.WriteLine("\n\nМолодец! Кого будешь бить?");
                Console.WriteLine(" 1 - Добро \n 2 - Зло \n 3 - Нейтральный \n");
                input2 = Console.ReadLine();
                int.TryParse(input2, out fractionEnemy);

                //Console.WriteLine("Ты ввёл в консоль " + fractionForDamage);
            } while (fractionEnemy > 4 | fractionEnemy < 1);


            // Сколько урона пройдёт по фракции игрока
            if (fractionEnemy == 3 || fraction == 3)
            {
                damage *= 1f;

            }
            else if (fraction == fractionEnemy && fraction < 3 && fractionEnemy < 3)
            {
                damage /= 2f;

            }
            else if (fraction > fractionEnemy || fraction < fractionEnemy)
            {
                damage *= 1.5f;
            }

            // Бьём врага пока есть жизни
            do
            {

                // Если есть режим берсерка

                do
                {
                    string input3;

                    Console.WriteLine("\n\nСлушай!\nВключить режим берсерка?");
                    Console.WriteLine(" 1 - Да\n 2 - Нет \n");
                    input3 = Console.ReadLine();
                    int.TryParse(input3, out berserk);

                    //Console.WriteLine("Ты ввёл в консоль " + fractionForDamage);
                } while (berserk > 3 | berserk < 1);
                if (berserk == 1)
                {
                    damage *= 2f;
                    defense -= 80f;
                    if (healts < damage)
                    {
                        healts = damage;
                    }
                    Console.WriteLine("\nТы в режиме БЕРСЕРК нанёс урона " + damage + "\nУ врага осталось " + (healts -= damage));
                }
                else if (berserk == 2)
                {
                    damage *= 1f;
                    if (healts < damage)
                    {
                        healts = damage;
                    }
                    Console.WriteLine("\nТы нанёс урона " + damage + "\nУ врага осталось " + (healts -= damage));
                }

                while (strike < 1 || strike > 2)
                {
                    // Ударить снова
                    Console.WriteLine("\n\nХочешь ударить снова?\n 1 - Нет\n 2 - Да \n");
                    string input;

                    input = Console.ReadLine();
                    int.TryParse(input, out strike);
                    strike *= 1;
                } 

                if (strike == 1)
                    healts = 0;
                else if (strike == 2)
                    healts *= 1f;

            } while (healts > 0);

            Console.WriteLine("\n\nВраг повержен!!! ");









        }
    }
}
