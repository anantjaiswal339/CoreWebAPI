
-----------2(a)-----------
SELECT City, COUNT(*) as TotalStudent 
FROM Student
WHERE City in ('Bangalore', 'Mysore', 'Hyderabad', 'Vijayawada')
GROUP BY City

-----------2(a) With More than 300-----------
SELECT City, COUNT(*) as TotalStudent 
FROM Student
WHERE City in ('Bangalore', 'Mysore', 'Hyderabad', 'Vijayawada')
GROUP BY City Having COUNT(*) > 300


-----------2(b)-----------
CREATE TABLE SubjectMaster(
	SubjectID int primary key identity(1,1),
	DepartmentID int,
	TotalMarks int,
	SubjectName nvarchar(100)
)

CREATE TABLE StudentMarks(
	StudentMarksID int primary key identity(1,1),
	StudentID int,
	SubjectID int,
	Marks int,
)

INSERT INTO SubjectMaster(SubjectName,TotalMarks)
VALUES ('eng',100), ('telugu',100), ('science',100),('math',100),('social',100)


INSERT INTO StudentMarks(StudentID,SubjectID,Marks) VALUES(2,1,65)
INSERT INTO StudentMarks(StudentID,SubjectID,Marks) VALUES(2,2,85)
INSERT INTO StudentMarks(StudentID,SubjectID,Marks) VALUES(2,3,50)
INSERT INTO StudentMarks(StudentID,SubjectID,Marks) VALUES(2,4,80)
INSERT INTO StudentMarks(StudentID,SubjectID,Marks) VALUES(2,5,75)
INSERT INTO StudentMarks(StudentID,SubjectID,Marks) VALUES(3,1,50)
INSERT INTO StudentMarks(StudentID,SubjectID,Marks) VALUES(3,4,80)
INSERT INTO StudentMarks(StudentID,SubjectID,Marks) VALUES(3,5,80)
INSERT INTO StudentMarks(StudentID,SubjectID,Marks) VALUES(4,1,40)
INSERT INTO StudentMarks(StudentID,SubjectID,Marks) VALUES(4,2,35)


------------Query to show all students who score more than 60% overall total marks------------------------
/*
	This "(SELECT SUM(TotalMarks) FROM SubjectMaster)" query is to get the sum of total marks of available subject
	In case any subject added/removed then also percentage will accurate with this query
*/

SELECT sm.StudentID,s.FirstName, (SUM(Marks)*100/(SELECT SUM(TotalMarks) FROM SubjectMaster)) as [Percentage] FROM StudentMarks sm
INNER JOIN Student s ON s.StudentID = sm.StudentID
GROUP BY sm.StudentID,s.FirstName HAVING (SUM(Marks)*100/(SELECT SUM(TotalMarks) FROM SubjectMaster)) >= 60




