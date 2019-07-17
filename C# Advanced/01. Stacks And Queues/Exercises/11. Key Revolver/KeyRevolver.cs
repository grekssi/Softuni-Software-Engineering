using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacksexc5
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            var inputBullets = Console.ReadLine().Split(' ').Select(int.Parse);
            var inputLocks = Console.ReadLine().Split(' ').Select(int.Parse);
            int value = int.Parse(Console.ReadLine());
            int totalbulletsused = 0;
            var bullets = new Stack<int>(inputBullets);
            var locks = new Queue<int>(inputLocks);

            int bulletsShot = 0;
            while (bullets.Any() && locks.Any())
            {
                int currentLock = locks.Peek();
                int currentBullet = bullets.Pop();
                bulletsShot++;
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (bullets.Count > 0 && bulletsShot % gunBarrel == 0)
                {
                    totalbulletsused += bulletsShot;
                    bulletsShot = 0;
                    Console.WriteLine($"Reloading!");
                }
            }
            totalbulletsused += bulletsShot;
            if (locks.Count() > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");

            }
            else
            {
                Console.WriteLine($"{bullets.Count()} bullets left. Earned ${value - (totalbulletsused * bulletPrice)}");

            }
            
        }
    }
}
