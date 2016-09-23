﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz
{
    [TestFixture]
    public class FizBuzzTests
    {
        private static readonly string[] _100FizzBuzz =
        {
            "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz",
            "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz",
            "Fizz", "22", "23", "Fizz", "Buzz", "26", "Fizz", "28", "29", "FizzBuzz",
            "31", "32", "Fizz", "34", "Buzz", "Fizz", "37", "38", "Fizz", "Buzz", "41",
            "Fizz", "43", "44", "FizzBuzz", "46", "47", "Fizz", "49", "Buzz",
            "Fizz", "52", "53", "Fizz", "Buzz", "56", "Fizz", "58", "59", "FizzBuzz",
            "61", "62", "Fizz", "64", "Buzz", "Fizz", "67", "68", "Fizz", "Buzz",
            "71", "Fizz", "73", "74", "FizzBuzz", "76", "77", "Fizz", "79", "Buzz",
            "Fizz", "82", "83", "Fizz", "Buzz", "86", "Fizz", "88", "89", "FizzBuzz",
            "91", "92", "Fizz", "94", "Buzz", "Fizz", "97", "98", "Fizz", "Buzz"
        };

        private static readonly List<string> _list = new List<string>();

        private static readonly IGenerator[] AllGenerators =
        {
            new ForLoopWithIfElse(_list.Add),
            new WithRuleEngine(_list.Add),
            new WithLinq(_list.Add),
            new ImplicitConversion(_list.Add)
        };

        [Test, TestCaseSource(nameof(AllGenerators))]
        public void TestGenerator(IGenerator generator)
        {
            _list.Clear();
            generator.Generate(100);
            _list.ShouldAllBeEquivalentTo(_100FizzBuzz);
        }
    }
}