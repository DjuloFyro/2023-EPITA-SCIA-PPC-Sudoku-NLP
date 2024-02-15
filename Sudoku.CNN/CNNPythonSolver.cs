﻿using System.Runtime.InteropServices;
using Python.Runtime;
using Sudoku.Shared;

namespace Sudoku.CNN;

public class CNNPythonSolver : PythonSolverBase
{
    public override SudokuGrid Solve(SudokuGrid s)
    {
        using (PyModule scope = Py.CreateScope())
        {
            // convert the Cells array object to a PyObject
            PyObject pyCells = s.Cells.ToPython();

            // create a Python variable "instance"
            scope.Set("instance", pyCells);
            
            // Create a new Path variable that holds the path model
            try
            {
                string modelPath = Path.Combine(Environment.CurrentDirectory, @".\Resources\", "model", "sudoku.model");
                Console.WriteLine($"model Path:\n{modelPath}");
                scope.Set("modelPath", modelPath);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
            // run the Python script
            string code = Resources.PythonSolver_py;
            scope.Exec(code);

            //Retrieve solved Sudoku variable
            var result = scope.Get("r");

            //Convert back to C# object
            var managedResult = result.As<int[][]>();
            //var convertesdResult = managedResult.Select(objList => objList.Select(o => (int)o).ToArray()).ToArray();
            return new Shared.SudokuGrid() { Cells = managedResult };
        }
        throw new NotImplementedException();
    }

    protected override void InitializePythonComponents()
    {
	    //declare your pip packages here
	    InstallPipModule("numpy");
		InstallPipModule("tensorflow");
		InstallPipModule("keras");

		base.InitializePythonComponents();
    }

}