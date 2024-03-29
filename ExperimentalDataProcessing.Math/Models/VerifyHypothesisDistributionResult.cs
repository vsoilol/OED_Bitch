﻿using System.Collections.Generic;

namespace ExperimentalDataProcessing.Math.Models
{
    public class VerifyHypothesisDistributionResult
    {
        public int IntervalsAmount { get; set; }

        /// <summary>
        ///     Критическое значение
        /// </summary>
        public double CriticalChiSquareValue { get; set; }

        /// <summary>
        ///     Критерий согласия
        /// </summary>
        public double CriterionOfConsent { get; set; }

        /// <summary>
        ///     Число степень свободы
        /// </summary>
        public int DegreesOfFreedom { get; set; }

        /// <summary>
        ///     Опровергается ли гипотеза
        /// </summary>
        public bool IsHypothesisRefuted { get; set; }

        public IEnumerable<IntervalHypothesisDistributionInfo> Intervals { get; set; }
    }
}