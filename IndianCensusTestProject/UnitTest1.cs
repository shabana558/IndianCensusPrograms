using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IndianCensusPrograms;
using System.Collections.Generic;
using IndianCensusPrograms.DTO;

namespace IndianCensusTestProject
{
    [TestClass]
    public class IndianCensusTestClass
    {
        CSVAdapterFactory csv;
        Dictionary<string, CensusDTO> stateRecords;
        string IndiastateCensusPath = @"G:\shabana\IndianCensusPrograms\IndianCensusPrograms\IndianCensusPrograms\CSVFiles\IndianPopulation.csv";
        string GivenWrongFilePath = @"G:\shabana\IndianCensusPrograms\IndianCensusPrograms\IndianCensusPrograms\CSVFiles\IndiaStateCode1.csv";
        string WrongFilePath = @"G:\shabana\IndianCensusPrograms\IndianCensusPrograms\IndianCensusPrograms\CSVFiles\IndianPopulation.txt";
        string WrongDelimiterType = @"G:\shabana\IndianCensusPrograms\IndianCensusPrograms\IndianCensusPrograms\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string WrongHeaderType = @"G:\shabana\IndianCensusPrograms\IndianCensusPrograms\IndianCensusPrograms\CSVFiles\WrongIndiaSensusData.csv";
        [TestInitialize]
        public void setup()
        {
            csv = new CSVAdapterFactory();
            //totalRecords=new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }


        ///Testcase1.1
        ///Giving the correct path it should return the total count from the census
        [TestMethod]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            stateRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, IndiastateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");

            Assert.AreEqual(29, stateRecords.Count);
        }
        ///Testcase1.2
        ///Giving the wrong file path it should return custom Exception
        [TestMethod]
        public void GivenWrongFilePathReturnCustomException()
        {
            string expected = "File Not Found";
            try
            {
                stateRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, GivenWrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
                Assert.AreEqual(29, stateRecords.Count);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        ///Tc 1.2
        /// Giving the wrong file path it should return custom Exception
        [TestMethod]
        public void GivenWrongFilePathreturnCustomExceptionUsingAssertThrowMethod()
        {
            string expected = "File Not Found";
            var ex = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, GivenWrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, ex.Message);
            Console.WriteLine(ex.Message);

        }

        //Tc 1.3
        ///Giving the wrong file it should return custom Exception
        [TestMethod]
        public void GivenWrongFileTypeReturnCustomexception()
        {
            string expected = "Invalid file type";
            var ex = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, WrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, ex.Message);
            Console.WriteLine(ex.Message);

        }

        ///Tc 1.4
        ///Giving the wrong delimiter it should return custom exception
        [TestMethod]
        public void GivenWrongDelimiterReturnCustomException()
        {
            string expected = "File contains Wrong Delimiter";
            var ex = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, WrongDelimiterType, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, ex.Message);
            Console.WriteLine(ex.Message);
        }

        ///TC 1.5
        ///Giving the wrong headers it should return custom exception
        [TestMethod]
        public void GivenWrongFileHeadersReturnCustomException()
        {
            string expected = "Incorrect header in Data";
            var ex = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, WrongHeaderType, "state,population,AreaInsqkm,Densitypersqkm"));
            Assert.AreEqual(expected, ex.Message);
            Console.WriteLine(ex.Message);
        }
    }
}
