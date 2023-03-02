﻿


using NameGenerator;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

//string[] names = { "Анастасия","Анна","Мария","Елена","Дарья","Алина","Ирина","Екатерина","Арина","Полина","Ольга","Юлия","Татьяна","Наталья","Виктория","Елизавета","Ксения","Милана","Вероника","Алиса","Валерия","Александра","Ульяна","Кристина","София","Марина","Светлана","Варвара","Софья","Диана","Яна","Кира","Ангелина","Маргарита","Ева","Алёна","Дарина","Карина","Василиса","Олеся","Аделина","Оксана","Таисия","Надежда","Евгения","Элина","Злата","Есения","Милена","Вера","Мирослава","Галина","Людмила","Валентина","Нина","Эмилия","Камилла","Альбина","Лилия","Любовь","Лариса","Эвелина","Инна","Агата","Амелия","Амина","Эльвира","Ярослава","Стефания","Регина","Алла","Виолетта","Лидия","Амалия","Наталия","Марьяна","Анжелика","Нелли","Влада","Виталина","Майя","Тамара","Мелания","Лиана","Василина","Зарина","Алия","Владислава","Самира","Антонина","Ника","Мадина","Наташа","Каролина","Снежана","Юлиана","Ариана","Эльмира","Ясмина","Жанна",
  //  "Александр","Дмитрий","Максим","Сергей","Андрей","Алексей","Артём","Илья","Кирилл","Михаил","Никита","Матвей","Роман","Егор","Арсений","Иван","Денис","Евгений","Даниил","Тимофей","Владислав","Игорь","Владимир","Павел","Руслан","Марк","Константин","Тимур","Олег","Ярослав","Антон","Николай","Глеб","Данил","Савелий","Вадим","Степан","Юрий","Богдан","Артур","Семен","Макар","Лев","Виктор","Елисей","Виталий","Вячеслав","Захар","Мирон","Дамир","Георгий","Давид","Платон","Анатолий","Григорий","Демид","Данила","Станислав","Василий","Федор","Родион","Леонид","Одиссей","Валерий","Святослав","Борис","Эдуард","Марат","Герман","Даниэль","Петр","Амир","Всеволод","Мирослав","Гордей","Артемий","Эмиль","Назар","Савва","Ян","Рустам","Игнат","Влад","Альберт","Тамерлан","Айдар","Роберт","Адель","Марсель","Ильдар","Самир","Тихон","Рамиль","Ринат","Радмир","Филипп","Арсен","Ростислав","Святогор","Яромир" };

string[] names = { "Hokkaidō", "Tōhoku", "Akita", "Aomori", "Fukushima", "Iwate", "Miyagi", "Yamagata", "Kantō", "Chiba", "Gunma", "Ibaraki", "Kanagawa", "Saitama", "Tochigi", "Tōkyō", "Chūbu", "Aichi", "Fukui", "Gifu", "Ishikawa", "Nagano", "Niigata", "Shizuoka", "Toyama", "Yamanashi", "Kansai", "Kinki", "Hyōgo", "Kyōto", "Mie", "Nara", "Ōsaka", "Shiga", "Wakayama", "Chūgoku", "Hiroshima", "Okayama", "Shimane", "Tottori", "Yamaguchi", "Shikoku", "Ehime", "Kagawa", "Kōchi", "Tokushima", "Kyūshū", "Fukuoka", "Kagoshima", "Kumamoto,", "Miyazaki", "Nagasaki", "Ōita", "Okinawa", "Saga" };



MarkovGenerator generator = new MarkovGenerator();
generator.Init(names);

List<string> seedsAr = new List<string>();
int num = 20;
for (int i = 0; i < num; i++)
{
    seedsAr.Add(generator.Generate());
    Console.WriteLine(seedsAr[i]);
}

