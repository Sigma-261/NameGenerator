


using NameGenerator;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

string[] names = { "Tōhoku", "Akita", "Aomori", "Fukushima", "Iwate", "Miyagi", "Yamagata", "Kantō", "Chiba", "Gunma", "Ibaraki", "Kanagawa", "Saitama", "Tochigi", "Tōkyō", "Chūbu", "Aichi", "Fukui", "Gifu", "Ishikawa", "Nagano", "Niigata", "Shizuoka", "Toyama", "Yamanashi", "Kansai", "Kinki", "Hyōgo", "Kyōto", "Mie", "Nara", "Ōsaka", "Shiga", "Wakayama", "Chūgoku", "Hiroshima", "Okayama", "Shimane", "Tottori", "Yamaguchi", "Shikoku", "Ehime", "Kagawa", "Kōchi", "Tokushima", "Kyūshū", "Fukuoka", "Kagoshima", "Kumamoto,", "Miyazaki", "Nagasaki", "Ōita", "Okinawa", "Saga" };

MarkovGenerator generator = new MarkovGenerator();
generator.Init(names);

List<string> seedsAr = new List<string>();
int num = 20;
for (int i = 0; i < num; i++)
{
    seedsAr.Add(generator.Generate());
    Console.WriteLine(seedsAr[i]);
}

