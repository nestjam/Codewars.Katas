﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterpreterKata;

namespace UnitTestProject.SimpleInteractiveInterpreter
{
    [TestClass]
    public class InterpreterTest
    {
        private static void check(ref Interpreter interpret, string inp, double? res)
        {
            double? result = -9999.99;
            try { result = interpret.input(inp); } catch (Exception) { result = null; }
            if (result != res) Assert.Fail("input(\"" + inp + "\") == <" + res + "> and not <" + result + "> => wrong solution, aborted!"); else Console.WriteLine("input(\"" + inp + "\") == <" + res + "> was ok");
        }

        [TestMethod]
        public void BasicArithmeticTests()
        {
            Interpreter interpret = new Interpreter();
            check(ref interpret, "1 + 1", 2);
            check(ref interpret, "2 - 1", 1);
            check(ref interpret, "2 * 3", 6);
            check(ref interpret, "8 / 4", 2);
            check(ref interpret, "7 % 4", 3);
        }

        [TestMethod]
        public void VariablesTests()
        {
            Interpreter interpret = new Interpreter();
            check(ref interpret, "x = 1", 1);
            check(ref interpret, "x", 1);
            check(ref interpret, "x + 3", 4);
            check(ref interpret, "y", null);
        }

        [TestMethod]
        public void FunctionsTests()
        {
            Interpreter interpret = new Interpreter();
            check(ref interpret, "fn avg x y => (x + y) / 2", null);
            check(ref interpret, "avg 4 2", 3);
            check(ref interpret, "avg 7", null);
            check(ref interpret, "avg 7 2 4", null);
        }

        [TestMethod]
        public void ConflictsTests()
        {
            Interpreter interpret = new Interpreter();
            check(ref interpret, "fn x x => 0", null);
            check(ref interpret, "fn avg => 0", null);
            check(ref interpret, "avg = 5", null);
        }

        [TestMethod]
        public void DescriptionCases()
        {
            Interpreter interpret = new Interpreter();
            check(ref interpret, "x = 10 + (y = 1)", 11);
            check(ref interpret, "y", 1);

            check(ref interpret, "fn echo x => x", null);
            check(ref interpret, "fn add x y => x + y", null);
            check(ref interpret, "add echo 4 echo 3", 7);
        }

        [TestMethod]
        public void Case1()
        {
            Interpreter interpret = new Interpreter();
            check(ref interpret, "x = 10", 10);
            check(ref interpret, "fn echo x => x", null);
            check(ref interpret, "echo 9", 9);
        }
    }
}
