USE master
GO

IF (EXISTS (SELECT name FROM master.dbo.sysdatabases 
WHERE name = 'UDDATADB'))
BEGIN
    ALTER DATABASE UDDATADB set single_user with rollback immediate
    DROP DATABASE UDDATADB
END
GO

CREATE DATABASE UDDATADB
GO
USE UDDATADB
GO

CREATE TABLE Student (
StudentId INT IDENTITY (1,1) PRIMARY KEY,
StudentName NVARCHAR(255),
DateOfBirth DATETIME
)

CREATE TABLE Teacher (
TeacherId INT IDENTITY (1,1) PRIMARY KEY,
TeacherName NVARCHAR (255),
DateOfBirth DATETIME
)

CREATE TABLE TeacherStudent (
TeacherId INT,
StudentId INT
)
GO
INSERT INTO TeacherStudent VALUES (1,1), (1,2), (1,3)
SELECT * FROM Teacher
SELECT * FROM Student
SELECT * FROM TeacherStudent

SELECT Student.StudentId, Student.StudentName, Student.DateOfBirth
FROM TeacherStudent 
JOIN Student  ON Student.StudentId = TeacherStudent.StudentId
WHERE TeacherStudent.TeacherId = 1