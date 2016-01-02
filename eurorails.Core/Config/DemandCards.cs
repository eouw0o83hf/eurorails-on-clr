﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eurorails.Core.Config
{
    public class DemandCards
    {
        public static readonly IReadOnlyCollection<DemandCard> Values = new[]
        {
            new DemandCard(1, new LoadDemand("Cheese", "Berlin", 10), new LoadDemand("Bauxite", "Manchester", 31), new LoadDemand("Labor", "Luxembourg", 22)),
            new DemandCard(2, new LoadDemand("Fish", "Holland", 23), new LoadDemand("Ham", "Marseille", 37), new LoadDemand("Cars", "Leipzig", 8)),
            new DemandCard(3, new LoadDemand("Oranges", "London", 34), new LoadDemand("Chocolate", "Munchen", 7), new LoadDemand("Iron", "Lyon", 21)),
            new DemandCard(4, new LoadDemand("Copper", "Madrid", 46), new LoadDemand("Cheese", "Napoli", 23), new LoadDemand("Sheep", "Nantes", 15)),
            new DemandCard(5, new LoadDemand("Potatoes", "Milano", 24), new LoadDemand("Wood", "Praha", 18), new LoadDemand("Tobacco", "Newcastle", 51)),
            new DemandCard(6, new LoadDemand("Cattle", "Paris", 7), new LoadDemand("Coal", "Roma", 29), new LoadDemand("Cheese", "Oslo", 14)),
            new DemandCard(7, new LoadDemand("Hops", "Ruhr", 16), new LoadDemand("Tobacco", "Stockholm", 63), new LoadDemand("Imports", "Porto", 36)),
            new DemandCard(8, new LoadDemand("Flowers", "Wien", 18), new LoadDemand("Oil", "Torino", 24), new LoadDemand("Sheep", "Sarajevo", 44)),
            new DemandCard(9, new LoadDemand("Bauxite", "Berlin", 14), new LoadDemand("Potatoes", "Zurich", 20), new LoadDemand("Beer", "Sevilla", 48)),
            new DemandCard(10, new LoadDemand("Hops", "Holland", 16), new LoadDemand("Fish", "Warszawa", 38), new LoadDemand("Sheep", "Stuttgart", 30)),
            new DemandCard(11, new LoadDemand("Machinery", "London", 10), new LoadDemand("Cheese", "Barcelona", 21), new LoadDemand("Oranges", "Szczecin", 44)),
            new DemandCard(12, new LoadDemand("Labor", "Madrid", 42), new LoadDemand("Beer", "Antwerpen", 10), new LoadDemand("Marble", "Toulouse", 21)),
            new DemandCard(13, new LoadDemand("Hops", "Milano", 29), new LoadDemand("Cars", "Beograd", 19), new LoadDemand("Tobacco", "Valencia", 39)),
            new DemandCard(14, new LoadDemand("Wine", "Paris", 11), new LoadDemand("Copper", "Birmingham", 29), new LoadDemand("Steel", "Venezia", 19)),
            new DemandCard(15, new LoadDemand("Oil", "Ruhr", 18), new LoadDemand("Imports", "Budapest", 25), new LoadDemand("Sheep", "Wroclaw", 33)),
            new DemandCard(16, new LoadDemand("Cork", "Wien", 53), new LoadDemand("Ham", "Bruxelles", 24), new LoadDemand("China", "Aberdeen", 17)),
            new DemandCard(17, new LoadDemand("Wheat", "Berlin", 21), new LoadDemand("Wood", "Glasgow", 35), new LoadDemand("Marble", "Zagreb", 15)),
            new DemandCard(18, new LoadDemand("Beer", "London", 11), new LoadDemand("Oil", "Hamburg", 22), new LoadDemand("Tobacco", "Arhus", 44)),
            new DemandCard(19, new LoadDemand("Potatoes", "Holland", 12), new LoadDemand("Machinery", "Lisboa", 23), new LoadDemand("Cattle", "Belfast", 33)),
            new DemandCard(20, new LoadDemand("Wheat", "Madrid", 15), new LoadDemand("Marble", "Lodz", 27), new LoadDemand("Fish", "Bern", 37)),
            new DemandCard(21, new LoadDemand("Tourists", "Milano", 16), new LoadDemand("Ham", "Manchester", 35), new LoadDemand("Chocolate", "Bilbao", 24)),
            new DemandCard(22, new LoadDemand("Steel", "Paris", 6), new LoadDemand("Wheat", "Marseille", 8), new LoadDemand("Cattle", "Bordeaux", 7)),
            new DemandCard(23, new LoadDemand("Wheat", "Ruhr", 13), new LoadDemand("Tobacco", "Munchen", 22), new LoadDemand("Copper", "Cardiff", 31)),
            new DemandCard(24, new LoadDemand("Cattle", "Wien", 15), new LoadDemand("Coal", "Napoli", 33), new LoadDemand("Bauxite", "Bremen", 22)),
            new DemandCard(25, new LoadDemand("Chocolate", "Berlin", 13), new LoadDemand("Ham", "Roma", 35), new LoadDemand("Flowers", "Cork", 24)),
            new DemandCard(26, new LoadDemand("Oranges", "Holland", 33), new LoadDemand("Iron", "Praha", 17), new LoadDemand("Machinery", "Dublin", 25)),
            new DemandCard(27, new LoadDemand("Potatoes", "London", 16), new LoadDemand("Flowers", "Stockholm", 34), new LoadDemand("Cars", "Firenze", 9)),
            new DemandCard(28, new LoadDemand("Tourists", "Madrid", 35), new LoadDemand("Machinery", "Torino", 20), new LoadDemand("Wheat", "Frankfurt", 14)),
            new DemandCard(29, new LoadDemand("Fish", "Milano", 27), new LoadDemand("Labor", "Warszawa", 18), new LoadDemand("Coal", "Goteborg", 27)),
            new DemandCard(30, new LoadDemand("Potatoes", "Paris", 20), new LoadDemand("Fish", "Zurich", 38), new LoadDemand("China", "Kaliningrad", 17)),
            new DemandCard(31, new LoadDemand("Sheep", "Ruhr", 22), new LoadDemand("Wood", "Barcelona", 37), new LoadDemand("Cork", "Kobenhavn", 62)),
            new DemandCard(32, new LoadDemand("Wheat", "Wien", 21), new LoadDemand("Cattle", "Antwerpen", 11), new LoadDemand("Tobacco", "Krakow", 33)),
            new DemandCard(33, new LoadDemand("Tourists", "Berlin", 8), new LoadDemand("Machinery", "Beograd", 28), new LoadDemand("Iron", "Luxembourg", 18)),
            new DemandCard(34, new LoadDemand("Beer", "Holland", 7), new LoadDemand("Wine", "Birmingham", 19), new LoadDemand("Fish", "Leipzig", 30)),
            new DemandCard(35, new LoadDemand("Cattle", "London", 16), new LoadDemand("Ham", "Glasgow", 43), new LoadDemand("Wood", "Lyon", 28)),
            new DemandCard(36, new LoadDemand("Wine", "Madrid", 10), new LoadDemand("Steel", "Budapest", 22), new LoadDemand("Copper", "Nantes", 31)),
            new DemandCard(37, new LoadDemand("Labor", "Milano", 12), new LoadDemand("Coal", "Bruxelles", 19), new LoadDemand("Cork", "Newcastle", 55)),
            new DemandCard(38, new LoadDemand("Sheep", "Paris", 19), new LoadDemand("Tobacco", "Hamburg", 35), new LoadDemand("Cork", "Oslo", 73)),
            new DemandCard(39, new LoadDemand("Cattle", "Ruhr", 19), new LoadDemand("Cheese", "Lodz", 20), new LoadDemand("Cars", "Porto", 35)),
            new DemandCard(40, new LoadDemand("Chocolate", "Wien", 13), new LoadDemand("Bauxite", "Lisboa", 29), new LoadDemand("Potatoes", "Sarajevo", 22)),
            new DemandCard(41, new LoadDemand("Flowers", "Berlin", 11), new LoadDemand("Copper", "Manchester", 30), new LoadDemand("Tourists", "Sevilla", 48)),
            new DemandCard(42, new LoadDemand("Labor", "Holland", 23), new LoadDemand("Oranges", "Marseille", 18), new LoadDemand("Fish", "Stuttgart", 33)),
            new DemandCard(43, new LoadDemand("Marble", "London", 31), new LoadDemand("Iron", "Munchen", 26), new LoadDemand("Wine", "Szczecin", 12)),
            new DemandCard(44, new LoadDemand("Bauxite", "Madrid", 20), new LoadDemand("Tourists", "Napoli", 32), new LoadDemand("Sheep", "Toulouse", 11)),
            new DemandCard(45, new LoadDemand("Machinery", "Milano", 20), new LoadDemand("Oranges", "Praha", 43), new LoadDemand("Beer", "Valencia", 35)),
            new DemandCard(46, new LoadDemand("Flowers", "Paris", 8), new LoadDemand("Tourists", "Roma", 28), new LoadDemand("Oil", "Wroclaw", 19)),
            new DemandCard(47, new LoadDemand("Oranges", "Ruhr", 33), new LoadDemand("Imports", "Stockholm", 28), new LoadDemand("Wood", "Venezia", 15)),
            new DemandCard(48, new LoadDemand("Sheep", "Wien", 38), new LoadDemand("Tourists", "Torino", 19), new LoadDemand("Bauxite", "Arhus", 26)),
            new DemandCard(49, new LoadDemand("Tobacco", "Berlin", 32), new LoadDemand("Iron", "Antwerpen", 14), new LoadDemand("Oranges", "Aberdeen", 53)),
            new DemandCard(50, new LoadDemand("Cars", "Holland", 10), new LoadDemand("Tobacco", "Zurich", 22), new LoadDemand("Cheese", "Zagreb", 19)),
            new DemandCard(51, new LoadDemand("Chocolate", "London", 10), new LoadDemand("Oil", "Warszawa", 21), new LoadDemand("Wine", "Belfast", 33)),
            new DemandCard(52, new LoadDemand("China", "Madrid", 39), new LoadDemand("Steel", "Beograd", 28), new LoadDemand("Imports", "Bern", 11)),
            new DemandCard(53, new LoadDemand("Ham", "Milano", 26), new LoadDemand("Coal", "Barcelona", 32), new LoadDemand("Hops", "Dublin", 12)),
            new DemandCard(54, new LoadDemand("Wood", "Paris", 32), new LoadDemand("Imports", "Birmingham", 14), new LoadDemand("Cork", "Firenze", 44)),
            new DemandCard(55, new LoadDemand("Potatoes", "Ruhr", 11), new LoadDemand("Cork", "Budapest", 60), new LoadDemand("China", "Goteborg", 25)),
            new DemandCard(56, new LoadDemand("Imports", "Wien", 19), new LoadDemand("Labor", "Bruxelles", 26), new LoadDemand("Marble", "Cardiff", 35)),
            new DemandCard(57, new LoadDemand("Oranges", "Berlin", 42), new LoadDemand("Steel", "Glasgow", 13), new LoadDemand("China", "Bordeaux", 26)),
            new DemandCard(58, new LoadDemand("Marble", "Holland", 25), new LoadDemand("Coal", "Hamburg", 12), new LoadDemand("Wood", "Bilbao", 44)),
            new DemandCard(59, new LoadDemand("Wine", "London", 16), new LoadDemand("Chocolate", "Lisboa", 40), new LoadDemand("Hops", "Frankfurt", 21)),
            new DemandCard(60, new LoadDemand("Machinery", "Madrid", 11), new LoadDemand("Sheep", "Lodz", 36), new LoadDemand("Imports", "Cork", 27)),
            new DemandCard(61, new LoadDemand("Cheese", "Milano", 7), new LoadDemand("Chocolate", "Manchester", 17), new LoadDemand("Wood", "Bremen", 25)),
            new DemandCard(62, new LoadDemand("Coal", "Paris", 13), new LoadDemand("Fish", "Munchen", 38), new LoadDemand("Flowers", "Kaliningrad", 25)),
            new DemandCard(63, new LoadDemand("Cork", "Ruhr", 44), new LoadDemand("Cars", "Marseille", 10), new LoadDemand("Cattle", "Kobenhavn", 28)),
            new DemandCard(64, new LoadDemand("Marble", "Wien", 16), new LoadDemand("Cork", "Napoli", 52), new LoadDemand("Steel", "Krakow", 20)),
            new DemandCard(65, new LoadDemand("Oil", "Berlin", 23), new LoadDemand("Beer", "Stockholm", 36), new LoadDemand("Wheat", "Luxembourg", 10)),
            new DemandCard(66, new LoadDemand("Oil", "Holland", 16), new LoadDemand("Wheat", "Roma", 20), new LoadDemand("Hops", "Leipzig", 25)),
            new DemandCard(67, new LoadDemand("Imports", "London", 10), new LoadDemand("Hops", "Praha", 27), new LoadDemand("Marble", "Lyon", 17)),
            new DemandCard(68, new LoadDemand("Cheese", "Madrid", 30), new LoadDemand("Chocolate", "Torino", 8), new LoadDemand("Iron", "Nantes", 19)),
            new DemandCard(69, new LoadDemand("Copper", "Milano", 20), new LoadDemand("Iron", "Warszawa", 8), new LoadDemand("Bauxite", "Newcastle", 35)),
            new DemandCard(70, new LoadDemand("China", "Paris", 13), new LoadDemand("Coal", "Zurich", 24), new LoadDemand("Copper", "Porto", 54)),
            new DemandCard(71, new LoadDemand("Oranges", "Wien", 42), new LoadDemand("Oil", "Antwerpen", 20), new LoadDemand("China", "Oslo", 30)),
            new DemandCard(72, new LoadDemand("Wood", "Ruhr", 27), new LoadDemand("Wine", "Barcelona", 11), new LoadDemand("Beer", "Sarajevo", 18)),
            new DemandCard(73, new LoadDemand("Cars", "Berlin", 10), new LoadDemand("Imports", "Beograd", 31), new LoadDemand("Machinery", "Sevilla", 21)),
            new DemandCard(74, new LoadDemand("Bauxite", "Holland", 22), new LoadDemand("Machinery", "Napoli", 32), new LoadDemand("Cattle", "Toulouse", 11)),
            new DemandCard(75, new LoadDemand("Copper", "London", 25), new LoadDemand("Ham", "Praha", 13), new LoadDemand("Flowers", "Valencia", 34)),
            new DemandCard(76, new LoadDemand("Hops", "Madrid", 37), new LoadDemand("Ham", "Budapest", 14), new LoadDemand("Iron", "Stuttgart", 22)),
            new DemandCard(77, new LoadDemand("Steel", "Milano", 13), new LoadDemand("Machinery", "Glasgow", 26), new LoadDemand("Tobacco", "Szczecin", 36)),
            new DemandCard(78, new LoadDemand("Labor", "Paris", 25), new LoadDemand("Beer", "Hamburg", 9), new LoadDemand("Tourists", "Venezia", 19)),
            new DemandCard(79, new LoadDemand("China", "Ruhr", 7), new LoadDemand("Wheat", "Lisboa", 26), new LoadDemand("Cork", "Wroclaw", 59)),
            new DemandCard(80, new LoadDemand("Potatoes", "Wien", 9), new LoadDemand("Oranges", "Bruxelles", 29), new LoadDemand("China", "Belfast", 15)),
            new DemandCard(81, new LoadDemand("Steel", "Berlin", 8), new LoadDemand("Labor", "Manchester", 36), new LoadDemand("Ham", "Zagreb", 18)),
            new DemandCard(82, new LoadDemand("Iron", "Holland", 11), new LoadDemand("Potatoes", "Marseille", 32), new LoadDemand("Ham", "Arhus", 22)),
            new DemandCard(83, new LoadDemand("Fish", "London", 6), new LoadDemand("Hops", "Munchen", 29), new LoadDemand("Wine", "Bilbao", 8)),
            new DemandCard(84, new LoadDemand("Flowers", "Madrid", 35), new LoadDemand("Beer", "Birmingham", 11), new LoadDemand("Labor", "Bern", 20)),
            new DemandCard(85, new LoadDemand("Wood", "Milano", 17), new LoadDemand("Fish", "Lodz", 37), new LoadDemand("Chocolate", "Aberdeen", 29)),
            new DemandCard(86, new LoadDemand("Ham", "Paris", 27), new LoadDemand("Wine", "Roma", 22), new LoadDemand("Bauxite", "Bordeaux", 13)),
            new DemandCard(87, new LoadDemand("Tobacco", "Ruhr", 31), new LoadDemand("Marble", "Stockholm", 55), new LoadDemand("Tourists", "Cork", 17)),
            new DemandCard(88, new LoadDemand("Cars", "Wien", 7), new LoadDemand("Copper", "Torino", 24), new LoadDemand("Cheese", "Cardiff", 15)),
            new DemandCard(89, new LoadDemand("Cattle", "Berlin", 17), new LoadDemand("Oil", "Zurich", 25), new LoadDemand("Iron", "Goteborg", 11)),
            new DemandCard(90, new LoadDemand("Wood", "Holland", 29), new LoadDemand("Steel", "Warszawa", 19), new LoadDemand("Coal", "Dublin", 12)),
            new DemandCard(91, new LoadDemand("Coal", "Madrid", 37), new LoadDemand("Labor", "Antwerpen", 26), new LoadDemand("Wheat", "Firenze", 17)),
            new DemandCard(92, new LoadDemand("Bauxite", "London", 25), new LoadDemand("Sheep", "Barcelona", 10), new LoadDemand("Cork", "Frankfurt", 46)),
            new DemandCard(93, new LoadDemand("Flowers", "Milano", 19), new LoadDemand("Sheep", "Beograd", 51), new LoadDemand("Fish", "Bremen", 25)),
            new DemandCard(94, new LoadDemand("Beer", "Paris", 11), new LoadDemand("Cheese", "Budapest", 21), new LoadDemand("Chocolate", "Kaliningrad", 27)),
            new DemandCard(95, new LoadDemand("Marble", "Ruhr", 22), new LoadDemand("Hops", "Marseille", 29), new LoadDemand("Imports", "Kobenhavn", 13)),
            new DemandCard(96, new LoadDemand("China", "Wien", 9), new LoadDemand("Potatoes", "Birmingham", 15), new LoadDemand("Flowers", "Krakow", 23)),
            new DemandCard(97, new LoadDemand("Wine", "Antwerpen", 10), new LoadDemand("Copper", "Glasgow", 38), new LoadDemand("China", "Lyon", 23)),
            new DemandCard(98, new LoadDemand("Cattle", "Beograd", 27), new LoadDemand("Beer", "Lisboa", 46), new LoadDemand("Coal", "Luxembourg", 19)),
            new DemandCard(99, new LoadDemand("Cars", "Barcelona", 19), new LoadDemand("Marble", "Hamburg", 27), new LoadDemand("Coal", "Newcastle", 13)),
            new DemandCard(100, new LoadDemand("Oranges", "Birmingham", 38), new LoadDemand("Bauxite", "Lodz", 12), new LoadDemand("Tourists", "Nantes", 17)),
            new DemandCard(101, new LoadDemand("Steel", "Bruxelles", 6), new LoadDemand("Cheese", "Manchester", 13), new LoadDemand("Cork", "Leipzig", 52)),
            new DemandCard(102, new LoadDemand("Oil", "Budapest", 8), new LoadDemand("Copper", "Bruxelles", 19), new LoadDemand("Tourists", "Oslo", 30)),
            new DemandCard(103, new LoadDemand("Imports", "Glasgow", 24), new LoadDemand("Bauxite", "Munchen", 14), new LoadDemand("Chocolate", "Porto", 35)),
            new DemandCard(104, new LoadDemand("Ham", "Hamburg", 17), new LoadDemand("Marble", "Napoli", 10), new LoadDemand("Flowers", "Sarajevo", 31)),
            new DemandCard(105, new LoadDemand("Wheat", "Manchester", 24), new LoadDemand("Wine", "Praha", 6), new LoadDemand("Cattle", "Sevilla", 32)),
            new DemandCard(106, new LoadDemand("Cattle", "Lodz", 24), new LoadDemand("Iron", "Roma", 40), new LoadDemand("Labor", "Stuttgart", 16)),
            new DemandCard(107, new LoadDemand("Sheep", "Lisboa", 17), new LoadDemand("Potatoes", "Stockholm", 29), new LoadDemand("Beer", "Szczecin", 9)),
            new DemandCard(108, new LoadDemand("Tobacco", "Marseille", 21), new LoadDemand("Bauxite", "Warszawa", 14), new LoadDemand("Cork", "Aberdeen", 63)),
            new DemandCard(109, new LoadDemand("Oil", "Munchen", 19), new LoadDemand("Machinery", "Praha", 12), new LoadDemand("Tourists", "Valencia", 35)),
            new DemandCard(110, new LoadDemand("Cars", "Antwerpen", 12), new LoadDemand("Oranges", "Zurich", 31), new LoadDemand("Flowers", "Belfast", 25)),
            new DemandCard(111, new LoadDemand("Labor", "Napoli", 23), new LoadDemand("Iron", "Barcelona", 31), new LoadDemand("Steel", "Wroclaw", 14)),
            new DemandCard(112, new LoadDemand("Chocolate", "Roma", 18), new LoadDemand("Ham", "Birmingham", 33), new LoadDemand("Hops", "Arhus", 27)),
            new DemandCard(113, new LoadDemand("Copper", "Stockholm", 36), new LoadDemand("Beer", "Beograd", 17), new LoadDemand("China", "Toulouse", 26)),
            new DemandCard(114, new LoadDemand("Steel", "Torino", 16), new LoadDemand("Cheese", "Bruxelles", 5), new LoadDemand("Imports", "Zagreb", 23)),
            new DemandCard(115, new LoadDemand("Wood", "Warszawa", 24), new LoadDemand("Beer", "Torino", 12), new LoadDemand("Tobacco", "Bilbao", 38)),
            new DemandCard(116, new LoadDemand("Wine", "Zurich", 10), new LoadDemand("Fish", "Budapest", 42), new LoadDemand("Wheat", "Cardiff", 22)),
            new DemandCard(117, new LoadDemand("Potatoes", "Antwerpen", 17), new LoadDemand("Chocolate", "Glasgow", 25), new LoadDemand("Fish", "Venezia", 42)),
            new DemandCard(118, new LoadDemand("Tourists", "Barcelona", 29), new LoadDemand("Copper", "Hamburg", 12), new LoadDemand("Cars", "Bordeaux", 19)),
            new DemandCard(119, new LoadDemand("Wheat", "Beograd", 32), new LoadDemand("Labor", "Lisboa", 55), new LoadDemand("Iron", "Bremen", 17)),
            new DemandCard(120, new LoadDemand("Cheese", "Birmingham", 12), new LoadDemand("Hops", "Lodz", 35), new LoadDemand("Potatoes", "Bern", 21)),
            new DemandCard(121, new LoadDemand("Cars", "Bruxelles", 12), new LoadDemand("Imports", "Marseille", 20), new LoadDemand("Machinery", "Cork", 30)),
            new DemandCard(122, new LoadDemand("Wood", "Budapest", 12), new LoadDemand("Oranges", "Manchester", 40), new LoadDemand("Oil", "Frankfurt", 23)),
            new DemandCard(123, new LoadDemand("Coal", "Glasgow", 17), new LoadDemand("Oranges", "Munchen", 36), new LoadDemand("China", "Firenze", 22)),
            new DemandCard(124, new LoadDemand("Cork", "Hamburg", 51), new LoadDemand("Imports", "Napoli", 33), new LoadDemand("Cheese", "Dublin", 19)),
            new DemandCard(125, new LoadDemand("Flowers", "Lisboa", 44), new LoadDemand("Steel", "Praha", 12), new LoadDemand("Sheep", "Goteborg", 33)),
            new DemandCard(126, new LoadDemand("Wood", "Lodz", 22), new LoadDemand("Cars", "Roma", 13), new LoadDemand("Bauxite", "Kobenhavn", 30)),
            new DemandCard(127, new LoadDemand("Machinery", "Manchester", 18), new LoadDemand("Wheat", "Stockholm", 46), new LoadDemand("Oil", "Kaliningrad", 27)),
            new DemandCard(128, new LoadDemand("Sheep", "Marseille", 18), new LoadDemand("Tourists", "Stockholm", 33), new LoadDemand("Fish", "Krakow", 40)),
            new DemandCard(129, new LoadDemand("Cars", "Lisboa", 30), new LoadDemand("Tobacco", "Warszawa", 39), new LoadDemand("Marble", "Leipzig", 22)),
            new DemandCard(130, new LoadDemand("Wine", "Napoli", 25), new LoadDemand("Sheep", "Praha", 35), new LoadDemand("China", "Luxembourg", 12)),
            new DemandCard(131, new LoadDemand("Iron", "Zurich", 24), new LoadDemand("Wheat", "Aberdeen", 37), new LoadDemand("Tourists", "Kobenhavn", 18)),
            new DemandCard(132, new LoadDemand("Potatoes", "Roma", 32), new LoadDemand("Oil", "Arhus", 15), new LoadDemand("Cars", "Nantes", 51)),
            new DemandCard(133, new LoadDemand("Bauxite", "Torino", 11), new LoadDemand("Hops", "Belfast", 17), new LoadDemand("Flowers", "Oslo", 30)),
            new DemandCard(134, new LoadDemand("Ham", "Torino", 29), new LoadDemand("Fish", "Bilbao", 12), new LoadDemand("Chocolate", "Newcastle", 21)),
            new DemandCard(135, new LoadDemand("Wine", "Warszawa", 12), new LoadDemand("Tobacco", "Bern", 23), new LoadDemand("Steel", "Porto", 37)),
            new DemandCard(136, new LoadDemand("China", "Zurich", 13), new LoadDemand("Oil", "Bremen", 24), new LoadDemand("Oranges", "Sarajevo", 46)),
            new DemandCard(137, new LoadDemand("Copper", "Antwerpen", 19), new LoadDemand("Labor", "Bordeaux", 34), new LoadDemand("Flowers", "Sevilla", 46)),
            new DemandCard(138, new LoadDemand("Cattle", "Barcelona", 17), new LoadDemand("Labor", "Cardiff", 38), new LoadDemand("Ham", "Stuttgart", 21)),
            new DemandCard(139, new LoadDemand("Potatoes", "Beograd", 20), new LoadDemand("Cattle", "Cork", 32), new LoadDemand("Machinery", "Szczecin", 9)),
            new DemandCard(140, new LoadDemand("Marble", "Birmingham", 35), new LoadDemand("Wood", "Krakow", 18), new LoadDemand("Iron", "Toulouse", 26)),
            new DemandCard(141, new LoadDemand("Beer", "Bruxelles", 10), new LoadDemand("Copper", "Firenze", 24), new LoadDemand("Steel", "Valencia", 31)),
            new DemandCard(142, new LoadDemand("Machinery", "Budapest", 22), new LoadDemand("Coal", "Frankfurt", 15), new LoadDemand("Cork", "Venezia", 46)),
            new DemandCard(143, new LoadDemand("Wine", "Glasgow", 28), new LoadDemand("Marble", "Goteborg", 46), new LoadDemand("Cheese", "Wroclaw", 17)),
            new DemandCard(144, new LoadDemand("Cattle", "Dublin", 27), new LoadDemand("Cork", "Lyon", 33), new LoadDemand("Chocolate", "Zagreb", 18)),
            new DemandCard(145, new LoadDemand("Coal", "Munchen", 15), new LoadDemand("Hops", "Kaliningrad", 39), new LoadDemand("Labor", "Arhus", 28)),
            new DemandCard(146, new LoadDemand("Imports", "Lodz", 16), new LoadDemand("Sheep", "Hamburg", 27), new LoadDemand("Hops", "Stockholm", 48))
        };
    }
}
