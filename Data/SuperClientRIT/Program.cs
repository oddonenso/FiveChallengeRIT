using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Data.Tables;
using SuperClientRIT.Classes;

namespace SuperClientRIT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string baseAddress = "https://localhost:7143"; // Замените на ваш адрес API

            var drillBlockClient = new DrillBlockClient(baseAddress);
            var holeClient = new HoleClient(baseAddress);
            var drillBlockPointClient = new DrillBlockPointClient(baseAddress);
            var holePointClient = new HolePointClient(baseAddress);

            try
            {
                
                Console.WriteLine("Fetching DrillBlocks...");
                var drillBlocks = await drillBlockClient.GetDrillBlocksAsync();
                foreach (var drillBlock in drillBlocks)
                {
                    Console.WriteLine($"DrillBlock: {drillBlock.Id}, {drillBlock.Name}, {drillBlock.UpdateDate}");
                }

               
                var newDrillBlock = new DrillBlock
                {
                    Name = "New DrillBlock",
                    UpdateDate = DateTime.Now
                };
                var createdDrillBlock = await drillBlockClient.CreateDrillBlockAsync(newDrillBlock);
                Console.WriteLine($"Created DrillBlock: {createdDrillBlock.Id}, {createdDrillBlock.Name}, {createdDrillBlock.UpdateDate}");

                
                createdDrillBlock.Name = "Updated DrillBlock";
                await drillBlockClient.UpdateDrillBlockAsync(createdDrillBlock.Id, createdDrillBlock);
                Console.WriteLine($"Updated DrillBlock: {createdDrillBlock.Id}, {createdDrillBlock.Name}, {createdDrillBlock.UpdateDate}");

            
                await drillBlockClient.DeleteDrillBlockAsync(createdDrillBlock.Id);
                Console.WriteLine($"Deleted DrillBlock: {createdDrillBlock.Id}");

                
                Console.WriteLine("Fetching Holes...");
                var holes = await holeClient.GetHolesAsync();
                foreach (var hole in holes)
                {
                    Console.WriteLine($"Hole: {hole.Id}, {hole.Name}, {hole.DEPTH}");
                }

                
                var newHole = new Hole
                {
                    Name = "New Hole",
                    DrillBlockId = 1, 
                    DEPTH = 100.0
                };
                var createdHole = await holeClient.CreateHoleAsync(newHole);
                Console.WriteLine($"Created Hole: {createdHole.Id}, {createdHole.Name}, {createdHole.DEPTH}");

                // Пример обновления Hole
                createdHole.Name = "Updated Hole";
                await holeClient.UpdateHoleAsync(createdHole.Id, createdHole);
                Console.WriteLine($"Updated Hole: {createdHole.Id}, {createdHole.Name}, {createdHole.DEPTH}");

                // Пример удаления Hole
                await holeClient.DeleteHoleAsync(createdHole.Id);
                Console.WriteLine($"Deleted Hole: {createdHole.Id}");

                // Пример использования DrillBlockPointClient
                Console.WriteLine("Fetching DrillBlockPoints...");
                var drillBlockPoints = await drillBlockPointClient.GetDrillBlockPointsAsync();
                foreach (var drillBlockPoint in drillBlockPoints)
                {
                    Console.WriteLine($"DrillBlockPoint: {drillBlockPoint.Id}, {drillBlockPoint.X}, {drillBlockPoint.Y}, {drillBlockPoint.Z}");
                }

             
                var newDrillBlockPoint = new DrillBlockPoint
                {
                    DrillBlockId = 1, 
                    Sequence = 1,
                    X = 10.0,
                    Y = 20.0,
                    Z = 30.0
                };
                var createdDrillBlockPoint = await drillBlockPointClient.CreateDrillBlockPointAsync(newDrillBlockPoint);
                Console.WriteLine($"Created DrillBlockPoint: {createdDrillBlockPoint.Id}, {createdDrillBlockPoint.X}, {createdDrillBlockPoint.Y}, {createdDrillBlockPoint.Z}");

                // Пример обновления DrillBlockPoint
                createdDrillBlockPoint.X = 15.0;
                await drillBlockPointClient.UpdateDrillBlockPointAsync(createdDrillBlockPoint.Id, createdDrillBlockPoint);
                Console.WriteLine($"Updated DrillBlockPoint: {createdDrillBlockPoint.Id}, {createdDrillBlockPoint.X}, {createdDrillBlockPoint.Y}, {createdDrillBlockPoint.Z}");

                // Пример удаления DrillBlockPoint
                await drillBlockPointClient.DeleteDrillBlockPointAsync(createdDrillBlockPoint.Id);
                Console.WriteLine($"Deleted DrillBlockPoint: {createdDrillBlockPoint.Id}");

                // Пример использования HolePointClient
                Console.WriteLine("Fetching HolePoints...");
                var holePoints = await holePointClient.GetHolePointsAsync();
                foreach (var holePoint in holePoints)
                {
                    Console.WriteLine($"HolePoint: {holePoint.Id}, {holePoint.X}, {holePoint.Y}, {holePoint.Z}");
                }

                // Пример создания нового HolePoint
                var newHolePoint = new HolePoint
                {
                    HoleId = 1, // Замените на существующий HoleId
                    X = 10.0,
                    Y = 20.0,
                    Z = 30.0
                };
                var createdHolePoint = await holePointClient.CreateHolePointAsync(newHolePoint);
                Console.WriteLine($"Created HolePoint: {createdHolePoint.Id}, {createdHolePoint.X}, {createdHolePoint.Y}, {createdHolePoint.Z}");

                // Пример обновления HolePoint
                createdHolePoint.X = 15.0;
                await holePointClient.UpdateHolePointAsync(createdHolePoint.Id, createdHolePoint);
                Console.WriteLine($"Updated HolePoint: {createdHolePoint.Id}, {createdHolePoint.X}, {createdHolePoint.Y}, {createdHolePoint.Z}");

                // Пример удаления HolePoint
                await holePointClient.DeleteHolePointAsync(createdHolePoint.Id);
                Console.WriteLine($"Deleted HolePoint: {createdHolePoint.Id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                
            }
        }
    }
}
