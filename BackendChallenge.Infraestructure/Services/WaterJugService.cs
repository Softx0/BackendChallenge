using BackendChallenge.Application.WaterJug.Dto;
using BackendChallenge.Application.WaterJug.Interfaces;
using BackendChallenge.Application.WaterJug.Queries;
using BackendChallenge.Domain.Entities;
using BackendChallenge.Infraestructure.Common.Utils;
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
        private static void SetTheLargestAndSmallestJug(GetSolveWaterJugChallengeQuery getSolveWaterJugChallengeQuery, Jug jugLarge, Jug jugSmall)
        {
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
        }

        private static void SetEvenStep(int quantityWaterJugLarge, int quantityWaterJugSmall, bool isTransition, Jug jugLarge, Jug jugSmall, WaterJugResponseDto waterJugResponseDto, string step = null)
        {
            waterJugResponseDto.BucketOne.Bucket = jugLarge.Bucket;
            waterJugResponseDto.BucketOne.Value = quantityWaterJugLarge;

            waterJugResponseDto.BucketTwo.Bucket = jugSmall.Bucket;
            waterJugResponseDto.BucketTwo.Value = quantityWaterJugSmall;

            var explanation = isTransition ? $"Transfer bucket {jugLarge.Bucket} to bucket {jugSmall.Bucket}" : $"{step} {jugLarge.Bucket}";
            waterJugResponseDto.Explanation = explanation;
        }

        private static void SetOddStep(int quantityWaterJugLarge, int quantityWaterJugSmall, bool isTransition, Jug jugLarge, Jug jugSmall, WaterJugResponseDto waterJugResponseDto, string step = null)
        {
            waterJugResponseDto.BucketOne.Bucket = jugLarge.Bucket;
            waterJugResponseDto.BucketOne.Value = quantityWaterJugSmall;

            waterJugResponseDto.BucketTwo.Bucket = jugSmall.Bucket;
            waterJugResponseDto.BucketTwo.Value = quantityWaterJugLarge;

            var explanation = isTransition ? $"Transfer bucket {jugSmall.Bucket} to bucket {jugLarge.Bucket}" : $"{step} {jugSmall.Bucket}";
            waterJugResponseDto.Explanation = explanation;
        }

        private static List<WaterJugResponseDto> GetSolveStepsWaterJugChallenge(GetSolveWaterJugChallengeQuery getSolveWaterJugChallengeQuery)
        {
            List<WaterJugResponseDto> waterJugResponseDtoList = new();

            // Initialize two quantities jugs empties
            int quantityWaterJugLarge = 0;
            int quantityWaterJugSmall = 0;

            // Initialize two instances of Jug
            Jug jugLarge = new();
            Jug jugSmall = new();
            SetTheLargestAndSmallestJug(getSolveWaterJugChallengeQuery, jugLarge, jugSmall);

            // Utilizar el algoritmo de Euclides para encontrar la solución general
            while (quantityWaterJugLarge != getSolveWaterJugChallengeQuery.BucketZ &&
                   quantityWaterJugSmall != getSolveWaterJugChallengeQuery.BucketZ)
            {
                WaterJugResponseDto waterJugResponseDto = new();

                if (MathematicsUtils.GetEvenOrOddOfMCD(jugLarge, jugSmall) || (MathematicsUtils.MCD(jugSmall.Value, getSolveWaterJugChallengeQuery.BucketZ) == jugSmall.Value))
                {

                    if (quantityWaterJugLarge == 0)
                    {
                        quantityWaterJugLarge = jugSmall.Value;

                        string step = "Fill bucket ";
                        SetOddStep(quantityWaterJugLarge, quantityWaterJugSmall, false, jugLarge, jugSmall, waterJugResponseDto, step);

                        waterJugResponseDtoList.Add(waterJugResponseDto);
                    }
                    else if (quantityWaterJugSmall == jugLarge.Value)
                    {
                        quantityWaterJugSmall = 0;

                        string step = "Dumb/Pour bucket ";
                        SetOddStep(quantityWaterJugLarge, quantityWaterJugSmall, false, jugLarge, jugSmall, waterJugResponseDto, step);

                        waterJugResponseDtoList.Add(waterJugResponseDto);
                    }
                    else
                    {
                        int cantidad = Math.Min(quantityWaterJugLarge, jugLarge.Value - quantityWaterJugSmall);

                        quantityWaterJugLarge -= cantidad;
                        quantityWaterJugSmall += cantidad;

                        SetOddStep(quantityWaterJugLarge, quantityWaterJugSmall, true, jugLarge, jugSmall, waterJugResponseDto);

                        waterJugResponseDtoList.Add(waterJugResponseDto);
                    }
                }
                else
                {
                    if (quantityWaterJugLarge == 0)
                    {
                        quantityWaterJugLarge = jugLarge.Value;

                        string step = "Fill bucket";
                        SetEvenStep(quantityWaterJugLarge, quantityWaterJugSmall, false, jugLarge, jugSmall, waterJugResponseDto, step);

                        waterJugResponseDtoList.Add(waterJugResponseDto);
                    }
                    else if (quantityWaterJugSmall == jugSmall.Value)
                    {
                        quantityWaterJugSmall = 0;

                        string step = "Dumb/Pour bucket";
                        SetEvenStep(quantityWaterJugLarge, quantityWaterJugSmall, false, jugLarge, jugSmall, waterJugResponseDto, step);

                        waterJugResponseDtoList.Add(waterJugResponseDto);
                    }
                    else
                    {
                        int cantidad = Math.Min(quantityWaterJugLarge, jugSmall.Value - quantityWaterJugSmall);

                        quantityWaterJugLarge -= cantidad;
                        quantityWaterJugSmall += cantidad;

                        SetEvenStep(quantityWaterJugLarge, quantityWaterJugSmall, true, jugLarge, jugSmall, waterJugResponseDto);
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
