CREATE DATABASE CovidCaseDb;
GO

USE CovidCaseDb;
GO

CREATE TABLE CovidCases
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Department NVARCHAR(100) NOT NULL,
    Province NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(50) NOT NULL,
    ReportedCases INT NOT NULL,
    RecoveredCases INT NOT NULL,
    ActiveCases INT NOT NULL
);