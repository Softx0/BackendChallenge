using BackendChallenge.Application.WaterJug.Dto;
using BackendChallenge.Application.WaterJug.Interfaces;
using BackendChallenge.Application.WaterJug.Queries;
using BackendChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendChallenge.Infraestructure.Services
{
    public class WaterJugService : IWaterJug
    {
        private static int MCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return MCD(b, a % b);
            }
        }
        private static bool getEvenOrOddOfMCD(Jug jugLarge, Jug jugSmall)
        {
            return MCD(jugLarge.Value, jugSmall.Value) % 2 == 0;
        }

        public static List<WaterJugResponseDto> GetSolveStepsWaterJugChallenge(GetSolveWaterJugChallengeQuery getSolveWaterJugChallengeQuery)
        {

            List<WaterJugResponseDto> waterJugResponseDtoList = new();

            // Initialize two quantities jugs empties
            int quantityWaterJugLarge = 0;
            int quantityWaterJugSmall = 0;
            int counter = 0;

            // Initialize two instances of Jug
            Jug jugLarge = new();
            Jug jugSmall = new();

            if (getSolveWaterJugChallengeQuery.BucketX > getSolveWaterJugChallengeQuery.BucketY)
            {

                jugLarge.Bucket = "X";
                jugLarge.Value = getSolveWaterJugChallengeQuery.BucketX;

                jugSmall.Bucket = "Y";
                jugSmall.Value = getSolveWaterJugChallengeQuery.BucketY;
            }
            else
            {
                jugLarge.Bucket = "Y";
                jugLarge.Value = getSolveWaterJugChallengeQuery.BucketY;

                jugSmall.Bucket = "X";
                jugSmall.Value = getSolveWaterJugChallengeQuery.BucketX;
            }

            // Utilizar el algoritmo de Euclides para encontrar la solución general
            while (quantityWaterJugLarge != getSolveWaterJugChallengeQuery.BucketZ &&
                   quantityWaterJugSmall != getSolveWaterJugChallengeQuery.BucketZ)
            {
                WaterJugResponseDto waterJugResponseDto = new WaterJugResponseDto();

                Console.WriteLine($"\nPote grande = {quantityWaterJugLarge}");
                Console.WriteLine($"Pote pequeño = {quantityWaterJugSmall}");
                Console.WriteLine($"Z = {getSolveWaterJugChallengeQuery.BucketZ}");

                Console.WriteLine(getEvenOrOddOfMCD(jugLarge, jugSmall)); // ME DEVUELVE TRUE SI ES PAR | ME DEVUELVE FALSE SI ES IMPAR

                if (!getEvenOrOddOfMCD(jugLarge, jugSmall))
                {
                    if (quantityWaterJugLarge == 0)
                    {
                        quantityWaterJugLarge = jugLarge.Value;
                        counter += 1;

                        waterJugResponseDto.BucketLarger.Bucket = jugLarge.Bucket;
                        waterJugResponseDto.BucketLarger.Value = quantityWaterJugLarge;

                        waterJugResponseDto.BucketSmaller.Bucket = jugSmall.Bucket;
                        waterJugResponseDto.BucketSmaller.Value = quantityWaterJugSmall;
                        waterJugResponseDto.Explanation = $"Fill bucket impar {jugLarge.Bucket}";

                        waterJugResponseDtoList.Add(waterJugResponseDto);

                        Console.WriteLine($" Paso #{counter} Bucket {jugLarge.Bucket} {quantityWaterJugLarge} Bucket {jugSmall.Bucket} {quantityWaterJugSmall} | Fill bucket {jugLarge.Bucket}\n");

                    }
                    else if (quantityWaterJugSmall == jugSmall.Value)
                    {
                        quantityWaterJugSmall = 0;
                        counter += 1;

                        waterJugResponseDto.BucketLarger.Bucket = jugLarge.Bucket;
                        waterJugResponseDto.BucketLarger.Value = quantityWaterJugLarge;

                        waterJugResponseDto.BucketSmaller.Bucket = jugSmall.Bucket;
                        waterJugResponseDto.BucketSmaller.Value = quantityWaterJugSmall;
                        waterJugResponseDto.Explanation = $"Dumb/Pour bucket {jugSmall.Bucket} ";

                        waterJugResponseDtoList.Add(waterJugResponseDto);

                        Console.WriteLine($"Paso #{counter} Pour {jugSmall.Bucket} | {jugSmall.Value} to {quantityWaterJugSmall} \n");

                    }
                    else
                    {
                        int cantidad = Math.Min(quantityWaterJugLarge, jugSmall.Value - quantityWaterJugSmall);

                        quantityWaterJugLarge -= cantidad;
                        quantityWaterJugSmall += cantidad;
                        counter += 1;

                        Console.WriteLine($"Paso #{counter} Bucket {jugLarge.Bucket} {quantityWaterJugLarge} Bucket {jugSmall.Bucket} {quantityWaterJugSmall} Transfer bucket {jugLarge.Bucket} to bucket {jugSmall.Bucket} \n\n");

                        waterJugResponseDto.BucketLarger.Bucket = jugLarge.Bucket;
                        waterJugResponseDto.BucketLarger.Value = quantityWaterJugLarge;

                        waterJugResponseDto.BucketSmaller.Bucket = jugSmall.Bucket;
                        waterJugResponseDto.BucketSmaller.Value = quantityWaterJugSmall;
                        waterJugResponseDto.Explanation = $"Transfer bucket {jugLarge.Bucket} to bucket {jugSmall.Bucket}";

                        waterJugResponseDtoList.Add(waterJugResponseDto);
                    }
                }
                else
                {
                    if (quantityWaterJugLarge == 0)
                    {
                        quantityWaterJugLarge = jugSmall.Value;
                        counter += 1;

                        waterJugResponseDto.BucketLarger.Bucket = jugLarge.Bucket;
                        waterJugResponseDto.BucketLarger.Value = quantityWaterJugSmall;

                        waterJugResponseDto.BucketSmaller.Bucket = jugSmall.Bucket;
                        waterJugResponseDto.BucketSmaller.Value = quantityWaterJugLarge;
                        waterJugResponseDto.Explanation = $"Fill bucket par {jugSmall.Bucket}";

                        waterJugResponseDtoList.Add(waterJugResponseDto);

                        Console.WriteLine($" Paso #{counter} Bucket {jugSmall.Bucket} {quantityWaterJugLarge} Bucket {jugLarge.Bucket} {quantityWaterJugSmall} | Fill bucket {jugSmall.Bucket}\n");

                    }
                    else if (quantityWaterJugSmall == jugLarge.Value)
                    {
                        quantityWaterJugSmall = 0;
                        counter += 1;

                        waterJugResponseDto.BucketLarger.Bucket = jugLarge.Bucket;
                        waterJugResponseDto.BucketLarger.Value = quantityWaterJugSmall;

                        waterJugResponseDto.BucketSmaller.Bucket = jugSmall.Bucket;
                        waterJugResponseDto.BucketSmaller.Value = quantityWaterJugLarge;
                        waterJugResponseDto.Explanation = $"Dumb/Pour bucket {jugSmall.Bucket} ";

                        waterJugResponseDtoList.Add(waterJugResponseDto);

                        Console.WriteLine($"Paso #{counter} Pour {jugLarge.Bucket} | {jugLarge.Value} to {quantityWaterJugSmall} \n");

                    }
                    else
                    {
                        int cantidad = Math.Min(quantityWaterJugLarge, jugLarge.Value - quantityWaterJugSmall);

                        quantityWaterJugLarge -= cantidad;
                        quantityWaterJugSmall += cantidad;
                        counter += 1;

                        Console.WriteLine($"Paso #{counter} Bucket {jugSmall.Bucket} {quantityWaterJugLarge} Bucket {jugLarge.Bucket} {quantityWaterJugSmall} Transfer bucket {jugSmall.Bucket} to bucket {jugLarge.Bucket} \n\n");

                        waterJugResponseDto.BucketLarger.Bucket = jugLarge.Bucket;
                        waterJugResponseDto.BucketLarger.Value = quantityWaterJugSmall;

                        waterJugResponseDto.BucketSmaller.Bucket = jugSmall.Bucket;
                        waterJugResponseDto.BucketSmaller.Value = quantityWaterJugLarge;
                        waterJugResponseDto.Explanation = $"Transfer bucket {jugSmall.Bucket} to bucket {jugLarge.Bucket}";

                        waterJugResponseDtoList.Add(waterJugResponseDto);
                    }
                }

            }

            return waterJugResponseDtoList;
        }

        public Task<List<WaterJugResponseDto>> GetSolveWaterJugChallenge(GetSolveWaterJugChallengeQuery getSolveWaterJugChallengeQuery)
        {
            return Task.FromResult(GetSolveStepsWaterJugChallenge(getSolveWaterJugChallengeQuery));
        }
    }
}
