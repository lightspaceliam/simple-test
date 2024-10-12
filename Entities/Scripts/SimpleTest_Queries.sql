/*
    Simple Test:
        1. Deletes
        2. Reads
        3. Query
*/
DELETE FROM StudentFaculty
DELETE FROM Students
DELETE FROM Faculties

SELECT  *
FROM    Students
SELECT  *
FROM    Faculties
SELECT  *
FROM    StudentFaculty


SELECT  CONCAT(S.FirstName, ' ', S.LastName) AS 'StudnetName'
        , F.Name
FROM    Faculties AS F
        INNER JOIN StudentFaculty AS SF
            ON F.Id = SF.FacultyId
        INNER JOIN Students AS S
            ON SF.StudentId = S.Id
WHERE   F.Name = 'Medicine'